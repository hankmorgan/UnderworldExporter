using UnityEngine;
using System.Collections;

public class CutsceneAnimationFullscreen : HudAnimation {
	public bool PlayingSequence;
	private bool isFullScreen;

	//TODO:Move the definition of the frames into an extendable class so I can define cutscene scripts.
	//image arrays
	public float[] ImageTimes; //The time that the frame begins.
	public string[] ImageFrames; //The cut that plays at that point.
	public int[] ImageLoops;//How many times the image loops until fade to black.
	
	//Subtitle arrays
	public float[] SubsTimes; //The time that the subtitle appears.
	public int[] SubsStringIndices; //The string no to display.
	//To consider. Colour of the text.
	public float[] SubsDuration; //The duration of the string. Must be less than time to next sub.
	
	public float[] AudioTimes;//The time that the audio clip begins at.
	public string[] AudioClipName;//The clip to play at that time.
	
	public int StringBlockNo;    //What block the subtitles are drawn from
	
	public ScrollController mlCuts; //What control will print the subtitles
	//CutsceneLarge cutsPlayer;//What control will play the anim.
	public AudioSource aud; //What control will play the audio.
	
	public int currentFrameLoops;

	public override void Start ()
	{
		base.Start ();
		Begin ();
	}

	public void Begin()
	{
		//Starts a sequenced cutscene.
		playerUW.playerCam.cullingMask=0;//Stops the camera from rendering.
		chains.ActiveControl=5;
		chains.Refresh();
		isFullScreen= playerUW.playerHud.window.FullScreen;
		if (!isFullScreen)
		{
			playerUW.playerHud.window.SetFullScreen();
		}

		PlayingSequence=true;
		//Begin the image seq
		StartCoroutine(PlayCutsImageSequence());
		//Begin the subs seq
		StartCoroutine(PlayCutsSubtitle());
		//Begin the audio seq
		StartCoroutine(PlayCutsAudio());
	}
	
	IEnumerator PlayCutsImageSequence()
	{
		float currTime=0.0f;
		for (int i = 0; i<=ImageTimes.GetUpperBound(0); i++)
		{
			yield return new WaitForSeconds(ImageTimes[i]-currTime);   //Wait until it is time for the frame
			currTime = ImageTimes[i];                                   //For the next wait.
			currentFrameLoops = ImageLoops[i];
			SetAnimation= ImageFrames[i];
		}
		SetAnimation= "Anim_Base";//End of anim.
		PlayingSequence=false;
		PostAnimPlay();
		
	}
	
	public void Loop()
	{ //Handles the looping of frames for the images.
		switch (currentFrameLoops)
		{
		case -1://Loop forever until interupted. Assumes anim is already looping.
			break;
		case 0://Loop has completed. Switch to black anim
			SetAnimation= "cs000_n01";
			break;
		default:
			currentFrameLoops--;  //Assumes animation is already looping.
			break;
		}
	}
	
	IEnumerator PlayCutsSubtitle()
	{
		float currTime=0.0f;
		for (int i = 0; i<=SubsTimes.GetUpperBound(0); i++)
		{
			yield return new WaitForSeconds(SubsTimes[i]-currTime);
			currTime = SubsTimes[i]+SubsDuration[i];//The time the subtitle finishes at.
			mlCuts.Set("[FFFFFF]" + playerUW.StringControl.GetString(StringBlockNo, SubsStringIndices[i]));
			yield return new WaitForSeconds(SubsDuration[i]);
			mlCuts.Set("");//Clear the control.
		}
	}
	
	IEnumerator PlayCutsAudio()
	{
		float currTime=0.0f;
		for (int i = 0; i<=AudioTimes.GetUpperBound(0); i++)
		{
			yield return new WaitForSeconds(AudioTimes[i]-currTime);
			currTime = AudioTimes[i];
			//aud.play(AudioClipName[i]);
			aud.clip = Resources.Load <AudioClip>(AudioClipName[i]);
			aud.loop=false;
			aud.Play();
		}
	}
  



	/*Functions for handling the end of cutscene clip events*/
	public void PreAnimPlay()
	{//Called by events in certain animations when starting playing
		if (PlayingSequence==false)
		{
			playerUW.playerCam.cullingMask=0;//Stops the camera from rendering.
			chains.ActiveControl=5;
			chains.Refresh();
			isFullScreen= playerUW.playerHud.window.FullScreen;
			if (!isFullScreen)
			{
				playerUW.playerHud.window.SetFullScreen();
			}
		}		
		return;
	} 
	
	public void PostAnimPlay()
	{
		if (PlayingSequence==false)
		{
			if (!isFullScreen)
			{
				playerUW.playerHud.window.UnSetFullScreen();
			}
			playerUW.playerCam.cullingMask=HudAnimation.NormalCullingMask;
			chains.ActiveControl=0;
			chains.Refresh();
			SetAnimation= "Anim_Base";//Clears out the animation.
		}
		else
		{
			Loop ();
		}
	}
	
}

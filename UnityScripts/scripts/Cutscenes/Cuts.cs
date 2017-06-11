using UnityEngine;
using System.Collections;
/// <summary>
/// Base class for cutscene scripts.
/// </summary>
/// To Use Implement a start funcfion that sets up the arrays in the subclasses. See cutscene_intro.cs as an example
public class Cuts : GuiBase {
	

	public static CutsLoader filler;
    ///The times that the frames begin at
	protected float[] ImageTimes=new float[50]; 
	///The cut animation that plays at those points.
	protected string[] ImageFrames=new string[50]; 
	///How many times the image loops until fade to black.
	protected int[] ImageLoops=new int[50];
	
	//Subtitle arrays
	///The time that the subtitle appears.
	protected float[] SubsTimes=new float[50]; 
	///The string no to display.
	protected int[] SubsStringIndices=new int[50];
	///The duration of the string. Must be less than time to next sub.
	protected float[] SubsDuration=new float[50]; 

	//Speech audio arrays
	///The time that the audio clip begins at.
	protected float[] AudioTimes=new float[50];
	///The clip to play at that time.
	protected string[] AudioClipName=new string[50];
	
	///What block the subtitles are drawn from
	public int StringBlockNo;    
	
	///Number of images in the cutscene
	protected int noOfImages;
	///Number of subtitles in the cutscene
	protected int noOfSubs;
	///Number of audio clips
	protected int noOfAudioClips;
	
	/// <summary>
	/// Gets the filler animation. Used for black screens.
	/// </summary>
	/// <returns>The filler animation.</returns>
	public virtual string getFillerAnim()
	{
		switch(_RES)
		{
		case GAME_UWDEMO:
				return "CS011.N00";
		default:
				return "cs000_n01";
		}		
	}	

	/// <summary>
	/// Numbers of images.
	/// </summary>
	/// <returns>The of images.</returns>
	public int NoOfImages()
	{
		return noOfImages;
	}
	
	/// <summary>
	/// Gets the image time.
	/// </summary>
	/// <returns>The image time.</returns>
	/// <param name="index">Array index to return</param>
	public float getImageTime(int index)
	{
		return ImageTimes[index];
	}
	
	/// <summary>
	/// Gets the image loop number
	/// </summary>
	/// <returns>The image loops.</returns>
	/// <param name="index">Array index to return</param>
	public int getImageLoops(int index)
	{
		return ImageLoops[index];
	}

	/// <summary>
	/// Gets the image frame to display
	/// </summary>
	/// <returns>The image frame.</returns>
	/// <param name="index">Array index to return</param>
	public string getImageFrame(int index)
	{
		return ImageFrames[index];
	}
	

	/// <summary>
	/// Gets the number of subs.
	/// </summary>
	/// <returns>The no of subs.</returns>
	public int getNoOfSubs()
	{
		return  noOfSubs;
	}
	
	/// <summary>
	/// Gets the time the sub appears at
	/// </summary>
	/// <returns>The sub time.</returns>
	/// <param name="index">Array index to return</param>
	public float getSubTime(int index)
	{
		return SubsTimes[index];
	}
	
	/// <summary>
	/// Gets the string index of the sub to display
	/// </summary>
	/// <returns>The sub index.</returns>
	/// <param name="index">Array index to return</param>
	public int getSubIndex(int index)
	{
		return SubsStringIndices[index];
	}
	
	/// <summary>
	/// Gets the duration of the sub.
	/// </summary>
	/// <returns>The sub duration.</returns>
	/// <param name="index">Array index to return</param>
	public float getSubDuration(int index)
	{
		return SubsDuration[index];
	}
	
	/// <summary>
	/// Gets the no of audio clips to process
	/// </summary>
	/// <returns>The no of audio clips.</returns>
	public int getNoOfAudioClips()
	{
		return noOfAudioClips;
	}

	/// <summary>
	/// Gets the time the audio plays at.
	/// </summary>
	/// <returns>The audio time.</returns>
	/// <param name="index">Array index to return</param>
	public float getAudioTime(int index)
	{
		return AudioTimes[index];
	}
	
	/// <summary>
	/// Gets the audio clip.
	/// </summary>
	/// <returns>The audio clip.</returns>
	/// <param name="index">Array index to return</param>
	public string getAudioClip(int index)
	{
		return AudioClipName[index];
	}	

	/// <summary>
	/// Awake this instance and initialize the values for the cutscene
	/// </summary>
	public virtual void Awake()
	{
		if (filler==null)
		{
			filler=new CutsLoader(getFillerAnim().Replace("_","."));
		}
		return;	
	}

	/// <summary>
	/// Support for code to be called at the start of the cutscene
	/// </summary>
	public virtual void PreCutsceneEvent()
	{
		return;	
	}

	/// <summary>
	/// Support for code to be called after the cutscene ends
	/// </summary>
	public virtual void PostCutSceneEvent()
	{
			return;		
	}
}
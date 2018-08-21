using UnityEngine;
using System.Collections;

public class CutsceneAnimation : HudAnimation {
		//public string CurrentSpriteName;
		//Sprite CurrentSpriteLoaded;
		//public string currentCutsFile;
		//public string previousCutsFile;
		//public Sprite filler;

	/*Gui element for the small window animations*/

	/*Is also responsible for calling the resurrection sequence in UW1*/

//	public Camera maincam;

	//public void PreAnimPlay()
	//{//Called by events in certain animations when starting playing
	//	UWCharacter.Instance.playerCam.cullingMask=0;//Stops the camera from rendering.
	//	return;
	//} 
	
		/*
	public void PostAnimPlay()
	{//Called by events in certain animations when finished playing

		switch (SetAnimationFile)
		{
		case "FadeToBlackSleep":
			UWCharacter.Instance.playerCam.cullingMask=HudAnimation.NormalCullingMask;
			SetAnimationFile = "Anim_Base";//Clears out the animation.
			Bedroll.WakeUp (UWCharacter.Instance);
			break;
		case "ChasmMap":
			//maincam.enabled=true;
			UWCharacter.Instance.playerCam.cullingMask=HudAnimation.NormalCullingMask;
			SetAnimationFile= "Anim_Base";//Clears out the animation.
			break;
		case "Death_With_Sapling"://Resurrection
		//	MusicController mus = GameObject.Find("MusicController").GetComponent<MusicController>();
			if (MusicController.instance!=null)
			{
				UWCharacter.Instance.CurVIT=UWCharacter.Instance.MaxVIT;
				MusicController.instance.Death=false;
				MusicController.instance.Combat=false;
				MusicController.instance.Fleeing=false;
				MusicController.LastAttackCounter=0.0f;
			}
			//maincam.enabled=true;
			UWCharacter.Instance.playerCam.cullingMask=HudAnimation.NormalCullingMask;
			SetAnimationFile= "Anim_Base";//Clears out the animation.
			
			
			if (GameWorldController.instance.LevelNo!=UWCharacter.Instance.ResurrectLevel-1)
			{
				GameWorldController.instance.SwitchLevel(UWCharacter.Instance.ResurrectLevel-1);
			}
			UWCharacter.Instance.gameObject.transform.position=UWCharacter.Instance.ResurrectPosition;
			break;

		case "Death"://Forever
			SetAnimationFile= "Death_Final";
			break;
		case "Death_Final"://Forever
			break;
		default:
			//maincam.enabled=true;
			UWCharacter.Instance.playerCam.cullingMask=HudAnimation.NormalCullingMask;
			SetAnimationFile= "Anim_Base";//Clears out the animation.
			break;
		}
	}
	*/
}
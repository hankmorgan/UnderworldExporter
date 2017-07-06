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
	//	GameWorldController.instance.playerUW.playerCam.cullingMask=0;//Stops the camera from rendering.
	//	return;
	//} 
	
		/*
	public void PostAnimPlay()
	{//Called by events in certain animations when finished playing

		switch (SetAnimationFile)
		{
		case "FadeToBlackSleep":
			GameWorldController.instance.playerUW.playerCam.cullingMask=HudAnimation.NormalCullingMask;
			SetAnimationFile = "Anim_Base";//Clears out the animation.
			Bedroll.WakeUp (GameWorldController.instance.playerUW);
			break;
		case "ChasmMap":
			//maincam.enabled=true;
			GameWorldController.instance.playerUW.playerCam.cullingMask=HudAnimation.NormalCullingMask;
			SetAnimationFile= "Anim_Base";//Clears out the animation.
			break;
		case "Death_With_Sapling"://Resurrection
		//	MusicController mus = GameObject.Find("MusicController").GetComponent<MusicController>();
			if (GameWorldController.instance.getMus()!=null)
			{
				GameWorldController.instance.playerUW.CurVIT=GameWorldController.instance.playerUW.MaxVIT;
				GameWorldController.instance.getMus().Death=false;
				GameWorldController.instance.getMus().Combat=false;
				GameWorldController.instance.getMus().Fleeing=false;
				MusicController.LastAttackCounter=0.0f;
			}
			//maincam.enabled=true;
			GameWorldController.instance.playerUW.playerCam.cullingMask=HudAnimation.NormalCullingMask;
			SetAnimationFile= "Anim_Base";//Clears out the animation.
			
			
			if (GameWorldController.instance.LevelNo!=GameWorldController.instance.playerUW.ResurrectLevel-1)
			{
				GameWorldController.instance.SwitchLevel(GameWorldController.instance.playerUW.ResurrectLevel-1);
			}
			GameWorldController.instance.playerUW.gameObject.transform.position=GameWorldController.instance.playerUW.ResurrectPosition;
			break;

		case "Death"://Forever
			SetAnimationFile= "Death_Final";
			break;
		case "Death_Final"://Forever
			break;
		default:
			//maincam.enabled=true;
			GameWorldController.instance.playerUW.playerCam.cullingMask=HudAnimation.NormalCullingMask;
			SetAnimationFile= "Anim_Base";//Clears out the animation.
			break;
		}
	}
	*/
}
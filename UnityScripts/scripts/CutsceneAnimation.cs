using UnityEngine;
using System.Collections;

public class CutsceneAnimation : HudAnimation {
	/*Gui element for the small window animations*/

	/*Is also responsible for calling the resurrection sequence in UW1*/

	public Camera maincam;

	public void PreAnimPlay()
	{//Called by events in certain animations when starting playing
		playerUW.playerCam.cullingMask=0;//Stops the camera from rendering.
		return;
	} 
	
	public void PostAnimPlay()
	{//Called by events in certain animations when finished playing

		switch (SetAnimation)
		{
		case "ChasmMap":
			//maincam.enabled=true;
			playerUW.playerCam.cullingMask=HudAnimation.NormalCullingMask;
			SetAnimation= "Anim_Base";//Clears out the animation.
			break;
		case "Death_With_Sapling"://Resurrection
			MusicController mus = GameObject.Find("MusicController").GetComponent<MusicController>();
			if (mus!=null)
			{
				playerUW.CurVIT=playerUW.MaxVIT;
				mus.Death=false;
				mus.Combat=false;
				mus.Fleeing=false;
				MusicController.LastAttackCounter=0.0f;
			}
			maincam.enabled=true;
			playerUW.playerCam.cullingMask=HudAnimation.NormalCullingMask;
			SetAnimation= "Anim_Base";//Clears out the animation.
			break;

		case "Death"://Forever
			SetAnimation= "Death_Final";
			break;
		case "Death_Final"://Forever
			break;
		default:
			//maincam.enabled=true;
			playerUW.playerCam.cullingMask=HudAnimation.NormalCullingMask;
			SetAnimation= "Anim_Base";//Clears out the animation.
			break;
		}
	}
}

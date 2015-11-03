using UnityEngine;
using System.Collections;

public class CutsceneAnimation : HudAnimation {


	public Camera maincam;

	public void PreAnimPlay()
	{//Called by events in certain animations
		//Debug.Log("Preanim");
		//maincam.enabled=false;
		return;
	}
	
	public void PostAnimPlay()
	{//Called by events in certain animations

		switch (SetAnimation)
		{
		case "Death_With_Sapling"://Resurrection
			MusicController mus = GameObject.Find("MusicController").GetComponent<MusicController>();
			if (mus!=null)
			{
				UWCharacter playerUW = GameObject.Find ("Gronk").GetComponent<UWCharacter>();
				playerUW.CurVIT=playerUW.MaxVIT;
				mus.Death=false;
				mus.Combat=false;
				mus.Fleeing=false;
				MusicController.LastAttackCounter=0.0f;
			}
			maincam.enabled=true;
			SetAnimation= "Anim_Base";//Clears out the animation.
			break;

		case "Death"://Forever
			SetAnimation= "Death_Final";
			//maincam.enabled=true;
			//TODO:Switch animation to repeating final skull
			//SetAnimation= "Anim_Base";//Clears out the animation.
			break;
		case "Death_Final"://Forever
			//maincam.enabled=true;
			//TODO:Switch animation to repeating final skull
			//SetAnimation= "Anim_Base";//Clears out the animation.
			break;

		default:
			maincam.enabled=true;
			SetAnimation= "Anim_Base";//Clears out the animation.
			break;
		}
	}
}

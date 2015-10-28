using UnityEngine;
using System.Collections;

public class CutsceneAnimation : HudAnimation {


	public Camera maincam;

	public void PreAnimPlay()
	{//Called by events in certain animations
		//Debug.Log("Preanim");
		maincam.enabled=false;
		return;
	}
	
	public void PostAnimPlay()
	{//Called by events in certain animations


		//Debug.Log("Postanim");
		maincam.enabled=true;
		SetAnimation= "Anim_Base";//Clears out the animation.
		return;
	}
}

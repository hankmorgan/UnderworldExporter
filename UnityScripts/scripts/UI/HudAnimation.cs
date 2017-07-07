using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HudAnimation : GuiBase {
	//Base Class For playing cutscenes and other animations on the hud.

	//public UITexture TargetControl;
	//public RawImage TargetControl;
//	public string SetAnimationFile;
	//protected SpriteRenderer sprt;
//	public string PreviousAnimationFile;
	//private string PreviousSprite="";
	//private Animator anim;
	public CutsAnimator anim;

	public const int NormalCullingMask=-33;//-33
	// Use this for initialization
	public override void Start()
		{
		base.Start();
		anim.SetAnimation="Anim_Base";
		anim.PrevAnimation="Anim_Base";
		//PreviousAnimationFile=SetAnimationFile;
		//NormalCullingMask=-33;  //= playerUW.playerCam.cullingMask;
	}
	
	// Update is called once per frame
	//protected virtual void Update () {
	//	if (SetAnimationFile !=PreviousAnimationFile)
	//	{
	//		anim.SetAnimation=SetAnimationFile;
	//		PreviousAnimationFile=SetAnimationFile;
	//	}
	//}


	//void PlayAnimFile(string animName)
	//{
			
	//}


	/*Have to declare these in derived classes due to unity editor bug*/
//	public virtual void PreAnimPlay()
//	{//Called by events in certain animations
//		return;
//	}

//	public virtual void PostAnimPlay()
//	{//Called by events in certain animations
//		return;
//	}
}

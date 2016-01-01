using UnityEngine;
using System.Collections;

public class HudAnimation : GuiBase {
	//Base Class For playing cutscenes and other animations on the hud.

	public UITexture TargetControl;
	public string SetAnimation;
	private SpriteRenderer sprt;
	public string PreviousAnimation;
	private Animator anim;

	public static int NormalCullingMask;//-33
	// Use this for initialization
	protected virtual void Start () {
		sprt=this.GetComponent<SpriteRenderer>();
		anim=this.GetComponent<Animator>();
		anim.Play (SetAnimation);
		PreviousAnimation=SetAnimation;
		NormalCullingMask=-33;  //= playerUW.playerCam.cullingMask;
	}
	
	// Update is called once per frame
	protected virtual void Update () {
		if (SetAnimation !=PreviousAnimation)
		{
			anim.Play (SetAnimation);
			PreviousAnimation=SetAnimation;
		}
		if (sprt.sprite!=null)
		{
			TargetControl.mainTexture =sprt.sprite.texture;
		}
	}

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

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HudAnimation : GuiBase {
	//Base Class For playing cutscenes and other animations on the hud.

	//public UITexture TargetControl;
	public RawImage TargetControl;
	public string SetAnimation;
	protected SpriteRenderer sprt;
	public string PreviousAnimation;
	private string PreviousSprite="";
	private Animator anim;

	public static int NormalCullingMask;//-33
	// Use this for initialization
	public override void Start()
		{
		base.Start();
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
			if (PreviousSprite!=sprt.sprite.name)
			{
					TargetControl.texture =sprt.sprite.texture;
					PreviousSprite=sprt.sprite.name;
			}			
		}
	}


	void PlayAnimFile(string animName)
	{
			
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

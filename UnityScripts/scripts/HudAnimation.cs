using UnityEngine;
using System.Collections;

public class HudAnimation : MonoBehaviour {


	public UITexture TargetControl;
	public string SetAnimation;
	private SpriteRenderer sprt;
	public string PreviousAnimation;
	private Animator anim;
	// Use this for initialization
	void Start () {
		sprt=this.GetComponent<SpriteRenderer>();
		anim=this.GetComponent<Animator>();
		anim.Play (SetAnimation);
		PreviousAnimation=SetAnimation;
	}
	
	// Update is called once per frame
	void Update () {
		if (SetAnimation !=PreviousAnimation)
		{
			//Debug.Log ("trying to play");
			anim.Play (SetAnimation);
			//Debug.Log ("played");
			PreviousAnimation=SetAnimation;
			}
		if (sprt.sprite!=null)
		{
			TargetControl.mainTexture =sprt.sprite.texture;
		}
	}
}

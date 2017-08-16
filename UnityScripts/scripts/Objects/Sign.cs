using UnityEngine;
using System.Collections;

public class Sign : Decal {
	//private bool spriteReady;
	protected override void Start ()
	{
		base.Start ();
		BoxCollider bx = this.GetComponent<BoxCollider>();
		bx.size= new Vector3(0.3f, 0.3f, 0.1f);
		bx.center= new Vector3(0.0f,0.15f,0.0f);
		//setSprite(this.GetComponentInChildren<SpriteRenderer>(),_RES + "/Sprites/tmobj/tmobj_" + (20 + (objInt().flags & 0x07)));
		setSpriteTMOBJ(this.GetComponentInChildren<SpriteRenderer>(),(20 + (objInt().flags & 0x07)));
	}


	public override bool use ()
	{
		return Read();
	}

	public override bool LookAt ()
	{
		return Read ();
	}

	public virtual bool Read ()
	{

		UWHUD.instance.MessageScroll.Add (StringController.instance.GetString (8,objInt().link - 0x200));
		return true;

	}


	public override string UseVerb()
	{
			return "read";	
	}

	public override string ExamineVerb ()
	{
			return "read";
	}


}

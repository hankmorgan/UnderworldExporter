using UnityEngine;
using System.Collections;

public class Sign : Readable {
	//private bool spriteReady;
	protected override void Start ()
	{
		base.Start ();
		//setSprite(this.GetComponentInChildren<SpriteRenderer>(),_RES + "/Sprites/tmobj/tmobj_" + (20 + (objInt().flags & 0x07)));
		setSpriteTMOBJ(this.GetComponentInChildren<SpriteRenderer>(),(20 + (objInt().flags & 0x07)));
	}


	public override bool use ()
	{
		return Read();
	}

	public override bool Read ()
	{

		UWHUD.instance.MessageScroll.Add (StringController.instance.GetString (8,objInt().link - 0x200));
		return true;

	}



}

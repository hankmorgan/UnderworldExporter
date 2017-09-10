using UnityEngine;
using System.Collections;

public class UWPainting : Decal {


	protected override void Start ()
	{
		base.Start ();
		setSpriteTMOBJ(this.GetComponentInChildren<SpriteRenderer>(),(42 + (objInt().flags & 0x07)));
	}
}

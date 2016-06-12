using UnityEngine;
using System.Collections;

public class SpellProp_OrtGrav : SpellProp {
	//Electric bolt
	public override void init ()
	{
		base.init ();
		ProjectileSprite = "Sprites/objects_021";
		Force=200.0f;
		BaseDamage=8;
		impactFrameStart=46;
		impactFrameEnd=50;
	}
}

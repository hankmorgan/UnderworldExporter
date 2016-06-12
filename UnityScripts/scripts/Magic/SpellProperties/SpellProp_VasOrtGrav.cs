using UnityEngine;
using System.Collections;

public class SpellProp_VasOrtGrav : SpellProp_PorFlam {
	//Sheet Lightning

	public override void init ()
	{
		base.init ();
		ProjectileSprite = "Sprites/object_blank";
		Force=500.0f;
		BaseDamage=8;
		splashDamage=3;
		splashDistance=1.0f;
		impactFrameStart=62;
		impactFrameEnd=62;
		spread=4;
		noOfCasts=Random.Range(1,3);
		SecondaryStartFrame=50;
		SecondaryEndFrame=53;
	}
}

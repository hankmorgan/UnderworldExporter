using UnityEngine;
using System.Collections;

public class SpellProp_FlameWind : SpellProp_Fireball {
	//Flame wind. Aka DOOM.

	public override void init(int effectId, GameObject SpellCaster)
	{

		base.init (effectId,SpellCaster);
		ProjectileSprite = UWEBase._RES +"/Sprites/object_blank";
		Force=500.0f;
		BaseDamage=16;
		splashDamage=8;
		splashDistance=1.0f;
		impactFrameStart=21;
		impactFrameEnd=25;
		spread=5;
		noOfCasts=Random.Range(2,5);
		SecondaryStartFrame=31;
		SecondaryEndFrame=35;
	}
}

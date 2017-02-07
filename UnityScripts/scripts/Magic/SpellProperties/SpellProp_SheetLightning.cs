using UnityEngine;
using System.Collections;

public class SpellProp_SheetLightning : SpellProp_Fireball {
	//Sheet Lightning

	public override void init(int effectId, GameObject SpellCaster)
	{
		base.init (effectId,SpellCaster);
		//ProjectileSprite = UWEBase._RES +"/Sprites/object_blank";
		ProjectileItemId=21;//This shoudld be something invisible.
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

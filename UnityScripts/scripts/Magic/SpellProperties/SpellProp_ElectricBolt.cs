using UnityEngine;
using System.Collections;

public class SpellProp_ElectricBolt : SpellProp {
	//Electric bolt
	public override void init(int effectId, GameObject SpellCaster)
	{
		base.init (effectId,SpellCaster);
		//ProjectileSprite = UWEBase._RES +"/Sprites/Objects/Objects_021";
		ProjectileItemId=21;
		Force=200.0f;
		BaseDamage=8;
		impactFrameStart=46;
		impactFrameEnd=50;
		damagetype = DamageTypes.electric;
	}
}

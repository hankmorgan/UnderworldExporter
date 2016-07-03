using UnityEngine;
using System.Collections;

public class SpellProp_ElectricBolt : SpellProp {
	//Electric bolt
	public override void init(int effectId)
	{
		base.init (effectId);
		ProjectileSprite = UWEBase._RES +"/Sprites/objects_021";
		Force=200.0f;
		BaseDamage=8;
		impactFrameStart=46;
		impactFrameEnd=50;
	}
}

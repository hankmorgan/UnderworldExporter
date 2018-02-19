using UnityEngine;
using System.Collections;

public class SpellProp_Movement : SpellProp {
//Movement related properties
	public float Speed;
	public override void init (int effectId, GameObject SpellCaster)
	{
		base.init (effectId,SpellCaster);
		damagetype = DamageTypes.mobility;
				/*
		int SpellEffectSlot = CheckActiveSpellEffect(caster);
		SpellProp_Movement movement = new SpellProp_Movement();
		movement.init(EffectID);
		*/
		//leap, slowfall, speed, waterwalking, flight

		switch (effectId)
			{
			case SpellEffect.UW1_Spell_Effect_Leap:
					counter=4;break;
			case SpellEffect.UW1_Spell_Effect_Levitate:
			case SpellEffect.UW1_Spell_Effect_Levitate_alt01:
			case SpellEffect.UW1_Spell_Effect_Levitate_alt02:
					counter=3;Speed=1.0f; break;
			case SpellEffect.UW1_Spell_Effect_Fly:
			case SpellEffect.UW1_Spell_Effect_Fly_alt01:
			case SpellEffect.UW1_Spell_Effect_Fly_alt02:	
					counter=4;Speed=2.0f; break;
			case SpellEffect.UW1_Spell_Effect_SlowFall:
			case SpellEffect.UW1_Spell_Effect_SlowFall_alt01:
			case SpellEffect.UW1_Spell_Effect_SlowFall_alt02:
					counter=2;break;
			case SpellEffect.UW1_Spell_Effect_WaterWalk:
			case SpellEffect.UW1_Spell_Effect_WaterWalk_alt01:
			case SpellEffect.UW1_Spell_Effect_WaterWalk_alt02:
					counter = 4;break;
			case SpellEffect.UW1_Spell_Effect_Speed:
			case SpellEffect.UW1_Spell_Effect_Haste:
					Speed=1.2f; counter=6;break;

				default:
						Debug.Log("Default values used in speed spell");
						Speed=1.2f; counter=6;break;
			}
	}
}

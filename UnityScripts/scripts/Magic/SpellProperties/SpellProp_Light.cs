using UnityEngine;
using System.Collections;

public class SpellProp_Light : SpellProp{

		public override void init (int effectId, GameObject SpellCaster)
	{
		base.init (effectId,SpellCaster);
				this.counter=5;//Should counter be a function of the casters casting ability as this drives the stability of the spell.
				switch(effectId)
				{//TODO:Review these light values.
				case SpellEffect.UW1_Spell_Effect_Darkness:	this.BaseDamage=1;  break;
				case SpellEffect.UW1_Spell_Effect_BurningMatch:	this.BaseDamage=2;  break;
				case SpellEffect.UW1_Spell_Effect_Candlelight:	this.BaseDamage=3;  break;
				case SpellEffect.UW1_Spell_Effect_Light:	this.BaseDamage=4;  break;
				case SpellEffect.UW1_Spell_Effect_MagicLantern:	this.BaseDamage=5;  break;
				case SpellEffect.UW1_Spell_Effect_Daylight:	this.BaseDamage=6;  break;
				case SpellEffect.UW1_Spell_Effect_Sunlight:	this.BaseDamage=7;  break;
				case SpellEffect.UW1_Spell_Effect_Light_alt01:	this.BaseDamage=4;  break;
				case SpellEffect.UW1_Spell_Effect_Daylight_alt01:	this.BaseDamage=7;  break;
				case SpellEffect.UW1_Spell_Effect_Light_alt02:	this.BaseDamage=4;  break;
				case SpellEffect.UW1_Spell_Effect_Daylight_alt02:	this.BaseDamage=7;  break;
				case SpellEffect.UW1_Spell_Effect_NightVision:
				case SpellEffect.UW1_Spell_Effect_NightVision_alt01:
				case SpellEffect.UW1_Spell_Effect_NightVision_alt02:
						this.BaseDamage=12;  break;

				default:
						Debug.Log("Default values used in light spell");
						BaseDamage=12;break;
				}

	}
}

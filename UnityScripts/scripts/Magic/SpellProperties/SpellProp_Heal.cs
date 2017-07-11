using UnityEngine;
using System.Collections;

public class SpellProp_Heal : SpellProp {

	public override void init (int effectId, GameObject SpellCaster)
	{
		base.init (effectId,SpellCaster);
				//TODO:Heal affected by caster ability
		switch (effectId)
				{
				case SpellEffect.UW1_Spell_Effect_LesserHeal:
				case SpellEffect.UW1_Spell_Effect_LesserHeal_alt01:
				case SpellEffect.UW1_Spell_Effect_LesserHeal_alt02:
				case SpellEffect.UW1_Spell_Effect_LesserHeal_alt03:
				case SpellEffect.UW1_Spell_Effect_LesserHeal_alt04:						
						this.BaseDamage=(short)Random.Range (1,10);break;
				case SpellEffect.UW1_Spell_Effect_Heal:
				case SpellEffect.UW1_Spell_Effect_Heal_alt01:
				case SpellEffect.UW1_Spell_Effect_Heal_alt02:
				case SpellEffect.UW1_Spell_Effect_Heal_alt03:
				case SpellEffect.UW1_Spell_Effect_Heal_alt04:
						this.BaseDamage=(short)Random.Range (10,20);break;
				case SpellEffect.UW1_Spell_Effect_EnhancedHeal:
				case SpellEffect.UW1_Spell_Effect_EnhancedHeal_alt01:
				case SpellEffect.UW1_Spell_Effect_EnhancedHeal_alt02:
				case SpellEffect.UW1_Spell_Effect_EnhancedHeal_alt03:
						this.BaseDamage=(short)Random.Range (30,40);break;
				case SpellEffect.UW1_Spell_Effect_GreaterHeal:
				case SpellEffect.UW1_Spell_Effect_GreaterHeal_alt01:
				case SpellEffect.UW1_Spell_Effect_GreaterHeal_alt02:
				case SpellEffect.UW1_Spell_Effect_GreaterHeal_alt03:
				case SpellEffect.UW1_Spell_Effect_GreaterHeal_alt04:						
						this.BaseDamage=(short)Random.Range (50,60);break;

				}
	}
}

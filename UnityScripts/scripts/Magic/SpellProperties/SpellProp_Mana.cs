using UnityEngine;
using System.Collections;

public class SpellProp_Mana : SpellProp {

	public override void init (int effectId, GameObject SpellCaster)	
	{
		base.init (effectId,SpellCaster);
				damagetype = DamageTypes.aid;
				switch(effectId)
				{
				case SpellEffect.UW1_Spell_Effect_ManaBoost:
				case SpellEffect.UW1_Spell_Effect_ManaBoost_alt01:
				case SpellEffect.UW1_Spell_Effect_ManaBoost_alt02:
				case SpellEffect.UW1_Spell_Effect_ManaBoost_alt03:
				case SpellEffect.UW1_Spell_Effect_ManaBoost_alt04:
						BaseDamage=(short)Random.Range(5,10);break;						
				case SpellEffect.UW1_Spell_Effect_RestoreMana_alt04:
						BaseDamage=(short)Random.Range(20,50);break;
				case SpellEffect.UW1_Spell_Effect_IncreaseMana:
				case SpellEffect.UW1_Spell_Effect_IncreaseMana_alt01:
				case SpellEffect.UW1_Spell_Effect_IncreaseMana_alt02:
				case SpellEffect.UW1_Spell_Effect_IncreaseMana_alt03:
						BaseDamage=(short)Random.Range(30,50);break;
				case SpellEffect.UW1_Spell_Effect_RegainMana:
				case SpellEffect.UW1_Spell_Effect_RegainMana_alt01:
				case SpellEffect.UW1_Spell_Effect_RegainMana_alt02:
				case SpellEffect.UW1_Spell_Effect_RegainMana_alt03:
						BaseDamage=(short)Random.Range(30,50);break;
				case SpellEffect.UW1_Spell_Effect_RestoreMana:
				case SpellEffect.UW1_Spell_Effect_RestoreMana_alt01:
				case SpellEffect.UW1_Spell_Effect_RestoreMana_alt02:
				case SpellEffect.UW1_Spell_Effect_RestoreMana_alt03:
						BaseDamage=(short)Random.Range(3,70);break;

				default:
						Debug.Log("Default values used in mana spell");
						BaseDamage=20;;break;

				}
	}
}

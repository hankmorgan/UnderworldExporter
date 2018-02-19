using UnityEngine;
using System.Collections;

public class SpellProp_Mind : SpellProp {
		//Non damaging/Mind altering spells with durations

		/*
			SpellProp_Mind mindspell = new SpellProp_Mind();
			mindspell.init(EffectID);
		 */
		public override void init (int effectId, GameObject SpellCaster)
	{
		base.init (effectId,SpellCaster);
		damagetype = DamageTypes.psychic;
		switch (effectId)
		{		
		case SpellEffect.UW1_Spell_Effect_Paralyze:
		case SpellEffect.UW1_Spell_Effect_Paralyze_alt01:
			counter=4; break;
		case SpellEffect.UW1_Spell_Effect_Ally:
		case SpellEffect.UW1_Spell_Effect_Ally_alt01:
			counter=5; break;						
		case SpellEffect.UW1_Spell_Effect_Confusion:
		case SpellEffect.UW1_Spell_Effect_Confusion_alt01:
			counter=3; break;
		case SpellEffect.UW1_Spell_Effect_CauseFear:
		case SpellEffect.UW1_Spell_Effect_CauseFear_alt01:
			counter=4; break;
		case SpellEffect.UW1_Spell_Effect_Telekinesis:
		case SpellEffect.UW1_Spell_Effect_Telekinesis_alt01:
		case SpellEffect.UW1_Spell_Effect_Telekinesis_alt02:						
			counter=2; break;
		case SpellEffect.UW1_Spell_Effect_MazeNavigation:
			counter=4; break;	
		case SpellEffect.UW1_Spell_Effect_Hallucination:
			counter=4; break;
		case SpellEffect.UW1_Spell_Effect_RoamingSight:						
		case SpellEffect.UW1_Spell_Effect_RoamingSight_alt01:
		case SpellEffect.UW1_Spell_Effect_RoamingSight_alt02:
			counter=2; break;
		case SpellEffect.UW1_Spell_Effect_FreezeTime:
		case SpellEffect.UW1_Spell_Effect_FreezeTime_alt01:
		case SpellEffect.UW1_Spell_Effect_FreezeTime_alt02:
			counter=4; break;						
		case SpellEffect.UW1_Spell_Effect_DetectMonster:
		case SpellEffect.UW1_Spell_Effect_DetectMonster_alt01:
				BaseDamage=5;//range of the detection
				break;

				default:
						Debug.Log("Default values used in mind spell");
						BaseDamage=5;break;
		}

		
		impactFrameStart=40;
		impactFrameEnd=44;

	}
}

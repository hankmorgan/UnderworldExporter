using UnityEngine;
using System.Collections;

public class SpellProp_Stealth : SpellProp {
	public int StealthLevel;//What skill bonus this spell gives.
	public override void init (int effectId, GameObject SpellCaster)
	{
		base.init (effectId,SpellCaster);
		switch(effectId)
			{
			case SpellEffect.UW1_Spell_Effect_Stealth:
			case SpellEffect.UW1_Spell_Effect_Stealth_alt01:
			case SpellEffect.UW1_Spell_Effect_Stealth_alt02:
					StealthLevel=5;counter=2;break;					
					
			case SpellEffect.UW1_Spell_Effect_Conceal:
			case SpellEffect.UW1_Spell_Effect_Conceal_alt01:
			case SpellEffect.UW1_Spell_Effect_Conceal_alt02:
					StealthLevel=15;counter=3;break;

			case SpellEffect.UW1_Spell_Effect_Invisibilty:
			case SpellEffect.UW1_Spell_Effect_Invisibility_alt01:
			case SpellEffect.UW1_Spell_Effect_Invisibility_alt02:
					StealthLevel=30;counter=5;break;

				default:
						Debug.Log("Default values used in stealth spell");
						StealthLevel=30;counter=5;break;
			}
		}
}

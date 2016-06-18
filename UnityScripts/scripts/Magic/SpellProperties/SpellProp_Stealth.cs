using UnityEngine;
using System.Collections;

public class SpellProp_Stealth : SpellProp {
	public int StealthLevel;

	public override void init (int effectId)
	{
		base.init (effectId);
		switch(effectId)
			{
			case SpellEffect.UW1_Spell_Effect_Stealth:
			case SpellEffect.UW1_Spell_Effect_Stealth_alt01:
			case SpellEffect.UW1_Spell_Effect_Stealth_alt02:
					StealthLevel=1;counter=2;break;					
					
			case SpellEffect.UW1_Spell_Effect_Conceal:
			case SpellEffect.UW1_Spell_Effect_Conceal_alt01:
			case SpellEffect.UW1_Spell_Effect_Conceal_alt02:
					StealthLevel=2;counter=3;break;

			case SpellEffect.UW1_Spell_Effect_Invisibilty:
			case SpellEffect.UW1_Spell_Effect_Invisibility_alt01:
			case SpellEffect.UW1_Spell_Effect_Invisibility_alt02:
					StealthLevel=3;counter=5;break;
			}
		}
}

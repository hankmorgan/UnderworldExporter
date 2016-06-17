using UnityEngine;
using System.Collections;

public class SpellProp_Poison : SpellProp {

	public override void init (int effectId)
	{
		base.init (effectId);
		impactFrameStart=40;
		impactFrameEnd=44;
		switch (effectId)
			{//TODO:what values? How does this affect the player or NPC casts of poison?
			case SpellEffect.UW1_Spell_Effect_Poison:
					BaseDamage=50;counter=5;break;
			case SpellEffect.UW1_Spell_Effect_Poison_alt01:
					BaseDamage=100;counter=6;break;
			case SpellEffect.UW1_Spell_Effect_PoisonHidden:
					BaseDamage=40;counter=5;break;
			}
	}
}

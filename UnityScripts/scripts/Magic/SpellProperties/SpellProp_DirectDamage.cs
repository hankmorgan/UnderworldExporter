using UnityEngine;
using System.Collections;

public class SpellProp_DirectDamage : SpellProp {


		//Direct impact spells no projectile

	public override void init (int effectId)
	{
		base.init (effectId);
		switch(effectId)
			{
			case SpellEffect.UW1_Spell_Effect_SmiteUndead:
			case SpellEffect.UW1_Spell_Effect_SmiteUndead_alt01:	
				BaseDamage=100;//Instant kill undead?
				break;
			}
	}
}

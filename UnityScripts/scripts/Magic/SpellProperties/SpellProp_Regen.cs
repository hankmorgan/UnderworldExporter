using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellProp_Regen : SpellProp {

	public override void init (int effectId, GameObject SpellCaster)
	{
		damagetype = DamageTypes.aid;
		switch (_RES)
		{
			case GAME_UW2:
				{
					switch(effectId)
					{
					default:
				//	case SpellEffect.UW2_Spell_Effect_ManaRegeneration:
						{
							BaseDamage = 20;
							counter = 3;
							break;
						}
					}
					break;
				}
			default:
				{
				switch(effectId)
					{
						default:
						//case SpellEffect.UW1_Spell_Effect_ManaRegeneration:
							{
								BaseDamage = 20;
								counter = 3;
								break;
							}
					}
					break;
				}

		}
	}
	

}

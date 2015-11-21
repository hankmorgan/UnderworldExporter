using UnityEngine;
using System.Collections;

public class a_damage_trap : trap_base {
	/*
Per uw-formats.txt
	0180  a_damage trap
	player vitality is decreased; number of hit points are in "quality"
	field; if the "owner" field is != 0, the hit points are added
	instead. the trap is only set of when a random value [0..10] is >= 7.

Examples of usage
Ironwits maze on Level2 (rotworm area)

//UPDATE
It appears the above may be wrong?
owner = 0 damage trap
owner != 0 poison trap
*/

	public override void ExecuteTrap (int triggerX, int triggerY, int State)
	{

		if (objInt.Owner ==0)
		{
			if (Random.Range(0,11) >= 7)
			{
				playerUW.CurVIT= playerUW.CurVIT- objInt.Quality;
			}
		}
		else//poison version
		{
			if (playerUW.Poisoned==false)
			{
				playerUW.PlayerMagic.CastEnchantment(playerUW.gameObject,SpellEffect.UW1_Spell_Effect_Poison);
			}		
		}
	}
}

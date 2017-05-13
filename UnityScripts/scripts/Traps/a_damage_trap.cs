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

		//Question to answer. What impact does the flags value have?

	public override void ExecuteTrap (int triggerX, int triggerY, int State)
	{

		if (objInt().owner ==0)
		{
			if (Random.Range(0,11) >= 7)
			{
				GameWorldController.instance.playerUW.CurVIT= GameWorldController.instance.playerUW.CurVIT- objInt().quality;
			}
		}
		else//poison version
		{
			if (GameWorldController.instance.playerUW.play_poison==0)
			{
				GameWorldController.instance.playerUW.PlayerMagic.CastEnchantment(GameWorldController.instance.playerUW.gameObject,null,SpellEffect.UW1_Spell_Effect_Poison,Magic.SpellRule_TargetSelf);
				GameWorldController.instance.playerUW.play_poison=Mathf.Max(1, GameWorldController.instance.playerUW.play_poison);//Is this the value the poison should apply?
			}		
		}
	}
}

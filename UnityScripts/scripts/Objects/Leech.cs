using UnityEngine;
using System.Collections;
/// <summary>
/// Leches can be used to cure poison
/// </summary>
public class Leech : object_base {


public override bool use ()
	{
		if (playerUW.playerInventory.ObjectInHand!="")
		{
			playerUW.PlayerMagic.CastEnchantment(playerUW.gameObject,null, SpellEffect.UW1_Spell_Effect_CurePoison,Magic.SpellRule_TargetSelf);
			GameWorldController.instance.playerUW.playerHud.MessageScroll.Add(playerUW.StringControl.GetString (1,224));
			playerUW.ApplyDamage(Random.Range (1,6));
			objInt().consumeObject();
			return true;
		}
		else
		{
			return ActivateByObject (playerUW.playerInventory.GetGameObjectInHand());
		}
	}
}

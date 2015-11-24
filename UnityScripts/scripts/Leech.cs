using UnityEngine;
using System.Collections;

public class Leech : object_base {


public override bool use ()
	{
		if (playerUW.playerInventory.ObjectInHand!="")
		{
			playerUW.PlayerMagic.CastEnchantment(playerUW.gameObject, SpellEffect.UW1_Spell_Effect_CurePoison);
			playerUW.GetMessageLog ().text =playerUW.StringControl.GetString (1,224);
			playerUW.ApplyDamage(Random.Range (1,6));
			objInt.consumeObject();
			return true;
		}
		else
		{
			return ActivateByObject (playerUW.playerInventory.GetGameObjectInHand());
		}
	}
}

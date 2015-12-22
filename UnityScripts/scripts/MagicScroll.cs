using UnityEngine;
using System.Collections;

public class MagicScroll : enchantment_base {


	public override bool use ()
	{
		if (playerUW.playerInventory.ObjectInHand=="")
		{
			playerUW.PlayerMagic.CastEnchantment(playerUW.gameObject,null,GetActualSpellIndex(),Magic.SpellRule_TargetSelf );
			objInt.consumeObject();
			return true;
		}
		else
		{
			//return playerUW.playerInventory.GetGameObjectInHand().GetComponent<ObjectInteraction>().FailMessage();
			return ActivateByObject(playerUW.playerInventory.GetGameObjectInHand());
		}		
	}
}

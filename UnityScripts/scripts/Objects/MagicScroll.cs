using UnityEngine;
using System.Collections;

public class MagicScroll : enchantment_base {
	public override bool use ()
	{
		if (GameWorldController.instance.playerUW.playerInventory.ObjectInHand=="")
		{
			GameWorldController.instance.playerUW.PlayerMagic.CastEnchantment(GameWorldController.instance.playerUW.gameObject,null,GetActualSpellIndex(),Magic.SpellRule_TargetSelf );
			objInt().consumeObject();
			return true;
		}
		else
		{
			return ActivateByObject(GameWorldController.instance.playerUW.playerInventory.GetGameObjectInHand());
		}		
	}


		public override string ContextMenuUsedDesc ()
		{
			return "L-Click to cast";
		}
}

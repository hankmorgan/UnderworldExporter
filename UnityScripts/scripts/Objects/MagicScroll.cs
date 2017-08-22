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


	public override string UseVerb ()
	{
		return "cast";
	}

	public override bool ApplyAttack (short damage)
	{
		objInt().quality-=damage;
		if (objInt().quality<=0)
		{
			ChangeType(213,23);//Change to debris.
			this.gameObject.AddComponent<enchantment_base>();//Add a generic object base for behaviour. THis is the famous magic debris
			Destroy(this);//Remove the potion enchantment.
		}
		return true;
	}

}

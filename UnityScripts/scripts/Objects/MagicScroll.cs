using UnityEngine;
using System.Collections;

public class MagicScroll : enchantment_base {
	public override bool use ()
	{
        if (ConversationVM.InConversation) { return false; }
        if (UWCharacter.Instance.playerInventory.ObjectInHand=="")
		{
			UWCharacter.Instance.PlayerMagic.CastEnchantment(UWCharacter.Instance.gameObject,null,GetActualSpellIndex(),Magic.SpellRule_TargetSelf,Magic.SpellRule_Consumable );
			objInt().consumeObject();
			return true;
		}
		else
		{
			return ActivateByObject(UWCharacter.Instance.playerInventory.GetGameObjectInHand());
		}		
	}


	public override string UseVerb ()
	{
		return "cast";
	}

	public override bool ApplyAttack (short damage)
	{
		quality-=damage;
		if (quality<=0)
		{
			ChangeType(213);//Change to debris.
			this.gameObject.AddComponent<enchantment_base>();//Add a generic object base for behaviour. THis is the famous magic debris
			Destroy(this);//Remove the potion enchantment.
		}
		return true;
	}

}

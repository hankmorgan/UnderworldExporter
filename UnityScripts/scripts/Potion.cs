using UnityEngine;
using System.Collections;

public class Potion : enchantment_base {

	public override bool Eat ()
	{
		return use();
	}

	public override bool use ()
	{
		if (playerUW.playerInventory.ObjectInHand=="")
		{
			int index=0; //= GetActualSpellIndex();
			int UseString=-1;
			switch (objInt.item_id)
			{
			case 184 :// a_mushroom
				UseString=232;
				index=SpellEffect.UW1_Spell_Effect_Hallucination;//Tripping
				break;
			case 185 :// a_toadstool
				UseString=231;
				index=SpellEffect.UW1_Spell_Effect_Poison;//Poisoning
				break;
			case 186 :// a_bottle_of_ale_bottles_of_ale
				UseString=239;
				index=GetActualSpellIndex();
				break;
			case 187 :// a_red_potion
			case 188 :// a_green_potion
				UseString=240;
				index=GetActualSpellIndex();
				break;
			}
			
			
			playerUW.PlayerMagic.CastEnchantment(playerUW.gameObject,null,index,Magic.SpellRule_TargetSelf );
			
			if (UseString !=-1)
			{
				ml.Add (playerUW.StringControl.GetString (1,UseString));
			}
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

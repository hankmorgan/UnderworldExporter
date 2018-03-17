using UnityEngine;
using System.Collections;

public class Potion : enchantment_base {
	
	public override bool Eat ()
	{
		return use();
	}

	public override bool use ()
	{
		if (UWCharacter.Instance.playerInventory.ObjectInHand=="")
		{
			int index=0; //= GetActualSpellIndex();
			int UseString=-1;
			switch (objInt().item_id)
			{
			case 184 :// a_mushroom
				UseString=StringController.str_the_mushroom_causes_your_head_to_spin_and_your_vision_to_blur_;
				index=SpellEffect.UW1_Spell_Effect_Hallucination;//Tripping
				break;
			case 185 :// a_toadstool
				UseString=StringController.str_the_toadstool_tastes_odd_and_you_begin_to_feel_ill_;
				index=SpellEffect.UW1_Spell_Effect_Poison;//Poisoning
				break;
			case 186 :// a_bottle_of_ale_bottles_of_ale
				UseString=StringController.str_you_drink_the_dark_ale_;
				index=base.GetActualSpellIndex();
				break;
			case 187 :// a_red_potion
			case 188 :// a_green_potion
			default:
				UseString=StringController.str_you_quaff_the_potion_in_one_gulp_;
				index=GetActualSpellIndex();
				break;
			}
		
			UWCharacter.Instance.PlayerMagic.CastEnchantment(UWCharacter.Instance.gameObject,null,index,Magic.SpellRule_TargetSelf,Magic.SpellRule_Consumable );
			
			if (UseString !=-1)
			{
				UWHUD.instance.MessageScroll.Add (StringController.instance.GetString (1,UseString));
			}
			objInt().consumeObject();

			return true;
		}
		else
		{
			//return UWCharacter.Instance.playerInventory.GetGameObjectInHand().GetComponent<ObjectInteraction>().FailMessage();
			return ActivateByObject(UWCharacter.Instance.playerInventory.GetGameObjectInHand());
		}
	}

	protected override int GetActualSpellIndex ()
	{
		return objInt().link - 256;//527;
	}



	public override bool ApplyAttack (short damage)
	{
		objInt().quality-=damage;
		if (objInt().quality<=0)
		{
			ChangeType(213,23);//Change to debris.
			this.gameObject.AddComponent<enchantment_base>();//Add a generic object base for behaviour. THis is the famous magic debris
			//objInt().objectloaderinfo.InUseFlag=0;
			Destroy(this);//Remove the potion enchantment.
		}
		return true;
	}


		public override string UseVerb ()
		{
				return "consume";
		}
}

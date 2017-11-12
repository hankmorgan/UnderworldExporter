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
			
			
			UWCharacter.Instance.PlayerMagic.CastEnchantment(UWCharacter.Instance.gameObject,null,index,Magic.SpellRule_TargetSelf );
			
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

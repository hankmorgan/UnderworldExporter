using UnityEngine;
using System.Collections;

public class Weapon : Equipment {

	public int AccuracyBonus;
	public int DamageBonus;

	public override bool use ()
	{
		if (GameWorldController.instance.playerUW.playerInventory.ObjectInHand =="")
		{
			if (((this.objInt().inventorySlot==7) && (GameWorldController.instance.playerUW.isLefty==false)) || ((this.objInt().inventorySlot==8) && (GameWorldController.instance.playerUW.isLefty==true)))
			{
				if(UWCharacter.InteractionMode==UWCharacter.InteractionModeAttack)
				{
					UWCharacter.InteractionMode=UWCharacter.InteractionModeUse;		
				}
				else
				{
					UWCharacter.InteractionMode=UWCharacter.InteractionModeAttack;				
				}
			}
			InteractionModeControl.UpdateNow=true;
						return true;
		}
		return false;
	}

	public virtual void WeaponSelfDamage()
	{//Damage caused to the weapon when it hits something with heavy resistance.
		objInt().Quality-=1;
		if (objInt().Quality<=0)
		{
			ChangeType(218,23);//Change to debris.
			this.gameObject.AddComponent<object_base>();//Add a generic object base for behaviour
			GameWorldController.instance.playerUW.PlayerCombat.currWeapon=null;
			Destroy(this);//Kill me now.
		}
	}

	public override bool EquipEvent (int slotNo)
	{
		//GameWorldController.instance.playerUW.PlayerCombat.currWeapon= this;
		if (((slotNo ==7) && (GameWorldController.instance.playerUW.isLefty==false)) || ((slotNo ==8) && (GameWorldController.instance.playerUW.isLefty==true)))
		{
			if (this.GetComponent<WeaponRanged>()!=null)
			{
				GameWorldController.instance.playerUW.PlayerCombat.currWeaponRanged=(WeaponRanged)this;
			}
			if (this.GetComponent<WeaponMelee>()!=null)
			{
				GameWorldController.instance.playerUW.PlayerCombat.currWeapon=(WeaponMelee)this;
			}

			if (objInt().isEnchanted==true)
			{
				int EffectId = GetActualSpellIndex ();
				switch (EffectId )
				{
				case SpellEffect.UW1_Spell_Effect_MinorAccuracy:
				case SpellEffect.UW1_Spell_Effect_Accuracy:
				case SpellEffect.UW1_Spell_Effect_AdditionalAccuracy:
				case SpellEffect.UW1_Spell_Effect_MajorAccuracy:
				case SpellEffect.UW1_Spell_Effect_GreatAccuracy:
				case SpellEffect.UW1_Spell_Effect_VeryGreatAccuracy:
				case SpellEffect.UW1_Spell_Effect_TremendousAccuracy:
				case SpellEffect.UW1_Spell_Effect_UnsurpassedAccuracy:
					this.AccuracyBonus =  EffectId - 447;
					break;
				case SpellEffect.UW1_Spell_Effect_MinorDamage:
				case SpellEffect.UW1_Spell_Effect_Damage:
				case SpellEffect.UW1_Spell_Effect_AdditionalDamage:
				case SpellEffect.UW1_Spell_Effect_MajorDamage:
				case SpellEffect.UW1_Spell_Effect_GreatDamage:
				case SpellEffect.UW1_Spell_Effect_VeryGreatDamage:
				case SpellEffect.UW1_Spell_Effect_TremendousDamage:
				case SpellEffect.UW1_Spell_Effect_UnsurpassedDamage:
					this.DamageBonus = EffectId-455;
					break;
				}
			}
		}
		return true;
	}

	public override bool UnEquipEvent (int slotNo)
	{
		if (((slotNo ==7) && (GameWorldController.instance.playerUW.isLefty==false)) || ((slotNo ==8) && (GameWorldController.instance.playerUW.isLefty==true)))
		{
			GameWorldController.instance.playerUW.PlayerCombat.currWeapon = null;
			GameWorldController.instance.playerUW.PlayerCombat.currWeaponRanged = null;
		}
		return false;
	}


}

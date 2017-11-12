using UnityEngine;
using System.Collections;

public class Weapon : Equipment {

	//public int AccuracyBonus;
	//public int DamageBonus;

	public override bool use ()
	{
		if (UWCharacter.Instance.playerInventory.ObjectInHand =="")
		{
			if (((this.objInt().inventorySlot==7) && (UWCharacter.Instance.isLefty==false)) || ((this.objInt().inventorySlot==8) && (UWCharacter.Instance.isLefty==true)))
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
		else
		{
			return ActivateByObject(UWCharacter.Instance.playerInventory.GetGameObjectInHand());
		}
		//return false;
	}

	//public virtual void WeaponSelfDamage()
	//{//Damage caused to the weapon when it hits something with heavy resistance.
		//
	//}

	public override bool EquipEvent (short slotNo)
	{
		//UWCharacter.Instance.PlayerCombat.currWeapon= this;
		if (((slotNo ==7) && (UWCharacter.Instance.isLefty==false)) || ((slotNo ==8) && (UWCharacter.Instance.isLefty==true)))
		{
			if (this.GetComponent<WeaponRanged>()!=null)
			{
				UWCharacter.Instance.PlayerCombat.currWeaponRanged=(WeaponRanged)this;
			}
			if (this.GetComponent<WeaponMelee>()!=null)
			{
				UWCharacter.Instance.PlayerCombat.currWeapon=(WeaponMelee)this;
			}

			/*if (objInt().isEnchanted()==true)
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
			}*/
		}
		return true;
	}

	public override bool UnEquipEvent (short slotNo)
	{
		if (((slotNo ==7) && (UWCharacter.Instance.isLefty==false)) || ((slotNo ==8) && (UWCharacter.Instance.isLefty==true)))
		{
			UWCharacter.Instance.PlayerCombat.currWeapon = null;
			UWCharacter.Instance.PlayerCombat.currWeaponRanged = null;
		}
		return false;
	}


}

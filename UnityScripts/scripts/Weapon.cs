using UnityEngine;
using System.Collections;

public class Weapon : Equipment {

	public int AccuracyBonus;
	public int DamageBonus;

	public override bool EquipEvent (int slotNo)
	{
		//playerUW.PlayerCombat.currWeapon= this;
		if (((slotNo ==7) && (playerUW.isLefty==false)) || ((slotNo ==8) && (playerUW.isLefty==true)))
		{
			if (this.GetComponent<WeaponRanged>()!=null)
			{
				playerUW.PlayerCombat.currWeaponRanged=(WeaponRanged)this;
			}
			if (this.GetComponent<WeaponMelee>()!=null)
			{
				playerUW.PlayerCombat.currWeapon=(WeaponMelee)this;
			}

			if (objInt.isEnchanted==true)
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
		if (((slotNo ==7) && (playerUW.isLefty==false)) || ((slotNo ==8) && (playerUW.isLefty==true)))
		{
			playerUW.PlayerCombat.currWeapon = null;
			playerUW.PlayerCombat.currWeaponRanged = null;
		}
		return false;
	}


}

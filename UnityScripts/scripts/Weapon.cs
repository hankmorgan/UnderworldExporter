using UnityEngine;
using System.Collections;

public class Weapon : Equipment {

	//public SpellEffect SpellEffectApplied;
	public int AccuracyBonus;
	public int DamageBonus;
	public int Skill;
	//public int Durability;
	public int Slash;
	public int Bash;
	public int Stab;

	public override bool EquipEvent (int slotNo)
	{
		playerUW.PlayerCombat.currWeapon= this;
		if (((slotNo ==7) && (playerUW.isLefty==false)) || ((slotNo ==8) && (playerUW.isLefty==true)))
		{
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


				/*
				//cast enchantment.
				SpellEffectApplied = playerUW.PlayerMagic.CastEnchantment(playerUW.gameObject,GetActualSpellIndex());
				if (SpellEffectApplied!=null)
				{
					SpellEffectApplied.SetPermanent(true);
				}
				*/
			}
		}
		return true;
	}

	public override bool UnEquipEvent (int slotNo)
	{
		if (((slotNo ==7) && (playerUW.isLefty==false)) || ((slotNo ==8) && (playerUW.isLefty==true)))
		{
			//if (SpellEffectApplied!=null)
			//{
			//	SpellEffectApplied.CancelEffect();
			//	return true;
			//}
			playerUW.PlayerCombat.currWeapon= null;
		}
		return false;
	}

	public virtual void onHit(GameObject target)
	{//Apply any posible magic effects when the weapon strikes.
		if (objInt.isEnchanted==true)
		{
			int EffectId = GetActualSpellIndex ();
			if (EffectId<=447)
			{//Not a standard effect
				//Debug.Log ("Casting + "+EffectId + " on " + target.name);
				playerUW.PlayerMagic.CastEnchantmentImmediate(playerUW.gameObject,target,EffectId,Magic.SpellRule_TargetOther);
			}
		}
	}
}

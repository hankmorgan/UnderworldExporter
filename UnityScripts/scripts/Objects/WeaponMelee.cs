using UnityEngine;
using System.Collections;

/// <summary>
/// Melee Weapons.
/// </summary>
public class WeaponMelee : Weapon {
			

	/// <summary>
	/// Apply any possible magic effects when the weapon strikes.
	/// </summary>
	/// <param name="target">The entity that is hit by the weapon</param>
	public virtual void onHit(GameObject target)
	{
        if (target == null) { return; }
		if (objInt().isEnchanted==true)
		{
			int EffectId = GetActualSpellIndex ();
			//if (EffectId<=447)
			//{//Not a standard effect
				UWCharacter.Instance.PlayerMagic.CastEnchantmentImmediate(UWCharacter.Instance.gameObject,target,EffectId,Magic.SpellRule_TargetOther,Magic.SpellRule_Immediate);
			//}
		}
	}

		/// <summary>
		/// Gets the slash base damage
		/// </summary>
		/// <returns>The slash damage</returns>
		public short GetSlash()
		{
			return (short)(GameWorldController.instance.objDat.weaponStats[item_id].Slash);
		}

		/// <summary>
		/// Gets the bash base damage
		/// </summary>
		/// <returns>The bash damage</returns>
		public short GetBash()
		{
			return (short)(GameWorldController.instance.objDat.weaponStats[item_id].Bash);
		}

		/// <summary>
		/// Gets the stab damage
		/// </summary>
		/// <returns>The stab damage</returns>
		public short GetStab()
		{
			return (short)(GameWorldController.instance.objDat.weaponStats[item_id].Stab);
		}


		/// <summary>
		/// Gets the durability of the weapon.
		/// </summary>
		/// <returns>The durability.</returns>
		public override short getDurability()
		{
			return (short)(GameWorldController.instance.objDat.weaponStats[item_id].Durability+DurabilityBonus());
		}


		/// <summary>
		/// Gets the melee slash value
		/// </summary>
		/// <returns>The melee slash.</returns>
		public static short getMeleeSlash()
		{
			return GameWorldController.instance.objDat.weaponStats[15].Slash;
		}

		/// <summary>
		/// Gets the melee bash value
		/// </summary>
		/// <returns>The melee bash.</returns>
		public static short getMeleeBash()
		{
			return GameWorldController.instance.objDat.weaponStats[15].Bash;
		}

		/// <summary>
		/// Gets the melee stab value.
		/// </summary>
		/// <returns>The melee stab.</returns>
		public static short getMeleeStab()
		{
			return GameWorldController.instance.objDat.weaponStats[15].Stab;
		}

		/// <summary>
		/// Gets the skill that this weapon uses
		/// </summary>
		/// <returns>The skill.</returns>
		public int GetSkill()
		{
			//return GameWorldController.instance.weaponprops.getPropSkill(item_id);
			return GameWorldController.instance.objDat.weaponStats[item_id].Skill;
		}

        public short GetMinCharge()
        {
            return (short)(GameWorldController.instance.objDat.weaponStats[item_id].MinCharge );
        }

        public short GetMaxCharge()
        {
            return (short)(GameWorldController.instance.objDat.weaponStats[item_id].MaxCharge );
        }



        public static short GetMeleeMinCharge()
        {
            return (short)(GameWorldController.instance.objDat.weaponStats[15].MinCharge);
        }

        public static short GetMeleeMaxCharge()
        {
            return (short)(GameWorldController.instance.objDat.weaponStats[15].MaxCharge);
        }

        public override void UpdateQuality ()
	    {
		    if ((quality>0) && (quality<=15))
		    {
				    //Shit quality
			    EquipIconIndex=  4;
		    }
		    else if ((quality>15) && (quality<=30))
		    {//bashed about
			    EquipIconIndex=  3;
		    }
		    else if ((quality>30) && (quality<=45))
		    {//medium
			    EquipIconIndex=  2;
		    }
		    else
		    {//best
			    EquipIconIndex=  1;
		    }
	    }

		/// <summary>
		/// Returns the damage bonus provided by the weapons enchantment
		/// </summary>
		/// <returns>The bonus.</returns>
	public short DamageBonus()
	{
        switch(_RES)
        {

            case GAME_UW2:
                {

                    switch(link)
                    {
                        case SpellEffect.UW2_Spell_Effect_MinorDamage:
                        case SpellEffect.UW2_Spell_Effect_MajorDamage:
                        case SpellEffect.UW2_Spell_Effect_GreatDamage:
                        case SpellEffect.UW2_Spell_Effect_UnsurpassedDamage:
                            {
                                int bonus = link - SpellEffect.UW2_Spell_Effect_MinorDamage;
                                bonus = (bonus << 1) + 1;
                                return (short)bonus;
                            }
                    }
                    break;
                }
            default:
                {
                    switch(link)
                    {
                        case SpellEffect.UW1_Spell_Effect_MinorDamage:
                        case SpellEffect.UW1_Spell_Effect_Damage:
                        case SpellEffect.UW1_Spell_Effect_AdditionalDamage:
                        case SpellEffect.UW1_Spell_Effect_MajorDamage:
                        case SpellEffect.UW1_Spell_Effect_GreatDamage:
                        case SpellEffect.UW1_Spell_Effect_VeryGreatDamage:
                        case SpellEffect.UW1_Spell_Effect_TremendousDamage:
                        case SpellEffect.UW1_Spell_Effect_UnsurpassedDamage:
                            {
                                int bonus = link - SpellEffect.UW1_Spell_Effect_MinorDamage;
                                bonus = (bonus << 1) + 1;
                                return (short)bonus;
                            }
                    }
                    break;
                }

        }
	    return 0;
	}


		/// <summary>
		/// Returns a bonus toHit score provided by the enchantment
		/// </summary>
		/// <returns>The bonus.</returns>
		public short AccuracyBonus()
		{
        switch (_RES)
        {
            case GAME_UW2:
                {
                    switch(link)
                    {
                        case SpellEffect.UW2_Spell_Effect_MinorAccuracy:
                        case SpellEffect.UW2_Spell_Effect_MajorAccuracy:
                        case SpellEffect.UW2_Spell_Effect_GreatAccuracy:
                        case SpellEffect.UW2_Spell_Effect_UnsurpassedAccuracy:
                            {
                                int bonus = link - SpellEffect.UW2_Spell_Effect_MinorAccuracy;
                                bonus = (bonus << 1) + 1;
                                return (short)bonus;
                            }
                    }

                break;
                }

            default:
                {
                    switch (link)
                    {//Note I have only confirmed this math in UW2 where there is not as many enchantments.
                        case SpellEffect.UW1_Spell_Effect_MinorAccuracy:
                        case SpellEffect.UW1_Spell_Effect_Accuracy:
                        case SpellEffect.UW1_Spell_Effect_AdditionalAccuracy:
                        case SpellEffect.UW1_Spell_Effect_MajorAccuracy:
                        case SpellEffect.UW1_Spell_Effect_GreatAccuracy:
                        case SpellEffect.UW1_Spell_Effect_VeryGreatAccuracy:
                        case SpellEffect.UW1_Spell_Effect_TremendousAccuracy:
                        case SpellEffect.UW1_Spell_Effect_UnsurpassedAccuracy:
                            {
                                int bonus = link - SpellEffect.UW1_Spell_Effect_MinorAccuracy;
                                bonus = (bonus << 1) + 1;
                                return (short)bonus;
                            }
                    }

                    break;
                }

        }

			return 0;
		}

	public override bool LookAt ()
	{
		if ( (_RES==GAME_UW1) && (item_id==Quest.TalismanSword))
		{
				heading=7;
				switch(objInt().identity())
				{
				case ObjectInteraction.IdentificationFlags.Identified:
					UWHUD.instance.MessageScroll.Add (StringController.instance.GetString(1,StringController.str_you_see_) +  StringController.instance.GetString(1,268));
					break;
				default:
					UWHUD.instance.MessageScroll.Add (StringController.instance.GetFormattedObjectNameUW(objInt(),GetEquipmentConditionString()) + OwnershipString());		
					break;
				}
				return true;
		}
		else
		{
			return base.LookAt ();				
		}
		
	}

    public override int repairEstimate()
    {
        return GameWorldController.instance.objDat.weaponStats[item_id].Durability;
    }

}


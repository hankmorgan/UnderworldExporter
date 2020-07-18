using UnityEngine;
using System.Collections;

public class Shield : Equipment
{
    public SpellEffect SpellEffectApplied;

    public override int GetActualSpellIndex()
    {
        return link - 240;
    }

    public override short Protection()
    {
        //Per disassembly calculation for base protection offered by armour is
        // 1 + ((quality X protection stat)>>6)
        return (short)(1 + ((GameWorldController.instance.objDat.armourStats[item_id - 32].protection * quality) >> 6) + ProtectionBonus());
    }

    public override bool EquipEvent(short slotNo)
    {
        if (((slotNo == 7) && (UWCharacter.Instance.isLefty == true)) || ((slotNo == 8) && (UWCharacter.Instance.isLefty == false)))//Only on off hand
        {
            UpdateQuality();
            if (objInt().isEnchanted == true)
            {
                switch (_RES)
                {
                    case GAME_UW2:
                        {
                            int EffectId = GetActualSpellIndex();
                            switch (EffectId)
                            {
                                case SpellEffect.UW2_Spell_Effect_MinorProtection:
                                case SpellEffect.UW2_Spell_Effect_Protection:
                                case SpellEffect.UW2_Spell_Effect_AdditionalProtection:
                                case SpellEffect.UW2_Spell_Effect_MajorProtection:
                                case SpellEffect.UW2_Spell_Effect_GreatProtection:
                                case SpellEffect.UW2_Spell_Effect_VeryGreatProtection:
                                case SpellEffect.UW2_Spell_Effect_TremendousProtection:
                                case SpellEffect.UW2_Spell_Effect_UnsurpassedProtection:
                                    break;
                                case SpellEffect.UW2_Spell_Effect_MinorToughness:
                                case SpellEffect.UW2_Spell_Effect_Toughness:
                                case SpellEffect.UW2_Spell_Effect_AdditionalToughness:
                                case SpellEffect.UW2_Spell_Effect_MajorToughness:
                                case SpellEffect.UW2_Spell_Effect_GreatToughness:
                                case SpellEffect.UW2_Spell_Effect_VeryGreatToughness:
                                case SpellEffect.UW2_Spell_Effect_TremendousToughness:
                                case SpellEffect.UW2_Spell_Effect_UnsurpassedToughness:
                                    break;
                                default:
                                    //cast enchantment.
                                    SpellEffectApplied = UWCharacter.Instance.PlayerMagic.CastEnchantment(UWCharacter.Instance.gameObject, null, GetActualSpellIndex(), Magic.SpellRule_TargetSelf, Magic.SpellRule_Equipable);
                                    if (SpellEffectApplied != null)
                                    {
                                        SpellEffectApplied.SetPermanent(true);
                                    }
                                    break;
                            }
                            break;
                        }


                    default:
                        {
                            int EffectId = GetActualSpellIndex();
                            switch (EffectId)
                            {
                                case SpellEffect.UW1_Spell_Effect_MinorProtection:
                                case SpellEffect.UW1_Spell_Effect_Protection:
                                case SpellEffect.UW1_Spell_Effect_AdditionalProtection:
                                case SpellEffect.UW1_Spell_Effect_MajorProtection:
                                case SpellEffect.UW1_Spell_Effect_GreatProtection:
                                case SpellEffect.UW1_Spell_Effect_VeryGreatProtection:
                                case SpellEffect.UW1_Spell_Effect_TremendousProtection:
                                case SpellEffect.UW1_Spell_Effect_UnsurpassedProtection:
                                    //ProtectionBonus=(short)(EffectId-463);
                                    break;
                                case SpellEffect.UW1_Spell_Effect_MinorToughness:
                                case SpellEffect.UW1_Spell_Effect_Toughness:
                                case SpellEffect.UW1_Spell_Effect_AdditionalToughness:
                                case SpellEffect.UW1_Spell_Effect_MajorToughness:
                                case SpellEffect.UW1_Spell_Effect_GreatToughness:
                                case SpellEffect.UW1_Spell_Effect_VeryGreatToughness:
                                case SpellEffect.UW1_Spell_Effect_TremendousToughness:
                                case SpellEffect.UW1_Spell_Effect_UnsurpassedToughness:
                                    //ToughnessBonus=(short)(EffectId-471);
                                    break;
                                default:
                                    //cast enchantment.
                                    SpellEffectApplied = UWCharacter.Instance.PlayerMagic.CastEnchantment(UWCharacter.Instance.gameObject, null, GetActualSpellIndex(), Magic.SpellRule_TargetSelf, Magic.SpellRule_Equipable);
                                    if (SpellEffectApplied != null)
                                    {
                                        SpellEffectApplied.SetPermanent(true);
                                    }
                                    break;
                            }
                            break;
                        }
                }
            }
        }
        return true;
    }


    public override bool LookAt()
    {
        if ((_RES == GAME_UW1) && (item_id == Quest.TalismanShield))
        {
            heading = 7;
            switch (objInt().identity())
            {
                case ObjectInteraction.IdentificationFlags.Identified:
                    UWHUD.instance.MessageScroll.Add(StringController.instance.GetString(1, StringController.str_you_see_) + StringController.instance.GetString(1, 266));
                    break;
                default:
                    UWHUD.instance.MessageScroll.Add(StringController.instance.GetFormattedObjectNameUW(objInt(), GetEquipmentConditionString()) + OwnershipString());
                    break;
            }
            return true;
        }
        else
        {
            return base.LookAt();
        }
    }
}



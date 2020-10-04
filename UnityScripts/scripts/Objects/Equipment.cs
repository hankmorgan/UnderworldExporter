using UnityEngine;
using System.Collections;
using UnityEngine.UI;
/// <summary>
/// Base class for weapons and armour
/// </summary>
public class Equipment : object_base
{

    public int EquipIconIndex;

    public string DisplayEnchantment;

    protected override void Start()
    {
        base.Start();
        UpdateQuality();
        SetDisplayEnchantment();
    }

    /// <summary>
    /// Pulls in the enchantment name on this object for use in the context menu
    /// </summary>
    public void SetDisplayEnchantment()
    {
        DisplayEnchantment = StringController.instance.GetString(6, GetActualSpellIndex());
        if (DisplayEnchantment == "")
        {
            DisplayEnchantment = "NONE";
        }
    }

    public virtual int GetActualSpellIndex()
    {
        return link - 256;
    }

    public override bool use()
    {
        if (CurrentObjectInHand != null)
        {
            return ActivateByObject(CurrentObjectInHand);
        }
        else
        {
            return false;
        }
    }


    /// <summary>
    /// Activation of this object by another. EG key on door
    /// </summary>
    /// <returns>true</returns>
    /// <c>false</c>
    /// <param name="ObjectUsed">Object used.</param>
    /// Handles anvil usage
    public override bool ActivateByObject(ObjectInteraction ObjectUsed)
    {
        //ObjectInteraction objIntUsed = ObjectUsed.GetComponent<ObjectInteraction>();
        if (ObjectUsed != null)
        {
            switch (ObjectUsed.GetItemType())
            {
                case ObjectInteraction.ANVIL: //ANVIL
                    {
                        //Do a difficulty check and prompt for approval.
                        int RepairDifficulty = repairEstimate();
                        int estimateStringNo=0;
                        int repairStringOffset = StringController.str_you_think_it_will_be_;
                        if (_RES==GAME_UW2)
                        {
                            repairStringOffset = 231;
                        }
                        if (RepairDifficulty == -1)
                        {
                            UWHUD.instance.MessageScroll.Add(StringController.instance.GetString(1, StringController.str_you_cannot_repair_that_));
                            return true;
                        }
                        else
                        {
                            int estimate = RepairDifficulty - UWCharacter.Instance.PlayerSkills.Repair + 0xF;
                            if (estimate>=0x1E)
                                {
                                estimate = 4;
                                }
                            else
                            {
                                estimate = (estimate / 0xA) + 1;
                            }
                            estimateStringNo += repairStringOffset + estimate + 3 ;
                        }
                        

                        string question = StringController.instance.GetString(1, repairStringOffset)
                            + StringController.instance.GetString(1, estimateStringNo)
                            + StringController.instance.GetString(1, repairStringOffset + 1)
                            + StringController.instance.GetObjectNounUW(item_id)
                            + StringController.instance.GetString(1,StringController.str__make_an_attempt_ ); 

                        UWHUD.instance.MessageScroll.Set(question);
                        InputField inputctrl = UWHUD.instance.InputControl;
                        inputctrl.gameObject.SetActive(true);
                        inputctrl.gameObject.GetComponent<InputHandler>().target = this.gameObject;
                        inputctrl.gameObject.GetComponent<InputHandler>().currentInputMode = InputHandler.InputAnvil;
                        inputctrl.contentType = InputField.ContentType.Alphanumeric;
                        inputctrl.text = "No";
                        inputctrl.Select();
                        WindowDetect.WaitingForInput = true;
                        Time.timeScale = 0.0f;
                        return true;
                    }
            }
        }
        return false;
    }

    /// <summary>
    /// Refreshes the quality of armour when damage is taken
    /// </summary>
    public virtual void UpdateQuality()
    {//Template for repairing and updating the graphics on equipment. Used by armour mainly.
        return;
    }

    /// <summary>
    /// Event handler for processing the repair question y/n
    /// </summary>
    /// <param name="ans">Ans.</param>
    public void OnSubmitPickup(string ans)
    {
        Time.timeScale = 1.0f;
        UWHUD.instance.InputControl.gameObject.SetActive(false);
        WindowDetectUW.WaitingForInput = false;
        UWHUD.instance.MessageScroll.Clear();//="";
        if (ans.Substring(0, 1).ToUpper() == "Y")
        {
            //do the repair 
            //Play the cutscene.
            switch (_RES)
            {
                case GAME_UW2:
                    //todo
                    break;
                default:
                    UWHUD.instance.CutScenesSmall.anim.SetAnimation = "cs404.n01";
                    break;
            }          

            int RepairDifficulty = repairEstimate();

            Skills.SkillRollResult result = Skills.SkillRoll(UWCharacter.Instance.PlayerSkills.Repair, RepairDifficulty);

            switch (result)
            {
                case Skills.SkillRollResult.CriticalFailure://attempt fails. dice roll of 0-63. If repair skill is lower than result damage item by another roll (0-7)+4;
                    {
                        if (Random.Range(0,64) >= UWCharacter.Instance.PlayerSkills.Repair)
                        {
                            int damage = Random.Range(0, 7) + 4;
                            quality = (short)(quality - (short)damage);
                            if (quality>0)
                            {
                                UWHUD.instance.MessageScroll.Add(StringController.instance.GetString(1, StringController.str_you_damaged_the_) + StringController.instance.GetObjectNounUW(item_id));
                            }
                        }
                    }
                    break;
                case Skills.SkillRollResult.Failure://attempt fails. no change to item.
                    UWHUD.instance.MessageScroll.Add(StringController.instance.GetString(1, StringController.str_your_attempt_has_no_effect_on_the_) + StringController.instance.GetObjectNounUW(item_id) );
                    break;
                case Skills.SkillRollResult.Success://repair up to (repair skill/5+3)
                    int newQuality = (UWCharacter.Instance.PlayerSkills.Repair / 5 + 3);
                    if(quality>= newQuality)
                    {
                        UWHUD.instance.MessageScroll.Add(StringController.instance.GetString(1, StringController.str_your_attempt_has_no_effect_on_the_) + StringController.instance.GetObjectNounUW(item_id)) ;
                    }
                    else
                    {
                        quality = (short)newQuality;
                        if (quality > 63)
                        {
                            UWHUD.instance.MessageScroll.Add(StringController.instance.GetString(1, StringController.str_you_have_fully_repaired_the_) + StringController.instance.GetObjectNounUW(item_id) );
                            quality = 63;
                        }
                        else
                        {
                            UWHUD.instance.MessageScroll.Add(StringController.instance.GetString(1, StringController.str_you_have_partially_repaired_the_) + StringController.instance.GetObjectNounUW(item_id)) ;
                        }
                    }


                    break;
                case Skills.SkillRollResult.CriticalSuccess://fully repair the item.
                    quality = 63;
                    UWHUD.instance.MessageScroll.Add(StringController.instance.GetString(1,StringController.str_you_have_fully_repaired_the_) + StringController.instance.GetObjectNounUW(item_id) );
                    break;

            }


            if (quality <= 0)
            {
                //destroy the item.
                UWHUD.instance.MessageScroll.Add(StringController.instance.GetString(1, StringController.str_you_destroyed_the_) + StringController.instance.GetObjectNounUW(item_id));
                objInt().consumeObject();//ToDO: Create DEBRIS                
            }
            else
            {
                UpdateQuality();
            }            
        }
        //cancel the repair 
        CurrentObjectInHand = null;
     }

    public override bool LookAt()
    {
        if (objInt().isEnchanted == true)
        {
            switch (objInt().identity())
            {
                case ObjectInteraction.IdentificationFlags.Identified:
                    UWHUD.instance.MessageScroll.Add(StringController.instance.GetFormattedObjectNameUW(objInt(), GetEquipmentConditionString()) + " of " + StringController.instance.GetString(6, GetActualSpellIndex()) + OwnershipString());
                    SetDisplayEnchantment();
                    break;
                case ObjectInteraction.IdentificationFlags.Unidentified:
                case ObjectInteraction.IdentificationFlags.PartiallyIdentified:
                    //Try and re-id using lore skill
                    if (UWCharacter.Instance.PlayerSkills.TrySkill(Skills.SkillLore, getIdentificationLevels(GetActualSpellIndex())))
                    {
                        heading = 7;
                        UWHUD.instance.MessageScroll.Add(StringController.instance.GetFormattedObjectNameUW(objInt(), GetEquipmentConditionString()) + " of " + StringController.instance.GetString(6, GetActualSpellIndex()) + OwnershipString());
                    }
                    else
                    {
                        UWHUD.instance.MessageScroll.Add(StringController.instance.GetFormattedObjectNameUW(objInt(), GetEquipmentConditionString()) + OwnershipString());
                    }
                    break;
            }
            return true;
        }
        else
        {
            if (objInt().PickedUp == true)
            {
                UWHUD.instance.MessageScroll.Add(StringController.instance.GetFormattedObjectNameUW(objInt(), GetEquipmentConditionString()));
            }
            else
            {
                return base.LookAt();
            }
        }
        return true;
    }

    /// <summary>
    /// Gets the equipment condition.
    /// </summary>
    /// <returns>The equipment condition string.</returns>
    public virtual string GetEquipmentConditionString()
    {
        if (_RES == GAME_UW1)
        {
            if ((item_id == 10) || (item_id == 55) || (item_id == 47) || (item_id == 48) || (item_id == 49) || (item_id == 50))
            {
                return StringController.instance.GetString(5, 10);
            }
        }
        if ((quality > 0) && (quality <= 15))
        {//lowest
            return StringController.instance.GetString(5, 7);
        }
        else if ((quality > 15) && (quality <= 30))
        {
            //Low quality
            return StringController.instance.GetString(5, 8);

        }
        else if ((quality > 30) && (quality <= 45))
        {
            //Medium
            return StringController.instance.GetString(5, 9);
        }
        else //if ((quality>45))// && (quality<=63))
        {
            //Best
            return StringController.instance.GetString(5, 10);
        }
        //return " ";
    }


    /// <summary>
    /// Damage caused to the item when it hits or is hit by something with heavy resistance.
    /// </summary>
    public virtual void SelfDamage(short damage)
    {
        if (_RES == GAME_UW1)
        {
            if ((item_id == 10) || (item_id == 55) || (item_id == 47) || (item_id == 48) || (item_id == 49) || (item_id == 50))
            {//No damage to sword of justice shield of valor, dragonskin boots or crowns.
                return;
            }
        }
        short equipBefore = (short)EquipIconIndex;
        quality -= damage;
        UpdateQuality();
        if (quality <= 0)
        {
            UWHUD.instance.MessageScroll.Add("Your " + StringController.instance.GetSimpleObjectNameUW(item_id) + " was destroyed");
            ChangeType(208);//Change to debris.
            this.gameObject.AddComponent<object_base>();//Add a generic object base for behaviour
            if (this.GetComponent<Weapon>())
            {
                UWCharacter.Instance.PlayerCombat.currWeapon = null;
            }
        }
        else
        {
            if (equipBefore != EquipIconIndex)
            {
                UWHUD.instance.MessageScroll.Add("Your " + StringController.instance.GetSimpleObjectNameUW(item_id) + " was damaged");
            }
        }

    }


    /// <summary>
    /// Gets the defence score of this armour.
    /// </summary>
    /// <returns>The defence.</returns>
    public virtual short Protection()
    {
        //return GameWorldController.instance.objDat.armourStats[item_id-32].protection;	
        return 0;
    }

    public virtual short getDurability()
    {
        return (short)(0 + DurabilityBonus());
        //return GameWorldController.instance.objDat.armourStats[item_id-32].durability;	
    }


    /// <summary>
    /// Returns the durability bonus applied to the weapon from it's enchantment.
    /// </summary>
    /// <returns>The bonus.</returns>
    public short DurabilityBonus()
    {
        switch (link)
        {
            case SpellEffect.UW1_Spell_Effect_MinorToughness:
            case SpellEffect.UW1_Spell_Effect_Toughness:
            case SpellEffect.UW1_Spell_Effect_AdditionalToughness:
            case SpellEffect.UW1_Spell_Effect_MajorToughness:
            case SpellEffect.UW1_Spell_Effect_GreatToughness:
            case SpellEffect.UW1_Spell_Effect_VeryGreatToughness:
            case SpellEffect.UW1_Spell_Effect_TremendousToughness:
            case SpellEffect.UW1_Spell_Effect_UnsurpassedToughness:
                return (short)(link - 472);//Toughness bonus starts at +3 why not					
        }
        return 0;
    }


    public short ProtectionBonus()
    {
        switch (link)
        {
            case SpellEffect.UW1_Spell_Effect_MinorProtection:
            case SpellEffect.UW1_Spell_Effect_Protection:
            case SpellEffect.UW1_Spell_Effect_AdditionalProtection:
            case SpellEffect.UW1_Spell_Effect_MajorProtection:
            case SpellEffect.UW1_Spell_Effect_GreatProtection:
            case SpellEffect.UW1_Spell_Effect_VeryGreatProtection:
            case SpellEffect.UW1_Spell_Effect_TremendousProtection:
            case SpellEffect.UW1_Spell_Effect_UnsurpassedProtection:
                return (short)(link - 461);//Protection bonus starts at +3 why not					
        }
        return 0;
    }

    public override string ContextMenuDesc(int item_id)
    {
        if (objInt().isEnchanted)
        {
            switch (objInt().identity())
            {
                case ObjectInteraction.IdentificationFlags.Identified:
                    return StringController.instance.GetFormattedObjectNameUW(objInt()) + " of " + DisplayEnchantment;
                default:
                    return base.ContextMenuDesc(item_id);
            }
        }
        return base.ContextMenuDesc(item_id);
    }



}
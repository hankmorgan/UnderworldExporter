using UnityEngine;
using System.Collections;

public class a_hack_trap_class_item : a_hack_trap
{
    //Turns the item at index 995 in britannia castle into a specific item based on the skills of the player


        //TODO: disassembly has shown this is actually based on skills not class. FIX
        //Also probably the next item rather than specifically 995
        

    public override void ExecuteTrap(object_base src, int triggerX, int triggerY, int State)
    {
        if (this.next ==0)
        {
            Debug.Log("Hack Trap Class Item has no next!");
            return;
        }
        ObjectInteraction obj = ObjectLoader.getObjectIntAt(this.next);
        if (obj == null)
        {
            Debug.Log("Next item for hack trap item has no instance @" + this.next);
            return;
        }
        Destroy(obj.GetComponent<object_base>());//Remove object base from the existing item so it can be changed further on.

        
        //Get max magic skill score
        int MaxMagicSkillScore = Mathf.Max(UWCharacter.Instance.PlayerSkills.Casting, UWCharacter.Instance.PlayerSkills.ManaSkill);

        int MaxCombatSkillScore = 0;
        byte CombatSkillType = 0; //0=none, 1=sword, 2=axe, 3=mace; 4=missile, 5=unarmed.
        if ( UWCharacter.Instance.PlayerSkills.Sword>MaxCombatSkillScore)
            {
            MaxCombatSkillScore = UWCharacter.Instance.PlayerSkills.Sword;
            CombatSkillType = 1;
            }
        if (UWCharacter.Instance.PlayerSkills.Axe > MaxCombatSkillScore)
        {
            MaxCombatSkillScore = UWCharacter.Instance.PlayerSkills.Axe;
            CombatSkillType = 2;
        }
        if (UWCharacter.Instance.PlayerSkills.Mace > MaxCombatSkillScore)
        {
            MaxCombatSkillScore = UWCharacter.Instance.PlayerSkills.Mace;
            CombatSkillType = 3;
        }
        if (UWCharacter.Instance.PlayerSkills.Missile> MaxCombatSkillScore)
        {
            MaxCombatSkillScore = UWCharacter.Instance.PlayerSkills.Missile;
            CombatSkillType = 4;
        }
        if (UWCharacter.Instance.PlayerSkills.Unarmed > MaxCombatSkillScore)
        {
            MaxCombatSkillScore = UWCharacter.Instance.PlayerSkills.Unarmed;
            CombatSkillType = 5;
        }

        if ((MaxMagicSkillScore==0) && (MaxCombatSkillScore==0))
        {//Both scores are zero. Give a shield - they will need it!
            obj.item_id = 60;
            obj.WorldDisplayIndex = 60;
            obj.InvDisplayIndex = 60;
            obj.gameObject.AddComponent<Shield>();          
        }
        else
        {
            if (MaxMagicSkillScore > MaxCombatSkillScore)
            {//magic is higher. Give a mani stone
                obj.item_id = 244;
                obj.WorldDisplayIndex = 224;
                obj.InvDisplayIndex = 244;
                obj.gameObject.AddComponent<RuneStone>();
            }
            else
            {//combat is higher give a item based on the skill type.
                switch (CombatSkillType)
                {
                    case 1: //shortsword
                        obj.item_id = 4;
                        obj.WorldDisplayIndex = 4;
                        obj.InvDisplayIndex = 4;
                        obj.gameObject.AddComponent<WeaponMelee>();
                        break;
                    case 2: //hand axe/ 
                        obj.item_id = 0;
                        obj.WorldDisplayIndex = 0;
                        obj.InvDisplayIndex = 0;
                        obj.gameObject.AddComponent<WeaponMelee>();
                        break;
                    case 3: //cudgel
                        obj.item_id = 7;
                        obj.WorldDisplayIndex = 7;
                        obj.InvDisplayIndex = 7;
                        obj.gameObject.AddComponent<WeaponMelee>();
                        break;
                    case 4: // supply of slingstones
                        obj.item_id = 16;
                        obj.WorldDisplayIndex = 16;
                        obj.InvDisplayIndex = 16;
                        obj.isquant = 1;
                        obj.link = 10;
                        obj.gameObject.AddComponent<object_base>();
                        break;
                    default: //unarmed/gloves
                        obj.item_id = 38;
                        obj.WorldDisplayIndex = 38;
                        obj.InvDisplayIndex = 38;
                        obj.gameObject.AddComponent<Gloves>();
                        break;
                }
            }
        }

        obj.gameObject.name = ObjectLoader.UniqueObjectName(obj.BaseObjectData);
        obj.UpdateAnimation();

        //switch (UWCharacter.Instance.CharClass)
        //{
        //    //Gloves
        //    case UWCharacter.CharClassFighter://fighter
        //        obj.item_id = 38;
        //        obj.WorldDisplayIndex = 38;
        //        obj.InvDisplayIndex = 38;
        //        obj.gameObject.AddComponent<Gloves>();
        //        break;
        //    //Mani stone
        //    case UWCharacter.CharClassMage://mage
        //    case UWCharacter.CharClassBard://bard
        //    case UWCharacter.CharClassDruid://Druid
        //    case UWCharacter.CharClassShepard://shepherd
        //        obj.item_id = 244;
        //        obj.WorldDisplayIndex = 224;
        //        obj.InvDisplayIndex = 244;
        //        obj.gameObject.AddComponent<RuneStone>();
        //        break;
        //    //Shortsword
        //    case UWCharacter.CharClassTinker://tinker
        //    case UWCharacter.CharClassPaladin://paladin				
        //        obj.item_id = 4;
        //        obj.WorldDisplayIndex = 4;
        //        obj.InvDisplayIndex = 4;
        //        obj.gameObject.AddComponent<WeaponMelee>();
        //        break;
        //    //Shield
        //    case UWCharacter.CharClassRanger://ranger
        //        obj.item_id = 60;
        //        obj.WorldDisplayIndex = 60;
        //        obj.InvDisplayIndex = 60;
        //        obj.gameObject.AddComponent<Shield>();
        //        break;
        //}

    }
}
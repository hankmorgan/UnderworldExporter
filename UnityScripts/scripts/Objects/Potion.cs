using UnityEngine;
using System.Collections;

public class Potion : enchantment_base
{

    public ObjectInteraction linked;

    public override bool Eat()
    {
        return use();
    }

    public override bool use()
    {
        if (UWCharacter.Instance.playerInventory.ObjectInHand == "")
        {
            if (linked != null)
            {
                switch (linked.item_id)
                {
                    case 384://A damage trap
                        linked.gameObject.GetComponent<trap_base>().Activate(this, 0, 0, 0);
                        objInt().consumeObject();
                        return true;
                    default://A spell trap
                        UWCharacter.Instance.PlayerMagic.CastEnchantment(UWCharacter.Instance.gameObject, null, linked.gameObject.GetComponent<a_spell>().objInt().link - 256, Magic.SpellRule_TargetSelf, Magic.SpellRule_Consumable);
                        objInt().consumeObject();
                        return true;
                }
            }
            else
            {
                int UseString = -1;
                UseString = StringController.str_you_quaff_the_potion_in_one_gulp_;

                UWHUD.instance.MessageScroll.Add(StringController.instance.GetString(1, UseString));
                UWCharacter.Instance.PlayerMagic.CastEnchantment(UWCharacter.Instance.gameObject, null, GetActualSpellIndex(), Magic.SpellRule_TargetSelf, Magic.SpellRule_Consumable);
                objInt().consumeObject();
                return true;
            }  
        }
        else
        {
            return ActivateByObject(UWCharacter.Instance.playerInventory.GetGameObjectInHand());
        }
    }

    protected override int GetActualSpellIndex()
    {
        if (linked != null)
        {
            switch (linked.item_id)
            {
                case 384://A damage trap
                    return 116;
                default: //spell trap
                    return linked.link - 256;
            }
        }
        else
        {
            return objInt().link - 256;//527;
        }        
    }

    public override bool ApplyAttack(short damage)
    {
        objInt().quality -= damage;
        if (objInt().quality <= 0)
        {
            ChangeType(213);//Change to debris.
            this.gameObject.AddComponent<enchantment_base>();//Add a generic object base for behaviour. THis is the famous magic debris
                                                             //objInt().objectloaderinfo.InUseFlag=0;
            Destroy(this);//Remove the potion enchantment.
        }
        return true;
    }


    public override string UseVerb()
    {
        return "quaff"; //why not quaff a potion!
    }


    //To support potions that are linked to spells/damage traps
    public override void MoveToWorldEvent()
    {
        if ((objInt().isquant == 0) && (objInt().link < 256) && (objInt().link > 0))
        {//Object links to a spell.
            if (linked != null)
            {
                bool match = false;
                //Try and find a spell already in the level that matches the characteristics of this spell
                ObjectLoaderInfo[] objList = GameWorldController.instance.CurrentObjectList().objInfo;
                for (int i = 0; i <= objList.GetUpperBound(0); i++)
                {
                    if (objList[i].GetItemType() == linked.GetItemType())//Find a matching item type
                    {
                        if (objList[i].instance != null)
                        {
                            if ((objList[i].link == linked.link) && (objList[i].owner == linked.owner) && (objList[i].quality == linked.quality))
                            {
                                Destroy(linked.gameObject);
                                linked = objList[i].instance;
                                objInt().link = i;
                                match = true;
                                break;
                            }
                        }
                    }
                }

                if (!match)
                {
                    //linkedspell.gameObject.transform.parent=GameWorldController.instance.DynamicObjectMarker();
                    GameWorldController.MoveToWorld(linked.gameObject);
                }
            }
        }
    }

    public override void MoveToInventoryEvent()
    {
        if (linked != null)
        {
            GameObject clonelinkedspell = Object.Instantiate(linked.gameObject);
            clonelinkedspell.name = ObjectInteraction.UniqueObjectName(clonelinkedspell.GetComponent<ObjectInteraction>());
            clonelinkedspell.gameObject.transform.parent = GameWorldController.instance.InventoryMarker.transform;
            linked = clonelinkedspell.GetComponent<ObjectInteraction>();
        }
    }

    void MagicFood()
    {

    }

}

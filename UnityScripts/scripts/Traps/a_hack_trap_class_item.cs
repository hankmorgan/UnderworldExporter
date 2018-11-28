using UnityEngine;
using System.Collections;

public class a_hack_trap_class_item : a_hack_trap
{
    //Turns the item at index 995 in britannia castle into a class specific item.

    public override void ExecuteTrap(object_base src, int triggerX, int triggerY, int State)
    {
        ObjectInteraction obj = ObjectLoader.getObjectIntAt(995);

        if (obj == null)
        {
            return;
        }
        Destroy(obj.GetComponent<object_base>());
        switch (UWCharacter.Instance.CharClass)
        {
            //Gloves
            case UWCharacter.CharClassFighter://fighter
                obj.item_id = 38;
                obj.WorldDisplayIndex = 38;
                obj.InvDisplayIndex = 38;
                obj.gameObject.AddComponent<Gloves>();
                break;
            //Mani stone
            case UWCharacter.CharClassMage://mage
            case UWCharacter.CharClassBard://bard
            case UWCharacter.CharClassDruid://Druid
            case UWCharacter.CharClassShepard://shepherd
                obj.item_id = 244;
                obj.WorldDisplayIndex = 224;
                obj.InvDisplayIndex = 244;
                obj.gameObject.AddComponent<RuneStone>();
                break;
            //Shortsword
            case UWCharacter.CharClassTinker://tinker
            case UWCharacter.CharClassPaladin://paladin				
                obj.item_id = 4;
                obj.WorldDisplayIndex = 4;
                obj.InvDisplayIndex = 4;
                obj.gameObject.AddComponent<WeaponMelee>();
                break;
            //Shield
            case UWCharacter.CharClassRanger://ranger
                obj.item_id = 60;
                obj.WorldDisplayIndex = 60;
                obj.InvDisplayIndex = 60;
                obj.gameObject.AddComponent<Shield>();
                break;
        }
        obj.UpdateAnimation();
    }
}
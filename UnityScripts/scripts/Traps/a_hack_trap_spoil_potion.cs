using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Spoils your potion of cure poison and replaces it with a poisoning damage trap
/// </summary>
public class a_hack_trap_spoil_potion : a_hack_trap {

    //Change bottle type of the potion and link it to a damage trap.

    public override void ExecuteTrap(object_base src, int triggerX, int triggerY, int State)
    {
        foreach (Transform child in GameWorldController.instance.InventoryMarker.transform)
        {
            if (child.gameObject.GetComponent<ObjectInteraction>()!=null)
            {
                ObjectInteraction obj = child.gameObject.GetComponent<ObjectInteraction>();
                if (obj.GetItemType()==ObjectInteraction.POTIONS)
                {
                    if ((obj.link == 529) && (obj.enchantment ==1) && (obj.GetComponent<Potion>().linked == null))
                    {
                        SpoilPotion(obj);
                    }
                }
            }
        }
    }

    void SpoilPotion(ObjectInteraction obj)
    {
        obj.ChangeType(228);
        obj.isquant = 0;

        ObjectLoaderInfo newobjt = ObjectLoader.newWorldObject(384, 40, 1, 0, 256);
        newobjt.InUseFlag = 1;
        ObjectInteraction created = ObjectInteraction.CreateNewObject(CurrentTileMap(), newobjt, CurrentObjectList().objInfo, GameWorldController.instance.DynamicObjectMarker().gameObject, GameWorldController.instance.InventoryMarker.transform.position);
        GameWorldController.MoveToInventory(created);
        created.transform.parent = GameWorldController.instance.InventoryMarker.transform;
        obj.GetComponent<Potion>().linked = created;
        obj.GetComponent<Potion>().SetDisplayEnchantment();
    }
}

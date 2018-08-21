using UnityEngine;
using System.Collections;

/// <summary>
/// spawns vending selection
/// </summary>
public class a_hack_trap_vending : a_hack_trap
{
    public override void ExecuteTrap(object_base src, int triggerX, int triggerY, int State)
    {
        Vector3 spawn = CurrentTileMap().getTileVector(ObjectTileX, ObjectTileY);
        spawn = new Vector3(spawn.x, 4.4f, spawn.z);
        int ItemStringIndex = 0;
        int Price = 0;

        //Pick the item to sell and get its price
        switch (Quest.instance.variables[owner])
        {
            case 0://fish
                ItemStringIndex = 182;
                Price = 3;
                break;
            case 1://meat
                ItemStringIndex = 176;
                Price = 3;
                break;
            case 2://ale
                ItemStringIndex = 187;
                Price = 4;
                break;
            case 3://leeches
                ItemStringIndex = 293;
                Price = 4;
                break;
            case 4://water
                ItemStringIndex = 188;
                Price = 3;
                break;
            case 5://dagger
                ItemStringIndex = 3;
                Price = 11;
                break;
            case 6://lockpick
                ItemStringIndex = 257;
                Price = 6;
                break;
            case 7://torch
                ItemStringIndex = 145;
                Price = 4;
                break;
            default:
                return;
        }

        if (CheckPrice(Price, ObjectTileX, ObjectTileY))
        {//price check
            ObjectLoaderInfo newobjt = ObjectLoader.newObject(ItemStringIndex, 40, 0, 0, 256);
            newobjt.InUseFlag = 1;
            UnFreezeMovement(GameWorldController.MoveToWorld(ObjectInteraction.CreateNewObject(CurrentTileMap(), newobjt, CurrentObjectList().objInfo, GameWorldController.instance.DynamicObjectMarker().gameObject, spawn)).gameObject);
        }
    }


    /// <summary>
    /// Checks if enough gold is on the pad
    /// </summary>
    /// <param name="TargetPrice"></param>
    /// <param name="triggerX"></param>
    /// <param name="triggerY"></param>
    /// <returns></returns>
    bool CheckPrice(int TargetPrice, int triggerX, int triggerY)
    {
        Vector3 ContactArea = new Vector3(0.59f, 0.15f, 0.59f);
        Collider[] colliders = Physics.OverlapBox(CurrentTileMap().getTileVector(triggerX, triggerY), ContactArea);
        for (int i = 0; i <= colliders.GetUpperBound(0); i++)
        {
            if (colliders[i].gameObject.GetComponent<ObjectInteraction>() != null)
            {
                if (
                        (colliders[i].gameObject.GetComponent<ObjectInteraction>().item_id == 160)
                )
                {
                    if (colliders[i].gameObject.GetComponent<ObjectInteraction>().GetQty() >= TargetPrice)
                    {
                        for (int p = 0; p < TargetPrice; p++)
                        {//Only take what is needed 
                            colliders[i].gameObject.GetComponent<ObjectInteraction>().consumeObject();
                        }
                        return true;
                    }
                }
            }
        }
        return false;
    }
    
    public override void PostActivate(object_base src)
    {
        Debug.Log("Overridden PostActivate to test " + this.name);
        base.PostActivate(src);
    }
}

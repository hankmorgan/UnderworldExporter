using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SilverTree : object_base {

    public override bool PickupEvent()
    {
        base.PickupEvent();
        return PickUpSeed();
        //if (item_id == 458)
        //{//The seed is a sapling
        // //Turn it into a seed.
        // //objInt().ChangeType(290,objInt().GetItemType());
        //    item_id = 290;
        //    objInt().WorldDisplayIndex = 290;
        //    objInt().InvDisplayIndex = 290;
        //    AnimationOverlay animo = this.GetComponent<AnimationOverlay>();
        //    if (animo != null)
        //    {
        //        animo.Stop();
        //    }
        //    objInt().UpdateAnimation();//Update the inventory display
        //    UWHUD.instance.CursorIcon = objInt().GetInventoryDisplay().texture;
        //    objInt().SetWorldDisplay(objInt().GetInventoryDisplay());

        //    return true;
        //}
        //else
        //{
        //    return false;
        //}
    }

    public override bool use()
    {
        return PickUpSeed();
    }

    private bool PickUpSeed()
    {
        ObjectLoaderInfo newseed = ObjectLoader.newObject(290, 40, 16, 1, 256);
        newseed.is_quant = 1;
        ObjectInteraction newseedobj = ObjectInteraction.CreateNewObject
            (
            CurrentTileMap(),
            newseed,
            CurrentObjectList().objInfo,
            GameWorldController.instance.InventoryMarker.gameObject,
            CurrentTileMap().getTileVector(TileMap.ObjectStorageTile, TileMap.ObjectStorageTile)
            );
        GameWorldController.MoveToInventory(newseedobj.gameObject);
        UWCharacter.Instance.ResurrectPosition = Vector3.zero;
        UWCharacter.Instance.ResurrectLevel = 0;
        UWHUD.instance.MessageScroll.Add(StringController.instance.GetString(1, 9));
        CurrentObjectInHand = newseedobj;
        //newseedobj.UpdateAnimation();
        //UWHUD.instance.CursorIcon = newseedobj.GetWorldDisplay().texture;
        UWCharacter.InteractionMode=UWCharacter.InteractionModePickup;
		InteractionModeControl.UpdateNow=true;

        objInt().consumeObject();
        return true;
    }
}

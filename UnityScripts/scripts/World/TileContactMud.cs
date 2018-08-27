using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileContactMud : TileContactWater {


    protected override void TileContactEvent(ObjectInteraction obj, Vector3 position)
    {
        switch (obj.item_id)
        {
            case 230:
                if(obj.link==579)
                {//Potion of basilisk oil
                    BasiliskOilOnMud(obj);
                }
                break;
        }
        base.TileContactEvent(obj, position);
    }


    void BasiliskOilOnMud(ObjectInteraction obj)
    {
        if (Quest.instance.x_clocks[3]<2)
        {
            Quest.instance.x_clocks[3] = 2;
            //000~001~332~The thick oil permeates the mud. \n
            UWHUD.instance.MessageScroll.Add(StringController.instance.GetString(1, 332));
        }
    }

}

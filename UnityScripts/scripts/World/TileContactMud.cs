using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Used for throwing objects into special mud in UW2
/// </summary>
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

    /// <summary>
    /// Handles throwing basilisk oil into the mud in UW2.
    /// </summary>
    /// <param name="obj"></param>
    void BasiliskOilOnMud(ObjectInteraction obj)
    {
        if (Quest.instance.x_clocks[3]<2)
        {//Advance the xclock tracking quest progress.
            Quest.instance.x_clocks[3] = 2;
            //000~001~332~The thick oil permeates the mud. \n
            UWHUD.instance.MessageScroll.Add(StringController.instance.GetString(1, 332));
        }
    }

}

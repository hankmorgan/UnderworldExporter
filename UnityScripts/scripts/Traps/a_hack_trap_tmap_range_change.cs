using UnityEngine;
using System.Collections;

public class a_hack_trap_tmap_range_change : a_hack_trap
{
    //Looks like it changes a range of textures on TMAPs between the trap of the trigger object and the trap
    //Tmaps with an owner == 63 gets changed to 40 plus traps owner and their texture changes accordingly
    //This implementation is not fully correct yet!

    public override void ExecuteTrap(object_base src, int triggerX, int triggerY, int State)
    {
        int minX = Mathf.Min(triggerX, src.ObjectTileX);
        int minY = Mathf.Min(triggerY, src.ObjectTileY);
        int maxX = Mathf.Max(triggerX, src.ObjectTileX);
        int maxY = Mathf.Max(triggerY, src.ObjectTileY);
        //Ignore the range for the moment.
        minX = 0;
        minY = 0;
        maxX = 63;
        maxY = 63;
        ObjectLoaderInfo[] objList = CurrentObjectList().objInfo;
        for (int i = 0; i <= objList.GetUpperBound(0); i++)
        {
            if ((objList[i].item_id == 366) || (objList[i].item_id == 367))
            {
                if (objList[i].instance != null)
                {
                    if (
                            (objList[i].instance.ObjectTileX >= minX) &&
                            (objList[i].instance.ObjectTileX <= maxX) &&
                            (objList[i].instance.ObjectTileY >= minY) &&
                            (objList[i].instance.ObjectTileY <= maxY)
                            )
                    {
                        if (objList[i].instance.owner == 63)
                        {
                            TMAP tmap = objList[i].instance.GetComponent<TMAP>();
                            if (tmap != null)
                            {
                                tmap.owner = (short)(40 + owner);
                                tmap.TextureIndex = CurrentTileMap().texture_map[40 + owner];
                                TMAP.CreateTMAP(tmap.gameObject, tmap.TextureIndex);
                            }
                        }
                    }
                }
            }
        }
    }

    public override void PostActivate(object_base src)
    {
        Debug.Log("Overridden PostActivate to test " + this.name);
        base.PostActivate(src);
    }
}

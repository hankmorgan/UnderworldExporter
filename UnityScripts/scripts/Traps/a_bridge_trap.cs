using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Toggles a row of bridges of length = quality ?
/// Starts at trigger x and y
///  heading controls the direction (cardinal directions only) 0=north 2= east 4 = south. 6=west
///  zpos controls the height of the bridges
/// Owner is used to control the texture and if the highest bit is set on owner then the trap will
/// remove the bridges
/// </summary>
/// This trap appears to be fairly buggy in vanilla.
public class a_bridge_trap : trap_base {

    public override void ExecuteTrap(object_base src, int triggerX, int triggerY, int State)
    {
      
        if (((owner >> 5)  & 0x1) == 1)
        {
            DestroyBridges(triggerX, triggerY);
        }
        else
        {
            CreateBridges(triggerX, triggerY);
        }
    }


    /// <summary>
    /// Creates bridges in a line
    /// </summary>
    /// <param name="triggerX"></param>
    /// <param name="triggerY"></param>
    void CreateBridges(int triggerX, int triggerY)
    {
        int dirX = 0; int dirY = 0;
        GetDirectionsForBridgeTrap(ref dirX, ref dirY);

        for (int i = 0; i < quality; i++)
        {
            int tileX = triggerX + dirX * i;
            int tileY = triggerY + dirY * i;
            if (TileMap.ValidTile(tileX, tileY))
            {
                //Create a bridge at this tile. Only if no bridge is already there.
                if (ObjectLoader.findObjectByTypeInTile(GameWorldController.instance.CurrentObjectList().objInfo, (short)tileX, (short)tileY, ObjectInteraction.BRIDGE) == -1)
                {
                    ObjectLoaderInfo newObj = ObjectLoader.newObject(356, 40, 0, 0, 256);
                    newObj.xpos = 4; newObj.ypos = 4; newObj.zpos = zpos;
                    // bridge texture will be set by  (bridge.enchantment << 3) | bridge.flags & 0x3F;
                    newObj.flags = (short)(owner & 0x7);
                    newObj.enchantment = (short)((owner >> 3) & 0x1);
                    newObj.heading = heading;
                    newObj.ObjectTileX = (short)tileX;
                    newObj.ObjectTileY = (short)tileY;
                    Vector3 pos = ObjectLoader.CalcObjectXYZ(_RES, GameWorldController.instance.currentTileMap(),
                        GameWorldController.instance.currentTileMap().Tiles,
                        GameWorldController.instance.CurrentObjectList().objInfo, newObj.index, newObj.ObjectTileX, newObj.ObjectTileY, 0);
                    ObjectInteraction.CreateNewObject(GameWorldController.instance.currentTileMap(), newObj, GameWorldController.instance.CurrentObjectList().objInfo, GameWorldController.instance.LevelModel, pos);
                }
            }
        }
    }


    /// <summary>
    /// Gets the direction the bridges get created along
    /// </summary>
    /// <param name="dirX"></param>
    /// <param name="dirY"></param>
    private void GetDirectionsForBridgeTrap(ref int dirX, ref int dirY)
    {
        switch (heading)
        {
            case 0:
            case 1://North
                dirY = +1; break;
            case 2:
            case 3://East
                dirX = +1; break;
            case 4:
            case 5://South  
                dirY = -1; break;
            case 6:
            case 7://West
                dirX = -1; break;
        }
    }

    /// <summary>
    /// Destroys the bridges in a line
    /// </summary>
    /// <param name="triggerX"></param>
    /// <param name="triggerY"></param>
    void DestroyBridges(int triggerX, int triggerY)
    {
        int dirX = 0; int dirY = 0;
        GetDirectionsForBridgeTrap(ref dirX, ref dirY);

        for (int i = 0; i < quality; i++)
        {
            int tileX = triggerX + dirX * i;
            int tileY = triggerY + dirY * i;
            if (TileMap.ValidTile(tileX, tileY))
            {
                int index = ObjectLoader.findObjectByTypeInTile(GameWorldController.instance.CurrentObjectList().objInfo, (short)tileX, (short)tileY, ObjectInteraction.BRIDGE);
                //Create a bridge at this tile. Only if no bridge is already there.
                if (index != -1)
                {
                    ObjectInteraction obj = ObjectLoader.getObjectIntAt(index);
                    obj.consumeObject();
                }
            }
        }
    }
}

using UnityEngine;
using System.Collections;

public class a_change_terrain_trap : trap_base
{
    /*
    A change terrain trap changes a tile from one type to another. It works over a range of tiles that are set by the traps
    x,y values. In Underworld these are set by the the relative position of the trap within the tile.
    The tile it acts on is controlled by the trigger.

    Examples of it's usage
    The Moonstone room on Level2
    The path to the sword hilt on Level3

    */

    public override void ExecuteTrap(object_base src, int triggerX, int triggerY, int State)
    {
        //Debug.Log (this.name);
        int textureQuality = (quality >> 1) & 0xf;
        for (short x = 0; x <= xpos; x++)
        {
            for (short y = 0; y <= ypos; y++)
            {
                short tileXToChange = (short)(x + triggerX);
                short tileYToChange = (short)(y + triggerY);
                GameObject tile = GameWorldController.FindTile(tileXToChange, tileYToChange, TileMap.SURFACE_FLOOR);
                if (tile != null)
                {
                    TileInfo tileToChange = CurrentTileMap().Tiles[tileXToChange, tileYToChange];
                    //Destroy (tile);

                    switch (_RES)
                    {//I will probably have to change this again!
                     //case GAME_UW2:
                     //	tileToChange.floorTexture=textureQuality;
                     //	break;
                        default:
                            if (textureQuality < 10)
                            {
                                tileToChange.floorTexture = (short)textureQuality;//+48;
                                                                                  //tileToChange.floorTexture=CurrentTileMap().texture_map[textureQuality+48];
                            }
                            break;
                    }

                    //currobj.zpos >> 2
                    //(objList[k].zpos >> 2);
                    tileToChange.Render = true;
                    for (int v = 0; v < 6; v++)
                    {
                        tileToChange.VisibleFaces[v] = true;
                    }
                    short tileTypeToChangeTo = (short)(quality & 0x01);
                    short newTileHeight;// = (short)(zpos>>2);
                    if (zpos == 120)
                    {//If at this height use the trigger zpos for height instead.
                        newTileHeight = (short)(src.zpos >> 2);
                    }
                    else
                    {
                        newTileHeight = (short)(zpos >> 2);
                    }
                    short newWallTexture = tileToChange.wallTexture;
                    if (_RES == GAME_UW2)
                    {//Also the owner can be used to change wall texture. This means changing it's neighours.
                        if (owner < 63)
                        {
                            newWallTexture = owner;
                        }
                    }

                    //tileToChange.tileType=tileTypeToChangeTo;
                    tileToChange.DimX = 1;
                    tileToChange.DimY = 1;

                    ////tileToChange.floorHeight=newTileHeight;	
                    //tileToChange.floorHeight=tileToChange.floorHeight;//DOUBLE CHECK THIS
                    //water x tileToChange.isWater=TileMap.isTextureWater(CurrentTileMap().texture_map[ tileToChange.floorTexture]);
                    //TileMapRenderer.RenderTile(GameWorldController.instance.LevelModel,tileXToChange,tileYToChange,tileToChange,tileToChange.isWater,false,false,true);
                    tileToChange.TileNeedsUpdate();
                    TileMapRenderer.UpdateTile(tileXToChange, tileYToChange, tileTypeToChangeTo, newTileHeight, tileToChange.floorTexture, newWallTexture, false);
                    Destroy(tile);

                    if (tileToChange.IsDoorForNPC)
                    {//The door may be rendered
                        GameObject door = DoorControl.findDoor(tileToChange.tileX, tileToChange.tileY);
                        if (door != null)
                        {
                            string doorname = ObjectLoader.UniqueObjectName(door.GetComponent<ObjectInteraction>().objectloaderinfo);
                            DestroyDoorPortion("front_leftside_" + doorname);
                            DestroyDoorPortion("front_over_" + doorname);
                            DestroyDoorPortion("front_rightside_" + doorname);
                            DestroyDoorPortion("side1_filler_" + doorname);
                            DestroyDoorPortion("over_filler_" + doorname);
                            DestroyDoorPortion("side2_filler_" + doorname);
                            DestroyDoorPortion("front_filler_" + doorname);
                            DestroyDoorPortion("rear_leftside_" + doorname);
                            DestroyDoorPortion("rear_over_" + doorname);
                            DestroyDoorPortion("rear_rightside_" + doorname);
                            DestroyDoorPortion(doorname);
                            TileMapRenderer.RenderDoor(
                                    GameWorldController.instance.SceneryModel.gameObject,
                                    CurrentTileMap(),
                                    CurrentObjectList(),
                                    door.GetComponent<ObjectInteraction>().objectloaderinfo.index);
                            /*								TileMapRenderer.RenderDoorwayFront(
                                                            GameWorldController.instance.LevelModel,
                                                                                CurrentTileMap(),
                                                                                CurrentObjectList(),
                                                                                door.GetComponent<ObjectInteraction>().objectloaderinfo
                                                                                );
                                                            TileMapRenderer.RenderDoorwayRear(
                                                                            GameWorldController.instance.LevelModel,
                                                                            CurrentTileMap(),
                                                                            CurrentObjectList(),
                                                                            door.GetComponent<ObjectInteraction>().objectloaderinfo
                                                                                );*/
                            Vector3 objPos = door.transform.position;
                            ObjectInteraction.CreateNewObject(CurrentTileMap(),
                                                            door.GetComponent<ObjectInteraction>().objectloaderinfo,
                                                            CurrentObjectList().objInfo,
                                                            GameWorldController.instance.LevelModel, objPos
                                                    );

                        }
                    }
                }
                else
                {
                    Debug.Log(this.name + " Unable to find tile for change terrain trap " + tileXToChange + " " + tileYToChange);
                }
            }
        }

        GameWorldController.WorldReRenderPending = true;

        //	if ((owner<63) && (_RES==GAME_UW2))
        //	{
        //Now force re-render the tiles and their neighbours
        for (int x = -1; x <= xpos + 1; x++)
        {
            for (int y = -1; y <= ypos + 1; y++)
            {
                int tileXToChange = x + triggerX;
                int tileYToChange = y + triggerY;

                GameObject tile = GameWorldController.FindTile(tileXToChange, tileYToChange, TileMap.SURFACE_FLOOR);
                if (tile != null)
                {
                    Destroy(tile);
                }
                if ((tileXToChange >= 0) && (tileXToChange <= 63) && (tileYToChange >= 0) && (tileYToChange <= 63))
                {
                    TileInfo tileToChange = CurrentTileMap().Tiles[tileXToChange, tileYToChange];
                    tileToChange.Render = true;
                    for (int v = 0; v < 6; v++)
                    {
                        tileToChange.VisibleFaces[v] = true;
                    }
                    //water x tileToChange.isWater=TileMap.isTextureWater(CurrentTileMap().texture_map[ tileToChange.floorTexture]);
                    //TileMapRenderer.RenderTile(GameWorldController.instance.LevelModel,tileXToChange,tileYToChange,tileToChange,tileToChange.isWater,false,false,true);											
                    tileToChange.TileNeedsUpdate();
                }
            }
        }
        //}

    }

    public override void PostActivate(object_base src)
    {
        //	base.PostActivate ();
        Debug.Log("Overridden PostActivate to test " + this.name);
        base.PostActivate(src);
    }


    /// <summary>
    /// Destroy the door frame around a changed tile
    /// </summary>
    /// <param name="portionName"></param>
    public void DestroyDoorPortion(string portionName)
    {
        GameObject obj = GameObject.Find(portionName);
        if (obj != null)
        {
            Destroy(obj);
        }
    }
}

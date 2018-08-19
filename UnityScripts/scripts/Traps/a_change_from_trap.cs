using UnityEngine;
using System.Collections;

public class a_change_from_trap : trap_base
{
    //Theory. Untested 
    //This is used to change the tile type &  wall/floor texture on all tiles in a level.
    //The From trap defines the criteria
    //and the to trap defines the changes to make.
    //Heading seems to define a  floor texture to match for changing.
    //Nothing seems to define the range of tiles to change so it may be a global change
    //Therefore
    //Use the change_From trap to execute the changes using the values in the to trap.
    //Use the to trap as a placeholder to pass execution along in the link chain.

    public override void ExecuteTrap(object_base src, int triggerX, int triggerY, int State)
    {
        //return;
        //TileMap curr = GameWorldController.instance.currentTileMap();
        ObjectInteraction ChangeTo = null;
        if (link != 0)
        {
            ChangeTo = GameWorldController.instance.CurrentObjectList().objInfo[link].instance;
        }
        if (ChangeTo == null)
        {
            return;
        }

        short NewTileFloorTexture = (short)(ChangeTo.heading | (((ChangeTo.zpos >> 4) & 0x1) << 3));

        short tileFloorCriteria = (short)(heading | (((zpos >> 4) & 0x1) << 3));

        for (int x = 0; x <= 63; x++)
        {
            for (int y = 0; y <= 63; y++)
            {
                //	if (ChangeTo.quality<63)
                if (quality == GameWorldController.instance.currentTileMap().Tiles[x, y].wallTexture)
                {//This is probably a seperate test to the floor texture test above.

                    GameWorldController.instance.currentTileMap().Tiles[x, y].wallTexture = ChangeTo.quality;

                    if (GameWorldController.instance.currentTileMap().Tiles[x, y].floorTexture == tileFloorCriteria)//==heading)
                    {   //Putting this in this block could be wrong as well.
                        if (GameWorldController.instance.currentTileMap().Tiles[x, y].Render)
                        {
                            for (int v = 0; v < 6; v++)
                            {
                                GameWorldController.instance.currentTileMap().Tiles[x, y].VisibleFaces[v] = true;
                                GameWorldController.instance.currentTileMap().Tiles[x, y].VisibleFaces[v] = true;
                            }
                        }

                        GameWorldController.instance.currentTileMap().Tiles[x, y].floorTexture = NewTileFloorTexture;//ChangeTo.heading;
                        if (ChangeTo.owner < 10)
                        {
                            GameWorldController.instance.currentTileMap().Tiles[x, y].tileType = (short)ChangeTo.owner;
                        }
                        if (ChangeTo.zpos < 15)
                        {
                            GameWorldController.instance.currentTileMap().Tiles[x, y].floorHeight = ChangeTo.zpos;
                        }
                    }//end floor texture criteria.
                }
            }
        }
        //Re-render the level to see the changes
        //TODO:make this a tile based update rather than a full redraw.
        GameWorldController.instance.currentTileMap().SetTileMapWallFacesUW();//Update neighbour wall faces
        GameWorldController.WorldReRenderPending = true;//Request a world redraw at the next lateupdate.
        GameWorldController.FullReRender = true;
    }
}
using UnityEngine;
using System.Collections;

public class a_hack_trap_colour_cycle : a_hack_trap
{
    //cycles the tile textures between owner and quality. Mainly used in Talorus

    public override void ExecuteTrap(object_base src, int triggerX, int triggerY, int State)
    {
        TileMap tm = GameWorldController.instance.currentTileMap();
        short maxTexture = quality;
        short minTexture = owner;
        for (int x = triggerX; x <= triggerX + 4; x++)
        {
            for (int y = triggerY; y <= triggerY + 4; y++)
            {
                if (TileMap.ValidTile(x, y))
                {
                    tm.Tiles[x, y].floorTexture++;
                    if (tm.Tiles[x, y].floorTexture > maxTexture)
                    {
                        tm.Tiles[x, y].floorTexture = minTexture;
                    }
                    tm.Tiles[x, y].wallTexture++;
                    if (tm.Tiles[x, y].wallTexture > maxTexture)
                    {
                        tm.Tiles[x, y].wallTexture = minTexture;
                    }
                }
            }
        }
        GameWorldController.instance.currentTileMap().SetTileMapWallFacesUW();
        //Tell the tells and their neighbours to rerender.
        for (int x = triggerX - 1; x <= triggerX + 5; x++)
        {
            for (int y = triggerY - 1; y <= triggerY + 5; y++)
            {
                if (TileMap.ValidTile(x, y))
                {
                    tm.Tiles[x, y].TileNeedsUpdate();
                    GameObject tile = null;
                    GameObject tileWall = null;
                    switch (tm.Tiles[x, y].tileType)
                    {
                        case TileMap.TILE_DIAG_NE:
                        case TileMap.TILE_DIAG_SE:
                        case TileMap.TILE_DIAG_NW:
                        case TileMap.TILE_DIAG_SW:
                            tile = GameWorldController.FindTile(x, y, TileMap.SURFACE_FLOOR);
                            tileWall = GameWorldController.FindTile(x, y, TileMap.SURFACE_WALL);
                            break;
                        default:
                            tile = GameWorldController.FindTile(x, y, TileMap.SURFACE_FLOOR); break;
                            //default:

                    }
                    if (tile != null)
                    {
                        Destroy(tile);
                    }
                    if (tileWall != null)
                    {
                        Destroy(tileWall);
                    }
                }
            }
        }
    }

    public override void PostActivate(object_base src)
    {
        //Do not delete 
        //Debug.Log("Overridden PostActivate to test " + this.name);
        //base.PostActivate(src);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Collapses the ground underneath the player if it is of a certain height.
/// Works based on proximetry to the trap
/// </summary>
/// Example in Ice caverns is there is several of these connected to timer triggers.
/// Each covers a range of tiles.
/// WHen the player is standing in a tile that has a floor texture = owner (texture map) then the 
/// tile will collaps one step and it's texture will change to the value defined by xpos<<3 | ypos
public class a_hack_trap_floorcollapse : a_hack_trap {

    const int range = 10;

    public override void ExecuteTrap(object_base src, int triggerX, int triggerY, int State)
    {
        //Check if the player is in range of the trap
        if 
            (
            (TileMap.visitedTileX >=  triggerX - range)
            &&
            (TileMap.visitedTileY >= triggerY - range)
            &&
            (TileMap.visitedTileX <= triggerX + range)
            &&
            (TileMap.visitedTileY <= triggerY + range)
            )
        {
            //get the texture map of the floor the player is on.

        if (UWCharacter.Instance.Grounded)
            {
                int texture = CurrentTileMap().Tiles[TileMap.visitTileX, TileMap.visitTileY].floorTexture;
                if (texture == owner)
                {
                    TileInfo tileToChange = CurrentTileMap().Tiles[TileMap.visitTileX, TileMap.visitTileY];
                    if (tileToChange.floorHeight>=2)
                    {
                        tileToChange.floorTexture = (short)((ypos << 3) | xpos);
                        tileToChange.floorHeight -= 2;
                        tileToChange.Render = true;
                        for (int v = 0; v < 6; v++)
                        {
                            tileToChange.VisibleFaces[v] = true;
                        }
                        tileToChange.isWater = TileMap.isTextureWater(CurrentTileMap().texture_map[tileToChange.floorTexture]);
                        GameObject tile = GameWorldController.FindTile(TileMap.visitTileX, TileMap.visitTileY, TileMap.SURFACE_FLOOR);
                        if (tile != null)
                        {
                            Destroy(tile);
                        }
                        tileToChange.TileNeedsUpdate();
                    }
                }
            }
        }
    }

}

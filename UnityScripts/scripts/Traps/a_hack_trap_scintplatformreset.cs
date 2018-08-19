using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// A hack trap scintplatformreset.
/// </summary>
/// Resets the platforms on scint level 7
public class a_hack_trap_scintplatformreset : a_hack_trap
{

    public override void ExecuteTrap(object_base src, int triggerX, int triggerY, int State)
    {
        UpdateTile(25, 32, 0);
        UpdateTile(25, 35, 2);
        UpdateTile(25, 38, 1);
        UpdateTile(25, 41, 2);
        UpdateTile(25, 44, 2);

        UpdateTile(28, 32, 3);
        UpdateTile(28, 35, 1);
        UpdateTile(28, 38, 0);
        UpdateTile(28, 41, 1);
        UpdateTile(28, 44, 3);

        UpdateTile(31, 32, 0);
        UpdateTile(31, 35, 3);
        UpdateTile(31, 38, 1);
        UpdateTile(31, 41, 0);
        UpdateTile(31, 44, 2);

        UpdateTile(34, 32, 3);
        UpdateTile(34, 35, 0);
        UpdateTile(34, 38, 0);
        UpdateTile(34, 41, 0);
        UpdateTile(34, 44, 3);

    }


    public override void PostActivate(object_base src)
    {
        //Do not destroy
        Debug.Log("Overridden PostActivate to test " + this.name);
        base.PostActivate(src);
    }


    void UpdateTile(int tileXToChange, int tileYToChange, short newFloorTexture)
    {

        TileInfo tileToChange = GameWorldController.instance.currentTileMap().Tiles[tileXToChange, tileYToChange];
        if (tileToChange.floorTexture != newFloorTexture)
        {
            GameObject tile = GameWorldController.FindTile(tileXToChange, tileYToChange, TileMap.SURFACE_FLOOR);
            tileToChange.TileNeedsUpdate();
            tileToChange.isWater = false;
            TileMapRenderer.UpdateTile(tileXToChange, tileYToChange, tileToChange.tileType, 18, newFloorTexture, tileToChange.wallTexture, false);
            Destroy(tile);
        }
    }
}

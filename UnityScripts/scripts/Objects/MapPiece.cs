using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Copies a map chunk to another level map
/// </summary>
/// Owner-1 is the destination level
/// quality is a pointer to the map block to use. 70 + quality is the map to copy.
/// The link is a bit field of which eights of the src map to copy.
/// Ice caverns (fullmap) = quality=8  owner=25  link= 767

public class MapPiece : Map {

    public override bool use()
    {
        int unused = objInt().link & 0xff;
        if (unused >=1)
        {
            UWHUD.instance.MessageScroll.Add(StringController.instance.GetString(1, 9));            
            //Debug.Log("Copying map chunck " + objInt().link);
            CopyMap(70 + objInt().quality, objInt().owner -1); //Copy the map in  level 78 to the map in level 24
            objInt().link = objInt().link & 0x300;//Clear link bits 0-7
        }
        else
        {//use as a normal map
            OpenMap(objInt().owner - 1);
        }
        return true;
    }

    /// <summary>
    /// Copies an automap map/notes from one block and copies them to another block.
    /// </summary>
    /// <param name="SrcMap"></param>
    /// <param name="DstMap"></param>
    void CopyMap(int SrcMap, int DstMap)
    {
        if ((GameWorldController.instance.AutoMaps[SrcMap] != null) && (GameWorldController.instance.AutoMaps[DstMap] != null))
        {
            AutoMap src = GameWorldController.instance.AutoMaps[SrcMap];
            AutoMap dst = GameWorldController.instance.AutoMaps[DstMap];
            for (int x=0; x<=TileMap.TileMapSizeX;x++)
            {
                for (int y = 0; y <= TileMap.TileMapSizeY; y++)
                {
                    float angle = Mathf.Atan2 (y-31,x-31) * 180.0f / Mathf.PI;

                    //Check the angle between the map point and the center versus the bitfield controlling which sections get copied.
                    if (TestAngleAgainstBitField(angle, objInt().link & 0xFF))
                    {
                        if (dst.Tiles[x, y].DisplayType == 0)
                        {//Don't overwrite already visited tiles.
                            dst.Tiles[x, y].DisplayType = src.Tiles[x, y].DisplayType;
                            dst.Tiles[x, y].tileType = src.Tiles[x, y].tileType;
                        }
                    }
                }
            }
            for (int i = 0; i<src.MapNotes.Count; i++)
            {
                float angle = Mathf.Atan2(src.MapNotes[i].PosY - 100, src.MapNotes[i].PosX - 100) * 180.0f / Mathf.PI;

                if (TestAngleAgainstBitField(angle, objInt().link & 0xFF))
                {
                    dst.MapNotes.Add(new MapNote(src.MapNotes[i].PosX, src.MapNotes[i].PosY, src.MapNotes[i].NoteText));
                }
                 
            }
        }
    }

    /// <summary>
    /// Tests what eight of the map the point on the map is relative to the center. Bitfield controls what section gets copied.
    /// </summary>
    /// <param name="angle"></param>
    /// <param name="bitfield"></param>
    /// <returns></returns>
    bool TestAngleAgainstBitField(float angle, long bitfield)
    {            
        //TODO: The bit shifts below are wrong at the moment. Too lazy to fix now!
        //eights
        //0     1     2
        //7    Cent   3
        //6     5     4
        if (bitfield >= 512) { return true; }
        if ((angle <= 180) && (angle > 135))
        {
            //sector 0
            return ((bitfield >> 0) & 0x1) == 1;
        }
        if ((angle <=135) && (angle > 90))
        {
            //sector 1
            return ((bitfield >> 1) & 0x1) == 1;
        }

        if ((angle <= 90) && (angle > 45))
        {
            //sector 2
            return ((bitfield >> 2) & 0x1) == 1;
        }

        if ((angle <= 45) && (angle > 0))
        {
            //sector 3
            return ((bitfield >> 3) & 0x1) == 1;
        }

        if ((angle <= 0) && (angle > -45))
        {
            //sector 4
            return ((bitfield >> 4) & 0x1) == 1;
        }

        if ((angle <= -45) && (angle > -90))
        {
            //sector 5
            return ((bitfield >> 5) & 0x1) == 1;
        }

        if ((angle <= -90) && (angle > -135))
        {
            //sector 6
            return ((bitfield >> 6) & 0x1) == 1;
        }

        if ((angle <= -135) && (angle > -180))
        {
            //sector 7
            return ((bitfield >> 7) & 0x1) == 1;
        }

        return true;
    }
}

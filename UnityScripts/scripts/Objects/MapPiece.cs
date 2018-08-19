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
        int unused = link & 0xff;
        if (unused >=1)
        {
            UWHUD.instance.MessageScroll.Add(StringController.instance.GetString(1, 9));            
            //Debug.Log("Copying map chunck " + link);
            CopyMap(70 + quality, owner -1); //Copy the map in  level 78 to the map in level 24
            link = link & 0x300;//Clear link bits 0-7
        }
        else
        {//use as a normal map
            OpenMap(owner - 1);
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
                    if (TestAngleAgainstBitField(angle, link & 0xFF, x, y))
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

                if (TestAngleAgainstBitField(angle, link & 0xFF, (int)(src.MapNotes[i].PosX * 0.32f), (int)(src.MapNotes[i].PosY * 0.32f)))
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
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    bool TestAngleAgainstBitField(float angle, long bitfield, int x, int y)
    {
        //TODO: The bit shifts below are wrong at the moment. Too lazy to fix now!
        //eights
        //0     1     2
        //7    Cent   3
        //6     5     4
        //In uw2 usage on the tombs and ice caverns
        //hidden room -centre - 1 - bit 0
        //fire element - ne -  2 - bit 1 
        //presure plate room - north - 4 - bit 2
        //skeleton - north west - 8 - bit 3
        //switch room - west - 16 - bit 4
        //golem - south west - 32 - bit 5
        //spider room -south - 64 - bit 6
        //Assume se = 128 - bit 7
        //assume east = 256 - bit 8
        //Entire map = 512 - bit 9
        if (angle < 0) { angle += 360f; }
        float arcToTest =45f;
        bool inCenter = false;
        if ((x<=40) && (x>=24) && (y <= 40) && (y >= 24))
        {
            inCenter = true;
        }
        //Entire map = 512 - bit 10
        if (bitfield >= 512) { return true; }
        //Bit 0 center of map
        if ((bitfield & 0x1) == 1)
        {
            return inCenter;
        }

        //fire element - ne -  2 - bit 1 
        if (TestAngle(angle, 0f, 45, bitfield, 1))
        {
            return !inCenter;
        }
        //presure plate room - north - 4 - bit 2
        if (TestAngle(angle, 45f, 60, bitfield, 2))
        {
            return !inCenter;
        }
        //skeleton - north west - 8 - bit 3
        if (TestAngle(angle, 105f, 45, bitfield, 3))
        {
            return !inCenter;
        }
        //switch room - west - 16 - bit 4
        if (TestAngle(angle, 150f, 60, bitfield, 4))
        {
            return !inCenter;
        }
        //golem - south west - 32 - bit 5
        if (TestAngle(angle, 210f, 45, bitfield, 5))
        {
            return !inCenter;
        }
        //spider room -south - 64 - bit 6
        if (TestAngle(angle, 245f, 75, bitfield, 6))
        {
            return !inCenter;
        }
        //Assume se = 128 - bit 7
        if (TestAngle(angle, 320f, 40, bitfield, 7))
        {
            return !inCenter;
        }
        //assume east = 256 - bit 8
        // if (TestAngle(angle, 337.5f, bitfield, 8))
        //if ((angle>= 336.5 + offset) && (angle< 22.5 + offset))
        if (TestAngle(angle, 315f, arcToTest, bitfield, 8))
        {
            return !inCenter;
        }        
        return false;

        //if ((angle <= 180) && (angle > 135))
        //{
        //    //sector 0
        //    return ((bitfield >> 0) & 0x1) == 1;
        //}
        //if ((angle <=135) && (angle > 90))
        //{
        //    //sector 1
        //    return ((bitfield >> 1) & 0x1) == 1;
        //}

        //if ((angle <= 90) && (angle > 45))
        //{
        //    //sector 2
        //    return ((bitfield >> 2) & 0x1) == 1;
        //}

        //if ((angle <= 45) && (angle > 0))
        //{
        //    //sector 3
        //    return ((bitfield >> 3) & 0x1) == 1;
        //}

        //if ((angle <= 0) && (angle > -45))
        //{
        //    //sector 4
        //    return ((bitfield >> 4) & 0x1) == 1;
        //}

        //if ((angle <= -45) && (angle > -90))
        //{
        //    //sector 5
        //    return ((bitfield >> 5) & 0x1) == 1;
        //}

        //if ((angle <= -90) && (angle > -135))
        //{
        //    //sector 6
        //    return ((bitfield >> 6) & 0x1) == 1;
        //}

        //if ((angle <= -135) && (angle > -180))
        //{
        //    //sector 7
        //    return ((bitfield >> 7) & 0x1) == 1;
        //}

        //return true;
    }


    
    bool TestAngle(float angleToTest, float toTestAgainst, float ArcToTest, long bitfield, int shiftBit)
    {//Only use when within the scope of the circle.
        if((angleToTest >= toTestAgainst) && (angleToTest < toTestAgainst + ArcToTest))
        {
            return ((bitfield >> shiftBit) & 0x1) == 1;
        }
        return false;
    }
}

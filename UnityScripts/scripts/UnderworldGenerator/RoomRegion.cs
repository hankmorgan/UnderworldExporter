using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A region consisting of a single room.
/// </summary>
public class RoomRegion : Region
{
    public RoomRegion(int index, int RegionLayer, int x, int y, int width, int height, int NoOfSubRegions, Region Parent)
    {
        InitRegion(index, RegionLayer, x, y, width, height,Parent);
        Generate(NoOfSubRegions);
        BuildSubRegions(NoOfSubRegions);
    }

    protected override void Generate(int NoOfSubRegions)
    {       
        for (int x = 0; x <= Map.GetUpperBound(0); x++)
        {
            for (int y = 0; y <= Map.GetUpperBound(1); y++)
            {
                if ((x==0) || (y==0) || (x== Map.GetUpperBound(0)) || (y== Map.GetUpperBound(1)))
                {
                    Map[x, y].TileLayoutMap = SOLID;
                }
                else
                {
                    Map[x, y].TileLayoutMap = OPEN;
                }                
            }
        }

        BuildSubRegions(NoOfSubRegions);
    }

    /*
    public Room(int NewIndex)
    {
        index = NewIndex;
        x = Random.Range(2, 62);
        y = Random.Range(2, 62);
        dimX = Random.Range(3, 20);
        dimY = Random.Range(3, 20);
        if (x + dimX >= 63)
        {
            dimX = 63 - x;
        }
        if (y + dimY >= 63)
        {
            dimY = 63 - y;
        }

        SetBaseHeight();
    }

    /// <summary>
    /// Make the room look nice.
    /// </summary>
    public override void StyleArea()
    {
      /*  CaveStyler cs = new CaveStyler();
        int[,] result = cs.Style(dimX,dimY);
        
        for (int xPos=0; xPos <= result.GetUpperBound(0); xPos++)
        {
            for (int yPos = 0; yPos <= result.GetUpperBound(1); yPos++)
            {
                UnderworldGenerator.instance.mappings[x + xPos, y + yPos].TileLayoutMap = result[xPos, yPos];
            }
        }*/
    //}

    public override string RegionType()
    {
        return "Room";
    }
}

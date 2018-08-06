using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Taken from
//http://roguebasin.roguelikedevelopment.org/index.php?title=Cellular_Automata_Method_for_Generating_Random_Cave-Like_Levels

public class CaveRegion: Region
{

    public int PercentAreWalls { get; set; }
    private int NoOfIterations = 2;
    int[,] Flood;
    int[,] BorderFlood;
    int floodIndex = 1;
    int borderfloodIndex = 1;
    List<int> floodSizes = new List<int>();

    public CaveRegion(int index, int RegionLayer, int x, int y, int width, int height, int NoOfSubRegions, Region Parent)
    {
        InitRegion(index, RegionLayer, x, y, width, height, Parent);
        Generate(NoOfSubRegions);
        BuildSubRegions(NoOfSubRegions);
    }

    protected override void Generate(int NoOfSubRegions)
    {
        PercentAreWalls = 40;
        RandomFillMap();        
        for (int i = 0; i < NoOfIterations; i++)
        {
            MakeCaverns();
        }

        Flood = new int[MapWidth + 1, MapHeight + 1];
        FillCaves();//Fill in all but the largest cave
        if (layer > 1)
        {//This is not at the top layer so I need to remove the outer tiles to avoid a block surrounding the cave.
            //TODO: Only do this depending on what the parent layer is like.
            if (ParentRegion!=null)
            {
                if (ParentRegion.RegionType() == "Base")
                {//Do not clean up the border if in the middle of a solid region such as the base region
                    return;
                }
            }
            CleanUpBorder();
        }
    }

    public void MakeCaverns()
    {
        // By initilizing column in the outter loop, its only created ONCE
        for (int column = 0, row = 0; row <= MapHeight ; row++)
        {
            for (column = 0; column <= MapWidth ; column++)
            {
                Map[column, row].TileLayoutMap = PlaceWallLogic(column, row);
            }
        }
    }

    public int PlaceWallLogic(int x, int y)
    {
        int numWalls = GetAdjacentWalls(x, y, 1, 1);


        if (Map[x, y].TileLayoutMap == SOLID)
        {
            if (numWalls >= 4)
            {
                return SOLID;
            }
            if (numWalls < 2)
            {
                return OPEN;
            }

        }
        else
        {
            if (numWalls >= 5)
            {
                return SOLID;
            }
        }
        return OPEN;
    }

    public void RandomFillMap()
    {
        // New, empty map
       // Map = new GeneratorMap[MapWidth, MapHeight];
        BlankMap();
        int mapMiddle = 0; // Temp variable
        for (int column = 0, row = 0; row <= MapHeight; row++)
        {
            for (column = 0; column <= MapWidth; column++)
            {
                Map[column,row] = new GeneratorMap();
                Map[column, row].TileLayoutMap = OPEN;
                // If coordinants lie on the the edge of the map (creates a border)
                if (column == 0)
                {
                    Map[column, row].TileLayoutMap = SOLID;
                }
                else if (row == 0)
                {
                    Map[column, row].TileLayoutMap = SOLID;
                }
                else if (column == MapWidth - 1)
                {
                    Map[column, row].TileLayoutMap = SOLID;
                }
                else if (row == MapHeight - 1)
                {
                    Map[column, row].TileLayoutMap = SOLID;
                }
                // Else, fill with a wall a random percent of the time
                else
                {
                    mapMiddle = (MapHeight / 2);

                    if (row == mapMiddle)
                    {
                        Map[column, row].TileLayoutMap = SOLID;
                    }
                    else
                    {
                        Map[column, row].TileLayoutMap = RandomPercentWall(PercentAreWalls);
                    }
                }
            }
        }
    }

    int RandomPercentWall(int percent)
    {
        if (percent >= Random.Range(1, 101))
        {
            return SOLID;
        }
        return OPEN;
    }

    public override string RegionType()
    {
        return "Cave";
    }

    void FillCaves()
    {       
        floodSizes.Add(0);
        for (int x=0; x<=Map.GetUpperBound(0); x++)
        {
            for (int y = 0; y <= Map.GetUpperBound(1); y++)
            {
                if (Flood[x,y] == 0 )
                {
                    if (Map[x,y].TileLayoutMap != SOLID)
                    {//This is an open tile that has not been filled in.
                        floodSizes.Add(0);
                        FloodFill(x, y, floodIndex++);                        
                    }
                }
            }
        }
        int maxFlood = 0;
        //Find the biggest cavern
        for (int i=1; i<floodSizes.Count;i++)
        {
            if (floodSizes[i]> floodSizes[maxFlood])
            {
                maxFlood = i;
            }
        }
        //Fill in the other caverns
        for (int x = 0; x <= Map.GetUpperBound(0); x++)
        {
            for (int y = 0; y <= Map.GetUpperBound(1); y++)
            {
                if (Flood[x,y]!=maxFlood)
                {
                    Map[x, y].TileLayoutMap = SOLID;
                    Flood[x, y] = 0;//Clear from flood map
                }
            }
        }
    }

    void FloodFill(int x, int y, int indexToFill)
    {
        //Check n,s,e,w of each tile
        Flood[x, y] = indexToFill;
        floodSizes[indexToFill]= floodSizes[indexToFill]+1;
        if (x + 1 <= Map.GetUpperBound(0))
        {
            if ((Map[x + 1, y].TileLayoutMap != SOLID) && (Flood[x+1, y]==0))
            {
                FloodFill(x + 1, y, indexToFill);
            }
        }

        if (x - 1 >= 0 )
        {
            if ((Map[x - 1, y].TileLayoutMap != SOLID) && (Flood[x-1, y] == 0))
            {
                FloodFill(x - 1, y, indexToFill);
            }
        }

        if (y + 1 <= Map.GetUpperBound(0))
        {
            if ((Map[x, y + 1].TileLayoutMap != SOLID) && (Flood[x, y+1] == 0))
            {
                FloodFill(x, y + 1, indexToFill);
            }
        }
        if (y - 1 >= 0)
        {
            if ((Map[x, y-1].TileLayoutMap != SOLID) && (Flood[x, y-1] == 0))
            {
                FloodFill(x, y-1, indexToFill);
            }
        }
    }

    void CleanUpBorderX()
    {
        //Clear all solid tiles that do not border the main area of the cavern.
        for (int x = 0; x <= Map.GetUpperBound(0); x++)
        {
            for (int y = 0; y <= Map.GetUpperBound(1); y++)
            {
                //If this tile does not touch any open tile then remove
                bool touching = false;
                for (int a = -1; a <= 1; a++)
                {
                    for (int b = -1; b <= 1; b++)
                    {
                        if ((a != 0) && (b != 0))
                        {
                            if ( (x + a >= 0) && (x + a <= Map.GetUpperBound(0)) && (y + b >= 0) && (y + b <= Map.GetUpperBound(1)))
                            {
                                if (Flood[x + a, y + b] !=0)
                                {
                                    touching = true;
                                }
                            }
                        }
                    }
                }
                if (!touching)
                {
                    Map[x, y].TileLayoutMap = OPEN;
                }
            }
        }
    }

    void CleanUpBorder()
    {
        BorderFlood = new int[MapWidth + 1, MapHeight + 1];
        for (int x=0; x<=Map.GetUpperBound(0);x++)
        {
            for (int y = 0; y <= Map.GetUpperBound(1); y++)
            {
                if (x==0 || y==0 || x==Map.GetUpperBound(0) || y==Map.GetUpperBound(0))
                {//Only test from the edge
                    if (!isTouchingOpenArea(x,y))
                    {
                        floodFillBorder(x, y, borderfloodIndex++);
                    }
                }
            }
        }

        for (int x = 0; x <= Map.GetUpperBound(0); x++)
        {
            for (int y = 0; y <= Map.GetUpperBound(1); y++)
            {
            if (BorderFlood[x,y]!=0)
                {
                    Map[x, y].TileLayoutMap = OPEN;
                }
            }
        }
    }


    void floodFillBorder(int x, int y, int floodIndex)
    {
        if (BorderFlood[x, y] != 0) { return; }
        BorderFlood[x, y] = floodIndex;
        for (int a = -1; a <= 1; a++)
        {
            for (int b = -1; b <= 1; b++)
            {
                if ((a != 0) && (b != 0))
                {
                    if ((x + a >= 0) && (x + a <= Map.GetUpperBound(0)) && (y + b >= 0) && (y + b <= Map.GetUpperBound(1)))
                    {
                        if (!isTouchingOpenArea(x+a, y+b))
                        {
                            floodFillBorder(x+a, y+b, floodIndex);
                        }
                    }
                }
            }
        }
    }


    bool isTouchingOpenArea(int x, int y)
    {
        bool touching = false;
        if (Map[x,y].TileLayoutMap !=SOLID)
        {
            return true;
        }
        for (int a=-1; a<=1; a++)
        {
            for (int b = -1; b <= 1; b++)
            {
                if ((a!=0) && (b!=0))
                {
                    if ((x + a >= 0) && (y + b >= 0) && (x + a <= Map.GetUpperBound(0)) && (y + b <= Map.GetUpperBound(1)))
                    {
                        if (Flood[x+a,y+b]!=0)
                        {
                            return true;
                        }
                    }
                }
            }
        }
        return touching;
    }
}



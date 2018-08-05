using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Base region.
/// </summary>
/// Creates a region consisting of MapWidth X MapHeight solid tiles.
public class Region : GeneratorClasses {

    public int RegionIndex;
    public int layer;
    protected const int SOLID = 0;
    protected const int OPEN = 1;

    public GeneratorMap[,] Map;//Map of tiles within the region
   // public int[,] RegionMap; //Map of subregions
    public int MapWidth { get; set; }
    public int MapHeight { get; set; }
    public int originX { get; set; }
    public int originY { get; set; }

    public int BaseHeight;//Starting height for this area.

    struct RoomCandidate
    {
        public int x;
        public int y;
        public int dimX;
        public int dimY;
    }

    // public int[] ConnectedRooms; //Indices of rooms connected to this room (direct or indirect)
    // public int[] BuiltConnections; //What connections are made by virtue of a corridor intersecting this room.

    /// <summary>
    /// List of regions formed within the current region
    /// </summary>
    List<Region> SubRegions = new List<Region>();

    public Region()
    {
        //InitRegion(0, 0, 0, 0, 64, 64);
        //Generate(0);
    }

    public Region(int index, int RegionLayer, int x, int y, int width, int height, int NoOfSubRegions)
    {       
        InitRegion(index, RegionLayer, x, y, width, height);
        Generate(NoOfSubRegions);
        BuildSubRegions(NoOfSubRegions);
    }

    protected void InitRegion(int index, int RegionLayer, int x, int y, int width, int height)
    {
        Debug.Log("Region " + RegionType() + " "  + index + " at " + x + "," + y + " " + width + "x" + height);
        RegionIndex = index;
        layer = RegionLayer;
        originX = x;
        originY = y;
        MapHeight = height;
        MapWidth = width;
        SetBaseHeight();
        Map = new GeneratorMap[MapWidth + 1, MapHeight +1];
        for (int a = 0; a <=  Map.GetUpperBound(0); a++)
        {
            for (int b = 0; b <= Map.GetUpperBound(1); b++)
            {
                Map[a, b] = new GeneratorMap();
                Map[a, b].FloorTexture = index;
                Map[a, b].FloorHeight = BaseHeight;
                Map[a, b].TileLayoutMap = OPEN;
            }
        }
    }

    /// <summary>
    /// Generate the tiles in the map.
    /// </summary>
    protected virtual void Generate(int NoOfSubRegions)
    {
        for (int x = 0; x < MapWidth; x++)
        {
            for (int y = 0; y < MapHeight; y++)
            {
                Map[x, y].TileLayoutMap = SOLID;
            }
        }
    }

    protected void BuildSubRegions(int NoOfSubRegions)
    {
        if (NoOfSubRegions > 0)
        {
            switch (layer)
            {
                case 0://top level. Fill a large area.
                    FillSubRegionLarge(NoOfSubRegions);
                    break;
                case 1://a medium sized region. Eg a map quadrant.
                    FillSubRegionMedium(NoOfSubRegions);
                    break;
                case 2://A small region. Eg a room or a couple of directly connected rooms.
                    FillSubRegionSmall(NoOfSubRegions);
                    break;
            }
        }
    }


    /// <summary>
    /// Fills most of the map as a single large region.
    /// </summary>
    /// <param name="NoOfSubRegions"></param>
    public virtual void FillSubRegionLarge(int NoOfSubRegions)
    {
        int NoOfNewSubRegions = Random.Range(0,5);
        NoOfNewSubRegions = Random.Range(0,6);
        switch (Random.Range(0,3))
        {
            case 0://A solid fill
                SubRegions.Add(new Region(UnderworldGenerator.RegionIndex++, layer + 1, 1, 1, 62, 62, NoOfNewSubRegions)); break;
            case 1://A single room with sub regions.
                SubRegions.Add(new RoomRegion(UnderworldGenerator.RegionIndex++, layer + 1, 1, 1, 62, 62, NoOfNewSubRegions)); break;
            case 2:
            default://A cave
                SubRegions.Add(new CaveRegion(UnderworldGenerator.RegionIndex++, layer + 1, 1, 1, 62, 62, NoOfNewSubRegions)); break;
                
        }        
    }

    public virtual void FillSubRegionMedium(int NoOfSubRegions)
    {
        int NoOfAttempts = NoOfSubRegions * 8;//Try each room 8 times.   
        int minDimX = 10; int minDimY = 10;//A medium sized room.
        while ((NoOfSubRegions > 0) && (NoOfAttempts > 0))
        {
            NoOfAttempts--;
            RoomCandidate roomCand = NewRoom(MapWidth - 1, MapHeight - 1, 30, 30, minDimX, minDimY);
            if (!DoesRoomCollide(roomCand))
            {//A a room or cave subregion.
                PlaceRoom(roomCand, UnderworldGenerator.RegionIndex+1);
                switch (Random.Range (0,2))
                {
                    case 0:
                        SubRegions.Add(new RoomRegion(UnderworldGenerator.RegionIndex++, layer + 1, roomCand.x, roomCand.y, roomCand.dimX, roomCand.dimY, Random.Range(0, 5))); break;
                    case 1:
                    default:                        
                         SubRegions.Add(new CaveRegion(UnderworldGenerator.RegionIndex++, layer + 1, roomCand.x, roomCand.y, roomCand.dimX, roomCand.dimY, Random.Range(0, 5))); break;
                }
                NoOfSubRegions--;
            }
        }          
    }

    public virtual void FillSubRegionSmall(int NoOfSubRegions)
    {//At the moment just add rooms
        int NoOfAttempts = NoOfSubRegions * 8;//Try each room 8 times.   
        int minDimX = 3; int minDimY = 3;//A medium sized room.
        while ((NoOfSubRegions > 0) && (NoOfAttempts > 0))
        {
            NoOfAttempts--;
            RoomCandidate roomCand = NewRoom(MapWidth - 1, MapHeight - 1, 15, 15, minDimX, minDimY);
            if (!DoesRoomCollide(roomCand))
            {//A a room or cave subregion.
                PlaceRoom(roomCand, UnderworldGenerator.RegionIndex + 1);
                switch (Random.Range(0, 2))
                {
                    case 0:
                        SubRegions.Add(new RoomRegion(UnderworldGenerator.RegionIndex++, layer + 1, roomCand.x, roomCand.y, roomCand.dimX, roomCand.dimY, Random.Range(0, 5))); break;
                    case 1:
                    default:
                        SubRegions.Add(new CaveRegion(UnderworldGenerator.RegionIndex++, layer + 1, roomCand.x, roomCand.y, roomCand.dimX, roomCand.dimY, Random.Range(0, 5))); break;
                }
                NoOfSubRegions--;
            }
        }
    }



    RoomCandidate NewRoom(int MaxX, int MaxY, int MaxDimX,int MaxDimY, int MinDimX, int MinDimY)
    {
        RoomCandidate roomCand;
        if (MinDimX >= MaxDimX) { MinDimX = MaxDimX - 1; }
        if (MinDimY >= MaxDimY) { MinDimY = MaxDimY - 1; }

        roomCand.x = Random.Range(1, MaxX);
        roomCand.y = Random.Range(1, MaxY);
        roomCand.dimX = Random.Range(MinDimX, MaxDimX);
        roomCand.dimY = Random.Range(MinDimY, MaxDimY);
        if (roomCand.x + roomCand.dimX >= MaxX)
        {
            roomCand.dimX = MaxX - roomCand.x;
        }
        if (roomCand.y + roomCand.dimY >= MaxY)
        {
            roomCand.dimY = MaxY - roomCand.y;
        }
        return roomCand;
    }


  bool DoesRoomCollide(RoomCandidate candidate)
  {
      for (int x = candidate.x; x <= candidate.x + candidate.dimX && x <= 63; x++)
      {
          for (int y = candidate.y; y <= candidate.y + candidate.dimY && y <= 63; y++)
          {
              if (Map[x, y].RoomMap != 0)
              {//Space already contains a room.
                  return true;
              }
          }
      }
      return false;
  }

    void PlaceRoom(RoomCandidate candidate, int roomIndex)
    {
        for (int x = candidate.x; x <= candidate.x + candidate.dimX && x <= 63; x++)
        {
            for (int y = candidate.y; y <= candidate.y + candidate.dimY && y <= 63; y++)
            {
                Map[x, y].RoomMap = roomIndex;
            }
        }
    }

    public virtual void StyleArea()
    {

    }

    protected virtual void SetBaseHeight()
    {
        BaseHeight = Random.Range(0, 13) * 2;//Only multiple of two allowed. Range from 0 to 24
    }

    /// <summary>
    /// Gets the map of the entire region and all it's subregions.
    /// </summary>
    /// <returns></returns>
    public GeneratorMap [,] GetEntireMap()
    {
        GeneratorMap[,] OutputMap = new GeneratorMap[MapWidth+1, MapHeight+1];

        //Populate the base map.
        for (int i=0; i<=Map.GetUpperBound(0); i++)
        {
            for (int j = 0; j <= Map.GetUpperBound(1); j++)
            {
                OutputMap[i, j] = Map[i, j];
            }
        }

        //Overlay the subregions
        for (int i = 0; i < SubRegions.Count; i++)
        {
            GeneratorMap[,] overlay = SubRegions[i].GetEntireMap();
            int subX = 0;
            for (int a = SubRegions[i].originX; a<= SubRegions[i].originX+ SubRegions[i].MapWidth; a++)
            {                
                int subY = 0;
                for (int b = SubRegions[i].originY; b <= SubRegions[i].originY + SubRegions[i].MapHeight; b++)
                {
                    OutputMap[a, b] = overlay[subX, subY];
                    subY++;
                }
                subX++;
            }
        }

        return OutputMap;
    }


    string MapToString()
    {
        string returnString = "";
        for (int column = 0, row = 0; row < MapHeight; row++)
        {
            for (column = 0; column < MapWidth; column++)
            {
                returnString += Map[column, row].TileLayoutMap + ",";
            }
            returnString += "\n";
        }
        return returnString;
    }

    public void PrintMap()
    {
        System.IO.StreamWriter writer = new System.IO.StreamWriter(Application.dataPath + "//..//" + index + "_rnd.txt");
        writer.Write(MapToString());
        writer.Close();
    }

    public virtual string RegionType()
    {
        return "Base";
    }

    public int GetAdjacentWalls(int x, int y, int scopeX, int scopeY)
    {
        int startX = x - scopeX;
        int startY = y - scopeY;
        int endX = x + scopeX;
        int endY = y + scopeY;

        int iX = startX;
        int iY = startY;

        int wallCounter = 0;

        for (iY = startY; iY <= endY; iY++)
        {
            for (iX = startX; iX <= endX; iX++)
            {
                if (!(iX == x && iY == y))
                {
                    if (IsWall(iX, iY))
                    {
                        wallCounter += 1;
                    }
                }
            }
        }
        return wallCounter;
    }

    bool IsWall(int x, int y)
    {
        // Consider out-of-bound a wall
        if (IsOutOfBounds(x, y))
        {
            return true;
        }

        if (Map[x, y].TileLayoutMap == SOLID)
        {
            return true;
        }

        if (Map[x, y].TileLayoutMap == OPEN)
        {
            return false;
        }
        return false;
    }

    bool IsOutOfBounds(int x, int y)
    {
        if (x < 0 || y < 0)
        {
            return true;
        }
        else if (x > MapWidth - 1 || y > MapHeight - 1)
        {
            return true;
        }
        return false;
    }


    public void BlankMap()
    {
        for (int column = 0, row = 0; row <= MapHeight; row++)
        {
            for (column = 0; column <= MapWidth; column++)
            {
                Map[column, row].TileLayoutMap = OPEN;
            }
        }
    }



}

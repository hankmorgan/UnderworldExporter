using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UnderworldGenerator : UWEBase {

    public static int RegionIndex=0;
    public GeneratorMap[,] mappings;

    public int startX = 0; public int startY = 0;
    public Text output;//for debugging
    public int Seed;

    public static UnderworldGenerator instance;
    private int ConnectorCount = 1;

   // Room[] rooms;
   // List<Connector> Connectors = new List<Connector>();
    public int NoOfRooms = 4;
    public int sizeForCaveX = 64;
    public int sizeForCaveY = 64;
    public int IterationsForGenerator;
    void Start()
    {
        instance = this;
        
    }

    /// <summary>
    /// Main loop for create the random level.
    /// </summary>
    /// <param name="levelseed"></param>
    public void GenerateLevel(int levelseed)
    {
        Seed = levelseed;
        ConnectorCount = 1;
        mappings = new GeneratorMap[64, 64];
        Random.InitState(levelseed);

        Region newMap = new Region(RegionIndex++, 0, 0, 0, 64, 64, Random.Range(3,26),null); //Top layer starts off with a single large region and a number of sub regions
        mappings = newMap.GetEntireMap();
    }

   /* private void GenerateCaveMap()
    {
        CaveRegion mp = new CaveRegion(64, 64, IterationsForGenerator);
        for (int x=0; x<=63;x++)
        {
            for (int y = 0; y <= 63; y++)
            {
                mappings[x, y].TileLayoutMap = mp.Map[x, y];
            }
        }
        PlaceCorners();
    }*/

    /// <summary>
    /// Create a map consisting of rooms connected to each other.
    /// </summary>
  /*  private void GenerateConnectedRoomsMap()
    {
        Connectors = new List<Connector>();
        
        NoOfRooms = Random.Range(1, 26);

        int validRooms = CreateRooms();
        ConnectAllRooms(validRooms); //make sure all rooms on the map are connected in some way

        //Init the player start tile
        startX = rooms[1].x;
        startY = rooms[1].y;

        for (int i = 1; i <= rooms.GetUpperBound(0); i++)
        {
            rooms[i].StyleArea();//Fill room contents
        }

        PlaceConnectors();//Place corridors on the map. Not all calculated connectors will be placed
        
        for (int i = 0; i < Connectors.Count; i++)
        {
            Connectors[i].StyleArea();//Fill room contents
        }

        for (int x = 2; x < 62; x++)
        {
            for (int y = 2; y < 62; y++)
            {
                //Set up diagonal tiles
                if (mappings[x, y].isDiag)
                {
                    PlaceDiagonal(x, y);
                }
            }
        }

        for (int x = 2; x < 62; x++)
        {
            for (int y = 2; y < 62; y++)
            {
                //Set up sloped tiles
                if (mappings[x, y].isSlope)
                {
                    PlaceSlope(x, y);
                }
            }
        }

        StyleJunctions();//Make some junctions look nice.
    }*/

    /// <summary>
    /// Create a random number of rooms and attempt to place them on the map.
    /// </summary>
    /// <returns></returns>
    //private int CreateRooms()
    //{
    //    //Randomly place rooms
    //    int RoomsLeft = NoOfRooms;
    //    int NoOfAttempts = NoOfRooms * 8;//Try each room 8 times.
    //    int RoomIndex = 1;
    //    int validRooms = 0;
    //    rooms = new Room[NoOfRooms + 1];
    //    while ((RoomsLeft > 0) && (NoOfAttempts > 0))
    //    {
    //        //Generate a new random room
    //        rooms[RoomIndex] = new Room(RoomIndex);

    //        //check collision on room.
    //        if (!DoesRoomCollide(rooms[RoomIndex]))
    //        {
    //            // Debug.Log("Placing Room " + RoomIndex + " at " + newroom.x + "," + newroom.y + " (" +newroom.dimX + "," + newroom.dimY + ")");
    //            //rooms[RoomIndex] = newroom;
    //            rooms[RoomIndex].index = RoomIndex;
    //            PlaceRoom(rooms[RoomIndex]);
    //            RoomIndex++;
    //            RoomsLeft--;
    //            validRooms++;
    //        }
    //        else
    //        {
    //            NoOfAttempts++;
    //        }
    //    }

    //    //Initialise connected rooms for this data set.
    //    for (int i = 1; i <= validRooms; i++)
    //    {
    //        rooms[i].ConnectedRooms = new int[validRooms + 1];
    //        rooms[i].BuiltConnections = new int[validRooms + 1];
    //        for (int j = 0; j <= rooms[i].ConnectedRooms.GetUpperBound(0); j++)
    //        {
    //            rooms[i].ConnectedRooms[j] = 0;
    //            rooms[i].BuiltConnections[j] = 0;
    //        }
    //        rooms[i].ConnectedRooms[i] = i;//always connect to itself
    //    }
    //    return validRooms;
    //}




  /*  bool DoesRoomCollide(Room candidate)
    {
        for (int x = candidate.x; x <= candidate.x + candidate.dimX && x <= 63; x++)
        {
            for (int y = candidate.y; y <= candidate.y + candidate.dimY && y <= 63; y++)
            {
                if (mappings[x, y].RoomMap != 0)
                {//Space already contains a room.
                    return true;
                }
            }
        }
        return false;
    }*/

 /*   void PlaceRoom(Room candidate)
    {
        for (int x = candidate.x; x < candidate.x + candidate.dimX && x <= 63; x++)
        {
            for (int y = candidate.y; y < candidate.y + candidate.dimY && y <= 63; y++)
            {
                mappings[x, y].RoomMap = candidate.index;
                mappings[x, y].TileLayoutMap = TileMap.TILE_OPEN;
                mappings[x, y].FloorHeight = candidate.BaseHeight;
            }
        }
    }*/

    //void PrintRooms()
    //{
    //    output.text = "";
    //    for (int y = 63; y >= 0; y--)
    //    {
    //        for (int x = 0; x <= 63; x++)
    //        {
    //            if (mappings[x, y].RoomMap >= 0)
    //            {
    //                output.text = output.text + mappings[x, y].RoomMap + ",";
    //            }
    //            else
    //            {
    //                output.text = output.text + mappings[x, y].RoomMap + ",";
    //            }
    //        }
    //        output.text = output.text + "\n";
    //    }
    //}


    /// <summary>
    /// Connect all rooms such that there is at least one room that connects to all the others.
    /// </summary>
    /// <param name="NoOfRooms"></param>
    //void ConnectAllRooms(int NoOfRooms)
    //{
    //    //check all rooms until we find a room that is connected to all others(either directly or indirectly)
    //    int NoOfAttempts = 100;//Try 100 times.

    //    //while there is no room that does not connect to all others.
    //    while ((!findRoomWithAllConnections()) && (NoOfAttempts >= 0))
    //    {
    //        //Pick a random room to start from.
    //        int startRoom = Random.Range(1, NoOfRooms + 1);

    //        //pick a random room to connect to
    //        int endRoom = Random.Range(1, NoOfRooms + 1);

    //        if (startRoom != endRoom)
    //        {
    //            if (rooms[startRoom].ConnectedRooms[endRoom] != endRoom)
    //            {//add a connection between these rooms.
    //                ConnectRoom(startRoom, endRoom, NoOfRooms, true);
    //            }
    //        }
    //        NoOfAttempts--;
    //    }
    //}

    /// <summary>
    /// Connects two rooms together.
    /// </summary>
    /// <param name="startRoom"></param>
    /// <param name="endRoom"></param>
    /// <param name="NoOfRooms"></param>
    /// <param name="Direct"></param>
    //void ConnectRoom(int startRoom, int endRoom, int NoOfRooms, bool Direct)
    //{
    //    rooms[startRoom].ConnectedRooms[endRoom] = endRoom;//Create a direct connection between these rooms.
    //    rooms[endRoom].ConnectedRooms[startRoom] = startRoom;

    //    if (Direct)
    //    {//Creates a direct link from startroom to endroom
    //     // Debug.Log("Connecting " + startRoom + " to " + endRoom);
    //        Connector con = new Connector(ConnectorCount++, startRoom, endRoom, NoOfRooms, rooms, Connectors);
    //        Connectors.Add(con);
    //    }

    //    //check all other rooms. If the room connects to either start or end of the connection then it will connect to the other as well.
    //    for (int tr = 1; tr <= rooms.GetUpperBound(0); tr++)
    //    {
    //        for (int r = 1; r <= rooms.GetUpperBound(0); r++)
    //        {
    //            for (int c = 1; c <= rooms[r].ConnectedRooms.GetUpperBound(0); c++)
    //            {
    //                if
    //                        (
    //                            (rooms[r].ConnectedRooms[c] == startRoom)
    //                            ||
    //                            (rooms[r].ConnectedRooms[c] == endRoom)
    //                        )
    //                {
    //                    //Debug.Log("adding secondary link for room " + r + " to " + startRoom + " & " + endRoom);
    //                    rooms[r].ConnectedRooms[startRoom] = startRoom;
    //                    rooms[r].ConnectedRooms[endRoom] = endRoom;
    //                }
    //            }
    //        }
    //    }
    //}


    /// <summary>
    /// Recursively checks all rooms to find one that is connected to all others
    /// </summary>
    /// <returns></returns>
    //bool findRoomWithAllConnections()
    //{
    //    for (int r = 1; r <= rooms.GetUpperBound(0); r++)
    //    {
    //        for (int c = 1; c <= rooms[r].ConnectedRooms.GetUpperBound(0); c++)
    //        {
    //            if (rooms[r].ConnectedRooms[c] != c)
    //            {//This room is not connected to every other room. 
    //                break;
    //            }
    //            if (c == rooms[r].ConnectedRooms.GetUpperBound(0))
    //            {//I have looped through all the rooms and this room is connected to all others. 
    //             //Therefore all rooms are connected in some way.
    //             //Debug.Log("Room " + r + " connects to all rooms");
    //                return true;
    //            }
    //        }
    //    }
    //    return false;
    //}


    /// <summary>
    /// Debug function
    /// </summary>
    //void PrintRoomConnections()
    //{
    //    for (int r = 1; r <= rooms.GetUpperBound(0); r++)
    //    {
    //        string connected = "";
    //        for (int i = 1; i <= rooms[r].ConnectedRooms.GetUpperBound(0); i++)
    //        {
    //            connected = connected + rooms[r].ConnectedRooms[i] + ",";
    //        }
    //    }
    //}


    /// <summary>
    /// Try and position all the connectors on the map until all rooms are connected.
    /// </summary>
    //void PlaceConnectors()
    //{
    //    int ccount = Connectors.Count;
    //    // foreach (Connector con in Connectors)
    //    for (int cc = 0; cc < ccount; cc++)
    //    {
    //        PlaceConnector(cc);
    //    }

    //    //Now smooth all the connects
    //    ccount = Connectors.Count;
    //    // foreach (Connector con in Connectors)
    //    for (int cc = 0; cc < ccount; cc++)
    //    {
    //        Connectors[cc].FixConnectorHeight();
    //    }
    //}

    //private void PlaceConnector(int cc)
    //{
    //    //Run a path between start and end.
    //    int curX = Connectors[cc].startX; int curY = Connectors[cc].startY;
    //    Connectors[cc].AddPathStep(curX, curY);//Flag the first step/beginning point

    //    if (rooms[Connectors[cc].StartRoom].BuiltConnections[Connectors[cc].EndRoom] == Connectors[cc].EndRoom)
    //    {//A connection already exists.

    //        curX = Connectors[cc].endX;
    //        curY = Connectors[cc].endY;
    //    }
    //    while (curX != Connectors[cc].endX || curY != Connectors[cc].endY)
    //    {

    //        int diffX = Connectors[cc].endX - curX;
    //        int diffY = Connectors[cc].endY - curY;


    //        if ((diffX != 0) && (diffY != 0))
    //        {//I can move diagonally
    //            switch (Random.Range(1, 4))
    //            {
    //                case 1: //Try and move diagonally
    //                    MoveAlongDiag(cc, ref curX, ref curY, diffX, diffY);
    //                    break;
    //                default: //move randomly on xy
    //                    MoveAlongXYOnly(cc, ref curX, ref curY, diffX, diffY);
    //                    break;
    //            }
    //        }
    //        else
    //        {
    //            MoveAlongXYOnly(cc, ref curX, ref curY, diffX, diffY);
    //        }


    //    }
    //    rooms[Connectors[cc].StartRoom].BuiltConnections[Connectors[cc].EndRoom] = Connectors[cc].EndRoom;
    //    rooms[Connectors[cc].EndRoom].BuiltConnections[Connectors[cc].StartRoom] = Connectors[cc].StartRoom;
    //    if (Connectors[cc].actualEndX == -1)
    //    {
    //        Connectors[cc].actualEndX = Connectors[cc].endX;
    //    }
    //    if (Connectors[cc].actualEndY == -1)
    //    {
    //        Connectors[cc].actualEndY = Connectors[cc].endY;
    //    }
    //}


    //private void MoveAlongDiag(int cc, ref int curX, ref int curY, int diffX, int diffY)
    //{
    //    int dirX; int dirY;
    //    int moveX = 0; int moveY = 0;//How far is to be moved in the x/y axis.
    //    int MoveAbs = 0;    //The movement distance choosen.   
    //    int Diag = Mathf.Min(Mathf.Abs(diffX), Mathf.Abs(diffY));//This is the max distance the diag can go in an axis
    //    MoveAbs = Random.Range(1, Diag);

    //    //Pick the step direction for x/y
    //    if (diffX >= 0) { dirX = +1; } else { dirX = -1; }
    //    if (diffY >= 0) { dirY = +1; } else { dirY = -1; }
    //    for (int x = 0; x < MoveAbs * 2; x++)
    //    {
    //        if ((curX != Connectors[cc].endX) && (curX != Connectors[cc].endY))
    //        {
    //            if (x % 2 == 0)
    //            {
    //                moveX = 1;
    //                moveY = 0;
    //            }
    //            else
    //            {
    //                moveX = 0;
    //                moveY = 1;
    //            }
    //            MoveAlongXYOnly(cc, ref curX, ref curY, dirX * moveX, dirY * moveY);
    //            if ((curX >= 0) && (curY >= 0) && (curX < 64) && (curY < 64))
    //            {
    //                UnderworldGenerator.instance.mappings[curX, curY].isDiag = true;
    //            }
    //        }
    //    }
    //}

    /// <summary>
    /// 
    /// </summary>
    /// <param name="cc"></param>
    /// Corridor being traversed
    /// <param name="curX"></param>
    /// <param name="curY"></param>
    /// <param name="dirX"></param>
    /// <param name="dirY"></param>
    /// <param name="diffX"></param>
    /// <param name="diffY"></param>
    //private void MoveAlongXYOnly(int cc, ref int curX, ref int curY, int diffX, int diffY)
    //{
    //    int dirX; int dirY;
    //    int moveX = 0; int moveY = 0;//How far is to be moved in the x/y axis.
    //    int MoveAbs = 0;    //The movement distance choosen.
    //    //Pick how far will be moved in each axis
    //    if (diffX != 0)
    //    {
    //        moveX = Random.Range(1, Mathf.Abs(diffX) + 1);
    //    }
    //    if (diffY != 0)
    //    {
    //        moveY = Random.Range(1, Mathf.Abs(diffY) + 1);
    //    }
    //    //Pick the step direction for x/y
    //    if (diffX >= 0) { dirX = 1; } else { dirX = -1; }
    //    if (diffY >= 0) { dirY = 1; } else { dirY = -1; }

    //    if (moveX != 0 && moveY != 0)
    //    {//move in a random non-zero axis
    //        if (Random.Range(0, 2) == 1)
    //        {//move x
    //            MoveAbs = moveX;
    //            dirY = 0;
    //        }
    //        else
    //        {//move 
    //            MoveAbs = moveY;
    //            dirX = 0;
    //        }
    //    }
    //    else if (moveX != 0)
    //    {//move on x axis
    //        MoveAbs = moveX;
    //        dirY = 0;
    //    }
    //    else
    //    {//move on y axis
    //     //MoveOnY = true;
    //        MoveAbs = moveY;
    //        dirX = 0;
    //    }

    //    MoveAlongPath(cc, ref curX, ref curY, dirX, dirY, MoveAbs);
    //}

    //private void MoveAlongPath(int cc, ref int curX, ref int curY, int dirX, int dirY, int MoveAbs)
    //{
    //    //Perform the move for however many steps are randomly picked
    //    for (int x = 1; x <= Mathf.Abs(MoveAbs); x++)
    //    {
    //        curX += dirX;
    //        curY += dirY;
    //        if ((curX >= 64) || (curY >= 64) || (curX < 0) || (curY < 0))
    //        {
    //            Debug.Log("Connector " + cc + " has attempted to exit the world");
    //            //End my previous connector
    //            Connectors[cc].SetEnd(curX, curY);
    //            curX = Connectors[cc].endX;
    //            curY = Connectors[cc].endY;
    //            return;
    //        }
    //        Connectors[cc].AddPathStep(curX, curY);
    //        if (mappings[curX, curY].RoomMap == 0)
    //        {
    //            mappings[curX, curY].RoomMap = -Connectors[cc].index;//Connectors are negative numbers
    //            mappings[curX, curY].TileLayoutMap = TileMap.TILE_OPEN;
    //        }
    //        else if (mappings[curX, curY].RoomMap > 0)
    //        {//I've hit another room. Set a built connection between start and this room
    //            int roomReached = mappings[curX, curY].RoomMap;
    //            rooms[roomReached].BuiltConnections[Connectors[cc].StartRoom] = Connectors[cc].StartRoom;
    //            Connectors[cc].Start().BuiltConnections[roomReached] = roomReached;
    //            if ((roomReached != Connectors[cc].StartRoom) && (roomReached != Connectors[cc].EndRoom))
    //            {//Check if the room I've reached has connected to my target room. If so stop connecting
    //                int[] testedRooms = new int[NoOfRooms + 1];
    //                if (AreRoomsConnected(rooms[roomReached], Connectors[cc].End(), ref testedRooms))
    //                {//there is a built connection to the target. Stop traversing.                                
    //                    Connectors[cc].SetEnd(curX, curY);
    //                    Connectors[cc].EndRoom = roomReached;//Change the room I have reached for smoothing out the slopes
    //                    curX = Connectors[cc].endX;
    //                    curY = Connectors[cc].endY;
    //                    break;
    //                }
    //                else
    //                {
    //                    //Room is not the one I want. 
    //                    //End my path but create a new connector from this room to the want I want to go to.
    //                    Connector NewCon = new Connector(ConnectorCount++, roomReached, Connectors[cc].EndRoom, NoOfRooms, rooms, Connectors);
    //                    Connectors.Add(NewCon);
    //                    PlaceConnector(NewCon.index - 1);

    //                    //End my previous connector
    //                    Connectors[cc].SetEnd(curX, curY);
    //                    Connectors[cc].EndRoom = roomReached;//Change the room I have reached for smoothing out the slopes
    //                    curX = Connectors[cc].endX;
    //                    curY = Connectors[cc].endY;
    //                }
    //            }
    //        }
    //        else
    //        {//I've hit a corridor. Check if that corridor connects to where I want to be.
    //            mappings[curX, curY].JunctionMap = mappings[curX, curY].JunctionMap + 1;
    //            int foundcorridor = Mathf.Abs(mappings[curX, curY].RoomMap) - 1;
    //            Room FoundStartRoom = rooms[Connectors[foundcorridor].StartRoom];
    //            Room FoundEndRoom = rooms[Connectors[foundcorridor].EndRoom];
    //            //Add connections to start and end of found corridor
    //            Connectors[cc].Start().BuiltConnections[FoundStartRoom.index] = FoundStartRoom.index;
    //            Connectors[cc].Start().BuiltConnections[FoundEndRoom.index] = FoundEndRoom.index;
    //            FoundStartRoom.BuiltConnections[Connectors[cc].StartRoom] = Connectors[cc].StartRoom;
    //            FoundEndRoom.BuiltConnections[Connectors[cc].StartRoom] = Connectors[cc].StartRoom;

    //            int[] testedRooms = new int[NoOfRooms + 1];
    //            if (AreRoomsConnected(rooms[Connectors[foundcorridor].StartRoom], Connectors[cc].End(), ref testedRooms))
    //            {//I've reached the target room because it connects to my destination via this corridor
    //                Connectors[cc].SetEnd(curX, curY);
    //                curX = Connectors[cc].endX;
    //                curY = Connectors[cc].endY;
    //                break;
    //            }
    //            else
    //            {//This connector is not the one I want to find. I stop my connector here and start a new one from this spot. 
    //                Connector NewCon = new Connector(ConnectorCount++, Connectors[cc].StartRoom, Connectors[cc].EndRoom, NoOfRooms, rooms, Connectors);
    //                NewCon.ParentConnector = cc;//Flags that this connector is starting from another connector
    //                NewCon.startX = curX; NewCon.startY = curY;//Resume the old path.
    //                NewCon.endX = Connectors[cc].endX; NewCon.endY = Connectors[cc].endY;
    //                Connectors.Add(NewCon);
    //                PlaceConnector(NewCon.index - 1);

    //                //End my previous connector
    //                Connectors[cc].SetEnd(curX, curY);
    //                curX = Connectors[cc].endX;
    //                curY = Connectors[cc].endY;

    //            }
    //        }
    //        //if ((curX== Connectors[cc].endX) && (curY == Connectors[cc].endY) && (Connectors[cc].actualEndX!=-1) && (Connectors[cc].actualEndY != -1))
    //        if (Connectors[cc].AtFinalDest(curX, curY))
    //        {//actually reached my destination without hitting any other room.
    //            Connectors[cc].SetEnd();
    //        }
    //        //Stop when reached the target x&y                       
    //        if ((curX == Connectors[cc].endX) && (dirX != 0)) { break; }
    //        if ((curY == Connectors[cc].endY) && (dirY != 0)) { break; }
    //    }
    //}


    /// <summary>
    /// Creates a tilemap from scratch
    /// </summary>
    /// <param name="levelNo"></param>
    /// <returns></returns>
    public TileMap CreateTileMap(short levelNo)
    {
        TileMap tm = new TileMap(levelNo);
        tm.texture_map = new short[TileMap.UW1_TEXTUREMAPSIZE];
        for (short t = 0; t <= tm.texture_map.GetUpperBound(0); t++)
        {//Some quick and dirty values
            if (t <= 57)
            {
                tm.texture_map[t] = t;
            }
            else
            {
                tm.texture_map[t] = (short)(t - 57);
            }

        }
        tm.Tiles = new TileInfo[64, 64];
        tm.CEILING_HEIGHT = ((128 >> 2) * 8 >> 3);
        //Apply calculated tiles to the map.
        RoomsToTileMap(tm, tm.Tiles);
        return tm;
    }

    /// <summary>
    /// Overwrite the tiles in a tilemap with those already calcuated by the generator
    /// </summary>
    /// <param name="tm"></param>
    /// <param name="Tiles"></param>
    public void RoomsToTileMap(TileMap tm, TileInfo[,] Tiles)
    {
       // PrintRooms();
        for (int x = 0; x <= 63; x++)
        {
            for (int y = 0; y <= 63; y++)
            {
                Tiles[x, y] = new TileInfo();
                Tiles[x, y].tileX = (short)x;
                Tiles[x, y].tileY = (short)y;
                Tiles[x, y].ceilingHeight = 0;
                Tiles[x, y].indexObjectList = 0;
                Tiles[x, y].floorHeight = 30;
                //Tiles[x, y].tileType = TileMap.TILE_SOLID;
                Tiles[x, y].tileType = (short)mappings[x, y].TileLayoutMap;
                Tiles[x, y].shockSlopeFlag = TileMap.SLOPE_FLOOR_ONLY;
                Tiles[x, y].doorBit = 0;
                Tiles[x, y].DimX = 1;
                Tiles[x, y].DimY = 1;
                Tiles[x, y].Render = true;
                Tiles[x, y].Grouped = false;

                for (int v = 0; v < 6; v++)
                {
                    Tiles[x, y].VisibleFaces[v] = true;
                    Tiles[x, y].VisibleFaces[v] = true;
                }
                Tiles[x, y].floorTexture = 1;// (short)Random.Range(48, 57);
                Tiles[x, y].wallTexture = 1;// (short)Random.Range(0, 48);
                Tiles[x, y].North = Tiles[x, y].wallTexture;
                Tiles[x, y].South = Tiles[x, y].wallTexture;
                Tiles[x, y].East = Tiles[x, y].wallTexture;
                Tiles[x, y].West = Tiles[x, y].wallTexture;
                Tiles[x, y].Top = Tiles[x, y].floorTexture;
                Tiles[x, y].Bottom = Tiles[x, y].floorTexture;
                Tiles[x, y].Diagonal = Tiles[x, y].wallTexture;

                if (mappings[x, y].TileLayoutMap != TileMap.TILE_SOLID)
                {
                    switch (Tiles[x, y].tileType)
                    {
                        case TileMap.TILE_SLOPE_E:
                        case TileMap.TILE_SLOPE_W:
                        case TileMap.TILE_SLOPE_N:
                        case TileMap.TILE_SLOPE_S:
                            Tiles[x, y].shockSteep = 2;
                            break;
                    }

                    //Tiles[x, y].tileType = (short)mappings[x, y].TileLayoutMap;
                    // if (mappings[x, y].RoomMap>0) //this is a room
                    //{
                    Tiles[x, y].floorHeight = (short)mappings[x, y].FloorHeight; //16;
                                                                                 // }
                                                                                 //  else
                                                                                 // {
                                                                                 // Tiles[x, y].floorHeight = (short)mappings[x, y].FloorHeight; //(short)Connectors[ Mathf.Abs(mappings[x, y].RoomMap)-1].BaseHeight; //16;
                                                                                 //  }
                    Tiles[x, y].VisibleFaces[TileMap.vBOTTOM] = false;
                    Tiles[x, y].floorTexture = (short)Mathf.Min(Mathf.Abs(mappings[x, y].RoomMap), 10);
                    ////Floor textures are 49 to 56             
                }
                // return;
            }
        }
        tm.SetTileMapWallFacesUW();//Update so walls display correctly
    }


    /// <summary>
    /// Searches the full list of rooms to see if the src and dst rooms are connected either directly or indirectly.
    /// Searches built connections only.
    /// </summary>
    /// <param name="src"></param>
    /// <param name="dst"></param>
    /// <param name="testedRooms"></param>
    /// <returns></returns>
  /*  bool AreRoomsConnected(Room src, Room dst, ref int[] testedRooms)
    {
        bool result = false;
        testedRooms[src.index] = src.index;

        if (src.BuiltConnections[dst.index] == dst.index)
        {//rooms are connected
            return true;
        }

        //Check each conected room to the current room to see if they are connected to the destination
        for (int c = 1; c <= src.ConnectedRooms.GetUpperBound(0); c++)
        {

            if (
                (c != src.index) //Not the room we are already in
                &&
                (src.ConnectedRooms[c] == c)    //Is a connected room
                &&
                (testedRooms[c] != c)  //not already tested
                )
            {
                if (AreRoomsConnected(rooms[src.ConnectedRooms[c]], dst, ref testedRooms))
                {
                    result = true;
                    break;
                }
            }
        }
        return result;
    }*/


    /// <summary>
    /// Future use.
    /// </summary>
    void StyleJunctions()
    {
        //Turn found junctions of corridors into something nicer.
    }

    void PlaceDiagonal(int x, int y)
    {
        //A diagonal is place based on the tiles surrounding it.
        //000
        //1D0
        //111 
        //where x= solid, d is diagonal and 0 is a diag open to the sw. Diag tiles are treats as being solids.
        if (mappings[x, y].RoomMap > 0) { return; }


        for (int i = 2; i <= 5; i++)
        {
            switch (i)
            {//TODO:support sloped neighbour tiles.
                case TileMap.TILE_DIAG_NE:
                    {//If tiles to the s and w is solid then this the tile to the south and west can be a diag.
                        if (mappings[x, y - 1].TileLayoutMap == TileMap.TILE_SOLID) { TurnTileDiag(x, y - 1, i, -1, -1, mappings[x, y].FloorHeight); }
                        if (mappings[x - 1, y].TileLayoutMap == TileMap.TILE_SOLID) { TurnTileDiag(x - 1, y, i, -1, -1, mappings[x, y].FloorHeight); }
                        break;
                    }
                case TileMap.TILE_DIAG_NW:
                    {
                        if (mappings[x, y - 1].TileLayoutMap == TileMap.TILE_SOLID) { TurnTileDiag(x, y - 1, i, +1, -1, mappings[x, y].FloorHeight); }
                        if (mappings[x + 1, y].TileLayoutMap == TileMap.TILE_SOLID) { TurnTileDiag(x + 1, y, i, +1, -1, mappings[x, y].FloorHeight); }
                        break;
                    }
                case TileMap.TILE_DIAG_SE:
                    {
                        if (mappings[x, y + 1].TileLayoutMap == TileMap.TILE_SOLID) { TurnTileDiag(x, y + 1, i, -1, +1, mappings[x, y].FloorHeight); }
                        if (mappings[x - 1, y].TileLayoutMap == TileMap.TILE_SOLID) { TurnTileDiag(x - 1, y, i, -1, +1, mappings[x, y].FloorHeight); }
                        break;
                    }
                case TileMap.TILE_DIAG_SW:
                    {
                        if (mappings[x, y + 1].TileLayoutMap == TileMap.TILE_SOLID) { TurnTileDiag(x, y + 1, i, +1, +1, mappings[x, y].FloorHeight); }
                        if (mappings[x + 1, y].TileLayoutMap == TileMap.TILE_SOLID) { TurnTileDiag(x + 1, y, i, +1, +1, mappings[x, y].FloorHeight); }
                        break;
                    }
            }
        }
    }


    void TurnTileDiag(int x, int y, int newTileType, int dirX, int dirY, int Height)
    {
        if (mappings[x, y].TileLayoutMap == TileMap.TILE_SOLID)
        {
            if (
                (mappings[x + 0, y + dirY].TileLayoutMap == TileMap.TILE_SOLID)
                &&
                (mappings[x + dirX, y + 0].TileLayoutMap == TileMap.TILE_SOLID)
                )
            {//If what is behind this tile is a solid wall then change the tile.
                mappings[x, y].TileLayoutMap = newTileType;
                mappings[x, y].FloorHeight = Height;
            }
        }
        else
        {//This tile has already been changed to something else. Play it safe and make it an open tile
            mappings[x, y].TileLayoutMap = TileMap.TILE_OPEN;
        }
    }


    void PlaceSlope(int x, int y)
    {
        bool[] OpenTiles =new bool[4];
        OpenTiles[0] = isTileWideOpen(x + 1, y);//east
        OpenTiles[1] = isTileWideOpen(x -1, y);//west
        OpenTiles[2] = isTileWideOpen(x , y +1);//north
        OpenTiles[3] = isTileWideOpen(x, y-1);//south
        int[] heights = new int[4];
        int thisHeight = getHeight(x, y);
        heights[0] = thisHeight - getHeight(x + 1, y);
        heights[1] = thisHeight - getHeight(x -1, y);
        heights[2] = thisHeight - getHeight(x , y + 1);
        heights[3] = thisHeight - getHeight(x , y - 1);
        if (x==27 && y==61)
        {
            Debug.Log("Here");
        }

        if (OpenTiles[0] && OpenTiles[1])
        {//test east west scenarios.
            if ((heights[0] == -2) && (heights[1]== +2))
            {
               // Debug.Log("1-" + x + "," + y);
                mappings[x, y].TileLayoutMap = TileMap.TILE_SLOPE_E;
                return;
            }
            if ((heights[0] == +2) && (heights[1] == -2))
            {
                //Debug.Log("2-" + x + "," + y);
                mappings[x, y].TileLayoutMap = TileMap.TILE_SLOPE_W;
                return;
            }
        }

        if (OpenTiles[2] && OpenTiles[3])
        {//test north south scenarios.
            if ((heights[2] == -2) && (heights[3] == +2))
            {
               // Debug.Log("3-" + x + "," + y);
                mappings[x, y].TileLayoutMap = TileMap.TILE_SLOPE_N;
                return;
            }
            if ((heights[2] == +2) && (heights[3] == -2))
            {
                //Debug.Log("4-" + x + "," + y);
                mappings[x, y].TileLayoutMap = TileMap.TILE_SLOPE_S;
                return;
            }
        }

    }


    /// <summary>
    /// Is the tile one of tile_open or tile_slope_X
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    bool isTileWideOpen(int x, int y)
    {
        return
            (
            (mappings[x, y].TileLayoutMap == TileMap.TILE_OPEN)
            ||
            ((mappings[x, y].TileLayoutMap >= TileMap.TILE_SLOPE_N) && (mappings[x, y].TileLayoutMap <= TileMap.TILE_SLOPE_W))
            );
    }

    int getHeight(int x, int y)
    {
      
        return mappings[x, y].FloorHeight;
    }

    int getTileType(int x, int y)
    {
        return mappings[x, y].TileLayoutMap;
    }

    void PlaceCorners()
    {
        for (int x=1; x<=62;x++)
        {
            for (int y = 1; y <= 62; y++)
            {
                if (getTileType(x,y) == TileMap.TILE_OPEN)
                {
                    if ((getTileType(x+1, y) == TileMap.TILE_SOLID) && (getTileType(x, y+1) == TileMap.TILE_SOLID))
                    {
                        mappings[x, y].TileLayoutMap = TileMap.TILE_DIAG_SW;
                    }
                    if ((getTileType(x + 1, y) == TileMap.TILE_SOLID) && (getTileType(x, y - 1) == TileMap.TILE_SOLID))
                    {
                        mappings[x, y].TileLayoutMap = TileMap.TILE_DIAG_NW;
                    }
                    if ((getTileType(x - 1, y) == TileMap.TILE_SOLID) && (getTileType(x, y + 1) == TileMap.TILE_SOLID))
                    {
                        mappings[x, y].TileLayoutMap = TileMap.TILE_DIAG_SE;
                    }
                    if ((getTileType(x - 1, y) == TileMap.TILE_SOLID) && (getTileType(x, y - 1) == TileMap.TILE_SOLID))
                    {
                        mappings[x, y].TileLayoutMap = TileMap.TILE_DIAG_NE;
                    }
                }
            }
        }
    }
}

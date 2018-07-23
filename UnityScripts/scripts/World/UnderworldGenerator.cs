using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UnderworldGenerator : UWEBase {
    struct Room
    {
        public int index;
        public int x;//bottom left 
        public int y;
        public int dimX;//Dimensions of room
        public int dimY;
        public int[] ConnectedRooms; //Indices of rooms connected to this room (direct or indirect)
        public int[] BuiltConnections; //What connections are made by virtue of a corridor intersecting this room.
    };

    struct Connector
    {
        public int index;
        public int StartRoom;
        public int EndRoom;
        public int startX;
        public int startY;
        public int endX;
        public int endY;
        public int[] ConnectedRooms; //What rooms are connected to this corridor.        
    };

    public Text output;
    public int Seed;
    public int[,] RoomMap;//= new int[64, 64];
    public static UnderworldGenerator instance;
    private int ConnectorCount = 1;

    Room[] rooms;
    List<Connector> Connectors = new List<Connector>();
    public int NoOfRooms = 4;

    void Start()
    {
        instance = this;
    }

    public void GenerateLevel(int levelseed)
    {
        Seed = levelseed;
        ConnectorCount = 1;
        RoomMap = new int[64, 64];
        Connectors = new List<Connector>();
        Random.InitState(levelseed);
        NoOfRooms = Random.Range(1, 26);
        instance = this;
        //Randomly place
        int RoomsLeft = NoOfRooms;
        int NoOfAttempts = NoOfRooms * 8;//Try each room 8 times.
        int RoomIndex = 1;
        int validRooms = 0;
        rooms = new Room[NoOfRooms + 1];
        while ((RoomsLeft > 0) && (NoOfAttempts > 0))
        {
            //Generate a room
            Room newroom = RandomRoom();
            //check collision on room.
            if (!DoesRoomCollide(newroom))
            {
                // Debug.Log("Placing Room " + RoomIndex + " at " + newroom.x + "," + newroom.y + " (" +newroom.dimX + "," + newroom.dimY + ")");
                rooms[RoomIndex] = newroom;
                rooms[RoomIndex].index = RoomIndex;
                PlaceRoom(rooms[RoomIndex]);
                RoomIndex++;
                RoomsLeft--;
                validRooms++;
            }
            else
            {
                NoOfAttempts++;
            }
        }

        //Set no of connected rooms
        for (int i = 0; i <= validRooms; i++)
        {
            rooms[i].ConnectedRooms = new int[validRooms + 1];
            rooms[i].BuiltConnections = new int[validRooms + 1];
            for (int j = 0; j <= rooms[i].ConnectedRooms.GetUpperBound(0); j++)
            {
                rooms[i].ConnectedRooms[j] = 0;
                rooms[i].BuiltConnections[j] = 0;
            }
            rooms[i].ConnectedRooms[i] = i;//always connect to itself
        }

        FillConnectedRooms(validRooms);
        PlaceConnectors();
        PrintRoomConnections();
        PrintRooms();
    }

    Room RandomRoom()
    {
        Room room = new Room();

        room.x = Random.Range(2, 62);
        room.y = Random.Range(2, 62);
        room.dimX = Random.Range(3, 20);
        room.dimY = Random.Range(3, 20);
        if (room.x+room.dimX>=63)
        {
            room.dimX = 63 - room.x;
        }
        if (room.y + room.dimY >= 63)
        {
            room.dimY = 63 - room.y;
        }
        return room;
    }


    bool DoesRoomCollide(Room candidate)
    {
        for (int x = candidate.x; x <= candidate.x+ candidate.dimX && x <= 63; x++)
        {
            for (int y = candidate.y; y <= candidate.y+candidate.dimY && y <= 63; y++)
            {
                if (RoomMap[x,y] !=0)
                {//Space already contains a room.
                    return true;
                }
            }
        }
        return false;
    }

    void PlaceRoom(Room candidate)
    {
        for (int x = candidate.x; x < candidate.x+ candidate.dimX && x <= 63; x++)
        {
            for (int y = candidate.y; y < candidate.y+candidate.dimY && y <= 63; y++)
            {
                RoomMap[x, y] = candidate.index;
            }
        }
    }

    void PrintRooms()
    {
        for (int y = 63; y >= 0; y--)
        {
            for (int x = 0; x <= 63; x++)
            {
                if (RoomMap[x, y]>=0)
                {
                    output.text = output.text + RoomMap[x, y] +",";
                }
                else
                {
                    output.text = output.text + -RoomMap[x, y] + ",";
                }                
            }
            output.text = output.text + "\n";
        }
    }


    void FillConnectedRooms(int NoOfRooms)
    {
        //check all rooms until we find a room that is connected to all others
        int NoOfAttempts = 100;
        //connect room 1 to all rooms
      //  rooms[1].ConnectedRooms[1] = 1;
       // rooms[1].ConnectedRooms[2] = 2;
       // rooms[1].ConnectedRooms[3] = 3;
      //  rooms[1].ConnectedRooms[4] = 4;

        while ( ( !findRoomWithAllConnections()) && (NoOfAttempts>=0) )
        {
            //Pick a random room
            int startRoom = Random.Range(1, NoOfRooms+1);

            //pick a random room to connect to
            int endRoom = Random.Range(1, NoOfRooms+1);

            if (startRoom != endRoom)
            {
                if (rooms[startRoom].ConnectedRooms[endRoom]!=endRoom)
                {
                    ConnectRoom(startRoom, endRoom, NoOfRooms,true);
                }
            }

            NoOfAttempts--;
        }
    }

    void ConnectRoom(int startRoom, int endRoom, int NoOfRooms, bool Direct)
    {
        rooms[startRoom].ConnectedRooms[endRoom] = endRoom;//Create a direct connection between these rooms.
        rooms[endRoom].ConnectedRooms[startRoom] = startRoom;

        if (Direct)
        {
            //TODO:create the actual corridor link
           // Debug.Log("Connecting " + startRoom + " to " + endRoom);
            Connector con = new Connector();
            con.index = ConnectorCount++;
            con.StartRoom = startRoom;
            con.EndRoom = endRoom;
            con.ConnectedRooms = new int[NoOfRooms + 1];
            con.ConnectedRooms[con.StartRoom] = con.StartRoom; //Always connected to itself.
            con.startX = Random.Range(rooms[con.StartRoom].x, rooms[con.StartRoom].x + rooms[con.StartRoom].dimX);
            con.startY = Random.Range(rooms[con.StartRoom].y, rooms[con.StartRoom].y + rooms[con.StartRoom].dimY);
            con.endX = Random.Range(rooms[con.EndRoom].x, rooms[con.EndRoom].x + rooms[con.EndRoom].dimX);
            con.endY = Random.Range(rooms[con.EndRoom].y, rooms[con.EndRoom].y + rooms[con.EndRoom].dimY);

            Connectors.Add(con);
        }

        //check all other rooms. If the room connects to either start or end then it will connect to the other as well.

        for (int tr = 1; tr <= rooms.GetUpperBound(0); tr++)
        {
            for (int r = 1; r <= rooms.GetUpperBound(0); r++)
            {
                for (int c = 1; c <= rooms[r].ConnectedRooms.GetUpperBound(0); c++)
                {
                    if
                            (
                                (rooms[r].ConnectedRooms[c] == startRoom)
                                ||
                                (rooms[r].ConnectedRooms[c] == endRoom)
                            )
                    {
                        //Debug.Log("adding secondary link for room " + r + " to " + startRoom + " & " + endRoom);
                        rooms[r].ConnectedRooms[startRoom] = startRoom;
                        rooms[r].ConnectedRooms[endRoom] = endRoom;
                       
                    }
                }
            }
        }
    }



    bool findRoomWithAllConnections()
    {
        for (int r = 1; r<=rooms.GetUpperBound(0);r++)
        {
            for (int c = 1; c<= rooms[r].ConnectedRooms.GetUpperBound(0);c++)
            {
                if (rooms[r].ConnectedRooms[c] != c)
                {//This room is not connected to every other room. 
                    break;
                }
                if (c == rooms[r].ConnectedRooms.GetUpperBound(0))
                {//I have looped through all the rooms and this room is connected to all others. 
                 //Therefore all rooms are connected in some way.
                    //Debug.Log("Room " + r + " connects to all rooms");
                    return true;
                }
            }
        }
        return false;
    }

    void PrintRoomConnections()
    {
        for (int r= 1; r<=rooms.GetUpperBound(0);r++)
        {
            string connected="";
            for (int i=1; i<=rooms[r].ConnectedRooms.GetUpperBound(0);i++)
            {
                connected = connected + rooms[r].ConnectedRooms[i] + ",";
            }
            //Debug.Log("Room " + r + " connects to " + connected);
        }

      //  foreach( Connector con in Connectors)
       // {
            //Debug.Log("Connection from " + con.StartRoom + " to " + con.EndRoom);
       // }
    }


    void PlaceConnectors()
    {
        foreach (Connector con in Connectors)
        {
            
            //Run a path between start and end.
            int curX = con.startX; int curY = con.startY;
            int dirX; int dirY;
            if (rooms[con.StartRoom].BuiltConnections[con.EndRoom] == con.EndRoom)
            {//A connection already exists.
                curX = con.endX;
                curY = con.endY;
            }
            while (curX != con.endX || curY != con.endY)
            {
                int moveX = 0; int moveY = 0;//How far is to be moved in the x/y axis.
                int diffX = con.endX - curX;
                int diffY = con.endY - curY;
                int MoveAbs = 0;    //The movement distance choosen.

                //Pick how far will be moved in each axis
                if (diffX != 0)
                {
                    moveX = Random.Range(1, Mathf.Abs(diffX) + 1);
                }
                if (diffY != 0)
                {
                    moveY = Random.Range(1, Mathf.Abs(diffY) + 1);
                }
                //Pick the step direction for x/y
                if (diffX >= 0) { dirX = 1; } else { dirX = -1; }
                if (diffY >= 0) { dirY = 1; } else { dirY = -1; }
               
                if (moveX != 0 && moveY != 0)
                {//move in a random non-zero axis
                    if (Random.Range(0, 2) == 1)
                    {//move x
                        MoveAbs = moveX;
                        dirY = 0;
                    }
                    else
                    {//move 
                        MoveAbs = moveY;
                        dirX = 0;
                    }
                }
                else if (moveX != 0)
                {//move on x axis
                   // MoveOnX = true;
                    MoveAbs = moveX;
                    dirY = 0;
                }
                else
                {//move on y axis
                    //MoveOnY = true;
                    MoveAbs = moveY;
                    dirX = 0;
                }
                
                for (int x= 1; x<=Mathf.Abs(MoveAbs);x++)
                {
                    curX += dirX;
                    curY += dirY;
                    if (RoomMap[curX, curY] == 0)
                    {
                        RoomMap[curX, curY] = - con.index;//Connectors are negative numbers
                    }
                    else if(RoomMap[curX, curY] > 0)
                    {//I've hit another room. Set a built connection between start and this room
                        int roomReached = RoomMap[curX, curY];
                        rooms[roomReached].BuiltConnections[con.StartRoom] = con.StartRoom;
                        rooms[con.StartRoom].BuiltConnections[roomReached] = roomReached;
                        if ((roomReached != con.StartRoom) && (roomReached!=con.EndRoom))
                        {
                            int[] testedRooms = new int[NoOfRooms + 1];
                            if (AreRoomsConnected(rooms[roomReached], rooms[con.EndRoom], ref testedRooms))
                            {//there is a built connection to the target. Stop traversing.
                                curX = con.endX;
                                curY = con.endY;
                                break;
                            }
                        }
                    } 
                    else
                    {//I've hit a corridor. Check if that corridor connects to where I want to be.
                        int foundcorridor = Mathf.Abs(RoomMap[curX, curY]) - 1;
                        Room FoundStartRoom = rooms[Connectors[foundcorridor].StartRoom];
                        Room FoundEndRoom = rooms[Connectors[foundcorridor].EndRoom];
                        //Add connections to start and end of found corridor
                        rooms[con.StartRoom].BuiltConnections[FoundStartRoom.index] = FoundStartRoom.index;
                        rooms[con.StartRoom].BuiltConnections[FoundEndRoom.index] = FoundEndRoom.index;
                        FoundStartRoom.BuiltConnections[con.StartRoom] = con.StartRoom;
                        FoundEndRoom.BuiltConnections[con.StartRoom] = con.StartRoom;

                        //if (Connectors[foundcorridor].ConnectedRooms[con.EndRoom] == con.EndRoom)
                        int[] testedRooms = new int[NoOfRooms + 1];
                        if (AreRoomsConnected(rooms[Connectors[foundcorridor].StartRoom], rooms[con.EndRoom], ref testedRooms))
                        {//I've reached the target room because it connects to my destination via this corridor
                            curX = con.endX;
                            curY = con.endY;
                            break;
                        }
                    }
                    //Stop when reached the target x&y                       
                    if ((curX == con.endX) && (dirX != 0)) { break; }
                    if ((curY == con.endY) && (dirY != 0)) { break; }
                }
            }
            rooms[con.StartRoom].BuiltConnections[con.EndRoom] = con.EndRoom;
            rooms[con.EndRoom].BuiltConnections[con.StartRoom] = con.StartRoom;
        }

    }

    public TileMap CreateTileMap(short levelNo)
    {
        TileMap tm = new TileMap(levelNo);
        tm.texture_map = new short[TileMap.UW1_TEXTUREMAPSIZE];
        for (short t=0; t<=tm.texture_map.GetUpperBound(0); t++)
        {//Some quick and dirty values
            if (t<=57)
            {
                tm.texture_map[t] = t;
            }
            else
            {
                tm.texture_map[t] =(short)( t - 57);
            }
            
        }
        tm.Tiles = new TileInfo[64, 64];
        tm.CEILING_HEIGHT = ((128 >> 2) * 8 >> 3);
        RoomsToTileMap(tm, tm.Tiles);
        return tm;
    }


    public void RoomsToTileMap(TileMap tm, TileInfo[,] Tiles)
    {        
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
                Tiles[x, y].tileType = TileMap.TILE_SOLID;
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

                if (RoomMap[x,y] !=0)
                {                   
                    Tiles[x, y].tileType = TileMap.TILE_OPEN;
                    Tiles[x, y].floorHeight = 16;
                    Tiles[x, y].VisibleFaces[TileMap.vBOTTOM] = false;
                    Tiles[x, y].floorTexture = (short)Mathf.Min(Mathf.Abs(RoomMap[x, y]),10);
                    ////Floor textures are 49 to 56             
                }
               // return;
            }            
        }
       tm.SetTileMapWallFacesUW();
    }

    //void ConnectAll(int src, int dst )
    //{
    //    foreach (Connector con in Connectors)
    //    {
    //        //for (int c= 1;c<=con.ConnectedRooms.GetUpperBound(0);c++)
    //        // {
    //        // If a connector connects to src then it must also connect to dst.
    //        if (con.ConnectedRooms[src] == src)
    //        {
    //            con.ConnectedRooms[dst] = dst;
    //        }
    //        if (con.ConnectedRooms[dst] == dst)
    //        {
    //            con.ConnectedRooms[src] = src; 
    //        }            //}
    //    }

    //    for (int r=1;r<=rooms.GetUpperBound(0);r++)
    //    {             
    //        if(rooms[r].BuiltConnections[src]==src)
    //        {
    //            rooms[r].BuiltConnections[dst] = dst; 
    //        }

    //        if (rooms[r].BuiltConnections[dst] == dst)
    //        {
    //            rooms[r].BuiltConnections[src] = src; 
    //        }
    //    }
    //}


    bool AreRoomsConnected(Room src, Room dst, ref int[] testedRooms)
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
                (c!= src.index) //Not the room we are already in
                &&
                (src.ConnectedRooms[c] == c)    //Is a connected room
                &&
                (testedRooms[c]!=c)  //not already tested
                )
            {
                if (AreRoomsConnected( rooms[src.ConnectedRooms[c]] , dst, ref testedRooms ))
                {
                    result = true;
                    break;
                }
            }
        }


        return result;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A connecting passage betweent rooms.
/// </summary>
public class Connector : GeneratorClasses {

            
        public int StartRoom;
        public int EndRoom;
        public int startX;
        public int startY;
        public int endX;//The target endX & Y
        public int endY;
        public int actualEndX;//Where the corridor actually finishes up
        public int actualEndY;//Where the corridor actually finishes up
        public int[] ConnectedRooms; //What rooms are connected to this corridor.     
        public List<int> PathTakenX;//What xy coordinates are on the
        public List<int> PathTakenY;//What xy coordinates are on the
    public int TargetHeight;    //What height the corridor will end at

    private Room[] roomList;

    public Connector(int connectorIndex, int targetStartRoom, int targetEndRoom, int NoOfRooms, Room[] rooms)
    {
        actualEndX = -1;
        actualEndY = -1;
        index = connectorIndex;
        StartRoom = targetStartRoom;
        EndRoom = targetEndRoom;

        PathTakenX = new List<int>();
        PathTakenY = new List<int>();

        //To Track what rooms are connected by these connection
        ConnectedRooms = new int[NoOfRooms + 1];
        ConnectedRooms[StartRoom] = StartRoom; //Always connected to itself.

        SetRandomStartXY(rooms[StartRoom]);
        SetRandomEndXY(rooms[EndRoom]);

        roomList = rooms;

        SetBaseHeight();

    }

    void SetRandomStartXY(Room startRoom)
    {
        //Pick a random location within the room to place the connection points to.
        startX = Random.Range(startRoom.x, startRoom.x + startRoom.dimX);
        startY = Random.Range(startRoom.y, startRoom.y + startRoom.dimY);
    }

    void SetRandomEndXY(Room endRoom)
    {
        endX = Random.Range(endRoom.x, endRoom.x + endRoom.dimX);
        endY = Random.Range(endRoom.y, endRoom.y + endRoom.dimY);
    }

    public void AddPathStep (int newX, int newY)
    {
        PathTakenX.Add(newX);
        PathTakenY.Add(newY);
    }


    public void SetEnd()
    {
        actualEndX = endX;
        actualEndY = endY;
    }

    public void SetEnd(int newActualEndX, int newActualEndY)
    {
        actualEndX = newActualEndX;
        actualEndY = newActualEndY;
    }

    public Room Start()
    {
        return roomList[StartRoom];
    }

    public Room End()
    {
        return roomList[EndRoom];
    }

    public bool AtFinalDest(int curX, int curY)
    {
        return ((curX == endX) && (curY == endY) && (actualEndX != -1) && (actualEndY != -1));
    }


    /// <summary>
    /// Set the height the corridor will start at.
    /// </summary>
    protected override void SetBaseHeight()
    {//Use the base height of the start room.
        //In future this could also be withing a step or two of the start room to give the starting step or slope
        BaseHeight = roomList[StartRoom].BaseHeight;
    }

    public void SetTargetHeight(int[,]heightMap)
    {
        //Set the height the corridor will end at. Uses the actual end x&y so as to interest at the height of it's end junction,
        TargetHeight = heightMap[actualEndX, actualEndY];
    }

    void FixConnectorHeight(GeneratorMap[,] mappings)
    {//Placeholder
        //smooth the heights between start and end points so the corridor is continous.
     //Follow the path.

        //While there is still distance remaining randomly increase the height. 

        //If there is no less distance than height steps then just change the height.

        //Try and get as close as possible.

        //Issue. How do we handle intersections that are not the end point of the corridor. 
        //Should another connection have been created at that point to continue the connection/

    }
}

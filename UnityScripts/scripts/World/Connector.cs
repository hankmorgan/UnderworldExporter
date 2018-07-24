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
    public int ParentConnector; //This connector starts from another connector.
    public List<Connector> connectorslist; //ref to masterlist of connectors
    private Room[] roomList;

    public Connector(int connectorIndex, int targetStartRoom, int targetEndRoom, int NoOfRooms, Room[] rooms, List<Connector> connectors)
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
        connectorslist = connectors;

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
    /// 
    protected override void SetBaseHeight()
    {//Use the base height of the start room.
        //In future this could also be withing a step or two of the start room to give the starting step or slope
        if (ParentConnector ==-1)
        {
            BaseHeight = roomList[StartRoom].BaseHeight;
        }
        else
        {//starting from another corridor
            BaseHeight = UnderworldGenerator.instance.mappings[startX, startY].FloorHeight;
        }
        
    }

    public void SetTargetHeight()
    {

        if (ParentConnector == -1)
        { //Set the height the corridor will end at. Uses the actual end x&y so as to interest at the height of it's end junction,
            TargetHeight = UnderworldGenerator.instance.mappings[actualEndX, actualEndY].FloorHeight;
        }
        else
        {
            TargetHeight = roomList[EndRoom].BaseHeight;
        }          
           
    }

    public void FixConnectorHeight()
    {//Placeholder
     //smooth the heights between start and end points so the corridor is continous.
     //Follow the path.

        //While there is still distance remaining randomly increase the height. 

        //If there is no less distance than height steps then just change the height.

        //Try and get as close as possible.

        //Issue. How do we handle intersections that are not the end point of the corridor. 
        //Should another connection have been created at that point to continue the connection/

        //This will create steps at the very start of the connector. It looks kind of crap but you get the idea.
        SetBaseHeight();
        SetTargetHeight();
        Debug.Log("Smoothing connector " + index + " from room " + StartRoom + " to " + EndRoom + " height " + BaseHeight + " to " + TargetHeight);
        int accum=0;
        for (int i = 0; i<PathTakenX.Count;i++)
        {
            if (UnderworldGenerator.instance.mappings[PathTakenX[i], PathTakenY[i]].RoomMap != StartRoom)
            {//Only climb when outside the start room
                int change = 0;
                //Add accumulated height changes to this start height.
                UnderworldGenerator.instance.mappings[PathTakenX[i], PathTakenY[i]].FloorHeight = BaseHeight + accum;

                int heightAtStep = UnderworldGenerator.instance.mappings[PathTakenX[i], PathTakenY[i]].FloorHeight;

                //Check where the step is now in relation to the target.
                if (heightAtStep < TargetHeight)
                {//increase height
                    change = change + 2;
                }
                else if (heightAtStep > TargetHeight)
                {//decrease height
                    change = change - 2;
                }
                else
                {
                    //Future random wobble.
                    change = 0;
                }
                accum += change;//Accumulate the new change

                //Change by the new increase.    
                UnderworldGenerator.instance.mappings[PathTakenX[i], PathTakenY[i]].FloorHeight += change;

                //Clamp heights          
                if (UnderworldGenerator.instance.mappings[PathTakenX[i], PathTakenY[i]].FloorHeight < 0)
                {
                    UnderworldGenerator.instance.mappings[PathTakenX[i], PathTakenY[i]].FloorHeight = 0;
                }

                if (UnderworldGenerator.instance.mappings[PathTakenX[i], PathTakenY[i]].FloorHeight > 16)
                {
                    UnderworldGenerator.instance.mappings[PathTakenX[i], PathTakenY[i]].FloorHeight = 16;
                }
            }
        }
    }
}

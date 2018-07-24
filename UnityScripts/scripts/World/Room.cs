using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : GeneratorClasses {

    public int x;//bottom left 
    public int y;
    public int dimX;//Dimensions of room
    public int dimY;
    public int[] ConnectedRooms; //Indices of rooms connected to this room (direct or indirect)
    public int[] BuiltConnections; //What connections are made by virtue of a corridor intersecting this room.
   

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
        base.StyleArea();
    }


}

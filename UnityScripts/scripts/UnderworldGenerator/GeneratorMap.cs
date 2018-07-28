using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorMap : GeneratorClasses {
      
    //Defines the properties of a tile in the map generator.
    public int RoomMap; //What room is in this tile
    public int TileLayoutMap; //what tile type is at the tile. Currently only solid or open.
    public int JunctionMap; //Does this tile contain a junction and how many corridors meet here.
    public int FloorHeight;//Unimplemented.
    public int FloorTexture;
    public int WallTexture;
    public bool isDiag; //Is the tile a candidate for a diagonal tile
    public bool isSlope; //Is the tile a candidate for a slope


}

using UnityEngine;
using System.Collections;

public class TileInfo : Loader {

		public short tileType;	//What type of tile I am.
		//public int trueHeight;
		public short floorHeight;	//How high is the floor.
		public short ceilingHeight;	//Constant in UW. Variable in shock
		public short floorTexture;	//At the moment this is the index into the texture table
		public short wallTexture;	
		public int indexObjectList;	//Points to a linked list of objects in the objects block
		public short doorBit;
		public bool isDoor;	
		public short shockDoor;
		public short Render;		//If set then we output this tile. Is off when it is a subpart of a group or is hidden from sight.
		public short DimX;			//The dimensions (in tilesize) of this tile. 1 for a regular tile. 
		public short DimY;			//>1 for when it is a group in which case we do not render it but only render it parent til
		public short Grouped;		//textures/darkmod/stone/cobblestones/blocks_uneven06_grey off but when I group a set of tiles this indicates the tile is a child of a group.
		public short[] VisibleFaces=new short[6];	//Which faces are visible on a block. 
		public short North; public short South;
		public short East; public short West;
		public short UpperNorth; public short UpperSouth;
		public short UpperEast; public short UpperWest;
		public short LowerNorth; public short LowerSouth;
		public short LowerEast; public short LowerWest;
		public short Diagonal;
		public short Top; public short Bottom;	//Textures in each face
		//public short noOfNeighbours;	//Non solid neighbour tile count.
		public bool isLand;
		public bool isWater;		//Set when it has a water texture.
		public bool isLava;		//Set when it has a lava texture.
		public bool hasBridge;//Set when the tile contains a bridge.
		//public short hasExit;//Set when it contains a move trigger that goes to another level.
		//short waterRegion;	//Index to the water contigous area.
		//public short isCorridor;  //Part of a group of 4 or more tiles with only 2 non solid neighbours
		public short roomRegion;	//Index to the contigous room that the tile is part of.
		//short upperRegion; //Special case to store multiple values when the tile is part of a bridge.
		public short waterRegion; //Mask on water tiles for nav mesh generation.
		public short lavaRegion;// Mask on lave tiles for nav mesh generation.
		public short landRegion;// mask on land tiles for nave mesh generation
		public short bridgeRegion;//Mask for bridges.
		public short tileTested;  //for recursive region tests
		public short tileX;
		public short tileY;
		public short flags;//UW Tile flags
		public short noMagic;//Only seems to matter on Level 9 and possibly where there is water?

		public short BullFrog;	//Tile is a bullfrog tile. UW1/lvl3
		//Shock Specific Stuff
		public short shockSlopeFlag;	//For controlling ceiling slopes for shock.
		//short shockHazard;
		public short shockCeilingTexture;
		public short shockSteep;
		public short UseAdjacentTextures;
		public short shockTextureOffset;
		public short shockNorthOffset; public short shockSouthOffset;
		public short shockEastOffset; public short shockWestOffset;
		public short shockShadeUpper;	
		public short shockShadeLower;
		public short shockNorthCeilHeight; public short shockSouthCeilHeight;
		public short shockEastCeilHeight; public short shockWestCeilHeight;
		public short shockFloorOrientation; public short shockCeilOrientation;

		public short ActualType;

		//public int DoorIndex;	//Index to the door object if this tile has one.

		//public short hasPatch;	//Indicates that this tile has a tmap object in it.
		//int PatchIndex;	//Index to the tmap object

		public short hasElevator;	//Indicates that the tile has an elevator
		//Some flags are needed for this to support shock elevators
		//	1 = floor only	(uw style)
		//	2 = ceiling only 
		//  3 = both	
		//int ElevatorIndex;	//index to the elevator do_trap

		public short TerrainChange;	//Indicates that the tile can change into another type of tile
		//public short TerrainChangeCount;	//No of terrain changes acting on this tile
		///int TerrainChangeIndices[10];	//Array of terrain change objects affecting this tile. I'll need this for scripting.
		//int TerrainChangeIndex;	//index to the change terrain trap.

		public int[] SHOCKSTATE=new int[4];	//These should be ff,00,00,00 on an initial map. I'm just bringing them back for research purposes.
		//scripting state flags
		//short global;
		//short shadeUpperGlobal;
		//short shadeLowerGlobal;

		//public long address;	//The file address of the tile in question.

		public bool NeedsReRender=false;
		//public bool HasTeleport=false;

		///Some stuff I need to obsolete
		/// 
		//public bool tileVisited;



		/// <summary>
		/// Tells us the tile needs to be updated next LateUpdate
		/// </summary>
		public void TileNeedsUpdate()
		{
			NeedsReRender=true;
			GameWorldController.WorldReRenderPending=true;
		}
}

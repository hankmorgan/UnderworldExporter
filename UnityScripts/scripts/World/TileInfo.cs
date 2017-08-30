using UnityEngine;
using System.Collections;

public class TileInfo : Loader {

		public short tileType;	//What type of tile I am.
		public short floorHeight;	//How high is the floor.
		public short ceilingHeight;	//Constant in UW. Variable in shock
		public short floorTexture;	//At the moment this is the index into the texture table
		public short wallTexture;	
		public int indexObjectList;	//Points to a linked list of objects in the objects block
		public short doorBit;
		public bool isDoor;	
		public bool Render;		//If set then we output this tile. Is off when it is a subpart of a group or is hidden from sight.
		public short DimX;			//The dimensions (in tilesize) of this tile. 1 for a regular tile. 
		public short DimY;			//>1 for when it is a group in which case we do not render it but only render it parent til
		public bool Grouped;		// when I group a set of tiles this indicates the tile is a child of a group.
		public bool[] VisibleFaces=new bool[6];	//Which faces are visible on a block. 
		public short North; public short South;
		public short East; public short West;
		public short UpperNorth; public short UpperSouth;
		public short UpperEast; public short UpperWest;
		public short LowerNorth; public short LowerSouth;
		public short LowerEast; public short LowerWest;
		public short Diagonal;
		public short Top; public short Bottom;	//Textures in each face
		public bool isLand;
		public bool isWater;		//Set when it has a water texture.
		public bool isLava;		//Set when it has a lava texture.
		public bool hasBridge; //Set when the tile contains a bridge.
		public bool isNothing; //Set when the tile has the nothing textures
		public short roomRegion;	//Index to the contigous room that the tile is part of.
		public short waterRegion; //Mask on water tiles for nav mesh generation.
		public short lavaRegion;// Mask on lave tiles for nav mesh generation.
		public short landRegion;// mask on land tiles for nave mesh generation
		public short tileX;
		public short tileY;
		public short flags;//UW Tile flags
		public short noMagic;//Only seems to matter on Level 9 and possibly where there is water? UPDATE>Possible bug in reading data. Retest this.

		//Shock Specific Stuff
		public short shockSlopeFlag;	//For controlling ceiling slopes for shock.
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

		public bool TerrainChange;	//Indicates that the tile can change into another type of tile or moves in someway.

		public int[] SHOCKSTATE=new int[4];	//These should be ff,00,00,00 on an initial map. I'm just bringing them back for research purposes.

		public bool NeedsReRender=false;


		/// <summary>
		/// Tells us the tile needs to be updated next LateUpdate
		/// </summary>
		public void TileNeedsUpdate()
		{
			NeedsReRender=true;
			GameWorldController.WorldReRenderPending=true;
		}

		/// <summary>
		/// Tells us the texture index in the specified direction. If the surface is not visible it returns -1
		/// </summary>
		/// <returns>The visible wall texture.</returns>
		/// <param name="direction">Direction.</param>
		public int VisibleWallTexture(int direction)
		{
				if (VisibleFaces[direction]==false)
				{//Face is invisible.
						return -1;
				}
				else
				{
						switch (direction)	
						{
						case TileMap.vSOUTH:
								{
									return (int)South;
								}	
						case TileMap.vNORTH:
								{
									return (int)North;
								}	
						case TileMap.vEAST:
								{
									return (int)East;
								}	
						case TileMap.vWEST:
								{
									return (int)West;
								}	

						case TileMap.vBOTTOM:
						case TileMap.vTOP:
						default:
								{
									return (int)floorTexture;
								}
						}	
				}	
		}

}

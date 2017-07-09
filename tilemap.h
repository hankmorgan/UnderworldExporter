#ifndef tilemap_h
	#define tilemap_h
	


#define SLOPE_BOTH_PARALLEL 0
#define SLOPE_BOTH_OPPOSITE 1
#define SLOPE_FLOOR_ONLY 2
#define SLOPE_CEILING_ONLY 3

#define NORTH 180
#define SOUTH 0
#define EAST 270
#define WEST 90

#define SHOCK_NORTH 128
#define SHOCK_SOUTH 0
#define SHOCK_EAST 64
#define SHOCK_WEST 192

#define TILE_SOLID 0
#define TILE_OPEN 1
/*
Note the order of these 4 tiles are actually different in SHOCK. I swap them around in BuildTileMapShock for consistancy
*/
#define TILE_DIAG_SE 2
#define TILE_DIAG_SW 3
#define TILE_DIAG_NE 4
#define TILE_DIAG_NW 5

#define TILE_SLOPE_N 6
#define TILE_SLOPE_S 7
#define	TILE_SLOPE_E 8
#define TILE_SLOPE_W 9
#define TILE_VALLEY_NW 10
#define TILE_VALLEY_NE 11
#define TILE_VALLEY_SE 12
#define TILE_VALLEY_SW 13
#define TILE_RIDGE_SE 14
#define TILE_RIDGE_SW 15
#define TILE_RIDGE_NW 16
#define TILE_RIDGE_NE 17

#define CLEANUPHIDDEN  1
#define CLEANUPXAXIS 2
#define CLEANUPYAXIS 3

#define SURFACE_FLOOR 1
#define SURFACE_CEIL 2
#define SURFACE_WALL 3
#define SURFACE_SLOPE 4

struct tile
{
int tileType;	//What type of tile I am.
long floorHeight;	//How high is the floor.
long ceilingHeight;	//Constant in UW. Variable in shock
int floorTexture;	//At the moment this is the index into the texture table
int wallTexture;	
int indexObjectList;	//Points to a linked list of objects in the objects block
short isDoor;	
short shockDoor;
short Render;		//If set then we output this tile. Is off when it is a subpart of a group or is hidden from sight.
short DimX;			//The dimensions (in tilesize) of this tile. 1 for a regular tile. 
short DimY;			//>1 for when it is a group in which case we do not render it but only render it parent til
short Grouped;		//textures/darkmod/stone/cobblestones/blocks_uneven06_grey off but when I group a set of tiles this indicates the tile is a child of a group.
short VisibleFaces[6];	//Which faces are visible on a block. top0,east1,bottom2,west3,north4,south5 (these might be wrong. Test more!)
int North; int South;
int East; int West;
int UpperNorth; int UpperSouth;
int UpperEast; int UpperWest;
int LowerNorth; int LowerSouth;
int LowerEast; int LowerWest;
int Diagonal;
int Top; int Bottom;	//Textures in each face
short noOfNeighbours;	//Non solid neighbour tile count.
short isWater;		//Set when it has a water texture.
short isLava;		//Set when it has a lava texture.
short hasBridge;//Set when the tile contains a bridge.
short hasExit;//Set when it contains a move trigger that goes to another level.
//short waterRegion;	//Index to the water contigous area.
short isCorridor;  //Part of a group of 4 or more tiles with only 2 non solid neighbours
//short roomRegion;	//Index to the contigous room that the tile is part of.
//short upperRegion; //Special case to store multiple values when the tile is part of a bridge.
short waterRegion; //Mask on water tiles for nav mesh generation.
short lavaRegion;// Mask on lave tiles for nav mesh generation.
short landRegion;// mask on land tiles for nave mesh generation
short bridgeRegion;//Mask for bridges.
short tileTested;  //for recursive region tests
short tileX;
short tileY;
short flags;//UW Tile flags
short noMagic;//Only seems to matter on Level 9 and possibly where there is water?

short BullFrog;	//Tile is a bullfrog tile. UW1/lvl3
//Shock Specific Stuff
short shockSlopeFlag;	//For controlling ceiling slopes for shock.
short shockHazard;
int shockCeilingTexture;
int shockSteep;
int UseAdjacentTextures;
int shockTextureOffset;
int shockNorthOffset; int shockSouthOffset;
int shockEastOffset; int shockWestOffset;
short shockShadeUpper;	
short shockShadeLower;
long shockNorthCeilHeight; long shockSouthCeilHeight;
long shockEastCeilHeight; long shockWestCeilHeight;
short shockFloorOrientation; short shockCeilOrientation;

short ActualType;

int DoorIndex;	//Index to the door object if this tile has one.

short hasPatch;	//Indicates that this tile has a tmap object in it.
//int PatchIndex;	//Index to the tmap object

short hasElevator;	//Indicates that the tile has an elevator
					//Some flags are needed for this to support shock elevators
					//	1 = floor only	(uw style)
					//	2 = ceiling only 
					//  3 = both	
//int ElevatorIndex;	//index to the elevator do_trap

short TerrainChange;	//Indicates that the tile can change into another type of tile
short TerrainChangeCount;	//No of terrain changes acting on this tile
int TerrainChangeIndices[10];	//Array of terrain change objects affecting this tile. I'll need this for scripting.
//int TerrainChangeIndex;	//index to the change terrain trap.

int SHOCKSTATE[4];	//These should be ff,00,00,00 on an initial map. I'm just bringing them back for research purposes.
	//scripting state flags
	short global;
	short shadeUpperGlobal;
	short shadeLowerGlobal;

	long address;	//The file address of the tile in question.

	short DisplayType;
};






int getTile(int tileData);
int getHeight(int tileData);
int getDoors(long tileData);
int getFloorTex(unsigned char *buffer, long textureOffset, long tileData);
int getWallTex(unsigned char *buffer, long textureOffset, long tileData);
int getFloorTexUw2(unsigned char *buffer, long textureOffset, long tileData);
int getWallTexUw2(unsigned char *buffer, long textureOffset, long tileData);
int getObject(long tileData);
int DoTilesMatch(tile &t1, tile &t2);
void CleanUp(tile LevelInfo[64][64],int game);



int CalcNeighbourCeilHeight(tile &t1, tile &t2,int Direction);
void lookUpSubClass(unsigned char *tmp_ark, int BlockNo, int index, int *property1,int *property2,int *property3,int *property4);
void MergeCurrentWaterRegion(tile LevelInfo[64][64], int currRegion, int x, int y);
void MergeWaterRegions(tile LevelInfo[64][64]);
void MergeCurrentLavaRegion(tile LevelInfo[64][64], int currRegion, int x, int y);
void MergeLavaRegions(tile LevelInfo[64][64]);
void setTileNeighbourCount(tile LevelInfo[64][64]);
void setCorridors(tile LevelInfo[64][64], int *RoomIndex);
void MergeCorridors(tile LevelInfo[64][64], int *currentCorridorCount, int corridorIndex, int x, int y, int SetValue);
void ResetTileTests(tile LevelInfo[64][64]);
int isMergeableRoom(tile LevelInfo[64][64], int x, int y);
void MergeCurrentRoomRegion(tile LevelInfo[64][64], int currRegion, int x, int y);
void setRooms(tile LevelInfo[64][64], int *RoomIndex);
void CleanUp(tile LevelInfo[64][64], int game, int CleanupType, int tileType, int Surface);
void ResetCleanup(tile LevelInfo[64][64], int game);
void CleanUpHiddenTiles(tile LevelInfo[64][64], int game);
int DoTilesMatch(tile &t1, tile &t2, int Surface);
void CaulkHiddenWalls(tile LevelInfo[64][64], int game, int surface);
extern tile LevelInfo[64][64];

void LaunchEditor(tile LevelInfo[64][64]);

#endif /*tilemap_h*/
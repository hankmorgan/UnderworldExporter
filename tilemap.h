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
int VisibleFaces;	//Which faces are visible for caulking textures on solidblocks. 0-63 Binary combo. north,south,east,west,top,bottom.
int North; int South;
int East; int West;
int Diagonal;
int Top; int Bottom;	//Textures in each face
short noOfNeighbours;	//Non solid neighbour tile count.
short isWater;		//Set when it has a water texture.
//short waterRegion;	//Index to the water contigous area.
short isCorridor;  //Part of a group of 4 or more tiles with only 2 non solid neighbours
short roomRegion;	//Index to the contigous room that the tile is part of.
short tileTested;  //for recursive region tests
short tileX;
short tileY;

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
//int TerrainChangeIndex;	//index to the change terrain trap.

int SHOCKSTATE[4];	//These should be ff,00,00,00 on an initial map. I'm just bringing them back for research purposes.
	//scripting state flags
	short global;
	short shadeUpperGlobal;
	short shadeLowerGlobal;

	long address;	//The file address of the tile in question.
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
//long returnObject(ObjectItem &currObj);
//int BuildTileMapUW(tile LevelInfo[64][64],ObjectItem objList[1025], long texture_map[256] ,char *filePath, int game, int LevelNo);
//void BuildObjectListUW(tile LevelInfo[64][64], ObjectItem objList[1025],long texture_map[256],char *filePath, int game, int LevelNo);
unsigned char* unpack(unsigned char *tmp, int address_pointer, int *datalen);
//int BuildTileMapShock(tile LevelInfo[64][64],ObjectItem objList[1025], char *filePath, int game, int LevelNo);
void unpack_data (unsigned char *pack,    unsigned char *unpack,  unsigned long unpacksize);

long getShockBlockAddress(long BlockNo, unsigned char *tmp_ark , long *chunkPackedLength,long *chunkUnpackedLength, long *chunkType);
int CalcNeighbourCeilHeight(tile &t1, tile &t2,int Direction);
void lookUpSubClass(unsigned char *tmp_ark, int BlockNo, int index, int *property1,int *property2,int *property3,int *property4);
void MergeCurrentWaterRegion(tile LevelInfo[64][64], int currRegion, int x, int y);
void MergeWaterRegions(tile LevelInfo[64][64]);
void setTileNeighbourCount(tile LevelInfo[64][64]);
void setCorridors(tile LevelInfo[64][64], int *RoomIndex);
void MergeCorridors(tile LevelInfo[64][64], int *currentCorridorCount, int corridorIndex, int x, int y, int SetValue);
void ResetTileTests(tile LevelInfo[64][64]);
int isMergeableRoom(tile LevelInfo[64][64], int x, int y);
void MergeCurrentRoomRegion(tile LevelInfo[64][64], int currRegion, int x, int y);
void setRooms(tile LevelInfo[64][64], int *RoomIndex);
extern tile LevelInfo[64][64];

#endif /*tilemap_h*/
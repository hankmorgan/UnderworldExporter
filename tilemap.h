#ifndef _tilemap_h_
#define _tilemap_h_

#define SLOPE_BOTH_PARALLEL 0
#define SLOPE_BOTH_OPPOSITE 1
#define SLOPE_FLOOR_ONLY 2
#define SLOPE_CEILING_ONLY 3

#define NORTH 180
#define SOUTH 0
#define EAST 270
#define WEST 90

#define TILE_SOLID 0
#define TILE_OPEN 1
#define TILE_SLOPE_N 6
#define TILE_SLOPE_S 7
#define	TILE_SLOPE_E 8
#define TILE_SLOPE_W 9

struct tile
{
	int tileType;	//What type of tile I am.
	long floorHeight;	//How high is the floor.
	long ceilingHeight;	//Constant in UW. Variable in shock
	int floorTexture;	//At the moment this is the index into the texture table
	int wallTexture;	
	int indexObjectList;	//Points to a linked list of objects in the objects block
	short isDoor;		
	short Render;		//If set then we output this tile. Is off when it is a subpart of a group or is hidden from sight.
	short DimX;			//The dimensions (in tilesize) of this tile. 1 for a regular tile. 
	short DimY;			//>1 for when it is a group in which case we do not render it but only render it parent til
	short Grouped;		//textures/darkmod/stone/cobblestones/blocks_uneven06_grey off but when I group a set of tiles this indicates the tile is a child of a group.
	int VisibleFaces;	//Which faces are visible for caulking textures on solidblocks. 0-63 Binary combo. north,south,east,west,top,bottom.
	int North; int South;
	int East; int West;
	int Diagonal;
	int Top; int Bottom;	//Textures in each face
	short isWater;		//Set when it has a water texture.

	short tileX;
	short tileY;

	//Shock Specific Stuff
	int shockSlopeFlag;	//For controlling ceiling slopes for shock.
	short shockHazard;
	int shockCeilingTexture;
	int shockSteep;
	int UseAdjacentTextures;
	int shockTextureOffset;
	int shockNorthOffset; int shockSouthOffset;
	int shockEastOffset; int shockWestOffset;

	long shockNorthCeilHeight; long shockSouthCeilHeight;
	long shockEastCeilHeight; long shockWestCeilHeight;

	int DoorIndex;	//Index to the door object if this tile has one.

	int hasPatch;	//Indicates that this tile has a tmap object in it.
	int PatchIndex;	//Index to the tmap object

	int hasElevator;	//Indicates that the tile has an elevator
	int ElevatorIndex;	//index to the elevator do_trap

	int TerrainChange;	//Indicates that the tile can change into another type of tile
	int TerrainChangeIndex;	//index to the change terrain trap.
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
unsigned char* unpack(unsigned char *tmp, int address_pointer);
//int BuildTileMapShock(tile LevelInfo[64][64],ObjectItem objList[1025], char *filePath, int game, int LevelNo);
void unpack_data (unsigned char *pack,    unsigned char *unpack,  unsigned long unpacksize);
//void setDoorBits(tile LevelInfo[64][64], ObjectItem objList[1025]);
//void setPatchBits(tile LevelInfo[64][64], ObjectItem objList[1025]);
long getShockBlockAddress(long BlockNo, unsigned char *tmp_ark , long *chunkPackedLength,long *chunkUnpackedLength, long *chunkType);
int CalcNeighbourCeilHeight(tile &t1, tile &t2,int Direction);
void lookUpSubClass(unsigned char *tmp_ark, int BlockNo, int index);

extern tile LevelInfo[64][64];

#endif // _tilemap_h_
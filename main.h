#ifndef main_h
	#define main_h

#include "tilemap.h"
#include "gameobjects.h"
/*Game paths*/

//#define UW0_LEVEL_PATH  "C:\\Games\\Ultima\\UWDemo\\DATA\\level13.st"
#define UW0_TEXTUREW_PATH "DATA\\level13.txm"

//#define UW1_LEVEL_PATH  "C:\\Games\\UW1\\Data\\lev.ark"
#define UW1_TEXTURE_CONFIG_FILE "uw1_retro_config.txt"
#define UW1_TEXTURE_CONFIG_FILE_SOURCE "uw1_retro_config_source.txt"
#define UW1_OBJECT_CONFIG_FILE "uw1_object_config.txt"
#define UW1_STRINGS_FILE "data\\strings.pak"
#define UW1_CLEAN_STRINGS_FILE "uw1_stringsclean.txt"
#define UW1_TERRAIN_PROPS "Data\\terrain.dat"
#define UW1_CONVERSATION "data\\cnv.ark"
#define UW1_CRITTER_ASSOC "crit\\assoc.anm"
#define UW1_WEAPON_PAL "data\\WEAPONS.CM"	//Palette file for weapon skin colours.
//#define UW1_CRITTER_FILE "C:\\Games\\UW1\\crit\\CR23PAGE.N00"

//#define UW2_LEVEL_PATH "C:\\Games\\UW2\\data\\lev.ark"
#define UW2_TEXTURE_CONFIG_FILE "uw2_retro_config.txt"
#define UW2_TEXTURE_CONFIG_FILE_SOURCE "uw2_retro_config_source.txt"
#define UW2_OBJECT_CONFIG_FILE "uw2_object_config.txt"
#define UW2_STRINGS_FILE "data\\strings.pak"
#define UW2_TERRAIN_PROPS "Data\\terrain.dat"
#define UW2_CRITTER_ASSOC "crit\\AS.AN"
#define UW2_WEAPON_PAL "data\\WEAP.CM"
//#define UW2_OUT_PATH "C:\\Games\\UW2\\data\\Repacked.ark"

//Change these depending on which set of textures you want to extract
//#define GRAPHICS_FILE "C:\\Games\\UW2\\DATA\\DOORS.GR"
//#define GRAPHICS_PAL_FILE "C:\\Games\\UW2\\DATA\\pals.dat"
#define AUXILARY_PAL_FILE "DATA\\allpals.dat"


//#define SHOCK_LEVEL_PATH  "C:\\Games\\SystemShock\\Res\\DATA\\ARCHIVE.dat"
#define SHOCK_STRINGS_FILE "\\Res\\DATA\\CYBSTRNG.RES"
#define SHOCK_TEXTURE_CONFIG_FILE "shock_texture_config.txt"
#define SHOCK_TEXTURE_CONFIG_FILE_SOURCE "shock_texture_config_source.txt"
#define SHOCK_OBJECT_CONFIG_FILE "shock_object_config.txt"
#define SHOCK_COMMONOBJ_FILE  "C:\\Games\\SystemShock\\Res\\DATA\\objprop.dat"
#define SHOCK_MODEL_FILE  "Res\\DATA\\obj3d.res"
//#define SHOCK_OUT_PATH "C:\\Games\\SystemShock\\Res\\DATA\\Repacked.dat"

#define ENTRANCES_CONFIG_FILE  "uw1_entrances.txt"

//temporary paths for testing things before I implement commandline params/interface for file paths once I switch to file I/O
#define SCRIPT_GlOBAL_FILE "scriptglobal.txt"
#define SCRIPT_MAIN_FILE "scriptmain.txt"
#define SCRIPT_BODY_FILE "scriptbody.txt"
//#define SCRIPT_FINAL_FILE "C:\\games\\darkmod\\maps\\shock_1.script"
//#define MAP_OUTPUT_FILE "C:\\games\\darkmod\\maps\\shock_1.map"
#define MAP_OUTPUT_FILE_SOURCE "C:\\source.vmf"

#define ENABLE_LIGHTING 1
#define ENABLE_WATER 0

/*Globals*/
extern int BrushSizeX;
extern int BrushSizeY;
extern int BrushSizeZ;
extern int PrimitiveCount;
extern int EntityCount;
extern int CEILING_HEIGHT;

//BrushFaces
#define fSELF 128
#define fCEIL 64
#define fNORTH 32
#define fSOUTH 16
#define fEAST 8
#define fWEST 4
#define fTOP 2
#define fBOTTOM 1

//Game IDs
#define UWDEMO 0
#define UW1 1
#define UW2 2
#define SHOCK 3

//ceiling constants
//#xdefine UW_CEILING_HEIGHT 19
//This is now set in buildtilemapshock in order to support variable height levels.
//#dxefine SHOCK_CEILING_HEIGHT 32	 

//Uw graphic formats.
#define UW_GRAPHICS_BITMAPS -1	//BYT
#define UW_GRAPHICS_TEXTURES 0	//.tr
#define UW_GRAPHICS_GR 1	//.gr
#define UW_GRAPHICS_TR 2
#define UW_GRAPHICS_CR 3
#define UW_GRAPHICS_SR 4
#define UW_GRAPHICS_AR 5


//Modes
#define ASCII_MODE 0
#define D3_MODE 1
#define STRINGS_EXTRACT_MODE 2
#define BITMAP_EXTRACT_MODE 3
#define SCRIPT_BUILD_MODE 4
#define MATERIALS_BUILD_MODE 5
#define CONVERSATION_MODE 6
#define REPACK_MODE 7
#define SOURCE_MODE 8
#define CRITTER_EXTRACT_MODE 9
#define CUTSCENE_EXTRACT_MODE 10
#define FBX_MODE 11
#define UNITY_MODE 12
#define UNITY_TILEMAP_MODE 13
#define FONT_EXTRACT_MODE 14


//UW2 Ark block numbers
#define UW2_OFFSET_BLOCK 0
#define UW2_COMPRESS_BLOCK 1
#define UW2_SIZE_BLOCK 2
#define UW2_SPACE_BLOCK 3

//Turn off alpha channels globally.
#define ALPHA 1

//Should graphics be actually extracted or should I just go through the motions?
#define ACTUALLY_EXTRACT_FILES 1

//Door size defaults
#define DOORWIDTH 80
#define DOORTHICKNESS 2
#define DOORHEIGHTUNITS 7

#define LOGFILENAME "UWEXPORT_LOG.txt"
extern FILE *LOGFILE;

void exportMaps(int game, int mode, int LevelNo, char OutFileName[255], char filePath[255]);
void LoadConfig(int game, int mode);
int getShockObjectIndex(int objClass, int objSubClass, int objSubClassIndex);

int BuildTileMapUW(tile LevelInfo[64][64], ObjectItem objList[1600], long texture_map[256], char *filePath, int game, int LevelNo);
int BuildTileMapShock(tile LevelInfo[64][64], ObjectItem objList[1600], long texture_map[272], char *filePath, int game, int LevelNo);
void BuildObjectListUW(tile LevelInfo[64][64], ObjectItem objList[1600], long texture_map[256], char *filePath, int game, int LevelNo);
void BuildObjectListShock(tile LevelInfo[64][64], ObjectItem objList[1600], long texture_map[256], char *filePath, int game, int LevelNo);

void setElevatorBits(tile LevelInfo[64][64], ObjectItem objList[1600]);
void setKeyCount(int game, tile LevelInfo[64][64], ObjectItem objList[1600]);
void setObjectTileXY(int game, tile LevelInfo[64][64], ObjectItem objList[1600]);

void setTerrainChangeBits(tile LevelInfo[64][64], ObjectItem objList[1600]);

void RenderEntity(int game, float x, float y, float z, ObjectItem &currobj, ObjectItem objList[1600], tile LevelInfo[64][64]);

extern char path_uw0[100];
extern char path_uw1[100];
extern char path_uw2[100];
extern char path_shock[100];


#endif /* main_h */


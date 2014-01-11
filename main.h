#ifndef gameobjects_h
	#define gameobjects_h
	#include "gameobjects.h"
#endif
#ifndef gamestrings_h
	#define gamestrings_h
	#include "gamestrings.h"
#endif
#ifndef tilemap_h
	#define tilemap_h
	#include "tilemap.h"
#endif
#ifndef utils_h
	#define utils_h
	#include "utils.h"
#endif
#ifndef tilemap_h
	#define tilemap_h
	#include "tilemap.h"
#endif
#ifndef textures_h
	#define textures_h
	#include "textures.h"
#endif
#ifndef main_h
	#define main_h
	#include "main.h"
#endif	
#ifndef gamegraphics_h
	#define gamegraphics_h
	#include "gamegraphics.h"
#endif


/*Game paths*/

#define UW0_LEVEL_PATH  "C:\\Games\\Ultima\\UWDemo\\DATA\\level13.st"
#define UW0_TEXTUREW_PATH "C:\\Games\\Ultima\\UWDemo\\DATA\\level13.txm"
#define UW1_LEVEL_PATH  "C:\\Games\\Ultima\\UW1\\Data\\lev.ark"
#define UW2_LEVEL_PATH "C:\\Games\\Ultima\\UW2\\DATA\\lev.ark"
#define SHOCK_LEVEL_PATH  "C:\\Games\\SystemShock\\Res\\DATA\\archive.dat"
#define GRAPHICS_FILE "C:\\Games\\Ultima\\UW2\\DATA\\T64.TR"
#define GRAPHICS_PAL_FILE "C:\\Games\\Ultima\\UW2\\DATA\\pals.dat"
#define TEXTURE_CONFIG_FILE "C:\\Documents and Settings\\me\\Desktop\\Downloads\\Underworld\\uw_exporter\\Underworld Exporter\\Underworld Exporter\\uw1_retro_config.txt"
#define OBJECT_CONFIG_FILE "C:\\Documents and Settings\\me\\Desktop\\Downloads\\Underworld\\uw_exporter\\Underworld Exporter\\Underworld Exporter\\uw1_object_config.txt"
#define STRINGS_FILE "C:\\Games\\Ultima\\UW2\\data\\strings.pak"
#define SHOCK_STRINGS_FILE "C:\\Games\\SystemShock\\Res\\DATA\\CYBSTRNG.RES"
#define ENTRANCES_CONFIG_FILE  "C:\\Documents and Settings\\me\\Desktop\\Downloads\\Underworld\\uw_exporter\\Underworld Exporter\\Underworld Exporter\\uw1_entrances.txt"

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
#define UW_CEILING_HEIGHT 19
//This is now set in buildtilemapshock in order to support variable height levels.
//#dxefine SHOCK_CEILING_HEIGHT 32	 



//Modes
#define ASCII_MODE 0
#define D3_MODE 1



void exportMaps(int game,int mode,int LevelNo);
void LoadConfig(int game);



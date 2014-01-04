#include <stdio.h>
#include <stdlib.h>
#include <fstream>
#include <math.h>

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
#ifndef gameobjects_h
	#define gameobjects_h
	#include "gameobjects.h"
#endif
#ifndef D3DarkMod_h
	#define D3DarkMod_h
	#include "D3DarkMod.h"
#endif
#ifndef asciimode_h
	#define asciimode_h
	#include "asciimode.h"
#endif
#include <string.h>

using namespace std;

texture *textureMasters;
objectMaster *objectMasters;

void setDoorBits(tile LevelInfo[64][64], ObjectItem objList[1025]);
int BuildTileMapUW(tile LevelInfo[64][64],ObjectItem objList[1025], long texture_map[256] ,char *filePath, int game, int LevelNo);
void BuildObjectListUW(tile LevelInfo[64][64], ObjectItem objList[1025],long texture_map[256],char *filePath, int game, int LevelNo);
void setPatchBits(tile LevelInfo[64][64], ObjectItem objList[1025]);
void setElevatorBits(tile LevelInfo[64][64], ObjectItem objList[1025]);
void setTerrainChangeBits(tile LevelInfo[64][64], ObjectItem objList[1025]);
void BuildObjectListUW(tile LevelInfo[64][64], ObjectItem objList[1025],long texture_map[256],char *filePath, int game, int LevelNo);
int BuildTileMapShock(tile LevelInfo[64][64],ObjectItem objList[1025], long texture_map[272], char *filePath, int game, int LevelNo);
void setObjectTileXY(tile LevelInfo[64][64], ObjectItem objList[1025]);
void unpackStringsShock();
extern int levelNo;


int main()
{
objectMaster *objMasterList;
BrushSizeX=80;BrushSizeY=80;BrushSizeZ=15;	

levelNo=1;
int NoOfLevels=9;		//uw1 has 9, uw2 has 80(kind of), shock has 15, uw demo has 0. Level no 0 is the first level.

	LoadConfig(UW1);
//Uncomment this this loop to see everything but note the output will not work in Radiant. 
//for (levelNo=0; levelNo<NoOfLevels; levelNo++)
//{

//The two modes are ASCII_MODE and D3_MODE.

	//exportMaps(UWDEMO,D3_MODE,0); //export level 0  from Underworld demo.
	//exportMaps(UW1,D3_MODE,levelNo);	//Export levelno from Underworld.
	//exportMaps(UW2,D3_MODE,levelNo);	//export levelno from Underworld II
	exportMaps(SHOCK, D3_MODE,levelNo);	//Export Level No from Shock.
//	}
	

//Use this to extract bitmaps from UW1. You can change the paths in the function to point to UW2 and Demo texture files and byt files.
//For Byt files set the NoOfTextures variable to 0;	
	//extractTextureBitmap(-1);
	
//Use this to extract strings from UW1. You can change the paths in the function to point to UW2 and Demo string files 	
	//unpackStrings();
	//unpackStringsShock();
	
}



void LoadConfig(int game)
{
//Read in mile
FILE *f = NULL;
int i=0;
int texNo=0;
char texDesc[80];
char texPath[80];

int objNo=0;
char objDesc[80];
char objPath[80];
char objCat[10];
int objType;

char line[255];
switch (game)
	{
	case UW1:
		{
		textureMasters =new texture[300];	
		objectMasters=new objectMaster[1025];
		}
	}
const char *filePathT = TEXTURE_CONFIG_FILE;

f=fopen(filePathT,"r");
if (f!=NULL)
	{
	while (fgets(line,255,f))
		{
		float align1_1=0;
		float align1_2=0;
		float align1_3=0;
		float align2_1=0;
		float align2_2=0;
		float align2_3=0;
		
		float floor_align1_1=0;
		float floor_align1_2=0;
		float floor_align1_3=0;
		float floor_align2_1=0;
		float floor_align2_2=0;
		float floor_align2_3=0;
		
		int water=0;
		int lava=0;
		sscanf(line, "%d %s %s %f %f %f %f %f %f %f %f %f %f %f %f %d %d",
		&texNo,&texDesc,&texPath, 
		&align1_1, &align1_2, &align1_3, &align2_1, &align2_2, &align2_3, 
		&floor_align1_1, &floor_align1_2, &floor_align1_3, &floor_align2_1, &floor_align2_2, &floor_align2_3, 
		&water, &lava);
		
		
		textureMasters[i].textureNo = texNo;
		strcpy(textureMasters[i].desc, texDesc);
		strcpy(textureMasters[i].path , texPath);
		textureMasters[i].align1_1 = align1_1;
		textureMasters[i].align1_2 = align1_2;
		textureMasters[i].align1_3 = align1_3;
		textureMasters[i].align2_1 = align2_1;
		textureMasters[i].align2_2 = align2_2;
		textureMasters[i].align2_3 = align2_3;

		textureMasters[i].floor_align1_1 = floor_align1_1;
		textureMasters[i].floor_align1_2 = floor_align1_2;
		textureMasters[i].floor_align1_3 = floor_align1_3;
		textureMasters[i].floor_align2_1 = floor_align2_1;
		textureMasters[i].floor_align2_2 = floor_align2_2;
		textureMasters[i].floor_align2_3 = floor_align2_3;		
		
		
		textureMasters[i].water = water;
		textureMasters[i].lava = lava;
		i++;
		}
	fclose(f);
	}
	
const char *filePathO = OBJECT_CONFIG_FILE;
f=fopen(filePathO,"r");
if (f!=NULL)
	{
	while (fgets(line,173,f))
		{
		sscanf(line, "%d %s %s %s %d",&objNo,&objDesc,&objPath,&objCat,&objType );
		objectMasters[objNo].index=objNo;
		objectMasters[objNo].isSet=1;
		strcpy(objectMasters[objNo].desc, objDesc);
		strcpy(objectMasters[objNo].path , objPath);
		if (strcmp(objCat,"model") == 0)
			{
			objectMasters[objNo].isEntity = 0;
			}
		else if(strcmp(objCat,"entity") == 0)
			{
			objectMasters[objNo].isEntity = 1;
			}
		else
			{
			objectMasters[objNo].isEntity = -1;
			}
		objectMasters[objNo].type = objType;
		i++;
		}
	fclose(f);
	}	
}


void exportMaps(int game,int mode,int LevelNo)
{

//	tile LevelInfo[64][64];
	ObjectItem objList[1025];
	long texture_map[256]; 
	long texture_map_shock[272]; 
	//texture_map = new unsigned char[256];
	long textureOffset;	
	char *filePath;
	switch (game)
		{
		case UWDEMO:		//Underworld Demo
			{
			filePath = UW0_LEVEL_PATH ;	//"C:\\Games\\Ultima\\UWDemo\\DATA\\level13.st";
			BuildTileMapUW(LevelInfo,objList,texture_map,filePath,game,LevelNo);
			BuildObjectListUW(LevelInfo,objList,texture_map,filePath,game,LevelNo);
			setObjectTileXY(LevelInfo,objList);
			setDoorBits(LevelInfo,objList);
			setPatchBits(LevelInfo,objList);
			setElevatorBits(LevelInfo,objList);
			setTerrainChangeBits(LevelInfo,objList);
			CleanUp(LevelInfo,game); //Get rid of unneeded tiles.			
			break; 			
			}
		case UW1:		//Underworld 1
			{
			filePath = UW1_LEVEL_PATH ;	// "C:\\Games\\Ultima\\UW1\\DATA\\lev.ark";
			BuildTileMapUW(LevelInfo,objList, texture_map,filePath,game,LevelNo);
			BuildObjectListUW(LevelInfo,objList,texture_map,filePath,game,LevelNo);
			setObjectTileXY(LevelInfo,objList);
			setDoorBits(LevelInfo,objList);
			setPatchBits(LevelInfo,objList);
			setElevatorBits(LevelInfo,objList);
			setTerrainChangeBits(LevelInfo,objList);
			CleanUp(LevelInfo,game); //Get rid of unneeded tiles.			
			break; 
			}
		case UW2:		//Underworld 2
			{
			filePath = UW2_LEVEL_PATH;	//"C:\\Games\\Ultima\\UW2\\DATA\\lev.ark";
			if (BuildTileMapUW(LevelInfo,objList,texture_map,filePath,game,LevelNo) == -1) {return;};
			BuildObjectListUW(LevelInfo,objList,texture_map,filePath,game,LevelNo);
			setObjectTileXY(LevelInfo,objList);
			setDoorBits(LevelInfo,objList);
			setPatchBits(LevelInfo,objList);
			setElevatorBits(LevelInfo,objList);
			CleanUp(LevelInfo,game); //Get rid of unneeded tiles.
			break;			
			}
		case SHOCK:		//system shock
			{
			filePath = SHOCK_LEVEL_PATH;	//"C:\\Games\\SystemShock\\Res\\DATA\\archive.dat";
			BuildTileMapShock(LevelInfo,objList,texture_map_shock,filePath,game,LevelNo);
			CleanUp(LevelInfo,game); //Get rid of unneeded tiles.
			break;
			}			
		default:
			{printf("Invalid Game!");return;}
		}


	
	switch (mode)
		{
		case ASCII_MODE:		//ascii + other data maps
			{
			DumpAscii(game,LevelInfo,objList,LevelNo,0);	//1 for maps only. 0 for extra printouts like objects, textures + heightmaps.
			break;
			}		
		case D3_MODE:		//D3/Dark Mod
			{
			RenderDarkModLevel(LevelInfo,objList,game);		
			break;
			}
		}
	}
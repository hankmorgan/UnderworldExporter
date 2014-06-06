#include <stdio.h>
#include <stdlib.h>
#include <fstream>
#include <math.h>
#include <string.h>


#include "textures.h"
#include "gameobjects.h"
#include "tilemap.h"
#include "d3darkmod.h"
#include "scripting.h"
#include "materials.h"
#include "main.h"
#include "asciimode.h"
#include "gamestrings.h"
#include "gamegraphics.h"
#include "Conversations.h"

using namespace std;

texture *textureMasters;
objectMaster *objectMasters;
FILE *MAPFILE;
//shockObjectMaster *shockObjectMasters;

//void setDoorBits(tile LevelInfo[64][64], ObjectItem objList[1600]);
//

//void setPatchBits(tile LevelInfo[64][64], ObjectItem objList[1600]);
//
//
//void BuildObjectListUW(tile LevelInfo[64][64], ObjectItem objList[1600],long texture_map[256],char *filePath, int game, int LevelNo);
////void BuildObjectListShock(tile LevelInfo[64][64], shockObjectItem shockobjList[1600], long texture_map[256],char *filePath, int game, int LevelNo);
//
//
//
//
//void RenderDarkModLevel(tile LevelInfo[64][64],ObjectItem objList[1600],int game);
//void DumpAscii(int game,tile LevelInfo[64][64],ObjectItem objList[1600],int LevelNo,int mapOnly);

//
//

extern int levelNo;
extern int GAME;

int main()
{
//int game = SHOCK;
//int game = UWDEMO;
int game = UW1;
//int game = UW2;
int mode = D3_MODE;
//int mode = ASCII_MODE;
//int mode = STRINGS_EXTRACT_MODE;
//int mode = BITMAP_EXTRACT_MODE;
//int mode = SCRIPT_BUILD_MODE;
//int mode = MATERIALS_BUILD_MODE;
//int mode = CONVERSATION_MODE;

levelNo = 3;

GAME = game;
switch (game)
	{
	case UWDEMO:
	case UW1:
	case UW2:
		{BrushSizeX=120;BrushSizeY=120;BrushSizeZ=15;break;}
	case SHOCK:
		{BrushSizeX=120;BrushSizeY=120;BrushSizeZ=15;break;}//To ease on the steepness of some slopes that are impassible
	}
//int NoOfLevels=80;		//uw1 has 9, uw2 has 80(kind of), shock has 15, uw demo has 0. Level no 0 is the first level.

	LoadConfig(game);
	
	switch (mode)
		{
		case D3_MODE:
		case ASCII_MODE:
		case SCRIPT_BUILD_MODE:
			//for (levelNo = 0; levelNo < 80; levelNo++)
			//{
				printf("============================Level %d=========================\n", levelNo);
				exportMaps(game, mode, levelNo);
			//}
			break;
		case STRINGS_EXTRACT_MODE:
			if (game == SHOCK)
				{
				unpackStringsShock(SHOCK_STRINGS_FILE);
				}
			else
				{
				unpackStrings(game);
				}
			break;
		case BITMAP_EXTRACT_MODE:
			extractTextureBitmap(-1, GRAPHICS_FILE, GRAPHICS_PAL_FILE, 0, 64, UW_GRAPHICS_GR);
			break;
		case MATERIALS_BUILD_MODE:
			//BuildXDataFile(game);
			//BuildSndShaderFiles();
			//BuildShockMtrFiles(3);
			//BuildUWMtrFiles(game,2);
			BuildUWXData(game, 8);
			//BuildGuiFiles();
			//ExportModelFormat();
			//BuildWORDSXData(game);
			break;
		case CONVERSATION_MODE:
			ExtractConversations(UW1);
			break;
		}
	}



void LoadConfig(int game)
{
//Read in mile
FILE *f = NULL;
char filePathT[255];
int i=0;
int texNo=0;
char texDesc[80];
char texPath[80];

int objNo=0;
char objDesc[80];
char objPath[80];
char objCat[10];
int objType;

int objClass; int objSubClass; int objSubClassIndex;	//Shock object classes

char line[255];
textureMasters =new texture[300];
objectMasters=new objectMaster[1025];
switch (game)
	{
	case UWDEMO:
	case UW1:
		strcpy_s(filePathT, UW1_TEXTURE_CONFIG_FILE);break;	
	case UW2:
		strcpy_s(filePathT, UW2_TEXTURE_CONFIG_FILE);break;	
	case SHOCK:
		strcpy_s(filePathT, SHOCK_TEXTURE_CONFIG_FILE);break;	
	}

//f=fopen(filePathT,"r");
if ((fopen_s(&f,filePathT, "r") == 0))
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
		
		
		textureMasters[texNo].textureNo = texNo;
		strcpy_s(textureMasters[texNo].desc, texDesc);
		strcpy_s(textureMasters[texNo].path , texPath);
		textureMasters[texNo].align1_1 = align1_1;
		textureMasters[texNo].align1_2 = align1_2;
		textureMasters[texNo].align1_3 = align1_3;
		textureMasters[texNo].align2_1 = align2_1;
		textureMasters[texNo].align2_2 = align2_2;
		textureMasters[texNo].align2_3 = align2_3;

		textureMasters[texNo].floor_align1_1 = floor_align1_1;
		textureMasters[texNo].floor_align1_2 = floor_align1_2;
		textureMasters[texNo].floor_align1_3 = floor_align1_3;
		textureMasters[texNo].floor_align2_1 = floor_align2_1;
		textureMasters[texNo].floor_align2_2 = floor_align2_2;
		textureMasters[texNo].floor_align2_3 = floor_align2_3;		
		
		
		textureMasters[texNo].water = water;
		textureMasters[texNo].lava = lava;
		i++;
		}
	fclose(f);
	}
	char filePathO[255];
	switch (game)
	{
	case UWDEMO:
	case UW1:
		strcpy_s(filePathO, UW1_OBJECT_CONFIG_FILE );break;	
	case UW2:
		strcpy_s(filePathO, UW2_OBJECT_CONFIG_FILE );break;	
	case SHOCK:
		strcpy_s(filePathO, SHOCK_OBJECT_CONFIG_FILE );break;	
	}

if ((fopen_s(&f,filePathO, "r") == 0))
	{
		switch (game)
			{
			case UWDEMO:
			case UW1:
			case UW2:
			case SHOCK:			
				{
				while (fgets(line,173,f))
					{
					sscanf(line, "%d %d %d %d %s %s %s %d",
					&objNo, &objClass, &objSubClass, &objSubClassIndex,
					&objDesc,&objPath,&objCat,&objType );
					objectMasters[objNo].index=objNo;
					objectMasters[objNo].isSet=1;
					
					objectMasters[objNo].objClass = objClass;
					objectMasters[objNo].objSubClass = objSubClass;
					objectMasters[objNo].objSubClassIndex = objSubClassIndex;	
									
					strcpy_s(objectMasters[objNo].desc, objDesc);
					strcpy_s(objectMasters[objNo].path , objPath);
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
					objectMasters[objNo].DeathWatch = 0;
					i++;
					}
				fclose(f);
				break;
				}
			}
		}
}


void exportMaps(int game,int mode,int LevelNo)
{
	ObjectItem objList[1600];
	//shockObjectItem shockobjList[1600];
	long texture_map[256]; 
	long texture_map_shock[272]; 

	char *filePath;
	if (mode == D3_MODE)
		{
		if (fopen_s(&MAPFILE,MAP_OUTPUT_FILE, "w")!=0)
		{
		printf("Unable to create output file for map");
		return;
		}
		}
	switch (game)
		{
		case UWDEMO:		//Underworld Demo
			{
			filePath = UW0_LEVEL_PATH ;	//"C:\\Games\\Ultima\\UWDemo\\DATA\\level13.st";
			BuildTileMapUW(LevelInfo,objList,texture_map,filePath,game,LevelNo);
			BuildObjectListUW(LevelInfo,objList,texture_map,filePath,game,LevelNo);
			setObjectTileXY(game,LevelInfo,objList);
			setDoorBits(LevelInfo,objList);
			setPatchBits(LevelInfo,objList);
			setElevatorBits(LevelInfo,objList);
			setTerrainChangeBits(LevelInfo,objList);
			setKeyCount(game, LevelInfo, objList);
			PrintUWObjects(objList);	//Since I can't get full debug info until I have TileX/Y set.
			CleanUp(LevelInfo,game); //Get rid of unneeded tiles.			
			break; 			
			}
		case UW1:		//Underworld 1
			{
			filePath = UW1_LEVEL_PATH ;	// "C:\\Games\\Ultima\\UW1\\DATA\\lev.ark";
			BuildTileMapUW(LevelInfo,objList, texture_map,filePath,game,LevelNo);
			BuildObjectListUW(LevelInfo,objList,texture_map,filePath,game,LevelNo);
			setObjectTileXY(game, LevelInfo, objList);
			setDoorBits(LevelInfo,objList);
			setPatchBits(LevelInfo,objList);
			setElevatorBits(LevelInfo,objList);
			setTerrainChangeBits(LevelInfo,objList);
			setKeyCount(game, LevelInfo, objList);
			PrintUWObjects(objList);	//Since I can't get full debug info until I have TileX/Y set.
			CleanUp(LevelInfo,game); //Get rid of unneeded tiles.
			MergeWaterRegions(LevelInfo);
			break; 
			}
		case UW2:		//Underworld 2
			{
			filePath = UW2_LEVEL_PATH;	//"C:\\Games\\Ultima\\UW2\\DATA\\lev.ark";
			if (BuildTileMapUW(LevelInfo,objList,texture_map,filePath,game,LevelNo) == -1) {return;};
			BuildObjectListUW(LevelInfo,objList,texture_map,filePath,game,LevelNo);
			setObjectTileXY(game, LevelInfo, objList);
			setDoorBits(LevelInfo,objList);
			setPatchBits(LevelInfo,objList);
			setElevatorBits(LevelInfo,objList);
			setTerrainChangeBits(LevelInfo,objList);
			setKeyCount(game, LevelInfo, objList);
			PrintUWObjects(objList);	//Since I can't get full debug info until I have TileX/Y set.
			CleanUp(LevelInfo,game); //Get rid of unneeded tiles.
			MergeWaterRegions(LevelInfo);
			break;			
			}
		case SHOCK:		//system shock
			{
			filePath = SHOCK_LEVEL_PATH;	//"C:\\Games\\SystemShock\\Res\\DATA\\archive.dat";
			BuildTileMapShock(LevelInfo, objList,texture_map_shock,filePath,game,LevelNo);
			BuildObjectListShock(LevelInfo, objList,texture_map,filePath,game,LevelNo);
			SetDeathWatch(objList);
			setDoorBits(LevelInfo,objList);
			setKeyCount(game, LevelInfo, objList);
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
			fclose (MAPFILE) ;
			break;
			}
		case SCRIPT_BUILD_MODE:
			{
			if (game !=SHOCK)
				{
				buildScriptsUW(game,LevelInfo,objList,LevelNo);
				}
			else	
				{
				BuildScriptsShock(game,LevelInfo,objList,LevelNo);
				}
			 break;
			}
		}
	}
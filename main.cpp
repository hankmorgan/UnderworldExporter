#include <stdio.h>
#include <stdlib.h>
#include <fstream>
#include <math.h>
#include <string.h>

#include "utils.h"
#include "textures.h"
#include "gameobjects.h"
#include "tilemap.h"
#include "d3darkmod.h"
#include "SourceEngine.h"
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
int game=-1;
int mode=-1;
//int game = SHOCK;
//int game = UWDEMO;
//int game = UW1;
//int game = UW2;
//int mode = D3_MODE;
//int mode = ASCII_MODE;
//int mode = STRINGS_EXTRACT_MODE;
//int mode = BITMAP_EXTRACT_MODE;
//int mode = SCRIPT_BUILD_MODE;
//int mode = MATERIALS_BUILD_MODE;
//int mode = CONVERSATION_MODE;
//int mode = REPACK_MODE;
//int mode= SOURCE_MODE;

levelNo = 0;
printf("Welcome to Underworld Exporter.\n");
	printf("\nAvailable games\n");
	printf("0) Ultima Underworld Demo (probably doesn't work!)\n");
	printf("1) Ultima Underworld 1: The Stygian Abyss\n");
	printf("2) Ultima Underworld 2: The Labyrinth of Worlds\n");
	printf("3) System Shock 1\n");
	printf("Please select a game.\n>");
	scanf("%d",&game);
	if ((game < UWDEMO) || (game > SHOCK))
		{
		printf("Invalid input. Bye.");
		return 0;
		}

printf("Available Modes.\n");
printf("%d) Ascii dump.\n",ASCII_MODE);
printf("%d) IDTech/DarkMod export.\n",D3_MODE);
printf("%d) String Extraction\n",STRINGS_EXTRACT_MODE);
printf("%d) Bitmap Extraction\n",BITMAP_EXTRACT_MODE);
printf("%d) Script build(Also runs as part of IDTech export)\n",SCRIPT_BUILD_MODE);
printf("%d) Support Materials Builder\n",MATERIALS_BUILD_MODE);
printf("%d) Conversation code dump (unfinished!)\n",CONVERSATION_MODE);
printf("%d) Repacker mode (UW2 and Shock only. Use at own risk!)\n",REPACK_MODE);
printf("%d) Source Engine export.\n",SOURCE_MODE);
printf("Please select a mode.\n>");
scanf("%d", &mode);
if ((mode < 0) || (mode > 8))
{
	printf("Invalid input. Bye.");
	return 0;
}

switch (mode)
{
case ASCII_MODE:
case D3_MODE:
case SOURCE_MODE:
case SCRIPT_BUILD_MODE:
	{
	switch (game)
		{
			case UWDEMO:
				levelNo = 0;	//only possible value
				break;
			case UW1://Print list of UW1 levels.
				printf("\nPick a level\n");
				printf("0)Entrance level.\n");
				printf("1)Domain of the Mountainmen.\n");
				printf("2)The Swamp and Lizardmen.\n");
				printf("3)Trolls and Knights.\n");
				printf("4)Catacombs and banquet halls.\n");
				printf("5)The Seers.\n");
				printf("6)Tybals Lair.\n");
				printf("7)The Volcano.\n");
				printf("8)Ethereal Void.\n");
				printf(">");
				scanf("%d", &levelNo);
				if ((levelNo < 0) || (levelNo > 9))
					{
					printf("Invalid input. Bye.");
					return 0;
					}
				break;
			case UW2:
				printf("\nPick a level\n");
				printf("0 - 4 Britannia\n");
				printf("8 - 15 Prison Tower\n");
				printf("16 - 17 Killorn Keep\n");
				printf("24 - 25 Ice Cavern\n");
				printf("32 - 33 Talorus\n");
				printf("40 - 47 Academy\n");
				printf("48 - 51 Tomb\n");
				printf("56 - 58 Pits\n");
				printf("64 - 72 Void (65 is stickman level)\n");
				printf(">");
				scanf("%d", &levelNo);
				if (!(
					((levelNo >= 0) && (levelNo <= 4))
					|| ((levelNo >= 8) && (levelNo <= 15))
					|| ((levelNo >= 16) && (levelNo <= 17))
					|| ((levelNo >= 24) && (levelNo <= 25))
					|| ((levelNo >= 32) && (levelNo <= 33))
					|| ((levelNo >= 40) && (levelNo <= 47))
					|| ((levelNo >= 48) && (levelNo <= 51))
					|| ((levelNo >= 56) && (levelNo <= 58))
					|| ((levelNo >= 64) && (levelNo <= 72))
					))
					{
					printf("Invalid input. Bye.");
					return 0;
					}
				break;
			case SHOCK:
				printf("\nPick a level (need to dblchk these)\n");
				printf("0)Reactor\n");
				printf("1)Med SCI\n");
				printf("2)Research\n");
				printf("3)Maintenance\n");
				printf("4)Storage\n");
				printf("5)Flight Deck\n");
				printf("6)Executive\n");
				printf("7)System Engineering\n");
				printf("8)Security\n");
				printf("9)Bridge\n");
				printf("10)Cyberspace 1 (Shodan)\n");
				printf("11)Grove 1\n");
				printf("12)Grove 1\n");
				printf("13)Grove 1\n");
				printf("14)Cyberspace 2\n");
				printf("15)Cyberspace 3\n");
				printf(">");
				scanf("%d", &levelNo);
				if ((levelNo < 0) || (levelNo > 15))
					{
					printf("Invalid input. Bye.");
					return 0;
					}
				break;
				}
		}
	}

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

	LoadConfig(game,mode);
	
	switch (mode)
		{
		case D3_MODE:
		case ASCII_MODE:
		case SCRIPT_BUILD_MODE:
		case SOURCE_MODE:
			//for (levelNo = 0; levelNo < 80; levelNo++)
			//{
				printf("\n============================Level %d=========================\n", levelNo);
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
			extractTextureBitmap(-1, GRAPHICS_FILE, GRAPHICS_PAL_FILE, 0, 32, UW_GRAPHICS_GR);
			//extractPanels(-1, GRAPHICS_FILE, GRAPHICS_PAL_FILE, 0, 64, UW_GRAPHICS_GR,game);
			//extractCritters( UW1_CRITTER_ASSOC, GRAPHICS_PAL_FILE, 0, 64, UW_GRAPHICS_GR,UW1,0);
			break;
		case MATERIALS_BUILD_MODE:
			//BuildXDataFile(game);
			//BuildSndShaderFiles();
			//BuildShockMtrFiles(3);
			//BuildUWMtrFiles(game,2);
			//BuildUWXData(game, 8);
			//BuildGuiFiles();
			//ExportModelFormat();
			//BuildWORDSXData(game);
			BuildUWParticles();
			break;
		case CONVERSATION_MODE:
			ExtractConversations(UW1);
			break;
		case REPACK_MODE:
			if (game==UW2)
				{
				RepackUW2();
				}
			else
			{
				if (game == SHOCK)
				{
					RepackShock();
				}
			}
			break;
		}
	}



void LoadConfig(int game,int mode)
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
char objSound[80];
char objParticle[80];
char objBase[80];
char invIcon[80];
int objType;
int hasPart;
int hasSound;
int isSolid;
int isMoveable;
int isInventory;


int objClass; int objSubClass; int objSubClassIndex;	//Shock object classes

char line[255];
textureMasters =new texture[300];
objectMasters=new objectMaster[1025];
switch (game)
	{
	case UWDEMO:
	case UW1:
		if (mode != SOURCE_MODE)
		{
			strcpy_s(filePathT, UW1_TEXTURE_CONFIG_FILE);
		}
		else
		{
			strcpy_s(filePathT, UW1_TEXTURE_CONFIG_FILE_SOURCE);
		}	
		break;
	case UW2:
		if (mode != SOURCE_MODE)
		{
			strcpy_s(filePathT, UW2_TEXTURE_CONFIG_FILE);
		}
		else
		{
			strcpy_s(filePathT, UW2_TEXTURE_CONFIG_FILE_SOURCE);
		}	
		break;
	case SHOCK:
		if (mode!=SOURCE_MODE) 
			{
			strcpy_s(filePathT, SHOCK_TEXTURE_CONFIG_FILE);
			}
		else
			{
			strcpy_s(filePathT, SHOCK_TEXTURE_CONFIG_FILE_SOURCE);
			}
		break;
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
				while (fgets(line,255,f))
					{
					sscanf(line, "%d %d %d %d %s %d %s %s %d %s %d %s %s %d %d %d %s",
						&objNo, &objClass, &objSubClass, &objSubClassIndex, &objCat, &objType,
						&objDesc, &objPath, &hasPart, &objParticle, &hasSound, &objSound, &objBase, &isSolid, &isMoveable, &isInventory, &invIcon);
					objectMasters[objNo].index=objNo;
					objectMasters[objNo].isSet=1;
					objectMasters[objNo].objClass = objClass;
					objectMasters[objNo].objSubClass = objSubClass;
					objectMasters[objNo].objSubClassIndex = objSubClassIndex;	
					
									
					strcpy_s(objectMasters[objNo].desc, objDesc);
					strcpy_s(objectMasters[objNo].path , objPath);
					strcpy_s(objectMasters[objNo].particle, objParticle);
					strcpy_s(objectMasters[objNo].sound, objSound);
					strcpy_s(objectMasters[objNo].base , objBase);
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
					objectMasters[objNo].hasParticle=hasPart;
					objectMasters[objNo].hasSound=hasSound;
					objectMasters[objNo].isSolid = isSolid;
					objectMasters[objNo].isMoveable=isMoveable;
					objectMasters[objNo].isInventory =isInventory;
					strcpy_s(objectMasters[objNo].InvIcon,invIcon);
					
					//printf("uw1_object_%03d.prt\n",objNo);
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
	int roomIndex=1; 

	char *filePath;
	if ((mode == D3_MODE))
		{
		if (fopen_s(&MAPFILE,MAP_OUTPUT_FILE, "w")!=0)
			{
			printf("Unable to create output file for map");
			return;
			}
		}
	if ((mode == SOURCE_MODE))
	{
		if (fopen_s(&MAPFILE, MAP_OUTPUT_FILE_SOURCE, "w") != 0)
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
			setTileNeighbourCount(LevelInfo);
			BuildObjectListUW(LevelInfo,objList,texture_map,filePath,game,LevelNo);
			setObjectTileXY(game,LevelInfo,objList);
			setDoorBits(LevelInfo,objList);
			setCorridors(LevelInfo, &roomIndex);
			setRooms(LevelInfo, &roomIndex);
			setPatchBits(LevelInfo,objList);
			setElevatorBits(LevelInfo,objList);
			setTerrainChangeBits(LevelInfo,objList);
			setKeyCount(game, LevelInfo, objList);
			PrintUWObjects(objList);	//Since I can't get full debug info until I have TileX/Y set.
			MergeWaterRegions(LevelInfo);
			//			
			break; 			
			}
		case UW1:		//Underworld 1
			{
			filePath = UW1_LEVEL_PATH ;	// "C:\\Games\\Ultima\\UW1\\DATA\\lev.ark";
			BuildTileMapUW(LevelInfo,objList, texture_map,filePath,game,LevelNo);
			setTileNeighbourCount(LevelInfo);
			BuildObjectListUW(LevelInfo,objList,texture_map,filePath,game,LevelNo);
			setObjectTileXY(game, LevelInfo, objList);
			setDoorBits(LevelInfo,objList);
			setCorridors(LevelInfo, &roomIndex);
			setRooms(LevelInfo,&roomIndex);
			setPatchBits(LevelInfo,objList);
			setElevatorBits(LevelInfo,objList);
			setTerrainChangeBits(LevelInfo,objList);
			SetBullFrog(LevelInfo,objList,LevelNo);
			setKeyCount(game, LevelInfo, objList);
			PrintUWObjects(objList);	//Since I can't get full debug info until I have TileX/Y set.
			//CleanUp(LevelInfo,game); //Get rid of unneeded tiles.
			MergeWaterRegions(LevelInfo);
			break; 
			}
		case UW2:		//Underworld 2
			{
			filePath = UW2_LEVEL_PATH;	//"C:\\Games\\Ultima\\UW2\\DATA\\lev.ark";
			if (BuildTileMapUW(LevelInfo,objList,texture_map,filePath,game,LevelNo) == -1) {return;};
			setTileNeighbourCount(LevelInfo);
			BuildObjectListUW(LevelInfo,objList,texture_map,filePath,game,LevelNo);
			setObjectTileXY(game, LevelInfo, objList);
			setDoorBits(LevelInfo,objList);
			setCorridors(LevelInfo, &roomIndex);
			setRooms(LevelInfo, &roomIndex);
			setPatchBits(LevelInfo,objList);
			setElevatorBits(LevelInfo,objList);
			setTerrainChangeBits(LevelInfo,objList);
			setKeyCount(game, LevelInfo, objList);
			PrintUWObjects(objList);	//Since I can't get full debug info until I have TileX/Y set.
			//CleanUp(LevelInfo,game); //Get rid of unneeded tiles.
			MergeWaterRegions(LevelInfo);
			break;			
			}
		case SHOCK:		//system shock
			{
			filePath = SHOCK_LEVEL_PATH;	//"C:\\Games\\SystemShock\\Res\\DATA\\archive.dat";
			BuildTileMapShock(LevelInfo, objList,texture_map_shock,filePath,game,LevelNo);
			BuildObjectListShock(LevelInfo, objList,texture_map,filePath,game,LevelNo);
			SetDeathWatch(objList);
			setTileNeighbourCount(LevelInfo);
			setDoorBits(LevelInfo,objList);
			setCorridors(LevelInfo, &roomIndex);
			setRooms(LevelInfo, &roomIndex);
			setKeyCount(game, LevelInfo, objList);
			//CleanUp(LevelInfo,game); //Get rid of unneeded tiles.
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
			//break;
			}
		case SOURCE_MODE:	//Source engine
			{
			CleanUp(LevelInfo, game); //Get rid of unneeded tiles.
			RenderSourceEnginelLevel(LevelInfo, objList, game);
			fclose(MAPFILE);
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
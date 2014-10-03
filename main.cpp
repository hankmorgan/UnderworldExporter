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
#include "fbxExport.h"
#include "Unity.h"


using namespace std;

texture *textureMasters;
objectMaster *objectMasters;
FILE *MAPFILE;

extern int levelNo;
extern int GAME;

int main()
{
int game=-1;
int mode=-1;
int gamefile=-1;
int graphics_file_no=-1;
int graphics_mode;
int BitMapSize=32;
short panels = 0;//Panels.gr are a special case for extraction
char Graphics_File[255];
char Graphics_Pal[255];
char path_uw0[100];
char path_uw1[100];
char path_uw2[100];
char path_shock[100];
char TempOutFileName[255];
char auxPalPath[255];
char path_target_platform[100];
char OutFileName[255];
char GameFilePath[255];
char fileAssoc[255];
char fileCrit[255];
int critPal=0;
int bytark=0;
int BlocksToRepack=320;//UW2 blocks to repack
int useTGA=0;
FILE *f = NULL;
if ((f = fopen("gamepaths.txt", "r")) == NULL)
	{
	printf("Could not open specified file\n");
	return 0;
	}

fgets(path_uw0, 100, f);
int ln = strlen(path_uw0) - 1;
if (path_uw0[ln] == '\n')
path_uw0[ln] = '\0';

fgets(path_uw1, 100, f);
ln = strlen(path_uw1) - 1;
if (path_uw1[ln] == '\n')
path_uw1[ln] = '\0';

fgets(path_uw2, 100, f);
ln = strlen(path_uw2) - 1;
if (path_uw2[ln] == '\n')
path_uw2[ln] = '\0';

fgets(path_shock, 100, f);
ln = strlen(path_shock) - 1;
if (path_shock[ln] == '\n')
path_shock[ln] = '\0';

fgets(path_target_platform, 100, f);
ln = strlen(path_target_platform) - 1;
if (path_target_platform[ln] == '\n')
path_target_platform[ln] = '\0';

fclose(f);
const char *uw_game_files[7];
uw_game_files[0] = "Data\\lev.ark";
uw_game_files[1] = "Save0\\lev.ark";
uw_game_files[2] = "Save1\\lev.ark";
uw_game_files[3] = "Save2\\lev.ark";
uw_game_files[4] = "Save3\\lev.ark";
uw_game_files[5] = "Save4\\lev.ark";
uw_game_files[6] = "data\\byt.ark";	//UW2 ark files.

const char *shock_game_files[9];
shock_game_files[0] = "res\\Data\\archive.dat";
shock_game_files[1] = "res\\Data\\SAVGAM00.dat";
shock_game_files[2] = "res\\Data\\SAVGAM01.dat";
shock_game_files[3] = "res\\Data\\SAVGAM02.dat";
shock_game_files[4] = "res\\Data\\SAVGAM03.dat";
shock_game_files[5] = "res\\Data\\SAVGAM04.dat";
shock_game_files[6] = "res\\Data\\SAVGAM05.dat";
shock_game_files[7] = "res\\Data\\SAVGAM06.dat";
shock_game_files[8] = "res\\Data\\SAVGAM07.dat";



const char *uw1_graphics_file[45];
const char *uw2_graphics_file[45];
uw1_graphics_file[0] = "Data\\F16.tr";// - Floor textures 16x16");
uw1_graphics_file[1] = "Data\\F32.tr";// - Floor textures 32x32\n");
uw1_graphics_file[2] = "Data\\W16.tr";// - Wall textures 16x16");
uw1_graphics_file[3] = "Data\\W64.tr";// - Wall textures 64x64\n");
uw1_graphics_file[4] = "Data\\3DWIN.GR";
uw1_graphics_file[5] = "Data\\ANIMO.GR";
uw1_graphics_file[6] = "Data\\ARMOR_F.GR";
uw1_graphics_file[7] = "Data\\ARMOR_M.GR";
uw1_graphics_file[8] = "Data\\BODIES.GR";
uw1_graphics_file[9] = "Data\\BUTTONS.GR";
uw1_graphics_file[10] = "Data\\CHAINS.GR";
uw1_graphics_file[11] = "Data\\CHARHEAD.GR";
uw1_graphics_file[12] = "Data\\CHRBTNS.GR";
uw1_graphics_file[13] = "Data\\COMPASS.GR";
uw1_graphics_file[14] = "Data\\CONVERSE.GR";
uw1_graphics_file[15] = "Data\\CURSORS.GR";
uw1_graphics_file[16] = "Data\\DOORS.GR";
uw1_graphics_file[17] = "Data\\DRAGONS.GR";
uw1_graphics_file[18] = "Data\\EYES.GR";
uw1_graphics_file[19] = "Data\\FLASKS.GR";
uw1_graphics_file[20] = "Data\\GENHEAD.GR";
uw1_graphics_file[21] = "Data\\HEADS.GR";
uw1_graphics_file[22] = "Data\\INV.GR";
uw1_graphics_file[23] = "Data\\LFTI.GR";
uw1_graphics_file[24] = "Data\\OBJECTS.GR";
uw1_graphics_file[25] = "Data\\OPTBN";
uw1_graphics_file[26] = "Data\\OPTB";
uw1_graphics_file[27] = "Data\\OPTBNS";
uw1_graphics_file[28] = "Data\\PANELS.GR";
uw1_graphics_file[29] = "Data\\POWER.GR";
uw1_graphics_file[30] = "Data\\QUEST.GR";
uw1_graphics_file[31] = "Data\\SCRLEDGE.GR";
uw1_graphics_file[32] = "Data\\SPELLS.GR";
uw1_graphics_file[33] = "Data\\TMFLAT.GR";
uw1_graphics_file[34] = "Data\\TMOBJ.GR";
uw1_graphics_file[35] = "Data\\WEAPONS.GR";
uw1_graphics_file[36] = "Data\\BLNKMAP.BYT";
uw1_graphics_file[37] = "Data\\CHARGEN.BYT";
uw1_graphics_file[38] = "Data\\CONV.BYT";
uw1_graphics_file[39] = "Data\\MAIN.BYT";
uw1_graphics_file[40] = "Data\\OPSCR.BYT";
uw1_graphics_file[41] = "Data\\PRES1.BYT";
uw1_graphics_file[42] = "Data\\PRES2.BYT";
uw1_graphics_file[43] = "Data\\WIN1.BYT";
uw1_graphics_file[44] = "Data\\WIN2.BYT";

uw2_graphics_file[0] = "Data\\T64.tr";//uw2 textures
uw2_graphics_file[1] = "Data\\3DWIN.GR";
uw2_graphics_file[2] = "Data\\ANIMO.GR";
uw2_graphics_file[3] = "Data\\ARMOR_F.GR";
uw2_graphics_file[4] = "Data\\ARMOR_M.GR";
uw2_graphics_file[5] = "Data\\BODIES.GR";
uw2_graphics_file[6] = "Data\\BUTTONS.GR";
uw2_graphics_file[7] = "Data\\CHAINS.GR";
uw2_graphics_file[8] = "Data\\CHARHEAD.GR";
uw2_graphics_file[9] = "Data\\CHRBTNS.GR";
uw2_graphics_file[10] = "Data\\COMPASS.GR";
uw2_graphics_file[11] = "Data\\CONVERSE.GR";
uw2_graphics_file[12] = "Data\\CURSORS.GR";
uw2_graphics_file[13] = "Data\\DOORS.GR";
uw2_graphics_file[14] = "Data\\DRAGONS.GR";
uw2_graphics_file[15] = "Data\\EYES.GR";
uw2_graphics_file[16] = "Data\\FLASKS.GR";
uw2_graphics_file[17] = "Data\\GEMPT.GR";
uw2_graphics_file[18] = "Data\\GENHEAD.GR";
uw2_graphics_file[19] = "Data\\GHEAD.GR";
uw2_graphics_file[20] = "Data\\HEADS.GR";
uw2_graphics_file[21] = "Data\\INV.GR";
uw2_graphics_file[22] = "Data\\LFTI.GR";
uw2_graphics_file[23] = "Data\\OBJECTS.GR";
uw2_graphics_file[24] = "Data\\OPTBN";
uw2_graphics_file[25] = "Data\\OPTB";
uw2_graphics_file[26] = "Data\\OPTBNS";
uw2_graphics_file[27] = "Data\\PANELS.GR";
uw2_graphics_file[28] = "Data\\POWER.GR";
uw2_graphics_file[29] = "Data\\QUESTION.GR";
uw2_graphics_file[30] = "Data\\SCRLEDGE.GR";
uw2_graphics_file[31] = "Data\\SPELLS.GR";
uw2_graphics_file[32] = "Data\\TMFLAT.GR";
uw2_graphics_file[33] = "Data\\TMOBJ.GR";
uw2_graphics_file[34] = "Data\\VIEWS.GR";
uw2_graphics_file[35] = "Data\\WEAP.GR";
uw2_graphics_file[36] = "Data\\BYT.ARK";
uw2_graphics_file[37] = "Cuts\\LBACK000.BYT";
uw2_graphics_file[38] = "Cuts\\LBACK001.BYT";
uw2_graphics_file[39] = "Cuts\\LBACK002.BYT";
uw2_graphics_file[40] = "Cuts\\LBACK003.BYT";
uw2_graphics_file[41] = "Cuts\\LBACK004.BYT";
uw2_graphics_file[42] = "Cuts\\LBACK005.BYT";
uw2_graphics_file[43] = "Cuts\\LBACK006.BYT";
uw2_graphics_file[44] = "Cuts\\LBACK007.BYT";

const char *shock_graphics_file[18];
shock_graphics_file[0] = "RES\\DATA\\OBJART.RES";
shock_graphics_file[1] = "RES\\DATA\\OBJART2.RES";
shock_graphics_file[2] = "RES\\DATA\\OBJART3.RES";
shock_graphics_file[3] = "RES\\DATA\\CITMAT.RES";
shock_graphics_file[4] = "RES\\DATA\\GAMESCR.RES";
shock_graphics_file[5] = "RES\\DATA\\HANDART.RES";
shock_graphics_file[6] = "RES\\DATA\\MFDART.RES";
shock_graphics_file[7] = "RES\\DATA\\SIDEART.RES";
shock_graphics_file[8] = "RES\\DATA\\START1.RES";
shock_graphics_file[9] = "RES\\DATA\\SPLASH.RES";
shock_graphics_file[10] = "RES\\DATA\\TEXTURE.RES";
shock_graphics_file[11] = "RES\\DATA\\DEATH.RES";
shock_graphics_file[12] = "RES\\DATA\\INTRO.RES";
shock_graphics_file[13] = "RES\\DATA\\SVGADETH.RES";
shock_graphics_file[14] = "RES\\DATA\\SVGAEND.RES";
shock_graphics_file[15] = "RES\\DATA\\SVGAINTR.RES";
shock_graphics_file[16] = "RES\\DATA\\vidmail.RES";
shock_graphics_file[17] = "RES\\DATA\\WIN1.RES";

const char *shock_pal_file[3];
shock_pal_file[0] = "RES\\DATA\\gamepal.res";
shock_pal_file[1] = "RES\\DATA\\cutspal.res";
shock_pal_file[2] = "RES\\DATA\\splshpal.res";

const char *shock_cuts_file[3];
shock_cuts_file[0] = "RES\\DATA\\START1.RES";
shock_cuts_file[1] = "RES\\DATA\\DEATH.RES";
shock_cuts_file[2] = "RES\\DATA\\WIN1.RES";

levelNo = -1;
if (true)
	{
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
	printf("%d) Source Engine export\n",SOURCE_MODE);
	printf("%d) Critter Art Extract\n", CRITTER_EXTRACT_MODE);
	printf("%d) Cutscene Art Extract\n", CUTSCENE_EXTRACT_MODE);
	printf("%d) FBX Export\n", FBX_MODE);
	printf("%d) Unity script generation\n", UNITY_MODE);
	printf("Please select a mode.\n>");
	scanf("%d", &mode);
	if ((mode < 0) || (mode > 12))
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
	case REPACK_MODE:
    case FBX_MODE:
    case UNITY_MODE:
		{
		switch (game)
			{
			case UWDEMO:
				sprintf_s(GameFilePath, 255, "%s\\level13.st", path_uw0);
				break;
			case UW1:
			case UW2:
				printf("\nPick a level archive or save game to open\n");
				for (int i = 0; i < 6; i++)
					{
					printf("%d) %s\n",i,uw_game_files[i]);
					}
					if ((game==UW2) && (mode==REPACK_MODE))
						{
						printf("%d) %s\n",6,uw_game_files[6]);
						}				
				printf(">");
				scanf("%d", &gamefile);
				if ((gamefile < 0) || (gamefile >= 7))
					{
					printf("Invalid input. Bye.");
					return 0;
					}
				if(game==UW1)
					{
					sprintf_s(GameFilePath, 255, "%s\\%s", path_uw1, uw_game_files[gamefile]);
					}
				else
					{
					sprintf_s(GameFilePath, 255, "%s\\%s", path_uw2, uw_game_files[gamefile]);
					}
				break;
			case SHOCK:
				printf("\nPick a level archive or save game to open\n");
				for (int i = 0; i < 9; i++)
					{
					printf("%d) %s\n", i, shock_game_files[i]);
					}
				printf(">");
				scanf("%d", &gamefile);
				if ((gamefile < 0) || (gamefile >= 10))
					{
					printf("Invalid input. Bye.");
					return 0;
					}
					sprintf_s(GameFilePath, 255, "%s\\%s", path_shock, shock_game_files[gamefile]);
				break;
			}
		if (mode !=REPACK_MODE)
		{
		switch (game)
			{
				case UWDEMO:
					levelNo = 0;	//only possible value
					break;
				case UW1://Print list of UW1 levels.
					printf("\nPick a level.\n");
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
			printf("Enter a filename for output (%s\\[filename].map)\n>", path_target_platform);
			
			scanf("%s", TempOutFileName);
			sprintf_s(OutFileName, 255, "%s\\%s", path_target_platform, TempOutFileName);
			}
		else
			{
			switch (game)
				{
					case UW2:
					printf("Enter a filename for repacking into (%s\\data\\[filename].ark)\n>", path_uw2);
					scanf("%s", TempOutFileName);
					sprintf_s(OutFileName, 255, "%s\\data\\%s.ark", path_uw2, TempOutFileName);
					break;
				case SHOCK:
					printf("Enter a filename for repacking into (%s\\[filename].data)\n>", path_shock);
					scanf("%s", TempOutFileName);
					sprintf_s(OutFileName, 255, "%s\\res\\data\\%s.ark", path_shock, TempOutFileName);
					break;
				default:
					printf("\nInvalid game for repacking. Goodbye");
					return 0;
				}

			}
			
		break;
		}
	case BITMAP_EXTRACT_MODE:
		switch (game)
			{
			case UWDEMO:
				printf("\nCome back later...\n");
				return 0;
				break;
			case UW1:
				for (int i = 0; i < 45; i++)
					{
					printf("%d) %s",i, uw1_graphics_file[i]);
					if (i % 2 == 0)
						{
						printf("\t\t");
						}
					else
						{
						printf("\n");
						}
					}
				printf("\nPick a file\n>");
				scanf("%d", &graphics_file_no);
				if ((graphics_file_no < 0) || (graphics_file_no > 44))
					{
					printf("Invalid input. Bye.");
					return 0;
					}
				sprintf_s(Graphics_File, 255, "%s\\%s", path_uw1, uw1_graphics_file[graphics_file_no]);
				sprintf_s(Graphics_Pal, 255, "%s\\data\\pals.dat", path_uw1);
				sprintf_s(auxPalPath, 255, "%s\\%s", path_uw1, AUXILARY_PAL_FILE);
				if (graphics_file_no <= 3)
					{
					graphics_mode = UW_GRAPHICS_TEXTURES;
					switch (graphics_file_no)
						{
							case 0:
								BitMapSize=16; break;
							case 1:
								BitMapSize = 32; break;
							case 2:
								BitMapSize = 16; break;
							case 3:
								BitMapSize = 64; break;
						}
					}
				else if (graphics_file_no <= 35)
					{
					if (graphics_file_no == 28)//Panels
						{
						panels=1;
						}
					graphics_mode = UW_GRAPHICS_GR;
					}
				else
					{
					graphics_mode = UW_GRAPHICS_BITMAPS;
					}
				break;
			case UW2:
				for (int i = 0; i < 45; i++)
					{
					printf("%d) %s", i, uw2_graphics_file[i]);
					if (i % 2 == 0)
						{
						printf("\t\t");
						}
					else
						{
						printf("\n");
						}
					}
				printf("\nPick a file\n>");
				scanf("%d", &graphics_file_no);
				if ((graphics_file_no < 0) || (graphics_file_no > 45))
					{
					printf("Invalid input. Bye.");
					return 0;
					}
				if (graphics_file_no == 36)
					{//UW2 Byt ark
					bytark=1;
					}
				sprintf_s(Graphics_File, 255, "%s\\%s", path_uw2, uw2_graphics_file[graphics_file_no]);
				sprintf_s(Graphics_Pal, 255, "%s\\data\\pals.dat", path_uw2);
				sprintf_s(auxPalPath, 255, "%s\\%s", path_uw2, AUXILARY_PAL_FILE);

				if (graphics_file_no <= 0)
					{//only on texture file in uw2
					graphics_mode = UW_GRAPHICS_TEXTURES;
					BitMapSize = 64;
					}
					else if (graphics_file_no>=37)
						{//Byt files in cuts dir
						graphics_mode=UW_GRAPHICS_BITMAPS;
						}
					else 
						{
						graphics_mode = UW_GRAPHICS_GR;
						if (graphics_file_no == 28)//Panels
							{
							panels = 1;//special case due to file headers
							}
						
						}
				break;
			case SHOCK:
				for (int i = 0; i < 18; i++)
					{
					printf("%d) %s",i, shock_graphics_file[i]);
					if (i % 2 == 0)
						{
						printf("\t\t");
						}
					else
						{
						printf("\n");
						}
					}
				printf("\nPick a file\n>");
				scanf("%d", &graphics_file_no);
				if ((graphics_file_no < 0) || (graphics_file_no > 18))
					{
					printf("Invalid input. Bye.");
					return 0;
					}									
				sprintf_s(Graphics_File, 255, "%s\\%s", path_shock, shock_graphics_file[graphics_file_no]);
				for (int i = 0; i < 3; i++)
					{
					printf("%d) %s\n",i, shock_pal_file[i]);
					}
				printf("\nPick a file\n>");
				scanf("%d", &graphics_file_no);
				if ((graphics_file_no < 0) || (graphics_file_no > 3))
					{
					printf("Invalid input. Bye.");
					return 0;
					}	
				sprintf_s(Graphics_Pal, 255, "%s\\%s", path_shock, shock_pal_file[graphics_file_no]);
				//return 0;
			}
		printf("\nEnter a palette number to use.(Typically 0 to 7)\n>");
		scanf("%d", &critPal);
		printf("\nEnter a file format to use.\n0) BMP\n1) TGA\n>");
		scanf("%d", &useTGA);
		if (useTGA==1)
			{
			printf("Enter a filename for output ([filename]_###.tga)\n>");
			}
		else
			{
			printf("Enter a filename for output ([filename]_###.bmp)\n>");
			}
		scanf("%s", OutFileName);
		break;
		case STRINGS_EXTRACT_MODE:
			switch (game)
				{
				case UWDEMO:
					sprintf_s(GameFilePath, 255, "%s\\%s", path_uw0, UW1_STRINGS_FILE);
					break;
				case UW1:
					sprintf_s(GameFilePath, 255, "%s\\%s", path_uw1, UW1_STRINGS_FILE);
					break;
				case UW2:
					sprintf_s(GameFilePath, 255, "%s\\%s", path_uw2, UW2_STRINGS_FILE);
					break;
				case SHOCK:
					sprintf_s(GameFilePath, 255, "%s\\%s", path_shock, SHOCK_STRINGS_FILE);
					break;
				}
			break;
		case MATERIALS_BUILD_MODE:
			break;
		case CRITTER_EXTRACT_MODE:
			if (game == SHOCK)
				{
				printf("\nI don't have a graphics extractor for System Shock as part of this program. You'll have to find one yourself.\n");
				return 0;
				}
			printf("\nType a critter filename for extraction from. gamepath\crit\\[filename]\n");
			scanf("%s",TempOutFileName);
			switch (game)
				{
				case UWDEMO:
					sprintf_s(fileCrit, 255, "%s\\crit\\%s", path_uw0, TempOutFileName);
					sprintf_s(fileAssoc, 255, "%s\\%s", path_uw0, UW1_CRITTER_ASSOC);
					sprintf_s(Graphics_Pal, 255, "%s\\data\\pals.dat", path_uw0);
					sprintf_s(auxPalPath, 255, "%s\\%s", path_uw0, AUXILARY_PAL_FILE);
					break;
				case UW1:
					sprintf_s(fileCrit, 255, "%s\\crit\\%s", path_uw1, TempOutFileName);
					sprintf_s(fileAssoc, 255, "%s\\%s", path_uw1, UW1_CRITTER_ASSOC);
					sprintf_s(Graphics_Pal, 255, "%s\\data\\pals.dat", path_uw1);
					sprintf_s(auxPalPath, 255, "%s\\%s", path_uw1, AUXILARY_PAL_FILE);
					break;
				case UW2:
					sprintf_s(fileCrit, 255, "%s\\crit\\%s", path_uw2, TempOutFileName);
					sprintf_s(fileAssoc, 255, "%s\\%s", path_uw2, UW2_CRITTER_ASSOC);
					sprintf_s(Graphics_Pal, 255, "%s\\data\\pals.dat", path_uw2);
					sprintf_s(auxPalPath, 255, "%s\\%s", path_uw2, AUXILARY_PAL_FILE);
					break;
				}
			printf("\nEnter a palette number to use.(0 to 3)\n>");
			scanf("%d", &critPal);
			printf("\nEnter a file format to use.\n0) BMP\n1) TGA\n>");
			scanf("%d", &useTGA);
			if (useTGA==1)
				{
				printf("Enter a filename for output ([filename]_###.tga)\n>");
				}
			else
				{
				printf("Enter a filename for output ([filename]_###.bmp)\n>");
				}		
			scanf("%s", OutFileName);
			break;
		case CUTSCENE_EXTRACT_MODE:
			if (game == SHOCK)
				{
				for (int i = 0; i < 3; i++)
					{
					printf("%d) %s",i, shock_cuts_file[i]);
					if (i % 2 == 0)
						{
						printf("\t\t");
						}
					else
						{
						printf("\n");
						}
					}
				printf("\nPick a file\n>");
				scanf("%d", &graphics_file_no);
				if ((graphics_file_no < 0) || (graphics_file_no > 3))
					{
					printf("Invalid input. Bye.");
					return 0;
					}									
				sprintf_s(Graphics_File, 255, "%s\\%s", path_shock, shock_cuts_file[graphics_file_no]);
				for (int i = 0; i < 3; i++)
					{
					printf("%d) %s\n",i, shock_pal_file[i]);
					}
				printf("\nPick a file\n>");
				scanf("%d", &graphics_file_no);
				if ((graphics_file_no < 0) || (graphics_file_no > 3))
					{
					printf("Invalid input. Bye.");
					return 0;
					}	
				sprintf_s(Graphics_Pal, 255, "%s\\%s", path_shock, shock_pal_file[graphics_file_no]);
				}
			else
				{
				printf("\nType a cutscene filename for extraction from. gamedata\\cuts\\[filename]\n");
				scanf("%s", TempOutFileName);
				switch (game)
					{
						case UWDEMO:
							sprintf_s(Graphics_File, 255, "%s\\cuts\\%s", path_uw0, TempOutFileName);
							break;
						case UW1:
							sprintf_s(Graphics_File, 255, "%s\\cuts\\%s", path_uw1, TempOutFileName);
							break;
						case UW2:
							sprintf_s(Graphics_File, 255, "%s\\cuts\\%s", path_uw2, TempOutFileName);
							break;
					}
				}
				//printf("\nEnter a file format to use.\n0) BMP\n1) TGA\n>");
				//scanf("%d", &useTGA);
				if (useTGA==1)
					{
					printf("Enter a filename for output ([filename]_###.tga)\n>");
					}
				else
					{
					printf("Enter a filename for output ([filename]_###.bmp)\n>");
					}	
				scanf("%s", OutFileName);
			break;
		case CONVERSATION_MODE:
			break;
		}
	}
	else
		{
		printf("commandline args processing eventually");
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

	LoadConfig(game,mode);
	
	switch (mode)
		{
		case D3_MODE:
		case ASCII_MODE:
		case SCRIPT_BUILD_MODE:
		case SOURCE_MODE:
		case FBX_MODE:
		case UNITY_MODE:
			printf("\n============================Level %d=========================\n", levelNo);
			exportMaps(game, mode, levelNo, OutFileName,GameFilePath);
			break;
		case STRINGS_EXTRACT_MODE:
			if (game == SHOCK)
				{
				unpackStringsShock(GameFilePath);
				}
			else
				{
				unpackStrings(game,GameFilePath);
				}
			break;
		case BITMAP_EXTRACT_MODE:
			if (game != SHOCK)
				{
				if (panels==0)
					{
					if (bytark!=1)
						{
						extractTextureBitmap(-1, Graphics_File, Graphics_Pal, critPal, BitMapSize, graphics_mode, OutFileName,auxPalPath,useTGA);
						}
					else
						{
						extractUW2Bitmaps(Graphics_File,Graphics_Pal,critPal,OutFileName,useTGA);
						}
					}
				else
					{
					extractPanels(-1, Graphics_File, Graphics_Pal, 0, BitMapSize, UW_GRAPHICS_GR, game,OutFileName,useTGA);
					}
				}
			else
				{
				ExtractShockGraphics( Graphics_File, Graphics_Pal,critPal,OutFileName,useTGA);
				}
			break;
		case CRITTER_EXTRACT_MODE:
			extractCritters(fileAssoc, fileCrit, Graphics_Pal, critPal, 64, UW_GRAPHICS_GR,game, 0, OutFileName,useTGA);
			break;
		case CUTSCENE_EXTRACT_MODE:
			if (game == SHOCK)
				{
				ExtractShockCutscenes( Graphics_File, Graphics_Pal,critPal,OutFileName,0);//Bitmap only so far
				}
			else
				{
				load_cuts_anim(Graphics_File, OutFileName,useTGA);
				}
			break;
		case MATERIALS_BUILD_MODE:
			//BuildSHOCKMtrFiles(0);
			//BuildXDataFile(game);
			//BuildSndShaderFiles();
			//BuildShockMtrFiles(3);
			//BuildUWMtrFiles(game,2);
			//BuildUWXData(game, 8);
			//BuildGuiFiles();
			//ExportModelFormat();
			//BuildWORDSXData(game);
			BuildParticles(game);
			printf("Materials builder turned off at the moment.");
			break;
		case CONVERSATION_MODE:
			ExtractConversations(UW1);
			break;
		case REPACK_MODE:
			if (game==UW2)
				{
				RepackUW2(GameFilePath,OutFileName,BlocksToRepack);
				}
			else
				{
				if (game == SHOCK)
					{//C:\Games\Terra Nova\CD\Terra_Nova\MAPS
					RepackShock(GameFilePath, OutFileName);
					//RepackShock("C:\\Games\\Terra Nova\\CD\\Terra_Nova\\MAPS\\FLAT.RES", OutFileName);
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


void exportMaps(int game,int mode,int LevelNo, char OutFileName[255], char filePath[255])
{
	ObjectItem objList[1600];
	//shockObjectItem shockobjList[1600];
	long texture_map[256]; 
	long texture_map_shock[272];
	int roomIndex=1; 
	char Map_Output_File[255];
	char Script_Output_File[255];
	//char *filePath;
	
	if ((mode == D3_MODE))
		{
		sprintf_s(Map_Output_File, 255, "%s.map", OutFileName);
		if (fopen_s(&MAPFILE, Map_Output_File, "w") != 0)
			{
			printf("Unable to create output file for map");
			return;
			}
		}
	if ((mode == SOURCE_MODE))
	{
	sprintf_s(Map_Output_File, 255, "%s.vmf", OutFileName);
	if (fopen_s(&MAPFILE, Map_Output_File, "w") != 0)
		{
			printf("Unable to create output file for map");
			return;
		}
	}
	switch (game)
		{
		case UWDEMO:		//Underworld Demo
			{
			//filePath = UW0_LEVEL_PATH ;	//"C:\\Games\\Ultima\\UWDemo\\DATA\\level13.st";
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
			//filePath = UW1_LEVEL_PATH ;	// "C:\\Games\\Ultima\\UW1\\DATA\\lev.ark";
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
			//filePath = UW2_LEVEL_PATH;	//"C:\\Games\\Ultima\\UW2\\DATA\\lev.ark";
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
			//filePath = SHOCK_LEVEL_PATH;	//"C:\\Games\\SystemShock\\Res\\DATA\\archive.dat";
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
			sprintf_s(Script_Output_File, 255, "%s.script", OutFileName);
			if (game !=SHOCK)
				{
				buildScriptsUW(game, LevelInfo, objList, LevelNo, Script_Output_File);
				}
			else	
				{
				BuildScriptsShock(game, LevelInfo, objList, LevelNo, Script_Output_File);
				}
			 break;
			}
		case FBX_MODE:
			CleanUp(LevelInfo, game); //Get rid of unneeded tiles.
			RenderFBXLevel(LevelInfo,objList,game);
			break;
		case UNITY_MODE:
			RenderUnityObjectList(game,LevelNo,LevelInfo,objList);
			break;
		}
	}
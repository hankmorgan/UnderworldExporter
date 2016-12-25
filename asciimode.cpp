/*
UNDERWORLD EXPORTER
asciimode.cpp

Functions for printing out usefull information, tilemaps and object lists.

*/
#include <stdio.h>
#include <stdlib.h>
#include <fstream>

#include "main.h"
#include "gameobjects.h"
#include "tilemap.h"
//#include "scripting.h"
#include "asciimode.h"
#include "utils.h"
#include "textures.h"

FILE *LOGFILE;

long printObject(ObjectItem &currObj, int TableFormat)
	{
	/*
	Outputs some debug info on an object.
	Returns the index to next object in the chain
	*/
	int value = (((currObj.owner & 0x7) << 3) | (currObj.y));	//for check variables
	if (objectMasters[currObj.item_id].isSet == 1)
		{
		if (TableFormat == 0)
			{
			fprintf(LOGFILE,"Index:%d,Type:%d(%s),TileX=%d,TileY=%d,x=%d,y=%d,z=%d,heading=%d,qual=%d,owner=%d,link=%d,flags=%d,val=%d,angle=(%d,%d,%d)"
				, currObj.index, currObj.item_id, objectMasters[currObj.item_id].desc,
				currObj.tileX, currObj.tileY,
				currObj.x, currObj.y, currObj.zpos
				, currObj.heading, currObj.quality, currObj.owner, currObj.link, currObj.flags, value, currObj.Angle1, currObj.Angle2, currObj.Angle3);

			}
		else
			{//Tab delimited.
			fprintf(LOGFILE,"%d\t%d\t%20s\t%d\t%d\t%d\t%d\t%d\t%d\t%d\t%d\t%d\t%d\t%d\t%d\t%d\t%d"
				, currObj.index, currObj.item_id, objectMasters[currObj.item_id].desc,
				currObj.tileX, currObj.tileY,
				currObj.x, currObj.y, currObj.zpos
				, currObj.heading, currObj.quality, currObj.owner, currObj.link, currObj.flags, value, currObj.Angle1, currObj.Angle2, currObj.Angle3);

			}
		//fprintf(LOGFILE,"[id=%d Type=%d(%.20s)(%d,%d,%d)%ddeg qual=%d link(q)=%d owner(s)=%d flags=%d isquant=%d]",currObj.index,currObj.item_id,objectMasters[currObj.item_id].desc,currObj.x ,currObj.y,currObj.zpos, currObj.heading ,currObj.quality,currObj.link,currObj.owner,currObj.flags,currObj.is_quant );
		}
	return currObj.next;
	}

long printObject(ObjectItem &currObj)
	{
	/*
	Prints the specified object and returns it's next object.
	*/
	//fprintf(LOGFILE,"Index:%d,%s-",currObj.index, objectMasters[currObj.item_id].desc);
	fprintf(LOGFILE,"%s", UniqueObjectName(currObj));
	return currObj.next;
	}

void RenderAsciiTile(tile &t)	//,int x, int y, int BlockStart,unsigned char *buffer
	{
	/*
	Picks which ascii character is printed for a particular tile type.
	*/

	switch (t.tileType)
		{
			case TILE_SOLID:
				{//solid	
				if (t.Render == 1)
					{
					fprintf(LOGFILE,"#");
					}
				else
					{
					fprintf(LOGFILE,"*");
					}
				return;
				}
			case TILE_OPEN:
				{//open
				if (t.Render == 1)
					{
					fprintf(LOGFILE,".");
					}
				else
					{
					fprintf(LOGFILE,".");
					}
				return;
				}
			case TILE_DIAG_SE:
				{//diag se
				if (t.Render == 1)
					{
					fprintf(LOGFILE,"/");
					}
				else
					{
					fprintf(LOGFILE," ");
					}
				return;
				}
			case TILE_DIAG_SW:
				{//diag sw
				if (t.Render == 1)
					{
					fprintf(LOGFILE,"\\");
					}
				else
					{
					fprintf(LOGFILE," ");
					}
				return;
				}
			case TILE_DIAG_NE:
				{//diag ne
				if (t.Render == 1)
					{
					fprintf(LOGFILE,"\\");
					}
				else
					{
					fprintf(LOGFILE," ");
					}
				return;
				}
			case TILE_DIAG_NW:
				{//diag nw
				if (t.Render == 1)
					{
					fprintf(LOGFILE,"/");
					}
				else
					{
					fprintf(LOGFILE," ");
					}
				return;
				}
			case TILE_SLOPE_N:
				{//slope n
				if (t.Render == 1)
					{
					fprintf(LOGFILE,"n");
					}
				else
					{
					fprintf(LOGFILE," ");
					}
				return;
				}
			case TILE_SLOPE_S:
				{//slope s
				if (t.Render == 1)
					{
					fprintf(LOGFILE,"x");
					}
				else
					{
					fprintf(LOGFILE," ");
					}
				return;
				}
			case TILE_SLOPE_E:
				{//slope e
				if (t.Render == 1)
					{
					fprintf(LOGFILE,"e");
					}
				else
					{
					fprintf(LOGFILE," ");
					}
				return;
				}
			case TILE_SLOPE_W:
				{//slopew
				if (t.Render == 1)
					{
					fprintf(LOGFILE,"w");
					}
				else
					{
					fprintf(LOGFILE," ");
					}
				return;
				}

			case TILE_VALLEY_NW:
				{//nw valley
				if (t.Render == 1)
					{
					fprintf(LOGFILE,"a");
					}
				else
					{
					fprintf(LOGFILE," ");
					}
				return;
				}
			case TILE_VALLEY_NE:
				{//ne valley
				if (t.Render == 1)
					{
					fprintf(LOGFILE,"b");
					}
				else
					{
					fprintf(LOGFILE," ");
					}
				return;
				}
			case TILE_VALLEY_SE:
				{//se valley
				if (t.Render == 1)
					{
					fprintf(LOGFILE,"c");
					}
				else
					{
					fprintf(LOGFILE," ");
					}
				return;
				}
			case TILE_VALLEY_SW:
				{//sw valley
				if (t.Render == 1)
					{
					fprintf(LOGFILE,"d");
					}
				else
					{
					fprintf(LOGFILE," ");
					}
				return;
				}

			case TILE_RIDGE_SE:
				{//se ridge
				if (t.Render == 1)
					{
					fprintf(LOGFILE,"f");
					}
				else
					{
					fprintf(LOGFILE," ");
					}
				return;
				}
			case TILE_RIDGE_SW:
				{//sw ridge
				if (t.Render == 1)
					{
					fprintf(LOGFILE,"g");
					}
				else
					{
					fprintf(LOGFILE," ");
					}
				return;
				}
			case TILE_RIDGE_NW:
				{//nw ridge
				if (t.Render == 1)
					{
					fprintf(LOGFILE,"h");
					}
				else
					{
					fprintf(LOGFILE," ");
					}
				return;
				}
			case TILE_RIDGE_NE:
				{//ne ridge
				if (t.Render == 1)
					{
					fprintf(LOGFILE,"i");
					}
				else
					{
					fprintf(LOGFILE," ");
					}
				return;
				}


			default:
				{//Unknown tile type.
				if (t.Render == 1)
					{
					fprintf(LOGFILE,"?");
					}
				else
					{
					fprintf(LOGFILE,"?");
					}
				return;
				}
		}
	}

void DumpAscii(int game, tile LevelInfo[64][64], ObjectItem objList[1600], int LevelNo, int mapOnly)
	{
	/*
	Runs every ASCII report.
	Not every report applies to each game.
	*/

	printTileMap(LevelInfo, LevelNo);

	printNoMagicMap(LevelInfo,LevelNo);

	printFlagsMap(LevelInfo, LevelNo);
	if (mapOnly == 1) { return; }


	printFloorHeights(LevelInfo, LevelNo);

	printFloorTextures(LevelInfo, LevelNo);

	printWallTextures(LevelInfo, LevelNo);

	printDoorPositions(LevelInfo, objList, LevelNo);

	//printWaterRegions(LevelInfo,LevelNo);

	printNeighbourCounts(LevelInfo, LevelNo);

	printRoomRegions(LevelInfo, LevelNo);

	printRoomRegionsForNavmeshTagging(LevelInfo,objList, LevelNo);

	if (game == SHOCK)
		{
		printCeilingHeights(LevelInfo, LevelNo);

		printSlopeSteepness(LevelInfo, LevelNo);
		printSlopeFlags(LevelInfo, LevelNo);

		printAdjacentFlags(LevelInfo, LevelNo);

		printTextureOffsets(LevelInfo, LevelNo);

		PrintShadeValues(LevelInfo, LevelNo);
		PrintLightStates(LevelInfo, LevelNo);

		printFloorOrientations(LevelInfo, LevelNo);
		printCeilOrientations(LevelInfo, LevelNo);
		shockCommonObject();
		}
	else
		{
		PrintLevelEntrances(LevelInfo, objList, LevelNo);
		//ParseTerrainProperties(game);
		}

	PrintObjectsByTile(LevelInfo, objList, LevelNo);
	}

void printTileMap(tile LevelInfo[64][64], int LevelNo)
	{
	//Prints the tilemap 
	int x; int y;
	fprintf(LOGFILE,"\nNow Printing Tile for level :%d.", LevelNo);
	for (y = 63; y >= 0; y--) //invert for ascii
		{
		fprintf(LOGFILE,"\n");
		for (x = 0; x <= 63; x++)
			{
			RenderAsciiTile(LevelInfo[x][y]);
			fprintf(LOGFILE,"|");//delimiter.
			}
		}
	}

void printNoMagicMap(tile LevelInfo[64][64], int LevelNo)
	{
	//Prints the tilemap 
	int x; int y;
	fprintf(LOGFILE, "\nNow Printing No Magic for level :%d.", LevelNo);
	for (y = 63; y >= 0; y--) //invert for ascii
		{
		fprintf(LOGFILE, "\n");
		for (x = 0; x <= 63; x++)
			{
			fprintf(LOGFILE, "%d", LevelInfo[x][y].noMagic);
			fprintf(LOGFILE, "\\");//delimiter.
			}
		}
	}

void printFlagsMap(tile LevelInfo[64][64], int LevelNo)
	{
	//Prints the tilemap 
	int x; int y;
	fprintf(LOGFILE, "\nNow Printing flags for level :%d.", LevelNo);
	for (y = 63; y >= 0; y--) //invert for ascii
		{
		fprintf(LOGFILE, "\n");
		for (x = 0; x <= 63; x++)
			{
			fprintf(LOGFILE, "%02d", LevelInfo[x][y].flags);
			fprintf(LOGFILE, "\\");//delimiter.
			}
		}
	}

void printFloorHeights(tile LevelInfo[64][64], int LevelNo)
	{
	//Prints the height map of the level.

	int x; int y;
	fprintf(LOGFILE,"\nNow Printing Floor Heights for level :%d.", LevelNo);
	for (y = 63; y >= 0; y--)
		{
		fprintf(LOGFILE,"\n");
		for (x = 0; x<64; x++)
			{
			fprintf(LOGFILE,"%02d|", LevelInfo[x][y].floorHeight);
			}
		}
	}

void printFloorTextures(tile LevelInfo[64][64], int LevelNo)
	{
	//Prints the floor textures (the mapped values) of the level.
	int x; int y;
	fprintf(LOGFILE,"\nNow Printing floor textures for level :%d.(##)", LevelNo);
	for (y = 63; y >= 0; y--)
		{
		fprintf(LOGFILE,"\n");
		for (x = 0; x<64; x++)
			{
			fprintf(LOGFILE,"%d|", LevelInfo[x][y].floorTexture);
			}
		}
	}

void printDoorPositions(tile LevelInfo[64][64], ObjectItem objList[1600], int LevelNo)
	{
	//Shows which tiles contain doors.
	//Door flags set by setDoorBits()

	int x; int y;
	fprintf(LOGFILE,"\nNow Printing door positions for level :%d.", LevelNo);
	for (y = 63; y >= 0; y--)
		{
		fprintf(LOGFILE,"\n");
		for (x = 0; x<64; x++)
			{
			if (LevelInfo[x][y].isDoor == 1)
				{
				fprintf(LOGFILE,"%d(%d,%d)|", objList[LevelInfo[x][y].indexObjectList].heading, objList[LevelInfo[x][y].indexObjectList].x, objList[LevelInfo[x][y].indexObjectList].y);
				}
			else
				{
				fprintf(LOGFILE,".|");
				}
			}
		}

	}

void printWallTextures(tile LevelInfo[64][64], int LevelNo)
	{
	//Prints the value of the wall texture of the tile.
	//When rendering a tile we actually use the adjacent wall texture value which is set to the north,south,east and west fields
	//Exception is when the adjacent flag is set. In that case north,south,east and west uses the tile value.

	int x; int y;
	fprintf(LOGFILE,"\nNow Printing wall textures for level :%d.(##)", LevelNo);
	fprintf(LOGFILE,"\n\tNote that the rendered textures are the adjacent north, south, east and west values which are got from the neighbour tiles.");
	for (y = 63; y >= 0; y--)
		{
		fprintf(LOGFILE,"\n");
		for (x = 0; x <= 63; x++)
			{
			fprintf(LOGFILE,"%d|", LevelInfo[x][y].wallTexture);
			}
		}
	}

void printAdjacentFlags(tile LevelInfo[64][64], int LevelNo)
	{
	//What tiles sets their north,south,east and west values from their neighbour tiles.
	int x; int y;
	fprintf(LOGFILE,"\nNow Printing adjacent flags for level :%d.(##)", LevelNo);
	for (y = 63; y >= 0; y--)
		{
		fprintf(LOGFILE,"\n");
		for (x = 0; x <= 63; x++)
			{
			fprintf(LOGFILE,"%d|", LevelInfo[x][y].UseAdjacentTextures);
			}
		}
	}

void printTextureOffsets(tile LevelInfo[64][64], int LevelNo)
	{
	//Texture offset is how much the wall texture is shifted from the ceiling.
	int x; int y;
	fprintf(LOGFILE,"\nNow printing texture offsets :%d.(##)", LevelNo);
	for (y = 63; y >= 0; y--)
		{
		fprintf(LOGFILE,"\n");
		for (x = 0; x <= 63; x++)
			{
			fprintf(LOGFILE,"%d|", LevelInfo[x][y].shockTextureOffset);
			}
		}
	}

void printCeilingHeights(tile LevelInfo[64][64], int LevelNo)
	{
	//The actual ceiling height is actually the max ceiling height less this value.
	int x; int y;
	fprintf(LOGFILE,"\nPrint out ceiling height by tile for level :%d\n", LevelNo);
	for (y = 63; y >= 0; y--)
		{
		fprintf(LOGFILE,"\n");
		for (x = 0; x<64; x++)
			{
			fprintf(LOGFILE,"%02d|", LevelInfo[x][y].ceilingHeight);
			}
		}
	}

void printSlopeSteepness(tile LevelInfo[64][64], int LevelNo)
	{
	//Prints the number of "levels" a slope changes by.
	int x; int y;
	fprintf(LOGFILE,"\nPrint out slope steepness by tile for level :%d\n", LevelNo);
	for (y = 63; y >= 0; y--)
		{
		fprintf(LOGFILE,"\n");
		for (x = 0; x<64; x++)
			{
			fprintf(LOGFILE,"%02d|", LevelInfo[x][y].shockSteep);
			}
		}
	}

void printSlopeFlags(tile LevelInfo[64][64], int LevelNo)
	{
	//Prints the flags which determine whether a slope is floor or ceiling only, both, inverted etc.

	int x; int y;

	fprintf(LOGFILE,"\nPrint out slope flags by tile for level :%d\n", LevelNo);
	for (y = 63; y >= 0; y--)
		{
		fprintf(LOGFILE,"\n");
		for (x = 0; x<64; x++)
			{
			fprintf(LOGFILE,"%02d|", LevelInfo[x][y].shockSlopeFlag);
			}
		}
	}

void PrintObjectsByTile(tile LevelInfo[64][64], ObjectItem objList[1600], int LevelNo)
	{
	//Prints a tile map that lists each object in it
	int x; int y;
	fprintf(LOGFILE,"\nPrint out objects by Tile for level :%d\n", LevelNo);

	for (y = 63; y >= 0; y--)
		{
		fprintf(LOGFILE,"\n");
		for (x = 0; x<64; x++)
			{

			if (LevelInfo[x][y].indexObjectList != 0)
				{
				//fprintf(LOGFILE,"\nAt tile x=%d, y=%d :",x,y);
				long nextShockObj = printObject(objList[LevelInfo[x][y].indexObjectList]);
				while (nextShockObj != 0)
					{
					fprintf(LOGFILE,"-");
					nextShockObj = printObject(objList[nextShockObj]);

					}
				}
			else
				{
				fprintf(LOGFILE,"[]");
				}
			fprintf(LOGFILE,"*");
			}
		}

	}

void PrintShadeValues(tile LevelInfo[64][64], int LevelNo)
	{
	//Prints out the tile shading values for System Shock.
	int x; int y;
	fprintf(LOGFILE,"\nPrint out shade value by tile for level :%d\n", LevelNo);
	for (y = 63; y >= 0; y--)
		{
		fprintf(LOGFILE,"\n");
		for (x = 0; x<64; x++)
			{
			fprintf(LOGFILE,"%d-%d|", LevelInfo[x][y].shockShadeUpper, LevelInfo[x][y].shockShadeLower);
			}
		}
	}

void PrintLightStates(tile LevelInfo[64][64], int LevelNo)
	{
	//Prints the state value that Shock stores for the light calculations.
	int x; int y;
	fprintf(LOGFILE,"\nPrint out light state by tile for level :%d\n", LevelNo);
	for (y = 63; y >= 0; y--)
		{
		fprintf(LOGFILE,"\n");
		for (x = 0; x<64; x++)
			{
			fprintf(LOGFILE,"%d-%d|", (LevelInfo[x][y].SHOCKSTATE[3] >> 4 & 0x0F), (LevelInfo[x][y].SHOCKSTATE[3] & 0x0F));
			}
		}
	}

void PrintLevelEntrances(tile LevelInfo[64][64], ObjectItem objList[1600], int LevelNo)
	{
	//UW. Prints the teleport traps that point to a different level i.e. level entrances.

	fprintf(LOGFILE,"\nLevel Entrances\n");		//go through the objects and find teleport traps with a zpos !=0
	fprintf(LOGFILE,"LevelNo\tTileX\tTileY\n");
	for (int i = 0; i<1024; i++)
		{
		if ((isTrigger(objList[i])) && (objectMasters[objList[objList[i].link].item_id].type == A_TELEPORT_TRAP))
		if ((objList[objList[i].link].zpos != 0))	//Trap goes to another level
			{
			fprintf(LOGFILE,"%d\t%d\t%d\n", objList[objList[i].link].zpos - 1, objList[objList[i].link].quality, objList[objList[i].link].owner);
			}
		}
	}

void PrintUWObjects(ObjectItem objList[1600])
	{
	//Prints the object debug info for UW.
	for (int x = 0; x < 1024; x++)
		{
		//if (objList[x].InUseFlag == 1)
		//{
		UniqueObjectName(objList[x]);
		fprintf(LOGFILE,"\n\nIndex: %d", objList[x].index);
		fprintf(LOGFILE, "\n\nAddress: %d", objList[x].address);
		fprintf(LOGFILE,"\tName: %s", UniqueObjectName(objList[x]));
		if (objectMasters[objList[x].item_id].isSet == 1)
			{
			fprintf(LOGFILE,"\n\tObject Type : %d %s", objList[x].item_id, objectMasters[objList[x].item_id].desc);
			}
		else
			{
			fprintf(LOGFILE,"\n\tObject Type : %d %s", objList[x].item_id, "Unknown or bugged");
			}
		fprintf(LOGFILE,"\n\tLocation Tile(%d,%d) Position(%d,%d,%d) Heading (%d)", objList[x].tileX, objList[x].tileY, objList[x].x, objList[x].y, objList[x].zpos, objList[x].heading);
		fprintf(LOGFILE,"\n\tIn use %d", objList[x].InUseFlag);
		fprintf(LOGFILE,"\n\tFlags: %d", objList[x].flags);
		fprintf(LOGFILE,"\n\t\tEnchantment: %d", objList[x].enchantment);
		fprintf(LOGFILE,"\n\t\tDoordir : %d", objList[x].doordir);
		fprintf(LOGFILE,"\n\t\tInvis : %d", objList[x].invis);
		fprintf(LOGFILE,"\n\t\tIs Quant : %d", objList[x].is_quant);

		fprintf(LOGFILE,"\n\tQuality : %d", objList[x].quality);
		fprintf(LOGFILE,"\n\tNext : %d", objList[x].next);

		fprintf(LOGFILE,"\n\tOwner : %d", objList[x].owner);
		if (objList[x].is_quant == 1)
			{
			if (objList[x].link > 512)
				{
				fprintf(LOGFILE,"\n\tSpecial Property : %d", objList[x].link);
				fprintf(LOGFILE,"\tless 512 is %d : ", objList[x].link - 512);
				}
			else
				{
				fprintf(LOGFILE,"\n\tQuantity : %d", objList[x].link);
				}

			}
		else
			{
			fprintf(LOGFILE,"\n\tSpecial Link : %d", objList[x].link);
			}

		if (objList[x].texture > -1)
			{
			printf("\n\tTexture: %d" , objList[x].texture );
			}
		//if (objList[x].npc_whoami >=0)
		if (x<256)
			{
			fprintf(LOGFILE, "\n\tNPC HP : %d ", objList[x].npc_hp);
			fprintf(LOGFILE, "\n\tNPC Goal : %d ", objList[x].npc_goal);
			fprintf(LOGFILE, "\n\tNPC GTarg : %d ", objList[x].npc_gtarg);
			fprintf(LOGFILE, "\n\tNPC Level : %d ", objList[x].npc_level);
			fprintf(LOGFILE, "\n\tNPC TalkedTo : %d ", objList[x].npc_talkedto);
			fprintf(LOGFILE, "\n\tNPC Attitude : %d ", objList[x].npc_attitude);
			fprintf(LOGFILE, "\n\tNPC yHome : %d ", objList[x].npc_yhome);
			fprintf(LOGFILE, "\n\tNPC xHome : %d ", objList[x].npc_xhome);
			fprintf(LOGFILE, "\n\tNPC Heading : %d ", objList[x].npc_heading);
			fprintf(LOGFILE, "\n\tNPC Hunger : %d ", objList[x].npc_hunger);
			fprintf(LOGFILE,"\n\tNPC Who Am I : %d ", objList[x].npc_whoami);
			//fprintf(LOGFILE,"\n\tNPC Death Quest variable : %d ", objList[x].npc_deathVariable);


			/*

			objList[x].npc_hp = getValAtAddress(lev_ark, objectsAddress + address_pointer + 8, 8);

			objList[x].npc_goal = getValAtAddress(lev_ark, objectsAddress + address_pointer + 11, 16) & 0xF;
			objList[x].npc_gtarg = (getValAtAddress(lev_ark, objectsAddress + address_pointer + 11, 16)>>4 & 0xFF);

			objList[x].npc_level = getValAtAddress(lev_ark, objectsAddress + address_pointer + 13, 16) & 0xF;

			objList[x].npc_talkedto = (getValAtAddress(lev_ark, objectsAddress + address_pointer + 13, 16)>>13 & 0x1);
			objList[x].npc_attitude = (getValAtAddress(lev_ark, objectsAddress + address_pointer + 13, 16) >> 14 & 0x3);

			objList[x].npc_yhome = (getValAtAddress(lev_ark, objectsAddress + address_pointer + 22, 16) >> 4 & 0xF);
			objList[x].npc_xhome = (getValAtAddress(lev_ark, objectsAddress + address_pointer + 22, 16) >> 10 & 0xF);

			objList[x].npc_heading = (getValAtAddress(lev_ark, objectsAddress + address_pointer + 24, 16) >> 4 & 0xF);
			objList[x].npc_hunger = (getValAtAddress(lev_ark, objectsAddress + address_pointer + 25, 16)  & 0x3F);


*/
			}

		if ((objectMasters[objList[x].item_id].type == TMAP_SOLID) 
			|| (objectMasters[objList[x].item_id].type == TMAP_CLIP)
			|| (objectMasters[objList[x].item_id].type == BRIDGE)
			|| (objectMasters[objList[x].item_id].type == BUTTON)
			)
			{
			fprintf(LOGFILE, "\n\tTexture: %d", objList[x].texture);
			}
		if (objectMasters[objList[x].item_id].type == A_SPELLTRAP)
			{
			fprintf(LOGFILE, "\n\tEffectID: %d", ((objList[x].quality & 0xf) << 4) | (objList[x].owner & 0xf));
//((objInt.Quality & 0xf)<<4) | (objInt.Owner & 0xf)
			}
		}
	//}
	}

void printWaterRegions(tile LevelInfo[64][64], int LevelNo)
	{
	//Prints a tilemap of the water bodies only.

	int x; int y;
	fprintf(LOGFILE,"\nNow Printing Water Regions for level :%d.", LevelNo);
	for (y = 63; y >= 0; y--) //invert for ascii
		{
		fprintf(LOGFILE,"\n");
		for (x = 0; x <= 63; x++)
			{
			if (LevelInfo[x][y].isWater == 1)
				{
				fprintf(LOGFILE,"%02d-", LevelInfo[x][y].waterRegion);
				}
			else
				{
				fprintf(LOGFILE,"  -");
				}

			}
		}

	}

void printNeighbourCounts(tile LevelInfo[64][64], int LevelNo)
	{
	//Prints a tile map showing a count of neighbouring (nonsolid) tiles.

	int x; int y;
	fprintf(LOGFILE,"\nNow Printing Neighbour counts for level :%d.", LevelNo);
	for (y = 63; y >= 0; y--) //invert for ascii
		{
		fprintf(LOGFILE,"\n");
		for (x = 0; x <= 63; x++)
			{
			fprintf(LOGFILE,"%d-", LevelInfo[x][y].noOfNeighbours);
			}
		}
	}


void printRoomRegionsForNavmeshTagging(tile LevelInfo[64][64], ObjectItem objList[1600], int LevelNo)
	{
	//Prints a tilemap that shows the various room regions that we have generated.
	//Room regions can be rooms, corridors, water and doors.
	int x; int y; int z;
	fprintf(LOGFILE,"\nNow Printing Room  regions for level :%d.", LevelNo);
	for (y = 63; y >= 0; y--) //invert for ascii
		{
		fprintf(LOGFILE,"\n");
		for (x = 0; x <= 63; x++)
			{
			if (LevelInfo[x][y].Render == 1)
				{//TODO:Support other tile types
				if (LevelInfo[x][y].tileType == TILE_SOLID)
					{
					if (LevelInfo[x][y].Render == 1)
						{
						fprintf(LOGFILE, "SetTileTag(%d,%d,\"SOLIDWALL\",%d);", x, y, LevelInfo[x][y].Render);
						}
					}
				else if (LevelInfo[x][y].isWater == 1)
					{
					fprintf(LOGFILE, "SetTileTag(%d,%d,\"WATER_%d\", %d);", x, y, LevelInfo[x][y].waterRegion, LevelInfo[x][y].Render);
					}
				else if (LevelInfo[x][y].isLava == 1)
					{
					fprintf(LOGFILE, "SetTileTag(%d,%d,\"LAVA_%d\", %d);", x, y, LevelInfo[x][y].lavaRegion, LevelInfo[x][y].Render);
					}
				else
					{
					//if (LevelInfo[x][y].landRegion >= 30)
					//	{//Cap the number of regions.
					//	fprintf(LOGFILE, "SetTileTag(%d,%d,\"LAND_%d\", %d);", x, y, 30, LevelInfo[x][y].Render);
						//}
					//else
					//	{
						fprintf(LOGFILE, "SetTileTag(%d,%d,\"LAND_%d\", %d);", x, y, LevelInfo[x][y].landRegion, LevelInfo[x][y].Render);
						//}					
					}
				}


			}
		}
	for (int z = 0; z < 1024; z++)
		{
		if (objectMasters[objList[z].item_id].type== BRIDGE)
			{
			x = objList[z].tileX; y = objList[z].tileY;
			//fprintf(LOGFILE, "SetObjectTag(\"BRIDGE_%02d_%02d\", \"LAND_%d\");\n", x, y, LevelInfo[x][y].bridgeRegion);
			if ((x <= 64) && (y <= 64))
				{
				fprintf(LOGFILE, "SetObjectTag(\"%s\", \"LAND_%d\");\n", UniqueObjectName(objList[z]), LevelInfo[x][y].bridgeRegion);
				}
			
			}
		else if (objectMasters[objList[z].item_id].type == A_CHANGE_TERRAIN_TRAP)
			{
			for (int i = 0; i <= objList[z].x; i++)
				{
				for (int j = 0; j <= objList[z].y; j++)
					{	//I can't know what land region I will have yet so I will just assume land 1.
					int floorTexture;
					if (objList[z].texture == -1)
						{
						if ((objList[z].tileX != 99) || (objList[z].tileX != 99))
							{
							floorTexture = LevelInfo[objList[z].tileX + i][objList[z].tileY + j].floorTexture;//?
							}
						else
							{
							floorTexture = objList[z].texture;
							}
						}
					else
						{
						floorTexture = objList[z].texture;
						}
					if (textureMasters[floorTexture].water == 1)
						{
						fprintf(LOGFILE, "SetObjectTag(\"%s_%02d_%02d\", \"WATER_%d\");\n", UniqueObjectName(objList[z]), i, j, 1);
						}
					else if(textureMasters[floorTexture].lava == 1)
						{
						fprintf(LOGFILE, "SetObjectTag(\"%s_%02d_%02d\", \"LAVA_%d\");\n", UniqueObjectName(objList[z]), i, j, 1);
						}
					else
						{
						fprintf(LOGFILE, "SetObjectTag(\"%s_%02d_%02d\", \"LAND_%d\");\n", UniqueObjectName(objList[z]), i, j, 1);
						}					
					}
				}
			}
		}
	}

void printRoomRegions(tile LevelInfo[64][64], int LevelNo)
	{
	//Prints a tilemap that shows the various room regions that we have generated.
	//Room regions can be rooms, corridors, water and doors.
	int x; int y;
	fprintf(LOGFILE, "\nNow Printing Room  regions for level :%d.", LevelNo);
	for (y = 63; y >= 0; y--) //invert for ascii
		{
		fprintf(LOGFILE, "\n");
		for (x = 0; x <= 63; x++)
			{
			if (LevelInfo[x][y].tileType == TILE_SOLID)
				{
				//fprintf(LOGFILE,"S%03d-", LevelInfo[x][y].roomRegion);
				fprintf(LOGFILE, "S%03d-", LevelInfo[x][y].landRegion);
				}

			else if (LevelInfo[x][y].isWater == 1)
				{
				fprintf(LOGFILE, "W%03d-", LevelInfo[x][y].waterRegion);
				}
			else if (LevelInfo[x][y].isCorridor == 1)
				{
				fprintf(LOGFILE, "C%03d-", LevelInfo[x][y].landRegion);
				}
			else if (LevelInfo[x][y].isDoor == 1)
				{
				fprintf(LOGFILE, "D%03d-", LevelInfo[x][y].landRegion);
				}
			else
				{
				fprintf(LOGFILE, "R%03d-", LevelInfo[x][y].landRegion);
				}
			}
		}
	}




void printFloorOrientations(tile LevelInfo[64][64], int LevelNo)
	{
	//Prints the texture direction for floor tiles in SHOCK.

	int x; int y;
	fprintf(LOGFILE,"\nNow Printing Floor orientations for level :%d.", LevelNo);
	for (y = 63; y >= 0; y--)
		{
		fprintf(LOGFILE,"\n");
		for (x = 0; x<64; x++)
			{
			fprintf(LOGFILE,"%d|", LevelInfo[x][y].shockFloorOrientation);
			}
		}
	}

void printCeilOrientations(tile LevelInfo[64][64], int LevelNo)
	{

	//Prints the ceiling texture orientations in SHOCK.
	int x; int y;
	fprintf(LOGFILE,"\nNow Printing ceiling orientations for level :%d.", LevelNo);
	for (y = 63; y >= 0; y--)
		{
		fprintf(LOGFILE,"\n");
		for (x = 0; x<64; x++)
			{
			fprintf(LOGFILE,"%d|", LevelInfo[x][y].shockCeilOrientation);
			}
		}
	}
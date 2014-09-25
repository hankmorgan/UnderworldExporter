/*
UNDERWORLD EXPORTER
SourceEngine.cpp

Functions for writing out the .vmf files

*/
#include <stdio.h>
#include <stdlib.h>
#include <fstream>
#include "math.h"

#include "tilemap.h"
#include "main.h"
#include "textures.h"
#include "SourceEngine.h"
//#include "gameobjects.h"
//#include "gameobjectsrender.h"

extern FILE *MAPFILE;
extern int iGame;
extern long SHOCK_CEILING_HEIGHT;
extern long UW_CEILING_HEIGHT;
FILE *UNITYFILE;

char *UniqueTileName(int x, int y, int surface, int part)
	{
	char str[20] = "";
	switch (surface)
		{
			case SURFACE_WALL:
				{
				sprintf_s(str, 20, "Tile_%02d_%02d\0", x, y);
				return str;
				break;
				}
			case SURFACE_CEIL:
				{
				if (part == 0)
					{
					sprintf_s(str, 20, "Ceiling_%02d_%02d\0", x, y);
					}
				else
					{
					sprintf_s(str, 20, "Ceiling_%02d_%02d_%d\0", x, y, part);
					}
				return str;
				break;
				}
			case SURFACE_FLOOR:
			case SURFACE_SLOPE:
			default:
				{
				if (part == 0)
					{
					sprintf_s(str, 20, "Floor_%02d_%02d\0", x, y);
					}
				else
					{
					sprintf_s(str, 20, "Floor_%02d_%02d_%d\0", x, y, part);
					}
				return str;
				break;
				}
		}
	return str;
	}


void StoreTileName(int x, int y, int surface, int part)
	{

	char str[20] = "";
	switch (surface)
		{
			case SURFACE_WALL:
				{
				sprintf_s(str, 20, "Tile_%02d_%02d\0", x, y);
				break;
				}
			case SURFACE_CEIL:
				{
				if (part == 0)
					{
					sprintf_s(str, 20, "Ceiling_%02d_%02d\0", x, y);
					}
				else
					{
					sprintf_s(str, 20, "Ceiling_%02d_%02d_%d\0", x, y, part);
					}
				break;
				}
			case SURFACE_FLOOR:
			case SURFACE_SLOPE:
			default:
				{
				if (part == 0)
					{
					sprintf_s(str, 20, "Floor_%02d_%02d\0", x, y);
					}
				else
					{
					sprintf_s(str, 20, "Floor_%02d_%02d_%d\0", x, y, part);
					}
				break;
				}
		}



	printf("Tilename %s\n",str);
	//Matches a tile name with it's brush numbers so I can rename the brush later on.
	fprintf(UNITYFILE, "RenameBrushes(\"world.worldspawn.Brush_%d\",\"", PrimitiveCount);
	fprintf(UNITYFILE, "%s", str);
	fprintf(UNITYFILE, "\");\n");
	}

void RenderSourceEnginelLevel(tile LevelInfo[64][64], ObjectItem objList[1600], int game)
//Main processing loop for generating the level.
{
int x;
int y;
int skipCeil=0;

iGame = game;
if (fopen_s(&UNITYFILE, "unity_tiles.txt", "w") != 0)
	{
	printf("Unable to create output file for unity tile mappings! Carrying on regardless.");
	}
//Levels use different ceiling heights.
//Shock is variable, UW is fixed.
switch (game)
	{
	case SHOCK:
		{
		CEILING_HEIGHT = SHOCK_CEILING_HEIGHT;
		break;
		}
	default://UW1&2
		{
		skipCeil = 1;
			CEILING_HEIGHT = UW_CEILING_HEIGHT;
			break;
		}

	}

//File header of the map file.
fprintf(MAPFILE, "versioninfo\n");
	fprintf(MAPFILE, "{\n");
		fprintf(MAPFILE, "\t\"editorversion\" \"400\"\n");
		fprintf(MAPFILE, "\t\"editorbuild\" \"6412\"\n");	//?
		fprintf(MAPFILE, "\t\"mapversion\" \"3\"\n");
		fprintf(MAPFILE, "\t\"formatversion\" \"100\"\n");
		fprintf(MAPFILE, "\t\"prefab\" \"0\"\n");
	fprintf(MAPFILE, "}\n");
	//visgroups?
	fprintf(MAPFILE, "visgroups\n{\n}\n");
	//world
	fprintf(MAPFILE, "world\n");
	fprintf(MAPFILE, "{\n");
	fprintf(MAPFILE, "\t\"id\" \"1\"\n");
	fprintf(MAPFILE, "\t\"mapversion\" \"3\"\n");
	fprintf(MAPFILE, "\t\"classname\" \"worldspawn\"\n");
	fprintf(MAPFILE, "\t\"detailmaterial\" \"detail/detailsprites\"\n");	//?
	fprintf(MAPFILE, "\t\"detailvbsp\" \"detail.vbsp\"\n");
	fprintf(MAPFILE, "\t\"maxpropscreenwidth\" \"-1\"\n");
	fprintf(MAPFILE, "\t\"skyname\" \"sky_day01_01\"\n");
	
		PrimitiveCount = 1;
		//Now the tiles
		for (y = 0; y <= 63; y++)
		{
			for (x = 0; x <= 63; x++)
			{
				RenderSourceTile(game, x, y, LevelInfo[x][y], 0, 0, 0, skipCeil);
			}

		}

		if (game != SHOCK)
			{
			//Render UW ceiling
			tile tmp;
			tmp.tileType = 1;
			tmp.Render = 1;
			tmp.isWater = 0;
			tmp.tileX = 0;
			tmp.tileY = 0;
			tmp.DimX = 64;
			tmp.DimY = 64;
			tmp.ceilingHeight = 0;
			tmp.floorTexture = LevelInfo[0][0].shockCeilingTexture;
			tmp.shockCeilingTexture = LevelInfo[0][0].shockCeilingTexture;
			tmp.East = LevelInfo[0][0].shockCeilingTexture;//CAULK;
			tmp.West = LevelInfo[0][0].shockCeilingTexture;//CAULK;
			tmp.North = LevelInfo[0][0].shockCeilingTexture;//CAULK;
			tmp.South = LevelInfo[0][0].shockCeilingTexture;//CAULK;
			RenderSourceTile(game, 0, 0, tmp, 0, 0, 1, 0);
			}


		fprintf(MAPFILE, "}\n");

		fprintf(MAPFILE, "cordon\n");
			fprintf(MAPFILE, "{\n");
			fprintf(MAPFILE, "\t\"mins\" \"(-%d -%d -%d)\"\n", 64 * BrushSizeX, 64 * BrushSizeY, 64 * BrushSizeZ);
			fprintf(MAPFILE, "\t\"maxs\" \"(%d %d %d)\"\n", 64 * BrushSizeX, 64 * BrushSizeY, 64 * BrushSizeZ);
			fprintf(MAPFILE, "\t\"active\" \"0\"");
			fprintf(MAPFILE, "}\n");

			fclose(UNITYFILE);
}

void RenderSourceTile(int game, int x, int y, tile &t, short Water, short invert, short skipFloor, short skipCeil)
{
	//Picks the tile to render based on tile type/flags.
	switch (t.tileType)
	{
	case TILE_SOLID:	//0
		{	//solid
			RenderSourceSolidTile(x, y, t, Water);
			return;
		}
	case TILE_OPEN:		//1
		{//open
			if (skipFloor != 1) { RenderSourceOpenTile(x, y, t, Water, 0,SURFACE_FLOOR); }	//floor
			if ((skipCeil != 1)) { RenderSourceOpenTile(x, y, t, Water, 1, SURFACE_CEIL); }	//ceiling	
			return;
		}
	
	case 2:
		{//diag se
					if (skipFloor != 1) { RenderSourceDiagSETile(x, y, t, Water, 0); }//floor
					if ((skipCeil != 1)) { RenderSourceDiagSETile(x, y, t, Water, 1); }
					return;
		}

	case 3:
		{	//diag sw
					if (skipFloor != 1) { RenderSourceDiagSWTile(x, y, t, Water, 0); }//floor
					if ((skipCeil != 1)) { RenderSourceDiagSWTile(x, y, t, Water, 1); }
					return;
		}

	case 4:
		{	//diag ne
			  if (skipFloor != 1) { RenderSourceDiagNETile(x, y, t, Water, invert); }//floor
			  if ((skipCeil != 1)) { RenderSourceDiagNETile(x, y, t, Water, 1); }
				  return;
		}

	case 5:
		{//diag nw
			if (skipFloor != 1) { RenderSourceDiagNWTile(x, y, t, Water, invert); }//floor
			if ((skipCeil != 1)) { RenderSourceDiagNWTile(x, y, t, Water, 1); }
			return;
		}

	case TILE_SLOPE_N:	//6
		{//slope n
			switch (t.shockSlopeFlag)
				{
				case SLOPE_BOTH_PARALLEL:
					{
						if (skipFloor != 1) { RenderSourceSlopeNTile(x, y, t, Water, 0,SURFACE_FLOOR,0); }//floor
						if ((skipCeil != 1)) { RenderSourceSlopeNTile(x, y, t, Water, 1,SURFACE_CEIL,0); }
						break;
					}
				case SLOPE_BOTH_OPPOSITE:
					{
					if (skipFloor != 1) { RenderSourceSlopeNTile(x, y, t, Water, 0, SURFACE_FLOOR, 0); }//floor
					if ((skipCeil != 1)) { RenderSourceSlopeSTile(x, y, t, Water, 1, SURFACE_CEIL, 0); }
						break;
					}
				case SLOPE_FLOOR_ONLY:
					{
					if (skipFloor != 1) { RenderSourceSlopeNTile(x, y, t, Water, 0, SURFACE_FLOOR, 0); }//floor
					if ((skipCeil != 1)) { RenderSourceOpenTile(x, y, t, Water, 1, SURFACE_CEIL); }	//ceiling
						break;
					}
				case SLOPE_CEILING_ONLY:
				{
					if (skipFloor != 1) { RenderSourceOpenTile(x, y, t, Water, 0,SURFACE_FLOOR); }	//floor
					RenderSourceSlopeNTile(x, y, t, Water, 1, SURFACE_CEIL, 0);
					break;
				}
				}
			return;
		}
	case TILE_SLOPE_S: //slope s	7
		{
			switch (t.shockSlopeFlag)
			{
			case SLOPE_BOTH_PARALLEL:
			{
			if (skipFloor != 1) { RenderSourceSlopeSTile(x, y, t, Water, 0, SURFACE_FLOOR, 0); }	//floor
			RenderSourceSlopeSTile(x, y, t, Water, 1, SURFACE_CEIL, 0);
				break;
			}
			case SLOPE_BOTH_OPPOSITE:
			{
			if (skipFloor != 1) { RenderSourceSlopeSTile(x, y, t, Water, 0, SURFACE_FLOOR, 0); }	//floor
			RenderSourceSlopeNTile(x, y, t, Water, 1, SURFACE_CEIL, 0);
				break;
			}
			case SLOPE_FLOOR_ONLY:
			{
			if (skipFloor != 1) { RenderSourceSlopeSTile(x, y, t, Water, 0, SURFACE_FLOOR, 0); }	//floor
			if ((skipCeil != 1)) { RenderSourceOpenTile(x, y, t, Water, 1, SURFACE_CEIL); }	//ceiling
			break;
			}
			case SLOPE_CEILING_ONLY:
			{
			if (skipFloor != 1) { RenderSourceOpenTile(x, y, t, Water, 0, SURFACE_FLOOR); }	//floor
				if ((skipCeil != 1)) { RenderSourceSlopeSTile(x, y, t, Water, 1,SURFACE_CEIL,0); }
				break;
			}
		}
		return;
	}
	case TILE_SLOPE_E:		//slope e 8	
	{
		switch (t.shockSlopeFlag)
		{
		case SLOPE_BOTH_PARALLEL:
		{
		if (skipFloor != 1) { RenderSourceSlopeETile(x, y, t, Water, 0, SURFACE_FLOOR, 0); }//floor
		RenderSourceSlopeETile(x, y, t, Water, 1, SURFACE_CEIL, 0);
			break;
		}
		case SLOPE_BOTH_OPPOSITE:
		{
		if (skipFloor != 1) { RenderSourceSlopeETile(x, y, t, Water, 0, SURFACE_FLOOR, 0); }//floor
		RenderSourceSlopeWTile(x, y, t, Water, 1, SURFACE_CEIL, 0);
			break;
		}
		case SLOPE_FLOOR_ONLY:
		{
		if (skipFloor != 1) { RenderSourceSlopeETile(x, y, t, Water, 0, SURFACE_FLOOR, 0); }//floor
		if ((skipCeil != 1)) { RenderSourceOpenTile(x, y, t, Water, 1, SURFACE_CEIL); }	//ceiling
			break;
		}
		case SLOPE_CEILING_ONLY:
		{
		if (skipFloor != 1) { RenderSourceOpenTile(x, y, t, Water, 0, SURFACE_FLOOR); }	//floor
			if ((skipCeil != 1)) { RenderSourceSlopeETile(x, y, t, Water, 1, SURFACE_CEIL, 0); }
			break;
		}
		}
		return;
	}
	case TILE_SLOPE_W: 	//9
	{ //slope w
		switch (t.shockSlopeFlag)
			{
			case SLOPE_BOTH_PARALLEL:
			{
			if (skipFloor != 1) { RenderSourceSlopeWTile(x, y, t, Water, 0, SURFACE_FLOOR, 0); }//floor
			if ((skipCeil != 1)) { RenderSourceSlopeWTile(x, y, t, Water, 1, SURFACE_CEIL, 0); }
			break;
			}
			case SLOPE_BOTH_OPPOSITE:
			{
			if (skipFloor != 1) { RenderSourceSlopeWTile(x, y, t, Water, 0, SURFACE_FLOOR, 0); }//floor
			if ((skipCeil != 1)) { RenderSourceSlopeETile(x, y, t, Water, 1, SURFACE_CEIL, 0); }
			break;
			}
			case SLOPE_FLOOR_ONLY:
			{
			if (skipFloor != 1) { RenderSourceSlopeWTile(x, y, t, Water, 0, SURFACE_FLOOR, 0); }//floor
			if ((skipCeil != 1)) { RenderSourceOpenTile(x, y, t, Water, 1, SURFACE_CEIL); }	//ceiling
			break;
			}
			case SLOPE_CEILING_ONLY:
			{
			if (skipFloor != 1) { RenderSourceOpenTile(x, y, t, Water, 0, SURFACE_FLOOR); }	//floor
			if ((skipCeil != 1)) { RenderSourceSlopeWTile(x, y, t, Water, 1, SURFACE_CEIL, 0); }
			break;
			}
		}
		return;
	}
	case TILE_VALLEY_NW:
	{	//valleyNw(a)
						   switch (t.shockSlopeFlag)
						   {
						   case SLOPE_BOTH_PARALLEL:
						   {
						   if (skipFloor != 1) { RenderSourceValleyNWTile(x, y, t, Water, 0, SURFACE_FLOOR); }//floor
						   if ((skipCeil != 1)) { RenderSourceValleyNWTile(x, y, t, Water, 1, SURFACE_CEIL); }
													   break;
						   }
						   case SLOPE_BOTH_OPPOSITE:
						   {
						   if (skipFloor != 1) { RenderSourceValleyNWTile(x, y, t, Water, 0, SURFACE_FLOOR); }//floor
						   if ((skipCeil != 1)) { RenderSourceValleySETile(x, y, t, Water, 1, SURFACE_CEIL); }
													   break;
						   }
						   case SLOPE_FLOOR_ONLY:
						   {
						   if (skipFloor != 1) { RenderSourceValleyNWTile(x, y, t, Water, 0, SURFACE_FLOOR); }//floor
						   if ((skipCeil != 1)) { RenderSourceOpenTile(x, y, t, Water, 1, SURFACE_CEIL); }	//ceiling
													break;
						   }
						   case SLOPE_CEILING_ONLY:
						   {
						   if (skipFloor != 1) { RenderSourceOpenTile(x, y, t, Water, 0, SURFACE_FLOOR); }	//floor
						   if ((skipCeil != 1)) { RenderSourceValleyNWTile(x, y, t, Water, 1, SURFACE_CEIL); }
													  break;
						   }
						   }
						   return;
	}
	case TILE_VALLEY_NE:
	{	//valleyne(b)
						   switch (t.shockSlopeFlag)
						   {
						   case SLOPE_BOTH_PARALLEL:
						   {
						   if (skipFloor != 1) { RenderSourceValleyNETile(x, y, t, Water, 0, SURFACE_FLOOR); }//floor
						   if ((skipCeil != 1)) { RenderSourceValleyNETile(x, y, t, Water, 1, SURFACE_CEIL); }
							break;
						   }
						   case SLOPE_BOTH_OPPOSITE:
						   {
						   if (skipFloor != 1) { RenderSourceValleyNETile(x, y, t, Water, 0, SURFACE_FLOOR); }//floor
						   if ((skipCeil != 1)) { RenderSourceValleySWTile(x, y, t, Water, 1, SURFACE_CEIL); }
							break;
						   }
						   case SLOPE_FLOOR_ONLY:
						   {
						   if (skipFloor != 1) { RenderSourceValleyNETile(x, y, t, Water, 0, SURFACE_FLOOR); }//floor
						   if ((skipCeil != 1)) { RenderSourceOpenTile(x, y, t, Water, 1, SURFACE_CEIL); }	//ceiling
							break;
						   }
						   case SLOPE_CEILING_ONLY:
						   {
						   if (skipFloor != 1) { RenderSourceOpenTile(x, y, t, Water, 0, SURFACE_FLOOR); }//floor
						   if ((skipCeil != 1)) { RenderSourceValleyNETile(x, y, t, Water, 1, SURFACE_CEIL); }
								break;
						   }
						   }
						   return;
	}
	case TILE_VALLEY_SE:
	{	//valleyse(c)
						   switch (t.shockSlopeFlag)
						   {
						   case SLOPE_BOTH_PARALLEL:
						   {
						   if (skipFloor != 1) { RenderSourceValleySETile(x, y, t, Water, 0, SURFACE_FLOOR); }//floor
						   if ((skipCeil != 1)) { RenderSourceValleySETile(x, y, t, Water, 1, SURFACE_CEIL); }
													   break;
						   }
						   case SLOPE_BOTH_OPPOSITE:
						   {
						   if (skipFloor != 1) { RenderSourceValleySETile(x, y, t, Water, 0, SURFACE_FLOOR); }//floor
						   if ((skipCeil != 1)) { RenderSourceValleyNWTile(x, y, t, Water, 1, SURFACE_CEIL); }
													   break;
						   }
						   case SLOPE_FLOOR_ONLY:
						   {
						   if (skipFloor != 1) { RenderSourceValleySETile(x, y, t, Water, 0, SURFACE_FLOOR); }//floor
						   if ((skipCeil != 1)) { RenderSourceOpenTile(x, y, t, Water, 1, SURFACE_CEIL); }	//ceiling
													break;
						   }
						   case SLOPE_CEILING_ONLY:
						   {
						   if (skipFloor != 1) { RenderSourceOpenTile(x, y, t, Water, 0, SURFACE_FLOOR); }	//floor
						   if ((skipCeil != 1)) { RenderSourceValleySETile(x, y, t, Water, 1, SURFACE_CEIL); }
													  break;
						   }
						   }
						   return;
	}
	case TILE_VALLEY_SW:
	{	//valleysw(d)
						   switch (t.shockSlopeFlag)
						   {
						   case SLOPE_BOTH_PARALLEL:
						   {
						   if (skipFloor != 1) { RenderSourceValleySWTile(x, y, t, Water, 0, SURFACE_FLOOR); }//floor
						   if ((skipCeil != 1)) { RenderSourceValleySWTile(x, y, t, Water, 1, SURFACE_CEIL); }
													   break;
						   }
						   case SLOPE_BOTH_OPPOSITE:
						   {
						   if (skipFloor != 1) { RenderSourceValleySWTile(x, y, t, Water, 0, SURFACE_FLOOR); }//floor
						   if ((skipCeil != 1)) { RenderSourceValleyNETile(x, y, t, Water, 1, SURFACE_CEIL); }
													   break;
						   }
						   case SLOPE_FLOOR_ONLY:
						   {
						   if (skipFloor != 1) { RenderSourceValleySWTile(x, y, t, Water, 0, SURFACE_FLOOR); }//floor
						   if ((skipCeil != 1)) { RenderSourceOpenTile(x, y, t, Water, 1, SURFACE_CEIL); }	//ceiling
													break;
						   }
						   case SLOPE_CEILING_ONLY:
						   {
						   if (skipFloor != 1) { RenderSourceOpenTile(x, y, t, Water, 0, SURFACE_FLOOR); }	//floor
						   if ((skipCeil != 1)) { RenderSourceValleySWTile(x, y, t, Water, 1, SURFACE_CEIL); }
													  break;
						   }
						   }
						   return;
	}
	case TILE_RIDGE_SE:
	{	//ridge se(f)
						  switch (t.shockSlopeFlag)
						  {
						  case SLOPE_BOTH_PARALLEL:
						  {
						  if (skipFloor != 1) { RenderSourceRidgeSETile(x, y, t, Water, 0, SURFACE_FLOOR); }//floor
						  if ((skipCeil != 1)) { RenderSourceRidgeSETile(x, y, t, Water, 1, SURFACE_CEIL); }
													  break;
						  }
						  case SLOPE_BOTH_OPPOSITE:
						  {
						  if (skipFloor != 1) { RenderSourceRidgeSETile(x, y, t, Water, 0, SURFACE_FLOOR); }//floor
						  if ((skipCeil != 1)) { RenderSourceRidgeNWTile(x, y, t, Water, 1, SURFACE_CEIL); }
													  break;
						  }
						  case SLOPE_FLOOR_ONLY:
						  {
						  if (skipFloor != 1) { RenderSourceRidgeSETile(x, y, t, Water, 0, SURFACE_FLOOR); }//floor
						  if ((skipCeil != 1)) { RenderSourceOpenTile(x, y, t, Water, 1, SURFACE_CEIL); }	//ceiling
												   break;
						  }
						  case SLOPE_CEILING_ONLY:
						  {
						  if (skipFloor != 1) { RenderSourceOpenTile(x, y, t, Water, 0, SURFACE_FLOOR); }//floor
						  if ((skipCeil != 1)) { RenderSourceValleySETile(x, y, t, Water, 1, SURFACE_CEIL); }
													 break;
						  }
						  }
						  return;
	}
	case TILE_RIDGE_SW:
	{	//ridgesw(g)
						  switch (t.shockSlopeFlag)
						  {
						  case SLOPE_BOTH_PARALLEL:
						  {
						  if (skipFloor != 1) { RenderSourceRidgeSWTile(x, y, t, Water, 0, SURFACE_FLOOR); }//floor
						  if ((skipCeil != 1)) { RenderSourceRidgeSWTile(x, y, t, Water, 1, SURFACE_CEIL); }
													  break;
						  }
						  case SLOPE_BOTH_OPPOSITE:
						  {
						  if (skipFloor != 1) { RenderSourceRidgeSWTile(x, y, t, Water, 0, SURFACE_FLOOR); }//floor
						  if ((skipCeil != 1)) { RenderSourceRidgeNETile(x, y, t, Water, 1, SURFACE_CEIL); }
													  break;
						  }
						  case SLOPE_FLOOR_ONLY:
						  {
						  if (skipFloor != 1) { RenderSourceRidgeSWTile(x, y, t, Water, 0, SURFACE_FLOOR); }//floor
						  if ((skipCeil != 1)) { RenderSourceOpenTile(x, y, t, Water, 1, SURFACE_CEIL); }	//ceiling
												   break;
						  }
						  case SLOPE_CEILING_ONLY:
						  {
						  if (skipFloor != 1) { RenderSourceOpenTile(x, y, t, Water, 0, SURFACE_FLOOR); }	//floor
						  if ((skipCeil != 1)) { RenderSourceValleySWTile(x, y, t, Water, 1, SURFACE_CEIL); }
													 break;
						  }
						  }
						  return;
	}
	case TILE_RIDGE_NW:
	{	//ridgenw(h)
						  switch (t.shockSlopeFlag)
						  {
						  case SLOPE_BOTH_PARALLEL:
						  {
						  if (skipFloor != 1) { RenderSourceRidgeNWTile(x, y, t, Water, 0, SURFACE_FLOOR); }//floor
						  if ((skipCeil != 1)) { RenderSourceRidgeNWTile(x, y, t, Water, 1, SURFACE_CEIL); }
													  break;
						  }
						  case SLOPE_BOTH_OPPOSITE:
						  {
						  if (skipFloor != 1) { RenderSourceRidgeNWTile(x, y, t, Water, 0, SURFACE_FLOOR); }//floor
						  if ((skipCeil != 1)) { RenderSourceRidgeSETile(x, y, t, Water, 1, SURFACE_CEIL); }
													  break;
						  }
						  case SLOPE_FLOOR_ONLY:
						  {
						  if (skipFloor != 1) { RenderSourceRidgeNWTile(x, y, t, Water, 0, SURFACE_FLOOR); }//floor
						  if ((skipCeil != 1)) { RenderSourceOpenTile(x, y, t, Water, 1, SURFACE_CEIL); }	//ceiling
												   break;
						  }
						  case SLOPE_CEILING_ONLY:
						  {
						  if (skipFloor != 1) { RenderSourceOpenTile(x, y, t, Water, 0, SURFACE_FLOOR); }	//floor
						  if ((skipCeil != 1)) { RenderSourceValleyNWTile(x, y, t, Water, 1, SURFACE_CEIL); }
													 break;
						  }
						  }
						  return;
	}
	case TILE_RIDGE_NE:
	{	//ridgene(i)
						  switch (t.shockSlopeFlag)
						  {
						  case SLOPE_BOTH_PARALLEL:
						  {
						  if (skipFloor != 1) { RenderSourceRidgeNETile(x, y, t, Water, 0, SURFACE_FLOOR); }//floor
						  if ((skipCeil != 1)) { RenderSourceRidgeNETile(x, y, t, Water, 1, SURFACE_CEIL); }
													  break;
						  }
						  case SLOPE_BOTH_OPPOSITE:
						  {
						  if (skipFloor != 1) { RenderSourceRidgeNETile(x, y, t, Water, 0, SURFACE_FLOOR); }//floor
						  if ((skipCeil != 1)) { RenderSourceRidgeSWTile(x, y, t, Water, 1, SURFACE_CEIL); }
													  break;
						  }
						  case SLOPE_FLOOR_ONLY:
						  {
						  if (skipFloor != 1) { RenderSourceRidgeNETile(x, y, t, Water, 0, SURFACE_FLOOR); }//floor
						  if ((skipCeil != 1)) { RenderSourceOpenTile(x, y, t, Water, 1, SURFACE_CEIL); }	//ceiling
												   break;
						  }
						  case SLOPE_CEILING_ONLY:
						  {
						  if (skipFloor != 1) { RenderSourceOpenTile(x, y, t, Water, 0, SURFACE_FLOOR); }	//floor
						  if ((skipCeil != 1)) { RenderSourceValleyNETile(x, y, t, Water, 1, SURFACE_CEIL); }
													 break;
						  }
						  }
						  return;
	}
	}
	////////case 2:
	////////{//diag se
	////////		  if (skipFloor != 1) { RenderDiagSETile(x, y, t, Water, 0); }//floor
	////////		  if ((skipCeil != 1)) { RenderDiagSETile(x, y, t, Water, 1); }
	////////		  return;
	////////}
	////////case 3:
	////////{	//diag sw
	////////		  if (skipFloor != 1) { RenderDiagSWTile(x, y, t, Water, 0); }//floor
	////////		  if ((skipCeil != 1)) { RenderDiagSWTile(x, y, t, Water, 1); }
	////////		  return;
	////////}
	////////case 4:
	////////{	//diag ne
	////////		  if (skipFloor != 1) { RenderDiagNETile(x, y, t, Water, invert); }//floor
	////////		  if ((skipCeil != 1)) { RenderDiagNETile(x, y, t, Water, 1); }
	////////		  return;
	////////}
	////////case 5:
	////////{//diag nw
	////////		  if (skipFloor != 1) { RenderDiagNWTile(x, y, t, Water, invert); }//floor
	////////		  if ((skipCeil != 1)) { RenderDiagNWTile(x, y, t, Water, 1); }
	////////		  return;
	////////}
	////////case TILE_SLOPE_N:	//6
	////////{//slope n
	////////						switch (t.shockSlopeFlag)
	////////						{
	////////						case SLOPE_BOTH_PARALLEL:
	////////						{
	////////													if (skipFloor != 1) { RenderSlopeNTile(x, y, t, Water, 0); }//floor
	////////													if ((skipCeil != 1)) { RenderSlopeNTile(x, y, t, Water, 1); }
	////////													break;
	////////						}
	////////						case SLOPE_BOTH_OPPOSITE:
	////////						{
	////////													if (skipFloor != 1) { RenderSlopeNTile(x, y, t, Water, 0); }//floor
	////////													if ((skipCeil != 1)) { RenderSlopeSTile(x, y, t, Water, 1); }
	////////													break;
	////////						}
	////////						case SLOPE_FLOOR_ONLY:
	////////						{
	////////												 if (skipFloor != 1) { RenderSlopeNTile(x, y, t, Water, 0); }//floor
	////////												 if ((skipCeil != 1)) { RenderOpenTile(x, y, t, Water, 1); }	//ceiling
	////////												 break;
	////////						}
	////////						case SLOPE_CEILING_ONLY:
	////////						{
	////////												   if (skipFloor != 1) { RenderOpenTile(x, y, t, Water, 0); }	//floor
	////////												   RenderSlopeNTile(x, y, t, Water, 1);
	////////												   break;
	////////						}
	////////						}
	////////						return;
	////////}
	////////case TILE_SLOPE_S: //slope s	7
	////////{
	////////					   switch (t.shockSlopeFlag)
	////////					   {
	////////					   case SLOPE_BOTH_PARALLEL:
	////////					   {
	////////												   if (skipFloor != 1) { RenderSlopeSTile(x, y, t, Water, 0); }	//floor
	////////												   RenderSlopeSTile(x, y, t, Water, 1);
	////////												   break;
	////////					   }
	////////					   case SLOPE_BOTH_OPPOSITE:
	////////					   {
	////////												   if (skipFloor != 1) { RenderSlopeSTile(x, y, t, Water, 0); }	//floor
	////////												   RenderSlopeNTile(x, y, t, Water, 1);
	////////												   break;
	////////					   }
	////////					   case SLOPE_FLOOR_ONLY:
	////////					   {
	////////												if (skipFloor != 1) { RenderSlopeSTile(x, y, t, Water, 0); }	//floor
	////////												if ((skipCeil != 1)) { RenderOpenTile(x, y, t, Water, 1); }	//ceiling
	////////												break;
	////////					   }
	////////					   case SLOPE_CEILING_ONLY:
	////////					   {
	////////												  if (skipFloor != 1) { RenderOpenTile(x, y, t, Water, 0); }	//floor
	////////												  if ((skipCeil != 1)) { RenderSlopeSTile(x, y, t, Water, 1); }
	////////												  break;
	////////					   }
	////////					   }
	////////					   return;
	////////}
	////////case TILE_SLOPE_E:		//slope e 8	
	////////{
	////////							switch (t.shockSlopeFlag)
	////////							{
	////////							case SLOPE_BOTH_PARALLEL:
	////////							{
	////////														if (skipFloor != 1) { RenderSlopeETile(x, y, t, Water, 0); }//floor
	////////														RenderSlopeETile(x, y, t, Water, 1);
	////////														break;
	////////							}
	////////							case SLOPE_BOTH_OPPOSITE:
	////////							{
	////////														if (skipFloor != 1) { RenderSlopeETile(x, y, t, Water, 0); }//floor
	////////														RenderSlopeWTile(x, y, t, Water, 1);
	////////														break;
	////////							}
	////////							case SLOPE_FLOOR_ONLY:
	////////							{
	////////													 if (skipFloor != 1) { RenderSlopeETile(x, y, t, Water, 0); }//floor
	////////													 if ((skipCeil != 1)) { RenderOpenTile(x, y, t, Water, 1); }	//ceiling
	////////													 break;
	////////							}
	////////							case SLOPE_CEILING_ONLY:
	////////							{
	////////													   if (skipFloor != 1) { RenderOpenTile(x, y, t, Water, 0); }	//floor
	////////													   if ((skipCeil != 1)) { RenderSlopeETile(x, y, t, Water, 1); }
	////////													   break;
	////////							}
	////////							}
	////////							return;
	////////}
	////////case TILE_SLOPE_W: 	//9
	////////{ //slope w
	////////						switch (t.shockSlopeFlag)
	////////						{
	////////						case SLOPE_BOTH_PARALLEL:
	////////						{
	////////													if (skipFloor != 1) { RenderSlopeWTile(x, y, t, Water, 0); }//floor
	////////													if ((skipCeil != 1)) { RenderSlopeWTile(x, y, t, Water, 1); }
	////////													break;
	////////						}
	////////						case SLOPE_BOTH_OPPOSITE:
	////////						{
	////////													if (skipFloor != 1) { RenderSlopeWTile(x, y, t, Water, 0); }//floor
	////////													if ((skipCeil != 1)) { RenderSlopeETile(x, y, t, Water, 1); }
	////////													break;
	////////						}
	////////						case SLOPE_FLOOR_ONLY:
	////////						{
	////////												 if (skipFloor != 1) { RenderSlopeWTile(x, y, t, Water, 0); }//floor
	////////												 if ((skipCeil != 1)) { RenderOpenTile(x, y, t, Water, 1); }	//ceiling
	////////												 break;
	////////						}
	////////						case SLOPE_CEILING_ONLY:
	////////						{
	////////												   if (skipFloor != 1) { RenderOpenTile(x, y, t, Water, 0); }	//floor
	////////												   if ((skipCeil != 1)) { RenderSlopeWTile(x, y, t, Water, 1); }
	////////												   break;
	////////						}
	////////						}
	////////						return;
	////////}
	////////case TILE_VALLEY_NW:
	////////{	//valleyNw(a)
	////////					   switch (t.shockSlopeFlag)
	////////					   {
	////////					   case SLOPE_BOTH_PARALLEL:
	////////					   {
	////////												   if (skipFloor != 1) { RenderValleyNWTile(x, y, t, Water, 0); }//floor
	////////												   if ((skipCeil != 1)) { RenderValleyNWTile(x, y, t, Water, 1); }
	////////												   break;
	////////					   }
	////////					   case SLOPE_BOTH_OPPOSITE:
	////////					   {
	////////												   if (skipFloor != 1) { RenderValleyNWTile(x, y, t, Water, 0); }//floor
	////////												   if ((skipCeil != 1)) { RenderValleySETile(x, y, t, Water, 1); }
	////////												   break;
	////////					   }
	////////					   case SLOPE_FLOOR_ONLY:
	////////					   {
	////////												if (skipFloor != 1) { RenderValleyNWTile(x, y, t, Water, 0); }//floor
	////////												if ((skipCeil != 1)) { RenderOpenTile(x, y, t, Water, 1); }	//ceiling
	////////												break;
	////////					   }
	////////					   case SLOPE_CEILING_ONLY:
	////////					   {
	////////												  if (skipFloor != 1) { RenderOpenTile(x, y, t, Water, 0); }	//floor
	////////												  if ((skipCeil != 1)) { RenderValleyNWTile(x, y, t, Water, 1); }
	////////												  break;
	////////					   }
	////////					   }
	////////					   return;
	////////}
	////////case TILE_VALLEY_NE:
	////////{	//valleyne(b)
	////////					   switch (t.shockSlopeFlag)
	////////					   {
	////////					   case SLOPE_BOTH_PARALLEL:
	////////					   {
	////////												   if (skipFloor != 1) { RenderValleyNETile(x, y, t, Water, 0); }//floor
	////////												   if ((skipCeil != 1)) { RenderValleyNETile(x, y, t, Water, 1); }
	////////												   break;
	////////					   }
	////////					   case SLOPE_BOTH_OPPOSITE:
	////////					   {
	////////												   if (skipFloor != 1) { RenderValleyNETile(x, y, t, Water, 0); }//floor
	////////												   if ((skipCeil != 1)) { RenderValleySWTile(x, y, t, Water, 1); }
	////////												   break;
	////////					   }
	////////					   case SLOPE_FLOOR_ONLY:
	////////					   {
	////////												if (skipFloor != 1) { RenderValleyNETile(x, y, t, Water, 0); }//floor
	////////												if ((skipCeil != 1)) { RenderOpenTile(x, y, t, Water, 1); }	//ceiling
	////////												break;
	////////					   }
	////////					   case SLOPE_CEILING_ONLY:
	////////					   {
	////////												  if (skipFloor != 1) { RenderOpenTile(x, y, t, Water, 0); }//floor
	////////												  if ((skipCeil != 1)) { RenderValleyNETile(x, y, t, Water, 1); }
	////////												  break;
	////////					   }
	////////					   }
	////////					   return;
	////////}
	////////case TILE_VALLEY_SE:
	////////{	//valleyse(c)
	////////					   switch (t.shockSlopeFlag)
	////////					   {
	////////					   case SLOPE_BOTH_PARALLEL:
	////////					   {
	////////												   if (skipFloor != 1) { RenderValleySETile(x, y, t, Water, 0); }//floor
	////////												   if ((skipCeil != 1)) { RenderValleySETile(x, y, t, Water, 1); }
	////////												   break;
	////////					   }
	////////					   case SLOPE_BOTH_OPPOSITE:
	////////					   {
	////////												   if (skipFloor != 1) { RenderValleySETile(x, y, t, Water, 0); }//floor
	////////												   if ((skipCeil != 1)) { RenderValleyNWTile(x, y, t, Water, 1); }
	////////												   break;
	////////					   }
	////////					   case SLOPE_FLOOR_ONLY:
	////////					   {
	////////												if (skipFloor != 1) { RenderValleySETile(x, y, t, Water, 0); }//floor
	////////												if ((skipCeil != 1)) { RenderOpenTile(x, y, t, Water, 1); }	//ceiling
	////////												break;
	////////					   }
	////////					   case SLOPE_CEILING_ONLY:
	////////					   {
	////////												  if (skipFloor != 1) { RenderOpenTile(x, y, t, Water, 0); }	//floor
	////////												  if ((skipCeil != 1)) { RenderValleySETile(x, y, t, Water, 1); }
	////////												  break;
	////////					   }
	////////					   }
	////////					   return;
	////////}
	////////case TILE_VALLEY_SW:
	////////{	//valleysw(d)
	////////					   switch (t.shockSlopeFlag)
	////////					   {
	////////					   case SLOPE_BOTH_PARALLEL:
	////////					   {
	////////												   if (skipFloor != 1) { RenderValleySWTile(x, y, t, Water, 0); }//floor
	////////												   if ((skipCeil != 1)) { RenderValleySWTile(x, y, t, Water, 1); }
	////////												   break;
	////////					   }
	////////					   case SLOPE_BOTH_OPPOSITE:
	////////					   {
	////////												   if (skipFloor != 1) { RenderValleySWTile(x, y, t, Water, 0); }//floor
	////////												   if ((skipCeil != 1)) { RenderValleyNETile(x, y, t, Water, 1); }
	////////												   break;
	////////					   }
	////////					   case SLOPE_FLOOR_ONLY:
	////////					   {
	////////												if (skipFloor != 1) { RenderValleySWTile(x, y, t, Water, 0); }//floor
	////////												if ((skipCeil != 1)) { RenderOpenTile(x, y, t, Water, 1); }	//ceiling
	////////												break;
	////////					   }
	////////					   case SLOPE_CEILING_ONLY:
	////////					   {
	////////												  if (skipFloor != 1) { RenderOpenTile(x, y, t, Water, 0); }	//floor
	////////												  if ((skipCeil != 1)) { RenderValleySWTile(x, y, t, Water, 1); }
	////////												  break;
	////////					   }
	////////					   }
	////////					   return;
	////////}
	////////case TILE_RIDGE_SE:
	////////{	//ridge se(f)
	////////					  switch (t.shockSlopeFlag)
	////////					  {
	////////					  case SLOPE_BOTH_PARALLEL:
	////////					  {
	////////												  if (skipFloor != 1) { RenderRidgeSETile(x, y, t, Water, 0); }//floor
	////////												  if ((skipCeil != 1)) { RenderRidgeSETile(x, y, t, Water, 1); }
	////////												  break;
	////////					  }
	////////					  case SLOPE_BOTH_OPPOSITE:
	////////					  {
	////////												  if (skipFloor != 1) { RenderRidgeSETile(x, y, t, Water, 0); }//floor
	////////												  if ((skipCeil != 1)) { RenderRidgeNWTile(x, y, t, Water, 1); }
	////////												  break;
	////////					  }
	////////					  case SLOPE_FLOOR_ONLY:
	////////					  {
	////////											   if (skipFloor != 1) { RenderRidgeSETile(x, y, t, Water, 0); }//floor
	////////											   if ((skipCeil != 1)) { RenderOpenTile(x, y, t, Water, 1); }	//ceiling
	////////											   break;
	////////					  }
	////////					  case SLOPE_CEILING_ONLY:
	////////					  {
	////////												 if (skipFloor != 1) { RenderOpenTile(x, y, t, Water, 0); }//floor
	////////												 if ((skipCeil != 1)) { RenderValleySETile(x, y, t, Water, 1); }
	////////												 break;
	////////					  }
	////////					  }
	////////					  return;
	////////}
	////////case TILE_RIDGE_SW:
	////////{	//ridgesw(g)
	////////					  switch (t.shockSlopeFlag)
	////////					  {
	////////					  case SLOPE_BOTH_PARALLEL:
	////////					  {
	////////												  if (skipFloor != 1) { RenderRidgeSWTile(x, y, t, Water, 0); }//floor
	////////												  if ((skipCeil != 1)) { RenderRidgeSWTile(x, y, t, Water, 1); }
	////////												  break;
	////////					  }
	////////					  case SLOPE_BOTH_OPPOSITE:
	////////					  {
	////////												  if (skipFloor != 1) { RenderRidgeSWTile(x, y, t, Water, 0); }//floor
	////////												  if ((skipCeil != 1)) { RenderRidgeNETile(x, y, t, Water, 1); }
	////////												  break;
	////////					  }
	////////					  case SLOPE_FLOOR_ONLY:
	////////					  {
	////////											   if (skipFloor != 1) { RenderRidgeSWTile(x, y, t, Water, 0); }//floor
	////////											   if ((skipCeil != 1)) { RenderOpenTile(x, y, t, Water, 1); }	//ceiling
	////////											   break;
	////////					  }
	////////					  case SLOPE_CEILING_ONLY:
	////////					  {
	////////												 if (skipFloor != 1) { RenderOpenTile(x, y, t, Water, 0); }	//floor
	////////												 if ((skipCeil != 1)) { RenderValleySWTile(x, y, t, Water, 1); }
	////////												 break;
	////////					  }
	////////					  }
	////////					  return;
	////////}
	////////case TILE_RIDGE_NW:
	////////{	//ridgenw(h)
	////////					  switch (t.shockSlopeFlag)
	////////					  {
	////////					  case SLOPE_BOTH_PARALLEL:
	////////					  {
	////////												  if (skipFloor != 1) { RenderRidgeNWTile(x, y, t, Water, 0); }//floor
	////////												  if ((skipCeil != 1)) { RenderRidgeNWTile(x, y, t, Water, 1); }
	////////												  break;
	////////					  }
	////////					  case SLOPE_BOTH_OPPOSITE:
	////////					  {
	////////												  if (skipFloor != 1) { RenderRidgeNWTile(x, y, t, Water, 0); }//floor
	////////												  if ((skipCeil != 1)) { RenderRidgeSETile(x, y, t, Water, 1); }
	////////												  break;
	////////					  }
	////////					  case SLOPE_FLOOR_ONLY:
	////////					  {
	////////											   if (skipFloor != 1) { RenderRidgeNWTile(x, y, t, Water, 0); }//floor
	////////											   if ((skipCeil != 1)) { RenderOpenTile(x, y, t, Water, 1); }	//ceiling
	////////											   break;
	////////					  }
	////////					  case SLOPE_CEILING_ONLY:
	////////					  {
	////////												 if (skipFloor != 1) { RenderOpenTile(x, y, t, Water, 0); }	//floor
	////////												 if ((skipCeil != 1)) { RenderValleyNWTile(x, y, t, Water, 1); }
	////////												 break;
	////////					  }
	////////					  }
	////////					  return;
	////////}
	////////case TILE_RIDGE_NE:
	////////{	//ridgene(i)
	////////					  switch (t.shockSlopeFlag)
	////////					  {
	////////					  case SLOPE_BOTH_PARALLEL:
	////////					  {
	////////												  if (skipFloor != 1) { RenderRidgeNETile(x, y, t, Water, 0); }//floor
	////////												  if ((skipCeil != 1)) { RenderRidgeNETile(x, y, t, Water, 1); }
	////////												  break;
	////////					  }
	////////					  case SLOPE_BOTH_OPPOSITE:
	////////					  {
	////////												  if (skipFloor != 1) { RenderRidgeNETile(x, y, t, Water, 0); }//floor
	////////												  if ((skipCeil != 1)) { RenderRidgeSWTile(x, y, t, Water, 1); }
	////////												  break;
	////////					  }
	////////					  case SLOPE_FLOOR_ONLY:
	////////					  {
	////////											   if (skipFloor != 1) { RenderRidgeNETile(x, y, t, Water, 0); }//floor
	////////											   if ((skipCeil != 1)) { RenderOpenTile(x, y, t, Water, 1); }	//ceiling
	////////											   break;
	////////					  }
	////////					  case SLOPE_CEILING_ONLY:
	////////					  {
	////////												 if (skipFloor != 1) { RenderOpenTile(x, y, t, Water, 0); }	//floor
	////////												 if ((skipCeil != 1)) { RenderValleyNETile(x, y, t, Water, 1); }
	////////												 break;
	////////					  }
	////////					  }
	////////					  return;
	////////}
}

void RenderSourceSolidTile(int x, int y, tile &t, short Water)
{
	if (t.Render == 1){
		if (t.isWater == Water)
		{
///////*			fprintf(MAPFILE, "\tsolid\n");
//////			fprintf(MAPFILE, "\t{\n");
//////			fprin*/tf(MAPFILE, "\t\t\"id\" \"%d\"\n",PrimitiveCount++);
		    StoreTileName(x, y, SURFACE_WALL, 0);
			RenderSourceCuboid(x,y,t,Water,-2,CEILING_HEIGHT+1,SURFACE_WALL);
//////			//Plane goes here Points are clockwise as you face the plane
//////			//East Face
//////			int BLeftX = t.tileX*BrushSizeX+t.DimX*BrushSizeX;
//////			int BLeftY = t.tileY*BrushSizeY;
//////			int BLeftZ = 0;
//////			int TLeftX = t.tileX*BrushSizeX + t.DimX*BrushSizeX;
//////			int TLeftY = t.tileY*BrushSizeY;
//////			int TLeftZ = (CEILING_HEIGHT + 1)*BrushSizeZ;
//////			int TRightX = t.tileX*BrushSizeX + t.DimX*BrushSizeX;
//////			int TRightY = t.tileY*BrushSizeY+t.DimY*BrushSizeY;
//////			int TRightZ = (CEILING_HEIGHT+1)*BrushSizeZ;
//////			Plane(1, fEAST, BLeftX, BLeftY, BLeftZ, TLeftX, TLeftY, TLeftZ, TRightX, TRightY, TRightZ, t);
//////
//////			//North Face
//////			BLeftX = t.tileX*BrushSizeX+t.DimX*BrushSizeX;
//////			BLeftY = t.tileY*BrushSizeY+t.DimY*BrushSizeY;
//////			BLeftZ = 0;
//////			TLeftX = t.tileX*BrushSizeX + t.DimX*BrushSizeX;
//////			TLeftY = t.tileY*BrushSizeY + t.DimY*BrushSizeY;
//////			TLeftZ = (CEILING_HEIGHT + 1)*BrushSizeZ;
//////			TRightX = t.tileX*BrushSizeX;
//////			TRightY = t.tileY*BrushSizeY + t.DimY*BrushSizeY;
//////			TRightZ = (CEILING_HEIGHT + 1)*BrushSizeZ;
//////			Plane(2, fNORTH, BLeftX, BLeftY, BLeftZ, TLeftX, TLeftY, TLeftZ, TRightX, TRightY, TRightZ, t);
//////
//////			//top Face
//////			BLeftX = t.tileX*BrushSizeX;
//////			BLeftY = t.tileY*BrushSizeY;
//////			BLeftZ = (CEILING_HEIGHT + 1)*BrushSizeZ;
//////			TLeftX = t.tileX*BrushSizeX;
//////			TLeftY = t.tileY*BrushSizeY + t.DimY*BrushSizeY;
//////			TLeftZ = (CEILING_HEIGHT + 1)*BrushSizeZ;
//////			TRightX = t.tileX*BrushSizeX + t.DimX+BrushSizeX;
//////			TRightY = t.tileY*BrushSizeY + t.DimY*BrushSizeY;
//////			TRightZ = (CEILING_HEIGHT + 1)*BrushSizeZ;
//////			Plane(3, fTOP, BLeftX, BLeftY, BLeftZ, TLeftX, TLeftY, TLeftZ, TRightX, TRightY, TRightZ, t);
//////
//////			//west Face
//////			BLeftX = t.tileX*BrushSizeX;
//////			BLeftY = t.tileY*BrushSizeY+t.DimY*BrushSizeY;
//////			BLeftZ = 0;
//////			TLeftX = t.tileX*BrushSizeX;
//////			TLeftY = t.tileY*BrushSizeY + t.DimY*BrushSizeY;
//////			TLeftZ = (CEILING_HEIGHT + 1)*BrushSizeZ;
//////			TRightX = t.tileX*BrushSizeX;
//////			TRightY = t.tileY*BrushSizeY ;
//////			TRightZ = (CEILING_HEIGHT + 1)*BrushSizeZ;
//////			Plane(4,fWEST,BLeftX, BLeftY, BLeftZ,TLeftX, TLeftY, TLeftZ,TRightX, TRightY, TRightZ,t);
//////
////////South face
//////			BLeftX = t.tileX*BrushSizeX;
//////			BLeftY = t.tileY*BrushSizeY;
//////			BLeftZ = 0;
//////			TLeftX = t.tileX*BrushSizeX;
//////			TLeftY = t.tileY*BrushSizeY;
//////			TLeftZ = (CEILING_HEIGHT + 1)*BrushSizeZ;
//////			TRightX = t.tileX*BrushSizeX+t.DimX*BrushSizeX;
//////			TRightY = t.tileY*BrushSizeY;
//////			TRightZ = (CEILING_HEIGHT + 1)*BrushSizeZ;
//////			Plane(5, fSOUTH, BLeftX, BLeftY, BLeftZ, TLeftX, TLeftY, TLeftZ, TRightX, TRightY, TRightZ, t);
//////
//////			//South face
//////			BLeftX = t.tileX*BrushSizeX;
//////			BLeftY = t.tileY*BrushSizeY;
//////			BLeftZ = 0;
//////			TLeftX = t.tileX*BrushSizeX;
//////			TLeftY = t.tileY*BrushSizeY;
//////			TLeftZ = (CEILING_HEIGHT + 1)*BrushSizeZ;
//////			TRightX = t.tileX*BrushSizeX + t.DimX*BrushSizeX;
//////			TRightY = t.tileY*BrushSizeY;
//////			TRightZ = (CEILING_HEIGHT + 1)*BrushSizeZ;
//////			Plane(5, fSOUTH, BLeftX, BLeftY, BLeftZ, TLeftX, TLeftY, TLeftZ, TRightX, TRightY, TRightZ, t);
//////
//////
//////			//bottom face
//////			BLeftX = t.tileX*BrushSizeX;
//////			BLeftY = t.tileY*BrushSizeY + t.DimY*BrushSizeY;
//////			BLeftZ = 0;
//////			TLeftX = t.tileX*BrushSizeX;
//////			TLeftY = t.tileY*BrushSizeY;
//////			TLeftZ = 0;
//////			TRightX = t.tileX*BrushSizeX+t.DimX*BrushSizeX;
//////			TRightY = t.tileY*BrushSizeY;
//////			TRightZ = 0;
//////			Plane(6, fSOUTH, BLeftX, BLeftY, BLeftZ, TLeftX, TLeftY, TLeftZ, TRightX, TRightY, TRightZ, t);
//////
//////
//////			//fprintf(MAPFILE, "\t\t}\n");
//////			fprintf(MAPFILE, "\t}\n");
		}
	}
	return;
}

void Plane(int index, int face, int BLeftX, int BLeftY, int BLeftZ, int TLeftX, int TLeftY, int TLeftZ, int TRightX, int TRightY, int TRightZ, tile t, int surface)
	{
	fprintf(MAPFILE, "\t\tside\n");
	fprintf(MAPFILE, "\t\t{\n");
	fprintf(MAPFILE, "\t\t\t\"id\" \"%d\"\n", index);
	fprintf(MAPFILE, "\t\t\t\"plane\" \"");
	fprintf(MAPFILE, "(%d %d %d) ", BLeftX, BLeftY, BLeftZ);
	fprintf(MAPFILE, "(%d %d %d) ", TLeftX, TLeftY, TLeftZ);
	fprintf(MAPFILE, "(%d %d %d)\" \n", TRightX, TRightY, TRightZ);
	switch (surface)
	{
	case SURFACE_CEIL:
	case SURFACE_FLOOR:
	case SURFACE_SLOPE:
		//fprintf(MAPFILE, "\t\t\t\"material\" \"BRICK/BRICKFLOOR001A\"\n");
		//fprintf(MAPFILE, "\t\t\t\"uaxis\" \"[1 0 0 0] 0.25\"\n");
		//fprintf(MAPFILE, "\t\t\t\"vaxis\" \"[0 -1 0 0] 0.25\"\n");
		FloorTexture(face,t);
		break;
	case SURFACE_WALL:
		WallTexture(face, t);
		//fprintf(MAPFILE, "\t\t\t\"material\" \"BRICK/BRICKWALL001A\"\n");
		//fprintf(MAPFILE, "\t\t\t\"uaxis\" \"[0 1 0 0] 0.25\"\n");
		//fprintf(MAPFILE, "\t\t\t\"vaxis\" \"[0 0 -1 0] 0.25\"\n");
		break;

	}
	fprintf(MAPFILE, "\t\t\t\"rotation\" \"0\"\n");
	fprintf(MAPFILE, "\t\t\t\"lightmapscale\" \"16\"\n");
	fprintf(MAPFILE, "\t\t\t\"smoothing_groups\" \"0\"\n");
	fprintf(MAPFILE, "\t\t\}\n");
	}

void WallTexture(int face, tile t)
{
float Reverse=1;
int wallTexture;
float uAx_1=0;
float uAx_2=1;
float uAx_3=0;
float uAx_4=0;
float vAx_1=0;
float vAx_2=0;
float vAx_3=-1;
float vAx_4=0;
//int textureOffset = 1;
int ceilOffset = 0;
	wallTexture=t.wallTexture;
	if (iGame == SHOCK)
		{ //I need to calculate an offset for SHOCK.
		ceilOffset = t.ceilingHeight;
		}

	switch (face)
		{
		case fSOUTH:
			wallTexture = t.South;
			if ((iGame == SHOCK))
				{
				ceilOffset = t.shockSouthCeilHeight;
				}
			//fprintf(MAPFILE, "\t\t\t\"material\" \"BRICK/BRICKWALL009A\"\n");
			uAx_1 = 1;
			uAx_2 = 0;
			uAx_3 = 0;
			uAx_4 = 0;
			vAx_1 = 0;
			vAx_2 = 0;
			vAx_3 = -1;
			vAx_4 = 0;
			break;
		case fNORTH:
			wallTexture = t.North;
			if ((iGame == SHOCK))
				{
				ceilOffset = t.shockNorthCeilHeight;
				}
			//fprintf(MAPFILE, "\t\t\t\"material\" \"BRICK/BRICKWALL014D\"\n");
			//fprintf(MAPFILE, "\t\t\t\"material\" \"BRICK/BRICKWALL009A\"\n");
			uAx_1 = -1;
			uAx_2 = 0;
			uAx_3 = 0;
			uAx_4 = 0;
			vAx_1 = 0;
			vAx_2 = 0;
			vAx_3 = -1;
			vAx_4 = 0;
			break;
		case fEAST:
			wallTexture = t.East;
			if ((iGame == SHOCK))
				{
				ceilOffset = t.shockEastCeilHeight;
				}
			//fprintf(MAPFILE, "\t\t\t\"material\" \"BRICK/BRICKWALL034D\"\n");
			//fprintf(MAPFILE, "\t\t\t\"material\" \"BRICK/BRICKWALL009A\"\n");
			uAx_1 = 0;
			uAx_2 = 1;
			uAx_3 = 0;
			uAx_4 = 0;
			vAx_1 = 0;
			vAx_2 = 0;
			vAx_3 = -1;
			vAx_4 = 0;
			break;
		case fWEST:
			wallTexture = t.West;
			if ((iGame == SHOCK))
				{
				ceilOffset = t.shockWestCeilHeight;
				}
			//fprintf(MAPFILE, "\t\t\t\"material\" \"BRICK/BRICKWALL045i\"\n");
			//fprintf(MAPFILE, "\t\t\t\"material\" \"BRICK/BRICKWALL009A\"\n");
			uAx_1 = 0;
			uAx_2 = -1;
			uAx_3 = 0;
			uAx_4 = 0;
			vAx_1 = 0;
			vAx_2 = 0;
			vAx_3 = -1;
			vAx_4 = 0;
			break;
		case fSELF:
			{
			if ((t.tileType == TILE_DIAG_SW) || (t.tileType == TILE_DIAG_NW))
				{
				Reverse=-1;
				}
			}
		}
	if ((wallTexture<0) || (wallTexture >512))
		{
		wallTexture=0;
		}

	if (iGame == SHOCK)
		{
		float shock_ceil = SHOCK_CEILING_HEIGHT;
		float floorOffset = shock_ceil - ceilOffset - 8;	//The floor of the tile if it is 1 texture tall.
		while (floorOffset >= 8)	//Reduce the offset to 0 to 7 since textures go up in steps of 1/8ths
			{
			floorOffset -= 8;
			}
		vAx_4 = (floorOffset)* 16;
		}
		



	fprintf(MAPFILE, "\t\t\t\"material\" \"%s\"\n", textureMasters[wallTexture].path);
	fprintf(MAPFILE, "\t\t\t\"uaxis\" \"[%f %f %f %f] %f\"\n", uAx_1, uAx_2, uAx_3, uAx_4, Reverse*0.9375);
	fprintf(MAPFILE, "\t\t\t\"vaxis\" \"[%f %f %f %f] %f\"\n", vAx_1, vAx_2, vAx_3, vAx_4, 0.9375);
}

void FloorTexture(int face, tile t)
{
int floorTexture;

if (face == fCEIL)
	{
		floorTexture = t.shockCeilingTexture;
	}
else
	{
		floorTexture = t.floorTexture;
	}

if ((floorTexture<0) || (floorTexture >512))
	{
		floorTexture = 0;
	}

	fprintf(MAPFILE, "\t\t\t\"material\" \"%s\"\n", textureMasters[floorTexture].path);
	fprintf(MAPFILE, "\t\t\t\"uaxis\" \"[1 0 0 0] 0.9375\"\n");
	fprintf(MAPFILE, "\t\t\t\"vaxis\" \"[0 -1 0 0] 0.9375\"\n");
}

void RenderSourceOpenTile(int x, int y, tile &t, short Water, short invert,int surface)
{
	if (t.Render == 1){
		if (t.isWater == Water)
		{
			if (invert == 0)
			{
				//Bottom face 
				if ((t.hasElevator == 0))
				{
					if (t.BullFrog >0)
					{
					    StoreTileName(x, y, SURFACE_FLOOR,0);
						RenderSourceCuboid(x,y,t,Water,-16,t.floorHeight,SURFACE_FLOOR);
					}
					else
					{
					    StoreTileName(x, y, SURFACE_FLOOR, 0);
						RenderSourceCuboid(x, y, t, Water, -2, t.floorHeight, SURFACE_FLOOR);
					}

				}
				else
				{
				   StoreTileName(x, y, SURFACE_FLOOR, 0);
				   RenderSourceCuboid(x, y, t, Water, -8, t.floorHeight, SURFACE_FLOOR);
				}

			}
			else
			{
			    StoreTileName(x, y, SURFACE_CEIL, 0);
				//Ceiling version of the tile
				RenderSourceCuboid(x, y, t, Water, CEILING_HEIGHT - t.ceilingHeight, CEILING_HEIGHT + 1, SURFACE_CEIL);
			}
		}
	}
}

void RenderSourceCuboid(int x, int y, tile &t, short Water,int Bottom, int Top,int surface)
{
   // StoreTileName(x, y, SURFACE_FLOOR,0);
	fprintf(MAPFILE, "\tsolid\n");
	fprintf(MAPFILE, "\t{\n");
	
	fprintf(MAPFILE, "\t\t\"id\" \"%d\"\n", PrimitiveCount++);

	//Plane goes here Points are clockwise as you face the plane
	//East Face
	int BLeftX = t.tileX*BrushSizeX + t.DimX*BrushSizeX;
	int BLeftY = t.tileY*BrushSizeY;
	int BLeftZ = Bottom*BrushSizeZ;
	int TLeftX = t.tileX*BrushSizeX + t.DimX*BrushSizeX;
	int TLeftY = t.tileY*BrushSizeY;
	int TLeftZ = Top*BrushSizeZ;
	int TRightX = t.tileX*BrushSizeX + t.DimX*BrushSizeX;
	int TRightY = t.tileY*BrushSizeY + t.DimY*BrushSizeY;
	int TRightZ = Top*BrushSizeZ;
	Plane(1, fEAST, BLeftX, BLeftY, BLeftZ, TLeftX, TLeftY, TLeftZ, TRightX, TRightY, TRightZ, t, SURFACE_WALL);

	//North Face
	BLeftX = t.tileX*BrushSizeX + t.DimX*BrushSizeX;
	BLeftY = t.tileY*BrushSizeY + t.DimY*BrushSizeY;
	BLeftZ = Bottom*BrushSizeZ;
	TLeftX = t.tileX*BrushSizeX + t.DimX*BrushSizeX;
	TLeftY = t.tileY*BrushSizeY + t.DimY*BrushSizeY;
	TLeftZ = Top*BrushSizeZ;
	TRightX = t.tileX*BrushSizeX;
	TRightY = t.tileY*BrushSizeY + t.DimY*BrushSizeY;
	TRightZ = Top*BrushSizeZ;
	Plane(2, fNORTH, BLeftX, BLeftY, BLeftZ, TLeftX, TLeftY, TLeftZ, TRightX, TRightY, TRightZ, t, SURFACE_WALL);

	//top Face
	BLeftX = t.tileX*BrushSizeX;
	BLeftY = t.tileY*BrushSizeY;
	BLeftZ = Top*BrushSizeZ;
	TLeftX = t.tileX*BrushSizeX;
	TLeftY = t.tileY*BrushSizeY + t.DimY*BrushSizeY;
	TLeftZ = Top*BrushSizeZ;
	TRightX = t.tileX*BrushSizeX + t.DimX + BrushSizeX;
	TRightY = t.tileY*BrushSizeY + t.DimY*BrushSizeY;
	TRightZ = Top*BrushSizeZ;
	Plane(3, fTOP, BLeftX, BLeftY, BLeftZ, TLeftX, TLeftY, TLeftZ, TRightX, TRightY, TRightZ, t, SURFACE_CEIL);

	//west Face
	BLeftX = t.tileX*BrushSizeX;
	BLeftY = t.tileY*BrushSizeY + t.DimY*BrushSizeY;
	BLeftZ = Bottom*BrushSizeZ;
	TLeftX = t.tileX*BrushSizeX;
	TLeftY = t.tileY*BrushSizeY + t.DimY*BrushSizeY;
	TLeftZ = Top*BrushSizeZ;
	TRightX = t.tileX*BrushSizeX;
	TRightY = t.tileY*BrushSizeY;
	TRightZ = Top*BrushSizeZ;
	Plane(4, fWEST, BLeftX, BLeftY, BLeftZ, TLeftX, TLeftY, TLeftZ, TRightX, TRightY, TRightZ, t, SURFACE_WALL);

	//South face
	BLeftX = t.tileX*BrushSizeX;
	BLeftY = t.tileY*BrushSizeY;
	BLeftZ = Bottom*BrushSizeZ;//?
	TLeftX = t.tileX*BrushSizeX;
	TLeftY = t.tileY*BrushSizeY;
	TLeftZ = Top*BrushSizeZ;
	TRightX = t.tileX*BrushSizeX + t.DimX*BrushSizeX;
	TRightY = t.tileY*BrushSizeY;
	TRightZ = Top*BrushSizeZ;
	Plane(5, fSOUTH, BLeftX, BLeftY, BLeftZ, TLeftX, TLeftY, TLeftZ, TRightX, TRightY, TRightZ, t, SURFACE_WALL);

	//bottom face
	BLeftX = t.tileX*BrushSizeX;
	BLeftY = t.tileY*BrushSizeY + t.DimY*BrushSizeY;
	BLeftZ = Bottom*BrushSizeZ;
	TLeftX = t.tileX*BrushSizeX;
	TLeftY = t.tileY*BrushSizeY;
	TLeftZ = Bottom*BrushSizeZ;
	TRightX = t.tileX*BrushSizeX + t.DimX*BrushSizeX;
	TRightY = t.tileY*BrushSizeY;
	TRightZ = Bottom*BrushSizeZ;
	Plane(6, fCEIL, BLeftX, BLeftY, BLeftZ, TLeftX, TLeftY, TLeftZ, TRightX, TRightY, TRightZ, t, SURFACE_FLOOR);


	//fprintf(MAPFILE, "\t\t}\n");
	fprintf(MAPFILE, "\t}\n");

}

void RenderSourceDiagSETile(int x, int y, tile &t, short Water, short invert)
{
	int BLeftX; int BLeftY; int BLeftZ; int TLeftX; int TLeftY; int TLeftZ; int TRightX; int TRightY; int TRightZ;

	if (t.Render == 1)
	{
		if (invert == 0)
		{

			if (Water != 1)
			{
				//the wall part
			    StoreTileName(x, y, SURFACE_WALL, 0);
				RenderSourceDiagSEPortion(-2,CEILING_HEIGHT+1,t);

			}
			if (t.isWater == Water)
			{
				//it's floor
			    StoreTileName(x, y, SURFACE_FLOOR, 0);
				RenderSourceDiagNWPortion(-2,t.floorHeight,t);
			}
		}
		else
		{//it's ceiling
		    StoreTileName(x, y, SURFACE_CEIL, 0);
			RenderSourceDiagNWPortion(CEILING_HEIGHT-t.ceilingHeight, CEILING_HEIGHT+1, t);
		}
	}
	return;
}

void RenderSourceDiagNWTile(int x, int y, tile &t, short Water, short invert)
{

	if (t.Render == 1)
	{
		if (invert == 0)
		{
			if (Water != 1)
			{
				//It's wall.
			     StoreTileName(x, y, SURFACE_WALL, 0);
				RenderSourceDiagNWPortion(- 2, CEILING_HEIGHT + 1, t);
			}

			
			if (t.isWater == Water)
			{
				//it's floor
			    StoreTileName(x, y, SURFACE_FLOOR, 0);
				RenderSourceDiagSEPortion(-2, t.floorHeight, t);
			}
		}
		else
		{//it's ceiling
		    StoreTileName(x, y, SURFACE_CEIL, 0);
			RenderSourceDiagSEPortion(CEILING_HEIGHT - t.ceilingHeight, CEILING_HEIGHT + 1, t);
		}
	}
	return;
}

void RenderSourceDiagSWTile(int x, int y, tile &t, short Water, short invert)
{
	if (t.Render == 1)
	{
		if (invert == 0)
		{
			if (Water != 1)
			{
				//Its wall
			StoreTileName(x, y, SURFACE_WALL, 0);
				RenderSourceDiagSWPortion(- 2, CEILING_HEIGHT + 1, t);
			}
			if (t.isWater == Water)
			{
				//it's floor
			StoreTileName(x, y, SURFACE_FLOOR, 0);
				RenderSourceDiagNEPortion(-2, t.floorHeight, t);
			}
		}
		else
		{
			//its' ceiling.
		    StoreTileName(x, y, SURFACE_CEIL, 0);
			RenderSourceDiagNEPortion(CEILING_HEIGHT - t.ceilingHeight, CEILING_HEIGHT + 1, t);
		}
	}
	return;
}

void RenderSourceDiagNETile(int x, int y, tile &t, short Water, short invert)
{

	if (t.Render == 1){
		if (invert == 0)
		{

			if (Water != 1)
			{
			StoreTileName(x, y, SURFACE_WALL, 0);
				RenderSourceDiagNEPortion(-2, CEILING_HEIGHT + 1, t);
			}
			if (t.isWater == Water)
			{
				//it's floor
			    StoreTileName(x, y, SURFACE_FLOOR, 0);
				RenderSourceDiagSWPortion(-2, t.floorHeight, t);
			}
		}
		else
		{//it's ceiling
		StoreTileName(x, y, SURFACE_CEIL, 0);
			RenderSourceDiagSWPortion(CEILING_HEIGHT - t.ceilingHeight, CEILING_HEIGHT + 1, t);
		}
	}
	return;
}

void RenderSourceSlopeNTile(int x, int y, tile &t, short Water, short invert, int surface,int part)
{
	if (t.Render == 1){
		if (invert == 0)
		{
			if (t.isWater == Water)
			{
			//A floor
			StoreTileName(x, y, SURFACE_FLOOR, part);
				RenderSlopedSourceCuboid(x,y,t,Water,-2,t.floorHeight,TILE_SLOPE_N,t.shockSteep,1);
			}
		}
		else
		{
		//It's invert
		    StoreTileName(x, y, SURFACE_CEIL, part);
			RenderSlopedSourceCuboid(x, y, t, Water, CEILING_HEIGHT - t.ceilingHeight, CEILING_HEIGHT + 1, TILE_SLOPE_N, t.shockSteep, 0);
		}
	}
	return;
}

void RenderSourceSlopeSTile(int x, int y, tile &t, short Water, short invert, int surface, int part)
{
	if (t.Render == 1){
		if (invert == 0)
		{
			if (t.isWater == Water)
			{
				//A floor
			StoreTileName(x, y, SURFACE_FLOOR, part);
				RenderSlopedSourceCuboid(x, y, t, Water, -2, t.floorHeight, TILE_SLOPE_S, t.shockSteep, 1);
			}
		}
		else
		{
			//It's invert
		StoreTileName(x, y, SURFACE_CEIL, part);
			RenderSlopedSourceCuboid(x, y, t, Water, CEILING_HEIGHT - t.ceilingHeight, CEILING_HEIGHT + 1, TILE_SLOPE_S, t.shockSteep, 0);
		}
	}
	return;
}

void RenderSourceSlopeWTile(int x, int y, tile &t, short Water, short invert, int surface, int part)
{
	if (t.Render == 1){
		if (invert == 0)
		{
			if (t.isWater == Water)
			{
				//A floor
			StoreTileName(x, y, SURFACE_FLOOR, part);
				RenderSlopedSourceCuboid(x, y, t, Water, -2, t.floorHeight, TILE_SLOPE_W, t.shockSteep, 1);
			}
		}
		else
		{
			//It's invert
		StoreTileName(x, y, SURFACE_CEIL, part);
			RenderSlopedSourceCuboid(x, y, t, Water, CEILING_HEIGHT - t.ceilingHeight, CEILING_HEIGHT + 1, TILE_SLOPE_W, t.shockSteep, 0);
		}
	}
	return;
}

void RenderSourceSlopeETile(int x, int y, tile &t, short Water, short invert, int surface, int part)
{
	if (t.Render == 1){
		if (invert == 0)
		{
			if (t.isWater == Water)
			{
				//A floor
			StoreTileName(x, y, SURFACE_FLOOR, part);
				RenderSlopedSourceCuboid(x, y, t, Water, -2, t.floorHeight, TILE_SLOPE_E, t.shockSteep, 1);
			}
		}
		else
		{
			//It's invert
		StoreTileName(x, y, SURFACE_CEIL, part);
			RenderSlopedSourceCuboid(x, y, t, Water, CEILING_HEIGHT - t.ceilingHeight, CEILING_HEIGHT + 1, TILE_SLOPE_E, t.shockSteep, 0);
		}
	}
	return;
}

void RenderSourceDiagSEPortion(int Bottom, int Top, tile t)
{
	int BLeftX; int BLeftY; int BLeftZ; int TLeftX; int TLeftY; int TLeftZ; int TRightX; int TRightY; int TRightZ;
	fprintf(MAPFILE, "\tsolid\n");
	fprintf(MAPFILE, "\t{\n");
	fprintf(MAPFILE, "\t\t\"id\" \"%d\"\n", PrimitiveCount++);
	BLeftX = t.tileX*BrushSizeX;
	BLeftY = t.tileY*BrushSizeY;
	BLeftZ = Bottom * BrushSizeZ;
	TLeftX = t.tileX*BrushSizeX;
	TLeftY = t.tileY*BrushSizeY;
	TLeftZ = (Top)* BrushSizeZ;
	TRightX = (t.tileX + 1)*BrushSizeX;
	TRightY = (t.tileY + 1)*BrushSizeX;
	TRightZ = (Top)* BrushSizeZ;
	Plane(1, fSELF, BLeftX, BLeftY, BLeftZ, TLeftX, TLeftY, TLeftZ, TRightX, TRightY, TRightZ, t,SURFACE_WALL);
	//Western face
	BLeftX = t.tileX*BrushSizeX;
	BLeftY = (t.tileY + 1)*BrushSizeY;
	BLeftZ = Bottom * BrushSizeZ;
	TLeftX = t.tileX*BrushSizeX;
	TLeftY = (t.tileY + 1)*BrushSizeY;
	TLeftZ = (Top)* BrushSizeZ;
	TRightX = t.tileX*BrushSizeX;;
	TRightY = t.tileY*BrushSizeY;
	TRightZ = (Top)* BrushSizeZ;
	Plane(2, fWEST, BLeftX, BLeftY, BLeftZ, TLeftX, TLeftY, TLeftZ, TRightX, TRightY, TRightZ, t, SURFACE_WALL);
	//Northern face
	BLeftX = (t.tileX + 1)*BrushSizeX;
	BLeftY = (t.tileY + 1)*BrushSizeY;
	BLeftZ = Bottom * BrushSizeZ;
	TLeftX = (t.tileX + 1)*BrushSizeX;
	TLeftY = (t.tileY + 1)*BrushSizeY;
	TLeftZ = (Top)* BrushSizeZ;
	TRightX = t.tileX*BrushSizeX;;
	TRightY = (t.tileY + 1)*BrushSizeY;
	TRightZ = (Top)* BrushSizeZ;
	Plane(3, fNORTH, BLeftX, BLeftY, BLeftZ, TLeftX, TLeftY, TLeftZ, TRightX, TRightY, TRightZ, t, SURFACE_WALL);

	//Top Face
	BLeftX = (t.tileX)*BrushSizeX;
	BLeftY = (t.tileY)*BrushSizeY;
	BLeftZ = (Top)* BrushSizeZ;
	TLeftX = (t.tileX)*BrushSizeX;;
	TLeftY = (t.tileY + 1)*BrushSizeY;
	TLeftZ = (Top)* BrushSizeZ;
	TRightX = (t.tileX + 1)*BrushSizeX;;
	TRightY = (t.tileY + 1)*BrushSizeY;
	TRightZ = (Top)* BrushSizeZ;
	Plane(4, fTOP, BLeftX, BLeftY, BLeftZ, TLeftX, TLeftY, TLeftZ, TRightX, TRightY, TRightZ, t,SURFACE_FLOOR);

	//Bottom Face
	BLeftX = (t.tileX)*BrushSizeX;
	BLeftY = (t.tileY)*BrushSizeY;
	BLeftZ = (Bottom)* BrushSizeZ;
	TLeftX = (t.tileX + 1)*BrushSizeX;;
	TLeftY = (t.tileY + 1)*BrushSizeY;
	TLeftZ = (Bottom)* BrushSizeZ;
	TRightX = (t.tileX)*BrushSizeX;;
	TRightY = (t.tileY + 1)*BrushSizeY;
	TRightZ = (Bottom)* BrushSizeZ;
	Plane(5, fCEIL, BLeftX, BLeftY, BLeftZ, TLeftX, TLeftY, TLeftZ, TRightX, TRightY, TRightZ, t, SURFACE_CEIL);

	fprintf(MAPFILE, "\t}\n");
}

void RenderSourceDiagSWPortion(int Bottom, int Top, tile t)
{
	int BLeftX; int BLeftY; int BLeftZ; int TLeftX; int TLeftY; int TLeftZ; int TRightX; int TRightY; int TRightZ;
	fprintf(MAPFILE, "\tsolid\n");
	fprintf(MAPFILE, "\t{\n");
	fprintf(MAPFILE, "\t\t\"id\" \"%d\"\n", PrimitiveCount++);
	//Angled Face
	BLeftX = t.tileX*BrushSizeX;
	BLeftY = (t.tileY+1)*BrushSizeY;
	BLeftZ = Bottom*BrushSizeZ;
	TLeftX = t.tileX*BrushSizeX;
	TLeftY = (t.tileY + 1)*BrushSizeY;
	TLeftZ = Top*BrushSizeZ;
	TRightX = (t.tileX+1)*BrushSizeX;
	TRightY = (t.tileY)*BrushSizeY;
	TRightZ = Top*BrushSizeZ;
	Plane(1, fSELF, BLeftX, BLeftY, BLeftZ, TLeftX, TLeftY, TLeftZ, TRightX, TRightY, TRightZ, t,SURFACE_WALL);
	
	//Eastern face
	//BLeftX = (t.tileX + 1)*BrushSizeX;
	//BLeftY = t.tileY*BrushSizeY;
	//BLeftZ = Bottom*BrushSizeZ;
	//TLeftX = (t.tileX + 1)*BrushSizeX;
	//TLeftY = t.tileY*BrushSizeY;
	//TLeftZ = Top*BrushSizeZ;
	//TRightX = (t.tileX + 1)*BrushSizeX;
	//TRightY = (t.tileY + 1)*BrushSizeY;
	//TRightZ = Top*BrushSizeZ;

	BLeftX = (t.tileX + 1)*BrushSizeX;
	BLeftY = t.tileY*BrushSizeY;
	BLeftZ = Bottom*BrushSizeZ;
	TLeftX = (t.tileX + 1)*BrushSizeX;
	TLeftY = t.tileY*BrushSizeY;
	TLeftZ = Top*BrushSizeZ;
	TRightX = (t.tileX + 1)*BrushSizeX;
	TRightY = (t.tileY + 1)*BrushSizeY;
	TRightZ = Top*BrushSizeZ;
	Plane(2, fEAST, BLeftX, BLeftY, BLeftZ, TLeftX, TLeftY, TLeftZ, TRightX, TRightY, TRightZ, t, SURFACE_WALL);

	//Northern face
	BLeftX = (t.tileX + 1)*BrushSizeX;
	BLeftY = (t.tileY + 1)*BrushSizeY;
	BLeftZ = Bottom * BrushSizeZ;
	TLeftX = (t.tileX + 1)*BrushSizeX;
	TLeftY = (t.tileY + 1)*BrushSizeY;
	TLeftZ = (Top)* BrushSizeZ;
	TRightX = t.tileX*BrushSizeX;;
	TRightY = (t.tileY + 1)*BrushSizeY;
	TRightZ = (Top)* BrushSizeZ;
	Plane(3, fNORTH, BLeftX, BLeftY, BLeftZ, TLeftX, TLeftY, TLeftZ, TRightX, TRightY, TRightZ, t, SURFACE_WALL);

	//Top Face
	BLeftX = (t.tileX)*BrushSizeX;
	BLeftY = (t.tileY + 1)*BrushSizeY;
	BLeftZ = Top*BrushSizeZ;
	TLeftX = (t.tileX + 1)*BrushSizeX;
	TLeftY = (t.tileY + 1)*BrushSizeY;
	TLeftZ = Top*BrushSizeZ;
	TRightX = (t.tileX + 1)*BrushSizeX;
	TRightY = (t.tileY)*BrushSizeY;
	TRightZ = Top*BrushSizeZ;
	Plane(4, fTOP, BLeftX, BLeftY, BLeftZ, TLeftX, TLeftY, TLeftZ, TRightX, TRightY, TRightZ, t, SURFACE_FLOOR);

	//Bottom Face
	BLeftX = (t.tileX+1)*BrushSizeX;
	BLeftY = (t.tileY+1)*BrushSizeY;
	BLeftZ = Bottom*BrushSizeZ;
	TLeftX = (t.tileX)*BrushSizeX;;
	TLeftY = (t.tileY+1)*BrushSizeY;
	TLeftZ = Bottom*BrushSizeZ;
	TRightX = (t.tileX + 1)*BrushSizeX;
	TRightY = (t.tileY)*BrushSizeY;;
	TRightZ = Bottom*BrushSizeZ;
	Plane(5, fCEIL, BLeftX, BLeftY, BLeftZ, TLeftX, TLeftY, TLeftZ, TRightX, TRightY, TRightZ, t, SURFACE_CEIL);

	fprintf(MAPFILE, "\t}\n");


}

void RenderSourceDiagNWPortion(int Bottom, int Top, tile t)
{
	int BLeftX; int BLeftY; int BLeftZ; int TLeftX; int TLeftY; int TLeftZ; int TRightX; int TRightY; int TRightZ;
	fprintf(MAPFILE, "\tsolid\n");
	fprintf(MAPFILE, "\t{\n");
	fprintf(MAPFILE, "\t\t\"id\" \"%d\"\n", PrimitiveCount++);
	//Angled Face
	BLeftX = (t.tileX+1)*BrushSizeX;
	BLeftY = (t.tileY+1)*BrushSizeY;
	BLeftZ = Bottom*BrushSizeZ;
	TLeftX = (t.tileX + 1)*BrushSizeX;
	TLeftY = (t.tileY + 1)*BrushSizeY;
	TLeftZ = Top*BrushSizeZ;
	TRightX =(t.tileX)*BrushSizeX;
	TRightY = t.tileY*BrushSizeY;
	TRightZ =Top*BrushSizeZ;
	Plane(1, fSELF, BLeftX, BLeftY, BLeftZ, TLeftX, TLeftY, TLeftZ, TRightX, TRightY, TRightZ, t,SURFACE_WALL);
	
	//Eastern face
	BLeftX = (t.tileX+1)*BrushSizeX;
	BLeftY = t.tileY*BrushSizeY;
	BLeftZ = Bottom*BrushSizeZ;
	TLeftX = (t.tileX+1)*BrushSizeX ;
	TLeftY = t.tileY*BrushSizeY;
	TLeftZ = Top*BrushSizeZ;
	TRightX = (t.tileX+1)*BrushSizeX;
	TRightY = (t.tileY+1)*BrushSizeY;
	TRightZ = Top*BrushSizeZ;
	Plane(2, fEAST, BLeftX, BLeftY, BLeftZ, TLeftX, TLeftY, TLeftZ, TRightX, TRightY, TRightZ, t, SURFACE_WALL);
	
	//South face
	BLeftX = t.tileX*BrushSizeX;
	BLeftY = t.tileY*BrushSizeY;
	BLeftZ = Bottom*BrushSizeZ;
	TLeftX = t.tileX*BrushSizeX;
	TLeftY = t.tileY*BrushSizeY;
	TLeftZ = Top*BrushSizeZ;
	TRightX = (t.tileX+1)*BrushSizeX;
	TRightY = t.tileY*BrushSizeY;
	TRightZ = Top*BrushSizeZ;
	Plane(3, fSOUTH, BLeftX, BLeftY, BLeftZ, TLeftX, TLeftY, TLeftZ, TRightX, TRightY, TRightZ, t, SURFACE_WALL);

	//Top Face
	BLeftX = t.tileX*BrushSizeX;
	BLeftY = t.tileY*BrushSizeY;
	BLeftZ = Top*BrushSizeZ;
	TLeftX = (t.tileX+1)*BrushSizeX;
	TLeftY = (t.tileY + 1)*BrushSizeY;
	TLeftZ = Top*BrushSizeZ;
	TRightX = (t.tileX+1)*BrushSizeX;
	TRightY = (t.tileY)*BrushSizeY;
	TRightZ = Top*BrushSizeZ;
	Plane(4, fTOP, BLeftX, BLeftY, BLeftZ, TLeftX, TLeftY, TLeftZ, TRightX, TRightY, TRightZ, t, SURFACE_FLOOR);

	//Bottom Face
	BLeftX = (t.tileX )*BrushSizeX;
	BLeftY = (t.tileY+1)*BrushSizeY;
	BLeftZ = Bottom*BrushSizeZ;
	TLeftX = t.tileX+1*BrushSizeX;
	TLeftY = (t.tileY+1)*BrushSizeY;
	TLeftZ = Bottom*BrushSizeZ;
	TRightX = (t.tileX + 1)*BrushSizeX;
	TRightY = (t.tileY)*BrushSizeY;
	TRightZ = Bottom*BrushSizeZ;
	Plane(5, fCEIL, BLeftX, BLeftY, BLeftZ, TLeftX, TLeftY, TLeftZ, TRightX, TRightY, TRightZ, t, SURFACE_CEIL);

	fprintf(MAPFILE, "\t}\n");
}

void RenderSourceDiagNEPortion(int Bottom, int Top, tile t)
{
	int BLeftX; int BLeftY; int BLeftZ; int TLeftX; int TLeftY; int TLeftZ; int TRightX; int TRightY; int TRightZ;
	fprintf(MAPFILE, "\tsolid\n");
	fprintf(MAPFILE, "\t{\n");
	fprintf(MAPFILE, "\t\t\"id\" \"%d\"\n", PrimitiveCount++);
	//Angled Face
	BLeftX = (t.tileX+1)*BrushSizeX;
	BLeftY = (t.tileY)*BrushSizeY;
	BLeftZ = Bottom*BrushSizeZ;
	TLeftX = (t.tileX+1)*BrushSizeX;
	TLeftY = (t.tileY )*BrushSizeY;
	TLeftZ = Top*BrushSizeZ;
	TRightX = (t.tileX)*BrushSizeX;
	TRightY = (t.tileY+1)*BrushSizeY;
	TRightZ = Top*BrushSizeZ;
	Plane(1, fSELF, BLeftX, BLeftY, BLeftZ, TLeftX, TLeftY, TLeftZ, TRightX, TRightY, TRightZ, t, SURFACE_WALL);

//western face
	BLeftX = t.tileX*BrushSizeX;
	BLeftY = (t.tileY + 1)*BrushSizeY;
	BLeftZ = Bottom * BrushSizeZ;
	TLeftX = t.tileX*BrushSizeX;
	TLeftY = (t.tileY + 1)*BrushSizeY;
	TLeftZ = (Top)* BrushSizeZ;
	TRightX = t.tileX*BrushSizeX;;
	TRightY = t.tileY*BrushSizeY;
	TRightZ = (Top)* BrushSizeZ;
	Plane(2, fWEST, BLeftX, BLeftY, BLeftZ, TLeftX, TLeftY, TLeftZ, TRightX, TRightY, TRightZ, t, SURFACE_WALL);

//Southern face
	BLeftX = t.tileX*BrushSizeX;
	BLeftY = t.tileY*BrushSizeY;
	BLeftZ = Bottom*BrushSizeZ;
	TLeftX = t.tileX*BrushSizeX;
	TLeftY = t.tileY*BrushSizeY;
	TLeftZ = Top*BrushSizeZ;
	TRightX = (t.tileX + 1)*BrushSizeX;
	TRightY = t.tileY*BrushSizeY;
	TRightZ = Top*BrushSizeZ;
	Plane(3, fSOUTH, BLeftX, BLeftY, BLeftZ, TLeftX, TLeftY, TLeftZ, TRightX, TRightY, TRightZ, t, SURFACE_WALL);

//Top Face
	BLeftX = t.tileX*BrushSizeX;
	BLeftY = t.tileY*BrushSizeY;
	BLeftZ = Top*BrushSizeZ;
	TLeftX = t.tileX*BrushSizeX;
	TLeftY = (t.tileY+1)*BrushSizeY;
	TLeftZ = Top*BrushSizeZ;
	TRightX = (t.tileX+1)*BrushSizeX;;
	TRightY = t.tileY*BrushSizeY;
	TRightZ = Top*BrushSizeZ;
	Plane(4, fBOTTOM, BLeftX, BLeftY, BLeftZ, TLeftX, TLeftY, TLeftZ, TRightX, TRightY, TRightZ, t, SURFACE_FLOOR);

//Bottom Face
	BLeftX = t.tileX*BrushSizeX;
	BLeftY = (t.tileY+1)*BrushSizeY;
	BLeftZ = Bottom*BrushSizeZ;
	TLeftX = t.tileX*BrushSizeX;
	TLeftY = (t.tileY)*BrushSizeY;
	TLeftZ = Bottom*BrushSizeZ;
	TRightX = (t.tileX+1)*BrushSizeX;
	TRightY = (t.tileY + 1)*BrushSizeY;
	TRightZ = Bottom*BrushSizeZ;
	Plane(5, fCEIL, BLeftX, BLeftY, BLeftZ, TLeftX, TLeftY, TLeftZ, TRightX, TRightY, TRightZ, t, SURFACE_CEIL);

	fprintf(MAPFILE, "\t}\n");
}

void RenderSlopedSourceCuboid(int x, int y, tile &t, short Water, int Bottom, int Top, int SlopeDir, int Steepness, int Floor)
{
	fprintf(MAPFILE, "\tsolid\n");
	fprintf(MAPFILE, "\t{\n");
	fprintf(MAPFILE, "\t\t\"id\" \"%d\"\n", PrimitiveCount++);

	//Plane goes here Points are clockwise as you face the plane
	//East Face
	int BLeftX = t.tileX*BrushSizeX + t.DimX*BrushSizeX;
	int BLeftY = t.tileY*BrushSizeY;
	int BLeftZ = Bottom*BrushSizeZ;
	int TLeftX = t.tileX*BrushSizeX + t.DimX*BrushSizeX;
	int TLeftY = t.tileY*BrushSizeY;
	int TLeftZ = Top*BrushSizeZ;
	int TRightX = t.tileX*BrushSizeX + t.DimX*BrushSizeX;
	int TRightY = t.tileY*BrushSizeY + t.DimY*BrushSizeY;
	int TRightZ = Top*BrushSizeZ;
	Plane(1, fEAST, BLeftX, BLeftY, BLeftZ, TLeftX, TLeftY, TLeftZ, TRightX, TRightY, TRightZ, t, SURFACE_WALL);

	//North Face
	BLeftX = t.tileX*BrushSizeX + t.DimX*BrushSizeX;
	BLeftY = t.tileY*BrushSizeY + t.DimY*BrushSizeY;
	BLeftZ = Bottom*BrushSizeZ;
	TLeftX = t.tileX*BrushSizeX + t.DimX*BrushSizeX;
	TLeftY = t.tileY*BrushSizeY + t.DimY*BrushSizeY;
	TLeftZ = Top*BrushSizeZ;
	TRightX = t.tileX*BrushSizeX;
	TRightY = t.tileY*BrushSizeY + t.DimY*BrushSizeY;
	TRightZ = Top*BrushSizeZ;
	Plane(2, fNORTH, BLeftX, BLeftY, BLeftZ, TLeftX, TLeftY, TLeftZ, TRightX, TRightY, TRightZ, t, SURFACE_WALL);

	//top Face
	BLeftX = t.tileX*BrushSizeX;
	BLeftY = t.tileY*BrushSizeY;
	BLeftZ = Top*BrushSizeZ;
	TLeftX = t.tileX*BrushSizeX;
	TLeftY = t.tileY*BrushSizeY + t.DimY*BrushSizeY;
	TLeftZ = Top*BrushSizeZ;
	TRightX = t.tileX*BrushSizeX + t.DimX + BrushSizeX;
	TRightY = t.tileY*BrushSizeY + t.DimY*BrushSizeY;
	TRightZ = Top*BrushSizeZ;
	if (Floor == 1)
		{
		switch (SlopeDir)
			{
			case TILE_SLOPE_N:
				BLeftZ = Top*BrushSizeZ;
				TLeftZ = (Top + Steepness)*BrushSizeZ;
				TRightZ = (Top + Steepness)*BrushSizeZ;
				break;
			case TILE_SLOPE_S:
				BLeftZ = (Top + Steepness)*BrushSizeZ;
				TLeftZ = Top*BrushSizeZ;
				TRightZ = Top*BrushSizeZ;
				break;
			case TILE_SLOPE_E:
				BLeftZ = Top*BrushSizeZ;
				TLeftZ = Top*BrushSizeZ;
				TRightZ = (Top + Steepness)*BrushSizeZ;
				break;
			case TILE_SLOPE_W:
				BLeftZ = (Top + Steepness)*BrushSizeZ;
				TLeftZ = (Top + Steepness)*BrushSizeZ;
				TRightZ = Top*BrushSizeZ;
				break;
			}
		}
	Plane(3, fTOP, BLeftX, BLeftY, BLeftZ, TLeftX, TLeftY, TLeftZ, TRightX, TRightY, TRightZ, t, SURFACE_SLOPE);

	//west Face
	BLeftX = t.tileX*BrushSizeX;
	BLeftY = t.tileY*BrushSizeY + t.DimY*BrushSizeY;
	BLeftZ = Bottom*BrushSizeZ;
	TLeftX = t.tileX*BrushSizeX;
	TLeftY = t.tileY*BrushSizeY + t.DimY*BrushSizeY;
	TLeftZ = Top*BrushSizeZ;
	TRightX = t.tileX*BrushSizeX;
	TRightY = t.tileY*BrushSizeY;
	TRightZ = Top*BrushSizeZ;
	Plane(4, fWEST, BLeftX, BLeftY, BLeftZ, TLeftX, TLeftY, TLeftZ, TRightX, TRightY, TRightZ, t, SURFACE_WALL);

	//South face
	BLeftX = t.tileX*BrushSizeX;
	BLeftY = t.tileY*BrushSizeY;
	BLeftZ = Bottom*BrushSizeZ;//?
	TLeftX = t.tileX*BrushSizeX;
	TLeftY = t.tileY*BrushSizeY;
	TLeftZ = Top*BrushSizeZ;
	TRightX = t.tileX*BrushSizeX + t.DimX*BrushSizeX;
	TRightY = t.tileY*BrushSizeY;
	TRightZ = Top*BrushSizeZ;
	Plane(5, fSOUTH, BLeftX, BLeftY, BLeftZ, TLeftX, TLeftY, TLeftZ, TRightX, TRightY, TRightZ, t, SURFACE_WALL);
	
	//bottom face
	BLeftX = t.tileX*BrushSizeX;
	BLeftY = t.tileY*BrushSizeY + t.DimY*BrushSizeY;
	BLeftZ = Bottom*BrushSizeZ;
	TLeftX = t.tileX*BrushSizeX;
	TLeftY = t.tileY*BrushSizeY;
	TLeftZ = Bottom*BrushSizeZ;
	TRightX = t.tileX*BrushSizeX + t.DimX*BrushSizeX;
	TRightY = t.tileY*BrushSizeY;
	TRightZ = Bottom*BrushSizeZ;

if (Floor == 0)
	{
		switch (SlopeDir)
		{
		case TILE_SLOPE_N:
			BLeftZ = Bottom*BrushSizeZ;
			TLeftZ = (Bottom - Steepness)*BrushSizeZ;
			TRightZ = (Bottom - Steepness)*BrushSizeZ;
			break;
		case TILE_SLOPE_S:
			BLeftZ = (Bottom - Steepness)*BrushSizeZ;
			TLeftZ = Bottom*BrushSizeZ;
			TRightZ = Bottom*BrushSizeZ;
			break;
		case TILE_SLOPE_E:
			BLeftZ = (Bottom - Steepness)*BrushSizeZ;
			TLeftZ = (Bottom - Steepness)*BrushSizeZ;
			TRightZ = Bottom*BrushSizeZ;
			break;
		case TILE_SLOPE_W:
			BLeftZ = Bottom*BrushSizeZ;
			TLeftZ = Bottom*BrushSizeZ;
			TRightZ = (Bottom - Steepness)*BrushSizeZ;
			break;
		}
	}
	Plane(6, fSOUTH, BLeftX, BLeftY, BLeftZ, TLeftX, TLeftY, TLeftZ, TRightX, TRightY, TRightZ, t,SURFACE_SLOPE);


	//fprintf(MAPFILE, "\t\t}\n");
	fprintf(MAPFILE, "\t}\n");

}

void RenderSourceValleyNWTile(int x, int y, tile &t, short Water, short invert, int surface)
{
	int originalTile = t.tileType;
	t.tileType = TILE_SLOPE_N;
	RenderSourceSlopeNTile(x, y, t, Water, invert,surface,1);
	t.tileType = TILE_SLOPE_W;
	RenderSourceSlopeWTile(x, y, t, Water, invert,surface,2);
	t.tileType = originalTile;
	return;
}

void RenderSourceValleyNETile(int x, int y, tile &t, short Water, short invert, int surface)
{
	int originalTile = t.tileType;
	t.tileType = TILE_SLOPE_E;
	RenderSourceSlopeETile(x, y, t, Water, invert,surface,1);
	t.tileType = TILE_SLOPE_N;
	RenderSourceSlopeNTile(x, y, t, Water, surface, invert, 2);
	t.tileType = originalTile;
	return;
}

void RenderSourceValleySWTile(int x, int y, tile &t, short Water, short invert, int surface)
{
	int originalTile = t.tileType;
	t.tileType = TILE_SLOPE_W;
	RenderSourceSlopeWTile(x, y, t, Water, invert, surface, 1);
	t.tileType = TILE_SLOPE_S;
	RenderSourceSlopeSTile(x, y, t, Water, invert, surface, 2);
	t.tileType = originalTile;
	return;
}

void RenderSourceValleySETile(int x, int y, tile &t, short Water, short invert, int surface)
{
	int originalTile = t.tileType;
	t.tileType = TILE_SLOPE_E;
	RenderSourceSlopeETile(x, y, t, Water, invert, surface,1);
	t.tileType = TILE_SLOPE_S;
	RenderSourceSlopeSTile(x, y, t, Water, invert, surface,2);
	t.tileType = originalTile;
	return;
}

void RenderSourceRidgeNWTile(int x, int y, tile &t, short Water, short invert, int surface)
{

	if (t.Render == 1)
		{
		if (invert == 0)

			{//consists of a slope n and a slope w
				if (t.isWater == Water)
				{
					RenderSourceSlopeNTile(x,y,t,Water,invert,surface,1);
					RenderSourceSlopeWTile(x, y, t, Water, invert, surface, 2);
				}
			}
		else
			{
			//made of upper slope e and upper slope s

			RenderSourceSlopeETile(x, y, t, Water, invert, surface, 1);
			RenderSourceSlopeSTile(x, y, t, Water, invert, surface, 2);
			}

	}
	return;
}

void RenderSourceRidgeNETile(int x, int y, tile &t, short Water, short invert, int surface)
{
	//consists of a slope n and a slope e

	if (t.Render == 1){
		if (invert == 0){
			if (t.isWater == Water)
			{
			RenderSourceSlopeNTile(x, y, t, Water, invert, surface, 1);
			RenderSourceSlopeETile(x, y, t, Water, invert, surface, 2);
			}
		}
		else
		{//invert is south and west slopes
		RenderSourceSlopeSTile(x, y, t, Water, invert, surface, 1);
		RenderSourceSlopeWTile(x, y, t, Water, invert, surface, 2);
		}
	}

	return;
}

void RenderSourceRidgeSWTile(int x, int y, tile &t, short Water, short invert, int surface)
{
	//consists of a slope s and a slope w
	if (t.Render == 1)
	if (invert == 0)
	{
		{
			if (t.isWater == Water)
			{
			RenderSourceSlopeSTile(x, y, t, Water, invert, surface, 1);
			RenderSourceSlopeWTile(x, y, t, Water, invert, surface, 2);
			}
		}
	}
	else
	{	//invert is n and w slopes
		//render a ceiling version of this tile
	RenderSourceSlopeNTile(x, y, t, Water, invert, surface, 1);
	RenderSourceSlopeWTile(x, y, t, Water, invert, surface, 2);

	}
	return;
}

void RenderSourceRidgeSETile(int x, int y, tile &t, short Water, short invert, int surface)
{
	//consists of a slope s and a slope e
	//done

	if (t.Render == 1)
	{
		if (invert == 0)
		{
			if (t.isWater == Water)
			{
			RenderSourceSlopeSTile(x, y, t, Water, invert, surface, 1);
			RenderSourceSlopeETile(x, y, t, Water, invert, surface, 2);
			}
		}
		else
		{//invert is n w
			//render a ceiling version of this tile
			//top and bottom faces move up
		RenderSourceSlopeNTile(x, y, t, Water, invert, surface, 1);
		RenderSourceSlopeWTile(x, y, t, Water, invert, surface, 2);
		}
	}
	return;
}
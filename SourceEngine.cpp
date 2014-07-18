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

void RenderSourceEnginelLevel(tile LevelInfo[64][64], ObjectItem objList[1600], int game)
//Main processing loop for generating the level.
{
int x;
int y;

iGame = game;

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
				RenderSourceTile(game, x, y, LevelInfo[x][y], 0, 0, 0, 0);
			}

		}


		fprintf(MAPFILE, "}\n");

		fprintf(MAPFILE, "cordon\n");
			fprintf(MAPFILE, "{\n");
			fprintf(MAPFILE, "\t\"mins\" \"(-%d -%d -%d)\"\n", 64 * BrushSizeX, 64 * BrushSizeY, 64 * BrushSizeZ);
			fprintf(MAPFILE, "\t\"maxs\" \"(%d %d %d)\"\n", 64 * BrushSizeX, 64 * BrushSizeY, 64 * BrushSizeZ);
			fprintf(MAPFILE, "\t\"active\" \"0\"");
			fprintf(MAPFILE, "}\n");
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
			if (skipFloor != 1) { RenderSourceOpenTile(x, y, t, Water, 0); }	//floor
			if ((skipCeil != 1)) { RenderSourceOpenTile(x, y, t, Water, 1); }	//ceiling	
			return;
		}
	
case 2:
	{//diag se
			  if (skipFloor != 1) { RenderSourceDiagSETile(x, y, t, Water, 0); }//floor
			  if ((skipCeil != 1)) { RenderSourceDiagSETile(x, y, t, Water, 1); }
			  return;
	}

case 5:
{//diag nw
		  if (skipFloor != 1) { RenderSourceDiagNWTile(x, y, t, Water, invert); }//floor
		  if ((skipCeil != 1)) { RenderSourceDiagNWTile(x, y, t, Water, 1); }
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
			RenderSourceCuboid(x,y,t,Water,-2,CEILING_HEIGHT+1);
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

void Plane(int index, int face, int BLeftX, int BLeftY, int BLeftZ, int TLeftX, int TLeftY, int TLeftZ, int TRightX, int TRightY, int TRightZ, tile t)
	{
	fprintf(MAPFILE, "\t\tside\n");
	fprintf(MAPFILE, "\t\t{\n");
	fprintf(MAPFILE, "\t\t\t\"id\" \"%d\"\n", index);
	fprintf(MAPFILE, "\t\t\t\"plane\" \"");
	fprintf(MAPFILE, "(%d %d %d) ", BLeftX, BLeftY, BLeftZ);
	fprintf(MAPFILE, "(%d %d %d) ", TLeftX, TLeftY, TLeftZ);
	fprintf(MAPFILE, "(%d %d %d)\" \n", TRightX, TRightY, TRightZ);
	fprintf(MAPFILE, "\t\t\t\"material\" \"BRICK/BRICKWALL001A\"\n");
	fprintf(MAPFILE, "\t\t\t\"uaxis\" \"[1 0 0 0] 0.25\"\n");
	fprintf(MAPFILE, "\t\t\t\"vaxis\" \"[0 -1 0 0] 0.25\"\n");
	fprintf(MAPFILE, "\t\t\t\"rotation\" \"0\"\n");
	fprintf(MAPFILE, "\t\t\t\"lightmapscale\" \"16\"\n");
	fprintf(MAPFILE, "\t\t\t\"smoothing_groups\" \"0\"\n");
	fprintf(MAPFILE, "\t\t\}\n");
	}

void RenderSourceOpenTile(int x, int y, tile &t, short Water, short invert)
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
						RenderSourceCuboid(x,y,t,Water,-16,t.floorHeight);
					}
					else
					{
						RenderSourceCuboid(x, y, t, Water, -2, t.floorHeight);
					}

				}
				else
				{
					RenderSourceCuboid(x, y, t, Water, -8, t.floorHeight);
				}

			}
			else
			{
				//Ceiling version of the tile
				RenderSourceCuboid(x, y, t, Water, CEILING_HEIGHT - t.ceilingHeight, CEILING_HEIGHT - t.ceilingHeight + 1);
			}
		}
	}
}

void RenderSourceCuboid(int x, int y, tile &t, short Water,int Bottom, int Top)
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
	Plane(1, fEAST, BLeftX, BLeftY, BLeftZ, TLeftX, TLeftY, TLeftZ, TRightX, TRightY, TRightZ, t);

	//North Face
	BLeftX = t.tileX*BrushSizeX + t.DimX*BrushSizeX;
	BLeftY = t.tileY*BrushSizeY + t.DimY*BrushSizeY;
	BLeftZ = Bottom*BrushSizeZ;
	TLeftX = t.tileX*BrushSizeX + t.DimX*BrushSizeX;
	TLeftY = t.tileY*BrushSizeY + t.DimY*BrushSizeY;
	TLeftZ = Top*BrushSizeZ;
	TRightX = t.tileX*BrushSizeX;
	TRightY = t.tileY*BrushSizeY + t.DimY*BrushSizeY;
	TRightZ = (CEILING_HEIGHT + 1)*BrushSizeZ;
	Plane(2, fNORTH, BLeftX, BLeftY, BLeftZ, TLeftX, TLeftY, TLeftZ, TRightX, TRightY, TRightZ, t);

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
	Plane(3, fTOP, BLeftX, BLeftY, BLeftZ, TLeftX, TLeftY, TLeftZ, TRightX, TRightY, TRightZ, t);

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
	Plane(4, fWEST, BLeftX, BLeftY, BLeftZ, TLeftX, TLeftY, TLeftZ, TRightX, TRightY, TRightZ, t);

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
	Plane(5, fSOUTH, BLeftX, BLeftY, BLeftZ, TLeftX, TLeftY, TLeftZ, TRightX, TRightY, TRightZ, t);

	//South face
	BLeftX = t.tileX*BrushSizeX;
	BLeftY = t.tileY*BrushSizeY;
	BLeftZ = Bottom*BrushSizeZ;
	TLeftX = t.tileX*BrushSizeX;
	TLeftY = t.tileY*BrushSizeY;
	TLeftZ = Top*BrushSizeZ;
	TRightX = t.tileX*BrushSizeX + t.DimX*BrushSizeX;
	TRightY = t.tileY*BrushSizeY;
	TRightZ = Top*BrushSizeZ;
	Plane(5, fSOUTH, BLeftX, BLeftY, BLeftZ, TLeftX, TLeftY, TLeftZ, TRightX, TRightY, TRightZ, t);


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
	Plane(6, fSOUTH, BLeftX, BLeftY, BLeftZ, TLeftX, TLeftY, TLeftZ, TRightX, TRightY, TRightZ, t);


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
				RenderSourceDiagSEPortion(-2,CEILING_HEIGHT+1,t);

			}
			if (t.isWater == Water)
			{
				//it's floor
				RenderSourceDiagNWPortion(-2,t.floorHeight,t);
			}
		}
		else
		{//it's ceiling
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
				RenderSourceDiagNWPortion(- 2, CEILING_HEIGHT + 1, t);
			}

			
			if (t.isWater == Water)
			{
				//it's floor
				RenderSourceDiagSEPortion(-2, t.floorHeight, t);
			}
		}
		else
		{//it's ceiling
			RenderSourceDiagSEPortion(CEILING_HEIGHT - t.ceilingHeight, CEILING_HEIGHT + 1, t);
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
	Plane(1, fSELF, BLeftX, BLeftY, BLeftZ, TLeftX, TLeftY, TLeftZ, TRightX, TRightY, TRightZ, t);
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
	Plane(2, fWEST, BLeftX, BLeftY, BLeftZ, TLeftX, TLeftY, TLeftZ, TRightX, TRightY, TRightZ, t);
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
	Plane(3, fNORTH, BLeftX, BLeftY, BLeftZ, TLeftX, TLeftY, TLeftZ, TRightX, TRightY, TRightZ, t);

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
	Plane(4, fTOP, BLeftX, BLeftY, BLeftZ, TLeftX, TLeftY, TLeftZ, TRightX, TRightY, TRightZ, t);

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
	Plane(5, fBOTTOM, BLeftX, BLeftY, BLeftZ, TLeftX, TLeftY, TLeftZ, TRightX, TRightY, TRightZ, t);

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
	Plane(1, fSELF, BLeftX, BLeftY, BLeftZ, TLeftX, TLeftY, TLeftZ, TRightX, TRightY, TRightZ, t);
	
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
	Plane(2, fEAST, BLeftX, BLeftY, BLeftZ, TLeftX, TLeftY, TLeftZ, TRightX, TRightY, TRightZ, t);
	
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
	Plane(3, fSOUTH, BLeftX, BLeftY, BLeftZ, TLeftX, TLeftY, TLeftZ, TRightX, TRightY, TRightZ, t);

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
	Plane(4, fTOP, BLeftX, BLeftY, BLeftZ, TLeftX, TLeftY, TLeftZ, TRightX, TRightY, TRightZ, t);

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
	Plane(5, fBOTTOM, BLeftX, BLeftY, BLeftZ, TLeftX, TLeftY, TLeftZ, TRightX, TRightY, TRightZ, t);

	fprintf(MAPFILE, "\t}\n");
}
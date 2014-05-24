#include <stdio.h>
#include <stdlib.h>
#include <fstream>
#include "math.h"

#include "tilemap.h"
#include "main.h"
#include "textures.h"
#include "gameobjects.h"

#include "D3DarkMod.h"
#include "gameobjectsrender.h"

extern FILE *MAPFILE;

void RenderDarkModTile(int game, int x, int y, tile &t, short Water, short invert, short skipFloor, short skipCeil)
{
	//Picks the tile to render based on tile type/flags.
	if (t.Render == 1)
	{
		fprintf(MAPFILE, "\n");
	}
	switch (t.tileType)
	{
	case TILE_SOLID:	//0
	{	//solid
							RenderSolidTile(x, y, t, Water);
							return;
	}
	case TILE_OPEN:		//1
	{//open
							if (skipFloor != 1) { RenderOpenTile(x, y, t, Water, 0); }	//floor
							if ((skipCeil != 1)) { RenderOpenTile(x, y, t, Water, 1); }	//ceiling	//(game == SHOCK) && 
							return;
	}
	case 2:
	{//diag se
			  if (skipFloor != 1) { RenderDiagSETile(x, y, t, Water, 0); }//floor
			  if ((skipCeil != 1)) { RenderDiagSETile(x, y, t, Water, 1); }
			  return;
	}
	case 3:
	{	//diag sw
			  if (skipFloor != 1) { RenderDiagSWTile(x, y, t, Water, 0); }//floor
			  if ((skipCeil != 1)) { RenderDiagSWTile(x, y, t, Water, 1); }
			  return;
	}
	case 4:
	{	//diag ne
			  if (skipFloor != 1) { RenderDiagNETile(x, y, t, Water, invert); }//floor
			  if ((skipCeil != 1)) { RenderDiagNETile(x, y, t, Water, 1); }
			  return;
	}
	case 5:
	{//diag nw
			  if (skipFloor != 1) { RenderDiagNWTile(x, y, t, Water, invert); }//floor
			  if ((skipCeil != 1)) { RenderDiagNWTile(x, y, t, Water, 1); }
			  return;
	}
	case TILE_SLOPE_N:	//6
	{//slope n
							switch (t.shockSlopeFlag)
							{
							case SLOPE_BOTH_PARALLEL:
							{
														if (skipFloor != 1) { RenderSlopeNTile(x, y, t, Water, 0); }//floor
														if ((skipCeil != 1)) { RenderSlopeNTile(x, y, t, Water, 1); }
														break;
							}
							case SLOPE_BOTH_OPPOSITE:
							{
														if (skipFloor != 1) { RenderSlopeNTile(x, y, t, Water, 0); }//floor
														if ((skipCeil != 1)) { RenderSlopeSTile(x, y, t, Water, 1); }
														break;
							}
							case SLOPE_FLOOR_ONLY:
							{
													 if (skipFloor != 1) { RenderSlopeNTile(x, y, t, Water, 0); }//floor
													 if ((skipCeil != 1)) { RenderOpenTile(x, y, t, Water, 1); }	//ceiling
													 break;
							}
							case SLOPE_CEILING_ONLY:
							{
													   if (skipFloor != 1) { RenderOpenTile(x, y, t, Water, 0); }	//floor
													   RenderSlopeNTile(x, y, t, Water, 1);
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
													   if (skipFloor != 1) { RenderSlopeSTile(x, y, t, Water, 0); }	//floor
													   RenderSlopeSTile(x, y, t, Water, 1);
													   break;
						   }
						   case SLOPE_BOTH_OPPOSITE:
						   {
													   if (skipFloor != 1) { RenderSlopeSTile(x, y, t, Water, 0); }	//floor
													   RenderSlopeNTile(x, y, t, Water, 1);
													   break;
						   }
						   case SLOPE_FLOOR_ONLY:
						   {
													if (skipFloor != 1) { RenderSlopeSTile(x, y, t, Water, 0); }	//floor
													if ((skipCeil != 1)) { RenderOpenTile(x, y, t, Water, 1); }	//ceiling
													break;
						   }
						   case SLOPE_CEILING_ONLY:
						   {
													  if (skipFloor != 1) { RenderOpenTile(x, y, t, Water, 0); }	//floor
													  if ((skipCeil != 1)) { RenderSlopeSTile(x, y, t, Water, 1); }
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
															if (skipFloor != 1) { RenderSlopeETile(x, y, t, Water, 0); }//floor
															RenderSlopeETile(x, y, t, Water, 1);
															break;
								}
								case SLOPE_BOTH_OPPOSITE:
								{
															if (skipFloor != 1) { RenderSlopeETile(x, y, t, Water, 0); }//floor
															RenderSlopeWTile(x, y, t, Water, 1);
															break;
								}
								case SLOPE_FLOOR_ONLY:
								{
														 if (skipFloor != 1) { RenderSlopeETile(x, y, t, Water, 0); }//floor
														 if ((skipCeil != 1)) { RenderOpenTile(x, y, t, Water, 1); }	//ceiling
														 break;
								}
								case SLOPE_CEILING_ONLY:
								{
														   if (skipFloor != 1) { RenderOpenTile(x, y, t, Water, 0); }	//floor
														   if ((skipCeil != 1)) { RenderSlopeETile(x, y, t, Water, 1); }
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
														if (skipFloor != 1) { RenderSlopeWTile(x, y, t, Water, 0); }//floor
														if ((skipCeil != 1)) { RenderSlopeWTile(x, y, t, Water, 1); }
														break;
							}
							case SLOPE_BOTH_OPPOSITE:
							{
														if (skipFloor != 1) { RenderSlopeWTile(x, y, t, Water, 0); }//floor
														if ((skipCeil != 1)) { RenderSlopeETile(x, y, t, Water, 1); }
														break;
							}
							case SLOPE_FLOOR_ONLY:
							{
													 if (skipFloor != 1) { RenderSlopeWTile(x, y, t, Water, 0); }//floor
													 if ( (skipCeil != 1)) { RenderOpenTile(x, y, t, Water, 1); }	//ceiling
													 break;
							}
							case SLOPE_CEILING_ONLY:
							{
													   if (skipFloor != 1) { RenderOpenTile(x, y, t, Water, 0); }	//floor
													   if ((skipCeil != 1)) { RenderSlopeWTile(x, y, t, Water, 1); }
													   break;
							}
							}
							return;
	}
	case 10:
	{	//valleyNw(a)
			   switch (t.shockSlopeFlag)
			   {
			   case SLOPE_BOTH_PARALLEL:
			   {
										   if (skipFloor != 1) { RenderValleyNWTile(x, y, t, Water, 0); }//floor
										   if ((skipCeil != 1)) { RenderValleyNWTile(x, y, t, Water, 1); }
										   break;
			   }
			   case SLOPE_BOTH_OPPOSITE:
			   {
										   if (skipFloor != 1) { RenderValleyNWTile(x, y, t, Water, 0); }//floor
										   if ((skipCeil != 1)) { RenderValleySETile(x, y, t, Water, 1); }
										   break;
			   }
			   case SLOPE_FLOOR_ONLY:
			   {
										if (skipFloor != 1) { RenderValleyNWTile(x, y, t, Water, 0); }//floor
										if ((skipCeil != 1)) { RenderOpenTile(x, y, t, Water, 1); }	//ceiling
										break;
			   }
			   case SLOPE_CEILING_ONLY:
			   {
										  if (skipFloor != 1) { RenderOpenTile(x, y, t, Water, 0); }	//floor
										  if ((skipCeil != 1)) { RenderValleyNWTile(x, y, t, Water, 1); }
										  break;
			   }
			   }
			   return;
	}
	case 11:
	{	//valleyne(b)
			   switch (t.shockSlopeFlag)
			   {
			   case SLOPE_BOTH_PARALLEL:
			   {
										   if (skipFloor != 1) { RenderValleyNETile(x, y, t, Water, 0); }//floor
										   if ((skipCeil != 1)) { RenderValleyNETile(x, y, t, Water, 1); }
										   break;
			   }
			   case SLOPE_BOTH_OPPOSITE:
			   {
										   if (skipFloor != 1) { RenderValleyNETile(x, y, t, Water, 0); }//floor
										   if ((skipCeil != 1)) { RenderValleySWTile(x, y, t, Water, 1); }
										   break;
			   }
			   case SLOPE_FLOOR_ONLY:
			   {
										if (skipFloor != 1) { RenderValleyNETile(x, y, t, Water, 0); }//floor
										if ((skipCeil != 1)) { RenderOpenTile(x, y, t, Water, 1); }	//ceiling
										break;
			   }
			   case SLOPE_CEILING_ONLY:
			   {
										  if (skipFloor != 1) { RenderOpenTile(x, y, t, Water, 0); }//floor
										  if ((skipCeil != 1)) { RenderValleyNETile(x, y, t, Water, 1); }
										  break;
			   }
			   }
			   return;
	}
	case 12:
	{	//valleyse(c)
			   switch (t.shockSlopeFlag)
			   {
			   case SLOPE_BOTH_PARALLEL:
			   {
										   if (skipFloor != 1) { RenderValleySETile(x, y, t, Water, 0); }//floor
										   if ((skipCeil != 1)) { RenderValleySETile(x, y, t, Water, 1); }
										   break;
			   }
			   case SLOPE_BOTH_OPPOSITE:
			   {
										   if (skipFloor != 1) { RenderValleySETile(x, y, t, Water, 0); }//floor
										   if ((skipCeil != 1)) { RenderValleyNWTile(x, y, t, Water, 1); }
										   break;
			   }
			   case SLOPE_FLOOR_ONLY:
			   {
										if (skipFloor != 1) { RenderValleySETile(x, y, t, Water, 0); }//floor
										if ((skipCeil != 1)) { RenderOpenTile(x, y, t, Water, 1); }	//ceiling
										break;
			   }
			   case SLOPE_CEILING_ONLY:
			   {
										  if (skipFloor != 1) { RenderOpenTile(x, y, t, Water, 0); }	//floor
										  if ((skipCeil != 1)) { RenderValleySETile(x, y, t, Water, 1); }
										  break;
			   }
			   }
			   return;
	}
	case 13:
	{	//valleysw(d)
			   switch (t.shockSlopeFlag)
			   {
			   case SLOPE_BOTH_PARALLEL:
			   {
										   if (skipFloor != 1) { RenderValleySWTile(x, y, t, Water, 0); }//floor
										   if ((skipCeil != 1)) { RenderValleySWTile(x, y, t, Water, 1); }
										   break;
			   }
			   case SLOPE_BOTH_OPPOSITE:
			   {
										   if (skipFloor != 1) { RenderValleySWTile(x, y, t, Water, 0); }//floor
										   if ((skipCeil != 1)) { RenderValleyNETile(x, y, t, Water, 1); }
										   break;
			   }
			   case SLOPE_FLOOR_ONLY:
			   {
										if (skipFloor != 1) { RenderValleySWTile(x, y, t, Water, 0); }//floor
										if ((skipCeil != 1)) { RenderOpenTile(x, y, t, Water, 1); }	//ceiling
										break;
			   }
			   case SLOPE_CEILING_ONLY:
			   {
										  if (skipFloor != 1) { RenderOpenTile(x, y, t, Water, 0); }	//floor
										  if ((skipCeil != 1)) { RenderValleySWTile(x, y, t, Water, 1); }
										  break;
			   }
			   }
			   return;
	}
	case 14:
	{	//ridge se(f)
			   switch (t.shockSlopeFlag)
			   {
			   case SLOPE_BOTH_PARALLEL:
			   {
										   if (skipFloor != 1) { RenderRidgeSETile(x, y, t, Water, 0); }//floor
										   if ((skipCeil != 1)) { RenderRidgeSETile(x, y, t, Water, 1); }
										   break;
			   }
			   case SLOPE_BOTH_OPPOSITE:
			   {
										   if (skipFloor != 1) { RenderRidgeSETile(x, y, t, Water, 0); }//floor
										   if ((skipCeil != 1)) { RenderRidgeNWTile(x, y, t, Water, 1); }
										   break;
			   }
			   case SLOPE_FLOOR_ONLY:
			   {
										if (skipFloor != 1) { RenderRidgeSETile(x, y, t, Water, 0); }//floor
										if ((skipCeil != 1)) { RenderOpenTile(x, y, t, Water, 1); }	//ceiling
										break;
			   }
			   case SLOPE_CEILING_ONLY:
			   {
										  if (skipFloor != 1) { RenderOpenTile(x, y, t, Water, 0); }//floor
										  if ((skipCeil != 1)) { RenderValleySETile(x, y, t, Water, 1); }
										  break;
			   }
			   }
			   return;
	}
	case 15:
	{	//ridgesw(g)
			   switch (t.shockSlopeFlag)
			   {
			   case SLOPE_BOTH_PARALLEL:
			   {
										   if (skipFloor != 1) { RenderRidgeSWTile(x, y, t, Water, 0); }//floor
										   if ((skipCeil != 1)) { RenderRidgeSWTile(x, y, t, Water, 1); }
										   break;
			   }
			   case SLOPE_BOTH_OPPOSITE:
			   {
										   if (skipFloor != 1) { RenderRidgeSWTile(x, y, t, Water, 0); }//floor
										   if ((skipCeil != 1)) { RenderRidgeNETile(x, y, t, Water, 1); }
										   break;
			   }
			   case SLOPE_FLOOR_ONLY:
			   {
										if (skipFloor != 1) { RenderRidgeSWTile(x, y, t, Water, 0); }//floor
										if ((skipCeil != 1)) { RenderOpenTile(x, y, t, Water, 1); }	//ceiling
										break;
			   }
			   case SLOPE_CEILING_ONLY:
			   {
										  if (skipFloor != 1) { RenderOpenTile(x, y, t, Water, 0); }	//floor
										  if ((skipCeil != 1)) { RenderValleySWTile(x, y, t, Water, 1); }
										  break;
			   }
			   }
			   return;
	}
	case 16:
	{	//ridgenw(h)
			   switch (t.shockSlopeFlag)
			   {
			   case SLOPE_BOTH_PARALLEL:
			   {
										   if (skipFloor != 1) { RenderRidgeNWTile(x, y, t, Water, 0); }//floor
										   if ((skipCeil != 1)) { RenderRidgeNWTile(x, y, t, Water, 1); }
										   break;
			   }
			   case SLOPE_BOTH_OPPOSITE:
			   {
										   if (skipFloor != 1) { RenderRidgeNWTile(x, y, t, Water, 0); }//floor
										   if ((skipCeil != 1)) { RenderRidgeSETile(x, y, t, Water, 1); }
										   break;
			   }
			   case SLOPE_FLOOR_ONLY:
			   {
										if (skipFloor != 1) { RenderRidgeNWTile(x, y, t, Water, 0); }//floor
										if ((skipCeil != 1)) { RenderOpenTile(x, y, t, Water, 1); }	//ceiling
										break;
			   }
			   case SLOPE_CEILING_ONLY:
			   {
										  if (skipFloor != 1) { RenderOpenTile(x, y, t, Water, 0); }	//floor
										  if ((skipCeil != 1)) { RenderValleyNWTile(x, y, t, Water, 1); }
										  break;
			   }
			   }
			   return;
	}
	case 17:
	{	//ridgene(i)
			   switch (t.shockSlopeFlag)
			   {
			   case SLOPE_BOTH_PARALLEL:
			   {
										   if (skipFloor != 1) { RenderRidgeNETile(x, y, t, Water, 0); }//floor
										   if ((skipCeil != 1)) { RenderRidgeNETile(x, y, t, Water, 1); }
										   break;
			   }
			   case SLOPE_BOTH_OPPOSITE:
			   {
										   if (skipFloor != 1) { RenderRidgeNETile(x, y, t, Water, 0); }//floor
										   if ((skipCeil != 1)) { RenderRidgeSWTile(x, y, t, Water, 1); }
										   break;
			   }
			   case SLOPE_FLOOR_ONLY:
			   {
										if (skipFloor != 1) { RenderRidgeNETile(x, y, t, Water, 0); }//floor
										if ((skipCeil != 1)) { RenderOpenTile(x, y, t, Water, 1); }	//ceiling
										break;
			   }
			   case SLOPE_CEILING_ONLY:
			   {
										  if (skipFloor != 1) { RenderOpenTile(x, y, t, Water, 0); }	//floor
										  if ((skipCeil != 1)) { RenderValleyNETile(x, y, t, Water, 1); }
										  break;
			   }
			   }
			   return;
	}
	}
}

void RenderSolidTile(int x, int y, tile &t, short Water)
{
	if (t.Render == 1){
		if (t.isWater == Water)
		{
			fprintf(MAPFILE, "// primitive %d\n", PrimitiveCount++);
			fprintf(MAPFILE, "{\nbrushDef3\n{\n");
			//east face 
			fprintf(MAPFILE, "( 1 0 0 %d )", -((x + t.DimX)*BrushSizeX));
			getWallTextureName(t, fEAST, 0);
			//north face 
			fprintf(MAPFILE, "( 0 1 0 %d )", -((y + t.DimY)*BrushSizeY));
			getWallTextureName(t, fNORTH, 0);
			//top face
			fprintf(MAPFILE, "( 0 0 1 %d )", -BrushSizeZ * (CEILING_HEIGHT + 1));
			getFloorTextureName(t, fTOP);
			//west face
			fprintf(MAPFILE, "( -1 0 0 %d )", +((x)*BrushSizeX));
			getWallTextureName(t, fWEST, 0);
			//south face
			fprintf(MAPFILE, "( 0 -1 0 %d )", +((y)*BrushSizeY));
			getWallTextureName(t, fSOUTH, 0);
			//bottom face
			fprintf(MAPFILE, "( 0 0 -1 %d )", -2 * BrushSizeZ);
			getFloorTextureName(t, fBOTTOM);
			fprintf(MAPFILE, "}\n}\n");
		}
	}
	return;
}

void RenderOpenTile(int x, int y, tile &t, short Water, short invert)
{
	if (t.Render == 1){
		if (t.isWater == Water)
		{
			if (invert == 0)
			{
				fprintf(MAPFILE, "// primitive %d\n", PrimitiveCount++);
				fprintf(MAPFILE, "{\nbrushDef3\n{\n");
				//East face
				fprintf(MAPFILE, "( 1 0 0 %d )", -((x + t.DimX)*BrushSizeX));
				getWallTextureName(t, fEAST, t.isWater);
				//North face
				fprintf(MAPFILE, "( 0 1 0 %d ) ", -((y + t.DimY)*BrushSizeY));
				getWallTextureName(t, fNORTH, t.isWater);
				//Top face
				fprintf(MAPFILE, "( 0 0 1 %d )", -((t.floorHeight) * BrushSizeZ));
				getFloorTextureName(t, fTOP);
				//West face
				fprintf(MAPFILE, "( -1 0 0 %d )", +((x)*BrushSizeX));
				getWallTextureName(t, fWEST, t.isWater);
				//South face
				fprintf(MAPFILE, "( 0 -1 0 %d )", +((y)*BrushSizeY));
				getWallTextureName(t, fSOUTH, t.isWater);
				//Bottom face 
				if (t.hasElevator == 0)
				{
					fprintf(MAPFILE, "( 0 0 -1 %d ) ", -2 * BrushSizeZ);
				}
				else
				{
					fprintf(MAPFILE, "( 0 0 -1 %d ) ", -8 * BrushSizeZ);
				}
				getFloorTextureName(t, fBOTTOM);
				fprintf(MAPFILE, "}\n}\n");
			}
			else
			{
				//render a ceiling version of this tile
				//top and bottom faces move up
				fprintf(MAPFILE, "// primitive %d\n", PrimitiveCount++);
				fprintf(MAPFILE, "{\nbrushDef3\n{\n");
				//East face
				fprintf(MAPFILE, "( 1 0 0 %d )", -((x + t.DimX)*BrushSizeX));
				getWallTextureName(t, fEAST, t.isWater);
				//North face
				fprintf(MAPFILE, "( 0 1 0 %d ) ", -((y + t.DimY)*BrushSizeY));
				getWallTextureName(t, fNORTH, t.isWater);
				//Top face
				fprintf(MAPFILE, "( 0 0 1 %d )", -((CEILING_HEIGHT + 1) * BrushSizeZ));
				getFloorTextureName(t, fTOP);
				//West face
				fprintf(MAPFILE, "( -1 0 0 %d )", +((x)*BrushSizeX));
				getWallTextureName(t, fWEST, t.isWater);
				//South face
				fprintf(MAPFILE, "( 0 -1 0 %d )", +((y)*BrushSizeY));
				getWallTextureName(t, fSOUTH, t.isWater);
				//Bottom face 
				fprintf(MAPFILE, "( 0 0 -1 %d ) ", +(CEILING_HEIGHT - (t.ceilingHeight))* BrushSizeZ);
				getFloorTextureName(t, fCEIL);
				fprintf(MAPFILE, "}\n}\n");
			}
		}
	}
}

void RenderDiagSETile(int x, int y, tile &t, short Water, short invert)
{
	float angle = 0;
	float BrushX = 0; float BrushY = 0; float BrushZ = 0;
	float normalDist = 0;

	if (t.Render == 1)
	{
		BrushX = (float)BrushSizeX; BrushY = (float)BrushSizeY;
		angle = atan((float)(BrushX / BrushY));
		if (invert == 0)
		{
			normalDist = (cos(atan((float)BrushY / BrushX))) * (x - y) * BrushSizeY;
			if (Water != 1)
			{
				fprintf(MAPFILE, "// primitive %d\n", PrimitiveCount++);
				fprintf(MAPFILE, "{\nbrushDef3\n{\n");
				//North face
				fprintf(MAPFILE, "( 0 1 0 %d )", -((y + t.DimY)*BrushSizeY));
				getWallTextureName(t, fNORTH, 0);
				//Top face
				fprintf(MAPFILE, "( 0 0 1 %d )", -BrushSizeZ * (CEILING_HEIGHT + 1));
				getFloorTextureName(t, fTOP);
				//West face
				fprintf(MAPFILE, "( -1 0 0 %d )", +((x)*BrushSizeX));
				getWallTextureName(t, fWEST, 0);
				//Bottom face 
				fprintf(MAPFILE, "( 0 0 -1 %d )", -2 * BrushSizeZ);	//to go underneath
				getFloorTextureName(t, fBOTTOM);
				//Angled face. x & y change
				//TODO: Change texture here
				fprintf(MAPFILE, "( %f -%f 0 %f )", cos(angle), sin(angle), -normalDist);
				getWallTextureName(t, fSELF, 0);
				fprintf(MAPFILE, "}\n}\n");
			}
			if (t.isWater == Water)
			{
				//it's floor
				fprintf(MAPFILE, "// primitive %d\n", PrimitiveCount++);
				fprintf(MAPFILE, "{\nbrushDef3\n{\n");
				//East Face
				fprintf(MAPFILE, "( 1 0 0 %d )", -((x + t.DimX)*BrushSizeX));
				getWallTextureName(t, fEAST, t.isWater);
				//Top face
				fprintf(MAPFILE, "( 0 0 1 %d )", -((t.floorHeight) * BrushSizeZ));
				getFloorTextureName(t, fTOP);
				//South face
				fprintf(MAPFILE, "( 0 -1 0 %d )", +((y)*BrushSizeY));
				getWallTextureName(t, fSOUTH, t.isWater);
				//Bottom face
				fprintf(MAPFILE, "( 0 0 -1 %d )", -2 * BrushSizeZ);
				getFloorTextureName(t, fBOTTOM);
				//Angled face. x & y change
				normalDist = (cos(atan((float)BrushY / BrushX))) * (x - y) * BrushSizeY;
				fprintf(MAPFILE, "( -%f %f 0 %f )", cos(angle), sin(angle), normalDist);
				getWallTextureName(t, fEAST, t.isWater);
				fprintf(MAPFILE, "}\n}\n");
			}
		}
		else
		{//it's ceiling
			fprintf(MAPFILE, "// primitive %d\n", PrimitiveCount++);
			fprintf(MAPFILE, "{\nbrushDef3\n{\n");
			//East Face
			fprintf(MAPFILE, "( 1 0 0 %d )", -((x + t.DimX)*BrushSizeX));
			getWallTextureName(t, fEAST, t.isWater);
			//Top face
			fprintf(MAPFILE, "( 0 0 1 %d )", -((CEILING_HEIGHT + 1) * BrushSizeZ));
			getFloorTextureName(t, fTOP);
			//South face
			fprintf(MAPFILE, "( 0 -1 0 %d )", +((y)*BrushSizeY));
			getWallTextureName(t, fSOUTH, t.isWater);
			//Bottom face
			//fprintf (MAPFILE, "( 0 0 -1 %d )", +t.ceilingHeight * BrushSizeZ);
			fprintf(MAPFILE, "( 0 0 -1 %d ) ", +(CEILING_HEIGHT - (t.ceilingHeight))* BrushSizeZ);
			getFloorTextureName(t, fCEIL);
			//Angled face. x & y change
			normalDist = (cos(atan((float)BrushY / BrushX))) * (x - y) * BrushSizeY;
			fprintf(MAPFILE, "( -%f %f 0 %f )", cos(angle), sin(angle), normalDist);
			getWallTextureName(t, fEAST, t.isWater);
			fprintf(MAPFILE, "}\n}\n");
		}
	}
	return;
}

void RenderDiagSWTile(int x, int y, tile &t, short Water, short invert)
{
	float angle = 0;
	float BrushX = 0; float BrushY = 0; float BrushZ = 0;
	float normalDist = 0;

	if (t.Render == 1)
	{
		BrushX = (float)BrushSizeX; BrushY = (float)BrushSizeY;
		angle = atan((float)(BrushX / BrushY));
		if (invert == 0)
		{
			normalDist = (cos(atan((float)BrushY / BrushX))) * (y + x + 1) * BrushSizeY;
			if (Water != 1)
			{
				fprintf(MAPFILE, "// primitive %d\n", PrimitiveCount++);
				fprintf(MAPFILE, "{\nbrushDef3\n{\n");
				//East face
				fprintf(MAPFILE, "( 1 0 0 %d )", -((x + t.DimX)*BrushSizeX));
				getWallTextureName(t, fEAST, 0);
				//North face
				fprintf(MAPFILE, "( 0 1 0 %d )", -((y + t.DimY)*BrushSizeY));
				getWallTextureName(t, fNORTH, 0);
				//Top face
				fprintf(MAPFILE, "( 0 0 1 %d )", -BrushSizeZ * (CEILING_HEIGHT + 1));
				getFloorTextureName(t, fTOP);
				//Bottom face
				fprintf(MAPFILE, "( 0 0 -1 %d )", -2 * BrushSizeZ);
				getWallTextureName(t, fBOTTOM, 0);
				//Angled face. x & y change
				fprintf(MAPFILE, "( -%f -%f 0 %f )", cos(angle), sin(angle), +normalDist);
				getWallTextureName(t, fSELF, 0);
				fprintf(MAPFILE, "}\n}\n");
			}
			if (t.isWater == Water)
			{
				//it's floor
				fprintf(MAPFILE, "// primitive %d\n", PrimitiveCount++);
				fprintf(MAPFILE, "{\nbrushDef3\n{\n");
				//Top face
				fprintf(MAPFILE, "( 0 0 1 %d )", -((t.floorHeight) * BrushSizeZ));
				getFloorTextureName(t, fTOP);
				//West face 
				fprintf(MAPFILE, "( -1 0 0 %d )", +((x)*BrushSizeX));
				getWallTextureName(t, fWEST, t.isWater);
				//South face
				fprintf(MAPFILE, "( 0 -1 0 %d )", +((y)*BrushSizeY));
				getWallTextureName(t, fSOUTH, t.isWater);
				//Bottom face
				fprintf(MAPFILE, "( 0 0 -1 %d )", -2 * BrushSizeZ);
				getWallTextureName(t, fBOTTOM, t.isWater);
				//Angled face. x & y change
				normalDist = (cos(atan((float)BrushY / BrushX))) * (y + x + 1) * BrushSizeY;
				fprintf(MAPFILE, "( %f %f 0 %f )", cos(angle), sin(angle), -normalDist);
				getWallTextureName(t, fEAST, t.isWater);
				fprintf(MAPFILE, "}\n}\n");
			}
		}
		else
		{//its' ceiling.
			fprintf(MAPFILE, "// primitive %d\n", PrimitiveCount++);
			fprintf(MAPFILE, "{\nbrushDef3\n{\n");
			//Top face
			fprintf(MAPFILE, "( 0 0 1 %d )", -((CEILING_HEIGHT + 1) * BrushSizeZ));
			getFloorTextureName(t, fTOP);
			//West face 
			fprintf(MAPFILE, "( -1 0 0 %d )", +((x)*BrushSizeX));
			getWallTextureName(t, fWEST, t.isWater);
			//South face
			fprintf(MAPFILE, "( 0 -1 0 %d )", +((y)*BrushSizeY));
			getWallTextureName(t, fSOUTH, t.isWater);
			//Bottom face
			//fprintf (MAPFILE, "( 0 0 -1 %d )", +t.ceilingHeight * BrushSizeZ);
			fprintf(MAPFILE, "( 0 0 -1 %d ) ", +(CEILING_HEIGHT - (t.ceilingHeight))* BrushSizeZ);
			//getWallTextureName(t,fCEIL,t.isWater );
			getFloorTextureName(t, fCEIL);
			//Angled face. x & y change
			normalDist = (cos(atan((float)BrushY / BrushX))) * (y + x + 1) * BrushSizeY;
			fprintf(MAPFILE, "( %f %f 0 %f )", cos(angle), sin(angle), -normalDist);
			getWallTextureName(t, fEAST, t.isWater);
			fprintf(MAPFILE, "}\n}\n");
		}
	}
	return;
}

void RenderDiagNETile(int x, int y, tile &t, short Water, short invert)
{
	float angle = 0;
	float BrushX = 0; float BrushY = 0; float BrushZ = 0;
	float normalDist = 0;

	if (t.Render == 1){
		BrushX = (float)BrushSizeX; BrushY = (float)BrushSizeY;
		angle = atan((float)(BrushX / BrushY));
		if (invert == 0)
		{
			normalDist = (cos(atan((float)BrushY / BrushX))) * (y + x + 1) * BrushSizeY;
			if (Water != 1)
			{
				fprintf(MAPFILE, "// primitive %d\n", PrimitiveCount++);
				fprintf(MAPFILE, "{\nbrushDef3\n{\n");
				//Top face
				fprintf(MAPFILE, "( 0 0 1 %d )", -BrushSizeZ * (CEILING_HEIGHT + 1));
				getFloorTextureName(t, fTOP);
				//West face
				fprintf(MAPFILE, "( -1 0 0 %d )", +((x)*BrushSizeX));
				getWallTextureName(t, fWEST, 0);
				//South face 
				fprintf(MAPFILE, "( 0 -1 0 %d )", +((y)*BrushSizeY));
				getWallTextureName(t, fSOUTH, 0);
				//Bottom face
				fprintf(MAPFILE, "( 0 0 -1 %d )", -2 * BrushSizeZ);
				getWallTextureName(t, fBOTTOM, 0);
				//Angled face. x & y change
				fprintf(MAPFILE, "( %f %f 0 %f )", cos(angle), sin(angle), -normalDist);
				getWallTextureName(t, fSELF, 0);
				fprintf(MAPFILE, "}\n}\n");
			}
			if (t.isWater == Water)
			{
				//it's floor
				fprintf(MAPFILE, "// primitive %d\n", PrimitiveCount++);
				fprintf(MAPFILE, "{\nbrushDef3\n{\n");
				//East face
				fprintf(MAPFILE, "( 1 0 0 %d )", -((x + t.DimX)*BrushSizeX));
				getWallTextureName(t, fEAST, t.isWater);
				//North face
				fprintf(MAPFILE, "( 0 1 0 %d )", -((y + t.DimY)*BrushSizeY));
				getWallTextureName(t, fNORTH, t.isWater);
				//Top face
				fprintf(MAPFILE, "( 0 0 1 %d )", -((t.floorHeight) * BrushSizeZ));
				getFloorTextureName(t, fTOP);
				//Bottom face
				fprintf(MAPFILE, "( 0 0 -1 %d )", -2 * BrushSizeZ);
				getWallTextureName(t, fBOTTOM, t.isWater);
				//Angled face. x & y change
				normalDist = (cos(atan((float)BrushY / BrushX))) * (y + x + 1) * BrushSizeY;
				fprintf(MAPFILE, "( -%f -%f 0 %f )", cos(angle), sin(angle), +normalDist);
				getWallTextureName(t, fWEST, t.isWater);
				fprintf(MAPFILE, "}\n}\n");
			}
		}
		else
		{//it's ceiling
			fprintf(MAPFILE, "// primitive %d\n", PrimitiveCount++);
			fprintf(MAPFILE, "{\nbrushDef3\n{\n");
			//East face
			fprintf(MAPFILE, "( 1 0 0 %d )", -((x + t.DimX)*BrushSizeX));
			getWallTextureName(t, fEAST, t.isWater);
			//North face
			fprintf(MAPFILE, "( 0 1 0 %d )", -((y + t.DimY)*BrushSizeY));
			getWallTextureName(t, fNORTH, t.isWater);
			//Top face
			fprintf(MAPFILE, "( 0 0 1 %d )", -((CEILING_HEIGHT + 1) * BrushSizeZ));
			getFloorTextureName(t, fTOP);
			//Bottom face
			//fprintf (MAPFILE, "( 0 0 -1 %d )", + t.ceilingHeight * BrushSizeZ);
			fprintf(MAPFILE, "( 0 0 -1 %d ) ", +(CEILING_HEIGHT - (t.ceilingHeight))* BrushSizeZ);
			//getWallTextureName(t,fCEIL,t.isWater );
			getFloorTextureName(t, fCEIL);
			//Angled face. x & y change
			normalDist = (cos(atan((float)BrushY / BrushX))) * (y + x + 1) * BrushSizeY;
			fprintf(MAPFILE, "( -%f -%f 0 %f )", cos(angle), sin(angle), +normalDist);
			getWallTextureName(t, fWEST, t.isWater);
			fprintf(MAPFILE, "}\n}\n");
		}
	}
	return;
}

void RenderDiagNWTile(int x, int y, tile &t, short Water, short invert)
{
	float angle = 0;
	float BrushX = 0; float BrushY = 0; float BrushZ = 0;
	float normalDist = 0;

	if (t.Render == 1)
	{
		BrushX = (float)BrushSizeX; BrushY = (float)BrushSizeY;
		angle = atan((float)(BrushX / BrushY));
		normalDist = (cos(atan((float)BrushY / BrushX))) * (x - y) * BrushSizeY;
		if (invert == 0)
		{
			if (Water != 1)
			{
				fprintf(MAPFILE, "// primitive %d\n", PrimitiveCount++);
				fprintf(MAPFILE, "{\nbrushDef3\n{\n");
				//East face -absdist
				fprintf(MAPFILE, "( 1 0 0 %d )", -((x + t.DimX)*BrushSizeX));
				getWallTextureName(t, fEAST, 0);
				//Top face
				fprintf(MAPFILE, "( 0 0 1 %d )", -BrushSizeZ * (CEILING_HEIGHT + 1));
				getFloorTextureName(t, fTOP);
				//South face
				fprintf(MAPFILE, "( 0 -1 0 %d )", +((y)*BrushSizeY));
				getWallTextureName(t, fSOUTH, 0);
				//Bottom face
				fprintf(MAPFILE, "( 0 0 -1 %d )", -2 * BrushSizeZ);
				getWallTextureName(t, fBOTTOM, 0);
				//Angled face. x & y change
				fprintf(MAPFILE, "( -%f %f 0 %f )", cos(angle), sin(angle), normalDist);
				getWallTextureName(t, fSELF, 0);
				fprintf(MAPFILE, "}\n}\n");
			}

			//it's floor
			if (t.isWater == Water)
			{
				fprintf(MAPFILE, "// primitive %d\n", PrimitiveCount++);
				fprintf(MAPFILE, "{\nbrushDef3\n{\n");
				//North face
				fprintf(MAPFILE, "( 0 1 0 %d )", -((y + t.DimY)*BrushSizeY));
				getWallTextureName(t, fNORTH, t.isWater);
				//Top face
				fprintf(MAPFILE, "( 0 0 1 %d )", -((t.floorHeight) * BrushSizeZ));
				getFloorTextureName(t, fTOP);
				//West face
				fprintf(MAPFILE, "( -1 0 0 %d )", +((x)*BrushSizeX));
				getWallTextureName(t, fWEST, t.isWater);
				//Bottom face +absdist
				fprintf(MAPFILE, "( 0 0 -1 %d )", -2 * BrushSizeZ);
				getWallTextureName(t, fBOTTOM, t.isWater);
				//Angled face. x & y change
				normalDist = (cos(atan((float)BrushY / BrushX))) * (x - y) * BrushSizeY;
				fprintf(MAPFILE, "( %f -%f 0 %f )", cos(angle), sin(angle), -normalDist);
				getWallTextureName(t, fWEST, t.isWater);
				fprintf(MAPFILE, "}\n}\n");
			}
		}
		else
		{//it's ceiling
			fprintf(MAPFILE, "// primitive %d\n", PrimitiveCount++);
			fprintf(MAPFILE, "{\nbrushDef3\n{\n");
			//North face
			fprintf(MAPFILE, "( 0 1 0 %d )", -((y + t.DimY)*BrushSizeY));
			getWallTextureName(t, fNORTH, t.isWater);
			//Top face
			fprintf(MAPFILE, "( 0 0 1 %d )", -((CEILING_HEIGHT + 1) * BrushSizeZ));
			getFloorTextureName(t, fTOP);
			//West face
			fprintf(MAPFILE, "( -1 0 0 %d )", +((x)*BrushSizeX));
			getWallTextureName(t, fWEST, t.isWater);
			//Bottom face +absdist
			//fprintf (MAPFILE, "( 0 0 -1 %d )", +t.ceilingHeight * BrushSizeZ);
			fprintf(MAPFILE, "( 0 0 -1 %d ) ", +(CEILING_HEIGHT - (t.ceilingHeight))* BrushSizeZ);
			//getWallTextureName(t,fCEIL,t.isWater );
			getFloorTextureName(t, fCEIL);
			//Angled face. x & y change
			normalDist = (cos(atan((float)BrushY / BrushX))) * (x - y) * BrushSizeY;
			fprintf(MAPFILE, "( %f -%f 0 %f )", cos(angle), sin(angle), -normalDist);
			getWallTextureName(t, fWEST, t.isWater);
			fprintf(MAPFILE, "}\n}\n");
		}
	}
	return;
}

void RenderSlopeNTile(int x, int y, tile &t, short Water, short invert)
{
	float angle = 0;
	float BrushX = 0; float BrushY = 0; float BrushZ = 0;
	float normalDist = 0;
	float floorHeight = t.floorHeight;
	float ceilingHeight = (CEILING_HEIGHT - (t.ceilingHeight));//-1
	float steepness = t.shockSteep;

	if (t.Render == 1){
		if (invert == 0)
		{
			BrushZ = (float)BrushSizeZ*steepness; BrushY = (float)BrushSizeY;
			angle = atan((float)(BrushY / BrushZ));
			normalDist = (cos(atan(BrushZ / BrushY))) * ((floorHeight / steepness) - y) * BrushZ;
			if (t.isWater == Water)
			{
				fprintf(MAPFILE, "// primitive %d\n", PrimitiveCount++);
				fprintf(MAPFILE, "{\nbrushDef3\n{\n");
				//East face
				fprintf(MAPFILE, "( 1 0 0 %d )", -((x + t.DimX)*BrushSizeX));
				getWallTextureName(t, fEAST, t.isWater);
				//North face
				fprintf(MAPFILE, "( 0 1 0 %d )", -((y + t.DimY)*BrushSizeY));
				getWallTextureName(t, fNORTH, t.isWater);
				//Top face
				fprintf(MAPFILE, "( 0 %f %f %f )", -cos(angle), sin(angle), -normalDist);
				getFloorTextureName(t, fTOP);
				//West face
				fprintf(MAPFILE, "( -1 0 0 %d )", +((x)*BrushSizeX));
				getWallTextureName(t, fWEST, t.isWater);
				//South face
				fprintf(MAPFILE, "( 0 -1 0 %d )", +((y)*BrushSizeY));
				getWallTextureName(t, fSOUTH, t.isWater);
				//Bottom face
				fprintf(MAPFILE, "( 0 0 -1 %d )", -2 * BrushSizeZ);
				getWallTextureName(t, fBOTTOM, t.isWater);
				fprintf(MAPFILE, "}\n}\n");
			}
		}
		else
		{
			BrushZ = (float)BrushSizeZ*steepness; BrushY = (float)BrushSizeY;
			angle = atan((float)(BrushY / BrushZ));
			normalDist = (cos(atan(BrushZ / BrushY))) * ((ceilingHeight / steepness) - y - 1) * BrushZ;

			fprintf(MAPFILE, "// primitive %d\n", PrimitiveCount++);
			fprintf(MAPFILE, "{\nbrushDef3\n{\n");
			//East face
			fprintf(MAPFILE, "( 1 0 0 %d )", -((x + t.DimX)*BrushSizeX));
			getWallTextureName(t, fEAST, t.isWater);
			//North face
			fprintf(MAPFILE, "( 0 1 0 %d )", -((y + t.DimY)*BrushSizeY));
			getWallTextureName(t, fNORTH, t.isWater);
			//Top face	->becomes ceiling 
			fprintf(MAPFILE, "( 0 0 1 %d )", -(CEILING_HEIGHT + 1)*BrushSizeZ);

			getFloorTextureName(t, fTOP);
			//West face
			fprintf(MAPFILE, "( -1 0 0 %d )", +((x)*BrushSizeX));
			getWallTextureName(t, fWEST, t.isWater);
			//South face
			fprintf(MAPFILE, "( 0 -1 0 %d )", +((y)*BrushSizeY));
			getWallTextureName(t, fSOUTH, t.isWater);
			//Bottom face
			fprintf(MAPFILE, "( 0 %f %f %f )", cos(angle), -sin(angle), +normalDist);
			getFloorTextureName(t, fCEIL);
			fprintf(MAPFILE, "}\n}\n");

		}
	}
	return;
}

void RenderSlopeSTile(int x, int y, tile &t, short Water, short invert)
{
	float angle = 0;
	float BrushX = 0; float BrushY = 0; float BrushZ = 0;
	float normalDist = 0;
	float floorHeight = t.floorHeight;
	float steepness = t.shockSteep;
	float ceilingHeight = CEILING_HEIGHT - t.ceilingHeight;//t.floorHeight + t.ceilingHeight ;// -(t.ceilingHeight)) ;

	if (t.Render == 1)
	{
		if (invert == 0)
		{
			BrushZ = (float)BrushSizeZ*steepness; BrushY = (float)BrushSizeY;
			angle = atan((float)(BrushY / BrushZ));
			normalDist = (cos(atan(BrushZ / BrushY))) * ((floorHeight / steepness) + y + 1) * BrushZ;
			if (t.isWater == Water)
			{
				fprintf(MAPFILE, "// primitive %d\n", PrimitiveCount++);
				fprintf(MAPFILE, "{\nbrushDef3\n{\n");
				//East face
				fprintf(MAPFILE, "( 1 0 0 %d )", -((x + t.DimX)*BrushSizeX));
				getWallTextureName(t, fEAST, t.isWater);
				//North face
				fprintf(MAPFILE, "( 0 1 0 %d )", -((y + t.DimY)*BrushSizeY));
				getWallTextureName(t, fNORTH, t.isWater);
				//Top face
				fprintf(MAPFILE, "( 0 %f %f %f )", cos(angle), sin(angle), -normalDist);
				getFloorTextureName(t, fTOP);
				//West face
				fprintf(MAPFILE, "( -1 0 0 %d )", +((x)*BrushSizeX));
				getWallTextureName(t, fWEST, t.isWater);
				//South face
				fprintf(MAPFILE, "( 0 -1 0 %d )", +((y)*BrushSizeY));
				getWallTextureName(t, fSOUTH, t.isWater);
				//Bottom face +absdist
				fprintf(MAPFILE, "( 0 0 -1 %d )", -2 * BrushSizeZ);	//+10 to go underneath
				getWallTextureName(t, fBOTTOM, t.isWater);
				fprintf(MAPFILE, "}\n}\n");
			}
		}
		else
		{

			BrushZ = (float)BrushSizeZ*steepness; BrushY = (float)BrushSizeY;
			angle = atan((float)(BrushY / BrushZ));
			//normalDist = (cos(atan(BrushZ/BrushY))) * ((ceilingHeight/steepness) -y) * BrushZ;
			normalDist = (cos(atan(BrushZ / BrushY))) * ((ceilingHeight / steepness) + y) * BrushZ;
			fprintf(MAPFILE, "// primitive %d\n", PrimitiveCount++);
			fprintf(MAPFILE, "{\nbrushDef3\n{\n");
			//East face
			fprintf(MAPFILE, "( 1 0 0 %d )", -((x + t.DimX)*BrushSizeX));
			getWallTextureName(t, fEAST, t.isWater);
			//North face
			fprintf(MAPFILE, "( 0 1 0 %d )", -((y + t.DimY)*BrushSizeY));
			getWallTextureName(t, fNORTH, t.isWater);
			//Top face	->becomes ceiling 
			fprintf(MAPFILE, "( 0 0 1 %d )", -(CEILING_HEIGHT + 1)*BrushSizeZ);

			getFloorTextureName(t, fTOP);
			//West face
			fprintf(MAPFILE, "( -1 0 0 %d )", +((x)*BrushSizeX));
			getWallTextureName(t, fWEST, t.isWater);
			//South face
			fprintf(MAPFILE, "( 0 -1 0 %d )", +((y)*BrushSizeY));
			getWallTextureName(t, fSOUTH, t.isWater);
			//Bottom face
			fprintf(MAPFILE, "( 0 %f %f %f )", -cos(angle), -sin(angle), +normalDist);
			getFloorTextureName(t, fCEIL);
			fprintf(MAPFILE, "}\n}\n");

		}
	}
	return;

}

void RenderSlopeWTile(int x, int y, tile &t, short Water, short invert)
{
	float angle = 0;
	float BrushX = 0; float BrushY = 0; float BrushZ = 0;
	float normalDist = 0;
	float floorHeight = t.floorHeight;
	float steepness = t.shockSteep;
	float ceilingHeight = t.ceilingHeight;
	if (t.Render == 1){
		if (invert == 0)
		{
			BrushZ = (float)BrushSizeZ*steepness; BrushX = (float)BrushSizeX;
			angle = atan((float)(BrushX / BrushZ));
			normalDist = (cos(atan(BrushZ / BrushX))) * ((floorHeight) / steepness + x + 1) * BrushZ;
			if (t.isWater == Water)
			{
				fprintf(MAPFILE, "// primitive %d\n", PrimitiveCount++);
				fprintf(MAPFILE, "{\nbrushDef3\n{\n");
				//East face
				fprintf(MAPFILE, "( 1 0 0 %d )", -((x + t.DimX)*BrushSizeX));
				getWallTextureName(t, fEAST, t.isWater);
				//North face
				fprintf(MAPFILE, "( 0 1 0 %d )", -((y + t.DimY)*BrushSizeY));
				getWallTextureName(t, fNORTH, t.isWater);
				//Top face
				fprintf(MAPFILE, "( %f 0 %f %f )", cos(angle), sin(angle), -normalDist);
				getFloorTextureName(t, fTOP);
				//West face
				fprintf(MAPFILE, "( -1 0 0 %d )", +((x)*BrushSizeX));
				getWallTextureName(t, fWEST, t.isWater);
				//South face
				fprintf(MAPFILE, "( 0 -1 0 %d )", +((y)*BrushSizeY));
				getWallTextureName(t, fSOUTH, t.isWater);
				//Bottom face
				fprintf(MAPFILE, "( 0 0 -1 %d )", -2 * BrushSizeZ);	//+10 to go underneath
				getWallTextureName(t, fBOTTOM, t.isWater);
				fprintf(MAPFILE, "}\n}\n");
			}
		}
		else
		{
			BrushZ = (float)BrushSizeZ*steepness; BrushX = (float)BrushSizeX;
			angle = atan((float)(BrushX / (BrushZ)));
			//((+x) + ((CEILING_HEIGHT-ceilingHeight)/steepness))
			normalDist = (cos(atan((BrushZ) / (BrushX)))) * ((-x) - ((CEILING_HEIGHT - ceilingHeight) / steepness)) * BrushZ;

			fprintf(MAPFILE, "// primitive %d\n", PrimitiveCount++);
			fprintf(MAPFILE, "{\nbrushDef3\n{\n");
			//East face
			fprintf(MAPFILE, "( 1 0 0 %d )", -((x + t.DimX)*BrushSizeX));
			getWallTextureName(t, fEAST, t.isWater);
			//North face
			fprintf(MAPFILE, "( 0 1 0 %d )", -((y + t.DimY)*BrushSizeY));
			getWallTextureName(t, fNORTH, t.isWater);
			//Top face
			fprintf(MAPFILE, "( 0 0 1 %d )", -(CEILING_HEIGHT + 1)*BrushSizeZ);
			getFloorTextureName(t, fTOP);
			//West face
			fprintf(MAPFILE, "( -1 0 0 %d )", +((x)*BrushSizeX));
			getWallTextureName(t, fWEST, t.isWater);
			//South face
			fprintf(MAPFILE, "( 0 -1 0 %d )", +((y)*BrushSizeY));
			getWallTextureName(t, fSOUTH, t.isWater);
			//Bottom face
			fprintf(MAPFILE, "( %f 0 %f %f )", -cos(angle), -sin(angle), -normalDist);
			getFloorTextureName(t, fCEIL);
			fprintf(MAPFILE, "}\n}\n");
		}
	}
	return;
}

void RenderSlopeETile(int x, int y, tile &t, short Water, short invert)
{
	float angle = 0;
	float BrushX = 0; float BrushY = 0; float BrushZ = 0;
	float normalDist = 0;
	float floorHeight = t.floorHeight;
	float steepness = t.shockSteep;
	float ceilingHeight = t.ceilingHeight;

	if (t.Render == 1){
		if (invert == 0)
		{
			BrushZ = (float)BrushSizeZ*steepness; BrushX = (float)BrushSizeX;
			angle = atan((float)(BrushX / (BrushZ)));
			normalDist = (cos(atan((BrushZ) / (BrushX)))) * ((floorHeight / steepness) - (x)) * BrushZ;
			if (t.isWater == Water)
			{
				fprintf(MAPFILE, "// primitive %d\n", PrimitiveCount++);
				fprintf(MAPFILE, "{\nbrushDef3\n{\n");
				//East face
				fprintf(MAPFILE, "( 1 0 0 %d )", -((x + t.DimX)*BrushSizeX));
				getWallTextureName(t, fEAST, t.isWater);
				//North face 
				fprintf(MAPFILE, "( 0 1 0 %d )", -((y + t.DimY)*BrushSizeY));
				getWallTextureName(t, fNORTH, t.isWater);
				//Top face
				fprintf(MAPFILE, "( -%f 0 %f %f )", cos(angle), sin(angle), -normalDist);
				getFloorTextureName(t, fTOP);
				//West face
				fprintf(MAPFILE, "( -1 0 0 %d )", +((x)*BrushSizeX));
				getWallTextureName(t, fWEST, t.isWater);
				//South face
				fprintf(MAPFILE, "( 0 -1 0 %d )", +((y)*BrushSizeY));
				getWallTextureName(t, fSOUTH, t.isWater);
				//Bottom face
				fprintf(MAPFILE, "( 0 0 -1 %d )", -2 * BrushSizeZ);
				getWallTextureName(t, fBOTTOM, t.isWater);
				fprintf(MAPFILE, "}\n}\n");
			}
		}
		else
		{
			BrushZ = (float)BrushSizeZ*steepness; BrushX = (float)BrushSizeX;
			angle = atan((float)(BrushX / BrushZ));
			normalDist = (cos(atan(BrushZ / BrushX))) * ((+x + 1) - ((CEILING_HEIGHT - ceilingHeight) / steepness)) * BrushZ;
			fprintf(MAPFILE, "// primitive %d\n", PrimitiveCount++);
			fprintf(MAPFILE, "{\nbrushDef3\n{\n");
			//East face
			fprintf(MAPFILE, "( 1 0 0 %d )", -((x + t.DimX)*BrushSizeX));
			getWallTextureName(t, fEAST, t.isWater);
			//North face
			fprintf(MAPFILE, "( 0 1 0 %d )", -((y + t.DimY)*BrushSizeY));
			getWallTextureName(t, fNORTH, t.isWater);
			//Top face
			fprintf(MAPFILE, "( 0 0 1 %d )", -(CEILING_HEIGHT + 1)*BrushSizeZ);
			getFloorTextureName(t, fTOP);
			//West face
			fprintf(MAPFILE, "( -1 0 0 %d )", +((x)*BrushSizeX));
			getWallTextureName(t, fWEST, t.isWater);
			//South face
			fprintf(MAPFILE, "( 0 -1 0 %d )", +((y)*BrushSizeY));
			getWallTextureName(t, fSOUTH, t.isWater);
			//Bottom face
			fprintf(MAPFILE, "( %f 0 %f %f )", cos(angle), -sin(angle), -normalDist);
			getFloorTextureName(t, fCEIL);
			fprintf(MAPFILE, "}\n}\n");

		}
	}
	return;
}

void RenderValleyNWTile(int x, int y, tile &t, short Water, short invert)
{
	int originalTile = t.tileType;
	t.tileType = TILE_SLOPE_N;
	RenderSlopeNTile(x, y, t, Water, invert);
	t.tileType = TILE_SLOPE_W;
	RenderSlopeWTile(x, y, t, Water, invert);
	t.tileType = originalTile;
	return;
}

void RenderValleyNETile(int x, int y, tile &t, short Water, short invert)
{
	int originalTile = t.tileType;
	t.tileType = TILE_SLOPE_E;
	RenderSlopeETile(x, y, t, Water, invert);
	t.tileType = TILE_SLOPE_N;
	RenderSlopeNTile(x, y, t, Water, invert);
	t.tileType = originalTile;
	return;
}

void RenderValleySWTile(int x, int y, tile &t, short Water, short invert)
{
	int originalTile = t.tileType;
	t.tileType = TILE_SLOPE_W;
	RenderSlopeWTile(x, y, t, Water, invert);
	t.tileType = TILE_SLOPE_S;
	RenderSlopeSTile(x, y, t, Water, invert);
	t.tileType = originalTile;
	return;
}

void RenderValleySETile(int x, int y, tile &t, short Water, short invert)
{
	int originalTile = t.tileType;
	t.tileType = TILE_SLOPE_E;
	RenderSlopeETile(x, y, t, Water, invert);
	t.tileType = TILE_SLOPE_S;
	RenderSlopeSTile(x, y, t, Water, invert);
	t.tileType = originalTile;
	return;
}

void RenderRidgeNWTile(int x, int y, tile &t, short Water, short invert)
{
	float angle = 0;
	float BrushX = 0; float BrushY = 0; float BrushZ = 0;
	float normalDist = 0;
	float floorHeight = t.floorHeight;
	float steepness = t.shockSteep;

	if (t.Render == 1){
		if (invert == 0)

		{//consists of a slope n and a slope w
			BrushZ = (float)BrushSizeZ*steepness; BrushY = (float)BrushSizeY;
			angle = atan((float)(BrushY / BrushZ));
			normalDist = (cos(atan(BrushZ / BrushY))) * ((floorHeight / steepness) - y) * BrushZ;
			if (t.isWater == Water)
			{
				fprintf(MAPFILE, "// primitive %d\n", PrimitiveCount++);
				fprintf(MAPFILE, "{\nbrushDef3\n{\n");
				//East face
				fprintf(MAPFILE, "( 1 0 0 %d )", -((x + t.DimX)*BrushSizeX));
				getWallTextureName(t, fEAST, t.isWater);
				//North face
				fprintf(MAPFILE, "( 0 1 0 %d )", -((y + t.DimY)*BrushSizeY));
				getWallTextureName(t, fNORTH, t.isWater);
				//Top face
				fprintf(MAPFILE, "( 0 %f %f %f )", -cos(angle), sin(angle), -normalDist);
				getFloorTextureName(t, fTOP);
				//West face
				fprintf(MAPFILE, "( -1 0 0 %d )", +((x)*BrushSizeX));
				getWallTextureName(t, fWEST, t.isWater);
				//South face
				fprintf(MAPFILE, "( 0 -1 0 %d )", +((y)*BrushSizeY));
				getWallTextureName(t, fSOUTH, t.isWater);
				//Bottom face
				fprintf(MAPFILE, "( 0 0 -1 %d )", -2 * BrushSizeZ);
				getWallTextureName(t, fBOTTOM, t.isWater);

				//the other slope(w)
				BrushZ = (float)BrushSizeZ*steepness; BrushX = (float)BrushSizeX;
				angle = atan((float)(BrushX / BrushZ));
				normalDist = (cos(atan(BrushZ / BrushX))) * ((floorHeight) / steepness + x + 1) * BrushZ;
				fprintf(MAPFILE, "( %f 0 %f %f )", cos(angle), sin(angle), -normalDist);
				getFloorTextureName(t, fTOP);
				fprintf(MAPFILE, "}\n}\n");
			}
		}
		else
		{//made of upper slope e and upper slope s
			//render a ceiling version of this tile
			//top and bottom faces move up
			fprintf(MAPFILE, "// primitive %d\n", PrimitiveCount++);
			fprintf(MAPFILE, "{\nbrushDef3\n{\n");
			//East face
			fprintf(MAPFILE, "( 1 0 0 %d )", -((x + t.DimX)*BrushSizeX));
			getWallTextureName(t, fEAST, t.isWater);
			//North face
			fprintf(MAPFILE, "( 0 1 0 %d ) ", -((y + t.DimY)*BrushSizeY));
			getWallTextureName(t, fNORTH, t.isWater);
			//Top face
			fprintf(MAPFILE, "( 0 0 1 %d )", -((CEILING_HEIGHT)* BrushSizeZ));
			getFloorTextureName(t, fTOP);
			//West face
			fprintf(MAPFILE, "( -1 0 0 %d )", +((x)*BrushSizeX));
			getWallTextureName(t, fWEST, t.isWater);
			//South face
			fprintf(MAPFILE, "( 0 -1 0 %d )", +((y)*BrushSizeY));
			getWallTextureName(t, fSOUTH, t.isWater);
			//Bottom face 
			//s and e here
			float ceilingHeight = CEILING_HEIGHT - t.ceilingHeight;
			BrushZ = (float)BrushSizeZ*steepness; BrushY = (float)BrushSizeY;
			angle = atan((float)(BrushY / BrushZ));
			normalDist = (cos(atan(BrushZ / BrushY))) * ((ceilingHeight / steepness) + y) * BrushZ;
			fprintf(MAPFILE, "( 0 %f %f %f )", -cos(angle), -sin(angle), +normalDist);
			getFloorTextureName(t, fCEIL);

			ceilingHeight = t.ceilingHeight;
			BrushZ = (float)BrushSizeZ*steepness; BrushX = (float)BrushSizeX;
			angle = atan((float)(BrushX / BrushZ));
			normalDist = (cos(atan(BrushZ / BrushX))) * ((+x + 1) - ((CEILING_HEIGHT - ceilingHeight) / steepness)) * BrushZ;
			fprintf(MAPFILE, "( %f 0 %f %f )", cos(angle), -sin(angle), -normalDist);
			getWallTextureName(t, fCEIL, t.isWater);

			fprintf(MAPFILE, "}\n}\n");
		}

	}
	return;
}

void RenderRidgeNETile(int x, int y, tile &t, short Water, short invert)
{
	//consists of a slope n and a slope e
	float angle = 0;
	float BrushX = 0; float BrushY = 0; float BrushZ = 0;
	float normalDist = 0;
	float floorHeight = t.floorHeight;
	float steepness = t.shockSteep;

	if (t.Render == 1){
		if (invert == 0){
			BrushZ = (float)BrushSizeZ*steepness; BrushY = (float)BrushSizeY;
			angle = atan((float)(BrushY / BrushZ));
			normalDist = (cos(atan(BrushZ / BrushY))) * ((floorHeight / steepness) - y) * BrushZ;
			if (t.isWater == Water)
			{
				fprintf(MAPFILE, "// primitive %d\n", PrimitiveCount++);
				fprintf(MAPFILE, "{\nbrushDef3\n{\n");
				//East face
				fprintf(MAPFILE, "( 1 0 0 %d )", -((x + t.DimX)*BrushSizeX));
				getWallTextureName(t, fEAST, t.isWater);
				//North face
				fprintf(MAPFILE, "( 0 1 0 %d )", -((y + t.DimY)*BrushSizeY));
				getWallTextureName(t, fNORTH, t.isWater);
				//Top face
				fprintf(MAPFILE, "( 0 %f %f %f )", -cos(angle), sin(angle), -normalDist);
				getFloorTextureName(t, fTOP);
				//West face
				fprintf(MAPFILE, "( -1 0 0 %d )", +((x)*BrushSizeX));
				getWallTextureName(t, fWEST, t.isWater);
				//South face
				fprintf(MAPFILE, "( 0 -1 0 %d )", +((y)*BrushSizeY));
				getWallTextureName(t, fSOUTH, t.isWater);
				//Bottom face
				fprintf(MAPFILE, "( 0 0 -1 %d )", -2 * BrushSizeZ);
				getWallTextureName(t, fBOTTOM, t.isWater);

				//slope e
				BrushZ = (float)BrushSizeZ*steepness; BrushX = (float)BrushSizeX;
				angle = atan((float)(BrushX / (BrushZ)));
				normalDist = (cos(atan((BrushZ) / (BrushX)))) * ((floorHeight / steepness) - (x)) * BrushZ;
				fprintf(MAPFILE, "( -%f 0 %f %f )", cos(angle), sin(angle), -normalDist);
				getFloorTextureName(t, fTOP);
				fprintf(MAPFILE, "}\n}\n");
			}
		}
		else
		{//invert is south and west slopes

			//render a ceiling version of this tile
			//top and bottom faces move up
			fprintf(MAPFILE, "// primitive %d\n", PrimitiveCount++);
			fprintf(MAPFILE, "{\nbrushDef3\n{\n");
			//East face
			fprintf(MAPFILE, "( 1 0 0 %d )", -((x + t.DimX)*BrushSizeX));
			getWallTextureName(t, fEAST, t.isWater);
			//North face
			fprintf(MAPFILE, "( 0 1 0 %d ) ", -((y + t.DimY)*BrushSizeY));
			getWallTextureName(t, fNORTH, t.isWater);
			//Top face
			fprintf(MAPFILE, "( 0 0 1 %d )", -((CEILING_HEIGHT)* BrushSizeZ));
			getFloorTextureName(t, fTOP);
			//West face
			fprintf(MAPFILE, "( -1 0 0 %d )", +((x)*BrushSizeX));
			getWallTextureName(t, fWEST, t.isWater);
			//South face
			fprintf(MAPFILE, "( 0 -1 0 %d )", +((y)*BrushSizeY));
			getWallTextureName(t, fSOUTH, t.isWater);
			//Bottom face
			//s
			float ceilingHeight = CEILING_HEIGHT - t.ceilingHeight;
			BrushZ = (float)BrushSizeZ*steepness; BrushY = (float)BrushSizeY;
			angle = atan((float)(BrushY / BrushZ));
			normalDist = (cos(atan(BrushZ / BrushY))) * ((ceilingHeight / steepness) + y) * BrushZ;
			fprintf(MAPFILE, "( 0 %f %f %f )", -cos(angle), -sin(angle), +normalDist);
			getFloorTextureName(t, fCEIL);
			//w
			ceilingHeight = t.ceilingHeight;
			BrushZ = (float)BrushSizeZ*steepness; BrushX = (float)BrushSizeX;
			angle = atan((float)(BrushX / (BrushZ)));
			normalDist = (cos(atan((BrushZ) / (BrushX)))) * ((-x) - ((CEILING_HEIGHT - ceilingHeight) / steepness)) * BrushZ;
			fprintf(MAPFILE, "( %f 0 %f %f )", -cos(angle), -sin(angle), -normalDist);
			getFloorTextureName(t, fCEIL);
			fprintf(MAPFILE, "}\n}\n");
		}
	}

	return;
}

void RenderRidgeSWTile(int x, int y, tile &t, short Water, short invert)
{
	//consists of a slope s and a slope w
	float angle = 0;
	float BrushX = 0; float BrushY = 0; float BrushZ = 0;
	float normalDist = 0;
	float floorHeight = t.floorHeight;
	float steepness = t.shockSteep;

	if (t.Render == 1)
	if (invert == 0)
	{
		{
			BrushZ = (float)BrushSizeZ*steepness; BrushY = (float)BrushSizeY;
			angle = atan((float)(BrushY / BrushZ));
			normalDist = (cos(atan(BrushZ / BrushY))) * ((floorHeight / steepness) + y + 1) * BrushZ;
			if (t.isWater == Water)
			{
				fprintf(MAPFILE, "// primitive %d\n", PrimitiveCount++);
				fprintf(MAPFILE, "{\nbrushDef3\n{\n");
				//East face
				fprintf(MAPFILE, "( 1 0 0 %d )", -((x + t.DimX)*BrushSizeX));
				getWallTextureName(t, fEAST, t.isWater);
				//North face
				fprintf(MAPFILE, "( 0 1 0 %d )", -((y + t.DimY)*BrushSizeY));
				getWallTextureName(t, fNORTH, t.isWater);
				//Top face
				fprintf(MAPFILE, "( 0 %f %f %f )", cos(angle), sin(angle), -normalDist);
				getFloorTextureName(t, fTOP);
				//West face
				fprintf(MAPFILE, "( -1 0 0 %d )", +((x)*BrushSizeX));
				getWallTextureName(t, fWEST, t.isWater);
				//South face
				fprintf(MAPFILE, "( 0 -1 0 %d )", +((y)*BrushSizeY));
				getWallTextureName(t, fSOUTH, t.isWater);
				//Bottom face +absdist
				fprintf(MAPFILE, "( 0 0 -1 %d )", -2 * BrushSizeZ);	//+10 to go underneath
				getWallTextureName(t, fBOTTOM, t.isWater);

				//slope w
				BrushZ = (float)BrushSizeZ*steepness; BrushX = (float)BrushSizeX;
				angle = atan((float)(BrushX / BrushZ));
				normalDist = (cos(atan(BrushZ / BrushX))) * ((floorHeight) / steepness + x + 1) * BrushZ;
				fprintf(MAPFILE, "( %f 0 %f %f )", cos(angle), sin(angle), -normalDist);
				getFloorTextureName(t, fTOP);
				fprintf(MAPFILE, "}\n}\n");
			}
		}
	}
	else
	{	//invert is n and w slopes
		//render a ceiling version of this tile
		fprintf(MAPFILE, "// primitive %d\n", PrimitiveCount++);
		fprintf(MAPFILE, "{\nbrushDef3\n{\n");
		//East face
		fprintf(MAPFILE, "( 1 0 0 %d )", -((x + t.DimX)*BrushSizeX));
		getWallTextureName(t, fEAST, t.isWater);
		//North face
		fprintf(MAPFILE, "( 0 1 0 %d ) ", -((y + t.DimY)*BrushSizeY));
		getWallTextureName(t, fNORTH, t.isWater);
		//Top face
		fprintf(MAPFILE, "( 0 0 1 %d )", -((CEILING_HEIGHT)* BrushSizeZ));
		getFloorTextureName(t, fTOP);
		//West face
		fprintf(MAPFILE, "( -1 0 0 %d )", +((x)*BrushSizeX));
		getWallTextureName(t, fWEST, t.isWater);
		//South face
		fprintf(MAPFILE, "( 0 -1 0 %d )", +((y)*BrushSizeY));
		getWallTextureName(t, fSOUTH, t.isWater);
		//Bottom faces
		//e
		float ceilingHeight = t.ceilingHeight;
		BrushZ = (float)BrushSizeZ*steepness; BrushX = (float)BrushSizeX;
		angle = atan((float)(BrushX / BrushZ));
		normalDist = (cos(atan(BrushZ / BrushX))) * ((+x + 1) - ((CEILING_HEIGHT - ceilingHeight) / steepness)) * BrushZ;
		fprintf(MAPFILE, "( %f 0 %f %f )", cos(angle), -sin(angle), -normalDist);
		getFloorTextureName(t, fCEIL);

		//n
		ceilingHeight = (CEILING_HEIGHT - (t.ceilingHeight));
		BrushZ = (float)BrushSizeZ*steepness; BrushY = (float)BrushSizeY;
		angle = atan((float)(BrushY / BrushZ));
		normalDist = (cos(atan(BrushZ / BrushY))) * ((ceilingHeight / steepness) - y - 1) * BrushZ;
		fprintf(MAPFILE, "( 0 %f %f %f )", cos(angle), -sin(angle), +normalDist);
		getFloorTextureName(t, fCEIL);
		fprintf(MAPFILE, "}\n}\n");

	}
	return;
}

void RenderRidgeSETile(int x, int y, tile &t, short Water, short invert)
{
	//consists of a slope s and a slope e
	//done
	float angle = 0;
	float BrushX = 0; float BrushY = 0; float BrushZ = 0;
	float normalDist = 0;
	float floorHeight = t.floorHeight;
	float steepness = t.shockSteep;

	if (t.Render == 1)
	{
		if (invert == 0)
		{
			BrushZ = (float)BrushSizeZ*steepness; BrushY = (float)BrushSizeY;
			angle = atan((float)(BrushY / BrushZ));
			normalDist = (cos(atan(BrushZ / BrushY))) * ((floorHeight / steepness) + y + 1) * BrushZ;
			if (t.isWater == Water)
			{
				fprintf(MAPFILE, "// primitive %d\n", PrimitiveCount++);
				fprintf(MAPFILE, "{\nbrushDef3\n{\n");
				//East face
				fprintf(MAPFILE, "( 1 0 0 %d )", -((x + t.DimX)*BrushSizeX));
				getWallTextureName(t, fEAST, t.isWater);
				//North face
				fprintf(MAPFILE, "( 0 1 0 %d )", -((y + t.DimY)*BrushSizeY));
				getWallTextureName(t, fNORTH, t.isWater);
				//Top face
				fprintf(MAPFILE, "( 0 %f %f %f )", cos(angle), sin(angle), -normalDist);
				getFloorTextureName(t, fTOP);
				//West face
				fprintf(MAPFILE, "( -1 0 0 %d )", +((x)*BrushSizeX));
				getWallTextureName(t, fWEST, t.isWater);
				//South face
				fprintf(MAPFILE, "( 0 -1 0 %d )", +((y)*BrushSizeY));
				getWallTextureName(t, fSOUTH, t.isWater);
				//Bottom face +absdist
				fprintf(MAPFILE, "( 0 0 -1 %d )", -2 * BrushSizeZ);	//+10 to go underneath
				getWallTextureName(t, fBOTTOM, t.isWater);

				//Other sloped face
				BrushZ = (float)BrushSizeZ*steepness; BrushX = (float)BrushSizeX;
				angle = atan((float)(BrushX / (BrushZ)));
				normalDist = (cos(atan((BrushZ) / (BrushX)))) * ((floorHeight / steepness) - (x)) * BrushZ;
				fprintf(MAPFILE, "( -%f 0 %f %f )", cos(angle), sin(angle), -normalDist);
				getFloorTextureName(t, fTOP);

				fprintf(MAPFILE, "}\n}\n");
			}
		}
		else
		{//invert is n w
			//render a ceiling version of this tile
			//top and bottom faces move up
			fprintf(MAPFILE, "// primitive %d\n", PrimitiveCount++);
			fprintf(MAPFILE, "{\nbrushDef3\n{\n");
			//East face
			fprintf(MAPFILE, "( 1 0 0 %d )", -((x + t.DimX)*BrushSizeX));
			getWallTextureName(t, fEAST, t.isWater);
			//North face
			fprintf(MAPFILE, "( 0 1 0 %d ) ", -((y + t.DimY)*BrushSizeY));
			getWallTextureName(t, fNORTH, t.isWater);
			//Top face
			fprintf(MAPFILE, "( 0 0 1 %d )", -((CEILING_HEIGHT)* BrushSizeZ));
			getFloorTextureName(t, fTOP);
			//West face
			fprintf(MAPFILE, "( -1 0 0 %d )", +((x)*BrushSizeX));
			getWallTextureName(t, fWEST, t.isWater);
			//South face
			fprintf(MAPFILE, "( 0 -1 0 %d )", +((y)*BrushSizeY));
			getWallTextureName(t, fSOUTH, t.isWater);
			//Bottom face
			//w
			float ceilingHeight = t.ceilingHeight;
			BrushZ = (float)BrushSizeZ*steepness; BrushX = (float)BrushSizeX;
			angle = atan((float)(BrushX / (BrushZ)));
			normalDist = (cos(atan((BrushZ) / (BrushX)))) * ((-x) - ((CEILING_HEIGHT - ceilingHeight) / steepness)) * BrushZ;
			fprintf(MAPFILE, "( %f 0 %f %f )", -cos(angle), -sin(angle), -normalDist);
			getFloorTextureName(t, fCEIL);

			//n			
			ceilingHeight = (CEILING_HEIGHT - (t.ceilingHeight));
			BrushZ = (float)BrushSizeZ*steepness; BrushY = (float)BrushSizeY;
			angle = atan((float)(BrushY / BrushZ));
			normalDist = (cos(atan(BrushZ / BrushY))) * ((ceilingHeight / steepness) - y - 1) * BrushZ;
			fprintf(MAPFILE, "( 0 %f %f %f )", cos(angle), -sin(angle), +normalDist);
			getFloorTextureName(t, fCEIL);
			fprintf(MAPFILE, "}\n}\n");
		}
	}
	return;
}

void RenderShockDoorway(int game, int x, int y, tile &t, ObjectItem currDoor, tile LevelInfo[64][64], ObjectItem objList[1600])
{
	float offX; float offY; float offZ;
	CalcObjectXYZ(game, &offX, &offY, &offZ, LevelInfo, objList, currDoor.index, x, y);
	//The visportal.
	tile Tmpt;	//tmp tile for rendering a visportal.

	switch (currDoor.Angle2)
	{

	case SHOCK_SOUTH:
	case SHOCK_NORTH:
	{
						Tmpt.tileType = 0;
						Tmpt.isWater = 0;
						Tmpt.wallTexture = NODRAW;
						Tmpt.North = NODRAW;
						Tmpt.South = VISPORTAL;
						Tmpt.East = NODRAW;
						Tmpt.West = NODRAW;
						Tmpt.Top = NODRAW;
						Tmpt.Bottom = NODRAW;
						Tmpt.DimX = 1; Tmpt.DimY = 1;

						fprintf(MAPFILE, "// primitive %d\n", PrimitiveCount++);
						fprintf(MAPFILE, "{\nbrushDef3\n{\n");
						//east face 
						fprintf(MAPFILE, "( 1 0 0 %d )", -((x + Tmpt.DimX)*BrushSizeX));
						getWallTextureName(Tmpt, fEAST, 0);
						//north face 
						fprintf(MAPFILE, "( 0 1 0 %f )", -(offY + 0.05));
						getWallTextureName(Tmpt, fNORTH, 0);
						//top face
						fprintf(MAPFILE, "( 0 0 1 %d )", -(120 + LevelInfo[currDoor.tileX][currDoor.tileY].floorHeight  * BrushSizeZ));
						getFloorTextureName(Tmpt, fTOP);
						//west face
						fprintf(MAPFILE, "( -1 0 0 %d )", +((x)*BrushSizeX));
						getWallTextureName(Tmpt, fWEST, 0);
						//south face
						fprintf(MAPFILE, "( 0 -1 0 %f )", +(offY - 0.05));
						getWallTextureName(Tmpt, fSOUTH, 0);
						//bottom face
						fprintf(MAPFILE, "( 0 0 -1 %d )", LevelInfo[currDoor.tileX][currDoor.tileY].floorHeight  * BrushSizeZ);
						getFloorTextureName(Tmpt, fBOTTOM);
						fprintf(MAPFILE, "}\n}\n");
						break;
	}
	case SHOCK_EAST:
	case SHOCK_WEST:
	{
					   Tmpt.tileType = 0;
					   Tmpt.isWater = 0;
					   Tmpt.wallTexture = NODRAW;
					   Tmpt.North = NODRAW;
					   Tmpt.South = NODRAW;
					   Tmpt.East = VISPORTAL;
					   Tmpt.West = NODRAW;
					   Tmpt.Top = NODRAW;
					   Tmpt.Bottom = NODRAW;
					   Tmpt.DimX = 1; Tmpt.DimY = 1;

					   fprintf(MAPFILE, "// primitive %d\n", PrimitiveCount++);
					   fprintf(MAPFILE, "{\nbrushDef3\n{\n");
					   //east face 
					   //fprintf(MAPFILE, "( 1 0 0 %d )", -((x + t.DimX)*BrushSizeX));
					   fprintf(MAPFILE, "( 1 0 0 %f )", -(offX + 0.05));
					   getWallTextureName(Tmpt, fEAST, 0);
					   //north face 
					   fprintf(MAPFILE, "( 0 1 0 %d )", -((y + t.DimY)*BrushSizeY));
					   getWallTextureName(Tmpt, fNORTH, 0);
					   //top face
					   fprintf(MAPFILE, "( 0 0 1 %d )", -(120 + LevelInfo[currDoor.tileX][currDoor.tileY].floorHeight  * BrushSizeZ));
					   getFloorTextureName(Tmpt, fTOP);
					   //west face
					   //fprintf(MAPFILE, "( -1 0 0 %d )", +((x)*BrushSizeX));
					   fprintf(MAPFILE, "( -1 0 0 %f )", +(offX - 0.05));
					   getWallTextureName(Tmpt, fWEST, 0);
					   //south face
					   fprintf(MAPFILE, "( 0 -1 0 %d )", +((y)*BrushSizeY));
					   getWallTextureName(Tmpt, fSOUTH, 0);
					   //bottom face
					   fprintf(MAPFILE, "( 0 0 -1 %d )", LevelInfo[currDoor.tileX][currDoor.tileY].floorHeight  * BrushSizeZ);
					   getFloorTextureName(Tmpt, fBOTTOM);
					   fprintf(MAPFILE, "}\n}\n");
					   break;
	}
	}
}

void RenderDoorway(int game, int x, int y, tile &t, ObjectItem currDoor)
{
	//TODO:Define door widths in config file. 
	int doorWidth = 48;
	int doorHeight = 96;
	int resolution;
	float BrushX = BrushSizeX;
	float BrushY = BrushSizeY;
	float BrushZ = BrushSizeZ;

	switch (game)
	{
	case SHOCK:
		resolution = 255;
		break;
	default:
		resolution = 7;
		break;
	}

	float offX = (x*BrushX) + ((currDoor.x) * (BrushX / resolution));//from obj position code
	float offY = (y*BrushY) + ((currDoor.y) * (BrushY / resolution));
	int heading = 0;
	if (game != SHOCK)
	{
		heading = currDoor.heading;
	}
	else
	{
		heading = currDoor.Angle2;
	}

	switch (heading)
	{
	case EAST:
	case WEST:	//east west
	case SHOCK_EAST:
	case SHOCK_WEST:
	{

					   //if(currDoor.heading == EAST) {offY =offY+DOORORIGINOFFSET;}else{offY =offY+DOORORIGINOFFSET;}
					   if ((heading == EAST) || (heading == SHOCK_EAST))
					   {
						   offY = (y*BrushY) + ((BrushY - doorWidth) / 2) + doorWidth;
					   }
					   else
					   {
						   offY = (y*BrushY) + ((BrushY - doorWidth) / 2);
					   }
					   //left side
					   fprintf(MAPFILE, "// primitive %d\n", PrimitiveCount++);
					   fprintf(MAPFILE, "{\nbrushDef3\n{\n");
					   //east face 
					   fprintf(MAPFILE, "( 1 0 0 %f )", -((offX + 2)));
					   getWallTextureName(t, fSELF, 0);
					   //north face 
					   fprintf(MAPFILE, "( 0 1 0 %f )", -((y + 1)*BrushY));
					   getWallTextureName(t, fSELF, 0);
					   //top face
					   fprintf(MAPFILE, "( 0 0 1 %f )", -(t.floorHeight*BrushZ + doorHeight));
					   getFloorTextureName(t, fTOP);
					   //west face
					   fprintf(MAPFILE, "( -1 0 0 %f )", +((offX - 2)));
					   getWallTextureName(t, fSELF, 0);
					   //south face
					   if ((heading == EAST) || (heading == SHOCK_EAST))
					   {
						   fprintf(MAPFILE, "( 0 -1 0 %f )", +(offY));
					   }
					   else
						   fprintf(MAPFILE, "( 0 -1 0 %f )", +(offY)+doorWidth);

					   getWallTextureName(t, fSELF, 0);
					   //bottom face
					   fprintf(MAPFILE, "( 0 0 -1 %f )", t.floorHeight*BrushZ);
					   getFloorTextureName(t, fBOTTOM);
					   //fprintf (MAPFILE, "0"); 
					   fprintf(MAPFILE, "}\n}\n");

					   //over the door
					   fprintf(MAPFILE, "// primitive %d\n", PrimitiveCount++);
					   fprintf(MAPFILE, "{\nbrushDef3\n{\n");
					   //east face 
					   fprintf(MAPFILE, "( 1 0 0 %f )", -((offX + 2)));
					   getWallTextureName(t, fSELF, 0);
					   //north face 
					   fprintf(MAPFILE, "( 0 1 0 %f )", -((y + 1)*BrushY));
					   getWallTextureName(t, fSELF, 0);
					   //top face
					   fprintf(MAPFILE, "( 0 0 1 %f )", -BrushZ * (CEILING_HEIGHT + 1));
					   getFloorTextureName(t, fTOP);
					   //west face
					   fprintf(MAPFILE, "( -1 0 0 %f )", +((offX - 2)));
					   getWallTextureName(t, fSELF, 0);
					   //south face
					   fprintf(MAPFILE, "( 0 -1 0 %f )", +(y*BrushY));
					   getWallTextureName(t, fSELF, 0);
					   //bottom face
					   fprintf(MAPFILE, "( 0 0 -1 %f )", (t.floorHeight*BrushZ) + doorHeight);
					   getFloorTextureName(t, fBOTTOM);
					   //fprintf (MAPFILE, "0"); 
					   fprintf(MAPFILE, "}\n}\n");

					   // right side
					   fprintf(MAPFILE, "// primitive %d\n", PrimitiveCount++);
					   fprintf(MAPFILE, "{\nbrushDef3\n{\n");
					   //east face 
					   fprintf(MAPFILE, "( 1 0 0 %f )", -((offX + 2)));
					   getWallTextureName(t, fSELF, 0);
					   //north face 
					   if ((heading == EAST) || (heading == SHOCK_EAST))
					   {
						   fprintf(MAPFILE, "( 0 1 0 %f )", -(offY - doorWidth));
					   }
					   else
					   {
						   fprintf(MAPFILE, "( 0 1 0 %f )", -(offY));
					   }
					   getWallTextureName(t, fSELF, 0);
					   //top face
					   fprintf(MAPFILE, "( 0 0 1 %f )", -(t.floorHeight*BrushZ + doorHeight));
					   getFloorTextureName(t, fTOP);
					   //west face
					   fprintf(MAPFILE, "( -1 0 0 %f )", +((offX - 2)));
					   getWallTextureName(t, fSELF, 0);
					   //south face
					   fprintf(MAPFILE, "( 0 -1 0 %f )", +(y * BrushY));
					   getWallTextureName(t, fSELF, 0);
					   //bottom face
					   fprintf(MAPFILE, "( 0 0 -1 %f )", t.floorHeight*BrushZ);
					   getFloorTextureName(t, fBOTTOM);
					   //fprintf (MAPFILE, "0"); 
					   fprintf(MAPFILE, "}\n}\n");
					   if (t.TerrainChange == 0)
					   {
						   tile Tmpt;	//tmp tile for rendering a visportal.
						   Tmpt.tileType = 0;
						   Tmpt.isWater = 0;
						   Tmpt.wallTexture = NODRAW;
						   Tmpt.North = NODRAW;
						   Tmpt.South = NODRAW;
						   Tmpt.East = VISPORTAL;
						   Tmpt.West = NODRAW;
						   Tmpt.Top = NODRAW;
						   Tmpt.Bottom = NODRAW;
						   //Visportal
						   fprintf(MAPFILE, "// primitive %d\n", PrimitiveCount++);
						   fprintf(MAPFILE, "{\nbrushDef3\n{\n");
						   //east face 
						   fprintf(MAPFILE, "( 1 0 0 %f )", -((offX + 2)));
						   getWallTextureName(Tmpt, fSELF, 0);
						   //north face 
						   if ((heading == EAST) || (heading == SHOCK_EAST))
						   {
							   fprintf(MAPFILE, "( 0 1 0 %f )", -((offY)));
						   }
						   else
						   {
							   fprintf(MAPFILE, "( 0 1 0 %f )", -((offY + doorWidth)));
						   }
						   getWallTextureName(Tmpt, fSELF, 0);
						   //top face
						   fprintf(MAPFILE, "( 0 0 1 %f )", -((t.floorHeight*BrushZ) + doorHeight));
						   getWallTextureName(Tmpt, fTOP, 0);
						   //west face
						   fprintf(MAPFILE, "( -1 0 0 %f )", +((offX - 1)));
						   getWallTextureName(Tmpt, fSELF, 0);
						   //south face
						   if ((heading == EAST) || (heading == SHOCK_EAST))
						   {
							   fprintf(MAPFILE, "( 0 -1 0 %f )", +(offY - doorWidth));
						   }
						   else
						   {
							   fprintf(MAPFILE, "( 0 -1 0 %f )", +(offY));
						   }
						   getWallTextureName(Tmpt, fSELF, 0);
						   //bottom face
						   fprintf(MAPFILE, "( 0 0 -1 %f )", (t.floorHeight*BrushZ));
						   getWallTextureName(Tmpt, fBOTTOM, 0);
						   //fprintf (MAPFILE, "0"); 
						   fprintf(MAPFILE, "}\n}\n");
					   }
					   break;

	}
	case NORTH:	//north south (0)
	case SOUTH:
	case SHOCK_NORTH:
		//case SHOCK_SOUTH:
	{

						if ((heading == NORTH) || (heading == SHOCK_NORTH))
						{
							offX = (x*BrushSizeX) + ((BrushSizeX - doorWidth) / 2) + doorWidth;
						}
						else
						{
							offX = (x*BrushSizeX) + ((BrushSizeX - doorWidth) / 2);
						}
						//left side
						fprintf(MAPFILE, "// primitive %d\n", PrimitiveCount++);
						fprintf(MAPFILE, "{\nbrushDef3\n{\n");
						//east face 
						if ((heading == NORTH) || (heading == SHOCK_NORTH))
						{
							fprintf(MAPFILE, "( 1 0 0 %f )", -(offX - doorWidth));

						}
						else
						{
							fprintf(MAPFILE, "( 1 0 0 %f )", -(offX));
						}

						getWallTextureName(t, fSELF, 0);
						//north face 
						fprintf(MAPFILE, "( 0 1 0 %f )", -(offY + 2));
						getWallTextureName(t, fSELF, 0);
						//top face
						fprintf(MAPFILE, "( 0 0 1 %f )", -(t.floorHeight*BrushZ + doorHeight));
						getFloorTextureName(t, fTOP);
						//west face
						fprintf(MAPFILE, "( -1 0 0 %f )", +((x)*BrushX));
						getWallTextureName(t, fSELF, 0);
						//south face
						fprintf(MAPFILE, "( 0 -1 0 %f )", +(offY - 2));
						getWallTextureName(t, fSELF, 0);
						//bottom face
						fprintf(MAPFILE, "( 0 0 -1 %f )", t.floorHeight * BrushZ);	//to go underneath
						getFloorTextureName(t, fBOTTOM);
						//fprintf (MAPFILE, "0"); 
						fprintf(MAPFILE, "}\n}\n");
						//top
						fprintf(MAPFILE, "// primitive %d\n", PrimitiveCount++);
						fprintf(MAPFILE, "{\nbrushDef3\n{\n");
						//east face 
						fprintf(MAPFILE, "( 1 0 0 %f )", -((x + 1)*BrushX));
						getWallTextureName(t, fSELF, 0);
						//north face 
						fprintf(MAPFILE, "( 0 1 0 %f )", -(offY + 2));
						getWallTextureName(t, fSELF, 0);
						//top face
						fprintf(MAPFILE, "( 0 0 1 %f )", -BrushZ * (CEILING_HEIGHT + 1));
						getFloorTextureName(t, fTOP);
						//west face
						fprintf(MAPFILE, "( -1 0 0 %f )", +(x*BrushX));
						getWallTextureName(t, fSELF, 0);
						//south face
						fprintf(MAPFILE, "( 0 -1 0 %f )", +(offY - 2));
						getWallTextureName(t, fSELF, 0);
						//bottom face
						fprintf(MAPFILE, "( 0 0 -1 %f )", (t.floorHeight*BrushZ) + doorHeight);	//to go underneath
						getFloorTextureName(t, fBOTTOM);
						//fprintf (MAPFILE, "0"); 
						fprintf(MAPFILE, "}\n}\n");
						//right
						fprintf(MAPFILE, "// primitive %d\n", PrimitiveCount++);
						fprintf(MAPFILE, "{\nbrushDef3\n{\n");
						//east face 
						fprintf(MAPFILE, "( 1 0 0 %f )", -((x + 1)*BrushX));
						getWallTextureName(t, fSELF, 0);
						//north face 
						fprintf(MAPFILE, "( 0 1 0 %f )", -(offY + 2));
						getWallTextureName(t, fSELF, 0);
						//top face
						fprintf(MAPFILE, "( 0 0 1 %f )", -(t.floorHeight*BrushZ + doorHeight));
						getFloorTextureName(t, fTOP);
						//west face
						if ((heading == NORTH) || (heading == SHOCK_NORTH))
						{
							fprintf(MAPFILE, "( -1 0 0 %f )", +(offX));
						}
						else
						{
							fprintf(MAPFILE, "( -1 0 0 %f )", +(offX + doorWidth));
						}
						getWallTextureName(t, fSELF, 0);
						//south face
						fprintf(MAPFILE, "( 0 -1 0 %f )", +(offY - 2));
						getWallTextureName(t, fSELF, 0);
						//bottom face
						fprintf(MAPFILE, "( 0 0 -1 %f )", t.floorHeight * BrushZ);	//to go underneath
						getFloorTextureName(t, fBOTTOM);
						//fprintf (MAPFILE, "0"); 
						fprintf(MAPFILE, "}\n}\n");
						if (t.TerrainChange == 0)
						{
							//visportal.
							tile Tmpt;	//tmp tile for rendering a visportal.
							Tmpt.tileType = 0;
							Tmpt.isWater = 0;
							Tmpt.wallTexture = NODRAW;
							Tmpt.North = NODRAW;
							Tmpt.South = VISPORTAL;
							Tmpt.East = NODRAW;
							Tmpt.West = NODRAW;
							Tmpt.Top = NODRAW;
							Tmpt.Bottom = NODRAW;
							fprintf(MAPFILE, "// primitive %d\n", PrimitiveCount++);
							fprintf(MAPFILE, "{\nbrushDef3\n{\n");
							//east face 
							if ((heading == NORTH) || (heading == SHOCK_NORTH))
							{
								fprintf(MAPFILE, "( 1 0 0 %f )", -(offX));
							}
							else
							{
								fprintf(MAPFILE, "( 1 0 0 %f )", -(offX + doorWidth));
							}
							getWallTextureName(Tmpt, fSELF, 0);
							//north face 
							fprintf(MAPFILE, "( 0 1 0 %f )", -(offY + 2));
							getWallTextureName(Tmpt, fSELF, 0);
							//top face
							fprintf(MAPFILE, "( 0 0 1 %f )", -(t.floorHeight*BrushZ + doorHeight));
							getFloorTextureName(Tmpt, fTOP);
							//west face
							if ((heading == NORTH) || (heading == SHOCK_NORTH))
							{
								fprintf(MAPFILE, "( -1 0 0 %f )", +(offX - doorWidth));
							}
							else
							{
								fprintf(MAPFILE, "( -1 0 0 %f )", +(offX));
							}
							getWallTextureName(Tmpt, fSELF, 0);
							//south face
							fprintf(MAPFILE, "( 0 -1 0 %f )", +(offY - 2));
							getWallTextureName(Tmpt, fSELF, 0);
							//bottom face
							fprintf(MAPFILE, "( 0 0 -1 %f )", (t.floorHeight*BrushZ));	//to go underneath
							getFloorTextureName(Tmpt, fBOTTOM);
							//fprintf (MAPFILE, "0"); 
							fprintf(MAPFILE, "}\n}\n");
						}
	}
	}
}

void RenderPatch(int game, int x, int y, int z, long PatchIndex, ObjectItem objList[1600])
{
	//
	//Flat decal object, think the Abyss doors.
	ObjectItem currobj = objList[PatchIndex];

	float patchX; float patchY; float patchZ; float patchOffsetX; float patchOffsetY;
	////////////float offX= (x*BrushSizeX) + ((objList[PatchIndex].x) * (BrushSizeX/7));
	////////////float offY= (y*BrushSizeY) + ((objList[PatchIndex].y) * (BrushSizeY/7));
	////////////
	////////////if ((objList[PatchIndex].x ==0) ||(objList[PatchIndex].x ==7) )
	////////////	{
	////////////	offY= objList[PatchIndex].tileY * BrushSizeY+ (BrushSizeY/2);
	////////////	}
	////////////if ((objList[PatchIndex].y ==0) || (objList[PatchIndex].y ==7))
	////////////	{
	////////////	offX= objList[PatchIndex].tileX * BrushSizeX+ (BrushSizeX/2);
	////////////	}
	//////////////float offX= objList[PatchIndex].tileX * BrushSizeX + (BrushSizeX/2);
	//////////////float offY= objList[PatchIndex].tileY * BrushSizeY+ (BrushSizeY/2);
	////////////float floorHeight = LevelInfo[x][y].floorHeight <<3 ;
	////////////float nextFloorHeight =(LevelInfo[x][y].floorHeight+1) <<3 ;
	////////////float relativeZpos = objList[PatchIndex].zpos - floorHeight;
	////////////float zposRatio = relativeZpos/(nextFloorHeight-floorHeight);	//relative adjustment
	////////////float offZ = LevelInfo[x][y].floorHeight * BrushSizeZ + (zposRatio*BrushSizeZ);
	float offX; float offY; float offZ;
	CalcObjectXYZ(game, &offX, &offY, &offZ, LevelInfo, objList, PatchIndex, x, y);
	offX = currobj.tileX * BrushSizeX;
	offY = currobj.tileY * BrushSizeY;
	float tex1 = -1; float tex2 = -1;	//target values
	switch (currobj.heading)
	{//Headings are horribly broken.
	default:
	case SOUTH:	//Southfacing
	{patchX = -BrushSizeX; patchY = 0; patchZ = 12 * BrushSizeZ; patchOffsetX = 0; patchOffsetY = -0.1;		//12 was 11
	offY = offY + (BrushSizeY );
	offX = offX + (BrushSizeX);
	break; }
	case NORTH://Northfacing
	{patchX = BrushSizeX; patchY = 0; patchZ = 12 * BrushSizeZ; patchOffsetX = 0; patchOffsetY = +0.1;
	//offX = offX - (BrushSizeX / 2);
	break; }
	case EAST://east facing 
	{patchX = 0; patchY = -BrushSizeY; patchZ = 12 * BrushSizeZ; patchOffsetX = +0.1; patchOffsetY = 0;
	offY = offY + (BrushSizeY );
	break; }
	case WEST:
	{patchX = 0; patchY = +BrushSizeY; patchZ = 12 * BrushSizeZ; patchOffsetX = -0.1; patchOffsetY = 0;
	//offY = offY - (BrushSizeY / 2);
	offX = offX + BrushSizeX;
	break; }
	}
	//fprintf (MAPFILE, "\"name\" \"%s_%03d_%03d\"",objectMasters[currobj.item_id].desc,currobj.tileX,currobj.tileY );
	//fprintf (MAPFILE, "\"model\" \"%s_%03d_%03d\"",objectMasters[currobj.item_id].desc,currobj.tileX,currobj.tileY );
	//Things like the abyss doors,stairs down//a patch?
	fprintf(MAPFILE, "\n//primitive %d\n{\npatchDef2\n{\n", 0);
	fprintf(MAPFILE, "\"%s\"\n", textureMasters[currobj.owner].path);
	fprintf(MAPFILE, "( 3 5 0 0 0 )\n(\n");	//not sure what they mean but they appear to stay constant?
	for (int j = 0; j <3; j++)
	{
		fprintf(MAPFILE, "(");
		for (int i = 0; i <= 4; i++)
		{
			//x y z texture param1 textureparam 2
			fprintf(MAPFILE, " ( %f %f %f %f %f )", offX + patchOffsetX + i*(patchX / 4), offY + patchOffsetY + i*(patchY / 4), offZ + j*(patchZ / 3), i*(tex1 / 4), j*(tex2 / 2));
		}
		fprintf(MAPFILE, " )\n");
	}
	fprintf(MAPFILE, ")\n}\n}\n");
}

void RenderElevatorLeakProtection(int game, tile LevelInfo[64][64])
{
	//Just makes sure the elevator entity does not cause a map leak.
	for (int y = 0; y <= 63; y++)
	{
		for (int x = 0; x <= 63; x++)
		{
			if (LevelInfo[x][y].hasElevator >= 1)
			{
				//Below the map
				tile t = LevelInfo[x][y];
				fprintf(MAPFILE, "\n");
				fprintf(MAPFILE, "// primitive %d\n", PrimitiveCount++);
				fprintf(MAPFILE, "{\nbrushDef3\n{\n");
				//east face 
				fprintf(MAPFILE, "( 1 0 0 %d )", -((x + t.DimX)*BrushSizeX) - 10);
				getWallTextureName(t, fEAST, 0);
				//north face 
				fprintf(MAPFILE, "( 0 1 0 %d )", -((y + t.DimY)*BrushSizeY) - 10);
				getWallTextureName(t, fNORTH, 0);
				//top face
				fprintf(MAPFILE, "( 0 0 1 %d )", +1);
				getFloorTextureName(t, fTOP);
				//west face
				fprintf(MAPFILE, "( -1 0 0 %d )", +((x)*BrushSizeX) - 10);
				getWallTextureName(t, fWEST, 0);
				//south face
				fprintf(MAPFILE, "( 0 -1 0 %d )", +((y)*BrushSizeY) - 10);
				getWallTextureName(t, fSOUTH, 0);
				//bottom face
				fprintf(MAPFILE, "( 0 0 -1 %d )", -32 * BrushSizeZ);
				getFloorTextureName(t, fBOTTOM);
				//fprintf (MAPFILE, "0"); 
				fprintf(MAPFILE, "}\n}\n");

				//Above the map for shock
				/*if (game == SHOCK)
				{*/
					fprintf(MAPFILE, "\n");
					fprintf(MAPFILE, "// primitive %d\n", PrimitiveCount++);
					fprintf(MAPFILE, "{\nbrushDef3\n{\n");
					//east face 
					fprintf(MAPFILE, "( 1 0 0 %d )", -((x + t.DimX)*BrushSizeX) - 10);
					getWallTextureName(t, fEAST, 0);
					//north face 
					fprintf(MAPFILE, "( 0 1 0 %d )", -((y + t.DimY)*BrushSizeY) - 10);
					getWallTextureName(t, fNORTH, 0);
					//top face
					fprintf(MAPFILE, "( 0 0 1 %d )", -CEILING_HEIGHT * 2 * BrushSizeZ);	//ugly.
					getFloorTextureName(t, fTOP);
					//west face
					fprintf(MAPFILE, "( -1 0 0 %d )", +((x)*BrushSizeX) - 10);
					getWallTextureName(t, fWEST, 0);
					//south face
					fprintf(MAPFILE, "( 0 -1 0 %d )", +((y)*BrushSizeY) - 10);
					getWallTextureName(t, fSOUTH, 0);
					//bottom face
					fprintf(MAPFILE, "( 0 0 -1 %d )", (CEILING_HEIGHT+1)*BrushSizeZ);
					getFloorTextureName(t, fBOTTOM);
					//fprintf (MAPFILE, "0"); 
					fprintf(MAPFILE, "}\n}\n");
				//}
			}
		}
	}
}

void RenderGenericTile(int x, int y, tile &t, int iCeiling, int iFloor)
{
	//
	//Just for special temporary tiles
	fprintf(MAPFILE, "// primitive %d\n", PrimitiveCount++);
	fprintf(MAPFILE, "{\nbrushDef3\n{\n");
	//East face
	fprintf(MAPFILE, "( 1 0 0 %d )", -((x + t.DimX)*BrushSizeX));
	getWallTextureName(t, fEAST, t.isWater);
	//North face
	fprintf(MAPFILE, "( 0 1 0 %d ) ", -((y + t.DimY)*BrushSizeY));
	getWallTextureName(t, fNORTH, t.isWater);
	//Top face
	fprintf(MAPFILE, "( 0 0 1 %d )", -((iCeiling)* BrushSizeZ));
	getFloorTextureName(t, fTOP);
	//West face
	fprintf(MAPFILE, "( -1 0 0 %d )", +((x)*BrushSizeX));
	getWallTextureName(t, fWEST, t.isWater);
	//South face
	fprintf(MAPFILE, "( 0 -1 0 %d )", +((y)*BrushSizeY));
	getWallTextureName(t, fSOUTH, t.isWater);
	//Bottom face 
	fprintf(MAPFILE, "( 0 0 -1 %d ) ", iFloor*BrushSizeZ);
	getFloorTextureName(t, fBOTTOM);
	fprintf(MAPFILE, "}\n}\n");
}

void RenderGenericTileAroundOrigin(int x, int y, tile &t, int iCeiling, int iFloor, int tileHeight)
{
	//
	//Just for special temporary tiles

	int xPlane; int yPlane; int zPlane;
	xPlane = BrushSizeX / 2;
	yPlane = BrushSizeY / 2;
	zPlane = tileHeight / 2;

	fprintf(MAPFILE, "// primitive %d\n", PrimitiveCount++);
	fprintf(MAPFILE, "{\nbrushDef3\n{\n");
	//East face
	fprintf(MAPFILE, "( 1 0 0 %d )", -xPlane);
	getWallTextureName(t, fEAST, t.isWater);
	//North face
	fprintf(MAPFILE, "( 0 1 0 %d ) ", -yPlane);
	getWallTextureName(t, fNORTH, t.isWater);
	//Top face
	fprintf(MAPFILE, "( 0 0 1 %d )", -zPlane);
	getFloorTextureName(t, fTOP);
	//West face
	fprintf(MAPFILE, "( -1 0 0 %d )", -(xPlane));
	getWallTextureName(t, fWEST, t.isWater);
	//South face
	fprintf(MAPFILE, "( 0 -1 0 %d )", -(yPlane));
	getWallTextureName(t, fSOUTH, t.isWater);
	//Bottom face 
	fprintf(MAPFILE, "( 0 0 -1 %d ) ", -zPlane);
	getFloorTextureName(t, fBOTTOM);
	fprintf(MAPFILE, "}\n}\n");
}

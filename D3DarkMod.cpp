#include <stdio.h>
#include <stdlib.h>
#include <fstream>
#include "math.h"

#include "tilemap.h"
#include "main.h"
#include "textures.h"
#include "gameobjects.h"

#include "D3DarkMod.h"

int BrushSizeX;
int BrushSizeY;
int BrushSizeZ;
int PrimitiveCount;
int EntityCount;
int CEILING_HEIGHT;
tile LevelInfo[64][64];
int iGame;
void RenderEntity(int game,float x, float y, float z, ObjectItem &currobj, ObjectItem objList[1600], tile LevelInfo[64][64]);
void CalcObjectXYZ(int game, float *offX,  float *offY, float *offZ, tile LevelInfo[64][64], ObjectItem objList[1600], long nextObj,int x,int y);
float calcAlignmentFactor(float adjacent, float opposite);
void AddEmails(int game, tile LevelInfo[64][64], ObjectItem objList[1600]);

int levelNo;
long SHOCK_CEILING_HEIGHT;
long UW_CEILING_HEIGHT;

extern FILE *MAPFILE;

void RenderDarkModLevel(tile LevelInfo[64][64],ObjectItem objList[1600],int game)
{
//Main processing loop for generating the level.
iGame =game;

//Levels use different ceiling heights.
//Shock is variable, UW is fixed.
switch (game)
	{
	case SHOCK:
		{CEILING_HEIGHT=SHOCK_CEILING_HEIGHT;break;}
	default:
		{CEILING_HEIGHT=UW_CEILING_HEIGHT;break;}
	}
int x; int y; 
//
//File header of the map file.
	fprintf (MAPFILE, "Version 2\n");
	fprintf (MAPFILE, "// entity 0\n{\n\"classname\" \"worldspawn\"\n");
	//sick of starting at origin in dr.
	fprintf (MAPFILE, "\"editor_drLastCameraPos\" \"2594.79 -1375.88 1780.4\"\n");
	fprintf (MAPFILE, "\"editor_drLastCameraAngle\" \"-28.5 90.9 0\"\n");
	PrimitiveCount=0;
	fprintf (MAPFILE, "\n");
	for (y=0; y<=63;y++) 
		{
		for (x=0; x<=63;x++)
			{
			if ((LevelInfo[x][y].hasElevator == 0))
				{
				if ( LevelInfo[x][y].TerrainChange == 0)
					{
					//A regular tile with no special properites.
					RenderDarkModTile(game,x,y,LevelInfo[x][y],0,0,0,0);
					}
				if (LevelInfo[x][y].isDoor == 1)
					{//Adds a UW door frame.
					RenderDoorway(game,x,y,LevelInfo[x][y],objList[LevelInfo[x][y].DoorIndex]);
					}
				}
			}
		}

		RenderElevatorLeakProtection(game,LevelInfo);
		if (game != SHOCK)
			{			
			RenderFloorAndCeiling(game,LevelInfo);	//Shocks ceils are already done.
			}
		fprintf (MAPFILE, "}");	//End worldspawn section of the .map file.
		//Now start rendering entities.			
		EntityCount=1;
		switch (game)
			{
			case UWDEMO:
				RenderObjectList(game,LevelInfo,objList); break;
			case UW1:
				RenderObjectList(game,LevelInfo,objList);
				RenderLevelExits(game,LevelInfo,objList);
				break;
			case UW2:
				RenderObjectList(game,LevelInfo,objList);
			case SHOCK:
				RenderObjectList(game,LevelInfo,objList);
				AddEmails(game, LevelInfo, objList);
				for (y=0; y<=63;y++) 
					{
					for (x=0; x<=63;x++)
						{
						if (LevelInfo[x][y].hasElevator >=1)
							{//render the shock elevators
							ObjectItem tempObj;
							tempObj.tileX=x;tempObj.tileY=y;
							RenderEntityElevator(game,LevelInfo,tempObj);
							}
						}
					}
				break;
			}
		//Now render thewater

		for (y=0; y<=63;y++) 
			{

			for (x=0; x<=63;x++)
				{
				if (LevelInfo[x][y].isWater == 1)
					{	//TODO:Take this section out of the loop and just just one entity for all the water?
						fprintf (MAPFILE, "\n");
						PrimitiveCount=0;	//resets for each entity.
						fprintf (MAPFILE, "// entity %d\n", EntityCount);
						fprintf (MAPFILE, "{\n\"classname\" \"atdm:liquid_water\"\n");
						fprintf (MAPFILE, "\n\"name\" \"atdm_liquid_water_%02d\"\n",EntityCount);
						fprintf (MAPFILE, "\n\"model\" \"atdm_liquid_water_%02d\"\n",EntityCount);
						fprintf (MAPFILE, "\n\"underwater_gui\" \"guis\\underwater\\underwater_green_thinmurk.gui\"\n");	
						tile t = LevelInfo[x][y];	//temp tile for rendering.
						//Test each face for waterfalls. Open -> open of different height or slope that does not go in the same direction
						t.East = NODRAW;
						t.West = NODRAW;
						t.North =NODRAW;
						t.South =NODRAW;
						t.wallTexture = NODRAW;
						if (t.tileType !=TILE_SOLID)
							{
							//test south.
							if ((LevelInfo[x][y-1].tileType == TILE_OPEN) && (t.floorHeight > LevelInfo[x][y-1].floorHeight ))
								{
								t.South = t.Top ;	//force face texture to be water.
								}
							if ( (LevelInfo[x][y-1].tileType == TILE_SLOPE_S) || (LevelInfo[x][y-1].tileType == TILE_SLOPE_E) || (LevelInfo[x][y-1].tileType == TILE_SLOPE_W) )
								{
								t.South = t.Top ;
								}
								
							//test north.
							if ((LevelInfo[x][y+t.DimY].tileType == TILE_OPEN) && (t.floorHeight > LevelInfo[x][y+t.DimY].floorHeight ))
								{
								t.North  = t.Top ;	//force face texture to be water.
								}
							if ( (LevelInfo[x][y+t.DimY].tileType == TILE_SLOPE_N) || (LevelInfo[x][y+t.DimY].tileType == TILE_SLOPE_E) || (LevelInfo[x][y+t.DimY].tileType == TILE_SLOPE_W) )
								{
								t.North = t.Top ;
								}	

							//test west.
							if ((LevelInfo[x-1][y].tileType == TILE_OPEN) && (t.floorHeight > LevelInfo[x-1][y].floorHeight ))
								{
								t.West = t.Top ;	//force face texture to be water.
								}
							if ( (LevelInfo[x-1][y].tileType == TILE_SLOPE_N) || (LevelInfo[x-1][y].tileType == TILE_SLOPE_E) || (LevelInfo[x-1][y].tileType == TILE_SLOPE_S) )
								{
								t.West = t.Top ;
								}	
								
							//test east.
							if ((LevelInfo[x+t.DimX][y].tileType == TILE_OPEN) && (t.floorHeight > LevelInfo[x+t.DimX][y].floorHeight ))
								{
								t.East  = t.Top ;	//force face texture to be water.
								}
							if ( (LevelInfo[x+t.DimX][y].tileType == TILE_SLOPE_N) || (LevelInfo[x+t.DimX][y].tileType == TILE_SLOPE_S) || (LevelInfo[x+t.DimX][y].tileType == TILE_SLOPE_W) )
								{
								t.East = t.Top ;
								}																								
							
							}
						
						RenderDarkModTile(game,x,y,t,1,0,0,0);
						fprintf (MAPFILE, "}\n");
						EntityCount++;	
					}
				}

			}
			if  ((game == SHOCK) && (ENABLE_LIGHTING))
				{//Light her up based on shade values
				for (y=0; y<=63;y++) 
					{
					for (x=0; x<=63;x++)
						{
						if (LevelInfo[x][y].tileType != 0)
							{
							float shade = 0.50;	//Max brightness.
							//put a light here. absolute frame rate killer. Need to merge contigous regions of light together or do something clever with texture brightness
							fprintf (MAPFILE, "// entity %d\n", EntityCount++);
							fprintf (MAPFILE, "{\n\"classname\" \"light\"");
							fprintf (MAPFILE, "\n\"name\" \"light_%02d_%02d_upper\"",x,y);
							fprintf (MAPFILE, "\n\"origin\" \"%d %d %d\"",
								x*BrushSizeX + BrushSizeX/2,
								y*BrushSizeY + BrushSizeY/2,
								(LevelInfo[x][y].floorHeight + (3*(CEILING_HEIGHT -LevelInfo[x][y].ceilingHeight - LevelInfo[x][y].floorHeight)/4))* BrushSizeZ);	
							fprintf (MAPFILE, "\n\"light_center\" \"0 0 0\"");
							fprintf (MAPFILE, "\n\"light_radius\" \"%d %d %d\"",
								40+BrushSizeX/2,
								40+BrushSizeY/2,
									((CEILING_HEIGHT - LevelInfo[x][y].ceilingHeight - LevelInfo[x][y].floorHeight)/2)*BrushSizeZ);
							
							shade = (0.50) * (1 - ((float)LevelInfo[x][y].shockShadeUpper / 15));
							fprintf (MAPFILE, "\n\"_color\" \"%f %f %f\"",shade,shade,shade);	
							fprintf (MAPFILE, "\n\"nodiffuse\" \"0\"");
							fprintf (MAPFILE, "\n\"noshadows\" \"1\"");
							fprintf (MAPFILE, "\n\"nospecular\" \"0\"");
							fprintf (MAPFILE, "\n\"parallel\" \"0\"");
							//fprintf (MAPFILE, "\n\"texture\" \"lights/tdmnofalloff\"");
							fprintf(MAPFILE, "\n\"texture\" \"lights/square\"");
							fprintf (MAPFILE, "\n}\n");

							fprintf(MAPFILE, "// entity %d\n", EntityCount++);
							fprintf(MAPFILE, "{\n\"classname\" \"light\"");
							fprintf(MAPFILE, "\n\"name\" \"light_%02d_%02d_lower\"", x, y);
							fprintf(MAPFILE, "\n\"origin\" \"%d %d %d\"",
								x*BrushSizeX + BrushSizeX / 2,
								y*BrushSizeY + BrushSizeY / 2,
								(LevelInfo[x][y].floorHeight + (1 * (CEILING_HEIGHT - LevelInfo[x][y].ceilingHeight - LevelInfo[x][y].floorHeight) / 4))* BrushSizeZ);
							fprintf(MAPFILE, "\n\"light_center\" \"0 0 0\"");
							fprintf(MAPFILE, "\n\"light_radius\" \"%d %d %d\"",
								40 + BrushSizeX / 2,
								40 + BrushSizeY / 2,
								((CEILING_HEIGHT - LevelInfo[x][y].ceilingHeight - LevelInfo[x][y].floorHeight) / 2)*BrushSizeZ);
							
							shade = (0.50) * (1 - ((float)LevelInfo[x][y].shockShadeLower / 15));
							fprintf(MAPFILE, "\n\"_color\" \"%f %f %f\"", shade, shade, shade);
							fprintf(MAPFILE, "\n\"nodiffuse\" \"0\"");
							fprintf(MAPFILE, "\n\"noshadows\" \"1\"");
							fprintf(MAPFILE, "\n\"nospecular\" \"0\"");
							fprintf(MAPFILE, "\n\"parallel\" \"0\"");
							//fprintf (MAPFILE, "\n\"texture\" \"lights/tdmnofalloff\"");
							fprintf(MAPFILE, "\n\"texture\" \"lights/square\"");
							fprintf(MAPFILE, "\n}\n");

							} 
						}
					}
				}	
			else
				{
			//Ambient world light

					fprintf (MAPFILE, "// entity %d\n", EntityCount++);
					fprintf (MAPFILE, "{\n\"classname\" \"atdm:ambient_world\"");
					fprintf (MAPFILE, "\n\"name\" \"ambient_world\"",EntityCount);
					fprintf (MAPFILE, "\n\"origin\" \"%d %d 120\"",32 * BrushSizeX,32 * BrushSizeY);	//May cause leaks on small maps.
					fprintf (MAPFILE, "\n\"light_center\" \"0 0 0\"");
					fprintf (MAPFILE, "\n\"light_radius\" \"4500 4500 2500\"");	
					fprintf (MAPFILE, "\n\"_color\" \"0.21 0.21 0.21\"");
					fprintf (MAPFILE, "\n\"nodiffuse\" \"0\"");
					fprintf (MAPFILE, "\n\"noshadows\" \"0\"");
					fprintf (MAPFILE, "\n\"nospecular\" \"0\"");
					fprintf (MAPFILE, "\n\"parallel\" \"0\"");
					fprintf (MAPFILE, "\n}\n");
					}
			if (game == SHOCK)
				{
				//Speaker for playing back logs
				fprintf (MAPFILE, "// entity %d\n", EntityCount++);
				fprintf (MAPFILE, "{\n\"classname\" \"atdm:voice\"");
				fprintf (MAPFILE, "\n\"name\" \"data_reader_voice\"");
				fprintf (MAPFILE, "\n\"origin\" \"%d %d 120\"",32 * BrushSizeX,32 * BrushSizeY);	//May cause leaks on small maps.
				fprintf (MAPFILE, "\n\"s_shader\" \"silence\"");
				fprintf (MAPFILE, "\n}\n");						
				
				fprintf (MAPFILE, "// entity %d\n", EntityCount++);
				fprintf (MAPFILE, "{\n\"classname\" \"atdm:trigger_voice\"");
				fprintf (MAPFILE, "\n\"name\" \"data_reader_trigger\"");
				fprintf (MAPFILE, "\n\"origin\" \"%d %d 120\"",32 * BrushSizeX,32 * BrushSizeY);	//May cause leaks on small maps.
				fprintf (MAPFILE, "\n\"snd_say\" \"silence\"");
				fprintf (MAPFILE, "\n\"target0\" \"data_reader_voice\"");
				fprintf (MAPFILE, "\n\"as_player\" \"1\"");
				fprintf (MAPFILE, "\n}\n");	
				
				if (levelNo == 1)
					{//startposition for player
					fprintf(MAPFILE, "// entity %d\n", EntityCount++);
					fprintf(MAPFILE, "{\n\"classname\" \"info_player_start\"");
					fprintf(MAPFILE, "\n\"name\" \"info_player_start\"");
					fprintf(MAPFILE, "\n\"origin\" \"%f %f %f\"",3642.25, 2722.75, 175.75 );
					fprintf(MAPFILE, "\n}\n");
					}
				
				}
		
}

void RenderDarkModTile(int game, int x, int y, tile &t, short Water, short invert, short skipFloor, short skipCeil)
{
//Picks the tile to render based on tile type/flags.
if (t.Render == 1)
	{fprintf (MAPFILE, "\n");}
	switch (t.tileType)
		{
		case TILE_SOLID:	//0
			{	//solid
			RenderSolidTile(x,y,t,Water);
			return;
			}
		case TILE_OPEN:		//1
			{//open
			if (skipFloor !=1) {RenderOpenTile(x,y,t,Water,0);}	//floor
			if ((game == SHOCK) && (skipCeil!=1)) {RenderOpenTile(x,y,t,Water,1);}	//ceiling
			return;
			}
		case 2: 
			{//diag se
			if (skipFloor !=1) {RenderDiagSETile(x,y,t,Water,0);}//floor
			if ((game == SHOCK) && (skipCeil!=1)) {RenderDiagSETile(x,y,t,Water,1);}
			return;		
			}
		case 3: 
			{	//diag sw 
			if (skipFloor !=1) {RenderDiagSWTile(x,y,t,Water,0);}//floor
			if ((game == SHOCK) && (skipCeil!=1)) {RenderDiagSWTile(x,y,t,Water,1);}
			return;		
			}
		case 4: 	
			{	//diag ne
			if (skipFloor !=1) {RenderDiagNETile(x,y,t,Water,invert);}//floor
			if ((game == SHOCK) && (skipCeil!=1)) {RenderDiagNETile(x,y,t,Water,1);}
			return;		
			}
		case 5: 
			{//diag nw
			if (skipFloor !=1) {RenderDiagNWTile(x,y,t,Water,invert);}//floor
			if ((game == SHOCK) && (skipCeil!=1)) {RenderDiagNWTile(x,y,t,Water,1);}
			return;
			}	
		case TILE_SLOPE_N:	//6
			{//slope n
			switch (t.shockSlopeFlag)
				{
				case SLOPE_BOTH_PARALLEL:
					{
					if (skipFloor !=1) {RenderSlopeNTile(x,y,t,Water,0);}//floor
					if ((game == SHOCK) && (skipCeil!=1)) {RenderSlopeNTile(x,y,t,Water,1);}
					break;
					}
				case SLOPE_BOTH_OPPOSITE:
					{
					if (skipFloor !=1) {RenderSlopeNTile(x,y,t,Water,0);}//floor
					if ((game == SHOCK) && (skipCeil!=1)) { RenderSlopeSTile(x,y,t,Water,1);}
					break;
					}
				case SLOPE_FLOOR_ONLY:
					{
					if (skipFloor !=1) {RenderSlopeNTile(x,y,t,Water,0);}//floor
					if ((game == SHOCK) && (skipCeil!=1)) {RenderOpenTile(x,y,t,Water,1);}	//ceiling
					break;
					}
				case SLOPE_CEILING_ONLY:
					{
					if (skipFloor !=1) {RenderOpenTile(x,y,t,Water,0);}	//floor
					RenderSlopeNTile(x,y,t,Water,1);
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
					if (skipFloor !=1) {RenderSlopeSTile(x,y,t,Water,0);}	//floor
					RenderSlopeSTile(x,y,t,Water,1);
					break;
					}
				case SLOPE_BOTH_OPPOSITE:
					{
					if (skipFloor !=1) {RenderSlopeSTile(x,y,t,Water,0);}	//floor
					RenderSlopeNTile(x,y,t,Water,1);
					break;
					}
				case SLOPE_FLOOR_ONLY:
					{
					if (skipFloor !=1) {RenderSlopeSTile(x,y,t,Water,0);}	//floor
					if ((game == SHOCK) && (skipCeil!=1)) {RenderOpenTile(x,y,t,Water,1);}	//ceiling
					break;
					}
				case SLOPE_CEILING_ONLY:
					{
					if (skipFloor !=1) {RenderOpenTile(x,y,t,Water,0);}	//floor
					if ((game == SHOCK) && (skipCeil!=1)) {RenderSlopeSTile(x,y,t,Water,1);}
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
					if (skipFloor !=1) {RenderSlopeETile(x,y,t,Water,0);}//floor
					RenderSlopeETile(x,y,t,Water,1);
					break;
					}
				case SLOPE_BOTH_OPPOSITE:
					{
					if (skipFloor !=1) {RenderSlopeETile(x,y,t,Water,0);}//floor
					RenderSlopeWTile(x,y,t,Water,1);
					break;
					}
				case SLOPE_FLOOR_ONLY:
					{
					if (skipFloor !=1) {RenderSlopeETile(x,y,t,Water,0);}//floor
					if ((game == SHOCK) && (skipCeil!=1)) {RenderOpenTile(x,y,t,Water,1);}	//ceiling
					break;
					}
				case SLOPE_CEILING_ONLY:
					{
					if (skipFloor !=1) {RenderOpenTile(x,y,t,Water,0);}	//floor
					if ((game == SHOCK) && (skipCeil!=1)) {RenderSlopeETile(x,y,t,Water,1);}
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
					if (skipFloor !=1) {RenderSlopeWTile(x,y,t,Water,0);}//floor
					if ((game == SHOCK) && (skipCeil!=1)) {RenderSlopeWTile(x,y,t,Water,1);}
					break;
					}
				case SLOPE_BOTH_OPPOSITE:
					{
					if (skipFloor !=1) {RenderSlopeWTile(x,y,t,Water,0);}//floor
					if ((game == SHOCK) && (skipCeil!=1)) {RenderSlopeETile(x,y,t,Water,1);}
					break;
					}
				case SLOPE_FLOOR_ONLY:
					{
					if (skipFloor !=1) {RenderSlopeWTile(x,y,t,Water,0);}//floor
					if ((game == SHOCK) && (skipCeil!=1)) {RenderOpenTile(x,y,t,Water,1);}	//ceiling
					break;
					}
				case SLOPE_CEILING_ONLY:
					{
					if (skipFloor !=1) {RenderOpenTile(x,y,t,Water,0);}	//floor
					if ((game == SHOCK) && (skipCeil!=1)) {RenderSlopeWTile(x,y,t,Water,1);}
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
					if (skipFloor !=1) {RenderValleyNWTile(x,y,t,Water,0);}//floor
					if ((game == SHOCK) && (skipCeil!=1)) {RenderValleyNWTile(x,y,t,Water,1);}
					break;
					}
				case SLOPE_BOTH_OPPOSITE:
					{
					if (skipFloor !=1) {RenderValleyNWTile(x,y,t,Water,0);}//floor
					if ((game == SHOCK) && (skipCeil!=1)) {RenderValleySETile(x,y,t,Water,1);}
					break;
					}
				case SLOPE_FLOOR_ONLY:
					{
					if (skipFloor !=1) {RenderValleyNWTile(x,y,t,Water,0);}//floor
					if ((game == SHOCK) && (skipCeil!=1)) {RenderOpenTile(x,y,t,Water,1);}	//ceiling
					break;
					}
				case SLOPE_CEILING_ONLY:
					{
					if (skipFloor !=1) {RenderOpenTile(x,y,t,Water,0);}	//floor
					if ((game == SHOCK) && (skipCeil!=1)) {RenderValleyNWTile(x,y,t,Water,1);}
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
					if (skipFloor !=1) {RenderValleyNETile(x,y,t,Water,0);}//floor
					if ((game == SHOCK) && (skipCeil!=1)) {RenderValleyNETile(x,y,t,Water,1);}
					break;
					}
				case SLOPE_BOTH_OPPOSITE:
					{
					if (skipFloor !=1) {RenderValleyNETile(x,y,t,Water,0);}//floor
					if ((game == SHOCK) && (skipCeil!=1)) {RenderValleySWTile(x,y,t,Water,1);}
					break;
					}
				case SLOPE_FLOOR_ONLY:
					{
					if (skipFloor !=1) {RenderValleyNETile(x,y,t,Water,0);}//floor
					if ((game == SHOCK) && (skipCeil!=1)) {RenderOpenTile(x,y,t,Water,1);}	//ceiling
					break;
					}
				case SLOPE_CEILING_ONLY:
					{
					if (skipFloor !=1) {RenderOpenTile(x,y,t,Water,0);}//floor
					if ((game == SHOCK) && (skipCeil!=1)) {RenderValleyNETile(x,y,t,Water,1);}
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
					if (skipFloor !=1) {RenderValleySETile(x,y,t,Water,0);}//floor
					if ((game == SHOCK) && (skipCeil!=1)) {RenderValleySETile(x,y,t,Water,1);}
					break;
					}
				case SLOPE_BOTH_OPPOSITE:
					{
					if (skipFloor !=1) {RenderValleySETile(x,y,t,Water,0);}//floor
					if ((game == SHOCK) && (skipCeil!=1)) {RenderValleyNWTile(x,y,t,Water,1);}
					break;
					}
				case SLOPE_FLOOR_ONLY:
					{
					if (skipFloor !=1) {RenderValleySETile(x,y,t,Water,0);}//floor
					if ((game == SHOCK) && (skipCeil!=1)) {RenderOpenTile(x,y,t,Water,1);}	//ceiling
					break;
					}
				case SLOPE_CEILING_ONLY:
					{
					if (skipFloor !=1) {RenderOpenTile(x,y,t,Water,0);}	//floor
					if ((game == SHOCK) && (skipCeil!=1)) {RenderValleySETile(x,y,t,Water,1);}
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
					if (skipFloor !=1) {RenderValleySWTile(x,y,t,Water,0);}//floor
					if ((game == SHOCK) && (skipCeil!=1)) {RenderValleySWTile(x,y,t,Water,1);}
					break;
					}
				case SLOPE_BOTH_OPPOSITE:
					{
					if (skipFloor !=1) {RenderValleySWTile(x,y,t,Water,0);}//floor
					if ((game == SHOCK) && (skipCeil!=1)) {RenderValleyNETile(x,y,t,Water,1);}
					break;
					}
				case SLOPE_FLOOR_ONLY:
					{
					if (skipFloor !=1) {RenderValleySWTile(x,y,t,Water,0);}//floor
					if ((game == SHOCK) && (skipCeil!=1)) {RenderOpenTile(x,y,t,Water,1);}	//ceiling
					break;
					}
				case SLOPE_CEILING_ONLY:
					{
					if (skipFloor !=1) {RenderOpenTile(x,y,t,Water,0);}	//floor
					if ((game == SHOCK) && (skipCeil!=1)) {RenderValleySWTile(x,y,t,Water,1);}
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
					if (skipFloor !=1) {RenderRidgeSETile(x,y,t,Water,0);}//floor
					if ((game == SHOCK) && (skipCeil!=1)) {RenderRidgeSETile(x,y,t,Water,1);}
					break;
					}
				case SLOPE_BOTH_OPPOSITE:
					{
					if (skipFloor !=1) {RenderRidgeSETile(x,y,t,Water,0);}//floor
					if ((game == SHOCK) && (skipCeil!=1)) {RenderRidgeNWTile(x,y,t,Water,1);}
					break;
					}
				case SLOPE_FLOOR_ONLY:
					{
					if (skipFloor !=1) {RenderRidgeSETile(x,y,t,Water,0);}//floor
					if ((game == SHOCK) && (skipCeil!=1)) {RenderOpenTile(x,y,t,Water,1);}	//ceiling
					break;
					}
				case SLOPE_CEILING_ONLY:
					{
					if (skipFloor !=1) {RenderOpenTile(x,y,t,Water,0);}//floor
					if ((game == SHOCK) && (skipCeil!=1)) {RenderValleySETile(x,y,t,Water,1);}
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
					if (skipFloor !=1) {RenderRidgeSWTile(x,y,t,Water,0);}//floor
					if ((game == SHOCK) && (skipCeil!=1)) {RenderRidgeSWTile(x,y,t,Water,1);}
					break;
					}
				case SLOPE_BOTH_OPPOSITE:
					{
					if (skipFloor !=1) {RenderRidgeSWTile(x,y,t,Water,0);}//floor
					if ((game == SHOCK) && (skipCeil!=1)) {RenderRidgeNETile(x,y,t,Water,1);}
					break;
					}
				case SLOPE_FLOOR_ONLY:
					{
					if (skipFloor !=1) {RenderRidgeSWTile(x,y,t,Water,0);}//floor
					if ((game == SHOCK) && (skipCeil!=1)) {RenderOpenTile(x,y,t,Water,1);}	//ceiling
					break;
					}
				case SLOPE_CEILING_ONLY:
					{
					if (skipFloor !=1) {RenderOpenTile(x,y,t,Water,0);}	//floor
					if ((game == SHOCK) && (skipCeil!=1)) {RenderValleySWTile(x,y,t,Water,1);}
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
					if (skipFloor !=1) {RenderRidgeNWTile(x,y,t,Water,0);}//floor
					if ((game == SHOCK) && (skipCeil!=1)) {RenderRidgeNWTile(x,y,t,Water,1);}
					break;
					}
				case SLOPE_BOTH_OPPOSITE:
					{
					if (skipFloor !=1) {RenderRidgeNWTile(x,y,t,Water,0);}//floor
					if ((game == SHOCK) && (skipCeil!=1)) {RenderRidgeSETile(x,y,t,Water,1);}
					break;
					}
				case SLOPE_FLOOR_ONLY:
					{
					if (skipFloor !=1) {RenderRidgeNWTile(x,y,t,Water,0);}//floor
					if ((game == SHOCK) && (skipCeil!=1)) {RenderOpenTile(x,y,t,Water,1);}	//ceiling
					break;
					}
				case SLOPE_CEILING_ONLY:
					{
					if (skipFloor !=1) {RenderOpenTile(x,y,t,Water,0);}	//floor
					if ((game == SHOCK) && (skipCeil!=1)) {RenderValleyNWTile(x,y,t,Water,1);}
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
					if (skipFloor !=1) {RenderRidgeNETile(x,y,t,Water,0);}//floor
					if ((game == SHOCK) && (skipCeil!=1)) {RenderRidgeNETile(x,y,t,Water,1);}
					break;
					}
				case SLOPE_BOTH_OPPOSITE:
					{
					if (skipFloor !=1) {RenderRidgeNETile(x,y,t,Water,0);}//floor
					if ((game == SHOCK) && (skipCeil!=1)) {RenderRidgeSWTile(x,y,t,Water,1);}
					break;
					}
				case SLOPE_FLOOR_ONLY:
					{
					if (skipFloor !=1) {RenderRidgeNETile(x,y,t,Water,0);}//floor
					if ((game == SHOCK) && (skipCeil!=1)) {RenderOpenTile(x,y,t,Water,1);}	//ceiling
					break;
					}
				case SLOPE_CEILING_ONLY:
					{
					if (skipFloor !=1) {RenderOpenTile(x,y,t,Water,0);}	//floor
					if ((game == SHOCK) && (skipCeil!=1)) {RenderValleyNETile(x,y,t,Water,1);}
					break;
					}
				}			
			return;
			}																	
	}
}




	
void getWallTextureName(tile t, int face, short waterWall)
{
//Spits out the wall textures.
//Water is a special case here and in SHOCK the texture needs to be offset
int wallTexture;
int textureOffset=1;
int ceilOffset=0;
wallTexture = t.wallTexture;
if (iGame==SHOCK)
	{ 
	textureOffset = t.shockTextureOffset;
	ceilOffset = t.ceilingHeight ;
	}
if ((t.isWater != 1 )|| (waterWall == 0 ))
	{
	//if ((t.tileType == 0))  //solid
	//	{
		switch (face)
			{
			case fNORTH:
				wallTexture=t.North ; 
				if ((iGame==SHOCK))
					{ 
					textureOffset = t.shockNorthOffset;
					ceilOffset = t.shockNorthCeilHeight;
					}
				break;
			case fSOUTH:
				wallTexture=t.South  ; 
				if ((iGame==SHOCK))
					{ 
					textureOffset = t.shockSouthOffset;
					ceilOffset = t.shockSouthCeilHeight;
					}
				break;
			case fWEST:
				wallTexture=t.West  ;
				if ((iGame==SHOCK))
					{ 
					textureOffset = t.shockWestOffset;
					ceilOffset = t.shockWestCeilHeight;
					}
				 break;
			case fEAST:
				wallTexture=t.East  ; 
				if ((iGame==SHOCK))
					{ 
					textureOffset = t.shockEastOffset;
					ceilOffset = t.shockEastCeilHeight;
					}
				break;
	//		}
		}
	if (wallTexture >512) {wallTexture=CAULK;}
	switch (wallTexture)
		{
		case TRIGGER_MULTI:	//For trigger entities.
			{fprintf (MAPFILE, "( ( 0 0.03125 0 ) ( -0.03125 0 0 ) ) \"textures/common/trigmulti\" 0 0 0\n");break;}
		case NODRAW:	//nodraw
			{fprintf (MAPFILE, "( ( 0 0.03125 0 ) ( -0.03125 0 0 ) ) \"textures/common/nodraw\" 0 0 0\n");break;}
		case VISPORTAL:	//visportal
			{fprintf (MAPFILE, "( ( 0 0.03125 0 ) ( -0.03125 0 0 ) ) \"textures/editor/visportal\" 0 0 0\n");break;}
		case CAULK:
			{fprintf (MAPFILE, "( ( 0 0.03125 0 ) ( -0.03125 0 0 ) ) \"textures/common/caulk\" 0 0 0\n");break;}
		default:
			{
			if (iGame == SHOCK)
				{
				float shock_ceil = SHOCK_CEILING_HEIGHT;
				float floorOffset = shock_ceil - ceilOffset - 8;	//The floor of the tile if it is 1 texture tall.
				while (floorOffset >= 8)	//Reduce the offset to 0 to 7 since textures go up in steps of 1/8ths
				{
					floorOffset -= 8;
				}
				float textureVertAlign = (floorOffset) / 8;
				fprintf(MAPFILE, "( ( %f %f %f ) ( %f %f %f ) ) \"",
					textureMasters[wallTexture].align1_1, textureMasters[wallTexture].align1_2, textureMasters[wallTexture].align1_3,
					textureMasters[wallTexture].align2_1, textureMasters[wallTexture].align2_2, textureVertAlign);
				}
			else
				{//Texture aligned with the ceiling
				fprintf (MAPFILE, "( ( %f %f %f ) ( %f %f %f ) ) \"",
				textureMasters[wallTexture].align1_1,textureMasters[wallTexture].align1_2,textureMasters[wallTexture].align1_3,
				textureMasters[wallTexture].align2_1,textureMasters[wallTexture].align2_2,textureMasters[wallTexture].align2_3);						
				}
			fprintf (MAPFILE, "%s", textureMasters[wallTexture].path );
			fprintf (MAPFILE, "\" 0 0 0\n");
					
			}
		}
	}
else	//Water tile
	{
		switch (face)
			{
			case fNORTH:
				wallTexture=t.North ; break;
			case fSOUTH:
				wallTexture=t.South  ; break;
			case fWEST:
				wallTexture=t.West  ; break;
			case fEAST:
				wallTexture=t.East  ; break;				
			}
	if (wallTexture >512) {wallTexture=CAULK;}
	switch (wallTexture)
		{
		case TRIGGER_MULTI:
			{fprintf (MAPFILE, "( ( 0 0.03125 0 ) ( -0.03125 0 0 ) ) \"textures/common/trigmulti\" 0 0 0\n");break;}
		case NODRAW:	//nodraw
			{fprintf (MAPFILE, "( ( 0 0.03125 0 ) ( -0.03125 0 0 ) ) \"textures/common/nodraw\" 0 0 0\n");break;}
		case VISPORTAL:	//visportal
			{fprintf (MAPFILE, "( ( 0 0.03125 0 ) ( -0.03125 0 0 ) ) \"textures/editor/visportal\" 0 0 0\n");break;}
		case CAULK:
			{fprintf (MAPFILE, "( ( 0 0.03125 0 ) ( -0.03125 0 0 ) ) \"textures/common/caulk\" 0 0 0\n");break;}
		default:
			{
			fprintf (MAPFILE, "( ( %f %f %f ) ( %f %f %f ) ) \"",textureMasters[wallTexture].align1_1,textureMasters[wallTexture].align1_2,textureMasters[wallTexture].align1_3,textureMasters[wallTexture].align2_1,textureMasters[wallTexture].align2_2,textureMasters[wallTexture].align2_3);	
			fprintf (MAPFILE, "%s", textureMasters[wallTexture].path );
			fprintf (MAPFILE, "\" 0 0 0\n");
			}
		}	
	}
	return ;
}

void getFloorTextureName(tile t, int face)
{
//Spits out the floor texture for a tile based on the face.

int floorTexture;
float alignFactor;	//For stretching floor textures.
	if (face == fCEIL)
		{
		floorTexture = t.shockCeilingTexture ;
		}
	else
		{
		floorTexture=t.floorTexture ;
		}

if (floorTexture <0)
	{
	switch (floorTexture)
		{
		case TRIGGER_MULTI:
			{fprintf (MAPFILE, "( ( 0 0.03125 0 ) ( -0.03125 0 0 ) ) \"textures/common/trigmulti\" 0 0 0\n");break;}
		case NODRAW:	//nodraw
			{fprintf (MAPFILE, "( ( 0 0.03125 0 ) ( -0.03125 0 0 ) ) \"textures/common/nodraw\" 0 0 0\n");break;}
		case VISPORTAL:	//visportal
			{fprintf (MAPFILE, "( ( 0 0.03125 0 ) ( -0.03125 0 0 ) ) \"textures/editor/visportal\" 0 0 0\n");break;}
		case CAULK:
		default:
			{fprintf (MAPFILE, "( ( 0 0.03125 0 ) ( -0.03125 0 0 ) ) \"textures/common/caulk\" 0 0 0\n");break;}
		}
	}
	else
		{
			if (floorTexture >=513)	
				{
				fprintf (MAPFILE, "( ( 0 0.03125 0 ) ( -0.03125 0 0 ) ) \"textures/common/caulk\" 0 0 0\n");
				}
			else
				{
				//float textVertAlign = textureMasters[floorTexture].floor_align2_3;	//Default value
				//alignFactor = 1;
				////This is buggy at the moment due to diffent slope types. 
				//if ((t.shockSteep >= 1) && (t.tileType >= 2) && ((face == fCEIL) || (face == fBOTTOM)))
				//{
				//	alignFactor = calcAlignmentFactor(BrushSizeX, t.shockSteep * BrushSizeZ);
				//	//basically how much of the slope if extended to the axis is above that axis line.
				//	if (face = fCEIL) 
				//	{
				//		textVertAlign = (t.ceilingHeight % t.shockSteep) / t.shockSteep;
				//	}
				//	else
				//	{
				//		textVertAlign = (t.floorHeight % t.shockSteep) / t.shockSteep;
				//	}
				//}
				fprintf (MAPFILE, "( ( %f %f %f ) ( %f %f %f ) ) \"",
						textureMasters[floorTexture].floor_align1_1,textureMasters[floorTexture].floor_align1_2,textureMasters[floorTexture].floor_align1_3,
						textureMasters[floorTexture].floor_align2_1, textureMasters[floorTexture].floor_align2_2, textureMasters[floorTexture].floor_align2_3);
//				fprintf(MAPFILE, "( ( %f %f %f ) ( %f %f %f ) ) \"",
//					textureMasters[floorTexture].floor_align1_1, textureMasters[floorTexture].floor_align1_2, textureMasters[floorTexture].floor_align1_3,
//					textureMasters[floorTexture].floor_align2_1, textureMasters[floorTexture].floor_align2_2 / alignFactor, textVertAlign);

				fprintf (MAPFILE, "%s", textureMasters[floorTexture].path );
				fprintf (MAPFILE, "\" 0 0 0\n");
				}
		}

	return ;
}



void RenderFloorAndCeiling(int game, tile LevelInfo[64][64])
{
//
//Not really floor and ceiling but just ceiling.
switch (game)
	{
	case SHOCK:
		{//due to variable ceiling heights I have to render each tile's roof.
			for (int y=0; y<=63;y++) 
				{
				fprintf (MAPFILE, "\n");
				for (int x=0; x<=63;x++)
					{
						if ((LevelInfo[x][y].tileType == 1))
							//Only do a ceiling for open and diagonals. everything else gets it's ceiling on the first pass due to slope flags
							{
							RenderDarkModTile(game,x,y,LevelInfo[x][y],0,1,0,0);
							}
					}
				}
		break;
		}	
	default:
		{//UW has a single height ceiling. Just need to put a roof on her and a riverbed for water features.
		//put a roof on her 
		fprintf (MAPFILE, "// primitive %d\n",PrimitiveCount++);
		fprintf (MAPFILE, "{\nbrushDef3\n{\n");
		//001	east face -absdist
		fprintf (MAPFILE, "( 1 0 0 %d ) ( ( 0.03125 0 0 ) ( 0 0.03125 0 ) ) \"textures/common/caulk\" 0 0 0\n",-(64*BrushSizeX));
		//010 north face -absdist
		fprintf (MAPFILE, "( 0 1 0 %d ) ( ( 0.03125 0 0 ) ( 0 0.03125 0 ) ) \"textures/common/caulk\" 0 0 0\n",-(64*BrushSizeY));
		//100	top face -absdist
		fprintf (MAPFILE, "( 0 0 1 %d ) ( ( 0.03125 0 0 ) ( 0 0.03125 0 ) ) \"textures/common/caulk\" 0 0 0\n", -BrushSizeZ * (CEILING_HEIGHT+1));	
		//00-1	west face +absdist
		fprintf (MAPFILE, "( -1 0 0 %d ) ( ( 0.03125 0 0 ) ( 0 0.03125 0 ) ) \"textures/common/caulk\" 0 0 0\n", +(0));
		//0-1 0	south face +absdist
		fprintf (MAPFILE, "( 0 -1 0 %d ) ( ( 0.03125 0 0 ) ( 0 0.03125 0 ) ) \"textures/common/caulk\" 0 0 0\n", +(0));
		//-100	bottom face +absdist
		fprintf (MAPFILE, "( 0 0 -1 %d ) ( ( 0.03125 0 0 ) ( 0 0.03125 0 ) ) \"textures/darkmod/stone/flat/slate_rough_dark01\" 0 0 0\n", (BrushSizeZ * (CEILING_HEIGHT)));	
		fprintf (MAPFILE, "}\n}\n");
		
		//and a ceiling 
		fprintf (MAPFILE, "// primitive %d\n",PrimitiveCount++);
		fprintf (MAPFILE, "{\nbrushDef3\n{\n");
		//001	east face -absdist
		fprintf (MAPFILE, "( 1 0 0 %d ) ( ( 0.03125 0 0 ) ( 0 0.03125 0 ) ) \"textures/common/caulk\" 0 0 0\n",-(64*BrushSizeX));
		//010 north face -absdist
		fprintf (MAPFILE, "( 0 1 0 %d ) ( ( 0.03125 0 0 ) ( 0 0.03125 0 ) ) \"textures/common/caulk\" 0 0 0\n",-(64*BrushSizeY));
		//100	top face -absdist
		fprintf (MAPFILE, "( 0 0 1 %d ) ( ( 0.03125 0 0 ) ( 0 0.03125 0 ) ) \"textures/darkmod/stone/natural/tiling_1d/gravel_red_01\" 0 0 0\n", +(2*BrushSizeZ) );	
		//00-1	west face +absdist
		fprintf (MAPFILE, "( -1 0 0 %d ) ( ( 0.03125 0 0 ) ( 0 0.03125 0 ) ) \"textures/common/caulk\" 0 0 0\n", +(0));
		//0-1 0	south face +absdist
		fprintf (MAPFILE, "( 0 -1 0 %d ) ( ( 0.03125 0 0 ) ( 0 0.03125 0 ) ) \"textures/common/caulk\" 0 0 0\n", +(0));
		//-100	bottom face +absdist
		fprintf (MAPFILE, "( 0 0 -1 %d ) ( ( 0.03125 0 0 ) ( 0 0.03125 0 ) ) \"textures/common/caulk\" 0 0 0\n", -(2*BrushSizeZ)-10);	
		fprintf (MAPFILE, "}\n}\n");
		break;
		}
	}
}

void RenderObjectList(int game, tile LevelInfo[64][64], ObjectItem objList[1600])
{
//Parses UW's object list and sets up their x,y,z position.

int x; int y; 
float offX;float offY;float offZ;
for (y=0; y<=63;y++) 
	{
	for (x=0; x<=63;x++)
		{
		if ((LevelInfo[x][y].indexObjectList !=0))
			{
				long nextObj = LevelInfo[x][y].indexObjectList;
				while (nextObj !=0)
					{
					objList[nextObj].tileX=x;
					objList[nextObj].tileY=y;
					CalcObjectXYZ(game,&offX,&offY,&offZ,LevelInfo,objList,nextObj,x,y);
					RenderEntity(game,offX,offY,offZ ,objList[nextObj],objList,LevelInfo);
					nextObj=objList[nextObj].next;
					}
			}
		}
	}	
}

void RenderSolidTile(int x, int y, tile &t, short Water)
{
	if (t.Render==1){
		if (t.isWater==Water)
			{
			fprintf (MAPFILE, "// primitive %d\n",PrimitiveCount++);
			fprintf (MAPFILE, "{\nbrushDef3\n{\n");
			//east face 
			fprintf (MAPFILE, "( 1 0 0 %d )",-((x+t.DimX)*BrushSizeX));
			getWallTextureName(t,fEAST,0);
			//north face 
			fprintf (MAPFILE, "( 0 1 0 %d )",-((y+t.DimY)*BrushSizeY));
			getWallTextureName(t,fNORTH,0);
			//top face
			fprintf (MAPFILE, "( 0 0 1 %d )", -BrushSizeZ * (CEILING_HEIGHT+1) );	
			getFloorTextureName(t,fTOP);
			//west face
			fprintf (MAPFILE, "( -1 0 0 %d )", +((x)*BrushSizeX));
			getWallTextureName(t,fWEST,0);
			//south face
			fprintf (MAPFILE, "( 0 -1 0 %d )", +((y)*BrushSizeY));
			getWallTextureName(t, fSOUTH,0);
			//bottom face
			fprintf (MAPFILE, "( 0 0 -1 %d )", -2*BrushSizeZ);	
			getFloorTextureName(t, fBOTTOM);
			fprintf (MAPFILE, "}\n}\n");
		}
	}
	return;
}

void RenderOpenTile(int x, int y, tile &t, short Water,short invert)
{
	if (t.Render ==1 ){
		if(t.isWater==Water)
			{	
			if (invert==0)
				{			
				fprintf (MAPFILE, "// primitive %d\n",PrimitiveCount++);
				fprintf (MAPFILE, "{\nbrushDef3\n{\n");
				//East face
				fprintf (MAPFILE, "( 1 0 0 %d )",-((x+t.DimX)*BrushSizeX));
				getWallTextureName(t,fEAST,t.isWater);
				//North face
				fprintf (MAPFILE, "( 0 1 0 %d ) ",-((y+t.DimY)*BrushSizeY));
				getWallTextureName(t,fNORTH,t.isWater);
				//Top face
				fprintf (MAPFILE, "( 0 0 1 %d )", -( (t.floorHeight) * BrushSizeZ) );	
				getFloorTextureName(t,fTOP);
				//West face
				fprintf (MAPFILE, "( -1 0 0 %d )", +((x)*BrushSizeX));
				getWallTextureName(t,fWEST,t.isWater);
				//South face
				fprintf (MAPFILE, "( 0 -1 0 %d )", +((y)*BrushSizeY));
				getWallTextureName(t,fSOUTH,t.isWater);
				//Bottom face 
				if (t.hasElevator ==0)
					{
					fprintf (MAPFILE, "( 0 0 -1 %d ) ", -2*BrushSizeZ);	
					}
				else
					{
					fprintf (MAPFILE, "( 0 0 -1 %d ) ", -8*BrushSizeZ);	
					}
				getFloorTextureName(t,fBOTTOM);
				fprintf (MAPFILE, "}\n}\n");
				}
			else
				{
				//render a ceiling version of this tile
				//top and bottom faces move up
				fprintf (MAPFILE, "// primitive %d\n",PrimitiveCount++);
				fprintf (MAPFILE, "{\nbrushDef3\n{\n");
				//East face
				fprintf (MAPFILE, "( 1 0 0 %d )",-((x+t.DimX)*BrushSizeX));
				getWallTextureName(t,fEAST,t.isWater);
				//North face
				fprintf (MAPFILE, "( 0 1 0 %d ) ",-((y+t.DimY)*BrushSizeY));
				getWallTextureName(t,fNORTH,t.isWater);
				//Top face
				fprintf (MAPFILE, "( 0 0 1 %d )", -( (CEILING_HEIGHT+1) * BrushSizeZ));	
				getFloorTextureName(t,fTOP);
				//West face
				fprintf (MAPFILE, "( -1 0 0 %d )", +((x)*BrushSizeX));
				getWallTextureName(t,fWEST,t.isWater);
				//South face
				fprintf (MAPFILE, "( 0 -1 0 %d )", +((y)*BrushSizeY));
				getWallTextureName(t,fSOUTH,t.isWater);
				//Bottom face 
				fprintf (MAPFILE, "( 0 0 -1 %d ) ", +(CEILING_HEIGHT -(t.ceilingHeight))* BrushSizeZ);	
				getFloorTextureName(t,fCEIL);
				fprintf (MAPFILE, "}\n}\n");				
				}
			}
		}
}

void RenderDiagSETile(int x, int y, tile &t, short Water,short invert)
{
float angle=0;
float BrushX=0; float BrushY=0; float BrushZ=0;
float normalDist =0;

	if (t.Render ==1 )
		{
		BrushX = (float)BrushSizeX; BrushY = (float)BrushSizeY;
		angle = atan((float)(BrushX/BrushY));
		if (invert==0)
			{
			normalDist = ( cos(atan((float)BrushY/BrushX)) ) * (x-y) * BrushSizeY;
			if(Water!=1)	
				{
				fprintf (MAPFILE, "// primitive %d\n",PrimitiveCount++);
				fprintf (MAPFILE, "{\nbrushDef3\n{\n");
				//North face
				fprintf (MAPFILE, "( 0 1 0 %d )",-((y+t.DimY)*BrushSizeY));
				getWallTextureName(t,fNORTH,0);
				//Top face
				fprintf (MAPFILE, "( 0 0 1 %d )", -BrushSizeZ * (CEILING_HEIGHT+1)   );
				getFloorTextureName(t,fTOP);
				//West face
				fprintf (MAPFILE, "( -1 0 0 %d )", +((x)*BrushSizeX));
				getWallTextureName(t,fWEST,0);
				//Bottom face 
				fprintf (MAPFILE, "( 0 0 -1 %d )", -2*BrushSizeZ);	//to go underneath
				getFloorTextureName(t,fBOTTOM);
				//Angled face. x & y change
				//TODO: Change texture here
				fprintf (MAPFILE, "( %f -%f 0 %f )", cos(angle),sin(angle),-normalDist);	
				getWallTextureName(t,fSELF,0);
				fprintf (MAPFILE, "}\n}\n");
				}
			if(t.isWater==Water)
				{					
				//it's floor
				fprintf (MAPFILE, "// primitive %d\n",PrimitiveCount++);
				fprintf (MAPFILE, "{\nbrushDef3\n{\n");
				//East Face
				fprintf (MAPFILE, "( 1 0 0 %d )",-((x+t.DimX)*BrushSizeX));
				getWallTextureName(t, fEAST,t.isWater );
				//Top face
				fprintf (MAPFILE, "( 0 0 1 %d )", -( (t.floorHeight) * BrushSizeZ) );	
				getFloorTextureName(t, fTOP);
				//South face
				fprintf (MAPFILE, "( 0 -1 0 %d )", +((y)*BrushSizeY));
				getWallTextureName(t,fSOUTH,t.isWater );
				//Bottom face
				fprintf (MAPFILE, "( 0 0 -1 %d )", -2*BrushSizeZ);
				getFloorTextureName(t, fBOTTOM );
				//Angled face. x & y change
				normalDist = ( cos(atan((float)BrushY/BrushX)) ) * (x-y) * BrushSizeY;
				fprintf (MAPFILE, "( -%f %f 0 %f )", cos(angle),sin(angle),normalDist);	
				getWallTextureName(t,fEAST,t.isWater );
				fprintf (MAPFILE, "}\n}\n");
				}
			}
		else
			{//it's ceiling
				fprintf (MAPFILE, "// primitive %d\n",PrimitiveCount++);
				fprintf (MAPFILE, "{\nbrushDef3\n{\n");
				//East Face
				fprintf (MAPFILE, "( 1 0 0 %d )",-((x+t.DimX)*BrushSizeX));
				getWallTextureName(t, fEAST,t.isWater );
				//Top face
				fprintf (MAPFILE, "( 0 0 1 %d )", -( (CEILING_HEIGHT+1) * BrushSizeZ) );
				getFloorTextureName(t, fTOP);
				//South face
				fprintf (MAPFILE, "( 0 -1 0 %d )", +((y)*BrushSizeY));
				getWallTextureName(t,fSOUTH,t.isWater );
				//Bottom face
				//fprintf (MAPFILE, "( 0 0 -1 %d )", +t.ceilingHeight * BrushSizeZ);
				fprintf (MAPFILE, "( 0 0 -1 %d ) ", +(CEILING_HEIGHT -(t.ceilingHeight))* BrushSizeZ);				
				getFloorTextureName(t, fCEIL );
				//Angled face. x & y change
				normalDist = ( cos(atan((float)BrushY/BrushX)) ) * (x-y) * BrushSizeY;
				fprintf (MAPFILE, "( -%f %f 0 %f )", cos(angle),sin(angle),normalDist);	
				getWallTextureName(t,fEAST,t.isWater );
				fprintf (MAPFILE, "}\n}\n");	
			}
	}
	return;
}
void RenderDiagSWTile(int x, int y, tile &t, short Water,short invert)
{
float angle=0;
float BrushX=0; float BrushY=0; float BrushZ=0;
float normalDist =0;

	if (t.Render==1)
		{
		BrushX = (float)BrushSizeX; BrushY = (float)BrushSizeY;
		angle = atan((float)(BrushX/BrushY));		
		if (invert ==0)
		{
		normalDist = ( cos(atan((float)BrushY/BrushX)) ) * (y+x+1) * BrushSizeY;				
		if(Water!=1)
			{
			fprintf (MAPFILE, "// primitive %d\n",PrimitiveCount++);
			fprintf (MAPFILE, "{\nbrushDef3\n{\n");
			//East face
			fprintf (MAPFILE, "( 1 0 0 %d )",-((x+t.DimX)*BrushSizeX));
			getWallTextureName(t,fEAST,0);
			//North face
			fprintf (MAPFILE, "( 0 1 0 %d )",-((y+t.DimY)*BrushSizeY));
			getWallTextureName(t, fNORTH,0);
			//Top face
			fprintf (MAPFILE, "( 0 0 1 %d )", -BrushSizeZ * (CEILING_HEIGHT+1)   );	
			getFloorTextureName(t,fTOP);
			//Bottom face
			fprintf (MAPFILE, "( 0 0 -1 %d )", -2*BrushSizeZ);	
			getWallTextureName(t,fBOTTOM,0);
			//Angled face. x & y change
			fprintf (MAPFILE, "( -%f -%f 0 %f )", cos(angle),sin(angle),+normalDist);		
			getWallTextureName(t,fSELF,0);
			fprintf (MAPFILE, "}\n}\n");
			}
		if(t.isWater==Water)
			{
			//it's floor
			fprintf (MAPFILE, "// primitive %d\n",PrimitiveCount++);
			fprintf (MAPFILE, "{\nbrushDef3\n{\n");
			//Top face
			fprintf (MAPFILE, "( 0 0 1 %d )", -( (t.floorHeight) * BrushSizeZ) );
			getFloorTextureName(t,fTOP);		
			//West face 
			fprintf (MAPFILE, "( -1 0 0 %d )", +((x)*BrushSizeX));
			getWallTextureName(t,fWEST,t.isWater );
			//South face
			fprintf (MAPFILE, "( 0 -1 0 %d )", +((y)*BrushSizeY));
			getWallTextureName(t,fSOUTH,t.isWater );
			//Bottom face
			fprintf (MAPFILE, "( 0 0 -1 %d )", -2*BrushSizeZ);
			getWallTextureName(t,fBOTTOM,t.isWater );
			//Angled face. x & y change
			normalDist = ( cos(atan((float)BrushY/BrushX)) ) * (y+x+1) * BrushSizeY;
			fprintf (MAPFILE, "( %f %f 0 %f )", cos(angle),sin(angle),-normalDist);
			getWallTextureName(t,fEAST,t.isWater );
			fprintf (MAPFILE, "}\n}\n");
			}
		}
		else
			{//its' ceiling.
			fprintf (MAPFILE, "// primitive %d\n",PrimitiveCount++);
			fprintf (MAPFILE, "{\nbrushDef3\n{\n");
			//Top face
			fprintf (MAPFILE, "( 0 0 1 %d )", -( (CEILING_HEIGHT+1) * BrushSizeZ) );
			getFloorTextureName(t,fTOP);		
			//West face 
			fprintf (MAPFILE, "( -1 0 0 %d )", +((x)*BrushSizeX));
			getWallTextureName(t,fWEST,t.isWater );
			//South face
			fprintf (MAPFILE, "( 0 -1 0 %d )", +((y)*BrushSizeY));
			getWallTextureName(t,fSOUTH,t.isWater );
			//Bottom face
			//fprintf (MAPFILE, "( 0 0 -1 %d )", +t.ceilingHeight * BrushSizeZ);
			fprintf (MAPFILE, "( 0 0 -1 %d ) ", +(CEILING_HEIGHT -(t.ceilingHeight))* BrushSizeZ);			
			//getWallTextureName(t,fCEIL,t.isWater );
			getFloorTextureName(t,fCEIL);
			//Angled face. x & y change
			normalDist = ( cos(atan((float)BrushY/BrushX)) ) * (y+x+1) * BrushSizeY;
			fprintf (MAPFILE, "( %f %f 0 %f )", cos(angle),sin(angle),-normalDist);
			getWallTextureName(t,fEAST,t.isWater );
			fprintf (MAPFILE, "}\n}\n");			
			}
		}
return;
}
void RenderDiagNETile(int x, int y, tile &t, short Water,short invert)
{
float angle=0;
float BrushX=0; float BrushY=0; float BrushZ=0;
float normalDist =0;

	if (t.Render==1){
			BrushX = (float)BrushSizeX; BrushY = (float)BrushSizeY;
			angle = atan((float)(BrushX/BrushY));
		if (invert == 0)
			{
			normalDist = ( cos(atan((float)BrushY/BrushX)) ) * (y+x+1) * BrushSizeY;				
			if(Water!=1)
				{				
				fprintf (MAPFILE, "// primitive %d\n",PrimitiveCount++);
				fprintf (MAPFILE, "{\nbrushDef3\n{\n");
				//Top face
				fprintf (MAPFILE, "( 0 0 1 %d )", -BrushSizeZ * (CEILING_HEIGHT+1)   );	
				getFloorTextureName(t,fTOP);
				//West face
				fprintf (MAPFILE, "( -1 0 0 %d )", +((x)*BrushSizeX));
				getWallTextureName(t,fWEST,0);
				//South face 
				fprintf (MAPFILE, "( 0 -1 0 %d )", +((y)*BrushSizeY));
				getWallTextureName(t,fSOUTH,0);
				//Bottom face
				fprintf (MAPFILE, "( 0 0 -1 %d )", -2*BrushSizeZ);
				getWallTextureName(t,fBOTTOM,0);
				//Angled face. x & y change
				fprintf (MAPFILE, "( %f %f 0 %f )", cos(angle),sin(angle),-normalDist);
				getWallTextureName(t,fSELF,0);
				fprintf (MAPFILE, "}\n}\n");
				}
			if(t.isWater==Water)
				{					
				//it's floor
				fprintf (MAPFILE, "// primitive %d\n",PrimitiveCount++);
				fprintf (MAPFILE, "{\nbrushDef3\n{\n");
				//East face
				fprintf (MAPFILE, "( 1 0 0 %d )",-((x+t.DimX)*BrushSizeX));
				getWallTextureName(t,fEAST,t.isWater );
				//North face
				fprintf (MAPFILE, "( 0 1 0 %d )",-((y+t.DimY)*BrushSizeY));
				getWallTextureName(t,fNORTH,t.isWater );
				//Top face
				fprintf (MAPFILE, "( 0 0 1 %d )", -( (t.floorHeight) * BrushSizeZ) );	
				getFloorTextureName(t,fTOP );
				//Bottom face
				fprintf (MAPFILE, "( 0 0 -1 %d )", -2*BrushSizeZ);
				getWallTextureName(t,fBOTTOM,t.isWater );
				//Angled face. x & y change
				normalDist = ( cos(atan((float)BrushY/BrushX)) ) * (y+x+1) * BrushSizeY;
				fprintf (MAPFILE, "( -%f -%f 0 %f )", cos(angle),sin(angle),+normalDist);	
				getWallTextureName(t,fWEST,t.isWater );	
				fprintf (MAPFILE, "}\n}\n");
				}
			}
	else
		{//it's ceiling
			fprintf (MAPFILE, "// primitive %d\n",PrimitiveCount++);
			fprintf (MAPFILE, "{\nbrushDef3\n{\n");
			//East face
			fprintf (MAPFILE, "( 1 0 0 %d )",-((x+t.DimX)*BrushSizeX));
			getWallTextureName(t,fEAST,t.isWater );
			//North face
			fprintf (MAPFILE, "( 0 1 0 %d )",-((y+t.DimY)*BrushSizeY));
			getWallTextureName(t,fNORTH,t.isWater );
			//Top face
			fprintf (MAPFILE, "( 0 0 1 %d )", -( (CEILING_HEIGHT+1) * BrushSizeZ));	
			getFloorTextureName(t,fTOP );
			//Bottom face
			//fprintf (MAPFILE, "( 0 0 -1 %d )", + t.ceilingHeight * BrushSizeZ);
			fprintf (MAPFILE, "( 0 0 -1 %d ) ", +(CEILING_HEIGHT -(t.ceilingHeight))* BrushSizeZ);			
			//getWallTextureName(t,fCEIL,t.isWater );
			getFloorTextureName(t,fCEIL);
			//Angled face. x & y change
			normalDist = ( cos(atan((float)BrushY/BrushX)) ) * (y+x+1) * BrushSizeY;
			fprintf (MAPFILE, "( -%f -%f 0 %f )", cos(angle),sin(angle),+normalDist);	
			getWallTextureName(t,fWEST,t.isWater );	
			fprintf (MAPFILE, "}\n}\n");		
		}
	}
return;
}
void RenderDiagNWTile(int x, int y, tile &t, short Water,short invert)
{
float angle=0;
float BrushX=0; float BrushY=0; float BrushZ=0;
float normalDist =0;

	if (t.Render==1)
		{
		BrushX = (float)BrushSizeX; BrushY = (float)BrushSizeY;
		angle = atan((float)(BrushX/BrushY));
		normalDist = ( cos(atan((float)BrushY/BrushX)) ) * (x-y) * BrushSizeY;				
		if (invert==0)
			{
			if(Water!=1)
				{
				fprintf (MAPFILE, "// primitive %d\n",PrimitiveCount++);
				fprintf (MAPFILE, "{\nbrushDef3\n{\n");
				//East face -absdist
				fprintf (MAPFILE, "( 1 0 0 %d )",-((x+t.DimX)*BrushSizeX));
				getWallTextureName(t,fEAST,0 );
				//Top face
				fprintf (MAPFILE, "( 0 0 1 %d )", -BrushSizeZ * (CEILING_HEIGHT+1)   );	
				getFloorTextureName(t,fTOP );
				//South face
				fprintf (MAPFILE, "( 0 -1 0 %d )", +((y)*BrushSizeY));
				getWallTextureName(t,fSOUTH,0 );
				//Bottom face
				fprintf (MAPFILE, "( 0 0 -1 %d )", -2*BrushSizeZ);
				getWallTextureName(t,fBOTTOM,0 );
				//Angled face. x & y change
				fprintf (MAPFILE, "( -%f %f 0 %f )", cos(angle),sin(angle),normalDist);
				getWallTextureName(t,fSELF,0 );	
				fprintf (MAPFILE, "}\n}\n");
				}
			
			//it's floor
			if(t.isWater==Water)
				{					
				fprintf (MAPFILE, "// primitive %d\n",PrimitiveCount++);
				fprintf (MAPFILE, "{\nbrushDef3\n{\n");
				//North face
				fprintf (MAPFILE, "( 0 1 0 %d )",-((y+t.DimY)*BrushSizeY));
				getWallTextureName(t,fNORTH,t.isWater );
				//Top face
				fprintf (MAPFILE, "( 0 0 1 %d )", -( (t.floorHeight) * BrushSizeZ) );
				getFloorTextureName(t,fTOP);
				//West face
				fprintf (MAPFILE, "( -1 0 0 %d )", +((x)*BrushSizeX));
				getWallTextureName(t,fWEST,t.isWater);
				//Bottom face +absdist
				fprintf (MAPFILE, "( 0 0 -1 %d )", -2*BrushSizeZ);
				getWallTextureName(t,fBOTTOM,t.isWater );
				//Angled face. x & y change
				normalDist = ( cos(atan((float)BrushY/BrushX)) ) * (x-y) * BrushSizeY;
				fprintf (MAPFILE, "( %f -%f 0 %f )", cos(angle),sin(angle),-normalDist);
				getWallTextureName(t,fWEST,t.isWater );	
				fprintf (MAPFILE, "}\n}\n");
				}
			}
		else
			{//it's ceiling
			fprintf (MAPFILE, "// primitive %d\n",PrimitiveCount++);
			fprintf (MAPFILE, "{\nbrushDef3\n{\n");
			//North face
			fprintf (MAPFILE, "( 0 1 0 %d )",-((y+t.DimY)*BrushSizeY));
			getWallTextureName(t,fNORTH,t.isWater );
			//Top face
			fprintf (MAPFILE, "( 0 0 1 %d )", -( (CEILING_HEIGHT+1) * BrushSizeZ) );
			getFloorTextureName(t,fTOP);
			//West face
			fprintf (MAPFILE, "( -1 0 0 %d )", +((x)*BrushSizeX));
			getWallTextureName(t,fWEST,t.isWater);
			//Bottom face +absdist
			//fprintf (MAPFILE, "( 0 0 -1 %d )", +t.ceilingHeight * BrushSizeZ);
			fprintf (MAPFILE, "( 0 0 -1 %d ) ", +(CEILING_HEIGHT -(t.ceilingHeight))* BrushSizeZ);			
			//getWallTextureName(t,fCEIL,t.isWater );
			getFloorTextureName(t,fCEIL);
			//Angled face. x & y change
			normalDist = ( cos(atan((float)BrushY/BrushX)) ) * (x-y) * BrushSizeY;
			fprintf (MAPFILE, "( %f -%f 0 %f )", cos(angle),sin(angle),-normalDist);
			getWallTextureName(t,fWEST,t.isWater );	
			fprintf (MAPFILE, "}\n}\n");
			}
		}
return;
}
void RenderSlopeNTile(int x, int y, tile &t, short Water,short invert)
{
float angle=0;
float BrushX=0; float BrushY=0; float BrushZ=0;
float normalDist =0;
float floorHeight = t.floorHeight ;
float ceilingHeight = (CEILING_HEIGHT -(t.ceilingHeight)) ;//-1
float steepness = t.shockSteep ;

	if (t.Render==1){
		if (invert ==0)
			{
			BrushZ = (float)BrushSizeZ*steepness; BrushY = (float)BrushSizeY;
			angle = atan((float)(BrushY/BrushZ));
			normalDist = (cos(atan(BrushZ/BrushY))) * ((floorHeight/steepness) -y) * BrushZ;
			if(t.isWater==Water)
				{				
				fprintf (MAPFILE, "// primitive %d\n",PrimitiveCount++);
				fprintf (MAPFILE, "{\nbrushDef3\n{\n");
				//East face
				fprintf (MAPFILE, "( 1 0 0 %d )",-((x+t.DimX)*BrushSizeX));
				getWallTextureName(t,fEAST,t.isWater );
				//North face
				fprintf (MAPFILE, "( 0 1 0 %d )",-((y+t.DimY)*BrushSizeY));
				getWallTextureName(t, fNORTH,t.isWater );
				//Top face
				fprintf (MAPFILE, "( 0 %f %f %f )", -cos(angle), sin(angle),-normalDist);	
				getFloorTextureName(t,fTOP );
				//West face
				fprintf (MAPFILE, "( -1 0 0 %d )", +((x)*BrushSizeX));
				getWallTextureName(t,fWEST,t.isWater );
				//South face
				fprintf (MAPFILE, "( 0 -1 0 %d )", +((y)*BrushSizeY));
				getWallTextureName(t,fSOUTH,t.isWater );
				//Bottom face
				fprintf (MAPFILE, "( 0 0 -1 %d )", -2*BrushSizeZ);
				getWallTextureName(t,fBOTTOM,t.isWater );
				fprintf (MAPFILE, "}\n}\n");
				}
			}
		else
			{
			BrushZ = (float)BrushSizeZ*steepness; BrushY = (float)BrushSizeY;
			angle = atan((float)(BrushY/BrushZ));
			normalDist = (cos(atan(BrushZ/BrushY))) * ((ceilingHeight/steepness)-y-1) * BrushZ;
				
				fprintf (MAPFILE, "// primitive %d\n",PrimitiveCount++);
				fprintf (MAPFILE, "{\nbrushDef3\n{\n");
				//East face
				fprintf (MAPFILE, "( 1 0 0 %d )",-((x+t.DimX)*BrushSizeX));
				getWallTextureName(t,fEAST,t.isWater );
				//North face
				fprintf (MAPFILE, "( 0 1 0 %d )",-((y+t.DimY)*BrushSizeY));
				getWallTextureName(t, fNORTH,t.isWater );
				//Top face	->becomes ceiling 
				fprintf (MAPFILE, "( 0 0 1 %d )", -(CEILING_HEIGHT+1)*BrushSizeZ);
					
				getFloorTextureName(t,fTOP );
				//West face
				fprintf (MAPFILE, "( -1 0 0 %d )", +((x)*BrushSizeX));
				getWallTextureName(t,fWEST,t.isWater );
				//South face
				fprintf (MAPFILE, "( 0 -1 0 %d )", +((y)*BrushSizeY));
				getWallTextureName(t,fSOUTH,t.isWater );
				//Bottom face
				fprintf (MAPFILE, "( 0 %f %f %f )", cos(angle), -sin(angle),+normalDist);
				getFloorTextureName(t,fCEIL);
				fprintf (MAPFILE, "}\n}\n");			

			}
		}
	return;
}
void RenderSlopeSTile(int x, int y, tile &t, short Water,short invert)
{
float angle=0;
float BrushX=0; float BrushY=0; float BrushZ=0;
float normalDist =0;
float floorHeight = t.floorHeight ;
float steepness = t.shockSteep ;
float ceilingHeight = CEILING_HEIGHT - t.ceilingHeight ;//t.floorHeight + t.ceilingHeight ;// -(t.ceilingHeight)) ;

if (t.Render==1)
	{
	if (invert==0)
		{
		BrushZ = (float)BrushSizeZ*steepness; BrushY = (float)BrushSizeY;
		angle = atan((float)(BrushY/BrushZ));
		normalDist = (cos(atan(BrushZ/BrushY))) * ((floorHeight/steepness) +y+1) * BrushZ;				
		if(t.isWater==Water)
			{
			fprintf (MAPFILE, "// primitive %d\n",PrimitiveCount++);
			fprintf (MAPFILE, "{\nbrushDef3\n{\n");
			//East face
			fprintf (MAPFILE, "( 1 0 0 %d )",-((x+t.DimX)*BrushSizeX));
			getWallTextureName(t,fEAST,t.isWater );
			//North face
			fprintf (MAPFILE, "( 0 1 0 %d )",-((y+t.DimY)*BrushSizeY));
			getWallTextureName(t,fNORTH,t.isWater );
			//Top face
			fprintf (MAPFILE, "( 0 %f %f %f )", cos(angle), sin(angle),-normalDist);	
			getFloorTextureName(t,fTOP );
			//West face
			fprintf (MAPFILE, "( -1 0 0 %d )", +((x)*BrushSizeX));
			getWallTextureName(t,fWEST,t.isWater );
			//South face
			fprintf (MAPFILE, "( 0 -1 0 %d )", +((y)*BrushSizeY));
			getWallTextureName(t,fSOUTH,t.isWater );
			//Bottom face +absdist
			fprintf (MAPFILE, "( 0 0 -1 %d )", -2*BrushSizeZ);	//+10 to go underneath
			getWallTextureName(t,fBOTTOM,t.isWater );
			fprintf (MAPFILE, "}\n}\n");
			}
		}
		else
			{

			BrushZ = (float)BrushSizeZ*steepness; BrushY = (float)BrushSizeY;
			angle = atan((float)(BrushY/BrushZ));
			//normalDist = (cos(atan(BrushZ/BrushY))) * ((ceilingHeight/steepness) -y) * BrushZ;
			normalDist = (cos(atan(BrushZ/BrushY))) * ((ceilingHeight/steepness) +y) * BrushZ;					
				fprintf (MAPFILE, "// primitive %d\n",PrimitiveCount++);
				fprintf (MAPFILE, "{\nbrushDef3\n{\n");
				//East face
				fprintf (MAPFILE, "( 1 0 0 %d )",-((x+t.DimX)*BrushSizeX));
				getWallTextureName(t,fEAST,t.isWater );
				//North face
				fprintf (MAPFILE, "( 0 1 0 %d )",-((y+t.DimY)*BrushSizeY));
				getWallTextureName(t, fNORTH,t.isWater );
				//Top face	->becomes ceiling 
				fprintf (MAPFILE, "( 0 0 1 %d )", -(CEILING_HEIGHT+1)*BrushSizeZ);
					
				getFloorTextureName(t,fTOP );
				//West face
				fprintf (MAPFILE, "( -1 0 0 %d )", +((x)*BrushSizeX));
				getWallTextureName(t,fWEST,t.isWater );
				//South face
				fprintf (MAPFILE, "( 0 -1 0 %d )", +((y)*BrushSizeY));
				getWallTextureName(t,fSOUTH,t.isWater );
				//Bottom face
				fprintf (MAPFILE, "( 0 %f %f %f )", -cos(angle), -sin(angle),+normalDist);
				getFloorTextureName(t,fCEIL);
				fprintf (MAPFILE, "}\n}\n");
			
			}
		}
return;

}
void RenderSlopeWTile(int x, int y, tile &t, short Water,short invert)
{
float angle=0;
float BrushX=0; float BrushY=0; float BrushZ=0;
float normalDist =0;
float floorHeight = t.floorHeight ;
float steepness = t.shockSteep ;
float ceilingHeight =  t.ceilingHeight ;
	if (t.Render==1){
		if(invert==0)
			{
			BrushZ = (float)BrushSizeZ*steepness; BrushX = (float)BrushSizeX;
			angle = atan((float)(BrushX/BrushZ));
			normalDist = (cos(atan(BrushZ/BrushX))) * ((floorHeight)/steepness+x+1) * BrushZ;				
			if(t.isWater==Water)
				{
				fprintf (MAPFILE, "// primitive %d\n",PrimitiveCount++);
				fprintf (MAPFILE, "{\nbrushDef3\n{\n");
				//East face
				fprintf (MAPFILE, "( 1 0 0 %d )",-((x+t.DimX)*BrushSizeX));
				getWallTextureName(t,fEAST,t.isWater);
				//North face
				fprintf (MAPFILE, "( 0 1 0 %d )",-((y+t.DimY)*BrushSizeY));
				getWallTextureName(t,fNORTH,t.isWater);
				//Top face
				fprintf (MAPFILE, "( %f 0 %f %f )", cos(angle),sin(angle),-normalDist);	
				getFloorTextureName(t,fTOP);
				//West face
				fprintf (MAPFILE, "( -1 0 0 %d )", +((x)*BrushSizeX));
				getWallTextureName(t,fWEST,t.isWater);
				//South face
				fprintf (MAPFILE, "( 0 -1 0 %d )", +((y)*BrushSizeY));
				getWallTextureName(t, fSOUTH,t.isWater);
				//Bottom face
				fprintf (MAPFILE, "( 0 0 -1 %d )", -2*BrushSizeZ);	//+10 to go underneath
				getWallTextureName(t,fBOTTOM,t.isWater);
				fprintf (MAPFILE, "}\n}\n");
			}
			}
		else
			{
				BrushZ = (float)BrushSizeZ*steepness ; BrushX = (float)BrushSizeX;
				angle = atan((float)(BrushX/(BrushZ)));
				//((+x) + ((CEILING_HEIGHT-ceilingHeight)/steepness))
				normalDist = (cos(atan((BrushZ)/(BrushX)))) * ((-x) - ((CEILING_HEIGHT-ceilingHeight)/steepness)) * BrushZ  ;	
				
				fprintf (MAPFILE, "// primitive %d\n",PrimitiveCount++);
				fprintf (MAPFILE, "{\nbrushDef3\n{\n");
				//East face
				fprintf (MAPFILE, "( 1 0 0 %d )",-((x+t.DimX)*BrushSizeX));
				getWallTextureName(t,fEAST,t.isWater);
				//North face
				fprintf (MAPFILE, "( 0 1 0 %d )",-((y+t.DimY)*BrushSizeY));
				getWallTextureName(t,fNORTH,t.isWater);
				//Top face
				fprintf (MAPFILE, "( 0 0 1 %d )", -(CEILING_HEIGHT+1)*BrushSizeZ);					
				getFloorTextureName(t,fTOP);
				//West face
				fprintf (MAPFILE, "( -1 0 0 %d )", +((x)*BrushSizeX));
				getWallTextureName(t,fWEST,t.isWater);
				//South face
				fprintf (MAPFILE, "( 0 -1 0 %d )", +((y)*BrushSizeY));
				getWallTextureName(t, fSOUTH,t.isWater);
				//Bottom face
				fprintf (MAPFILE, "( %f 0 %f %f )", -cos(angle),-sin(angle),-normalDist);
				getFloorTextureName(t,fCEIL);
				fprintf (MAPFILE, "}\n}\n");			
			}
		}
return;
}
void RenderSlopeETile(int x, int y, tile &t, short Water,short invert)
{
float angle=0;
float BrushX=0; float BrushY=0; float BrushZ=0;
float normalDist =0;
float floorHeight = t.floorHeight ;
float steepness = t.shockSteep ;
float ceilingHeight =  t.ceilingHeight ;

	if (t.Render==1){
	if (invert == 0)
		{
		BrushZ = (float)BrushSizeZ*steepness ; BrushX = (float)BrushSizeX;
		angle = atan((float)(BrushX/(BrushZ)));
		normalDist = (cos(atan((BrushZ)/(BrushX)))) * ((floorHeight/steepness) -(x)) * BrushZ  ;				
		if(t.isWater==Water)
			{
			fprintf (MAPFILE, "// primitive %d\n",PrimitiveCount++);
			fprintf (MAPFILE, "{\nbrushDef3\n{\n");
			//East face
			fprintf (MAPFILE, "( 1 0 0 %d )",-((x+t.DimX)*BrushSizeX));
			getWallTextureName(t,fEAST,t.isWater );
			//North face 
			fprintf (MAPFILE, "( 0 1 0 %d )",-((y+t.DimY)*BrushSizeY));
			getWallTextureName(t,fNORTH,t.isWater );
			//Top face
			fprintf (MAPFILE, "( -%f 0 %f %f )", cos(angle),sin(angle),-normalDist);	
			getFloorTextureName(t,fTOP);
			//West face
			fprintf (MAPFILE, "( -1 0 0 %d )", +((x)*BrushSizeX));
			getWallTextureName(t,fWEST,t.isWater );
			//South face
			fprintf (MAPFILE, "( 0 -1 0 %d )", +((y)*BrushSizeY));
			getWallTextureName(t,fSOUTH,t.isWater );
			//Bottom face
			fprintf (MAPFILE, "( 0 0 -1 %d )", -2*BrushSizeZ);
			getWallTextureName(t,fBOTTOM,t.isWater );
			fprintf (MAPFILE, "}\n}\n");
			}
		}
	else
		{
		BrushZ = (float)BrushSizeZ*steepness; BrushX = (float)BrushSizeX;
		angle = atan((float)(BrushX/BrushZ));
		normalDist = (cos(atan(BrushZ/BrushX))) * ((+x+1) - ((CEILING_HEIGHT-ceilingHeight)/steepness)) * BrushZ;	
			fprintf (MAPFILE, "// primitive %d\n",PrimitiveCount++);
			fprintf (MAPFILE, "{\nbrushDef3\n{\n");
			//East face
			fprintf (MAPFILE, "( 1 0 0 %d )",-((x+t.DimX)*BrushSizeX));
			getWallTextureName(t,fEAST,t.isWater);
			//North face
			fprintf (MAPFILE, "( 0 1 0 %d )",-((y+t.DimY)*BrushSizeY));
			getWallTextureName(t,fNORTH,t.isWater);
			//Top face
			fprintf (MAPFILE, "( 0 0 1 %d )", -(CEILING_HEIGHT+1)*BrushSizeZ);				
			getFloorTextureName(t,fTOP);
			//West face
			fprintf (MAPFILE, "( -1 0 0 %d )", +((x)*BrushSizeX));
			getWallTextureName(t,fWEST,t.isWater);
			//South face
			fprintf (MAPFILE, "( 0 -1 0 %d )", +((y)*BrushSizeY));
			getWallTextureName(t, fSOUTH,t.isWater);
			//Bottom face
			fprintf (MAPFILE, "( %f 0 %f %f )", cos(angle),-sin(angle),-normalDist);
			getFloorTextureName(t,fCEIL);
			fprintf (MAPFILE, "}\n}\n");
					
		}
	}
return;
}
void RenderValleyNWTile(int x, int y, tile &t, short Water,short invert)
{
RenderSlopeNTile(x,y,t,Water,invert);
RenderSlopeWTile(x,y,t,Water,invert);
return;
}
void RenderValleyNETile(int x, int y, tile &t, short Water,short invert)
{
RenderSlopeETile(x,y,t,Water,invert);
RenderSlopeNTile(x,y,t,Water,invert);
return;
}
void RenderValleySWTile(int x, int y, tile &t, short Water,short invert)
{
RenderSlopeWTile(x,y,t,Water,invert);
RenderSlopeSTile(x,y,t,Water,invert);
return;
}
void RenderValleySETile(int x, int y, tile &t, short Water,short invert)
{
RenderSlopeETile(x,y,t,Water,invert);
RenderSlopeSTile(x,y,t,Water,invert);
return;
}
void RenderRidgeNWTile(int x, int y, tile &t, short Water,short invert)
{
float angle=0;
float BrushX=0; float BrushY=0; float BrushZ=0;
float normalDist =0;
float floorHeight = t.floorHeight ;
float steepness = t.shockSteep ;

	if (t.Render==1){
		if (invert==0)
						
			{//consists of a slope n and a slope w
			BrushZ = (float)BrushSizeZ*steepness; BrushY = (float)BrushSizeY;
			angle = atan((float)(BrushY/BrushZ));
			normalDist = (cos(atan(BrushZ/BrushY))) * ((floorHeight/steepness) -y) * BrushZ;
			if(t.isWater==Water)
				{				
				fprintf (MAPFILE, "// primitive %d\n",PrimitiveCount++);
				fprintf (MAPFILE, "{\nbrushDef3\n{\n");
				//East face
				fprintf (MAPFILE, "( 1 0 0 %d )",-((x+t.DimX)*BrushSizeX));
				getWallTextureName(t,fEAST,t.isWater );
				//North face
				fprintf (MAPFILE, "( 0 1 0 %d )",-((y+t.DimY)*BrushSizeY));
				getWallTextureName(t, fNORTH,t.isWater );
				//Top face
				fprintf (MAPFILE, "( 0 %f %f %f )", -cos(angle), sin(angle),-normalDist);	
				getFloorTextureName(t,fTOP );
				//West face
				fprintf (MAPFILE, "( -1 0 0 %d )", +((x)*BrushSizeX));
				getWallTextureName(t,fWEST,t.isWater );
				//South face
				fprintf (MAPFILE, "( 0 -1 0 %d )", +((y)*BrushSizeY));
				getWallTextureName(t,fSOUTH,t.isWater );
				//Bottom face
				fprintf (MAPFILE, "( 0 0 -1 %d )", -2*BrushSizeZ);
				getWallTextureName(t,fBOTTOM,t.isWater );
				
				//the other slope(w)
				BrushZ = (float)BrushSizeZ*steepness; BrushX = (float)BrushSizeX;
				angle = atan((float)(BrushX/BrushZ));
				normalDist = (cos(atan(BrushZ/BrushX))) * ((floorHeight)/steepness+x+1) * BrushZ;	
				fprintf (MAPFILE, "( %f 0 %f %f )", cos(angle),sin(angle),-normalDist);	
				getFloorTextureName(t,fTOP);			
				fprintf (MAPFILE, "}\n}\n");
			}
			}
		else
			{//made of upper slope e and upper slope s
				//render a ceiling version of this tile
				//top and bottom faces move up
				fprintf (MAPFILE, "// primitive %d\n",PrimitiveCount++);
				fprintf (MAPFILE, "{\nbrushDef3\n{\n");
				//East face
				fprintf (MAPFILE, "( 1 0 0 %d )",-((x+t.DimX)*BrushSizeX));
				getWallTextureName(t,fEAST,t.isWater);
				//North face
				fprintf (MAPFILE, "( 0 1 0 %d ) ",-((y+t.DimY)*BrushSizeY));
				getWallTextureName(t,fNORTH,t.isWater);
				//Top face
				fprintf (MAPFILE, "( 0 0 1 %d )", -( (CEILING_HEIGHT) * BrushSizeZ));	
				getFloorTextureName(t,fTOP);
				//West face
				fprintf (MAPFILE, "( -1 0 0 %d )", +((x)*BrushSizeX));
				getWallTextureName(t,fWEST,t.isWater);
				//South face
				fprintf (MAPFILE, "( 0 -1 0 %d )", +((y)*BrushSizeY));
				getWallTextureName(t,fSOUTH,t.isWater);
				//Bottom face 
				//s and e here
				float ceilingHeight = CEILING_HEIGHT - t.ceilingHeight;
				BrushZ = (float)BrushSizeZ*steepness; BrushY = (float)BrushSizeY;
				angle = atan((float)(BrushY/BrushZ));
				normalDist = (cos(atan(BrushZ/BrushY))) * ((ceilingHeight/steepness) +y) * BrushZ;
				fprintf (MAPFILE, "( 0 %f %f %f )", -cos(angle), -sin(angle),+normalDist);
				getFloorTextureName(t, fCEIL );

                 ceilingHeight =  t.ceilingHeight ;
				BrushZ = (float)BrushSizeZ*steepness; BrushX = (float)BrushSizeX;
				angle = atan((float)(BrushX/BrushZ));
				normalDist = (cos(atan(BrushZ/BrushX))) * ((+x+1) - ((CEILING_HEIGHT-ceilingHeight)/steepness)) * BrushZ;
				fprintf (MAPFILE, "( %f 0 %f %f )", cos(angle),-sin(angle),-normalDist);
				getWallTextureName(t,fCEIL,t.isWater);

				fprintf (MAPFILE, "}\n}\n");				
				}			
			
			}
	return;
}
void RenderRidgeNETile(int x, int y, tile &t, short Water,short invert)
{
//consists of a slope n and a slope e
float angle=0;
float BrushX=0; float BrushY=0; float BrushZ=0;
float normalDist =0;
float floorHeight = t.floorHeight ;
float steepness = t.shockSteep ;

	if (t.Render==1){
	if (invert==0){
		BrushZ = (float)BrushSizeZ*steepness; BrushY = (float)BrushSizeY;
		angle = atan((float)(BrushY/BrushZ));
		normalDist = (cos(atan(BrushZ/BrushY))) * ((floorHeight/steepness) -y) * BrushZ;
		if(t.isWater==Water)
			{				
			fprintf (MAPFILE, "// primitive %d\n",PrimitiveCount++);
			fprintf (MAPFILE, "{\nbrushDef3\n{\n");
			//East face
			fprintf (MAPFILE, "( 1 0 0 %d )",-((x+t.DimX)*BrushSizeX));
			getWallTextureName(t,fEAST,t.isWater );
			//North face
			fprintf (MAPFILE, "( 0 1 0 %d )",-((y+t.DimY)*BrushSizeY));
			getWallTextureName(t, fNORTH,t.isWater );
			//Top face
			fprintf (MAPFILE, "( 0 %f %f %f )", -cos(angle), sin(angle),-normalDist);	
			getFloorTextureName(t,fTOP );
			//West face
			fprintf (MAPFILE, "( -1 0 0 %d )", +((x)*BrushSizeX));
			getWallTextureName(t,fWEST,t.isWater );
			//South face
			fprintf (MAPFILE, "( 0 -1 0 %d )", +((y)*BrushSizeY));
			getWallTextureName(t,fSOUTH,t.isWater );
			//Bottom face
			fprintf (MAPFILE, "( 0 0 -1 %d )", -2*BrushSizeZ);
			getWallTextureName(t,fBOTTOM,t.isWater );
			
			//slope e
			BrushZ = (float)BrushSizeZ*steepness ; BrushX = (float)BrushSizeX;
			angle = atan((float)(BrushX/(BrushZ)));
			normalDist = (cos(atan((BrushZ)/(BrushX)))) * ((floorHeight/steepness) -(x)) * BrushZ  ;						
			fprintf (MAPFILE, "( -%f 0 %f %f )", cos(angle),sin(angle),-normalDist);	
			getFloorTextureName(t,fTOP);			
			fprintf (MAPFILE, "}\n}\n");
		}
		}
	else
		{//invert is south and west slopes
		
			//render a ceiling version of this tile
			//top and bottom faces move up
			fprintf (MAPFILE, "// primitive %d\n",PrimitiveCount++);
			fprintf (MAPFILE, "{\nbrushDef3\n{\n");
			//East face
			fprintf (MAPFILE, "( 1 0 0 %d )",-((x+t.DimX)*BrushSizeX));
			getWallTextureName(t,fEAST,t.isWater);
			//North face
			fprintf (MAPFILE, "( 0 1 0 %d ) ",-((y+t.DimY)*BrushSizeY));
			getWallTextureName(t,fNORTH,t.isWater);
			//Top face
			fprintf (MAPFILE, "( 0 0 1 %d )", -( (CEILING_HEIGHT) * BrushSizeZ));	
			getFloorTextureName(t,fTOP);
			//West face
			fprintf (MAPFILE, "( -1 0 0 %d )", +((x)*BrushSizeX));
			getWallTextureName(t,fWEST,t.isWater);
			//South face
			fprintf (MAPFILE, "( 0 -1 0 %d )", +((y)*BrushSizeY));
			getWallTextureName(t,fSOUTH,t.isWater);
			//Bottom face
			//s
				float ceilingHeight = CEILING_HEIGHT - t.ceilingHeight;
				BrushZ = (float)BrushSizeZ*steepness; BrushY = (float)BrushSizeY;
				angle = atan((float)(BrushY/BrushZ));
				normalDist = (cos(atan(BrushZ/BrushY))) * ((ceilingHeight/steepness) +y) * BrushZ;
				fprintf (MAPFILE, "( 0 %f %f %f )", -cos(angle), -sin(angle),+normalDist);
				getFloorTextureName(t, fCEIL );	
			//w
				ceilingHeight =  t.ceilingHeight ;	
				BrushZ = (float)BrushSizeZ*steepness ; BrushX = (float)BrushSizeX;
				angle = atan((float)(BrushX/(BrushZ)));
				normalDist = (cos(atan((BrushZ)/(BrushX)))) * ((-x) - ((CEILING_HEIGHT-ceilingHeight)/steepness)) * BrushZ  ;
				fprintf (MAPFILE, "( %f 0 %f %f )", -cos(angle),-sin(angle),-normalDist);
				getFloorTextureName(t,fCEIL);
			fprintf (MAPFILE, "}\n}\n");		
		}
	}

return;
}
void RenderRidgeSWTile(int x, int y, tile &t, short Water,short invert)
{
//consists of a slope s and a slope w
float angle=0;
float BrushX=0; float BrushY=0; float BrushZ=0;
float normalDist =0;
float floorHeight = t.floorHeight ;
float steepness = t.shockSteep ;

if (t.Render==1)
if (invert == 0)
	{
	{
	BrushZ = (float)BrushSizeZ*steepness; BrushY = (float)BrushSizeY;
	angle = atan((float)(BrushY/BrushZ));
	normalDist = (cos(atan(BrushZ/BrushY))) * ((floorHeight/steepness) +y+1) * BrushZ;				
	if(t.isWater==Water)
		{
		fprintf (MAPFILE, "// primitive %d\n",PrimitiveCount++);
		fprintf (MAPFILE, "{\nbrushDef3\n{\n");
		//East face
		fprintf (MAPFILE, "( 1 0 0 %d )",-((x+t.DimX)*BrushSizeX));
		getWallTextureName(t,fEAST,t.isWater );
		//North face
		fprintf (MAPFILE, "( 0 1 0 %d )",-((y+t.DimY)*BrushSizeY));
		getWallTextureName(t,fNORTH,t.isWater );
		//Top face
		fprintf (MAPFILE, "( 0 %f %f %f )", cos(angle), sin(angle),-normalDist);	
		getFloorTextureName(t,fTOP );
		//West face
		fprintf (MAPFILE, "( -1 0 0 %d )", +((x)*BrushSizeX));
		getWallTextureName(t,fWEST,t.isWater );
		//South face
		fprintf (MAPFILE, "( 0 -1 0 %d )", +((y)*BrushSizeY));
		getWallTextureName(t,fSOUTH,t.isWater );
		//Bottom face +absdist
		fprintf (MAPFILE, "( 0 0 -1 %d )", -2*BrushSizeZ);	//+10 to go underneath
		getWallTextureName(t,fBOTTOM,t.isWater );
		
		//slope w
		BrushZ = (float)BrushSizeZ*steepness; BrushX = (float)BrushSizeX;
		angle = atan((float)(BrushX/BrushZ));
		normalDist = (cos(atan(BrushZ/BrushX))) * ((floorHeight)/steepness+x+1) * BrushZ;	
		fprintf (MAPFILE, "( %f 0 %f %f )", cos(angle),sin(angle),-normalDist);	
		getFloorTextureName(t,fTOP);				
		fprintf (MAPFILE, "}\n}\n");
		}
	}
	}
	else
	{	//invert is n and w slopes
				//render a ceiling version of this tile
				fprintf (MAPFILE, "// primitive %d\n",PrimitiveCount++);
				fprintf (MAPFILE, "{\nbrushDef3\n{\n");
				//East face
				fprintf (MAPFILE, "( 1 0 0 %d )",-((x+t.DimX)*BrushSizeX));
				getWallTextureName(t,fEAST,t.isWater);
				//North face
				fprintf (MAPFILE, "( 0 1 0 %d ) ",-((y+t.DimY)*BrushSizeY));
				getWallTextureName(t,fNORTH,t.isWater);
				//Top face
				fprintf (MAPFILE, "( 0 0 1 %d )", -( (CEILING_HEIGHT) * BrushSizeZ));	
				getFloorTextureName(t,fTOP);
				//West face
				fprintf (MAPFILE, "( -1 0 0 %d )", +((x)*BrushSizeX));
				getWallTextureName(t,fWEST,t.isWater);
				//South face
				fprintf (MAPFILE, "( 0 -1 0 %d )", +((y)*BrushSizeY));
				getWallTextureName(t,fSOUTH,t.isWater);
				//Bottom faces
				//e
                 float ceilingHeight =  t.ceilingHeight ;
				BrushZ = (float)BrushSizeZ*steepness; BrushX = (float)BrushSizeX;
				angle = atan((float)(BrushX/BrushZ));
				normalDist = (cos(atan(BrushZ/BrushX))) * ((+x+1) - ((CEILING_HEIGHT-ceilingHeight)/steepness)) * BrushZ;
				fprintf (MAPFILE, "( %f 0 %f %f )", cos(angle),-sin(angle),-normalDist);
				getFloorTextureName(t,fCEIL);
				
				//n
                ceilingHeight = (CEILING_HEIGHT -(t.ceilingHeight)) ;
				BrushZ = (float)BrushSizeZ*steepness; BrushY = (float)BrushSizeY;
				angle = atan((float)(BrushY/BrushZ));
				normalDist = (cos(atan(BrushZ/BrushY))) * ((ceilingHeight/steepness)-y-1) * BrushZ;
                fprintf (MAPFILE, "( 0 %f %f %f )", cos(angle), -sin(angle),+normalDist);			
				getFloorTextureName(t,fCEIL);
				fprintf (MAPFILE, "}\n}\n");				
	
	}
return;
}
void RenderRidgeSETile(int x, int y, tile &t, short Water,short invert)
{
//consists of a slope s and a slope e
//done
float angle=0;
float BrushX=0; float BrushY=0; float BrushZ=0;
float normalDist =0;
float floorHeight = t.floorHeight ;
float steepness = t.shockSteep ;

if (t.Render==1)
	{
if (invert ==0)
	{
	BrushZ = (float)BrushSizeZ*steepness; BrushY = (float)BrushSizeY;
	angle = atan((float)(BrushY/BrushZ));
	normalDist = (cos(atan(BrushZ/BrushY))) * ((floorHeight/steepness) +y+1) * BrushZ;				
	if(t.isWater==Water)
		{
		fprintf (MAPFILE, "// primitive %d\n",PrimitiveCount++);
		fprintf (MAPFILE, "{\nbrushDef3\n{\n");
		//East face
		fprintf (MAPFILE, "( 1 0 0 %d )",-((x+t.DimX)*BrushSizeX));
		getWallTextureName(t,fEAST,t.isWater );
		//North face
		fprintf (MAPFILE, "( 0 1 0 %d )",-((y+t.DimY)*BrushSizeY));
		getWallTextureName(t,fNORTH,t.isWater );
		//Top face
		fprintf (MAPFILE, "( 0 %f %f %f )", cos(angle), sin(angle),-normalDist);	
		getFloorTextureName(t,fTOP );
		//West face
		fprintf (MAPFILE, "( -1 0 0 %d )", +((x)*BrushSizeX));
		getWallTextureName(t,fWEST,t.isWater );
		//South face
		fprintf (MAPFILE, "( 0 -1 0 %d )", +((y)*BrushSizeY));
		getWallTextureName(t,fSOUTH,t.isWater );
		//Bottom face +absdist
		fprintf (MAPFILE, "( 0 0 -1 %d )", -2*BrushSizeZ);	//+10 to go underneath
		getWallTextureName(t,fBOTTOM,t.isWater );

		//Other sloped face
		BrushZ = (float)BrushSizeZ*steepness ; BrushX = (float)BrushSizeX;
		angle = atan((float)(BrushX/(BrushZ)));
		normalDist = (cos(atan((BrushZ)/(BrushX)))) * ((floorHeight/steepness) -(x)) * BrushZ  ;	
		fprintf (MAPFILE, "( -%f 0 %f %f )", cos(angle),sin(angle),-normalDist);	
		getFloorTextureName(t,fTOP);		
		
		fprintf (MAPFILE, "}\n}\n");
		}
	}
	else
		{//invert is n w
				//render a ceiling version of this tile
				//top and bottom faces move up
				fprintf (MAPFILE, "// primitive %d\n",PrimitiveCount++);
				fprintf (MAPFILE, "{\nbrushDef3\n{\n");
				//East face
				fprintf (MAPFILE, "( 1 0 0 %d )",-((x+t.DimX)*BrushSizeX));
				getWallTextureName(t,fEAST,t.isWater);
				//North face
				fprintf (MAPFILE, "( 0 1 0 %d ) ",-((y+t.DimY)*BrushSizeY));
				getWallTextureName(t,fNORTH,t.isWater);
				//Top face
				fprintf (MAPFILE, "( 0 0 1 %d )", -( (CEILING_HEIGHT) * BrushSizeZ));	
				getFloorTextureName(t,fTOP);
				//West face
				fprintf (MAPFILE, "( -1 0 0 %d )", +((x)*BrushSizeX));
				getWallTextureName(t,fWEST,t.isWater);
				//South face
				fprintf (MAPFILE, "( 0 -1 0 %d )", +((y)*BrushSizeY));
				getWallTextureName(t,fSOUTH,t.isWater);
				//Bottom face
				//w
				float ceilingHeight =  t.ceilingHeight ;
				BrushZ = (float)BrushSizeZ*steepness ; BrushX = (float)BrushSizeX;
				angle = atan((float)(BrushX/(BrushZ)));
				normalDist = (cos(atan((BrushZ)/(BrushX)))) * ((-x) - ((CEILING_HEIGHT-ceilingHeight)/steepness)) * BrushZ  ;
				fprintf (MAPFILE, "( %f 0 %f %f )", -cos(angle),-sin(angle),-normalDist);
				getFloorTextureName(t,fCEIL);	
				
				//n			
				ceilingHeight = (CEILING_HEIGHT -(t.ceilingHeight)) ;
				BrushZ = (float)BrushSizeZ*steepness; BrushY = (float)BrushSizeY;
				angle = atan((float)(BrushY/BrushZ));
				normalDist = (cos(atan(BrushZ/BrushY))) * ((ceilingHeight/steepness)-y-1) * BrushZ;
                fprintf (MAPFILE, "( 0 %f %f %f )", cos(angle), -sin(angle),+normalDist);
                getFloorTextureName(t,fCEIL);	
				fprintf (MAPFILE, "}\n}\n");		
		}
	}
return;
}


void RenderDoorway(int game,int x,int y, tile &t , ObjectItem currDoor)
{
//TODO:Define door widths in config file. 
int doorWidth=48;
int doorHeight =96;
int resolution;
float BrushX=BrushSizeX;
float BrushY=BrushSizeY;
float BrushZ = BrushSizeZ;

switch (game)
	{
	case SHOCK:	
		resolution =255;
		break;
	default:
		resolution =7;
		break;
	}
	
float offX= (x*BrushX) + ((currDoor.x) * (BrushX/resolution));//from obj position code
float offY= (y*BrushY) + ((currDoor.y) * (BrushY/resolution));
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
			{offY =(y*BrushY)+((BrushY-doorWidth)/2)+doorWidth;}
		else
			{offY = (y*BrushY)+((BrushY-doorWidth)/2);}			
			//left side
			fprintf (MAPFILE, "// primitive %d\n",PrimitiveCount++);
			fprintf (MAPFILE, "{\nbrushDef3\n{\n");
			//east face 
			fprintf (MAPFILE, "( 1 0 0 %f )",-((offX+2)));
			getWallTextureName(t,fEAST,0);
			//north face 
			fprintf (MAPFILE, "( 0 1 0 %f )",-((y+1)*BrushY));
			getWallTextureName(t,fNORTH,0);
			//top face
			fprintf (MAPFILE, "( 0 0 1 %f )", -(t.floorHeight*BrushZ + doorHeight) );	
			getFloorTextureName(t,fTOP);
			//west face
			fprintf (MAPFILE, "( -1 0 0 %f )", +((offX-2)));
			getWallTextureName(t,fWEST,0);
			//south face
			if ((heading == EAST) || (heading == SHOCK_EAST))
				{fprintf (MAPFILE, "( 0 -1 0 %f )", +(offY));}
			else
				fprintf (MAPFILE, "( 0 -1 0 %f )", +(offY)+doorWidth);
			
			getWallTextureName(t, fSOUTH,0);
			//bottom face
			fprintf (MAPFILE, "( 0 0 -1 %f )", t.floorHeight*BrushZ);	
			getFloorTextureName(t, fBOTTOM);
			//fprintf (MAPFILE, "0"); 
			fprintf (MAPFILE, "}\n}\n");		
		
		//over the door
			fprintf (MAPFILE, "// primitive %d\n",PrimitiveCount++);
			fprintf (MAPFILE, "{\nbrushDef3\n{\n");
			//east face 
			fprintf (MAPFILE, "( 1 0 0 %f )",-((offX+2)));
			getWallTextureName(t,fEAST,0);
			//north face 
			fprintf (MAPFILE, "( 0 1 0 %f )",-((y+1)*BrushY));
			getWallTextureName(t,fNORTH,0);
			//top face
			fprintf (MAPFILE, "( 0 0 1 %f )", -BrushZ * (CEILING_HEIGHT+1) );	
			getFloorTextureName(t,fTOP);
			//west face
			fprintf (MAPFILE, "( -1 0 0 %f )", +((offX-2)));
			getWallTextureName(t,fWEST,0);
			//south face
			fprintf (MAPFILE, "( 0 -1 0 %f )", +(y*BrushY));
			getWallTextureName(t, fSOUTH,0);
			//bottom face
			fprintf (MAPFILE, "( 0 0 -1 %f )", (t.floorHeight*BrushZ)+doorHeight);	
			getFloorTextureName(t, fBOTTOM);
			//fprintf (MAPFILE, "0"); 
			fprintf (MAPFILE, "}\n}\n");			
	
		// right side
			fprintf (MAPFILE, "// primitive %d\n",PrimitiveCount++);
			fprintf (MAPFILE, "{\nbrushDef3\n{\n");
			//east face 
			fprintf (MAPFILE, "( 1 0 0 %f )",-((offX+2)));
			getWallTextureName(t,fEAST,0);
			//north face 
			if ((heading == EAST) || (heading == SHOCK_EAST))
				{
				fprintf (MAPFILE, "( 0 1 0 %f )",-(offY-doorWidth));	
				}
			else
				{
				fprintf (MAPFILE, "( 0 1 0 %f )",-(offY));
				}			
			getWallTextureName(t,fNORTH,0);
			//top face
			fprintf (MAPFILE, "( 0 0 1 %f )", -(t.floorHeight*BrushZ + doorHeight) );
			getFloorTextureName(t,fTOP);
			//west face
			fprintf (MAPFILE, "( -1 0 0 %f )", +((offX-2)));
			getWallTextureName(t,fWEST,0);
			//south face
			fprintf (MAPFILE, "( 0 -1 0 %f )", +(y * BrushY));
			getWallTextureName(t, fSOUTH,0);
			//bottom face
			fprintf (MAPFILE, "( 0 0 -1 %f )", t.floorHeight*BrushZ);	
			getFloorTextureName(t, fBOTTOM);
			//fprintf (MAPFILE, "0"); 
			fprintf (MAPFILE, "}\n}\n");			
	if (t.TerrainChange==0)
		{
		tile Tmpt;	//tmp tile for rendering a visportal.
		Tmpt.tileType =0;
		Tmpt.isWater =0;
		Tmpt.wallTexture =NODRAW;
		Tmpt.North=NODRAW;
		Tmpt.South=NODRAW;
		Tmpt.East=VISPORTAL;
		Tmpt.West=NODRAW;
		Tmpt.Top=NODRAW;
		Tmpt.Bottom=NODRAW;
		//Visportal
			fprintf (MAPFILE, "// primitive %d\n",PrimitiveCount++);
			fprintf (MAPFILE, "{\nbrushDef3\n{\n");
			//east face 
			fprintf (MAPFILE, "( 1 0 0 %f )",-((offX+2)));
			getWallTextureName(Tmpt,fEAST,0);
			//north face 
			if ((heading == EAST) || (heading == SHOCK_EAST))
				{
				fprintf (MAPFILE, "( 0 1 0 %f )",-((offY)));
				}
			else
				{
				fprintf (MAPFILE, "( 0 1 0 %f )",-((offY+doorWidth)));
				}
			getWallTextureName(Tmpt,fNORTH,0);
			//top face
			fprintf (MAPFILE, "( 0 0 1 %f )", -((t.floorHeight*BrushZ)+doorHeight) );	
			getWallTextureName(Tmpt,fTOP,0);
			//west face
			fprintf (MAPFILE, "( -1 0 0 %f )", +((offX-1)));
			getWallTextureName(Tmpt,fWEST,0);
			//south face
			if ((heading == EAST) || (heading == SHOCK_EAST))
				{
				fprintf (MAPFILE, "( 0 -1 0 %f )", +(offY-doorWidth));
				}
			else
				{
				fprintf (MAPFILE, "( 0 -1 0 %f )", +(offY));
				}
			getWallTextureName(Tmpt, fSOUTH,0);
			//bottom face
			fprintf (MAPFILE, "( 0 0 -1 %f )", (t.floorHeight*BrushZ));	
			getWallTextureName(Tmpt, fBOTTOM,0);
			//fprintf (MAPFILE, "0"); 
			fprintf (MAPFILE, "}\n}\n");			
		}
			break;
			
		}
	case NORTH:	//north south (0)
	case SOUTH:
	case SHOCK_NORTH:
	//case SHOCK_SOUTH:
		{
		
		if ((heading == NORTH) || (heading == SHOCK_NORTH))
			{offX = (x*BrushSizeX)+((BrushSizeX-doorWidth)/2)+doorWidth;}
		else
			{offX = (x*BrushSizeX)+((BrushSizeX-doorWidth)/2);}
		//left side
			fprintf (MAPFILE, "// primitive %d\n",PrimitiveCount++);
			fprintf (MAPFILE, "{\nbrushDef3\n{\n");
			//east face 
			if ((heading == NORTH) || (heading == SHOCK_NORTH))
				{
				fprintf (MAPFILE, "( 1 0 0 %f )",-(offX-doorWidth));
								
				}
			else
				{
				fprintf (MAPFILE, "( 1 0 0 %f )",-(offX));		
				}
			
			getWallTextureName(t,fEAST,0);
			//north face 
			fprintf (MAPFILE, "( 0 1 0 %f )",-(offY+2));
			getWallTextureName(t,fNORTH,0);
			//top face
			fprintf (MAPFILE, "( 0 0 1 %f )", -(t.floorHeight*BrushZ + doorHeight) );	
			getFloorTextureName(t,fTOP);
			//west face
			fprintf (MAPFILE, "( -1 0 0 %f )", +((x)*BrushX));
			getWallTextureName(t,fWEST,0);
			//south face
			fprintf (MAPFILE, "( 0 -1 0 %f )", +(offY-2));
			getWallTextureName(t, fSOUTH,0);
			//bottom face
			fprintf (MAPFILE, "( 0 0 -1 %f )", t.floorHeight * BrushZ);	//to go underneath
			getFloorTextureName(t, fBOTTOM);
			//fprintf (MAPFILE, "0"); 
			fprintf (MAPFILE, "}\n}\n");
		//top
			fprintf (MAPFILE, "// primitive %d\n",PrimitiveCount++);
			fprintf (MAPFILE, "{\nbrushDef3\n{\n");
			//east face 
			fprintf (MAPFILE, "( 1 0 0 %f )",-((x+1)*BrushX));
			getWallTextureName(t,fEAST,0);
			//north face 
			fprintf (MAPFILE, "( 0 1 0 %f )",-(offY+2));
			getWallTextureName(t,fNORTH,0);
			//top face
			fprintf (MAPFILE, "( 0 0 1 %f )", -BrushZ * (CEILING_HEIGHT+1) );	
			getFloorTextureName(t,fTOP);
			//west face
			fprintf (MAPFILE, "( -1 0 0 %f )", +(x*BrushX));
			getWallTextureName(t,fWEST,0);
			//south face
			fprintf (MAPFILE, "( 0 -1 0 %f )", +(offY-2));
			getWallTextureName(t, fSOUTH,0);
			//bottom face
			fprintf (MAPFILE, "( 0 0 -1 %f )", (t.floorHeight*BrushZ) +doorHeight);	//to go underneath
			getFloorTextureName(t, fBOTTOM);
			//fprintf (MAPFILE, "0"); 
			fprintf (MAPFILE, "}\n}\n");
		//right
			fprintf (MAPFILE, "// primitive %d\n",PrimitiveCount++);
			fprintf (MAPFILE, "{\nbrushDef3\n{\n");
			//east face 
			fprintf (MAPFILE, "( 1 0 0 %f )",-((x+1)*BrushX));
			getWallTextureName(t,fEAST,0);
			//north face 
			fprintf (MAPFILE, "( 0 1 0 %f )",-(offY+2));
			getWallTextureName(t,fNORTH,0);
			//top face
			fprintf (MAPFILE, "( 0 0 1 %f )", -(t.floorHeight*BrushZ + doorHeight) );	
			getFloorTextureName(t,fTOP);
			//west face
			if ((heading == NORTH) || (heading == SHOCK_NORTH))
				{
				fprintf (MAPFILE, "( -1 0 0 %f )", +(offX ));
				}
			else
				{
				fprintf (MAPFILE, "( -1 0 0 %f )", +(offX +doorWidth ));
				}
			getWallTextureName(t,fWEST,0);
			//south face
			fprintf (MAPFILE, "( 0 -1 0 %f )", +(offY-2));
			getWallTextureName(t, fSOUTH,0);
			//bottom face
			fprintf (MAPFILE, "( 0 0 -1 %f )", t.floorHeight * BrushZ);	//to go underneath
			getFloorTextureName(t, fBOTTOM);
			//fprintf (MAPFILE, "0"); 
			fprintf (MAPFILE, "}\n}\n");
		if (t.TerrainChange==0)
			{		
		//visportal.
		tile Tmpt;	//tmp tile for rendering a visportal.
		Tmpt.tileType =0;
		Tmpt.isWater =0;
		Tmpt.wallTexture =NODRAW;
		Tmpt.North=NODRAW;
		Tmpt.South=VISPORTAL;
		Tmpt.East=NODRAW;
		Tmpt.West=NODRAW;
		Tmpt.Top=NODRAW;
		Tmpt.Bottom=NODRAW;
			fprintf (MAPFILE, "// primitive %d\n",PrimitiveCount++);
			fprintf (MAPFILE, "{\nbrushDef3\n{\n");
			//east face 
			if ((heading == NORTH) || (heading == SHOCK_NORTH))
				{
				fprintf (MAPFILE, "( 1 0 0 %f )",-(offX));	
				}
			else
				{
				fprintf (MAPFILE, "( 1 0 0 %f )",-(offX +doorWidth));	
				}
			getWallTextureName(Tmpt,fEAST,0);
			//north face 
			fprintf (MAPFILE, "( 0 1 0 %f )",-(offY+2));
			getWallTextureName(Tmpt,fNORTH,0);
			//top face
			fprintf (MAPFILE, "( 0 0 1 %f )", -(t.floorHeight*BrushZ + doorHeight));	
			getFloorTextureName(Tmpt,fTOP);
			//west face
			if ((heading == NORTH) || (heading == SHOCK_NORTH))
				{
				fprintf (MAPFILE, "( -1 0 0 %f )", +(offX-doorWidth));
				}
			else
				{
				fprintf (MAPFILE, "( -1 0 0 %f )", +(offX));
				}
			getWallTextureName(Tmpt,fWEST,0);
			//south face
			fprintf (MAPFILE, "( 0 -1 0 %f )", +(offY-2));
			getWallTextureName(Tmpt, fSOUTH,0);
			//bottom face
			fprintf (MAPFILE, "( 0 0 -1 %f )", (t.floorHeight*BrushZ));	//to go underneath
			getFloorTextureName(Tmpt, fBOTTOM);
			//fprintf (MAPFILE, "0"); 
			fprintf (MAPFILE, "}\n}\n");
			}			
		}
	}
}
void RenderPatch(int game, int x, int y, int z,long PatchIndex, ObjectItem objList[1600] )
{
//
//Flat decal object, think the Abyss doors.
ObjectItem currobj = objList[PatchIndex];

float patchX;float patchY;float patchZ;float patchOffsetX;float patchOffsetY;
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
float offX;float offY; float offZ;
CalcObjectXYZ(game,&offX,&offY,&offZ,LevelInfo,objList,PatchIndex,x,y);

float tex1 = -1; float tex2 =-1;	//target values
	switch (currobj.heading)
		{//Headings are horribly broken.
		default:
		case SOUTH:	//Southfacing
			{patchX=-BrushSizeX;patchY=0;patchZ=11*BrushSizeZ;patchOffsetX=0; patchOffsetY=-0.1;
			offX=offX+(BrushSizeX/2);
			break;}
		case NORTH://Northfacing
			{patchX=BrushSizeX;patchY=0;patchZ=11*BrushSizeZ;patchOffsetX=0;patchOffsetY=+0.1;
			offX=offX-(BrushSizeX/2);
			break;}
		case EAST://east facing 
			{patchX=0;patchY=-BrushSizeY;patchZ=11*BrushSizeZ;patchOffsetX=+0.1;patchOffsetY=0;
			offY=offY+(BrushSizeY/2);
			break;}
		case WEST:
			{patchX=0;patchY=+BrushSizeY;patchZ=11*BrushSizeZ;patchOffsetX=-0.1;patchOffsetY=0;
			offY=offY-(BrushSizeY/2);
			break;}
		}
	//fprintf (MAPFILE, "\"name\" \"%s_%03d_%03d\"",objectMasters[currobj.item_id].desc,currobj.tileX,currobj.tileY );
	//fprintf (MAPFILE, "\"model\" \"%s_%03d_%03d\"",objectMasters[currobj.item_id].desc,currobj.tileX,currobj.tileY );
	//Things like the abyss doors,stairs down//a patch?
	fprintf (MAPFILE, "\n//primitive %d\n{\npatchDef2\n{\n",0);
	fprintf (MAPFILE, "\"%s\"\n",textureMasters[currobj.owner].path);
	fprintf (MAPFILE, "( 3 5 0 0 0 )\n(\n");	//not sure what they mean but they appear to stay constant?
	for (int j= 0; j <3; j++)
		{
		fprintf (MAPFILE, "(");
		for (int i=0; i<=4;i++)
			{
			//x y z texture param1 textureparam 2
			fprintf (MAPFILE, " ( %f %f %f %f %f )" ,offX+patchOffsetX + i*(patchX/4), offY+patchOffsetY + i*(patchY/4), offZ+j*(patchZ/3),i*(tex1/4),j*(tex2/2));
			}
			fprintf (MAPFILE, " )\n");
		}
	fprintf (MAPFILE, ")\n}\n}\n");
				}
				
void RenderElevatorLeakProtection(int game, tile LevelInfo[64][64])
	{
	//Just makes sure the elevator entity does not cause a map leak.
	for (int y=0; y<=63;y++) 
		{
		for (int x=0; x<=63;x++)
			{
			if (LevelInfo[x][y].hasElevator >= 1)
				{
				//Below the map
				tile t=LevelInfo[x][y];
				fprintf (MAPFILE, "\n");
				fprintf (MAPFILE, "// primitive %d\n",PrimitiveCount++);
				fprintf (MAPFILE, "{\nbrushDef3\n{\n");
				//east face 
				fprintf (MAPFILE, "( 1 0 0 %d )",-((x+t.DimX)*BrushSizeX)-10);
				getWallTextureName(t,fEAST,0);
				//north face 
				fprintf (MAPFILE, "( 0 1 0 %d )",-((y+t.DimY)*BrushSizeY)-10);
				getWallTextureName(t,fNORTH,0);
				//top face
				fprintf (MAPFILE, "( 0 0 1 %d )", +1 );	
				getFloorTextureName(t,fTOP);
				//west face
				fprintf (MAPFILE, "( -1 0 0 %d )", +((x)*BrushSizeX)-10);
				getWallTextureName(t,fWEST,0);
				//south face
				fprintf (MAPFILE, "( 0 -1 0 %d )", +((y)*BrushSizeY)-10);
				getWallTextureName(t, fSOUTH,0);
				//bottom face
				fprintf (MAPFILE, "( 0 0 -1 %d )", -32*BrushSizeZ);	
				getFloorTextureName(t, fBOTTOM);
				//fprintf (MAPFILE, "0"); 
				fprintf (MAPFILE, "}\n}\n");
				
				//Above the map for shock
				if (game== SHOCK)
					{
					fprintf (MAPFILE, "\n");
					fprintf (MAPFILE, "// primitive %d\n",PrimitiveCount++);
					fprintf (MAPFILE, "{\nbrushDef3\n{\n");
					//east face 
					fprintf (MAPFILE, "( 1 0 0 %d )",-((x+t.DimX)*BrushSizeX)-10);
					getWallTextureName(t,fEAST,0);
					//north face 
					fprintf (MAPFILE, "( 0 1 0 %d )",-((y+t.DimY)*BrushSizeY)-10);
					getWallTextureName(t,fNORTH,0);
					//top face
					fprintf (MAPFILE, "( 0 0 1 %d )", -CEILING_HEIGHT*2*BrushSizeZ );	//ugly.
					getFloorTextureName(t,fTOP);
					//west face
					fprintf (MAPFILE, "( -1 0 0 %d )", +((x)*BrushSizeX)-10);
					getWallTextureName(t,fWEST,0);
					//south face
					fprintf (MAPFILE, "( 0 -1 0 %d )", +((y)*BrushSizeY)-10);
					getWallTextureName(t, fSOUTH,0);
					//bottom face
					fprintf (MAPFILE, "( 0 0 -1 %d )", CEILING_HEIGHT*BrushSizeZ);	
					getFloorTextureName(t, fBOTTOM);
					//fprintf (MAPFILE, "0"); 
					fprintf (MAPFILE, "}\n}\n");				
					}
				}
			}
		}
	}

void RenderGenericTile(int x, int y, tile &t, int iCeiling ,int iFloor)
{
//
//Just for special temporary tiles
	fprintf (MAPFILE, "// primitive %d\n",PrimitiveCount++);
	fprintf (MAPFILE, "{\nbrushDef3\n{\n");
	//East face
	fprintf (MAPFILE, "( 1 0 0 %d )",-((x+t.DimX)*BrushSizeX));
	getWallTextureName(t,fEAST,t.isWater);
	//North face
	fprintf (MAPFILE, "( 0 1 0 %d ) ",-((y+t.DimY)*BrushSizeY));
	getWallTextureName(t,fNORTH,t.isWater);
	//Top face
	fprintf (MAPFILE, "( 0 0 1 %d )", -( (iCeiling) * BrushSizeZ) );	
	getFloorTextureName(t,fTOP);
	//West face
	fprintf (MAPFILE, "( -1 0 0 %d )", +((x)*BrushSizeX));
	getWallTextureName(t,fWEST,t.isWater);
	//South face
	fprintf (MAPFILE, "( 0 -1 0 %d )", +((y)*BrushSizeY));
	getWallTextureName(t,fSOUTH,t.isWater);
	//Bottom face 
	fprintf (MAPFILE, "( 0 0 -1 %d ) ", iFloor*BrushSizeZ);	
	getFloorTextureName(t,fBOTTOM);
	fprintf (MAPFILE, "}\n}\n");
}


void RenderGenericTileAroundOrigin(int x, int y, tile &t, int iCeiling ,int iFloor,int tileHeight)
{
//
//Just for special temporary tiles

int xPlane; int yPlane;int zPlane;
xPlane = BrushSizeX/2;
yPlane = BrushSizeY/2;
zPlane = tileHeight/2;

	fprintf (MAPFILE, "// primitive %d\n",PrimitiveCount++);
	fprintf (MAPFILE, "{\nbrushDef3\n{\n");
	//East face
	fprintf (MAPFILE, "( 1 0 0 %d )",-xPlane);
	getWallTextureName(t,fEAST,t.isWater);
	//North face
	fprintf (MAPFILE, "( 0 1 0 %d ) ",-yPlane);
	getWallTextureName(t,fNORTH,t.isWater);
	//Top face
	fprintf (MAPFILE, "( 0 0 1 %d )", - zPlane );	
	getFloorTextureName(t,fTOP);
	//West face
	fprintf (MAPFILE, "( -1 0 0 %d )", -(xPlane));
	getWallTextureName(t,fWEST,t.isWater);
	//South face
	fprintf (MAPFILE, "( 0 -1 0 %d )", -(yPlane));
	getWallTextureName(t,fSOUTH,t.isWater);
	//Bottom face 
	fprintf (MAPFILE, "( 0 0 -1 %d ) ", -zPlane);	
	getFloorTextureName(t,fBOTTOM);
	fprintf (MAPFILE, "}\n}\n");
}

void RenderLevelExits(int game, tile LevelInfo[64][64], ObjectItem objList[1600])
	{
	int i;
	//go through the objects and find teleport traps with a zpos !=0
	for (i=0; i<1024;i++)
		{
		if ((isTrigger(objList[i])) && (objectMasters[objList[objList[i].link].item_id ].type == A_TELEPORT_TRAP))
			if ((objList[objList[i].link].zpos !=0))	//Trap goes to another level
				{
				//first a trigger to reference in scripting.
				fprintf (MAPFILE, "// entity %d\n", EntityCount++);
				fprintf (MAPFILE, "{\n\"classname\" \"trigger_relay\"\n");
				fprintf (MAPFILE, "\"name\" \"%s_%03d_%03d\"\n","trigger_endlevel" ,objList[i].tileX,objList[i].tileY);		
				fprintf (MAPFILE, "\n\"origin\" \"2500 2500 120\"\n");
				fprintf (MAPFILE, "\"target\" \"%s_%03d_%03d\"\n","endlevel" ,objList[i].tileX,objList[i].tileY);		
				fprintf (MAPFILE, "}\n");	
				
				fprintf (MAPFILE, "// entity %d\n", EntityCount++);
				fprintf (MAPFILE, "{\n\"classname\" \"target_endlevel\"\n");
				fprintf (MAPFILE, "\"name\" \"%s_%03d_%03d\"\n","endlevel" ,objList[i].tileX,objList[i].tileY);		
				fprintf (MAPFILE, "\n\"origin\" \"2500 2500 120\"\n");
				switch (game)
					{
					case UWDEMO:
						fprintf (MAPFILE, "\n\"nextmap\" \"%s\"\n", "NO_SUCH_LEVEL");break;	
					case UW1:
						fprintf (MAPFILE, "\n\"nextmap\" \"%s_%d\"\n","uw1", objList[objList[i].link].zpos-1);	break;
					case UW2:
						fprintf (MAPFILE, "\n\"nextmap\" \"%s_%d\"\n","uw2",objList[objList[i].link].zpos-1);	break;
					case SHOCK:
						fprintf (MAPFILE, "\n\"nextmap\" \"%s_%d\"\n","shock", objList[objList[i].link].zpos-1);	break;
					}
				fprintf (MAPFILE, "}\n");				
				}
		
		}
		
		//Now create matching entrance teleports. For this I'm using a file I generated from an ascii dump
		FILE *f = NULL;
		char line[255];
		const char *filePathE = ENTRANCES_CONFIG_FILE;
		f=fopen(filePathE,"r");
		if (f!=NULL)
			{
			fgets(line,254,f);//skip the first line
			while (fgets(line,255,f))
				{
				int level=0;
				int tileX=0;
				int tileY=0;
			
				sscanf(line, "%d %d %d",&level,&tileX,&tileY);
				if (level==levelNo)
					{	//on this level
						fprintf (MAPFILE, "// entity %d\n", EntityCount++);
						fprintf (MAPFILE, "{\n\"classname\" \"func_teleporter\"\n");
						fprintf (MAPFILE, "\"name\" \"%s_%03d_%03d\"\n","entrance" ,tileX,tileY);		
						fprintf (MAPFILE, "\n\"origin\" \"%d %d %d\"\n", tileX * BrushSizeX+(BrushSizeX/2),tileY*BrushSizeY+(BrushSizeY/2),(LevelInfo[tileX][tileY].floorHeight)* BrushSizeZ + 30);		
						fprintf (MAPFILE, "}\n");	
					}
				}
				fclose(f);
			}
	}

void RenderEntityElevator(int game, tile LevelInfo[64][64], ObjectItem &currobj)
{
//	1 = floor only	(uw style)
//	2 = ceiling only 
//  3 = both	
		
		//floor
 		fprintf (MAPFILE, "\n// entity %d\n{\n",EntityCount);
		fprintf (MAPFILE, "\"classname\" \"func_mover\"\n");
		fprintf (MAPFILE, "\"name\" \"floor_%03d_%03d\"\n" ,currobj.tileX,currobj.tileY);
		fprintf (MAPFILE, "\"model\" \"floor_%03d_%03d\"\n" ,currobj.tileX,currobj.tileY);
		PrimitiveCount=0;
		RenderDarkModTile(game,currobj.tileX,currobj.tileY,LevelInfo[currobj.tileX][currobj.tileY],0,0,0,1);
		fprintf (MAPFILE, "\n}");
		
		//ceiling
		EntityCount++;
		fprintf (MAPFILE, "\n// entity %d\n{\n",EntityCount);
		fprintf (MAPFILE, "\"classname\" \"func_mover\"\n");
		fprintf (MAPFILE, "\"name\" \"ceiling_%03d_%03d\"\n",currobj.tileX,currobj.tileY);
		fprintf (MAPFILE, "\"model\" \"ceiling_%03d_%03d\"\n",currobj.tileX,currobj.tileY);
		PrimitiveCount=0;
		RenderDarkModTile(game,currobj.tileX,currobj.tileY,LevelInfo[currobj.tileX][currobj.tileY],0,1,1,0);
		fprintf (MAPFILE, "\n}");
		EntityCount++;

}

float calcAlignmentFactor(float adjacent, float opposite)
{

return  sqrt((adjacent*adjacent+opposite*opposite))/adjacent;

}


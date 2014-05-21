#include <stdio.h>
#include <stdlib.h>
#include <fstream>
#include "math.h"

#include "tilemap.h"
#include "main.h"
#include "textures.h"
#include "gameobjects.h"
#include "gameobjectsrender.h"
#include "D3DarkMod.h"

int BrushSizeX;
int BrushSizeY;
int BrushSizeZ;
int PrimitiveCount;
int EntityCount;
int CEILING_HEIGHT;
tile LevelInfo[64][64];
int iGame;
//void RenderEntity(int game,float x, float y, float z, ObjectItem &currobj, ObjectItem objList[1600], tile LevelInfo[64][64]);
void CalcObjectXYZ(int game, float *offX,  float *offY, float *offZ, tile LevelInfo[64][64], ObjectItem objList[1600], long nextObj,int x,int y);
float calcAlignmentFactor(float adjacent, float opposite);
void AddEmails(int game, tile LevelInfo[64][64], ObjectItem objList[1600]);
void RenderShockDoorway(int game, int x, int y, tile &t, ObjectItem currDoor, tile LevelInfo[64][64], ObjectItem objList[1600]);
float getSteepOffset(int steepness);

int levelNo;
long SHOCK_CEILING_HEIGHT;
long UW_CEILING_HEIGHT;

extern FILE *MAPFILE;

void RenderDarkModLevel(tile LevelInfo[64][64],ObjectItem objList[1600],int game)
{

//Main processing loop for generating the level.

	int x;
	int y;

iGame =game;

//Levels use different ceiling heights.
//Shock is variable, UW is fixed.
switch (game)
	{
		case SHOCK:
		{
		CEILING_HEIGHT = SHOCK_CEILING_HEIGHT;
		break;
		}
		default:
		{
			CEILING_HEIGHT = UW_CEILING_HEIGHT;
			break;
		}

	}

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
				if (LevelInfo[x][y].shockDoor  == 1)
					{//Adds a Shock door frame.
						RenderShockDoorway(game, x, y, LevelInfo[x][y], objList[LevelInfo[x][y].DoorIndex],LevelInfo,objList);
					} 
				if ((LevelInfo[x][y].isWater == 1) && ((LevelInfo[x][y].tileType == TILE_OPEN) || (LevelInfo[x][y].tileType >= TILE_SLOPE_N)))
					{
						//render the ceilings of water tiles
					LevelInfo[x][y].isWater=0;
					RenderDarkModTile(game, x, y, LevelInfo[x][y], 0, 0, 1, 0);
					LevelInfo[x][y].isWater = 1;
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
				RenderLevelExits (game,LevelInfo,objList);
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
						
						RenderDarkModTile(game,x,y,t,1,0,0,1);
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
	
void getWallTextureName(tile t, int face, short waterWall)
{
//Spits out the wall textures.
//Water is a special case here and in SHOCK the texture needs to be offset
int wallTexture;
int textureOffset=1;
int ceilOffset=0;
float scaleFactor = 1;
float shiftFactorH= 0;
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
		case COLLISION:
			{fprintf(MAPFILE, "( ( 0 0.03125 0 ) ( -0.03125 0 0 ) ) \"textures/common/collision\" 0 0 0\n"); break; }
		default:
			{
			if ((t.tileType >= 2) && (t.tileType <= 5) && (face==fSELF))
				   {//The angled portion of a diagonal tile
				   scaleFactor = calcAlignmentFactor(BrushSizeX,BrushSizeY);
				   switch (t.tileType)
					   {
						case 2: 
							if ((t.tileX - t.tileY) % 2 == 0)
							{
								shiftFactorH = 0;
							}
							else
							{
								shiftFactorH = 0.5;
							}
							break;
						case 3: 
							if ((t.tileX - t.tileY) % 2 == 0)
							{
								shiftFactorH = 0.5;
							}
							else
							{
								shiftFactorH = 0;
							}
							break;
						case 4: 
							if ((t.tileX - t.tileY) % 2 == 0)
							{
								shiftFactorH = 0.5;
							}
							else
							{
								shiftFactorH = 0;
							}
							break;
						case 5: 
							if ((t.tileX - t.tileY) % 2 == 0)
							{
								shiftFactorH = 0;
							}
							else
							{
								shiftFactorH = 0.5;
							}
							break;
					   }
				   }
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
					textureMasters[wallTexture].align1_1 / scaleFactor, textureMasters[wallTexture].align1_2, shiftFactorH,
					textureMasters[wallTexture].align2_1, textureMasters[wallTexture].align2_2, textureVertAlign);
				}
			else
				{//Texture aligned with the ceiling
				fprintf (MAPFILE, "( ( %f %f %f ) ( %f %f %f ) ) \"",
				textureMasters[wallTexture].align1_1 / scaleFactor,textureMasters[wallTexture].align1_2,shiftFactorH,
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
		case COLLISION:
			{fprintf(MAPFILE, "( ( 0 0.03125 0 ) ( -0.03125 0 0 ) ) \"textures/common/caulk\" 0 0 0\n"); break; }
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


float floorAlign1;
float floorAlign2;
float floorAlign3;
float floorAlign4;
float floorAlign5;
float floorAlign6;

if (face == fCEIL)
{
	floorTexture = t.shockCeilingTexture;
}
else
{
	floorTexture = t.floorTexture;
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
		case COLLISION:
			{fprintf(MAPFILE, "( ( 0 0.03125 0 ) ( -0.03125 0 0 ) ) \"textures/common/collision\" 0 0 0\n"); break; }
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
				//default values first.
				floorAlign1 = textureMasters[floorTexture].floor_align1_1;
				floorAlign2 = textureMasters[floorTexture].floor_align1_2;
				floorAlign3 = textureMasters[floorTexture].floor_align1_3;
				floorAlign4 = textureMasters[floorTexture].floor_align2_1;
				floorAlign5 = textureMasters[floorTexture].floor_align2_2;
				floorAlign6 = textureMasters[floorTexture].floor_align2_3;


				CalcSlopedTextureAlignments(t, face, floorTexture, &floorAlign1, &floorAlign2, &floorAlign3, &floorAlign4, &floorAlign5, &floorAlign6);


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
				//fprintf (MAPFILE, "( ( %f %f %f ) ( %f %f %f ) ) \"",
				//		textureMasters[floorTexture].floor_align1_1,textureMasters[floorTexture].floor_align1_2,textureMasters[floorTexture].floor_align1_3,
				//		textureMasters[floorTexture].floor_align2_1, textureMasters[floorTexture].floor_align2_2, textureMasters[floorTexture].floor_align2_3);

				fprintf(MAPFILE, "( ( %f %f %f ) ( %f %f %f ) ) \"",
					floorAlign1, floorAlign2, floorAlign3,
					floorAlign4, floorAlign5, floorAlign6);
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
	//case UWDEMO:
	//case UW1:
	//case UW2:
	//case SHOCK:
	//	{//due to variable ceiling heights I have to render each tile's roof.
	//		for (int y=0; y<=63;y++) 
	//			{
	//			fprintf (MAPFILE, "\n");
	//			for (int x=0; x<=63;x++)
	//				{
	//					if ((LevelInfo[x][y].tileType == 1))
	//						//Only do a ceiling for open and diagonals. everything else gets it's ceiling on the first pass due to slope flags
	//						{
	//						//RenderDarkModTile(game,x,y,LevelInfo[x][y],0,1,0,0);
	//						}
	//				}
	//			}
	//	break;
	//	}	
	default:
		{//UW has a single height ceiling. Just need to put a roof on her and a riverbed for water features.
		//put a roof on her 
		//////fprintf (MAPFILE, "// primitive %d\n",PrimitiveCount++);
		//////fprintf (MAPFILE, "{\nbrushDef3\n{\n");
		////////001	east face -absdist
		//////fprintf (MAPFILE, "( 1 0 0 %d ) ( ( 0.03125 0 0 ) ( 0 0.03125 0 ) ) \"textures/common/caulk\" 0 0 0\n",-(64*BrushSizeX));
		////////010 north face -absdist
		//////fprintf (MAPFILE, "( 0 1 0 %d ) ( ( 0.03125 0 0 ) ( 0 0.03125 0 ) ) \"textures/common/caulk\" 0 0 0\n",-(64*BrushSizeY));
		////////100	top face -absdist
		//////fprintf (MAPFILE, "( 0 0 1 %d ) ( ( 0.03125 0 0 ) ( 0 0.03125 0 ) ) \"textures/common/caulk\" 0 0 0\n", -BrushSizeZ * (CEILING_HEIGHT+1));	
		////////00-1	west face +absdist
		//////fprintf (MAPFILE, "( -1 0 0 %d ) ( ( 0.03125 0 0 ) ( 0 0.03125 0 ) ) \"textures/common/caulk\" 0 0 0\n", +(0));
		////////0-1 0	south face +absdist
		//////fprintf (MAPFILE, "( 0 -1 0 %d ) ( ( 0.03125 0 0 ) ( 0 0.03125 0 ) ) \"textures/common/caulk\" 0 0 0\n", +(0));
		////////-100	bottom face +absdist
		//////fprintf (MAPFILE, "( 0 0 -1 %d ) ( ( 0.03125 0 0 ) ( 0 0.03125 0 ) ) \"textures/darkmod/stone/flat/slate_rough_dark01\" 0 0 0\n", (BrushSizeZ * (CEILING_HEIGHT)));	
		//////fprintf (MAPFILE, "}\n}\n");
		
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

float getSteepOffset(int steepness)
{
//These are the multiplication factors for each level of steepness in aligning their textures on the slope.
	//if (iGame == SHOCK)
	//{
		switch (steepness)
		{
		case 1:return 1.969 / 128.0;
		case 2:return 3.764 / 128.0;
		case 3:return 5.26 / 128.0;
		case 4:return 6.4 / 128.0;
		case 5:return 7.191 / 128.0;
		case 6:return 7.68 / 128.0;
		case 7:return 7.929 / 128.0;
		case 8:return 8.0 / 128.0;
		case 9:return 7.944 / 128.0;
		case 10:return 7.804 / 128.0;
		case 12:return 7.384 / 128.0;
		case 11:return 7.6108 / 128.0;
		case 14:return 6.892 / 128.0;
		default:return 0;
		}
	//}
	//else
	//{
	//	return 0.008490625; ///1.0868 / 128.0;	//Underworld offset
	//}
}

void CalcSlopedTextureAlignments(tile t, int face, int floorTexture, float *floorAlign1, float *floorAlign2, float *floorAlign3, float *floorAlign4, float *floorAlign5, float *floorAlign6)
{

	float BrushZ = (float)BrushSizeZ;
	float BrushX = (float)BrushSizeX;

	float scaleFactor = 1;	//For stretching floor textures.
	float shiftFactor = 1; //for aligning floor textures.

	scaleFactor = calcAlignmentFactor(BrushX, (float)t.shockSteep * BrushZ);
	switch (t.tileType)  //different tile orientations take different alignment values.
	{
	case TILE_OPEN:
		{
			//flip the fourth parameter since I'm an idiot who did'nt check his work
			//*floorAlign4= -*floorAlign4;
			break;
		}
	case TILE_SLOPE_N:
		{
		if (
			((face != fCEIL) && (t.shockSlopeFlag != SLOPE_CEILING_ONLY))
			)
		{
			*floorAlign1 = textureMasters[floorTexture].floor_align1_2;
			*floorAlign2 = textureMasters[floorTexture].floor_align1_3;
			*floorAlign3 = textureMasters[floorTexture].floor_align1_1;
			*floorAlign4 = textureMasters[floorTexture].floor_align2_3;
			*floorAlign5 = -textureMasters[floorTexture].floor_align2_1 / scaleFactor;  //scale factor
			float shiftPoint = t.floorHeight - (t.tileY * t.shockSteep); //get a position where that slope intercects the axis
			shiftFactor = getSteepOffset(t.shockSteep) * (float)shiftPoint;
			*floorAlign6 = 1 + shiftFactor;
		}
		else if ((face == fCEIL) && (t.shockSlopeFlag == SLOPE_BOTH_OPPOSITE))
		{//do t tile slope s alignment.
			*floorAlign1 = textureMasters[floorTexture].floor_align2_1;
			*floorAlign2 = textureMasters[floorTexture].floor_align2_2;
			*floorAlign3 = textureMasters[floorTexture].floor_align2_3;
			*floorAlign4 = textureMasters[floorTexture].floor_align1_1;
			*floorAlign5 = +textureMasters[floorTexture].floor_align1_2 / scaleFactor;  //scale factor
			//fixme float shiftPoint = (t.tileY + 1) * t.shockSteep + (CEILING_HEIGHT - t.ceilingHeight - t.shockSteep);
			float shiftPoint;
			if (t.ActualType != t.tileType)
				{//Tile is a valley tile that has had it's type changed temporarily for rendering. It's ceiling is adjusted for differently!
					shiftPoint = (t.tileY + 1) * t.shockSteep + (CEILING_HEIGHT - t.ceilingHeight);
				}
			else
				{
					shiftPoint = (t.tileY + 1) * t.shockSteep + (CEILING_HEIGHT - t.ceilingHeight - t.shockSteep);
				}
			
			shiftFactor = getSteepOffset(t.shockSteep) * (float)shiftPoint;
			*floorAlign6 = +shiftFactor;
		}
		else if ((face == fCEIL) && ((t.shockSlopeFlag == SLOPE_BOTH_PARALLEL) || (t.shockSlopeFlag == SLOPE_CEILING_ONLY)))
		{//a north slope from the ceiling.
			*floorAlign1 = textureMasters[floorTexture].floor_align1_2;
			*floorAlign2 = textureMasters[floorTexture].floor_align1_3;
			*floorAlign3 = textureMasters[floorTexture].floor_align1_1;
			*floorAlign4 = textureMasters[floorTexture].floor_align2_3;
			*floorAlign5 = -textureMasters[floorTexture].floor_align2_1 / scaleFactor;  //scale factor
			float shiftPoint = (CEILING_HEIGHT - t.ceilingHeight - t.shockSteep) - (t.tileY * t.shockSteep); //get a position where that slope intercects the axis
			shiftFactor = getSteepOffset(t.shockSteep) * (float)shiftPoint;
			*floorAlign6 = 1 + shiftFactor;
		}
		else
		{
			printf("x");
		}

		break;
	}
	case TILE_SLOPE_S:
		{
			if (
				((face != fCEIL) && (t.shockSlopeFlag != SLOPE_CEILING_ONLY))
				)
			{
				*floorAlign1 = textureMasters[floorTexture].floor_align2_1;
				*floorAlign2 = textureMasters[floorTexture].floor_align2_2;
				*floorAlign3 = textureMasters[floorTexture].floor_align2_3;
				*floorAlign4 = textureMasters[floorTexture].floor_align1_1;
				*floorAlign5 = +textureMasters[floorTexture].floor_align1_2 / scaleFactor;  //scale factor
				float shiftPoint = (t.tileY + 1) * t.shockSteep + t.floorHeight;
				shiftFactor = getSteepOffset(t.shockSteep) * (float)shiftPoint;
				*floorAlign6 = +shiftFactor;
			}
			else if ((face == fCEIL) && (t.shockSlopeFlag == SLOPE_BOTH_OPPOSITE))
			{//do t tile slope n alignment.#
				*floorAlign1 = textureMasters[floorTexture].floor_align1_2;
				*floorAlign2 = textureMasters[floorTexture].floor_align1_3;
				*floorAlign3 = textureMasters[floorTexture].floor_align1_1;
				*floorAlign4 = textureMasters[floorTexture].floor_align2_3;
				*floorAlign5 = +textureMasters[floorTexture].floor_align2_1 / scaleFactor;  //scale factor
				//float shiftPoint = (CEILING_HEIGHT - t.ceilingHeight - t.shockSteep) - (t.tileY * t.shockSteep); //get a position where that slope intercects the axis
				float shiftPoint;
				if (t.ActualType != t.tileType)
					{//Tile is a valley tile that has had it's type changed temporarily for rendering. It's ceiling is adjusted for differently!
						shiftPoint = (CEILING_HEIGHT - t.ceilingHeight ) - (t.tileY * t.shockSteep); //get a position where that slope intercects the axis
					}
				else
					{
						shiftPoint = (CEILING_HEIGHT - t.ceilingHeight - t.shockSteep) - (t.tileY * t.shockSteep); //get a position where that slope intercects the axis
					}
				shiftFactor = getSteepOffset(t.shockSteep) * (float)shiftPoint;
				*floorAlign6 = +shiftFactor;
			}
			else if ((face == fCEIL) && ((t.shockSlopeFlag == SLOPE_BOTH_PARALLEL) || (t.shockSlopeFlag == SLOPE_CEILING_ONLY)))
			{//The a south slope from the ceiling.
				*floorAlign1 = textureMasters[floorTexture].floor_align2_1;
				*floorAlign2 = textureMasters[floorTexture].floor_align2_2;
				*floorAlign3 = textureMasters[floorTexture].floor_align2_3;
				*floorAlign4 = textureMasters[floorTexture].floor_align1_1;
				*floorAlign5 = +textureMasters[floorTexture].floor_align1_2 / scaleFactor;  //scale factor
				float shiftPoint = (t.tileY + 1) * t.shockSteep + (CEILING_HEIGHT - t.ceilingHeight - t.shockSteep);
				shiftFactor = getSteepOffset(t.shockSteep) * (float)shiftPoint;
				*floorAlign6 = +shiftFactor;
			}
			else
			{
				printf("x");
			}
			break;
		}

	case TILE_SLOPE_E:
	{
		if (
			((face != fCEIL) && (t.shockSlopeFlag != SLOPE_CEILING_ONLY))
			)
		{
			*floorAlign1 = textureMasters[floorTexture].floor_align1_1;
			*floorAlign2 = textureMasters[floorTexture].floor_align2_1 / scaleFactor;   //vert scale
			float shiftPoint = -t.floorHeight + (t.tileX * t.shockSteep); //get a position where that slope intercects the axis
			shiftFactor = getSteepOffset(t.shockSteep) * (float)shiftPoint;
			*floorAlign3 = shiftFactor;// 	//horz Shift factor.textureMasters[floorTexture].floor_align1_3;
			*floorAlign4 = textureMasters[floorTexture].floor_align1_2;  //horz scale factor
			*floorAlign5 = textureMasters[floorTexture].floor_align2_2;
			*floorAlign6 = textureMasters[floorTexture].floor_align2_3;
		}
		else if ((face == fCEIL) && (t.shockSlopeFlag == SLOPE_BOTH_OPPOSITE))
		{//do t tile slope w alignment.#
			*floorAlign1 = textureMasters[floorTexture].floor_align1_1;
			*floorAlign2 = textureMasters[floorTexture].floor_align1_2 / scaleFactor;  //scale factor
			//float shiftPoint = (t.tileX + 1) * t.shockSteep + (CEILING_HEIGHT - t.ceilingHeight - t.shockSteep);
			float shiftPoint;
			if (t.ActualType != t.tileType)
			{
				shiftPoint = (t.tileX + 1) * t.shockSteep + (CEILING_HEIGHT - t.ceilingHeight );
			}
			else
			{
				shiftPoint = (t.tileX + 1) * t.shockSteep + (CEILING_HEIGHT - t.ceilingHeight - t.shockSteep);
			}
			shiftFactor = getSteepOffset(t.shockSteep) * (float)shiftPoint;
			*floorAlign3 = 1 + shiftFactor; // textureMasters[floorTexture].floor_align1_3; //Shift factor.
			*floorAlign4 = textureMasters[floorTexture].floor_align2_1;
			*floorAlign5 = textureMasters[floorTexture].floor_align2_2;
			*floorAlign6 = textureMasters[floorTexture].floor_align2_3;
		}
		else if ((face == fCEIL) && ((t.shockSlopeFlag == SLOPE_BOTH_PARALLEL) || (t.shockSlopeFlag == SLOPE_CEILING_ONLY)))
		{//The a east slope from the ceiling.
			*floorAlign1 = textureMasters[floorTexture].floor_align1_1;
			*floorAlign2 = textureMasters[floorTexture].floor_align2_1 / scaleFactor;   //vert scale
			float shiftPoint = -(CEILING_HEIGHT - t.ceilingHeight - t.shockSteep) + (t.tileX * t.shockSteep); //get a position where that slope intercects the axis
			shiftFactor = getSteepOffset(t.shockSteep) * (float)shiftPoint;
			*floorAlign3 = shiftFactor;// 	//horz Shift factor.textureMasters[floorTexture].floor_align1_3;
			*floorAlign4 = textureMasters[floorTexture].floor_align1_2;  //horz scale factor
			*floorAlign5 = textureMasters[floorTexture].floor_align2_2;
			*floorAlign6 = textureMasters[floorTexture].floor_align2_3;
		}
		else
		{
			printf("x");
		}

		break;
	}

	case TILE_SLOPE_W:
	{
		if (
			((face != fCEIL) && (t.shockSlopeFlag != SLOPE_CEILING_ONLY))
			)
		{
			*floorAlign1 = textureMasters[floorTexture].floor_align1_1;
			*floorAlign2 = textureMasters[floorTexture].floor_align1_2 / scaleFactor;  //scale factor
			float shiftPoint = (t.tileX + 1) * t.shockSteep + t.floorHeight;
			shiftFactor = getSteepOffset(t.shockSteep) * (float)shiftPoint;
			*floorAlign3 = 1 + shiftFactor; // textureMasters[floorTexture].floor_align1_3; //Shift factor.
			*floorAlign4 = textureMasters[floorTexture].floor_align2_1;
			*floorAlign5 = textureMasters[floorTexture].floor_align2_2;
			*floorAlign6 = textureMasters[floorTexture].floor_align2_3;
		}
		else if ((face == fCEIL) && (t.shockSlopeFlag == SLOPE_BOTH_OPPOSITE))
		{//do t tile slope e alignment.
			*floorAlign1 = textureMasters[floorTexture].floor_align1_1;
			*floorAlign2 = textureMasters[floorTexture].floor_align2_1 / scaleFactor;   //vert scale
			//float shiftPoint = -(CEILING_HEIGHT - t.ceilingHeight - t.shockSteep) + (t.tileX * t.shockSteep); //get a position where that slope intercects the axis
			float shiftPoint;
			if (t.ActualType != t.tileType)
				{
					shiftPoint = -(CEILING_HEIGHT - t.ceilingHeight ) + (t.tileX * t.shockSteep); //get a position where that slope intercects the axis
				}
			else
				{
					shiftPoint = -(CEILING_HEIGHT - t.ceilingHeight - t.shockSteep) + (t.tileX * t.shockSteep); //get a position where that slope intercects the axis
				}
			shiftFactor = getSteepOffset(t.shockSteep) * (float)shiftPoint;
			*floorAlign3 = shiftFactor;// 	//horz Shift factor.textureMasters[floorTexture].floor_align1_3;
			*floorAlign4 = textureMasters[floorTexture].floor_align1_2;  //horz scale factor
			*floorAlign5 = textureMasters[floorTexture].floor_align2_2;
			*floorAlign6 = textureMasters[floorTexture].floor_align2_3;
		}
		else if ((face == fCEIL) && ((t.shockSlopeFlag == SLOPE_BOTH_PARALLEL) || (t.shockSlopeFlag == SLOPE_CEILING_ONLY)))
		{// a west slope from the ceiling.
			*floorAlign1 = textureMasters[floorTexture].floor_align1_1;
			*floorAlign2 = textureMasters[floorTexture].floor_align1_2 / scaleFactor;  //scale factor
			float shiftPoint = (t.tileX + 1) * t.shockSteep + (CEILING_HEIGHT - t.ceilingHeight - t.shockSteep);
			shiftFactor = getSteepOffset(t.shockSteep) * (float)shiftPoint;
			*floorAlign3 = 1 + shiftFactor; // textureMasters[floorTexture].floor_align1_3; //Shift factor.
			*floorAlign4 = textureMasters[floorTexture].floor_align2_1;
			*floorAlign5 = textureMasters[floorTexture].floor_align2_2;
			*floorAlign6 = textureMasters[floorTexture].floor_align2_3;
		}
		else
		{
			printf("x");
		}

		break;
	}
	default:
		{
			   *floorAlign1 = textureMasters[floorTexture].floor_align1_1;
			   *floorAlign2 = textureMasters[floorTexture].floor_align1_2;
			   *floorAlign3 = textureMasters[floorTexture].floor_align1_3;
			   *floorAlign4 = textureMasters[floorTexture].floor_align2_1;
			   *floorAlign5 = textureMasters[floorTexture].floor_align2_2;
			   *floorAlign6 = textureMasters[floorTexture].floor_align2_3;
		break;
		}
	}


}
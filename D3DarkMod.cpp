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
#ifndef d3darkmod_h
	#define d3darkmod_h
	#include "D3DarkMod.h"
#endif
#include "math.h"

int BrushSizeX;
int BrushSizeY;
int BrushSizeZ;
int PrimitiveCount;
int EntityCount;
int CEILING_HEIGHT;
tile LevelInfo[64][64];
int iGame;
void RenderEntity(int game,int x, int y,int z, ObjectItem &currobj, ObjectItem objList[1025], tile LevelInfo[64][64]);

int levelNo;
int SHOCK_CEILING_HEIGHT;

void RenderDarkModLevel(tile LevelInfo[64][64],ObjectItem objList[1025],int game)
{
iGame =game;
switch (game)
	{
	case SHOCK:
		{CEILING_HEIGHT=SHOCK_CEILING_HEIGHT;break;}
	default:
		{CEILING_HEIGHT=UW_CEILING_HEIGHT;break;}
	}
int x; int y; 
	printf ("Version 2\n");
	printf("// entity 0\n{\"classname\" \"worldspawn\"\n");
	//sick of starting at origin.
	printf("\"editor_drLastCameraPos\" \"2594.79 -1375.88 1780.4\"\n");
	printf("\"editor_drLastCameraAngle\" \"-28.5 90.9 0\"\n");
	PrimitiveCount=0;
	printf ("\n");
	for (y=0; y<=63;y++) 
		{
		for (x=0; x<=63;x++)
			{
			if ((LevelInfo[x][y].hasElevator == 0))
				{
				if ( LevelInfo[x][y].TerrainChange == 0)
					{
					RenderDarkModTile(game,x,y,LevelInfo[x][y],0,0);
					}
				if (LevelInfo[x][y].isDoor == 1)
					{
					RenderDoorway(game,x,y,LevelInfo[x][y],objList[LevelInfo[x][y].DoorIndex]);
					}
					
				//if (LevelInfo[x][y].hasPatch == 1)
				//	{
				//	objList[LevelInfo[x][y].PatchIndex].tileX= x;
				//	objList[LevelInfo[x][y].PatchIndex].tileY= y;
				//	RenderPatch(game,x,y,LevelInfo[x][y].floorHeight ,LevelInfo[x][y].PatchIndex,objList);
				//	}
				}
			}
		}
		if (game != SHOCK)
			{
			RenderElevatorLeakProtection(game,LevelInfo);
			RenderFloorAndCeiling(game,LevelInfo);
			}
		printf("}");	//End worldspawn			
		EntityCount=1;
		if (game != SHOCK)
			{
			RenderObjectList(game,LevelInfo,objList);
			RenderElevator(game,LevelInfo,objList);
			RenderLevelExits(game,LevelInfo,objList);
			}
		//Now render thewater

		for (y=0; y<=63;y++) 
			{

			for (x=0; x<=63;x++)
				{
				if (LevelInfo[x][y].isWater == 1)
									{	//TODO:Take this section out of the loop and just just one entity for all the water?
						printf ("\n");
						PrimitiveCount=0;	//resets for each entity.
						printf("// entity %d\n", EntityCount);
						printf("{\n\"classname\" \"atdm:liquid_water\"");
						printf("\n\"name\" \"atdm_liquid_water_%02d\"",EntityCount);
						printf("\n\"model\" \"atdm_liquid_water_%02d\"",EntityCount);
						printf("\n\"underwater_gui\" \"guis\underwater\underwater_green_thinmurk.gui\"\n");	
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
						
						RenderDarkModTile(game,x,y,t,1,0);
						printf("}\n");
						EntityCount++;	
					}
				}

			}
		//Ambient world
			printf("// entity %d\n", EntityCount++);
			printf("{\n\"classname\" \"atdm:ambient_world\"");
			printf("\n\"name\" \"ambient_world\"",EntityCount);
			printf("\n\"origin\" \"2500 2500 120\"");
			printf("\n\"light_center\" \"0 0 0\"");
			printf("\n\"light_radius\" \"4500 4500 2500\"");
			printf("\n\"color\" \"0.50 0.50 0.50\"");
			printf("\n\"nodiffuse\" \"0\"");
			printf("\n\"noshadows\" \"0\"");
			printf("\n\"nospecular\" \"0\"");
			printf("\n\"parallel\" \"0\"");
			printf("}\n");
			
			
		
}

void RenderDarkModTile(int game, int x, int y, tile &t, short Water,short invert)
{ 
if (t.Render == 1)
	{printf ("\n");}
	switch (t.tileType)
		{
		case TILE_SOLID:	//0
			{	//solid
			RenderSolidTile(x,y,t,Water);
			return;
			}
		case TILE_OPEN:		//1
			{//open
			RenderOpenTile(x,y,t,Water,0);	//floor
			if (game == SHOCK) {RenderOpenTile(x,y,t,Water,1);}	//ceiling
			return;
			}
		case 2: 
			{//diag se
			RenderDiagSETile(x,y,t,Water,0);
			if (game == SHOCK) {RenderDiagSETile(x,y,t,Water,1);}
			return;		
			}
		case 3: 
			{	//diag sw 
			RenderDiagSWTile(x,y,t,Water,0);
			if (game == SHOCK) {RenderDiagSWTile(x,y,t,Water,1);}
			return;		
			}
		case 4: 	
			{	//diag ne
			RenderDiagNETile(x,y,t,Water,invert);
			if (game == SHOCK) {RenderDiagNETile(x,y,t,Water,1);}
			return;		
			}
		case 5: 
			{//diag nw
			RenderDiagNWTile(x,y,t,Water,invert);
			if (game == SHOCK) {RenderDiagNWTile(x,y,t,Water,1);}
			return;
			}	
		case TILE_SLOPE_N:	//6
			{//slope n
			switch (t.shockSlopeFlag)
				{
				case SLOPE_BOTH_PARALLEL:
					{
					RenderSlopeNTile(x,y,t,Water,0);
					RenderSlopeNTile(x,y,t,Water,1);
					break;
					}
				case SLOPE_BOTH_OPPOSITE:
					{
					RenderSlopeNTile(x,y,t,Water,0);
					RenderSlopeSTile(x,y,t,Water,1);
					break;
					}
				case SLOPE_FLOOR_ONLY:
					{
					RenderSlopeNTile(x,y,t,Water,0);
					if (game == SHOCK) {RenderOpenTile(x,y,t,Water,1);}	//ceiling
					break;
					}
				case SLOPE_CEILING_ONLY:
					{
					RenderSlopeNTile(x,y,t,Water,1);
					RenderOpenTile(x,y,t,Water,0);	//floor
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
					RenderSlopeSTile(x,y,t,Water,0);
					RenderSlopeSTile(x,y,t,Water,1);
					break;
					}
				case SLOPE_BOTH_OPPOSITE:
					{
					RenderSlopeSTile(x,y,t,Water,0);
					RenderSlopeNTile(x,y,t,Water,1);
					break;
					}
				case SLOPE_FLOOR_ONLY:
					{
					RenderSlopeSTile(x,y,t,Water,0);
					if (game == SHOCK) {RenderOpenTile(x,y,t,Water,1);}	//ceiling
					break;
					}
				case SLOPE_CEILING_ONLY:
					{
					RenderSlopeSTile(x,y,t,Water,1);
					RenderOpenTile(x,y,t,Water,0);	//floor
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
					RenderSlopeETile(x,y,t,Water,0);
					RenderSlopeETile(x,y,t,Water,1);
					break;
					}
				case SLOPE_BOTH_OPPOSITE:
					{
					RenderSlopeETile(x,y,t,Water,0);
					RenderSlopeWTile(x,y,t,Water,1);
					break;
					}
				case SLOPE_FLOOR_ONLY:
					{
					RenderSlopeETile(x,y,t,Water,0);
					if (game == SHOCK) {RenderOpenTile(x,y,t,Water,1);}	//ceiling
					break;
					}
				case SLOPE_CEILING_ONLY:
					{
					RenderSlopeETile(x,y,t,Water,1);
					RenderOpenTile(x,y,t,Water,0);	//floor
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
					RenderSlopeWTile(x,y,t,Water,0);
					RenderSlopeWTile(x,y,t,Water,1);
					break;
					}
				case SLOPE_BOTH_OPPOSITE:
					{
					RenderSlopeWTile(x,y,t,Water,0);
					RenderSlopeETile(x,y,t,Water,1);
					break;
					}
				case SLOPE_FLOOR_ONLY:
					{
					RenderSlopeWTile(x,y,t,Water,0);
					if (game == SHOCK) {RenderOpenTile(x,y,t,Water,1);}	//ceiling
					break;
					}
				case SLOPE_CEILING_ONLY:
					{
					RenderSlopeWTile(x,y,t,Water,1);
					RenderOpenTile(x,y,t,Water,0);	//floor
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
					RenderValleyNWTile(x,y,t,Water,0);
					RenderValleyNWTile(x,y,t,Water,1);
					break;
					}
				case SLOPE_BOTH_OPPOSITE:
					{
					RenderValleyNWTile(x,y,t,Water,0);
					RenderValleySETile(x,y,t,Water,1);
					break;
					}
				case SLOPE_FLOOR_ONLY:
					{
					RenderValleyNWTile(x,y,t,Water,0);
					if (game == SHOCK) {RenderOpenTile(x,y,t,Water,1);}	//ceiling
					break;
					}
				case SLOPE_CEILING_ONLY:
					{
					RenderValleyNWTile(x,y,t,Water,1);
					RenderOpenTile(x,y,t,Water,0);	//floor
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
					RenderValleyNETile(x,y,t,Water,0);
					RenderValleyNETile(x,y,t,Water,1);
					break;
					}
				case SLOPE_BOTH_OPPOSITE:
					{
					RenderValleyNETile(x,y,t,Water,0);
					RenderValleySWTile(x,y,t,Water,1);
					break;
					}
				case SLOPE_FLOOR_ONLY:
					{
					RenderValleyNETile(x,y,t,Water,0);
					if (game == SHOCK) {RenderOpenTile(x,y,t,Water,1);}	//ceiling
					break;
					}
				case SLOPE_CEILING_ONLY:
					{
					RenderValleyNETile(x,y,t,Water,1);
					RenderOpenTile(x,y,t,Water,0);	//floor
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
					RenderValleySETile(x,y,t,Water,0);
					RenderValleySETile(x,y,t,Water,1);
					break;
					}
				case SLOPE_BOTH_OPPOSITE:
					{
					RenderValleySETile(x,y,t,Water,0);
					RenderValleyNWTile(x,y,t,Water,1);
					break;
					}
				case SLOPE_FLOOR_ONLY:
					{
					RenderValleySETile(x,y,t,Water,0);
					if (game == SHOCK) {RenderOpenTile(x,y,t,Water,1);}	//ceiling
					break;
					}
				case SLOPE_CEILING_ONLY:
					{
					RenderValleySETile(x,y,t,Water,1);
					RenderOpenTile(x,y,t,Water,0);	//floor
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
					RenderValleySWTile(x,y,t,Water,0);
					RenderValleySWTile(x,y,t,Water,1);
					break;
					}
				case SLOPE_BOTH_OPPOSITE:
					{
					RenderValleySWTile(x,y,t,Water,0);
					RenderValleyNETile(x,y,t,Water,1);
					break;
					}
				case SLOPE_FLOOR_ONLY:
					{
					RenderValleySWTile(x,y,t,Water,0);
					if (game == SHOCK) {RenderOpenTile(x,y,t,Water,1);}	//ceiling
					break;
					}
				case SLOPE_CEILING_ONLY:
					{
					RenderValleySWTile(x,y,t,Water,1);
					RenderOpenTile(x,y,t,Water,0);	//floor
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
					RenderRidgeSETile(x,y,t,Water,0);
					RenderRidgeSETile(x,y,t,Water,1);
					break;
					}
				case SLOPE_BOTH_OPPOSITE:
					{
					RenderRidgeSETile(x,y,t,Water,0);
					RenderRidgeNWTile(x,y,t,Water,1);
					break;
					}
				case SLOPE_FLOOR_ONLY:
					{
					RenderRidgeSETile(x,y,t,Water,0);
					if (game == SHOCK) {RenderOpenTile(x,y,t,Water,1);}	//ceiling
					break;
					}
				case SLOPE_CEILING_ONLY:
					{
					RenderValleySETile(x,y,t,Water,1);
					RenderOpenTile(x,y,t,Water,0);	//floor
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
					RenderRidgeSWTile(x,y,t,Water,0);
					RenderRidgeSWTile(x,y,t,Water,1);
					break;
					}
				case SLOPE_BOTH_OPPOSITE:
					{
					RenderRidgeSWTile(x,y,t,Water,0);
					RenderRidgeNETile(x,y,t,Water,1);
					break;
					}
				case SLOPE_FLOOR_ONLY:
					{
					RenderRidgeSWTile(x,y,t,Water,0);
					if (game == SHOCK) {RenderOpenTile(x,y,t,Water,1);}	//ceiling
					break;
					}
				case SLOPE_CEILING_ONLY:
					{
					RenderValleySWTile(x,y,t,Water,1);
					RenderOpenTile(x,y,t,Water,0);	//floor
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
					RenderRidgeNWTile(x,y,t,Water,0);
					RenderRidgeNWTile(x,y,t,Water,1);
					break;
					}
				case SLOPE_BOTH_OPPOSITE:
					{
					RenderRidgeNWTile(x,y,t,Water,0);
					RenderRidgeSETile(x,y,t,Water,1);
					break;
					}
				case SLOPE_FLOOR_ONLY:
					{
					RenderRidgeNWTile(x,y,t,Water,0);
					if (game == SHOCK) {RenderOpenTile(x,y,t,Water,1);}	//ceiling
					break;
					}
				case SLOPE_CEILING_ONLY:
					{
					RenderValleyNWTile(x,y,t,Water,1);
					RenderOpenTile(x,y,t,Water,0);	//floor
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
					RenderRidgeNETile(x,y,t,Water,0);
					RenderRidgeNETile(x,y,t,Water,1);
					break;
					}
				case SLOPE_BOTH_OPPOSITE:
					{
					RenderRidgeNETile(x,y,t,Water,0);
					RenderRidgeSWTile(x,y,t,Water,1);
					break;
					}
				case SLOPE_FLOOR_ONLY:
					{
					RenderRidgeNETile(x,y,t,Water,0);
					if (game == SHOCK) {RenderOpenTile(x,y,t,Water,1);}	//ceiling
					break;
					}
				case SLOPE_CEILING_ONLY:
					{
					RenderValleyNETile(x,y,t,Water,1);
					RenderOpenTile(x,y,t,Water,0);	//floor
					break;
					}
				}			
			return;
			}																	
	}
}




	
void getWallTextureName(tile t, int face, short waterWall)
{
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
	
	switch (wallTexture)
		{
		case TRIGGER_MULTI:
			{printf( "( ( 0 0.03125 0 ) ( -0.03125 0 0 ) ) \"textures/common/trigmulti\" 0 0 0\n");break;}
		case NODRAW:	//nodraw
			{printf( "( ( 0 0.03125 0 ) ( -0.03125 0 0 ) ) \"textures/common/nodraw\" 0 0 0\n");break;}
		case VISPORTAL:	//visportal
			{printf( "( ( 0 0.03125 0 ) ( -0.03125 0 0 ) ) \"textures/editor/visportal\" 0 0 0\n");break;}
		case CAULK:
			{printf( "( ( 0 0.03125 0 ) ( -0.03125 0 0 ) ) \"textures/common/caulk\" 0 0 0\n");break;}
		default:
			{
				if (wallTexture > 300)
					{
					printf( "( ( 0 0.03125 0 ) ( -0.03125 0 0 ) ) \"textures/common/caulk\" 0 0 0\n");break;
					}
				else
					{
					if (iGame == SHOCK)
						{
						float shock_ceil = SHOCK_CEILING_HEIGHT;
						float floorOffset = shock_ceil-ceilOffset -8;
						while (floorOffset >=8)
							{
							floorOffset -=8;
							}
						//float textureVertAlign = ((SHOCK_CEILING_HEIGHT+1)-(ceilOffset+textureOffset)) * BrushSizeZ;
						//float textureVertAlign = ((ceilOffset+textureOffset)) / (shock_ceil);
						//float textureVertAlign =(textureOffset) * textureMasters[wallTexture].align2_3;
						//fuck it. Just align with it's ceiling
						//float textureVertAlign = ((ceilOffset)  * (1/shock_ceil));
						float textureVertAlign = (floorOffset) / 8;
						printf( "( ( %f %f %f ) ( %f %f %f ) ) \"",
						textureMasters[wallTexture].align1_1,textureMasters[wallTexture].align1_2,textureMasters[wallTexture].align1_3,
						textureMasters[wallTexture].align2_1,textureMasters[wallTexture].align2_2,textureVertAlign);						
						}
					else
						{
						printf( "( ( %f %f %f ) ( %f %f %f ) ) \"",
						textureMasters[wallTexture].align1_1,textureMasters[wallTexture].align1_2,textureMasters[wallTexture].align1_3,
						textureMasters[wallTexture].align2_1,textureMasters[wallTexture].align2_2,textureMasters[wallTexture].align2_3);						
						}
					printf("%s", textureMasters[wallTexture].path );
					printf("\" 0 0 0\n");
					}
			}
		}
	}
else
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
	//printf( "( ( 0 0.03125 0 ) ( -0.03125 0 0 ) ) \"textures/common/nodraw\" 0 0 0\n");
	switch (wallTexture)
		{
		case TRIGGER_MULTI:
			{printf( "( ( 0 0.03125 0 ) ( -0.03125 0 0 ) ) \"textures/common/trigmulti\" 0 0 0\n");break;}
		case NODRAW:	//nodraw
			{printf( "( ( 0 0.03125 0 ) ( -0.03125 0 0 ) ) \"textures/common/nodraw\" 0 0 0\n");break;}
		case VISPORTAL:	//visportal
			{printf( "( ( 0 0.03125 0 ) ( -0.03125 0 0 ) ) \"textures/editor/visportal\" 0 0 0\n");break;}
		case CAULK:
			{printf( "( ( 0 0.03125 0 ) ( -0.03125 0 0 ) ) \"textures/common/caulk\" 0 0 0\n");break;}
		default:
			{
			printf( "( ( %f %f %f ) ( %f %f %f ) ) \"",textureMasters[wallTexture].align1_1,textureMasters[wallTexture].align1_2,textureMasters[wallTexture].align1_3,textureMasters[wallTexture].align2_1,textureMasters[wallTexture].align2_2,textureMasters[wallTexture].align2_3);	
			printf("%s", textureMasters[wallTexture].path );
			printf("\" 0 0 0\n");
			}
		}	
	}
	return ;
}

void getFloorTextureName(tile t, int face)
{
//{printf( " ( ( 0.0078125 0 0 ) ( 0 0.0078125 0 ) ) \"textures/darkmod/stone/natural/gravel_grey_01\" 0 0 0\n");}
//return; 

int floorTexture;

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
			{printf( "( ( 0 0.03125 0 ) ( -0.03125 0 0 ) ) \"textures/common/trigmulti\" 0 0 0\n");break;}
		case NODRAW:	//nodraw
			{printf( "( ( 0 0.03125 0 ) ( -0.03125 0 0 ) ) \"textures/common/nodraw\" 0 0 0\n");break;}
		case VISPORTAL:	//visportal
			{printf( "( ( 0 0.03125 0 ) ( -0.03125 0 0 ) ) \"textures/editor/visportal\" 0 0 0\n");break;}
		case CAULK:
		default:
			{printf( "( ( 0 0.03125 0 ) ( -0.03125 0 0 ) ) \"textures/common/caulk\" 0 0 0\n");break;}
		}
	}
	else
		{
			printf( "( ( %f %f %f ) ( %f %f %f ) ) \"",textureMasters[floorTexture].floor_align1_1,textureMasters[floorTexture].floor_align1_2,textureMasters[floorTexture].floor_align1_3,textureMasters[floorTexture].floor_align2_1,textureMasters[floorTexture].floor_align2_2,textureMasters[floorTexture].floor_align2_3);	
			printf("%s", textureMasters[floorTexture].path );
			printf("\" 0 0 0\n");
		}

	return ;
}



void RenderFloorAndCeiling(int game, tile LevelInfo[64][64])
{
switch (game)
	{
	case SHOCK:
		{//due to variable ceiling heights I have to render each tile's roof.
			for (int y=0; y<=63;y++) 
				{
				printf ("\n");
				for (int x=0; x<=63;x++)
					{
						if ((LevelInfo[x][y].tileType == 1))
							//Only do a ceiling for open and diagonals. everything else gets it's ceiling on the first pass due to slope flags
							{
							RenderDarkModTile(game,x,y,LevelInfo[x][y],0,1);
							}
					}
				}
		break;
		}	
	default:
		{//UW has a single height ceiling. Just need to put a roof on her and a riverbed for water features.
		//put a roof on her 
		printf("// primitive %d\n",PrimitiveCount++);
		printf("{\nbrushDef3\n{\n");
		//001	east face -absdist
		printf ("( 1 0 0 %d ) ( ( 0.03125 0 0 ) ( 0 0.03125 0 ) ) \"textures/common/caulk\" 0 0 0\n",-(64*BrushSizeX));
		//010 north face -absdist
		printf ("( 0 1 0 %d ) ( ( 0.03125 0 0 ) ( 0 0.03125 0 ) ) \"textures/common/caulk\" 0 0 0\n",-(64*BrushSizeY));
		//100	top face -absdist
		printf ("( 0 0 1 %d ) ( ( 0.03125 0 0 ) ( 0 0.03125 0 ) ) \"textures/common/caulk\" 0 0 0\n", -BrushSizeZ * (CEILING_HEIGHT+1));	
		//00-1	west face +absdist
		printf ("( -1 0 0 %d ) ( ( 0.03125 0 0 ) ( 0 0.03125 0 ) ) \"textures/common/caulk\" 0 0 0\n", +(0));
		//0-1 0	south face +absdist
		printf ("( 0 -1 0 %d ) ( ( 0.03125 0 0 ) ( 0 0.03125 0 ) ) \"textures/common/caulk\" 0 0 0\n", +(0));
		//-100	bottom face +absdist
		printf ("( 0 0 -1 %d ) ( ( 0.03125 0 0 ) ( 0 0.03125 0 ) ) \"textures/darkmod/stone/flat/slate_rough_dark01\" 0 0 0\n", (BrushSizeZ * (CEILING_HEIGHT)));	
		printf ("}\n}\n");
		
		//and a ceiling 
		printf("// primitive %d\n",PrimitiveCount++);
		printf("{\nbrushDef3\n{\n");
		//001	east face -absdist
		printf ("( 1 0 0 %d ) ( ( 0.03125 0 0 ) ( 0 0.03125 0 ) ) \"textures/common/caulk\" 0 0 0\n",-(64*BrushSizeX));
		//010 north face -absdist
		printf ("( 0 1 0 %d ) ( ( 0.03125 0 0 ) ( 0 0.03125 0 ) ) \"textures/common/caulk\" 0 0 0\n",-(64*BrushSizeY));
		//100	top face -absdist
		printf ("( 0 0 1 %d ) ( ( 0.03125 0 0 ) ( 0 0.03125 0 ) ) \"textures/darkmod/stone/natural/tiling_1d/gravel_red_01\" 0 0 0\n", +(2*BrushSizeZ) );	
		//00-1	west face +absdist
		printf ("( -1 0 0 %d ) ( ( 0.03125 0 0 ) ( 0 0.03125 0 ) ) \"textures/common/caulk\" 0 0 0\n", +(0));
		//0-1 0	south face +absdist
		printf ("( 0 -1 0 %d ) ( ( 0.03125 0 0 ) ( 0 0.03125 0 ) ) \"textures/common/caulk\" 0 0 0\n", +(0));
		//-100	bottom face +absdist
		printf ("( 0 0 -1 %d ) ( ( 0.03125 0 0 ) ( 0 0.03125 0 ) ) \"textures/common/caulk\" 0 0 0\n", -(2*BrushSizeZ)-10);	
		printf ("}\n}\n");
		break;
		}
	}
}

void RenderObjectList(int game, tile LevelInfo[64][64], ObjectItem objList[1025])
{
int x; int y;
//print out objects.
for (y=0; y<=63;y++) 
	{
	for (x=0; x<=63;x++)
		{
		if ((LevelInfo[x][y].indexObjectList !=0))
			{
			//TODO: Position objects by x,y values in leveldata
			long nextObj = LevelInfo[x][y].indexObjectList;
			int offX=0; int offY=0; int offZ=0;
			while (nextObj !=0)
				{
				objList[nextObj].tileX=x;
				objList[nextObj].tileY=y;
				
				
				offX= (x*BrushSizeX) + ((objList[nextObj].x) * (BrushSizeX/7));
				offY= (y*BrushSizeY) + ((objList[nextObj].y) * (BrushSizeY/7));
				//offZ = objList[nextObj].zpos ; //TODO:Adjust this.
				int floorHeight = LevelInfo[x][y].floorHeight <<3 ;
				int nextFloorHeight =(LevelInfo[x][y].floorHeight+1) <<3 ;
				float relativeZpos = (float)(objList[nextObj].zpos - floorHeight);
				float zposRatio = (float)(relativeZpos/(nextFloorHeight-floorHeight));	//relative adjustment
				//float zposRatio = (float)(relativeZpos/(12*BrushSizeZ));	//relative adjustment
				offZ = LevelInfo[x][y].floorHeight * BrushSizeZ + (zposRatio*BrushSizeZ*1);
				
				if ((zposRatio !=0) && (objectMasters[objList[nextObj].item_id].type != BRIDGE))
					{
					float zpos= objList[nextObj].zpos;
					float brushZ = BrushSizeZ;
					float ceiling = CEILING_HEIGHT;
					offZ = (zpos/127) * (brushZ*ceiling);
					}
				
				if ((LevelInfo[x][y].tileType >= 6) && (LevelInfo[x][y].tileType <= 9) && (LevelInfo[x][y].isWater == 0))
					{
					offZ = offZ + (LevelInfo[x][y].shockSteep * (BrushSizeZ /2));
					}
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
			printf("// primitive %d\n",PrimitiveCount++);
			printf("{\nbrushDef3\n{\n");
			//east face 
			printf ("( 1 0 0 %d )",-((x+t.DimX)*BrushSizeX));
			getWallTextureName(t,fEAST,0);
			//north face 
			printf ("( 0 1 0 %d )",-((y+t.DimY)*BrushSizeY));
			getWallTextureName(t,fNORTH,0);
			//top face
			printf ("( 0 0 1 %d )", -BrushSizeZ * (CEILING_HEIGHT+1) );	
			getFloorTextureName(t,fTOP);
			//west face
			printf ("( -1 0 0 %d )", +((x)*BrushSizeX));
			getWallTextureName(t,fWEST,0);
			//south face
			printf ("( 0 -1 0 %d )", +((y)*BrushSizeY));
			getWallTextureName(t, fSOUTH,0);
			//bottom face
			printf ("( 0 0 -1 %d )", -2*BrushSizeZ);	
			getFloorTextureName(t, fBOTTOM);
			printf ("}\n}\n");
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
				printf("// primitive %d\n",PrimitiveCount++);
				printf("{\nbrushDef3\n{\n");
				//East face
				printf ("( 1 0 0 %d )",-((x+t.DimX)*BrushSizeX));
				getWallTextureName(t,fEAST,t.isWater);
				//North face
				printf ("( 0 1 0 %d ) ",-((y+t.DimY)*BrushSizeY));
				getWallTextureName(t,fNORTH,t.isWater);
				//Top face
				printf ("( 0 0 1 %d )", -( (t.floorHeight) * BrushSizeZ) );	
				getFloorTextureName(t,fTOP);
				//West face
				printf ("( -1 0 0 %d )", +((x)*BrushSizeX));
				getWallTextureName(t,fWEST,t.isWater);
				//South face
				printf ("( 0 -1 0 %d )", +((y)*BrushSizeY));
				getWallTextureName(t,fSOUTH,t.isWater);
				//Bottom face 
				if (t.hasElevator ==0)
					{
					printf ("( 0 0 -1 %d ) ", -2*BrushSizeZ);	
					}
				else
					{
					printf ("( 0 0 -1 %d ) ", -8*BrushSizeZ);	
					}
				getFloorTextureName(t,fBOTTOM);
				printf ("}\n}\n");
				}
			else
				{
				//render a ceiling version of this tile
				//top and bottom faces move up
				printf("// primitive %d\n",PrimitiveCount++);
				printf("{\nbrushDef3\n{\n");
				//East face
				printf ("( 1 0 0 %d )",-((x+t.DimX)*BrushSizeX));
				getWallTextureName(t,fEAST,t.isWater);
				//North face
				printf ("( 0 1 0 %d ) ",-((y+t.DimY)*BrushSizeY));
				getWallTextureName(t,fNORTH,t.isWater);
				//Top face
				printf ("( 0 0 1 %d )", -( (CEILING_HEIGHT+1) * BrushSizeZ));	
				getFloorTextureName(t,fTOP);
				//West face
				printf ("( -1 0 0 %d )", +((x)*BrushSizeX));
				getWallTextureName(t,fWEST,t.isWater);
				//South face
				printf ("( 0 -1 0 %d )", +((y)*BrushSizeY));
				getWallTextureName(t,fSOUTH,t.isWater);
				//Bottom face 
				printf ("( 0 0 -1 %d ) ", +(CEILING_HEIGHT -(t.ceilingHeight))* BrushSizeZ);	
				getFloorTextureName(t,fCEIL);
				printf ("}\n}\n");				
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
				printf("// primitive %d\n",PrimitiveCount++);
				printf("{\nbrushDef3\n{\n");
				//North face
				printf ("( 0 1 0 %d )",-((y+t.DimY)*BrushSizeY));
				getWallTextureName(t,fNORTH,0);
				//Top face
				printf ("( 0 0 1 %d )", -BrushSizeZ * (CEILING_HEIGHT+1)   );
				getFloorTextureName(t,fTOP);
				//West face
				printf ("( -1 0 0 %d )", +((x)*BrushSizeX));
				getWallTextureName(t,fWEST,0);
				//Bottom face 
				printf ("( 0 0 -1 %d )", -2*BrushSizeZ);	//to go underneath
				getFloorTextureName(t,fBOTTOM);
				//Angled face. x & y change
				//TODO: Change texture here
				printf ("( %f -%f 0 %f )", cos(angle),sin(angle),-normalDist);	
				getWallTextureName(t,fSELF,0);
				printf ("}\n}\n");
				}
			if(t.isWater==Water)
				{					
				//it's floor
				printf("// primitive %d\n",PrimitiveCount++);
				printf("{\nbrushDef3\n{\n");
				//East Face
				printf ("( 1 0 0 %d )",-((x+t.DimX)*BrushSizeX));
				getWallTextureName(t, fEAST,t.isWater );
				//Top face
				printf ("( 0 0 1 %d )", -( (t.floorHeight) * BrushSizeZ) );	
				getFloorTextureName(t, fTOP);
				//South face
				printf ("( 0 -1 0 %d )", +((y)*BrushSizeY));
				getWallTextureName(t,fSOUTH,t.isWater );
				//Bottom face
				printf ("( 0 0 -1 %d )", -2*BrushSizeZ);
				getFloorTextureName(t, fBOTTOM );
				//Angled face. x & y change
				normalDist = ( cos(atan((float)BrushY/BrushX)) ) * (x-y) * BrushSizeY;
				printf ("( -%f %f 0 %f )", cos(angle),sin(angle),normalDist);	
				getWallTextureName(t,fEAST,t.isWater );
				printf ("}\n}\n");
				}
			}
		else
			{//it's ceiling
				printf("// primitive %d\n",PrimitiveCount++);
				printf("{\nbrushDef3\n{\n");
				//East Face
				printf ("( 1 0 0 %d )",-((x+t.DimX)*BrushSizeX));
				getWallTextureName(t, fEAST,t.isWater );
				//Top face
				printf ("( 0 0 1 %d )", -( (CEILING_HEIGHT+1) * BrushSizeZ) );
				getFloorTextureName(t, fTOP);
				//South face
				printf ("( 0 -1 0 %d )", +((y)*BrushSizeY));
				getWallTextureName(t,fSOUTH,t.isWater );
				//Bottom face
				//printf ("( 0 0 -1 %d )", +t.ceilingHeight * BrushSizeZ);
				printf ("( 0 0 -1 %d ) ", +(CEILING_HEIGHT -(t.ceilingHeight))* BrushSizeZ);				
				getFloorTextureName(t, fCEIL );
				//Angled face. x & y change
				normalDist = ( cos(atan((float)BrushY/BrushX)) ) * (x-y) * BrushSizeY;
				printf ("( -%f %f 0 %f )", cos(angle),sin(angle),normalDist);	
				getWallTextureName(t,fEAST,t.isWater );
				printf ("}\n}\n");	
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
			printf("// primitive %d\n",PrimitiveCount++);
			printf("{\nbrushDef3\n{\n");
			//East face
			printf ("( 1 0 0 %d )",-((x+t.DimX)*BrushSizeX));
			getWallTextureName(t,fEAST,0);
			//North face
			printf ("( 0 1 0 %d )",-((y+t.DimY)*BrushSizeY));
			getWallTextureName(t, fNORTH,0);
			//Top face
			printf ("( 0 0 1 %d )", -BrushSizeZ * (CEILING_HEIGHT+1)   );	
			getFloorTextureName(t,fTOP);
			//Bottom face
			printf ("( 0 0 -1 %d )", -2*BrushSizeZ);	
			getWallTextureName(t,fBOTTOM,0);
			//Angled face. x & y change
			printf ("( -%f -%f 0 %f )", cos(angle),sin(angle),+normalDist);		
			getWallTextureName(t,fSELF,0);
			printf ("}\n}\n");
			}
		if(t.isWater==Water)
			{
			//it's floor
			printf("// primitive %d\n",PrimitiveCount++);
			printf("{\nbrushDef3\n{\n");
			//Top face
			printf ("( 0 0 1 %d )", -( (t.floorHeight) * BrushSizeZ) );
			getFloorTextureName(t,fTOP);		
			//West face 
			printf ("( -1 0 0 %d )", +((x)*BrushSizeX));
			getWallTextureName(t,fWEST,t.isWater );
			//South face
			printf ("( 0 -1 0 %d )", +((y)*BrushSizeY));
			getWallTextureName(t,fSOUTH,t.isWater );
			//Bottom face
			printf ("( 0 0 -1 %d )", -2*BrushSizeZ);
			getWallTextureName(t,fBOTTOM,t.isWater );
			//Angled face. x & y change
			normalDist = ( cos(atan((float)BrushY/BrushX)) ) * (y+x+1) * BrushSizeY;
			printf ("( %f %f 0 %f )", cos(angle),sin(angle),-normalDist);
			getWallTextureName(t,fEAST,t.isWater );
			printf ("}\n}\n");
			}
		}
		else
			{//its' ceiling.
			printf("// primitive %d\n",PrimitiveCount++);
			printf("{\nbrushDef3\n{\n");
			//Top face
			printf ("( 0 0 1 %d )", -( (CEILING_HEIGHT+1) * BrushSizeZ) );
			getFloorTextureName(t,fTOP);		
			//West face 
			printf ("( -1 0 0 %d )", +((x)*BrushSizeX));
			getWallTextureName(t,fWEST,t.isWater );
			//South face
			printf ("( 0 -1 0 %d )", +((y)*BrushSizeY));
			getWallTextureName(t,fSOUTH,t.isWater );
			//Bottom face
			//printf ("( 0 0 -1 %d )", +t.ceilingHeight * BrushSizeZ);
			printf ("( 0 0 -1 %d ) ", +(CEILING_HEIGHT -(t.ceilingHeight))* BrushSizeZ);			
			getWallTextureName(t,fCEIL,t.isWater );
			//Angled face. x & y change
			normalDist = ( cos(atan((float)BrushY/BrushX)) ) * (y+x+1) * BrushSizeY;
			printf ("( %f %f 0 %f )", cos(angle),sin(angle),-normalDist);
			getWallTextureName(t,fEAST,t.isWater );
			printf ("}\n}\n");			
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
				printf("// primitive %d\n",PrimitiveCount++);
				printf("{\nbrushDef3\n{\n");
				//Top face
				printf ("( 0 0 1 %d )", -BrushSizeZ * (CEILING_HEIGHT+1)   );	
				getFloorTextureName(t,fTOP);
				//West face
				printf ("( -1 0 0 %d )", +((x)*BrushSizeX));
				getWallTextureName(t,fWEST,0);
				//South face 
				printf ("( 0 -1 0 %d )", +((y)*BrushSizeY));
				getWallTextureName(t,fSOUTH,0);
				//Bottom face
				printf ("( 0 0 -1 %d )", -2*BrushSizeZ);
				getWallTextureName(t,fBOTTOM,0);
				//Angled face. x & y change
				printf ("( %f %f 0 %f )", cos(angle),sin(angle),-normalDist);
				getWallTextureName(t,fSELF,0);
				printf ("}\n}\n");
				}
			if(t.isWater==Water)
				{					
				//it's floor
				printf("// primitive %d\n",PrimitiveCount++);
				printf("{\nbrushDef3\n{\n");
				//East face
				printf ("( 1 0 0 %d )",-((x+t.DimX)*BrushSizeX));
				getWallTextureName(t,fEAST,t.isWater );
				//North face
				printf ("( 0 1 0 %d )",-((y+t.DimY)*BrushSizeY));
				getWallTextureName(t,fNORTH,t.isWater );
				//Top face
				printf ("( 0 0 1 %d )", -( (t.floorHeight) * BrushSizeZ) );	
				getFloorTextureName(t,fTOP );
				//Bottom face
				printf ("( 0 0 -1 %d )", -2*BrushSizeZ);
				getWallTextureName(t,fBOTTOM,t.isWater );
				//Angled face. x & y change
				normalDist = ( cos(atan((float)BrushY/BrushX)) ) * (y+x+1) * BrushSizeY;
				printf ("( -%f -%f 0 %f )", cos(angle),sin(angle),+normalDist);	
				getWallTextureName(t,fWEST,t.isWater );	
				printf ("}\n}\n");
				}
			}
	else
		{//it's ceiling
			printf("// primitive %d\n",PrimitiveCount++);
			printf("{\nbrushDef3\n{\n");
			//East face
			printf ("( 1 0 0 %d )",-((x+t.DimX)*BrushSizeX));
			getWallTextureName(t,fEAST,t.isWater );
			//North face
			printf ("( 0 1 0 %d )",-((y+t.DimY)*BrushSizeY));
			getWallTextureName(t,fNORTH,t.isWater );
			//Top face
			printf ("( 0 0 1 %d )", -( (CEILING_HEIGHT+1) * BrushSizeZ));	
			getFloorTextureName(t,fTOP );
			//Bottom face
			//printf ("( 0 0 -1 %d )", + t.ceilingHeight * BrushSizeZ);
			printf ("( 0 0 -1 %d ) ", +(CEILING_HEIGHT -(t.ceilingHeight))* BrushSizeZ);			
			getWallTextureName(t,fCEIL,t.isWater );
			//Angled face. x & y change
			normalDist = ( cos(atan((float)BrushY/BrushX)) ) * (y+x+1) * BrushSizeY;
			printf ("( -%f -%f 0 %f )", cos(angle),sin(angle),+normalDist);	
			getWallTextureName(t,fWEST,t.isWater );	
			printf ("}\n}\n");		
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
				printf("// primitive %d\n",PrimitiveCount++);
				printf("{\nbrushDef3\n{\n");
				//East face -absdist
				printf ("( 1 0 0 %d )",-((x+t.DimX)*BrushSizeX));
				getWallTextureName(t,fEAST,0 );
				//Top face
				printf ("( 0 0 1 %d )", -BrushSizeZ * (CEILING_HEIGHT+1)   );	
				getFloorTextureName(t,fTOP );
				//South face
				printf ("( 0 -1 0 %d )", +((y)*BrushSizeY));
				getWallTextureName(t,fSOUTH,0 );
				//Bottom face
				printf ("( 0 0 -1 %d )", -2*BrushSizeZ);
				getWallTextureName(t,fBOTTOM,0 );
				//Angled face. x & y change
				printf ("( -%f %f 0 %f )", cos(angle),sin(angle),normalDist);
				getWallTextureName(t,fSELF,0 );	
				printf ("}\n}\n");
				}
			
			//it's floor
			if(t.isWater==Water)
				{					
				printf("// primitive %d\n",PrimitiveCount++);
				printf("{\nbrushDef3\n{\n");
				//North face
				printf ("( 0 1 0 %d )",-((y+t.DimY)*BrushSizeY));
				getWallTextureName(t,fNORTH,t.isWater );
				//Top face
				printf ("( 0 0 1 %d )", -( (t.floorHeight) * BrushSizeZ) );
				getFloorTextureName(t,fTOP);
				//West face
				printf ("( -1 0 0 %d )", +((x)*BrushSizeX));
				getWallTextureName(t,fWEST,t.isWater);
				//Bottom face +absdist
				printf ("( 0 0 -1 %d )", -2*BrushSizeZ);
				getWallTextureName(t,fBOTTOM,t.isWater );
				//Angled face. x & y change
				normalDist = ( cos(atan((float)BrushY/BrushX)) ) * (x-y) * BrushSizeY;
				printf ("( %f -%f 0 %f )", cos(angle),sin(angle),-normalDist);
				getWallTextureName(t,fWEST,t.isWater );	
				printf ("}\n}\n");
				}
			}
		else
			{//it's ceiling
			printf("// primitive %d\n",PrimitiveCount++);
			printf("{\nbrushDef3\n{\n");
			//North face
			printf ("( 0 1 0 %d )",-((y+t.DimY)*BrushSizeY));
			getWallTextureName(t,fNORTH,t.isWater );
			//Top face
			printf ("( 0 0 1 %d )", -( (CEILING_HEIGHT+1) * BrushSizeZ) );
			getFloorTextureName(t,fTOP);
			//West face
			printf ("( -1 0 0 %d )", +((x)*BrushSizeX));
			getWallTextureName(t,fWEST,t.isWater);
			//Bottom face +absdist
			//printf ("( 0 0 -1 %d )", +t.ceilingHeight * BrushSizeZ);
			printf ("( 0 0 -1 %d ) ", +(CEILING_HEIGHT -(t.ceilingHeight))* BrushSizeZ);			
			getWallTextureName(t,fCEIL,t.isWater );
			//Angled face. x & y change
			normalDist = ( cos(atan((float)BrushY/BrushX)) ) * (x-y) * BrushSizeY;
			printf ("( %f -%f 0 %f )", cos(angle),sin(angle),-normalDist);
			getWallTextureName(t,fWEST,t.isWater );	
			printf ("}\n}\n");
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
				printf("// primitive %d\n",PrimitiveCount++);
				printf("{\nbrushDef3\n{\n");
				//East face
				printf ("( 1 0 0 %d )",-((x+t.DimX)*BrushSizeX));
				getWallTextureName(t,fEAST,t.isWater );
				//North face
				printf ("( 0 1 0 %d )",-((y+t.DimY)*BrushSizeY));
				getWallTextureName(t, fNORTH,t.isWater );
				//Top face
				printf ("( 0 %f %f %f )", -cos(angle), sin(angle),-normalDist);	
				getFloorTextureName(t,fTOP );
				//West face
				printf ("( -1 0 0 %d )", +((x)*BrushSizeX));
				getWallTextureName(t,fWEST,t.isWater );
				//South face
				printf ("( 0 -1 0 %d )", +((y)*BrushSizeY));
				getWallTextureName(t,fSOUTH,t.isWater );
				//Bottom face
				printf ("( 0 0 -1 %d )", -2*BrushSizeZ);
				getWallTextureName(t,fBOTTOM,t.isWater );
				printf ("}\n}\n");
				}
			}
		else
			{
			BrushZ = (float)BrushSizeZ*steepness; BrushY = (float)BrushSizeY;
			angle = atan((float)(BrushY/BrushZ));
			normalDist = (cos(atan(BrushZ/BrushY))) * ((ceilingHeight/steepness)-y-1) * BrushZ;
				
				printf("// primitive %d\n",PrimitiveCount++);
				printf("{\nbrushDef3\n{\n");
				//East face
				printf ("( 1 0 0 %d )",-((x+t.DimX)*BrushSizeX));
				getWallTextureName(t,fEAST,t.isWater );
				//North face
				printf ("( 0 1 0 %d )",-((y+t.DimY)*BrushSizeY));
				getWallTextureName(t, fNORTH,t.isWater );
				//Top face	->becomes ceiling 
				printf ("( 0 0 1 %d )", -(CEILING_HEIGHT+1)*BrushSizeZ);
					
				getFloorTextureName(t,fTOP );
				//West face
				printf ("( -1 0 0 %d )", +((x)*BrushSizeX));
				getWallTextureName(t,fWEST,t.isWater );
				//South face
				printf ("( 0 -1 0 %d )", +((y)*BrushSizeY));
				getWallTextureName(t,fSOUTH,t.isWater );
				//Bottom face
				printf ("( 0 %f %f %f )", cos(angle), -sin(angle),+normalDist);
				getFloorTextureName(t,fCEIL);
				printf ("}\n}\n");			

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
			printf("// primitive %d\n",PrimitiveCount++);
			printf("{\nbrushDef3\n{\n");
			//East face
			printf ("( 1 0 0 %d )",-((x+t.DimX)*BrushSizeX));
			getWallTextureName(t,fEAST,t.isWater );
			//North face
			printf ("( 0 1 0 %d )",-((y+t.DimY)*BrushSizeY));
			getWallTextureName(t,fNORTH,t.isWater );
			//Top face
			printf ("( 0 %f %f %f )", cos(angle), sin(angle),-normalDist);	
			getFloorTextureName(t,fTOP );
			//West face
			printf ("( -1 0 0 %d )", +((x)*BrushSizeX));
			getWallTextureName(t,fWEST,t.isWater );
			//South face
			printf ("( 0 -1 0 %d )", +((y)*BrushSizeY));
			getWallTextureName(t,fSOUTH,t.isWater );
			//Bottom face +absdist
			printf ("( 0 0 -1 %d )", -2*BrushSizeZ);	//+10 to go underneath
			getWallTextureName(t,fBOTTOM,t.isWater );
			printf ("}\n}\n");
			}
		}
		else
			{

			BrushZ = (float)BrushSizeZ*steepness; BrushY = (float)BrushSizeY;
			angle = atan((float)(BrushY/BrushZ));
			//normalDist = (cos(atan(BrushZ/BrushY))) * ((ceilingHeight/steepness) -y) * BrushZ;
			normalDist = (cos(atan(BrushZ/BrushY))) * ((ceilingHeight/steepness) +y) * BrushZ;					
				printf("// primitive %d\n",PrimitiveCount++);
				printf("{\nbrushDef3\n{\n");
				//East face
				printf ("( 1 0 0 %d )",-((x+t.DimX)*BrushSizeX));
				getWallTextureName(t,fEAST,t.isWater );
				//North face
				printf ("( 0 1 0 %d )",-((y+t.DimY)*BrushSizeY));
				getWallTextureName(t, fNORTH,t.isWater );
				//Top face	->becomes ceiling 
				printf ("( 0 0 1 %d )", -(CEILING_HEIGHT+1)*BrushSizeZ);
					
				getFloorTextureName(t,fTOP );
				//West face
				printf ("( -1 0 0 %d )", +((x)*BrushSizeX));
				getWallTextureName(t,fWEST,t.isWater );
				//South face
				printf ("( 0 -1 0 %d )", +((y)*BrushSizeY));
				getWallTextureName(t,fSOUTH,t.isWater );
				//Bottom face
				printf ("( 0 %f %f %f )", -cos(angle), -sin(angle),+normalDist);
				getFloorTextureName(t,fCEIL);
				printf ("}\n}\n");
			
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
				printf("// primitive %d\n",PrimitiveCount++);
				printf("{\nbrushDef3\n{\n");
				//East face
				printf ("( 1 0 0 %d )",-((x+t.DimX)*BrushSizeX));
				getWallTextureName(t,fEAST,t.isWater);
				//North face
				printf ("( 0 1 0 %d )",-((y+t.DimY)*BrushSizeY));
				getWallTextureName(t,fNORTH,t.isWater);
				//Top face
				printf ("( %f 0 %f %f )", cos(angle),sin(angle),-normalDist);	
				getFloorTextureName(t,fTOP);
				//West face
				printf ("( -1 0 0 %d )", +((x)*BrushSizeX));
				getWallTextureName(t,fWEST,t.isWater);
				//South face
				printf ("( 0 -1 0 %d )", +((y)*BrushSizeY));
				getWallTextureName(t, fSOUTH,t.isWater);
				//Bottom face
				printf ("( 0 0 -1 %d )", -2*BrushSizeZ);	//+10 to go underneath
				getWallTextureName(t,fBOTTOM,t.isWater);
				printf ("}\n}\n");
			}
			}
		else
			{
				BrushZ = (float)BrushSizeZ*steepness ; BrushX = (float)BrushSizeX;
				angle = atan((float)(BrushX/(BrushZ)));
				//((+x) + ((CEILING_HEIGHT-ceilingHeight)/steepness))
				normalDist = (cos(atan((BrushZ)/(BrushX)))) * ((-x) - ((CEILING_HEIGHT-ceilingHeight)/steepness)) * BrushZ  ;	
				
				printf("// primitive %d\n",PrimitiveCount++);
				printf("{\nbrushDef3\n{\n");
				//East face
				printf ("( 1 0 0 %d )",-((x+t.DimX)*BrushSizeX));
				getWallTextureName(t,fEAST,t.isWater);
				//North face
				printf ("( 0 1 0 %d )",-((y+t.DimY)*BrushSizeY));
				getWallTextureName(t,fNORTH,t.isWater);
				//Top face
				printf ("( 0 0 1 %d )", -(CEILING_HEIGHT+1)*BrushSizeZ);					
				getFloorTextureName(t,fTOP);
				//West face
				printf ("( -1 0 0 %d )", +((x)*BrushSizeX));
				getWallTextureName(t,fWEST,t.isWater);
				//South face
				printf ("( 0 -1 0 %d )", +((y)*BrushSizeY));
				getWallTextureName(t, fSOUTH,t.isWater);
				//Bottom face
				printf ("( %f 0 %f %f )", -cos(angle),-sin(angle),-normalDist);
				getFloorTextureName(t,fCEIL);
				printf ("}\n}\n");			
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
			printf("// primitive %d\n",PrimitiveCount++);
			printf("{\nbrushDef3\n{\n");
			//East face
			printf ("( 1 0 0 %d )",-((x+t.DimX)*BrushSizeX));
			getWallTextureName(t,fEAST,t.isWater );
			//North face 
			printf ("( 0 1 0 %d )",-((y+t.DimY)*BrushSizeY));
			getWallTextureName(t,fNORTH,t.isWater );
			//Top face
			printf ("( -%f 0 %f %f )", cos(angle),sin(angle),-normalDist);	
			getFloorTextureName(t,fTOP);
			//West face
			printf ("( -1 0 0 %d )", +((x)*BrushSizeX));
			getWallTextureName(t,fWEST,t.isWater );
			//South face
			printf ("( 0 -1 0 %d )", +((y)*BrushSizeY));
			getWallTextureName(t,fSOUTH,t.isWater );
			//Bottom face
			printf ("( 0 0 -1 %d )", -2*BrushSizeZ);
			getWallTextureName(t,fBOTTOM,t.isWater );
			printf ("}\n}\n");
			}
		}
	else
		{
		BrushZ = (float)BrushSizeZ*steepness; BrushX = (float)BrushSizeX;
		angle = atan((float)(BrushX/BrushZ));
		normalDist = (cos(atan(BrushZ/BrushX))) * ((+x+1) - ((CEILING_HEIGHT-ceilingHeight)/steepness)) * BrushZ;	
			printf("// primitive %d\n",PrimitiveCount++);
			printf("{\nbrushDef3\n{\n");
			//East face
			printf ("( 1 0 0 %d )",-((x+t.DimX)*BrushSizeX));
			getWallTextureName(t,fEAST,t.isWater);
			//North face
			printf ("( 0 1 0 %d )",-((y+t.DimY)*BrushSizeY));
			getWallTextureName(t,fNORTH,t.isWater);
			//Top face
			printf ("( 0 0 1 %d )", -(CEILING_HEIGHT+1)*BrushSizeZ);				
			getFloorTextureName(t,fTOP);
			//West face
			printf ("( -1 0 0 %d )", +((x)*BrushSizeX));
			getWallTextureName(t,fWEST,t.isWater);
			//South face
			printf ("( 0 -1 0 %d )", +((y)*BrushSizeY));
			getWallTextureName(t, fSOUTH,t.isWater);
			//Bottom face
			printf ("( %f 0 %f %f )", cos(angle),-sin(angle),-normalDist);
			getFloorTextureName(t,fCEIL);
			printf ("}\n}\n");
					
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
				printf("// primitive %d\n",PrimitiveCount++);
				printf("{\nbrushDef3\n{\n");
				//East face
				printf ("( 1 0 0 %d )",-((x+t.DimX)*BrushSizeX));
				getWallTextureName(t,fEAST,t.isWater );
				//North face
				printf ("( 0 1 0 %d )",-((y+t.DimY)*BrushSizeY));
				getWallTextureName(t, fNORTH,t.isWater );
				//Top face
				printf ("( 0 %f %f %f )", -cos(angle), sin(angle),-normalDist);	
				getFloorTextureName(t,fTOP );
				//West face
				printf ("( -1 0 0 %d )", +((x)*BrushSizeX));
				getWallTextureName(t,fWEST,t.isWater );
				//South face
				printf ("( 0 -1 0 %d )", +((y)*BrushSizeY));
				getWallTextureName(t,fSOUTH,t.isWater );
				//Bottom face
				printf ("( 0 0 -1 %d )", -2*BrushSizeZ);
				getWallTextureName(t,fBOTTOM,t.isWater );
				
				//the other slope(w)
				BrushZ = (float)BrushSizeZ*steepness; BrushX = (float)BrushSizeX;
				angle = atan((float)(BrushX/BrushZ));
				normalDist = (cos(atan(BrushZ/BrushX))) * ((floorHeight)/steepness+x+1) * BrushZ;	
				printf ("( %f 0 %f %f )", cos(angle),sin(angle),-normalDist);	
				getFloorTextureName(t,fTOP);			
				printf ("}\n}\n");
			}
			}
		else
			{//made of upper slope e and upper slope s
				//render a ceiling version of this tile
				//top and bottom faces move up
				printf("// primitive %d\n",PrimitiveCount++);
				printf("{\nbrushDef3\n{\n");
				//East face
				printf ("( 1 0 0 %d )",-((x+t.DimX)*BrushSizeX));
				getWallTextureName(t,fEAST,t.isWater);
				//North face
				printf ("( 0 1 0 %d ) ",-((y+t.DimY)*BrushSizeY));
				getWallTextureName(t,fNORTH,t.isWater);
				//Top face
				printf ("( 0 0 1 %d )", -( (CEILING_HEIGHT) * BrushSizeZ));	
				getFloorTextureName(t,fTOP);
				//West face
				printf ("( -1 0 0 %d )", +((x)*BrushSizeX));
				getWallTextureName(t,fWEST,t.isWater);
				//South face
				printf ("( 0 -1 0 %d )", +((y)*BrushSizeY));
				getWallTextureName(t,fSOUTH,t.isWater);
				//Bottom face 
				//s and e here
				float ceilingHeight = CEILING_HEIGHT - t.ceilingHeight;
				BrushZ = (float)BrushSizeZ*steepness; BrushY = (float)BrushSizeY;
				angle = atan((float)(BrushY/BrushZ));
				normalDist = (cos(atan(BrushZ/BrushY))) * ((ceilingHeight/steepness) +y) * BrushZ;
				printf ("( 0 %f %f %f )", -cos(angle), -sin(angle),+normalDist);
				getFloorTextureName(t, fCEIL );

                 ceilingHeight =  t.ceilingHeight ;
				BrushZ = (float)BrushSizeZ*steepness; BrushX = (float)BrushSizeX;
				angle = atan((float)(BrushX/BrushZ));
				normalDist = (cos(atan(BrushZ/BrushX))) * ((+x+1) - ((CEILING_HEIGHT-ceilingHeight)/steepness)) * BrushZ;
				printf ("( %f 0 %f %f )", cos(angle),-sin(angle),-normalDist);
				getWallTextureName(t,fCEIL,t.isWater);

				printf ("}\n}\n");				
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
			printf("// primitive %d\n",PrimitiveCount++);
			printf("{\nbrushDef3\n{\n");
			//East face
			printf ("( 1 0 0 %d )",-((x+t.DimX)*BrushSizeX));
			getWallTextureName(t,fEAST,t.isWater );
			//North face
			printf ("( 0 1 0 %d )",-((y+t.DimY)*BrushSizeY));
			getWallTextureName(t, fNORTH,t.isWater );
			//Top face
			printf ("( 0 %f %f %f )", -cos(angle), sin(angle),-normalDist);	
			getFloorTextureName(t,fTOP );
			//West face
			printf ("( -1 0 0 %d )", +((x)*BrushSizeX));
			getWallTextureName(t,fWEST,t.isWater );
			//South face
			printf ("( 0 -1 0 %d )", +((y)*BrushSizeY));
			getWallTextureName(t,fSOUTH,t.isWater );
			//Bottom face
			printf ("( 0 0 -1 %d )", -2*BrushSizeZ);
			getWallTextureName(t,fBOTTOM,t.isWater );
			
			//slope e
			BrushZ = (float)BrushSizeZ*steepness ; BrushX = (float)BrushSizeX;
			angle = atan((float)(BrushX/(BrushZ)));
			normalDist = (cos(atan((BrushZ)/(BrushX)))) * ((floorHeight/steepness) -(x)) * BrushZ  ;						
			printf ("( -%f 0 %f %f )", cos(angle),sin(angle),-normalDist);	
			getFloorTextureName(t,fTOP);			
			printf ("}\n}\n");
		}
		}
	else
		{//invert is south and west slopes
		
			//render a ceiling version of this tile
			//top and bottom faces move up
			printf("// primitive %d\n",PrimitiveCount++);
			printf("{\nbrushDef3\n{\n");
			//East face
			printf ("( 1 0 0 %d )",-((x+t.DimX)*BrushSizeX));
			getWallTextureName(t,fEAST,t.isWater);
			//North face
			printf ("( 0 1 0 %d ) ",-((y+t.DimY)*BrushSizeY));
			getWallTextureName(t,fNORTH,t.isWater);
			//Top face
			printf ("( 0 0 1 %d )", -( (CEILING_HEIGHT) * BrushSizeZ));	
			getFloorTextureName(t,fTOP);
			//West face
			printf ("( -1 0 0 %d )", +((x)*BrushSizeX));
			getWallTextureName(t,fWEST,t.isWater);
			//South face
			printf ("( 0 -1 0 %d )", +((y)*BrushSizeY));
			getWallTextureName(t,fSOUTH,t.isWater);
			//Bottom face
			//s
				float ceilingHeight = CEILING_HEIGHT - t.ceilingHeight;
				BrushZ = (float)BrushSizeZ*steepness; BrushY = (float)BrushSizeY;
				angle = atan((float)(BrushY/BrushZ));
				normalDist = (cos(atan(BrushZ/BrushY))) * ((ceilingHeight/steepness) +y) * BrushZ;
				printf ("( 0 %f %f %f )", -cos(angle), -sin(angle),+normalDist);
				getFloorTextureName(t, fCEIL );	
			//w
				ceilingHeight =  t.ceilingHeight ;	
				BrushZ = (float)BrushSizeZ*steepness ; BrushX = (float)BrushSizeX;
				angle = atan((float)(BrushX/(BrushZ)));
				normalDist = (cos(atan((BrushZ)/(BrushX)))) * ((-x) - ((CEILING_HEIGHT-ceilingHeight)/steepness)) * BrushZ  ;
				printf ("( %f 0 %f %f )", -cos(angle),-sin(angle),-normalDist);
				getFloorTextureName(t,fCEIL);
			printf ("}\n}\n");		
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
		printf("// primitive %d\n",PrimitiveCount++);
		printf("{\nbrushDef3\n{\n");
		//East face
		printf ("( 1 0 0 %d )",-((x+t.DimX)*BrushSizeX));
		getWallTextureName(t,fEAST,t.isWater );
		//North face
		printf ("( 0 1 0 %d )",-((y+t.DimY)*BrushSizeY));
		getWallTextureName(t,fNORTH,t.isWater );
		//Top face
		printf ("( 0 %f %f %f )", cos(angle), sin(angle),-normalDist);	
		getFloorTextureName(t,fTOP );
		//West face
		printf ("( -1 0 0 %d )", +((x)*BrushSizeX));
		getWallTextureName(t,fWEST,t.isWater );
		//South face
		printf ("( 0 -1 0 %d )", +((y)*BrushSizeY));
		getWallTextureName(t,fSOUTH,t.isWater );
		//Bottom face +absdist
		printf ("( 0 0 -1 %d )", -2*BrushSizeZ);	//+10 to go underneath
		getWallTextureName(t,fBOTTOM,t.isWater );
		
		//slope w
		BrushZ = (float)BrushSizeZ*steepness; BrushX = (float)BrushSizeX;
		angle = atan((float)(BrushX/BrushZ));
		normalDist = (cos(atan(BrushZ/BrushX))) * ((floorHeight)/steepness+x+1) * BrushZ;	
		printf ("( %f 0 %f %f )", cos(angle),sin(angle),-normalDist);	
		getFloorTextureName(t,fTOP);				
		printf ("}\n}\n");
		}
	}
	}
	else
	{	//invert is n and w slopes
				//render a ceiling version of this tile
				printf("// primitive %d\n",PrimitiveCount++);
				printf("{\nbrushDef3\n{\n");
				//East face
				printf ("( 1 0 0 %d )",-((x+t.DimX)*BrushSizeX));
				getWallTextureName(t,fEAST,t.isWater);
				//North face
				printf ("( 0 1 0 %d ) ",-((y+t.DimY)*BrushSizeY));
				getWallTextureName(t,fNORTH,t.isWater);
				//Top face
				printf ("( 0 0 1 %d )", -( (CEILING_HEIGHT) * BrushSizeZ));	
				getFloorTextureName(t,fTOP);
				//West face
				printf ("( -1 0 0 %d )", +((x)*BrushSizeX));
				getWallTextureName(t,fWEST,t.isWater);
				//South face
				printf ("( 0 -1 0 %d )", +((y)*BrushSizeY));
				getWallTextureName(t,fSOUTH,t.isWater);
				//Bottom faces
				//e
                 float ceilingHeight =  t.ceilingHeight ;
				BrushZ = (float)BrushSizeZ*steepness; BrushX = (float)BrushSizeX;
				angle = atan((float)(BrushX/BrushZ));
				normalDist = (cos(atan(BrushZ/BrushX))) * ((+x+1) - ((CEILING_HEIGHT-ceilingHeight)/steepness)) * BrushZ;
				printf ("( %f 0 %f %f )", cos(angle),-sin(angle),-normalDist);
				getFloorTextureName(t,fCEIL);
				
				//n
                ceilingHeight = (CEILING_HEIGHT -(t.ceilingHeight)) ;
				BrushZ = (float)BrushSizeZ*steepness; BrushY = (float)BrushSizeY;
				angle = atan((float)(BrushY/BrushZ));
				normalDist = (cos(atan(BrushZ/BrushY))) * ((ceilingHeight/steepness)-y-1) * BrushZ;
                printf ("( 0 %f %f %f )", cos(angle), -sin(angle),+normalDist);			
				getFloorTextureName(t,fCEIL);
				printf ("}\n}\n");				
	
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
		printf("// primitive %d\n",PrimitiveCount++);
		printf("{\nbrushDef3\n{\n");
		//East face
		printf ("( 1 0 0 %d )",-((x+t.DimX)*BrushSizeX));
		getWallTextureName(t,fEAST,t.isWater );
		//North face
		printf ("( 0 1 0 %d )",-((y+t.DimY)*BrushSizeY));
		getWallTextureName(t,fNORTH,t.isWater );
		//Top face
		printf ("( 0 %f %f %f )", cos(angle), sin(angle),-normalDist);	
		getFloorTextureName(t,fTOP );
		//West face
		printf ("( -1 0 0 %d )", +((x)*BrushSizeX));
		getWallTextureName(t,fWEST,t.isWater );
		//South face
		printf ("( 0 -1 0 %d )", +((y)*BrushSizeY));
		getWallTextureName(t,fSOUTH,t.isWater );
		//Bottom face +absdist
		printf ("( 0 0 -1 %d )", -2*BrushSizeZ);	//+10 to go underneath
		getWallTextureName(t,fBOTTOM,t.isWater );

		//Other sloped face
		BrushZ = (float)BrushSizeZ*steepness ; BrushX = (float)BrushSizeX;
		angle = atan((float)(BrushX/(BrushZ)));
		normalDist = (cos(atan((BrushZ)/(BrushX)))) * ((floorHeight/steepness) -(x)) * BrushZ  ;	
		printf ("( -%f 0 %f %f )", cos(angle),sin(angle),-normalDist);	
		getFloorTextureName(t,fTOP);		
		
		printf ("}\n}\n");
		}
	}
	else
		{//invert is n w
				//render a ceiling version of this tile
				//top and bottom faces move up
				printf("// primitive %d\n",PrimitiveCount++);
				printf("{\nbrushDef3\n{\n");
				//East face
				printf ("( 1 0 0 %d )",-((x+t.DimX)*BrushSizeX));
				getWallTextureName(t,fEAST,t.isWater);
				//North face
				printf ("( 0 1 0 %d ) ",-((y+t.DimY)*BrushSizeY));
				getWallTextureName(t,fNORTH,t.isWater);
				//Top face
				printf ("( 0 0 1 %d )", -( (CEILING_HEIGHT) * BrushSizeZ));	
				getFloorTextureName(t,fTOP);
				//West face
				printf ("( -1 0 0 %d )", +((x)*BrushSizeX));
				getWallTextureName(t,fWEST,t.isWater);
				//South face
				printf ("( 0 -1 0 %d )", +((y)*BrushSizeY));
				getWallTextureName(t,fSOUTH,t.isWater);
				//Bottom face
				//w
				float ceilingHeight =  t.ceilingHeight ;
				BrushZ = (float)BrushSizeZ*steepness ; BrushX = (float)BrushSizeX;
				angle = atan((float)(BrushX/(BrushZ)));
				normalDist = (cos(atan((BrushZ)/(BrushX)))) * ((-x) - ((CEILING_HEIGHT-ceilingHeight)/steepness)) * BrushZ  ;
				printf ("( %f 0 %f %f )", -cos(angle),-sin(angle),-normalDist);
				getFloorTextureName(t,fCEIL);	
				
				//n			
				ceilingHeight = (CEILING_HEIGHT -(t.ceilingHeight)) ;
				BrushZ = (float)BrushSizeZ*steepness; BrushY = (float)BrushSizeY;
				angle = atan((float)(BrushY/BrushZ));
				normalDist = (cos(atan(BrushZ/BrushY))) * ((ceilingHeight/steepness)-y-1) * BrushZ;
                printf ("( 0 %f %f %f )", cos(angle), -sin(angle),+normalDist);
                getFloorTextureName(t,fCEIL);	
				printf ("}\n}\n");		
		}
	}
return;
}


void RenderDoorway(int game,int x,int y, tile &t , ObjectItem currDoor)
{
int doorWidth=48;
int doorHeight =96;

//TODO:Define door widths in config file. For the moment width is 50. height is 100
int offX= (x*BrushSizeX) + ((currDoor.x) * (BrushSizeX/7));//from obj position code
int offY= (y*BrushSizeY) + ((currDoor.y) * (BrushSizeY/7));

switch (currDoor.heading)
	{
	case EAST:
	case WEST:	//east west
		{
		
			//if(currDoor.heading == EAST) {offY =offY+DOORORIGINOFFSET;}else{offY =offY+DOORORIGINOFFSET;}
		if(currDoor.heading == EAST) 
			{offY =(y*BrushSizeY)+((BrushSizeY-doorWidth)/2)+doorWidth;}
		else
			{offY = (y*BrushSizeY)+((BrushSizeY-doorWidth)/2);}			
		//left side
			printf("// primitive %d\n",PrimitiveCount++);
			printf("{\nbrushDef3\n{\n");
			//east face 
			printf ("( 1 0 0 %d )",-((offX+2)));
			getWallTextureName(t,fEAST,0);
			//north face 
			printf ("( 0 1 0 %d )",-((y+1)*BrushSizeY));
			getWallTextureName(t,fNORTH,0);
			//top face
			printf ("( 0 0 1 %d )", -(t.floorHeight*BrushSizeZ + doorHeight) );	
			getFloorTextureName(t,fTOP);
			//west face
			printf ("( -1 0 0 %d )", +((offX-2)));
			getWallTextureName(t,fWEST,0);
			//south face
			if (currDoor.heading == EAST)
				{printf ("( 0 -1 0 %d )", +(offY));}
			else
				printf ("( 0 -1 0 %d )", +(offY)+doorWidth);
			
			getWallTextureName(t, fSOUTH,0);
			//bottom face
			printf ("( 0 0 -1 %d )", t.floorHeight*BrushSizeZ);	
			getFloorTextureName(t, fBOTTOM);
			//printf("0"); 
			printf ("}\n}\n");		
		
		//over the door
			printf("// primitive %d\n",PrimitiveCount++);
			printf("{\nbrushDef3\n{\n");
			//east face 
			printf ("( 1 0 0 %d )",-((offX+2)));
			getWallTextureName(t,fEAST,0);
			//north face 
			printf ("( 0 1 0 %d )",-((y+1)*BrushSizeY));
			getWallTextureName(t,fNORTH,0);
			//top face
			printf ("( 0 0 1 %d )", -BrushSizeZ * (CEILING_HEIGHT+1) );	
			getFloorTextureName(t,fTOP);
			//west face
			printf ("( -1 0 0 %d )", +((offX-2)));
			getWallTextureName(t,fWEST,0);
			//south face
			printf ("( 0 -1 0 %d )", +(y*BrushSizeY));
			getWallTextureName(t, fSOUTH,0);
			//bottom face
			printf ("( 0 0 -1 %d )", (t.floorHeight*BrushSizeZ)+doorHeight);	
			getFloorTextureName(t, fBOTTOM);
			//printf("0"); 
			printf ("}\n}\n");			
	
		// right side
			printf("// primitive %d\n",PrimitiveCount++);
			printf("{\nbrushDef3\n{\n");
			//east face 
			printf ("( 1 0 0 %d )",-((offX+2)));
			getWallTextureName(t,fEAST,0);
			//north face 
			if (currDoor.heading == EAST)
				{
				printf ("( 0 1 0 %d )",-(offY-doorWidth));	
				}
			else
				{
				printf ("( 0 1 0 %d )",-(offY));
				}			
			getWallTextureName(t,fNORTH,0);
			//top face
			printf ("( 0 0 1 %d )", -(t.floorHeight*BrushSizeZ + doorHeight) );
			getFloorTextureName(t,fTOP);
			//west face
			printf ("( -1 0 0 %d )", +((offX-2)));
			getWallTextureName(t,fWEST,0);
			//south face
			printf ("( 0 -1 0 %d )", +(y * BrushSizeY));
			getWallTextureName(t, fSOUTH,0);
			//bottom face
			printf ("( 0 0 -1 %d )", t.floorHeight*BrushSizeZ);	
			getFloorTextureName(t, fBOTTOM);
			//printf("0"); 
			printf ("}\n}\n");			
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
			printf("// primitive %d\n",PrimitiveCount++);
			printf("{\nbrushDef3\n{\n");
			//east face 
			printf ("( 1 0 0 %d )",-((offX+2)));
			getWallTextureName(Tmpt,fEAST,0);
			//north face 
			if (currDoor.heading == EAST)
				{
				printf ("( 0 1 0 %d )",-((offY)));
				}
			else
				{
				printf ("( 0 1 0 %d )",-((offY+doorWidth)));
				}
			getWallTextureName(Tmpt,fNORTH,0);
			//top face
			printf ("( 0 0 1 %d )", -((t.floorHeight*BrushSizeZ)+doorHeight) );	
			getWallTextureName(Tmpt,fTOP,0);
			//west face
			printf ("( -1 0 0 %d )", +((offX-1)));
			getWallTextureName(Tmpt,fWEST,0);
			//south face
			if (currDoor.heading == EAST)
				{
				printf ("( 0 -1 0 %d )", +(offY-doorWidth));
				}
			else
				{
				printf ("( 0 -1 0 %d )", +(offY));
				}
			getWallTextureName(Tmpt, fSOUTH,0);
			//bottom face
			printf ("( 0 0 -1 %d )", (t.floorHeight*BrushSizeZ));	
			getWallTextureName(Tmpt, fBOTTOM,0);
			//printf("0"); 
			printf ("}\n}\n");			
		}
			break;
			
		}
	case NORTH:	//north south (0)
	case SOUTH:
		{
		
		if (currDoor.heading==NORTH)
			{offX = (x*BrushSizeX)+((BrushSizeX-doorWidth)/2)+doorWidth;}
		else
			{offX = (x*BrushSizeX)+((BrushSizeX-doorWidth)/2);}
		//left side
			printf("// primitive %d\n",PrimitiveCount++);
			printf("{\nbrushDef3\n{\n");
			//east face 
			if (currDoor.heading == NORTH)
				{
				printf ("( 1 0 0 %d )",-(offX-doorWidth));
								
				}
			else
				{
				printf ("( 1 0 0 %d )",-(offX));		
				}
			
			getWallTextureName(t,fEAST,0);
			//north face 
			printf ("( 0 1 0 %d )",-(offY+2));
			getWallTextureName(t,fNORTH,0);
			//top face
			printf ("( 0 0 1 %d )", -(t.floorHeight*BrushSizeZ + doorHeight) );	
			getFloorTextureName(t,fTOP);
			//west face
			printf ("( -1 0 0 %d )", +((x)*BrushSizeX));
			getWallTextureName(t,fWEST,0);
			//south face
			printf ("( 0 -1 0 %d )", +(offY-2));
			getWallTextureName(t, fSOUTH,0);
			//bottom face
			printf ("( 0 0 -1 %d )", t.floorHeight * BrushSizeZ);	//to go underneath
			getFloorTextureName(t, fBOTTOM);
			//printf("0"); 
			printf ("}\n}\n");
		//top
			printf("// primitive %d\n",PrimitiveCount++);
			printf("{\nbrushDef3\n{\n");
			//east face 
			printf ("( 1 0 0 %d )",-((x+1)*BrushSizeX));
			getWallTextureName(t,fEAST,0);
			//north face 
			printf ("( 0 1 0 %d )",-(offY+2));
			getWallTextureName(t,fNORTH,0);
			//top face
			printf ("( 0 0 1 %d )", -BrushSizeZ * (CEILING_HEIGHT+1) );	
			getFloorTextureName(t,fTOP);
			//west face
			printf ("( -1 0 0 %d )", +(x*BrushSizeX));
			getWallTextureName(t,fWEST,0);
			//south face
			printf ("( 0 -1 0 %d )", +(offY-2));
			getWallTextureName(t, fSOUTH,0);
			//bottom face
			printf ("( 0 0 -1 %d )", (t.floorHeight*BrushSizeZ) +doorHeight);	//to go underneath
			getFloorTextureName(t, fBOTTOM);
			//printf("0"); 
			printf ("}\n}\n");
		//right
			printf("// primitive %d\n",PrimitiveCount++);
			printf("{\nbrushDef3\n{\n");
			//east face 
			printf ("( 1 0 0 %d )",-((x+1)*BrushSizeX));
			getWallTextureName(t,fEAST,0);
			//north face 
			printf ("( 0 1 0 %d )",-(offY+2));
			getWallTextureName(t,fNORTH,0);
			//top face
			printf ("( 0 0 1 %d )", -(t.floorHeight*BrushSizeZ + doorHeight) );	
			getFloorTextureName(t,fTOP);
			//west face
			if (currDoor.heading == NORTH)
				{
				printf ("( -1 0 0 %d )", +(offX ));
				}
			else
				{
				printf ("( -1 0 0 %d )", +(offX +doorWidth ));
				}
			getWallTextureName(t,fWEST,0);
			//south face
			printf ("( 0 -1 0 %d )", +(offY-2));
			getWallTextureName(t, fSOUTH,0);
			//bottom face
			printf ("( 0 0 -1 %d )", t.floorHeight * BrushSizeZ);	//to go underneath
			getFloorTextureName(t, fBOTTOM);
			//printf("0"); 
			printf ("}\n}\n");
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
			printf("// primitive %d\n",PrimitiveCount++);
			printf("{\nbrushDef3\n{\n");
			//east face 
			if (currDoor.heading == NORTH)
				{
				printf ("( 1 0 0 %d )",-(offX));	
				}
			else
				{
				printf ("( 1 0 0 %d )",-(offX +doorWidth));	
				}
			getWallTextureName(Tmpt,fEAST,0);
			//north face 
			printf ("( 0 1 0 %d )",-(offY+2));
			getWallTextureName(Tmpt,fNORTH,0);
			//top face
			printf ("( 0 0 1 %d )", -(t.floorHeight*BrushSizeZ + doorHeight));	
			getFloorTextureName(Tmpt,fTOP);
			//west face
			if (currDoor.heading==NORTH)
				{
				printf ("( -1 0 0 %d )", +(offX-doorWidth));
				}
			else
				{
				printf ("( -1 0 0 %d )", +(offX));
				}
			getWallTextureName(Tmpt,fWEST,0);
			//south face
			printf ("( 0 -1 0 %d )", +(offY-2));
			getWallTextureName(Tmpt, fSOUTH,0);
			//bottom face
			printf ("( 0 0 -1 %d )", (t.floorHeight*BrushSizeZ));	//to go underneath
			getFloorTextureName(Tmpt, fBOTTOM);
			//printf("0"); 
			printf ("}\n}\n");
			}			
		}
	}
}
void RenderPatch(int game, int x, int y, int z,long PatchIndex, ObjectItem objList[1025] )
{
ObjectItem currobj = objList[PatchIndex];

float patchX;float patchY;float patchZ;float patchOffsetX;float patchOffsetY;
float offX= (x*BrushSizeX) + ((objList[PatchIndex].x) * (BrushSizeX/7));
float offY= (y*BrushSizeY) + ((objList[PatchIndex].y) * (BrushSizeY/7));

if ((objList[PatchIndex].x ==0) ||(objList[PatchIndex].x ==7) )
	{
	offY= objList[PatchIndex].tileY * BrushSizeY+ (BrushSizeY/2);
	}
if ((objList[PatchIndex].y ==0) || (objList[PatchIndex].y ==7))
	{
	offX= objList[PatchIndex].tileX * BrushSizeX+ (BrushSizeX/2);
	}
//float offX= objList[PatchIndex].tileX * BrushSizeX + (BrushSizeX/2);
//float offY= objList[PatchIndex].tileY * BrushSizeY+ (BrushSizeY/2);
float floorHeight = LevelInfo[x][y].floorHeight <<3 ;
float nextFloorHeight =(LevelInfo[x][y].floorHeight+1) <<3 ;
float relativeZpos = objList[PatchIndex].zpos - floorHeight;
float zposRatio = relativeZpos/(nextFloorHeight-floorHeight);	//relative adjustment
float offZ = LevelInfo[x][y].floorHeight * BrushSizeZ + (zposRatio*BrushSizeZ);
float tex1 = -1; float tex2 =-1;	//target values
	switch (currobj.heading)
		{
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
	//printf("\"name\" \"%s_%03d_%03d\"",objectMasters[currobj.item_id].desc,currobj.tileX,currobj.tileY );
	//printf("\"model\" \"%s_%03d_%03d\"",objectMasters[currobj.item_id].desc,currobj.tileX,currobj.tileY );
	//Things like the abyss doors,stairs down//a patch?
	printf("\n//primitive %d\n{\npatchDef2\n{\n",0);
	printf("\"%s\"\n",textureMasters[currobj.owner].path);
	printf("( 3 5 0 0 0 )\n(\n");	//not sure what they mean but they appear to stay constant?
	for (int j= 0; j <3; j++)
		{
		printf("(");
		for (int i=0; i<=4;i++)
			{
			//x y z texture param1 textureparam 2
			printf(" ( %f %f %f %f %f )" ,offX+patchOffsetX + i*(patchX/4), offY+patchOffsetY + i*(patchY/4), offZ+j*(patchZ/3),i*(tex1/4),j*(tex2/2));
			}
			printf(" )\n");
		}
	printf(")\n}\n}\n");
				}
				
void RenderElevatorLeakProtection(int game, tile LevelInfo[64][64])
	{
	//First render the enclosing brush under the map to stop it leaking.
	for (int y=0; y<=63;y++) 
		{
		for (int x=0; x<=63;x++)
			{
			if (LevelInfo[x][y].hasElevator == 1)
				{
				tile t=LevelInfo[x][y];
				printf ("\n");
				printf("// primitive %d\n",PrimitiveCount++);
				printf("{\nbrushDef3\n{\n");
				//east face 
				printf ("( 1 0 0 %d )",-((x+t.DimX)*BrushSizeX)-10);
				getWallTextureName(t,fEAST,0);
				//north face 
				printf ("( 0 1 0 %d )",-((y+t.DimY)*BrushSizeY)-10);
				getWallTextureName(t,fNORTH,0);
				//top face
				printf ("( 0 0 1 %d )", +1 );	
				getFloorTextureName(t,fTOP);
				//west face
				printf ("( -1 0 0 %d )", +((x)*BrushSizeX)-10);
				getWallTextureName(t,fWEST,0);
				//south face
				printf ("( 0 -1 0 %d )", +((y)*BrushSizeY)-10);
				getWallTextureName(t, fSOUTH,0);
				//bottom face
				printf ("( 0 0 -1 %d )", -32*BrushSizeZ);	
				getFloorTextureName(t, fBOTTOM);
				//printf("0"); 
				printf ("}\n}\n");
				}
			}
		}
	}

void RenderElevator(int game, tile LevelInfo[64][64], ObjectItem objList[1025])		
{
	for (int y=0; y<=63;y++) 
		{
		for (int x=0; x<=63;x++)
			{
			if (LevelInfo[x][y].hasElevator==1)
				{
				//objList[LevelInfo[x][y].ElevatorIndex].tileX=x;
				//objList[LevelInfo[x][y].ElevatorIndex].tileY=y;
				//printf("\n// entity %d\n{\n",EntityCount);
				//printf("\"classname\" \"func_mover\"\n");
				//printf("\"name\" \"elevator_%02d_%02d\"\n",x,y);
				//printf("\"model\" \"elevator_%02d_%02d\"\n",x,y);
				//PrimitiveCount=0;
				//int floor =LevelInfo[x][y].floorHeight;
				////LevelInfo[x][y].floorHeight = -8;	
				//RenderDarkModTile(game,x,y,LevelInfo[x][y],0,0);
				//LevelInfo[x][y].floorHeight = floor;
				//printf("\n}");
				//EntityCount++;
				}	
			}
		}
}

void RenderGenericTile(int x, int y, tile &t, int iCeiling ,int iFloor)
{
	printf("// primitive %d\n",PrimitiveCount++);
	printf("{\nbrushDef3\n{\n");
	//East face
	printf ("( 1 0 0 %d )",-((x+t.DimX)*BrushSizeX));
	getWallTextureName(t,fEAST,t.isWater);
	//North face
	printf ("( 0 1 0 %d ) ",-((y+t.DimY)*BrushSizeY));
	getWallTextureName(t,fNORTH,t.isWater);
	//Top face
	printf ("( 0 0 1 %d )", -( (iCeiling) * BrushSizeZ) );	
	getFloorTextureName(t,fTOP);
	//West face
	printf ("( -1 0 0 %d )", +((x)*BrushSizeX));
	getWallTextureName(t,fWEST,t.isWater);
	//South face
	printf ("( 0 -1 0 %d )", +((y)*BrushSizeY));
	getWallTextureName(t,fSOUTH,t.isWater);
	//Bottom face 
	printf ("( 0 0 -1 %d ) ", iFloor*BrushSizeZ);	
	getFloorTextureName(t,fBOTTOM);
	printf ("}\n}\n");
}

void RenderLevelExits(int game, tile LevelInfo[64][64], ObjectItem objList[1025])
	{
	int i;
	//go through the objects and find teleport traps with a zpos !=0
	for (i=0; i<1024;i++)
		{
		if ((isTrigger(objList[i])) && (objectMasters[objList[objList[i].link].item_id ].type == A_TELEPORT_TRAP))
			if ((objList[objList[i].link].zpos !=0))	//Trap goes to another level
				{
				//first a trigger to reference in scripting.
				printf("// entity %d\n", EntityCount++);
				printf("{\n\"classname\" \"trigger_relay\"");
				printf("\"name\" \"%s_%03d_%03d\"\n","trigger_endlevel" ,objList[i].tileX,objList[i].tileY);		
				printf("\n\"origin\" \"2500 2500 120\"\n");
				printf("\"target\" \"%s_%03d_%03d\"\n","endlevel" ,objList[i].tileX,objList[i].tileY);		
				printf("}\n");	
				
				printf("// entity %d\n", EntityCount++);
				printf("{\n\"classname\" \"target_endlevel\"\n");
				printf("\"name\" \"%s_%03d_%03d\"\n","endlevel" ,objList[i].tileX,objList[i].tileY);		
				printf("\n\"origin\" \"2500 2500 120\"\n");
				switch (game)
					{
					case UWDEMO:
						printf("\n\"nextmap\" \"%s\"\n", "NO_SUCH_LEVEL");break;	
					case UW1:
						printf("\n\"nextmap\" \"%s_%d\"\n","uw1", objList[objList[i].link].zpos-1);	break;
					case UW2:
						printf("\n\"nextmap\" \"%s_%d\"\n","uw2",objList[objList[i].link].zpos-1);	break;
					case SHOCK:
						printf("\n\"nextmap\" \"%s_%d\"\n","shock", objList[objList[i].link].zpos-1);	break;
					}
				printf("}\n");				
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
				printf("// entity %d\n", EntityCount++);
				printf("{\n\"classname\" \"func_teleporter\"");
				printf("\"name\" \"%s_%03d_%03d\"\n","entrance" ,tileX,tileY);		
				printf("\n\"origin\" \"%d %d %d\"", tileX * BrushSizeX+(BrushSizeX/2),tileY*BrushSizeY+(BrushSizeY/2),(LevelInfo[tileX][tileY].floorHeight)* BrushSizeZ + 30);		
				printf("}\n");	
			}
		}
		fclose(f);
	}
}

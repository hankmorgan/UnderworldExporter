
#include "utils.h"
#include "main.h"
#include "textures.h"
#include "gameobjects.h"
#include "tilemap.h"
////#include "stb-master\stb_tilemap_editor.h"
//typedef unsigned int uint;
//      void STBTE_DRAW_RECT(int x0, int y0, int x1, int y1, int color);
//      // this must draw a filled rectangle (exclusive on right/bottom)
//      // color = (r<<16)|(g<<8)|(b)
//      
//      void STBTE_DRAW_TILE(int x0, int y0,
//                    unsigned short id, int highlight, float *data);
//      // this draws the tile image identified by 'id' in one of several
//      // highlight modes (see STBTE_drawmode_* in the header section);
//      // if 'data' is NULL, it's drawing the tile in the palette; if 'data'
//      // is not NULL, it's drawing a tile on the map, and that is the data
//      // associated with that map tile
//
//#define STB_TILEMAP_EDITOR_IMPLEMENTATION
//#include "stb-master\stb_tilemap_editor.h"

extern long SHOCK_CEILING_HEIGHT;
extern long UW_CEILING_HEIGHT;

int currRoomIndex;

int getTile(int tileData)
{
	//gets tile data at bits 0-3 of the tile data
	return (tileData & 0x0F);
}

int getHeight(int tileData)
{//gets height data at bits 4-7 of the tile data
	return (tileData & 0xF0) >> 4;
}

int getDoors(long tileData)
{//gets door positions at bit 15 of the tile data
	return (tileData>>15 & 0x01);
}

int getFloorTex(unsigned char *buffer, long textureOffset, long tileData)
{//gets floor texture data at bits 10-13 of the tile data
	int val = (tileData >>10) & 0x0F;	//gets the index of the texture
//look it up in texture block for it's absolute index for wxx.tr
	return getValAtAddress(buffer,textureOffset+96+(val*2),16) +210;			//96 needed?
	//	return ((tileData >>10) & 0x0F);	//was	11
}

int getWallTex(unsigned char *buffer, long textureOffset, long tileData)
{
//gets wall texture data at bits 0-5 (+16) of the tile data(2nd part)
	//return ((tileData >>17)& 0x3F);
	int val = (tileData & 0x3F);	//gets the index of the texture
	return getValAtAddress(buffer,textureOffset+(val*2),16);
	//return (tileData& 0x3F);
}

int getFloorTexUw2(unsigned char *buffer, long textureOffset, long tileData)
{//gets floor texture data at bits 10-13 of the tile data
	int val = (tileData >>10) & 0x0F;	//gets the index of the texture
//look it up in texture block for it's absolute index for wxx.tr
	return getValAtAddress(buffer,textureOffset+(val*2),16);	
//	return ((tileData >>10) & 0x0F);	//was	11
}

int getWallTexUw2(unsigned char *buffer, long textureOffset, long tileData)
{
//gets wall texture data at bits 0-5 (+16) of the tile data(2nd part)
	//return ((tileData >>17)& 0x3F);
	int val = (tileData & 0x3F);	//gets the index of the texture
	return getValAtAddress(buffer,textureOffset+(val*2),16);
	//return (tileData& 0x3F);
}


void CleanUp(tile LevelInfo[64][64], int game)
{
	int x; int y;
	

//Reduces tile complexity. Hides hidden solids and merges matching tiles along axis.
	////if (game != SHOCK)
	////{
	////
	////for (x = 1; x<63; x++){
	////	for (y = 1; y<63; y++){
	////		if (LevelInfo[x][y].tileType ==TILE_OPEN)
	////			{
	////			if (LevelInfo[x + 1][y].floorHeight >= LevelInfo[x][y].floorHeight)
	////				{
	////				LevelInfo[x][y].East=CAULK;
	////				}
	////			if (LevelInfo[x-1][y].floorHeight >= LevelInfo[x][y].floorHeight)
	////				{
	////					LevelInfo[x][y].West = CAULK;
	////				}
	////			if (LevelInfo[x][y+1].floorHeight >= LevelInfo[x][y].floorHeight)
	////				{
	////					LevelInfo[x][y].North = CAULK;
	////				}
	////			if (LevelInfo[x][y-1].floorHeight >= LevelInfo[x][y].floorHeight)
	////				{
	////					LevelInfo[x][y].South = CAULK;
	////				}
	////			}
	////		}
	////	}
	////}


	for (x=0;x<64;x++){
		for (y=0;y<64;y++){
	//lets test this tile for visibility
	//A tile is invisible if it only touches other solid tiles and has no objects or does not have a terrain change.
		if ((LevelInfo[x][y].tileType ==0) && (LevelInfo[x][y].indexObjectList == 0)  && (LevelInfo[x][y].TerrainChange == 0)){
				switch (y)
				{
				case 0:	//bottom row
					switch (x)
					{
					case 0:	//bl corner
						if ((LevelInfo[x + 1][y].tileType == 0) && (LevelInfo[x][y + 1].tileType == 0)
						 && (LevelInfo[x + 1][y].TerrainChange == 0) && (LevelInfo[x][y+1].TerrainChange == 0))
						{LevelInfo[x][y].Render =0 ; ;break;}
						else {LevelInfo[x][y].Render =1 ;break;}
					case 63://br corner
						if ((LevelInfo[x - 1][y].tileType == 0) && (LevelInfo[x][y + 1].tileType == 0)
						 && (LevelInfo[x - 1][y].TerrainChange == 0) && (LevelInfo[x][y+1].TerrainChange == 0))
						{LevelInfo[x][y].Render =0 ;break;}
						else {LevelInfo[x][y].Render =1 ;break;}
					default: // invert t
						if ((LevelInfo[x + 1][y].tileType == 0) && (LevelInfo[x][y + 1].tileType == 0) && (LevelInfo[x + 1][y].tileType == 0) 
						&& (LevelInfo[x+1][y].TerrainChange == 0) && (LevelInfo[x][y+1].TerrainChange == 0) && (LevelInfo[x+1][y].TerrainChange == 0))
						{LevelInfo[x][y].Render =0 ;break;}
						else {LevelInfo[x][y].Render =1 ;break;}
					}
					break;
				case 63: //Top row
					switch (x)
					{
					case 0:	//tl corner
						if ((LevelInfo[x + 1][y].tileType == 0) && (LevelInfo[x][y - 1].tileType == 0) 
						&& (LevelInfo[x + 1][y].TerrainChange == 0) && (LevelInfo[x][y-1].TerrainChange == 0))
						{LevelInfo[x][y].Render =0 ;break;}
						else {LevelInfo[x][y].Render =1 ;break;}
					case 63://tr corner
						if ((LevelInfo[x - 1][y].tileType == 0) && (LevelInfo[x][y - 1].tileType == 0) 
						&& (LevelInfo[x - 1][y].TerrainChange == 0) && (LevelInfo[x][y-1].TerrainChange == 0))
						{LevelInfo[x][y].Render =0 ;break;}
						else {LevelInfo[x][y].Render =1 ;break;}
					default: //  t
						if ((LevelInfo[x + 1][y].tileType == 0) && (LevelInfo[x][y - 1].tileType == 0) && (LevelInfo[x - 1][y].tileType == 0) 
						&& (LevelInfo[x + 1][y].TerrainChange == 0) && (LevelInfo[x][y - 1].TerrainChange == 0) && (LevelInfo[x-1][y].TerrainChange == 0))
						{LevelInfo[x][y].Render =0;break;}
						else {LevelInfo[x][y].Render =1 ;break;}
					}	
					break;
				default: //
					switch (x)
					{
					case 0:		//left edge
						if ((LevelInfo[x][y + 1].tileType == 0) && (LevelInfo[x + 1][y].tileType == 0) && (LevelInfo[x][y - 1].tileType == 0) 
							&& (LevelInfo[x][y+1].TerrainChange == 0) && (LevelInfo[x+1][y].TerrainChange == 0) && (LevelInfo[x][y-1].TerrainChange == 0))
						{LevelInfo[x][y].Render =0;break;}
						else {LevelInfo[x][y].Render =1 ;break;}
					case 63:	//right edge
						if ((LevelInfo[x][y + 1].tileType == 0) && (LevelInfo[x - 1][y].tileType == 0) && (LevelInfo[x][y - 1].tileType == 0) 
							&& (LevelInfo[x][y+1].TerrainChange == 0) && (LevelInfo[x-1][y].TerrainChange == 0) && (LevelInfo[x][y-1].TerrainChange == 0))
						{LevelInfo[x][y].Render =0 ;break;}
						else {LevelInfo[x][y].Render =1 ;break;}
					default:		//+
						if ((LevelInfo[x][y + 1].tileType == 0) && (LevelInfo[x + 1][y].tileType == 0) && (LevelInfo[x][y - 1].tileType == 0) && (LevelInfo[x - 1][y].tileType == 0) 
							&& (LevelInfo[x][y + 1].TerrainChange == 0) && (LevelInfo[x + 1][y].TerrainChange == 0) && (LevelInfo[x][y - 1].TerrainChange == 0) && (LevelInfo[x-1][y].TerrainChange == 0))
						{LevelInfo[x][y].Render =0; break;}
						else {LevelInfo[x][y].Render =1 ;break;}
					}
					break;
				}
			}
		}
	}






	//return;
//if (game == SHOCK) {return;}
	int j=1 ;
	//Now lets combine the solids along particular axis
	for (x=0;x<64;x++){
		for (y=0;y<64;y++){
			if ((x == 22) && (y == 52))
				{
				printf("%d\n", LevelInfo[22][52].VisibleFaces[vSOUTH]);
				}
			if  ((LevelInfo[x][y].Grouped ==0))
			{
			j=1;
			while ((LevelInfo[x][y].Render == 1) && (LevelInfo[x][y + j].Render == 1) && (LevelInfo[x][y + j].Grouped == 0) && (LevelInfo[x][y + j].BullFrog == 0))		//&& (LevelInfo[x][y].tileType ==0) && (LevelInfo[x][y+j].tileType ==0)
			{
			//combine these two if they match and they are not already part of a group
				if (DoTilesMatch(LevelInfo[x][y],LevelInfo[x][y+j])){
					LevelInfo[x][y+j].Render =0;
					LevelInfo[x][y+j].Grouped =1;
					LevelInfo[x][y].Grouped =1;
					//LevelInfo[x][y].DimY++;
					j++;
				}
				else
				{
					break;
				}
			
			}
			LevelInfo[x][y].DimY = LevelInfo[x][y].DimY +j-1;
			j=1;
			}
		}
	}
	j=1;
//////Now combine parallel solids
////	for (x=0;x<64;x++){
////		for (y=0;y<63;y++){
////			if  ((LevelInfo[x][y].Grouped ==1) && (LevelInfo[x][y].Render  ==1))  //is a start of a group
////			{
////			//test it's next door neighbour
////				if  ((LevelInfo[x][y+1].Grouped ==1) && (LevelInfo[x][y+1].Render  ==1))	//Neighbour is also a group,
////				{
////				if (DoTilesMatch(LevelInfo[x][y],LevelInfo[x+LevelInfo[x][y+1].DimX][y+1]))//test the first tile against the opposite corner of it's neighbour
////				{
////					//they match. -> merge em.
////					LevelInfo[x][y].DimX++;
////					for ( int k =1; k <=LevelInfo[x][y+1].DimX;k++)
////					{
////					LevelInfo[k][y+1].Render =0;
////					LevelInfo[k][y+1].Grouped =1;
////					
////					}
////				}
////				}
////			}
////		}
////	}

	////Now lets combine solids along the other axis
for (y=0;y<64;y++){
		for (x=0;x<64;x++){
			if ((x == 22) && (y == 52))
				{
				printf("%d\n", LevelInfo[22][52].VisibleFaces[vSOUTH]);
				}
			if  ((LevelInfo[x][y].Grouped ==0))
			{
			j=1;
			while ((LevelInfo[x][y].Render == 1) && (LevelInfo[x + j][y].Render == 1) && (LevelInfo[x + j][y].Grouped == 0) && (LevelInfo[x + j][y].BullFrog == 0))		//&& (LevelInfo[x][y].tileType ==0) && (LevelInfo[x][y+j].tileType ==0)
			{
			//combine these two if they  match and they are not already part of a group
				if (DoTilesMatch(LevelInfo[x][y],LevelInfo[x+j][y])){
					LevelInfo[x+j][y].Render =0;
					LevelInfo[x+j][y].Grouped =1;
					LevelInfo[x][y].Grouped =1;
					//LevelInfo[x][y].DimY++;
					j++;
				}
				else
				{
					break;
				}
			
			}
			LevelInfo[x][y].DimX = LevelInfo[x][y].DimX +j-1;
			j=1;
			}
		}
	}

//Clear invisible faces on solid tiles. 
//TODO:Support all 64x64 tiles
for (y = 0; y<=63; y++){
	for (x = 0; x<=63; x++){
		if ((LevelInfo[x][y].tileType == TILE_SOLID))
			{
			int dimx = LevelInfo[x][y].DimX;
			int dimy = LevelInfo[x][y].DimY;

			if (x == 0)
				{
				LevelInfo[x][y].VisibleFaces[vWEST]=0;
				}
			if (x == 63)
				{
				LevelInfo[x][y].VisibleFaces[vEAST] = 0;
				}
			if (y == 0 )
				{
				LevelInfo[x][y].VisibleFaces[vSOUTH] = 0;
				}

			if (y == 63)
				{
				LevelInfo[x][y].VisibleFaces[vNORTH] = 0;
				}
			if ((x != 63) || (y != 63))
				{
				if ((LevelInfo[x + dimx][y].tileType == TILE_SOLID) && (LevelInfo[x + dimx][y].TerrainChange == 0) && (LevelInfo[x][y].TerrainChange == 0))//Tile to the east is a solid
					{
					LevelInfo[x][y].VisibleFaces[vEAST] = 0;
					LevelInfo[x + dimx][y].VisibleFaces[vWEST] = 0;
					}
				if ((LevelInfo[x][y + dimy].tileType == TILE_SOLID) && (LevelInfo[x][y].TerrainChange == 0) && (LevelInfo[x][y + dimy].TerrainChange == 0))//TIle to the north is a solid
					{
					LevelInfo[x][y].VisibleFaces[vNORTH] = 0;
					LevelInfo[x][y + dimy].VisibleFaces[vSOUTH] = 0;
					}
				}
			}
		}
	}

//Clear invisible faces on diagonals
for (y = 1; y < 63; y++){
	for (x = 1; x < 63; x++){
		switch (LevelInfo[x][y].tileType)
			{
				case TILE_DIAG_NW:
					{
					if ((LevelInfo[x][y - 1].tileType == TILE_SOLID) && (LevelInfo[x][y-1].TerrainChange == 0))
						{
						LevelInfo[x][y].VisibleFaces[vSOUTH]=0;
						LevelInfo[x][y - 1].VisibleFaces[vNORTH]=0;
						}
					if ((LevelInfo[x + 1][y].tileType == TILE_SOLID) && (LevelInfo[x + 1][y].TerrainChange==0))
						{
						LevelInfo[x][y].VisibleFaces[vEAST] = 0;
						LevelInfo[x + 1][y].VisibleFaces[vWEST]=0;
						}
					}
					break;
				case TILE_DIAG_NE:
					{
					if ((LevelInfo[x][y - 1].tileType == TILE_SOLID) && (LevelInfo[x][y - 1].TerrainChange == 0))
						{
						LevelInfo[x][y].VisibleFaces[vSOUTH] = 0;
						LevelInfo[x][y - 1].VisibleFaces[vNORTH] = 0;
						}
					if ((LevelInfo[x - 1][y].tileType == TILE_SOLID) && (LevelInfo[x - 1][y].TerrainChange == 0))
						{
						LevelInfo[x][y].VisibleFaces[vWEST] = 0;
						LevelInfo[x - 1][y].VisibleFaces[vEAST] = 0;
						}
					}
					break;
				case TILE_DIAG_SE:
					{
					if ((LevelInfo[x][y + 1].tileType == TILE_SOLID) && (LevelInfo[x][y + 1].TerrainChange == 0))
						{
						LevelInfo[x][y].VisibleFaces[vNORTH] = 0;
						LevelInfo[x][y + 1].VisibleFaces[vSOUTH] = 0;
						}
					if ((LevelInfo[x - 1][y].tileType == TILE_SOLID) && (LevelInfo[x - 1][y].TerrainChange == 0))
						{
						LevelInfo[x][y].VisibleFaces[vWEST] = 0;
						LevelInfo[x - 1][y].VisibleFaces[vEAST] = 0;
						}
					}
					break;
				case TILE_DIAG_SW:
					{
					if ((LevelInfo[x][y + 1].tileType == TILE_SOLID) && (LevelInfo[x][y + 1].TerrainChange == 0))
						{
						LevelInfo[x][y].VisibleFaces[vNORTH] = 0;
						LevelInfo[x][y + 1].VisibleFaces[vSOUTH] = 0;
						}
					if ((LevelInfo[x + 1][y].tileType == TILE_SOLID) && (LevelInfo[x + 1][y].TerrainChange == 0))
						{
						LevelInfo[x][y].VisibleFaces[vEAST] = 0;
						LevelInfo[x + 1][y].VisibleFaces[vWEST] = 0;
						}
					}
					break;
			}

		}

	}

for (y = 1; y < 63; y++){
	for (x = 1; x < 63; x++){
		if ((LevelInfo[x][y].tileType == TILE_OPEN) && (LevelInfo[x][y].TerrainChange == 0) && (LevelInfo[x][y].BullFrog == 0))
			{
			if (
				((LevelInfo[x + 1][y].tileType == TILE_OPEN) && (LevelInfo[x + 1][y].TerrainChange == 0) && (LevelInfo[x + 1][y].BullFrog == 0) && (LevelInfo[x + 1][y].floorHeight >= LevelInfo[x][y].floorHeight))
				||
				(LevelInfo[x + 1][y].tileType == TILE_SOLID) && (LevelInfo[x + 1][y].TerrainChange == 0) && (LevelInfo[x + 1][y].BullFrog == 0)
				)
				{
				LevelInfo[x][y].VisibleFaces[vEAST]=0;
				}
			

			if (
				((LevelInfo[x - 1][y].tileType == TILE_OPEN) && (LevelInfo[x - 1][y].TerrainChange == 0) && (LevelInfo[x - 1][y].BullFrog == 0) && (LevelInfo[x - 1][y].floorHeight >= LevelInfo[x][y].floorHeight))
				||
				(LevelInfo[x - 1][y].tileType == TILE_SOLID) && (LevelInfo[x - 1][y].TerrainChange == 0) && (LevelInfo[x - 1][y].BullFrog == 0)
				)
				{
				LevelInfo[x][y].VisibleFaces[vWEST] = 0;
				}


			if (
				((LevelInfo[x][y + 1].tileType == TILE_OPEN) && (LevelInfo[x][y + 1].TerrainChange == 0) && (LevelInfo[x][y + 1].BullFrog == 0) && (LevelInfo[x][y + 1].floorHeight >= LevelInfo[x][y].floorHeight))
				||
				(LevelInfo[x][y + 1].tileType == TILE_SOLID) && (LevelInfo[x][y + 1].TerrainChange == 0) && (LevelInfo[x][y + 1].BullFrog == 0)
				)
				{
				LevelInfo[x][y].VisibleFaces[vNORTH] = 0;
				}

			if (
				((LevelInfo[x][y - 1].tileType == TILE_OPEN) && (LevelInfo[x][y - 1].TerrainChange == 0) && (LevelInfo[x][y - 1].BullFrog == 0) && (LevelInfo[x][y - 1].floorHeight >= LevelInfo[x][y].floorHeight))
				||
				(LevelInfo[x][y - 1].tileType == TILE_SOLID) && (LevelInfo[x][y - 1].TerrainChange == 0) && (LevelInfo[x][y - 1].BullFrog == 0)
				)
				{
				LevelInfo[x][y].VisibleFaces[vSOUTH] = 0;
				}
			}

		}
	}
//Make sure solids & opens are still consistently visible.
	for (y = 1; y < 63; y++){
		for (x = 1; x < 63; x++){

			if ((LevelInfo[x][y].tileType == TILE_SOLID) || (LevelInfo[x][y].tileType == TILE_OPEN))
				{
				int dimx = LevelInfo[x][y].DimX;
				int dimy = LevelInfo[x][y].DimY;
				if (dimx>1)
					{//Make sure the ends are set properly
					LevelInfo[x][y].VisibleFaces[vEAST] = LevelInfo[x + dimx - 1][y].VisibleFaces[vEAST];
					}
				if (dimy>1)
					{
					LevelInfo[x][y].VisibleFaces[vNORTH] = LevelInfo[x][y + dimy - 1].VisibleFaces[vNORTH];
					}

				//Check along each axis
				for (int i = 0; i < LevelInfo[x][y].DimX; i++)
					{
					if (LevelInfo[x + i][y].VisibleFaces[vNORTH] == 1)
						{
						LevelInfo[x][y].VisibleFaces[vNORTH]=1;
						}
					if (LevelInfo[x + i][y].VisibleFaces[vSOUTH] == 1)
						{
						LevelInfo[x][y].VisibleFaces[vSOUTH] = 1;
						}
					}

				for (int i = 0; i < LevelInfo[x][y].DimY; i++)
					{
					if (LevelInfo[x][y+i].VisibleFaces[vEAST] == 1)
						{
						LevelInfo[x][y].VisibleFaces[vEAST] = 1;
						}
					if (LevelInfo[x][y+i].VisibleFaces[vWEST] == 1)
						{
						LevelInfo[x][y].VisibleFaces[vWEST] = 1;
						}
					}

				}
			}
		}
	for (int y = 0; y <= 63; y++){
		LevelInfo[0][y].VisibleFaces[vEAST]=1;
		LevelInfo[63][y].VisibleFaces[vWEST] = 1;
		}
	for (int x = 0; x <= 63; x++){
		LevelInfo[x][0].VisibleFaces[vNORTH] = 1;
		LevelInfo[x][63].VisibleFaces[vSOUTH] = 1;
		}
}



int DoTilesMatch(tile &t1, tile &t2)
{//TODO:Tiles have a lot more properties now.
	//if ((t1.tileType >1) || (t1.hasElevator==1) || (t1.TerrainChange ==1) ||  (t2.hasElevator==1) || (t2.TerrainChange ==1) || (t1.isWater ==1) || (t2.isWater ==1)){	//autofail no none solid/open/special.
		if ((t1.tileType >1) || (t1.hasElevator == 1) || (t1.TerrainChange == 1) || (t2.hasElevator == 1) || (t2.TerrainChange == 1)){	//autofail no none solid/open/special.
		return 0;
	}
	else
	{
//if ((t1.floorTexture == t2.floorTexture ) && (t1.floorHeight == t2.floorHeight)
//		&& (t1.DimX==t2.DimX) && (t1.DimY == t2.DimY ) 
//		 && (t1.tileType == t2.tileType ) 
//		 && (t1.isDoor==0) && (t2.isDoor ==0)) {
//fprintf(LOGFILE,"");
//}
	if ((t1.tileType==0) && (t2.tileType == 0))	//solid
		{
		return ((t1.wallTexture==t2.wallTexture) && (t1.West == t2.West) && (t1.South == t2.South) && (t1.East == t2.East) && (t1.North == t2.North) && (t1.UseAdjacentTextures == t2.UseAdjacentTextures));
		}
	else
		{
		return (t1.shockCeilingTexture == t2.shockCeilingTexture)
			&& (t1.floorTexture == t2.floorTexture) 
			&& (t1.floorHeight == t2.floorHeight)
			&& (t1.ceilingHeight == t2.ceilingHeight )
			&& (t1.DimX==t2.DimX) && (t1.DimY == t2.DimY ) 
			&& (t1.wallTexture == t2.wallTexture)
			&& (t1.tileType == t2.tileType ) 
			&& (t1.isDoor==0) && (t2.isDoor ==0);//
		}
	}
}


int getObject(long tileData)
{
//gets object data at bits 6-15 (+16) of the tile data(2nd part)
return tileData >> 6;
}



int BuildTileMapUW(tile LevelInfo[64][64],ObjectItem objList[1600], long texture_map[256], char *filePath, int game, int LevelNo)
{
	FILE *file = NULL;      // File pointer
	unsigned char *lev_ark; 
	unsigned char *tmp_ark; 
	unsigned char *tex_ark; 
    int NoOfBlocks;
	long AddressOfBlockStart;
	long address_pointer;
	long textureAddress;
	long fileSize;
	int x;	
	int y;
	int i;
	int CeilingTexture=0;
	int textureMapSize;
	
	UW_CEILING_HEIGHT = ((128 >> 2) * 8 >>3);	//Shifts the scale of the level. Idea borrowed from abysmal
	switch (game)
	{
	case UWDEMO:	//UW Demo
		{
		char UWdemoFileToOpen[255];
		sprintf_s(UWdemoFileToOpen, 255, "%s\\data\\level13.st", filePath);
		textureMapSize=0x7a;
		if ((file = fopen(UWdemoFileToOpen, "rb")) == NULL)
			{
			fprintf(LOGFILE, "Could not open specified file\n");
			return 0;
			}
		long fileSize = getFileSize(file);
		lev_ark = new unsigned char[fileSize];
		fread(lev_ark, fileSize, 1,file);
		fclose(file);  
		
		//Get the number of blocks in this file.
		NoOfBlocks = 1;
		//Get the first map block
		AddressOfBlockStart = 0;	
		textureAddress = 0; //it's in a different file
		address_pointer =0;
		//read in the textures
		FILE *fileT = NULL; 
		//filePath = UW0_TEXTUREW_PATH;	
		sprintf_s(UWdemoFileToOpen, 255, "%s\\DATA\\level13.txm", filePath);
		if ((fileT = fopen(UWdemoFileToOpen, "rb")) == NULL)
			{
			fprintf(LOGFILE, "Could not open specified file\n");
			}
		fileSize = getFileSize(fileT);
		tex_ark = new unsigned char[fileSize];
		fread(tex_ark, fileSize, 1,fileT);
		fclose(fileT);  		
		break;		
		}
	case UW1:	//UW1
		{
		textureMapSize = 64; // 0x7a;
		if ((file = fopen(filePath, "rb")) == NULL)
			fprintf(LOGFILE,"Could not open specified file\n");
		else
			fprintf(LOGFILE,"");
		fileSize = getFileSize(file);
		lev_ark = new unsigned char[fileSize];
		fread(lev_ark, fileSize, 1,file);
		fclose(file);  
					
		//Get the number of blocks in this file.
		NoOfBlocks = ConvertInt16(lev_ark[0],lev_ark[1]);
		NoOfBlocks = getValAtAddress(lev_ark,0,32);
		//Get the first map block
		AddressOfBlockStart = getValAtAddress(lev_ark,(LevelNo * 4) + 2,32);	
		textureAddress = getValAtAddress(lev_ark,((LevelNo+18) * 4) + 2 ,32);
		//long objectsAddress = AddressOfBlockStart + (64*64*4); //+ 1;
		address_pointer =0;
		break;
		}	
	
	case UW2:	//Underworld 2
		{
		textureMapSize = 70;	//0x86;
		if ((file = fopen(filePath, "rb")) == NULL)
			fprintf(LOGFILE,"Could not open specified file\n");
		else
			fprintf(LOGFILE,"");
		fileSize = getFileSize(file);
		tmp_ark = new unsigned char[fileSize];
		//tex_ark = new unsigned char[fileSize];
		fread(tmp_ark, fileSize, 1,file);
		//fread(tex_ark,fileSize,1,file);
		fclose(file);  

		address_pointer=0;
		NoOfBlocks=getValAtAddress(tmp_ark,0,32);	
					
		address_pointer=6;

		int compressionFlag=getValAtAddress(tmp_ark,address_pointer + (NoOfBlocks*4) + (LevelNo*4) ,32);
		int isCompressed =(compressionFlag>>1) & 0x01;
		//	long dataSize = address_pointer + (2*NoOfBlocks*4);	//????
		address_pointer=(LevelNo * 4) + 6;
		if (getValAtAddress(tmp_ark,address_pointer,32)==0)
			{
			fprintf(LOGFILE,"\nInvalid block address!\n");
			return -1;
			}
		if (isCompressed == 1)
			{
			int datalen;
			lev_ark = unpackUW2(tmp_ark,getValAtAddress(tmp_ark,address_pointer,32),&datalen);
			address_pointer=address_pointer+4;
			AddressOfBlockStart=0;
			//ObjectsAddress=1024;
			address_pointer=0;
			}
		else
			{
			//fprintf(LOGFILE,"uncompressed? what do i do here???");
			int BlockStart = getValAtAddress(tmp_ark, address_pointer, 32);
			int j=0;
			AddressOfBlockStart=0;
			address_pointer = 0;
			lev_ark = new unsigned char[0x7c08];
			for (i = BlockStart; i < BlockStart + 0x7c08; i++)
				{
				lev_ark[j] = tmp_ark[i];
				j++;
				}
			}	
		
		
		//read in the textures
		//address_pointer=(LevelNo * 4) + 6 + (80*4);
		//tex_ark = tmp_ark;	//unpack(tmp_ark,getValAtAddress(tmp_ark,address_pointer,32));
		textureAddress=getValAtAddress(tmp_ark,(LevelNo * 4) + 6 + (80*4),32);	
		fprintf(LOGFILE,"\nTextures address: %d", textureAddress);
		compressionFlag=getValAtAddress(tmp_ark,(LevelNo * 4) + 6 + (80*4)+ (NoOfBlocks*4),32);
		isCompressed =(compressionFlag>>1) & 0x01;

		if (isCompressed == 1)
			{
			int datalen;
			tex_ark = unpackUW2(tmp_ark, textureAddress, &datalen);
			textureAddress=-1;
			}
		break;
		}		
		
	}

	int offset=0;
	for (i = 0; i<textureMapSize; i++)	//256
		{//TODO: Only use this for texture lookups.
		switch (game)
			{
			case UWDEMO:
				{
				texture_map[i] = getValAtAddress(tex_ark, textureAddress + (i * 2), 16);
				//printf("%d = %d\n",i, texture_map[i]);
				if (i == 57)
					{
					CeilingTexture = texture_map[i]+210;
					}

				break; 
				}//tex_ark[textureAddress+i];break;}
			case UW1:
				{
				if (i<48)	//Wall and floor textures are int 16s
					{
					texture_map[i] = getValAtAddress(lev_ark, textureAddress + offset, 16); //(i * 2)
						offset=offset+2;
						
					}
				else if (i<=57)	//Wall and floor textures are int 16s
					{
						texture_map[i] = getValAtAddress(lev_ark, textureAddress + offset, 16)+210; //(i * 2)
						offset = offset + 2;

					}
				else
					{ //door textures are int 8s
						texture_map[i] = getValAtAddress(lev_ark, textureAddress + offset, 8) ;//+210; //(i * 1)
						offset++;
					}
				if (i == 57)
					{
					CeilingTexture = texture_map[i];
					}
				fprintf(LOGFILE,"\nTexture %d = %d (%s)", i, texture_map[i], textureMasters[texture_map[i]].desc);
				break;
				}
			case UW2:
				{
				if (textureAddress == -1)//Texture block was decompressed
					{
					//textureAddress = 0;
					if (i<64)
						{
						texture_map[i] =getValAtAddress(tex_ark,offset ,16);//tmp //textureAddress+ //(i*2)
						offset = offset + 2;
						}
					else
						{//door textures
							texture_map[i] = getValAtAddress(tex_ark, textureAddress + offset, 8);//tmp //textureAddress+//(i*2)
							offset++;
						}
					}
				else
					{
					if (i<64)
						{
						texture_map[i] =getValAtAddress(tmp_ark,textureAddress+offset,16);//tmp //textureAddress+//(i*2)
						offset = offset + 2;
						}
					else
						{//door textures
						texture_map[i] = getValAtAddress(tmp_ark, textureAddress + offset, 8);//tmp //textureAddress+//(i*2)
						offset++;
						}
					}
				fprintf(LOGFILE,"\nTexture %d = %d (%s)", i, texture_map[i],textureMasters[texture_map[i]].desc);
				if (i == 0xf)
					{
					CeilingTexture=texture_map[i];
					}
				break;
				}
			}
		}
	//Assign door textures to the object masters list
	//Depends on the correct values in the config!!
	switch (game)
	{
		case UWDEMO:
			objectMasters[320].extraInfo = texture_map[48];
			objectMasters[321].extraInfo = texture_map[49];
			objectMasters[322].extraInfo = texture_map[50];
			objectMasters[323].extraInfo = texture_map[51];
			objectMasters[324].extraInfo = texture_map[52];
			objectMasters[325].extraInfo = texture_map[53];
			break;
		case UW1:
			objectMasters[320].extraInfo = texture_map[58];
			objectMasters[321].extraInfo = texture_map[59];
			objectMasters[322].extraInfo = texture_map[60];
			objectMasters[323].extraInfo = texture_map[61];
			objectMasters[324].extraInfo = texture_map[62];
			objectMasters[325].extraInfo = texture_map[63];
			
			objectMasters[328].extraInfo = texture_map[58];
			objectMasters[329].extraInfo = texture_map[59];
			objectMasters[330].extraInfo = texture_map[60];
			objectMasters[331].extraInfo = texture_map[61];
			objectMasters[332].extraInfo = texture_map[62];
			objectMasters[333].extraInfo = texture_map[63];
			break;
		case UW2:
			objectMasters[320].extraInfo = texture_map[64];
			objectMasters[321].extraInfo = texture_map[65];
			objectMasters[322].extraInfo = texture_map[66];
			objectMasters[323].extraInfo = texture_map[67];
			objectMasters[324].extraInfo = texture_map[68];
			objectMasters[325].extraInfo = texture_map[69];
			break;
	}
	for (y=0; y<64;y++)
		{
		for (x=0; x<64;x++)
			{
				LevelInfo[x][y].tileX = x;
				LevelInfo[x][y].tileY = y;
				LevelInfo[x][y].address = AddressOfBlockStart+address_pointer;
				long FirstTileInt = getValAtAddress(lev_ark,AddressOfBlockStart+(address_pointer+0),16);
				// FirstTileInt = getValAtCoordinate(x,y,AddressOfBlockStart,lev_ark,16);
				//long SecondTileInt = (getValAtCoordinate(x,y,AddressOfBlockStart,lev_ark,32) >> 16);
				long SecondTileInt = getValAtAddress(lev_ark,AddressOfBlockStart+(address_pointer+2),16);
				//fprintf(LOGFILE, "\n%d X@%d Y@%d = %d + %d,",AddressOfBlockStart+address_pointer,x,y,FirstTileInt,SecondTileInt);
				address_pointer=address_pointer+4;

				LevelInfo[x][y].tileType = getTile(FirstTileInt) ;
				LevelInfo[x][y].floorHeight = getHeight(FirstTileInt) ;
				LevelInfo[x][y].floorHeight = ((LevelInfo[x][y].floorHeight <<3) >> 2)*8 >>3;	//Try and copy this shift from shock.

				LevelInfo[x][y].ceilingHeight = 0;//UW_CEILING_HEIGHT;	//constant for uw				
				LevelInfo[x][y].noOfNeighbours=0;
				LevelInfo[x][y].tileTested = 0;
				LevelInfo[x][y].TerrainChangeCount=0;
				LevelInfo[x][y].BullFrog = 0;

				LevelInfo[x][y].flags = (FirstTileInt>>7) & 0x3;
				LevelInfo[x][y].noMagic = (FirstTileInt>>13) & 0x1;
				switch (game)
					{
					case UWDEMO:	//special case for demo since textures mappings are in a seperate file
						LevelInfo[x][y].floorTexture = getFloorTex(tex_ark, textureAddress, FirstTileInt);
						LevelInfo[x][y].shockCeilingTexture = LevelInfo[x][y].floorTexture;
						LevelInfo[x][y].wallTexture = getWallTex(tex_ark, textureAddress, SecondTileInt);//?
						LevelInfo[x][y].wallTexture = texture_map[SecondTileInt & 0x3F];
						break;
					case UW1:	//uw1
						LevelInfo[x][y].floorTexture = getFloorTex(lev_ark, textureAddress, FirstTileInt);
						if (LevelNo == 6)
							{//Tybals lair. Special case for the maze
							int val = (FirstTileInt >> 10) & 0x0F;
							if (val == 4)
								{//Maze floor
								LevelInfo[x][y].floorTexture = 278;
								}
							}
						LevelInfo[x][y].wallTexture = getWallTex(lev_ark, textureAddress, SecondTileInt);
						break;
					case UW2:	//uw2
						{
						LevelInfo[x][y].floorTexture = getFloorTexUw2(tmp_ark, textureAddress, FirstTileInt);
						//int val = (FirstTileInt >>10) & 0x0F;
						LevelInfo[x][y].floorTexture = texture_map[(FirstTileInt >>10) & 0x0F];
						LevelInfo[x][y].wallTexture = getWallTexUw2(tmp_ark, textureAddress, SecondTileInt);	
						//(tileData & 0x3F
						LevelInfo[x][y].wallTexture= texture_map[SecondTileInt & 0x3F];
						break;
						}						
					default:
						LevelInfo[x][y].floorTexture=CAULK;
						LevelInfo[x][y].wallTexture=CAULK;
						break;
					}
				if (LevelInfo[x][y].floorTexture<0)
					{
					LevelInfo[x][y].floorTexture=0;
					}
				if (LevelInfo[x][y].wallTexture>=256)
					{
					LevelInfo[x][y].wallTexture =0;
					}					
				//UW only has a single ceiling texture so this is ignored.
				//LevelInfo[x][y].shockCeilingTexture = LevelInfo[x][y].floorTexture;					
				LevelInfo[x][y].shockCeilingTexture=CeilingTexture;
				//There is only one possible steepness in UW so I set it's properties to match a similar tile in shock.
				if (LevelInfo[x][y].tileType >=2)
					{
					LevelInfo[x][y].shockSteep = 1;
					LevelInfo[x][y].shockSteep = ((LevelInfo[x][y].shockSteep  <<3) >> 2)*8 >>3;	//Shift copied from shock
					LevelInfo[x][y].shockSlopeFlag = SLOPE_FLOOR_ONLY ;
					}

			
				//LevelInfo[x][y].isDoor = getDoors(FirstTileInt);
				
				//Different textures on solid tiles faces
				LevelInfo[x][y].North = LevelInfo[x][y].wallTexture;
				LevelInfo[x][y].South = LevelInfo[x][y].wallTexture;
				LevelInfo[x][y].East = LevelInfo[x][y].wallTexture;
				LevelInfo[x][y].West = LevelInfo[x][y].wallTexture;
				LevelInfo[x][y].Top = LevelInfo[x][y].floorTexture; 
				LevelInfo[x][y].Bottom = LevelInfo[x][y].floorTexture; 
				LevelInfo[x][y].Diagonal = LevelInfo[x][y].wallTexture;
				//First index of the linked list of objects.
				LevelInfo[x][y].indexObjectList = getObject(SecondTileInt);

				LevelInfo[x][y].Render=1;		
				LevelInfo[x][y].DimX=1;			
				LevelInfo[x][y].DimY=1;			
				LevelInfo[x][y].Grouped=0;	
				//LevelInfo[x][y].VisibleFaces = 63;
				for (int v = 0; v < 6; v++)
					{
					LevelInfo[x][y].VisibleFaces[v]=1;
					}
				LevelInfo[x][y].isWater = (textureMasters[LevelInfo[x][y].floorTexture].water == 1) && ((LevelInfo[x][y].tileType !=0) && (ENABLE_WATER==1));
				LevelInfo[x][y].isLava = (textureMasters[LevelInfo[x][y].floorTexture].lava == 1) && ((LevelInfo[x][y].tileType != 0));
				LevelInfo[x][y].waterRegion= 0;
				LevelInfo[x][y].landRegion = 0;//including connected bridges.
				LevelInfo[x][y].lavaRegion = 0;

				//Set some easy tile visible settings
				switch (LevelInfo[x][y].tileType)
					{
					case TILE_SOLID:
						//Bottom and top are invisible
						LevelInfo[x][y].VisibleFaces[0] = 0;
						LevelInfo[x][y].VisibleFaces[2] = 0;
						break;
					default:
						//Bottom is invisible
						LevelInfo[x][y].VisibleFaces[2] = 0;
						break;
					}

				//Force off water to save on compile time during testing.
				//LevelInfo[x][y].isWater=0;
				//LevelInfo[x][y].TerrainChange=0;
				//LevelInfo[x][y].hasElevator=0;
			}
		}
	for (y=0; y<64;y++)
		{
		for (x=0; x<64;x++)
			{
			if (LevelInfo[x][y].tileType >= 0) //was just solid only. Note: If textures are all wrong it's probably caused here!
				{
				//assign it's north texture
				if (y<63)
					{LevelInfo[x][y].North =LevelInfo[x][y+1].wallTexture;}
				else
					{LevelInfo[x][y].North =-1;}
				//assign it's southern
				if (y>0)
					{LevelInfo[x][y].South  =LevelInfo[x][y-1].wallTexture;}
				else
					{LevelInfo[x][y].South =-1;}
				}
				//it's east
				if (x<63)
					{LevelInfo[x][y].East =LevelInfo[x+1][y].wallTexture;}
				else
					{LevelInfo[x][y].East =-1;}
				//assign it's West
				if (x>0)
					{LevelInfo[x][y].West =LevelInfo[x-1][y].wallTexture;}
				else
					{LevelInfo[x][y].West =-1;}				
				}
			LevelInfo[x][y].UpperEast = LevelInfo[x][y].East;
			LevelInfo[x][y].UpperWest = LevelInfo[x][y].West;
			LevelInfo[x][y].UpperNorth = LevelInfo[x][y].North;
			LevelInfo[x][y].UpperSouth = LevelInfo[x][y].South;
			LevelInfo[x][y].LowerEast = LevelInfo[x][y].East;
			LevelInfo[x][y].LowerWest = LevelInfo[x][y].West;
			LevelInfo[x][y].LowerNorth = LevelInfo[x][y].North;
			LevelInfo[x][y].LowerSouth = LevelInfo[x][y].South;

			}
return 1;
}









int BuildTileMapShock(tile LevelInfo[64][64], ObjectItem objList[1600],long texture_map[272], char *filePath, int game, int LevelNo)
{
	unsigned char *archive_ark; 
	unsigned char *lev_ark; 
/*	unsigned char *tmp_ark; 
	unsigned char *sub_ark;*/ 
	unsigned char *tex_ark;
	unsigned char *inf_ark;
	long AddressOfBlockStart=0;
	long address_pointer=4;
	char blnLevelFound=0;
	long blockAddress =0;

//	int chunkId;
	long chunkUnpackedLength;
	long chunkType;//compression type
	long chunkPackedLength;
//	long chunkContentType;

//Read in the archive.
	FILE *file = NULL;      // File pointer
	if ((file = fopen(filePath, "rb")) == NULL)
		{
		fprintf(LOGFILE,"\nBuildTileMapSHock - Archive not found!\n");
		return -1;
		}
	long fileSize = getFileSize(file);
	//int filepos = ftell(file);	
	archive_ark = new unsigned char[fileSize];
	fread(archive_ark, fileSize, 1,file);
	fclose(file);
	
	
	
	//get the level info data from the archive
	blockAddress =getShockBlockAddress(LevelNo*100+4004,archive_ark,&chunkPackedLength,&chunkUnpackedLength,&chunkType); 
	if (blockAddress == -1) {return-1;}
	inf_ark=new unsigned char[chunkUnpackedLength];
	LoadShockChunk(blockAddress, chunkType, archive_ark, inf_ark,chunkPackedLength,chunkUnpackedLength);	
	//Process level properties (height c-space)
	long HeightUnits = getValAtAddress(inf_ark,16,32);	//Log2 value. The higher the value the lower the level height.
	if (HeightUnits > 3)	//Any higher we lose data, 
		{
		HeightUnits=3;
		}
	int cSpace = getValAtAddress(inf_ark,24,32);	//Per docs should return 1 on cyberspace. Does'nt appear to work.
	SHOCK_CEILING_HEIGHT = ((256 >> HeightUnits) * 8 >>3);	//Shifts the scale of the level.
	//long sizeV = getValAtAddress(inf_ark,0,32);
	//long sizeH = getValAtAddress(inf_ark,4,32);
	//long always6_1 = getValAtAddress(inf_ark,8,32);
	//long always6_2 = getValAtAddress(inf_ark,12,32);	
	
	//Read the main level data in
	blockAddress =getShockBlockAddress(LevelNo*100+4005,archive_ark,&chunkPackedLength,&chunkUnpackedLength,&chunkType); 
	if (blockAddress == -1) {return-1;}
	lev_ark=new unsigned char[chunkUnpackedLength]; //or 64*64*16
	LoadShockChunk(blockAddress, chunkType, archive_ark, lev_ark,chunkPackedLength,chunkUnpackedLength);
	AddressOfBlockStart=0;
	address_pointer=0;	
	

	
	//get the texture data from the archive.is never compressed?
	AddressOfBlockStart = getShockBlockAddress(4007+ LevelNo*100, archive_ark,  &chunkPackedLength, &chunkUnpackedLength,&chunkType);
	tex_ark = new unsigned char[chunkUnpackedLength];	
	for (long k=0; k< chunkUnpackedLength/2; k++)
	{
		texture_map[k] = getValAtAddress(archive_ark,AddressOfBlockStart + address_pointer,16);
		address_pointer =address_pointer+2;		//tmp_ark[AddressOfBlockStart+k];
	}
	AddressOfBlockStart=0;
	address_pointer=0;	


	//Reactor		Map 0  (chunk 40xx)
	//Levels 1-9	Map L  (chunk 4Lxx)
	//SHODAN c/space	Map 10 (chunk 50xx)
	//Delta grove	Map 11 (chunk 51xx)
	//Alpha grove	Map 12 (chunk 52xx)
	//Beta grove	Map 13 (chunk 53xx)
	//C/space L1-2    Map 14 (chunk 54xx)
	//C/space other	Map 15 (chunk 55xx)
	for (int y=0; y<64;y++)
		{
		for (int x = 0; x < 64; x++)
		{
			//Read in the tile data 
			LevelInfo[x][y].tileX = x;
			LevelInfo[x][y].tileY = y;
			LevelInfo[x][y].tileType = lev_ark[address_pointer];
			switch (LevelInfo[x][y].tileType)
			{//Need to swap some tile types around so that they conform to uw naming standards.
			case 4:	{LevelInfo[x][y].tileType = 5; break; }
			case 5:	{LevelInfo[x][y].tileType = 4; break; }
			case 7:	{LevelInfo[x][y].tileType = 8; break; }
			case 8:	{LevelInfo[x][y].tileType = 7; break; }
			}
			LevelInfo[x][y].ActualType = LevelInfo[x][y].tileType;
			LevelInfo[x][y].indexObjectList = 0;
			LevelInfo[x][y].Render = 1;
			LevelInfo[x][y].DimX = 1;
			LevelInfo[x][y].DimY = 1;
			LevelInfo[x][y].Grouped = 0;
			LevelInfo[x][y].BullFrog=0;
			for (int v = 0; v < 6; v++)
				{
				LevelInfo[x][y].VisibleFaces[v] = 1;
				}
			/* word 6 contains
				0-5	Wall texture (index into texture list)
				6-10	Ceiling texture
				11-15	Floor texture
				*/
			LevelInfo[x][y].wallTexture = texture_map[getValAtAddress(lev_ark, address_pointer + 6, 16) & 0x3F];
			LevelInfo[x][y].shockCeilingTexture = texture_map[(getValAtAddress(lev_ark, address_pointer + 6, 16) >> 6) & 0x1F];
			LevelInfo[x][y].floorTexture = texture_map[(getValAtAddress(lev_ark, address_pointer + 6, 16) >> 11) & 0x1F];

			//LevelInfo[x][y].wallTexture = 270;//debug
			//LevelInfo[x][y].shockCeilingTexture = 273;
			LevelInfo[x][y].North = LevelInfo[x][y].wallTexture;
			LevelInfo[x][y].South = LevelInfo[x][y].wallTexture;
			LevelInfo[x][y].East = LevelInfo[x][y].wallTexture;
			LevelInfo[x][y].West = LevelInfo[x][y].wallTexture;

			LevelInfo[x][y].isWater = 0;	//No swimming in shock.
			LevelInfo[x][y].landRegion=0;
			LevelInfo[x][y].lavaRegion = 0;
			LevelInfo[x][y].waterRegion = 0;
			LevelInfo[x][y].floorHeight = ((lev_ark[address_pointer + 1]) & 0x1F);
			LevelInfo[x][y].floorHeight = ((LevelInfo[x][y].floorHeight << 3) >> HeightUnits) * 8 >> 3; //Shift it for varying height scales

			LevelInfo[x][y].ceilingHeight = ((lev_ark[address_pointer + 2]) & 0x1F);
			LevelInfo[x][y].ceilingHeight = ((LevelInfo[x][y].ceilingHeight << 3) >> HeightUnits) * 8 >> 3; //Shift it for varying height scales

			LevelInfo[x][y].shockFloorOrientation = ((lev_ark[address_pointer + 1]) >> 5) & 0x3;
			LevelInfo[x][y].shockCeilOrientation = ((lev_ark[address_pointer + 2]) >> 5) & 0x3;

			//Need to know heights in various directions for alignments.
			//Will set these properly after loading levels.
			LevelInfo[x][y].shockNorthCeilHeight = LevelInfo[x][y].ceilingHeight;
			LevelInfo[x][y].shockSouthCeilHeight = LevelInfo[x][y].ceilingHeight;
			LevelInfo[x][y].shockEastCeilHeight = LevelInfo[x][y].ceilingHeight;
			LevelInfo[x][y].shockWestCeilHeight = LevelInfo[x][y].ceilingHeight;

			LevelInfo[x][y].shockSteep = (lev_ark[address_pointer + 3] & 0x0f);
			LevelInfo[x][y].shockSteep = ((LevelInfo[x][y].shockSteep << 3) >> HeightUnits) * 8 >> 3; //Shift it for varying height scales

			if ((LevelInfo[x][y].shockSteep == 0) && (LevelInfo[x][y].tileType >= 6))//If a sloped tile has no slope then it's a open tile.
			{
				LevelInfo[x][y].tileType = 1;
			}
			if ((LevelInfo[x][y].tileType == 1) && (LevelInfo[x][y].shockSteep > 0))	//similarly an open tile can't have a slope at all
			{
				LevelInfo[x][y].shockSteep = 0;
			}
			LevelInfo[x][y].indexObjectList = getValAtAddress(lev_ark, address_pointer + 4, 16);


			//if(LevelInfo[x][y].indexObjectList!=0)
			//	{
			//	fprintf(LOGFILE,"At %d %d we have: %d\n", x,y,LevelInfo[x][y].indexObjectList);
			//	}

			/*
				xxxxx0xx	Floor & ceiling, same direction
				xxxxx4xx	Floor & ceiling, ceiling opposite dir to tile type
				xxxxx8xx	Floor only
				xxxxxCxx	Ceiling only
				*/
			LevelInfo[x][y].shockSlopeFlag = (getValAtAddress(lev_ark, address_pointer + 8, 32) >> 10) & 0x03;
			LevelInfo[x][y].UseAdjacentTextures = (getValAtAddress(lev_ark, address_pointer + 8, 32) >> 8) & 0x01;
			LevelInfo[x][y].shockTextureOffset = getValAtAddress(lev_ark, address_pointer + 8, 32) & 0xF;
			//unknownflags
			//70E000E0
			//	fprintf(LOGFILE,"\nUnknownflags @ %d %d= %d",x,y, getValAtAddress(lev_ark,address_pointer+8,32) & 0x70E000E0);
			LevelInfo[x][y].shockShadeLower = (getValAtAddress(lev_ark, address_pointer + 8, 32) >> 16) & 0x0F;
			LevelInfo[x][y].shockShadeUpper = (getValAtAddress(lev_ark, address_pointer + 8, 32) >> 24) & 0x0F;
			LevelInfo[x][y].shadeUpperGlobal = 0;
			LevelInfo[x][y].shadeLowerGlobal = 0;
			LevelInfo[x][y].shockNorthOffset = LevelInfo[x][y].shockTextureOffset;
			LevelInfo[x][y].shockSouthOffset = LevelInfo[x][y].shockTextureOffset;
			LevelInfo[x][y].shockEastOffset = LevelInfo[x][y].shockTextureOffset;
			LevelInfo[x][y].shockWestOffset = LevelInfo[x][y].shockTextureOffset;

			LevelInfo[x][y].SHOCKSTATE[0] = getValAtAddress(lev_ark, address_pointer + 0xC, 8);
			LevelInfo[x][y].SHOCKSTATE[1] = getValAtAddress(lev_ark, address_pointer + 0xD, 8);
			LevelInfo[x][y].SHOCKSTATE[2] = getValAtAddress(lev_ark, address_pointer + 0xE, 8);
			LevelInfo[x][y].SHOCKSTATE[3] = getValAtAddress(lev_ark, address_pointer + 0xF, 8);
			
			//LevelInfo[x][y].indexObjectList=0;
			//if (y == 0)
			//{
			//	LevelInfo[x][y].tileType = TILE_SLOPE_N;
			//	LevelInfo[x][y].shockSlopeFlag=SLOPE_FLOOR_ONLY;
			//	LevelInfo[x][y].floorHeight=x;
			//	LevelInfo[x][y].shockSteep=11;
			//}
				address_pointer=address_pointer+16;
			}
		}
	
		for (int y=1; y<63;y++)	//skip the outer textures.
		{
		for (int x=1; x<63;x++)
			{
			//if (
			//	(LevelInfo[x][y].tileType  != TILE_OPEN) 
			//	||	((LevelInfo[x][y].tileType  != TILE_OPEN) && (LevelInfo[x][y].UseAdjacentTextures == 1))
			//	)
			//	{
			//if (LevelInfo[x][y].UseAdjacentTextures != 1)
			//	{
				if (LevelInfo[x+1][y].UseAdjacentTextures != 1)
					{
					LevelInfo[x][y].East = LevelInfo[x+1][y].wallTexture   ;
					LevelInfo[x][y].shockEastOffset =LevelInfo[x+1][y].shockTextureOffset;
					//LevelInfo[x][y].shockEastCeilHeight =LevelInfo[x+1][y].ceilingHeight - LevelInfo[x+1][y].shockSteep ;
					
					}
				if (LevelInfo[x-1][y].UseAdjacentTextures != 1)
					{					
					LevelInfo[x][y].West = LevelInfo[x-1][y].wallTexture   ;
					LevelInfo[x][y].shockWestOffset =LevelInfo[x-1][y].shockTextureOffset;
					//LevelInfo[x][y].shockWestCeilHeight =LevelInfo[x-1][y].ceilingHeight - LevelInfo[x-1][y].shockSteep ;
										
					}
				if (LevelInfo[x][y+1].UseAdjacentTextures != 1)
					{
					LevelInfo[x][y].North = LevelInfo[x][y+1].wallTexture   ;
					LevelInfo[x][y].shockNorthOffset =LevelInfo[x][y+1].shockTextureOffset;
					//LevelInfo[x][y].shockNorthCeilHeight =LevelInfo[x][y+1].ceilingHeight - LevelInfo[x][y+1].shockSteep ;
									
					}
				if (LevelInfo[x][y-1].UseAdjacentTextures != 1)
					{
					LevelInfo[x][y].South  = LevelInfo[x][y-1].wallTexture   ;
					LevelInfo[x][y].shockSouthOffset =LevelInfo[x][y-1].shockTextureOffset;
					//LevelInfo[x][y].shockSouthCeilHeight =LevelInfo[x][y-1].ceilingHeight - LevelInfo[x][y-1].shockSteep ;
					
					}
				//Need to calculate the adjustment here with the steepness and the direction of the slope.
				LevelInfo[x][y].shockEastCeilHeight= CalcNeighbourCeilHeight(LevelInfo[x][y],LevelInfo[x+1][y],fEAST);
				LevelInfo[x][y].shockWestCeilHeight= CalcNeighbourCeilHeight(LevelInfo[x][y],LevelInfo[x-1][y],fWEST);
				LevelInfo[x][y].shockNorthCeilHeight= CalcNeighbourCeilHeight(LevelInfo[x][y],LevelInfo[x][y+1],fNORTH);
				LevelInfo[x][y].shockSouthCeilHeight= CalcNeighbourCeilHeight(LevelInfo[x][y],LevelInfo[x][y-1],fSOUTH);
/*				LevelInfo[x][y].shockEastCeilHeight =LevelInfo[x+1][y].ceilingHeight - LevelInfo[x+1][y].shockSteep ;
				LevelInfo[x][y].shockWestCeilHeight =LevelInfo[x-1][y].ceilingHeight - LevelInfo[x-1][y].shockSteep ;
				LevelInfo[x][y].shockNorthCeilHeight =LevelInfo[x][y+1].ceilingHeight - LevelInfo[x][y+1].shockSteep ;
				LevelInfo[x][y].shockSouthCeilHeight =LevelInfo[x][y-1].ceilingHeight - LevelInfo[x][y-1].shockSteep ;*/	
				//}

				LevelInfo[x][y].UpperEast = LevelInfo[x][y].East;
				LevelInfo[x][y].UpperWest = LevelInfo[x][y].West;
				LevelInfo[x][y].UpperNorth = LevelInfo[x][y].North;
				LevelInfo[x][y].UpperSouth = LevelInfo[x][y].South;
				LevelInfo[x][y].LowerEast = LevelInfo[x][y].East;
				LevelInfo[x][y].LowerWest = LevelInfo[x][y].West;
				LevelInfo[x][y].LowerNorth = LevelInfo[x][y].North;
				LevelInfo[x][y].LowerSouth = LevelInfo[x][y].South;
			}
		}
return 1;
}

int CalcNeighbourCeilHeight(tile &t1, tile &t2,int Direction)
{//TODO:Test me. I'm terrible.
// fNORTH 32
// fSOUTH 16
// fEAST 8
// fWEST 4
	if  ((t2.tileType <=1) ||(t2.shockSlopeFlag == SLOPE_FLOOR_ONLY))
		{//Don't need to do anything since it has a flat ceiling.
		return t2.ceilingHeight;
		}
	else
		{
		//return t2.ceilingHeight;
		switch (Direction)
			{
			case fNORTH:
				{	
				switch (t2.tileType)
					{
					case TILE_SLOPE_N:
					case TILE_SLOPE_S:
						if ((t2.shockSlopeFlag == SLOPE_BOTH_OPPOSITE) ||(t2.shockSlopeFlag == SLOPE_CEILING_ONLY))
							{
							return t2.ceilingHeight+t2.shockSteep ;
							}
						else
							{
							return t2.ceilingHeight;
							}
							break;
					default:
						return t2.ceilingHeight;
						break;
					}
				}	
			case fSOUTH:
				{
				switch (t2.tileType)
					{
					case TILE_SLOPE_S:
					case TILE_SLOPE_N:
						if ((t2.shockSlopeFlag == SLOPE_BOTH_OPPOSITE) ||(t2.shockSlopeFlag == SLOPE_CEILING_ONLY))
							{
							return t2.ceilingHeight+t2.shockSteep ;
							}
						else
							{
							return t2.ceilingHeight;
							}
							break;
					default:
						return t2.ceilingHeight;
						break;
					}
				//if (t2.tileType == TILE_SLOPE_S)
				//	{
				//	if ((t2.shockSlopeFlag == SLOPE_BOTH_OPPOSITE) ||(t2.shockSlopeFlag == SLOPE_CEILING_ONLY))
				//		{
				//		return t2.ceilingHeight+t2.shockSteep ;
				//		}
				//	else
				//		{
				//		return t2.ceilingHeight;
				//		}
				//	}
				break;
				}	
			case fEAST:
				{
				switch (t2.tileType)
					{
					case TILE_SLOPE_E:
					case TILE_SLOPE_W:
						if ((t2.shockSlopeFlag == SLOPE_BOTH_OPPOSITE) ||(t2.shockSlopeFlag == SLOPE_CEILING_ONLY))
							{
							return t2.ceilingHeight+t2.shockSteep ;
							}
						else
							{
							return t2.ceilingHeight;
							}
							break;
					default:
						return t2.ceilingHeight;
						break;
					}
				}	
			case fWEST:
				{
				switch (t2.tileType)
					{
					case TILE_SLOPE_W:
					case TILE_SLOPE_E:
						if ((t2.shockSlopeFlag == SLOPE_BOTH_OPPOSITE) ||(t2.shockSlopeFlag == SLOPE_CEILING_ONLY))
							{
							return t2.ceilingHeight+t2.shockSteep ;
							}
						else
							{
							return t2.ceilingHeight;
							}
							break;
					default:
						return t2.ceilingHeight;
						break;
					}
				}
			}
		}
	return t2.ceilingHeight;
}

void setBridgeBits(tile LevelInfo[64][64], ObjectItem objList[1600])
	{//So I know if the tile contains a bridge
	ObjectItem currObj;
	for (int x = 0; x<64; x++)
		{
		for (int y = 0; y<64; y++)
			{
			if (LevelInfo[x][y].indexObjectList != 0)
				{
				currObj = objList[LevelInfo[x][y].indexObjectList];
				do
					{
					if ((objectMasters[objList[currObj.index].item_id].type == BRIDGE))
						{
						if (currObj.flags < 2)//Only tag the tiles if this is a standard bridge
							{
							LevelInfo[x][y].hasBridge = 1;
							}
						else
							{
							LevelInfo[x][y].hasBridge = 0;
							}
						}
					currObj = objList[currObj.next];
					} while (currObj.index != 0);
				}
			}
		}
}


void SetExitBits(tile LevelInfo[64][64], ObjectItem objList[1600])
	{//Sets when a tile contains a move trigger that links to a teleport trap that goes to another level.
	ObjectItem currObj;
	for (int x = 0; x<64; x++)
		{
		for (int y = 0; y<64; y++)
			{
			LevelInfo[x][y].hasExit=0;
			if (LevelInfo[x][y].indexObjectList != 0)
				{
				currObj = objList[LevelInfo[x][y].indexObjectList];
				do
					{
					if ((objectMasters[objList[currObj.index].item_id].type == A_MOVE_TRIGGER))
						{
						//Now check what it links to.
						if (currObj.link > 0)
							{
							ObjectItem triggerTarget = objList[currObj.link];
							if ((objectMasters[triggerTarget.item_id].type == A_TELEPORT_TRAP))
								{
								if (triggerTarget.zpos > 0)
									{//This is a teleport that goes to another level.
									LevelInfo[x][y].hasExit = 1;
									}
								}
							}
						}
					currObj = objList[currObj.next];
					} while (currObj.index != 0);
				}
			}

		}
	}

void setDoorBits(tile LevelInfo[64][64], ObjectItem objList[1600])
{//So I know if the tile contains a door.
ObjectItem currObj;
for (int x=0; x<64;x++)
	{
	for (int y=0;y<64;y++)
		{
		if (LevelInfo[x][y].indexObjectList !=0)
			{
			currObj = objList[LevelInfo[x][y].indexObjectList];
			do  
				{
				if ((objectMasters[objList[currObj.index].item_id].type == DOOR ) 
						|| (objectMasters[objList[currObj.index].item_id].type == HIDDENDOOR )
							|| (objectMasters[objList[currObj.index].item_id].type == PORTCULLIS))
				 {
					if (currObj.Angle1 >0)
					{
						//This door is a flat grating. I don't support that yet!
						break;
					}
					else
					{
					LevelInfo[x][y].isDoor = 1;
					LevelInfo[x][y].DoorIndex = currObj.index;
					}
					break;
					}
				else
				{
					if (objectMasters[objList[currObj.index].item_id].type == SHOCK_DOOR)
						{
						LevelInfo[x][y].shockDoor = 1;
						LevelInfo[x][y].DoorIndex = currObj.index;
						}
				}
				currObj=objList[currObj.next];
				}while (currObj.index !=0);
			}
		}
	
	}
}

void setPatchBits(tile LevelInfo[64][64], ObjectItem objList[1600])
{//So I know the tile contains a patch object. No longer needed?
ObjectItem currObj;
for (int x=0; x<64;x++)
	{
	for (int y=0;y<64;y++)
		{
		if (LevelInfo[x][y].indexObjectList !=0)
			{
			currObj = objList[LevelInfo[x][y].indexObjectList];
			do  
				{
				if ((objectMasters[objList[currObj.index].item_id].type == TMAP_SOLID ) || (objectMasters[objList[currObj.index].item_id].type == TMAP_CLIP ))
					{
					LevelInfo[x][y].hasPatch= 1;
//					LevelInfo[x][y].PatchIndex = currObj.index;
					break;
					}
				currObj=objList[currObj.next];
				}while (currObj.index !=0);
			}
		}
	
	}
}

void setElevatorBits(tile LevelInfo[64][64], ObjectItem objList[1600])
{//So I know the tile contains an elevator.
//Note for shock this is set when I read in the object. I should probably do the same for UW.
ObjectItem currObj;
for (int x=0; x<64;x++)
	{
	for (int y=0;y<64;y++)
		{
		if (LevelInfo[x][y].indexObjectList !=0)
			{
			currObj = objList[LevelInfo[x][y].indexObjectList];
			do  
				{
				if ((objectMasters[objList[currObj.index].item_id].type == A_DO_TRAP ) && (currObj.quality==3))
					{
					LevelInfo[x][y].hasElevator= 1;
					//LevelInfo[x][y].ElevatorIndex = currObj.index;
					currObj.tileX=x;
					currObj.tileY=y;
					break;
					}
				currObj=objList[currObj.next];
				}while (currObj.index !=0);
			}
		}
	
	}	
	
}

void setTerrainChangeBits(tile LevelInfo[64][64], ObjectItem objList[1600])
{//So I know that the tile terrains changes and I can later render both versions of the tile.
ObjectItem currObj;
for (int x=0; x<64;x++)
	{
	for (int y=0;y<64;y++)
		{
		if (LevelInfo[x][y].indexObjectList !=0)
			{
			currObj = objList[LevelInfo[x][y].indexObjectList];
			do  
				{
				if (objectMasters[objList[currObj.index].item_id].type == A_CHANGE_TERRAIN_TRAP )
					{
					LevelInfo[x][y].TerrainChange= 1;
					//LevelInfo[x][y].TerrainChangeIndex = currObj.index;
					//Need to flag the range of tiles affected. X/y of the object gives the dimensions
					for (int j=x; j<= x+currObj.x; j++ )
						{
						for (int k=y; k<= y+currObj.y; k++  )
							{
							LevelInfo[j][k].TerrainChange = 1;
							LevelInfo[j][k].TerrainChangeIndices[LevelInfo[j][k].TerrainChangeCount]=currObj.index;
							LevelInfo[j][k].TerrainChangeCount++;
							//LevelInfo[j][k].isWater  = 0;// turn off water in terrain change tiles
							if (LevelInfo[j][k].isDoor==1)//The tile contains a door. I need to make sure the door is created at the height of the tile.
								{
								objList[LevelInfo[j][k].DoorIndex].zpos = objList[currObj.index].zpos;
								}
							}						
						}
					currObj.tileX=x;
					currObj.tileY=y;
					//break;
					}
				currObj=objList[currObj.next];
				}while (currObj.index !=0);
			}
		}
	
	}	
	
}

void SetContainerInUse(int game, tile LevelInfo[64][64], ObjectItem objList[1600], int index)
	{
	//Take a container/npc and set inuseflag for it contents. 
	ObjectItem currobj = objList[index];
	//currobj.InUseFlag == 1;
	objList[index].InUseFlag=1;
	if (currobj.link != 0)
		{//Object has contents.
		ObjectItem tmpObj = objList[currobj.link];//Get the first item in the contents.
		objList[tmpObj.index].InUseFlag=1;
		if ((isContainer(tmpObj)) || (objectMasters[tmpObj.item_id].type == NPC))
			{//If the first item is a container recursively set it's flag
			SetContainerInUse(game, LevelInfo, objList, tmpObj.index);
			}
		//Now loop through the linked list.
		if (tmpObj.next > 0)
			{
			while (tmpObj.next > 0)
				{
				tmpObj = objList[tmpObj.next];
				objList[tmpObj.index].InUseFlag = 1;
				//if the next object is a countainer loop through it.
				if ((isContainer(tmpObj)) || (objectMasters[tmpObj.item_id].type == NPC))
					{//If the first item is a container recursively set it's flag
					SetContainerInUse(game, LevelInfo, objList, tmpObj.index);
					}
				}
			}
		tmpObj.InUseFlag = 1;
		}
	}

void setObjectTileXY(int game, tile LevelInfo[64][64], ObjectItem objList[1600])
{//Justs some useful info to know.
//ObjectItem currObj;
for (int x=0; x<64;x++)
	{
	for (int y=0;y<64;y++)
		{
		if ((x == 3) && (y == 33))
			{
			printf("");
			}
		if (LevelInfo[x][y].indexObjectList !=0)
			{
			long nextObj=LevelInfo[x][y].indexObjectList;
			while (nextObj!=0)
				{
				objList[nextObj].tileX=x;
				objList[nextObj].tileY=y;
				objList[nextObj].InUseFlag = 1;
				if ((isContainer(objList[nextObj])) || (objectMasters[objList[nextObj].item_id].type == NPC))
					{
					SetContainerInUse(game, LevelInfo,objList, objList[nextObj].index);
					}
				else if (objectMasters[objList[nextObj].item_id].type == A_CREATE_OBJECT_TRAP)
					{
					if (objList[nextObj].InUseFlag == 0)
						{
						objList[nextObj].tileX = x;
						objList[nextObj].tileY = y;
						objList[nextObj].InUseFlag = 1;
						}
						if ( 
							(objectMasters[objList[objList[nextObj].link].item_id].type == NPC)
								&& 
								(objList[objList[nextObj].link].InUseFlag==0)
								)
							{
							SetContainerInUse(game, LevelInfo, objList, objList[objList[nextObj].link].index);
							}
						}
					
				nextObj=objList[nextObj].next;
				}
			}
		}	

	for (int i = 0; i < 1024;i++)
		{//Make sure triggers and traps are created.
		if (objList[i].InUseFlag == 0)
			{
			if ((isTrigger(objList[i]) )|| (isTrap(objList[i])))
				{
				objList[i].InUseFlag=1;
				}
			}
		}

	}

//Set traps to create at the point where they are first linked.
for (int i = 0; i < 1024; i++)
	{
	int nextLink =0; 
	if ((isTrap(objList[i])) && (objList[i].InUseFlag == 1))
		{
		int nextLink =objList[i].link;
		int x = objList[i].tileX;
		int y = objList[i].tileY;
		while ((isTrap(objList[nextLink])) && (nextLink != 0))
			{
			if (objList[nextLink].InUseFlag != 1)
				{
				objList[nextLink].tileX = x;
				objList[nextLink].tileY = y;
				objList[nextLink].InUseFlag = 1;
				nextLink = objList[nextLink].link;
				if (objectMasters[objList[nextLink].item_id].type == A_DELETE_OBJECT_TRAP)
					{
					nextLink = 0;
					}
				}
			else
				{
				nextLink=0;
				}
			}
		}
	}
}




void MergeWaterRegions(tile LevelInfo[64][64])
{
int currRegion;
currRegion =1;
	for (int x = 0; x<64; x++)
	{
		for (int y = 0; y<64; y++)
		{
		if (LevelInfo[x][y].hasBridge != 1)
			{
			if ((LevelInfo[x][y].isWater == 1) && (LevelInfo[x][y].waterRegion == 0))//Unset water region.
				{
				LevelInfo[x][y].waterRegion = currRegion;
				MergeCurrentWaterRegion(LevelInfo, currRegion, x, y);
				currRegion++;
				}
			}
		}
	}
}

void MergeCurrentWaterRegion(tile LevelInfo[64][64], int currRegion, int x, int y)
{
	//north
	if ((LevelInfo[x][y+1].isWater==1) && (LevelInfo[x][y+1].waterRegion == 0))
		{
		LevelInfo[x][y + 1].waterRegion = currRegion;
		MergeCurrentWaterRegion(LevelInfo, currRegion, x, y+1);
		}
	//south
	if ((LevelInfo[x][y - 1].isWater == 1) && (LevelInfo[x][y - 1].waterRegion == 0))
	{
	LevelInfo[x][y - 1].waterRegion = currRegion;
		MergeCurrentWaterRegion(LevelInfo, currRegion, x , y-1);
	}
	//east
	if ((LevelInfo[x + 1][y].isWater == 1) && (LevelInfo[x + 1][y].waterRegion == 0))
	{
	LevelInfo[x + 1][y].waterRegion = currRegion;
		MergeCurrentWaterRegion(LevelInfo, currRegion, x+1, y);
	}
	//west
	if ((LevelInfo[x - 1][y].isWater == 1) && (LevelInfo[x - 1][y].waterRegion == 0))
	{
	LevelInfo[x - 1][y].waterRegion = currRegion;
		MergeCurrentWaterRegion(LevelInfo, currRegion, x-1, y);
	}
}



void MergeLavaRegions(tile LevelInfo[64][64])
	{
	int currRegion;
	currRegion = 1;
	for (int x = 0; x<64; x++)
		{
		for (int y = 0; y<64; y++)
			{
			if (LevelInfo[x][y].hasBridge != 1)
				{
				if ((LevelInfo[x][y].isLava == 1) && (LevelInfo[x][y].lavaRegion == 0))//Unset lava region.
					{
					LevelInfo[x][y].lavaRegion = currRegion;
					MergeCurrentLavaRegion(LevelInfo, currRegion, x, y);
					currRegion++;
					}
				}
			}
		}
	}

void MergeCurrentLavaRegion(tile LevelInfo[64][64], int currRegion, int x, int y)
	{
	//north
	if ((LevelInfo[x][y + 1].isLava == 1) && (LevelInfo[x][y + 1].lavaRegion == 0))
		{
		LevelInfo[x][y + 1].lavaRegion = currRegion;
		MergeCurrentLavaRegion(LevelInfo, currRegion, x, y + 1);
		}
	//south
	if ((LevelInfo[x][y - 1].isLava == 1) && (LevelInfo[x][y - 1].lavaRegion == 0))
		{
		LevelInfo[x][y - 1].lavaRegion = currRegion;
		MergeCurrentLavaRegion(LevelInfo, currRegion, x, y - 1);
		}
	//east
	if ((LevelInfo[x + 1][y].isLava == 1) && (LevelInfo[x + 1][y].lavaRegion == 0))
		{
		LevelInfo[x + 1][y].lavaRegion = currRegion;
		MergeCurrentLavaRegion(LevelInfo, currRegion, x + 1, y);
		}
	//west
	if ((LevelInfo[x - 1][y].isLava == 1) && (LevelInfo[x - 1][y].lavaRegion == 0))
		{
		LevelInfo[x - 1][y].lavaRegion = currRegion;
		MergeCurrentLavaRegion(LevelInfo, currRegion, x - 1, y);
		}
	}

void setTileNeighbourCount(tile LevelInfo[64][64])
{ 

	for (int x = 0; x<64; x++)
	{
		for (int y = 0; y<64; y++)
		{
			if (LevelInfo[x][y].tileType != TILE_SOLID)
			{
			
			//test north
				if (y != 63)
					{
					if (LevelInfo[x][y + 1].tileType!=TILE_SOLID)
						{
						LevelInfo[x][y].noOfNeighbours++;
						}
					}

			//test south
				if (y != 0)
				{
					if (LevelInfo[x][y - 1].tileType != TILE_SOLID)
					{
						LevelInfo[x][y].noOfNeighbours++;
					}
				}
	
			//test east
				if (x != 63)
				{
					if (LevelInfo[x+1][y].tileType != TILE_SOLID)
					{
						LevelInfo[x][y].noOfNeighbours++;
					}
				}

			//test west
				if (y != 0)
				{
					if (LevelInfo[x-1][y].tileType != TILE_SOLID)
					{
						LevelInfo[x][y].noOfNeighbours++;
					}
				}
			}
			else
			{
				LevelInfo[x][y].noOfNeighbours=0;
			}
		}
	}
}

void setCorridors(tile LevelInfo[64][64], int *RoomIndex)
{
return;
//int corridorIndex=1;
	for (int x = 0; x<64; x++)
	{
		for (int y = 0; y<64; y++)
		{
			if (((LevelInfo[x][y].noOfNeighbours == 1) || (LevelInfo[x][y].noOfNeighbours == 2))
				&&
				(LevelInfo[x][y].tileTested == 0)  && (LevelInfo[x][y].isDoor == 0) && (LevelInfo[x][y].isWater == 0))
				{
				if (*RoomIndex == 17)
				{
					fprintf(LOGFILE,"");
				}
				int currentCorridorCount=0;
				MergeCorridors(LevelInfo, &currentCorridorCount, *RoomIndex, x, y,0);
				if (currentCorridorCount >= 4)
					{//Found a corridor
						ResetTileTests(LevelInfo);
						LevelInfo[x][y].isCorridor = 1;
						LevelInfo[x][y].landRegion = *RoomIndex;
						MergeCorridors(LevelInfo, &currentCorridorCount, *RoomIndex, x, y, 1);
						*RoomIndex = *RoomIndex +1;
					}
				}
		}

	}

}

void MergeCorridors(tile LevelInfo[64][64], int *currentCorridorCount, int corridorIndex, int x, int y, int SetValue)
{
	if (((LevelInfo[x][y].noOfNeighbours == 1) || (LevelInfo[x][y].noOfNeighbours == 2))
		&&
		((LevelInfo[x][y].tileTested == 0)) && (LevelInfo[x][y].isDoor == 0) && (LevelInfo[x][y].isWater == 0))
			{
	
			if (LevelInfo[x][y].tileTested != 1)
				{
				*currentCorridorCount = *currentCorridorCount+1;
				LevelInfo[x][y].tileTested = 1;

				//test north
				if (y < 63)
					{
					MergeCorridors(LevelInfo, currentCorridorCount, corridorIndex, x, y + 1,SetValue);
					}

				//test south
				if (y > 0)
					{
					MergeCorridors(LevelInfo, currentCorridorCount, corridorIndex, x, y - 1, SetValue);
					}

				//test east
				if (x < 63)
					{
					MergeCorridors(LevelInfo, currentCorridorCount, corridorIndex, x + 1, y, SetValue);
					}
				//test west
				if (x > 0)
					{
					MergeCorridors(LevelInfo, currentCorridorCount, corridorIndex, x - 1, y, SetValue);
					}
				
				if (SetValue == 1)
					{
						LevelInfo[x][y].isCorridor = 1;
						LevelInfo[x][y].landRegion = corridorIndex;
					}
			}
		else
			{
			LevelInfo[x][y].tileTested = 1;
			}
	
	}
}


void setRooms(tile LevelInfo[64][64],int *RoomIndex)
{
	ResetTileTests(LevelInfo);
	for (int x = 0; x<64; x++)
	{
		for (int y = 0; y<64; y++)
		{
		currRoomIndex = *RoomIndex;
			if (isMergeableRoom(LevelInfo,x,y))
				{//Start Merging
				MergeCurrentRoomRegion(LevelInfo, *RoomIndex, x, y);
				LevelInfo[x][y].landRegion = *RoomIndex;
				*RoomIndex = *RoomIndex+1;
				}
		}
	}
}

void MergeCurrentRoomRegion(tile LevelInfo[64][64], int currRegion, int x, int y)
{
	//north
if (isMergeableRoom(LevelInfo, x, y + 1))
	{
		LevelInfo[x][y+1].landRegion = currRegion;
		MergeCurrentRoomRegion(LevelInfo, currRegion, x, y + 1);
	}
	//south
if (isMergeableRoom(LevelInfo, x, y - 1))
	{
		LevelInfo[x][y-1].landRegion = currRegion;
		MergeCurrentRoomRegion(LevelInfo, currRegion, x, y - 1);
	}
	//east
if (isMergeableRoom(LevelInfo, x + 1, y))
	{
		LevelInfo[x+1][y].landRegion = currRegion;
		MergeCurrentRoomRegion(LevelInfo, currRegion, x + 1, y);
	}
	//west
if (isMergeableRoom(LevelInfo, x - 1, y))
	{
		LevelInfo[x-1][y].landRegion = currRegion;
		MergeCurrentRoomRegion(LevelInfo, currRegion, x - 1, y);
	}
}


void ResetTileTests(tile LevelInfo[64][64])
{
	for (int x = 0; x<64; x++)
	{
		for (int y = 0; y<64; y++)
		{
			LevelInfo[x][y].tileTested=0;
		}
	}
}

int isMergeableRoom(tile LevelInfo[64][64], int x, int y)
{

if (
	(LevelInfo[x][y].isWater == 0)
	&&
	(LevelInfo[x][y].isLava == 0)
	&&
	(LevelInfo[x][y].tileType != TILE_SOLID)
	&&
	(LevelInfo[x][y].landRegion == 0)
	)
	{
	return 1;
	}
else
	{
	if ((LevelInfo[x][y].hasBridge == 1) && (LevelInfo[x][y].bridgeRegion == 0))
		{
		LevelInfo[x][y].bridgeRegion = currRoomIndex;
		return 1;
		}
	else
		{
		return 0;
		}	
	}
/*
	if (
		(LevelInfo[x][y].isDoor == 0)
		&&
		(LevelInfo[x][y].isWater == 0)
		&&
		(LevelInfo[x][y].shockDoor == 0)
		&&
		(LevelInfo[x][y].tileType != TILE_SOLID)
		&&
		(LevelInfo[x][y].isCorridor==0)
		&&
		(LevelInfo[x][y].roomRegion==0)
		)
		{
		return 1;
		}
	else
		{
		return 0;
		}
		*/
}


void CleanUp(tile LevelInfo[64][64], int game, int CleanupType, int tileType, int Surface)
{
int j;
	switch (CleanupType)
	{
	case CLEANUPHIDDEN:
		{
		CleanUpHiddenTiles(LevelInfo, game);
		break;
		}
	case CLEANUPXAXIS:
		{
		j = 1;
		//Now lets combine the solids along particular axis
		for (int x = 0; x<64; x++){
			for (int y = 0; y<63; y++){
				if ((LevelInfo[x][y].Grouped == 0) && (LevelInfo[x][y].tileType==tileType))
				{
					j = 1;
					while ((LevelInfo[x][y].Render == 1) && (LevelInfo[x][y + j].Render == 1) && (LevelInfo[x][y + j].Grouped == 0))		//&& (LevelInfo[x][y].tileType ==0) && (LevelInfo[x][y+j].tileType ==0)
					{
						//combine these two if they match and they are not already part of a group
						if (DoTilesMatch(LevelInfo[x][y], LevelInfo[x][y + j],Surface)){
							LevelInfo[x][y + j].Render = 0;
							LevelInfo[x][y + j].Grouped = 1;
							LevelInfo[x][y].Grouped = 1;
							//LevelInfo[x][y].DimY++;
							j++;
						}
						else
						{
							break;
						}

					}
					LevelInfo[x][y].DimY = LevelInfo[x][y].DimY + j - 1;
					j = 1;
				}
			}
		}
		break;
		}
	case CLEANUPYAXIS:
		{
		for (int y = 0; y<64; y++)
			{
			for (int x = 0; x<63; x++)
				{
				if ((LevelInfo[x][y].Grouped == 0) && (LevelInfo[x][y].tileType == tileType))
					{
						j = 1;
						while ((LevelInfo[x][y].Render == 1) && (LevelInfo[x + j][y].Render == 1) && (LevelInfo[x + j][y].Grouped == 0))		//&& (LevelInfo[x][y].tileType ==0) && (LevelInfo[x][y+j].tileType ==0)
						{
							//combine these two if they match and they are not already part of a group
							if (DoTilesMatch(LevelInfo[x][y], LevelInfo[x + j][y],Surface)){
								LevelInfo[x + j][y].Render = 0;
								LevelInfo[x + j][y].Grouped = 1;
								LevelInfo[x][y].Grouped = 1;
								//LevelInfo[x][y].DimY++;
								j++;
							}
							else
							{
								break;
							}

						}
						LevelInfo[x][y].DimX = LevelInfo[x][y].DimX + j - 1;
						j = 1;
					}
				}
			}
		}
	}
}

void ResetCleanup(tile LevelInfo[64][64], int game)
{//Resets tile cleanup so I can retest with new rules.
	for (int y = 0; y <= 63; y++)
	{
		for (int x = 0; x <= 63; x++)
		{
			LevelInfo[x][y].Render = 1;
			LevelInfo[x][y].Grouped = 0;
			LevelInfo[x][y].DimX = 1;
			LevelInfo[x][y].DimY = 1;
			LevelInfo[x][y].UpperEast = LevelInfo[x][y].East;
			LevelInfo[x][y].UpperWest = LevelInfo[x][y].West;
			LevelInfo[x][y].UpperNorth = LevelInfo[x][y].North;
			LevelInfo[x][y].UpperSouth = LevelInfo[x][y].South;
		}
	}
}


void CleanUpHiddenTiles(tile LevelInfo[64][64], int game)
{
	for (int x = 0; x<64; x++){
		for (int y = 0; y<64; y++){
			//lets test this tile for visibility
			//A tile is invisible if it only touches other solid tiles and has no objects or does not have a terrain change.
			if ((LevelInfo[x][y].tileType == 0) && (LevelInfo[x][y].indexObjectList == 0) && (LevelInfo[x][y].TerrainChange == 0)){
				switch (y)
				{
				case 0:	//bottom row
					switch (x)
					{
					case 0:	//bl corner
						if ((LevelInfo[x + 1][y].tileType == 0) && (LevelInfo[x][y + 1].tileType == 0)
							&& (LevelInfo[x + 1][y].TerrainChange == 0) && (LevelInfo[x][y + 1].TerrainChange == 0))
						{
							LevelInfo[x][y].Render = 0;; break;
						}
						else { LevelInfo[x][y].Render = 1; break; }
					case 63://br corner
						if ((LevelInfo[x - 1][y].tileType == 0) && (LevelInfo[x][y + 1].tileType == 0)
							&& (LevelInfo[x - 1][y].TerrainChange == 0) && (LevelInfo[x][y + 1].TerrainChange == 0))
						{
							LevelInfo[x][y].Render = 0; break;
						}
						else { LevelInfo[x][y].Render = 1; break; }
					default: // invert t
						if ((LevelInfo[x + 1][y].tileType == 0) && (LevelInfo[x][y + 1].tileType == 0) && (LevelInfo[x + 1][y].tileType == 0)
							&& (LevelInfo[x + 1][y].TerrainChange == 0) && (LevelInfo[x][y + 1].TerrainChange == 0) && (LevelInfo[x + 1][y].TerrainChange == 0))
						{
							LevelInfo[x][y].Render = 0; break;
						}
						else { LevelInfo[x][y].Render = 1; break; }
					}
					break;
				case 63: //Top row
					switch (x)
					{
					case 0:	//tl corner
						if ((LevelInfo[x + 1][y].tileType == 0) && (LevelInfo[x][y - 1].tileType == 0)
							&& (LevelInfo[x + 1][y].TerrainChange == 0) && (LevelInfo[x][y - 1].TerrainChange == 0))
						{
							LevelInfo[x][y].Render = 0; break;
						}
						else { LevelInfo[x][y].Render = 1; break; }
					case 63://tr corner
						if ((LevelInfo[x - 1][y].tileType == 0) && (LevelInfo[x][y - 1].tileType == 0)
							&& (LevelInfo[x - 1][y].TerrainChange == 0) && (LevelInfo[x][y - 1].TerrainChange == 0))
						{
							LevelInfo[x][y].Render = 0; break;
						}
						else { LevelInfo[x][y].Render = 1; break; }
					default: //  t
						if ((LevelInfo[x + 1][y].tileType == 0) && (LevelInfo[x][y - 1].tileType == 0) && (LevelInfo[x - 1][y].tileType == 0)
							&& (LevelInfo[x + 1][y].TerrainChange == 0) && (LevelInfo[x][y - 1].TerrainChange == 0) && (LevelInfo[x - 1][y].TerrainChange == 0))
						{
							LevelInfo[x][y].Render = 0; break;
						}
						else { LevelInfo[x][y].Render = 1; break; }
					}
					break;
				default: //
					switch (x)
					{
					case 0:		//left edge
						if ((LevelInfo[x][y + 1].tileType == 0) && (LevelInfo[x + 1][y].tileType == 0) && (LevelInfo[x][y - 1].tileType == 0)
							&& (LevelInfo[x][y + 1].TerrainChange == 0) && (LevelInfo[x + 1][y].TerrainChange == 0) && (LevelInfo[x][y - 1].TerrainChange == 0))
						{
							LevelInfo[x][y].Render = 0; break;
						}
						else { LevelInfo[x][y].Render = 1; break; }
					case 63:	//right edge
						if ((LevelInfo[x][y + 1].tileType == 0) && (LevelInfo[x - 1][y].tileType == 0) && (LevelInfo[x][y - 1].tileType == 0)
							&& (LevelInfo[x][y + 1].TerrainChange == 0) && (LevelInfo[x - 1][y].TerrainChange == 0) && (LevelInfo[x][y - 1].TerrainChange == 0))
						{
							LevelInfo[x][y].Render = 0; break;
						}
						else { LevelInfo[x][y].Render = 1; break; }
					default:		//+
						if ((LevelInfo[x][y + 1].tileType == 0) && (LevelInfo[x + 1][y].tileType == 0) && (LevelInfo[x][y - 1].tileType == 0) && (LevelInfo[x - 1][y].tileType == 0)
							&& (LevelInfo[x][y + 1].TerrainChange == 0) && (LevelInfo[x + 1][y].TerrainChange == 0) && (LevelInfo[x][y - 1].TerrainChange == 0) && (LevelInfo[x - 1][y].TerrainChange == 0))
						{
							LevelInfo[x][y].Render = 0; break;
						}
						else { LevelInfo[x][y].Render = 1; break; }
					}
					break;
				}
			}
		}
	}
}


int DoTilesMatch(tile &t1, tile &t2, int Surface)
{//TODO:Tiles have a lot more properties now.
	if ((t1.hasElevator == 1) || (t1.TerrainChange == 1) || (t2.hasElevator == 1) || (t2.TerrainChange == 1) || (t1.isWater != t2.isWater) || (t2.BullFrog == 1) || (t2.BullFrog == 1))
		{	//autofail on special or changes to water
		return 0;
		}

	switch (Surface)
	{
	case SURFACE_FLOOR:
		{
		if ((t1.tileType == 0) && (t2.tileType == 0))	//solid
			{
			return ((t1.wallTexture == t2.wallTexture) 
				&& (t1.West == t2.West) && (t1.South == t2.South) 
				&& (t1.East == t2.East) && (t1.North == t2.North) 
				&& (t1.UseAdjacentTextures == t2.UseAdjacentTextures));
			}
		else
		{
			return (t1.shockCeilingTexture == t2.shockCeilingTexture)
				&& (t1.floorTexture == t2.floorTexture)
				&& (t1.floorHeight == t2.floorHeight)
				&& (t1.isWater == t2.isWater)
				&& (t1.DimX == t2.DimX) && (t1.DimY == t2.DimY)
				&& (t1.LowerWest == t2.LowerWest) && (t1.LowerSouth == t2.LowerSouth) && (t1.LowerEast == t2.LowerEast) && (t1.LowerNorth == t2.LowerNorth) 
				&& (t1.UseAdjacentTextures == t2.UseAdjacentTextures)
				&& (t1.tileType == t2.tileType);
		}
		break;
		}
	case SURFACE_CEIL:
		{
		if ((t1.tileType == 0) && (t2.tileType == 0))	//solid
		{
			return ((t1.wallTexture == t2.wallTexture) && (t1.West == t2.West) && (t1.South == t2.South) && (t1.East == t2.East) && (t1.North == t2.North) && (t1.UseAdjacentTextures == t2.UseAdjacentTextures));
		}
		else
		{
			return (t1.shockCeilingTexture == t2.shockCeilingTexture)
				&& (t1.ceilingHeight == t2.ceilingHeight)
				&& (t1.DimX == t2.DimX) && (t1.DimY == t2.DimY)
				&& (t1.UpperWest == t2.UpperWest) && (t1.UpperSouth == t2.UpperSouth) && (t1.UpperEast == t2.UpperEast) && (t1.UpperNorth == t2.UpperNorth)
				&& (t1.UseAdjacentTextures == t2.UseAdjacentTextures)
				&& (t1.tileType == t2.tileType);
		}
		break;
		}	
	default:
		return 0;
	}
	//return (t1.shockCeilingTexture == t2.shockCeilingTexture)
	//	&& (t1.floorTexture == t2.floorTexture)
	//	&& (t1.floorHeight == t2.floorHeight)
	//	&& (t1.ceilingHeight == t2.ceilingHeight)
	//	&& (t1.DimX == t2.DimX) && (t1.DimY == t2.DimY)
	//	&& (t1.wallTexture == t2.wallTexture)
	//	&& (t1.tileType == t2.tileType)
	//	&& (t1.isDoor == 0) && (t2.isDoor == 0);

}

void CaulkHiddenWalls(tile LevelInfo[64][64], int game, int surface)
{
	for (int x = 1; x < 62; x++)
		{
		for (int y = 1; y < 62; y++)
			{
			if (LevelInfo[x][y].tileType == TILE_OPEN)
				{
				switch (surface)
					{
					case SURFACE_CEIL:
						{
						if (((LevelInfo[x][y].ceilingHeight == LevelInfo[x][y + 1].ceilingHeight) 
								&& (LevelInfo[x][y + 1].tileType == TILE_OPEN)) || (LevelInfo[x][y + 1].tileType == TILE_SOLID))
							{
							LevelInfo[x][y].UpperNorth=CAULK;
							}
						if (((LevelInfo[x][y].ceilingHeight == LevelInfo[x][y - 1].ceilingHeight) 
								&& (LevelInfo[x][y - 1].tileType == TILE_OPEN)) || (LevelInfo[x][y - 1].tileType == TILE_SOLID))
							{
							LevelInfo[x][y].UpperSouth = CAULK;
							}
						if (((LevelInfo[x][y].ceilingHeight == LevelInfo[x+1][y].ceilingHeight) 
								&& (LevelInfo[x+1][y].tileType == TILE_OPEN)) || (LevelInfo[x+1][y].tileType == TILE_SOLID))
							{
							LevelInfo[x][y].UpperEast = CAULK;
							}
						if (((LevelInfo[x][y].ceilingHeight == LevelInfo[x-1][y].ceilingHeight) 
								&& (LevelInfo[x - 1][y].tileType == TILE_OPEN)) || (LevelInfo[x - 1][y].tileType == TILE_SOLID))
						{
							LevelInfo[x][y].UpperWest = CAULK;
						}
						break;
						}
					case SURFACE_FLOOR:
						{
							if ((((LevelInfo[x][y].floorHeight == LevelInfo[x][y + 1].floorHeight) 
								&& (LevelInfo[x][y + 1].tileType == TILE_OPEN)) || (LevelInfo[x][y + 1].tileType == TILE_SOLID))
								&& (LevelInfo[x][y+1].isWater==0))
							{
								LevelInfo[x][y].LowerNorth = CAULK;
							}
							if ((((LevelInfo[x][y].floorHeight == LevelInfo[x][y - 1].floorHeight) 
								&& (LevelInfo[x][y - 1].tileType == TILE_OPEN)) || (LevelInfo[x][y - 1].tileType == TILE_SOLID))
								&& (LevelInfo[x][y - 1].isWater == 0))
							{
								LevelInfo[x][y].LowerSouth = CAULK;
							}
							if ((((LevelInfo[x][y].floorHeight == LevelInfo[x + 1][y].floorHeight) 
								&& (LevelInfo[x + 1][y].tileType == TILE_OPEN)) || (LevelInfo[x + 1][y].tileType == TILE_SOLID))
								&& (LevelInfo[x+1][y].isWater == 0))
							{
								LevelInfo[x][y].LowerEast = CAULK;
							}
							if ((((LevelInfo[x][y].floorHeight == LevelInfo[x - 1][y].floorHeight) 
								&& (LevelInfo[x - 1][y].tileType == TILE_OPEN)) || (LevelInfo[x - 1][y].tileType == TILE_SOLID))
								&& (LevelInfo[x-1][y].isWater == 0))
							{
								LevelInfo[x][y].LowerWest = CAULK;
							}
						break;
						}
					}
				}
			}
		}
}
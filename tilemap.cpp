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

extern long SHOCK_CEILING_HEIGHT;
extern long UW_CEILING_HEIGHT;
int getShockObjectIndex(int objClass, int objSubClass, int objSubClassIndex);
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

//Reduces tile complexity. Hides hidden solids and merges matching tiles along axis.

	int x; int y;
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
						if ((LevelInfo[x+1][y].tileType == 0) && (LevelInfo[x][y+1].tileType == 0))
						{LevelInfo[x][y].Render =0 ; ;break;}
						else {LevelInfo[x][y].Render =1 ;break;}
					case 63://br corner
						if ((LevelInfo[x-1][y].tileType == 0) && (LevelInfo[x][y+1].tileType == 0))
						{LevelInfo[x][y].Render =0 ;break;}
						else {LevelInfo[x][y].Render =1 ;break;}
					default: // invert t
						if ((LevelInfo[x+1][y].tileType == 0) && (LevelInfo[x][y+1].tileType == 0) && (LevelInfo[x-1][y].tileType == 0))
						{LevelInfo[x][y].Render =0 ;break;}
						else {LevelInfo[x][y].Render =1 ;break;}
					}
					break;
				case 63: //Top row
					switch (x)
					{
					case 0:	//tl corner
						if ((LevelInfo[x+1][y].tileType == 0) && (LevelInfo[x][y-1].tileType == 0))
						{LevelInfo[x][y].Render =0 ;break;}
						else {LevelInfo[x][y].Render =1 ;break;}
					case 63://tr corner
						if ((LevelInfo[x-1][y].tileType == 0) && (LevelInfo[x][y-1].tileType == 0))
						{LevelInfo[x][y].Render =0 ;break;}
						else {LevelInfo[x][y].Render =1 ;break;}
					default: //  t
						if ((LevelInfo[x+1][y].tileType == 0) && (LevelInfo[x][y-1].tileType == 0) && (LevelInfo[x-1][y].tileType == 0))
						{LevelInfo[x][y].Render =0;break;}
						else {LevelInfo[x][y].Render =1 ;break;}
					}	
					break;
				default: //
					switch (x)
					{
					case 0:		//left edge
						if ((LevelInfo[x][y+1].tileType  == 0) && (LevelInfo[x+1][y].tileType  == 0) && (LevelInfo[x][y-1].tileType  == 0))
						{LevelInfo[x][y].Render =0;break;}
						else {LevelInfo[x][y].Render =1 ;break;}
					case 63:	//right edge
						if ((LevelInfo[x][y+1].tileType  == 0) && (LevelInfo[x-1][y].tileType  == 0) && (LevelInfo[x][y-1].tileType  == 0))
						{LevelInfo[x][y].Render =0 ;break;}
						else {LevelInfo[x][y].Render =1 ;break;}
					default:		//+
					if ((LevelInfo[x][y+1].tileType  == 0) && (LevelInfo[x+1][y].tileType  == 0) && (LevelInfo[x][y-1].tileType  == 0) && (LevelInfo[x-1][y].tileType  == 0) )
						{LevelInfo[x][y].Render =0; break;}
						else {LevelInfo[x][y].Render =1 ;break;}
					}
					break;
				}
			}
		}
	}
	if (game == SHOCK)
		{return;}
	int j=1 ;
	//Now lets combine the solids along particular axis
	for (x=0;x<64;x++){
		for (y=0;y<63;y++){
			if  ((LevelInfo[x][y].Grouped ==0))
			{
			j=1;
			while ((LevelInfo[x][y].Render ==1) && (LevelInfo[x][y+j].Render==1) && (LevelInfo[x][y+j].Grouped==0) )		//&& (LevelInfo[x][y].tileType ==0) && (LevelInfo[x][y+j].tileType ==0)
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
////Now combine parallel solids
//	for (x=0;x<64;x++){
//		for (y=0;y<63;y++){
//			if  ((LevelInfo[x][y].Grouped ==1) && (LevelInfo[x][y].Render  ==1))  //is a start of a group
//			{
//			//test it's next door neighbour
//				if  ((LevelInfo[x][y+1].Grouped ==1) && (LevelInfo[x][y+1].Render  ==1))	//Neighbour is also a group,
//				{
//				if (DoTilesMatch(LevelInfo[x][y],LevelInfo[x+LevelInfo[x][y+1].DimX][y+1]))//test the first tile against the opposite corner of it's neighbour
//				{
//					//they match. -> merge em.
//					LevelInfo[x][y].DimX++;
//					for ( int k =1; k <=LevelInfo[x][y+1].DimX;k++)
//					{
//					LevelInfo[k][y+1].Render =0;
//					LevelInfo[k][y+1].Grouped =1;
//					
//					}
//				}
//				}
//			}
//		}
//	}

	////Now lets combine solids along the other axis
for (y=0;y<64;y++){
		for (x=0;x<63;x++){
			if  ((LevelInfo[x][y].Grouped ==0))
			{
			j=1;
			while ((LevelInfo[x][y].Render ==1) && (LevelInfo[x+j][y].Render==1) && (LevelInfo[x+j][y].Grouped==0) )		//&& (LevelInfo[x][y].tileType ==0) && (LevelInfo[x][y+j].tileType ==0)
			{
			//combine these two if they match and they are not already part of a group
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

}



int DoTilesMatch(tile &t1, tile &t2)
{//TODO:Tiles have a lot more properties now.
	if ((t1.tileType >1) || (t1.hasElevator==1) || (t1.TerrainChange ==1) ||  (t2.hasElevator==1) || (t2.TerrainChange ==1) || (t1.isWater ==1) || (t2.isWater ==1)){	//autofail no none solid/open/special.
		return 0;
	}
	else
	{
//if ((t1.floorTexture == t2.floorTexture ) && (t1.floorHeight == t2.floorHeight)
//		&& (t1.DimX==t2.DimX) && (t1.DimY == t2.DimY ) 
//		 && (t1.tileType == t2.tileType ) 
//		 && (t1.isDoor==0) && (t2.isDoor ==0)) {
//printf("");
//}
	if ((t1.tileType==0) && (t2.tileType == 0))	//solid
		{
		return ((t1.West == t2.West) && (t1.South==t2.South) && (t1.East == t2.East) && (t1.North == t2.North));
		}
	else
		{
	return (t1.floorTexture == t2.floorTexture ) && (t1.floorHeight == t2.floorHeight)
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
	
	UW_CEILING_HEIGHT = ((128 >> 2) * 8 >>3);	//Shifts the scale of the level. Idea borrowed from abysmal
	
	switch (game)
	{
	case UWDEMO:	//UW Demo
		{
		if ((file = fopen(filePath, "rb")) == NULL)
			printf("Could not open specified file\n");
		else
			printf ("");
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
		filePath = UW0_TEXTUREW_PATH;	
		if ((fileT = fopen(filePath, "rb")) == NULL)
			printf("Could not open specified file\n");
		else
			printf ("");
		fileSize = getFileSize(fileT);
		tex_ark = new unsigned char[fileSize];
		fread(tex_ark, fileSize, 1,fileT);
		fclose(fileT);  		
		break;		
		}
	case UW1:	//UW1
		{
		if ((file = fopen(filePath, "rb")) == NULL)
			printf("Could not open specified file\n");
		else
			printf ("");
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
		if ((file = fopen(filePath, "rb")) == NULL)
			printf("Could not open specified file\n");
		else
			printf ("");
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
			printf("\nInvalid block address!\n");
			return -1;
			}
		if (isCompressed == 1)
			{
			lev_ark = unpack(tmp_ark,getValAtAddress(tmp_ark,address_pointer,32));
			address_pointer=address_pointer+4;
			AddressOfBlockStart=0;
			//ObjectsAddress=1024;
			address_pointer=0;
			}
		else
			{
			printf("uncompressed? what do i do here???");
			}	
		
		
		//read in the textures
		//address_pointer=(LevelNo * 4) + 6 + (80*4);
		//tex_ark = tmp_ark;	//unpack(tmp_ark,getValAtAddress(tmp_ark,address_pointer,32));
		textureAddress=getValAtAddress(tmp_ark,(LevelNo * 4) + 6 + (80*4),32);	
		
		compressionFlag=getValAtAddress(tmp_ark,(LevelNo * 4) + 6 + (80*4)+ (NoOfBlocks*4),32);
		isCompressed =(compressionFlag>>1) & 0x01;

		if (isCompressed == 1)
			{
			tex_ark = unpack(tmp_ark,textureAddress);
			textureAddress=-1;
			}
		break;
		}		
		
	}
	for (i=0; i<256;i++)
		{//TODO: Only use this for texture lookups.
		switch (game)
			{
			case UWDEMO:
				{texture_map[i] = getValAtAddress(tex_ark,textureAddress+(i*2),16);break;}//tex_ark[textureAddress+i];break;}
			case UW1:
				{texture_map[i] = getValAtAddress(lev_ark,textureAddress+(i*2),16);break;}
			case UW2:
				{
				if (textureAddress == -1)//Texture block was decompressed
					{
					texture_map[i] =getValAtAddress(tex_ark,(i*2),16);break;//tmp //textureAddress+
					}
				else
					{
					texture_map[i] =getValAtAddress(tmp_ark,textureAddress+(i*2),16);break;//tmp //textureAddress+
					}
				}
			}
		}
	 
	for (y=0; y<64;y++)
		{
		for (x=0; x<64;x++)
			{
				LevelInfo[x][y].tileX = x;
				LevelInfo[x][y].tileY = y;
				long FirstTileInt = getValAtAddress(lev_ark,AddressOfBlockStart+(address_pointer+0),16);
				// FirstTileInt = getValAtCoordinate(x,y,AddressOfBlockStart,lev_ark,16);
				//long SecondTileInt = (getValAtCoordinate(x,y,AddressOfBlockStart,lev_ark,32) >> 16);
				long SecondTileInt = getValAtAddress(lev_ark,AddressOfBlockStart+(address_pointer+2),16);
				address_pointer=address_pointer+4;

				LevelInfo[x][y].tileType = getTile(FirstTileInt) ;

				LevelInfo[x][y].floorHeight = getHeight(FirstTileInt) ;
				LevelInfo[x][y].floorHeight = ((LevelInfo[x][y].floorHeight <<3) >> 2)*8 >>3;	//Try and copy this shift from shock.

				LevelInfo[x][y].ceilingHeight = UW_CEILING_HEIGHT;	//constant for uw				
				
				switch (game)
					{
					case UWDEMO:	//special case for demo since textures mappings are in a seperate file
						LevelInfo[x][y].floorTexture = getFloorTex(tex_ark, textureAddress, FirstTileInt);
						LevelInfo[x][y].shockCeilingTexture = LevelInfo[x][y].floorTexture;
						break;
					case UW1:	//uw1
						LevelInfo[x][y].floorTexture = getFloorTex(lev_ark, textureAddress, FirstTileInt);
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
				LevelInfo[x][y].shockCeilingTexture = LevelInfo[x][y].floorTexture;					
				
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
				LevelInfo[x][y].VisibleFaces = 63;
				//LevelInfo[x][y].isWater = (textureMasters[LevelInfo[x][y].floorTexture].water == 1) && ((LevelInfo[x][y].tileType !=0));
				//Force off water to save on compile time during testing.
				LevelInfo[x][y].isWater=0;
				LevelInfo[x][y].TerrainChange=0;
				LevelInfo[x][y].hasElevator=0;
				
			}
		}
	for (y=0; y<64;y++)
		{
		for (x=0; x<64;x++)
			{
			if (LevelInfo[x][y].tileType == 0) //solid
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
			}
return 1;
}

void BuildObjectListUW(tile LevelInfo[64][64], ObjectItem objList[1600],long texture_map[256],char *filePath, int game, int LevelNo)
{
	FILE *file = NULL;      // File pointer
	unsigned char *lev_ark; 
	unsigned char *tmp_ark;		//for uw2 decompression
	long fileSize;
    int NoOfBlocks;
	long AddressOfBlockStart;
	long objectsAddress;
	long address_pointer;
	//int x;	



switch (game)
	{
	case UWDEMO:	//Underworld Demo
		{
		if ((file = fopen(filePath, "rb")) == NULL)
			printf("Could not open specified file\n");
		else
			printf ("");
		// Get the size of the file in bytes
		fileSize = getFileSize(file);
		// Allocate space in the buffer for the whole file
		lev_ark = new unsigned char[fileSize];
		// Read the file in to the buffer
		fread(lev_ark, fileSize, 1,file);
		fclose(file);  		
		//Get the first map block
		AddressOfBlockStart = 0;
		objectsAddress = AddressOfBlockStart + (64*64*4); //+ 1;
		address_pointer = 0;
		break;
		}
	case UW1:	//Underworld 1
		{
		if ((file = fopen(filePath, "rb")) == NULL)
			printf("Could not open specified file\n");
		else
			printf ("");
		// Get the size of the file in bytes
		fileSize = getFileSize(file);
		// Allocate space in the buffer for the whole file
		lev_ark = new unsigned char[fileSize];
		// Read the file in to the buffer
		fread(lev_ark, fileSize, 1,file);
		fclose(file);  		
		//Get the number of blocks in this file.
		NoOfBlocks = ConvertInt16(lev_ark[0],lev_ark[1]);
		//Get the first map block
		AddressOfBlockStart = getValAtAddress(lev_ark,(LevelNo * 4) + 2,32);
		objectsAddress = AddressOfBlockStart + (64*64*4); //+ 1;
		address_pointer =0;
		break;
	case UW2:	//Underworld 2
		{
		if ((file = fopen(filePath, "rb")) == NULL)
			printf("Could not open specified file\n");
		else
			printf ("");
		fileSize = getFileSize(file);
		tmp_ark = new unsigned char[fileSize];
		fread(tmp_ark, fileSize, 1,file);
		fclose(file);
						
		address_pointer=6;
		NoOfBlocks=getValAtAddress(tmp_ark,0,32);
		int compressionFlag=getValAtAddress(tmp_ark,address_pointer + (NoOfBlocks*4) ,32);
		int isCompressed =(compressionFlag>>1) & 0x01;
		
		long dataSize = address_pointer + (2*NoOfBlocks*4);	//????
		address_pointer=(LevelNo * 4) + 6;
		if (getValAtAddress(tmp_ark,address_pointer,32)==0)
			{
			printf("\nInvalid block address!\n");
			return;
			}
		if (isCompressed == 1)
			{
			lev_ark = unpack(tmp_ark,getValAtAddress(tmp_ark,address_pointer,32));
			}
			address_pointer=address_pointer+4;
		AddressOfBlockStart=0;	//since this array only contains that particular block
		objectsAddress=(64*64*4);
		address_pointer=0;

			
		//	}		
		break;
		}
		}
	}
	for (int x=0; x<1025;x++)
		{	//read in master object list

			objList[x].index = x; 
			objList[x].tileX=-1;
			objList[x].tileY=-1;
			//These three will get set when I am rendering the object entity and if the item is an npc's inventory.
			objList[x].objectOwner =0;
			objList[x].objectOwnerEntity =0;
			objList[x].joint =0 ;
			
			//Object header.
			objList[x].item_id = (getValAtAddress(lev_ark,objectsAddress+address_pointer+0,16)) & 0x1FF;
			objList[x].flags  = ((getValAtAddress(lev_ark,objectsAddress+address_pointer+0,16))>> 9) & 0x0F;
			objList[x].enchantment = ((getValAtAddress(lev_ark,objectsAddress+address_pointer+0,16)) >> 12) & 0x01;
			objList[x].doordir  = ((getValAtAddress(lev_ark,objectsAddress+address_pointer+0,16)) >> 13) & 0x01;
			objList[x].invis  = ((getValAtAddress(lev_ark,objectsAddress+address_pointer+0,16)) >> 14 )& 0x01;
			objList[x].is_quant = ((getValAtAddress(lev_ark,objectsAddress+address_pointer+0,16)) >> 15) & 0x01;
			
			//position at +2
			objList[x].zpos = (getValAtAddress(lev_ark,objectsAddress+address_pointer+2,16)) & 0x7F;	//bits 0-6 I'll probably ignore this
			objList[x].heading =  45 * (((getValAtAddress(lev_ark,objectsAddress+address_pointer+2,16)) >> 7) & 0x07); //bits 7-9
			objList[x].y = ((getValAtAddress(lev_ark,objectsAddress+address_pointer+2,16)) >> 10) & 0x07;	//bits 10-12
			objList[x].x =((getValAtAddress(lev_ark,objectsAddress+address_pointer+2,16)) >> 13) & 0x07;	//bits 13-15
			
			//+4
			objList[x].quality =(getValAtAddress(lev_ark,objectsAddress+address_pointer+4,16)) & 0x3F;
			objList[x].next = (getValAtAddress(lev_ark,objectsAddress+address_pointer+4,16)>>6) & 0x3FF;
			//+6
			//objList[x].owner = (getValAtAddress(lev_ark,objectsAddress+address_pointer+6,16) ) ;//bits 0-5

			objList[x].owner = (getValAtAddress(lev_ark,objectsAddress+address_pointer+6,16) & 0x3F) ;//bits 0-5
			
			if ((objectMasters[objList[x].item_id].type  == TMAP_SOLID) || (objectMasters[objList[x].item_id].type  == TMAP_CLIP))
				{
				//printf("\n%d\n", texture_map[objList[x].owner]);
				objList[x].owner = texture_map[objList[x].owner];	//Sets the texture for tmap objects.
				}
						
				
			//objList[x].special = objList[x].owner;
			
			objList[x].link  = (getValAtAddress(lev_ark,objectsAddress+address_pointer+6,16) >> 6 & 0x3FF) ; //bits 6-15
			//objList[x].link = objList[x].quantity;
			
			////printf("\n\tNext Object ID to this object is  %d", objList[x].next  );
			////printf("\n%d free object. Value 4=%d",x,getValAtAddress(lev_ark,AddressOfBlockStart+address_pointer+6,16));
			
			//extra info //19 bytes
			////printf("\n%d free extra inf. Value 5=%d",x,getValAtAddress(lev_ark,AddressOfBlockStart+address_pointer+8,8));
			////printf("\n%d free extra inf. Value 6=%d",x,getValAtAddress(lev_ark,AddressOfBlockStart+address_pointer+9,8));
			////printf("\n%d free extra inf. Value 7=%d",x,getValAtAddress(lev_ark,AddressOfBlockStart+address_pointer+10,8));
			////printf("\n%d free extra inf. Value 8=%d",x,getValAtAddress(lev_ark,AddressOfBlockStart+address_pointer+11,8));
			////printf("\n%d free extra inf. Value 9=%d",x,getValAtAddress(lev_ark,AddressOfBlockStart+address_pointer+12,8));
			////printf("\n%d free extra inf. Value 10=%d",x,getValAtAddress(lev_ark,AddressOfBlockStart+address_pointer+13,8));
			////printf("\n%d free extra inf. Value 11=%d",x,getValAtAddress(lev_ark,AddressOfBlockStart+address_pointer+14,8));
			////printf("\n%d free extra inf. Value 12=%d",x,getValAtAddress(lev_ark,AddressOfBlockStart+address_pointer+15,8));
			////printf("\n%d free extra inf. Value 13=%d",x,getValAtAddress(lev_ark,AddressOfBlockStart+address_pointer+16,8));
			////printf("\n%d free extra inf. Value 14=%d",x,getValAtAddress(lev_ark,AddressOfBlockStart+address_pointer+17,8));
			////printf("\n%d free extra inf. Value 15=%d",x,getValAtAddress(lev_ark,AddressOfBlockStart+address_pointer+18,8));
			////printf("\n%d free extra inf. Value 16=%d",x,getValAtAddress(lev_ark,AddressOfBlockStart+address_pointer+19,8));
			////printf("\n%d free extra inf. Value 17=%d",x,getValAtAddress(lev_ark,AddressOfBlockStart+address_pointer+20,8));
			////printf("\n%d free extra inf. Value 18=%d",x,getValAtAddress(lev_ark,AddressOfBlockStart+address_pointer+21,8));
			////printf("\n%d free extra inf. Value 19=%d",x,getValAtAddress(lev_ark,AddressOfBlockStart+address_pointer+22,8));
			////printf("\n%d free extra inf. Value 20=%d",x,getValAtAddress(lev_ark,AddressOfBlockStart+address_pointer+23,8));
			////printf("\n%d free extra inf. Value 21=%d",x,getValAtAddress(lev_ark,AddressOfBlockStart+address_pointer+24,8));
			////printf("\n%d free extra inf. Value 22=%d",x,getValAtAddress(lev_ark,AddressOfBlockStart+address_pointer+25,8));
			////printf("\n%d free extra inf. Value 23=%d",x,getValAtAddress(lev_ark,AddressOfBlockStart+address_pointer+26,8));
			////
		if (x<256)	
			{
			//mobile objects			
			objList[x].npc_whoami =getValAtAddress(lev_ark,objectsAddress+address_pointer+26,8);
			objList[x].npc_attitude = (getValAtAddress(lev_ark,objectsAddress+address_pointer+13,16) >> 14);

			address_pointer=address_pointer+8+19;
			}
		else
			{
			//Static Objects
			address_pointer=address_pointer+8;
			}
		}
}


void BuildObjectListShock(tile LevelInfo[64][64], ObjectItem objList[1600], long texture_map[256],char *filePath, int game, int LevelNo)
{

int InUseFlag;
int ObjectClass;
int ObjectSubClass;
int ObjectSubClassIndex;
int IndexIntoCrossRef;
int PrevLink;
int NextLink;
int XCoord;
int YCoord;
int ZCoord;
int Angle1;
int Angle2;
int Angle3;
int AIIndex;
int ObjectType;
int HitPoints;
int State;

	FILE *file = NULL;      // File pointer
	//unsigned char *lev_ark; 
	unsigned char *tmp_ark; 
	unsigned char *sub_ark; 
	//unsigned char *tex_ark;
	unsigned char *inf_ark;
	unsigned char *mst_ark;
	long filepos;
	long AddressOfBlockStart=0;
	long address_pointer=4;
	char blnLevelFound=0;

	int chunkId;
	long chunkUnpackedLength;
	long chunkType;//compression type
	long chunkPackedLength;
	long chunkContentType;
	int MasterAddressLookup[1024];
	
//read in archive.dat
	if ((file = fopen(filePath, "rb")) == NULL)
		printf("Could not open specified file\n");
	else
		printf ("");
	long fileSize = getFileSize(file);
	filepos = ftell(file);
	tmp_ark = new unsigned char[fileSize];
	fread(tmp_ark, fileSize, 1,file);
	fclose(file);  
	//get the master object list from the archive
	AddressOfBlockStart = getShockBlockAddress(LevelNo*100+4008,tmp_ark,&chunkPackedLength,&chunkUnpackedLength,&chunkType);

	
	sub_ark = new unsigned char[chunkPackedLength];	
	mst_ark = new unsigned char[chunkUnpackedLength];	
	for (long k=0; k< chunkPackedLength; k++)
		{
			sub_ark[k] = tmp_ark[AddressOfBlockStart+k];
		}
	unpack_data(sub_ark,mst_ark,chunkUnpackedLength);

	int i=0;
	address_pointer=0;
	while (address_pointer <= chunkUnpackedLength)
		{//Get the addresses of the master list data of the mst_ark
		MasterAddressLookup[i++] = address_pointer;
		address_pointer+=27;
		}


//Read in the xref table and then read in it's stuff from the master table. I'll then have to go into the class blocks.
	AddressOfBlockStart = getShockBlockAddress(LevelNo*100+4009,tmp_ark,&chunkPackedLength,&chunkUnpackedLength,&chunkType);
	sub_ark = new unsigned char[chunkPackedLength];	
	inf_ark = new unsigned char[chunkUnpackedLength];	
	for (long k=0; k< chunkPackedLength; k++)
		{
			sub_ark[k] = tmp_ark[AddressOfBlockStart+k];
		}
	unpack_data(sub_ark,inf_ark,chunkUnpackedLength);
	i=0;
	long mstaddress_pointer;
	address_pointer=0;
	while (address_pointer < chunkUnpackedLength)
		{
//		printf("\nXRef : %d \n",i);
//		printf("TileX = %d\n",getValAtAddress(inf_ark,address_pointer+0,16));
//		printf("TileY = %d\n",getValAtAddress(inf_ark,address_pointer+2,16));
		int MasterIndex= getValAtAddress(inf_ark,address_pointer+4,16);
//		printf("Master Index = %d\n",MasterIndex);
//		printf("Next obj = %d\n",getValAtAddress(inf_ark,address_pointer+6,16));
//		printf("Next tile = %d\n",getValAtAddress(inf_ark,address_pointer+8,16));
		
		objList[i].index = i;
		objList[i].link =0;
		objList[i].joint=0;
		objList[i].next = getValAtAddress(inf_ark,address_pointer+6,16);
		objList[i].tileX= getValAtAddress(inf_ark,address_pointer+0,16);
		objList[i].tileY =getValAtAddress(inf_ark,address_pointer+2,16);
		
		//Now go visit the master list to get more info.
		
		mstaddress_pointer = MasterAddressLookup[MasterIndex];
		
//			printf("Object : %d \n",i);
			InUseFlag=getValAtAddress(mst_ark,mstaddress_pointer,8);
//			printf("InUse = %d\n",getValAtAddress(mst_ark,mstaddress_pointer,8));
			objList[i].InUseFlag = InUseFlag;
			ObjectClass =getValAtAddress(mst_ark,mstaddress_pointer+1,8);
//			printf("ObjectClass = %d\n",ObjectClass);
			objList[i].ObjectClass = ObjectClass;
			ObjectSubClass=getValAtAddress(mst_ark,mstaddress_pointer+2,8);
//			printf("ObjectSubClass = %d\n",ObjectSubClass);
			objList[i].ObjectSubClass = ObjectSubClass;

			//Subclass per sspecs is  a link to the sub table. no the class it self. For that we need the object type.
			ObjectSubClassIndex =getValAtAddress(mst_ark,mstaddress_pointer+20,8);	
//			printf("ObjectSubClassIndex = %d\n",ObjectSubClassIndex);//cross ref this with the class table.
			//if (ObjectClass==4)
			//	{
			//	lookUpSubClass(tmp_ark,LevelNo*100+4014, ObjectSubClassIndex);
			//	}
			objList[i].ObjectSubClassIndex = ObjectSubClassIndex;
//			printf("ObjectType = %d\n",getValAtAddress(mst_ark,mstaddress_pointer+20,8));
//			printf("Index back to cross = %d\n",getValAtAddress(mst_ark,mstaddress_pointer+5,16));
			int LookupIndex=getShockObjectIndex(ObjectClass,ObjectSubClass,ObjectSubClassIndex);
			//objList[i].LookUpIndex= LookupIndex;
			objList[i].item_id =LookupIndex;
			objList[i].x =getValAtAddress(mst_ark,mstaddress_pointer+11,8);
			objList[i].y = getValAtAddress(mst_ark,mstaddress_pointer+13,8);
			objList[i].zpos =getValAtAddress(mst_ark,mstaddress_pointer+15,8);
						
//			if (LookupIndex !=-1)
//				{
//				printf("It is a %s\n", shockObjectMasters[LookupIndex].desc );
//				}
//			else
//				{
//				printf("Description not found!\n");
//				}
			//printf("IndexIntoCrossRef = %d\n",getValAtAddress(mst_ark,mstaddress_pointer+5,16));
//			printf("PrevLink = %d\n",getValAtAddress(mst_ark,mstaddress_pointer+7,16));
//			printf("NextLink = %d\n",getValAtAddress(mst_ark,mstaddress_pointer+9,16));
//			printf("XCoord low= %d\n",getValAtAddress(mst_ark,mstaddress_pointer+11,8));
//			printf("XCoord high= %d\n",getValAtAddress(mst_ark,mstaddress_pointer+12,8));
//			printf("YCoord low= %d\n",getValAtAddress(mst_ark,mstaddress_pointer+13,8));
//			printf("YCoord high= %d\n",getValAtAddress(mst_ark,mstaddress_pointer+14,8));

			
//			printf("ZCoord = %d\n",getValAtAddress(mst_ark,mstaddress_pointer+15,8));
//			printf("Angle1 = %d\n",getValAtAddress(mst_ark,mstaddress_pointer+16,8));
//			printf("Angle2 = %d\n",getValAtAddress(mst_ark,mstaddress_pointer+17,8));
//			printf("Angle3 = %d\n",getValAtAddress(mst_ark,mstaddress_pointer+18,8));
//			printf("AIIndex = %d\n",getValAtAddress(mst_ark,mstaddress_pointer+19,8));
//			printf("ObjectType = %d\n",getValAtAddress(mst_ark,mstaddress_pointer+20,8));
//			printf("HitPoints = %d\n",getValAtAddress(mst_ark,mstaddress_pointer+21,16));
//			printf("State = %d\n",getValAtAddress(mst_ark,mstaddress_pointer+23,8));
//			printf("unk1 = %d\n",getValAtAddress(mst_ark,mstaddress_pointer+24,8));
//			printf("unk2 = %d\n",getValAtAddress(mst_ark,mstaddress_pointer+25,8));
//			printf("unk3 = %d\n",getValAtAddress(mst_ark,mstaddress_pointer+26,8));
		
		
		
		address_pointer+=10;
		i++;
		}

}


void lookUpSubClass(unsigned char *tmp_ark, int BlockNo, int index)
{
//
	int chunkId;
	long chunkUnpackedLength;
	long chunkType;//compression type
	long chunkPackedLength;
	long chunkContentType;
	
long AddressOfBlockStart = getShockBlockAddress(BlockNo,tmp_ark,&chunkPackedLength,&chunkUnpackedLength,&chunkType);
int k= 0;
int add_ptr=0;
while (k<=chunkUnpackedLength)
	{
	if (k==index)
		{
		printf("\n%d",k);
		printf("Index back=%d\n",getValAtAddress(tmp_ark,AddressOfBlockStart+add_ptr+0,16));
		printf("prev=%d\n",getValAtAddress(tmp_ark,AddressOfBlockStart+add_ptr+2,16));
		printf("next=%d\n",getValAtAddress(tmp_ark,AddressOfBlockStart+add_ptr+4,16));
		}
add_ptr+=6;
	k++;
	}
return;
}

unsigned char* unpack(unsigned char *tmp, int address_pointer)
  {
  
 //Robbed and changed slightly from the Labyrinth of Worlds implementation project.
 //This decompresses UW2 blocks.
 
    int	len = getValAtAddress(tmp,address_pointer,32);	//lword(base);
    unsigned char*	buf = new unsigned char[len+100];
    unsigned char*	up = buf;

    address_pointer += 4;

    while(up < buf+len)
      {
	int		bits = tmp[address_pointer++];
	for(int r=0; r<8; r++)
	  {
	    if(bits&1)
	    {
	    //printf("transfer %d\ at %d\n", byte(base),base);
		*up++ = tmp[address_pointer++];
		}
	    else
	      {
		int	o = tmp[address_pointer++];
		int	c = tmp[address_pointer++];

		o |= (c&0xF0)<<4;
		c = (c&15) + 3;
		o = o+18;
		if(o > (up-buf))
		    o -= 0x1000;
		while(o < (up-buf-0x1000))
		    o += 0x1000;
		 
		while(c--)
		    *up++ = buf[o++];
	      }
	    bits >>= 1;
	  }
      }

    return buf;
}

int BuildTileMapShock(tile LevelInfo[64][64], ObjectItem objList[1600],long texture_map[272], char *filePath, int game, int LevelNo)
{
	FILE *file = NULL;      // File pointer
	unsigned char *lev_ark; 
	unsigned char *tmp_ark; 
	unsigned char *sub_ark; 
	unsigned char *tex_ark;
	unsigned char *inf_ark;
	long filepos;
	long AddressOfBlockStart=0;
	long address_pointer=4;
	char blnLevelFound=0;

	int chunkId;
	long chunkUnpackedLength;
	long chunkType;//compression type
	long chunkPackedLength;
	long chunkContentType;
	

	
	
//read in archive.dat
	if ((file = fopen(filePath, "rb")) == NULL)
		printf("Could not open specified file\n");
	else
		printf ("");
	long fileSize = getFileSize(file);
	filepos = ftell(file);
	tmp_ark = new unsigned char[fileSize];
	fread(tmp_ark, fileSize, 1,file);
	fclose(file);  
	//get the level info data from the archive
	AddressOfBlockStart = getShockBlockAddress(4004+ LevelNo*100, tmp_ark,  &chunkPackedLength, &chunkUnpackedLength,&chunkType);
	sub_ark = new unsigned char[chunkPackedLength];	
	inf_ark = new unsigned char[chunkUnpackedLength];	
	for (long k=0; k< chunkPackedLength; k++)
		{
			sub_ark[k] = tmp_ark[AddressOfBlockStart+k];
		}
	unpack_data(sub_ark,inf_ark,chunkUnpackedLength);
	//long sizeV = getValAtAddress(inf_ark,0,32);
	//long sizeH = getValAtAddress(inf_ark,4,32);
	//long always6_1 = getValAtAddress(inf_ark,8,32);
	//long always6_2 = getValAtAddress(inf_ark,12,32);
	long HeightUnits = getValAtAddress(inf_ark,16,32);	//Log2 value. The higher the value the lower the level height.
	if (HeightUnits > 3)	//Any higher we lose data, 
		{
		HeightUnits=3;
		}
	int cSpace = getValAtAddress(inf_ark,24,32);	//Per docs should return 1 on cyberspace. Does'nt appear to work.
	SHOCK_CEILING_HEIGHT = ((256 >> HeightUnits) * 8 >>3);	//Shifts the scale of the level.
	
	//get the level data from the archive
	AddressOfBlockStart = getShockBlockAddress(4005+ LevelNo*100, tmp_ark,  &chunkPackedLength, &chunkUnpackedLength,&chunkType);
	sub_ark = new unsigned char[64*64*16];	
	for (long k=0; k< chunkPackedLength; k++)
		{//Copy that particular data.
			sub_ark[k] = tmp_ark[AddressOfBlockStart+k];
		}
	lev_ark=new unsigned char[64*64*16];
	AddressOfBlockStart=0;
	address_pointer=0;	
	//Decompress the chunk.
	unpack_data(sub_ark,lev_ark,64*64*16);
	
	
	//get the texture data from the archive
	AddressOfBlockStart = getShockBlockAddress(4007+ LevelNo*100, tmp_ark,  &chunkPackedLength, &chunkUnpackedLength,&chunkType);
	tex_ark = new unsigned char[chunkUnpackedLength];	
	for (long k=0; k< chunkUnpackedLength; k++)
	{
		texture_map[k] = getValAtAddress(tmp_ark,AddressOfBlockStart + address_pointer,16);
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
		for (int x=0; x<64;x++)
			{
				//Read in the tile data 
				LevelInfo[x][y].tileX = x;
				LevelInfo[x][y].tileY = y;
				LevelInfo[x][y].tileType = lev_ark[address_pointer];	
				switch (LevelInfo[x][y].tileType)
					{//Need to swap some tile types around so that they conform to uw naming standards.
					case 4:	{LevelInfo[x][y].tileType = 5; break;}
					case 5:	{LevelInfo[x][y].tileType = 4; break;}
					case 7:	{LevelInfo[x][y].tileType = 8; break;}
					case 8:	{LevelInfo[x][y].tileType = 7; break;}
					}
				LevelInfo[x][y].indexObjectList =0;
				LevelInfo[x][y].Render=1;		
				LevelInfo[x][y].DimX=1;			
				LevelInfo[x][y].DimY=1;			
				LevelInfo[x][y].Grouped=0;	
				
				/* word 6 contains
					0-5	Wall texture (index into texture list)
					6-10	Ceiling texture
					11-15	Floor texture
				*/
				LevelInfo[x][y].wallTexture =texture_map[getValAtAddress(lev_ark,address_pointer+6,16) & 0x3F]; 
				LevelInfo[x][y].shockCeilingTexture=texture_map[(getValAtAddress(lev_ark,address_pointer+6,16) >>6) & 0x1F];
				LevelInfo[x][y].floorTexture=texture_map[(getValAtAddress(lev_ark,address_pointer+6,16) >>11) & 0x1F];
				

				LevelInfo[x][y].North = LevelInfo[x][y].wallTexture;
				LevelInfo[x][y].South = LevelInfo[x][y].wallTexture;
				LevelInfo[x][y].East = LevelInfo[x][y].wallTexture;
				LevelInfo[x][y].West = LevelInfo[x][y].wallTexture;
				
				LevelInfo[x][y].isWater=0;	//No swimming in shock.
				LevelInfo[x][y].floorHeight =((lev_ark[address_pointer+1]) & 0x1F);
				LevelInfo[x][y].floorHeight = ((LevelInfo[x][y].floorHeight <<3) >> HeightUnits)*8 >>3; //Shift it for varying height scales

				LevelInfo[x][y].ceilingHeight =((lev_ark[address_pointer+2]) & 0x1F) ;
				LevelInfo[x][y].ceilingHeight = ((LevelInfo[x][y].ceilingHeight <<3) >> HeightUnits)*8 >>3; //Shift it for varying height scales
				
				//Need to know heights in various directions for alignments.
				//Will set these properly after loading levels.
				LevelInfo[x][y].shockNorthCeilHeight =LevelInfo[x][y].ceilingHeight;
				LevelInfo[x][y].shockSouthCeilHeight =LevelInfo[x][y].ceilingHeight;
				LevelInfo[x][y].shockEastCeilHeight =LevelInfo[x][y].ceilingHeight;
				LevelInfo[x][y].shockWestCeilHeight =LevelInfo[x][y].ceilingHeight;
				
				LevelInfo[x][y].shockSteep = (lev_ark[address_pointer+3] & 0x0f);
				LevelInfo[x][y].shockSteep = ((LevelInfo[x][y].shockSteep <<3) >> HeightUnits)*8 >>3; //Shift it for varying height scales
				
				if ((LevelInfo[x][y].shockSteep ==0) && (LevelInfo[x][y].tileType >=6))//If a sloped tile has no slope then it's a open tile.
					{LevelInfo[x][y].tileType =1;}
				LevelInfo[x][y].indexObjectList = getValAtAddress(lev_ark,address_pointer+4,16);
				//if(LevelInfo[x][y].indexObjectList!=0)
				//	{
				//	printf("At %d %d we have: %d\n", x,y,LevelInfo[x][y].indexObjectList);
				//	}

/*
	xxxxx0xx	Floor & ceiling, same direction
	xxxxx4xx	Floor & ceiling, ceiling opposite dir to tile type
	xxxxx8xx	Floor only
	xxxxxCxx	Ceiling only
*/
				LevelInfo[x][y].shockSlopeFlag = (getValAtAddress(lev_ark,address_pointer+8,32) >> 10) & 0x03;
				LevelInfo[x][y].UseAdjacentTextures = (getValAtAddress(lev_ark,address_pointer+8,32) >> 8) & 0x01;
				LevelInfo[x][y].shockTextureOffset = getValAtAddress(lev_ark,address_pointer+8,32) & 0xF;

				LevelInfo[x][y].shockNorthOffset =LevelInfo[x][y].shockTextureOffset;
				LevelInfo[x][y].shockSouthOffset =LevelInfo[x][y].shockTextureOffset;
				LevelInfo[x][y].shockEastOffset =LevelInfo[x][y].shockTextureOffset;
				LevelInfo[x][y].shockWestOffset =LevelInfo[x][y].shockTextureOffset;

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



//****************************************************************************

/* The following procedure comes straight from Jim Cameron
   http://madeira.physiol.ucl.ac.uk/people/jim
   Specifically, this procedure can be found on his "Unofficial System Shock
   Specifications" page at
   http://madeira.physiol.ucl.ac.uk/people/jim/games/ss-res.txt
*/
void unpack_data (unsigned char *pack,    unsigned char *unpack,
		  unsigned long unpacksize)
{

  unsigned char *byteptr;
  unsigned char *exptr;
  unsigned long word = 0;  /* initialise to stop "might be used before set" */
  int nbits;
/*    int type; */
  int val;

  int ntokens = 0;
  static int offs_token [16384];
  static int len_token  [16384];
  static int org_token  [16384];

  int i;

  for (i = 0; i < 16384; ++i)
  {
    len_token [i] = 1;
    org_token [i] = -1;
  }
  memset (unpack, 0, unpacksize);

  byteptr = pack;
  exptr   = unpack;
  nbits = 0;

  while (exptr - unpack < unpacksize)
  {

    while (nbits < 14)
    {
      word = (word << 8) + *byteptr++;
      nbits += 8;
    }

    nbits -= 14;
    val = (word >> nbits) & 0x3FFF;
    if (val == 0x3FFF)
    {
      break;
    }

    if (val == 0x3FFE)
    {
      for (i = 0; i < 16384; ++i)
      {
	len_token [i] = 1;
	org_token [i] = -1;
      }
      ntokens = 0;
      continue;
    }

    if (ntokens < 16384)
    {
      offs_token [ntokens] = exptr - unpack;
      if (val >= 0x100)
      {
	org_token [ntokens] = val - 0x100;
      }
    }
    ++ntokens;

    if (val < 0x100)
    {
      *exptr++ = val;
    }
    else
    {
      val -= 0x100;

      if (len_token [val] == 1)
      {	  
	if (org_token [val] != -1)
	{
	  len_token [val] += len_token [org_token [val]];
	}
	else
	{
	  len_token [val] += 1;
	}
      }
      for (i = 0; i < len_token [val]; ++i)
      {
	*exptr++ = unpack [i + offs_token [val]];
      }

    }
    
  }

}

// End of Jim Cameron's procedure



//****************************************************************************


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
				if ((objectMasters[objList[currObj.index].item_id].type == DOOR ) || (objectMasters[objList[currObj.index].item_id].type == HIDDENDOOR ))
					{
					LevelInfo[x][y].isDoor = 1;
					LevelInfo[x][y].DoorIndex = currObj.index;
					break;
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
					LevelInfo[x][y].PatchIndex = currObj.index;
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
					LevelInfo[x][y].ElevatorIndex = currObj.index;
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
					LevelInfo[x][y].TerrainChangeIndex = currObj.index;
					//Need to flag the range of tiles affected. X/y of the object gives the dimensions
					for (int j=x; (j <64 && j<= x+currObj.x); j++  )
						{
						for (int k=y; (k <64 && k<= y+currObj.y); k++  )
							{
							LevelInfo[j][k].TerrainChange = 1;
							}						
						}
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

void setObjectTileXY(tile LevelInfo[64][64], ObjectItem objList[1600])
{//Justs some useful info to know.
ObjectItem currObj;
for (int x=0; x<64;x++)
	{
	for (int y=0;y<64;y++)
		{
		if (LevelInfo[x][y].indexObjectList !=0)
			{
			long nextObj=LevelInfo[x][y].indexObjectList;
			while (nextObj!=0)
				{
				objList[nextObj].tileX=x;
				objList[nextObj].tileY=y;
				nextObj=objList[nextObj].next;
				}

			}
	
		}	
	}	
}

long getShockBlockAddress(long BlockNo, unsigned char *tmp_ark , long *chunkPackedLength,long *chunkUnpackedLength, long *chunkType)
{
//Finds the address of the block based on the directory block no.
//Justs loops through until it finds a match.
	int blnLevelFound =0;
	long DirectoryAddress=getValAtAddress(tmp_ark,124,32);
	//printf("\nThe directory is at %d\n", DirectoryAddress);
	
	long NoOfChunks = getValAtAddress(tmp_ark,DirectoryAddress,16);
	//printf("there are %d chunks\n",NoOfChunks);
	long firstChunkAddress = getValAtAddress(tmp_ark,DirectoryAddress+2,32);
	//printf("The first chunk is at %d\n", firstChunkAddress);
	long address_pointer=DirectoryAddress+6;
	long AddressOfBlockStart= firstChunkAddress;
	for (int k=0; k< NoOfChunks; k++)
		{
		long chunkId = getValAtAddress(tmp_ark,address_pointer,16);
		*chunkUnpackedLength =getValAtAddress(tmp_ark,address_pointer+2,24);
		*chunkType = getValAtAddress(tmp_ark,address_pointer+5,8);	//Compression.
		*chunkPackedLength = getValAtAddress(tmp_ark,address_pointer+6,24);
		long chunkContentType = getValAtAddress(tmp_ark,address_pointer+9,8);
		//printf("Index: %d, Chunk %d, Unpack size %d, compression %d, packed size %d, content type %d\t",k,chunkId, chunkUnpackedLength, chunkType,chunkPackedLength,chunkContentType);
		//printf("Absolute address is %d\n",AddressOfBlockStart);
		
		//target chunk id is 4005 + level no * 100 for levels
		if (chunkId== BlockNo)		//4005+ LevelNo*100
			{
			blnLevelFound=1;
			address_pointer=0;
			break;
			}
			
			
		AddressOfBlockStart=AddressOfBlockStart+ *chunkPackedLength;
		if ((AddressOfBlockStart % 4) != 0)
			AddressOfBlockStart = AddressOfBlockStart + 4 - (AddressOfBlockStart % 4); // chunk offsets always fall on 4-byte boundaries
		

		address_pointer=address_pointer+10;			
		}
		
	if (blnLevelFound == 0)
		{
		//printf("Level not found"); 
		return -1;
		}
	else
		{
		return AddressOfBlockStart;
		}
}
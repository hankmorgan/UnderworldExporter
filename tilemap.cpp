
#include "utils.h"
#include "main.h"
#include "textures.h"
#include "gameobjects.h"
#include "tilemap.h"

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
		printf("\nArchive not found!\n");
		return -1;
		}
	long fileSize = getFileSize(file);
	int filepos = ftell(file);	
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
	for (long k=0; k< chunkUnpackedLength; k++)
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

				int shockShadeLower  =(getValAtAddress(lev_ark,address_pointer+8,32) >> 16) & 0x0F;
				int shockShadeUpper  =(getValAtAddress(lev_ark,address_pointer+8,32) >> 24) & 0x0F;
				LevelInfo[x][y].shockShade = (shockShadeUpper<<4) | shockShadeLower;	//dark is 255.

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
//ObjectItem currObj;
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


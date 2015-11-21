#include <fstream>

#include "main.h"
#include "utils.h"
#include "textures.h"

long getFileSize(FILE *file)
{
    long lCurPos, lEndPos;
    lCurPos = ftell(file);
    fseek(file, 0, 2);
    lEndPos = ftell(file);
    fseek(file, lCurPos, 0);
    return lEndPos;
}

long ConvertInt16(unsigned char Byte1, unsigned char Byte2)
{
//return Byte1 << 8 | Byte2 ;
return Byte2 << 8 | Byte1 ;
}

long ConvertInt24(unsigned char Byte1, unsigned char Byte2,  unsigned char Byte3)
{
return Byte3 << 16 | Byte2 << 8 | Byte1 ;
}

long ConvertInt32(unsigned char Byte1, unsigned char Byte2,  unsigned char Byte3,  unsigned char Byte4)
{
return Byte4 << 24 | Byte3 << 16 | Byte2 << 8 | Byte1 ;		//24 was 32
}

long getValAtAddress(unsigned char *buffer, long Address, int size)
	{//Gets contents of bytes the the specific integer address. int(8), int(16), int(32) per uw-formats.txt
	if (Address < 0)
		{
		printf("Invalid Address Error\n");
		}
		switch (size)
		{
		case 8:
			{return buffer[Address];}
		case 16:
			{return ConvertInt16(buffer[Address],buffer[Address+1]);}
		case 24:
			{return ConvertInt24(buffer[Address],buffer[Address+1],buffer[Address+2]);}
		case 32:	//may be buggy!
			{return ConvertInt32(buffer[Address], buffer[Address + 1], buffer[Address + 2], buffer[Address + 3]); }
		default:
			{
			printf("Invalid size entered!");
			return -1;
			}
		}
	}



int getValAtCoordinate(int x, int y, int BlockStart,unsigned char *buffer,int size)
{
	int val = getValAtAddress(buffer, BlockStart + (x*4) + (y * (4 * 64)),size);
	return val;
}


unsigned char* unpackUW2(unsigned char *tmp, int address_pointer, int *datalen)
  {
  
 //Robbed and changed slightly from the Labyrinth of Worlds implementation project.
 //This decompresses UW2 blocks.
 
    int	len = getValAtAddress(tmp,address_pointer,32);	//lword(base);
    unsigned char*	buf = new unsigned char[len+100];
    unsigned char*	up = buf;
	*datalen = 0;
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
		*datalen = *datalen+1;
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
		    {
			*up++ = buf[o++];
			*datalen = *datalen+1;
			}
	      }
	    bits >>= 1;
	  }
      }

    return buf;
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
		  if (i + offs_token[val]<unpacksize)
		  {
			  *exptr++ = unpack[i + offs_token[val]];
		  }
		  else
		  {
			  printf("Oh shit");
		  }
	
      }

    }
    
  }

}

// End of Jim Cameron's procedure



//****************************************************************************

long getShockBlockAddress(long BlockNo, unsigned char *tmp_ark , long *chunkPackedLength,long *chunkUnpackedLength, long *chunkType)
{
//Finds the address of the block based on the directory block no.
//Justs loops through until it finds a match.
	int blnLevelFound =0;
	long DirectoryAddress=getValAtAddress(tmp_ark,124,32);
	//printf("\nThe directory is at %d\n", DirectoryAddress);
	
	int NoOfChunks = getValAtAddress(tmp_ark,DirectoryAddress,16);
	//printf("there are %d chunks\n",NoOfChunks);
	long firstChunkAddress = getValAtAddress(tmp_ark,DirectoryAddress+2,32);
	//printf("The first chunk is at %d\n", firstChunkAddress);
	long address_pointer=DirectoryAddress+6;
	long AddressOfBlockStart= firstChunkAddress;
	for (int k=0; k< NoOfChunks; k++)
		{
		int chunkId = getValAtAddress(tmp_ark,address_pointer,16);
		*chunkUnpackedLength =getValAtAddress(tmp_ark,address_pointer+2,24);
		*chunkType = getValAtAddress(tmp_ark,address_pointer+5,8);	//Compression.
		*chunkPackedLength = getValAtAddress(tmp_ark,address_pointer+6,24);
		short chunkContentType = getValAtAddress(tmp_ark,address_pointer+9,8);
		//printf("Index: %d, Chunk %d, Unpack size %d, compression %d, packed size %d, content type %d\t",
		//	k,chunkId, *chunkUnpackedLength, *chunkType,*chunkPackedLength,chunkContentType);
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

int LoadShockChunk(long AddressOfBlockStart, int chunkType, unsigned char *archive_ark, unsigned char *OutputChunk,long chunkPackedLength,long chunkUnpackedLength)
{
//Util to return an uncompressed shock block. Will use this for all future lookups and replace old ones


	int chunkId;
//	long chunkUnpackedLength;
	//int chunkType=Compressed;//compression type
	//long chunkPackedLength;
	//long chunkContentType;
	long filepos;
//	long AddressOfBlockStart=0;
	long address_pointer=4;
	//int blnLevelFound=0;		
	


	//Find the address of the block. This will also return the file size.
	//AddressOfBlockStart = getShockBlockAddress(ChunkNo,archive_ark,&chunkPackedLength,&chunkUnpackedLength,&chunkType);  	
	if (AddressOfBlockStart == -1)	{return -1;}
	
	//if (chunkType ==1)
	switch (chunkType)
		{
		case 0:
			{//Flat uncompressed
			for (long k=0; k< chunkUnpackedLength; k++)
				{
					OutputChunk[k] = archive_ark[AddressOfBlockStart+k];
				}		
			return chunkUnpackedLength;
			break;
			}
		case 1:	
			{//flat Compressed
			//printf("\nCompressed chunk");
				unsigned char *temp_ark = new unsigned char[chunkPackedLength];	
				for (long k=0; k< chunkPackedLength; k++)
					{
						temp_ark[k] = archive_ark[AddressOfBlockStart+k];
					}
				
				unpack_data(temp_ark,OutputChunk,chunkUnpackedLength);
				return chunkUnpackedLength;
				break;
			}
		
		case 3://Subdir compressed	//Just return the compressed data and unpack the sub chunks individually?
			{
			//uncompressed the sub chunks
			int NoOfEntries=getValAtAddress(archive_ark,AddressOfBlockStart,16);
			int SubDirLength=(NoOfEntries+1) * 4 + 2;
			unsigned char *temp_ark = new unsigned char[chunkPackedLength];	
			unsigned char *tmpchunk = new unsigned char[chunkUnpackedLength];	
				for (long k=0; k< chunkPackedLength; k++)
					{
						temp_ark[k] = archive_ark[AddressOfBlockStart+k+SubDirLength];
					}
					unpack_data(temp_ark,tmpchunk,chunkUnpackedLength);
				//Merge my subdir and uncompressed subdir data back together.
				for (long k=0;k<SubDirLength;k++)
					{//Subdir
					OutputChunk[k]=archive_ark[AddressOfBlockStart+k];
					}
				for (long k=SubDirLength;k<chunkUnpackedLength;k++)
					{//Subdir
					OutputChunk[k]=tmpchunk[k-SubDirLength];
					}
			return chunkUnpackedLength;					
			break;
			}
		case 2://Subdir uncompressed
			//{
			//printf("Uncompressed subdir!");
			//}
		default:
			{//Uncompressed. 
			//printf("\nUncompressed chunk");
			//OutputChunk =  new unsigned char[chunkUnpackedLength];
			for (long k=0; k< chunkUnpackedLength; k++)
				{
					OutputChunk[k] = archive_ark[AddressOfBlockStart+k];
				}		
			return chunkUnpackedLength;
			break;
			}
		}
}



void RepackUW2(char InputFile[255], char OutputFile[255],int BlocksToUnpack)
{
	//hopefully repacks a compressed level file into one containing uncompressed chuncks that I can edit to test object properties.

	FILE *file = NULL;
	char *filePath;
	//char *filePathO;
	long fileSize;
	unsigned char *lev_ark;
	int NoOfBlocks;
	if ((file = fopen(InputFile, "rb")) == NULL)
	{
		printf("Could not open specified file\n");
		return;
	}
	fileSize = getFileSize(file);
	lev_ark = new unsigned char[fileSize];
	fread(lev_ark, fileSize, 1, file);
	fclose(file);

	NoOfBlocks = getValAtAddress(lev_ark,0,16);
	

	//tables that I have to write.
	long *BlockAddress;
	BlockAddress=new long[NoOfBlocks];
//	long BlockAddress[NoOfBlocks];	//No of blocks in UW2
	long PreviousUsedLength;
	//int CompressionFlags[NoOfBlocks];
	//int DataSize[NoOfBlocks];
	//int AvailableSpace[NoOfBlocks];
	long currAddress;
	long address_pointer = 6;

	int compressionFlag ;
	int DataLen;
	int isCompressed;
	long *mapSize;
	mapSize=new long[NoOfBlocks];
	//long mapSize[BlocksToUnpack];// = 0x7c08;
	printf("Original Blocks\n");
	for (int x = 0; x < NoOfBlocks; x++)
	{//Just dump out some original data for info.
		currAddress = getValAtAddress(lev_ark, 6 + (x * 4), 32);
		compressionFlag = getValAtAddress(lev_ark, address_pointer + (UW2_COMPRESS_BLOCK *(NoOfBlocks * 4)) + (x * 4), 32);
		long DataSizeVal = getValAtAddress(lev_ark, address_pointer + (UW2_SIZE_BLOCK * (NoOfBlocks * 4)) + (x * 4), 32);
		long DataAvail = getValAtAddress(lev_ark, address_pointer + (UW2_SPACE_BLOCK * (NoOfBlocks * 4)) + (x * 4), 32);

		printf("Block no %d\n",x);
		printf("\tAddress %d", currAddress);
		printf("\tFlags %d\n", compressionFlag);
		printf("\tData Size %d", DataSizeVal);
		printf("\tAvailable %d\n", DataAvail);
		printf("\tNext if using datasize %d\n", currAddress+DataSizeVal);
		printf("\tNext if using available %d\n", currAddress + DataAvail);
		//if (x < BlocksToUnpack)
		//	{//This default size covers most of the map data except for the animation overlays + other stuff I know nothing about.
		//	mapSize[x]=0x7c08;//default size
		mapSize[x]= DataSizeVal;
		//	}
	}

	//Initial values for the loop for calculating block addresses.
	BlockAddress[0] = getValAtAddress(lev_ark, 6 , 32);//The first block stays the same
	long LastBlockAddress = BlockAddress[0];
	PreviousUsedLength = 0;

	for (int x = 0; x < NoOfBlocks; x++)
		{
		currAddress = getValAtAddress(lev_ark, 6 + (x * 4), 32);
		compressionFlag = getValAtAddress(lev_ark, address_pointer + (NoOfBlocks * 4) + (x * 4), 32);
		DataLen = getValAtAddress(lev_ark, address_pointer + (UW2_SIZE_BLOCK * (NoOfBlocks * 4)) + (x * 4), 32);
		isCompressed = (compressionFlag >> 1) & 0x01;
		if (x < BlocksToUnpack)
			{
			if (currAddress != 0)
				{//Map blocks are always compressed in UW2.
				if (isCompressed == 1)
					{
					unpackUW2(lev_ark, currAddress, &DataLen);		//Unpack and see how much space I need to allow for.
					mapSize[x]=DataLen;
					BlockAddress[x] = LastBlockAddress + PreviousUsedLength;  //Size of a map block
					LastBlockAddress = BlockAddress[x];
					PreviousUsedLength = mapSize[x];
					}
				else
					{
					BlockAddress[x] = LastBlockAddress + PreviousUsedLength;
				    LastBlockAddress = BlockAddress[x];
				    PreviousUsedLength = getValAtAddress(lev_ark, address_pointer + (UW2_SIZE_BLOCK * (NoOfBlocks * 4)) + (x * 4), 32);
				    //Set mapsize here???
					}
				}
			else
				{
					BlockAddress[x] = 0; 
					mapSize[x]=0;
				}
			}
		else
			{
			if (currAddress != 0)
				{//is this correct for all compression flags???
				BlockAddress[x] = LastBlockAddress + PreviousUsedLength;
				LastBlockAddress = BlockAddress[x];
				PreviousUsedLength = getValAtAddress(lev_ark, address_pointer + (UW2_SIZE_BLOCK * (NoOfBlocks * 4)) + (x * 4), 32);
				}
			else
				{
				BlockAddress[x] = 0;
				}
			}
		printf("\nBlock Address %d = %d", x, BlockAddress[x]);
		}
	
	if ((file = fopen(OutputFile, "w+b")) == NULL)
		{
		printf("Could not open specified file\n");
		return;
		}


	//Write the number of blocks
	WriteInt16(file,NoOfBlocks);
	//write 4x0
	WriteInt32(file, 0);

	//write my block addresses. increment by the size of the decompressed data.
	for (int x = 0; x < NoOfBlocks; x++)
	{
		//long currAddress = getValAtAddress(lev_ark, 6 + (x * 4), 32);
		WriteInt32(file, BlockAddress[x]);
	}

	//write my compression flags. each shoudld be 0 0 0
	for (int x = 0; x < NoOfBlocks; x++)
	{
		compressionFlag = getValAtAddress(lev_ark, address_pointer + (NoOfBlocks * 4) + (x * 4), 32);
		DataLen = getValAtAddress(lev_ark, address_pointer + (UW2_SIZE_BLOCK * (NoOfBlocks * 4)) + (x * 4), 32);
		isCompressed = (compressionFlag >> 1) & 0x01;
		if (x<BlocksToUnpack)
			{
				WriteInt32(file, 0);
			}
		else
		{//copy the existing flags.
			compressionFlag = getValAtAddress(lev_ark, address_pointer + (NoOfBlocks * 4) + (x * 4), 32);
			WriteInt32(file,compressionFlag);
		}
	}
	//write the space used
	for (int x = 0; x < NoOfBlocks; x++)
	{
		currAddress = getValAtAddress(lev_ark, 6 + (x * 4), 32);
		if (x <BlocksToUnpack)
		{
			if (currAddress != 0)
				{
				WriteInt32(file, mapSize[x]);
				}
			else
				{
				DataLen = getValAtAddress(lev_ark, address_pointer + (UW2_SIZE_BLOCK * (NoOfBlocks * 4)) + (x * 4), 32);
				WriteInt32(file, DataLen);
				}
		}
		else
		{//copy the existing values
			DataLen = getValAtAddress(lev_ark, address_pointer + (UW2_SIZE_BLOCK * (NoOfBlocks * 4)) + (x * 4), 32);
			WriteInt32(file, DataLen);
		}
	}
	//write my available space should not matter for decompression so I'll just put the block size here (?)
	for (int x = 0; x < NoOfBlocks; x++)
	{
		currAddress = getValAtAddress(lev_ark, 6 + (x * 4), 32);
		if (x <BlocksToUnpack)
		{
			if (currAddress != 0)
			{
				WriteInt32(file, mapSize[x]);
			}
			else
			{
				int DataLen = getValAtAddress(lev_ark, address_pointer + (UW2_SIZE_BLOCK * (NoOfBlocks * 4)) + (x * 4), 32);
				WriteInt32(file, DataLen);
			}
		}
		else
		{//copy the existing values
			int DataLen = getValAtAddress(lev_ark, address_pointer + (UW2_SIZE_BLOCK * (NoOfBlocks * 4)) + (x * 4), 32);
			WriteInt32(file, DataLen);
		}
	}
	//write my uncompressed blocks.
	for (int x = 0; x < NoOfBlocks; x++)
		{
			currAddress = getValAtAddress(lev_ark, 6 + (x * 4), 32);
			compressionFlag = getValAtAddress(lev_ark, address_pointer + (NoOfBlocks * 4) + (x * 4), 32);
			DataLen = getValAtAddress(lev_ark, address_pointer + (UW2_SIZE_BLOCK * (NoOfBlocks * 4)) + (x * 4), 32);
			isCompressed = (compressionFlag >> 1) & 0x01;
			if (x < BlocksToUnpack)
				{
				if (currAddress!=0)
					{
					switch (isCompressed)
						{
						case 0:
							//DataSize[x] = DataLen;
							for (int y = currAddress; y < currAddress + DataLen; y++)
							{//Copy the bytes
								fputc(lev_ark[y], file);
							}
							break;
						case 1://compressed block
						case 2:
							unsigned char *tmp_ark;
							tmp_ark = unpackUW2(lev_ark, currAddress, &DataLen);
							//DataSize[x] = DataLen;
							for (int y = 0; y < mapSize[x]; y++)
							{//Copy the bytes
								fputc(tmp_ark[y], file);
							}
							break;
						}
					}
				}
			else
				{	//non map. just copy the bytes
				if (currAddress != 0)
					{
					for (int y = currAddress; y < currAddress+DataLen; y++)
						{//Copy the bytes
							fputc(lev_ark[y], file);
						}
					}
				}
		}



	fclose(file);


	if ((file = fopen(OutputFile, "rb")) == NULL)
		{
			printf("Could not open specified file\n");
			return;
		}
	fileSize = getFileSize(file);
	lev_ark = new unsigned char[fileSize];
	fread(lev_ark, fileSize, 1, file);
	fclose(file);
	printf("New Blocks\n");
	for (int x = 0; x < NoOfBlocks; x++)
	{
		currAddress = getValAtAddress(lev_ark, 6 + (x * 4), 32);
		compressionFlag = getValAtAddress(lev_ark, address_pointer + (NoOfBlocks * 4) + (x * 4), 32);
		long DataSizeVal = getValAtAddress(lev_ark, address_pointer + (UW2_SIZE_BLOCK * (NoOfBlocks * 4)) + (x * 4), 32);
		long DataAvail = getValAtAddress(lev_ark, address_pointer + (UW2_SPACE_BLOCK * (NoOfBlocks * 4)) + (x * 4), 32);

		printf("Block no %d\n", x);
		printf("\tAddress %d", currAddress);
		printf("\tFlags %d\n", compressionFlag);
		printf("\tData Size %d", DataSizeVal);
		printf("\tAvailable %d\n", DataAvail);
		printf("\tNext if using datasize %d\n", currAddress + DataSizeVal);
		printf("\tNext if using available %d\n", currAddress + DataAvail);
	}
}

void WriteInt8(FILE *file, long val)
{
	unsigned char valOut;
	valOut = val & 0xff;
	fputc(valOut, file);
}

void WriteInt16(FILE *file, long val)
{
	unsigned char valOut;
	valOut = val & 0xff;
	fputc(valOut, file);

	valOut = val >> 8 & 0xff;
	fputc(valOut,file);


	//return Byte4 << 24 | Byte3 << 16 | Byte2 << 8 | Byte1;
}


void WriteInt32(FILE *file, long val)
{
unsigned char valOut;

	valOut = val & 0xff;
	fputc(valOut, file);

	valOut = val >> 8 & 0xff;
	fputc(valOut, file);

	valOut = val >> 16 & 0xff;
	fputc(valOut, file);

	valOut= val >> 24 & 0xff;
	fputc(valOut, file);

	//return Byte4 << 24 | Byte3 << 16 | Byte2 << 8 | Byte1;
}

void WriteInt24(FILE *file, long val)
{
	unsigned char valOut;

	valOut = val & 0xff;
	fputc(valOut, file);

	valOut = val >> 8 & 0xff;
	fputc(valOut, file);

	valOut = val >> 16 & 0xff;
	fputc(valOut, file);
}

void RepackShock(char InputFile[255], char OutputFile[255])
{
	unsigned char *archive_ark;
	unsigned char *tmp_ark;
	long DirectoryAddress;
	int NoOfChunks;
	long address_pointer;
	long AddressOfBlockStart;
	long NewBlockAddress;
	long BlockAddressesOld[1000];
	long BlockAddressesNew[1000];
	long NewBlockBoundary[1000];
	int chunkNos[1000];
	long UnpackedSize[1000];
	long PackedSize[1000];
	short contentType[1000];
	short compressionFlags[1000];
//load the shock resource file.
	//Read in the archive.
	FILE *file = NULL;      // File pointer
	if ((file = fopen(InputFile, "rb")) == NULL)
	{
		printf("\nRepackShock - Archive not found!\n");
		return;
	}
	long fileSize = getFileSize(file);
	int filepos = ftell(file);
	archive_ark = new unsigned char[fileSize];
	fread(archive_ark, fileSize, 1, file);
	fclose(file);


//Get the directory address
	DirectoryAddress = getValAtAddress(archive_ark,124,32);
	printf("\nThe Directory is at %d\n",DirectoryAddress);
//Read in the directory
	NoOfChunks = getValAtAddress(archive_ark, DirectoryAddress, 16);
	printf("No of chunks = %d\n",NoOfChunks);
	AddressOfBlockStart = getValAtAddress(archive_ark, DirectoryAddress + 2, 32);//The first chunk
	NewBlockAddress= AddressOfBlockStart;
	address_pointer = DirectoryAddress + 6;
	for (int x = 0; x < NoOfChunks; x++)
		{
		int chunkId = getValAtAddress(archive_ark, address_pointer, 16);
		chunkNos[x]=chunkId;

		int chunkUnpackedLength = getValAtAddress(archive_ark, address_pointer + 2, 24);
		UnpackedSize[x]=chunkUnpackedLength;

		int chunkCompression = getValAtAddress(archive_ark, address_pointer + 5, 8);	//Compression.
		compressionFlags[x]=chunkCompression;

		int chunkPackedLength = getValAtAddress(archive_ark, address_pointer + 6, 24);	//Does not matter
		PackedSize[x]=chunkPackedLength;

		short chunkContentType = getValAtAddress(archive_ark, address_pointer + 9, 8);
		contentType[x]=chunkContentType;

		printf("Index: %d, Chunk %d, Unpack size %d, compression %d, packed size %d, content type %d\t",
			x,chunkId, chunkUnpackedLength, chunkCompression,chunkPackedLength,chunkContentType);
		printf("Absolute address is %d",AddressOfBlockStart);
		
		BlockAddressesOld[x] = AddressOfBlockStart;
		BlockAddressesNew[x] = NewBlockAddress;
		printf("\tNew Block will be at %d\n", BlockAddressesNew[x]);
		
		AddressOfBlockStart = AddressOfBlockStart + chunkPackedLength;//The next block
		if ((AddressOfBlockStart % 4) != 0)
			AddressOfBlockStart = AddressOfBlockStart + 4 - (AddressOfBlockStart % 4); // chunk offsets always fall on 4-byte boundaries
		
		NewBlockAddress = NewBlockAddress + chunkUnpackedLength;	//The next block
		NewBlockBoundary[x]=0;
		//printf("\n%d\n",NewBlockAddress % 4);
		if ((NewBlockAddress % 4) != 0)
			{
			NewBlockBoundary[x] = 4 - (NewBlockAddress % 4);//Need to write these bytes to make it all match up.
			NewBlockAddress = NewBlockAddress + 4 - (NewBlockAddress % 4); // chunk offsets always fall on 4-byte boundaries
			}

		address_pointer = address_pointer + 10;
		}

//Write my data.
	if ((file = fopen(OutputFile, "w+b")) == NULL)
	{
		printf("Could not open specified file\n");
		return;
	}
//Copy the header
	for (int i = 0; i < 124; i++)
		{
		fputc(archive_ark[i],file);
		}

//My last chunk address is the directory.
	printf("\nThe New directory is at %d", NewBlockAddress);
	WriteInt32(file, NewBlockAddress);
	

	for (int x = 0; x < NoOfChunks; x++)
		{
		switch (compressionFlags[x])
			{
			case 0:	//Flat uncompressed. Just copy the bytes
				printf("\nCopying uncompressed chunk %d",x);
				for (int i = 0; i < UnpackedSize[x]; i++)
					{
					fputc(archive_ark[BlockAddressesOld[x] + i], file);
					//WriteInt8(file, x+1);
					}
				if (NewBlockBoundary[x]>0)
					{	
					printf("\nWriting a 4 byte boundary");
					for (int i = 0; i < NewBlockBoundary[x]; i++)
							{//Write to the 4 byte boundary.
							WriteInt8(file,0);
							}
					}
				break;
			case 1:	//Flat compressed. Unpacked and copy the output.
				tmp_ark = new unsigned char[UnpackedSize[x]];
				//unpack_data(archive_ark, tmp_ark, UnpackedSize[x]);
				printf("\nUnpacking compressed chunk %d", x);
				LoadShockChunk(BlockAddressesOld[x], compressionFlags[x], archive_ark, tmp_ark, PackedSize[x], UnpackedSize[x]);
				//if (chunkNos[x] == 4105)
				//	{
				//	int add_ptr=0;
				//	for (int i = 0; i<63; i++)
				//		{
				//		for (int j = 0; j<63; j++)
				//			{
				//			if ((i == 20) || (j == 27) || (i == 32) || (j == 20))
				//				{
				//				tmp_ark[add_ptr] = 0;
				//				//tmp_ark[add_ptr + 1] = tmp_ark[add_ptr + 1] & 0xE0;
				//				//tmp_ark[add_ptr+4] = 0;
				//				//tmp_ark[add_ptr+5] = 0;
				//				}
				//			else
				//				{
				//				if ((i != 0) || (j != 0)|| (i != 63) || (j != 63))
				//					{
				//					tmp_ark[add_ptr] = 1;
				//					tmp_ark[add_ptr + 1] = tmp_ark[add_ptr + 1] & 0xE0;
				//					//tmp_ark[add_ptr+4] = 0;
				//					//tmp_ark[add_ptr+5] = 0;
				//					}
				//				}
				//			add_ptr = add_ptr + 16;
				//			}
				//		}
				//	}
				for (int i = 0; i < UnpackedSize[x]; i++)
					{
					fputc(tmp_ark[i], file);
					//WriteInt8(file,x+1);
					}
				if (NewBlockBoundary[x]>0)
				{
					printf("\nWriting a 4 byte boundary");
					for (int i = 0; i < NewBlockBoundary[x]; i++)
					{//Write to the 4 byte boundary.
						WriteInt8(file, 0);
					}
				}
				break;
			case 2:
			case 3:
				printf("\nA subdir! What do I do here!!!\n");
				break;
			}
		}

		//Write the directory
		printf("\nWriting a new boundary");
		//No of chunks (int16)
		WriteInt16(file,NoOfChunks);
		//Offset to first chunk (int32)
		WriteInt32(file,BlockAddressesNew[0]);
		//Loop through
		for (int x = 0; x < NoOfChunks; x++)
		{
		//Chunk Id (int 16)
			WriteInt16(file, chunkNos[x]);
		//chunk unpacked length (int 24)
			WriteInt24(file, UnpackedSize[x]);
		//Chunk compression type (int 8)
			WriteInt8(file, 0);
		//chunk packed length (int 24)
			WriteInt24(file, UnpackedSize[x]);	//uncompressed.
		//Chunk content type.(int 8)
			WriteInt8(file,contentType[x]);
		}
	fclose(file);


//Reread my data
	//*file = NULL;      // File pointer
	if ((file = fopen(OutputFile, "rb")) == NULL)
	{
		printf("\nRepackShock - Archive not found!\n");
		return;
	}
	fileSize = getFileSize(file);

	archive_ark = new unsigned char[fileSize];
	fread(archive_ark, fileSize, 1, file);
	fclose(file);

	//Get the directory address
	DirectoryAddress = getValAtAddress(archive_ark, 124, 32);
	printf("\nThe Directory is at %d\n", DirectoryAddress);
	//Read in the directory
	NoOfChunks = getValAtAddress(archive_ark, DirectoryAddress, 16);
	printf("No of chunks = %d\n", NoOfChunks);
	AddressOfBlockStart = getValAtAddress(archive_ark, DirectoryAddress + 2, 32);//The first chunk
	address_pointer = DirectoryAddress + 6;
	for (int x = 0; x < NoOfChunks; x++)
	{
		int chunkId = getValAtAddress(archive_ark, address_pointer, 16);
		int chunkUnpackedLength = getValAtAddress(archive_ark, address_pointer + 2, 24);
		int chunkCompression = getValAtAddress(archive_ark, address_pointer + 5, 8);	//Compression.
		int chunkPackedLength = getValAtAddress(archive_ark, address_pointer + 6, 24);	//Does not matter
		short chunkContentType = getValAtAddress(archive_ark, address_pointer + 9, 8);
		printf("Index: %d, Chunk %d, Unpack size %d, compression %d, packed size %d, content type %d\t",
			x, chunkId, chunkUnpackedLength, chunkCompression, chunkPackedLength, chunkContentType);
		printf("Absolute address is %d\n", AddressOfBlockStart);

		AddressOfBlockStart = AddressOfBlockStart + chunkPackedLength;//The next block
		if ((AddressOfBlockStart % 4) != 0)
			AddressOfBlockStart = AddressOfBlockStart + 4 - (AddressOfBlockStart % 4); // chunk offsets always fall on 4-byte boundaries

		address_pointer = address_pointer + 10;
	}
}

void ParseTerrainProperties(int game)
{
long fileSize;
unsigned char *terraindat;

	FILE *file = NULL;      // File pointer
	switch (game)
		{
			case UWDEMO:
			case SHOCK:
				{
				return;
				break;
				}
		case UW1:
			{
			if ((file = fopen(UW1_TERRAIN_PROPS, "rb")) == NULL)
				{
				printf("\nParseTerrainProperties UW1 - Archive not found!\n");
				return;
				}
			break;
			}
		case UW2:
			{
			if ((file = fopen(UW2_TERRAIN_PROPS, "rb")) == NULL)
				{
					printf("\nParseTerrainProperties UW2 - Archive not found!\n");
					return;
				}
			break;
			}
		}
	fileSize = getFileSize(file);
	terraindat = new unsigned char[fileSize];
	fread(terraindat, fileSize, 1, file);
	fclose(file);
	printf("Print texture properties from terrain.dat");
	int j=0;
	for (int i = 0; i < 512; i++)
		{
		if (i < 256)
			{
			printf("\nWall:");
			}
		else
			{
			
			printf("\nFloor:");
			}
		if (j == 255)
			{
			j=0;
			}
		printf("%d %s", i, textureMasters[j].desc);
		int textureProp = getValAtAddress(terraindat, i * 2, 16);
		switch (textureProp)
				{
				case 0x0://Normal
					printf(" normal");
					break;
				case 0x2://Ankh Mural
					printf(" anhk mural");
					break;
				case 0x3://Stairs Up
					printf(" stairs up");
					break;
				case 0x4://Stairs down
					printf(" stairs down");
					break;
				case 0x5://Pipe
					printf(" pipe");
					break;
				case 0x6://Grating
					printf(" grating");
					break;
				case 0x7://Drain
					printf(" Drain");
					break;
				case 0x8://Chained up princess
					printf(" chained up princess");
					break;
				case 0x9://Window
					printf(" Window");
					break;
				case 0xa://Tapestry
					printf(" Tapestry");
					break;
				case 0xb://Textured Door
					printf(" Textured door");
					break;
				case 0x10://Water
					printf(" water");
					break;
				case 0x20://Lava
					printf(" Lava");
					break;
				case 0x40://Waterfall
					printf(" waterfall");
					break;
				case 0xC0://Ice wall
					printf(" waterfall");
					break;
				case 0xD8://Unknown
					printf(" unknown");
					break;
				case 0xE8://Ice wall (crumbling)
					printf(" ice wall (crumbling)");
					break;
				case 0x80://Lavafall
					printf(" lava fall");
					break;
				case 0xf8://Ice
					printf(" ice");
					break;
				default:
					printf(" unknown value %d", textureProp);
				}
		j++;
		}
}

void getNoOfFramesForShockDoors(int index, int *NoOfFrames, int *ChunkId)
	{//Frame zero to end
	switch (index)
		{
			case 299://blastdoor
			*ChunkId = 2400;
			*NoOfFrames=6;
			break;
		case 300://service access
			*ChunkId =2401;
			*NoOfFrames =7;
			break;
		case 301:
			*ChunkId =2402;
			*NoOfFrames =7;
			break;
		case 302:
			*ChunkId =2403;
			*NoOfFrames =7;
			break;
		case 303:
			*ChunkId = 2404;
			*NoOfFrames =5;
			break;
		case 304:
			*ChunkId =2405;
			*NoOfFrames =5;
			break;
		case 305:
			*ChunkId =2406;
			*NoOfFrames =7;
			break;
		case 306:
			*ChunkId =2407;
			*NoOfFrames =6;
			break;
		case 318:
		case 319:
		case 320:
		case 321:
			*ChunkId =2423;//????
			*NoOfFrames =7;
		case 322:
		case 323:
			*ChunkId =2424;
			*NoOfFrames =5;//??
			break;
		case 325:
			*ChunkId =2426;
			*NoOfFrames =6;
			break;
		case 326:
			*ChunkId =2427;
			*NoOfFrames =6;
			break;
		case 327:
			*ChunkId =2428;
			*NoOfFrames =7;
			break;
		case 328:
			*ChunkId =2429;
			*NoOfFrames =7;
			break;
		case 330:
			*ChunkId =2431;
			*NoOfFrames =7;
			break;
		case 331:
			*ChunkId =2432;
			*NoOfFrames =7;
			break;
		case 332:
			*ChunkId =2433;
			*NoOfFrames =6;
			break;
		case 336:
			*ChunkId =2437;
			*NoOfFrames =4;
			break;
		case 337:
			*ChunkId = 2438;
			*NoOfFrames =5;
			break;
		case 338:
			*ChunkId =2439;
			*NoOfFrames =5;
			break;
		default:
			*ChunkId=-1;
			*NoOfFrames=-1;
		}

	}
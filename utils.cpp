#include <fstream>

#include "main.h"


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

int getValAtAddress(unsigned char *buffer, long Address, int size)
	{//Gets contents of bytes the the specific integer address. int(8), int(16), int(32) per uw-formats.txt
		switch (size)
		{
		case 8:
			{return buffer[Address];}
		case 16:
			{return ConvertInt16(buffer[Address],buffer[Address+1]);}
		case 24:
			{return ConvertInt24(buffer[Address],buffer[Address+1],buffer[Address+2]);}
		case 32:	//may be buggy!
			{return ConvertInt32(buffer[Address],buffer[Address+1],buffer[Address+2],buffer[Address+3]);}
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
	long chunkContentType;
	long filepos;
//	long AddressOfBlockStart=0;
	long address_pointer=4;
	//int blnLevelFound=0;		
	


	//Find the address of the block. This will also return the file size.
	//AddressOfBlockStart = getShockBlockAddress(ChunkNo,archive_ark,&chunkPackedLength,&chunkUnpackedLength,&chunkType);  	
	if (AddressOfBlockStart == -1)	{return -1;}
	
	if (chunkType ==1)	
		{//Compressed
			unsigned char *temp_ark = new unsigned char[chunkPackedLength];	
			for (long k=0; k< chunkPackedLength; k++)
				{
					temp_ark[k] = archive_ark[AddressOfBlockStart+k];
				}
			
			unpack_data(temp_ark,OutputChunk,chunkUnpackedLength);
			return chunkUnpackedLength;
		}
	else
		{//Uncompressed. 
		//OutputChunk =  new unsigned char[chunkUnpackedLength];
		for (long k=0; k< chunkUnpackedLength; k++)
			{
				OutputChunk[k] = archive_ark[AddressOfBlockStart+k];
			}		
		return chunkUnpackedLength;
		}
}
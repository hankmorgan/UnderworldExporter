#include <stdio.h>
#include <stdlib.h>
#include <fstream>
#include <string.h>

#include "utils.h"
#include "main.h"
#include "gamestrings.h"




void unpackStrings(int game)
{
char filePath[255];
switch (game)
	{
	case UWDEMO:
	case UW1:
		strcpy_s(filePath, UW1_STRINGS_FILE);break;	
	case UW2:
		strcpy_s(filePath, UW2_STRINGS_FILE);break;	
	case SHOCK:
		strcpy_s(filePath, SHOCK_STRINGS_FILE);break;	
	}
huffman_node *hman;
block_dir *blocks;
unsigned char *Buffer;
long NoOfNodes; long NoOfStringBlocks;
long address_pointer=0;
//char *str;

	FILE *file = NULL;      // File pointer
	//fopen_s(file,filePath, "rb");
    if (fopen_s(&file,filePath, "rb") != 0)
        {
        printf("Could not open specified file\n");
        }
	else
		{
		// Get the size of the file in bytes
		long fileSize = getFileSize(file);
	 
		// Allocate space in the buffer for the whole file
	    
		Buffer = new unsigned char[fileSize];
		fread(Buffer, fileSize, 1,file);
		fclose(file);
		NoOfNodes=getValAtAddress(Buffer,address_pointer,16);
		int i=0;
		hman = new huffman_node [NoOfNodes];
		address_pointer=address_pointer+2;
		while (i<NoOfNodes)
			{
			hman[i].symbol= Buffer[address_pointer+0];
			hman[i].parent= Buffer[address_pointer+1];
			hman[i].left= Buffer[address_pointer+2];
			hman[i].right= Buffer[address_pointer+3];
			printf("Node:%d parent=%d, left=%d, right=%d, symbol=%c\n",i,hman[i].parent, hman[i].left, hman[i].right, hman[i].symbol);
			i++;
			address_pointer=address_pointer+4;
			}
		//next is the number of string blocks
		NoOfStringBlocks=getValAtAddress(Buffer,address_pointer,16);
		blocks=new block_dir[NoOfStringBlocks];
		address_pointer=address_pointer+2;
		i=0;
		while (i<NoOfStringBlocks)
			{
			blocks[i].block_no = getValAtAddress(Buffer,address_pointer,16);
			address_pointer=address_pointer+2;
			blocks[i].address = getValAtAddress(Buffer,address_pointer,32);	
			address_pointer=address_pointer+4;
			blocks[i].NoOfEntries = getValAtAddress(Buffer,blocks[i].address,16);	//look ahead and get no of entries.
			
			i++;
			}
		i=0;	
		while (i<NoOfStringBlocks)
			{
			//printf("Block %d is at address %d. It has %d entries\n",blocks[i].block_no,blocks[i].address, blocks[i].NoOfEntries );
			address_pointer=2 + blocks[i].address + blocks[i].NoOfEntries *2;
			//printf("It's strings begin at %d\n", address_pointer);
			//printf("It should end at %d\n",blocks[i+1].address );
			//printf("\n+=====================================+\n");
			//printf("Block Name: %d\n", blocks[i].block_no);
			long strAdd;
			int blnFnd;
			strAdd= address_pointer;
			for (int j=0;j< blocks[i].NoOfEntries;j++)
			{
				//Based on abysmal /uwadv implementations.
				blnFnd=0;
				char c;
				
				int bit = 0;
				int raw = 0;
				int node=0;
				do {
					node = NoOfNodes - 1; // starting node

					// huffman tree decode loop
					while (char(hman[node].left) != -1
						&& char(hman[node].right) != -1)
					{

						if (bit == 0) {
							bit = 8;
							raw = Buffer[address_pointer++];	//stream.get<uint8_t>();
						}

						// decide which node is next
						node = raw & 0x80 ? short (hman[node].right)
							   : short (hman[node].left);

						raw <<= 1;
						bit--;
					}

					// have a new symbol
					if ((hman[node].symbol !='|') && (hman[node].symbol !=10)){
						if (blnFnd==0)
							//{printf("\nBlock %d String %d at %d:",blocks[i].block_no, j, strAdd);	}
							{
							//printf("\n%03d=",j);	
							printf("\n%03d=%03d=",blocks[i].block_no,j);
							}
						printf("%c",hman[node].symbol);
						blnFnd = 1;
					}
				} while (hman[node].symbol != '|');		
			}
			i++;
			}	
		}
}

void unpackStringsShock(char filePath[255])
{//this looks familiar.
//long BlockNo;
unsigned char *tmp_ark ;
long chunkPackedLength;
long chunkUnpackedLength;
	//char *filePath = SHOCK_STRINGS_FILE;
	FILE *file = NULL;      // File pointer
	
     if (fopen_s(&file,filePath, "rb") != 0)
		{
        printf("Could not open specified file\n");
        }
    else
		{

	 
		// Get the size of the file in bytes
		long fileSize = getFileSize(file);
	 
		// Allocate space in the tmp_ark for the whole file
	    
		tmp_ark = new unsigned char[fileSize];
		fread(tmp_ark, fileSize, 1,file);
		fclose(file);
		
		int blnLevelFound =0;
		long DirectoryAddress=getValAtAddress(tmp_ark,124,32);
		printf("\nThe directory is at %d\n", DirectoryAddress);
		
		long NoOfChunks = getValAtAddress(tmp_ark,DirectoryAddress,16);
		printf("there are %d chunks\n",NoOfChunks);
		long firstChunkAddress = getValAtAddress(tmp_ark,DirectoryAddress+2,32);
		printf("The first chunk is at %d\n", firstChunkAddress);
		long address_pointer=DirectoryAddress+6;
		long AddressOfBlockStart= firstChunkAddress;
		for (int k=0; k< NoOfChunks; k++)
			{
			long chunkId = getValAtAddress(tmp_ark,address_pointer,16);
			chunkUnpackedLength =getValAtAddress(tmp_ark,address_pointer+2,24);
			long chunkType = getValAtAddress(tmp_ark,address_pointer+5,8);
			chunkPackedLength = getValAtAddress(tmp_ark,address_pointer+6,24);
			long chunkContentType = getValAtAddress(tmp_ark,address_pointer+9,8);
			printf("Index: %d, Chunk %d, Unpack size %d, compression %d, packed size %d, content type %d\t",k,chunkId, chunkUnpackedLength, chunkType,chunkPackedLength,chunkContentType);
			printf("Absolute address is %d\n",AddressOfBlockStart);
			long NoSubChunks = getValAtAddress(tmp_ark,AddressOfBlockStart,16);
			printf("\nIndex: %d Chunk %d has %d sub chunks",k, chunkId, NoSubChunks);
			printf("\n@Chunk:%d\n{",chunkId);
			printf("\n+=====================================+\n");
			long strPtr=2;
			for (int i = 0; i<NoSubChunks;i++)
				{
				long subChunkStart =AddressOfBlockStart+ getValAtAddress(tmp_ark,AddressOfBlockStart+strPtr,32);
				long subChunkEnd = AddressOfBlockStart+getValAtAddress(tmp_ark,AddressOfBlockStart+strPtr+4,32);
				if (subChunkEnd > subChunkStart)
					{
					printf("%d =", i);
					printf(" %.*s\n", subChunkEnd- subChunkStart, tmp_ark + subChunkStart);			
					}
				strPtr+=4;
				}
			printf("}\n");
			AddressOfBlockStart=AddressOfBlockStart+ chunkPackedLength;
			if ((AddressOfBlockStart % 4) != 0)
				AddressOfBlockStart = AddressOfBlockStart + 4 - (AddressOfBlockStart % 4); // chunk offsets always fall on 4-byte boundaries
			

			address_pointer=address_pointer+10;			
			}
		}	

	
}

int lookupString(int BlockNo, int StringNo, char StringOut[255] )
	{//looks up a flat file of strings to find the specified value
	//
	int BlockNoFnd=0;
	int StringNoFnd=0;
	char stringContents[255];
	char filePath[255];
	char line[255];
	
	FILE *file = NULL;      // File pointer
	strcpy_s(filePath,255,UW1_CLEAN_STRINGS_FILE);
     if (fopen_s(&file, filePath, "r") == 0)
		{
			while (fgets(line,255,file))
				{
				sscanf(line,"%d=%d=%[^\n]",&BlockNoFnd,&StringNoFnd,&stringContents);
				if ((BlockNo==BlockNoFnd) && (StringNo==StringNoFnd))
					{
					fclose(file);
					strcpy_s(StringOut ,255,stringContents);
					return 1;
					}
					
				}
			fclose(file);
			return	-1;
		}
	else
		{
		return -1;
		}
	}
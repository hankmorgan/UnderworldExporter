#include <stdio.h>
#include <stdlib.h>
#include <fstream>
#include <string.h>

#include "main.h"
#include "utils.h"


void parseInfoLine(char *str, int length, int *left, int *right);

void BuildXDataFile(int game)
{

	int right; int left;	//portraits.

	//this looks familiar.
	//long BlockNo;
	unsigned char *tmp_ark;
	long chunkPackedLength;
	long chunkUnpackedLength;
	char *filePath = SHOCK_STRINGS_FILE;
	FILE *file = NULL;      // File pointer

	if (fopen_s(&file, filePath, "rb") != 0)
	{
		printf("Could not open specified file\n");
	}
	else
	{
		// Get the size of the file in bytes
		long fileSize = getFileSize(file);

		// Allocate space in the tmp_ark for the whole file

		tmp_ark = new unsigned char[fileSize];
		fread(tmp_ark, fileSize, 1, file);
		fclose(file);
		
		int blnLevelFound = 0;
		long DirectoryAddress = getValAtAddress(tmp_ark, 124, 32);
		//printf("\nThe directory is at %d\n", DirectoryAddress);

		long NoOfChunks = getValAtAddress(tmp_ark, DirectoryAddress, 16);
		//printf("there are %d chunks\n", NoOfChunks);
		long firstChunkAddress = getValAtAddress(tmp_ark, DirectoryAddress + 2, 32);
		//printf("The first chunk is at %d\n", firstChunkAddress);
		long address_pointer = DirectoryAddress + 6;
		long AddressOfBlockStart = firstChunkAddress;
		for (int k = 0; k< NoOfChunks; k++)
		{
			long chunkId = getValAtAddress(tmp_ark, address_pointer, 16);
			chunkUnpackedLength = getValAtAddress(tmp_ark, address_pointer + 2, 24);
			long chunkType = getValAtAddress(tmp_ark, address_pointer + 5, 8);
			chunkPackedLength = getValAtAddress(tmp_ark, address_pointer + 6, 24);
			long chunkContentType = getValAtAddress(tmp_ark, address_pointer + 9, 8);
			long NoSubChunks = getValAtAddress(tmp_ark, AddressOfBlockStart, 16);
			//printf("\n@Chunk:%d\n{", chunkId);
			if ((chunkId >= 2490) && (chunkId <= 2621))
				{//we have a log.
				int step = 0;
					long strPtr = 2;
					for (int i = 0; i<NoSubChunks; i++)
					{
						long subChunkStart = AddressOfBlockStart + getValAtAddress(tmp_ark, AddressOfBlockStart + strPtr, 32);
						long subChunkEnd = AddressOfBlockStart + getValAtAddress(tmp_ark, AddressOfBlockStart + strPtr + 4, 32);
						if (subChunkEnd > subChunkStart)
						{
							switch (step)
							{
							case 0:
								{//Build the xdata header
								printf("readables/shock/log_%04d\n\t{\n\tprecache\n",chunkId);
								printf("\t\"num_pages\" : \"1\"\n");

								//Info Line : has the following format :
								//[event][colour]LeftId[, []RightId]
								//	event : 'iEE' or 't'
								//	EE = Hex Number of Log / eMail to follow immediately
								//	't' is set for Texts following a 'iEE' Text
								//colour : 'cCC'
								//		 CC = Hex Number of Colour Index in Palette;
								//only Sender and Subject are drawn in this colour
								//	LeftId, RightId:
								//decimal subchunk number of left(and right) bitmaps to show;
								//char *str;
								char *str;
								str=new char[subChunkEnd - subChunkStart];
								for (int x = 0; x < subChunkEnd - subChunkStart; x++)
									{
									str[x] = tmp_ark[subChunkStart + x];
									}
								//sprintf_s(str, "%.*s", subChunkEnd - subChunkStart, tmp_ark + subChunkStart);
							
								//The first line defines who appears in the gui
								//printf(" %.*s\n", subChunkEnd - subChunkStart, tmp_ark + subChunkStart);
								right=-1; left=-1;
								parseInfoLine(str, subChunkEnd - subChunkStart, &left, &right);
								strPtr += 4;
								step++;
								break;
								}
							case 1:
								{
								//Then the title of the document
								printf("\t\"page1_title\" :\n\t\t{\n");
								printf("\t\t\"%.*s\\n\"\n\t\t}", subChunkEnd - subChunkStart, tmp_ark + subChunkStart);
								strPtr += 4;
								step++;
								break;
								}
							case 2:
								{
								//And then the body
								printf("\n\t\"page1_body\" :\n\t\t{\n\t\t\"");
								}//and falls thru
							default:
								{//And the body
								printf("%.*s\\n", subChunkEnd - subChunkStart, tmp_ark + subChunkStart);
								step++;
								strPtr += 4;
								break;
								}
							}
						}
					}
					if (step >= 1)
					{	//Finish out the xdata definition
						printf("\"\n\t\t}\n\t\t\n\t\"gui_page1\"	: \"guis/readables/log.gui\"\n");
						if (left != -1)
						{
							printf("\t\"page1_PortraitLeft\" : \"guis/assets/shock/logs/0040_%04d.tga\"\n", left);
						}
						else
						{
							printf("\t\"page1_PortraitLeft\" : \"guis/assets/shock/logs/0040_0030.tga\"\n");
						}

						if (right != -1)
						{
							printf("\t\"page1_PortraitRight\" : \"guis/assets/shock/logs/0040_%04d.tga\"", right);
						}
						else
						{
							printf("\t\"page1_PortraitRight\" : \"guis/assets/shock/logs/0040_0030.tga\"");
						}
						
						printf("\n}\n\n");
						}
				
				}
			AddressOfBlockStart = AddressOfBlockStart + chunkPackedLength;
			if ((AddressOfBlockStart % 4) != 0)
				AddressOfBlockStart = AddressOfBlockStart + 4 - (AddressOfBlockStart % 4); // chunk offsets always fall on 4-byte boundaries


			address_pointer = address_pointer + 10;
		}
	}


}


void parseInfoLine(char *str, int length, int *left, int *right)
{
	short fndleft = 0;
	short fndright = 0;
	char strleft[2];
	char strright[2];
	int j = 0; int k = 0;
	int i = 0;
	while (i < length)
	{
		if (str[i] == 'e')
		{
			i = i + 3;
		}
		else
		{
			if (str[i] == 'c')
			{
				i = i + 3;
			}
			else
			{
				if ((str[i] == ' ') || (str[i] == ','))
				{
					i++;
				}
				else
				{
					if (fndleft == 0)
					{
						j = 0;
						while ((i < length) && (j <= 1))
						{
							if (isdigit(str[i]))
							{
								strleft[j++] = str[i++];
								fndleft = 1;
							}
							else
							{
								i++;
								break;
						    }
						}
						
					}
					else
					{
						if (fndright == 0)
						{

							//the right hand value
							k = 0;
							while ((i < length) && (k <= 1))
							{
								if (isdigit(str[i]))
									{
									strright[k++] = str[i++];
									fndright = 1;
									}
								else
									{
									i++;
									break;
									}
							}
							
						}
						else
						{
							i++;
						}
					}

				}
			}
		}

	}

	
	if (fndleft == 1)
	{
		char *strResult = new char[j];
		for (i = 0; i < j; i++)
		{
			strResult[i] = strleft[i];
		}
		*left = atoi(strResult);
	}
	else
	{
		*left = -1;
	}


	if (fndright == 1)
	{
		char *strResult = new char[k];
		for (i = 0; i < k; i++)
		{
			strResult[i] = strright[i];
		}
		*right = atoi(strResult);
	}
	else
	{
		*right = -1;
	}

}
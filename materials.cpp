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
			if ((chunkId >= 2441) && (chunkId <= 2621))
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
		if ((str[i] == 'e') || (str[i] == 'c') || (str[i] == 'i'))
		{
			i = i + 3;
		}
		else
			{
			if ((str[i] == ' ') || (str[i] == ',') || (str[i] == 't'))
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

void BuildSndShaderFiles()
{

	for (int i = 1; i <= 106; i++)
	{
		FILE *fileOut;
		char filePath[80]="";
		sprintf_s(filePath, 80, "c:\\games\\darkmod\\sound\\shock_bark_%d.sndshd", i);
		if (fopen_s(&fileOut, filePath, "w") != 0)
		{
			printf("Unable to create output file for shader");
			return;
		}
		fprintf(fileOut, "shock_audio_bark_%d\n{\n", i);
		fprintf(fileOut, "\t description \"shock_bark_%d\"\n",i);
		fprintf(fileOut, "\t no_dups\n", i);
		fprintf(fileOut, "\t minDistance 1\n");
		fprintf(fileOut, "\t maxDistance 30\n", i);
		fprintf(fileOut, "\t volume -12\n", i);
		fprintf(fileOut, "\t sound/sfx/shock_barks/bark%d.ogg\n", i);
		fprintf(fileOut, "}", i);
		fclose(fileOut);
	}

}

void BuildUWMtrFiles(int game, int mtrType)
{
	int noOfImages = 0;
	int noOfDoors = 0;
	int gameNo = 0;
	switch (game)
	{
	case UWDEMO:
	case UW1:
		noOfImages = 38;
		noOfDoors = 13;
		gameNo = 1;
		break;
	case UW2:
		noOfImages = 53;
		noOfDoors = 14;
		gameNo = 2;
		break;
	}
	switch (mtrType)
		{
		case 0://regular textures
			break;
		case 1:
			//tmobj files

			for (int i = 0; i < noOfImages; i++)
			{
				FILE *fileOut;
				char filePath[80] = "";
				sprintf_s(filePath, 80, "c:\\games\\darkmod\\materials\\uw%d_model_%02d.mtr",gameNo, i);
				if (fopen_s(&fileOut, filePath, "w") != 0)
				{
					printf("Unable to create output file for material");
					return;
				}//textures\uw1\tmobj\tmobj_02
				fprintf(fileOut, "textures\\uw%d\\tmobj\\tmobj_%02d\n{\n",gameNo, i);
				fprintf(fileOut, "\tbumpmap\t_flat\n\tdiffusemap\ttextures\\uw%d\\tmobj\\tmobj_%02d.tga\n\tspecularmap\t_black\n",gameNo, i);
				fprintf(fileOut, "\tqer_editorimage textures\\uw%d\\tmobj\\tmobj_%02d.tga\n", gameNo, i);
				fprintf(fileOut, "\t{\n\t\tblend gl_dst_color, gl_one\n\tcolored\n\t\tmap textures\\uw%d\\tmobj\\tmobj_%02d.tga\n\t}", gameNo, i);
				fprintf(fileOut, "\n}", i);
				fclose(fileOut);
			}
			break;
		case 2:
			for (int i = 0; i < noOfDoors; i++)
			{
				FILE *fileOut;
				char filePath[80] = "";
				sprintf_s(filePath, 80, "c:\\games\\darkmod\\materials\\uw%d_doors_%02d.mtr", gameNo, i);
				if (fopen_s(&fileOut, filePath, "w") != 0)
				{
					printf("Unable to create output file for material");
					return;
				}//textures\uw1\tmobj\tmobj_02
				fprintf(fileOut, "textures\\uw%d\\doors\\doors_%02d\n{\n", gameNo, i);
				fprintf(fileOut, "\tbumpmap\t_flat\n\tdiffusemap\ttextures\\uw%d\\doors\\doors_%02d.tga\n\tspecularmap\t_black\n", gameNo, i);
				fprintf(fileOut, "\tqer_editorimage textures\\uw%d\\doors\\doors_%02d.tga\n", gameNo, i);
				fprintf(fileOut, "\t{\n\t\tblend gl_dst_color, gl_one\n\tcolored\n\t\tmap textures\\uw%d\\doors\\doors_%02d.tga\n\t}", gameNo, i);
				fprintf(fileOut, "\n}", i);
				fclose(fileOut);
			}
		}
}

void BuildSHOCKMtrFiles(int MtrType)
{
	switch (MtrType)
	{
	case 0://regular textures

		break;
	case 1://decals
		for (int i = 0; i <= 17; i++)
		{//Icons
			FILE *fileOut;
			char filePath[80] = "";
			sprintf_s(filePath, 80, "c:\\games\\darkmod\\materials\\shock_icon_%d.mtr", i);
			if (fopen_s(&fileOut, filePath, "w") != 0)
			{
				printf("Unable to create output file for material");
				return;
			}
			fprintf(fileOut, "textures\\shock\\icon\\0078_%04d\n{\n", i);
			fprintf(fileOut, "\tDECAL_MACRO\n\tnoShadows\n\ttwoSided\n\tnonsolid\n\tnoimpact\n");
			fprintf(fileOut, "\tqer_editorimage textures/shock/icon/0078_%04d.tga\n", i);
			fprintf(fileOut, "\t{\n\t\tblend GL_SRC_ALPHA, GL_ONE_MINUS_SRC_ALPHA\n\tcolored\n\t\tmap textures/shock/icon/0078_%04d.tga\n\t\talphatest 0.8\n\t}", i);
			fprintf(fileOut, "\n}", i);
			fclose(fileOut);
		}
		for (int i = 0; i <= 7; i++)
		{//Graffiti
			FILE *fileOut;
			char filePath[80] = "";
			sprintf_s(filePath, 80, "c:\\games\\darkmod\\materials\\shock_graffiti_%d.mtr", i);
			if (fopen_s(&fileOut, filePath, "w") != 0)
			{
				printf("Unable to create output file for material");
				return;
			}
			fprintf(fileOut, "textures\\shock\\graffiti\\0079_%04d\n{\n", i);
			fprintf(fileOut, "\tDECAL_MACRO\n\tnoShadows\n\ttwoSided\n\tnonsolid\n\tnoimpact\n");
			fprintf(fileOut, "\tqer_editorimage textures/shock/graffiti/0079_%04d.tga\n", i);
			fprintf(fileOut, "\t{\n\t\tblend GL_SRC_ALPHA, GL_ONE_MINUS_SRC_ALPHA\n\tcolored\n\t\tmap textures/shock/graffiti/0079_%04d.tga\n\t\talphatest 0.8\n\t}", i);
			fprintf(fileOut, "\n}", i);
			fclose(fileOut);
		}

		for (int i = 0; i <= 1; i++)
		{//signs
			FILE *fileOut;
			char filePath[80] = "";
			sprintf_s(filePath, 80, "c:\\games\\darkmod\\materials\\shock_sign_%d.mtr", i);
			if (fopen_s(&fileOut, filePath, "w") != 0)
			{
				printf("Unable to create output file for material");
				return;
			}
			fprintf(fileOut, "textures\\shock\\sign\\1350_%04d\n{\n", 390+i);
			fprintf(fileOut, "\tDECAL_MACRO\n\tnoShadows\n\ttwoSided\n\tnonsolid\n\tnoimpact\n");
			fprintf(fileOut, "\tqer_editorimage textures/shock/sign/1350_%04d.tga\n", 390+i);
			fprintf(fileOut, "\t{\n\t\tblend GL_SRC_ALPHA, GL_ONE_MINUS_SRC_ALPHA\n\tcolored\n\t\tmap textures/shock/sign/1350_%04d.tga\n\t\talphatest 0.8\n\t}", 390 + i);
			fprintf(fileOut, "\n}", i);
			fclose(fileOut);
		}
		for (int i = 0; i <= 2; i++)
		{//paintings
			FILE *fileOut;
			char filePath[80] = "";
			sprintf_s(filePath, 80, "c:\\games\\darkmod\\materials\\shock_painting_%d.mtr", i);
			if (fopen_s(&fileOut, filePath, "w") != 0)
			{
				printf("Unable to create output file for material");
				return;
			}
			fprintf(fileOut, "textures\\shock\\painting\\1350_%04d\n{\n", 403 + i);
			fprintf(fileOut, "\tDECAL_MACRO\n\tnoShadows\n\ttwoSided\n\tnonsolid\n\tnoimpact\n");
			fprintf(fileOut, "\tqer_editorimage textures/shock/painting/1350_%04d.tga\n", 403 + i);
			fprintf(fileOut, "\t{\n\t\tblend GL_SRC_ALPHA, GL_ONE_MINUS_SRC_ALPHA\n\tcolored\n\t\tmap textures/shock/painting/1350_%04d.tga\n\t}", 403 + i);
			fprintf(fileOut, "\n}", i);
			fclose(fileOut);
		}
	case 2://Animated stuff
		break;
	case  3:	//3d model textures
		for (int i = 475; i <= 525; i++)
		{//3d models
			FILE *fileOut;
			char filePath[80] = "";
			sprintf_s(filePath, 80, "c:\\games\\darkmod\\materials\\shock_model_%d.mtr", i);
			if (fopen_s(&fileOut, filePath, "w") != 0)
			{
				printf("Unable to create output file for material");
				return;
			}
			fprintf(fileOut, "textures\\shock\\models\\model_%04d\n{\n", i);
			fprintf(fileOut, "\tbumpmap\t_flat\n\tdiffusemap\ttextures\\shock\\model\\%04d.tga\n\tspecularmap\t_black\n", i);
			fprintf(fileOut, "\tqer_editorimage textures/shock/model/%04d.tga\n", i);
			fprintf(fileOut, "\t{\n\t\tblend gl_dst_color, gl_one\n\tcolored\n\t\tmap textures/shock/model/%04d.tga\n\t}", i);
			fprintf(fileOut, "\n}", i);
			fclose(fileOut);
		}
}

}

void BuildGuiFiles()
{
	int startframe; int noofframes; int loopflag; int startframeactual;
	char line[255];
	FILE *fileOut;
	char filePath[80] = "";
	FILE *f = NULL;

	if ((fopen_s(&f, "C:\\Underworld Exporter\\src\\trunk\\Debug\\screens.txt", "r") == 0))
	{
		while (fgets(line, 255, f))
		{
			sscanf(line, "%d %d %d %d",
				&startframe, &noofframes, &loopflag, &startframeactual);
			sprintf_s(filePath, 80, "c:\\games\\darkmod\\guis\\shock\\screen_%d_%d_%d.gui", startframe, noofframes, loopflag);
			if (fopen_s(&fileOut, filePath, "w") != 0)
			{
				printf("Unable to create output file for material");
				
			}
			else
			{
				fprintf(fileOut,"windowDef Desktop\n{\n\trect 0,0,640,480\n\tnocursor 1\n");
				fprintf(fileOut, "\tfloat destroyed 0\n");
				fprintf(fileOut, "\t\twindowdef panel\n\t\t{\n");
				fprintf(fileOut, "\t\trect 0,0,640,480\n\t\tvisible 1\n");
				fprintf(fileOut, "\t\tbackground \"guis/assets/shock/screens/%04d\";\n\n", startframe + 321);
				int j = 0;
				int i = 0;
				for (i = startframe; i < startframe + noofframes; i++)
				{
					fprintf(fileOut, "\t\tonTime %d{\n", (j++) * 500);
					fprintf(fileOut, "\t\t\tif (\"gui::destroyed\"==1)\n");
					fprintf(fileOut, "\t\t\t{resetTime \"%d\";}\n", noofframes * 3 * 500);
					fprintf(fileOut, "\t\t\telse{\n");
					fprintf(fileOut, "\t\t\tset \"background\" \"guis/assets/shock/screens/%04d\";\n", i + 321);
					fprintf(fileOut, "\t\t\t}\n");
					fprintf(fileOut, "\t\t}\n");
				}
				if (loopflag != 0)
				{
					for (i = startframe + noofframes - 2; i > startframe ; i--)
					{
						fprintf(fileOut, "\t\tonTime %d{\n", (j++) * 500);
						fprintf(fileOut, "\t\t\tif (\"gui::destroyed\"==1)\n");
						fprintf(fileOut, "\t\t\t{resetTime \"%d\";}\n", noofframes * 3 * 500);
						fprintf(fileOut, "\t\t\telse{\n");
						fprintf(fileOut, "\t\t\tset \"background\" \"guis/assets/shock/screens/%04d\";\n", i + 321);
						fprintf(fileOut, "\t\t\t}\n");
						fprintf(fileOut, "\t\t}\n");
					}
					//reset a forwards and backwards sequence
					fprintf(fileOut, "\t\tonTime %d{\n", (j++) * 500);
					fprintf(fileOut, "\t\t\tif (\"gui::destroyed\"==1)\n");
					fprintf(fileOut, "\t\t\t{resetTime \"%d\";}\n", noofframes * 3 * 500);
					fprintf(fileOut, "\t\t\telse{\n");
					//fprintf(fileOut, "\t\t\tset \"background\" \"guis/assets/shock/screens/%04d\";\n", i + 321);
					fprintf(fileOut, "\t\t\tresetTime \"0\";\n");
					fprintf(fileOut, "\t\t\t}\n");
					fprintf(fileOut, "\t\t}\n");
				}
				else
				{
					//resets a forward only sequence.
					fprintf(fileOut, "\t\tonTime %d{\n", (j++) * 500);
					fprintf(fileOut, "\t\t\tif (\"gui::destroyed\"==1)\n");
					fprintf(fileOut, "\t\t\t{resetTime \"%d\";}\n", noofframes * 3 * 500);
					fprintf(fileOut, "\t\t\telse{\n");
					fprintf(fileOut, "\t\t\tresetTime \"0\";\n");
					fprintf(fileOut, "\t\t\t}\n");
					fprintf(fileOut, "\t\t}\n");

				}
				//Now the screen destruction sequence
				j = 0;
				int startTimeDestructTime = ((noofframes * 3) + 1) * 500;
				for (i = 16; i < 31; i++)
				{
					fprintf(fileOut, "\t\tonTime %d{\n", startTimeDestructTime + (j++)*100);
					fprintf(fileOut, "\t\t\tset \"background\" \"guis/assets/shock/screens/%04d\";\n", i + 321);
					fprintf(fileOut, "\t\t}\n");
				}

				fprintf(fileOut, "\t}\n}");
				fclose(fileOut);
			}
		}
	}
}

void BuildWORDSXData(int game)
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
		for (int k = 0; k < NoOfChunks; k++)
		{
			long chunkId = getValAtAddress(tmp_ark, address_pointer, 16);
			chunkUnpackedLength = getValAtAddress(tmp_ark, address_pointer + 2, 24);
			long chunkType = getValAtAddress(tmp_ark, address_pointer + 5, 8);
			chunkPackedLength = getValAtAddress(tmp_ark, address_pointer + 6, 24);
			long chunkContentType = getValAtAddress(tmp_ark, address_pointer + 9, 8);
			long NoSubChunks = getValAtAddress(tmp_ark, AddressOfBlockStart, 16);
			//printf("\n@Chunk:%d\n{", chunkId);
			if (chunkId == 2152) //The words
			{
				long strPtr = 2;
				for (int i = 0; i<NoSubChunks; i++)
				{
					long subChunkStart = AddressOfBlockStart + getValAtAddress(tmp_ark, AddressOfBlockStart + strPtr, 32);
					long subChunkEnd = AddressOfBlockStart + getValAtAddress(tmp_ark, AddressOfBlockStart + strPtr + 4, 32);
					if (subChunkEnd > subChunkStart)
					{

						printf("readables/shock/words_%d",i);
						printf("\n{");
						printf("\n\tprecache");
						printf("\n\t\"num_pages\"	: \"1\"");
						printf("\n\t\"page1_title\" :");
						printf("\n\t{");
						printf("\n\t\t\"\"");
						printf("\n\t}");
						printf("\n\t\"page1_body\" :");
						printf("\n\t{");
						//The works go here.
						printf("\n\t\t\"%.*s\"\n", subChunkEnd - subChunkStart, tmp_ark + subChunkStart);
						printf("\n\t}");
						printf("\n\t\"gui_page1\" : \"guis/readables/transparent.gui\"");
						printf("\n\t\"snd_page_turn\" : \"readable_page_turn\"");
						printf("\n}\n");

						//printf("%d =", i);
						
					}
					strPtr += 4;
				}
				break;
			}
			AddressOfBlockStart = AddressOfBlockStart + chunkPackedLength;
			if ((AddressOfBlockStart % 4) != 0)
				AddressOfBlockStart = AddressOfBlockStart + 4 - (AddressOfBlockStart % 4); // chunk offsets always fall on 4-byte boundaries


			address_pointer = address_pointer + 10;
		}
	}
}

void ExportModelFormat()
{
	unsigned char *archive_ark;
	unsigned char *model_chunk;
	FILE *file = NULL;      // File pointer
	long chunkUnpackedLength = 0;
	long chunkType = 0;//compression type
	long chunkPackedLength = 0;

	if ((file = fopen(SHOCK_MODEL_FILE, "rb")) == NULL)
	{
		printf("\nArchive not found!\n");
		return;
	}
	long fileSize = getFileSize(file);
	int filepos = ftell(file);
	archive_ark = new unsigned char[fileSize];
	fread(archive_ark, fileSize, 1, file);
	fclose(file);
	for (int k = 2300; k <= 2379; k++)
	{
		long blockAddress = getShockBlockAddress(k, archive_ark, &chunkPackedLength, &chunkUnpackedLength, &chunkType);
		if (blockAddress == -1) { return; }
		model_chunk = new unsigned char[chunkUnpackedLength];
		LoadShockChunk(blockAddress, chunkType, archive_ark, model_chunk, chunkPackedLength, chunkUnpackedLength);
		printf("Header 0 : %d\n", getValAtAddress(model_chunk, 0, 8));
		printf("Header 1 : %d\n", getValAtAddress(model_chunk, 1, 8));
		printf("Header 2 : %d\n", getValAtAddress(model_chunk, 2, 8));
		printf("Header 3 : %d\n", getValAtAddress(model_chunk, 3, 8));
		printf("Header 4 : %d\n", getValAtAddress(model_chunk, 4, 8));
		printf("Header 5 : %d\n", getValAtAddress(model_chunk, 5, 8));
		printf("Header 6 : %d\n", getValAtAddress(model_chunk, 6, 16));
		int noFaces = getValAtAddress(model_chunk, 6, 16); 
		long add_ptr = 8;
		while (add_ptr < chunkUnpackedLength)
		{
		
		switch (getValAtAddress(model_chunk, add_ptr, 16))
			{
		    case 0:	//End of sub-hull whatever that means
			default:
				printf("\n\t%d", getValAtAddress(model_chunk, add_ptr, 16));
				add_ptr = add_ptr + 2;
			}
		}
	}

}
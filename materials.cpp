#include <stdio.h>
#include <stdlib.h>
#include <fstream>
#include <string.h>

#include "main.h"
#include "utils.h"
#include "gamestrings.h"

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
		for (int i = 0; i <= 272; i++)
			{
			FILE *fileOut;
			char filePath[80] = "";
			sprintf_s(filePath, 80, "c:\\games\\darkmod\\materials\\shock_%03d.mtr", i);
			if (fopen_s(&fileOut, filePath, "w") != 0)
				{
				printf("Unable to create output file for material");
				return;
				}
			fprintf(fileOut, "textures\\shock\\shock_%03d\n{\n", i);
			fprintf(fileOut, "\tdescription\t\"stone\"\n");
			fprintf(fileOut, "\tqer_editorimage\ttextures\\shock\\shock_%04d_%04d.tga\n",i+1000, 0);
			fprintf(fileOut, "\tbumpmap\t_flat\n");
			fprintf(fileOut, "\tdiffusemap\ttextures\\shock\\shock_%04d_%04d.tga\n", i + 1000, 0);
			fprintf(fileOut, "\tspecularmap\t_black\n");
			fprintf(fileOut, "\t{\n");
			//fprintf(fileOut, "\tif (parm11 > 0)\n");
			fprintf(fileOut, "\tblend GL_SRC_ALPHA, GL_ONE_MINUS_SRC_ALPHA\n");
			//fprintf(fileOut, "\tblend gl_dst_color, gl_src_color\n");
			//fprintf(fileOut, "\n\tblend none\n");
			fprintf(fileOut, "\tmap\ttextures\\shock\\shock_%04d_%04d.tga\n", i + 1000, 0);
			fprintf(fileOut, "\t}\n");
			//Animation. Loop through palette textures.
			fprintf(fileOut, "\n\t{");
			fprintf(fileOut, "\n\tif ((time * 4) %% 4 == 0)");
			fprintf(fileOut, "\n\tblend GL_SRC_ALPHA, GL_ONE_MINUS_SRC_ALPHA\n");
			//fprintf(fileOut, "\n\tblend gl_dst_color, gl_src_color\n");
			//fprintf(fileOut, "\n\tblend none\n");
			fprintf(fileOut, "\n\tmap\ttextures\\shock\\shock_%04d_%04d.tga\n", i + 1000, 0);//Original frame
			fprintf(fileOut, "\t}");
//////shock_1000_PC01_0000
////			//Other frames. Texture file has palette cycle number in their name
			int MaxFrames =4;
			for (int k=1;k<=MaxFrames;k++)
				{
				fprintf(fileOut, "\n\t{");
				fprintf(fileOut, "\n\tif ((time * %d) %% %d == 0)",MaxFrames, k);
				fprintf(fileOut, "\n\tblend GL_SRC_ALPHA, GL_ONE_MINUS_SRC_ALPHA\n");
				//fprintf(fileOut, "\n\tblend gl_dst_color, gl_src_color\n");
				//fprintf(fileOut, "\n\tblend none\n");
				fprintf(fileOut, "\n\tmap\ttextures\\shock\\shock_%04d_pc%02d_%04d.tga\n", i + 1000, k, 0);
				fprintf(fileOut, "\t}");
				}
			fprintf(fileOut, "\n}");
			fclose(fileOut);
			}
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
			fprintf(fileOut, "\n}");
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
		{
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
		break;
		}
	case 4://Shaders for door animations
		{
		for (int i = 299; i <= 338; i++)
			{
			int NoOfFrames=-1; int ChunkId=-1;
			getNoOfFramesForShockDoors(i,&NoOfFrames,&ChunkId);
			if (NoOfFrames!=-1)
				{
				FILE *fileOut;
				char filePath[80] = "";
				sprintf_s(filePath, 80, "c:\\games\\darkmod\\materials\\shock_door_anim_%03d.mtr", i);
				if (fopen_s(&fileOut, filePath, "w") != 0)
					{
					printf("Unable to create output file for material");
					return;
					}
				fprintf(fileOut, "textures\\shock\\doors\\dooranim_%03d\n{\n", i);
				//fprintf(fileOut, "\tDECAL_MACRO\n\tnoShadows\n\ttwoSided\n\tnonsolid\n\tnoimpact\n");
				//fprintf(fileOut, "\tsort decal\n\tsort nearest\n");
				fprintf(fileOut, "\tqer_editorimage textures\\shock\\doors\\%04d\\%04d_0000.tga\n", ChunkId,ChunkId);
				fprintf(fileOut, "\t{\n\t\tblend GL_SRC_ALPHA, GL_ONE_MINUS_SRC_ALPHA\n\t\tcolored\n\talphatest 0.0\n");
				fprintf(fileOut, "\t\tmap textures\\shock\\doors\\%04d\\%04d_%04d.tga\n", ChunkId, ChunkId,NoOfFrames);
				fprintf(fileOut, "\n\t}");
				for (int k = 0; k <= NoOfFrames; k++)
					{
					fprintf(fileOut, "\n\t\t{");
					fprintf(fileOut, "\n\t\t\tif (parm8 == %d)",k);
					fprintf(fileOut, "\n\t\t\t\tblend GL_SRC_ALPHA, GL_ONE_MINUS_SRC_ALPHA");
					fprintf(fileOut, "\n\t\t\t\tcolored\n\t\t\talphatest 0.0");
					fprintf(fileOut, "\n\t\t\t\tmap textures\\shock\\doors\\%04d\\%04d_%04d.tga\n", ChunkId, ChunkId, k);
					fprintf(fileOut, "\n\t\t}");
					}
				fprintf(fileOut, "\n}");

				fclose(fileOut);
				}
			}

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

void BuildUWXData(int game, int TargetBlock)
{
	char filePath[255];
	switch (game)
	{
	case UWDEMO:
	case UW1:
		strcpy_s(filePath, UW1_STRINGS_FILE); break;
	case UW2:
		strcpy_s(filePath, UW2_STRINGS_FILE); break;
	}
	huffman_node *hman;
	block_dir *blocks;
	unsigned char *Buffer;
	long NoOfNodes; long NoOfStringBlocks;
	long address_pointer = 0;
	//char *str;

	FILE *file = NULL;      // File pointer
	//fopen_s(file,filePath, "rb");
	if (fopen_s(&file, filePath, "rb") != 0)
	{
		printf("Could not open specified file\n");
	}
	else
	{
		// Get the size of the file in bytes
		long fileSize = getFileSize(file);

		// Allocate space in the buffer for the whole file

		Buffer = new unsigned char[fileSize];
		fread(Buffer, fileSize, 1, file);
		fclose(file);
		NoOfNodes = getValAtAddress(Buffer, address_pointer, 16);
		int i = 0;
		hman = new huffman_node[NoOfNodes];
		address_pointer = address_pointer + 2;
		while (i<NoOfNodes)
		{
			hman[i].symbol = Buffer[address_pointer + 0];
			hman[i].parent = Buffer[address_pointer + 1];
			hman[i].left = Buffer[address_pointer + 2];
			hman[i].right = Buffer[address_pointer + 3];
			//printf("Node:%d parent=%d, left=%d, right=%d, symbol=%c\n", i, hman[i].parent, hman[i].left, hman[i].right, hman[i].symbol);
			i++;
			address_pointer = address_pointer + 4;
		}
		//next is the number of string blocks
		NoOfStringBlocks = getValAtAddress(Buffer, address_pointer, 16);
		blocks = new block_dir[NoOfStringBlocks];
		address_pointer = address_pointer + 2;
		i = 0;
		while (i<NoOfStringBlocks)
		{
			blocks[i].block_no = getValAtAddress(Buffer, address_pointer, 16);
			address_pointer = address_pointer + 2;
			blocks[i].address = getValAtAddress(Buffer, address_pointer, 32);
			address_pointer = address_pointer + 4;
			blocks[i].NoOfEntries = getValAtAddress(Buffer, blocks[i].address, 16);	//look ahead and get no of entries.

			i++;
		}
		i = 0;
		while (i<NoOfStringBlocks)
		{
			//printf("Block %d is at address %d. It has %d entries\n",blocks[i].block_no,blocks[i].address, blocks[i].NoOfEntries );
			address_pointer = 2 + blocks[i].address + blocks[i].NoOfEntries * 2;
			//printf("It's strings begin at %d\n", address_pointer);
			//printf("It should end at %d\n",blocks[i+1].address );
			//printf("\n+=====================================+\n");
			//printf("Block Name: %d\n", blocks[i].block_no);
			long strAdd;
			int blnFnd;
			strAdd = address_pointer;
			for (int j = 0; j< blocks[i].NoOfEntries; j++)
			{
				//Based on abysmal /uwadv implementations.
				blnFnd = 0;
				char c;

				int bit = 0;
				int raw = 0;
				int node = 0;
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
						node = raw & 0x80 ? short(hman[node].right)
							: short(hman[node].left);

						raw <<= 1;
						bit--;
					}

					// have a new symbol
					if ((hman[node].symbol != '|') && (hman[node].symbol != 10)){
						if (blnFnd == 0)
							//{printf("\nBlock %d String %d at %d:",blocks[i].block_no, j, strAdd);	}
							{
								//printf("\n%03d=",j);	
								if (TargetBlock == blocks[i].block_no)
									{
									if (j != 0)
										{
										printf("\"\n\t}");
										printf("\n\t\"gui_page1\"	: \"guis/readables/uw_transparent.gui\"");
										printf("\n\t\"snd_page_turn\" : \"readable_page_turn\"");
										printf("\n}");
										}
									
									printf("\n\nreadables/uw%d/sign_%03d",game,j);
									printf("\n{");
									printf("\n\tprecache");
									printf("\n\t\"num_pages\"	: \"1\"");
									printf("\n\t\"page1_title\" :");
									printf("\n\t\t{");
									printf("\n\t\t\"\"");
									printf("\n\t\t}");
									printf("\n\t\"page1_body\" :");
									printf("\n\t{");
									printf("\n\t\t\"");	//Start the string here.

									}
								//printf("\n%03d=%03d=", blocks[i].block_no, j);
							}
						if (TargetBlock == blocks[i].block_no)
							{
							if (hman[node].symbol == 34)
								{
								printf("%s", "'");
								}
							else
								{
								printf("%c", hman[node].symbol);
								}
								
							}
						blnFnd = 1;
					}
				} while (hman[node].symbol != '|');
			}
			i++;
		}
	}
}

void BuildParticles(int game)
{
int NoOfParticles=0;
switch (game)
	{
	case UW1:
		NoOfParticles = 460;
		break;
	case UW2:
		NoOfParticles = 464;
		break;
	case SHOCK:
		NoOfParticles =1706;
		break;
	default:
		return;
	}
for (int x = 0; x < NoOfParticles; x++)
	{
		FILE *fileOut;
		char filePath[80] = "";
		switch (game)
			{
			case UW1:
				sprintf_s(filePath, 80, "c:\\games\\darkmod\\particles\\uw1_object_%03d.prt", x);
				break;
			case UW2:
				sprintf_s(filePath, 80, "c:\\games\\darkmod\\particles\\uw2_object_%03d.prt", x);
				break;
			case SHOCK:
				sprintf_s(filePath, 80, "c:\\games\\darkmod\\particles\\shock_object_%04d.prt", x);
				break;
			}
		if (fopen_s(&fileOut, filePath, "w") != 0)
			{
			printf("Unable to create output file for material");
			return;
			}
	
		//fprintf(fileOut, "particle shock_object_%04d {\n", x);
		switch (game)
			{
			case UW1:
				fprintf(fileOut, "particle uw1_object_%03d {\n", x);
				break;
			case UW2:
				fprintf(fileOut, "particle uw2_object_%03d {\n", x);
				break;
			case SHOCK:
				fprintf(fileOut, "particle shock_object_%04d {\n", x);
				break;
			}
		
		fprintf(fileOut, "{\n");
		fprintf(fileOut, "count\t1\n");
		//
		switch (game)
			{
			case UW1:
				fprintf(fileOut, "material\ttextures/uw1/objects/objects_%03d\n", x);
				break;
			case UW2:
				fprintf(fileOut, "material\ttextures/uw2/objects/objects_%03d\n", x);
				break;
			case SHOCK:
				fprintf(fileOut, "material\ttextures/shock/objects/objects_%04d\n", x);
				break;
			}
		
		fprintf(fileOut, "time\t0.050\n");
		fprintf(fileOut, "cycles\t0.000\n");
		fprintf(fileOut, "bunching\t0.000\n");
		fprintf(fileOut, "distribution\trect 0.000 0.000 0.000\n");
		fprintf(fileOut, "direction\tcone \"0.000\"\n");
		fprintf(fileOut, "orientation\tview\n");
		fprintf(fileOut, "speed\t\"0.000\"\n");
		fprintf(fileOut, "size\t\"16.000\"\n");
		fprintf(fileOut, "aspect\t\"-1.000\"\n");
		fprintf(fileOut, "rotation\t\"-1.000\"\n");
		fprintf(fileOut, "angle\t180.000\n");
		fprintf(fileOut, "randomDistribution\t0\n");
		fprintf(fileOut, "boundsExpansion\t0.000\n");
		fprintf(fileOut, "fadeIn\t0.000\n");
		fprintf(fileOut, "fadeOut\t0.000\n");
		fprintf(fileOut, "fadeIndex\t0.000\n");
		fprintf(fileOut, "color\t1.000 1.000 1.000 1.000\n");
		fprintf(fileOut, "fadeColor\t0.000 0.000 0.000 0.000\n");
		fprintf(fileOut, "offset\t0.000 0.000 0.000\n");
		fprintf(fileOut, "gravity\t0.000\n");
		fprintf(fileOut, "}\n");
		fprintf(fileOut, "}\n");
		fclose(fileOut);
	}

for (int x = 0; x < NoOfParticles; x++)
	{
		FILE *fileOut;
		char filePath[80] = "";
		//sprintf_s(filePath, 80, "c:\\games\\darkmod\\materials\\shock_object_%04d.mtr", x);
		switch (game)
			{
				case UW1:
					sprintf_s(filePath, 80, "c:\\games\\darkmod\\materials\\uw1_object_%03d.mtr", x);
					break;
				case UW2:
					sprintf_s(filePath, 80, "c:\\games\\darkmod\\materials\\uw2_object_%03d.mtr", x);
					break;
				case SHOCK:
					sprintf_s(filePath, 80, "c:\\games\\darkmod\\materials\\shock_object_%04d.mtr", x);
					break;
			}
		
		if (fopen_s(&fileOut, filePath, "w") != 0)
			{
			printf("Unable to create output file for material");
			return;
			}
		switch (game)
			{
			case UW1:
				fprintf(fileOut, "textures\\uw1\\objects\\objects_%03d\n", x);
				break;
			case UW2:
				fprintf(fileOut, "textures\\uw2\\objects\\objects_%03d\n", x);
				break;
			case SHOCK:
				fprintf(fileOut, "textures\\shock\\objects\\objects_%04d\n", x);
				break;
			}
		
		fprintf(fileOut, "{\n");
		fprintf(fileOut,  "DECAL_MACRO\n");
		fprintf(fileOut, "noShadows\n");
		fprintf(fileOut, "twoSided\n");
		fprintf(fileOut, "nonsolid\n");
		fprintf(fileOut, "noimpact\n");
		fprintf(fileOut, "\tsort decal\n\tsort nearest\n");
		switch (game)
			{
			case UW1:
				fprintf(fileOut, "qer_editorimage textures/uw1/objects/objects_%03d.tga\n", x);
				break;
			case UW2:
				fprintf(fileOut, "qer_editorimage textures/uw2/objects/objects_%03d.tga\n", x);
				break;
			case SHOCK:
				fprintf(fileOut, "qer_editorimage textures/shock/objects/shock_object_1350_%04d.tga\n", x);
				break;
			}
	
		fprintf(fileOut, "{\n");
		fprintf(fileOut, "\tblend GL_SRC_ALPHA, GL_ONE_MINUS_SRC_ALPHA\n");
		fprintf(fileOut, "\tcolored\n");
		fprintf(fileOut, "\tclamp\n");
		//fprintf(fileOut, "\talphatest 0.0\n");
		//
		switch (game)
			{
			case UW1:
				fprintf(fileOut, "\tmap textures/uw1/objects/objects_%03d.tga\n", x);
				break;
			case UW2:
				fprintf(fileOut, "\tmap textures/uw2/objects/objects_%03d.tga\n", x);
				break;
			case SHOCK:
				fprintf(fileOut, " map textures/shock/objects/shock_object_1350_%04d.tga\n", x);
				break;
			}
		
		fprintf(fileOut, "}\n");
		fprintf(fileOut, "}\n");
		fclose(fileOut);
	}

}
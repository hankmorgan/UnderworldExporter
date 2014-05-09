#include <fstream>

#include "gamegraphics.h"
#include "utils.h"
#include "main.h"

void extractTextureBitmap(int ImageCount, char filePathIn[255], char PaletteFile[255], int PaletteNo, int BitmapSize, int FileType)
{
    //const char *filePathIn = GRAPHICS_FILE ; //"C:\\Games\\Ultima\\UW1\\DATA\\W64.tr"; 
//    int indexNo;
    //unsigned char *BigEndBuf;          // Pointer to our buffered data (big endian format)
	unsigned char *textureFile;          // Pointer to our buffered data (little endian format)
	int i;
	long NoOfTextures;

	FILE *file = NULL;      // File pointer
	
    if ((file = fopen(filePathIn, "rb")) == NULL)
       { printf("Could not open specified file\n"); return;}

    // Get the size of the file in bytes
    long fileSize = getFileSize(file);
    
	palette *pal;
	pal = new palette[256];
	getPalette(PaletteFile, pal, PaletteNo);    
 
    // Allocate space in the buffer for the whole file
    //BigEndBuf = new unsigned char[fileSize];
	textureFile = new unsigned char[fileSize];
    // Read the file in to the buffer
    fread(textureFile, fileSize, 1,file);
	fclose(file); 



	switch (FileType)
	{
		case UW_GRAPHICS_BITMAPS:	//BYT
		case UW_GRAPHICS_TEXTURES :	//.tr
			printf("File Type :%d\n",  textureFile[0]);
			printf("xy resolution:%d\n", textureFile[1]);
			printf("No of textures:%d\n", textureFile[3] << 8 | textureFile[2]);
			if (ImageCount == -1)	//All the images.
				{
				NoOfTextures = textureFile[3] << 8 | textureFile[2];
				}
			else
				{
				NoOfTextures = ImageCount;
				}
			for (i = 0; i <= NoOfTextures; i++)
				{
				long textureOffset = getValAtAddress(textureFile, (i * 4) + 4, 32);
				writeBMP(textureFile, textureOffset, BitmapSize, BitmapSize, i, pal);	//The numbers are the size of the bitmap. These change depending on what you extract (usually 32 or 64)
				}
			break;
		case UW_GRAPHICS_GR :	//.gr
		case UW_GRAPHICS_TR :
		case UW_GRAPHICS_CR :
		case UW_GRAPHICS_SR :
		case UW_GRAPHICS_AR :
			printf("File Type (should be %d):%d\n", FileType, textureFile[0]);
			printf("No of textures:%d\n", textureFile[2] << 8 | textureFile[1]);
			if (ImageCount == -1)	//All the images.
			{
				NoOfTextures = textureFile[2] << 8 | textureFile[1];
			}
			else
			{
				NoOfTextures = ImageCount;
			}
			for (i = 0; i < NoOfTextures; i++)
			{
				long textureOffset = getValAtAddress(textureFile, (i * 4) + 3, 32);
				int BitMapWidth = getValAtAddress(textureFile,textureOffset+1, 8);;
				int BitMapHeight = getValAtAddress(textureFile, textureOffset+2, 8);;
				switch (getValAtAddress(textureFile, textureOffset, 8))
					{
					case 0x4://8 bit uncompressed
						printf("8 bit uncompressed\n");
						textureOffset = textureOffset + 5;
						break;
					case 0x8://4 bit run-length
						printf("4 bit run-length\n");
						textureOffset = textureOffset + 5;
						break;
					case 0xA://4 bit uncompressed
						printf("4 bit uncompressed\n");
						textureOffset = textureOffset + 5;
						break;
					default:
						printf("Unknown file type\n");
						break;
					}
				writeBMP(textureFile, textureOffset, BitMapWidth, BitMapHeight, i, pal);	//The numbers are the size of the bitmap. These change depending on what you extract (usually 32 or 64)
			}
			break;
	}


	//NoOfTextures=0;
	//printf("Address of first block:%d\n",  (textureFile[7]<<16 | textureFile[6]<<32 | textureFile[5]<<8 | textureFile[4]));

 	
return;	         
}

void getPalette(char filePathPal[255], palette *pal, int paletteNo)
{
	FILE *filePal = NULL;
	unsigned char *palf;
	int j; int i;
	
	//const char *filePathPal = GRAPHICS_PAL_FILE	;	//"C:\\Games\\Ultima\\UW1\\DATA\\pals.dat"; 
	filePal = fopen(filePathPal,"rb");
	long fileSizePal = getFileSize(filePal);
	palf = new unsigned char[fileSizePal];
	fread(palf, fileSizePal, 1, filePal);
	fclose (filePal);
	i = 0;
	for (j = paletteNo*256; j < (paletteNo*256+256); j++) {
		pal[i].green = palf[j*3+0]<<1;
		pal[i].blue = palf[j*3+1]<<1;
		pal[i].red = palf[j*3+2]<<1;		
		pal[i].reserved = 0;
		i++;
	}			
return;
}


void writeBMP( unsigned char *bits, long Start, long SizeH, long SizeV, int index, palette *pal)
{
	BitMapHeader bmhead;
	BitMapInfoHeader bmihead;
	
	bmhead.bfType = 19778;
	bmhead.bfReserved1 = 0;
	bmhead.bfReserved2 = 0;
	bmhead.bfOffBits = 1078;
	bmihead.biSize = 40;
	bmihead.biPlanes = 1;
	bmihead.biBitCount = 8;
	bmihead.biCompression = 0;
	bmihead.biXPelsPerMeter = 0;
	bmihead.biYPelsPerMeter = 0;
	bmihead.biClrUsed = 0;
	bmihead.biClrImportant = 0;
	
	bmhead.bfOffBits = 1078; // Set up the .bmp header info
	bmihead.biBitCount = 8;
	bmihead.biClrUsed = 0;
	bmihead.biClrImportant = 0;
	

	//unsigned char *bits = unpackdat + substart + 28;
	bmihead.biWidth = SizeH;	//bm->width;
	bmihead.biHeight =SizeV;	// bm->height;
	int imwidth = SizeH;		//bmihead.biWidth;
	imwidth += (4-(imwidth%4));
	bmihead.biSizeImage = imwidth * bmihead.biHeight;
	bmhead.bfSize = bmihead.biSizeImage + 54;
	
	char outFile[80];//=("Texture_");
	//char fileNumber[4];

	/*sprintf(fileNumber,"%03d",index);
	strcat(outFile,fileNumber);
	strcat(outFile,".bmp");*/
	
	sprintf_s(outFile,80,"Door_%04d.bmp", index );
	//sprintf(outFile,sprintf(outFile, "-%d", index),".bmp");

	FILE *outf ;
	outf = fopen(outFile,"wb");
	
	fwrite(&bmhead.bfType,2,1,outf);
	fwrite(&bmhead.bfSize,4,1,outf);
	fwrite(&bmhead.bfReserved1,2,1,outf);
	fwrite(&bmhead.bfReserved2,2,1,outf);
	fwrite(&bmhead.bfOffBits,4,1,outf);
	fwrite(&bmihead,sizeof(BitMapInfoHeader),1,outf);
	fwrite(pal,256*4,1,outf);
	char ch = 0;
	for (int k = bmihead.biHeight-1; k >= 0; k--) {
		fwrite(Start+bits+(k*bmihead.biWidth),1,bmihead.biWidth,outf);
		if (bmihead.biWidth%4 != 0)
			for (int buf = 4; buf > bmihead.biWidth%4; buf--)
				fwrite(&ch,1,1,outf);
	}
	fclose(outf);	


}



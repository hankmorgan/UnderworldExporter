#ifndef gamegraphics_h
	#define gamegraphics_h
	#include "gamegraphics.h"
#endif
#ifndef utils_h
	#define utils_h
	#include "utils.h"
#endif
#include <fstream>

void extractTextureBitmap(int ImageCount, char filePathIn[255], char PaletteFile[255])
{
    //const char *filePathIn = GRAPHICS_FILE ; //"C:\\Games\\Ultima\\UW1\\DATA\\W64.tr"; 
//    int indexNo;
    //unsigned char *BigEndBuf;          // Pointer to our buffered data (big endian format)
	unsigned char *textureFile;          // Pointer to our buffered data (little endian format)
	int i;
	FILE *file = NULL;      // File pointer
	
    if ((file = fopen(filePathIn, "rb")) == NULL)
       { printf("Could not open specified file\n"); return;}

    // Get the size of the file in bytes
    long fileSize = getFileSize(file);
    
	palette *pal;
	pal = new palette[256];
	getPalette(PaletteFile, pal, 0);    
 
    // Allocate space in the buffer for the whole file
    //BigEndBuf = new unsigned char[fileSize];
	textureFile = new unsigned char[fileSize];
    // Read the file in to the buffer
    fread(textureFile, fileSize, 1,file);
	fclose(file); 

	//printf("Is always 2:%d\n", textureFile[0]);
	//printf("xy resolution:%d\n", textureFile[1]);		
	//printf("No of textures:%d\n", textureFile[3]<<8 | textureFile[2]);
	long NoOfTextures;
	if (ImageCount==-1)	//All the images.
		 {
		 NoOfTextures=textureFile[3]<<8 | textureFile[2];
		 }
	else
		{
		NoOfTextures=ImageCount;
		}
	//NoOfTextures=0;
	//printf("Address of first block:%d\n",  (textureFile[7]<<16 | textureFile[6]<<32 | textureFile[5]<<8 | textureFile[4]));

	for (i=0; i<=NoOfTextures;i++)
	{
	//long textureOffset = (textureFile[(i*4)+7]<<16 | textureFile[(i*4)+6]<<32 | textureFile[(i*4)+5]<<8 | textureFile[(i*4)+4]);
	long textureOffset = getValAtAddress(textureFile,(i*4)+4,32);
	//writeBMP(textureFile,textureOffset,32,32,i+211,pal);
	writeBMP(textureFile,textureOffset,64,64,i,pal);	//The numbers are the size of the bitmap. These change depending on what you extract (usually 32 or 64)
	}   	
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
	
	char outFile[20]=("Texture_");
	char fileNumber[4];

	sprintf(fileNumber,"%03d",index);
	strcat(outFile,fileNumber);
	strcat(outFile,".bmp");
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
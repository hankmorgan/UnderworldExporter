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
				int BitMapWidth = getValAtAddress(textureFile,textureOffset+1, 8);
				int BitMapHeight = getValAtAddress(textureFile, textureOffset+2, 8);
				int datalen;
				palette auxpal[16];
				int auxPalIndex;
				unsigned char *imgNibbles;
				unsigned char *outputImg;
				switch (getValAtAddress(textureFile, textureOffset, 8))
					{
					case 0x4://8 bit uncompressed
						printf("8 bit uncompressed\n");
						printf("Width = %d\n",getValAtAddress(textureFile, textureOffset + 1, 8));
						printf("Height = %d\n", getValAtAddress(textureFile, textureOffset + 2, 8));
						textureOffset = textureOffset + 5;
						writeBMP(textureFile, textureOffset, BitMapWidth, BitMapHeight, i, pal);	
						break;
					case 0x8://4 bit run-length
						printf("4 bit run-length\n");
						//printf("Width = %d\n", getValAtAddress(textureFile, textureOffset + 1, 8));
						//printf("Height = %d\n", getValAtAddress(textureFile, textureOffset + 2, 8));
						auxPalIndex = getValAtAddress(textureFile, textureOffset + 3, 8);
						//printf("Aux Pal = %d\n", auxPalIndex);
						//printf("Data length = %d\n", getValAtAddress(textureFile, textureOffset + 4, 16));
						datalen = getValAtAddress(textureFile,textureOffset+4,16);
						imgNibbles = new unsigned char[BitMapWidth*BitMapHeight*2];

						textureOffset = textureOffset + 6;	//Start of raw data.
						copyNibbles(textureFile, imgNibbles, datalen, textureOffset);
						LoadAuxilaryPal(auxpal, pal,auxPalIndex);
						outputImg = new unsigned char[BitMapWidth*BitMapHeight];
						DecodeRLEBitmap(imgNibbles,datalen,BitMapWidth,BitMapHeight,outputImg,auxpal,i);
						break;
					case 0xA://4 bit uncompressed
						printf("4 bit uncompressed\n");
						//printf("Width = %d\n", getValAtAddress(textureFile, textureOffset + 1, 8));
						//printf("Height = %d\n", getValAtAddress(textureFile, textureOffset + 2, 8));
						auxPalIndex = getValAtAddress(textureFile, textureOffset + 3, 8);
						//printf("Aux Pal = %d\n", auxPalIndex);
						//printf("Data length = %d\n", getValAtAddress(textureFile, textureOffset + 4, 16));
						datalen = getValAtAddress(textureFile, textureOffset + 4, 16);
						imgNibbles = new unsigned char[BitMapWidth*BitMapHeight * 2];

						textureOffset = textureOffset + 6;	//Start of raw data.
						copyNibbles(textureFile, imgNibbles, datalen, textureOffset);
						LoadAuxilaryPal(auxpal, pal, auxPalIndex);
						//outputImg = new unsigned char[BitMapWidth*BitMapHeight];
						writeBMP4(imgNibbles, 0, BitMapWidth, BitMapHeight, i, auxpal);
						break;
					default:
						printf("Unknown file type : %d\n", getValAtAddress(textureFile, textureOffset, 8));
						break;
					}
				
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
	
	char outFile[80];

	sprintf_s(outFile,80,"tmflat_%04d.bmp", index );

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

void LoadAuxilaryPal(palette auxpal[16], palette gamepal[256], int PalIndex)
{
	FILE *filePal = NULL;
	unsigned char *palf;
	//const char *filePathPal = GRAPHICS_PAL_FILE	;	//"C:\\Games\\Ultima\\UW1\\DATA\\pals.dat"; 
	filePal = fopen(AUXILARY_PAL_FILE, "rb");
	long fileSizePal = getFileSize(filePal);
	palf = new unsigned char[fileSizePal];
	fread(palf, fileSizePal, 1, filePal);
	fclose(filePal);

	for (int j = 0; j < 16; j++)
	{
		//auxpal[j]. = getValAtAddress(palf,PalIndex*0xf + j,8);
		int value = getValAtAddress(palf, PalIndex * 16 + j, 8);
		
		//auxpal[j].green = ((value) & 0xF) <<1;
		//auxpal[j].blue = ((value) >> 4 & 0xF) << 1;
		//auxpal[j].red = ((value) >> 8 & 0xF) << 1;
		//auxpal[j].reserved = 0;
		auxpal[j].green = gamepal[value].green;
		auxpal[j].blue = gamepal[value].blue;
		auxpal[j].red = gamepal[value].red;
		auxpal[j].reserved = gamepal[value].reserved;

		//printf("%d\n", auxpal[j]);
	}
	return;

}

void DecodeRLEBitmap(unsigned char *imageData, int datalen, int imageWidth, int imageHeight ,unsigned char *outputImg, palette auxpal[16], int index)
{
int state=0; 
int curr_pxl=0;
int count=0;
int repeatcount=0;
char nibble;

int add_ptr=0;

while ((curr_pxl<imageWidth*imageHeight) || (add_ptr<=datalen))
{
	switch (state)
	{
		case repeat_record_start:
			{
			count = getcount(imageData, &add_ptr,4);
			if (count == 1)
				{
				state = run_record;
				}
			else if (count == 2)
				{
				repeatcount = getcount(imageData, &add_ptr, 4)-1;
				state = repeat_record_start;
				}
			else
				{
				state = repeat_record;
				}
				break;
			}
		case repeat_record:
			{
				//printf("\nRepeatRecord\n");
				//printf("Count is %d\n",count);
				//get nibble for the palette;
				nibble = getNibble(imageData, &add_ptr);
				//for count times copy the palette data to the image at the output pointer
				if (imageWidth*imageHeight - curr_pxl < count)
					{
						count = imageWidth*imageHeight - curr_pxl;
					}
				for (int i = 0; i < count; i++)
					{
					//printf("%d=%d\n", curr_pxl, nibble);
					outputImg[curr_pxl++] = nibble;
					}
				if (repeatcount == 0 )
					{					
					state = run_record;
					}
				else
					{
					state = repeat_record_start;
					repeatcount--;
					}
				break;
			}


	case 2:	//runrecord
		{
		//printf("\nRunRecord\n");
		count = getcount(imageData, &add_ptr, 4);
		if (imageWidth*imageHeight - curr_pxl < count)
			{
				count = imageWidth*imageHeight - curr_pxl;
			}
		//printf("Count is %d\n", count);
			//for that count copy the data / pal as it is
			for (int i = 0; i < count; i++)
			{
				//get nibble for the palette;
				nibble = getNibble(imageData, &add_ptr);
				//printf("%d=%d\n", curr_pxl, nibble);
				outputImg[curr_pxl++] = nibble;
			}
			state = repeat_record_start;
			break;
		}
	}
}
writeBMP4(outputImg,0,imageWidth,imageHeight,index, auxpal);

}

int getcount(unsigned char *nibbles, int *addr_ptr , int size)
{
int n1;
int n2;
int n3;
int inc_ptr;
int count=0;

	n1 = getNibble(nibbles,addr_ptr);
	count = n1;

	if (count==0)
		{
		n1 = getNibble(nibbles, addr_ptr);
		n2 = getNibble(nibbles, addr_ptr);
		count = (n1 << size) | n2;
		}
	if (count == 0)
		{
		n1 = getNibble(nibbles, addr_ptr);
		n2 = getNibble(nibbles, addr_ptr);
		n3 = getNibble(nibbles, addr_ptr);
		count = (((n1 << size) | n2) << size) | n3;
		}
	return count;		
}

int getNibble(unsigned char *nibbles, int *addr_ptr)
{
	int n1 = nibbles[*addr_ptr];
	*addr_ptr = *addr_ptr + 1;
	return n1;
}

void copyNibbles(unsigned char *InputData, unsigned char *OutputData, int NoOfNibbles, int add_ptr)
{
//Split the data up into in's nibbles.
int i = 0;
	while (NoOfNibbles > 1)
	{
		OutputData[i] = (getValAtAddress(InputData, add_ptr, 8) >> 4) & 0x0F;		//High nibble
		OutputData[i + 1] = (getValAtAddress(InputData, add_ptr, 8)) & 0xf;	//Low nibble
		//printf("%d,%d\n", OutputData[i], OutputData[i+1]);
		i=i+2;
		add_ptr++;
		NoOfNibbles = NoOfNibbles-2;
	}
	if (NoOfNibbles == 1)
		{	//Odd nibble out.
		OutputData[i] = (getValAtAddress(InputData, add_ptr, 8) >> 4) & 0x0F;
		}
}

void writeBMP4(unsigned char *bits, long Start, long SizeH, long SizeV, int index, palette auxpal[16])
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
	bmihead.biHeight = SizeV;	// bm->height;
	int imwidth = SizeH;		//bmihead.biWidth;
	imwidth += (4 - (imwidth % 4));
	bmihead.biSizeImage = imwidth * bmihead.biHeight;
	bmhead.bfSize = bmihead.biSizeImage + 54;


	char outFile[80];

	sprintf_s(outFile, 80, "obj_%04d.bmp", index);

	FILE *outf;
	outf = fopen(outFile, "wb");

	fwrite(&bmhead.bfType, 2, 1, outf);
	fwrite(&bmhead.bfSize, 4, 1, outf);
	fwrite(&bmhead.bfReserved1, 2, 1, outf);
	fwrite(&bmhead.bfReserved2, 2, 1, outf);
	fwrite(&bmhead.bfOffBits, 4, 1, outf);
	fwrite(&bmihead, sizeof(BitMapInfoHeader), 1, outf);
	fwrite(auxpal, 256 * 4, 1, outf);
	char ch = 0;
	for (int k = bmihead.biHeight - 1; k >= 0; k--) {
		fwrite(Start + bits + (k*bmihead.biWidth), 1, bmihead.biWidth, outf);
		if (bmihead.biWidth % 4 != 0)
		for (int buf = 4; buf > bmihead.biWidth % 4; buf--)
			fwrite(&ch, 1, 1, outf);
	}

		//fwrite(bits,SizeH*SizeV,1,outf);

	
	fclose(outf);


}

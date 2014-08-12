#include <fstream>

#include "gamegraphics.h"
#include "utils.h"
#include "main.h"

//For use in the cutscene decoder.
typedef __int32 unsigned Uint32;
typedef __int16 unsigned Uint16;
typedef __int8 unsigned Uint8;

typedef __int32 signed Sint32;
typedef __int16 signed Sint16;
typedef __int8 signed Sint8;

typedef struct {
//Borrowed from Underworld Adventures for extracting cutscenes.
	Uint32 id;    /* 4 character ID == "LPF " */
	Uint16 maxLps;    /* max # largePages allowed. 256 FOR NOW.   */
	Uint16 nLps;    /* # largePages in this file. */
	Uint32 nRecords;  /* # records in this file.  65534 is current limit plus */
	/* one for last-to-first delta for looping the animation */
	Uint16 maxRecsPerLp;  /* # records permitted in an lp. 256 FOR NOW.   */
	Uint16 lpfTableOffset;  /* Absolute Seek position of lpfTable.  1280 FOR NOW.
							The lpf Table is an array of 256 large page structures
							that is used to facilitate finding records in an anim
							file without having to seek through all of the Large
							Pages to find which one a specific record lives in. */
	Uint32 contentType;  /* 4 character ID == "ANIM" */
	Uint16 width;    /* Width of screen in pixels. */
	Uint16 height;    /* Height of screen in pixels. */
	Uint8 variant;  /*   0==ANIM. */
	Uint8 version;  /*   0==frame rate is multiple of 18 cycles/sec.
					1==frame rate is multiple of 70 cycles/sec.  */
	Uint8 hasLastDelta;  /* 1==Last record is a delta from last-to-first frame. */
	Uint8 lastDeltaValid;  /* 0==The last-to-first delta (if present) hasn't been
						   updated to match the current first&last frames,  so it
						   should be ignored. */
	Uint8 pixelType;  /* 0==256 color. */
	Uint8 CompressionType;  /* 1==(RunSkipDump) Only one used FOR NOW. */
	Uint8 otherRecsPerFrm;  /* 0 FOR NOW. */
	Uint8 bitmaptype;  /*   1==320x200, 256-color.  Only one implemented so far. */
	Uint8 recordTypes[32];  /* Not yet implemented. */
	Uint32 nFrames;   /*   In case future version adds other records at end of
					  file, we still know how many actual frames.
					  NOTE: DOES include last-to-first delta when present. */
	Uint16 framesPerSecond;  /* Number of frames to play per second. */
	Uint16 pad2[29];  /* 58 bytes of filler to round up to 128 bytes total. */
	} lpfileheader;

/* this is the format of an large page structure 
Borrowed from Underworld adventures
*/
typedef struct {
	Uint16 baseRecord;  /* Number of first record in this large page. */
	Uint16 nRecords;  /* Number of records in lp.
					  bit 15 of "nRecords" == "has continuation from previous lp".
					  bit 14 of "nRecords" == "final record continues on next lp". */
	Uint16 nBytes;    /* Total number of bytes of contents, excluding header. */
	} lp_descriptor;

void myPlayRunSkipDump(Uint8 *srcP, Uint8 *dstP);

void extractUW2Bitmaps(char filePathIn[255],char PaletteFile[255],int PaletteNo,char OutFileName[255], int useTGA)
{
	unsigned char *textureFile;          // Pointer to our buffered data (little endian format)
	int i;
	long NoOfTextures;

	FILE *file = NULL;      // File pointer
	
    if ((file = fopen(filePathIn, "rb")) == NULL)
       { printf("Could not open specified file\n"); return;}

    // Get the size of the file in bytes
    long fileSize = getFileSize(file);
    textureFile = new unsigned char[fileSize];
    fread(textureFile, fileSize, 1,file);
	fclose(file); 
	palette *pal;
	pal = new palette[256];
	getPalette(PaletteFile, pal, PaletteNo);  
	NoOfTextures = getValAtAddress(textureFile,0,8);
	for (i = 0; i <NoOfTextures; i++)
		{
		long textureOffset = getValAtAddress(textureFile, (i * 4) + 6, 32);
		if (textureOffset !=0)
			{
			int compressionFlag=getValAtAddress(textureFile,((i * 4) + 6)+(NoOfTextures*4),32);
			int isCompressed =(compressionFlag>>1) & 0x01;
			if (isCompressed==1)	
				{
				int datalen;
				unsigned char *outputImg = unpackUW2(textureFile,textureOffset,&datalen);		
				if (useTGA == 1)
					{
					writeTGA(outputImg, 0, 320, 200, i, pal, OutFileName,0);
					}
				else
					{
					writeBMP(outputImg, 0, 320, 200, i, pal, OutFileName);
					}
				
				}
			else
				{
				if (useTGA == 1)
					{
					writeTGA(textureFile, textureOffset, 320, 200, i, pal, OutFileName,0);
					}
				else
					{
					writeBMP(textureFile, textureOffset, 320, 200, i, pal, OutFileName);
					}
				}
			}
		}	
}

void extractTextureBitmap(int ImageCount, char filePathIn[255], char PaletteFile[255], int PaletteNo, int BitmapSize, int FileType, char OutFileName[255],char auxPalPath[255],int useTGA)
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
			if (useTGA==1)
				{
				writeTGA(textureFile, 0, 320, 200, 0, pal,OutFileName,1);
				}
			else
				{
				writeBMP(textureFile, 0, 320, 200, 0, pal,OutFileName);
				}
			break;
		case UW_GRAPHICS_TEXTURES :	//.tr
			printf("File Type :%d\n",  textureFile[0]);
			printf("xy resolution:%d\n", textureFile[1]);
			printf("No of textures:%d\n", textureFile[3] << 8 | textureFile[2]);
			if (ImageCount == -1)	//All the images.
				{
				NoOfTextures = textureFile[3] << 8 | textureFile[2];
				NoOfTextures=256;//Count is wrong???
				}
			else
				{
				NoOfTextures = ImageCount;
				}
			for (i = 0; i <NoOfTextures; i++)
				{
				long textureOffset = getValAtAddress(textureFile, (i * 4) + 4, 32);
				if (useTGA==1)
					{
					writeTGA(textureFile, textureOffset, BitmapSize, BitmapSize, i, pal, OutFileName,0);
					}
				else
					{
					writeBMP(textureFile, textureOffset, BitmapSize, BitmapSize, i, pal, OutFileName);
					}
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
						if (useTGA==1)
							{
							writeTGA(textureFile, textureOffset, BitMapWidth, BitMapHeight, i, pal, OutFileName,1);
							}
						else
							{
							writeBMP(textureFile, textureOffset, BitMapWidth, BitMapHeight, i, pal, OutFileName);
							}
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
						LoadAuxilaryPal(auxPalPath, auxpal, pal,auxPalIndex);
						outputImg = new unsigned char[BitMapWidth*BitMapHeight];
//						DecodeRLEBitmap(imgNibbles, datalen, BitMapWidth, BitMapHeight, outputImg, auxpal, i, 4,OutFileName);
						DecodeRLEBitmap(imgNibbles, datalen, BitMapWidth, BitMapHeight, outputImg,4);
						if (useTGA==1)
							{
							writeTGA(outputImg, 0, BitMapWidth, BitMapHeight, i, auxpal, OutFileName,1);
							}
						else
							{
							writeBMP(outputImg, 0, BitMapWidth, BitMapHeight, i, auxpal, OutFileName);
							}
						
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
						LoadAuxilaryPal(auxPalPath, auxpal, pal, auxPalIndex);
						//outputImg = new unsigned char[BitMapWidth*BitMapHeight];
						if (useTGA==1)
							{
							writeTGA(imgNibbles, 0, BitMapWidth, BitMapHeight, i, auxpal, OutFileName,1);
							}
						else
							{
							writeBMP(imgNibbles, 0, BitMapWidth, BitMapHeight, i, auxpal, OutFileName);
							}
						
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
int palAddr = paletteNo * 256;
	for (j = 0; j < 256; j++) {
		pal[i].red = palf[palAddr + 0]<<2;//getValAtAddress(palf, palAddr + 0, 8);//palf[j * 3 + 2] << 2;
		pal[i].green = palf[palAddr + 1] << 2;//getValAtAddress(palf, palAddr +1, 8);//palf[j * 3 + 0] << 2;
		pal[i].blue = palf[palAddr + 2] << 2;//getValAtAddress(palf, palAddr + 2, 8);//palf[j * 3 + 1] << 2;
		pal[i].reserved = 0;
		palAddr = palAddr +3;
		i++;
	}

return;
}

void writeBMP(unsigned char *bits, long Start, long SizeH, long SizeV, int index, palette *pal, char OutFileName[255])
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
	
	char outFile[255];

	sprintf_s(outFile, 255, "%s_%04d.bmp", OutFileName, index);

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
	printf(".");
	fclose(outf);	


}

void LoadAuxilaryPal(char auxpalPath[255], palette auxpal[16], palette gamepal[256], int PalIndex)
{
	FILE *filePal = NULL;
	unsigned char *palf;
	//const char *filePathPal = GRAPHICS_PAL_FILE	;	//"C:\\Games\\Ultima\\UW1\\DATA\\pals.dat"; 
	filePal = fopen(auxpalPath, "rb");
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

void DecodeRLEBitmap(unsigned char *imageData, int datalen, int imageWidth, int imageHeight, unsigned char *outputImg , int BitSize)
//, palette *auxpal, int index, int BitSize, char OutFileName[255])
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
			count = getcount(imageData, &add_ptr,BitSize);
			if (count == 1)
				{
				state = run_record;
				}
			else if (count == 2)
				{
				repeatcount = getcount(imageData, &add_ptr, BitSize) - 1;
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
		count = getcount(imageData, &add_ptr, BitSize);
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

void copyNibbles5Bit(unsigned char *InputData, unsigned char *OutputData, int NoOfNibbles, int add_ptr)
{
int bit_ptr=0;
int bits_needed=5;
int bits_avail=7;
int mask[6];
int i=0;
mask[0] = 0x0;
mask[1] = 0x1;
mask[2] = 0x3;
mask[3] = 0x7;
mask[4] = 0xF;
mask[5] = 0x1F;
//mask[6] = 0x3F;
//mask[7] = 0xFF;
	while (NoOfNibbles > 0)
		{
		unsigned char buf;
		printf("\n**%d***\n", i);
		//read in my byte and take the needed bits from it
		if (bit_ptr<=2)
			{
			bits_avail=5;
			}
		else 
			{
			bits_avail = 8 - bit_ptr;
			}
		if (bits_avail == 0)
			{
			add_ptr++;
			bit_ptr=0;
			bits_avail=5;
			}
		printf("\nReading in %d bits @ %d",bits_avail,bit_ptr);
		buf = (InputData[add_ptr] >> (bit_ptr)) & mask[bits_avail];
		bit_ptr=bit_ptr+bits_avail;
		bits_needed= bits_needed-bits_avail;
	
		if (bits_needed > 0)
			{//I need more bits. Read in the next byte and take whats there.
			printf("\nI need %d bits", bits_needed);
				add_ptr++;
				bit_ptr = 0;
				printf("\nReading in %d bits @ %d", bits_needed, bit_ptr);
				buf = ((InputData[add_ptr] & mask[bits_needed])<<bits_needed) | buf;
				bit_ptr=bits_needed;
			}
		OutputData[i]=buf;
		i++;
		bits_needed=5;
		NoOfNibbles--;
		}
}

void extractPanels(int ImageCount, char filePathIn[255], char PaletteFile[255], int PaletteNo, int BitmapSize, int FileType, int game, char OutFileName[255], int useTGA)
{
	//const char *filePathIn = GRAPHICS_FILE ; //"C:\\Games\\Ultima\\UW1\\DATA\\W64.tr"; 
	//    int indexNo;
	//unsigned char *BigEndBuf;          // Pointer to our buffered data (big endian format)
	unsigned char *textureFile;          // Pointer to our buffered data (little endian format)
	int i;
	long NoOfTextures;

	FILE *file = NULL;      // File pointer

	if ((file = fopen(filePathIn, "rb")) == NULL)
	{
		printf("Could not open specified file\n"); return;
	}

	// Get the size of the file in bytes
	long fileSize = getFileSize(file);

	palette *pal;
	pal = new palette[256];
	getPalette(PaletteFile, pal, PaletteNo);

	// Allocate space in the buffer for the whole file
	//BigEndBuf = new unsigned char[fileSize];
	textureFile = new unsigned char[fileSize];
	// Read the file in to the buffer
	fread(textureFile, fileSize, 1, file);
	fclose(file);



	switch (FileType)
	{
	case UW_GRAPHICS_GR:	//.gr
	case UW_GRAPHICS_TR:
	case UW_GRAPHICS_CR:
	case UW_GRAPHICS_SR:
	case UW_GRAPHICS_AR:
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
		//NoOfTextures=1;
		for (i = 0; i < NoOfTextures; i++)
		{
			long textureOffset = getValAtAddress(textureFile, (i * 4) + 3, 32);
			int BitMapWidth = 83;  //getValAtAddress(textureFile, textureOffset + 1, 8);
			int BitMapHeight = 114; // getValAtAddress(textureFile, textureOffset + 2, 8);
			if (game == UW2)
				{
				BitMapWidth=79;
				BitMapHeight = 112;
				}
			int datalen;
			palette auxpal[16];
			int auxPalIndex;
			unsigned char *imgNibbles;
			unsigned char *outputImg;
			//switch (getValAtAddress(textureFile, textureOffset, 8))
			//{
			//default://8 bit uncompressed
				printf("8 bit uncompressed\n");
				printf("Width = %d\n", getValAtAddress(textureFile, textureOffset + 1, 8));
				printf("Height = %d\n", getValAtAddress(textureFile, textureOffset + 2, 8));
				//textureOffset = 1;//textureOffset + 1;
				writeBMP(textureFile, textureOffset, BitMapWidth, BitMapHeight, i, pal, OutFileName);
				//break;
			//}
		}
		break;
	}


	//NoOfTextures=0;
	//printf("Address of first block:%d\n",  (textureFile[7]<<16 | textureFile[6]<<32 | textureFile[5]<<8 | textureFile[4]));


	return;
}

void extractCritters(char fileAssoc[255], char fileCrit[255], char PaletteFile[255], int PaletteNo, int BitmapSize, int FileType, int game, int CritterNo, char OutFileName[255], int useTGA)
{
	palette *pal;
	unsigned char auxpalval[32];
	pal = new palette[256];
	getPalette(PaletteFile, pal, 0);//always palette 0?

	palette auxpal[32];
	long fileSize;
	unsigned char *assocFile;
	unsigned char *critterFile;
	int auxPalNo=PaletteNo;
	int anim;
	int AddressPointer;
	FILE *file = NULL;      // File pointer
	if ((file = fopen(fileAssoc, "rb")) == NULL)
	{
		printf("\nArchive not found!\n");
		return;
	}
	fileSize = getFileSize(file);
	assocFile = new unsigned char[fileSize];
	fread(assocFile, fileSize, 1, file);
	fclose(file);
	//AddressPointer= CritterNo *8;
	if (game !=UW2)
		{
		for (int i = 0; i < 8; i++)
			{
			printf("%c", assocFile[(CritterNo * 8) + i]);
			}
		anim = getValAtAddress(assocFile, (32 * 8) + (CritterNo * 2) + 0, 8);
		int DefaultauxPalNo = getValAtAddress(assocFile,(32 * 8) + (CritterNo*2)+1,8);
		printf("\nAnim is %d, AuxPal is %d", anim, DefaultauxPalNo);
		}
	else
		{
		anim = getValAtAddress(assocFile, (CritterNo * 2) + 0, 8);
		int DefaultauxPalNo = getValAtAddress(assocFile, (CritterNo * 2) + 1, 8);
		printf("\nAnim is %d, AuxPal is %d", anim, DefaultauxPalNo);
		}
	if ((file = fopen(fileCrit, "rb")) == NULL)
	{
		printf("\nArchive not found!\n");
		return;
	}
	fileSize = getFileSize(file);
	critterFile = new unsigned char[fileSize];
	fread(critterFile, fileSize, 1, file);
	fclose(file);
	if (game !=UW2)
			{
			printf("\nSlot base %d\n", getValAtAddress(critterFile, 0, 8));
			int NoOfSlots = getValAtAddress(critterFile,1,8);
			printf("No of Slots %d\n", NoOfSlots);
			for (int i = 0; i < NoOfSlots; i++)
			{
				printf("\nIndex %d = %d",i,getValAtAddress(critterFile,2+i,8));
			}
			int NoOfSegs = getValAtAddress(critterFile, 2 + NoOfSlots, 8);
			printf("\nNo of anim segments=%d", getValAtAddress(critterFile, 2 + NoOfSlots, 8));
			for (int i = 0; i < NoOfSegs*8; i++)
				{
				printf("\n%d = %d", i, getValAtAddress(critterFile,1+2+NoOfSlots+i,8));
				AddressPointer = 1 + 2 + NoOfSlots + i;
				}
			AddressPointer++;
			int NoOfPals = getValAtAddress(critterFile, AddressPointer, 8);
			AddressPointer++;
			printf("\nNo of Palettes %d",NoOfPals);
			//AddressPointer = AddressPointer + auxPalNo*32;
			//if (auxPalNo==0)
			//	{
			//	auxPalNo=0;//?
			//	}
			for (int i = 0; i < 32; i++)
				{
				int value = getValAtAddress(critterFile,(AddressPointer)+(auxPalNo*32)+i,8);
				auxpalval[i]=value;
				auxpal[i].green = pal[value].green;
				auxpal[i].blue = pal[value].blue;
				auxpal[i].red = pal[value].red;
				auxpal[i].reserved = pal[value].reserved;
				}
	
			AddressPointer=AddressPointer+NoOfPals*32;
			int NoOfFrames = getValAtAddress(critterFile,AddressPointer,8);
			printf("\nNo of Frames %d", NoOfFrames);
			printf("\nCompression Type %d", getValAtAddress(critterFile, AddressPointer+1, 8));
			AddressPointer=AddressPointer+2;
			for (int i = 0; i < NoOfFrames; i++)
				{
				int frameOffset = getValAtAddress(critterFile, AddressPointer + (i * 2), 16);
				printf("\n%d @ %d", i, frameOffset);
				int BitMapWidth = getValAtAddress(critterFile, frameOffset + 0, 8);
				int BitMapHeight = getValAtAddress(critterFile, frameOffset + 1, 8);
				int hotspotx = getValAtAddress(critterFile, frameOffset + 2, 8);
				int hotspoty = getValAtAddress(critterFile, frameOffset + 3, 8);
				int compression = getValAtAddress(critterFile, frameOffset + 4, 8);
				int datalen = getValAtAddress(critterFile, frameOffset + 5, 16);
				//unsigned char *imgNibbles;
				unsigned char *outputImg;
				//imgNibbles = new unsigned char[BitMapWidth*BitMapHeight * 2];
				//copyNibbles5Bit(critterFile, imgNibbles, datalen, frameOffset+7);
				//copyNibbles(critterFile, imgNibbles, datalen, frameOffset + 7);
				outputImg = new unsigned char[BitMapWidth*BitMapHeight];
				ua_image_decode_rle(critterFile, outputImg, compression == 6 ? 5 : 4, datalen, BitMapWidth*BitMapHeight, frameOffset + 7, auxpalval);
				if (useTGA==1)
					{
					writeTGA(outputImg, 0, BitMapWidth, BitMapHeight, i, pal, OutFileName,1);	
					}
				else
					{
					writeBMP(outputImg, 0, BitMapWidth, BitMapHeight, i, pal, OutFileName);	
					}
				
				//DecodeRLEBitmap(imgNibbles, datalen, BitMapWidth, BitMapHeight, outputImg, auxpal, i,4);
				}
			}
	else
		{//UW2 uses a different method
		//Starting at offset 0x80
		
		//auxPalNo=2;
		AddressPointer=auxPalNo*32;
		int i=0;
		for (int i = 0; i < 32; i++)
			{
			int value = getValAtAddress(critterFile, (AddressPointer), 8);
			auxpalval[i] = value;
			auxpal[i].green = pal[value].green;
			auxpal[i].blue = pal[value].blue;
			auxpal[i].red = pal[value].red;
			auxpal[i].reserved = pal[value].reserved;
			AddressPointer++;
			}
		for (int index = 128; index < 640; index=index+2)
			{
			int frameOffset = getValAtAddress(critterFile, index, 16);
			if (frameOffset != 0)
				{
				printf("\n%d @ %d", i, frameOffset);
				int BitMapWidth = getValAtAddress(critterFile, frameOffset + 0, 8);
				int BitMapHeight = getValAtAddress(critterFile, frameOffset + 1, 8);
				int hotspotx = getValAtAddress(critterFile, frameOffset + 2, 8);
				int hotspoty = getValAtAddress(critterFile, frameOffset + 3, 8);
				int compression = getValAtAddress(critterFile, frameOffset + 4, 8);
				int datalen = getValAtAddress(critterFile, frameOffset + 5, 16);
				unsigned char *outputImg;
				outputImg = new unsigned char[BitMapWidth*BitMapHeight];
				ua_image_decode_rle(critterFile, outputImg, compression == 6 ? 5 : 4, datalen, BitMapWidth*BitMapHeight, frameOffset + 7, auxpalval);
				if (useTGA==1)
					{
					writeTGA(outputImg, 0, BitMapWidth, BitMapHeight, i, pal, OutFileName,1);
					}
				else
					{
					writeBMP(outputImg, 0, BitMapWidth, BitMapHeight, i, pal, OutFileName);
					}
				
				i++;
				}
			}

		}

}


void ua_image_decode_rle(unsigned char *FileIn, unsigned char *pixels, unsigned int bits, unsigned int datalen, unsigned int maxpix, int addr_ptr,unsigned char *auxpal)
{
	//Code lifted from Underworld adventures.
	// bit extraction variables
	unsigned int bits_avail = 0;
	unsigned int rawbits = 0;
	unsigned int bitmask = ((1 << bits) - 1) << (8 - bits);
	unsigned int nibble;

	// rle decoding vars
	unsigned int pixcount = 0;
	unsigned int stage = 0; // we start in stage 0
	unsigned int count = 0;
	unsigned int record = 0; // we start with record 0=repeat (3=run)
	unsigned int repeatcount = 0;

	while (datalen>0 && pixcount<maxpix)
	{
		// get new bits
		if (bits_avail<bits)
		{
			// not enough bits available
			if (bits_avail>0)
			{
				nibble = ((rawbits & bitmask) >> (8 - bits_avail));
				nibble <<= (bits - bits_avail);
			}
			else
				nibble = 0;

			//rawbits = (unsigned int)fgetc(fd);
			rawbits = (unsigned int)getValAtAddress(FileIn,addr_ptr,8);
			addr_ptr++;
			if ((int)rawbits == EOF)
				return;

			//         printf("fgetc: %02x\n",rawbits);

			unsigned int shiftval = 8 - (bits - bits_avail);

			nibble |= (rawbits >> shiftval);

			rawbits = (rawbits << (8 - shiftval)) & 0xFF;

			bits_avail = shiftval;
		}
		else
		{
			// we still have enough bits
			nibble = (rawbits & bitmask) >> (8 - bits);
			bits_avail -= bits;
			rawbits <<= bits;
		}

		//      printf("nibble: %02x\n",nibble);

		// now that we have a nibble
		datalen--;

		switch (stage)
		{
		case 0: // we retrieve a new count
			if (nibble == 0)
				stage++;
			else
			{
				count = nibble;
				stage = 6;
			}
			break;
		case 1:
			count = nibble;
			stage++;
			break;

		case 2:
			count = (count << 4) | nibble;
			if (count == 0)
				stage++;
			else
				stage = 6;
			break;

		case 3:
		case 4:
		case 5:
			count = (count << 4) | nibble;
			stage++;
			break;
		}

		if (stage<6) continue;

		switch (record)
		{
		case 0:
			// repeat record stage 1
			//         printf("repeat: new count: %x\n",count);

			if (count == 1)
			{
				record = 3; // skip this record; a run follows
				break;
			}

			if (count == 2)
			{
				record = 2; // multiple run records
				break;
			}

			record = 1; // read next nibble; it's the color to repeat
			continue;

		case 1:
			// repeat record stage 2

		{
				  // repeat 'nibble' color 'count' times
				  for (unsigned int n = 0; n<count; n++)
				  {
					  pixels[pixcount++] = auxpal[nibble];
					  if (pixcount >= maxpix)
						  break;
				  }
		}

			//         printf("repeat: wrote %x times a '%x'\n",count,nibble);

			if (repeatcount == 0)
			{
				record = 3; // next one is a run record
			}
			else
			{
				repeatcount--;
				record = 0; // continue with repeat records
			}
			break;

		case 2:
			// multiple repeat stage

			// 'count' specifies the number of repeat record to appear
			//         printf("multiple repeat: %u\n",count);
			repeatcount = count - 1;
			record = 0;
			break;

		case 3:
			// run record stage 1
			// copy 'count' nibbles

			//         printf("run: count: %x\n",count);

			record = 4; // retrieve next nibble
			continue;

		case 4:
			// run record stage 2

			// now we have a nibble to write
			pixels[pixcount++] = auxpal[nibble];

			if (--count == 0)
			{
				//            printf("run: finished\n");
				record = 0; // next one is a repeat again
			}
			else
				continue;
			break;
		}

		stage = 0;
		// end of while loop
	}
}



bool load_cuts_anim(char filePathIn[255], char filePathOut[255],int useTGA)
	{
//This is lifted wholesale from the Underworld Adventures implementation 
	lpfileheader lpheader;
	lp_descriptor lparray[256];
	Uint8 *outbuffer;
	Uint8 *pages;
	int curlpnum = -1; // current large page
	lp_descriptor *curlp; // current large page
	Uint8 *thepage; // current page
 
	palette pal[256];
	FILE *fd = NULL;      // File pointer
	
	fopen_s(&fd, filePathIn, "rb");
	if (fd == NULL)
		{
		printf("Unable to open file!");
		return 0;
		}

	// find out file length
	fseek(fd, 0, SEEK_END);
	long filesize = ftell(fd);
	fseek(fd, 0, SEEK_SET);
	printf("Reading in cutscene header\n");
	// read in anim file header
	fread(&lpheader, sizeof(lpfileheader), 1, fd);

	// skip color cycling structures
	fseek(fd, 128, SEEK_CUR);
	printf("Reading in cutscene palette\n");
	// read in color palette
	for (int i = 0; i<256; i++)
		{
		//Palette order is different here.
		pal[i].blue = fgetc(fd);
		pal[i].green = fgetc(fd);
		pal[i].red = fgetc(fd);
		pal[i].reserved = fgetc(fd);
		//palette[i][2] = fgetc(fd); // red
		//palette[i][1] = fgetc(fd); // green
		//palette[i][0] = fgetc(fd); // blue

		// extra pad byte
		//fgetc(fd);
		}

	// read in large page descriptors
	printf("Reading in cutscene page descriptors\n");
	fread(lparray, sizeof(lp_descriptor), 256, fd);

	// the file pointer now points to the first large page structure

	// load remaining pages into memory
	filesize -= ftell(fd);
	pages = new Uint8[filesize];
	fread(pages, filesize, 1, fd);
	printf("All pages read into memory\n");
	fclose(fd);

	// alloc memory for the outbuffer
	outbuffer = new Uint8[lpheader.width*lpheader.height + 1000];
	for (int framenumber = 0; framenumber < lpheader.nFrames; framenumber++)
		{
		
		//draw_screen();
		int i = 0;
		for (; i<lpheader.nLps; i++)
		if (lparray[i].baseRecord <= framenumber && lparray[i].baseRecord + lparray[i].nRecords > framenumber)
			break;

		// calculate large page descriptor pointer and large page pointer
		curlp = reinterpret_cast<lp_descriptor*>(pages + 0x10000 * i);
		thepage = reinterpret_cast<Uint8*>(curlp)+sizeof(lp_descriptor)+2;
		// page length: curlp.nBytes+(curlp.nRecords*2)
		int destframe = framenumber - curlp->baseRecord;

		Uint16 offset = 0;
		Uint16 *pagepointer = (Uint16*)thepage;
		for (Uint16 i = 0; i < destframe; i++)
			offset += pagepointer[i];

		Uint8 *ppointer = thepage + curlp->nRecords * 2 + offset;

		Uint16 *ppointer16 = (Uint16*)(ppointer);

		if (ppointer[1])
			ppointer += (4 + (ppointer16[1] + (ppointer16[1] & 1)));
		else
			ppointer += 4;

		// extract data to the output buffer
		//   CPlayRunSkipDump(ppointer, outbuffer);
		printf("Decoding frame %d of %d\n", framenumber, lpheader.nFrames);
		myPlayRunSkipDump(ppointer, outbuffer);
		printf("Writing frame %d of %d to file\n", framenumber, lpheader.nFrames);
		if (useTGA==1)
			{
			writeTGA(outbuffer, 0, lpheader.width, lpheader.height, framenumber,pal,filePathOut,0);//No alpha on cutscenes.
			}
		else
			{
			writeBMP(outbuffer, 0, lpheader.width, lpheader.height, framenumber,pal,filePathOut);
			}
		}

	printf("Cutscene decoded\n");
	return true;
	}

void myPlayRunSkipDump(Uint8 *srcP, Uint8 *dstP)
	{//From an implemtation by Underworld Adventures (hacking tools)
	while (true)
		{
		Sint8 cnt = (Sint8)*srcP++;

		if (cnt>0)
			{
			// dump
			while (cnt>0)
				{
				*dstP++ = *srcP++;
				cnt--;
				}
			}
		else if (cnt == 0)
			{
			// run
			Uint8 wordCnt = *srcP++;
			Uint8 pixel = *srcP++;
			while (wordCnt>0)
				{
				*dstP++ = pixel;
				wordCnt--;
				}
			}
		else
			{
			cnt &= 0x7f; // cnt -= 0x80;
			if (cnt != 0)
				{
				// shortSkip
				dstP += cnt;
				}
			else
				{
				// longOp
				Uint16 wordCnt = *((Uint16*)srcP);
				srcP += 2;

				if ((Sint16)wordCnt <= 0)
					{
					// notLongSkip
					if (wordCnt == 0)
						{
						break; // end loop
						}

					wordCnt &= 0x7fff; // wordCnt -= 0x8000; // Remove sign bit.
					if (wordCnt >= 0x4000)
						{
						// longRun
						wordCnt -= 0x4000; // Clear "longRun" bit
						Uint8 pixel = *srcP++;
						while (wordCnt>0)
							{
							*dstP++ = pixel;
							wordCnt--;
							}
						//                  dstP += wordCnt;
						}
					else
						{
						// longDump
						while (wordCnt>0)
							{
							*dstP++ = *srcP++;
							wordCnt--;
							}

						//                  dstP += wordCnt;
						//                  srcP += wordCnt;
						}
					}
				else
					{
					// longSkip
					dstP += wordCnt;
					}
				}
			}
		}
	}


void writeTGA(unsigned char *bits, long Start, long SizeH, long SizeV, int index, palette *pal, char OutFileName[255], int Alpha)
	{
	FILE *fptr;
	char outFile[255];

	sprintf_s(outFile, 255, "%s_%04d.tga", OutFileName, index);

	/* Write the result as a uncompressed TGA */
	if ((fptr = fopen(outFile, "w")) == NULL) {
		fprintf(stderr, "Failed to open outputfile\n");
		exit(-1);
		}
	putc(0, fptr);
	putc(0, fptr);
	putc(2, fptr);                         /* uncompressed RGB */
	putc(0, fptr); putc(0, fptr);
	putc(0, fptr); putc(0, fptr);
	putc(0, fptr);
	putc(0, fptr); putc(0, fptr);           /* X origin */
	putc(0, fptr); putc(0, fptr);           /* y origin */
	putc((SizeH & 0x00FF), fptr);
	putc((SizeH & 0xFF00) / 256, fptr);
	putc((SizeV & 0x00FF), fptr);
	putc((SizeV & 0xFF00) / 256, fptr);
	putc(32, fptr);                        /* 32 bit bitmap */
	putc(8, fptr);

	for (int iRow = SizeV - 1; iRow >= 0; iRow--)
		{
		for (int j = (iRow *SizeH); j <(iRow*SizeH) + SizeH; j++)
			{
			int pixel = getValAtAddress(bits, Start + j, 8);
			putc(pal[pixel].blue, fptr);
			putc(pal[pixel].green, fptr);
			putc(pal[pixel].red, fptr);
			if (Alpha == 1)
				{
				if (pixel != 0)	//Alpha
					{
					fputc(255, fptr);
					}
				else
					{
					fputc(0, fptr);
					}
				}
			else
				{
				fputc(255, fptr);//No alpha
				}
			}
		}


	fclose(fptr);


	}


void ExtractShockGraphics(char GraphicsFile[255], char PaletteFile[255], int PaletteChunk,  char OutFileName[255], int useTGA)
{
	palette *pal;
	pal = new palette[256];
	
	unsigned char *art_ark;
	unsigned char *tmp_ark;
	int isCutscene=0;
	FILE *file = NULL;      // File pointer
	if ((file = fopen(GraphicsFile, "rb")) == NULL)
		{
		printf("\nGraphics file not found!\n");
		return;
		}
	long fileSize = getFileSize(file);
	tmp_ark = new unsigned char[fileSize];
	fread(tmp_ark, fileSize, 1,file);
	fclose(file);	
//for (int p=0; p<20;p++)
//{
//if (LoadShockPal(pal,PaletteFile,PaletteChunk)==1)
//	{
	long DirectoryAddress=getValAtAddress(tmp_ark,124,32);//Get the list of chunks in this archive.
	int NoOfChunks = getValAtAddress(tmp_ark,DirectoryAddress,16);
	long address_pointer=DirectoryAddress+6;
	for (int k=0; k< NoOfChunks; k++)
		{
		int chunkId = getValAtAddress(tmp_ark,address_pointer,16);
		short chunkContentType = getValAtAddress(tmp_ark,address_pointer+9,8);
		address_pointer=address_pointer+10;	//next chunk
		switch (chunkId)
			{//ss_xtract. However the fuck he got them!
			case 0x001e:
				isCutscene = 1;
				PaletteChunk = 0;
				break;
			case 0x001f:
			case 0x0020:
				isCutscene = 1;
				PaletteChunk = 1;
				break;
			case 0x01a9:
				isCutscene=1;
				PaletteChunk=2;
				break;
			case 0x01aa:
				isCutscene = 1;
				PaletteChunk=3;
				break;
			case 0x01ab:
				isCutscene = 1;
				PaletteChunk=4;
				break;
			case 0x01ac:
				isCutscene = 1;
				PaletteChunk=5;
				break;
			case 0x01ad:
			case 0x01ae:
				isCutscene = 1;
				PaletteChunk=6;
				break;
			case 0x01af:
			case 0x01b0:
				isCutscene = 1;
				PaletteChunk=7;
				break;
			case 0x01b1:
			case 0x01b2:
			case 0x01b3:
				isCutscene = 1;
				PaletteChunk=8;
				break;
			case 0x01b4:
				isCutscene = 1;
				PaletteChunk=9;
				break;	
			case 0x01b5:	
				isCutscene = 1;
				PaletteChunk=10;
				break;
			case 0x01b7:	
			case 0x01b8:		
				isCutscene = 1;
				PaletteChunk=11;
				break;
			case 0x01b9:
				isCutscene = 1;
				PaletteChunk=12;
				break;	
			case 0x01ba:
				isCutscene = 1;
				PaletteChunk=13;
				break;	
			case 0x01bb:		
				isCutscene = 1;
				PaletteChunk=14;
				break;	
			default:
				break;
			}
		if (LoadShockPal(pal,PaletteFile,PaletteChunk)==1)
			{

		
		if ((chunkContentType==2) || (chunkContentType==17))	//Bitmap and sometimes audio log
			{//load this chunk and extract
				char NewOutFileName[255];
				sprintf_s(NewOutFileName, 255, "%s_%04d", OutFileName, chunkId);
				long chunkUnpackedLength;
				long chunkType;//compression type
				long chunkPackedLength;
				int blockAddress =getShockBlockAddress(chunkId,tmp_ark,&chunkPackedLength,&chunkUnpackedLength,&chunkType); 
				if (blockAddress != -1)
					{
					printf("\nChunk %d, type %d", chunkId, chunkType);
					art_ark=new unsigned char[chunkUnpackedLength];
					LoadShockChunk(blockAddress, chunkType, tmp_ark, art_ark,chunkPackedLength,chunkUnpackedLength);
					
					//Read in my chunk header
					int NoOfTextures=getValAtAddress(art_ark,0,16);
					
					//printf("No of texture subblocks %d\n",NoOfTextures);
					//printf("Offset to first subblock %d\n",getValAtAddress(art_ark,2,32));
			
					for (int i =0; i<NoOfTextures; i++)
						{
						long textureOffset = getValAtAddress(art_ark,2+(i*4),32);
						WriteShockBitmaps(art_ark,pal,i,textureOffset, NewOutFileName,useTGA,isCutscene);
						}
					}
				else
					{
					printf("Graphics chunk %d not found in %s\n", chunkId,GraphicsFile);
					}
			}
		}	
	}
//}//endof
}

int LoadShockPal(palette *pal, char PaletteFile[255], int PaletteNo)
	{
	//Loads a system shock palette.
	unsigned char *pal_ark;
	unsigned char *tmp_ark;
	int chunkId=-1;
	long chunkUnpackedLength;
	long chunkType;//compression type
	long chunkPackedLength;
	FILE *file = NULL;      // File pointer
	if ((file = fopen(PaletteFile, "rb")) == NULL)
		{
		printf("\nPalette file not found!\n");
		return -1;
		}
	long fileSize = getFileSize(file);
	tmp_ark = new unsigned char[fileSize];
	fread(tmp_ark, fileSize, 1,file);
	fclose(file);	
	int MatchesFound=-1;
	long DirectoryAddress=getValAtAddress(tmp_ark,124,32);//Get the list of chunks in this archive.
	int NoOfChunks = getValAtAddress(tmp_ark,DirectoryAddress,16);
	long address_pointer=DirectoryAddress+6;
	for (int k=0; k< NoOfChunks; k++)
		{
		
		short chunkContentType = getValAtAddress(tmp_ark,address_pointer+9,8);
		
		
		if ((chunkContentType==0))	//Gamepal
			{
			MatchesFound++;
			chunkId = getValAtAddress(tmp_ark,address_pointer,16);//If I can find a match I'll just use the last one I found.
			if (MatchesFound==PaletteNo)
				{
				k=NoOfChunks+1;//break my loop.
				}
			}
		address_pointer=address_pointer+10;	//next chunk
		}
	
	if (chunkId==-1)
		{
		return -1;
		}
	
	
	int blockAddress =getShockBlockAddress(chunkId,tmp_ark,&chunkPackedLength,&chunkUnpackedLength,&chunkType); 
	if (blockAddress != -1)
		{
		pal_ark=new unsigned char[chunkUnpackedLength];
		LoadShockChunk(blockAddress, chunkType, tmp_ark, pal_ark,chunkPackedLength,chunkUnpackedLength);
		int i=0;
		int palAddr=0;
		for (int j = 0; j < 256; j++) {
			pal[i].red = pal_ark[palAddr + 0];//<<2;
			pal[i].green = pal_ark[palAddr + 1];// << 2;
			pal[i].blue = pal_ark[palAddr + 2];// << 2;
			pal[i].reserved = 0;
			palAddr = palAddr +3;
			i++;
			}
			return 1;
		}
	else
		{
		printf("Palette %d not found in %c", PaletteNo,PaletteFile);
		return-1;
		}
	return -1;
	}

// This one is also almost directly from Jim Cameron's code.
void UncompressBitmap(unsigned char *chunk_bits, unsigned char *bits, int numbits) {
	int i,xc;
	unsigned char *bits_end;

	bits_end = bits + numbits;

	memset(bits,0,numbits);

	while (bits < bits_end)
	{
		xc = *chunk_bits++;
		if (xc == 0)
		{
			xc = *chunk_bits++;
			for (i = 0; i < xc && bits < bits_end; ++i)
			{
				*bits++ = *chunk_bits;
			}
			++chunk_bits;
		}
		else if (xc < 0x81)
		{
			if (xc == 0x80)
			{
				xc = *chunk_bits++;
				if (xc == 0)
				{
					break;
				}
				if (*chunk_bits < 0x80)
				{
					bits += xc + (*chunk_bits << 8);
					xc = 0;
				}
				/*  	  xc = *chunk_bits++; */
				++chunk_bits;
			}
			for (i = 0; i < xc && bits < bits_end; ++i)
			{
				*bits++ = *chunk_bits++;
			}
		}
		else
		{
			bits += (xc & 0x7f);
		}
	}

}


void WriteShockBitmaps(unsigned char *art_ark, palette *pal,int index, int textureOffset, char OutFileName[255], int useTGA,int isCutscene)
{
//Process a system shock bitmap chunk
int BitMapHeaderSize=28;
int CompressionType;
int Width;
int Height;

		//First 28 bytes are header info.
		//printf("\nAlways 0=%d",getValAtAddress(art_ark,textureOffset+0,32));
		CompressionType=getValAtAddress(art_ark,textureOffset+4,16);
		//printf("\nType=%d",CompressionType);
		Width=getValAtAddress(art_ark,textureOffset+8,16);
		//printf("\nWidth=%d",Width);
		Height=getValAtAddress(art_ark,textureOffset+10,16);
		//Height=150;//?cutscenes???
		if (isCutscene == 1)
			{
			Width=320;
			Height=150;
			}
////printf("\nBitmap header\n");
////printf("Always %d = %d\n",0, getValAtAddress(art_ark,textureOffset+0,32));
////printf("Type %d = %d\n",0x4, getValAtAddress(art_ark,textureOffset+0x4,16));
////printf("??? %d = %d\n",0x6, getValAtAddress(art_ark,textureOffset+0x6,16));
////printf("Width %d = %d\n",0x8, getValAtAddress(art_ark,textureOffset+0x8,16));
////printf("Heigth %d = %d\n",0xA, getValAtAddress(art_ark,textureOffset+0xA,16));
////printf("Width in bytes %d = %d\n",0xC, getValAtAddress(art_ark,textureOffset+0xC,16));
////printf("log2width %d = %d\n",0xE, getValAtAddress(art_ark,textureOffset+0xE,8));
////printf("log2height %d = %d\n",0xF, getValAtAddress(art_ark,textureOffset+0xF,8));
////printf("%d = %d\n",0x10, getValAtAddress(art_ark,textureOffset+0x10,16));
////printf("%d = %d\n",0x12, getValAtAddress(art_ark,textureOffset+0x12,16));
////printf("%d = %d\n",0x14, getValAtAddress(art_ark,textureOffset+0x14,16));
////printf("%d = %d\n",0x16, getValAtAddress(art_ark,textureOffset+0x16,16));
////printf("??? %d = %d\n",0x18, getValAtAddress(art_ark,textureOffset+0x18,32));
		
		
		//printf("\nHeight=%d",Height);		
	if ((Width>0) && (Height >0))
		{
		//printf("\nAt 6 =%d",getValAtAddress(art_ark,textureOffset+6,16));
		//printf("\nAt E =%d",getValAtAddress(art_ark,textureOffset+0xE,8));
		//printf("\nAt F =%d",getValAtAddress(art_ark,textureOffset+0xF,8));
		//printf("\nAt 18 =%d",getValAtAddress(art_ark,textureOffset+0x18,32));
		if(CompressionType==4)
			{//compressed
			//printf("Compressed bmp\n");
			unsigned char *outputImg;
			outputImg = new unsigned char[Width*Height];
			UncompressBitmap(art_ark+textureOffset+BitMapHeaderSize, outputImg,Height*Width);
			if (useTGA==1)
				{
				writeTGA(outputImg,0,Width,Height,index,pal,OutFileName,1);
				}
			else
				{
				writeBMP(outputImg,0,Width,Height,index,pal,OutFileName);
				}
			}
		else
			{
			if (useTGA==1)
				{
				writeTGA(art_ark,textureOffset+BitMapHeaderSize,Width,Height,index,pal,OutFileName,1);
				}
			else
				{
				writeBMP(art_ark,textureOffset+BitMapHeaderSize,Width,Height,index,pal,OutFileName);
				}
			}			
		}
	}


void ExtractShockCutscenes(char GraphicsFile[255], char PaletteFile[255], int PaletteChunk,  char OutFileName[255], int useTGA)
{
PaletteChunk=2;
	palette *pal;
	pal = new palette[256];
	
	unsigned char *art_ark;
	unsigned char *tmp_ark;

	FILE *file = NULL;      // File pointer
	if ((file = fopen(GraphicsFile, "rb")) == NULL)
		{
		printf("\nGraphics file not found!\n");
		return;
		}
	long fileSize = getFileSize(file);
	tmp_ark = new unsigned char[fileSize];
	fread(tmp_ark, fileSize, 1,file);
	fclose(file);	
//for (int p=0; p<20;p++)
//{

	long DirectoryAddress=getValAtAddress(tmp_ark,124,32);//Get the list of chunks in this archive.
	int NoOfChunks = getValAtAddress(tmp_ark,DirectoryAddress,16);
	long address_pointer=DirectoryAddress+6;
	for (int k=0; k< NoOfChunks; k++)
		{
		int chunkId = getValAtAddress(tmp_ark,address_pointer,16);
		short chunkContentType = getValAtAddress(tmp_ark,address_pointer+9,8);
		address_pointer=address_pointer+10;	//next chunk
		switch (chunkId)
			{//ss_xtract. However the fuck he got them!
			case 0x001E:
				PaletteChunk=0;
					break;
			case 0x001F:
			case 0x0020:
				PaletteChunk = 1;
				break;
			case 0x01a9:
				PaletteChunk=2;
				break;
			case 0x01aa:
				PaletteChunk=3;
				break;
			case 0x01ab:
				PaletteChunk=4;
				break;
			case 0x01ac:
				PaletteChunk=5;
				break;
			case 0x01ad:
			case 0x01ae:
				PaletteChunk=6;
				break;
			case 0x01af:
			case 0x01b0:
				PaletteChunk=7;
				break;
			case 0x01b1:
			case 0x01b2:
			case 0x01b3:
				PaletteChunk=8;
				break;
			case 0x01b4:
				PaletteChunk=9;
				break;	
			case 0x01b5:		
				PaletteChunk=10;
				break;
			case 0x01b7:	
			case 0x01b8:			
				PaletteChunk=11;
				break;
			case 0x01b9:
				PaletteChunk=12;
				break;	
			case 0x01ba:
				PaletteChunk=13;
				break;	
			case 0x01bb:						
				PaletteChunk=14;
				break;	
			default:
				break;
			}
		if (LoadShockPal(pal,PaletteFile,PaletteChunk)==1)
			{
			if ((chunkContentType==2) || (chunkContentType==17))	//Bitmap and sometimes audio log
				{//load this chunk and extract
					char NewOutFileName[255];
					sprintf_s(NewOutFileName, 255, "%s_%04d", OutFileName, chunkId);
					long chunkUnpackedLength;
					long chunkType;//compression type
					long chunkPackedLength;
					int blockAddress =getShockBlockAddress(chunkId,tmp_ark,&chunkPackedLength,&chunkUnpackedLength,&chunkType); 
					if (blockAddress != -1)
						{
						printf("\nChunk %d, type %d", chunkId, chunkType);
						art_ark=new unsigned char[chunkUnpackedLength];
						LoadShockChunk(blockAddress, chunkType, tmp_ark, art_ark,chunkPackedLength,chunkUnpackedLength);
						
						//Read in my chunk header
						int NoOfTextures=getValAtAddress(art_ark,0,16);
						
						//printf("No of texture subblocks %d\n",NoOfTextures);
						//printf("Offset to first subblock %d\n",getValAtAddress(art_ark,2,32));
						unsigned char *keyframe=new unsigned char[320*150];
						for (int i =0; i<NoOfTextures; i++)
							{
							long textureOffset = getValAtAddress(art_ark,2+(i*4),32);
							WriteShockCutsceneBitmaps(keyframe,art_ark,pal,i,textureOffset, NewOutFileName,useTGA);
							}
						}
					else
						{
						printf("Graphics chunk %d not found in %s\n", chunkId,GraphicsFile);
						}
				}
		}
	}	
//}//endof
}



void WriteShockCutsceneBitmaps(unsigned char KeyFrame[48000], unsigned char *art_ark, palette *pal,int index, int textureOffset, char OutFileName[255], int useTGA)
{
//Process a system shock bitmap chunk
int BitMapHeaderSize=28;
int CompressionType;
int Width;
int Height;

		//First 28 bytes are header info.
		//printf("\nAlways 0=%d",getValAtAddress(art_ark,textureOffset+0,32));
		CompressionType=getValAtAddress(art_ark,textureOffset+4,16);
		//printf("\nType=%d",CompressionType);
		Width=getValAtAddress(art_ark,textureOffset+8,16);
		//printf("\nWidth=%d",Width);
		Height=getValAtAddress(art_ark,textureOffset+10,16);
		Height=150;//?cutscenes???
		
		
		
		//printf("\nHeight=%d",Height);		
	if ((Width>0) && (Height >0))
		{
		//printf("\nAt 6 =%d",getValAtAddress(art_ark,textureOffset+6,16));
		//printf("\nAt E =%d",getValAtAddress(art_ark,textureOffset+0xE,8));
		//printf("\nAt F =%d",getValAtAddress(art_ark,textureOffset+0xF,8));
		//printf("\nAt 18 =%d",getValAtAddress(art_ark,textureOffset+0x18,32));
		if(CompressionType==4)
			{//compressed
			//printf("Compressed bmp\n");
			unsigned char *outputImg;
			outputImg = new unsigned char[Width*Height];
			if (index==0)
				{//Keyframe
				//KeyFrame = new unsigned char[Width*Height];
				UncompressBitmap(art_ark+textureOffset+BitMapHeaderSize, KeyFrame,Height*Width);
				//copy keyframe to outputimg
				for (int z=0;z<Height*Width;z++)
					{
					outputImg[z]=KeyFrame[z];
					}
				}
			else
				{
				UncompressBitmap(art_ark+textureOffset+BitMapHeaderSize, outputImg,Height*Width);
				//ApplyKeyFrame(KeyFrame,outputImg,Height*Width);
				for (int z=0;z<Height*Width;z++)
					{
					if (getValAtAddress(outputImg,z,8)==0)
						{
						outputImg[z]=KeyFrame[z];
						//outputImg[z]=KeyFrame[z]^outputImg[z];
						}
					}
				}
			if (useTGA==1)
				{
				writeTGA(outputImg,0,Width,Height,index,pal,OutFileName,0);//Doesn't appear to work properly?
				}
			else
				{
				writeBMP(outputImg,0,Width,Height,index,pal,OutFileName);
				}
			////copy output img to key frame.
			//	for (int z=0;z<Height*Width;z++)
			//		{
			//		KeyFrame[z]=outputImg[z];
			//		}
			}
		else
			{
			if (useTGA==1)
				{
				writeTGA(art_ark,textureOffset+BitMapHeaderSize,Width,Height,index,pal,OutFileName,1);
				}
			else
				{
				writeBMP(art_ark,textureOffset+BitMapHeaderSize,Width,Height,index,pal,OutFileName);
				}
			}			
		}
	}
//	
//void ApplyKeyFrame(unsigned char *keyframe,unsigned char *output,int BitMapSize)
//{
////Merge animation frames into the key frame.
//for (int i=0;i<BitMapSize;i++)
//	{
//	if (output[i]==0)
//		{
//		output[i]=keyframe[i];
//		}
//	}
//}
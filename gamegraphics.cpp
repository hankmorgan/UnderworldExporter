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
			for (i = 0; i <NoOfTextures; i++)
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
						DecodeRLEBitmap(imgNibbles,datalen,BitMapWidth,BitMapHeight,outputImg,auxpal,i,4);
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
						writeBMP(imgNibbles, 0, BitMapWidth, BitMapHeight, i, auxpal);
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

	sprintf_s(outFile,80,"OBJECTS_%03d.bmp", index );

	FILE *outf ;
	outf = fopen(outFile,"wb");
	
	fwrite(&bmhead.bfType,2,1,outf);
	fwrite(&bmhead.bfSize,4,1,outf);
	fwrite(&bmhead.bfReserved1,2,1,outf);
	fwrite(&bmhead.bfReserved2,2,1,outf);
	fwrite(&bmhead.bfOffBits,4,1,outf);
	fwrite(&bmihead,sizeof(BitMapInfoHeader),1,outf);
	fwrite(pal,256*4,1,outf);
	//for (int z = 0; z<256; z++)
	//{
	//	fwrite(&pal[z].red, 1, 1, outf);
	//	fwrite(&pal[z].green , 1, 1, outf);
	//	fwrite(&pal[z].blue , 1, 1, outf);
	//	fwrite(&pal[z].reserved, 1, 1, outf);
	//}
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

void DecodeRLEBitmap(unsigned char *imageData, int datalen, int imageWidth, int imageHeight ,unsigned char *outputImg, palette *auxpal, int index,int BitSize)
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
writeBMP(outputImg,0,imageWidth,imageHeight,index, auxpal);

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

//void writeBMP4(unsigned char *bits, long Start, long SizeH, long SizeV, int index, palette auxpal[16])
//{
//	BitMapHeader bmhead;
//	BitMapInfoHeader bmihead;
//
//	bmhead.bfType = 19778;
//	bmhead.bfReserved1 = 0;
//	bmhead.bfReserved2 = 0;
//	bmhead.bfOffBits = 1078;
//	bmihead.biSize = 40;
//	bmihead.biPlanes = 1;
//	bmihead.biBitCount = 8;
//	bmihead.biCompression = 0;
//	bmihead.biXPelsPerMeter = 0;
//	bmihead.biYPelsPerMeter = 0;
//	bmihead.biClrUsed = 0;
//	bmihead.biClrImportant = 0;
//
//	bmhead.bfOffBits = 1078; // Set up the .bmp header info
//	bmihead.biBitCount = 8;
//	bmihead.biClrUsed = 0;
//	bmihead.biClrImportant = 0;
//
//
//	//unsigned char *bits = unpackdat + substart + 28;
//	bmihead.biWidth = SizeH;	//bm->width;
//	bmihead.biHeight = SizeV;	// bm->height;
//	int imwidth = SizeH;		//bmihead.biWidth;
//	imwidth += (4 - (imwidth % 4));
//	bmihead.biSizeImage = imwidth * bmihead.biHeight;
//	bmhead.bfSize = bmihead.biSizeImage + 54;
//
//
//	char outFile[80];
//
//	sprintf_s(outFile, 80, "obj_%04d.bmp", index);
//
//	FILE *outf;
//	outf = fopen(outFile, "wb");
//
//	fwrite(&bmhead.bfType, 2, 1, outf);
//	fwrite(&bmhead.bfSize, 4, 1, outf);
//	fwrite(&bmhead.bfReserved1, 2, 1, outf);
//	fwrite(&bmhead.bfReserved2, 2, 1, outf);
//	fwrite(&bmhead.bfOffBits, 4, 1, outf);
//	fwrite(&bmihead, sizeof(BitMapInfoHeader), 1, outf);
//	fwrite(auxpal, 256 * 4, 1, outf);
//	char ch = 0;
//	for (int k = bmihead.biHeight - 1; k >= 0; k--) {
//		fwrite(Start + bits + (k*bmihead.biWidth), 1, bmihead.biWidth, outf);
//		if (bmihead.biWidth % 4 != 0)
//		for (int buf = 4; buf > bmihead.biWidth % 4; buf--)
//			fwrite(&ch, 1, 1, outf);
//	}
//
//		//fwrite(bits,SizeH*SizeV,1,outf);
//
//	
//	fclose(outf);
//
//
//}


void extractPanels(int ImageCount, char filePathIn[255], char PaletteFile[255], int PaletteNo, int BitmapSize, int FileType, int game)
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
				writeBMP(textureFile, textureOffset, BitMapWidth, BitMapHeight, i, pal);
				//break;
			//}
		}
		break;
	}


	//NoOfTextures=0;
	//printf("Address of first block:%d\n",  (textureFile[7]<<16 | textureFile[6]<<32 | textureFile[5]<<8 | textureFile[4]));


	return;
}

void extractCritters(char filePathIn[255], char PaletteFile[255], int PaletteNo, int BitmapSize, int FileType, int game, int CritterNo)
{
	palette *pal;
	unsigned char auxpalval[32];
	pal = new palette[256];
	getPalette(PaletteFile, pal, PaletteNo);

	palette auxpal[32];
	long fileSize;
	unsigned char *assocFile;
	unsigned char *critterFile;
	int auxPalNo;
	int anim;
	int AddressPointer;
	FILE *file = NULL;      // File pointer
	if ((file = fopen(UW1_CRITTER_ASSOC, "rb")) == NULL)
	{
		printf("\nArchive not found!\n");
		return;
	}
	fileSize = getFileSize(file);
	assocFile = new unsigned char[fileSize];
	fread(assocFile, fileSize, 1, file);
	fclose(file);
	//AddressPointer= CritterNo *8;
	for (int i = 0; i < 8; i++)
		{
		printf("%c", assocFile[(CritterNo * 8) + i]);
		}
	anim = getValAtAddress(assocFile, (32 * 8) + (CritterNo * 2) + 0, 8);
	auxPalNo = getValAtAddress(assocFile,(32 * 8) + (CritterNo*2)+1,8);
	printf("\nAnim is %d, AuxPal is %d", anim,auxPalNo);
	//LoadAuxilaryPal(auxpal,pal,auxPalNo);

	//*file = NULL;      // File pointer
	if ((file = fopen(UW1_CRITTER_FILE, "rb")) == NULL)
	{
		printf("\nArchive not found!\n");
		return;
	}
	fileSize = getFileSize(file);
	critterFile = new unsigned char[fileSize];
	fread(critterFile, fileSize, 1, file);
	fclose(file);
	printf("Slot base %d\n",getValAtAddress(critterFile,0,8));
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
	if (auxPalNo==0)
		{
		auxPalNo=1;
		}
	for (int i = 0; i < 32; i++)
		{
		int value = getValAtAddress(critterFile,(AddressPointer)+(auxPalNo*i),8);
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
		printf("\n%d @ %d", i , frameOffset);
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
		writeBMP(outputImg, 0, BitMapWidth, BitMapHeight, i, pal);
		//DecodeRLEBitmap(imgNibbles, datalen, BitMapWidth, BitMapHeight, outputImg, auxpal, i,4);
	}
}




























void ua_image_decode_rle(unsigned char *FileIn, unsigned char *pixels, unsigned int bits,
	unsigned int datalen, unsigned int maxpix, int addr_ptr,unsigned char *auxpal)
{
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

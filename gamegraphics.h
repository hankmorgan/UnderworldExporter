#ifndef gamegraphics_h
	#define gamegraphics_h


#define repeat_record_start 0
#define repeat_record 1
#define run_record 2


struct palette
{
	unsigned char blue;
	unsigned char green;
	unsigned char red;
	unsigned char reserved;
};

struct BitMapHeader { 
  unsigned short int    bfType; 
  unsigned int   bfSize; 
  unsigned short int    bfReserved1; 
  unsigned short int    bfReserved2; 
  unsigned int   bfOffBits; 
};

struct BitMapInfoHeader{
  unsigned int  biSize; 
  int  biWidth; 
  int  biHeight; 
  unsigned short int   biPlanes; 
  unsigned short int   biBitCount; 
  unsigned int  biCompression; 
  unsigned int  biSizeImage; 
  int  biXPelsPerMeter; 
  int  biYPelsPerMeter; 
  unsigned int  biClrUsed; 
  unsigned int  biClrImportant; 
} ;


void extractTextureBitmap(int ImageCount, char filePathIn[255], char PaletteFile[255], int PaletteNo, int BitmapSize, int FileType, char OutFileName[255], char auxPalPath[255]);
void extractPanels(int ImageCount, char filePathIn[255], char PaletteFile[255], int PaletteNo, int BitmapSize, int FileType, int game, char OutFileName[255]);
void extractCritters(char fileAssoc[255], char fileCrit[255], char PaletteFile[255], int PaletteNo, int BitmapSize, int FileType, int game, int CritterNo, char OutFileName[255]);
void writeBMP(unsigned char *buffer, long Start, long SizeH, long SizeV, int index, palette *pal, char OutFileName[255]);
void getPalette(char filePathPal[255], palette *pal, int paletteNo);
void LoadAuxilaryPal(char auxpalPath[255], palette auxpal[16], palette gamepal[256], int PalIndex);
void copyNibbles(unsigned char *InputData, unsigned char  *OutputData, int NoOfNibbles, int add_ptr);
int getcount(unsigned char *nibbles, int *addr_ptr, int size);
void DecodeRLEBitmap(unsigned char *imageData, int datalen, int imageWidth, int imageHeight, unsigned char *outputImg, palette *auxpal, int index, int BitSize, char OutFileName[255]);
void writeBMP4(unsigned char *bits, long Start, long SizeH, long SizeV, int index, palette auxpal[16], char OutFileName[255]);
int getNibble(unsigned char *nibbles, int *addr_ptr);

bool load_cuts_anim(char filePathIn[255], char filePathOut[255]);

void ua_image_decode_rle(unsigned char *FileIn, unsigned char *pixels, unsigned int bits, unsigned int datalen, unsigned int maxpix, int addr_ptr, unsigned char *auxpal);

#endif /*gamegraphics_h*/
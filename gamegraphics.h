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

void extractTextureBitmap(int ImageCount, char filePathIn[255], char PaletteFile[255], int PaletteNo, int BitmapSize, int FileType, char OutFileName[255],char auxPalPath[255],int useTGA);
void extractPanels(int ImageCount, char filePathIn[255], char PaletteFile[255], int PaletteNo, int BitmapSize, int FileType, int game, char OutFileName[255], int useTGA);
void extractCrittersUW1(char fileAssoc[255], char fileCrit[255], char PaletteFile[255], int PaletteNo, int BitmapSize, int FileType, int game, int CritterNo, char OutFileName[255], int useTGA, int SkipFileOutput, int ItemId, int fileXX, int fileYY);
void extractCrittersUW2(char fileAssoc[255], char fileCrit[255], char PaletteFile[255], int PaletteNo, int BitmapSize, int FileType, int game, int CritterNo, char OutFileName[255], int useTGA, int SkipFileOutput);
void writeBMP(unsigned char *buffer, long Start, long SizeH, long SizeV, int index, palette *pal, char OutFileName[255]);
void writeTGA(unsigned char *bits, long Start, long SizeH, long SizeV, int index, palette *pal, char OutFileName[255], int Alpha);
void getPalette(char filePathPal[255], palette *pal, int paletteNo);
void LoadAuxilaryPal(char auxpalPath[255], palette auxpal[16], palette gamepal[256], int PalIndex);
void copyNibbles(unsigned char *InputData, unsigned char  *OutputData, int NoOfNibbles, int add_ptr);
int getcount(unsigned char *nibbles, int *addr_ptr, int size);
//void DecodeRLEBitmap(unsigned char *imageData, int datalen, int imageWidth, int imageHeight, unsigned char *outputImg, palette *auxpal, int index, int BitSize, char OutFileName[255]);
void DecodeRLEBitmap(unsigned char *imageData, int datalen, int imageWidth, int imageHeight, unsigned char *outputImg , int BitSize);
//void writeBMP4(unsigned char *bits, long Start, long SizeH, long SizeV, int index, palette auxpal[16], char OutFileName[255]);
int getNibble(unsigned char *nibbles, int *addr_ptr);

bool load_cuts_anim(char filePathIn[255], char filePathOut[255],int useTGA);

void ua_image_decode_rle(unsigned char *FileIn, unsigned char *pixels, unsigned int bits, unsigned int datalen, unsigned int maxpix, int addr_ptr, unsigned char *auxpal);
void extractUW2Bitmaps(char filePathIn[255],char PaletteFile[255],int PaletteNo,char OutFileName[255], int useTGA);


void ExtractShockGraphics(char GraphicsFile[255], char PaletteFile[255], int PaletteChunk,  char OutFileName[255], int useTGA);
void ExtractShockCutscenes(char GraphicsFile[255], char PaletteFile[255], int PaletteChunk,  char OutFileName[255], int useTGA);
int LoadShockPal(palette *pal, char PaletteFile[255], int PaletteNo);
void UncompressBitmap(unsigned char *chunk_bits, unsigned char *bits, int numbits);
//void WriteShockBitmaps(unsigned char *art_ark, palette *pal,int index, int textureOffset, char OutFileName[255], int useTGA);
void WriteShockBitmaps(unsigned char *art_ark, palette *pal, int index, int textureOffset, char OutFileName[255], int useTGA, int isCutscene);
void WriteShockCutsceneBitmaps(unsigned char *KeyFrame, unsigned char *art_ark, palette *pal,int index, int textureOffset, char OutFileName[255], int useTGA);
//void ApplyKeyFrame(unsigned char *keyframe,unsigned char *output,int BitMapSize);
void cyclePalette(palette *pal, int Start, int length);
void copyPalette(palette *inPal, palette *outPal);

void extractAllCrittersUW1(char fileAssoc[255], char CritPath[255], char PaletteFile[255], int game, int useTGA);
void extractAllCrittersUW2(char fileAssoc[255], char CritPath[255], char PaletteFile[255], int game, int useTGA);
void PrintAnimName(int game, int animNo);
void PrintCritAngle(int angle);
#endif /*gamegraphics_h*/
#ifndef gamegraphics_h
	#define gamegraphics_h
	
typedef struct palette
{
unsigned char red;
unsigned char green;
unsigned char blue;
unsigned char reserved;
}palette;


typedef struct { 
  unsigned short int    bfType; 
  unsigned int   bfSize; 
  unsigned short int    bfReserved1; 
  unsigned short int    bfReserved2; 
  unsigned int   bfOffBits; 
} BitMapHeader;

typedef struct {
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
} BitMapInfoHeader;




void extractTextureBitmap(int ImageCount, char filePathIn[255], char PaletteFile[255]);
void writeBMP( unsigned char *buffer, long Start, long SizeH, long SizeV, int index, palette *pal);
void getPalette(char filePathPal[255], palette *pal, int paletteNo);

#endif /*gamegraphics_h*/
#ifndef gameobjects_h
	#define gameobjects_h
	#include "gameobjects.h"
#endif
#ifndef gamestrings_h
	#define gamestrings_h
	#include "gamestrings.h"
#endif
#ifndef tilemap_h
	#define tilemap_h
	#include "tilemap.h"
#endif
#ifndef utils_h
	#define utils_h
	#include "utils.h"
#endif
#ifndef tilemap_h
	#define tilemap_h
	#include "tilemap.h"
#endif
#ifndef textures_h
	#define textures_h
	#include "textures.h"
#endif
#ifndef main_h
	#define main_h
	#include "main.h"
#endif	
#ifndef gamegraphics_h
	#define gamegraphics_h
	#include "gamegraphics.h"
#endif

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




void extractTextureBitmap(int indexNo);
void writeBMP( unsigned char *buffer, long Start, long SizeH, long SizeV, int index, palette *pal);
void getPalette(palette *pal, int paletteNo);
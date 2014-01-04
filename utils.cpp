#include <fstream>
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
#ifndef gameobjects_h
	#define gameobjects_h
	#include "gameobjects.h"
#endif
#ifndef main_h
	#define main_h
	#include "main.h"
#endif	

long getFileSize(FILE *file)
{
    long lCurPos, lEndPos;
    lCurPos = ftell(file);
    fseek(file, 0, 2);
    lEndPos = ftell(file);
    fseek(file, lCurPos, 0);
    return lEndPos;
}

long ConvertInt16(unsigned char Byte1, unsigned char Byte2)
{
//return Byte1 << 8 | Byte2 ;
return Byte2 << 8 | Byte1 ;
}

long ConvertInt24(unsigned char Byte1, unsigned char Byte2,  unsigned char Byte3)
{
return Byte3 << 16 | Byte2 << 8 | Byte1 ;
}

long ConvertInt32(unsigned char Byte1, unsigned char Byte2,  unsigned char Byte3,  unsigned char Byte4)
{
return Byte4 << 32 | Byte3 << 16 | Byte2 << 8 | Byte1 ;
}

int getValAtAddress(unsigned char *buffer, long Address, int size)
	{//Gets contents of bytes the the specific integer address. int(8), int(16), int(32) per uw-formats.txt
		switch (size)
		{
		case 8:
			{return buffer[Address];}
		case 16:
			{return ConvertInt16(buffer[Address],buffer[Address+1]);}
		case 24:
			{return ConvertInt24(buffer[Address],buffer[Address+1],buffer[Address+2]);}
		case 32:	//may be buggy!
			{return ConvertInt32(buffer[Address],buffer[Address+1],buffer[Address+2],buffer[Address+3]);}
		default:
			{
			printf("Invalid size entered!");
			return -1;
			}
		}
	}



int getValAtCoordinate(int x, int y, int BlockStart,unsigned char *buffer,int size)
{
	int val = getValAtAddress(buffer, BlockStart + (x*4) + (y * (4 * 64)),size);
	return val;
}

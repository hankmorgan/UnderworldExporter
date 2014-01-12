#include <fstream>

long ConvertInt16(unsigned char Byte1, unsigned char Byte2);
long ConvertInt24(unsigned char Byte1, unsigned char Byte2,  unsigned char Byte3);
long ConvertInt32(unsigned char Byte1, unsigned char Byte2,  unsigned char Byte3,  unsigned char Byte4);
long getFileSize(FILE *file);
int getValAtAddress(unsigned char *buffer, long Address, int size);
int getValAtCoordinate(int x, int y, int BlockStart,unsigned char *buffer, int size);
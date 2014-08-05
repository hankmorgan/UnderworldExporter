#ifndef util_h
	#define util_h

#include <fstream>

long ConvertInt16(unsigned char Byte1, unsigned char Byte2);
long ConvertInt24(unsigned char Byte1, unsigned char Byte2,  unsigned char Byte3);
long ConvertInt32(unsigned char Byte1, unsigned char Byte2,  unsigned char Byte3,  unsigned char Byte4);


void WriteInt32(FILE *file, long val);
void WriteInt24(FILE *file, long val);
void WriteInt16(FILE *file, long val);
void WriteInt8(FILE *file, long val);

long getFileSize(FILE *file);
int getValAtAddress(unsigned char *buffer, long Address, int size);
int getValAtCoordinate(int x, int y, int BlockStart,unsigned char *buffer, int size);
int LoadShockFile(char *filePath,long fileSize, unsigned char *archive_ark);
long getShockBlockAddress(long BlockNo, unsigned char *tmp_ark, long *chunkPackedLength, long *chunkUnpackedLength, long *chunkType);
int LoadShockChunk(long AddressOfBlockStart, int chunkType, unsigned char *archive_ark, unsigned char *OutputChunk,long chunkPackedLength,long chunkUnpackedLength);

unsigned char* unpackUW2(unsigned char *tmp, int address_pointer, int *datalen);
void unpack_data(unsigned char *pack, unsigned char *unpack, unsigned long unpacksize);
long getShockBlockAddress(long BlockNo, unsigned char *tmp_ark, long *chunkPackedLength, long *chunkUnpackedLength, long *chunkType);

void RepackUW2(char InputFile[255], char OutputFile[255]);
void RepackShock(char InputFile[255], char OutputFile[255]);
void ParseTerrainProperties(int game);
#endif /*util_h*/
#ifndef tilemap_h
	#define tilemap_h
	#include "tilemap.h"
#endif

void RenderAsciiTile(tile &t);
void DumpAscii(int game,tile LevelInfo[64][64],ObjectItem objList[1600],int LevelNo,int mapOnly);

int isTrigger(ObjectItem currobj);
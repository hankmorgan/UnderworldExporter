#ifndef asciimode_h
	#define asciimode_h



void RenderAsciiTile(tile &t);
void DumpAscii(int game,tile LevelInfo[64][64],ObjectItem objList[1600],int LevelNo,int mapOnly);
void PrintUWObjects(ObjectItem objList[1600]);
void printTileMap(tile LevelInfo[64][64], int LevelNo);
void printFloorHeights(tile LevelInfo[64][64], int LevelNo);
void printFloorTextures(tile LevelInfo[64][64], int LevelNo);
void printDoorPositions(tile LevelInfo[64][64], ObjectItem objList[1600], int LevelNo);
void printWallTextures(tile LevelInfo[64][64], int LevelNo);
void printAdjacentFlags(tile LevelInfo[64][64], int LevelNo);
void printTextureOffsets(tile LevelInfo[64][64], int LevelNo);
void printCeilingHeights(tile LevelInfo[64][64], int LevelNo);
void printSlopeSteepness(tile LevelInfo[64][64], int LevelNo);
void printSlopeFlags(tile LevelInfo[64][64], int LevelNo);
void PrintObjectsByTile(tile LevelInfo[64][64], ObjectItem objList[1600], int LevelNo);
void PrintShadeValues(tile LevelInfo[64][64], int LevelNo);
void PrintLightStates(tile LevelInfo[64][64], int LevelNo);
void PrintLevelEntrances(tile LevelInfo[64][64], ObjectItem objList[1600], int LevelNo);
void printWaterRegions(tile LevelInfo[64][64], int LevelNo);
void printNeighbourCounts(tile LevelInfo[64][64], int LevelNo);
void printRoomRegions(tile LevelInfo[64][64], int LevelNo);
void printFloorOrientations(tile LevelInfo[64][64], int LevelNo);
void printCeilOrientations(tile LevelInfo[64][64], int LevelNo);
//int isTrigger(ObjectItem currobj);
#endif /* asciimode_h */
#ifndef SourceEngine_h
#define SourceEngine_h

#include "tilemap.h"
#include "gameobjects.h"

void RenderSourceEnginelLevel(tile LevelInfo[64][64], ObjectItem objList[1600], int game);
void RenderSourceTile(int game, int x, int y, tile &t, short Water, short invert, short skipFloor, short skipCeil);
void RenderSourceSolidTile(int x, int y, tile &t, short Water);
void RenderSourceOpenTile(int x, int y, tile &t, short Water, short invert);
void RenderSourceDiagSETile(int x, int y, tile &t, short Water, short invert);
void RenderSourceDiagNWTile(int x, int y, tile &t, short Water, short invert);
void Plane(int index, int face, int BLeftX, int BLeftY, int BLeftZ, int TLeftX, int TLeftY, int TLeftZ, int TRightX, int TRightY, int TRightZ, tile t);
void RenderSourceCuboid(int x, int y, tile &t, short Water, int Bottom, int Top);
void RenderSourceDiagSEPortion(int Bottom, int Top, tile t);
void RenderSourceDiagNWPortion(int Bottom, int Top, tile t);
#endif /* SourceEngine_h*/
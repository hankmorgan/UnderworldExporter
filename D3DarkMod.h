#ifndef _d3ddarkmod_h_
#define _d3ddarkmod_h_

struct ObjectItem;

#define PI 3.14159265358979323846
#define DOORORIGINOFFSET 15

void RenderDarkModLevel(tile LevelInfo[64][64],ObjectItem objList[1600],int game);
void RenderDarkModTile(int game, int x, int y, tile &t, short Water,short invert);

void getWallTextureName(tile t, int face, short waterWall);
void getFloorTextureName(tile t, int face);
long printObject(ObjectItem &currObj);
void RenderFloorAndCeiling(int game,tile LevelInfo[64][64]);
void RenderElevatorLeakProtection(int game,tile LevelInfo[64][64]);
void RenderObjectList(int game, tile LevelInfo[64][64], ObjectItem objList[1600]);

void RenderElevator(int game, tile LevelInfo[64][64], ObjectItem objList[1600]);
void RenderSolidTile(int x, int y, tile &t, short Water);
void RenderOpenTile(int x, int y, tile &t, short Water,short invert);
void RenderDoorway(int game,int x,int y, tile &t , ObjectItem currDoor);
void RenderPatch(int game, int x, int y, int z,long PatchIndex, ObjectItem objList[1600] );
void RenderDiagSETile(int x, int y, tile &t, short Water,short invert);
void RenderDiagSWTile(int x, int y, tile &t, short Water,short invert);
void RenderDiagNETile(int x, int y, tile &t, short Water,short invert);
void RenderDiagNWTile(int x, int y, tile &t, short Water,short invert);
void RenderSlopeNTile(int x, int y, tile &t, short Water,short invert);
void RenderSlopeSTile(int x, int y, tile &t, short Water,short invert);
void RenderSlopeWTile(int x, int y, tile &t, short Water,short invert);
void RenderSlopeETile(int x, int y, tile &t, short Water,short invert);
void RenderValleyNWTile(int x, int y, tile &t, short Water,short invert);
void RenderValleyNETile(int x, int y, tile &t, short Water,short invert);
void RenderValleySWTile(int x, int y, tile &t, short Water,short invert);
void RenderValleySETile(int x, int y, tile &t, short Water,short invert);
void RenderRidgeNWTile(int x, int y, tile &t, short Water,short invert);
void RenderRidgeNETile(int x, int y, tile &t, short Water,short invert);
void RenderRidgeSWTile(int x, int y, tile &t, short Water,short invert);
void RenderRidgeSETile(int x, int y, tile &t, short Water,short invert);
void RenderGenericTile(int x, int y, tile &t, int iCeiling ,int iFloor);
void RenderLevelExits(int game, tile LevelInfo[64][64], ObjectItem objList[1600]);

#endif // _d3ddarkmod_h_

#ifndef gameobjectsrender_h
#define gameobjectsrender_h

#include "tilemap.h"
#include "gameobjects.h"

void CalcObjectXYZ(int game, float *offX, float *offY, float *offZ, tile LevelInfo[64][64], ObjectItem objList[1600], long nextObj, int x, int y);
void EntityRotation(int heading);
void EntityRotationSHOCK(int heading);

void RenderEntityA_DOOR_TRAP(int game, float x, float y, float z, ObjectItem &currobj, ObjectItem objList[1600], tile LevelInfo[64][64]);
void RenderEntityModel(int game, float x, float y, float z, ObjectItem &currobj, ObjectItem objList[1600], tile LevelInfo[64][64]);
void RenderEntityDecal(int game, float x, float y, float z, ObjectItem &currobj, ObjectItem objList[1600], tile LevelInfo[64][64]);
void RenderEntityComputerScreen(int game, float x, float y, float z, ObjectItem &currobj, ObjectItem objList[1600], tile LevelInfo[64][64]);
void RenderEntityNPC(int game, float x, float y, float z, ObjectItem &currobj, ObjectItem objList[1600], tile LevelInfo[64][64]);
void RenderEntityDoor(int game, float x, float y, float z, ObjectItem &currobj, ObjectItem objList[1600], tile LevelInfo[64][64]);
void RenderEntityKey(int game, float x, float y, float z, ObjectItem &currobj, ObjectItem objList[1600], tile LevelInfo[64][64]);
void RenderEntityContainer(int game, float x, float y, float z, ObjectItem &currobj, ObjectItem objList[1600], tile LevelInfo[64][64]);
void RenderEntityCorpse(int game, float x, float y, float z, ObjectItem &currobj, ObjectItem objList[1600], tile LevelInfo[64][64]);
void RenderEntityButton(int game, float x, float y, float z, ObjectItem &currobj, ObjectItem objList[1600], tile LevelInfo[64][64]);

void RenderEntityA_DO_TRAP(int game, float x, float y, float z, ObjectItem &currobj, ObjectItem objList[1600], tile LevelInfo[64][64]);
void RenderEntityA_CHANGE_TERRAIN_TRAP(int game, float x, float y, float z, ObjectItem &currobj, ObjectItem objList[1600], tile LevelInfo[64][64]);
void RenderEntityTMAP(int game, float x, float y, float z, ObjectItem &currobj, ObjectItem objList[1600], tile LevelInfo[64][64]);
void RenderEntityBOOK(int game, float x, float y, float z, short message, ObjectItem &currobj, ObjectItem objList[1600], tile LevelInfo[64][64]);
void RenderEntitySIGN(int game, float x, float y, float z, ObjectItem &currobj, ObjectItem objList[1600], tile LevelInfo[64][64]);
void RenderEntityA_TELEPORT_TRAP(int game, float x, float y, float z, ObjectItem &currobj, ObjectItem objList[1600], tile LevelInfo[64][64]);
void RenderEntityA_MOVE_TRIGGER(int game, float x, float y, float z, ObjectItem &currobj, ObjectItem objList[1600], tile LevelInfo[64][64]);
void RenderEntityNULL_TRIGGER(int game, float x, float y, float z, ObjectItem &currobj, ObjectItem objList[1600], tile LevelInfo[64][64]);
void RenderEntityLEVEL_ENTRY(int game, float x, float y, float z, ObjectItem &currobj, ObjectItem objList[1600], tile LevelInfo[64][64]);
void RenderEntityREPULSOR(int game, float x, float y, float z, ObjectItem &currobj, ObjectItem objList[1600], tile LevelInfo[64][64]);
void RenderEntityWords(int game, float x, float y, float z, ObjectItem &currobj, ObjectItem objList[1600], tile LevelInfo[64][64]);
void RenderEntityGrating(int game, float x, float y, float z, ObjectItem &currobj, ObjectItem objList[1600], tile LevelInfo[64][64]);
void RenderEntitySHOCKDoor(int game, float x, float y, float z, ObjectItem &currobj, ObjectItem objList[1600], tile LevelInfo[64][64]);
void RenderEntityPaintingUW(int game, float x, float y, float z, ObjectItem &currobj, ObjectItem objList[1600], tile LevelInfo[64][64]);
void RenderEntityBridgeUW(int game, float x, float y, float z, ObjectItem &currobj, ObjectItem objList[1600], tile LevelInfo[64][64]);

#endif /*gameobjectsrender_h*/
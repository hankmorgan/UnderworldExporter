#ifndef Unity_h
#define Unity_h
#include "tilemap.h"
#include "gameobjects.h"

void RenderUnityObjectList(int game, int Level, tile LevelInfo[64][64], ObjectItem objList[1600]);
void PrintUnityTileMap(int game, int Level, tile LevelInfo[64][64]);
void UnityRotation(int game, int angle1, int angle2, int angle3);
void setLink(ObjectItem currobj);
void setSprite(unsigned char *SpriteName);
void SetButtonProperties(int game, short on, int SpriteNoOn, int SpriteNoOff);
void SetButtonProperties(int game, int SpriteNoBegin);
void SetScale(float x, float y, float z);
#endif
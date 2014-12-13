#ifndef Unity_h
#define Unity_h
#include "tilemap.h"
#include "gameobjects.h"

void RenderUnityObjectList(int game, int Level, tile LevelInfo[64][64], ObjectItem objList[1600]);
void UnityRotation(int game, int angle1, int angle2, int angle3);
void setLink(ObjectItem currobj);
void setSprite(unsigned char *SpriteName);
#endif
#ifndef _asciimode_h_
#define _asciimode_h_

void RenderAsciiTile(tile &t);
void DumpAscii(int game,tile LevelInfo[64][64],ObjectItem objList[1600],int LevelNo,int mapOnly);

int isTrigger(ObjectItem currobj);

#endif // _asciimode_h_
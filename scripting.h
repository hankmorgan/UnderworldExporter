#ifndef scripting_h
	#define scripting_h
void buildScriptsUW(int game,tile LevelInfo[64][64],ObjectItem objList[1600],int LevelNo);
void EMAILScript(char objName[80], int x, int y, int objId, int logChunk);
void scriptChainFunctionsUW(ObjectItem objList[1600], ObjectItem currObj,int *conditionalCount, int *TriggerTargetX,int *TriggerTargetY,int *TriggerQuality,int *TriggerFlags,int *TriggerHomeX,int *TriggerHomeY,int scriptLevelNo);
void BuildScriptsShock(int game,tile LevelInfo[64][64],ObjectItem objList[1600],int LevelNo);

#endif scripting_h
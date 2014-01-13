#include <stdio.h>
#include <stdlib.h>
#include <fstream>
#include <math.h>
#include <string.h>
#include "scripting.h"


void EMAILScript(char objName[80], int x, int y, int objId, int logChunk)
{
	printf ("void start_%s_%03d_%03d_%03d()\n{",objName,x,y,objId);
	printf("\n$data_reader_trigger.setKey(\"snd_say\",\"shock_audio_log_%04d\");",logChunk);
	printf("\n$data_reader_trigger.activate($player1);");
	printf("\n}\n\n");
}
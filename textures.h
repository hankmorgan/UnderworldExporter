#ifndef gameobjects_h
	#define gameobjects_h
	#include "gameobjects.h"
#endif
#ifndef gamestrings_h
	#define gamestrings_h
	#include "gamestrings.h"
#endif
#ifndef tilemap_h
	#define tilemap_h
	#include "tilemap.h"
#endif
#ifndef utils_h
	#define utils_h
	#include "utils.h"
#endif
#ifndef tilemap_h
	#define tilemap_h
	#include "tilemap.h"
#endif
#ifndef textures_h
	#define textures_h
	#include "textures.h"
#endif
#ifndef main_h
	#define main_h
	#include "main.h"
#endif	
#ifndef gamegraphics_h
	#define gamegraphics_h
	#include "gamegraphics.h"
#endif

#define CAULK -1
#define VISPORTAL -2
#define NODRAW -3
#define TRIGGER_MULTI -4

typedef struct texture
{
int textureNo;	//internal texture no.
char path[80];	//Texture Path
short type;	//wall=0;floor=1;ceiling=2	may not need?
char desc[80];

float align1_1;
float align1_2;
float align1_3;

float align2_1;
float align2_2;
float align2_3;


float floor_align1_1;
float floor_align1_2;
float floor_align1_3;

float floor_align2_1;
float floor_align2_2;
float floor_align2_3;


int water;
int lava;
} texture;


extern texture *textureMasters;
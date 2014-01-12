#ifndef _textures_h_
#define _textures_h_

#define CAULK -1
#define VISPORTAL -2
#define NODRAW -3
#define TRIGGER_MULTI -4

struct texture
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
};

extern texture *textureMasters;

#endif // _textures_h_

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


//Master object type definition
typedef struct ObjectItem
{
	int index;	//it's own index in case I need to find myself.
//000
   int item_id;	//0-8
   int flags;	//9-12
   short enchantment;	//12
   short doordir;	//13
   short invis;		//14
   short is_quant;	//15
   //or
   int texture;	//8-15
  // Note: some objects don't have flags and use the whole lower byte as a texture number (gravestone, picture, lever, switch, shelf, bridge, ..)
  // 0002 position
   int zpos;    //  0- 6   7   "zpos"      Object Z position (0-127)
   int heading;	//        7- 9   3   "heading"   Heading (*45 deg)
   int x; //   10-12   3   "ypos"      Object Y position (0-7)
   int y; //  13-15   3   "xpos"      Object X position (0-7)
   //0004 quality / chain
   int quality;	//;     0- 5   6   "quality"   Quality
   long next; //    6-15   10  "next"      Index of next object in chain
   
   //0006 link / special
   //     0- 5   6   "owner"     Owner / special

   int owner;	//Also special
   //     6-15   10  (*)         Quantity / special link / special property
   
   int link	;	//also quantity
   //int quantity; //the same
   
   
   //The values stored in the NPC info area (19 bytes) contain infos for
   //critters unique to each object.
   //0008 
	int npc_hp;	//0-7
	//0009	
	//blank?
	//000a   
	//blank?
	//000b   Int16      
	int npc_goal;	//0-3
	int npc_gtarg;    //4-11   
	//000d        
	int npc_level;	//0-3
	int npc_talkedto;   //13     
	int npc_attitude;	//14-15
    //000f    
    int npc_height ;//6- 12 ?
   //0016  
    int npc_yhome;	// 4-9    
     int npc_xhome; // 10-15  
   //0018   0010   Int8   0-4:   npc_heading?
//   0019      Int8   0-6:   
   int npc_hunger; //(?)
   //001a   0012   Int8          
   int npc_whoami;
   
   //Some stuff I need for attaching objects to joints.
   int objectOwner;	//index to the npc carrying the object
   int objectOwnerName;	//Npc whoami for
   int objectOwnerEntity;	//entity number that the owner was given during renderentity
   
   int joint;	//index to joint no.
   
   int tileX;	//Position of the object on the tilemap
   int tileY;
   
   	
} ObjectItem;


typedef struct shockObjectItem
{
int index;
int LookUpIndex;
int item_id;
int InUseFlag;
int ObjectClass;
int ObjectSubClass;
int ObjectSubClassIndex;
int XCoord;
int YCoord;
int ZCoord;
int Angle1;
int Angle2;
int Angle3;
int AIIndex;
int ObjectType;
int HitPoints;
int State;
int next;	//Next object in this tile
int tileX;
int tileY;
int extends;	//Flags that this object crosses tiles. I think I will need to ignore it.
//Need to add extended info for object types
}shockObjectItem;

//Object types
//guessing at what I'll need at the moment
#define	NPC 0
#define	WEAPON 1
#define	ARMOUR 2
#define	AMMO 3
#define	DOOR 4
#define	KEY 5
#define	RUNE 6
#define	BRIDGE 7
#define	BUTTON 8	
#define	LIGHT 9
#define	SIGN 10
#define	BOOK 11
#define	WAND 12	
#define	SCROLL 13	//The reading kind
#define	POTIONS 14	
#define	INSERTABLE 15	//Shock style put the circuit board in the slot.
#define	INVENTORY 16	//Quest items and the like with no special properties
#define ACTIVATOR 17	//Crystal balls,magic fountains and surgery machines that have special custom effects when you activate them
#define TREASURE 18
#define CONTAINER 19
//#define TRAP 20	
#define LOCK 21
#define TORCH 22
#define	CLUTTER 23
#define FOOD 24
#define SCENERY 25
#define INSTRUMENT 26
#define FIRE 27
#define MAP 28
#define HIDDENDOOR 29
#define PORTCULLIS 30
#define PILLAR 31
#define SOUND 32

#define TMAP_SOLID 34
#define TMAP_CLIP 35
#define MAGICSCROLL 36
#define A_DAMAGE_TRAP 37
#define  A_TELEPORT_TRAP 38
#define  A_ARROW_TRAP 39
#define  A_DO_TRAP 40
#define  A_PIT_TRAP 41
#define  A_CHANGE_TERRAIN_TRAP 42
#define  A_SPELLTRAP 43
#define  A_CREATE_OBJECT_TRAP 44
#define  A_DOOR_TRAP 45
#define  A_WARD_TRAP 46
#define  A_TELL_TRAP  47
#define  A_DELETE_OBJECT_TRAP 48
#define  AN_INVENTORY_TRAP 49
#define  A_SET_VARIABLE_TRAP 50
#define  A_CHECK_VARIABLE_TRAP 51
#define  A_COMBINATION_TRAP 52
#define  A_TEXT_STRING_TRAP 53
#define  A_MOVE_TRIGGER 54
#define  A_PICK_UP_TRIGGER 55
#define  A_USE_TRIGGER 56
#define  A_LOOK_TRIGGER 57
#define  A_STEP_ON_TRIGGER 58
#define  AN_OPEN_TRIGGER 59
#define  AN_UNLOCK_TRIGGER 60
#define  A_FOUNTAIN	61



typedef struct objectMaster
{
int index;	
short type;	//from above
char desc[80];
char path[80]; //to object model
short isEntity; // 1 for entity. 0 for model. -1 for ignored entries
short isSet;
} objectMaster;


typedef struct shockObjectMaster
{
int index;
int objClass;
int objSubClass;
int objSubClassIndex;
char desc[80];
}shockObjectMaster;



void EntityRotation(int heading);
void AttachToJoint(ObjectItem &currobj);
int isTrigger(ObjectItem currobj);
int isButton(ObjectItem currobj);
int isTrap(ObjectItem currobj);
long nextObject(ObjectItem &currObj);
long nextObjectShock(shockObjectItem &currObj);
int isLock(ObjectItem currobj);
void createScriptCall(ObjectItem &currobj,int x,int y,int z);
void EntityRotation(int heading);

extern objectMaster *objectMasters;
extern shockObjectMaster *shockObjectMasters;
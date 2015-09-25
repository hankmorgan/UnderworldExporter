#ifndef gameobjects_h
	#define gameobjects_h
	
#include "tilemap.h"

//Object types
//guessing at what I'll need at the moment
#define	NPC 0
#define	WEAPON 1 
#define	ARMOUR 2         //Chest pieces
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
#define CORPSE 33
#define TMAP_SOLID 34
#define TMAP_CLIP 35
#define MAGICSCROLL 36
#define A_DAMAGE_TRAP 37
#define A_TELEPORT_TRAP 38
#define A_ARROW_TRAP 39
#define A_DO_TRAP 40
#define A_PIT_TRAP 41
#define A_CHANGE_TERRAIN_TRAP 42
#define A_SPELLTRAP 43
#define A_CREATE_OBJECT_TRAP 44
#define A_DOOR_TRAP 45
#define A_WARD_TRAP 46
#define A_TELL_TRAP  47
#define A_DELETE_OBJECT_TRAP 48
#define AN_INVENTORY_TRAP 49
#define A_SET_VARIABLE_TRAP 50
#define A_CHECK_VARIABLE_TRAP 51
#define A_COMBINATION_TRAP 52
#define A_TEXT_STRING_TRAP 53
#define A_MOVE_TRIGGER 54
#define A_PICK_UP_TRIGGER 55
#define A_USE_TRIGGER 56
#define A_LOOK_TRIGGER 57
#define A_STEP_ON_TRIGGER 58
#define AN_OPEN_TRIGGER 59
#define AN_UNLOCK_TRIGGER 60
#define A_FOUNTAIN	61
#define SHOCK_DECAL 62
#define COMPUTER_SCREEN 63
#define SHOCK_WORDS 64
#define SHOCK_GRATING 65 
#define SHOCK_DOOR 66
#define SHOCK_DOOR_TRANSPARENT 67
#define UW_PAINTING	68
#define PARTICLE 69
#define RUNEBAG 70
#define SHOCK_BRIDGE 71
#define FORCE_DOOR 72
#define HELM 73
#define RING 74
#define BOOT 75
#define GLOVES 76
#define LEGGINGS 77
#define SHIELD 78
#define LOCKPICK 79
#define HIDDENPLACEHOLDER 999

/*SYSTEM SHOCK TRIGGER TYPES. I'm adding 100 to keep them seperate from the above*/
#define	SHOCK_TRIGGER_ENTRY			100	//Player enters trigger's tile
#define	SHOCK_TRIGGER_NULL			101	//Not set off automatically, must be explicitly activated by a switch or another trigger
#define	SHOCK_TRIGGER_FLOOR			102
#define	SHOCK_TRIGGER_PLAYER_DEATH	103
#define	SHOCK_TRIGGER_DEATHWATCH	104	//Object is destroyed / dies
#define	SHOCK_TRIGGER_AOE_ENTRY		105
#define	SHOCK_TRIGGER_AOE_CONTINOUS	106
#define	SHOCK_TRIGGER_AI_HINT		107
#define	SHOCK_TRIGGER_LEVEL			108	//Player enters level
#define	SHOCK_TRIGGER_CONTINUOUS	109
#define	SHOCK_TRIGGER_REPULSOR		110	//Repulsor lift floor
#define	SHOCK_TRIGGER_ECOLOGY		111
#define	SHOCK_TRIGGER_SHODAN		112
#define	SHOCK_TRIGGER_TRIPBEAM		113
#define	SHOCK_TRIGGER_BIOHAZARD		114
#define	SHOCK_TRIGGER_RADHAZARD		115
#define	SHOCK_TRIGGER_CHEMHAZARD	116
#define	SHOCK_TRIGGER_MAPNOTE		117	//Map note placed by player (presumably)
#define	SHOCK_TRIGGER_MUSIC			118

//System Shock object classes
#define GUNS_WEAPONS		0
#define AMMUNITION		1
#define PROJECTILES	2
#define GRENADE_EXPLOSIONS	3
#define PATCHES		4
#define HARDWARE	5
#define SOFTWARE_LOGS	6
#define FIXTURES	7
#define GETTABLES_OTHER	8
#define SWITCHES_PANELS	9
#define DOORS_GRATINGS	10
#define ANIMATED	11
#define TRAPS_MARKERS	12
#define CONTAINERS_CORPSES	13
#define CRITTERS	14

//System Shock object classes offsets. For this I will use their chunk offset value.
#define GUNS_WEAPONS_OFFSET		4010
#define AMMUNITION_OFFSET		4011
#define PROJECTILES_OFFSET	4012
#define GRENADE_EXPLOSIONS_OFFSET	4013	//a guess
#define PATCHES_OFFSET		4014
#define HARDWARE_OFFSET	4015
#define SOFTWARE_LOGS_OFFSET	4016
#define FIXTURES_OFFSET	4017
#define GETTABLES_OTHER_OFFSET	4018		//a guess
#define SWITCHES_PANELS_OFFSET	4019
#define DOORS_GRATINGS_OFFSET	4020
#define ANIMATED_OFFSET	4021		//a guess?
#define TRAPS_MARKERS_OFFSET	4022
#define CONTAINERS_CORPSES_OFFSET	4023
#define CRITTERS_OFFSET	4024

#define SURVELLANCE_OFFSET 4043

/*SHOCK TRIGGER ACTION TYPES per ssspecs*/
#define ACTION_DO_NOTHING 0 
#define ACTION_TRANSPORT_LEVEL	1
#define ACTION_RESURRECTION	2
#define ACTION_CLONE	3
#define ACTION_SET_VARIABLE	4
#define ACTION_ACTIVATE	6
#define ACTION_LIGHTING	7
#define ACTION_EFFECT	8
#define ACTION_MOVING_PLATFORM	9
#define ACTION_TIMER   11		//This is an assumption
#define ACTION_CHOICE	12
#define ACTION_EMAIL	15
#define ACTION_RADAWAY	16
#define ACTION_CHANGE_STATE	19
#define ACTION_AWAKEN   21
#define ACTION_MESSAGE	22
#define ACTION_SPAWN	23		
#define ACTION_CHANGE_TYPE	24

/*Some friendly array indices for shock objProperties array*/
//Software
#define SOFT_PROPERTY_VERSION 0
#define SOFT_PROPERTY_LOG 9
#define SOFT_PROPERTY_LEVEL 2
//Buttons and panels

#define BUTTON_PROPERTY_TRIGGER 0
#define BUTTON_PROPERTY_PUZZLE 1
#define BUTTON_PROPERTY_COMBO 2
#define BUTTON_PROPERTY_TRIGGER_2 3


//Trigger props
#define TRIG_PROPERTY_OBJECT		0
#define TRIG_PROPERTY_TARGET_X	1
#define TRIG_PROPERTY_TARGET_Y	2
#define TRIG_PROPERTY_TARGET_Z	3
#define TRIG_PROPERTY_FLAG		4
#define TRIG_PROPERTY_VARIABLE	5
#define TRIG_PROPERTY_VALUE		6
#define TRIG_PROPERTY_OPERATION	7
#define TRIG_PROPERTY_MESSAGE1	8
#define TRIG_PROPERTY_MESSAGE2	9
#define TRIG_PROPERTY_LIGHT_OP	3
#define TRIG_PROPERTY_CONTROL_1	4 
#define TRIG_PROPERTY_CONTROL_2	5
#define TRIG_PROPERTY_UPPERSHADE_1 6
#define TRIG_PROPERTY_LOWERSHADE_1 7
#define TRIG_PROPERTY_UPPERSHADE_2 8
#define TRIG_PROPERTY_LOWERSHADE_2 9

#define TRIG_PROPERTY_FLOOR		5 
#define TRIG_PROPERTY_CEILING	6
#define TRIG_PROPERTY_SPEED		7 
#define TRIG_PROPERTY_TRIG_1		5
#define TRIG_PROPERTY_TRIG_2		6
#define TRIG_PROPERTY_EMAIL		9
#define TRIG_PROPERTY_TYPE		8

#define CONTAINER_CONTENTS_1	0
#define CONTAINER_CONTENTS_2	1
#define CONTAINER_CONTENTS_3	2
#define CONTAINER_CONTENTS_4	3
#define CONTAINER_WIDTH	        5
#define CONTAINER_HEIGHT	    6
#define CONTAINER_DEPTH	        7
#define CONTAINER_TOP			8
#define CONTAINER_SIDE			9

#define SCREEN_NO_OF_FRAMES 0
#define SCREEN_LOOP_FLAG 1
#define SCREEN_START 2
#define SCREEN_SURVEILLANCE_TARGET 3

#define WORDS_STRING_NO 0
#define WORDS_FONT 1
#define WORDS_SIZE 2
#define WORDS_COLOUR 3

#define BRIDGE_X_SIZE 0
#define BRIDGE_Y_SIZE 1
#define BRIDGE_HEIGHT 2
#define BRIDGE_TOP_BOTTOM_TEXTURE 3
#define BRIDGE_TOP_BOTTOM_TEXTURE_SOURCE 4
#define BRIDGE_SIDE_TEXTURE 5
#define BRIDGE_SIDE_TEXTURE_SOURCE 6

//Common properties from commonobj
#define UW_PROP_HEIGHT 0
#define UW_PROP_RADIUS 1
#define UW_PROP_MASS 2
#define UW_PROP_VALUE 3
#define UW_PROP_OWNER 4
#define UW_PROP_QUALITY 5

//Item type specific properties (for array uwproperites array)
#define UW_PROP_DURABILITY 10

//Melee Weapons
#define UW_PROP_WEAP_SLASH 6
#define UW_PROP_WEAP_BASH 7
#define UW_PROP_WEAP_STAB 8
#define UW_PROP_WEAP_SKILL 9

//Armour
#define UW_PROP_ARM_PROTECTION 6

//Containers
#define UW_PROP_CONT_CAPACITY 6
#define UW_PROP_CONT_OBJECTS 7
#define UW_PROP_CONT_SLOTS 8

//Light Sources
#define UW_PROP_LIGHT_BRIGHTNESS 6
#define UW_PROP_LIGHT_DURATION 7

//Animations
#define UW_PROP_ANIM_PAL 6
#define UW_PROP_ANIM_START 7
#define UW_PROP_ANIM_FRAMES 8




//Master object type definition
struct ObjectItem
{
   int index;	//it's own index in case I need to find myself.
   int item_id;	//0-8
   int flags;	//9-12
   short enchantment;	//12
   short doordir;	//13
   short invis;		//14
   short is_quant;	//15
  
   int texture;	// Note: some objects don't have flags and use the whole lower byte as a texture number 
				//(gravestone, picture, lever, switch, shelf, bridge, ..)

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
   
   //The values stored in the NPC info area (19 bytes) contain infos for
   //critters unique to each object.
   //0008 
	int npc_hp;	//0-7
	//0009	
	//blank?
	//000a   
	//blank?
	//000b   Int16      
	short npc_goal;	//0-3
	short npc_gtarg;    //4-11   
	//000d        
	short npc_level;	//0-3
	short npc_talkedto;   //13     
	short npc_attitude;	//14-15
    //000f    
    short npc_height ;//6- 12 ?
   //0016  
    short npc_yhome;	// 4-9    
    short npc_xhome; // 10-15  
   //0018   0010   Int8   0-4:   npc_heading?
//   0019      Int8   0-6:   
    short npc_hunger; //(?)
   //001a   0012   Int8          
    int npc_whoami;
   
   //Some stuff I need for attaching objects to joints.
   int objectOwner;	//index to the npc carrying the object
   int objectOwnerName;	//Npc whoami for
   int objectOwnerEntity;	//entity number that the owner was given during renderentity
   
   short joint;	//index to joint no.
   
   short levelno;
   short tileX;	//Position of the object on the tilemap
   short tileY;
 
   
   //Shock specific stuff
	short InUseFlag;
	short ObjectClass;
	short ObjectSubClass;
	short ObjectSubClassIndex;
	int Angle1;
	int Angle2;
	int Angle3;
	int AIIndex;
	int ObjectType;
	int HitPoints;
	int State;
	//int duplicate;   //when it extends into another tile
	short TriggerOnce;
	short TriggerAction;	//For triggers
	int shockProperties[10]; //Further generic properties for data pulled back from subclass blocks.
	int conditions[4];  	
	int sprite;
	short unk1;
	short SHOCKLocked;
	short DeathWatched;
	//scripting state flags
	short global;
	short TriggerOnceGlobal;
	int objectConversion;	//For what an object can turn into
	short keyCount; //If this is a key then it needs to know which number of key it is.
	short AlreadyRendered;

	long address;	//The file address of the object in question.
};






struct objectMaster	//For common object properties.
	{
	int index;
	short type;	//from above
	char desc[80];
	char path[80]; //to object model
	char particle[80];
	char sound[80];
	short isEntity; // 1 for entity. 0 for model. -1 for ignored entries
	short isSet;
	short objClass;	//For Shock
	short objSubClass;
	short objSubClassIndex;

	short extraInfo;	//For stuff like door texture info.

	short renderType;
	short frame1;	//Frame no
	short DeathWatch;

	short hasParticle;
	short hasSound;
	char base[80];
	short isSolid;
	short isMoveable;
	short isInventory;
	short isAnimated;
	short useSprite;
	char InvIcon[80];

	char EquippedIconFemaleLowest[80];
	char EquippedIconMaleLowest[80];//and default
	char EquippedIconFemaleLow[80];
	char EquippedIconMaleLow[80];
	char EquippedIconFemaleMedium[80];
	char EquippedIconMaleMedium[80];
	char EquippedIconFemaleBest[80];
	char EquippedIconMaleBest[80];

	int uwProperties[11];
};





//typedef struct shockObjectMaster
//{
//int index;
//int objClass;
//int objSubClass;
//int objSubClassIndex;
//char desc[80];
//}shockObjectMaster;
struct xrefTable
{
short tileX;// position
short tileY;// position
int next;
int	MstIndex;// into master object table
int nextTile; //objects in next tile
short duplicate;
short duplicateAssigned;
short duplicateNextAssigned;
};

struct mstTable
{
int index;
int inuse;
short objectclass;
short objectsubclass;
short subclasslink;
int xRef;
int nextlink;
};




void AttachToJoint(ObjectItem &currobj);
int isTrigger(ObjectItem currobj);
int isButton(ObjectItem currobj);
int isTrap(ObjectItem currobj);
int isLog (ObjectItem currobj);
int isContainer(ObjectItem currobj);
int isSHOCKDoor(ObjectItem currobj);
int hasContents(ObjectItem currobj);
long nextObject(ObjectItem &currObj);
//long nextObjectShock(shockObjectItem &currObj);
int isLock(ObjectItem currobj);
//void createScriptCall(ObjectItem &currobj,float x,float y, float z);

char *UniqueObjectName(ObjectItem currObj);
int isButtonSHOCK(ObjectItem currobj);
int isTriggerSHOCK(ObjectItem currobj);
char *getObjectNameByClass(int objClass, int subClass, int subClassIndex);
int getObjectIDByClass(int objClass, int subClass, int subClassIndex);
void shockCommonObject();

int lookUpSubClass(unsigned char *archive_ark, int BlockNo, int ClassType, int index, int RecordSize, xrefTable *xRef, ObjectItem objList[1600], long texture_map[256], int objIndex, int levelNo);
void getShockTriggerAction(tile LevelInfo[64][64], unsigned char *sub_ark, int add_ptr, xrefTable *xRef, ObjectItem objList[1600], int objIndex);
int LookupxRefTable(xrefTable *xref, int x, int y, int MasterIndex, int tableSize);
void replaceLink(xrefTable *xref, int tableSize, int indexToFind, int linkToReplace);
void replaceMapLink(tile levelInfo[64][64], xrefTable *xref, int tableSize, int indexToFind, int linkToReplace);
void getShockButtons(tile LevelInfo[64][64], unsigned char *sub_ark, int add_ptr, ObjectItem objList[1600], int objIndex);

void setElevatorProperties(tile LevelInfo[64][64], unsigned char *sub_ark, int add_ptr, ObjectItem objList[1600], int objIndex, short PrintDebug);
void DebugPrintTriggerVals(unsigned char *sub_ark, int add_ptr, int length);

void setDoorBits(tile LevelInfo[64][64], ObjectItem objList[1025]);
void setPatchBits(tile LevelInfo[64][64], ObjectItem objList[1025]);
void SetDeathWatch(ObjectItem objList[1600]);
void SetBullFrog(tile LevelInfo[64][64], ObjectItem objList[1600], int LevelNo);
extern objectMaster *objectMasters;
//extern shockObjectMaster *shockObjectMasters;
void DumpObjectCombinations(char *filePath, int game);
void UWCommonObj(int game);
#endif /*gameobjects_h*/

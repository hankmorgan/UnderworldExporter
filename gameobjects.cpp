#include <stdio.h>
#include <stdlib.h>
#include <fstream>
#include "math.h"

	#include "D3DarkMod.h"
	#include "textures.h"
	#define utils_h
	#include "utils.h"
	#include "main.h"
	#include "gameobjects.h"


void getWallTextureName(tile t, int face, short waterWall);
void getFloorTextureName(tile t, int face);
//void RenderPatch(int game, float x, float y, float z,long PatchIndex, ObjectItem objList[1600] );
 
void CalcObjectXYZ(int game, float *offX,  float *offY, float *offZ, tile LevelInfo[64][64], ObjectItem objList[1600], long nextObj,int x,int y);
int lookUpSubClass(unsigned char *archive_ark, int BlockNo, int ClassType ,int index, int RecordSize, xrefTable *xRef, ObjectItem objList[1600], int currObj);
void getShockTriggerAction(tile LevelInfo[64][64],unsigned char *sub_ark,int add_ptr, xrefTable *xRef, ObjectItem objList[1600], int objIndex);
int LookupxRefTable(xrefTable *xref,int x, int y, int MasterIndex, int tableSize);
void replaceLink(xrefTable *xref, int tableSize, int indexToFind, int linkToReplace);
void replaceMapLink(tile levelInfo[64][64], xrefTable *xref, int tableSize, int indexToFind, int linkToReplace);
void getShockButtons(tile LevelInfo[64][64],unsigned char *sub_ark,int add_ptr, ObjectItem objList[1600], int objIndex);
void shockCommonObject();
void setElevatorProperties(tile LevelInfo[64][64],unsigned char *sub_ark,int add_ptr, ObjectItem objList[1600], int objIndex,short PrintDebug);
void DebugPrintTriggerVals(unsigned char *sub_ark, int add_ptr, int length);
void AddEmails(int game, tile LevelInfo[64][64], ObjectItem objList[1600]);
void RenderEntityDecal(int game, float x, float y, float z, ObjectItem &currobj, ObjectItem objList[1600], tile LevelInfo[64][64]);
void RenderEntityComputerScreen(int game, float x, float y, float z, ObjectItem &currobj, ObjectItem objList[1600], tile LevelInfo[64][64]);
void RenderEntityModel(int game, float x, float y, float z, ObjectItem &currobj, ObjectItem objList[1600], tile LevelInfo[64][64]);
void RenderEntityNPC(int game, float x, float y, float z, ObjectItem &currobj, ObjectItem objList[1600], tile LevelInfo[64][64]);
void RenderEntityDoor(int game, float x, float y, float z, ObjectItem &currobj, ObjectItem objList[1600], tile LevelInfo[64][64]);
void RenderEntityKey(int game, float x, float y, float z, ObjectItem &currobj, ObjectItem objList[1600], tile LevelInfo[64][64]);
void RenderEntityContainer(int game, float x, float y, float z, ObjectItem &currobj, ObjectItem objList[1600], tile LevelInfo[64][64]);
void RenderEntityCorpse(int game, float x, float y, float z, ObjectItem &currobj, ObjectItem objList[1600], tile LevelInfo[64][64]);
void RenderEntityButton(int game, float x, float y, float z, ObjectItem &currobj, ObjectItem objList[1600], tile LevelInfo[64][64]);
void RenderEntityA_DOOR_TRAP(int game, float x, float y, float z, ObjectItem &currobj, ObjectItem objList[1600], tile LevelInfo[64][64]);
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

extern long SHOCK_CEILING_HEIGHT;
extern FILE *MAPFILE;
int GAME;

int keycount[256];	//For tracking key usage
//int levelNo;

void RenderEntity(int game, float x, float y, float z, ObjectItem &currobj, ObjectItem objList[1600], tile LevelInfo[64][64])
{
//Picks what type of object to generate.
//long patchX;long patchY;long patchZ;
//int patchOffsetX;int patchOffsetY;

printf("Rendering:%s\n", UniqueObjectName(currobj));
switch (objectMasters[currobj.item_id].isEntity )
	{
	case -1:	//ignore
		{return;break;}
	case 0:	//Model
		{
		RenderEntityModel(game,x,y,z,currobj,objList,LevelInfo);
		break;
		}
	case 1:	//entity
		{
		switch (objectMasters[currobj.item_id].type)
			{
			case NPC:
				{
				//
				RenderEntityNPC(game,x,y,z,currobj,objList,LevelInfo);
				break;
				}
			case HIDDENDOOR:
				printf("");
			case DOOR:
				{
				RenderEntityDoor(game,x,y,z,currobj,objList,LevelInfo);
				break;
				}
			case KEY:
				{
				RenderEntityKey(game,x,y,z,currobj,objList,LevelInfo);
				break;
				}
			case CONTAINER:
				{
				RenderEntityContainer(game,x,y,z,currobj,objList,LevelInfo);
				break;
				}
			case BUTTON:
				{	
				RenderEntityButton(game,x,y,z,currobj,objList,LevelInfo);
				break;
				}
			case LOCK:
			case A_DOOR_TRAP:
				RenderEntityA_DOOR_TRAP(game,x,y,z,currobj,objList,LevelInfo);
				break;
			case A_DO_TRAP:
				RenderEntityA_DO_TRAP(game,x,y,z,currobj,objList,LevelInfo);
				break;
			case A_CHANGE_TERRAIN_TRAP:
				RenderEntityA_CHANGE_TERRAIN_TRAP(game,x,y,z,currobj,objList,LevelInfo);
				break;
			case TMAP_SOLID:
			case TMAP_CLIP:
				RenderEntityTMAP(game,x,y,z,currobj,objList,LevelInfo);
				break;
			case BOOK:
			case SCROLL:
				RenderEntityBOOK(game,x,y,z,0,currobj,objList,LevelInfo);
				break;	
			case SIGN:
				RenderEntitySIGN(game,x,y,z,currobj,objList,LevelInfo);
				break;	
			case A_MOVE_TRIGGER:
				RenderEntityA_MOVE_TRIGGER(game,x,y,z,currobj,objList,LevelInfo);				
				
				break;
			case A_TELEPORT_TRAP:	//a destination for a teleport.
				RenderEntityA_TELEPORT_TRAP(game,x,y,z,currobj,objList,LevelInfo);
				break;
			case SHOCK_DECAL:
				RenderEntityDecal(game, x, y, z, currobj, objList, LevelInfo);
				break;
			case COMPUTER_SCREEN:
				RenderEntityComputerScreen(game, x, y, z, currobj, objList, LevelInfo);
				break;
			case SHOCK_TRIGGER_DEATHWATCH:
			case SHOCK_TRIGGER_NULL:
			case SHOCK_TRIGGER_LEVEL:
				RenderEntityNULL_TRIGGER(game,x,y,z,currobj,objList,LevelInfo);	
				break;	
			case SHOCK_TRIGGER_REPULSOR:
				RenderEntityREPULSOR(game,x,y,z,currobj,objList,LevelInfo);
				break;
			case CORPSE:
				RenderEntityCorpse(game, x, y, z, currobj, objList, LevelInfo);
				break;
			case SHOCK_WORDS:
				RenderEntityWords(game, x, y, z, currobj, objList, LevelInfo);
				break;
			case SHOCK_GRATING:
				RenderEntityGrating(game, x, y, z, currobj, objList, LevelInfo);
				break;
			case SHOCK_DOOR:
			case SHOCK_DOOR_TRANSPARENT:
				RenderEntitySHOCKDoor(game, x, y, z, currobj, objList, LevelInfo);
				break;
			default:
				{//just the basic name. with no properties.
				fprintf (MAPFILE, "\n// entity %d\n{\n",EntityCount);
				fprintf (MAPFILE, "\"classname\" \"%s\"\n", objectMasters[currobj.item_id].path);
				fprintf (MAPFILE, "\"name\" \"%s_%04d\"\n",objectMasters[currobj.item_id].desc,EntityCount);	
				//position
				fprintf (MAPFILE, "\"origin\" \"%f %f %f\"\n",x,y,z);	
				EntityRotation(currobj.heading);
				AttachToJoint(currobj);		//for npc items
				fprintf (MAPFILE, "}");
				EntityCount++;		
				break;
				}
			}
		}
	}	
	if ((currobj.objectConversion != 0) && (game == SHOCK))
		{
		//Swap out the object type but generate based on the original properties.
		int originalObj = objList[currobj.index].item_id;
		int newObj = currobj.objectConversion;
		int newObjId = getObjectIDByClass(currobj.ObjectClass, currobj.ObjectSubClass, currobj.objectConversion);
		objList[currobj.index].item_id = newObjId;
		objList[currobj.index].objectConversion = 0;
		objList[currobj.index].invis = 1;	//hide the object
		RenderEntity(game, x, y, z, currobj, objList, LevelInfo);
		objList[currobj.index].invis = 0;
		objList[currobj.index].item_id = originalObj;
		objList[currobj.index].objectConversion = newObj;
		}
}


void AttachToJoint(ObjectItem &currobj)
	{//TODO: fix me up.
	if (currobj.joint !=0 )
		{
		fprintf (MAPFILE, "\"bind\" \"NPC_%03d_%03d\"\n",currobj.objectOwnerName,currobj.objectOwnerEntity);
		fprintf (MAPFILE, "\"bindToJoint\" \"spine\"\n");
		}
	return;
	}
	
int isTrigger(ObjectItem currobj)
	{//Tells if the object is a trigger that can set of a trap.
		switch(objectMasters[currobj.item_id].type )
		{
			case  A_MOVE_TRIGGER :
			case  A_PICK_UP_TRIGGER :
			case  A_USE_TRIGGER :
			case  A_LOOK_TRIGGER :
			case  A_STEP_ON_TRIGGER :
			case  AN_OPEN_TRIGGER :
			case  AN_UNLOCK_TRIGGER :
				{
				return 1;
				break;
				}	
		default:
			{
			return 0;
			break;
			}
		}
	}
	
int isTriggerSHOCK(ObjectItem currobj)
	{
	return (currobj.ObjectClass == TRAPS_MARKERS );
	}
		
int isButton(ObjectItem currobj)
{//Guess
		switch(objectMasters[currobj.item_id].type )
		{
			case  BUTTON :
				{
				return 1;
				break;
				}	
			default:
				{
				return 0;
				break;
				}
		}
}


int isButtonSHOCK(ObjectItem currobj)
{
	return (currobj.ObjectClass == SWITCHES_PANELS );
}

int isLog (ObjectItem currobj)
	{
	if ((objectMasters[currobj.item_id].objClass == SOFTWARE_LOGS ) && (objectMasters[currobj.item_id].objSubClass==4) && (objectMasters[currobj.item_id].objSubClassIndex == 1))
		{
		return 1;
		}
	else
		{
		return 0;
		}
	
	}

int isContainer(ObjectItem currobj)
{
	return  ((objectMasters[currobj.item_id].type == CONTAINER) || (objectMasters[currobj.item_id].type == CORPSE));
}

int isSHOCKDoor(ObjectItem currobj)
{
	return  ((objectMasters[currobj.item_id].type == SHOCK_DOOR));
}

int hasContents(ObjectItem currobj)
{//Returns wether or not a contain contains items
	return (
		(currobj.shockProperties[CONTAINER_CONTENTS_1] > 0)
		|| (currobj.shockProperties[CONTAINER_CONTENTS_2] > 0)
		|| (currobj.shockProperties[CONTAINER_CONTENTS_3] > 0)
		|| (currobj.shockProperties[CONTAINER_CONTENTS_4] > 0)
		);
	
}

int isTrap(ObjectItem currobj)
	{
	switch (objectMasters[currobj.item_id].type )
		{
			case  A_DAMAGE_TRAP :
			case  A_TELEPORT_TRAP :
			case  A_ARROW_TRAP :
			case  A_DO_TRAP :
			case  A_PIT_TRAP :
			case  A_CHANGE_TERRAIN_TRAP :
			case  A_SPELLTRAP :
			case  A_CREATE_OBJECT_TRAP :
			case  A_DOOR_TRAP :
			case  A_WARD_TRAP :
			case  A_TELL_TRAP  :
			case  A_DELETE_OBJECT_TRAP :
			case  AN_INVENTORY_TRAP :
			case  A_SET_VARIABLE_TRAP :
			case  A_CHECK_VARIABLE_TRAP :
			case  A_COMBINATION_TRAP :
			case  A_TEXT_STRING_TRAP :
			{
				return 1;
				break;
			}
		default:
			{
			return 0;
			break;
			}
		}
	}

int isLock(ObjectItem currobj)
	{
	switch (objectMasters[currobj.item_id].type )
		{
			case LOCK :
			{
				return 1;
				break;
			}
		default:
			{
			return 0;
			break;
			}
		}
	}


long nextObject(ObjectItem &currObj)
{//Index of next object in the linked list.
	return currObj.next; 
}

//long nextObjectShock(shockObjectItem &currObj)
//{//Index of next object in the linked list.
//	return currObj.next; 
//}
void createScriptCall(ObjectItem &currobj,float x,float y, float z)
{//Entity for running a script when triggered.
	fprintf (MAPFILE, "\n// entity %d\n{\n",EntityCount);
	fprintf (MAPFILE, "\"classname\" \"atdm:target_callscriptfunction\"\n");
	fprintf (MAPFILE, "\"name\" \"runscript_%s\"\n", UniqueObjectName(currobj));	
	fprintf (MAPFILE, "\"origin\" \"%f %f %f\"\n",x,y,z);	
	fprintf (MAPFILE, "\"call\" \"start_%s\"\n", UniqueObjectName(currobj));
	fprintf (MAPFILE, "}\n");
	EntityCount++;
}

void createScriptCall(ObjectItem &currobj, float x, float y, float z,char *callname)
{//Entity for running a script when triggered.
	fprintf(MAPFILE, "\n// entity %d\n{\n", EntityCount);
	fprintf(MAPFILE, "\"classname\" \"atdm:target_callscriptfunction\"\n");
	fprintf(MAPFILE, "\"name\" \"runscript_%s_%s\"\n", UniqueObjectName(currobj),callname);
	fprintf(MAPFILE, "\"origin\" \"%f %f %f\"\n", x, y, z);
	fprintf(MAPFILE, "\"call\" \"start_%s_%s\"\n", UniqueObjectName(currobj),callname);
	fprintf(MAPFILE, "}\n");
	EntityCount++;
}


void RenderEntityModel (int game, float x, float y, float z, ObjectItem &currobj, ObjectItem objList[1600], tile LevelInfo[64][64])
{//A model with no properties.

//Params 
//item_id
//tileX
//tileY
//Index

		fprintf (MAPFILE, "\n// entity %d\n{\n",EntityCount);
		if ((currobj.DeathWatched >= 1) && (game == SHOCK))
		{
			fprintf(MAPFILE, "\"classname\" \"func_damagable\"\n");//this can be broken.
			fprintf(MAPFILE, "\"broken\" \"models/darkmod/junk/bot_parts/lanternbot_boiler.ase\"\n");
			fprintf(MAPFILE, "\"target\" \"runscript_%s\"\n", UniqueObjectName(currobj));
		}
		else
		{
			fprintf(MAPFILE, "\"classname\" \"func_static\"\n");
		}
		//print position+name
		fprintf (MAPFILE, "\"name\" \"%s\"\n", UniqueObjectName(currobj));
		fprintf (MAPFILE, "\"origin\" \"%f %f %f\"\n",x,y,z);	
		if (objectMasters[currobj.item_id].type = HIDDENPLACEHOLDER)
		{
			fprintf(MAPFILE, "\"solid\" \"%d\"\n", 1);	//temporarily till I figure out controlling solidity via script
		}

		fprintf(MAPFILE, "\"hide\" \"%d\"\n", currobj.invis);

		
		if (game == SHOCK)
		{
			EntityRotationSHOCK(currobj.Angle2);
		}
		else
		{
			EntityRotation(currobj.heading);
		}
		
		AttachToJoint(currobj);
		if (currobj.link!=0)
			{
			fprintf (MAPFILE, "\"frobable\" \"%d\"\n",1);	
			fprintf (MAPFILE, "\"frob_action_script\" \"start_%s\"\n", UniqueObjectName(currobj));	
			}
		fprintf (MAPFILE, "\n\"model\" \"%s\"\n}\n",objectMasters[currobj.item_id].path);
		EntityCount++;
		if ((currobj.DeathWatched >= 1) && (game == SHOCK))
		{
			createScriptCall(currobj, x, y, z);
		}
		return;
}

void RenderEntityNPC (int game, float x, float y, float z, ObjectItem &currobj, ObjectItem objList[1600], tile LevelInfo[64][64])
{
//Params
//item_id
//npc_whoami
//npc_attitude
//link for npc inventory in UW
//objectOwnerEntity.
	fprintf (MAPFILE, "\n// entity %d\n{\n",EntityCount);
	fprintf (MAPFILE, "\"classname\" \"%s\"\n", objectMasters[currobj.item_id].path);
	fprintf (MAPFILE, "\"name\" \"%s\"\n", UniqueObjectName(currobj));
	switch (currobj.npc_attitude)
		{	
		case 0:	//hostile
			{
			fprintf (MAPFILE, "\"team\" \"5\"\n");	//Criminals team
			break;
			}
		default:
			{
			fprintf (MAPFILE, "\"team\" \"5\"\n");	//Beggars team
			break;
			}
		}					
	
	//position
	fprintf (MAPFILE, "\"origin\" \"%f %f %f\"\n",x,y,z);	
	//fprintf (MAPFILE, "\"animal_patrol\" \"1\"\n");	
	EntityRotation(currobj.heading);
	fprintf (MAPFILE, "}");
	EntityCount++;	
	if (currobj.link !=0)//Npc has an inventory	I need to set up joints for the entities.
		{
		int JointCount=1;	//For a future joint enumeration
		//TODO:Clean this up,
		ObjectItem tmpobj = objList[currobj.link];
		tmpobj.objectOwner =currobj.index;
		currobj.objectOwner =currobj.index;
		tmpobj.objectOwnerName = currobj.npc_whoami;
		currobj.objectOwnerName = currobj.npc_whoami ;
		if (currobj.objectOwnerEntity ==0 ){currobj.objectOwnerEntity=EntityCount-1;} //assumes the previous entity is the npc with the inventory.
		tmpobj.objectOwnerEntity = currobj.objectOwnerEntity;
		tmpobj.joint = JointCount++;					
		while( tmpobj.next  !=0 )
			{
			RenderEntity(game,x,y,z,tmpobj,objList,LevelInfo);	//Need to fix up the x y z to a better spot.
			tmpobj = objList[tmpobj.next];
			//I pass the owner info down the line
			tmpobj.objectOwner = currobj.objectOwner;
			tmpobj.objectOwnerName = currobj.objectOwnerName;
			tmpobj.objectOwnerEntity = currobj.objectOwnerEntity;
			tmpobj.joint = JointCount++;							
			}
		RenderEntity(game,x,y,z,tmpobj,objList,LevelInfo); //NPC's inventory.
		}					
		
	return;	
}

void RenderEntityDoor (int game, float x, float y, float z, ObjectItem &currobj, ObjectItem objList[1600], tile LevelInfo[64][64])
{
//Params
//item_id
//tileX
//tileY
//Link for a lock
float doorWidth=48;
float doorHeight =96;
float tileX = currobj.tileX ;
float tileY = currobj.tileY ;
float BrushX= BrushSizeX;
float BrushY= BrushSizeY;
float zpos = z;


if (game == SHOCK)
	{
	zpos = LevelInfo[currobj.tileX][currobj.tileY].floorHeight * BrushSizeZ;
	if (currobj.Angle1 > 0)
	{
		return;	
	}
}
	//for a door I need to point it's used_by property at the key object's name. This is accessed through a lock object
	fprintf (MAPFILE, "\n// entity %d\n{\n",EntityCount);
	fprintf (MAPFILE, "\"classname\" \"%s\"\n", objectMasters[currobj.item_id].path);

	fprintf (MAPFILE, "\"name\" \"%s_%03d_%03d\"\n",objectMasters[currobj.item_id].desc,currobj.tileX,currobj.tileY);
	fprintf(MAPFILE, "\"hide\" \"%d\"\n", currobj.invis);

	fprintf(MAPFILE, "\"auto_close_time\" \"30\"\n");
	if ((currobj.link != 0) || (currobj.SHOCKLocked >0))	//door has a lock. bit 0-6 of the lock objects link is the keyid for opening it in uw
		{
		//up to 6 keys can be used for a door to allow duplicate keys.
		if (game != SHOCK)
			{
			fprintf(MAPFILE, "\"locked\" \"%d\"\n", (objList[currobj.link].flags & 0x01));
			fprintf (MAPFILE, "\"used_by\" \"a_key_%03d_0\"\n", objList[currobj.link].link & 0x3F);
			fprintf (MAPFILE, "\"used_by1\" \"a_key_%03d_1\"\n", objList[currobj.link].link & 0x3F);
			fprintf (MAPFILE, "\"used_by2\" \"a_key_%03d_2\"\n", objList[currobj.link].link & 0x3F);
			fprintf (MAPFILE, "\"used_by3\" \"a_key_%03d_3\"\n", objList[currobj.link].link & 0x3F);
			fprintf (MAPFILE, "\"used_by4\" \"a_key_%03d_4\"\n", objList[currobj.link].link & 0x3F);
			fprintf (MAPFILE, "\"used_by5\" \"a_key_%03d_5\"\n", objList[currobj.link].link & 0x3F);
			}
		else
		{
			fprintf(MAPFILE, "\"locked\" \"%d\"\n", 1);
			if ((currobj.link > 0) && (currobj.link <= 11))	//Only this many keycards
				{
				char *strKeyName = getObjectNameByClass(GETTABLES_OTHER, 4, currobj.link);
				fprintf(MAPFILE, "\"used_by\" \"%s_0\"\n", strKeyName);
				fprintf(MAPFILE, "\"used_by1\" \"%s_1\"\n", strKeyName);
				fprintf(MAPFILE, "\"used_by2\" \"%s_2\"\n", strKeyName);
				fprintf(MAPFILE, "\"used_by3\" \"%s_3\"\n", strKeyName);
				fprintf(MAPFILE, "\"used_by4\" \"%s_4\"\n", strKeyName);
				fprintf(MAPFILE, "\"used_by5\" \"%s_5\"\n", strKeyName);
				}
			}
		}

	fprintf (MAPFILE, "\"rotate\" \"0 90 0\"\n");		
	//position
	int heading = 0;
	if (game != SHOCK)
		{
			heading = currobj.heading;
		}
		else
		{
			heading = currobj.Angle2;
		}

		switch (heading)
			{//TODO: replace with proper model offset
			case SHOCK_EAST:
			case EAST:
				{fprintf (MAPFILE, "\"origin\" \"%f %f %f\"\n",x,(tileY)*BrushY + ( (doorWidth+(BrushY-doorWidth)/2 ) ),zpos);	break;}
			case SHOCK_WEST:
			case WEST:
				{fprintf (MAPFILE, "\"origin\" \"%f %f %f\"\n",x,(tileY)*BrushY + ( (0+(BrushY-doorWidth)/2 ) ),zpos);	break;}
			case SHOCK_NORTH:
			case NORTH:
				{fprintf (MAPFILE, "\"origin\" \"%f %f %f\"\n",(tileX)*BrushX + ( (doorWidth+(BrushX-doorWidth)/2 ) ),y,zpos);	break;}
			case SOUTH:
				{fprintf (MAPFILE, "\"origin\" \"%f %f %f\"\n",(tileX)*BrushX + ( (0+(BrushX-doorWidth)/2 ) ),y,zpos);	break;}
			}
		

	tile t = LevelInfo[currobj.tileX][currobj.tileY];
	if (game != SHOCK)
	{
		EntityRotation(currobj.heading);
	}
	else
	{
		if (objectMasters[currobj.item_id].type != HIDDENDOOR)
		{
			EntityRotationSHOCK(currobj.Angle2);
		}
	}
	
	if (objectMasters[currobj.item_id].type == HIDDENDOOR)
		{//For a secret door I need to render a brush to match the wall
		fprintf (MAPFILE, "\"model\" \"%s_%03d_%03d\"\n",objectMasters[currobj.item_id].desc,currobj.tileX,currobj.tileY);
		int heading = 0;
		if (game != SHOCK)
			{
			heading = currobj.heading;
			}
		else
			{
			heading = currobj.Angle2;
			}

		switch (heading)
			{
			case EAST:
			case SHOCK_EAST:
				fprintf (MAPFILE, "// primitive %d\n",0);
				fprintf (MAPFILE, "{\nbrushDef3\n{\n");
				//east face 
				fprintf (MAPFILE, "( 1 0 0 %d )",-(3));
				getWallTextureName(t,fEAST,0);
				//north face 
				fprintf (MAPFILE, "( 0 1 0 %d )",-(0));
				getWallTextureName(t,fNORTH,0);
				//top face
				fprintf (MAPFILE, "( 0 0 1 %f )", -doorHeight );	
				getFloorTextureName(t,fTOP);
				//west face
				fprintf (MAPFILE, "( -1 0 0 %d )", -(3));
				getWallTextureName(t,fWEST,0);
				//south face
				fprintf (MAPFILE, "( 0 -1 0 %f )", -(doorWidth));
				getWallTextureName(t, fSOUTH,0);
				//bottom face
				fprintf (MAPFILE, "( 0 0 -1 %d )", 0);	
				getFloorTextureName(t, fBOTTOM);
				break;
			case WEST:
			case SHOCK_WEST:
				fprintf (MAPFILE, "// primitive %f\n",0);
				fprintf (MAPFILE, "{\nbrushDef3\n{\n");
				//east face 
				fprintf (MAPFILE, "( 1 0 0 %d )",-(3));
				getWallTextureName(t,fEAST,0);
				//north face 
				fprintf (MAPFILE, "( 0 1 0 %f )",-(doorWidth));
				getWallTextureName(t,fNORTH,0);
				//top face
				fprintf (MAPFILE, "( 0 0 1 %f )", -doorHeight );	
				getFloorTextureName(t,fTOP);
				//west face
				fprintf (MAPFILE, "( -1 0 0 %d )", -(3));
				getWallTextureName(t,fWEST,0);
				//south face
				fprintf (MAPFILE, "( 0 -1 0 %d )", -(0));
				getWallTextureName(t, fSOUTH,0);
				//bottom face
				fprintf (MAPFILE, "( 0 0 -1 %d )", 0);	
				getFloorTextureName(t, fBOTTOM);
				break;
			case NORTH:
			case SHOCK_NORTH:
				fprintf (MAPFILE, "// primitive %f\n",0);
				fprintf (MAPFILE, "{\nbrushDef3\n{\n");
				//east face 
				fprintf (MAPFILE, "( 1 0 0 %d )",-(0));
				getWallTextureName(t,fEAST,0);
				//north face 
				fprintf (MAPFILE, "( 0 1 0 %d )",-(3));
				getWallTextureName(t,fNORTH,0);
				//top face
				fprintf (MAPFILE, "( 0 0 1 %f )", -doorHeight );	
				getFloorTextureName(t,fTOP);
				//west face
				fprintf (MAPFILE, "( -1 0 0 %f )", -(doorWidth));
				getWallTextureName(t,fWEST,0);
				//south face
				fprintf (MAPFILE, "( 0 -1 0 %d )", -(3));
				getWallTextureName(t, fSOUTH,0);
				//bottom face
				fprintf (MAPFILE, "( 0 0 -1 %d )", 0);	
				getFloorTextureName(t, fBOTTOM);
				break;
			case SOUTH:
			//case SHOCK_SOUTH:
				{
				fprintf (MAPFILE, "// primitive %f\n",0);
				fprintf (MAPFILE, "{\nbrushDef3\n{\n");
				//east face 
				fprintf (MAPFILE, "( 1 0 0 %f )",-(doorWidth));
				getWallTextureName(t,fEAST,0);
				//north face 
				fprintf (MAPFILE, "( 0 1 0 %d )",-(3));
				getWallTextureName(t,fNORTH,0);
				//top face
				fprintf (MAPFILE, "( 0 0 1 %f )", -doorHeight );	
				getFloorTextureName(t,fTOP);
				//west face
				fprintf (MAPFILE, "( -1 0 0 %d )", +(0));
				getWallTextureName(t,fWEST,0);
				//south face
				fprintf (MAPFILE, "( 0 -1 0 %d )", -(3));
				getWallTextureName(t, fSOUTH,0);
				//bottom face
				fprintf (MAPFILE, "( 0 0 -1 %d )", 0);	
				getFloorTextureName(t, fBOTTOM);
				break;
				}	

			}
			fprintf (MAPFILE, "}\n}\n");
		}
	fprintf (MAPFILE, "}");		
	EntityCount++;
	if ((currobj.link !=0) || (currobj.SHOCKLocked >0))
		{	//if it has a lock it needs a lock object for scripting purposes
		fprintf (MAPFILE, "\n// entity %d\n{\n",EntityCount);
		fprintf(MAPFILE, "\"classname\" \"%s\"\n", "atdm:target_changelockstate");
		//A lock trap object for opening doors.
		fprintf (MAPFILE, "\"name\" \"a_lock_%03d_%03d\"\n",currobj.tileX, currobj.tileY);
		fprintf (MAPFILE, "\"target\" \"%s_%03d_%03d\"\n", objectMasters[currobj.item_id].desc,currobj.tileX  ,currobj.tileY );
		fprintf (MAPFILE, "\"toggle\" \"1\"\n");	//todo: other types of behaviour.
		fprintf (MAPFILE, "\"origin\" \"%f %f %f\"\n",x,y,z);	
		fprintf (MAPFILE, "}");
		EntityCount++;	
		}
		return;
}

void setKeyCount(int game, tile LevelInfo[64][64], ObjectItem objList[1600])
{
	//Each keey needs a unique name in game. Here we set the key index number on the key so that will work properly for scripting and map generation
	int currobj;

	for (int x = 0; x < 64; x++)
	{
		for (int y = 0; y < 64; y++)
		{
			if (LevelInfo[x][y].indexObjectList != 0)
			{
				currobj = LevelInfo[x][y].indexObjectList;
				do
				{
					if (objectMasters[objList[currobj].item_id].type == KEY)
					{
						if (game == SHOCK)
						{
							keycount[objList[currobj].ObjectSubClassIndex]++;
							objList[currobj].keyCount = keycount[objList[currobj].ObjectSubClassIndex];
							printf("%s", UniqueObjectName(objList[currobj]));
						}
						else
						{
							keycount[objList[currobj].owner]++; 
							objList[currobj].keyCount = keycount[objList[currobj].owner];
						}
					}
					currobj = objList[currobj].next;
				} while (currobj > 0);
			}
		}

	}


}

void RenderEntityKey (int game, float x, float y, float z, ObjectItem &currobj, ObjectItem objList[1600], tile LevelInfo[64][64])
{
	//Creates a key. Each key is uniquely named based on a counter. Doors will have a list of potential matching key names to work with keys.
//Params
//Item_id
//Owner

	//A key's owner id matches it's lock link id.
	fprintf (MAPFILE, "\n// entity %d\n{\n",EntityCount);
	fprintf (MAPFILE, "\"classname\" \"%s\"\n", objectMasters[currobj.item_id].path);
	if (game != SHOCK)
	{
		//fprintf(MAPFILE, "\"name\" \"%s_%03d_%d\"\n", objectMasters[currobj.item_id].desc, currobj.owner, keycount[currobj.owner]++);
		fprintf(MAPFILE, "\"name\" \"%s_%03d_%d\"\n", objectMasters[currobj.item_id].desc, currobj.owner, currobj.keyCount);
	}
	else
	{
		//fprintf(MAPFILE, "\"name\" \"%s_%d\"\n", objectMasters[currobj.item_id].desc, keycount[currobj.ObjectSubClassIndex]++);
		fprintf(MAPFILE, "\"name\" \"%s_%d\"\n", objectMasters[currobj.item_id].desc, currobj.keyCount);
	}

	//they also need the following properties
	fprintf (MAPFILE, "\"usable\" \"1\"\n\"frobable\" \"1\"\n\"inv_name\" \"%s\"\n\"inv_target\" \"player1\"\n\"inv_stackable\" \"1\"\n\"inv_category\" \"Keys\"\n", objectMasters[currobj.item_id].desc);
	//position
	fprintf (MAPFILE, "\"origin\" \"%f %f %f\"\n",x,y,z);
	fprintf(MAPFILE, "\"hide\" \"%d\"\n", currobj.invis);
	EntityRotation(currobj.heading);	
	AttachToJoint(currobj);		
	fprintf (MAPFILE, "}");
	EntityCount++;	
	return;
}

void RenderEntityContainer (int game, float x, float y, float z, ObjectItem &currobj, ObjectItem objList[1600], tile LevelInfo[64][64])
{
	//Creates something that holds objects. Current behaviour is to spawn objects at various spawn points surrounding the object.
//Params.
//Item_id
//link	//To check for a lock and it's list of contents.

	if (game != SHOCK)
	{
		fprintf(MAPFILE, "\n// entity %d\n{\n", EntityCount);
		fprintf(MAPFILE, "\"classname\" \"%s\"\n", "func_static");
		fprintf(MAPFILE, "\"model\" \"%s\"\n", objectMasters[currobj.item_id].path);
		//I need to spawn it's contents at the same location (recursively)
		//render it first.
		//TODO: I also need to fix containers which are not really entities
		fprintf(MAPFILE, "\"name\" \"%s_%03d\"\n", objectMasters[currobj.item_id].desc, EntityCount);
		if (objectMasters[objList[currobj.link].item_id].type == LOCK)	//container has a lock.
			{//bit 1 of the flags is the lock?
			fprintf(MAPFILE, "\"locked\" \"%d\"\n", (objList[currobj.link].flags & 0x01));
			fprintf(MAPFILE, "\"used_by\" \"a_key_%03d_0\"\n", objList[currobj.link].link & 0x3F);
			fprintf(MAPFILE, "\"used_by1\" \"a_key_%03d_1\"\n", objList[currobj.link].link & 0x3F);
			fprintf(MAPFILE, "\"used_by2\" \"a_key_%03d_2\"\n", objList[currobj.link].link & 0x3F);
			fprintf(MAPFILE, "\"used_by3\" \"a_key_%03d_3\"\n", objList[currobj.link].link & 0x3F);
			fprintf(MAPFILE, "\"used_by4\" \"a_key_%03d_4\"\n", objList[currobj.link].link & 0x3F);
			fprintf(MAPFILE, "\"used_by5\" \"a_key_%03d_5\"\n", objList[currobj.link].link & 0x3F);
			}				
		//position
		printf("\"origin\" \"%f %f %f\"\n",x,y,z);
		fprintf(MAPFILE, "\"hide\" \"%d\"\n", currobj.invis);
		AttachToJoint(currobj);			
		printf("}");
		EntityCount++;

		//now recursively get it's contents.
		if (currobj.link !=0)	//Container has objects
			{
			ObjectItem tmpobj = objList[currobj.link];		
			while( tmpobj.next  !=0 )
				{
				RenderEntity(game,x,y,z,tmpobj,objList,LevelInfo);
				tmpobj = objList[tmpobj.next];
				}
			RenderEntity(game,x,y,z,tmpobj,objList,LevelInfo);
			}			
		return;
		}
	else
	{
		//Shock container. contents are different from uw1
		fprintf(MAPFILE, "\n// entity %d\n{\n", EntityCount++);
		fprintf(MAPFILE, "\"classname\" \"%s\"\n", "func_static");
		fprintf(MAPFILE, "\"model\" \"%s\"\n", objectMasters[currobj.item_id].path);
		fprintf(MAPFILE, "\"name\" \"%s\"\n", UniqueObjectName(currobj));
		fprintf(MAPFILE, "\"origin\" \"%f %f %f\"\n", x, y, z);
		fprintf(MAPFILE, "\"hide\" \"%d\"\n", currobj.invis);
		if (hasContents(currobj))
		{
			fprintf(MAPFILE, "\"grabable\" \"%d\"\n", 0);
			fprintf(MAPFILE, "\"frobable\" \"%d\"\n", 1);
			fprintf(MAPFILE, "\"frob_action_script\" \"start_%s\"\n", UniqueObjectName(currobj));
		}
		
		fprintf(MAPFILE, "}");

		if (hasContents(currobj))
			{
				//createScriptCall(currobj, x, y, z);

			//create 4 spawn points around the container to spawn the contents at.
			int offX = 10; int offY = 10;
			for (int i = 0; i < 4; i++)
			{
				switch (i)
				{
				case 0: offX = 10; offY = 10; break;
				case 1: offX = -10; offY = 10; break;
				case 2: offX = 10; offY = -10; break;
				case 3: offX = -10; offY = -10; break;
				}

				if (currobj.shockProperties[CONTAINER_CONTENTS_1 + i] != 0)
				{
					fprintf(MAPFILE, "\n// entity %d\n{\n", EntityCount++);
					fprintf(MAPFILE, "\"classname\" \"%s\"\n", "target_null");
					fprintf(MAPFILE, "\"name\" \"%s_spawnpoint_%d\"\n", UniqueObjectName(currobj), i);
					fprintf(MAPFILE, "\"origin\" \"%f %f %f\"\n", x + offX, y + offY, z);
					fprintf(MAPFILE, "}");
				}
			}
		}
	}
}

void RenderEntityCorpse(int game, float x, float y, float z, ObjectItem &currobj, ObjectItem objList[1600], tile LevelInfo[64][64])
{
	//Some corpses will have inventories. For these we have spawn points that behave just like containers.
	//Params.
	//Item_id
	//link	//To check for a lock and it's list of contents.

	if (game == SHOCK)
	{
		fprintf(MAPFILE, "\n// entity %d\n{\n", EntityCount++);//"atdm:mover_button"
		fprintf(MAPFILE, "\"classname\" \"%s\"\n", objectMasters[currobj.item_id].path);
		//fprintf(MAPFILE, "\"model\" \"%s\"\n", objectMasters[currobj.item_id].path);
		fprintf(MAPFILE, "\"name\" \"%s\"\n", UniqueObjectName(currobj));
		fprintf(MAPFILE, "\"origin\" \"%f %f %f\"\n", x, y, z);
		fprintf(MAPFILE, "\"hide\" \"%d\"\n", currobj.invis);
		if (hasContents(currobj))
		{
			fprintf(MAPFILE, "\"grabable\" \"%d\"\n", 0);
			fprintf(MAPFILE, "\"frobable\" \"%d\"\n", 1);
			fprintf(MAPFILE, "\"frob_action_script\" \"start_%s\"\n", UniqueObjectName(currobj));
		}
		fprintf(MAPFILE, "}");

		if (hasContents(currobj))
			{
					//createScriptCall(currobj, x, y, z);

			//create 4 spawn points around the container to spawn the contents at.
			int offX = 10; int offY = 10;
			for (int i = 0; i < 4; i++)
			{
				switch (i)
				{
				case 0: offX = 10; offY = 10; break;
				case 1: offX = -10; offY = 10; break;
				case 2: offX = 10; offY = -10; break;
				case 3: offX = -10; offY = -10; break;
				}

				if (currobj.shockProperties[CONTAINER_CONTENTS_1 + i] > 0)
				{
					fprintf(MAPFILE, "\n// entity %d\n{\n", EntityCount++);
					fprintf(MAPFILE, "\"classname\" \"%s\"\n", "target_null");
					fprintf(MAPFILE, "\"name\" \"%s_spawnpoint_%d\"\n", UniqueObjectName(currobj), i);
					fprintf(MAPFILE, "\"origin\" \"%f %f %f\"\n", x + offX, y + offY, z);
					fprintf(MAPFILE, "}");
				}
			}
		}
	}
}



void RenderEntityButton(int game, float x, float y, float z, ObjectItem &currobj, ObjectItem objList[1600], tile LevelInfo[64][64])
{
	//
	//Params
	//item_id
	//tileX
	//tileY
	//index
	//heading
	//Need to pass desc/path for generic handling
	fprintf(MAPFILE, "\n// entity %d\n{\n", EntityCount);
	fprintf(MAPFILE, "\"classname\" \"%s\"\n", "atdm:mover_button");
	fprintf(MAPFILE, "\"name\" \"%s\"\n", UniqueObjectName(currobj));
	//fprintf (MAPFILE, "\"model\" \"models/darkmod/mechanical/switches/switch_flip.ase\"\n");	//TODO:Need to pass this in from config
	fprintf(MAPFILE, "\"model\" \"%s\"\n",objectMasters[currobj.item_id].path);
	//position
	fprintf (MAPFILE, "\"origin\" \"%f %f %f\"\n",x,y,z);	
	fprintf (MAPFILE, "\"rotate\" \"0 0 1\"\n");
	fprintf (MAPFILE, "\"interruptable\" \"0\"\n");

	fprintf(MAPFILE, "\"hide\" \"%d\"\n",currobj.invis);
	
	fprintf (MAPFILE, "\"target\" \"runscript_%s\"\n", UniqueObjectName(currobj));
	if (game == SHOCK)
		{//gui related settings. Sets the gui that controls the 2d animation of this switch.
		fprintf(MAPFILE, "\"gui\" \"guis/shock/switch_%d_%d_%d.gui\"\n",currobj.ObjectClass,currobj.ObjectSubClass,currobj.ObjectSubClassIndex);
		fprintf(MAPFILE, "\"gui_parm1\" \"0\"\n", currobj.ObjectClass, currobj.ObjectSubClass, currobj.ObjectSubClassIndex);
		EntityRotationSHOCK(currobj.Angle2);
		}
	else
	{
		EntityRotation(currobj.heading);
	}
	fprintf (MAPFILE, "}\n");EntityCount++;
	createScriptCall(currobj,x,y,z);	//To run whatever actions this switch performs.
	return;
}

void RenderEntityA_DOOR_TRAP (int game, float x, float y, float z, ObjectItem &currobj, ObjectItem objList[1600], tile LevelInfo[64][64])
{//Is this in use?
//A door trap object for opening doors.
//Params
//objectOwnerName (passed down from a parent object)
//objectOwner
//tileX
//tileY
//Need to add path for generic usage.

		fprintf (MAPFILE, "\n// entity %d\n{\n",EntityCount);
		fprintf (MAPFILE, "\"classname\" \"%s\"\n", objectMasters[currobj.item_id].path);
		fprintf (MAPFILE, "\"name\" \"door_%03d_%03d\"\n",currobj.objectOwner, currobj.objectOwnerName);
		fprintf (MAPFILE, "\"target\" \"door_%03d_%03d\"\n", currobj.tileX  ,currobj.tileY );	//Doors are refered to by their tile location.
		fprintf (MAPFILE, "\"toggle\" \"1\"\n");	//todo: other types of behaviour.
		fprintf (MAPFILE, "\"origin\" \"%f %f %f\"\n",x,y,z);	
		fprintf (MAPFILE, "}");
		EntityCount++;	
		return;
}

void RenderEntityA_DO_TRAP (int game, float x, float y, float z, ObjectItem &currobj, ObjectItem objList[1600], tile LevelInfo[64][64])
{
	//This is a trigger in UW that can do a bunch of different things. Eg cameras/rising platforms.
	switch (currobj.quality )
		{
		case 2: //A camera	
			fprintf (MAPFILE, "\n// entity %d\n{\n",EntityCount);
			fprintf (MAPFILE, "\"classname\" \"func_cameraview\"\n");
			fprintf (MAPFILE, "\"name\" \"%s_%03d_%03d\"\n",objectMasters[currobj.item_id].desc ,currobj.tileX,currobj.tileY);
			fprintf (MAPFILE, "\"origin\" \"%f %f %f\"\n",x,y,z);	
			fprintf (MAPFILE, "\"trigger\" \"1\"\n");
			//Aim the camera.
			EntityRotation(currobj.heading);//TODO:Points in wrong direction
			fprintf (MAPFILE, "\n}");
			EntityCount++;
			break;
		case 3:	//rising platform
			RenderEntityElevator(game,LevelInfo,currobj);
			break;
		}
		return;
}


void RenderEntityA_CHANGE_TERRAIN_TRAP (int game, float x, float y, float z, ObjectItem &currobj, ObjectItem objList[1600], tile LevelInfo[64][64])
{
//
//A trigger that converts one type of terrain into another.
//We generate both types of terrain at the start but hide the second type until the trigger is activated.
	//render func static for the initial tiles.
	PrimitiveCount=0;
	int tileCount =0;
	for (int i=0;i<=currobj.x;i++)
		{
		for(int j=0;j<=currobj.y;j++)
			{

			fprintf (MAPFILE, "\n// entity %d\n{\n",EntityCount++);
			fprintf (MAPFILE, "\"classname\" \"%s\"\n", objectMasters[currobj.item_id].path);
			//TODO:There is some weirdness when I try and hide water. For now I'll just ignore it.
			//if (LevelInfo[currobj.tileX+i][currobj.tileY+j].isWater == 0)
			//	{
				//fprintf (MAPFILE, "\"name\" \"%s_initial_%03d_%03d_%03d_%03d\"\n",objectMasters[currobj.item_id].desc,currobj.tileX,currobj.tileY,currobj.index,tileCount);
			fprintf (MAPFILE, "\"name\" \"initial_%s_%03d\"\n", UniqueObjectName(currobj),tileCount);				
			//	}
			//else
			//	{//water
			//	fprintf (MAPFILE, "\"name\" \"%s_initial_%03d_%03d_%03d_%03d\"\n",objectMasters[currobj.item_id].desc,currobj.tileX,currobj.tileY,currobj.index,tileCount);
		//		fprintf (MAPFILE, "\n\"underwater_gui\" \"guis\underwater\underwater_green_thinmurk.gui\"\n");
	//			}
			fprintf (MAPFILE, "\"model\" \"initial_%s_%03d\"\n",UniqueObjectName(currobj),tileCount);
			fprintf (MAPFILE, "\"origin\" \"%d %d %d\"\n",(currobj.tileX+i)*BrushSizeX,(currobj.tileY+j)*BrushSizeY,0);														
			RenderDarkModTile(game,0,0,LevelInfo[currobj.tileX+i][currobj.tileY+j],LevelInfo[currobj.tileX+i][currobj.tileY+j].isWater,0,0,0);
			fprintf (MAPFILE, "\n}\n");
			tileCount++;
			}
		}
	
	
	//Then render a func static for how it ends up.
	PrimitiveCount=0;
	fprintf (MAPFILE, "\n// entity %d\n{\n",EntityCount++);
	fprintf (MAPFILE, "\"classname\" \"%s\"\n", objectMasters[currobj.item_id].path);
	fprintf (MAPFILE, "\"name\" \"final_%s\"\n",UniqueObjectName(currobj));
	fprintf (MAPFILE, "\"model\" \"final_%s\"\n",UniqueObjectName(currobj));
	fprintf (MAPFILE, "\"origin\" \"%d %d %d\"\n",currobj.tileX*BrushSizeX,currobj.tileY*BrushSizeY,0);
	
	for (int i=0;i<=currobj.x;i++)
		{
		for(int j=0;j<=currobj.y;j++)
			{
			tile t;	//temporary tile for rendering.
			t.tileType = currobj.quality & 0x01;
			t.Render= 1;
			t.floorHeight  = currobj.zpos>>3;	//heights in uw are shifted
			t.floorTexture = (currobj.quality >>1)+210;
			t.wallTexture = LevelInfo[i][j].wallTexture;
			t.West =LevelInfo[i][j].wallTexture;//LevelInfo[i][j].West;
			t.East =LevelInfo[i][j].wallTexture;//LevelInfo[i][j].East;
			t.North =LevelInfo[i][j].wallTexture;//LevelInfo[i][j].North;
			t.South =LevelInfo[i][j].wallTexture;//LevelInfo[i][j].South ;
			t.isWater =0;
			t.DimY=1;
			t.DimX=1;
			t.hasElevator=0;
			RenderDarkModTile(game,i,j,t,0,0,0,0);
			}
		}
	fprintf (MAPFILE, "\n}\n");
	return;
}

void RenderEntityTMAP (int game, float x, float y, float z, ObjectItem &currobj, ObjectItem objList[1600], tile LevelInfo[64][64])
{//Flat patch objects used as decals. This should be changed into something like a SHOCK screen model?
//params
//link	to see if it can be activated
//tileX
//tileY
//index
	fprintf (MAPFILE, "\n// entity %d\n{\n",EntityCount);
	if( isTrigger(objList[currobj.link])==0)
		{
		fprintf (MAPFILE, "\"classname\" \"%s\"\n", objectMasters[currobj.item_id].path);
		}
	else
		{
		//object is a trigger
		fprintf (MAPFILE, "\"classname\" \"%s\"\n", "atdm:mover_button");	//TODO:Is there something better I can use than this.
		fprintf (MAPFILE, "\"target\" \"runscript_%s\"\n",UniqueObjectName(currobj));	
		}
	fprintf (MAPFILE, "\"name\" \"%s\"\n",UniqueObjectName(currobj));
	fprintf (MAPFILE, "\"model\" \"%s\"\n",UniqueObjectName(currobj));
	fprintf (MAPFILE, "\"origin\" \"%f %f %f\"\n",x,y,z);
	fprintf(MAPFILE, "\"hide\" \"%d\"\n", currobj.invis);
	RenderPatch(game,currobj.tileX,currobj.tileY ,currobj.zpos,currobj.index,objList);
	fprintf (MAPFILE, "\n}\n");
	EntityCount++;
	if( isTrigger(objList[currobj.link])==1)
		{
		createScriptCall(currobj,x,y,z);
		}
	return;
}

void RenderEntityBOOK(int game, float x, float y, float z, short message, ObjectItem &currobj, ObjectItem objList[1600], tile LevelInfo[64][64])
{

	//A book in UW and an audio log/text in Shock. Xdata is generated in advance based on game files.
//Params
//tileX
//tileY
//Index
//currobj.link -200 = pointer to the readable string block in UW
//heading
int ReadableIndex;
switch (game)
	{
	case SHOCK: 
		ReadableIndex =currobj.shockProperties[SOFT_PROPERTY_LOG];	//currobj.Property1;	//The chunk that the text comes from.
		break;
	default:
		ReadableIndex = currobj.link-0x200;
		break;
	}
	fprintf(MAPFILE, "\n// entity %d\n{\n", EntityCount);

	if (message == 1)//atdm:readable_mobile_scroll01
		{//This is a hidden email OR MESSAGE
		fprintf(MAPFILE, "\"classname\" \"%s\"\n", "atdm:readable_mobile_scroll01");
		fprintf(MAPFILE, "\"name\" \"%s_email\"\n", UniqueObjectName(currobj));
		fprintf(MAPFILE, "\"hide\" \"1\"\n");
		}
	else
		{
		fprintf(MAPFILE, "\"classname\" \"%s\"\n", objectMasters[currobj.item_id].path);
		fprintf(MAPFILE, "\"name\" \"%s\"\n", UniqueObjectName(currobj));
		}
	fprintf(MAPFILE, "\"inv_name\" \"Readable_%d\"\n", ReadableIndex);	//Need a better name than this!
	switch (game)
		{
		case UWDEMO:
		case UW1:
			{fprintf (MAPFILE, "\"xdata_contents\" \"readables/uw1/scroll_%03d\"\n", ReadableIndex);break;}
		case UW2:
			{fprintf (MAPFILE, "\"xdata_contents\" \"readables/uw2/scroll_%03d\"\n", ReadableIndex);break;}
		case SHOCK:
			{
			fprintf (MAPFILE, "\"xdata_contents\" \"readables/shock/log_%03d\"\n",ReadableIndex);
			if (message == 0)
				{//plays the audio of this log
					fprintf(MAPFILE, "\"trigger_on_open\" \"runscript_%s\"\n", UniqueObjectName(currobj));
				}	
			else
				{
					fprintf(MAPFILE, "\"trigger_on_open\" \"runscript_%s_email\"\n", UniqueObjectName(currobj));
				}
			break;
			}
		}	
	fprintf (MAPFILE, "\"origin\" \"%f %f %f\"\n",x,y,z);	
	EntityRotation(currobj.heading);
	AttachToJoint(currobj);		//for npc items
	fprintf (MAPFILE, "}");
	EntityCount++;
	if (game == SHOCK)
	{
		if (message == 0)
			{
				createScriptCall(currobj, x, y, z);
			}
		else
			{
			//char str[80]; 
			//sprintf_s(str, "runscript_%s_email", UniqueObjectName(currobj));
			createScriptCall(currobj, x, y, z,"email");
			}
		}
	return;
}

void RenderEntitySIGN (int game, float x, float y, float z, ObjectItem &currobj, ObjectItem objList[1600], tile LevelInfo[64][64])
{
	//A flat object with a gui that is a readable.
//Params
//tileX
//tileY
//Index
//currobj.link -200 = pointer to the readable string block in UW
//heading

	fprintf (MAPFILE, "\n// entity %d\n{\n",EntityCount);
	fprintf (MAPFILE, "\"classname\" \"%s\"\n", objectMasters[currobj.item_id].path);
	fprintf (MAPFILE, "\"name\" \"%s\"\n",UniqueObjectName(currobj));		
	fprintf(MAPFILE, "\"hide\" \"%d\"\n", currobj.invis);
	//fprintf (MAPFILE, "\"xdata_contents\" \"readables/uw1/sign_%03d\"\n", currobj.link - 0x200);
	switch (game)
		{
		case UWDEMO:
		case UW1:
			{fprintf (MAPFILE, "\"xdata_contents\" \"readables/uw1/sign_%03d\"\n", currobj.link - 0x200);break;}
		case UW2:
			{fprintf (MAPFILE, "\"xdata_contents\" \"readables/uw12/sign_%03d\"\n", currobj.link - 0x200);break;}
		case SHOCK:
			{//TODO:Whatever needs to go here.
			//fprintf (MAPFILE, "\"xdata_contents\" \"readables/shock/sign_%03d\"\n", currobj.link - 0x200);
			break;}
		}		
	fprintf (MAPFILE, "\"origin\" \"%f %f %f\"\n",x,y,z);	
	fprintf (MAPFILE, "\"model\" \"models/darkmod/uw1/uw1_sign.ase\"\n");	//TODO:pass model path in.
	switch (currobj.heading)	//TODO: need to fix this mess with headings.
		{
		case 0:
			{EntityRotation(270);break;}
		case 270:
			{EntityRotation(0);break;}
		default:
			{EntityRotation(currobj.heading+90);break;}
		}
	//EntityRotation(currobj.heading);
	AttachToJoint(currobj);		//for npc items
	fprintf (MAPFILE, "\n}");
	EntityCount++;
	return;
}

void RenderEntityA_TELEPORT_TRAP (int game, float x, float y, float z, ObjectItem &currobj, ObjectItem objList[1600], tile LevelInfo[64][64]) 
{
//This is the destination spot of a teleport.
//zpos = this level
//item_id for type
//quality = x coord of destination
//owner = y coord of destination
//need to add objectmaster path for generic usage.

	//only show if it points to this level.
	if (currobj.zpos == 0)
		{
		fprintf (MAPFILE, "\n// entity %d\n{\n",EntityCount);
		fprintf (MAPFILE, "\"classname\" \"%s\"\n", objectMasters[currobj.item_id].path);
		fprintf (MAPFILE, "\"name\" \"%s\"\n",UniqueObjectName(currobj));	
		fprintf (MAPFILE, "\"origin\" \"%d %d %d\"\n",currobj.quality * BrushSizeX+(BrushSizeX/2),currobj.owner * BrushSizeY+(BrushSizeY/2), LevelInfo[currobj.quality][currobj.owner].floorHeight * BrushSizeZ);	
		fprintf (MAPFILE, "\n}");		
		}
	return;
}

void RenderEntityA_MOVE_TRIGGER (int game, float x, float y, float z, ObjectItem &currobj, ObjectItem objList[1600], tile LevelInfo[64][64])
{
//A trigger that fires when you step in it.
//Params
//item_id
//index
//tileX
//tileY
//need to add objectmaster path for generic usage
//need to add objectmaster desc for generic usage

	fprintf (MAPFILE, "\n// entity %d\n{\n",EntityCount++);
	fprintf (MAPFILE, "\"classname\" \"%s\"\n", objectMasters[currobj.item_id].path);
	fprintf (MAPFILE, "\"name\" \"%s\"\n",UniqueObjectName(currobj));	
	fprintf (MAPFILE, "\"model\" \"%s\"\n",UniqueObjectName(currobj) );	
	fprintf (MAPFILE, "\"target\" \"runscript_%s\"\n",UniqueObjectName(currobj));						
	fprintf (MAPFILE, "\"wait\" \"5\"\n");						
	tile t;	//temp tile for rendering trigger
	t.floorTexture = TRIGGER_MULTI;
	t.wallTexture = TRIGGER_MULTI;	
	t.East =TRIGGER_MULTI;
	t.West =TRIGGER_MULTI;
	t.North =TRIGGER_MULTI;
	t.South =TRIGGER_MULTI;
	t.DimX =1; t.DimY=1;
	t.tileType =1;
	t.Render=1;
	t.floorHeight = 0;	
	t.ceilingHeight =CEILING_HEIGHT;
	t.isWater=0;
	t.hasElevator=0;
	if (game == SHOCK)
		{	//enter tile behaviour.
		RenderGenericTile(currobj.tileX,currobj.tileY,t,CEILING_HEIGHT,0 );
		}
	else
		{	//step on behaviour
		RenderGenericTile(currobj.tileX,currobj.tileY,t,BrushSizeZ,LevelInfo[currobj.tileX][currobj.tileY].floorHeight );
		}
	fprintf (MAPFILE, "\n}");
	createScriptCall(currobj,x,y,z);	
}


void RenderEntityREPULSOR (int game, float x, float y, float z, ObjectItem &currobj, ObjectItem objList[1600], tile LevelInfo[64][64])
{
//A thing that lifts you up.
//Current repulsor theory.
// value (int8) at offset 21d of the subclass table is the target height (if not set then it's up to the ceiling)
// value (int8) at offset 24d of the subclass table is for direction. 0 is for going up. 1 is for pushing down
// value (int8) at offset 22d of the subclass table is for flags?

//Params
//item_id
//index
//tileX
//tileY
//need to add objectmaster path for generic usage
//need to add objectmaster desc for generic usage
//Need to revisit repulsors.Perhaps a chain of repulsors all the way up that I set on/off dynamically?
	fprintf (MAPFILE, "\n// entity %d\n{\n",EntityCount++);
	fprintf (MAPFILE, "\"classname\" \"%s\"\n", objectMasters[currobj.item_id].path);
	fprintf (MAPFILE, "\"name\" \"repulsor_%s\"\n",UniqueObjectName(currobj));	
	fprintf (MAPFILE, "\"model\" \"repulsor_%s\"\n",UniqueObjectName(currobj));
	fprintf (MAPFILE, "\"target0\" \"repulsor_%s_target\"\n",UniqueObjectName(currobj));	
	//int originZ = (CEILING_HEIGHT - LevelInfo[currobj.tileX][currobj.tileY].ceilingHeight) - LevelInfo[currobj.tileX][currobj.tileY].floorHeight- 8;
	int originZ = (currobj.State >> 3) * BrushSizeZ - LevelInfo[currobj.tileX][currobj.tileY].floorHeight;
	fprintf(MAPFILE, "\"origin\" \"%f %f %d\"\n", x, y, (originZ/2));
	fprintf (MAPFILE, "\"applyVelocity\" \"1\"\n");	
	fprintf (MAPFILE, "\"start_on\" \"1\"\n");	
	tile t;	//temp tile for rendering trigger
	t.floorTexture = CAULK;
	t.wallTexture = CAULK;	
	t.East =CAULK;
	t.West =CAULK;
	t.North =CAULK;
	t.South =CAULK;
	t.DimX =1; t.DimY=1;
	t.tileType =1;
	t.Render=1;
	t.floorHeight = LevelInfo[currobj.tileX][currobj.tileY].floorHeight ;	
	t.ceilingHeight =CEILING_HEIGHT - LevelInfo[currobj.tileX][currobj.tileY].ceilingHeight -4;
	t.isWater=0;
	t.hasElevator=0;
	RenderGenericTileAroundOrigin(0,0,t,t.ceilingHeight,t.floorHeight,originZ);
	//RenderGenericTile(0,0,t,t.ceilingHeight,t.floorHeight );

	fprintf (MAPFILE, "\n}");
	//Now create a target for it.
	fprintf (MAPFILE, "\n// entity %d\n{\n",EntityCount++);
	fprintf (MAPFILE, "\"classname\" \"target_null\"\n", objectMasters[currobj.item_id].path);
	fprintf (MAPFILE, "\"name\" \"repulsor_%s_target\"\n",UniqueObjectName(currobj));
	//fprintf (MAPFILE, "\"origin\" \"%f %f %d\"\n",x,y,(CEILING_HEIGHT - LevelInfo[currobj.tileX][currobj.tileY].ceilingHeight - 1) * BrushSizeZ);
	fprintf (MAPFILE, "\"origin\" \"%f %f %d\"\n",x,y, (1+(currobj.State >> 3))*BrushSizeZ);
	fprintf (MAPFILE, "\n}");	
	
	//and a script object for controlling it.
	createScriptCall(currobj,x,y,z);		
}

void RenderEntityNULL_TRIGGER (int game, float x, float y, float z, ObjectItem &currobj, ObjectItem objList[1600], tile LevelInfo[64][64])
{//And a level entry as well.
	if (currobj.TriggerAction == ACTION_TIMER)
		{
		//create a timer to set off.
		fprintf(MAPFILE, "\n// entity %d\n{\n", EntityCount);
		fprintf(MAPFILE, "\"classname\" \"trigger_timer\"\n");
		fprintf(MAPFILE, "\"name\" \"timer_%s\"\n", UniqueObjectName(currobj));
		fprintf(MAPFILE, "\"origin\" \"%f %f %f\"\n", x, y, z);
		fprintf(MAPFILE, "\"wait\" \"%d\"\n", 1);
		//fprintf(MAPFILE, "\"random\" \"%d\"\n", 3);
		fprintf(MAPFILE, "\"target0\" \"runscript_%s\"\n", UniqueObjectName(currobj));
		fprintf(MAPFILE, "}\n");
		EntityCount++;
		}

		createScriptCall(currobj,x,y,z);
}

void RenderEntityDecal(int game, float x, float y, float z, ObjectItem &currobj, ObjectItem objList[1600], tile LevelInfo[64][64])
{//decals like wall icons etc.
	fprintf(MAPFILE, "\n// entity %d\n{\n", EntityCount++);
	fprintf(MAPFILE, "\"classname\" \"%s\"\n", "func_static");
	fprintf(MAPFILE, "\"name\" \"%s\"\n", UniqueObjectName(currobj));
	
	switch (currobj.ObjectSubClassIndex)
	{
		case 0:	//sign
			fprintf(MAPFILE, "\"model\" \"%s\"\n", objectMasters[currobj.item_id].path);
			fprintf(MAPFILE, "\"skin\" \"shock_sign_%04d\"\n", 390+currobj.unk1);
			break;
		case 1:	//icon
			fprintf(MAPFILE, "\"model\" \"%s\"\n", objectMasters[currobj.item_id].path);
			fprintf(MAPFILE, "\"skin\" \"shock_icon_%04d\"\n", currobj.unk1);
			break;
		case 2:	//graffiti
			if (currobj.unk1 != 7)
			{
				fprintf(MAPFILE, "\"model\" \"%s\"\n", objectMasters[currobj.item_id].path);
			}
			else
			{
				fprintf(MAPFILE, "\"model\" \"%s\"\n", objectMasters[131].path);	//special case for shodan hearts diego 
			}
			fprintf(MAPFILE, "\"skin\" \"shock_graffiti_%04d\"\n", currobj.unk1);
			break;
		case 4:	//painting
			if (currobj.unk1 != 2)
			{
				fprintf(MAPFILE, "\"model\" \"%s\"\n", objectMasters[currobj.item_id].path);
			}
			else
			{
				fprintf(MAPFILE, "\"model\" \"%s\"\n", objectMasters[126].path);//special case for the scream.
			}
			fprintf(MAPFILE, "\"skin\" \"shock_painting_%04d\"\n", 403+currobj.unk1);

			break;
		case 5:	//poster
			fprintf(MAPFILE, "\"model\" \"%s\"\n", objectMasters[currobj.item_id].path);
			fprintf(MAPFILE, "\"skin\" \"shock_poster_%04d\"\n", currobj.unk1);
			break;
	}
	fprintf(MAPFILE, "\"origin\" \"%f %f %f\"\n", x, y, z);
	fprintf(MAPFILE, "\"hide\" \"%d\"\n", currobj.invis);
	EntityRotationSHOCK(currobj.Angle2);
	fprintf(MAPFILE, "\n}");
}

void RenderEntityGrating(int game, float x, float y, float z, ObjectItem &currobj, ObjectItem objList[1600], tile LevelInfo[64][64])
{//Transparent Gratings.
	fprintf(MAPFILE, "\n// entity %d\n{\n", EntityCount++);
	fprintf(MAPFILE, "\"classname\" \"%s\"\n", "func_static");
	fprintf(MAPFILE, "\"name\" \"%s\"\n", UniqueObjectName(currobj));
	fprintf(MAPFILE, "\"model\" \"%s\"\n", objectMasters[currobj.item_id].path);
	fprintf(MAPFILE, "\"skin\" \"shock_grating_%03d\"\n", currobj.ObjectSubClassIndex-4);
	fprintf(MAPFILE, "\"origin\" \"%f %f %f\"\n", x, y, z);
	fprintf(MAPFILE, "\"hide\" \"%d\"\n", currobj.invis);
	EntityRotationSHOCK(currobj.Angle2);
	fprintf(MAPFILE, "\n}");
}
void RenderEntityWords(int game, float x, float y, float z, ObjectItem &currobj, ObjectItem objList[1600], tile LevelInfo[64][64])
{
	fprintf(MAPFILE, "\n// entity %d\n{\n", EntityCount++);
	fprintf(MAPFILE, "\"classname\" \"%s\"\n", "atdm:readable_base");
	fprintf(MAPFILE, "\"name\" \"%s\"\n", UniqueObjectName(currobj));
	fprintf(MAPFILE, "\"model\" \"%s\"\n", objectMasters[currobj.item_id].path);
	fprintf(MAPFILE, "\"xdata_contents\" \"readables/shock/words_%d\"\n", currobj.shockProperties[0]);
	fprintf(MAPFILE, "\"origin\" \"%f %f %f\"\n", x, y, z);
	fprintf(MAPFILE, "\"hide\" \"%d\"\n", currobj.invis);
	EntityRotationSHOCK(currobj.Angle2);
	fprintf(MAPFILE, "\n}");
}

void RenderEntityComputerScreen(int game, float x, float y, float z, ObjectItem &currobj, ObjectItem objList[1600], tile LevelInfo[64][64])
{
	fprintf(MAPFILE, "\n// entity %d\n{\n", EntityCount++);



	if (currobj.shockProperties[SCREEN_START] < 246)
	{
		fprintf(MAPFILE, "\"classname\" \"%s\"\n", "func_damagable");
		fprintf(MAPFILE, "\"name\" \"%s\"\n", UniqueObjectName(currobj));
		fprintf(MAPFILE, "\"gui\" \"guis/shock/screen_%d_%d_%d.gui\"\n", currobj.shockProperties[SCREEN_START], currobj.shockProperties[SCREEN_NO_OF_FRAMES], currobj.shockProperties[SCREEN_LOOP_FLAG]);
		fprintf(MAPFILE, "\"target\" \"runscript_%s_destroy\"\n", UniqueObjectName(currobj));
		fprintf(MAPFILE, "\"gui_parm1\" \"0\"\n", UniqueObjectName(currobj));
	}
	else
	{//unimplemented special screens.
		fprintf(MAPFILE, "\"classname\" \"%s\"\n", "func_static");
		fprintf(MAPFILE, "\"gui\" \"guis/shock/screen.gui\"\n");

	}

	fprintf(MAPFILE, "\"origin\" \"%f %f %f\"\n", x, y, z);
	fprintf(MAPFILE, "\"model\" \"%s\"\n", objectMasters[currobj.item_id].path);
	fprintf(MAPFILE, "\"hide\" \"%d\"\n", currobj.invis);

	//currobj.shockProperties[SCREEN_NO_OF_FRAMES]
	//currobj.shockProperties[SCREEN_LOOP_FLAG] 
	//currobj.shockProperties[SCREEN_START] 
	//fprintf(MAPFILE, "\"gui\" \"guis/shock/screen.gui\"\n");
	EntityRotationSHOCK(currobj.Angle2);
	fprintf(MAPFILE, "\n}");

	if (currobj.shockProperties[SCREEN_START] < 246)
	{//destructable
		createScriptCall(currobj, x, y, z, "destroy");
	}


}


void RenderEntitySHOCKDoor(int game, float x, float y, float z, ObjectItem &currobj, ObjectItem objList[1600], tile LevelInfo[64][64])
{
	//The animated door graphics.
	fprintf(MAPFILE, "\n// entity %d\n{\n", EntityCount++);
	fprintf(MAPFILE, "\"classname\" \"%s\"\n", "func_static");
	fprintf(MAPFILE, "\"name\" \"%s_way\"\n", UniqueObjectName(currobj));
	fprintf(MAPFILE, "\"gui\" \"guis/shock/door_%d_%d_%d.gui\"\n", currobj.ObjectClass, currobj.ObjectSubClass, currobj.ObjectSubClassIndex);
	fprintf(MAPFILE, "\"gui_parm1\" \"0\"\n");
	fprintf(MAPFILE, "\"gui2\" \"guis/shock/door_%d_%d_%d_reverse.gui\"\n",currobj.ObjectClass, currobj.ObjectSubClass,currobj.ObjectSubClassIndex);
	fprintf(MAPFILE, "\"gui2_parm1\" \"0\"\n");
	fprintf(MAPFILE, "\"origin\" \"%f %f %f\"\n", x, y, z);
	fprintf(MAPFILE, "\"model\" \"%s\"\n", objectMasters[currobj.item_id].path);
	fprintf(MAPFILE, "\"hide\" \"%d\"\n", currobj.invis);
	fprintf(MAPFILE, "\"solid\" \"%d\"\n", 0);
	EntityRotationSHOCK(currobj.Angle2);
	fprintf(MAPFILE, "\n}");

	//The door frame model
	fprintf(MAPFILE, "\n// entity %d\n{\n", EntityCount++);
	fprintf(MAPFILE, "\"classname\" \"%s\"\n", "func_static");
	fprintf(MAPFILE, "\"name\" \"%s_frame\"\n", UniqueObjectName(currobj));
	fprintf(MAPFILE, "\"origin\" \"%f %f %f\"\n", x, y, z);
	fprintf(MAPFILE, "\"model\" \"%s\"\n", "models/darkmod/shock/doorframe.ase");
	fprintf(MAPFILE, "\"hide\" \"%d\"\n", currobj.invis);
	fprintf(MAPFILE, "\"frobable\" \"1\"\n");
	fprintf(MAPFILE, "\"frob_peer\" \"%s_%03d_%03d\"\n", objectMasters[currobj.item_id].desc, currobj.tileX, currobj.tileY);
	EntityRotationSHOCK(currobj.Angle2);
	fprintf(MAPFILE, "\n}");

	//The collision mesh that will act as the door.
	fprintf(MAPFILE, "\n// entity %d\n{\n", EntityCount++);
	fprintf(MAPFILE, "\"classname\" \"%s\"\n", "atdm:mover_door_sliding");
	//fprintf(MAPFILE, "\"name\" \"%s\"\n", UniqueObjectName(currobj));
	fprintf(MAPFILE, "\"name\" \"%s_%03d_%03d\"\n", objectMasters[currobj.item_id].desc, currobj.tileX, currobj.tileY);
	fprintf(MAPFILE, "\"origin\" \"%f %f %f\"\n", x, y, z);
	EntityRotationSHOCK(currobj.Angle2);
	//fprintf(MAPFILE, "\"model\" \"%s\"\n", UniqueObjectName(currobj));
	fprintf(MAPFILE, "\"model\" \"%s\"\n", "models/darkmod/shock/slidingdoor.ase");	//Need to provide a number of variants for transparency.
	//if (objectMasters[currobj.item_id].type == SHOCK_DOOR_TRANSPARENT)
	//{
	//	fprintf(MAPFILE, "\"hide\" \"%d\"\n", 1);
	//}
	fprintf(MAPFILE, "\"interruptable\" \"%d\"\n", 0); 
	fprintf(MAPFILE, "\"rotate\" \"%d %d %d\"\n", 0 , 0, 0);
	fprintf(MAPFILE, "\"translate_speed\" \"%d\"\n", 500);
	fprintf(MAPFILE, "\"translate\" \"%d %d %d\"\n", 0, 0, -120);
	fprintf(MAPFILE, "\"frobable\" \"%d\"\n", "1");
	//fprintf(MAPFILE, "\"frob_action_script\" \"start_%s\"\n", UniqueObjectName(currobj));
	fprintf(MAPFILE, "\"state_change_callback\" \"start_%s_callback\"\n", UniqueObjectName(currobj));

	//Lock stuff
	if ((currobj.link != 0) || (currobj.SHOCKLocked > 0))	//door has a lock. bit 0-6 of the lock objects link is the keyid for opening it in uw
	{
		fprintf(MAPFILE, "\"locked\" \"%d\"\n", 1);
		if ((currobj.link > 0) && (currobj.link <= 11))	//Only this many keycards
		{
			char *strKeyName = getObjectNameByClass(GETTABLES_OTHER, 4, currobj.link);
			fprintf(MAPFILE, "\"used_by\" \"%s_0\"\n", strKeyName);
			fprintf(MAPFILE, "\"used_by1\" \"%s_1\"\n", strKeyName);
			fprintf(MAPFILE, "\"used_by2\" \"%s_2\"\n", strKeyName);
			fprintf(MAPFILE, "\"used_by3\" \"%s_3\"\n", strKeyName);
			fprintf(MAPFILE, "\"used_by4\" \"%s_4\"\n", strKeyName);
			fprintf(MAPFILE, "\"used_by5\" \"%s_5\"\n", strKeyName);
			fprintf(MAPFILE, "\"used_action_script\" \"start_%s\"\n", UniqueObjectName(currobj));
		}
	}
	fprintf(MAPFILE, "\n}");


	if ((currobj.link != 0) || (currobj.SHOCKLocked >0))
	{	//if it has a lock it needs a lock object for scripting purposes
		fprintf(MAPFILE, "\n// entity %d\n{\n", EntityCount);
		fprintf(MAPFILE, "\"classname\" \"%s\"\n", "atdm:target_changelockstate");
		//A lock trap object for opening doors.
		fprintf(MAPFILE, "\"name\" \"a_lock_%03d_%03d\"\n", currobj.tileX, currobj.tileY);
		fprintf(MAPFILE, "\"target\" \"%s_%03d_%03d\"\n", objectMasters[currobj.item_id].desc, currobj.tileX, currobj.tileY);
		fprintf(MAPFILE, "\"toggle\" \"1\"\n");	//todo: other types of behaviour.
		fprintf(MAPFILE, "\"origin\" \"%f %f %f\"\n", x, y, z);
		fprintf(MAPFILE, "}");
		EntityCount++;
	}


	//EntityRotationSHOCK(currobj.Angle2);
	//the primitive for this slider.  It's the same as its visportal only slightly bigger.

	//tile Tmpt;	//tmp tile for rendering a visportal.

	//switch (currobj.Angle2)
	//	case SHOCK_SOUTH:
	//	case SHOCK_NORTH:
	//	{
	//	    Tmpt.floorHeight = LevelInfo[currobj.tileX][currobj.tileY].floorHeight;
	//		Tmpt.ceilingHeight = LevelInfo[currobj.tileX][currobj.tileY].ceilingHeight;
	//		Tmpt.shockWestCeilHeight = 16;
	//		Tmpt.shockEastCeilHeight = 16;
	//		Tmpt.shockSouthCeilHeight = 16;
	//		Tmpt.shockNorthCeilHeight = 16;
	//		Tmpt.tileType = 0;
	//		Tmpt.isWater = 0;
	//		Tmpt.wallTexture = 205;
	//		Tmpt.North = 205;
	//		Tmpt.South = 205;
	//		Tmpt.East = 205;
	//		Tmpt.West = 205;
	//		Tmpt.Top = 205;
	//		Tmpt.Bottom = 205;
	//		Tmpt.DimX = 1; Tmpt.DimY = 1;

	//		fprintf(MAPFILE, "// primitive %d\n", 0);
	//		fprintf(MAPFILE, "{\nbrushDef3\n{\n");
	//		//east face 
	//		fprintf(MAPFILE, "( 1 0 0 %d )", -((currobj.tileX + Tmpt.DimX)*BrushSizeX));
	//		getWallTextureName(Tmpt, fEAST, 0);
	//		//north face 
	//		//fprintf(MAPFILE, "( 0 1 0 %d )", -((y + Tmpt.DimY)*BrushSizeY)-1);
	//		fprintf(MAPFILE, "( 0 1 0 %f )", -(y + 1));
	//		getWallTextureName(Tmpt, fNORTH, 0);
	//		//top face
	//		//		fprintf(MAPFILE, "( 0 0 1 %d )", -BrushSizeZ * (CEILING_HEIGHT + 1));
	//		fprintf(MAPFILE, "( 0 0 1 %d )", -(120 + LevelInfo[currobj.tileX][currobj.tileY].floorHeight  * BrushSizeZ));
	//		getFloorTextureName(Tmpt, fTOP);
	//		//west face
	//		fprintf(MAPFILE, "( -1 0 0 %d )", +((currobj.tileX)*BrushSizeX));
	//		getWallTextureName(Tmpt, fWEST, 0);
	//		//south face
	//		//fprintf(MAPFILE, "( 0 -1 0 %d )", +((y)*BrushSizeY));
	//		fprintf(MAPFILE, "( 0 -1 0 %f )", +(y - 1));
	//		getWallTextureName(Tmpt, fSOUTH, 0);
	//		//bottom face
	//		fprintf(MAPFILE, "( 0 0 -1 %d )", LevelInfo[currobj.tileX][currobj.tileY].floorHeight  * BrushSizeZ);
	//		getFloorTextureName(Tmpt, fBOTTOM);
	//		fprintf(MAPFILE, "}\n}\n");
	//	}





	



}



void EntityRotation(int heading)
{//This is a fudge until I figure out the rotation math
	//this also violates the idea of having differing x/y scales
	switch (heading)
	{
	// 0	origin to the west
	//90	origin to the north
	//180 origin to the east
	//270 origin to the south
	
		case 0:	
			{fprintf (MAPFILE, "\n\"rotation\" \"1 0 0 0 1 0 0 0 1\"\n");break;}
		case 45:
			{fprintf (MAPFILE, "\n\"rotation\" \"0.707107 0.707107 0 -0.707107 0.707107 0 0 0 1\"\n");break;}
		case 90:	
			{fprintf (MAPFILE, "\n\"rotation\" \"0 1 0 -1 0 0 0 0 1\"\n");break;}
		case 135:
			{fprintf (MAPFILE, "\n\"rotation\" \"-0.707107 0.707107 0 -0.707107 -0.707107 0 0 0 1\"\n");break;}
		case 180:	
			{fprintf (MAPFILE, "\n\"rotation\" \"-1 0 0 0 -1 0 0 0 1\"\n");break;}					
		case 225:
			{fprintf (MAPFILE, "\n\"rotation\" \"-0.707107 -0.707107 0 0.707107 -0.707107 0 0 0 1\"\n");break;}
		case 270:	
			{fprintf (MAPFILE, "\n\"rotation\" \"0 -1 0 1 0 0 0 0 1\"\n");break;}																		
		case 315:
			{fprintf (MAPFILE, "\n\"rotation\" \"0.707107 -0.707107 0 0.707107 0.707107 0 0 0 1\"\n");break;}			
		default:
			{fprintf (MAPFILE, "\n\"rotation\" \"1 0 0 0 1 0 0 0 1\"\n");break;}						
	}
}

void EntityRotationSHOCK(int heading)
{//This is a fudge until I figure out the rotation math
	//this also violates the idea of having differing x/y scales
	switch (heading)
	{
//#define SHOCK_NORTH 192
//#define SHOCK_SOUTH 0
//#define SHOCK_EAST 64
//#define SHOCK_WEST 128
	case SHOCK_SOUTH:
	{fprintf(MAPFILE, "\n\"rotation\" \"1 0 0 0 1 0 0 0 1\"\n"); break; }
	case SHOCK_NORTH:
	{fprintf(MAPFILE, "\n\"rotation\" \"-1 0 0 0 -1 0 0 0 1\"\n"); break; }
	case SHOCK_EAST:
	{fprintf(MAPFILE, "\n\"rotation\" \"0 -1 0 1 0 0 0 0 1\"\n"); break; }
	case SHOCK_WEST:
	{fprintf(MAPFILE, "\n\"rotation\" \"0 1 0 -1 0 0 0 0 1\"\n"); break; }
	default:
	{fprintf(MAPFILE, "\n\"rotation\" \"0 1 0 -1 0 0 0 0 1\"\n"); break; }
	}
}

int getShockObjectIndex(int objClass, int objSubClass, int objSubClassIndex)
	{//Find the specified object in the array of shock objectmasters
	int i;
		for (i=0;i<=475;i++)
			{
			if (
				(objectMasters[i].objClass == objClass)
				&&
				(objectMasters[i].objSubClass == objSubClass)
				&&
				(objectMasters[i].objSubClassIndex == objSubClassIndex)
				)
				{
					return i;
				}
			}
	
	return -1;	//not found
	
	}
	
	
void BuildObjectListShock(tile LevelInfo[64][64], ObjectItem objList[1600], long texture_map[256],char *filePath, int game, int LevelNo)
{

int InUseFlag;
int ObjectClass;
int ObjectSubClass;
int ObjectSubClassIndex;
//int property1;	//Generic data pulled back from subclass tables. Messy but the data differs between types
//int property2;
//int property3;
//int property4;
//int property5;
//int objProperties[10];
	
	int MasterAddressLookup[1024];
	long address_pointer=4;	
	ObjectItem tmpObjList[1600];
	unsigned char *archive_ark;	//the full file.
	unsigned char *xref_ark;		//The crossref table
	unsigned char *mst_ark;		//The master table
	long blockAddress;
	long chunkUnpackedLength=0;
	long chunkType=0;//compression type
	long chunkPackedLength=0;

	//shockCommonObject();
	
	FILE *file = NULL;      // File pointer
	if ((file = fopen(filePath, "rb")) == NULL)
		{
		printf("\nArchive not found!\n");
		return;
		}
	long fileSize = getFileSize(file);
	int filepos = ftell(file);	
	archive_ark = new unsigned char[fileSize];
	fread(archive_ark, fileSize, 1,file);
	fclose(file);
	
	blockAddress =getShockBlockAddress(LevelNo*100+4009,archive_ark,&chunkPackedLength,&chunkUnpackedLength,&chunkType); 
	if (blockAddress == -1) {return;}
	xref_ark=new unsigned char[chunkUnpackedLength];
	LoadShockChunk(blockAddress, chunkType, archive_ark, xref_ark,chunkPackedLength,chunkUnpackedLength);
	xrefTable *xref;
	xref =new xrefTable[chunkUnpackedLength/10];
	int i=0;
	int xref_ptr=0; 
	int xRefLength = (chunkUnpackedLength/10);

	//printf("\nxref\tTileX\tTileY\tMst\tNext\tNextTile\n");
	for (i=0;i<chunkUnpackedLength/10;i++)
		{
		xref[i].tileX= getValAtAddress(xref_ark,xref_ptr+0,16);
		xref[i].tileY =getValAtAddress(xref_ark,xref_ptr+2,16);	
		xref[i].MstIndex =getValAtAddress(xref_ark,xref_ptr+4,16);	
		xref[i].next = getValAtAddress(xref_ark,xref_ptr+6,16);
		xref[i].nextTile =  getValAtAddress(xref_ark,xref_ptr+8,16);
		if (xref[i].nextTile!= i)
			{//object extends over many tiles
			xref[i].duplicate =1;
			xref[i].duplicateAssigned=0;	//when this changes to 1 in a later loop it is the particular instance to use.
			}
		//printf("%d\t%d\t%d\t%d\t%d\t%d\n",
//		i,xref[i].tileX ,xref[i].tileY,xref[i].MstIndex,xref[i].next,xref[i].nextTile);
		
		xref_ptr+=10;
		}

	blockAddress =getShockBlockAddress(LevelNo*100+4008,archive_ark,&chunkPackedLength,&chunkUnpackedLength,&chunkType); 
	if (blockAddress == -1) {return;}
	mst_ark=new unsigned char[chunkUnpackedLength];
	LoadShockChunk(blockAddress,chunkType,archive_ark,mst_ark,chunkPackedLength,chunkUnpackedLength);
	
	long mstaddress_pointer =0;
	
//now run through the master table and process the duplicates flag
	for (i=0;i<chunkUnpackedLength/27;i++)
		{
		xref_ptr= getValAtAddress(mst_ark,mstaddress_pointer+5,16);
		if (xref[xref_ptr].duplicate == 1)
			{
			//picks the first duplicate found to show any others will be pushed aside.
			xref[xref_ptr].duplicateAssigned =1;	
			}
		mstaddress_pointer+=27;
		}

for(i=0;i<xRefLength;i++)				
	{
	if ((xref[i].duplicate==1) && (xref[i].duplicateAssigned !=1))
		{//These are xref entries that are considered extra. I just cut them out of their linked list.
			replaceLink(xref,xRefLength,i,xref[i].next);	//replace the links to the duplicate
			replaceMapLink(LevelInfo,xref,xRefLength,i,xref[i].next);
		}
	}
	
			
for (i=0;i<1600;i++)
	{
	//To stop later crashes in ascii dumps I set some inital values.
	objList[i].index=i;objList[i].next =0;objList[i].item_id=0;objList[i].link =0;objList[i].owner =0;
	}
	
//now i can build based on my master list with no duplicates spoiling things.!	
mstaddress_pointer=0;
	for (i=0; i < chunkUnpackedLength/27; i++)
		{
			xref_ptr =getValAtAddress(mst_ark,mstaddress_pointer+5,16);
			int MasterIndex=xref[xref_ptr].MstIndex ;
			objList[MasterIndex].index=MasterIndex;
			objList[MasterIndex].link =0;
			objList[MasterIndex].joint=0;
			objList[MasterIndex].heading=0;
			objList[MasterIndex].objectConversion = 0;
			objList[MasterIndex].invis = 0;
				InUseFlag=getValAtAddress(mst_ark,mstaddress_pointer,8);
				objList[MasterIndex].InUseFlag = InUseFlag;
					
				objList[MasterIndex].levelno = LevelNo ;
				objList[MasterIndex].tileX = xref[xref_ptr].tileX ;
				objList[MasterIndex].tileY = xref[xref_ptr].tileY ;
				objList[MasterIndex].next =xref[xref[xref_ptr].next].MstIndex  ;

				ObjectClass =getValAtAddress(mst_ark,mstaddress_pointer+1,8);
				objList[MasterIndex].ObjectClass = ObjectClass;
				ObjectSubClass=getValAtAddress(mst_ark,mstaddress_pointer+2,8);
				objList[MasterIndex].ObjectSubClass = ObjectSubClass;
				int SubClassLink =getValAtAddress(mst_ark,mstaddress_pointer+3,16);

				//Subclass per sspecs is  a link to the sub table. not the class it self. For that we need the object type.
				ObjectSubClassIndex =getValAtAddress(mst_ark,mstaddress_pointer+20,8);	

				objList[MasterIndex].ObjectSubClassIndex = ObjectSubClassIndex;
		
				int LookupIndex=getShockObjectIndex(ObjectClass,ObjectSubClass,ObjectSubClassIndex);//Into my object list not the sublist
				if (LookupIndex != -1)
				{
					objList[MasterIndex].item_id = LookupIndex;

					objList[MasterIndex].x = getValAtAddress(mst_ark, mstaddress_pointer + 11, 8);
					objList[MasterIndex].y = getValAtAddress(mst_ark, mstaddress_pointer + 13, 8);
					objList[MasterIndex].zpos = getValAtAddress(mst_ark, mstaddress_pointer + 15, 8);

					objList[MasterIndex].Angle1 = getValAtAddress(mst_ark, mstaddress_pointer + 16, 8);
					objList[MasterIndex].Angle2 = getValAtAddress(mst_ark, mstaddress_pointer + 17, 8);
					objList[MasterIndex].Angle3 = getValAtAddress(mst_ark, mstaddress_pointer + 18, 8);
					//	printf("\tIt is a %s", objectMasters[objList[MasterIndex].item_id].desc );

					objList[MasterIndex].sprite = getValAtAddress(mst_ark, mstaddress_pointer + 23, 8);
					objList[MasterIndex].State = getValAtAddress(mst_ark, mstaddress_pointer + 23, 8);
					objList[MasterIndex].unk1 = getValAtAddress(mst_ark, mstaddress_pointer + 24, 8);

					printf("\n++++++++Next object++++++++++++\n");
					printf("\nIndex = %d \n", objList[MasterIndex].index);
					printf("Desc %s\t", objectMasters[objList[MasterIndex].item_id].desc);
					printf("(%s)\n", UniqueObjectName(objList[MasterIndex]));
					printf("Class: %d,%d,%d\n", objList[MasterIndex].ObjectClass, objList[MasterIndex].ObjectSubClass, objList[MasterIndex].ObjectSubClassIndex);
					printf("Location = (%d", objList[MasterIndex].tileX);
					printf(",%d", objList[MasterIndex].tileY);
					if (objList[MasterIndex].InUseFlag != 0)
					{
						printf(", %d)\n	", LevelInfo[objList[MasterIndex].tileX][objList[MasterIndex].tileY].floorHeight);
					}
					else
					{
						printf(")\n");
					}
					printf("InUse = %d\n", objList[MasterIndex].InUseFlag);
					printf("\tAIIndex = %d\n", getValAtAddress(mst_ark, mstaddress_pointer + 19, 8));
					printf("\tHitPoints = %d\n", getValAtAddress(mst_ark, mstaddress_pointer + 21, 16));

					//printf("\tunk1 = %d\n",getValAtAddress(mst_ark,mstaddress_pointer+24,8));
					//printf("\tunk2 = %d\n",getValAtAddress(mst_ark,mstaddress_pointer+25,8));
					//printf("\tunk3 = %d\n",getValAtAddress(mst_ark,mstaddress_pointer+26,8));				
					printf("\tXCoord= %d", getValAtAddress(mst_ark, mstaddress_pointer + 11, 8));
					//printf("\tXCoord high= %d\n",getValAtAddress(mst_ark,mstaddress_pointer+12,8)); same as tileX
					printf("\tYCoord= %d", getValAtAddress(mst_ark, mstaddress_pointer + 13, 8));
					//printf("\tYCoord high= %d\n",getValAtAddress(mst_ark,mstaddress_pointer+14,8)); same as tileY
					printf("\tZCoord = %d\n", getValAtAddress(mst_ark, mstaddress_pointer + 15, 8));
					printf("\tAngles = (%d", getValAtAddress(mst_ark, mstaddress_pointer + 16, 8));
					printf(",%d", getValAtAddress(mst_ark, mstaddress_pointer + 17, 8));
					printf("\,%d)\n", getValAtAddress(mst_ark, mstaddress_pointer + 18, 8));
					printf("\tObjectType = %d\n", getValAtAddress(mst_ark, mstaddress_pointer + 20, 8));
					printf("\tHitPoints = %d\n", getValAtAddress(mst_ark, mstaddress_pointer + 21, 16));
					printf("\tState = %d", objList[MasterIndex].State);
					printf("\t(%d,%d)\n", (objList[MasterIndex].State >> 4) & 0xF, objList[MasterIndex].State & 0xF);
					printf("\tunk1 = %d", getValAtAddress(mst_ark, mstaddress_pointer + 24, 8));
					printf("\tunk2 = %d", getValAtAddress(mst_ark, mstaddress_pointer + 25, 8));
					printf("\tunk3 = %d\n", getValAtAddress(mst_ark, mstaddress_pointer + 26, 8));
					switch (ObjectClass)	//to get further properties specific to each class
					{
					case GUNS_WEAPONS:break;
					case AMMUNITION:break;
					case PROJECTILES:break;
					case GRENADE_EXPLOSIONS:break;
					case PATCHES:break;
					case HARDWARE:break;
					case SOFTWARE_LOGS:
					{
					if (lookUpSubClass(archive_ark, LevelNo * 100 + SOFTWARE_LOGS_OFFSET, SOFTWARE_LOGS, SubClassLink, 9, xref, objList, MasterIndex) == -1) { printf("\nNo properties found!\n"); }
					break;
					}
					case FIXTURES:
					{
					if (lookUpSubClass(archive_ark, LevelNo * 100 + FIXTURES_OFFSET, FIXTURES, SubClassLink, 16, xref, objList, MasterIndex) == -1) { printf("\nNo properties found!\n"); }
					break;
					}
					case GETTABLES_OTHER:
					if (lookUpSubClass(archive_ark, LevelNo * 100 + GETTABLES_OTHER_OFFSET, GETTABLES_OTHER, SubClassLink, 16, xref, objList, MasterIndex) == -1) { printf("\nNo properties found!\n"); }
					break;
					case SWITCHES_PANELS:
					{
					if (lookUpSubClass(archive_ark, LevelNo * 100 + SWITCHES_PANELS_OFFSET, SWITCHES_PANELS, SubClassLink, 30, xref, objList, MasterIndex) == -1) { printf("\nNo properties found!\n"); }
					break;
					}
					case DOORS_GRATINGS:
					{
					if (lookUpSubClass(archive_ark, LevelNo * 100 + DOORS_GRATINGS_OFFSET, DOORS_GRATINGS, SubClassLink, 14, xref, objList, MasterIndex) == -1) { printf("\nNo properties found!\n"); }
					break;
					}
					case ANIMATED:break;
					case TRAPS_MARKERS:
					{
					if (lookUpSubClass(archive_ark, LevelNo * 100 + TRAPS_MARKERS_OFFSET, TRAPS_MARKERS, SubClassLink, 28, xref, objList, MasterIndex) == -1)  { printf("no properties found!"); }
					break;
					}
					case CONTAINERS_CORPSES:
					if (lookUpSubClass(archive_ark, LevelNo * 100 + CONTAINERS_CORPSES_OFFSET, CONTAINERS_CORPSES, SubClassLink, 21, xref, objList, MasterIndex) == -1)  { printf("no properties found!"); }
					break;
					case CRITTERS:break;
					}
					UniqueObjectName(objList[MasterIndex]);
				}
				else
				{
					printf("\n\nInvalid item id!!\n");
				}
	

		mstaddress_pointer +=27;
		}

//turn obj indices into master indices
	for (int x=0;x<64;x++)
		{
		for(int y=0;y<64;y++)
		{
			if (LevelInfo[x][y].indexObjectList !=0)
				{LevelInfo[x][y].indexObjectList= xref[LevelInfo[x][y].indexObjectList].MstIndex; }
			}
		}
}
	
void BuildObjectListUW(tile LevelInfo[64][64], ObjectItem objList[1600],long texture_map[256],char *filePath, int game, int LevelNo)
{
//parses the object list in UW.
	FILE *file = NULL;      // File pointer
	unsigned char *lev_ark; 
	unsigned char *tmp_ark;		//for uw2 decompression
	long fileSize;
    int NoOfBlocks;
	long AddressOfBlockStart;
	long objectsAddress;
	long address_pointer;
	//int x;	



switch (game)
	{
	case UWDEMO:	//Underworld Demo
		{
		if ((file = fopen(filePath, "rb")) == NULL)
			printf("Could not open specified file\n");
		else
			printf ("");
		// Get the size of the file in bytes
		fileSize = getFileSize(file);
		// Allocate space in the buffer for the whole file
		lev_ark = new unsigned char[fileSize];
		// Read the file in to the buffer
		fread(lev_ark, fileSize, 1,file);
		fclose(file);  		
		//Get the first map block
		AddressOfBlockStart = 0;
		objectsAddress = AddressOfBlockStart + (64*64*4); //+ 1;
		address_pointer = 0;
		break;
		}
	case UW1:	//Underworld 1
		{
		if ((file = fopen(filePath, "rb")) == NULL)
			printf("Could not open specified file\n");
		else
			printf ("");
		// Get the size of the file in bytes
		fileSize = getFileSize(file);
		// Allocate space in the buffer for the whole file
		lev_ark = new unsigned char[fileSize];
		// Read the file in to the buffer
		fread(lev_ark, fileSize, 1,file);
		fclose(file);  		
		//Get the number of blocks in this file.
		NoOfBlocks = ConvertInt16(lev_ark[0],lev_ark[1]);
		//Get the first map block
		AddressOfBlockStart = getValAtAddress(lev_ark,(LevelNo * 4) + 2,32);
		objectsAddress = AddressOfBlockStart + (64*64*4); //+ 1;
		address_pointer =0;
		break;
	case UW2:	//Underworld 2
		{
		if ((file = fopen(filePath, "rb")) == NULL)
			printf("Could not open specified file\n");
		else
			printf ("");
		fileSize = getFileSize(file);
		tmp_ark = new unsigned char[fileSize];
		fread(tmp_ark, fileSize, 1,file);
		fclose(file);
						
		address_pointer=6;
		NoOfBlocks=getValAtAddress(tmp_ark,0,32);
		int compressionFlag=getValAtAddress(tmp_ark,address_pointer + (NoOfBlocks*4) ,32);
		int isCompressed =(compressionFlag>>1) & 0x01;
		
		long dataSize = address_pointer + (2*NoOfBlocks*4);	//????
		address_pointer=(LevelNo * 4) + 6;
		if (getValAtAddress(tmp_ark,address_pointer,32)==0)
			{
			printf("\nInvalid block address!\n");
			return;
			}
		if (isCompressed == 1)
			{
			lev_ark = unpack(tmp_ark,getValAtAddress(tmp_ark,address_pointer,32));
			}
			address_pointer=address_pointer+4;
		AddressOfBlockStart=0;	//since this array only contains that particular block
		objectsAddress=(64*64*4);
		address_pointer=0;

			
		//	}		
		break;
		}
		}
	}
	for (int x=0; x<1025;x++)
		{	//read in master object list

			objList[x].index = x; 
			objList[x].InUseFlag =1;
			objList[x].tileX=-1;
			objList[x].tileY=-1;
			objList[x].levelno = LevelNo ;			
			//These three will get set when I am rendering the object entity and if the item is an npc's inventory.
			objList[x].objectOwner =0;
			objList[x].objectOwnerEntity =0;
			objList[x].joint =0 ;
			objList[x].objectConversion = 0;
			objList[x].invis = 0;
			
			//Object header.
			objList[x].item_id = (getValAtAddress(lev_ark,objectsAddress+address_pointer+0,16)) & 0x1FF;
			objList[x].flags  = ((getValAtAddress(lev_ark,objectsAddress+address_pointer+0,16))>> 9) & 0x0F;
			objList[x].enchantment = ((getValAtAddress(lev_ark,objectsAddress+address_pointer+0,16)) >> 12) & 0x01;
			objList[x].doordir  = ((getValAtAddress(lev_ark,objectsAddress+address_pointer+0,16)) >> 13) & 0x01;
			objList[x].invis  = ((getValAtAddress(lev_ark,objectsAddress+address_pointer+0,16)) >> 14 )& 0x01;
			objList[x].is_quant = ((getValAtAddress(lev_ark,objectsAddress+address_pointer+0,16)) >> 15) & 0x01;
			
			//position at +2
			objList[x].zpos = (getValAtAddress(lev_ark,objectsAddress+address_pointer+2,16)) & 0x7F;	//bits 0-6 I'll probably ignore this
			objList[x].heading =  45 * (((getValAtAddress(lev_ark,objectsAddress+address_pointer+2,16)) >> 7) & 0x07); //bits 7-9
			objList[x].y = ((getValAtAddress(lev_ark,objectsAddress+address_pointer+2,16)) >> 10) & 0x07;	//bits 10-12
			objList[x].x =((getValAtAddress(lev_ark,objectsAddress+address_pointer+2,16)) >> 13) & 0x07;	//bits 13-15
			
			//+4
			objList[x].quality =(getValAtAddress(lev_ark,objectsAddress+address_pointer+4,16)) & 0x3F;
			objList[x].next = (getValAtAddress(lev_ark,objectsAddress+address_pointer+4,16)>>6) & 0x3FF;
			//+6
			//objList[x].owner = (getValAtAddress(lev_ark,objectsAddress+address_pointer+6,16) ) ;//bits 0-5

			objList[x].owner = (getValAtAddress(lev_ark,objectsAddress+address_pointer+6,16) & 0x3F) ;//bits 0-5
			
			
			if ((objectMasters[objList[x].item_id].type  == TMAP_SOLID) || (objectMasters[objList[x].item_id].type  == TMAP_CLIP))
				{
				//printf("\n%d\n", texture_map[objList[x].owner]);
				objList[x].owner = texture_map[objList[x].owner];	//Sets the texture for tmap objects.
				}
						
				
			//objList[x].special = objList[x].owner;
			
			objList[x].link  = (getValAtAddress(lev_ark,objectsAddress+address_pointer+6,16) >> 6 & 0x3FF) ; //bits 6-15
			//objList[x].link = objList[x].quantity;
			
			////printf("\n\tNext Object ID to this object is  %d", objList[x].next  );
			////printf("\n%d free object. Value 4=%d",x,getValAtAddress(lev_ark,AddressOfBlockStart+address_pointer+6,16));
			
			//extra info //19 bytes
			////printf("\n%d free extra inf. Value 5=%d",x,getValAtAddress(lev_ark,AddressOfBlockStart+address_pointer+8,8));
			////printf("\n%d free extra inf. Value 6=%d",x,getValAtAddress(lev_ark,AddressOfBlockStart+address_pointer+9,8));
			////printf("\n%d free extra inf. Value 7=%d",x,getValAtAddress(lev_ark,AddressOfBlockStart+address_pointer+10,8));
			////printf("\n%d free extra inf. Value 8=%d",x,getValAtAddress(lev_ark,AddressOfBlockStart+address_pointer+11,8));
			////printf("\n%d free extra inf. Value 9=%d",x,getValAtAddress(lev_ark,AddressOfBlockStart+address_pointer+12,8));
			////printf("\n%d free extra inf. Value 10=%d",x,getValAtAddress(lev_ark,AddressOfBlockStart+address_pointer+13,8));
			////printf("\n%d free extra inf. Value 11=%d",x,getValAtAddress(lev_ark,AddressOfBlockStart+address_pointer+14,8));
			////printf("\n%d free extra inf. Value 12=%d",x,getValAtAddress(lev_ark,AddressOfBlockStart+address_pointer+15,8));
			////printf("\n%d free extra inf. Value 13=%d",x,getValAtAddress(lev_ark,AddressOfBlockStart+address_pointer+16,8));
			////printf("\n%d free extra inf. Value 14=%d",x,getValAtAddress(lev_ark,AddressOfBlockStart+address_pointer+17,8));
			////printf("\n%d free extra inf. Value 15=%d",x,getValAtAddress(lev_ark,AddressOfBlockStart+address_pointer+18,8));
			////printf("\n%d free extra inf. Value 16=%d",x,getValAtAddress(lev_ark,AddressOfBlockStart+address_pointer+19,8));
			////printf("\n%d free extra inf. Value 17=%d",x,getValAtAddress(lev_ark,AddressOfBlockStart+address_pointer+20,8));
			////printf("\n%d free extra inf. Value 18=%d",x,getValAtAddress(lev_ark,AddressOfBlockStart+address_pointer+21,8));
			////printf("\n%d free extra inf. Value 19=%d",x,getValAtAddress(lev_ark,AddressOfBlockStart+address_pointer+22,8));
			////printf("\n%d free extra inf. Value 20=%d",x,getValAtAddress(lev_ark,AddressOfBlockStart+address_pointer+23,8));
			////printf("\n%d free extra inf. Value 21=%d",x,getValAtAddress(lev_ark,AddressOfBlockStart+address_pointer+24,8));
			////printf("\n%d free extra inf. Value 22=%d",x,getValAtAddress(lev_ark,AddressOfBlockStart+address_pointer+25,8));
			////printf("\n%d free extra inf. Value 23=%d",x,getValAtAddress(lev_ark,AddressOfBlockStart+address_pointer+26,8));
			//cleanup of shock related stuff
			objList[x].SHOCKLocked = 0;
			////
		if (x<256)	
			{
			//mobile objects			
			objList[x].npc_whoami =getValAtAddress(lev_ark,objectsAddress+address_pointer+26,8);
			objList[x].npc_attitude = (getValAtAddress(lev_ark,objectsAddress+address_pointer+13,16) >> 14);

			address_pointer=address_pointer+8+19;
			}
		else
			{
			//Static Objects
			address_pointer=address_pointer+8;
			}
		}
}

int lookUpSubClass(unsigned char *archive_ark, int BlockNo, int ClassType ,int index, int RecordSize, xrefTable *xRef, ObjectItem objList[1600], int objIndex)
{
//
	unsigned char *sub_ark ;
	long chunkUnpackedLength;
	long chunkType;//compression type
	long chunkPackedLength;

//long chunkUnpackedLength =LoadShockChunk(filePath,BlockNo,sub_ark);

	long blockAddress =getShockBlockAddress(BlockNo,archive_ark,&chunkPackedLength,&chunkUnpackedLength,&chunkType); 
	if (blockAddress == -1) {return -1;}
	sub_ark=new unsigned char[chunkUnpackedLength];
	LoadShockChunk(blockAddress,chunkType,archive_ark,sub_ark,chunkPackedLength,chunkUnpackedLength);

	int k= 0;
int add_ptr=0;
while (k<=chunkUnpackedLength)
	{
	if (k==index)
		{
		switch(ClassType)
		{
			case SOFTWARE_LOGS:
				{
				objList[objIndex].shockProperties[SOFT_PROPERTY_VERSION]=getValAtAddress(sub_ark,add_ptr+6,8);	//Software version
				objList[objIndex].shockProperties[SOFT_PROPERTY_LOG]=getValAtAddress(sub_ark,add_ptr+7,8) + 2488;	//Chunk containing log
				objList[objIndex].shockProperties[SOFT_PROPERTY_LEVEL]=getValAtAddress(sub_ark,add_ptr+8,8);	//Level No of Chunk
				printf("\tSoftware Properties\n");
				printf("\t\tVersion %d",objList[objIndex].shockProperties[SOFT_PROPERTY_VERSION]);
				printf("\tLog Chunk %d",objList[objIndex].shockProperties[SOFT_PROPERTY_LOG]);
				printf("\tLevel %d",objList[objIndex].shockProperties[SOFT_PROPERTY_LEVEL]);
				return 1;
				break;
				}
			case FIXTURES:
			{
				printf("\tFixture Properties\n");
				switch (objList[objIndex].ObjectSubClass)
				{
					case 0://regular fixtures
					case 1:
					case 3:
					case 4:
					case 5:
					case 6:
						printf("\n\tVal 0x6: %d", getValAtAddress(sub_ark, add_ptr + 6, 16));
						printf("\n\tVal 0x8: %d", getValAtAddress(sub_ark, add_ptr + 8, 16));
						printf("\n\tVal 0xA: %d", getValAtAddress(sub_ark, add_ptr + 0xA, 16));
						printf("\n\tVal 0xC: %d", getValAtAddress(sub_ark, add_ptr + 0xC, 16));
						printf("\n\tVal 0xE: %d", getValAtAddress(sub_ark, add_ptr + 0xE, 16));
						break;
					case 2:
						  switch (objList[objIndex].ObjectSubClassIndex)
						  {
						  case 0://SIGN
						  case 1://ICON
						  case 2://GRAFFITI
						  case 4://painting
						  case 5://poster
							  printf("\n\tImage to use is value in unk1. Offset from image 1350_0390.bmp or 1350_0403.bmp in objart.res or 0078_0000.bmp or 0079_0000 in objart3.res");
							  break;
						  case 3:
							  {
								  //based on SSHP interpretation
								  int fontID[4] = { 4, 7, 0, 10 };
								  float scale[4] = { 1.0, 0.75, 0.5, 0.25 };
								  printf("Words:");
								  objList[objIndex].shockProperties[0] = getValAtAddress(sub_ark, add_ptr + 6, 16);
								  printf("\nSub chunk %d (from chunk 2152)", getValAtAddress(sub_ark, add_ptr + 6, 16));
								  int FontNSize = getValAtAddress(sub_ark, add_ptr + 8, 16);
								  printf("\nFont %d (+chunk 602)", fontID[FontNSize & 0x03]);
								  printf("\nSize %d ", fontID[FontNSize>>4 & 0x03]);
								  printf("\nColour %d ", getValAtAddress(sub_ark, add_ptr + 0xA, 16));

								  printf("\n\tVal 0x6: %d", getValAtAddress(sub_ark, add_ptr + 6, 16));
								  printf("\n\tVal 0x8: %d", getValAtAddress(sub_ark, add_ptr + 8, 16));
								  printf("\n\tVal 0xA: %d", getValAtAddress(sub_ark, add_ptr + 0xA, 16));
								  printf("\n\tVal 0xC: %d", getValAtAddress(sub_ark, add_ptr + 0xC, 16));
								  printf("\n\tVal 0xE: %d", getValAtAddress(sub_ark, add_ptr + 0xE, 16));
								  break;
							  }
						  case 6:
						  case 8:
						  case 9:
							  printf("Screens:");
							  objList[objIndex].shockProperties[SCREEN_NO_OF_FRAMES] = getValAtAddress(sub_ark, add_ptr + 6, 16);
							  objList[objIndex].shockProperties[SCREEN_LOOP_FLAG] = getValAtAddress(sub_ark, add_ptr + 8, 16);
							  objList[objIndex].shockProperties[SCREEN_START] = getValAtAddress(sub_ark, add_ptr + 0xC, 16);
							  printf("\nNo of Frames: %d", objList[objIndex].shockProperties[SCREEN_NO_OF_FRAMES]);
							  printf("\nLoop repeats: %d ", objList[objIndex].shockProperties[SCREEN_LOOP_FLAG]);
							  printf("\nStart Frame: %d (from chunk 321) = %d", objList[objIndex].shockProperties[SCREEN_START], 321 + objList[objIndex].shockProperties[SCREEN_START]);
							  break;
						  default:
							  printf("\n\tVal 0x6: %d", getValAtAddress(sub_ark, add_ptr + 6, 16));
							  printf("\n\tVal 0x8: %d", getValAtAddress(sub_ark, add_ptr + 8, 16));
							  printf("\n\tVal 0xA: %d", getValAtAddress(sub_ark, add_ptr + 0xA, 16));
							  printf("\n\tVal 0xC: %d", getValAtAddress(sub_ark, add_ptr + 0xC, 16));
							  printf("\n\tVal 0xE: %d", getValAtAddress(sub_ark, add_ptr + 0xE, 16));
							  break;
						  }
						break;
					case 7:	//bridges etc
						printf("\n\tVal 0x6: %d", getValAtAddress(sub_ark, add_ptr + 6, 16));
						printf("\n\tVal 0x8: %d", getValAtAddress(sub_ark, add_ptr + 8, 16));
						printf("\n\tVal 0xA: %d", getValAtAddress(sub_ark, add_ptr + 0xA, 16));
						printf("(%d", getValAtAddress(sub_ark, add_ptr + 0xA, 8));
						printf(",%d)", getValAtAddress(sub_ark, add_ptr + 0xB, 8));
						printf("\n\tVal 0xC: %d", getValAtAddress(sub_ark, add_ptr + 0xC, 16));
						printf("\n\tVal 0xE: %d", getValAtAddress(sub_ark, add_ptr + 0xE, 16));
						break;
				}
				
	

				return 1;
				break;
				}
			case GETTABLES_OTHER:
				{
				if (objList[objIndex].item_id == 191)	//Brief case contents
					{
					objList[objIndex].shockProperties[CONTAINER_CONTENTS_1] = getValAtAddress(sub_ark, add_ptr + 0x6, 16);
					objList[objIndex].shockProperties[CONTAINER_CONTENTS_2] = getValAtAddress(sub_ark, add_ptr + 0x8, 16);
					objList[objIndex].shockProperties[CONTAINER_CONTENTS_3] = getValAtAddress(sub_ark, add_ptr + 0xA, 16);
					objList[objIndex].shockProperties[CONTAINER_CONTENTS_4] = getValAtAddress(sub_ark, add_ptr + 0xC, 16);
					printf("\tContents 1 : %d\n", objList[objIndex].shockProperties[CONTAINER_CONTENTS_1]);
					printf("\tContents 2 : %d\n", objList[objIndex].shockProperties[CONTAINER_CONTENTS_2]);
					printf("\tContents 3 : %d\n", objList[objIndex].shockProperties[CONTAINER_CONTENTS_3]);
					printf("\tContents 4 : %d\n", objList[objIndex].shockProperties[CONTAINER_CONTENTS_4]);
					}
			
				for (int j = 0; j < RecordSize; j = j + 2)
					{
						printf("j=%d val(16) = %d\n", j, getValAtAddress(sub_ark, add_ptr+ j, 16));
					}

				return 1;
				break;
				}
			case SWITCHES_PANELS:
				{
				printf("\n\tSwitch Properties\n");
				printf("\t\tSwitch Action?:%d",getValAtAddress(sub_ark,add_ptr+6,16));
				printf("\tVariable:%d",getValAtAddress(sub_ark,add_ptr+8,16));
				printf("\tFail Message:%d",getValAtAddress(sub_ark,add_ptr+10,16));
				objList[objIndex].TriggerAction = getValAtAddress(sub_ark,add_ptr+6,16);
				getShockButtons(LevelInfo,sub_ark,add_ptr,objList,objIndex);
				return 1;
				break;
				}
			case DOORS_GRATINGS:
				{
				printf("\n\tDoor Properties\n");
				int crossref = getValAtAddress(sub_ark, add_ptr + 6, 16);
				if (crossref != 0)
					{
					    objList[objIndex].SHOCKLocked  = 1;	// = crossref;	
					}
				else
					{
						objList[objIndex].SHOCKLocked = 0;
					}
				objList[objIndex].link = getValAtAddress(sub_ark, add_ptr + 10, 8);	//Link to it's key. reusage from uw.

				printf("\t\tTrigger xref?:%d (%d)", xRef[crossref].MstIndex, crossref);
				printf("\tMessage:%d", getValAtAddress(sub_ark, add_ptr + 8, 16));
				printf("\tAccess Required:%d\n", getValAtAddress(sub_ark, add_ptr + 10, 8));
				return 1;
				break;
				}
			case	TRAPS_MARKERS: //and triggers too
				{
				objList[objIndex].conditions[0] = getValAtAddress(sub_ark,add_ptr+8,8);
				objList[objIndex].conditions[1] = getValAtAddress(sub_ark,add_ptr+9,8);
				objList[objIndex].conditions[2] = getValAtAddress(sub_ark,add_ptr+10,8);
				objList[objIndex].conditions[3] = getValAtAddress(sub_ark,add_ptr+11,8);
				objList[objIndex].TriggerOnce = getValAtAddress(sub_ark,add_ptr+7,8);
				objList[objIndex].TriggerOnceGlobal = 0;
					printf("\tConditions: %d",objList[objIndex].conditions[0]);
					printf(",%d",objList[objIndex].conditions[1]);
					printf(",%d",objList[objIndex].conditions[2]);
					printf(",%d\n",objList[objIndex].conditions[3]);
					printf("\tTrigger once: %d\n",objList[objIndex].TriggerOnce);
		
				getShockTriggerAction(LevelInfo,sub_ark,add_ptr,xRef,objList,objIndex);

				return 1;
				break;
			case CONTAINERS_CORPSES:
				printf("\n\tContainer Properties\n");
				objList[objIndex].shockProperties[CONTAINER_CONTENTS_1] = getValAtAddress(sub_ark, add_ptr + 0x6, 16);
				objList[objIndex].shockProperties[CONTAINER_CONTENTS_2] = getValAtAddress(sub_ark, add_ptr + 0x8, 16);
				objList[objIndex].shockProperties[CONTAINER_CONTENTS_3] = getValAtAddress(sub_ark, add_ptr + 0xA, 16);
				objList[objIndex].shockProperties[CONTAINER_CONTENTS_4] = getValAtAddress(sub_ark, add_ptr + 0xC, 16);
				objList[objIndex].shockProperties[CONTAINER_WIDTH] = getValAtAddress(sub_ark, add_ptr + 0xE, 8);
				objList[objIndex].shockProperties[CONTAINER_HEIGHT] = getValAtAddress(sub_ark, add_ptr + 0xF, 8);
				objList[objIndex].shockProperties[CONTAINER_DEPTH] = getValAtAddress(sub_ark, add_ptr + 0x10, 8);
				objList[objIndex].shockProperties[CONTAINER_TOP] = getValAtAddress(sub_ark, add_ptr + 0x11, 8);
				objList[objIndex].shockProperties[CONTAINER_SIDE] = getValAtAddress(sub_ark, add_ptr + 0x12, 8);
				printf("\tContents 1 : %d\n", objList[objIndex].shockProperties[CONTAINER_CONTENTS_1]);
				printf("\tContents 2 : %d\n", objList[objIndex].shockProperties[CONTAINER_CONTENTS_2]);
				printf("\tContents 3 : %d\n", objList[objIndex].shockProperties[CONTAINER_CONTENTS_3]);
				printf("\tContents 4 : %d\n", objList[objIndex].shockProperties[CONTAINER_CONTENTS_4]);
				printf("\tWidth : %d", objList[objIndex].shockProperties[CONTAINER_WIDTH]);
				printf("\tHeight : %d", objList[objIndex].shockProperties[CONTAINER_HEIGHT]);
				printf("\tDepth : %d\n", objList[objIndex].shockProperties[CONTAINER_DEPTH]);
				printf("\tTop : %d", objList[objIndex].shockProperties[CONTAINER_TOP]);
				printf("\tSide : %d", objList[objIndex].shockProperties[CONTAINER_SIDE]);
				return 1;
				break;
				}
			}
		}
	add_ptr+=RecordSize;
	k++;
	}
return -1;
}

void CalcObjectXYZ(int game, float *offX,  float *offY, float *offZ, tile LevelInfo[64][64], ObjectItem objList[1600], long nextObj, int x,int y)
{
int ResolutionXY=7;	// A tile has a 7x7 grid for object positioning.
int ResolutionZ=127;	//UW has 127 posible z positions for an object in tile.
if (game ==SHOCK){ResolutionXY =255;ResolutionZ=255;}	//Shock has more "z" in it.


		*offX=0;  *offY=0; *offZ=0;


		float BrushX=BrushSizeX;
		float BrushY=BrushSizeY;
		float BrushZ=BrushSizeZ;
		
		*offX= (x*BrushX) + ((objList[nextObj].x) * (BrushX/ResolutionXY));
		*offY= (y*BrushY) + ((objList[nextObj].y) * (BrushY/ResolutionXY));
		//offZ = objList[nextObj].zpos ; //TODO:Adjust this.
		float zpos = objList[nextObj].zpos;
		float ceil = CEILING_HEIGHT;
		*offZ = ((zpos / ResolutionZ) * (ceil)) * BrushZ;
		//TODO:This may mess with stuff on walls. It's here to prevent models cliping through sloped floors
		//if ((LevelInfo[x][y].tileType >= 6) && (LevelInfo[x][y].tileType <= 9) && (LevelInfo[x][y].isWater == 0) && (LevelInfo[x][y].shockSlopeFlag !=SLOPE_CEILING_ONLY))
		//	{
		//	*offZ = *offZ + (LevelInfo[x][y].shockSteep * (BrushSizeZ /2));
		//	}

}

void getShockTriggerAction(tile LevelInfo[64][64],unsigned char *sub_ark,int add_ptr, xrefTable *xRef, ObjectItem objList[1600], int objIndex)
{
//Look up what a trigger does in system shock. Different trigger types activate other triggers/ do things in different ways.
short PrintDebug = 1;// (objList[objIndex].item_id == 384);
printf("",UniqueObjectName(objList[objIndex]));	//Weirdness with garbage info getting printed out?
int TriggerType =getValAtAddress(sub_ark,add_ptr+6,8);
objList[objIndex].TriggerAction = TriggerType;
switch (TriggerType)
	{ 
	case ACTION_DO_NOTHING :
		{//Default action.
		if (PrintDebug==1)
			{
			printf("\tACTION_DO_NOTHING or default for %s\n",UniqueObjectName(objList[objIndex]));
			DebugPrintTriggerVals(sub_ark, add_ptr,28);
			//printf("\t\tOther values 1:%d\n",getValAtAddress(sub_ark,add_ptr+12,16));
			//printf("\t\tOther values 2:%d\n",getValAtAddress(sub_ark,add_ptr+14,16));
			//printf("\t\tOther values 3:%d\n",getValAtAddress(sub_ark,add_ptr+16,16));
			//printf("\t\tOther values 4:%d\n",getValAtAddress(sub_ark,add_ptr+18,16));
			//printf("\t\tOther values 5:%d\n",getValAtAddress(sub_ark,add_ptr+20,16));
			//printf("\t\tOther values 6:%d\n",getValAtAddress(sub_ark,add_ptr+22,16));		
			//printf("\t\tOther values 7:%d\n",getValAtAddress(sub_ark,add_ptr+24,16));		
			//printf("\t\tOther values 8:%d\n",getValAtAddress(sub_ark,add_ptr+26,16));	
			}		
		break;	
		}
	case ACTION_TRANSPORT_LEVEL:
		{//Sends the player to the specified position in the level.

		objList[objIndex].shockProperties[TRIG_PROPERTY_TARGET_X] = getValAtAddress(sub_ark,add_ptr+12,16);	//Target X of teleport
		objList[objIndex].shockProperties[TRIG_PROPERTY_TARGET_Y] = getValAtAddress(sub_ark,add_ptr+16,16); //Target Y of teleport
		objList[objIndex].shockProperties[TRIG_PROPERTY_TARGET_Z]= getValAtAddress(sub_ark,add_ptr+20,16);	//Target Z of teleport
		
		if (PrintDebug==1)
			{
			printf("\tACTION_TRANSPORT_LEVEL for %s\n",UniqueObjectName(objList[objIndex]));
			printf("\t\tDestination (%d,%d,%d)\n",objList[objIndex].shockProperties[TRIG_PROPERTY_TARGET_X], objList[objIndex].shockProperties[TRIG_PROPERTY_TARGET_Y],objList[objIndex].shockProperties[TRIG_PROPERTY_TARGET_Z] );
			DebugPrintTriggerVals(sub_ark, add_ptr, 28);
			//printf("\t\tOther values 1:%d\n",getValAtAddress(sub_ark,add_ptr+12,16));
			//printf("\t\tOther values 2:%d\n",getValAtAddress(sub_ark,add_ptr+14,16));
			//printf("\t\tOther values 3:%d\n",getValAtAddress(sub_ark,add_ptr+16,16));
			//printf("\t\tOther values 4:%d\n",getValAtAddress(sub_ark,add_ptr+18,16));
			//printf("\t\tOther values 5:%d\n",getValAtAddress(sub_ark,add_ptr+20,16));
			//printf("\t\tOther values 6:%d\n",getValAtAddress(sub_ark,add_ptr+22,16));		
			//printf("\t\tOther values 7:%d\n",getValAtAddress(sub_ark,add_ptr+24,16));		
			//printf("\t\tOther values 8:%d\n",getValAtAddress(sub_ark,add_ptr+26,16));	
			}		
		break;
		}
	case ACTION_RESURRECTION:
		{//Brings the player back to life?
		if (PrintDebug==1)
			{
			printf("\tACTION_RESURRECTION for %s\n",UniqueObjectName(objList[objIndex]));
			DebugPrintTriggerVals(sub_ark, add_ptr,30);
			//printf("\t\tOther values 1:%d\n",getValAtAddress(sub_ark,add_ptr+12,16));
			//printf("\t\tOther values 2:%d\n",getValAtAddress(sub_ark,add_ptr+14,16));
			//printf("\t\tOther values 3:%d\n",getValAtAddress(sub_ark,add_ptr+16,16));
			//printf("\t\tOther values 4:%d\n",getValAtAddress(sub_ark,add_ptr+18,16));
			//printf("\t\tOther values 5:%d\n",getValAtAddress(sub_ark,add_ptr+20,16));
			//printf("\t\tOther values 6:%d\n",getValAtAddress(sub_ark,add_ptr+22,16));		
			//printf("\t\tOther values 7:%d\n",getValAtAddress(sub_ark,add_ptr+24,16));		
			//printf("\t\tOther values 8:%d\n",getValAtAddress(sub_ark,add_ptr+26,16));	
			}
		objList[objIndex].shockProperties[TRIG_PROPERTY_VALUE] =	getValAtAddress(sub_ark,add_ptr+16,16);	//Target Health
		break;
		}
	case ACTION_CLONE:
		{//Need to do more research on what this does?
		//	000C	int16	Object to transport.
		//	000E	int16	Delete flag?
		//	0010	int16	Tile destination X
		//	0014	int16	Tile destination Y
		//	0018	int16	Destination height?		
		if (PrintDebug==1)
			{
			printf("\tACTION_CLONE for %s\n",UniqueObjectName(objList[objIndex]));
			printf("\t\tObject to transport:%d\n",getValAtAddress(sub_ark,add_ptr+0xC,16));
			printf("\t\tDeleteFlag?:%d\n",getValAtAddress(sub_ark,add_ptr+0xE,16));
			printf("\t\tDestination tileX:%d\n",getValAtAddress(sub_ark,add_ptr+0x10,16));
			printf("\t\tDestination tileY:%d\n",getValAtAddress(sub_ark,add_ptr+0x14,16));
			printf("\t\tDestination height:%d\n",getValAtAddress(sub_ark,add_ptr+0x18,16));
			DebugPrintTriggerVals(sub_ark, add_ptr, 28);
			//printf("\t\tOther values 1:%d\n",getValAtAddress(sub_ark,add_ptr+12,16));
			//printf("\t\tOther values 2:%d\n",getValAtAddress(sub_ark,add_ptr+14,16));
			//printf("\t\tOther values 3:%d\n",getValAtAddress(sub_ark,add_ptr+16,16));
			//printf("\t\tOther values 4:%d\n",getValAtAddress(sub_ark,add_ptr+18,16));
			//printf("\t\tOther values 5:%d\n",getValAtAddress(sub_ark,add_ptr+20,16));
			//printf("\t\tOther values 6:%d\n",getValAtAddress(sub_ark,add_ptr+22,16));		
			//printf("\t\tOther values 7:%d\n",getValAtAddress(sub_ark,add_ptr+24,16));		
			//printf("\t\tOther values 8:%d\n",getValAtAddress(sub_ark,add_ptr+26,16));	

			
		}
		objList[objIndex].shockProperties[TRIG_PROPERTY_OBJECT] =	getValAtAddress(sub_ark,add_ptr+0xC,16);	//obj to transport
		objList[objIndex].shockProperties[TRIG_PROPERTY_FLAG] = getValAtAddress(sub_ark,add_ptr+0x0E,16);		//Delete flag
		objList[objIndex].shockProperties[TRIG_PROPERTY_TARGET_X] = getValAtAddress(sub_ark,add_ptr+0x10,16);	//Target X
		objList[objIndex].shockProperties[TRIG_PROPERTY_TARGET_Y] = getValAtAddress(sub_ark,add_ptr+0x14,16);	//Target Y
		objList[objIndex].shockProperties[TRIG_PROPERTY_TARGET_Z] = getValAtAddress(sub_ark,add_ptr+0x18,16);	//Target z

		break;
		}
	case ACTION_SET_VARIABLE:
		{//Sets a game variable. I don't yet know what the various variables are. I suspect they may be in the exe so I'll have to just observe them in the wild?
		//000C	int16	variable to set
		//0010	int16	value
		//0012	int16	?? action 00 set 01 add
		//0014	int16	Optional message to receive
				if (PrintDebug==1)
					{
					printf("\tACTION_SET_VARIABLE for %s\n",UniqueObjectName(objList[objIndex]));
					printf("\t\tVariable to Set:%d\n",getValAtAddress(sub_ark,add_ptr+0xC,16));
					printf("\t\tValue:%d",getValAtAddress(sub_ark,add_ptr+0x10,16));
					printf("\t\taction?:%d (00 set 01 add)\n",getValAtAddress(sub_ark,add_ptr+0x12,16));
					printf("\t\tOptional Message:%d\n",getValAtAddress(sub_ark,add_ptr+0x14,16));
					DebugPrintTriggerVals(sub_ark, add_ptr, 28);
/*					printf("\t\tOther values 1:%d\n",getValAtAddress(sub_ark,add_ptr+12,16));
					printf("\t\tOther values 2:%d\n",getValAtAddress(sub_ark,add_ptr+14,16));
					printf("\t\tOther values 3:%d\n",getValAtAddress(sub_ark,add_ptr+16,16));
					printf("\t\tOther values 4:%d\n",getValAtAddress(sub_ark,add_ptr+18,16));
					printf("\t\tOther values 5:%d\n",getValAtAddress(sub_ark,add_ptr+20,16));
					printf("\t\tOther values 6:%d\n",getValAtAddress(sub_ark,add_ptr+22,16));		
					printf("\t\tOther values 7:%d\n",getValAtAddress(sub_ark,add_ptr+24,16));		
					printf("\t\tOther values 8:%d\n",getValAtAddress(sub_ark,add_ptr+26,16));	*/					
					}
		objList[objIndex].shockProperties[TRIG_PROPERTY_VARIABLE] =getValAtAddress(sub_ark,add_ptr+0xC,16);
		objList[objIndex].shockProperties[TRIG_PROPERTY_VALUE] = getValAtAddress(sub_ark,add_ptr+0x10,16);
		objList[objIndex].shockProperties[TRIG_PROPERTY_OPERATION]=getValAtAddress(sub_ark,add_ptr+0x12,16);
		objList[objIndex].shockProperties[TRIG_PROPERTY_MESSAGE1]=getValAtAddress(sub_ark,add_ptr+0x14,16);
			
		break;
		}
	case ACTION_ACTIVATE:
		{//Turns on up to 4 other triggers.
		//000C	int16	1st object to activate.
		//000E	int16	Delay before activating object 1.
		//0010	...	Up to 4 objects and delays stored here.	
		objList[objIndex].shockProperties[0] = getValAtAddress(sub_ark,add_ptr+0xC,16)		;					
		objList[objIndex].shockProperties[1] = getValAtAddress(sub_ark,add_ptr+0xe,16)		;
		objList[objIndex].shockProperties[2] = getValAtAddress(sub_ark,add_ptr+0x10,16)		;
		objList[objIndex].shockProperties[3] = getValAtAddress(sub_ark,add_ptr+0x12,16)		;
		objList[objIndex].shockProperties[4] = getValAtAddress(sub_ark,add_ptr+0x14,16)		;
		objList[objIndex].shockProperties[5] = getValAtAddress(sub_ark,add_ptr+0x16,16)		;
		objList[objIndex].shockProperties[6] = getValAtAddress(sub_ark,add_ptr+0x18,16)		;
		objList[objIndex].shockProperties[7] = getValAtAddress(sub_ark,add_ptr+0x1A,16)		;
		if (PrintDebug==1)
			{	
			printf("\tACTION_ACTIVATE for %s\n",UniqueObjectName(objList[objIndex]));

			printf("\t\t1st Object to activate raw :%d\t",objList[objIndex].shockProperties[0]);
			printf("1st Object Delay:%d\n",objList[objIndex].shockProperties[1]);

			printf("\t\t2nd Object to activate raw :%d\t",objList[objIndex].shockProperties[2]);		
			printf("2nd Object Delay:%d\n",objList[objIndex].shockProperties[3]);
			
			printf("\t\t3rd Object to activate raw :%d\t",objList[objIndex].shockProperties[4]);
			printf("3rd Object Delay:%d\n",objList[objIndex].shockProperties[5]);
			
			printf("\t\t4th Object to activate raw :%d\t",objList[objIndex].shockProperties[6]);		
			printf("4th Object Delay:%d\n",objList[objIndex].shockProperties[7]);	
			DebugPrintTriggerVals(sub_ark, add_ptr, 28);
/*			printf("\t\tOther values 1:%d\n",getValAtAddress(sub_ark,add_ptr+12,16));
			printf("\t\tOther values 2:%d\n",getValAtAddress(sub_ark,add_ptr+14,16));
			printf("\t\tOther values 3:%d\n",getValAtAddress(sub_ark,add_ptr+16,16));
			printf("\t\tOther values 4:%d\n",getValAtAddress(sub_ark,add_ptr+18,16));
			printf("\t\tOther values 5:%d\n",getValAtAddress(sub_ark,add_ptr+20,16));
			printf("\t\tOther values 6:%d\n",getValAtAddress(sub_ark,add_ptr+22,16));		
			printf("\t\tOther values 7:%d\n",getValAtAddress(sub_ark,add_ptr+24,16));		
			printf("\t\tOther values 8:%d\n",getValAtAddress(sub_ark,add_ptr+26,16));	*/						
			}

		break;
		}
	case ACTION_LIGHTING:
		{//Controls lighting between the specified control points. The control points are usually null triggers but are sometimes regular objects as well.
		//000C	int16	Control point 1
		//000E	int16	Control point 2
		//	...	?

		objList[objIndex].shockProperties[TRIG_PROPERTY_CONTROL_1] 	= getValAtAddress(sub_ark,add_ptr+12,16);
		objList[objIndex].shockProperties[TRIG_PROPERTY_CONTROL_2] 	= getValAtAddress(sub_ark,add_ptr+14,16);
		objList[objIndex].shockProperties[TRIG_PROPERTY_UPPERSHADE_1] = getValAtAddress(sub_ark, add_ptr + 22, 8);
		objList[objIndex].shockProperties[TRIG_PROPERTY_LOWERSHADE_1] = getValAtAddress(sub_ark, add_ptr + 24, 8);
		objList[objIndex].shockProperties[TRIG_PROPERTY_UPPERSHADE_2] = getValAtAddress(sub_ark, add_ptr + 23, 8);
		objList[objIndex].shockProperties[TRIG_PROPERTY_LOWERSHADE_2] = getValAtAddress(sub_ark, add_ptr + 25, 8);
		if (PrintDebug==1)
			{
			printf("\tACTION_LIGHTING for %s\n",UniqueObjectName(objList[objIndex]));
			printf("\t\tControl point 1:%d\n",objList[objIndex].shockProperties[TRIG_PROPERTY_CONTROL_1]);
			printf("\t\tControl point 2:%d\n", objList[objIndex].shockProperties[TRIG_PROPERTY_CONTROL_2]);
			printf("\t\t1st Time Upper Shade adjustment = %d\n", objList[objIndex].shockProperties[TRIG_PROPERTY_UPPERSHADE_1]);
			printf("\t\t1st Time Lower Shade adjustment = %d\n", objList[objIndex].shockProperties[TRIG_PROPERTY_LOWERSHADE_1]);
			printf("\t\t2nd Time Upper Shade adjustment = %d\n", objList[objIndex].shockProperties[TRIG_PROPERTY_UPPERSHADE_2]);
			printf("\t\t2nd Time Lower Shade adjustment = %d\n", objList[objIndex].shockProperties[TRIG_PROPERTY_LOWERSHADE_2]);
			DebugPrintTriggerVals(sub_ark, add_ptr, 28);
			//printf("\t\tOther values 1:%d\n",getValAtAddress(sub_ark,add_ptr+12,16));
			//printf("\t\tOther values 2:%d\n",getValAtAddress(sub_ark,add_ptr+14,16));
			//printf("\t\tOther values 3:%d\n",getValAtAddress(sub_ark,add_ptr+16,16));
			//printf("\t\tOther values 4:%d\n",getValAtAddress(sub_ark,add_ptr+18,16));
			//printf("\t\tOther values 5:%d\n",getValAtAddress(sub_ark,add_ptr+20,16));
			//printf("\t\tOther values 6:%d\n",getValAtAddress(sub_ark,add_ptr+22,16));		
			//printf("\t\tOther values 7:%d\n",getValAtAddress(sub_ark,add_ptr+24,16));		
			//printf("\t\tOther values 8:%d\n",getValAtAddress(sub_ark,add_ptr+26,16));	
		}			
		break;
		}
	case ACTION_EFFECT:
		{//Preforms a special effect. One example is the power breaker sparking on research level.
		if (PrintDebug==1)
			{
			printf("\tACTION_EFFECT for %s\n",UniqueObjectName(objList[objIndex]));
			DebugPrintTriggerVals(sub_ark, add_ptr, 28);
			//printf("\t\tOther values 1:%d\n",getValAtAddress(sub_ark,add_ptr+12,16));
			//printf("\t\tOther values 2:%d\n",getValAtAddress(sub_ark,add_ptr+14,16));
			//printf("\t\tOther values 3:%d\n",getValAtAddress(sub_ark,add_ptr+16,16));
			//printf("\t\tOther values 4:%d\n",getValAtAddress(sub_ark,add_ptr+18,16));
			//printf("\t\tOther values 5:%d\n",getValAtAddress(sub_ark,add_ptr+20,16));
			//printf("\t\tOther values 6:%d\n",getValAtAddress(sub_ark,add_ptr+22,16));		
			//printf("\t\tOther values 7:%d\n",getValAtAddress(sub_ark,add_ptr+24,16));		
			//printf("\t\tOther values 8:%d\n",getValAtAddress(sub_ark,add_ptr+26,16));	
			}		
		break;
		}
	case ACTION_MOVING_PLATFORM:
		{//Usually a lift or a blast door type setup. Both the floor and ceiling have parameters in this.

		setElevatorProperties(LevelInfo, sub_ark,add_ptr,objList, objIndex,PrintDebug);
		//objList[objIndex].shockProperties[TRIG_PROPERTY_TARGET_X] = getValAtAddress(sub_ark,add_ptr+0x0C,16);
		//objList[objIndex].shockProperties[TRIG_PROPERTY_TARGET_Y] = getValAtAddress(sub_ark,add_ptr+0x10,16);
		//objList[objIndex].shockProperties[TRIG_PROPERTY_FLOOR] = getValAtAddress(sub_ark,add_ptr+0x14,16);	//5
		//objList[objIndex].shockProperties[TRIG_PROPERTY_CEILING] = getValAtAddress(sub_ark,add_ptr+0x16,16);	//6
		//objList[objIndex].shockProperties[TRIG_PROPERTY_SPEED] = getValAtAddress(sub_ark,add_ptr+0x18,16);
		//LevelInfo[objList[objIndex].shockProperties[TRIG_PROPERTY_TARGET_X]][objList[objIndex].shockProperties[TRIG_PROPERTY_TARGET_Y]].hasElevator =1;
		//
		//short ceilingFlag = (objList[objIndex].shockProperties[TRIG_PROPERTY_CEILING]<=SHOCK_CEILING_HEIGHT);
		//short floorFlag = (objList[objIndex].shockProperties[TRIG_PROPERTY_FLOOR] <= SHOCK_CEILING_HEIGHT);
		//short elevatorFlag = (ceilingFlag << 1) | (floorFlag);
		//
		//LevelInfo[objList[objIndex].shockProperties[TRIG_PROPERTY_TARGET_X]][objList[objIndex].shockProperties[TRIG_PROPERTY_TARGET_Y]].hasElevator &= elevatorFlag;
		
		break;
		
		}
	case ACTION_TIMER:
		{//Delays the trigger getting fired off. A good example is the aftermath of destroying the CPUs on hospital level.
		//000C	int16	1st object to activate.?
		//000E	int16	Delay before activating object 1.?

		objList[objIndex].shockProperties[0] = getValAtAddress(sub_ark, add_ptr + 0xC, 16);
		objList[objIndex].shockProperties[1] = getValAtAddress(sub_ark, add_ptr + 0xe, 16);
		objList[objIndex].shockProperties[2] = getValAtAddress(sub_ark, add_ptr + 0x10, 16);
		objList[objIndex].shockProperties[3] = getValAtAddress(sub_ark, add_ptr + 0x12, 16);
		objList[objIndex].shockProperties[4] = getValAtAddress(sub_ark, add_ptr + 0x14, 16);
		objList[objIndex].shockProperties[5] = getValAtAddress(sub_ark, add_ptr + 0x16, 16);
		objList[objIndex].shockProperties[6] = getValAtAddress(sub_ark, add_ptr + 0x18, 16);
		objList[objIndex].shockProperties[7] = getValAtAddress(sub_ark, add_ptr + 0x1A, 16);
		if (PrintDebug == 1)
			{
				printf("\tACTION_TIMER (i think) for %s\n", UniqueObjectName(objList[objIndex]));

				printf("\t\t1st Object to activate raw :%d\t", objList[objIndex].shockProperties[0]);
				printf("1st Object Delay:%d\n", objList[objIndex].shockProperties[1]);

				DebugPrintTriggerVals(sub_ark, add_ptr, 28);
			}
		}
	case ACTION_CHOICE:
		{//A toggle?
		//000C	int16	Trigger 1
		//0010	int16	Trigger 2

		objList[objIndex].shockProperties[TRIG_PROPERTY_TRIG_1] = getValAtAddress(sub_ark,add_ptr+0x0C,16);	
		objList[objIndex].shockProperties[TRIG_PROPERTY_TRIG_2] = getValAtAddress(sub_ark,add_ptr+0x10,16);	
		if (PrintDebug==1)
			{
			printf("\tACTION_CHOICE for %s\n",UniqueObjectName(objList[objIndex]));
			printf("\t\tTrigger1:%d\n",objList[objIndex].shockProperties[TRIG_PROPERTY_TRIG_1]);
			printf("\t\tTrigger2:%d\n",objList[objIndex].shockProperties[TRIG_PROPERTY_TRIG_2]);
			DebugPrintTriggerVals(sub_ark, add_ptr, 28);
			//printf("\t\tOther values 1:%d\n",getValAtAddress(sub_ark,add_ptr+12,16));
			//printf("\t\tOther values 2:%d\n",getValAtAddress(sub_ark,add_ptr+14,16));
			//printf("\t\tOther values 3:%d\n",getValAtAddress(sub_ark,add_ptr+16,16));
			//printf("\t\tOther values 4:%d\n",getValAtAddress(sub_ark,add_ptr+18,16));
			//printf("\t\tOther values 5:%d\n",getValAtAddress(sub_ark,add_ptr+20,16));
			//printf("\t\tOther values 6:%d\n",getValAtAddress(sub_ark,add_ptr+22,16));		
			//printf("\t\tOther values 7:%d\n",getValAtAddress(sub_ark,add_ptr+24,16));		
			//printf("\t\tOther values 8:%d\n",getValAtAddress(sub_ark,add_ptr+26,16));	
			}
		break;
		}
	case ACTION_EMAIL:
		{//Sends the player an email. (Differs from a message in that a message just plays once and does not hit the data reader)
		if (PrintDebug==1)
			{
		printf("\tACTION_EMAIL for %s\n",UniqueObjectName(objList[objIndex]));
		//	0F Player receives email
		//000C	int16	Chunk no. of email (offset from 2441 0x0989)
		//Note the subject line of an email may be used to chain a sequence of emails together (see sspecs)
		printf("\t\tEmail chunk:", getValAtAddress(sub_ark,add_ptr+0x0C,16)+2441);
		DebugPrintTriggerVals(sub_ark, add_ptr, 28);
/*			printf("\t\tOther values 1:%d\n",getValAtAddress(sub_ark,add_ptr+12,16));
			printf("\t\tOther values 2:%d\n",getValAtAddress(sub_ark,add_ptr+14,16));
			printf("\t\tOther values 3:%d\n",getValAtAddress(sub_ark,add_ptr+16,16));
			printf("\t\tOther values 4:%d\n",getValAtAddress(sub_ark,add_ptr+18,16));
			printf("\t\tOther values 5:%d\n",getValAtAddress(sub_ark,add_ptr+20,16));
			printf("\t\tOther values 6:%d\n",getValAtAddress(sub_ark,add_ptr+22,16));		
			printf("\t\tOther values 7:%d\n",getValAtAddress(sub_ark,add_ptr+24,16));		
			printf("\t\tOther values 8:%d\n",getValAtAddress(sub_ark,add_ptr+26,16));*/	
		}			
		objList[objIndex].shockProperties[TRIG_PROPERTY_EMAIL] =getValAtAddress(sub_ark,add_ptr+0x0C,16)+2441;
		
		break;
		
		}
	case ACTION_RADAWAY:
		{//Radiation healing on the reactor?
			if (PrintDebug==1)
				{
				printf("\tACTION_RADAWAY for %s\n",UniqueObjectName(objList[objIndex]));
				DebugPrintTriggerVals(sub_ark, add_ptr, 28);
/*				printf("\t\tOther values 1:%d\n",getValAtAddress(sub_ark,add_ptr+12,16));
				printf("\t\tOther values 2:%d\n",getValAtAddress(sub_ark,add_ptr+14,16));
				printf("\t\tOther values 3:%d\n",getValAtAddress(sub_ark,add_ptr+16,16));
				printf("\t\tOther values 4:%d\n",getValAtAddress(sub_ark,add_ptr+18,16));
				printf("\t\tOther values 5:%d\n",getValAtAddress(sub_ark,add_ptr+20,16));
				printf("\t\tOther values 6:%d\n",getValAtAddress(sub_ark,add_ptr+22,16));		
				printf("\t\tOther values 7:%d\n",getValAtAddress(sub_ark,add_ptr+24,16));		
				printf("\t\tOther values 8:%d\n",getValAtAddress(sub_ark,add_ptr+26,16));*/	
				}
		break;
		}
	case ACTION_CHANGE_STATE:
		{//Used a lot in switches. Needs more research.
		if (PrintDebug==1)
			{
			printf("\tACTION_CHANGE_STATE for %s\n",UniqueObjectName(objList[objIndex]));
			DebugPrintTriggerVals(sub_ark, add_ptr, 28);
			//printf("\t\tOther values 1:%d\n",getValAtAddress(sub_ark,add_ptr+12,16));
			//printf("\t\tOther values 2:%d\n",getValAtAddress(sub_ark,add_ptr+14,16));
			//printf("\t\tOther values 3:%d\n",getValAtAddress(sub_ark,add_ptr+16,16));
			//printf("\t\tOther values 4:%d\n",getValAtAddress(sub_ark,add_ptr+18,16));
			//printf("\t\tOther values 5:%d\n",getValAtAddress(sub_ark,add_ptr+20,16));
			//printf("\t\tOther values 6:%d\n",getValAtAddress(sub_ark,add_ptr+22,16));		
			//printf("\t\tOther values 7:%d\n",getValAtAddress(sub_ark,add_ptr+24,16));		
			//printf("\t\tOther values 8:%d\n",getValAtAddress(sub_ark,add_ptr+26,16));	
			}
		break;
		}
	case ACTION_MESSAGE:
		{//A once off message. For example the computer voice when the cyborg conversion is activated.
		//16 Trap message offset in Chunk 2151 
		//000C	int16	"Success" message
		//0010	int16	"Fail" message
		objList[objIndex].shockProperties[TRIG_PROPERTY_MESSAGE1]=getValAtAddress(sub_ark,add_ptr+0x0C,16);
		objList[objIndex].shockProperties[TRIG_PROPERTY_MESSAGE2]=getValAtAddress(sub_ark,add_ptr+0x10,16);
		if (PrintDebug==1)
			{
			printf("\tACTION_MESSAGE for %s\n",UniqueObjectName(objList[objIndex]));
			printf("\t\tSuccess Message%d\n",objList[objIndex].shockProperties[TRIG_PROPERTY_MESSAGE1]);
			printf("\t\tFail Message:%d\n",objList[objIndex].shockProperties[TRIG_PROPERTY_MESSAGE2]);
			DebugPrintTriggerVals(sub_ark, add_ptr, 28);
/*			printf("\t\tOther values 1:%d\n",getValAtAddress(sub_ark,add_ptr+12,16));
			printf("\t\tOther values 2:%d\n",getValAtAddress(sub_ark,add_ptr+14,16));
			printf("\t\tOther values 3:%d\n",getValAtAddress(sub_ark,add_ptr+16,16));
			printf("\t\tOther values 4:%d\n",getValAtAddress(sub_ark,add_ptr+18,16));
			printf("\t\tOther values 5:%d\n",getValAtAddress(sub_ark,add_ptr+20,16));
			printf("\t\tOther values 6:%d\n",getValAtAddress(sub_ark,add_ptr+22,16));		
			printf("\t\tOther values 7:%d\n",getValAtAddress(sub_ark,add_ptr+24,16));		
			printf("\t\tOther values 8:%d\n",getValAtAddress(sub_ark,add_ptr+26,16));	*/	
			}			
		break;
		}
	case ACTION_SPAWN:	
		{
		//000C	int32	Class/subclass/type of object to spawn
		//0010	int16	Control point 1 (object)
		//0012	int16	Control point 2 (object)
		//0014		??
		//0018		??	

		objList[objIndex].shockProperties[TRIG_PROPERTY_TYPE]=getValAtAddress(sub_ark,add_ptr+0x0C,32);
		objList[objIndex].shockProperties[TRIG_PROPERTY_CONTROL_1]=getValAtAddress(sub_ark,add_ptr+0x10,16);
		objList[objIndex].shockProperties[TRIG_PROPERTY_CONTROL_2]=getValAtAddress(sub_ark,add_ptr+0x12,16);
		if (PrintDebug==1)
			{
			printf("\tACTION_SPAWN for %s\n",UniqueObjectName(objList[objIndex]));
			printf("\t\Class-sub-type to spawn:%d\n",objList[objIndex].shockProperties[TRIG_PROPERTY_TYPE]);
			printf("\t\tControl point object1:%d\n",objList[objIndex].shockProperties[TRIG_PROPERTY_CONTROL_1]);
			printf("\t\tControl point object2:%d\n",objList[objIndex].shockProperties[TRIG_PROPERTY_CONTROL_2]);
			printf("\t\t??:%d\n",getValAtAddress(sub_ark,add_ptr+0x14,16));		
			printf("\t\t??:%d\n",getValAtAddress(sub_ark,add_ptr+0x18,16));	
			DebugPrintTriggerVals(sub_ark, add_ptr, 28);
/*			printf("\t\tOther values 1:%d\n",getValAtAddress(sub_ark,add_ptr+12,16));
			printf("\t\tOther values 2:%d\n",getValAtAddress(sub_ark,add_ptr+14,16));
			printf("\t\tOther values 3:%d\n",getValAtAddress(sub_ark,add_ptr+16,16));
			printf("\t\tOther values 4:%d\n",getValAtAddress(sub_ark,add_ptr+18,16));
			printf("\t\tOther values 5:%d\n",getValAtAddress(sub_ark,add_ptr+20,16));
			printf("\t\tOther values 6:%d\n",getValAtAddress(sub_ark,add_ptr+22,16));		
			printf("\t\tOther values 7:%d\n",getValAtAddress(sub_ark,add_ptr+24,16));		
			printf("\t\tOther values 8:%d\n",getValAtAddress(sub_ark,add_ptr+26,16));		*/	
			}
				break;
		}	
	case ACTION_CHANGE_TYPE:
		{
		//000C	int16	Object ID to change.
		//0010	int8	New type.
		//0012		??

		objList[objIndex].shockProperties[TRIG_PROPERTY_OBJECT] =getValAtAddress(sub_ark,add_ptr+0x0C,16);
		objList[objIndex].shockProperties[TRIG_PROPERTY_TYPE] =getValAtAddress(sub_ark,add_ptr+0x10,8);
		if (PrintDebug==1)
			{
			printf("\tACTION_CHANGE_TYPE for %s\n",UniqueObjectName(objList[objIndex]));
			printf("\t\Object to Change:%d\n",objList[objIndex].shockProperties[TRIG_PROPERTY_OBJECT]);
			printf("\t\tNew Type (within subclass):%d\n",objList[objIndex].shockProperties[TRIG_PROPERTY_TYPE]);
			//printf("\t\tChanges to %s\n", getObjectNameByClass(objList[objIndex].ObjectClass, objList[objIndex].ObjectSubClass, objList[objIndex].ObjectSubClassIndex);
			printf("\t\t??:%d\n",getValAtAddress(sub_ark,add_ptr+0x12,16));	
			DebugPrintTriggerVals(sub_ark, add_ptr, 28);
/*			printf("\t\tOther values 1:%d\n",getValAtAddress(sub_ark,add_ptr+12,16));
			printf("\t\tOther values 2:%d\n",getValAtAddress(sub_ark,add_ptr+14,16));
			printf("\t\tOther values 3:%d\n",getValAtAddress(sub_ark,add_ptr+16,16));
			printf("\t\tOther values 4:%d\n",getValAtAddress(sub_ark,add_ptr+18,16));
			printf("\t\tOther values 5:%d\n",getValAtAddress(sub_ark,add_ptr+20,16));
			printf("\t\tOther values 6:%d\n",getValAtAddress(sub_ark,add_ptr+22,16));		
			printf("\t\tOther values 7:%d\n",getValAtAddress(sub_ark,add_ptr+24,16));		
			printf("\t\tOther values 8:%d\n",getValAtAddress(sub_ark,add_ptr+26,16));	*/		
			}			
		break;
		}
	default:
		{
		if (PrintDebug==1)
			{
				printf("\tUnknown triggeraction:%d for %s\n",TriggerType, UniqueObjectName(objList[objIndex]));
				DebugPrintTriggerVals(sub_ark, add_ptr, 28);
/*				printf("\t\tOther values 1:%d\n",getValAtAddress(sub_ark,add_ptr+12,16));
				printf("\t\tOther values 2:%d\n",getValAtAddress(sub_ark,add_ptr+14,16));
				printf("\t\tOther values 3:%d\n",getValAtAddress(sub_ark,add_ptr+16,16));
				printf("\t\tOther values 4:%d\n",getValAtAddress(sub_ark,add_ptr+18,16));
				printf("\t\tOther values 5:%d\n",getValAtAddress(sub_ark,add_ptr+20,16));
				printf("\t\tOther values 6:%d\n",getValAtAddress(sub_ark,add_ptr+22,16));		
				printf("\t\tOther values 7:%d\n",getValAtAddress(sub_ark,add_ptr+24,16));		
				printf("\t\tOther values 8:%d\n",getValAtAddress(sub_ark,add_ptr+26,16));	*/		
			}
		}	
	
	}

}

int LookupxRefTable(xrefTable *xref,int x, int y, int MasterIndex, int tableSize)
{
//Gets the index of the xref table at those xy coords for that particular master index
//Ugly but I want to get the specific table for that xy and object.
for (int i = 0; i <tableSize;i++)
	{
	if ((xref[i].tileX == x) && (xref[i].tileY == y) && (xref[i].MstIndex == MasterIndex) )
		{
		return i;
		}
	}
return -1;
}

void replaceLink(xrefTable *xref, int tableSize, int indexToFind, int linkToReplace)
	{
	if ((indexToFind==0) && (linkToReplace ==0))
		{return;}
	for (int i=0; i<tableSize;i++)
		{
		if (xref[i].next == indexToFind)
			{
			xref[i].next =linkToReplace;
			}
		}
	}
void replaceMapLink(tile levelInfo[64][64], xrefTable *xref, int tableSize, int indexToFind, int linkToReplace)
{
	if ((indexToFind==0) && (linkToReplace ==0))
		{return;}
		
	for (int x=0;x<64;x++)
		{
		for(int y=0;y<64;y++)
		{
			{
			if (levelInfo[x][y].indexObjectList == indexToFind)
				{
				levelInfo[x][y].indexObjectList=linkToReplace;
				}
			}
		}
	}
}


void getShockButtons(tile LevelInfo[64][64],unsigned char *sub_ark,int add_ptr, ObjectItem objList[1600], int objIndex)
{

	//printf("\n\tVal_oc: %d\n" ,getValAtAddress(sub_ark,add_ptr+0x0c,16));
	//printf("\tVal_oe: %d\n" ,getValAtAddress(sub_ark,add_ptr+0x0E,16));
	//printf("\tVal_10: %d\n" ,getValAtAddress(sub_ark,add_ptr+0x10,16));
	//printf("\tVal_12: %d\n" ,getValAtAddress(sub_ark,add_ptr+0x12,16));
	//printf("\tVal_14: %d\n" ,getValAtAddress(sub_ark,add_ptr+0x14,16));
	//printf("\tVal_16: %d\n" ,getValAtAddress(sub_ark,add_ptr+0x16,16));
	//printf("\tVal_18: %d\n" ,getValAtAddress(sub_ark,add_ptr+0x18,16));
	//printf("\tVal_1a: %d\n" ,getValAtAddress(sub_ark,add_ptr+0x1A,16));	
	//
	printf("\tSwitch Properties\n");
if (objList[objIndex].ObjectSubClass ==0)
	{//regular buttons and switches
	switch (objList[objIndex].TriggerAction)	//Switches have action types as well.
		{	
		case ACTION_ACTIVATE:
				{	//Assume same behaviour as a trigger?
				printf("Switch:Action_Activate\n");
				objList[objIndex].shockProperties[0] = getValAtAddress(sub_ark,add_ptr+0xC,16)		;					
				objList[objIndex].shockProperties[1] = getValAtAddress(sub_ark,add_ptr+0xe,16)		;
				objList[objIndex].shockProperties[2] = getValAtAddress(sub_ark,add_ptr+0x10,16)		;
				objList[objIndex].shockProperties[3] = getValAtAddress(sub_ark,add_ptr+0x12,16)		;
				objList[objIndex].shockProperties[4] = getValAtAddress(sub_ark,add_ptr+0x14,16)		;
				objList[objIndex].shockProperties[5] = getValAtAddress(sub_ark,add_ptr+0x16,16)		;
				objList[objIndex].shockProperties[6] = getValAtAddress(sub_ark,add_ptr+0x18,16)		;
				objList[objIndex].shockProperties[7] = getValAtAddress(sub_ark,add_ptr+0x1A,16)		;				
				break;
				}
		case ACTION_MOVING_PLATFORM:
				{
				printf("Switch:Action_Moving_Platform\n");
				setElevatorProperties(LevelInfo,sub_ark,add_ptr,objList,objIndex,1);
				}
		case ACTION_CHOICE:
				{
				printf("Switch:Action_Choice\n");
				objList[objIndex].shockProperties[TRIG_PROPERTY_TRIG_1] = getValAtAddress(sub_ark, add_ptr + 0x0C, 16);
				objList[objIndex].shockProperties[TRIG_PROPERTY_TRIG_2] = getValAtAddress(sub_ark, add_ptr + 0x10, 16);
				break;
				}
		case ACTION_LIGHTING:
				{	
				printf("Switch:Action_Lighting\n");
				objList[objIndex].shockProperties[TRIG_PROPERTY_CONTROL_1] = getValAtAddress(sub_ark, add_ptr + 12, 16);
				if (objList[objIndex].shockProperties[TRIG_PROPERTY_CONTROL_1] <= 3)
					{	//seems to be a special case?
					objList[objIndex].shockProperties[TRIG_PROPERTY_CONTROL_1] = objIndex;
					}
				objList[objIndex].shockProperties[TRIG_PROPERTY_CONTROL_2] = getValAtAddress(sub_ark, add_ptr + 14, 16);
				objList[objIndex].shockProperties[TRIG_PROPERTY_UPPERSHADE_1] = getValAtAddress(sub_ark, add_ptr + 22, 8);
				objList[objIndex].shockProperties[TRIG_PROPERTY_LOWERSHADE_1] = getValAtAddress(sub_ark, add_ptr + 24, 8);
				objList[objIndex].shockProperties[TRIG_PROPERTY_UPPERSHADE_2] = getValAtAddress(sub_ark, add_ptr + 23, 8);
				objList[objIndex].shockProperties[TRIG_PROPERTY_LOWERSHADE_2] = getValAtAddress(sub_ark, add_ptr + 25, 8);
				printf("\t\tControl point 1:%d\n", objList[objIndex].shockProperties[TRIG_PROPERTY_CONTROL_1]);
				printf("\t\tControl point 2:%d\n", objList[objIndex].shockProperties[TRIG_PROPERTY_CONTROL_2]);
				printf("\t\t1st Time Upper Shade adjustment = %d\n", objList[objIndex].shockProperties[TRIG_PROPERTY_UPPERSHADE_1]);
				printf("\t\t1st Time Lower Shade adjustment = %d\n", objList[objIndex].shockProperties[TRIG_PROPERTY_LOWERSHADE_1]);
				printf("\t\t2nd Time Upper Shade adjustment = %d\n", objList[objIndex].shockProperties[TRIG_PROPERTY_UPPERSHADE_2]);
				printf("\t\t2nd Time Lower Shade adjustment = %d\n", objList[objIndex].shockProperties[TRIG_PROPERTY_LOWERSHADE_2]);
				break;
				}
		case ACTION_CHANGE_TYPE:
				{
				printf("Switch:Action_Change_Type\n");
				objList[objIndex].shockProperties[TRIG_PROPERTY_OBJECT] = getValAtAddress(sub_ark, add_ptr + 0x0C, 16);
				objList[objIndex].shockProperties[TRIG_PROPERTY_TYPE] = getValAtAddress(sub_ark, add_ptr + 0x10, 8);
				}
		default:	
				{
				printf("Switch:Default\n");
				objList[objIndex].shockProperties[BUTTON_PROPERTY_TRIGGER] = getValAtAddress(sub_ark,add_ptr+12,16);
				objList[objIndex].shockProperties[BUTTON_PROPERTY_TRIGGER_2] = getValAtAddress(sub_ark,add_ptr+16,16);
				}
		}
		
		printf("\tDefault trigger target %d",objList[objIndex].shockProperties[BUTTON_PROPERTY_TRIGGER]);
		//printf("\n\tVal_oc: %d\n" ,getValAtAddress(sub_ark,add_ptr+0x0c,16));
		//printf("\tVal_oe: %d\n" ,getValAtAddress(sub_ark,add_ptr+0x0E,16));
		//printf("\tVal_10: %d\n" ,getValAtAddress(sub_ark,add_ptr+0x10,16));
		//printf("\tVal_12: %d\n" ,getValAtAddress(sub_ark,add_ptr+0x12,16));
		//printf("\tVal_14: %d\n" ,getValAtAddress(sub_ark,add_ptr+0x14,16));
		//printf("\tVal_16: %d\n" ,getValAtAddress(sub_ark,add_ptr+0x16,16));
		//printf("\tVal_18: %d\n" ,getValAtAddress(sub_ark,add_ptr+0x18,16));
		//printf("\tVal_1a: %d\n" ,getValAtAddress(sub_ark,add_ptr+0x1A,16));	
		DebugPrintTriggerVals(sub_ark, add_ptr, 30);
			
	return;
	}
if((objList[objIndex].ObjectSubClass==2) && (objList[objIndex].ObjectSubClassIndex==0))
	{//cyberspace terminal
	//000C  int16 X of target Cyberspace
	//0010  int16 Y of target Cyberspace
	//0014  int16 Z of target Cyberspace
	//0018  int16 Level (Cyberspace)
	objList[objIndex].shockProperties[0] = getValAtAddress(sub_ark,add_ptr+0x0c,16); 
	objList[objIndex].shockProperties[1] = getValAtAddress(sub_ark,add_ptr+0x10,16); 
	objList[objIndex].shockProperties[2] = getValAtAddress(sub_ark,add_ptr+0x14,16); 
	objList[objIndex].shockProperties[3] = getValAtAddress(sub_ark,add_ptr+0x18,16); 
	printf("\tCyberspace (%d,%d,%d @ %d)\n",objList[objIndex].shockProperties[0],objList[objIndex].shockProperties[1],objList[objIndex].shockProperties[2],objList[objIndex].shockProperties[3]);
	return;
	}

if((objList[objIndex].ObjectSubClass==2) && (objList[objIndex].ObjectSubClassIndex>=1))
	{//Fixup station/energy station
	objList[objIndex].shockProperties[0]  = getValAtAddress(sub_ark,add_ptr+0x0c,16);   //Amount of charge?/? always 255
	objList[objIndex].shockProperties[1]  = getValAtAddress(sub_ark,add_ptr+0x10,16);	//Security level?? //reuse timer??
	printf("\tEnergy Charge: %d %d\n",objList[objIndex].shockProperties[0] ,objList[objIndex].shockProperties[1] );
	return;
	}
if((objList[objIndex].ObjectSubClass==3) && (objList[objIndex].ObjectSubClassIndex<=3))
	{	
	//puzzle panels. need to see them in the wild before I know what other stuff does
	objList[objIndex].shockProperties[BUTTON_PROPERTY_TRIGGER]=getValAtAddress(sub_ark,add_ptr+0x0c,16);
	
	//if bit 28 is set (0x10000000) it is a block puzzle, else it is a wire puzzle.
	objList[objIndex].shockProperties[BUTTON_PROPERTY_PUZZLE]= (getValAtAddress(sub_ark,add_ptr+0x10,8)>>28) & 0x01;
	if (objList[objIndex].shockProperties[BUTTON_PROPERTY_PUZZLE] == 1)
		{
		printf("\tPuzzle panel: Type is block\n");
		}
	else
		{
		printf("\tPuzzle panel: Type is wire\n");
		}
	printf("\tTrigger is %d",objList[objIndex].shockProperties[BUTTON_PROPERTY_TRIGGER]);
	return;
	}

if((objList[objIndex].ObjectSubClass==3) && ((objList[objIndex].ObjectSubClassIndex==4) || (objList[objIndex].ObjectSubClassIndex==5) || (objList[objIndex].ObjectSubClassIndex==6)))
	{//elevators

	//Elevators (9 3 5):
	//000C  int16 Map index of Panel of target Level1 (this means the panel no itself!)
	//000E  int16 Map index of Panel of target Level2
	//0012  int16 Map index of Panel of target Level3
	//0018  int16 Bitfield of accessible Levels (Actual)
	//001A  int16 Bitfield of accessible Levels (Shaft)
	//	    Levels with a 1 in the "shaft" field but not in the "Actual" field
	//	     give a "Shaft damage: Unable to go there" message.
		
	objList[objIndex].shockProperties[0]  = getValAtAddress(sub_ark,add_ptr+0x0c,16);//elevator panel ids
	objList[objIndex].shockProperties[1]  = getValAtAddress(sub_ark,add_ptr+0x0E,16);
	objList[objIndex].shockProperties[2]  = getValAtAddress(sub_ark,add_ptr+0x12,16);
	objList[objIndex].shockProperties[3]  = getValAtAddress(sub_ark,add_ptr+0x18,16);//bitfields for access
	objList[objIndex].shockProperties[4]  = getValAtAddress(sub_ark,add_ptr+0x1A,16);
	printf("\tElevator to one of %d, %d or %d panels on other levels\n",objList[objIndex].shockProperties[0],objList[objIndex].shockProperties[2],objList[objIndex].shockProperties[2]);
	printf("\tAccesable levels actual:%d shaft:%d\n",objList[objIndex].shockProperties[3],objList[objIndex].shockProperties[4]);
	
	return;
	}

if((objList[objIndex].ObjectSubClass==3) && ((objList[objIndex].ObjectSubClassIndex==7) || (objList[objIndex].ObjectSubClassIndex==8) ))
	{
	//Number Pads
	//000C	int16	Combination in BCD
	//000E  int16 Map Object to trigger
	//0018  int16 Map Object to Extra Trigger (?)
	int combo =getValAtAddress(sub_ark,add_ptr+0x0c,16);
	int value = 
		(combo & 0x0F) * 1
		+(combo>>4 & 0x0F) * 10
		+(combo>>8 & 0x0F) * 100;
	objList[objIndex].shockProperties[BUTTON_PROPERTY_COMBO]  =value;	// getValAtAddress(sub_ark,add_ptr+0x0c,16);
	
	objList[objIndex].shockProperties[BUTTON_PROPERTY_TRIGGER]  = getValAtAddress(sub_ark,add_ptr+0x0E,16);
	objList[objIndex].shockProperties[3]  = getValAtAddress(sub_ark,add_ptr+0x18,16);	//extra trigger?
	printf("\tNumber pad. Combo is %d, Triggers %d",objList[objIndex].shockProperties[BUTTON_PROPERTY_COMBO],objList[objIndex].shockProperties[BUTTON_PROPERTY_TRIGGER] );
	return;
	}

//unknown object if all other tests fail. set the usual trigger value and keep an eye on this statement in debugging.
objList[objIndex].shockProperties[BUTTON_PROPERTY_TRIGGER]=getValAtAddress(sub_ark,add_ptr+0x0c,16);
/*	shockProperties[0]  = getValAtAddress(sub_ark,add_ptr+0x0c,16);   
	shockProperties[1]  = getValAtAddress(sub_ark,add_ptr+0x10,16);	
	shockProperties[2]  = getValAtAddress(sub_ark,add_ptr+0x12,16);
	shockProperties[3]  = getValAtAddress(sub_ark,add_ptr+0x14,16);
	shockProperties[4]  = getValAtAddress(sub_ark,add_ptr+0x16,16);
	shockProperties[5]  = getValAtAddress(sub_ark,add_ptr+0x18,16);
	shockProperties[6]  = getValAtAddress(sub_ark,add_ptr+0x1A,16);
	shockProperties[7]  = getValAtAddress(sub_ark,add_ptr+0x1B,16);
	shockProperties[8]  = getValAtAddress(sub_ark,add_ptr+0x1C,16);	*/	
	printf("\tUnknown button type!");
	DebugPrintTriggerVals(sub_ark, add_ptr, 30);

}




char *UniqueObjectName(ObjectItem currObj)
{//returns a unique name for the object
	char str[80] = "";
	switch (objectMasters[currObj.item_id].type)
	{
		case KEY:
			if (currObj.keyCount >= 0)
				{
				if (GAME != SHOCK)
					{
					sprintf_s(str, 80,"%s_%03d_%d\0", objectMasters[currObj.item_id].desc, currObj.owner, currObj.keyCount);
					return str;
					break;
					}
				else
					{
					sprintf_s(str, 80, "%s_%d\0", objectMasters[currObj.item_id].desc, currObj.keyCount);
					return str;
					break;
					}
				}
		default:
			{
				//_snprintf(str,80,"%s_%02d_%02d_%02d_%04d", objectMasters[currObj.item_id].desc, currObj.tileX, currObj.tileY, currObj.levelno ,currObj.index);
				sprintf_s(str, 80, "%s_%02d_%02d_%02d_%04d\0", objectMasters[currObj.item_id].desc, currObj.tileX, currObj.tileY, currObj.levelno, currObj.index);
				return str;
				break;
			}
	}
}

char *getObjectNameByClass(int objClass, int subClass, int subClassIndex)
{
	for (int i = 0; i < 475; i++)
	{
		if ((objectMasters[i].objClass == objClass) &&
			(objectMasters[i].objSubClass == subClass) &&
			(objectMasters[i].objSubClassIndex == subClassIndex))
		{
			return objectMasters[i].desc;
		}
	}
}

int getObjectIDByClass(int objClass, int subClass, int subClassIndex)
{
	for (int i = 0; i < 475; i++)
	{
		if ((objectMasters[i].objClass == objClass) &&
			(objectMasters[i].objSubClass == subClass) &&
			(objectMasters[i].objSubClassIndex == subClassIndex))
				{
					return i;
				}
	}
}

void shockCommonObject()
{//offset dec 5099
//Read in some common object properties to find some useful info.
char *filePathCO = SHOCK_COMMONOBJ_FILE;
FILE *f;
unsigned char *obj_ark; 
if ((fopen_s(&f,filePathCO, "r") == 0))
	{
		long fileSize = getFileSize(f);
		obj_ark = new unsigned char[fileSize];
		fread(obj_ark, fileSize, 1,f);
		fclose(f);  
		int frameCount=2;	
		int ObjOffset = 5099;	//hope this is right
		int prevClass = objectMasters[0].objClass;
		for (int i = 0; i<475;i++)
			{
			///if (prevClass != objectMasters[i].objClass)
			//{
				//frameCount=0;	//Start a new cycle for each class
				//printf("\n----next class------\n");
			//	}
			prevClass = objectMasters[i].objClass;
			//printf("\n%d:%s\t" ,i ,objectMasters[i].desc);
			//printf("\tRender:%d", getValAtAddress(obj_ark,ObjOffset+i*27+0x7,8));
			//
			//printf("\tmodel:%d", getValAtAddress(obj_ark,ObjOffset+i*27+0x16,16));
			//
			objectMasters[i].frame1 = frameCount;	
			frameCount+=(3+((getValAtAddress(obj_ark,ObjOffset+i*27+0x19,8) >>4) & 0x0F));
			//printf("\tframe:1350_%04d.bmp" ,objectMasters[i].frame1);
			//printf("Mass %d\t",getValAtAddress(obj_ark,ObjOffset+i*27+0x0,32));
			//printf("hp  %d\t",getValAtAddress(obj_ark,ObjOffset+i*27+0x04,16));
			//printf("armour  %d\t",getValAtAddress(obj_ark,ObjOffset+i*27+0x06,8));
			//printf("Render  %d\t",getValAtAddress(obj_ark,ObjOffset+i*27+0x07,8));
			//printf("Vulner  %d\t",getValAtAddress(obj_ark,ObjOffset+i*27+0x0e,8));
			//printf("spevul  %d\t",getValAtAddress(obj_ark,ObjOffset+i*27+0x0f,8));
			//printf("defence  %d\t",getValAtAddress(obj_ark,ObjOffset+i*27+0x12,8));
			//printf("flags  %d\t",getValAtAddress(obj_ark,ObjOffset+i*27+0x14,16));
			//printf("3d mod  %d\t",getValAtAddress(obj_ark,ObjOffset+i*27+0x16,16));
			//printf("frames  %d\t",getValAtAddress(obj_ark,ObjOffset+i*27+0x18,8));
			//printf("framesbits %d \t",getValAtAddress(obj_ark,ObjOffset+i*27+0x18,8)>>4);
			//printf("framesbits19 %d \t",getValAtAddress(obj_ark,ObjOffset+i*27+0x19,8)>>4);

			prevClass = objectMasters[i].objClass;
			
			}
	}

}
	
void setElevatorProperties(tile LevelInfo[64][64],unsigned char *sub_ark,int add_ptr, ObjectItem objList[1600], int objIndex,short PrintDebug)
{

		//000C	int16	Tile x coord of platform
		//0010	int16	Tile y coord of platform
		//0014	int16	Target floor height
		//0016	int16	Target ceiling height
		//0018	int16	Speed
		
	objList[objIndex].shockProperties[TRIG_PROPERTY_TARGET_X] = getValAtAddress(sub_ark,add_ptr+0x0C,16);
	objList[objIndex].shockProperties[TRIG_PROPERTY_TARGET_Y] = getValAtAddress(sub_ark,add_ptr+0x10,16);
	objList[objIndex].shockProperties[TRIG_PROPERTY_FLOOR] = getValAtAddress(sub_ark,add_ptr+0x14,16);	//5
	objList[objIndex].shockProperties[TRIG_PROPERTY_CEILING] = getValAtAddress(sub_ark,add_ptr+0x16,16);	//6
	objList[objIndex].shockProperties[TRIG_PROPERTY_SPEED] = getValAtAddress(sub_ark,add_ptr+0x18,16);
	//LevelInfo[objList[objIndex].shockProperties[TRIG_PROPERTY_TARGET_X]][objList[objIndex].shockProperties[TRIG_PROPERTY_TARGET_Y]].hasElevator =1;
	
	short ceilingFlag = (objList[objIndex].shockProperties[TRIG_PROPERTY_CEILING]<=SHOCK_CEILING_HEIGHT);
	short floorFlag = (objList[objIndex].shockProperties[TRIG_PROPERTY_FLOOR] <= SHOCK_CEILING_HEIGHT);
	short elevatorFlag = (ceilingFlag << 1) | (floorFlag);
	
	LevelInfo[objList[objIndex].shockProperties[TRIG_PROPERTY_TARGET_X]][objList[objIndex].shockProperties[TRIG_PROPERTY_TARGET_Y]].hasElevator = elevatorFlag;


		if (PrintDebug==1)
			{
			printf("\tACTION_MOVING_PLATFORM action for %s\n", UniqueObjectName(objList[objIndex]));
			printf("\t\tTileX of Platform:%d\n",objList[objIndex].shockProperties[TRIG_PROPERTY_TARGET_X]);
			printf("\t\tTileY of Platform:%d\n",objList[objIndex].shockProperties[TRIG_PROPERTY_TARGET_Y]);
			printf("\t\tTarget floor height:%d\n",objList[objIndex].shockProperties[TRIG_PROPERTY_FLOOR]);
			printf("\t\tTarget ceiling height:%d\n",objList[objIndex].shockProperties[TRIG_PROPERTY_CEILING]);
			printf("\t\tSpeed:%d\n",objList[objIndex].shockProperties[TRIG_PROPERTY_SPEED]);
			printf("\t\tMy elevator flag=%d\n",elevatorFlag);
			DebugPrintTriggerVals(sub_ark, add_ptr, 28);
/*			printf("\t\tOther values 1:%d\n",getValAtAddress(sub_ark,add_ptr+12,16));
			printf("\t\tOther values 2:%d\n",getValAtAddress(sub_ark,add_ptr+14,16));
			printf("\t\tOther values 3:%d\n",getValAtAddress(sub_ark,add_ptr+16,16));
			printf("\t\tOther values 4:%d\n",getValAtAddress(sub_ark,add_ptr+18,16));
			printf("\t\tOther values 5:%d\n",getValAtAddress(sub_ark,add_ptr+20,16));
			printf("\t\tOther values 6:%d\n",getValAtAddress(sub_ark,add_ptr+22,16));		
			printf("\t\tOther values 7:%d\n",getValAtAddress(sub_ark,add_ptr+24,16));		
			printf("\t\tOther values 8:%d\n",getValAtAddress(sub_ark,add_ptr+26,16));	*/		
		}	

}


void DebugPrintTriggerVals(unsigned char *sub_ark, int add_ptr,int length)
{
	for (int i = 12; i <= length-2; i = i + 2)
	{
		printf("\n\t\tOther values %i:%d (%d,%d)",i, 
			getValAtAddress(sub_ark, add_ptr + i, 16),
			getValAtAddress(sub_ark, add_ptr + i, 8),
			getValAtAddress(sub_ark, add_ptr + i+1, 8)
			);
	}
	//printf("\t\tOther values 1:%d\n", getValAtAddress(sub_ark, add_ptr + 12, 16));
	//printf("\t\tOther values 2:%d\n", getValAtAddress(sub_ark, add_ptr + 14, 16));
	//printf("\t\tOther values 3:%d\n", getValAtAddress(sub_ark, add_ptr + 16, 16));
	//printf("\t\tOther values 4:%d\n", getValAtAddress(sub_ark, add_ptr + 18, 16));
	//printf("\t\tOther values 5:%d\n", getValAtAddress(sub_ark, add_ptr + 20, 16));
	//printf("\t\tOther values 6:%d\n", getValAtAddress(sub_ark, add_ptr + 22, 16));
	//printf("\t\tOther values 7:%d\n", getValAtAddress(sub_ark, add_ptr + 24, 16));
	//printf("\t\tOther values 8:%d\n", getValAtAddress(sub_ark, add_ptr + 26, 16));
}

void AddEmails(int game, tile LevelInfo[64][64], ObjectItem objList[1600])
{//Generates hidden email objects for when triggers have a send email action
	for (int i = 0; i < 1600; i++)
	{
		if (objList[i].InUseFlag == 1)
		{
			if (isTriggerSHOCK(objList[i]))
			{
				if (objList[i].TriggerAction == ACTION_EMAIL)
				{
					float x; float y; float z;
					CalcObjectXYZ(game, &x, &y, &z, LevelInfo, &objList[i], 0, objList[i].tileX, objList[i].tileY);
					RenderEntityBOOK(game, x, y, z, 1, objList[i], objList, LevelInfo);
				}
			}
		}
	}
}

void SetDeathWatch(ObjectItem objList[1600])
{
	for (int i = 0; i < 1600; i++)
	{
		if ((objList[i].ObjectClass == 12) && (objList[i].ObjectSubClass == 0) && (objList[i].ObjectSubClassIndex == 4))
		{//Is a death watch trigger
			if (objList[i].conditions[3]==0)	//If 0 for a class. 1 for a specific object?
			{
				//Find all objects which have the object class being watched for.
				int targetClass = objList[i].conditions[2];
				int targetSubClass = objList[i].conditions[1];
				int targetSubClassIndex = objList[i].conditions[0];
				int k=getShockObjectIndex(targetClass, targetSubClass, targetSubClassIndex);
				if ((k >= 0) && (k <= 475))
					{
					objectMasters[k].DeathWatch++;	//Death watch is per class.
					for (int j = 0; j < 1600; j++)
						{
						if ((objList[j].ObjectClass == targetClass)
							&& (objList[j].ObjectSubClass == targetSubClass)
							&& (objList[j].ObjectSubClassIndex == targetSubClassIndex))
							{
							objList[j].DeathWatched = 1;
							}
						}
					}


				//objList[i].DeathWatched++;	//acts as a counter for the no of objects watched for.
				//objList[j].DeathWatched = 1;	//acts as a flag for the object being watched.
				//break;
			}
		}
	}
}
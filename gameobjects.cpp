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
void RenderPatch(int game, float x, float y, float z,long PatchIndex, ObjectItem objList[1600] );
void RenderEntityModel (int game, float x, float y, float z, ObjectItem &currobj, ObjectItem objList[1600], tile LevelInfo[64][64]);
void RenderEntityNPC (int game, float x, float y, float z, ObjectItem &currobj, ObjectItem objList[1600], tile LevelInfo[64][64]);
void RenderEntityDoor (int game, float x, float y, float z, ObjectItem &currobj, ObjectItem objList[1600], tile LevelInfo[64][64]);
void RenderEntityKey (int game, float x, float y, float z, ObjectItem &currobj, ObjectItem objList[1600], tile LevelInfo[64][64]) ;
void RenderEntityContainer (int game, float x, float y, float z, ObjectItem &currobj, ObjectItem objList[1600], tile LevelInfo[64][64]);
void RenderEntityButton (int game, float x, float y, float z, ObjectItem &currobj, ObjectItem objList[1600], tile LevelInfo[64][64]);
void RenderEntityA_DOOR_TRAP (int game, float x, float y, float z, ObjectItem &currobj, ObjectItem objList[1600], tile LevelInfo[64][64]);
void RenderEntityA_DO_TRAP (int game, float x, float y, float z, ObjectItem &currobj, ObjectItem objList[1600], tile LevelInfo[64][64]);
void RenderEntityA_CHANGE_TERRAIN_TRAP (int game, float x, float y, float z, ObjectItem &currobj, ObjectItem objList[1600], tile LevelInfo[64][64]);
void RenderEntityTMAP (int game, float x, float y, float z, ObjectItem &currobj, ObjectItem objList[1600], tile LevelInfo[64][64]);
void RenderEntityBOOK (int game, float x, float y, float z, ObjectItem &currobj, ObjectItem objList[1600], tile LevelInfo[64][64]);
void RenderEntitySIGN (int game, float x, float y, float z, ObjectItem &currobj, ObjectItem objList[1600], tile LevelInfo[64][64]);
void RenderEntityA_TELEPORT_TRAP (int game, float x, float y, float z, ObjectItem &currobj, ObjectItem objList[1600], tile LevelInfo[64][64]);
void RenderEntityA_MOVE_TRIGGER (int game, float x, float y, float z, ObjectItem &currobj, ObjectItem objList[1600], tile LevelInfo[64][64]);
void RenderEntityNULL_TRIGGER (int game, float x, float y, float z, ObjectItem &currobj, ObjectItem objList[1600], tile LevelInfo[64][64]);
void CalcObjectXYZ(int game, float *offX,  float *offY, float *offZ, tile LevelInfo[64][64], ObjectItem objList[1600], long nextObj,int x,int y);
int lookUpSubClass(unsigned char *archive_ark, int BlockNo, int ClassType ,int index, int RecordSize, xrefTable *xRef, ObjectItem objList[1600], int currObj);
void getShockTriggerAction(tile LevelInfo[64][64],unsigned char *sub_ark,int add_ptr, xrefTable *xRef, ObjectItem objList[1600], int objIndex);
int LookupxRefTable(xrefTable *xref,int x, int y, int MasterIndex, int tableSize);
void replaceLink(xrefTable *xref, int tableSize, int indexToFind, int linkToReplace);
void replaceMapLink(tile levelInfo[64][64], xrefTable *xref, int tableSize, int indexToFind, int linkToReplace);
void getShockButtons(unsigned char *sub_ark,int add_ptr, ObjectItem objList[1600], int objIndex);
void shockCommonObject();

extern long SHOCK_CEILING_HEIGHT;

int keycount[256];	//For tracking key usage
//int levelNo;

void RenderEntity(int game, float x, float y, float z, ObjectItem &currobj, ObjectItem objList[1600], tile LevelInfo[64][64])
{
//Picks what type of object to generate.
//long patchX;long patchY;long patchZ;
//int patchOffsetX;int patchOffsetY;


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
				RenderEntityBOOK(game,x,y,z,currobj,objList,LevelInfo);
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
			case NULL_TRIGGER:
				RenderEntityNULL_TRIGGER(game,x,y,z,currobj,objList,LevelInfo);	
				break;	
			default:
				{//just the basic name. with no properties.
				printf("\n// entity %d\n{\n",EntityCount);
				printf("\"classname\" \"%s\"\n", objectMasters[currobj.item_id].path);
				printf("\"name\" \"%s_%04d\"\n",objectMasters[currobj.item_id].desc,EntityCount);	
				//position
				printf("\"origin\" \"%f %f %f\"\n",x,y,z);	
				EntityRotation(currobj.heading);
				AttachToJoint(currobj);		//for npc items
				printf("}");
				EntityCount++;		
				break;
				}
			}
		}
	}		
}


void AttachToJoint(ObjectItem &currobj)
	{//TODO: fix me up.
	if (currobj.joint !=0 )
		{
		printf("\"bind\" \"NPC_%03d_%03d\"\n",currobj.objectOwnerName,currobj.objectOwnerEntity);
		printf("\"bindToJoint\" \"spine\"\n");
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
	printf("\n// entity %d\n{\n",EntityCount);
	printf("\"classname\" \"atdm:target_callscriptfunction\"\n");
	printf("\"name\" \"runscript_%s\"\n", UniqueObjectName(currobj));	
	printf("\"origin\" \"%f %f %f\"\n",x,y,z);	
	printf("\"call\" \"start_%s\"\n", UniqueObjectName(currobj));
	printf("}\n");
	EntityCount++;
}

void RenderEntityModel (int game, float x, float y, float z, ObjectItem &currobj, ObjectItem objList[1600], tile LevelInfo[64][64])
{//A model with no properties.

//Params 
//item_id
//tileX
//tileY
//Index

		printf("\n// entity %d\n{\n",EntityCount);
		printf("\"classname\" \"func_static\"\n");
		//print position+name
		printf("\"name\" \"%s\"\n", UniqueObjectName(currobj));
		printf("\"origin\" \"%f %f %f\"\n",x,y,z);	
		EntityRotation(currobj.heading);
		AttachToJoint(currobj);
		if (currobj.link!=0)
			{
			printf("\"frobable\" \"%d\"\n",1);	
			printf("\"frob_action_script\" \"start_%s\"\n", UniqueObjectName(currobj));	
			}
		printf("\n\"model\" \"%s\"\n}\n",objectMasters[currobj.item_id].path);
		EntityCount++;
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
	printf("\n// entity %d\n{\n",EntityCount);
	printf("\"classname\" \"%s\"\n", objectMasters[currobj.item_id].path);
	printf("\"name\" \"%s\"\n", UniqueObjectName(currobj));
	switch (currobj.npc_attitude)
		{	
		case 0:	//hostile
			{
			printf("\"team\" \"5\"\n");	//Criminals team
			break;
			}
		default:
			{
			printf("\"team\" \"5\"\n");	//Beggars team
			break;
			}
		}					
	
	//position
	printf("\"origin\" \"%f %f %f\"\n",x,y,z);	
	EntityRotation(currobj.heading);
	printf("}");
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
	{zpos = LevelInfo[currobj.tileX][currobj.tileY].floorHeight * BrushSizeZ;}
	//for a door I need to point it's used_by property at the key object's name. This is accessed through a lock object
	printf("\n// entity %d\n{\n",EntityCount);
	printf("\"classname\" \"%s\"\n", objectMasters[currobj.item_id].path);

	printf("\"name\" \"%s_%03d_%03d\"\n",objectMasters[currobj.item_id].desc,currobj.tileX,currobj.tileY);
	if (currobj.link !=0)	//door has a lock. bit 0-6 of the lock objects link is the keyid for opening it.
		{
		printf("\"locked\" \"%d\"\n",(objList[currobj.link].flags & 0x01));
		//up to 6 keys can be used for a door to allow duplicate keys.
		printf ("\"used_by\" \"a_key_%03d_0\"\n", objList[currobj.link].link & 0x3F);
		printf ("\"used_by1\" \"a_key_%03d_1\"\n", objList[currobj.link].link & 0x3F);
		printf ("\"used_by2\" \"a_key_%03d_2\"\n", objList[currobj.link].link & 0x3F);
		printf ("\"used_by3\" \"a_key_%03d_3\"\n", objList[currobj.link].link & 0x3F);
		printf ("\"used_by4\" \"a_key_%03d_4\"\n", objList[currobj.link].link & 0x3F);
		printf ("\"used_by5\" \"a_key_%03d_5\"\n", objList[currobj.link].link & 0x3F);
		}
	printf("\"rotate\" \"0 90 0\"\n");		
	//position
	
	switch (currobj.heading)
		{//TODO: replace with proper model offset
		case EAST:
			{printf("\"origin\" \"%f %f %f\"\n",x,(tileY)*BrushY + ( (doorWidth+(BrushY-doorWidth)/2 ) ),zpos);	break;}
		case WEST:
			{printf("\"origin\" \"%f %f %f\"\n",x,(tileY)*BrushY + ( (0+(BrushY-doorWidth)/2 ) ),zpos);	break;}
		case NORTH:
			{printf("\"origin\" \"%f %f %f\"\n",(tileX)*BrushX + ( (doorWidth+(BrushX-doorWidth)/2 ) ),y,zpos);	break;}
		case SOUTH:
			{printf("\"origin\" \"%f %f %f\"\n",(tileX)*BrushX + ( (0+(BrushX-doorWidth)/2 ) ),y,zpos);	break;}
		}

	tile t = LevelInfo[currobj.tileX][currobj.tileY];
	EntityRotation(currobj.heading);
	if (objectMasters[currobj.item_id].type == HIDDENDOOR)
		{//For a secret door I need to render a brush to match the wall
		printf("\"model\" \"%s_%03d_%03d\"\n",objectMasters[currobj.item_id].desc,currobj.tileX,currobj.tileY);
	
		switch (currobj.heading)
			{
			case EAST:
				printf("// primitive %d\n",0);
				printf("{\nbrushDef3\n{\n");
				//east face 
				printf ("( 1 0 0 %d )",-(3));
				getWallTextureName(t,fEAST,0);
				//north face 
				printf ("( 0 1 0 %d )",-(0));
				getWallTextureName(t,fNORTH,0);
				//top face
				printf ("( 0 0 1 %d )", -doorHeight );	
				getFloorTextureName(t,fTOP);
				//west face
				printf ("( -1 0 0 %d )", -(3));
				getWallTextureName(t,fWEST,0);
				//south face
				printf ("( 0 -1 0 %d )", -(doorWidth));
				getWallTextureName(t, fSOUTH,0);
				//bottom face
				printf ("( 0 0 -1 %d )", 0);	
				getFloorTextureName(t, fBOTTOM);
				break;
			case WEST:
				printf("// primitive %d\n",0);
				printf("{\nbrushDef3\n{\n");
				//east face 
				printf ("( 1 0 0 %d )",-(3));
				getWallTextureName(t,fEAST,0);
				//north face 
				printf ("( 0 1 0 %d )",-(doorWidth));
				getWallTextureName(t,fNORTH,0);
				//top face
				printf ("( 0 0 1 %d )", -doorHeight );	
				getFloorTextureName(t,fTOP);
				//west face
				printf ("( -1 0 0 %d )", -(3));
				getWallTextureName(t,fWEST,0);
				//south face
				printf ("( 0 -1 0 %d )", -(0));
				getWallTextureName(t, fSOUTH,0);
				//bottom face
				printf ("( 0 0 -1 %d )", 0);	
				getFloorTextureName(t, fBOTTOM);
				break;
			case NORTH:
				printf("// primitive %d\n",0);
				printf("{\nbrushDef3\n{\n");
				//east face 
				printf ("( 1 0 0 %d )",-(0));
				getWallTextureName(t,fEAST,0);
				//north face 
				printf ("( 0 1 0 %d )",-(3));
				getWallTextureName(t,fNORTH,0);
				//top face
				printf ("( 0 0 1 %d )", -doorHeight );	
				getFloorTextureName(t,fTOP);
				//west face
				printf ("( -1 0 0 %d )", -(doorWidth));
				getWallTextureName(t,fWEST,0);
				//south face
				printf ("( 0 -1 0 %d )", -(3));
				getWallTextureName(t, fSOUTH,0);
				//bottom face
				printf ("( 0 0 -1 %d )", 0);	
				getFloorTextureName(t, fBOTTOM);
				break;
			case SOUTH:
				{
				printf("// primitive %d\n",0);
				printf("{\nbrushDef3\n{\n");
				//east face 
				printf ("( 1 0 0 %d )",-(doorWidth));
				getWallTextureName(t,fEAST,0);
				//north face 
				printf ("( 0 1 0 %d )",-(3));
				getWallTextureName(t,fNORTH,0);
				//top face
				printf ("( 0 0 1 %d )", -doorHeight );	
				getFloorTextureName(t,fTOP);
				//west face
				printf ("( -1 0 0 %d )", +(0));
				getWallTextureName(t,fWEST,0);
				//south face
				printf ("( 0 -1 0 %d )", -(3));
				getWallTextureName(t, fSOUTH,0);
				//bottom face
				printf ("( 0 0 -1 %d )", 0);	
				getFloorTextureName(t, fBOTTOM);
				break;
				}	

			}
			printf ("}\n}\n");
		}
	printf("}");		
	EntityCount++;
	if (currobj.link !=0)
		{	//if it has a lock it needs a lock object for scripting purposes
		printf("\n// entity %d\n{\n",EntityCount);
		printf("\"classname\" \"%s\"\n", objectMasters[objList[currobj.link].item_id].path);
		//A lock trap object for opening doors.
		printf("\"name\" \"a_lock_%03d_%03d\"\n",currobj.tileX, currobj.tileY);
		printf("\"target\" \"%s_%03d_%03d\"\n", objectMasters[currobj.item_id].desc,currobj.tileX  ,currobj.tileY );
		printf("\"toggle\" \"1\"\n");	//todo: other types of behaviour.
		printf("\"origin\" \"%f %f %f\"\n",x,y,z);	
		printf("}");
		EntityCount++;	
		}
		return;
}

void RenderEntityKey (int game, float x, float y, float z, ObjectItem &currobj, ObjectItem objList[1600], tile LevelInfo[64][64])
{
//Params
//Item_id
//Owner

	//A key's owner id matches it's lock link id.
	printf("\n// entity %d\n{\n",EntityCount);
	printf("\"classname\" \"%s\"\n", objectMasters[currobj.item_id].path);
	printf("\"name\" \"%s_%03d_%d\"\n",objectMasters[currobj.item_id].desc,currobj.owner,keycount[currobj.owner]++);
	//they also need the following properties
	printf("\"usable\" \"1\"\n\"frobable\" \"1\"\n\"inv_name\" \"KEY_%03d\"\n\"inv_target\" \"player1\"\n\"inv_stackable\" \"1\"\n\"inv_category\" \"Keys\"\n",currobj.owner);
	//position
	printf("\"origin\" \"%f %f %f\"\n",x,y,z);
	EntityRotation(currobj.heading);	
	AttachToJoint(currobj);		
	printf("}");
	EntityCount++;	
	return;
}

void RenderEntityContainer (int game, float x, float y, float z, ObjectItem &currobj, ObjectItem objList[1600], tile LevelInfo[64][64])
{
//Params.
//Item_id
//link	//To check for a lock and it's list of contents.
	printf("\n// entity %d\n{\n",EntityCount);
	printf("\"classname\" \"%s\"\n", objectMasters[currobj.item_id].path);

	//I need to spawn it's contents at the same location (recursively)
	//render it first.
	//TODO: I also need to fix containers which are not really entities
	printf("\"name\" \"%s_%03d\"\n",objectMasters[currobj.item_id].desc,EntityCount);	
	if (objectMasters[objList[currobj.link].item_id].type == LOCK)	//container has a lock.
		{//bit 1 of the flags is the lock?
		printf("\"locked\" \"%d\"\n",(objList[currobj.link].flags & 0x01));
		printf ("\"used_by\" \"a_key_%03d_0\"\n", objList[currobj.link].link & 0x3F);
		printf ("\"used_by1\" \"a_key_%03d_1\"\n", objList[currobj.link].link & 0x3F);
		printf ("\"used_by2\" \"a_key_%03d_2\"\n", objList[currobj.link].link & 0x3F);
		printf ("\"used_by3\" \"a_key_%03d_3\"\n", objList[currobj.link].link & 0x3F);
		printf ("\"used_by4\" \"a_key_%03d_4\"\n", objList[currobj.link].link & 0x3F);
		printf ("\"used_by5\" \"a_key_%03d_5\"\n", objList[currobj.link].link & 0x3F);		
		}				
	//position
	printf("\"origin\" \"%f %f %f\"\n",x,y,z);
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

void RenderEntityButton (int game, float x, float y, float z, ObjectItem &currobj, ObjectItem objList[1600], tile LevelInfo[64][64])
{
//
//Params
//item_id
//tileX
//tileY
//index
//heading
//Need to pass desc/path for generic handling
	printf("\n// entity %d\n{\n",EntityCount);
	printf("\"classname\" \"%s\"\n", objectMasters[currobj.item_id].path);
	printf("\"name\" \"%s\"\n", UniqueObjectName(currobj));
	printf("\"model\" \"models/darkmod/mechanical/switches/switch_flip.ase\"\n");	//TODO:Need to pass this in from config
	//position
	printf("\"origin\" \"%f %f %f\"\n",x,y,z);	
	printf("\"rotate\" \"0 0 45\"\n");
	printf("\"interruptable\" \"0\"\n");
	EntityRotation(currobj.heading);
	printf("\"target\" \"runscript_%s\"\n", UniqueObjectName(currobj));
	printf("}\n");EntityCount++;
	createScriptCall(currobj,x,y,z);	//To run whatever actions this switch performs.
	return;
}

void RenderEntityA_DOOR_TRAP (int game, float x, float y, float z, ObjectItem &currobj, ObjectItem objList[1600], tile LevelInfo[64][64])
{
//A door trap object for opening doors.
//Params
//objectOwnerName (passed down from a parent object)
//objectOwner
//tileX
//tileY
//Need to add path for generic usage.

		printf("\n// entity %d\n{\n",EntityCount);
		printf("\"classname\" \"%s\"\n", objectMasters[currobj.item_id].path);
		printf("\"name\" \"door_%03d_%03d\"\n",currobj.objectOwner, currobj.objectOwnerName);
		printf("\"target\" \"door_%03d_%03d\"\n", currobj.tileX  ,currobj.tileY );	//Doors are refered to by their tile location.
		printf("\"toggle\" \"1\"\n");	//todo: other types of behaviour.
		printf("\"origin\" \"%f %f %f\"\n",x,y,z);	
		printf("}");
		EntityCount++;	
		return;
}

void RenderEntityA_DO_TRAP (int game, float x, float y, float z, ObjectItem &currobj, ObjectItem objList[1600], tile LevelInfo[64][64])
{
	switch (currobj.quality )
		{
		case 2: //A camera	
			printf("\n// entity %d\n{\n",EntityCount);
			printf("\"classname\" \"func_cameraview\"\n");
			printf("\"name\" \"%s_%03d_%03d\"\n",objectMasters[currobj.item_id].desc ,currobj.tileX,currobj.tileY);
			printf("\"origin\" \"%f %f %f\"\n",x,y,z);	
			printf("\"trigger\" \"1\"\n");
			//Aim the camera.
			EntityRotation(currobj.heading);//TODO:Points in wrong direction
			printf("\n}");
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
	//render func static for the initial tiles.
	PrimitiveCount=0;
	int tileCount =0;
	for (int i=0;i<=currobj.x;i++)
		{
		for(int j=0;j<=currobj.y;j++)
			{

			printf("\n// entity %d\n{\n",EntityCount++);
			printf("\"classname\" \"%s\"\n", objectMasters[currobj.item_id].path);
			//TODO:There is some weirdness when I try and hide water. For now I'll just ignore it.
			//if (LevelInfo[currobj.tileX+i][currobj.tileY+j].isWater == 0)
			//	{
				//printf("\"name\" \"%s_initial_%03d_%03d_%03d_%03d\"\n",objectMasters[currobj.item_id].desc,currobj.tileX,currobj.tileY,currobj.index,tileCount);
			printf("\"name\" \"initial_%s_%03d\"\n", UniqueObjectName(currobj),tileCount);				
			//	}
			//else
			//	{//water
			//	printf("\"name\" \"%s_initial_%03d_%03d_%03d_%03d\"\n",objectMasters[currobj.item_id].desc,currobj.tileX,currobj.tileY,currobj.index,tileCount);
		//		printf("\n\"underwater_gui\" \"guis\underwater\underwater_green_thinmurk.gui\"\n");
	//			}
			printf("\"model\" \"initial_%s_%03d\"\n",UniqueObjectName(currobj),tileCount);
			printf("\"origin\" \"%d %d %d\"\n",(currobj.tileX+i)*BrushSizeX,(currobj.tileY+j)*BrushSizeY,0);														
			RenderDarkModTile(game,0,0,LevelInfo[currobj.tileX+i][currobj.tileY+j],LevelInfo[currobj.tileX+i][currobj.tileY+j].isWater,0,0,0);
			printf("\n}\n");
			tileCount++;
			}
		}
	
	
	//Then render a func static for how it ends up.
	PrimitiveCount=0;
	printf("\n// entity %d\n{\n",EntityCount++);
	printf("\"classname\" \"%s\"\n", objectMasters[currobj.item_id].path);
	printf("\"name\" \"final_%s\"\n",UniqueObjectName(currobj));
	printf("\"model\" \"final_%s\"\n",UniqueObjectName(currobj));
	printf("\"origin\" \"%d %d %d\"\n",currobj.tileX*BrushSizeX,currobj.tileY*BrushSizeY,0);
	
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
	printf("\n}\n");
	return;
}

void RenderEntityTMAP (int game, float x, float y, float z, ObjectItem &currobj, ObjectItem objList[1600], tile LevelInfo[64][64])
{//Flat patch objects used as decals
//params
//link	to see if it can be activated
//tileX
//tileY
//index
	printf("\n// entity %d\n{\n",EntityCount);
	if( isTrigger(objList[currobj.link])==0)
		{
		printf("\"classname\" \"%s\"\n", objectMasters[currobj.item_id].path);
		}
	else
		{
		//object is a trigger
		printf("\"classname\" \"%s\"\n", "atdm:mover_button");	//TODO:Is there something better I can use than this.
		printf("\"target\" \"runscript_%s\"\n",UniqueObjectName(currobj));	
		}
	printf("\"name\" \"%s\"\n",UniqueObjectName(currobj));
	printf("\"model\" \"%s\"\n",UniqueObjectName(currobj));
	printf("\"origin\" \"%f %f %f\"\n",x,y,z);	
	RenderPatch(game,currobj.tileX,currobj.tileY ,currobj.zpos,currobj.index,objList);
	printf("\n}\n");
	EntityCount++;
	if( isTrigger(objList[currobj.link])==1)
		{
		createScriptCall(currobj,x,y,z);
		}
	return;
}

void RenderEntityBOOK (int game, float x, float y, float z, ObjectItem &currobj, ObjectItem objList[1600], tile LevelInfo[64][64])
{
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
	printf("\n// entity %d\n{\n",EntityCount);
	printf("\"classname\" \"%s\"\n", objectMasters[currobj.item_id].path);
	printf("\"name\" \"%s\"\n",UniqueObjectName(currobj));		
	printf("\"inv_name\" \"Readable_%d\"\n", ReadableIndex);
	switch (game)
		{
		case UWDEMO:
		case UW1:
			{printf("\"xdata_contents\" \"readables/uw1/scroll_%03d\"\n", ReadableIndex);break;}
		case UW2:
			{printf("\"xdata_contents\" \"readables/uw2/scroll_%03d\"\n", ReadableIndex);break;}
		case SHOCK:
			{
			printf("\"xdata_contents\" \"readables/shock/log_%03d\"\n",ReadableIndex);
			printf("\"trigger_on_open\" \"runscript_%s\"\n",UniqueObjectName(currobj) );	//plays the audio of this log
			break;
			}
		}	
	printf("\"origin\" \"%f %f %f\"\n",x,y,z);	
	EntityRotation(currobj.heading);
	AttachToJoint(currobj);		//for npc items
	printf("}");
	EntityCount++;
	if (game == SHOCK)
		{
		createScriptCall(currobj,x,y,z);
		}
	return;
}

void RenderEntitySIGN (int game, float x, float y, float z, ObjectItem &currobj, ObjectItem objList[1600], tile LevelInfo[64][64])
{
//Params
//tileX
//tileY
//Index
//currobj.link -200 = pointer to the readable string block in UW
//heading

	printf("\n// entity %d\n{\n",EntityCount);
	printf("\"classname\" \"%s\"\n", objectMasters[currobj.item_id].path);
	printf("\"name\" \"%s\"\n",UniqueObjectName(currobj));		
	printf("\"xdata_contents\" \"readables/uw1/sign_%03d\"\n", currobj.link - 0x200);
	switch (game)
		{
		case UWDEMO:
		case UW1:
			{printf("\"xdata_contents\" \"readables/uw1/sign_%03d\"\n", currobj.link - 0x200);break;}
		case UW2:
			{printf("\"xdata_contents\" \"readables/uw12/sign_%03d\"\n", currobj.link - 0x200);break;}
		case SHOCK:
			{//TODO:Whatever needs to go here.
			//printf("\"xdata_contents\" \"readables/shock/sign_%03d\"\n", currobj.link - 0x200);
			break;}
		}		
	printf("\"origin\" \"%f %f %f\"\n",x,y,z);	
	printf("\"model\" \"models/darkmod/uw1/uw1_sign.ase\"\n");	//TODO:pass model path in.
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
	printf("\n}");
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
		printf("\n// entity %d\n{\n",EntityCount);
		printf("\"classname\" \"%s\"\n", objectMasters[currobj.item_id].path);
		printf("\"name\" \"%s\"\n",UniqueObjectName(currobj));	
		printf("\"origin\" \"%d %d %d\"\n",currobj.quality * BrushSizeX+(BrushSizeX/2),currobj.owner * BrushSizeY+(BrushSizeY/2), LevelInfo[currobj.quality][currobj.owner].floorHeight * BrushSizeZ);	
		printf("\n}");		
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

	printf("\n// entity %d\n{\n",EntityCount);
	printf("\"classname\" \"%s\"\n", objectMasters[currobj.item_id].path);
	printf("\"name\" \"%s\"\n",UniqueObjectName(currobj));	
	printf("\"model\" \"%s\"\n",UniqueObjectName(currobj) );	
	printf("\"target\" \"runscript_%s\"\n",UniqueObjectName(currobj));						
	printf("\"wait\" \"5\"\n");						
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
	RenderGenericTile(currobj.tileX,currobj.tileY,t,CEILING_HEIGHT,0 );
	printf("\n}");
	createScriptCall(currobj,x,y,z);	
}

void RenderEntityNULL_TRIGGER (int game, float x, float y, float z, ObjectItem &currobj, ObjectItem objList[1600], tile LevelInfo[64][64])
{
createScriptCall(currobj,x,y,z);
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
			{printf("\n\"rotation\" \"1 0 0 0 1 0 0 0 1\"\n");break;}
		case 45:
			{printf("\n\"rotation\" \"0.707107 0.707107 0 -0.707107 0.707107 0 0 0 1\"\n");break;}
		case 90:	
			{printf("\n\"rotation\" \"0 1 0 -1 0 0 0 0 1\"\n");break;}
		case 135:
			{printf("\n\"rotation\" \"-0.707107 0.707107 0 -0.707107 -0.707107 0 0 0 1\"\n");break;}
		case 180:	
			{printf("\n\"rotation\" \"-1 0 0 0 -1 0 0 0 1\"\n");break;}					
		case 225:
			{printf("\n\"rotation\" \"-0.707107 -0.707107 0 0.707107 -0.707107 0 0 0 1\"\n");break;}
		case 270:	
			{printf("\n\"rotation\" \"0 -1 0 1 0 0 0 0 1\"\n");break;}																		
		case 315:
			{printf("\n\"rotation\" \"0.707107 -0.707107 0 0.707107 0.707107 0 0 0 1\"\n");break;}			
		default:
			{printf("\n\"rotation\" \"1 0 0 0 1 0 0 0 1\"\n");break;}						
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
				objList[MasterIndex].item_id =LookupIndex;

				objList[MasterIndex].x =getValAtAddress(mst_ark,mstaddress_pointer+11,8);
				objList[MasterIndex].y = getValAtAddress(mst_ark,mstaddress_pointer+13,8);
				objList[MasterIndex].zpos =getValAtAddress(mst_ark,mstaddress_pointer+15,8);
				
				objList[MasterIndex].Angle1 = getValAtAddress(mst_ark,mstaddress_pointer+16,8);
				objList[MasterIndex].Angle2 = getValAtAddress(mst_ark,mstaddress_pointer+17,8);
				objList[MasterIndex].Angle3 = getValAtAddress(mst_ark,mstaddress_pointer+18,8);
			//	printf("\tIt is a %s", objectMasters[objList[MasterIndex].item_id].desc );
				objList[MasterIndex].sprite = getValAtAddress(mst_ark,mstaddress_pointer+23,8);
			//	printf("\tSprite : %d\n", objList[MasterIndex].sprite  );
			//			printf("\n\t\tunk1 = %d\n",getValAtAddress(mst_ark,mstaddress_pointer+24,8));
			//			printf("\tunk2 = %d\n",getValAtAddress(mst_ark,mstaddress_pointer+25,8));
			//			printf("\tunk3 = %d\n",getValAtAddress(mst_ark,mstaddress_pointer+26,8));				
			//			printf("AIIndex = %d\n",getValAtAddress(mst_ark,mstaddress_pointer+19,8));
			//			printf("HitPoints = %d\n",getValAtAddress(mst_ark,mstaddress_pointer+21,16));
			//			printf("IndexIntoCrossRef = %d\n",getValAtAddress(mst_ark,mstaddress_pointer+5,16));
			//			printf("PrevLink = %d\n",getValAtAddress(mst_ark,mstaddress_pointer+7,16));
			//			printf("NextLink = %d\n",getValAtAddress(mst_ark,mstaddress_pointer+9,16));
			//			printf("XCoord low= %d\n",getValAtAddress(mst_ark,mstaddress_pointer+11,8));
			//			printf("XCoord high= %d\n",getValAtAddress(mst_ark,mstaddress_pointer+12,8));
			//			printf("YCoord low= %d\n",getValAtAddress(mst_ark,mstaddress_pointer+13,8));
			//			printf("YCoord high= %d\n",getValAtAddress(mst_ark,mstaddress_pointer+14,8));
			//			printf("ZCoord = %d\n",getValAtAddress(mst_ark,mstaddress_pointer+15,8));
			//			printf("Angle1 = %d\n",getValAtAddress(mst_ark,mstaddress_pointer+16,8));
			//			printf("Angle2 = %d\n",getValAtAddress(mst_ark,mstaddress_pointer+17,8));
			//			printf("Angle3 = %d\n",getValAtAddress(mst_ark,mstaddress_pointer+18,8));
			//			printf("AIIndex = %d\n",getValAtAddress(mst_ark,mstaddress_pointer+19,8));
			//			printf("ObjectType = %d\n",getValAtAddress(mst_ark,mstaddress_pointer+20,8));
			//			printf("HitPoints = %d\n",getValAtAddress(mst_ark,mstaddress_pointer+21,16));
			//			printf("State = %d\n",getValAtAddress(mst_ark,mstaddress_pointer+23,8));
			//			printf("unk1 = %d\n",getValAtAddress(mst_ark,mstaddress_pointer+24,8));
			//			printf("unk2 = %d\n",getValAtAddress(mst_ark,mstaddress_pointer+25,8));
			//			printf("unk3 = %d\n",getValAtAddress(mst_ark,mstaddress_pointer+26,8));

			//Debug obj


			//if ((MasterIndex == 250) ||(MasterIndex == 502) || (MasterIndex == 713))
			//	{
			//	
			//
			//			printf("\nIndex = %d \n",objList[MasterIndex].index);
			//			printf("xref = %d\n",xref_ptr);			
			//			//printf("master i = %d\n",objList[MasterIndex].mstrIndex);	
			//			printf("TileX = %d\n",objList[MasterIndex].tileX );
			//			printf("TileY = %d\n",objList[MasterIndex].tileY);
			//			printf("It is a %s\n", objectMasters[objList[MasterIndex].item_id].desc );
			//			printf("InUse = %d\n",objList[MasterIndex].InUseFlag);
			//			printf("xrefnext = %d (%d)\n", xref[xref_ptr].next,xref[xref[xref_ptr].next].MstIndex ) ;
			//			printf("xrefnexttile = %d (%d)\n", xref[xref_ptr].nextTile,xref[xref[xref_ptr].nextTile].MstIndex ) ;
			//			printf("Masterlist next = %d\n", objList[MasterIndex].next);
			//			printf("Index into tile :%d\n",LevelInfo[objList[MasterIndex].tileX][objList[MasterIndex].tileY].indexObjectList);
			//		}

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
					if (lookUpSubClass(archive_ark,LevelNo*100+SOFTWARE_LOGS_OFFSET, SOFTWARE_LOGS, SubClassLink, 9, xref, objList,MasterIndex) == -1) {printf("\nNo properties found!\n");}
					break;
					}
				case FIXTURES:break;
				case GETTABLES_OTHER:
					break;
				case SWITCHES_PANELS:
					{
				
					//printf("\n\nIndex = %d \n",objList[MasterIndex].index);
					//printf("\tIt is a %s\n", objectMasters[objList[MasterIndex].item_id].desc );
					//printf("\txref = %d\n",xref_ptr);			
					//printf("\tTileX = %d",objList[MasterIndex].tileX );
					//printf("\tTileY = %d\n",objList[MasterIndex].tileY);
					//printf("\tInUse = %d\n",objList[MasterIndex].InUseFlag);
					//printf("\tClass:%d-%d-%d\n",objList[MasterIndex].ObjectClass,objList[MasterIndex].ObjectSubClass,objList[MasterIndex].ObjectSubClassIndex);
					if (lookUpSubClass(archive_ark,LevelNo*100+SWITCHES_PANELS_OFFSET, SWITCHES_PANELS, SubClassLink, 30 ,xref, objList,MasterIndex) == -1) {printf("\nNo properties found!\n");}
					break;
					}
				case DOORS_GRATINGS:break;
				case ANIMATED:break;
				case TRAPS_MARKERS:
						{
						if (lookUpSubClass(archive_ark,LevelNo*100+TRAPS_MARKERS_OFFSET, TRAPS_MARKERS, SubClassLink, 28,xref, objList,MasterIndex) == -1)  {printf("no properties found!");}
						}
					break;
				case CONTAINERS_CORPSES:break;
				case CRITTERS:break;
				}	
				UniqueObjectName(objList[MasterIndex]);					
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
/////*		printf("Subclass Link=%d\n",k);
////		printf("Index back=%d\n",getValAtAddress(tmp_ark,AddressOfBlockStart+add_ptr+0,16));
////		printf("prev=%d\n",getValAtAddress(tmp_ark,AddressOfBlockStart+add_ptr+2,16));
////		printf("next=%d\n",getValAtAddress(tmp_ark,AddressOfBlockStart+add_ptr+4,16));
////		
////		printf("prev(8)=%d\n",getValAtAddress(tmp_ark,AddressOfBlockStart+add_ptr+2,8));
////		printf("next(8)=%d\n",getValAtAddress(tmp_ark,AddressOfBlockStart+add_ptr+3,8));
////		printf("prev(8)=%d\n",getValAtAddress(tmp_ark,AddressOfBlockStart+add_ptr+4,8));
////		printf("next(8)=%d\n",getValAtAddress(tmp_ark,AddressOfBlockStart+add_ptr+5,8));
////		
////		printf("val1(16)=%d\n",getValAtAddress(tmp_ark,AddressOfBlockStart+add_ptr+6,16));
////		printf("val2(16)=%d\n",getValAtAddress(tmp_ark,AddressOfBlockStart+add_ptr+8,16));
////		printf("val3(16)=%d\n",getValAtAddress(tmp_ark,AddressOfBlockStart+add_ptr+10,16));
////		
////		printf("val1(8)=%d\n",getValAtAddress(tmp_ark,AddressOfBlockStart+add_ptr+6,16));
////		printf("val2(8)=%d\n",getValAtAddress(tmp_ark,AddressOfBlockStart+add_ptr+7,16));
////		printf("val3(8)=%d\n",getValAtAddress(tmp_ark,AddressOfBlockStart+add_ptr+8,16));		
////		printf("val4(9)=%d\n",getValAtAddress(tmp_ark,AddressOfBlockStart+add_ptr+9,16));
////		printf("val5(8)=%d\n",getValAtAddress(tmp_ark,AddressOfBlockStart+add_ptr+10,16));
////		printf("val6(8)=%d\n",getValAtAddress(tmp_ark,AddressOfBlockStart+add_ptr+11,16));	*/	
		
		switch(ClassType)
			{
			case SOFTWARE_LOGS:
				{
				objList[objIndex].shockProperties[SOFT_PROPERTY_VERSION]=getValAtAddress(sub_ark,add_ptr+6,8);	//Software version
				objList[objIndex].shockProperties[SOFT_PROPERTY_LOG]=getValAtAddress(sub_ark,add_ptr+7,8) + 2488;	//Chunk containing log
				objList[objIndex].shockProperties[SOFT_PROPERTY_LEVEL]=getValAtAddress(sub_ark,add_ptr+8,8);	//Level No of Chunk
				return 1;
				break;
				}
			case SWITCHES_PANELS:
				{
				//printf("\tSwitch Index:%d\n",getValAtAddress(sub_ark,add_ptr+0,16));
				////printf("Prev:%d\n",getValAtAddress(sub_ark,add_ptr+2,16));
				////printf("Next:%d\n",getValAtAddress(sub_ark,add_ptr+4,16));
				//printf("\tUnknown:%d",getValAtAddress(sub_ark,add_ptr+6,16));
				//printf("\tVariable:%d",getValAtAddress(sub_ark,add_ptr+8,16));
				//printf("\tFail Message:%d",getValAtAddress(sub_ark,add_ptr+10,16));
				getShockButtons(sub_ark,add_ptr,objList,objIndex);
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
				
				getShockTriggerAction(LevelInfo,sub_ark,add_ptr,xRef,objList,objIndex);
				printf("\tCondition 0: %d\n",objList[objIndex].conditions[0]);
				printf("\tCondition 1: %d\n",objList[objIndex].conditions[1]);
				printf("\tCondition 2: %d\n",objList[objIndex].conditions[2]);
				printf("\tCondition 3: %d\n",objList[objIndex].conditions[3]);
				printf("\tTrigger once: %d\n",objList[objIndex].TriggerOnce);
				
				printf("\n=======\n");			
				return 1;
				break;
				}
			}
		break;
		}
	add_ptr+=RecordSize;
	k++;
	}
return -1;
}

void CalcObjectXYZ(int game, float *offX,  float *offY, float *offZ, tile LevelInfo[64][64], ObjectItem objList[1600], long nextObj, int x,int y)
{
int ResolutionXY=7;
int ResolutionZ=127;
if (game ==SHOCK){ResolutionXY =255;ResolutionZ=255;}


		*offX=0;  *offY=0; *offZ=0;


		float BrushX=BrushSizeX;
		float BrushY=BrushSizeY;
		float BrushZ=BrushSizeZ;
		
		*offX= (x*BrushX) + ((objList[nextObj].x) * (BrushX/ResolutionXY));
		*offY= (y*BrushY) + ((objList[nextObj].y) * (BrushY/ResolutionXY));
		//offZ = objList[nextObj].zpos ; //TODO:Adjust this.
		int floorHeight = LevelInfo[x][y].floorHeight <<3 ;
		int nextFloorHeight =(LevelInfo[x][y].floorHeight+1) <<3 ;
		float relativeZpos = (float)(objList[nextObj].zpos - floorHeight);
		float zposRatio = (float)(relativeZpos/(nextFloorHeight-floorHeight));	//relative adjustment
		//float zposRatio = (float)(relativeZpos/(12*BrushSizeZ));	//relative adjustment
		*offZ = LevelInfo[x][y].floorHeight * BrushZ + (zposRatio*BrushZ*1);
		
		if ((zposRatio !=0) && (objectMasters[objList[nextObj].item_id].type != BRIDGE))
			{
			float zpos= objList[nextObj].zpos;
			float brushZ = BrushSizeZ;
			float ceiling = CEILING_HEIGHT;
			*offZ = (zpos/ResolutionZ) * (brushZ*ceiling);
			}
		//TODO:This may mess with stuff on walls. It's here to prevent models cliping through sloped floors
		if ((LevelInfo[x][y].tileType >= 6) && (LevelInfo[x][y].tileType <= 9) && (LevelInfo[x][y].isWater == 0) && (LevelInfo[x][y].shockSlopeFlag !=SLOPE_CEILING_ONLY))
			{
			*offZ = *offZ + (LevelInfo[x][y].shockSteep * (BrushSizeZ /2));
			}

}

void getShockTriggerAction(tile LevelInfo[64][64],unsigned char *sub_ark,int add_ptr, xrefTable *xRef, ObjectItem objList[1600], int objIndex)
{
printf("",UniqueObjectName(objList[objIndex]));
int TriggerType =getValAtAddress(sub_ark,add_ptr+6,8);
objList[objIndex].TriggerAction = TriggerType;
switch (TriggerType)
	{ 
	case ACTION_DO_NOTHING :
		{
		printf("\tACTION_DO_NOTHING for %s\n",UniqueObjectName(objList[objIndex]));
		printf("\t\tOther values 1:%d\n",getValAtAddress(sub_ark,add_ptr+12,16));
		printf("\t\tOther values 2:%d\n",getValAtAddress(sub_ark,add_ptr+14,16));
		printf("\t\tOther values 3:%d\n",getValAtAddress(sub_ark,add_ptr+16,16));
		printf("\t\tOther values 4:%d\n",getValAtAddress(sub_ark,add_ptr+18,16));
		printf("\t\tOther values 5:%d\n",getValAtAddress(sub_ark,add_ptr+20,16));
		printf("\t\tOther values 6:%d\n",getValAtAddress(sub_ark,add_ptr+22,16));		
		printf("\t\tOther values 7:%d\n",getValAtAddress(sub_ark,add_ptr+24,16));		
		printf("\t\tOther values 8:%d\n",getValAtAddress(sub_ark,add_ptr+26,16));			
		break;	
		}
	case ACTION_TRANSPORT_LEVEL:
		{
		printf("\tACTION_TRANSPORT_LEVEL for %s\n",UniqueObjectName(objList[objIndex]));
		printf("\t\tOther values 1:%d\n",getValAtAddress(sub_ark,add_ptr+12,16));
		printf("\t\tOther values 2:%d\n",getValAtAddress(sub_ark,add_ptr+14,16));
		printf("\t\tOther values 3:%d\n",getValAtAddress(sub_ark,add_ptr+16,16));
		printf("\t\tOther values 4:%d\n",getValAtAddress(sub_ark,add_ptr+18,16));
		printf("\t\tOther values 5:%d\n",getValAtAddress(sub_ark,add_ptr+20,16));
		printf("\t\tOther values 6:%d\n",getValAtAddress(sub_ark,add_ptr+22,16));		
		printf("\t\tOther values 7:%d\n",getValAtAddress(sub_ark,add_ptr+24,16));		
		printf("\t\tOther values 8:%d\n",getValAtAddress(sub_ark,add_ptr+26,16));
		objList[objIndex].shockProperties[TRIG_PROPERTY_TARGET_X] = getValAtAddress(sub_ark,add_ptr+12,16);	//Target X of teleport
		objList[objIndex].shockProperties[TRIG_PROPERTY_TARGET_Y] = getValAtAddress(sub_ark,add_ptr+16,16); //Target Y of teleport
		objList[objIndex].shockProperties[TRIG_PROPERTY_TARGET_Z]= getValAtAddress(sub_ark,add_ptr+20,16);	//Target Z of teleport
		printf("\n=======\n");	
		break;
		}
	case ACTION_RESURRECTION:
		{
		printf("\tACTION_RESURRECTION for %s\n",UniqueObjectName(objList[objIndex]));
		printf("\t\tOther values 1:%d\n",getValAtAddress(sub_ark,add_ptr+12,16));
		printf("\t\tOther values 2:%d\n",getValAtAddress(sub_ark,add_ptr+14,16));
		printf("\t\tOther values 3:%d\n",getValAtAddress(sub_ark,add_ptr+16,16));
		printf("\t\tOther values 4:%d\n",getValAtAddress(sub_ark,add_ptr+18,16));
		printf("\t\tOther values 5:%d\n",getValAtAddress(sub_ark,add_ptr+20,16));
		printf("\t\tOther values 6:%d\n",getValAtAddress(sub_ark,add_ptr+22,16));		
		printf("\t\tOther values 7:%d\n",getValAtAddress(sub_ark,add_ptr+24,16));		
		printf("\t\tOther values 8:%d\n",getValAtAddress(sub_ark,add_ptr+26,16));	
		
		objList[objIndex].shockProperties[TRIG_PROPERTY_VALUE] =	getValAtAddress(sub_ark,add_ptr+16,16);	//Target Health
		break;
		}
	case ACTION_CLONE:
		{
		//	000C	int16	Object to transport.
		//	000E	int16	Delete flag?
		//	0010	int16	Tile destination X
		//	0014	int16	Tile destination Y
		//	0018	int16	Destination height?		
		printf("\tACTION_CLONE for %s\n",UniqueObjectName(objList[objIndex]));
		printf("\t\tObject to transport:%d\n",getValAtAddress(sub_ark,add_ptr+0xC,16));
		printf("\t\tDeleteFlag?:%d\n",getValAtAddress(sub_ark,add_ptr+0xE,16));
		printf("\t\tDestination tileX:%d\n",getValAtAddress(sub_ark,add_ptr+0x10,16));
		printf("\t\tDestination tileY:%d\n",getValAtAddress(sub_ark,add_ptr+0x14,16));
		printf("\t\tDestination height:%d\n",getValAtAddress(sub_ark,add_ptr+0x18,16));
		objList[objIndex].shockProperties[TRIG_PROPERTY_OBJECT] =	getValAtAddress(sub_ark,add_ptr+0xC,16);	//obj to transport
		objList[objIndex].shockProperties[TRIG_PROPERTY_FLAG] = getValAtAddress(sub_ark,add_ptr+0x0E,16);		//Delete flag
		objList[objIndex].shockProperties[TRIG_PROPERTY_TARGET_X] = getValAtAddress(sub_ark,add_ptr+0x10,16);	//Target X
		objList[objIndex].shockProperties[TRIG_PROPERTY_TARGET_Y] = getValAtAddress(sub_ark,add_ptr+0x14,16);	//Target Y
		objList[objIndex].shockProperties[TRIG_PROPERTY_TARGET_Z] = getValAtAddress(sub_ark,add_ptr+0x18,16);	//Target z
		printf("\n=======\n");	
		break;
		}
	case ACTION_SET_VARIABLE:
		{
		//000C	int16	variable to set
		//0010	int16	value
		//0012	int16	?? action 00 set 01 add
		//0014	int16	Optional message to receive
		printf("\tACTION_SET_VARIABLE for %s\n",UniqueObjectName(objList[objIndex]));
		printf("\t\tVariable to Set:%d\n",getValAtAddress(sub_ark,add_ptr+0xC,16));
		printf("\t\tValue:%d",getValAtAddress(sub_ark,add_ptr+0x10,16));
		printf("\t\taction?:%d (00 set 01 add)\n",getValAtAddress(sub_ark,add_ptr+0x12,16));
		printf("\t\tOptional Message:%d\n",getValAtAddress(sub_ark,add_ptr+0x14,16));	
		objList[objIndex].shockProperties[TRIG_PROPERTY_VARIABLE] =getValAtAddress(sub_ark,add_ptr+0xC,16);
		objList[objIndex].shockProperties[TRIG_PROPERTY_VALUE] = getValAtAddress(sub_ark,add_ptr+0x10,16);
		objList[objIndex].shockProperties[TRIG_PROPERTY_OPERATION]=getValAtAddress(sub_ark,add_ptr+0x12,16);
		objList[objIndex].shockProperties[TRIG_PROPERTY_MESSAGE1]=getValAtAddress(sub_ark,add_ptr+0x14,16);
			
		break;
		}
	case ACTION_ACTIVATE:
		{
		//000C	int16	1st object to activate.
		//000E	int16	Delay before activating object 1.
		//0010	...	Up to 4 objects and delays stored here.		
		printf("\tACTION_ACTIVATE for %s\n",UniqueObjectName(objList[objIndex]));

		printf("\t\t1st Object to activate raw :%d\t",getValAtAddress(sub_ark,add_ptr+0xC,16));
		printf("1st Object Delay:%d\n",getValAtAddress(sub_ark,add_ptr+0xe,16));

		printf("\t\t2nd Object to activate raw :%d\t",getValAtAddress(sub_ark,add_ptr+0x10,16));		
		printf("2nd Object Delay:%d\n",getValAtAddress(sub_ark,add_ptr+0x12,16));
		
		printf("\t\t3rd Object to activate raw :%d\t",getValAtAddress(sub_ark,add_ptr+0x14,16));
		printf("3rd Object Delay:%d\n",getValAtAddress(sub_ark,add_ptr+0x16,16));
		
		printf("\t\t4th Object to activate raw :%d\t",getValAtAddress(sub_ark,add_ptr+0x18,16));		
		printf("4th Object Delay:%d\n",getValAtAddress(sub_ark,add_ptr+0x1A,16));	
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
	case ACTION_LIGHTING:
		{
		//000C	int16	Control point 1
		//000E	int16	Control point 2
		//	...	?
		printf("\tACTION_LIGHTING for %s\n",UniqueObjectName(objList[objIndex]));
		printf("\t\tControl point 1:%d\n",getValAtAddress(sub_ark,add_ptr+12,16));
		printf("\t\tControl point 2%d\n",getValAtAddress(sub_ark,add_ptr+14,16));
		//printf("\t\tOther values 1:%d\n",getValAtAddress(sub_ark,add_ptr+16,16));
		//printf("\t\tOther values 2:%d\n",getValAtAddress(sub_ark,add_ptr+18,16));
		//printf("\t\tOther values 3:%d\n",getValAtAddress(sub_ark,add_ptr+20,16));
		//printf("\t\tOther values 4:%d\n",getValAtAddress(sub_ark,add_ptr+22,16));		
		//printf("\t\tOther values 5:%d\n",getValAtAddress(sub_ark,add_ptr+24,16));		
		//printf("\t\tOther values 6:%d\n",getValAtAddress(sub_ark,add_ptr+26,16));
		objList[objIndex].shockProperties[TRIG_PROPERTY_CONTROL_1] 	= getValAtAddress(sub_ark,add_ptr+12,16);
		objList[objIndex].shockProperties[TRIG_PROPERTY_CONTROL_2] 	= getValAtAddress(sub_ark,add_ptr+14,16);
			
		break;
		}
	case ACTION_EFFECT:
		{
		printf("\tACTION_EFFECT for %s\n",UniqueObjectName(objList[objIndex]));
		printf("\t\tOther values 1:%d\n",getValAtAddress(sub_ark,add_ptr+12,16));
		printf("\t\tOther values 2:%d\n",getValAtAddress(sub_ark,add_ptr+14,16));
		printf("\t\tOther values 3:%d\n",getValAtAddress(sub_ark,add_ptr+16,16));
		printf("\t\tOther values 4:%d\n",getValAtAddress(sub_ark,add_ptr+18,16));
		printf("\t\tOther values 5:%d\n",getValAtAddress(sub_ark,add_ptr+20,16));
		printf("\t\tOther values 6:%d\n",getValAtAddress(sub_ark,add_ptr+22,16));		
		printf("\t\tOther values 7:%d\n",getValAtAddress(sub_ark,add_ptr+24,16));		
		printf("\t\tOther values 8:%d\n",getValAtAddress(sub_ark,add_ptr+26,16));		
		break;
		}
	case ACTION_MOVING_PLATFORM:
		{
		//000C	int16	Tile x coord of platform
		//0010	int16	Tile y coord of platform
		//0014	int16	Target floor height
		//0016	int16	Target ceiling height
		//0018	int16	Speed
		printf("\tACTION_MOVING_PLATFORM action for %s\n", UniqueObjectName(objList[objIndex]));
		printf("\t\tTileX of Platform:%d\n",getValAtAddress(sub_ark,add_ptr+0x0C,16));
		printf("\t\tTileY of Platform:%d\n",getValAtAddress(sub_ark,add_ptr+0x10,16));
		printf("\t\tTarget floor height:%d\n",getValAtAddress(sub_ark,add_ptr+0x14,16));
		printf("\t\tTarget ceiling height:%d\n",getValAtAddress(sub_ark,add_ptr+0x16,16));
		printf("\t\tSpeed:%d\n",getValAtAddress(sub_ark,add_ptr+0x18,16));
		objList[objIndex].shockProperties[TRIG_PROPERTY_TARGET_X] = getValAtAddress(sub_ark,add_ptr+0x0C,16);
		objList[objIndex].shockProperties[TRIG_PROPERTY_TARGET_Y] = getValAtAddress(sub_ark,add_ptr+0x10,16);
		objList[objIndex].shockProperties[TRIG_PROPERTY_FLOOR] = getValAtAddress(sub_ark,add_ptr+0x14,16);	//5
		objList[objIndex].shockProperties[TRIG_PROPERTY_CEILING] = getValAtAddress(sub_ark,add_ptr+0x16,16);	//6
		objList[objIndex].shockProperties[TRIG_PROPERTY_SPEED] = getValAtAddress(sub_ark,add_ptr+0x18,16);
		LevelInfo[objList[objIndex].shockProperties[TRIG_PROPERTY_TARGET_X]][objList[objIndex].shockProperties[TRIG_PROPERTY_TARGET_Y]].hasElevator =1;
		
		short ceilingFlag = (objList[objIndex].shockProperties[TRIG_PROPERTY_CEILING]<=SHOCK_CEILING_HEIGHT);
		short floorFlag = (objList[objIndex].shockProperties[TRIG_PROPERTY_FLOOR] <= SHOCK_CEILING_HEIGHT);
		
		short elevatorFlag = (ceilingFlag << 1) | (floorFlag);
		
		LevelInfo[objList[objIndex].shockProperties[TRIG_PROPERTY_TARGET_X]][objList[objIndex].shockProperties[TRIG_PROPERTY_TARGET_Y]].hasElevator =elevatorFlag;
		//printf("\t\tOther values 1:%d\n",getValAtAddress(sub_ark,add_ptr+12,16));
		//printf("\t\tOther values 2:%d\n",getValAtAddress(sub_ark,add_ptr+14,16));
		//printf("\t\tOther values 3:%d\n",getValAtAddress(sub_ark,add_ptr+16,16));
		//printf("\t\tOther values 4:%d\n",getValAtAddress(sub_ark,add_ptr+18,16));
		//printf("\t\tOther values 5:%d\n",getValAtAddress(sub_ark,add_ptr+20,16));
		//printf("\t\tOther values 6:%d\n",getValAtAddress(sub_ark,add_ptr+22,16));		
		//printf("\t\tOther values 7:%d\n",getValAtAddress(sub_ark,add_ptr+24,16));		
		//printf("\t\tOther values 8:%d\n",getValAtAddress(sub_ark,add_ptr+26,16));
		
		break;
		
		}
	case ACTION_CHOICE:
		{//A toggle?
		//000C	int16	Trigger 1
		//0010	int16	Trigger 2
		printf("\tACTION_CHOICE for %s\n",UniqueObjectName(objList[objIndex]));
		printf("\t\tTrigger1:%d\n",getValAtAddress(sub_ark,add_ptr+0x0C,16));
		printf("\t\tTrigger2:%d\n",getValAtAddress(sub_ark,add_ptr+0x10,16));
		
		printf("\t\tOther values 4:%d\n",getValAtAddress(sub_ark,add_ptr+18,16));
		printf("\t\tOther values 5:%d\n",getValAtAddress(sub_ark,add_ptr+20,16));
		printf("\t\tOther values 6:%d\n",getValAtAddress(sub_ark,add_ptr+22,16));	
		printf("\t\tOther values 7:%d\n",getValAtAddress(sub_ark,add_ptr+24,16));		
		printf("\t\tOther values 8:%d\n",getValAtAddress(sub_ark,add_ptr+26,16));	
		objList[objIndex].shockProperties[TRIG_PROPERTY_TRIG_1] = getValAtAddress(sub_ark,add_ptr+0x0C,16);	
		objList[objIndex].shockProperties[TRIG_PROPERTY_TRIG_2] = getValAtAddress(sub_ark,add_ptr+0x10,16);	
		break;
		}
	case ACTION_EMAIL:
		{
		printf("\tACTION_EMAIL for %s\n",UniqueObjectName(objList[objIndex]));
		//	0F Player receives email
		//000C	int16	Chunk no. of email (offset from 2441 0x0989)
		printf("\t\tEmail chunk:", getValAtAddress(sub_ark,add_ptr+0x0C,16)+2441);
		objList[objIndex].shockProperties[TRIG_PROPERTY_EMAIL] =getValAtAddress(sub_ark,add_ptr+0x0C,16)+2441;
		
		break;
		
		}
	case ACTION_RADAWAY:
		{
		printf("\tACTION_RADAWAY for %s\n",UniqueObjectName(objList[objIndex]));
		printf("\t\tOther values 1:%d\n",getValAtAddress(sub_ark,add_ptr+12,16));
		printf("\t\tOther values 2:%d\n",getValAtAddress(sub_ark,add_ptr+14,16));
		printf("\t\tOther values 3:%d\n",getValAtAddress(sub_ark,add_ptr+16,16));
		printf("\t\tOther values 4:%d\n",getValAtAddress(sub_ark,add_ptr+18,16));
		//printf("\t\tOther values 5:%d\n",getValAtAddress(sub_ark,add_ptr+20,16));
		//printf("\t\tOther values 6:%d\n",getValAtAddress(sub_ark,add_ptr+22,16));		
		//printf("\t\tOther values 7:%d\n",getValAtAddress(sub_ark,add_ptr+24,16));		
		//printf("\t\tOther values 8:%d\n",getValAtAddress(sub_ark,add_ptr+26,16));	
		printf("\n=======\n");	
		break;
		}
	case ACTION_CHANGE_STATE:
		{
		printf("\tACTION_CHANGE_STATE for %s\n",UniqueObjectName(objList[objIndex]));
		printf("\t\tOther values 1:%d\n",getValAtAddress(sub_ark,add_ptr+12,16));
		printf("\t\tOther values 2:%d\n",getValAtAddress(sub_ark,add_ptr+14,16));
		printf("\t\tOther values 3:%d\n",getValAtAddress(sub_ark,add_ptr+16,16));
		printf("\t\tOther values 4:%d\n",getValAtAddress(sub_ark,add_ptr+18,16));
		printf("\t\tOther values 5:%d\n",getValAtAddress(sub_ark,add_ptr+20,16));
		printf("\t\tOther values 6:%d\n",getValAtAddress(sub_ark,add_ptr+22,16));		
		printf("\t\tOther values 7:%d\n",getValAtAddress(sub_ark,add_ptr+24,16));		
		printf("\t\tOther values 8:%d\n",getValAtAddress(sub_ark,add_ptr+26,16));
			
		break;
		}
	case ACTION_MESSAGE:
		{
		//16 Trap message offset in Chunk 2151 
		//000C	int16	"Success" message
		//0010	int16	"Fail" message
		printf("\tACTION_MESSAGE for %s\n",UniqueObjectName(objList[objIndex]));
			printf("\t\tSuccess Message%d\n",getValAtAddress(sub_ark,add_ptr+0x0C,16));
		printf("\t\tFail Message:%d\n",getValAtAddress(sub_ark,add_ptr+0x10,16));
		objList[objIndex].shockProperties[TRIG_PROPERTY_MESSAGE1]=getValAtAddress(sub_ark,add_ptr+0x0C,16);
		objList[objIndex].shockProperties[TRIG_PROPERTY_MESSAGE2]=getValAtAddress(sub_ark,add_ptr+0x10,16);
		
		printf("\t\tOther values 1:%d\n",getValAtAddress(sub_ark,add_ptr+12,16));
		printf("\t\tOther values 2:%d\n",getValAtAddress(sub_ark,add_ptr+14,16));
		printf("\t\tOther values 3:%d\n",getValAtAddress(sub_ark,add_ptr+16,16));
		printf("\t\tOther values 4:%d\n",getValAtAddress(sub_ark,add_ptr+18,16));
		printf("\t\tOther values 5:%d\n",getValAtAddress(sub_ark,add_ptr+20,16));
		printf("\t\tOther values 6:%d\n",getValAtAddress(sub_ark,add_ptr+22,16));		
		printf("\t\tOther values 7:%d\n",getValAtAddress(sub_ark,add_ptr+24,16));		
		printf("\t\tOther values 8:%d\n",getValAtAddress(sub_ark,add_ptr+26,16));	
					
		break;
		}
	case ACTION_SPAWN:	
		{
		//000C	int32	Class/subclass/type of object to spawn
		//0010	int16	Control point 1 (object)
		//0012	int16	Control point 2 (object)
		//0014		??
		//0018		??	
		printf("\tACTION_SPAWN for %s\n",UniqueObjectName(objList[objIndex]));
		printf("\t\Class-sub-type to spawn:%d\n",getValAtAddress(sub_ark,add_ptr+0x0C,32));
		printf("\t\tControl point object1:%d\n",getValAtAddress(sub_ark,add_ptr+0x10,16));
		printf("\t\tControl point object2:%d\n",getValAtAddress(sub_ark,add_ptr+0x12,16));
		printf("\t\t??:%d\n",getValAtAddress(sub_ark,add_ptr+0x14,16));		
		printf("\t\t??:%d\n",getValAtAddress(sub_ark,add_ptr+0x18,16));	
		objList[objIndex].shockProperties[TRIG_PROPERTY_TYPE]=getValAtAddress(sub_ark,add_ptr+0x0C,32);
		objList[objIndex].shockProperties[TRIG_PROPERTY_CONTROL_1]=getValAtAddress(sub_ark,add_ptr+0x10,16);
		objList[objIndex].shockProperties[TRIG_PROPERTY_CONTROL_1]=getValAtAddress(sub_ark,add_ptr+0x12,16);
			
		break;
		}	
	case ACTION_CHANGE_TYPE:
		{
		//000C	int16	Object ID to change.
		//0010	int8	New type.
		//0012		??
		printf("\tACTION_CHANGE_TYPE for %s\n",UniqueObjectName(objList[objIndex]));
		printf("\t\Object to Change:%d\n",getValAtAddress(sub_ark,add_ptr+0x0C,16));
		printf("\t\tNew Type:%d\n",getValAtAddress(sub_ark,add_ptr+0x10,8));
		printf("\t\t??:%d\n",getValAtAddress(sub_ark,add_ptr+0x12,16));	
			
		objList[objIndex].shockProperties[TRIG_PROPERTY_OBJECT] =getValAtAddress(sub_ark,add_ptr+0x0C,16);
		objList[objIndex].shockProperties[TRIG_PROPERTY_TYPE] =getValAtAddress(sub_ark,add_ptr+0x10,8);
			
		break;
		}
	default:
		{
		printf("\tUnknown triggeraction:%d for %s\n",TriggerType, UniqueObjectName(objList[objIndex]));
		printf("\t\tOther values 1:%d\n",getValAtAddress(sub_ark,add_ptr+12,16));
		printf("\t\tOther values 2:%d\n",getValAtAddress(sub_ark,add_ptr+14,16));
		printf("\t\tOther values 3:%d\n",getValAtAddress(sub_ark,add_ptr+16,16));
		printf("\t\tOther values 4:%d\n",getValAtAddress(sub_ark,add_ptr+18,16));
		printf("\t\tOther values 5:%d\n",getValAtAddress(sub_ark,add_ptr+20,16));
		printf("\t\tOther values 6:%d\n",getValAtAddress(sub_ark,add_ptr+22,16));		
		printf("\t\tOther values 7:%d\n",getValAtAddress(sub_ark,add_ptr+24,16));		
		printf("\t\tOther values 8:%d\n",getValAtAddress(sub_ark,add_ptr+26,16));			
		
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


void getShockButtons(unsigned char *sub_ark,int add_ptr, ObjectItem objList[1600], int objIndex)
{


if (objList[objIndex].ObjectSubClass ==0)
	{//regular buttons and switches
	objList[objIndex].shockProperties[BUTTON_PROPERTY_TRIGGER] = getValAtAddress(sub_ark,add_ptr+12,16);
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
	return;
	}

if((objList[objIndex].ObjectSubClass==2) && (objList[objIndex].ObjectSubClassIndex>=1))
	{//Fixup station/energy station
	objList[objIndex].shockProperties[0]  = getValAtAddress(sub_ark,add_ptr+0x0c,16);   //Amount of charge?/? always 255
	objList[objIndex].shockProperties[1]  = getValAtAddress(sub_ark,add_ptr+0x10,16);	//Security level?? //reuse timer??
		
	//shockProperties[2]  = getValAtAddress(sub_ark,add_ptr+0x12,16);
	//shockProperties[3]  = getValAtAddress(sub_ark,add_ptr+0x14,16);
	//
	//shockProperties[4]  = getValAtAddress(sub_ark,add_ptr+0x16,16);
	//shockProperties[5]  = getValAtAddress(sub_ark,add_ptr+0x18,16);
	//shockProperties[6]  = getValAtAddress(sub_ark,add_ptr+0x1A,16);
	//shockProperties[7]  = getValAtAddress(sub_ark,add_ptr+0x1B,16);
	//shockProperties[8]  = getValAtAddress(sub_ark,add_ptr+0x1C,16);		
	return;
	}
if((objList[objIndex].ObjectSubClass==3) && (objList[objIndex].ObjectSubClassIndex<=3))
	{	
	//puzzle panels. need to see them in the wild before I know what other stuff does
	objList[objIndex].shockProperties[BUTTON_PROPERTY_TRIGGER]=getValAtAddress(sub_ark,add_ptr+0x0c,16);
	
	//if bit 28 is set (0x10000000) it is a block puzzle, else it is a wire puzzle.
	objList[objIndex].shockProperties[BUTTON_PROPERTY_PUZZLE]= getValAtAddress(sub_ark,add_ptr+0x10,8);

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
}


char *UniqueObjectName(ObjectItem currObj)
{//returns a unique name for the object
	char str[80]="";
	//_snprintf(str,80,"%s_%02d_%02d_%02d_%04d", objectMasters[currObj.item_id].desc, currObj.tileX, currObj.tileY, currObj.levelno ,currObj.index);
	sprintf_s(str,80,"%s_%02d_%02d_%02d_%04d\0", objectMasters[currObj.item_id].desc, currObj.tileX, currObj.tileY, currObj.levelno ,currObj.index);
	return str;
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
	
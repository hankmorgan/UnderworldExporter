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
void CalcObjectXYZ(int game, float *offX,  float *offY, float *offZ, tile LevelInfo[64][64], ObjectItem objList[1600], long nextObj,int x,int y);

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
			default:
				{//just the basic name. with no properties.
				printf("\n// entity %d\n{\n",EntityCount);
				printf("\"classname\" \"%s\"\n", objectMasters[currobj.item_id].path);
				printf("\"name\" \"%s_%03d\"\n",objectMasters[currobj.item_id].desc,EntityCount);	
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
	printf("\"name\" \"runscript_%s_%03d_%03d_%03d\"\n",objectMasters[currobj.item_id].desc ,currobj.tileX,currobj.tileY,currobj.index );	
	printf("\"origin\" \"%f %f %f\"\n",x,y,z);	
	printf("\"call\" \"start_%s_%03d_%03d_%03d\"\n",objectMasters[currobj.item_id].desc ,currobj.tileX,currobj.tileY,currobj.index );	
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
		//printf("\"name\" \"entity_%03d\"\n",EntityCount);
		printf("\"name\" \"%s_%03d_%03d_%03d\"\n",objectMasters[currobj.item_id].desc ,currobj.tileX,currobj.tileY,currobj.index );	
		printf("\"origin\" \"%f %f %f\"\n",x,y,z);	
		EntityRotation(currobj.heading);
		AttachToJoint(currobj);
		if (currobj.link!=0)
			{
			printf("\"frobable\" \"%d\"\n",1);	
			printf("\"frob_action_script\" \"start_%s_%03d_%03d_%03d\"\n",objectMasters[currobj.item_id].desc ,currobj.tileX,currobj.tileY,currobj.index );	
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
	printf("\"name\" \"%s_%03d_%03d\"\n",objectMasters[currobj.item_id].desc,currobj.npc_whoami,EntityCount);
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
			{printf("\"origin\" \"%f %f %f\"\n",x,(tileY)*BrushY + ( (doorWidth+(BrushY-doorWidth)/2 ) ),z);	break;}
		case WEST:
			{printf("\"origin\" \"%f %f %f\"\n",x,(tileY)*BrushY + ( (0+(BrushY-doorWidth)/2 ) ),z);	break;}
		case NORTH:
			{printf("\"origin\" \"%f %f %f\"\n",(tileX)*BrushX + ( (doorWidth+(BrushX-doorWidth)/2 ) ),y,z);	break;}
		case SOUTH:
			{printf("\"origin\" \"%f %f %f\"\n",(tileX)*BrushX + ( (0+(BrushX-doorWidth)/2 ) ),y,z);	break;}
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
	printf("\"name\" \"%s_%03d_%03d_%03d\"\n",objectMasters[currobj.item_id].desc ,currobj.tileX,currobj.tileY,currobj.index );	
	printf("\"model\" \"models/darkmod/mechanical/switches/switch_flip.ase\"\n");	//Need to pass this in.
	//position
	printf("\"origin\" \"%f %f %f\"\n",x,y,z);	
	printf("\"rotate\" \"0 0 45\"\n");
	printf("\"interruptable\" \"0\"");
	EntityRotation(currobj.heading);
	printf("\"target\" \"runscript_%s_%03d_%03d_%03d\"\n",objectMasters[currobj.item_id].desc ,currobj.tileX,currobj.tileY,currobj.index );	
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
			printf("\n// entity %d\n{\n",EntityCount);
			printf("\"classname\" \"func_mover\"\n");
			printf("\"name\" \"%s_%03d_%03d\"\n",objectMasters[currobj.item_id].desc ,currobj.tileX,currobj.tileY);
			printf("\"model\" \"%s_%03d_%03d\"\n",objectMasters[currobj.item_id].desc ,currobj.tileX,currobj.tileY);
			PrimitiveCount=0;
			RenderDarkModTile(game,currobj.tileX,currobj.tileY,LevelInfo[currobj.tileX][currobj.tileY],0,0);
			printf("\n}");
			EntityCount++;
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

			printf("\n// entity %d\n{\n",EntityCount);
			printf("\"classname\" \"%s\"\n", objectMasters[currobj.item_id].path);
			//TODO:There is some weirdness when I try and hide water. For now I'll just ignore it.
			//if (LevelInfo[currobj.tileX+i][currobj.tileY+j].isWater == 0)
			//	{
				printf("\"name\" \"%s_initial_%03d_%03d_%03d_%03d\"\n",objectMasters[currobj.item_id].desc,currobj.tileX,currobj.tileY,currobj.index,tileCount);
			//	}
			//else
			//	{//water
			//	printf("\"name\" \"%s_initial_%03d_%03d_%03d_%03d\"\n",objectMasters[currobj.item_id].desc,currobj.tileX,currobj.tileY,currobj.index,tileCount);
		//		printf("\n\"underwater_gui\" \"guis\underwater\underwater_green_thinmurk.gui\"\n");
	//			}
			printf("\"model\" \"%s_initial_%03d_%03d_%03d_%03d\"\n",objectMasters[currobj.item_id].desc,currobj.tileX,currobj.tileY,currobj.index,tileCount);
			printf("\"origin\" \"%f %f %f\"\n",(currobj.tileX+i)*BrushSizeX,(currobj.tileY+j)*BrushSizeY,0);														
			RenderDarkModTile(game,0,0,LevelInfo[currobj.tileX+i][currobj.tileY+j],LevelInfo[currobj.tileX+i][currobj.tileY+j].isWater,0);
			printf("\n}\n");
			tileCount++;
			}
		}
	
	
	//Then render a func static for how it ends up.
	PrimitiveCount=0;
	printf("\n// entity %d\n{\n",EntityCount);
	printf("\"classname\" \"%s\"\n", objectMasters[currobj.item_id].path);
	printf("\"name\" \"%s_final_%03d_%03d_%03d\"\n",objectMasters[currobj.item_id].desc,currobj.tileX,currobj.tileY,currobj.index);
	printf("\"model\" \"%s_final_%03d_%03d_%03d\"\n",objectMasters[currobj.item_id].desc,currobj.tileX,currobj.tileY,currobj.index);
	printf("\"origin\" \"%f %f %f\"\n",currobj.tileX*BrushSizeX,currobj.tileY*BrushSizeY,0);
	
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
			RenderDarkModTile(game,i,j,t,0,0);
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
		printf("\"target\" \"runscript_%s_%03d_%03d_%03d\"\n",objectMasters[currobj.item_id].desc ,currobj.tileX,currobj.tileY,currobj.index );	
		}
	printf("\"name\" \"%s_%03d_%03d_%03d\"\n",objectMasters[currobj.item_id].desc,currobj.tileX,currobj.tileY,currobj.index);
	printf("\"model\" \"%s_%03d_%03d_%03d\"\n",objectMasters[currobj.item_id].desc,currobj.tileX,currobj.tileY,currobj.index);
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
		ReadableIndex = currobj.Property2;	//The chunk that the text comes from.
		break;
	default:
		ReadableIndex = currobj.link-0x200;
		break;
	}
	printf("\n// entity %d\n{\n",EntityCount);
	printf("\"classname\" \"%s\"\n", objectMasters[currobj.item_id].path);
	printf("\"name\" \"%s_%03d_%03d_%03d\"\n",objectMasters[currobj.item_id].desc ,currobj.tileX,currobj.tileY,currobj.index );		
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
			printf("\"trigger_on_open\" \"runscript_%s_%03d_%03d_%03d\"\n",objectMasters[currobj.item_id].desc ,currobj.tileX,currobj.tileY,currobj.index );	//plays the audio of this log
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
	printf("\"name\" \"%s_%03d_%03d_%03d\"\n",objectMasters[currobj.item_id].desc ,currobj.tileX,currobj.tileY,currobj.index );		
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
		printf("\"name\" \"%s_%03d_%03d_%03d\"\n",objectMasters[currobj.item_id].desc ,currobj.quality ,currobj.owner,currobj.index );	
		printf("\"origin\" \"%f %f %f\"\n",currobj.quality * BrushSizeX+(BrushSizeX/2),currobj.owner * BrushSizeY+(BrushSizeY/2), LevelInfo[currobj.quality][currobj.owner].floorHeight * BrushSizeZ);	
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
	printf("\"name\" \"%s_%03d_%03d_%03d\"\n",objectMasters[currobj.item_id].desc ,currobj.tileX,currobj.tileY,currobj.index );	
	printf("\"model\" \"%s_%03d_%03d_%03d\"\n",objectMasters[currobj.item_id].desc ,currobj.tileX,currobj.tileY,currobj.index );	
	printf("\"target\" \"runscript_%s_%03d_%03d_%03d\"\n",objectMasters[currobj.item_id].desc ,currobj.tileX,currobj.tileY,currobj.index );						
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
	t.floorHeight = 15;	//TODO:Is this right?
	t.isWater=0;
	t.hasElevator=0;
	RenderGenericTile(currobj.tileX,currobj.tileY,t,15,LevelInfo[currobj.tileX][currobj.tileY].floorHeight );
	printf("\n}");
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
int property1;	//Generic data pulled back from subclass tables.
int property2;
int property3;
int property4;
int property5;
//int IndexIntoCrossRef;
//int PrevLink;
//int NextLink;
//int XCoord;
//int YCoord;
//int ZCoord;
//int Angle1;
//int Angle2;
//int Angle3;
//int AIIndex;
//int ObjectType;
//int HitPoints;
//int State;

	FILE *file = NULL;      // File pointer
	//unsigned char *lev_ark; 
	unsigned char *tmp_ark; 
	unsigned char *sub_ark; 
	//unsigned char *tex_ark;
	unsigned char *inf_ark;
	unsigned char *mst_ark;
	long filepos;
	long AddressOfBlockStart=0;
	long address_pointer=4;
	char blnLevelFound=0;

//	int chunkId;
	long chunkUnpackedLength;
	long chunkType;//compression type
	long chunkPackedLength;
//	long chunkContentType;
	int MasterAddressLookup[1024];
	
//read in archive.dat
	if ((file = fopen(filePath, "rb")) == NULL)
		printf("Could not open specified file\n");
	else
		printf ("");
	long fileSize = getFileSize(file);
	filepos = ftell(file);
	tmp_ark = new unsigned char[fileSize];
	fread(tmp_ark, fileSize, 1,file);
	fclose(file);  
	//get the master object list from the archive
	AddressOfBlockStart = getShockBlockAddress(LevelNo*100+4008,tmp_ark,&chunkPackedLength,&chunkUnpackedLength,&chunkType);

	
	sub_ark = new unsigned char[chunkPackedLength];	
	mst_ark = new unsigned char[chunkUnpackedLength];	
	for (long k=0; k< chunkPackedLength; k++)
		{
			sub_ark[k] = tmp_ark[AddressOfBlockStart+k];
		}
	unpack_data(sub_ark,mst_ark,chunkUnpackedLength);

	int i=0;
	address_pointer=0;
	while (address_pointer <= chunkUnpackedLength)
		{//Get the addresses of the master list data of the mst_ark
		MasterAddressLookup[i++] = address_pointer;
		address_pointer+=27;
		}


//Read in the xref table and then read in it's stuff from the master table. I'll then have to go into the class blocks.
	AddressOfBlockStart = getShockBlockAddress(LevelNo*100+4009,tmp_ark,&chunkPackedLength,&chunkUnpackedLength,&chunkType);
	sub_ark = new unsigned char[chunkPackedLength];	
	inf_ark = new unsigned char[chunkUnpackedLength];	
	for (long k=0; k< chunkPackedLength; k++)
		{
			sub_ark[k] = tmp_ark[AddressOfBlockStart+k];
		}
	if (chunkType == 1)
		{
		unpack_data(sub_ark,inf_ark,chunkUnpackedLength);
		}
	else
		{
			for (long k=0; k< chunkUnpackedLength; k++)
				{
					inf_ark[k] = tmp_ark[k];
				}
		}
	i=0;
	long mstaddress_pointer;
	address_pointer=0;
	while (address_pointer < chunkUnpackedLength)
		{
		//printf("\nXRef : %d \n",i);
		//printf("TileX = %d\n",getValAtAddress(inf_ark,address_pointer+0,16));
		//printf("TileY = %d\n",getValAtAddress(inf_ark,address_pointer+2,16));
		int MasterIndex= getValAtAddress(inf_ark,address_pointer+4,16);
		//printf("Master Index = %d\n",MasterIndex);
		//printf("Next obj = %d\n",getValAtAddress(inf_ark,address_pointer+6,16));
//		printf("Next tile = %d\n",getValAtAddress(inf_ark,address_pointer+8,16));
		
		objList[i].index = i;
		objList[i].link =0;
		objList[i].joint=0;
		objList[i].heading=0;
		objList[i].next = getValAtAddress(inf_ark,address_pointer+6,16);
		objList[i].tileX= getValAtAddress(inf_ark,address_pointer+0,16);
		objList[i].tileY =getValAtAddress(inf_ark,address_pointer+2,16);

		//Now go visit the master list to get more info.
		
		mstaddress_pointer = MasterAddressLookup[MasterIndex];
		
			//printf("Object : %d \n",i);
			InUseFlag=getValAtAddress(mst_ark,mstaddress_pointer,8);
			//printf("InUse = %d\n",getValAtAddress(mst_ark,mstaddress_pointer,8));
			objList[i].InUseFlag = InUseFlag;
			ObjectClass =getValAtAddress(mst_ark,mstaddress_pointer+1,8);
			//printf("ObjectClass = %d\n",ObjectClass);
			objList[i].ObjectClass = ObjectClass;
			ObjectSubClass=getValAtAddress(mst_ark,mstaddress_pointer+2,8);
			//printf("ObjectSubClass = %d\n",ObjectSubClass);
			objList[i].ObjectSubClass = ObjectSubClass;
			int SubClassLink =getValAtAddress(mst_ark,mstaddress_pointer+3,16);
			//Subclass per sspecs is  a link to the sub table. not the class it self. For that we need the object type.
			ObjectSubClassIndex =getValAtAddress(mst_ark,mstaddress_pointer+20,8);	
			objList[i].ObjectSubClassIndex = ObjectSubClassIndex;
			//printf("ObjectSubClassIndex = %d\n",ObjectSubClassIndex);//cross ref this with the class table.

		
//			printf("ObjectType = %d\n",getValAtAddress(mst_ark,mstaddress_pointer+20,8));
//			printf("Index back to cross = %d\n",getValAtAddress(mst_ark,mstaddress_pointer+5,16));
			int LookupIndex=getShockObjectIndex(ObjectClass,ObjectSubClass,ObjectSubClassIndex);//Into my object list not the sublist
			//objList[i].LookUpIndex= LookupIndex;
			objList[i].item_id =LookupIndex;
			//printf("It is a %s\n", objectMasters[LookupIndex].desc );
			objList[i].x =getValAtAddress(mst_ark,mstaddress_pointer+11,8);
			objList[i].y = getValAtAddress(mst_ark,mstaddress_pointer+13,8);
			objList[i].zpos =getValAtAddress(mst_ark,mstaddress_pointer+15,8);
						
//			if (LookupIndex !=-1)
//				{
//				printf("It is a %s\n", shockObjectMasters[LookupIndex].desc );
//				}
//			else
//				{
//				printf("Description not found!\n");
//				}
			//printf("IndexIntoCrossRef = %d\n",getValAtAddress(mst_ark,mstaddress_pointer+5,16));
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
		lookUpSubClass(tmp_ark,LevelNo*100+SOFTWARE_LOGS_OFFSET, SubClassLink,&property1,&property2,&property3,&property4);
		objList[i].Property1 = property1;	//These will frustrate me eventually.
		objList[i].Property2 = property2;
		objList[i].Property3 = property3;
//		objList[i].Property4 = property4;
		break;
		}
	case FIXTURES:break;
	case GETTABLES_OTHER:break;
	case SWITCHES_PANELS:break;
	case DOORS_GRATINGS:break;
	case ANIMATED:break;
	case TRAPS_MARKERS:break;
	case CONTAINERS_CORPSES:break;
	case CRITTERS:break;
	}		
	
	
		//Object Debug output 
		//printf("\nXRef : %d \n",i);
		//printf("TileX = %d\n",getValAtAddress(inf_ark,address_pointer+0,16));
		//printf("TileY = %d\n",getValAtAddress(inf_ark,address_pointer+2,16));
		//printf("Master Index = %d\n",MasterIndex);
		//printf("Next obj = %d\n",getValAtAddress(inf_ark,address_pointer+6,16));
		//printf("Next tile = %d\n",getValAtAddress(inf_ark,address_pointer+8,16));		
		//printf("InUse = %d\n",getValAtAddress(mst_ark,mstaddress_pointer,8));
		//printf("ObjectClass = %d\n",ObjectClass);
		//printf("Object : %d \n",i);
		//printf("InUse = %d\n",getValAtAddress(mst_ark,mstaddress_pointer,8));
		//printf("ObjectClass = %d\n",ObjectClass);
		//printf("ObjectSubClass = %d\n",ObjectSubClass);
		//printf("ObjectSubClassIndex = %d\n",ObjectSubClassIndex);//cross ref this with the class table.
		//printf("It is a %s\n", objectMasters[LookupIndex].desc );
	
		
		
		address_pointer+=10;
		i++;
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
			objList[x].tileX=-1;
			objList[x].tileY=-1;
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

void lookUpSubClass(unsigned char *tmp_ark, int BlockNo, int index, int *property1,int *property2,int *property3,int *property4)
{
//
//	int chunkId;
	long chunkUnpackedLength;
	long chunkType;//compression type
	long chunkPackedLength;
//	long chunkContentType;
	
long AddressOfBlockStart = getShockBlockAddress(BlockNo,tmp_ark,&chunkPackedLength,&chunkUnpackedLength,&chunkType);
int k= 0;
int add_ptr=0;
while (k<=chunkUnpackedLength)
	{
	if (k==index)
		{
		
		//printf("Subclass Link=%d\n",k);
		//printf("Index back=%d\n",getValAtAddress(tmp_ark,AddressOfBlockStart+add_ptr+0,16));
		//printf("prev=%d\n",getValAtAddress(tmp_ark,AddressOfBlockStart+add_ptr+2,16));
		//printf("next=%d\n",getValAtAddress(tmp_ark,AddressOfBlockStart+add_ptr+4,16));
		//printf("version=%d\n",getValAtAddress(tmp_ark,AddressOfBlockStart+add_ptr+6,8));
		//printf("log chunk=%d\n",getValAtAddress(tmp_ark,AddressOfBlockStart+add_ptr+7,8));
		//printf("levelno=%d\n",getValAtAddress(tmp_ark,AddressOfBlockStart+add_ptr+8,8));
		*property1=getValAtAddress(tmp_ark,AddressOfBlockStart+add_ptr+6,8);	//Software version
		*property2=getValAtAddress(tmp_ark,AddressOfBlockStart+add_ptr+7,8) + 2488;	//Chunk containing log
		*property3=getValAtAddress(tmp_ark,AddressOfBlockStart+add_ptr+8,8);	//Level No of Chunk
		break;
		}
	add_ptr+=9;
	k++;
	}
return;
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
		
		if ((LevelInfo[x][y].tileType >= 6) && (LevelInfo[x][y].tileType <= 9) && (LevelInfo[x][y].isWater == 0))
			{
			*offZ = *offZ + (LevelInfo[x][y].shockSteep * (BrushSizeZ /2));
			}

}
#include <stdio.h>
#include <stdlib.h>
#include <fstream>
#ifndef gameobjects_h
	#define gameobjects_h
	#include "gameobjects.h"
#endif
#ifndef D3DarkMod_h
	#define D3DarkMod_h
	#include "D3DarkMod.h"
#endif
#ifndef textures_h
	#define textures_h
	#include "textures.h"
#endif
#ifndef main_h
	#define main_h
	#include "main.h"
#endif

#include "math.h"

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
	printf("}\n");EntityCount++;

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

	printf("\n// entity %d\n{\n",EntityCount);
	printf("\"classname\" \"%s\"\n", objectMasters[currobj.item_id].path);
	printf("\"name\" \"%s_%03d_%03d_%03d\"\n",objectMasters[currobj.item_id].desc ,currobj.tileX,currobj.tileY,currobj.index );		
	printf("\"inv_name\" \"Readable_%d\"\n", currobj.link - 0x200);
	switch (game)
		{
		case UWDEMO:
		case UW1:
			{printf("\"xdata_contents\" \"readables/uw1/scroll_%03d\"\n", currobj.link - 0x200);break;}
		case UW2:
			{printf("\"xdata_contents\" \"readables/uw2/scroll_%03d\"\n", currobj.link - 0x200);break;}
		case SHOCK:
			{//TODO:Whatever needs to go here.
			//printf("\"xdata_contents\" \"readables/shock/scroll_%03d\"\n", currobj.link - 0x200);
			break;}
		}	
	printf("\"origin\" \"%f %f %f\"\n",x,y,z);	
	EntityRotation(currobj.heading);
	AttachToJoint(currobj);		//for npc items
	printf("}");
	EntityCount++;
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
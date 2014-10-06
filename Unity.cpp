#include "tilemap.h"
#include "gameobjects.h"
#include "gameobjectsrender.h"
#include <fstream>
#include "main.h"
void RenderUnityModel(int game, float x, float y, float z, ObjectItem &currobj, ObjectItem objList[1600], tile LevelInfo[64][64]);
void RenderUnityEntity(int game, float x, float y, float z, ObjectItem &currobj, ObjectItem objList[1600], tile LevelInfo[64][64]);

extern long SHOCK_CEILING_HEIGHT;
extern long UW_CEILING_HEIGHT;
FILE *UNITY_FILE = NULL;

int LevelNo;

void RenderUnityObjectInteraction(int game, float x, float y, float z, ObjectItem &currobj, ObjectItem objList[1600], tile LevelInfo[64][64])
	{
	fprintf(UNITY_FILE, "\n\tCreateObjectInteraction(myObj,0.3f,0.3f,0.3f,\"OBJECTS_%03d\");",currobj.item_id);
	}

void RenderUnityEntityA_MOVE_TRIGGER(int game, float x, float y, float z, ObjectItem &currobj, ObjectItem objList[1600], tile LevelInfo[64][64])
	{
	//A trigger that fires when you step in it.
	//Params
	//item_id
	//index
	//tileX
	//tileY
	//need to add objectmaster path for generic usage
	//need to add objectmaster desc for generic usage
	RenderUnityModel(game, x, y, z, currobj, objList, LevelInfo);
	switch (game)
		{
			case UWDEMO:
			case UW1:	//At the corner of the tile
				//fprintf(MAPFILE, "\"origin\" \"%d %d %d\"\n", currobj.tileX*BrushSizeX, currobj.tileY*BrushSizeY, LevelInfo[currobj.tileX][currobj.tileY].floorHeight*BrushSizeZ);
				break;
			case UW2:	//Positioned around the triggers origin.
				//fprintf(MAPFILE, "\"origin\" \"%f %f %f\"\n", x, y, z);
				break;
			case SHOCK:	//At the corner of the tile.
				//fprintf(MAPFILE, "\"origin\" \"%d %d %d\"\n", currobj.tileX*BrushSizeX, currobj.tileY*BrushSizeY, 0);
				break;
		}

	//////tile t;	//temp tile for rendering trigger
	//////t.floorTexture = TRIGGER_MULTI;
	//////t.wallTexture = TRIGGER_MULTI;
	//////t.East = TRIGGER_MULTI;
	//////t.West = TRIGGER_MULTI;
	//////t.North = TRIGGER_MULTI;
	//////t.South = TRIGGER_MULTI;
	//////t.DimX = 1; t.DimY = 1;
	//////t.tileType = 1;
	//////t.Render = 1;
	//////t.floorHeight = 0;
	//////t.ceilingHeight = CEILING_HEIGHT;
	//////t.isWater = 0;
	//////t.hasElevator = 0;
	//////t.BullFrog = 0;
	//////switch (game)
	//////	{
	//////		case UWDEMO:
	//////		case UW1:
	//////			RenderGenericTile(0, 0, t, 1, 0);
	//////			break;
	//////		case UW2:
	//////			RenderGenericTileAroundOrigin(currobj.tileX, currobj.tileY, t, LevelInfo[currobj.tileX][currobj.tileY].floorHeight + 1, LevelInfo[currobj.tileX][currobj.tileY].floorHeight, BrushSizeZ);
	//////			break;
	//////		case SHOCK:
	//////			//enter any part of tile
	//////			RenderGenericTile(0, 0, t, CEILING_HEIGHT, 0);
	//////			break;
	//////	}

	//////fprintf(MAPFILE, "\n}");
	//////createScriptCall(currobj, x, y, z);
	}

void RenderUnityEntityPaintingUW(int game, float x, float y, float z, ObjectItem &currobj, ObjectItem objList[1600], tile LevelInfo[64][64])
	{//UW2 wall paintings.
	RenderUnityModel(game, x, y, z, currobj, objList, LevelInfo);
	RenderUnityObjectInteraction(game,x,y,z,currobj,objList,LevelInfo);
	}

void CreateUnityScriptCall(int game, float x, float y, float z, ObjectItem &currobj, ObjectItem objList[1600], tile LevelInfo[64][64], char *ScriptName)
	{//for objects that start scripts.
	//TriggerTargetX = currobj.quality;
	//TriggerTargetY = currobj.owner;
	//target = objList[nextObj].link
	if (currobj.link !=0)
		{//Need to update max state on this
		fprintf(UNITY_FILE, "\n\tCreateUWActivators(myObj,\"ButtonHandler\",\"%s\",%d,%d,%d,%d);", UniqueObjectName(objList[currobj.link]),currobj.quality,currobj.owner,currobj.flags,8);
		}
	}

void RenderUnityEntityNPC(int game, float x, float y, float z, ObjectItem &currobj, ObjectItem objList[1600], tile LevelInfo[64][64])
	{
	//Params
	//item_id
	//npc_whoami
	//npc_attitude
	//link for npc inventory in UW
	//objectOwnerEntity.
	//RenderUnityModel(game,x,y,z,currobj,objList,LevelInfo);
	
	fprintf(UNITY_FILE, "\n\tmyObj = new GameObject(\"%s\");", UniqueObjectName(currobj));//Create the object
	fprintf(UNITY_FILE, "\n\tpos = new Vector3(%ff, %ff, %ff);", x, z, y);//Create the object x,z,y
	fprintf(UNITY_FILE, "\n\tmyObj.transform.position = pos;");//Position the object
	fprintf(UNITY_FILE, "\n\tCreateNPC(myObj,\"%s\",\"Assets/Sprites/objects_%03d\");", objectMasters[currobj.item_id].desc, currobj.item_id);
	switch (currobj.npc_attitude)
		{
			case 0:	//hostile
				{
				//fprintf(MAPFILE, "\"team\" \"5\"\n");	//Criminals team
				break;
				}
			default:
				{
				//fprintf(MAPFILE, "\"team\" \"5\"\n");	//Beggars team
				break;
				}
		}

	if (currobj.link != 0)//Npc has an inventory	I need to set up joints for the entities.
		{
		int JointCount = 1;	//For a future joint enumeration
		//TODO:Clean this up,
		ObjectItem tmpobj = objList[currobj.link];
		tmpobj.objectOwner = currobj.index;
		currobj.objectOwner = currobj.index;
		tmpobj.objectOwnerName = currobj.npc_whoami;
		currobj.objectOwnerName = currobj.npc_whoami;
		if (currobj.objectOwnerEntity == 0){ currobj.objectOwnerEntity = EntityCount - 1; } //assumes the previous entity is the npc with the inventory.
		tmpobj.objectOwnerEntity = currobj.objectOwnerEntity;
		tmpobj.joint = JointCount++;
		while (tmpobj.next != 0)
			{
			RenderUnityEntity(game, x, y, z, tmpobj, objList, LevelInfo);	//Need to fix up the x y z to a better spot.
			tmpobj = objList[tmpobj.next];
			//I pass the owner info down the line
			tmpobj.objectOwner = currobj.objectOwner;
			tmpobj.objectOwnerName = currobj.objectOwnerName;
			tmpobj.objectOwnerEntity = currobj.objectOwnerEntity;
			tmpobj.joint = JointCount++;
			}
		RenderUnityEntity(game, x, y, z, tmpobj, objList, LevelInfo); //NPC's inventory.

		}

	return;
	}

void RenderUnityEntityDoor(int game, float x, float y, float z, ObjectItem &currobj, ObjectItem objList[1600], tile LevelInfo[64][64])
	{
	//Params
	//item_id
	//tileX
	//tileY
	//Link for a lock

	//float BrushX = BrushSizeX;
	//float BrushY = BrushSizeY;
	//float zpos = z;

	//zpos = LevelInfo[currobj.tileX][currobj.tileY].floorHeight*BrushSizeZ;//Force the door to stay on the ground.
	//z = zpos;

	//for a door I need to point it's used_by property at the key object's name. This is accessed through a lock object

	//RenderUnityModel(game, x, y, z, currobj, objList, LevelInfo);
	fprintf(UNITY_FILE, "\n\tmyObj = new GameObject(\"door_%03d_%03d\");",currobj.tileX, currobj.tileY);//Create the object
	fprintf(UNITY_FILE, "\n\tpos = new Vector3(%ff, %ff, %ff);", x, z, y);//Create the object x,z,y
	fprintf(UNITY_FILE, "\n\tmyObj.transform.position = pos;");//Position the object
	fprintf(UNITY_FILE, "\n\tCreateObjectGraphics(myObj,\"Assets/Sprites/objects_%03d.tga\",true);", currobj.item_id);
	
	RenderUnityObjectInteraction(game, x, y, z, currobj, objList, LevelInfo);

	if ((currobj.link != 0) || (currobj.SHOCKLocked >0))	//door has a lock. bit 0-6 of the lock objects link is the keyid for opening it in uw
		{
		//up to 6 keys can be used for a door to allow duplicate keys.
		if (game != SHOCK)
			{
			//The door is locked and needs a key
			}
		else
			{
			//And the same in shock
			//fprintf(MAPFILE, "\"locked\" \"%d\"\n", 1);
			if ((currobj.link > 0) && (currobj.link <= 11))	//Only this many keycards
				{
				//char *strKeyName = getObjectNameByClass(GETTABLES_OTHER, 4, currobj.link);
				//fprintf(MAPFILE, "\"used_by\" \"%s_0\"\n", strKeyName);
				//fprintf(MAPFILE, "\"used_by1\" \"%s_1\"\n", strKeyName);
				//fprintf(MAPFILE, "\"used_by2\" \"%s_2\"\n", strKeyName);
				//fprintf(MAPFILE, "\"used_by3\" \"%s_3\"\n", strKeyName);
				//fprintf(MAPFILE, "\"used_by4\" \"%s_4\"\n", strKeyName);
				//fprintf(MAPFILE, "\"used_by5\" \"%s_5\"\n", strKeyName);
				}
			}
		}
	if (objectMasters[currobj.item_id].type == PORTCULLIS)
		{
		//The door is a portcullis and must translate up.
		//fprintf(MAPFILE, "\"rotate\" \"0 0 0\"\n");
		//fprintf(MAPFILE, "\"translate\" \"0 0 80\"\n");
		}

	if ((currobj.link != 0) || (currobj.SHOCKLocked >0))
		{	
		//if it has a lock it needs a lock object for scripting purposes

		}
	return;
	}

void RenderUnityEntitySHOCKDoor(int game, float x, float y, float z, ObjectItem &currobj, ObjectItem objList[1600], tile LevelInfo[64][64])
	{
	RenderUnityModel(game,x,y,z,currobj,objList,LevelInfo);
	RenderUnityObjectInteraction(game, x, y, z, currobj, objList, LevelInfo);

	//Lock stuff
	if ((currobj.link != 0) || (currobj.SHOCKLocked > 0))	//door has a lock. bit 0-6 of the lock objects link is the keyid for opening it in uw
		{
		//the door is locked
		if ((currobj.link > 0) && (currobj.link <= 11))	//Only this many keycards
			{
			//What keys open this door.
			}
		}


	if ((currobj.link != 0) || (currobj.SHOCKLocked >0) && (game != SHOCK))
		{	
		//if it has a lock it needs a lock object for scripting purposes
		}

	}

void RenderUnityEntityKey(int game, float x, float y, float z, ObjectItem &currobj, ObjectItem objList[1600], tile LevelInfo[64][64])
	{
	//Creates a key. Each key is uniquely named based on a counter. Doors will have a list of potential matching key names to work with keys.
	//Params
	//Item_id
	//Owner

	//A key's owner id matches it's lock link id.
	RenderUnityModel(game,x,y,z,currobj,objList,LevelInfo);
	RenderUnityObjectInteraction(game, x, y, z, currobj, objList, LevelInfo);
	return;
	}

void RenderUnityEntityContainer(int game, float x, float y, float z, ObjectItem &currobj, ObjectItem objList[1600], tile LevelInfo[64][64])
	{
	//Creates something that holds objects. 
	//Params.
	//Item_id
	//link	//To check for a lock and it's list of contents.
	if (game != SHOCK)
		{
		RenderUnityModel(game,x,y,z,currobj,objList,LevelInfo);
		RenderUnityObjectInteraction(game, x, y, z, currobj, objList, LevelInfo);

		if (objectMasters[objList[currobj.link].item_id].type == LOCK)	//container has a lock.
			{//bit 1 of the flags is the lock?
			//Container is locked
			}
		//now recursively get it's contents.
		if (currobj.link != 0)	//Container has objects
			{
			fprintf(UNITY_FILE, "\n\t////Container contents");
			fprintf(UNITY_FILE, "\n\tParentContainer = myObj.AddComponent<Container>();");
			fprintf(UNITY_FILE, "\n\tmyObj.GetComponent<ObjectInteraction>().isContainer = true;");
			ObjectItem tmpobj = objList[currobj.link];
			int count = 0;
			while (tmpobj.next != 0)
				{
				if (objectMasters[objList[currobj.link].item_id].type != LOCK)
					{
					RenderUnityEntity(game, x, y, z, tmpobj, objList, LevelInfo);
					fprintf(UNITY_FILE, "\n\tmyObj.transform.position = invMarker.transform.position;");//Move the inventory contents to a inventory room
					fprintf(UNITY_FILE, "\n\tmyObj.transform.parent = invMarker.transform;");//Attach to the persistent marker.
					fprintf(UNITY_FILE, "\n\tAddObjectToContainer(myObj, ParentContainer, %d);", count++);//Move the inventory contents to a container script
					}
				tmpobj = objList[tmpobj.next];
				}
			RenderUnityEntity(game, x, y, z, tmpobj, objList, LevelInfo);
			fprintf(UNITY_FILE, "\n\tmyObj.transform.position = invMarker.transform.position;");//Move the inventory contents to a inventory room
			fprintf(UNITY_FILE, "\n\tmyObj.transform.parent = invMarker.transform;");//Attach to the persistent marker.
			fprintf(UNITY_FILE, "\n\tAddObjectToContainer(myObj, ParentContainer, %d);", count++);//Move the inventory contents to a container script
			}
		fprintf(UNITY_FILE, "\n\t////Container contents complete");
		return;
		}
	else
		{
		//Shock container. contents are different from uw1
		RenderUnityModel(game, x, y, z, currobj, objList, LevelInfo);

		if (hasContents(currobj))
			{
			////createScriptCall(currobj, x, y, z);

			////create 4 spawn points around the container to spawn the contents at.
			//int offX = 10; int offY = 10;
			//for (int i = 0; i < 4; i++)
			//	{
			//	switch (i)
			//		{
			//			case 0: offX = 10; offY = 10; break;
			//			case 1: offX = -10; offY = 10; break;
			//			case 2: offX = 10; offY = -10; break;
			//			case 3: offX = -10; offY = -10; break;
			//		}

			//	if (currobj.shockProperties[CONTAINER_CONTENTS_1 + i] != 0)
			//		{
			//		fprintf(MAPFILE, "\n// entity %d\n{\n", EntityCount++);
			//		fprintf(MAPFILE, "\"classname\" \"%s\"\n", "target_null");
			//		fprintf(MAPFILE, "\"name\" \"%s_spawnpoint_%d\"\n", UniqueObjectName(currobj), i);
			//		fprintf(MAPFILE, "\"origin\" \"%f %f %f\"\n", x + offX, y + offY, z);
			//		fprintf(MAPFILE, "}");
			//		}
			//	}
			}
		}
	}

void RenderUnityEntityActivator(int game, float x, float y, float z, ObjectItem &currobj, ObjectItem objList[1600], tile LevelInfo[64][64])
	{//Something in the game world that can fire off events
	RenderUnityModel(game, x, y, z, currobj, objList, LevelInfo);
	CreateUnityScriptCall(game,x,y,z,currobj,objList,LevelInfo,"ButtonHandler");
	return;
	}

void RenderUnityEntityButton(int game, float x, float y, float z, ObjectItem &currobj, ObjectItem objList[1600], tile LevelInfo[64][64])
	{
	//
	//Params
	//item_id
	//tileX
	//tileY
	//index
	//heading
	//Need to pass desc/path for generic handling
	RenderUnityModel(game, x, y, z, currobj, objList, LevelInfo);
	CreateUnityScriptCall(game, x, y, z, currobj, objList, LevelInfo, "ButtonHandler"); 
	return;
	}

void RenderUnityEntityA_DO_TRAP(int game, float x, float y, float z, ObjectItem &currobj, ObjectItem objList[1600], tile LevelInfo[64][64])
	{
	return;
	//This is a trigger in UW that can do a bunch of different things. Eg cameras/rising platforms.
	switch (currobj.quality)
		{
			case 2: //A camera	
				RenderUnityModel(game, x, y, z, currobj, objList, LevelInfo);
				//fprintf(MAPFILE, "\n// entity %d\n{\n", EntityCount);
				//fprintf(MAPFILE, "\"classname\" \"func_cameraview\"\n");
				//fprintf(MAPFILE, "\"name\" \"%s_%03d_%03d\"\n", objectMasters[currobj.item_id].desc, currobj.tileX, currobj.tileY);
				//fprintf(MAPFILE, "\"origin\" \"%f %f %f\"\n", x, y, z);
				//fprintf(MAPFILE, "\"trigger\" \"1\"\n");
				////Aim the camera.
				//EntityRotation(currobj.heading);//TODO:Points in wrong direction
				//fprintf(MAPFILE, "\n}");
				//EntityCount++;
				break;
			case 3:	//rising platform
				RenderUnityModel(game, x, y, z, currobj, objList, LevelInfo);
				if (currobj.link !=0)
					{
					fprintf(UNITY_FILE, "\n\tCreateUWScriptObjects(myObj,0,0,\"%s\",\"a_do_trap_platform\",%d);", UniqueObjectName(objList[currobj.link]), currobj.flags);
					}
				else
					{
					fprintf(UNITY_FILE, "\n\tCreateUWScriptObjects(myObj,0,0,\"\",\"a_do_trap_platform\",%d);",currobj.flags);
					}

				break;
				//case 24://Bullfrog
				//	
			default:
				//RenderEntityParticle(game, x, y, z, currobj, objList, LevelInfo, 0);
				RenderUnityModel(game, x, y, z, currobj, objList, LevelInfo);
				//	fprintf(MAPFILE, "\n// entity %d\n{\n", EntityCount);
				//	fprintf(MAPFILE, "\"classname\" \"func_static\"\n");
				//	fprintf(MAPFILE, "\"name\" \"%s\"\n",UniqueObjectName(currobj));
				//	//models/darkmod/decorative/hourglass.ase
				//	fprintf(MAPFILE, "\n\"model\" \"models/darkmod/decorative/hourglass.ase\"");
				//	fprintf(MAPFILE, "\"origin\" \"%f %f %f\"\n", x, y, z);
				//	fprintf(MAPFILE, "\n}");
				//	EntityCount++;
		}

	return;
	}

void RenderUnityEntityA_CHANGE_TERRAIN_TRAP(int game, float x, float y, float z, ObjectItem &currobj, ObjectItem objList[1600], tile LevelInfo[64][64])
	{
	//
	//A trigger that converts one type of terrain into another.
	//We generate both types of terrain at the start but hide the second type until the trigger is activated.
	//render func static for the initial tiles.
	//////PrimitiveCount = 0;
	//////int tileCount = 0;
	
RenderUnityModel(game, x, y, z, currobj, objList, LevelInfo);

	//////for (int i = 0; i <= currobj.x; i++)
	//////	{
	//////	for (int j = 0; j <= currobj.y; j++)
	//////		{
	//////		//Then render a func static for how it ends up.
	//////		PrimitiveCount = 0;
	//////		fprintf(MAPFILE, "\n// entity %d\n{\n", EntityCount++);
	//////		fprintf(MAPFILE, "\"classname\" \"%s\"\n", objectMasters[currobj.item_id].path);
	//////		fprintf(MAPFILE, "\"name\" \"%s_%02d_%02d\"\n", UniqueObjectName(currobj), currobj.tileX + i, currobj.tileY + j);
	//////		fprintf(MAPFILE, "\"model\" \"%s_%02d_%02d\"\n", UniqueObjectName(currobj), currobj.tileX + i, currobj.tileY + j);
	//////		fprintf(MAPFILE, "\"origin\" \"%d %d %d\"\n", currobj.tileX*BrushSizeX + (i*BrushSizeX), currobj.tileY*BrushSizeY + (j*BrushSizeY), 0);

	//////		tile t;	//temporary tile for rendering.
	//////		t.tileType = currobj.quality & 0x01;
	//////		t.Render = 1;
	//////		t.floorHeight = ((currobj.zpos >> 3) >> 2) * 8;	//heights in uw are shifted
	//////		t.floorHeight = (currobj.zpos >> 2);	//heights in uw are shifted
	//////		t.ceilingHeight = 0;
	//////		if (game != UW2)
	//////			{
	//////			t.floorTexture = (currobj.quality >> 1) + 210;
	//////			}
	//////		else
	//////			{
	//////			t.floorTexture = LevelInfo[currobj.tileX][currobj.tileY].floorTexture;//?
	//////			}
	//////		t.shockCeilingTexture = LevelInfo[currobj.tileX + i][currobj.tileY + j].shockCeilingTexture;
	//////		t.wallTexture = LevelInfo[currobj.tileX + i][currobj.tileY + j].wallTexture;
	//////		t.West = LevelInfo[currobj.tileX + i][currobj.tileY + j].West;
	//////		t.East = LevelInfo[currobj.tileX + i][currobj.tileY + j].East;
	//////		t.North = LevelInfo[currobj.tileX + i][currobj.tileY + j].North;
	//////		t.South = LevelInfo[currobj.tileX + i][currobj.tileY + j].South;
	//////		t.isWater = 0;
	//////		t.DimY = 1;
	//////		t.DimX = 1;
	//////		t.hasElevator = 0;
	//////		t.BullFrog = 0;
	//////		RenderDarkModTile(game, 0, 0, t, 0, 0, 0, 1);
	//////		fprintf(MAPFILE, "\n}\n");

	//////		}
	//////	}

	}

void RenderUnityEntityTMAP(int game, float x, float y, float z, ObjectItem &currobj, ObjectItem objList[1600], tile LevelInfo[64][64])
	{//Flat patch objects used as decals. This should be changed into something like a SHOCK screen model?
	//params
	//link	to see if it can be activated
	//tileX
	//tileY
	//index
	RenderUnityModel(game, x, y, z, currobj, objList, LevelInfo);

	if (isTrigger(objList[currobj.link]) != 0)
		{
		//object is a trigger
		CreateUnityScriptCall(game, x, y, z, currobj, objList, LevelInfo, "ButtonHandler");
		}
	else
		{
		RenderUnityObjectInteraction(game, x, y, z, currobj, objList, LevelInfo);
		}
	return;
	}

void RenderUnityEntityBOOK(int game, float x, float y, float z, short message, ObjectItem &currobj, ObjectItem objList[1600], tile LevelInfo[64][64])
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
				ReadableIndex = currobj.shockProperties[SOFT_PROPERTY_LOG];	//currobj.Property1;	//The chunk that the text comes from.
				break;
			default:
				ReadableIndex = currobj.link - 0x200;
				break;
		}
	RenderUnityModel(game, x, y, z, currobj, objList, LevelInfo);
	RenderUnityObjectInteraction(game, x, y, z, currobj, objList, LevelInfo);
	if (message == 1)//atdm:readable_mobile_scroll01
		{//This is a hidden email OR MESSAGE
		//fprintf(MAPFILE, "\"classname\" \"%s\"\n", "atdm:readable_mobile_scroll01");
		//fprintf(MAPFILE, "\"name\" \"%s_email\"\n", UniqueObjectName(currobj));
		//fprintf(MAPFILE, "\"hide\" \"1\"\n");
		}
	else
		{
		//fprintf(MAPFILE, "\"classname\" \"%s\"\n", objectMasters[currobj.item_id].path);
		//fprintf(MAPFILE, "\"name\" \"%s\"\n", UniqueObjectName(currobj));
		}
	//fprintf(MAPFILE, "\"inv_name\" \"Readable_%d\"\n", ReadableIndex);	//Need a better name than this!
	//fprintf(MAPFILE, "\"inv_icon\" \"%s\"\n", objectMasters[currobj.item_id].InvIcon);
	////////switch (game)
	////////	{
	////////		case UWDEMO:
	////////		case UW1:
	////////			{fprintf(MAPFILE, "\"xdata_contents\" \"readables/uw1/scroll_%03d\"\n", ReadableIndex); break; }
	////////		case UW2:
	////////			{fprintf(MAPFILE, "\"xdata_contents\" \"readables/uw2/scroll_%03d\"\n", ReadableIndex); break; }
	////////		case SHOCK:
	////////			{
	////////			fprintf(MAPFILE, "\"xdata_contents\" \"readables/shock/log_%03d\"\n", ReadableIndex);
	////////			if (message == 0)
	////////				{//plays the audio of this log
	////////				fprintf(MAPFILE, "\"trigger_on_open\" \"runscript_%s\"\n", UniqueObjectName(currobj));
	////////				}
	////////			else
	////////				{
	////////				fprintf(MAPFILE, "\"trigger_on_open\" \"runscript_%s_email\"\n", UniqueObjectName(currobj));
	////////				}
	////////			break;
	////////			}
	////////	}
	////////fprintf(MAPFILE, "\"origin\" \"%f %f %f\"\n", x, y, z);
	////////EntityRotation(currobj.heading);
	////////AttachToJoint(currobj);		//for npc items
	////////fprintf(MAPFILE, "}");
	////////EntityCount++;
	if (game == SHOCK)
		{
		if (message == 0)
			{
			////createScriptCall(currobj, x, y, z);
			}
		else
			{
			//char str[80]; 
			//sprintf_s(str, "runscript_%s_email", UniqueObjectName(currobj));
			///createScriptCall(currobj, x, y, z, "email");
			}
		}
	return;
	}

void RenderUnityEntitySIGN(int game, float x, float y, float z, ObjectItem &currobj, ObjectItem objList[1600], tile LevelInfo[64][64])
	{
	//A flat object with a gui that is a readable.
	//Params
	//tileX
	//tileY
	//Index
	//currobj.link -200 = pointer to the readable string block in UW
	//heading

	RenderUnityModel(game, x, y, z, currobj, objList, LevelInfo);
	RenderUnityObjectInteraction(game, x, y, z, currobj, objList, LevelInfo);

	//fprintf (MAPFILE, "\"xdata_contents\" \"readables/uw1/sign_%03d\"\n", currobj.link - 0x200);
	////////switch (game)
	////////	{
	////////		case UWDEMO:
	////////		case UW1:
	////////			fprintf(MAPFILE, "\"xdata_contents\" \"readables/uw1/sign_%03d\"\n", currobj.link - 0x200);
	////////			fprintf(MAPFILE, "\"skin\" \"uw1_sign_%02d\"\n", currobj.flags & 0x7);
	////////			break;
	////////		case UW2:
	////////			fprintf(MAPFILE, "\"xdata_contents\" \"readables/uw2/sign_%03d\"\n", currobj.link - 0x200);
	////////			fprintf(MAPFILE, "\"skin\" \"uw2_sign_%02d\"\n", currobj.flags & 0x7);
	////////			break;
	////////		case SHOCK:
	////////			{//TODO:Whatever needs to go here.
	////////			//fprintf (MAPFILE, "\"xdata_contents\" \"readables/shock/sign_%03d\"\n", currobj.link - 0x200);
	////////			break; }
	////////	}

	return;
	}

void RenderUnityEntityA_TELEPORT_TRAP(int game, float x, float y, float z, ObjectItem &currobj, ObjectItem objList[1600], tile LevelInfo[64][64])
	{
	//This is the destination spot of a teleport.
	//zpos = this level
	//item_id for type
	//quality = x coord of destination
	//owner = y coord of destination
	//need to add objectmaster path for generic usage.

	RenderUnityModel(game, x, y, z, currobj, objList, LevelInfo);
	RenderUnityObjectInteraction(game, x, y, z, currobj, objList, LevelInfo);

	//only show if it points to this level.
	if (currobj.zpos == 0)
		{
		////fprintf(MAPFILE, "\n// entity %d\n{\n", EntityCount);
		////fprintf(MAPFILE, "\"classname\" \"%s\"\n", objectMasters[currobj.item_id].path);
		////fprintf(MAPFILE, "\"name\" \"%s\"\n", UniqueObjectName(currobj));
		////fprintf(MAPFILE, "\"origin\" \"%d %d %d\"\n", currobj.quality * BrushSizeX + (BrushSizeX / 2), currobj.owner * BrushSizeY + (BrushSizeY / 2), LevelInfo[currobj.quality][currobj.owner].floorHeight * BrushSizeZ);
		////fprintf(MAPFILE, "\n}");
		}
	return;
	}

void RenderUnityEntityDecal(int game, float x, float y, float z, ObjectItem &currobj, ObjectItem objList[1600], tile LevelInfo[64][64])
	{//decals like wall icons etc.
	
RenderUnityModel(game, x, y, z, currobj, objList, LevelInfo);
RenderUnityObjectInteraction(game, x, y, z, currobj, objList, LevelInfo);

	switch (currobj.ObjectSubClassIndex)
		{
			case 0:	//sign
				//fprintf(MAPFILE, "\"model\" \"%s\"\n", objectMasters[currobj.item_id].path);
				//fprintf(MAPFILE, "\"skin\" \"shock_sign_%04d\"\n", 390 + currobj.unk1);
				break;
			case 1:	//icon
				//fprintf(MAPFILE, "\"model\" \"%s\"\n", objectMasters[currobj.item_id].path);
				//fprintf(MAPFILE, "\"skin\" \"shock_icon_%04d\"\n", currobj.unk1);
				break;
			case 2:	//graffiti
				if (currobj.unk1 != 7)
					{
					//fprintf(MAPFILE, "\"model\" \"%s\"\n", objectMasters[currobj.item_id].path);
					}
				else
					{
					//fprintf(MAPFILE, "\"model\" \"%s\"\n", objectMasters[131].path);	//special case for shodan hearts diego 
					}
				//fprintf(MAPFILE, "\"skin\" \"shock_graffiti_%04d\"\n", currobj.unk1);
				break;
			case 4:	//painting
				if (currobj.unk1 != 2)
					{
					//fprintf(MAPFILE, "\"model\" \"%s\"\n", objectMasters[currobj.item_id].path);
					}
				else
					{
					//fprintf(MAPFILE, "\"model\" \"%s\"\n", objectMasters[126].path);//special case for the scream.
					}
				//fprintf(MAPFILE, "\"skin\" \"shock_painting_%04d\"\n", 403 + currobj.unk1);

				break;
			case 5:	//poster
				//fprintf(MAPFILE, "\"model\" \"%s\"\n", objectMasters[currobj.item_id].path);
				//fprintf(MAPFILE, "\"skin\" \"shock_poster_%04d\"\n", currobj.unk1);
				break;
		}
	}

void RenderUnityEntityComputerScreen(int game, float x, float y, float z, ObjectItem &currobj, ObjectItem objList[1600], tile LevelInfo[64][64])
	{
	RenderUnityModel(game, x, y, z, currobj, objList, LevelInfo);
	RenderUnityObjectInteraction(game, x, y, z, currobj, objList, LevelInfo);
	if (currobj.shockProperties[SCREEN_START] < 246)
		{
		//fprintf(MAPFILE, "\"classname\" \"%s\"\n", "func_damagable");
		//fprintf(MAPFILE, "\"name\" \"%s\"\n", UniqueObjectName(currobj));
		//fprintf(MAPFILE, "\"gui\" \"guis/shock/screen_%d_%d_%d.gui\"\n", currobj.shockProperties[SCREEN_START], currobj.shockProperties[SCREEN_NO_OF_FRAMES], currobj.shockProperties[SCREEN_LOOP_FLAG]);
		//fprintf(MAPFILE, "\"target\" \"runscript_%s_destroy\"\n", UniqueObjectName(currobj));
		//fprintf(MAPFILE, "\"gui_parm1\" \"0\"\n", UniqueObjectName(currobj));
		}
	else
		{//unimplemented special screens.
		//fprintf(MAPFILE, "\"classname\" \"%s\"\n", "func_static");
		//fprintf(MAPFILE, "\"gui\" \"guis/shock/screen.gui\"\n");

		}


	if (currobj.shockProperties[SCREEN_START] < 246)
		{//destructable
		//createScriptCall(currobj, x, y, z, "destroy");
		}


	}

void RenderUnityEntityNULL_TRIGGER(int game, float x, float y, float z, ObjectItem &currobj, ObjectItem objList[1600], tile LevelInfo[64][64])
	{//And a level entry as well.
	RenderUnityModel(game, x, y, z, currobj, objList, LevelInfo);
	RenderUnityObjectInteraction(game, x, y, z, currobj, objList, LevelInfo);
	if (currobj.TriggerAction == ACTION_TIMER)
		{
		//create a timer to set off.
		//fprintf(MAPFILE, "\n// entity %d\n{\n", EntityCount);
		//fprintf(MAPFILE, "\"classname\" \"trigger_timer\"\n");
		//fprintf(MAPFILE, "\"name\" \"timer_%s\"\n", UniqueObjectName(currobj));
		//fprintf(MAPFILE, "\"origin\" \"%f %f %f\"\n", x, y, z);
		//fprintf(MAPFILE, "\"wait\" \"%d\"\n", 1);
		////fprintf(MAPFILE, "\"random\" \"%d\"\n", 3);
		//fprintf(MAPFILE, "\"target0\" \"runscript_%s\"\n", UniqueObjectName(currobj));
		//fprintf(MAPFILE, "}\n");
		//EntityCount++;
		}

	//createScriptCall(currobj, x, y, z);
	}

void RenderUnityEntityREPULSOR(int game, float x, float y, float z, ObjectItem &currobj, ObjectItem objList[1600], tile LevelInfo[64][64])
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

	RenderUnityModel(game, x, y, z, currobj, objList, LevelInfo);

	}

void RenderUnityEntityCorpse(int game, float x, float y, float z, ObjectItem &currobj, ObjectItem objList[1600], tile LevelInfo[64][64])
	{
	//Some corpses will have inventories. For these we have spawn points that behave just like containers.
	//Params.
	//Item_id
	//link	//To check for a lock and it's list of contents.
	RenderUnityModel(game, x, y, z, currobj, objList, LevelInfo);
	RenderUnityObjectInteraction(game, x, y, z, currobj, objList, LevelInfo);
	
	if (game == SHOCK)
		{
		//Corpses in shock will have inventory
		////fprintf(MAPFILE, "\n// entity %d\n{\n", EntityCount++);//"atdm:mover_button"
		////fprintf(MAPFILE, "\"classname\" \"%s\"\n", objectMasters[currobj.item_id].path);
		//////fprintf(MAPFILE, "\"model\" \"%s\"\n", objectMasters[currobj.item_id].path);
		////fprintf(MAPFILE, "\"name\" \"%s\"\n", UniqueObjectName(currobj));
		////fprintf(MAPFILE, "\"origin\" \"%f %f %f\"\n", x, y, z);
		////fprintf(MAPFILE, "\"hide\" \"%d\"\n", currobj.invis);
		////if (hasContents(currobj))
		////	{
		////	fprintf(MAPFILE, "\"grabable\" \"%d\"\n", 0);
		////	fprintf(MAPFILE, "\"frobable\" \"%d\"\n", 1);
		////	fprintf(MAPFILE, "\"frob_action_script\" \"start_%s\"\n", UniqueObjectName(currobj));
		////	}
		////fprintf(MAPFILE, "}");

		////if (hasContents(currobj))
		////	{
		////	//createScriptCall(currobj, x, y, z);

		////	//create 4 spawn points around the container to spawn the contents at.
		////	int offX = 10; int offY = 10;
		////	for (int i = 0; i < 4; i++)
		////		{
		////		switch (i)
		////			{
		////				case 0: offX = 10; offY = 10; break;
		////				case 1: offX = -10; offY = 10; break;
		////				case 2: offX = 10; offY = -10; break;
		////				case 3: offX = -10; offY = -10; break;
		////			}

		////		if (currobj.shockProperties[CONTAINER_CONTENTS_1 + i] > 0)
		////			{
		////			fprintf(MAPFILE, "\n// entity %d\n{\n", EntityCount++);
		////			fprintf(MAPFILE, "\"classname\" \"%s\"\n", "target_null");
		////			fprintf(MAPFILE, "\"name\" \"%s_spawnpoint_%d\"\n", UniqueObjectName(currobj), i);
		////			fprintf(MAPFILE, "\"origin\" \"%f %f %f\"\n", x + offX, y + offY, z);
		////			fprintf(MAPFILE, "}");
		////			}
		////		}
		////	}
		}
	}

void RenderUnityEntityWords(int game, float x, float y, float z, ObjectItem &currobj, ObjectItem objList[1600], tile LevelInfo[64][64])
	{
	RenderUnityModel(game, x, y, z, currobj, objList, LevelInfo);

	//fprintf(MAPFILE, "\"xdata_contents\" \"readables/shock/words_%d\"\n", currobj.shockProperties[0]);

	}

void RenderUnityEntityGrating(int game, float x, float y, float z, ObjectItem &currobj, ObjectItem objList[1600], tile LevelInfo[64][64])
	{//Transparent Gratings.
	RenderUnityModel(game, x, y, z, currobj, objList, LevelInfo);
	//fprintf(MAPFILE, "\"skin\" \"shock_grating_%03d\"\n", currobj.ObjectSubClassIndex - 4);
	}

void RenderUnityEntityBridgeUW(int game, float x, float y, float z, ObjectItem &currobj, ObjectItem objList[1600], tile LevelInfo[64][64])
	{//UW2 bridges
	RenderUnityModel(game, x, y, z, currobj, objList, LevelInfo);
	RenderUnityObjectInteraction(game, x, y, z, currobj, objList, LevelInfo);
	if (currobj.flags < 2)
		{
		//fprintf(MAPFILE, "\"skin\" \"uw%d_bridge_%02d\"\n", game, currobj.flags & 0x7);
		}
	else
		{
		printf("\nMake sure this skin exists!"); //uw2_bridge_texture_189
		//fprintf(MAPFILE, "\"skin\" \"uw%d_bridge_texture_%03d\"\n", game, currobj.texture);
		}
	}

void RenderUnityEntityParticle(int game, float x, float y, float z, ObjectItem &currobj, ObjectItem objList[1600], tile LevelInfo[64][64], int bind)
	{
	RenderUnityModel(game, x, y, z, currobj, objList, LevelInfo);
	}



void RenderUnityModel(int game, float x, float y, float z, ObjectItem &currobj, ObjectItem objList[1600], tile LevelInfo[64][64])
	{//A model with no properties.

	//Params 
	//item_id
	//tileX
	//tileY
	//Index

	fprintf(UNITY_FILE, "\n\tmyObj = new GameObject(\"%s\");", UniqueObjectName(currobj));//Create the object
	fprintf(UNITY_FILE, "\n\tpos = new Vector3(%ff, %ff, %ff);", x, z, y);//Create the object x,z,y
	fprintf(UNITY_FILE, "\n\tmyObj.transform.position = pos;");//Position the object
	fprintf(UNITY_FILE, "\n\tCreateObjectGraphics(myObj,\"Sprites/objects_%03d\",true);", currobj.item_id);
	if ((currobj.DeathWatched >= 1) && (game == SHOCK))
		{
		//If all object of this type are destroyed then do something.
		}


	if (objectMasters[currobj.item_id].type == HIDDENPLACEHOLDER)
		{
		//fprintf(MAPFILE, "\"solid\" \"%d\"\n", 1);	//temporarily till I figure out controlling solidity via script
		}

	//fprintf(MAPFILE, "\"hide\" \"%d\"\n", currobj.invis);


	if (game == SHOCK)
		{
		//EntityRotationSHOCK(currobj.Angle2);
		}
	else
		{
		//EntityRotation(currobj.heading);
		}

	//AttachToJoint(currobj);
	if (currobj.link != 0)
		{
		//Object start activates something
		}
	EntityCount++;
	//if ((currobj.DeathWatched >= 1) && (game == SHOCK))
	//	{
	//	createScriptCall(currobj, x, y, z);
	//	}
	return;
	}

void RenderUnityTrigger(int game, float x, float y, float z, ObjectItem &currobj, ObjectItem objList[1600], tile LevelInfo[64][64])
	{
	//TriggerTargetX = currobj.quality;
	//TriggerTargetY = currobj.owner;
	//target = objList[nextObj].link
	RenderUnityModel(game,-1.0,-1.0,-1.0,currobj,objList,LevelInfo);
	fprintf(UNITY_FILE, "\n\tCreateTrigger(myObj,%d,%d,\"%s\");", currobj.quality, currobj.owner, UniqueObjectName(objList[currobj.link]));//set the trigger here
	}

void RenderUnityTrap(int game, float x, float y, float z, ObjectItem &currobj, ObjectItem objList[1600], tile LevelInfo[64][64])
	{
	//TriggerTargetX = currobj.quality;
	//TriggerTargetY = currobj.owner;
	//target = objList[nextObj].link
	if (x < -1){ x = -1; }
	if (y < -1){ y = -1; }
	if (z < -1){ z = -1; }
	RenderUnityModel(game,x,y,z,currobj,objList,LevelInfo);
	switch (objectMasters[currobj.item_id].type)
		{
			case  A_DAMAGE_TRAP:
				fprintf(UNITY_FILE,"\n\tCreate_a_damage_trap(myObj);");
				break;
			case  A_TELEPORT_TRAP:
				fprintf(UNITY_FILE, "\n\tCreate_a_teleport_trap(myObj);");
				break;
			case  A_ARROW_TRAP:
				fprintf(UNITY_FILE, "\n\tCreate_a_arrow_trap(myObj);");
				break;
			case  A_DO_TRAP:
				{
				switch (currobj.quality)
					{
						case 0x02://Camera
							{fprintf(UNITY_FILE, "\n\tCreate_a_do_trap(myObj,%d,%d);",currobj.quality,currobj.flags); break;}
						case 0x03://Platform
							{fprintf(UNITY_FILE, "\n\tCreate_a_do_trap(myObj,%d,%d);", currobj.quality); break; }
						case 0x18:	//bullfrog
							{fprintf(UNITY_FILE, "\n\tCreate_trap_base(myObj,%d,%d);", currobj.quality, currobj.flags); break; }
						default:
							{fprintf(UNITY_FILE, "\n\tCreate_trap_base(myObj);"); break; }
					}
				break;
				}
			case  A_PIT_TRAP:
				fprintf(UNITY_FILE, "\n\tCreate_a_pit_trap(myObj);");
				break;
			case  A_CHANGE_TERRAIN_TRAP:
				fprintf(UNITY_FILE, "\n\tCreate_a_change_terrain_trap(myObj);");
				break;
			case  A_SPELLTRAP:
				fprintf(UNITY_FILE, "\n\tCreate_a_spelltrap(myObj);");
				break;
			case  A_CREATE_OBJECT_TRAP:
				fprintf(UNITY_FILE, "\n\tCreate_a_teleport_trap(myObj);");
				break;
			case  A_DOOR_TRAP:
				fprintf(UNITY_FILE, "\n\tCreate_a_door_trap(myObj,%d);",currobj.quality);
				break;
			case  A_WARD_TRAP:
				fprintf(UNITY_FILE, "\n\tCreate_a_ward_trap(myObj);");
				break;
			case  A_TELL_TRAP:
				fprintf(UNITY_FILE, "\n\tCreate_a_tell_trap(myObj);");
				break;
			case  A_DELETE_OBJECT_TRAP:
				fprintf(UNITY_FILE, "\n\tCreate_a_delete_object_trap(myObj);");
				break;
			case  AN_INVENTORY_TRAP:
				fprintf(UNITY_FILE, "\n\tCreate_an_inventory_trap(myObj);");
				break;
			case  A_SET_VARIABLE_TRAP:
				fprintf(UNITY_FILE, "\n\tCreate_a_set_variable_trap(myObj);");
				break;
			case  A_CHECK_VARIABLE_TRAP:
				fprintf(UNITY_FILE, "\n\tCreate_a_check_variable_trap(myObj);");
				break;
			case  A_COMBINATION_TRAP:
				fprintf(UNITY_FILE, "\n\tCreate_a_combination_trap(myObj);");
				break;
			case  A_TEXT_STRING_TRAP:
				fprintf(UNITY_FILE, "\n\tCreate_a_text_string_trap(myObj,%d,%d);", 9, 64 * (LevelNo)+currobj.owner);//block no and string no
				break;
		}
	}

void RenderUnityEntity(int game, float x, float y, float z, ObjectItem &currobj, ObjectItem objList[1600], tile LevelInfo[64][64])
	{
	//Picks what type of object to generate.
	printf("Rendering:%s\n", UniqueObjectName(currobj));
	switch (objectMasters[currobj.item_id].isEntity)
		{
			case -1:	//ignore
				{return; break; }
			case 0:	//Model
				{
				RenderUnityModel(game, x, y, z, currobj, objList, LevelInfo);
				break;
				}
			case 1:	//entity
				{
				switch (objectMasters[currobj.item_id].type)
					{
						case NPC:
							RenderUnityEntityNPC(game, x, y, z, currobj, objList, LevelInfo);
							break;
						case HIDDENDOOR:
						case DOOR:
						case PORTCULLIS:
							RenderUnityEntityDoor(game, x, y, z, currobj, objList, LevelInfo);
							break;
						case KEY:
							RenderUnityEntityKey(game, x, y, z, currobj, objList, LevelInfo);
							break;
						case CONTAINER:
							RenderUnityEntityContainer(game, x, y, z, currobj, objList, LevelInfo);
							break;
						case ACTIVATOR:
							RenderUnityEntityActivator(game, x, y, z, currobj, objList, LevelInfo);
							break;
						case BUTTON:
							RenderUnityEntityButton(game, x, y, z, currobj, objList, LevelInfo);
							break;
						case LOCK:
						case A_DOOR_TRAP:
							printf("no longer in use???");
							//RenderUnityEntityA_DOOR_TRAP(game, x, y, z, currobj, objList, LevelInfo);
							break;
						case A_DO_TRAP:
							RenderUnityEntityA_DO_TRAP(game, x, y, z, currobj, objList, LevelInfo);
							break;
						case A_CHANGE_TERRAIN_TRAP:
							RenderUnityEntityA_CHANGE_TERRAIN_TRAP(game, x, y, z, currobj, objList, LevelInfo);
							break;
						case TMAP_SOLID:
						case TMAP_CLIP:
							RenderUnityEntityTMAP(game, x, y, z, currobj, objList, LevelInfo);
							break;
						case BOOK:
						case SCROLL:
							RenderUnityEntityBOOK(game, x, y, z, 0, currobj, objList, LevelInfo);
							break;
						case SIGN:
							RenderUnityEntitySIGN(game, x, y, z, currobj, objList, LevelInfo);
							break;
						case A_MOVE_TRIGGER:
							RenderUnityEntityA_MOVE_TRIGGER(game, x, y, z, currobj, objList, LevelInfo);
							break;
						case A_TELEPORT_TRAP:	//a destination for a teleport.
							RenderUnityEntityA_TELEPORT_TRAP(game, x, y, z, currobj, objList, LevelInfo);
							break;
						case SHOCK_DECAL:
							RenderUnityEntityDecal(game, x, y, z, currobj, objList, LevelInfo);
							break;
						case COMPUTER_SCREEN:
							RenderUnityEntityComputerScreen(game, x, y, z, currobj, objList, LevelInfo);
							break;
						case SHOCK_TRIGGER_DEATHWATCH:
						case SHOCK_TRIGGER_NULL:
						case SHOCK_TRIGGER_LEVEL:
							RenderUnityEntityNULL_TRIGGER(game, x, y, z, currobj, objList, LevelInfo);
							break;
						case SHOCK_TRIGGER_REPULSOR:
							RenderUnityEntityREPULSOR(game, x, y, z, currobj, objList, LevelInfo);
							break;
						case CORPSE:
							RenderUnityEntityCorpse(game, x, y, z, currobj, objList, LevelInfo);
							break;
						case SHOCK_WORDS:
							RenderUnityEntityWords(game, x, y, z, currobj, objList, LevelInfo);
							break;
						case SHOCK_GRATING:
							RenderUnityEntityGrating(game, x, y, z, currobj, objList, LevelInfo);
							break;
						case SHOCK_DOOR:
						case SHOCK_DOOR_TRANSPARENT:
							RenderUnityEntitySHOCKDoor(game, x, y, z, currobj, objList, LevelInfo);
							break;
						case UW_PAINTING:
							RenderUnityEntityPaintingUW(game, x, y, z, currobj, objList, LevelInfo);
							break;
						case BRIDGE:
							RenderUnityEntityBridgeUW(game, x, y, z, currobj, objList, LevelInfo);
							break;
						case PARTICLE:
							RenderUnityEntityParticle(game, x, y, z, currobj, objList, LevelInfo, 0);
							RenderUnityObjectInteraction(game, x, y, z, currobj, objList, LevelInfo);
							break;
						default:
							RenderUnityModel(game, x, y, z, currobj, objList, LevelInfo);
							RenderUnityObjectInteraction(game,x,y,z,currobj,objList,LevelInfo);
							//EntityCount++;
							break;
					}
				}
		}
	if (objectMasters[currobj.item_id].hasParticle == 1)
		{
		//RenderEntityParticle(game, x, y, z, currobj, objList, LevelInfo, 1);
		}
	if (objectMasters[currobj.item_id].hasSound == 1)
		{
		//RenderEntitySound(game, x, y, z, currobj, objList, LevelInfo, 1);
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

void RenderUnityObjectList(int game, int Level, tile LevelInfo[64][64], ObjectItem objList[1600])
	{
	LevelNo = Level;
float BrushZ=BrushSizeZ;
int x; int y;
float offX; float offY; float offZ;

	switch (game)
		{
			case SHOCK:
				{
				CEILING_HEIGHT = SHOCK_CEILING_HEIGHT;
				break;
				}
			default://UW1&2
				{
				CEILING_HEIGHT = UW_CEILING_HEIGHT;
				break;
				}
		}

	
	if (fopen_s(&UNITY_FILE, "unity.txt", "w") != 0)
		{
		printf("Unable to create output file for this thing");
		return;
		}
	//Some quick declarations
	fprintf(UNITY_FILE, "\n\tGameObject myObj;\n\tVector3 pos;");
	fprintf(UNITY_FILE, "\n\tGameObject invMarker = GameObject.Find(\"InventoryMarker\");");
	fprintf(UNITY_FILE, "\n\tContainer ParentContainer;");
	/*Parses the object list and sets up their x,y,z position.
	Object lists in-game are linked lists. The index into the list is stored on the tilemap*/

	for (y = 0; y <= 63; y++)
		{
		for (x = 0; x <= 63; x++)
			{
			if ((LevelInfo[x][y].indexObjectList != 0))
				{
				long nextObj = LevelInfo[x][y].indexObjectList;
				while (nextObj != 0)
					{
					objList[nextObj].tileX = x;//Set the tile X and Y of the object. This is usefull to know.
					objList[nextObj].tileY = y;
					CalcObjectXYZ(game, &offX, &offY, &offZ, LevelInfo, objList, nextObj, x, y);//Figures out where the object should be.
					offX=offX/100.0;offY=offY/100.0;offZ=(offZ/100.0)+((BrushZ*1.5)/100);
					if ((!isTrigger(objList[nextObj])) && (!isTrap(objList[nextObj])))
						{//Everything but traps and triggers
						if (objList[nextObj].AlreadyRendered != 1)
							{
							RenderUnityEntity(game, offX, offY, offZ, objList[nextObj],objList,LevelInfo);
							//fprintf(UNITY_FILE, "\n\tmyObj = new GameObject(\"%s\");",UniqueObjectName(objList[nextObj]));//Create the object
							//fprintf(UNITY_FILE, "\n\tpos = new Vector3(%ff, %ff, %ff);",offX,offZ,offY);//Create the object x,z,y
							//fprintf(UNITY_FILE, "\n\tmyObj.transform.position = pos;");//Position the object
							//fprintf(UNITY_FILE, "\n\tCreateObjectGraphics(myObj,\"Assets/Sprites/objects_%03d.tga\");", objList[nextObj].item_id);
							}
						objList[nextObj].AlreadyRendered = 1;//Prevent possible duplication of objects due to system shock supporting objects that take occupy multiple tiles
						}
					nextObj = objList[nextObj].next;//In linked list.
					}
				}
			}
		}
	if (game!=SHOCK)
		{//Render my uw triggers and traps
		for (int i = 0; i < 1024; i++)
			{
			if (objList[i].AlreadyRendered!=1)
					{
					if (isTrigger(objList[i]))
						{
						RenderUnityTrigger(game, offX, offY, offZ, objList[i], objList, LevelInfo);
						}

					if (isTrap(objList[i]))
						{
						RenderUnityTrap(game, offX, offY, offZ, objList[i], objList, LevelInfo);
						}
					}
				}
			}
		
	fclose(UNITY_FILE);
	}
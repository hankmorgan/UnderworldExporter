#include "tilemap.h"
#include "gameobjects.h"
#include "gameobjectsrender.h"
#include <fstream>
#include "main.h"
#include "Unity.h"
#include "textures.h"

void RenderUnityModel(int game, float x, float y, float z, ObjectItem &currobj, ObjectItem objList[1600], tile LevelInfo[64][64]);
void RenderUnitySprite(int game, float x, float y, float z, ObjectItem &currobj, ObjectItem objList[1600], tile LevelInfo[64][64], int billboard);
void RenderUnityEntity(int game, float x, float y, float z, ObjectItem &currobj, ObjectItem objList[1600], tile LevelInfo[64][64]);
void AddShockTriggerActions(int game, float x, float y, float z, ObjectItem &currobj, ObjectItem objList[1600], tile LevelInfo[64][64]);

extern long SHOCK_CEILING_HEIGHT;
extern long UW_CEILING_HEIGHT;
FILE *UNITY_FILE = NULL;

int LevelNo;

void RenderUnityObjectInteraction(int game, float x, float y, float z, ObjectItem &currobj, ObjectItem objList[1600], tile LevelInfo[64][64])
	{
	fprintf(UNITY_FILE, "\n\tCreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, \"%s\", \"%s\", \"%s\", %d, %d, %d, %d, %d, %d, %d, %d, %d);",
		    objectMasters[currobj.item_id].particle,
			objectMasters[currobj.item_id].InvIcon,
			objectMasters[currobj.item_id].EquippedIconFemaleLowest,
			objectMasters[currobj.item_id].type, currobj.item_id,
			currobj.link, currobj.quality, currobj.owner,
			objectMasters[currobj.item_id].isMoveable,
			objectMasters[currobj.item_id].isAnimated,
			objectMasters[currobj.item_id].useSprite,
			currobj.is_quant
			);
	}

void RenderUnityObjectInteraction(int game, float x, float y, float z, ObjectItem &currobj, ObjectItem objList[1600], tile LevelInfo[64][64],char *ChildName)
	{
	fprintf(UNITY_FILE, "\n\tCreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f,\"%s\",\"%s\", \"%s\", %d, %d, %d, %d, %d, %d, %d, \"%s\");",
		objectMasters[currobj.item_id].particle,
		objectMasters[currobj.item_id].InvIcon,
		objectMasters[currobj.item_id].EquippedIconFemaleLowest,
		objectMasters[currobj.item_id].type, currobj.item_id, 
		currobj.link, currobj.quality, currobj.owner,
		objectMasters[currobj.item_id].isMoveable,
		objectMasters[currobj.item_id].isAnimated, 
		objectMasters[currobj.item_id].useSprite,
		currobj.is_quant,
		ChildName);
	}

void RenderUnityEntityAnimationOverlay(int game, float x, float y, float z, ObjectItem &currobj, ObjectItem objList[1600], tile LevelInfo[64][64])
	{//Is animated is treated as the start frame
	//useSprite is treated as the length of the animation
	fprintf(UNITY_FILE, "\n\tAddAnimationOverlay(myObj,%d,%d);", objectMasters[currobj.item_id].isAnimated, objectMasters[currobj.item_id].useSprite);
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

	//Center the object in the tile
	x = (currobj.tileX*BrushSizeX + (BrushSizeX/2) )/100.0;
	y = (currobj.tileY*BrushSizeY + (BrushSizeY / 2) )/100.0;
	if (game == SHOCK)
		{//Center vertically in the tile
		z= (CEILING_HEIGHT/2)*BrushSizeZ/100.0;
		}

	RenderUnityModel(game, x, y, z, currobj, objList, LevelInfo);
	RenderUnitySprite(game, x, y, z, currobj, objList, LevelInfo, 0);
	if (game != SHOCK)
		{
		fprintf(UNITY_FILE, "\n\tCreateTrigger(myObj,%d,%d,\"%s\");", currobj.quality, currobj.owner, UniqueObjectName(objList[currobj.link]));//set the trigger here
		fprintf(UNITY_FILE, "\n\tCreateCollider(myObj,1.20f,1.20f,1.20f);");
		}
	else
		{
		AddShockTriggerActions(game, x, y, z, currobj, objList, LevelInfo);
		fprintf(UNITY_FILE, "\n\tCreateEntry_Trigger(myObj, %d,%d,%d,%d,%d,%d);"
			, currobj.TriggerAction, currobj.TriggerOnce, currobj.conditions[0], currobj.conditions[1], currobj.conditions[2], currobj.conditions[3]);
		fprintf(UNITY_FILE, "\n\tCreateCollider(myObj,1.15f,%ff,1.15f);" , CEILING_HEIGHT * BrushSizeZ/100.0);
		}
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

void RenderUnityEntityRuneStone(int game, float x, float y, float z, ObjectItem &currobj, ObjectItem objList[1600], tile LevelInfo[64][64])
	{//Runestone
	RenderUnityModel(game, x, y, z, currobj, objList, LevelInfo);
	RenderUnitySprite(game, x, y, z, currobj, objList, LevelInfo, 1);
	RenderUnityObjectInteraction(game,x,y,z,currobj,objList,LevelInfo);
	fprintf(UNITY_FILE, "\n\tSetObjectAsRuneStone(myObj);");
	//SetInventoryIcon
	//fprintf(UNITY_FILE, "\n\tSetInventoryIcon(myObj,\"%s\",\"Sprites/%s\");\n", objectMasters[currobj.item_id].InvIcon, objectMasters[currobj.item_id].InvIcon);
	}

void RenderUnityEntityRuneBag(int game, float x, float y, float z, ObjectItem &currobj, ObjectItem objList[1600], tile LevelInfo[64][64])
	{//Runestone
	RenderUnityModel(game, x, y, z, currobj, objList, LevelInfo);
	RenderUnitySprite(game, x, y, z, currobj, objList, LevelInfo, 1);
	RenderUnityObjectInteraction(game, x, y, z, currobj, objList, LevelInfo);
	fprintf(UNITY_FILE, "\n\tSetObjectAsRuneBag(myObj);\n");
	}

void RenderUnityEntityPaintingUW(int game, float x, float y, float z, ObjectItem &currobj, ObjectItem objList[1600], tile LevelInfo[64][64])
	{//UW2 wall paintings.
	RenderUnityModel(game, x, y, z, currobj, objList, LevelInfo);
	RenderUnitySprite(game, x, y, z, currobj, objList, LevelInfo, 1);
	RenderUnityObjectInteraction(game, x, y, z, currobj, objList, LevelInfo);
	
	}

void CreateUnityScriptCall(int game, float x, float y, float z, ObjectItem &currobj, ObjectItem objList[1600], tile LevelInfo[64][64], char *ScriptName)
	{//for objects that start scripts.
	//TriggerTargetX = currobj.quality;
	//TriggerTargetY = currobj.owner;
	//target = objList[nextObj].link
	if (game != SHOCK)
		{
		if (currobj.link != 0)
			{//Need to update max state on this
			fprintf(UNITY_FILE, "\n\tCreateUWActivators(myObj,\"ButtonHandler\",\"%s\",%d,%d,%d,%d,%d);", UniqueObjectName(objList[currobj.link]), currobj.quality, currobj.owner, currobj.flags, 7, currobj.item_id);
			}
		}
	else
		{
//CreateSHOCKActivators(GameObject myObj, int TriggerAction)
		fprintf(UNITY_FILE, "\n\tCreateSHOCKActivators(myObj,%d);", currobj.TriggerAction);
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
	int count=0;
	fprintf(UNITY_FILE, "\n\tmyObj = new GameObject(\"%s\");", UniqueObjectName(currobj));//Create the object
	fprintf(UNITY_FILE, "\n\tpos = new Vector3(%ff, %ff, %ff);", x, z, y);//Create the object x,z,y
	fprintf(UNITY_FILE, "\n\tmyObj.transform.position = pos;");//Position the object
	fprintf(UNITY_FILE, "\n\tCreateNPC(myObj,\"%d\",\"%s\", %d);", currobj.item_id, objectMasters[currobj.item_id].particle, currobj.npc_whoami);
	RenderUnityObjectInteraction(game, x, y, z, currobj, objList, LevelInfo);
	/*Set NPC Properties*/
	if ((game == UW1) || (game == UWDEMO))
		{
		fprintf(UNITY_FILE, "\n\tSetNPCProps(myObj, %d, %d, %d, %d, %d, %d, %d, %d, %d, %d, %d, %d, %d, %d," ,
			currobj.npc_whoami, currobj.npc_xhome, currobj.npc_yhome,
			currobj.npc_hunger, currobj.npc_health,
			currobj.npc_hp, currobj.npc_arms, currobj.npc_power,
			currobj.npc_goal, currobj.npc_attitude, currobj.npc_gtarg,
			currobj.npc_talkedto, currobj.npc_level, currobj.npc_name
			);
		switch (currobj.item_id)//Split into my known fliers,swimmers and walkers.. TODO: Make this better!
			{
			case 66://bat
			case 73://vampire bat
				fprintf(UNITY_FILE, "\"SkyMesh1\");");//Fliers can go anywhere. Need to create this mesh.
				break;
			case 87://lurker
			case 116://deep lurker
				fprintf(UNITY_FILE, "\"WaterMesh%d\");", LevelInfo[currobj.tileX][currobj.tileY].waterRegion);
				break;
			default:
				fprintf(UNITY_FILE, "\"GroundMesh%d\");", LevelInfo[currobj.tileX][currobj.tileY].landRegion);
				break;
			}
		}
	/*
	(GameObject myObj,
	int WhoAmI, int npc_xhome, int npc_yhome,
	int npc_hunger, int npc_health,
	int npc_hp, int npc_arms, int npc_power ,
	int npc_goal, int npc_attitude, int npc_gtarg,
	int npc_talkedto, int npc_level,int npc_name)

*/


	fprintf(UNITY_FILE, "\n\t////Container contents");
	fprintf(UNITY_FILE, "\n\tParentContainer = CreateContainer(myObj, %d, %d, %d);"
		, 255
		, 255
		, 255
		);
	//fprintf(UNITY_FILE, "\n\tmyObj.GetComponent<ObjectInteraction>().isContainer = true;");

	if (game != SHOCK)
		{
		UnityRotation(game, 0, currobj.heading, 0);
		}
	else
		{
		UnityRotation(game, currobj.Angle1, currobj.Angle2, currobj.Angle3);
		}


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
			tmpobj = objList[tmpobj.next];
			//I pass the owner info down the line
			//tmpobj.objectOwner = currobj.objectOwner;
			//tmpobj.objectOwnerName = currobj.objectOwnerName;
			//tmpobj.objectOwnerEntity = currobj.objectOwnerEntity;
			//tmpobj.joint = JointCount++;
			
			RenderUnityEntity(game, x, y, z, tmpobj, objList, LevelInfo);	//Need to fix up the x y z to a better spot.
			fprintf(UNITY_FILE, "\n\tmyObj.transform.position = invMarker.transform.position;");//Move the inventory contents to a inventory room
			//fprintf(UNITY_FILE, "\n\tmyObj.transform.parent = invMarker.transform;");//Attach to the persistent marker.
			fprintf(UNITY_FILE, "\n\tAddObjectToContainer(myObj, ParentContainer, %d);", count++);//Move the inventory contents to a container script
			if (objectMasters[currobj.item_id].isMoveable == 1)
				{
				fprintf(UNITY_FILE, "\n\tFreezeMovement(myObj);\n");
				}
			}
		RenderUnityEntity(game, x, y, z, tmpobj, objList, LevelInfo); //NPC's inventory.
		fprintf(UNITY_FILE, "\n\tmyObj.transform.position = invMarker.transform.position;");//Move the inventory contents to a inventory room
		//fprintf(UNITY_FILE, "\n\tmyObj.transform.parent = invMarker.transform;");//Attach to the persistent marker.
		fprintf(UNITY_FILE, "\n\tAddObjectToContainer(myObj, ParentContainer, %d);", count++);//Move the inventory contents to a container script
		if (objectMasters[currobj.item_id].isMoveable == 1)
			{
			fprintf(UNITY_FILE, "\n\tFreezeMovement(myObj);\n");
			}

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
int hasLock=0;

	//float BrushX = BrushSizeX;
	//float BrushY = BrushSizeY;
	//float zpos = z;

	//zpos = LevelInfo[currobj.tileX][currobj.tileY].floorHeight*BrushSizeZ;//Force the door to stay on the ground.
	//z = zpos;

	//for a door I need to point it's used_by property at the key object's name. This is accessed through a lock object

	//RenderUnityModel(game, x, y, z, currobj, objList, LevelInfo);
	fprintf(UNITY_FILE, "\n\tmyObj = new GameObject(\"door_%03d_%03d\");",currobj.tileX, currobj.tileY);//Create the object
	switch (currobj.heading)
		{//Move the object position so it can pivot properly.
		case WEST:
			y = (currobj.tileY*BrushSizeY + DOORWIDTH + ((BrushSizeY - DOORWIDTH) / 2)) / 100.0;
			break;
		case EAST:
			y = (currobj.tileY*BrushSizeY + ((BrushSizeY - DOORWIDTH) / 2)) / 100.0;
			break;
		case NORTH:
			x = (currobj.tileX*BrushSizeX + DOORWIDTH + ((BrushSizeX - DOORWIDTH) / 2)) / 100.0;
			break;
		case SOUTH:
			x = (currobj.tileX*BrushSizeX + ((BrushSizeX - DOORWIDTH) / 2)) / 100.0;
			break;
		}
	fprintf(UNITY_FILE, "\n\tpos = new Vector3(%ff, %ff, %ff);", x, z, y);//Create the object x,z,y
	fprintf(UNITY_FILE, "\n\tmyObj.transform.position = pos;");//Position the object
	fprintf(UNITY_FILE, "\n\tCreateObjectGraphics(myObj,\"Sprites/objects_%03d\",true);", currobj.item_id);
	RenderUnityObjectInteraction(game, x, y, z, currobj, objList, LevelInfo);
	if (game != SHOCK)
		{//bit 0-6 of the lock objects link is the keyid for opening it in uw
		// The flags control the lock state
		if (currobj.link != 0)
			{
			hasLock=1;
			}
		}
	
//	RenderUnityObjectInteraction(game, x, y, z, currobj-, objList, LevelInfo);

	if ((currobj.link != 0) || (currobj.SHOCKLocked >0))	//door has a lock. bit 0-6 of the lock objects link is the keyid for opening it in uw
		{
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
	if (game != SHOCK)
		{
		switch (objectMasters[currobj.item_id].type)
			{
				case DOOR:
					fprintf(UNITY_FILE, "\n\tCreateDoor(myObj,\"textures/doors/doors_%02d\", %d, %d);",
						objectMasters[currobj.item_id].extraInfo, objList[currobj.link].link & 0x3F,
						hasLock);
					break;
				case HIDDENDOOR:
					fprintf(UNITY_FILE, "\n\tCreateDoor(myObj,\"textures/world/%s\", %d, %d);",
						textureMasters[LevelInfo[currobj.tileX][currobj.tileY].wallTexture].path, 
						objList[currobj.link].link & 0x3F,
						hasLock);
					break;
				case PORTCULLIS:
					fprintf(UNITY_FILE, "\n\tCreatePortcullis(myObj, %d, %d);",
						objList[currobj.link].link & 0x3F,
						hasLock);
					//fprintf(UNITY_FILE, "\n\tSetPortcullis(myObj,true);");
					break;
			}
		UnityRotation(game, -90, currobj.heading - 180, 0);
		}
	else
		{
		UnityRotation(game, currobj.Angle1, currobj.Angle2, currobj.Angle3);
		}
	//if (objectMasters[currobj.item_id].type == PORTCULLIS)
	//	{
	//	//The door is a portcullis and must translate up.
	//	//fprintf(MAPFILE, "\"rotate\" \"0 0 0\"\n");
	//	//fprintf(MAPFILE, "\"translate\" \"0 0 80\"\n");
	//	
	//	}

	if ((currobj.link != 0) || (currobj.SHOCKLocked >0))
		{	
		//if it has a lock it needs a lock object for scripting purposes

		}
	return;
	}

void RenderUnityEntitySHOCKDoor(int game, float x, float y, float z, ObjectItem &currobj, ObjectItem objList[1600], tile LevelInfo[64][64])
	{

	
//Centre the door within the tile depending on it's angles.
	if (currobj.Angle1 == 0)//In rare cases doors are on the floor.
		{
		z = LevelInfo[currobj.tileX][currobj.tileY].floorHeight*BrushSizeZ / 100.0;
		switch (currobj.Angle2)
			{
			case SHOCK_NORTH:
			case SHOCK_SOUTH:
				x=(currobj.tileX*BrushSizeX  + BrushSizeX/2) /100.0;
				break;
			case SHOCK_EAST:
			case SHOCK_WEST:
				y = (currobj.tileY*BrushSizeY + BrushSizeY / 2) / 100.0;
				break;
			}
		}
	else
		{//A flat door on the ground. Center in the tile.
		x = (currobj.tileX*BrushSizeX + BrushSizeX / 2) / 100.0;
		y = (currobj.tileY*BrushSizeY + BrushSizeY ) / 100.0;
		}
	RenderUnityModel(game, x, y, z, currobj, objList, LevelInfo);
	RenderUnitySprite(game, x, y, z, currobj, objList, LevelInfo, 0);
	SetScale(1.9f, 1.9f, 1.9f);//1.875f
	UnityRotation(game,currobj.Angle1,currobj.Angle2,currobj.Angle3);
	//RenderUnityObjectInteraction(game, x, y, z, currobj, objList, LevelInfo);

	////Lock stuff
	//if ((currobj.link != 0) || (currobj.SHOCKLocked > 0))	//door has a lock. bit 0-6 of the lock objects link is the keyid for opening it in uw
	//	{
	//	//the door is locked
	//	if ((currobj.link > 0) && (currobj.link <= 11))	//Only this many keycards
	//		{
	//		//What keys open this door.
	//		}
	//	}
	if ((currobj.link != 0) || (currobj.SHOCKLocked > 0))
		{//Door is locked
		if ((currobj.link > 0) && (currobj.link <= 11))//Valid range of keycards
			{
			fprintf(UNITY_FILE, "\n\tCreateShockDoor(myObj,%d,%d,%s);", currobj.link, 1, objectMasters[currobj.item_id].path);
			}
		else
			{
			fprintf(UNITY_FILE, "\n\tCreateShockDoor(myObj,%d,%d,%s);", -1, 1, objectMasters[currobj.item_id].path);
			}
		}
	else
		{//Door is unlocked
		fprintf(UNITY_FILE, "\n\tCreateShockDoor(myObj,%d,%d,%s);", currobj.link, 0, objectMasters[currobj.item_id].path);
		}
	

	//if ((currobj.link != 0) || (currobj.SHOCKLocked >0) && (game != SHOCK))
	//	{	
	//	//if it has a lock it needs a lock object for scripting purposes
	//	}

	}

void RenderUnityEntityKey(int game, float x, float y, float z, ObjectItem &currobj, ObjectItem objList[1600], tile LevelInfo[64][64])
	{
	//Creates a key. Each key is uniquely named based on a counter. Doors will have a list of potential matching key names to work with keys.
	//Params
	//Item_id
	//Owner

	//A key's owner id matches it's lock link id.
	RenderUnityModel(game, x, y, z, currobj, objList, LevelInfo);
	RenderUnitySprite(game, x, y, z, currobj, objList, LevelInfo, 1);
	RenderUnityObjectInteraction(game, x, y, z, currobj, objList, LevelInfo);
	fprintf(UNITY_FILE, "\n\tCreateKey(myObj, %d);",currobj.owner);
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
		RenderUnityModel(game, x, y, z, currobj, objList, LevelInfo);
		RenderUnitySprite(game, x, y, z, currobj, objList, LevelInfo, 1);
		RenderUnityObjectInteraction(game, x, y, z, currobj, objList, LevelInfo);
		fprintf(UNITY_FILE, "\n\t////Container contents");
		fprintf(UNITY_FILE, "\n\tParentContainer = CreateContainer(myObj, %d, %d, %d);"
			, objectMasters[currobj.item_id].uwProperties[UW_PROP_CONT_CAPACITY]
			, objectMasters[currobj.item_id].uwProperties[UW_PROP_CONT_SLOTS]
			, objectMasters[currobj.item_id].uwProperties[UW_PROP_CONT_OBJECTS]
			);
		//fprintf(UNITY_FILE, "\n\tmyObj.GetComponent<ObjectInteraction>().isContainer = true;");


		if (objectMasters[objList[currobj.link].item_id].type == LOCK)	//container has a lock.
			{//bit 1 of the flags is the lock?
			//Container is locked
			}
		//now recursively get it's contents.
		if (currobj.link != 0)	//Container has objects
			{
			ObjectItem tmpobj = objList[currobj.link];
			int count = 0;
			while (tmpobj.next != 0)
				{
				if (objectMasters[objList[currobj.link].item_id].type != LOCK)
					{
					RenderUnityEntity(game, x, y, z, tmpobj, objList, LevelInfo);
					fprintf(UNITY_FILE, "\n\tmyObj.transform.position = invMarker.transform.position;");//Move the inventory contents to a inventory room
					//fprintf(UNITY_FILE, "\n\tmyObj.transform.parent = invMarker.transform;");//Attach to the persistent marker.
					fprintf(UNITY_FILE, "\n\tAddObjectToContainer(myObj, ParentContainer, %d);", count++);//Move the inventory contents to a container script
					if (objectMasters[currobj.item_id].isMoveable == 1)
						{
						fprintf(UNITY_FILE, "\n\tFreezeMovement(myObj);\n");
						}
					}
				tmpobj = objList[tmpobj.next];
				}
			RenderUnityEntity(game, x, y, z, tmpobj, objList, LevelInfo);
			fprintf(UNITY_FILE, "\n\tmyObj.transform.position = invMarker.transform.position;");//Move the inventory contents to a inventory room
			//fprintf(UNITY_FILE, "\n\tmyObj.transform.parent = invMarker.transform;");//Attach to the persistent marker.
			fprintf(UNITY_FILE, "\n\tAddObjectToContainer(myObj, ParentContainer, %d);", count++);//Move the inventory contents to a container script
			if (objectMasters[currobj.item_id].isMoveable == 1)
				{
				fprintf(UNITY_FILE, "\n\tFreezeMovement(myObj);\n");
				}
			}
		fprintf(UNITY_FILE, "\n\t////Container contents complete\n");
		return;
		}
	else
		{
		//Shock container. contents are different from uw1
		RenderUnityModel(game, x, y, z, currobj, objList, LevelInfo);
		RenderUnitySprite(game, x, y, z, currobj, objList, LevelInfo, 1);
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
	RenderUnitySprite(game, x, y, z, currobj, objList, LevelInfo, 1);
	CreateUnityScriptCall(game,x,y,z,currobj,objList,LevelInfo,"ButtonHandler");
	RenderUnityObjectInteraction(game,x,y,z,currobj,objList,LevelInfo);
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
	RenderUnitySprite(game, x, y, z, currobj, objList, LevelInfo, 0);
	if (game != SHOCK)
		{
		CreateUnityScriptCall(game, x, y, z, currobj, objList, LevelInfo, "ButtonHandler");
		RenderUnityObjectInteraction(game, x, y, z, currobj, objList, LevelInfo);
		UnityRotation(game, 0, currobj.heading, 0);
		}
	else
		{
		CreateUnityScriptCall(game, x, y, z, currobj, objList, LevelInfo, "ShockButtonHandler");
		AddShockTriggerActions(game, x, y, z, currobj, objList, LevelInfo);
		RenderUnityObjectInteraction(game, x, y, z, currobj, objList, LevelInfo);
		UnityRotation(game, currobj.Angle1, currobj.Angle2, currobj.Angle3);

		}


	//Set the on/off artwork.
	switch (game)
		{
		case UWDEMO:
		case UW1:
			if ((currobj.item_id >= 368) && (currobj.item_id <= 375))
				{//Button is a turned off one.
				SetButtonProperties(game, 0, currobj.item_id - 368, currobj.item_id - 368 + 8);
				}
			else if((currobj.item_id >= 376) && (currobj.item_id <= 383))
				{//Button is a turned on one.
				SetButtonProperties(game, 1, currobj.item_id - 368, currobj.item_id - 368 - 8);
				}
			else if ((currobj.item_id == 353))//Rotary Switch
				{
				SetButtonProperties(game, 4);
				}
			else if ((currobj.item_id == 354))//Rotary Switch
				{
				SetButtonProperties(game, 12);
				}
			break;
		case UW2:
			break;
		case SHOCK:
			break;
		}
	return;
	}

void SetButtonProperties(int game, short on, int SpriteNoOn, int SpriteNoOff)
	{
	switch (game)
		{
			case UWDEMO:
			case UW1:
				fprintf(UNITY_FILE, "\n\tSetButtonProperties(myObj, %d, \"Sprites/tmflat/tmflat_00%02d\", \"Sprites/tmflat/tmflat_00%02d\");", on, SpriteNoOn,SpriteNoOff);
				break;
			case UW2:
				break;
			case SHOCK:
				break;
		}
	}

void SetButtonProperties(int game, int SpriteNoBegin)
	{//For rotary buttons.
	fprintf(UNITY_FILE, "\n\tSetButtonProperties(myObj,");
	switch (game)
		{
			case UWDEMO:
			case UW1:
				for (int i = 0; i < 8; i++)
					{
					fprintf(UNITY_FILE, "\"Sprites/tmobj/tmobj_%02d\"",i+SpriteNoBegin);
					if (i != 7)
						{
						fprintf(UNITY_FILE, ",");
						}
					}
				fprintf(UNITY_FILE, ");");
				break;
			case UW2:
				break;
			case SHOCK:
				break;
		}
	}

void RenderUnityEntityA_DO_TRAP(int game, float x, float y, float z, ObjectItem &currobj, ObjectItem objList[1600], tile LevelInfo[64][64])
	{
	return;
	//This is a trigger in UW that can do a bunch of different things. Eg cameras/rising platforms.
	switch (currobj.quality)
		{
			case 2: //A camera	
				RenderUnityModel(game, x, y, z, currobj, objList, LevelInfo);
				RenderUnitySprite(game, x, y, z, currobj, objList, LevelInfo, 1);
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
				RenderUnitySprite(game, x, y, z, currobj, objList, LevelInfo, 1);
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
				RenderUnitySprite(game, x, y, z, currobj, objList, LevelInfo, 1);
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
	RenderUnitySprite(game, x, y, z, currobj, objList, LevelInfo, 1);

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
	if (currobj.y == 0)
		{
		x = (currobj.tileX*BrushSizeX + (BrushSizeX / 2))/100.0;
		//y=y+0.01;
		}
	if (currobj.y == 7)
		{
		x = (currobj.tileX*BrushSizeX + (BrushSizeX / 2)) / 100.0;
		//y = y - 0.01;
		}
	if (currobj.x == 0)
		{
		y = (currobj.tileY*BrushSizeY + (BrushSizeY / 2)) / 100.0;
		//x = x + 0.01;
		}
	if (currobj.x == 7)
		{
		y = (currobj.tileY*BrushSizeX + (BrushSizeY / 2)) / 100.0;
		//x = x - 0.01;
		}
	//x=(currobj.tileX*BrushSizeX+(BrushSizeX/2));
	//y = (currobj.tileX*BrushSizeX + (BrushSizeX / 2));
//	z = (LevelInfo[currobj.tileX][currobj.tileY].floorHeight*BrushSizeZ)/100.0;
	RenderUnityModel(game, x, y, z, currobj, objList, LevelInfo);
	RenderUnityObjectInteraction(game, x, y, z, currobj, objList, LevelInfo);
	//SetScale(0.9375f,0.9375f,0.9375f);
	//RenderUnitySprite(game, x, y, z, currobj, objList, LevelInfo, 0);
	if (isTrigger(objList[currobj.link]) != 0)
		{
		fprintf(UNITY_FILE, "\n\tCreateTMAP(myObj,\"textures/tmap/%s\", \"%s\", %d, false);", textureMasters[currobj.texture].path, UniqueObjectName(objList[currobj.link]), currobj.texture);
		}
	else
		{
		fprintf(UNITY_FILE, "\n\tCreateTMAP(myObj,\"textures/tmap/%s\", \"\" , %d, false);", textureMasters[currobj.texture].path, currobj.texture);
		}

	//textureMasters[currobj.texture].path
	if (game != SHOCK)
		{
		UnityRotation(game, 0, currobj.heading, 0);
		}
	else
		{
		UnityRotation(game, currobj.Angle1, currobj.Angle2, currobj.Angle3);
		}
	if (isTrigger(objList[currobj.link]) != 0)
		{
		//object is a trigger
		//CreateUnityScriptCall(game, x, y, z, currobj, objList, LevelInfo, "ButtonHandler");
		}
	//else
	//	{

	//	}
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
	RenderUnityModel(game, x, y, z, currobj, objList, LevelInfo);
	RenderUnitySprite(game, x, y, z, currobj, objList, LevelInfo, 1);
	RenderUnityObjectInteraction(game, x, y, z, currobj, objList, LevelInfo);
	setReadable();

	switch (game)
		{
			case SHOCK:
				ReadableIndex = currobj.shockProperties[SOFT_PROPERTY_LOG];	//currobj.Property1;	//The chunk that the text comes from.
				fprintf(UNITY_FILE, "\n\tCreateEmail(myObj,%d);", ReadableIndex);
				break;
			default:
				//ReadableIndex = currobj.link - 0x200;
				setLink(currobj);
				break;
		}

		

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
	RenderUnitySprite(game, x, y, z, currobj, objList, LevelInfo, 0);
	RenderUnityObjectInteraction(game, x, y, z, currobj, objList, LevelInfo);//,"Activator");
	setReadable();

	if (game != SHOCK)
		{
		UnityRotation(game, 0, currobj.heading, 0);
		}
	else
		{
		UnityRotation(game, currobj.Angle1, currobj.Angle2, currobj.Angle3);
		}
	fprintf(UNITY_FILE, "\n\tSetSprite(myObj, \"Sprites/tmobj/tmobj_%02d\");", 20 + (currobj.flags & 0x07));
	setLink(currobj);
	
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

	//RenderUnityModel(game, x, y, z, currobj, objList, LevelInfo);
	//RenderUnitySprite(game, x, y, z, currobj, objList, LevelInfo, 1);
	RenderUnityObjectInteraction(game, x, y, z, currobj, objList, LevelInfo);
	
	//only show if it points to this level.

	if (currobj.zpos == 0)
		{
		fprintf(UNITY_FILE, "\n\tCreate_a_teleport_trap(myObj,(float)%f,(float)%f,(float)%f,false);"
			, (currobj.quality * BrushSizeX + (BrushSizeX / 2))/100.0, (currobj.owner * BrushSizeY + (BrushSizeY / 2))/100.0, (LevelInfo[currobj.quality][currobj.owner].floorHeight * BrushSizeZ)/100.0);
		
		////fprintf(MAPFILE, "\n// entity %d\n{\n", EntityCount);
		////fprintf(MAPFILE, "\"classname\" \"%s\"\n", objectMasters[currobj.item_id].path);
		////fprintf(MAPFILE, "\"name\" \"%s\"\n", UniqueObjectName(currobj));
		////fprintf(MAPFILE, "\"origin\" \"%d %d %d\"\n", currobj.quality * BrushSizeX + (BrushSizeX / 2), currobj.owner * BrushSizeY + (BrushSizeY / 2), LevelInfo[currobj.quality][currobj.owner].floorHeight * BrushSizeZ);
		////fprintf(MAPFILE, "\n}");
		}
	else
		{
		fprintf(UNITY_FILE, "\n\tCreate_a_teleport_trap(myObj,(float)%f,(float)%f,(float)%f,true);"
			, (currobj.quality * BrushSizeX + (BrushSizeX / 2)) / 100.0, (currobj.owner * BrushSizeY + (BrushSizeY / 2)) / 100.0, (LevelInfo[currobj.quality][currobj.owner].floorHeight * BrushSizeZ) / 100.0);
		}
	return;
	}

void RenderUnityEntityDecal(int game, float x, float y, float z, ObjectItem &currobj, ObjectItem objList[1600], tile LevelInfo[64][64])
	{//decals like wall icons etc.
	
RenderUnityModel(game, x, y, z, currobj, objList, LevelInfo);

//RenderUnitySprite(game, x, y, z, currobj, objList, LevelInfo, 0);
//RenderUnityObjectInteraction(game, x, y, z, currobj, objList, LevelInfo);
//fprintf(UNITY_FILE, "\n\tCreateObjectGraphics(myObj,\"%s\",false);", objectMasters[currobj.item_id].WorldSprite);
	switch (currobj.ObjectSubClassIndex)
		{
			case 0:	//sign . 
				//fprintf(MAPFILE, "\"model\" \"%s\"\n", objectMasters[currobj.item_id].path);
				//fprintf(MAPFILE, "\"skin\" \"shock_sign_%04d\"\n", 390 + currobj.unk1);
				fprintf(UNITY_FILE, "\n\tCreateObjectGraphics(myObj, \"Sprites/Sign/objects_1350_%04d\",false);", 390 + currobj.unk1);
				break;
			case 1:	//icon
				//fprintf(MAPFILE, "\"model\" \"%s\"\n", objectMasters[currobj.item_id].path);
				//fprintf(MAPFILE, "\"skin\" \"shock_icon_%04d\"\n", currobj.unk1);
				fprintf(UNITY_FILE, "\n\tCreateObjectGraphics(myObj, \"Sprites/Icons/objects_0078_%04d\",false);", currobj.unk1);
				break;
			case 2:	//graffiti
				//if (currobj.unk1 != 7)
				//	{
					//fprintf(MAPFILE, "\"model\" \"%s\"\n", objectMasters[currobj.item_id].path);
					fprintf(UNITY_FILE, "\n\tCreateObjectGraphics(myObj, \"Sprites/Graffiti/objects_0079_%04d\",false);", currobj.unk1);
				//	}
				//else
				//	{
					//fprintf(MAPFILE, "\"model\" \"%s\"\n", objectMasters[131].path);	//special case for shodan hearts diego 
				//	}
				//fprintf(MAPFILE, "\"skin\" \"shock_graffiti_%04d\"\n", currobj.unk1);
				break;
			case 4:	//painting
				fprintf(UNITY_FILE, "\n\tCreateObjectGraphics(myObj, \"Sprites/Painting/objects_1350_%04d\",false);", 403 + currobj.unk1);
				//if (currobj.unk1 != 2)
				//	{
					//fprintf(MAPFILE, "\"model\" \"%s\"\n", objectMasters[currobj.item_id].path);
				//	}
				//else
				//	{
					//fprintf(MAPFILE, "\"model\" \"%s\"\n", objectMasters[126].path);//special case for the scream.
				//	}
				//fprintf(MAPFILE, "\"skin\" \"shock_painting_%04d\"\n", 403 + currobj.unk1);

				break;
			case 5:	//poster (not in use?)
				fprintf(UNITY_FILE, "\n\tCreateObjectGraphics(myObj, \"Sprites/Graffiti/objects_1350_%04d\",false);", currobj.unk1);
				//fprintf(MAPFILE, "\"model\" \"%s\"\n", objectMasters[currobj.item_id].path);
				//fprintf(MAPFILE, "\"skin\" \"shock_poster_%04d\"\n", currobj.unk1);
				break;
		}
	UnityRotation(game, currobj.Angle1, currobj.Angle2, currobj.Angle3);
	}

void RenderUnityEntityComputerScreen(int game, float x, float y, float z, ObjectItem &currobj, ObjectItem objList[1600], tile LevelInfo[64][64])
	{
	RenderUnityModel(game, x, y, z, currobj, objList, LevelInfo);
	
	//RenderUnityObjectInteraction(game, x, y, z, currobj, objList, LevelInfo);
	if (currobj.shockProperties[SCREEN_START] < 246)
		{
		//RenderUnitySprite(game, x, y, z, currobj, objList, LevelInfo, 0);
		fprintf(UNITY_FILE, "\n\tCreateComputerScreen(myObj,%d,%d,%d);"
			, currobj.shockProperties[SCREEN_START], currobj.shockProperties[SCREEN_NO_OF_FRAMES], currobj.shockProperties[SCREEN_LOOP_FLAG]);
		}
	else
		{
		if ((currobj.shockProperties[SCREEN_START] >= 248) && (currobj.shockProperties[SCREEN_START] <= 255))
			{
			//Surveillance Screen
			fprintf(UNITY_FILE, "\n\tCreateSurveillanceScreen(myObj,\"%s\");", UniqueObjectName(objList[currobj.shockProperties[SCREEN_SURVEILLANCE_TARGET]]));
			}
		else
			{//unimplemented special screens.
			RenderUnitySprite(game, x, y, z, currobj, objList, LevelInfo, 0);
			fprintf(UNITY_FILE, "\n\tCreateComputerScreen(myObj,%d,%d,%d);", 0, 100, 1);
			}
		
		}

	UnityRotation(game,currobj.Angle1,currobj.Angle2 ,currobj.Angle3);
	if (currobj.shockProperties[SCREEN_START] < 246)
		{//destructable
		//createScriptCall(currobj, x, y, z, "destroy");
		}


	}

void AddShockTriggerActions(int game, float x, float y, float z, ObjectItem &currobj, ObjectItem objList[1600], tile LevelInfo[64][64])
	{
	switch (currobj.TriggerAction)
		{
			case ACTION_DO_NOTHING:
				if ((currobj.shockProperties[BUTTON_PROPERTY_TRIGGER] < 1600) && (currobj.shockProperties[BUTTON_PROPERTY_TRIGGER] >= 0))
					{
					fprintf(UNITY_FILE, "\n\tAddACTION_DO_NOTHING(myObj, \"%s\");", UniqueObjectName(objList[currobj.shockProperties[BUTTON_PROPERTY_TRIGGER]]));
					}
				else
					{
					fprintf(UNITY_FILE, "\n\tAddACTION_DO_NOTHING(myObj);");
					}
				 break;
			case ACTION_TRANSPORT_LEVEL:
				fprintf(UNITY_FILE, "\n\tAddACTION_TRANSPORT_LEVEL(myObj);"); break;
			case ACTION_RESURRECTION:
				fprintf(UNITY_FILE, "\n\tAddACTION_RESURRECTION(myObj);"); break;
			case ACTION_CLONE:
				fprintf(UNITY_FILE, "\n\tAddACTION_CLONE(myObj);"); break;
			case ACTION_SET_VARIABLE:
				fprintf(UNITY_FILE, "\n\tAddACTION_SET_VARIABLE(myObj);"); break;
			case ACTION_ACTIVATE:
				fprintf(UNITY_FILE, "\n\tAddACTION_ACTIVATE(myObj, ");
				//000C	int16	1st object to activate.
				//000E	int16	Delay before activating object 1.
				//0010	...	Up to 4 objects and delays stored here.		
				//printf("\tACTION_ACTIVATE\n");
				for (int i = 0; i <= 3; i++)
					{
					if ((currobj.shockProperties[i * 2]>0) && (currobj.shockProperties[i * 2]<1600))
						{//The object to activate and the delay in activating
						fprintf(UNITY_FILE, "\"%s\", %d", UniqueObjectName(objList[currobj.shockProperties[i * 2]]), currobj.shockProperties[1 + i * 2]);
						}
					else
						{
						fprintf(UNITY_FILE, "\"\",0");
						}
					if (i < 3)
						{
						fprintf(UNITY_FILE, ",");
						}
					else
						{
						fprintf(UNITY_FILE, ");");
						}
					}

				break;
			case ACTION_LIGHTING:
				fprintf(UNITY_FILE, "\n\tAddACTION_LIGHTING(myObj);"); break;
			case ACTION_EFFECT:
				fprintf(UNITY_FILE, "\n\tAddACTION_EFFECT(myObj);"); break;
			case ACTION_MOVING_PLATFORM:
				//int triggerX = currobj.shockProperties[TRIG_PROPERTY_TARGET_X];
				//int triggerY = currobj.shockProperties[TRIG_PROPERTY_TARGET_Y];
				//int targetFloor = currobj.shockProperties[TRIG_PROPERTY_FLOOR];
				//int targetCeiling = currobj.shockProperties[TRIG_PROPERTY_CEILING];
				//int flag = LevelInfo[triggerX][triggerY].hasElevator;
				fprintf(UNITY_FILE, "\n\tAddACTION_MOVING_PLATFORM(myObj, %d, %d, %d, %d, %d);"
					, currobj.shockProperties[TRIG_PROPERTY_TARGET_X], currobj.shockProperties[TRIG_PROPERTY_TARGET_Y]
					, currobj.shockProperties[TRIG_PROPERTY_FLOOR], CEILING_HEIGHT- currobj.shockProperties[TRIG_PROPERTY_CEILING]
					, LevelInfo[currobj.shockProperties[TRIG_PROPERTY_TARGET_X]][currobj.shockProperties[TRIG_PROPERTY_TARGET_Y]].hasElevator); break;
			case ACTION_TIMER:
				fprintf(UNITY_FILE, "\n\tAddACTION_TIMER(myObj);"); break;
			case ACTION_CHOICE:
				fprintf(UNITY_FILE, "\n\tAddACTION_CHOICE(myObj,\"%s\""
					, UniqueObjectName(objList[currobj.shockProperties[TRIG_PROPERTY_TRIG_1]]));
				fprintf(UNITY_FILE, ", \"%s\");"
				, UniqueObjectName(objList[currobj.shockProperties[TRIG_PROPERTY_TRIG_2]])); 
					break;
			case ACTION_EMAIL:
				fprintf(UNITY_FILE, "\n\tAddACTION_EMAIL(myObj);"); break;
			case ACTION_RADAWAY:
				fprintf(UNITY_FILE, "\n\tAddACTION_RADAWAY(myObj);"); break;
			case ACTION_CHANGE_STATE:
				fprintf(UNITY_FILE, "\n\tAddACTION_CHANGE_STATE(myObj, \"%s\", %d);"
					, UniqueObjectName(objList[currobj.shockProperties[TRIG_PROPERTY_OBJECT]])
					, currobj.shockProperties[TRIG_PROPERTY_TYPE]);
				break;
			case ACTION_AWAKEN:
				fprintf(UNITY_FILE, "\n\tAddACTION_AWAKEN(myObj);"); break;
			case ACTION_MESSAGE:
				fprintf(UNITY_FILE, "\n\tAddACTION_MESSAGE(myObj, %d, %d);",
					currobj.shockProperties[TRIG_PROPERTY_MESSAGE1], currobj.shockProperties[TRIG_PROPERTY_MESSAGE2]);
				break;
			case ACTION_SPAWN:
				fprintf(UNITY_FILE, "\n\tAddACTION_SPAWN(myObj);"); break;
			case ACTION_CHANGE_TYPE:
				fprintf(UNITY_FILE, "\n\tAddACTION_CHANGE_TYPE(myObj, \"%s\", %d, %d, %d);"
					, UniqueObjectName(objList[currobj.shockProperties[TRIG_PROPERTY_OBJECT]])
					, objList[currobj.shockProperties[TRIG_PROPERTY_OBJECT]].ObjectClass
					, objList[currobj.shockProperties[TRIG_PROPERTY_OBJECT]].ObjectSubClass 
					, currobj.shockProperties[TRIG_PROPERTY_TYPE]);
				break;
			default:
				fprintf(UNITY_FILE, "\n\tAddACTION_UNKNOWN(myObj);"); break;
				break;
		}
	}

void RenderUnityEntityNULL_TRIGGER(int game, float x, float y, float z, ObjectItem &currobj, ObjectItem objList[1600], tile LevelInfo[64][64])
	{//And a level entry as well.
	RenderUnityModel(game, x, y, z, currobj, objList, LevelInfo);
	RenderUnitySprite(game, x, y, z, currobj, objList, LevelInfo, 0);
	//RenderUnityObjectInteraction(game, x, y, z, currobj, objList, LevelInfo);
	fprintf(UNITY_FILE, "\n\tCreateNull_Trigger(myObj, %d,%d,%d,%d,%d,%d);"
		, currobj.TriggerAction, currobj.TriggerOnce, currobj.conditions[0], currobj.conditions[1], currobj.conditions[2], currobj.conditions[3]);
	AddShockTriggerActions(game,x,y,z,currobj,objList,LevelInfo);
	UnityRotation(game,currobj.Angle1,currobj.Angle2,currobj.Angle3);//Needed for surveillance cameras.
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
	RenderUnitySprite(game, x, y, z, currobj, objList, LevelInfo, 0);
	float displacement = currobj.shockProperties[TRIG_PROPERTY_VALUE];
	if (displacement == 0)
		{
		displacement = CEILING_HEIGHT - LevelInfo[currobj.tileX][currobj.tileY].ceilingHeight - LevelInfo[currobj.tileX][currobj.tileY].floorHeight;
		displacement = displacement/10 - (0.6);
		}
	else
		{
		displacement = displacement / (BrushSizeZ * 10);
		}

	if (currobj.shockProperties[TRIG_PROPERTY_FLAG] == 1)
		{//repulsor is off
		fprintf(UNITY_FILE, "\n\tCreateRepulsor(myObj,(float)%f,false", displacement);
		}
	else
		{//repulsor is on.
		fprintf(UNITY_FILE, "\n\tCreateRepulsor(myObj,(float)%f,true", displacement);
		}
	fprintf(UNITY_FILE, ",(float)0.0f,(float)%ff,(float)0.0f,(float)1.0f,(float)%ff,(float)1.0f);",displacement/2, displacement );

 	}

void RenderUnityEntityCorpse(int game, float x, float y, float z, ObjectItem &currobj, ObjectItem objList[1600], tile LevelInfo[64][64])
	{
	//Some corpses will have inventories. For these we have spawn points that behave just like containers.
	//Params.
	//Item_id
	//link	//To check for a lock and it's list of contents.
	RenderUnityModel(game, x, y, z, currobj, objList, LevelInfo);
	RenderUnitySprite(game, x, y, z, currobj, objList, LevelInfo, 1);
	//RenderUnityObjectInteraction(game, x, y, z, currobj, objList, LevelInfo);
	
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
	//RenderUnitySprite(game, x, y, z, currobj, objList, LevelInfo, 1);
	fprintf(UNITY_FILE, "\n\tCreateWords(myObj, %d, %d, %d, %d);", 
		currobj.shockProperties[WORDS_STRING_NO],
		currobj.shockProperties[WORDS_FONT],
		currobj.shockProperties[WORDS_SIZE],
		currobj.shockProperties[WORDS_COLOUR]);
	UnityRotation(game, currobj.Angle1, currobj.Angle2, currobj.Angle3);
	//fprintf(MAPFILE, "\"xdata_contents\" \"readables/shock/words_%d\"\n", currobj.shockProperties[0]);


	}

void RenderUnityEntityGrating(int game, float x, float y, float z, ObjectItem &currobj, ObjectItem objList[1600], tile LevelInfo[64][64])
	{//Transparent Gratings.
	RenderUnityModel(game, x, y, z, currobj, objList, LevelInfo);
	//RenderUnitySprite(game, x, y, z, currobj, objList, LevelInfo, 1);
	fprintf(UNITY_FILE, "\n\tCreateObjectGraphics(myObj, \"Sprites/Grating/objects_%04d_0000\",false);", 2414 + currobj.ObjectSubClassIndex - 4);
	fprintf(UNITY_FILE, "\n\tCreateColliderChild(myObj,0.60f,0.60f,0.05f,false);");
	UnityRotation(game, currobj.Angle1, currobj.Angle2, currobj.Angle3);
	SetScale(2.0f, 2.0f, 2.0f);
	//fprintf(MAPFILE, "\"skin\" \"shock_grating_%03d\"\n", currobj.ObjectSubClassIndex - 4);
	}

void RenderUnityEntityBridgeUW(int game, float x, float y, float z, ObjectItem &currobj, ObjectItem objList[1600], tile LevelInfo[64][64])
	{//UW2 bridges
	RenderUnityModel(game, x, y, z, currobj, objList, LevelInfo);
	//RenderUnitySprite(game, x, y, z, currobj, objList, LevelInfo, 0);
	//RenderUnityObjectInteraction(game, x, y, z, currobj, objList, LevelInfo);
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

void RenderUnityEntityForceDoor(int game, float x, float y, float z, ObjectItem &currobj, ObjectItem objList[1600], tile LevelInfo[64][64])
	{
	RenderUnityModel(game, x, y, z, currobj, objList, LevelInfo);
	switch (currobj.ObjectSubClassIndex)
		{
		case 2://force door
			fprintf(UNITY_FILE, "\n\tCreateForceDoor(myObj);");
			UnityRotation(game, currobj.Angle1, currobj.Angle2, currobj.Angle3);
			break;
		case 6://great lord snaq!
			fprintf(UNITY_FILE, "\n\tCreateGreatLord(myObj);");
			UnityRotation(game, currobj.Angle1, currobj.Angle2, currobj.Angle3);
			break;
		}
	}

void RenderUnityEntityBridgeSHOCK(int game, float x, float y, float z, ObjectItem &currobj, ObjectItem objList[1600], tile LevelInfo[64][64])
	{
	int TopBottomOffset = 0;
	int SideOffset = 0;
	RenderUnityModel(game, x, y, z, currobj, objList, LevelInfo);

	switch (currobj.ObjectSubClassIndex)
		{
		case 0://Catwalk
		case 1://Bridge
			if (currobj.shockProperties[BRIDGE_TOP_BOTTOM_TEXTURE_SOURCE] == 0)
				{
				TopBottomOffset = 325;
				}
			if (currobj.shockProperties[BRIDGE_SIDE_TEXTURE_SOURCE] == 0)
				{
				SideOffset = 325;
				}
			fprintf(UNITY_FILE, "\n\tCreateShockBridge(myObj, \"textures/%s\", \"textures/%s\", %d, %d, %d);",
				textureMasters[currobj.shockProperties[BRIDGE_TOP_BOTTOM_TEXTURE] + TopBottomOffset].path,
				textureMasters[currobj.shockProperties[BRIDGE_SIDE_TEXTURE] + SideOffset].path,
				currobj.shockProperties[BRIDGE_HEIGHT],
				currobj.shockProperties[BRIDGE_X_SIZE],
				currobj.shockProperties[BRIDGE_Y_SIZE]);
			UnityRotation(game, currobj.Angle1 + 64, currobj.Angle2, currobj.Angle3);
			if (currobj.ObjectSubClassIndex == 1)//catwalks are smaller
				{
				SetScale(0.6f, 1.0f, 1.0f);
				}
			break;
			
			case 7://force bridge
				fprintf(UNITY_FILE, "\n\tCreateForceBridge(myObj);");
				UnityRotation(game, currobj.Angle1, currobj.Angle2, currobj.Angle3);
				break;
			case 8://elephant jorp
				fprintf(UNITY_FILE, "\n\tCreateElephantJorp(myObj);");
				UnityRotation(game, currobj.Angle1, currobj.Angle2, currobj.Angle3);
				break;
		}

	


	}

void RenderUnityEntityHelm(int game, float x, float y, float z, ObjectItem &currobj, ObjectItem objList[1600], tile LevelInfo[64][64])
	{
	fprintf(UNITY_FILE, "\n\tCreateHelm(myObj, \"%s\", \"%s\", \"%s\", \"%s\", \"%s\", \"%s\", \"%s\", \"%s\", %d, %d);",
		objectMasters[currobj.item_id].EquippedIconFemaleLowest, objectMasters[currobj.item_id].EquippedIconMaleLowest,
		objectMasters[currobj.item_id].EquippedIconFemaleLow, objectMasters[currobj.item_id].EquippedIconMaleLow,
		objectMasters[currobj.item_id].EquippedIconFemaleMedium, objectMasters[currobj.item_id].EquippedIconMaleMedium,
		objectMasters[currobj.item_id].EquippedIconFemaleBest, objectMasters[currobj.item_id].EquippedIconMaleBest);
	}

void RenderUnityEntityArmour(int game, float x, float y, float z, ObjectItem &currobj, ObjectItem objList[1600], tile LevelInfo[64][64])
	{
	fprintf(UNITY_FILE, "\n\tCreateArmour(myObj, \"%s\", \"%s\", \"%s\", \"%s\", \"%s\", \"%s\", \"%s\", \"%s\", %d, %d);",
		objectMasters[currobj.item_id].EquippedIconFemaleLowest, objectMasters[currobj.item_id].EquippedIconMaleLowest,
		objectMasters[currobj.item_id].EquippedIconFemaleLow, objectMasters[currobj.item_id].EquippedIconMaleLow,
		objectMasters[currobj.item_id].EquippedIconFemaleMedium, objectMasters[currobj.item_id].EquippedIconMaleMedium,
		objectMasters[currobj.item_id].EquippedIconFemaleBest, objectMasters[currobj.item_id].EquippedIconMaleBest,
		objectMasters[currobj.item_id].uwProperties[UW_PROP_ARM_PROTECTION],
		objectMasters[currobj.item_id].uwProperties[UW_PROP_DURABILITY]);
	}

void RenderUnityEntityBoots(int game, float x, float y, float z, ObjectItem &currobj, ObjectItem objList[1600], tile LevelInfo[64][64])
	{
	fprintf(UNITY_FILE, "\n\tCreateBoots(myObj, \"%s\", \"%s\", \"%s\", \"%s\", \"%s\", \"%s\", \"%s\", \"%s\", %d, %d);",
		objectMasters[currobj.item_id].EquippedIconFemaleLowest, objectMasters[currobj.item_id].EquippedIconMaleLowest,
		objectMasters[currobj.item_id].EquippedIconFemaleLow, objectMasters[currobj.item_id].EquippedIconMaleLow,
		objectMasters[currobj.item_id].EquippedIconFemaleMedium, objectMasters[currobj.item_id].EquippedIconMaleMedium,
		objectMasters[currobj.item_id].EquippedIconFemaleBest, objectMasters[currobj.item_id].EquippedIconMaleBest,
		objectMasters[currobj.item_id].uwProperties[UW_PROP_ARM_PROTECTION],
		objectMasters[currobj.item_id].uwProperties[UW_PROP_DURABILITY]);
	}

void RenderUnityEntityGloves(int game, float x, float y, float z, ObjectItem &currobj, ObjectItem objList[1600], tile LevelInfo[64][64])
	{
	fprintf(UNITY_FILE, "\n\tCreateGloves(myObj, \"%s\", \"%s\", \"%s\", \"%s\", \"%s\", \"%s\", \"%s\", \"%s\", %d, %d);",
		objectMasters[currobj.item_id].EquippedIconFemaleLowest, objectMasters[currobj.item_id].EquippedIconMaleLowest,
		objectMasters[currobj.item_id].EquippedIconFemaleLow, objectMasters[currobj.item_id].EquippedIconMaleLow,
		objectMasters[currobj.item_id].EquippedIconFemaleMedium, objectMasters[currobj.item_id].EquippedIconMaleMedium,
		objectMasters[currobj.item_id].EquippedIconFemaleBest, objectMasters[currobj.item_id].EquippedIconMaleBest,
		objectMasters[currobj.item_id].uwProperties[UW_PROP_ARM_PROTECTION],
		objectMasters[currobj.item_id].uwProperties[UW_PROP_DURABILITY]);
	}

void RenderUnityEntityLeggings(int game, float x, float y, float z, ObjectItem &currobj, ObjectItem objList[1600], tile LevelInfo[64][64])
	{
	fprintf(UNITY_FILE, "\n\tCreateLeggings(myObj, \"%s\", \"%s\", \"%s\", \"%s\", \"%s\", \"%s\", \"%s\", \"%s\", %d, %d);",
		objectMasters[currobj.item_id].EquippedIconFemaleLowest, objectMasters[currobj.item_id].EquippedIconMaleLowest,
		objectMasters[currobj.item_id].EquippedIconFemaleLow, objectMasters[currobj.item_id].EquippedIconMaleLow,
		objectMasters[currobj.item_id].EquippedIconFemaleMedium, objectMasters[currobj.item_id].EquippedIconMaleMedium,
		objectMasters[currobj.item_id].EquippedIconFemaleBest, objectMasters[currobj.item_id].EquippedIconMaleBest,
		objectMasters[currobj.item_id].uwProperties[UW_PROP_ARM_PROTECTION],
		objectMasters[currobj.item_id].uwProperties[UW_PROP_DURABILITY]);
	}


void RenderUnityEntityLight(int game, float x, float y, float z, ObjectItem &currobj, ObjectItem objList[1600], tile LevelInfo[64][64])
	{
	int itemid_off; int itemid_on; int brightness; int duration;
	if ((game != UW1) && (game !=UWDEMO))
		{
		return;
		}
	if ((currobj.item_id >= 144) && (currobj.item_id <= 147))
		{
		itemid_off=currobj.item_id;
		itemid_on=currobj.item_id+4;
		}
	else
		{
		itemid_off = currobj.item_id-4;
		itemid_on = currobj.item_id;
		}
	brightness = objectMasters[itemid_on].uwProperties[UW_PROP_LIGHT_BRIGHTNESS];
	duration = objectMasters[itemid_on].uwProperties[UW_PROP_LIGHT_DURATION];

	fprintf(UNITY_FILE, "\n\tCreateLight(myObj, %d, %d, %d, %d);",
		brightness, 
		duration, 
		itemid_on, itemid_off);
	}

void RenderUnityEntityWeapon(int game, float x, float y, float z, ObjectItem &currobj, ObjectItem objList[1600], tile LevelInfo[64][64])
	{
	fprintf(UNITY_FILE, "\n\tCreateWeapon(myObj, %d, %d, %d, %d, %d);",
		objectMasters[currobj.item_id].uwProperties[UW_PROP_WEAP_SLASH]
		, objectMasters[currobj.item_id].uwProperties[UW_PROP_WEAP_BASH]
		, objectMasters[currobj.item_id].uwProperties[UW_PROP_WEAP_STAB]
		, objectMasters[currobj.item_id].uwProperties[UW_PROP_WEAP_SKILL]
		, objectMasters[currobj.item_id].uwProperties[UW_PROP_DURABILITY]
		);
	}

void RenderUnityEntityParticle(int game, float x, float y, float z, ObjectItem &currobj, ObjectItem objList[1600], tile LevelInfo[64][64], int bind)
	{
	RenderUnityModel(game, x, y, z, currobj, objList, LevelInfo);
	RenderUnitySprite(game, x, y, z, currobj, objList, LevelInfo, 1);
	}

void RenderUnitySprite(int game, float x, float y, float z, ObjectItem &currobj, ObjectItem objList[1600], tile LevelInfo[64][64], int billboard)
	{
	if (billboard == 1)
		{
		fprintf(UNITY_FILE, "\n\tCreateObjectGraphics(myObj,\"%s\",true);", objectMasters[currobj.item_id].particle);
//fprintf(UNITY_FILE, "\n\tCreateObjectGraphics(myObj,\"Sprites/objects_%03d\",true);", currobj.item_id);
		}
	else
		{
		fprintf(UNITY_FILE, "\n\tCreateObjectGraphics(myObj,\"%s\",false);", objectMasters[currobj.item_id].particle);
		}
	}

void RenderUnityModel(int game, float x, float y, float z, ObjectItem &currobj, ObjectItem objList[1600], tile LevelInfo[64][64])
	{//A model with no properties.

	//Params 
	//item_id
	//tileX
	//tileY
	//Index

	//fprintf(UNITY_FILE, "\n\tmyObj = new GameObject(\"%s\");", UniqueObjectName(currobj));//Create the object
	//fprintf(UNITY_FILE, "\n\tpos = new Vector3(%ff, %ff, %ff);", x, z, y);//Create the object x,z,y
	//fprintf(UNITY_FILE, "\n\tmyObj.transform.position = pos;");//Position the object
	
	fprintf(UNITY_FILE, "\n\tmyObj= CreateGameObject(\"%s\",%ff,%ff,%ff);", UniqueObjectName(currobj), x, z, y);
	
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
	RenderUnityModel(game, x, y, z, currobj, objList, LevelInfo);
	RenderUnitySprite(game, x, y, z, currobj, objList, LevelInfo, 0);
	fprintf(UNITY_FILE, "\n\tCreateTrigger(myObj,%d,%d,\"%s\");", currobj.quality, currobj.owner, UniqueObjectName(objList[currobj.link]));//set the trigger here
	RenderUnityObjectInteraction(game, x, y, z, currobj, objList, LevelInfo);
	}

void RenderUnityTrap(int game, float x, float y, float z, ObjectItem &currobj, ObjectItem objList[1600], tile LevelInfo[64][64])
	{
	//TriggerTargetX = currobj.quality;
	//TriggerTargetY = currobj.owner;
	//target = objList[nextObj].link
	if (x < -1){ x = -1; }
	if (y < -1){ y = -1; }
	if (z < -1){ z = -1; }
	RenderUnityModel(game, x, y, z, currobj, objList, LevelInfo);
	RenderUnitySprite(game, x, y, z, currobj, objList, LevelInfo, 0);
	RenderUnityObjectInteraction(game,x,y,z,currobj,objList,LevelInfo);
	switch (objectMasters[currobj.item_id].type)
		{
			case  A_DAMAGE_TRAP:
				//if (isTrigger(objList[currobj.link]) || (isButton(objList[currobj.link])) || (isTrap(objList[currobj.link])) || (isLock(objList[currobj.link])))
				//	{
				//	fprintf(UNITY_FILE, "\n\tCreate_a_damage_trap(myObj,\"%s\");", UniqueObjectName(objList[currobj.link]));
				//	}
				//else
				//	{
					fprintf(UNITY_FILE, "\n\tCreate_a_damage_trap(myObj);");
				//	}

				break;
			case  A_TELEPORT_TRAP:
				//fprintf(UNITY_FILE, "\n\tCreate_a_teleport_trap(myObj);");
				RenderUnityEntityA_TELEPORT_TRAP(game, x, y, z, currobj, objList, LevelInfo);
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
				//if (isTrigger(objList[currobj.link]) || (isButton(objList[currobj.link])) || (isTrap(objList[currobj.link])) || (isLock(objList[currobj.link])))
				//	{
				//	fprintf(UNITY_FILE, "\n\tCreate_a_change_terrain_trap(myObj,%d,%d,%d,%d,\"%s\");", currobj.tileX, currobj.tileY, currobj.x, currobj.y, UniqueObjectName(objList[currobj.link]));
				//	}
				//else
				//	{
					fprintf(UNITY_FILE, "\n\tCreate_a_change_terrain_trap(myObj,%d,%d,%d,%d);", currobj.tileX, currobj.tileY, currobj.x, currobj.y);
				//	}
				break;
			case  A_SPELLTRAP:
				fprintf(UNITY_FILE, "\n\tCreate_a_spelltrap(myObj);");
				break;
			case  A_CREATE_OBJECT_TRAP:
				fprintf(UNITY_FILE, "\n\tCreate_a_create_object_trap(myObj);");
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
				//if (isTrigger(objList[currobj.link]) || (isButton(objList[currobj.link])) || (isTrap(objList[currobj.link])) || (isLock(objList[currobj.link])))
				//	{
				//	fprintf(UNITY_FILE, "\n\tCreate_a_text_string_trap(myObj,%d,%d,\"%s\");", 9, 64 * (LevelNo)+currobj.owner, UniqueObjectName(objList[currobj.link]));//block no and string no
				//	}
				//else
				//	{
					fprintf(UNITY_FILE, "\n\tCreate_a_text_string_trap(myObj,%d,%d);", 9, 64 * (LevelNo)+currobj.owner);//block no and string no
				//	}
				break;
		}
	
	if (isTrigger(objList[currobj.link]) || (isButton(objList[currobj.link])) || (isTrap(objList[currobj.link])) || (isLock(objList[currobj.link])))
		{
		switch (objectMasters[objList[currobj.link].item_id].type)
			{
				case A_DELETE_OBJECT_TRAP:	//Need to stop on this due to infinite loops if the trigger object is being deleted.
				case LOCK://A lock uses it's link to set the key needed. stop here.
					break;
				default:
					fprintf(UNITY_FILE, "\n\tAddTrapLink(myObj,\"%s\");", UniqueObjectName(objList[currobj.link]));
			}
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
				RenderUnitySprite(game, x, y, z, currobj, objList, LevelInfo, 1);
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
						case SHOCK_BRIDGE:
							RenderUnityEntityBridgeSHOCK(game, x, y, z, currobj, objList, LevelInfo);
							break;
						case PARTICLE:
							RenderUnityEntityParticle(game, x, y, z, currobj, objList, LevelInfo, 0);
							RenderUnityObjectInteraction(game, x, y, z, currobj, objList, LevelInfo);
							break;
						case RUNE:
							{
							RenderUnityEntityRuneStone(game, x, y, z, currobj, objList, LevelInfo);
							break;
							}
						case RUNEBAG:
							{
							RenderUnityEntityRuneBag(game, x, y, z, currobj, objList, LevelInfo);
							break;
							}
						case SCENERY:
							RenderUnityModel(game, x, y, z, currobj, objList, LevelInfo);
							RenderUnitySprite(game, x, y, z, currobj, objList, LevelInfo, 1);
							break;
						case FORCE_DOOR:
							RenderUnityEntityForceDoor(game, x, y, z, currobj, objList, LevelInfo);
							break;
						case FOOD:
							RenderUnityModel(game, x, y, z, currobj, objList, LevelInfo);
							RenderUnitySprite(game, x, y, z, currobj, objList, LevelInfo, 1);
							RenderUnityObjectInteraction(game, x, y, z, currobj, objList, LevelInfo);
							fprintf(UNITY_FILE, "\n\tSetFood(myObj);");
							break;
						case MAP:
							RenderUnityModel(game, x, y, z, currobj, objList, LevelInfo);
							RenderUnitySprite(game, x, y, z, currobj, objList, LevelInfo, 1);
							RenderUnityObjectInteraction(game, x, y, z, currobj, objList, LevelInfo);
							fprintf(UNITY_FILE, "\n\tSetMap(myObj);");
							break;
						case HELM:
							RenderUnityModel(game, x, y, z, currobj, objList, LevelInfo);
							RenderUnitySprite(game, x, y, z, currobj, objList, LevelInfo, 1);
							RenderUnityObjectInteraction(game, x, y, z, currobj, objList, LevelInfo);
							RenderUnityEntityHelm(game,x,y,z,currobj,objList,LevelInfo);
							break;
						case ARMOUR:
							RenderUnityModel(game, x, y, z, currobj, objList, LevelInfo);
							RenderUnitySprite(game, x, y, z, currobj, objList, LevelInfo, 1);
							RenderUnityObjectInteraction(game, x, y, z, currobj, objList, LevelInfo);
							RenderUnityEntityArmour(game, x, y, z, currobj, objList, LevelInfo);
							break;
						case GLOVES:
							RenderUnityModel(game, x, y, z, currobj, objList, LevelInfo);
							RenderUnitySprite(game, x, y, z, currobj, objList, LevelInfo, 1);
							RenderUnityObjectInteraction(game, x, y, z, currobj, objList, LevelInfo);
							RenderUnityEntityGloves(game, x, y, z, currobj, objList, LevelInfo);
							break;
						case BOOT:
							RenderUnityModel(game, x, y, z, currobj, objList, LevelInfo);
							RenderUnitySprite(game, x, y, z, currobj, objList, LevelInfo, 1);
							RenderUnityObjectInteraction(game, x, y, z, currobj, objList, LevelInfo);
							RenderUnityEntityBoots(game, x, y, z, currobj, objList, LevelInfo);
							break;
						case LEGGINGS:
							RenderUnityModel(game, x, y, z, currobj, objList, LevelInfo);
							RenderUnitySprite(game, x, y, z, currobj, objList, LevelInfo, 1);
							RenderUnityObjectInteraction(game, x, y, z, currobj, objList, LevelInfo);
							RenderUnityEntityLeggings(game, x, y, z, currobj, objList, LevelInfo);
							break;
						case TORCH:
							RenderUnityModel(game, x, y, z, currobj, objList, LevelInfo);
							RenderUnitySprite(game, x, y, z, currobj, objList, LevelInfo, 1);
							RenderUnityObjectInteraction(game, x, y, z, currobj, objList, LevelInfo);
							RenderUnityEntityLight(game, x, y, z, currobj, objList, LevelInfo);
							break;
						case WEAPON:
							RenderUnityModel(game, x, y, z, currobj, objList, LevelInfo);
							RenderUnitySprite(game, x, y, z, currobj, objList, LevelInfo, 1);
							RenderUnityObjectInteraction(game, x, y, z, currobj, objList, LevelInfo);
							RenderUnityEntityWeapon(game, x, y, z, currobj, objList, LevelInfo);
							break;
						case ANIMATION:
							RenderUnityModel(game, x, y, z, currobj, objList, LevelInfo);
							RenderUnitySprite(game, x, y, z, currobj, objList, LevelInfo, 1);
							RenderUnityObjectInteraction(game, x, y, z, currobj, objList, LevelInfo);
							RenderUnityEntityAnimationOverlay(game, x, y, z, currobj, objList, LevelInfo);
							break;
						default:
							RenderUnityModel(game, x, y, z, currobj, objList, LevelInfo);
							RenderUnitySprite(game, x, y, z, currobj, objList, LevelInfo, 1);
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

void PrintUnityTileMap(int game, int Level, tile LevelInfo[64][64])
	{
	if (fopen_s(&UNITY_FILE, "unity.txt", "w") != 0)
		{
		printf("Unable to create output file for this thing");
		return;
		}
	for (int x = 0; x <= 63; x++)
		{
		for (int y = 0; y <= 63; y++)
			{
			fprintf(UNITY_FILE, "\n\tSetTileProp(%d,%d,%d,%d,%d,%d,%d,%d,%d);"
				, x, y, LevelInfo[x][y].tileType, 
				LevelInfo[x][y].Render, LevelInfo[x][y].floorHeight, LevelInfo[x][y].ceilingHeight, 
				LevelInfo[x][y].isWater, LevelInfo[x][y].isDoor, 0);  //TODO:Bridges
			}
		}
	fclose(UNITY_FILE);
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
					offX = 0.0; offY = 0.0; offZ = 0.0;
					CalcObjectXYZ(game, &offX, &offY, &offZ, LevelInfo, objList, nextObj, x, y,1);//Figures out where the object should be.
					offX=offX/100.0;offY=offY/100.0;offZ=(offZ/100.0);
					if ((!isTrigger(objList[nextObj])) && (!isTrap(objList[nextObj])) || (game==SHOCK))
						{//Everything but traps and triggers (uw)
						if (objList[nextObj].AlreadyRendered != 1)
							{
							if (objectMasters[objList[nextObj].item_id].isSet == 1)
								{
								RenderUnityEntity(game, offX, offY, offZ, objList[nextObj], objList, LevelInfo);
								}		
							else
								{
								fprintf(UNITY_FILE, "////Bugged object!");
								}
							//fprintf(UNITY_FILE, "\n\tmyObj = new GameObject(\"%s\");",UniqueObjectName(objList[nextObj]));//Create the object
							//fprintf(UNITY_FILE, "\n\tpos = new Vector3(%ff, %ff, %ff);",offX,offZ,offY);//Create the object x,z,y
							//fprintf(UNITY_FILE, "\n\tmyObj.transform.position = pos;");//Position the object
							//fprintf(UNITY_FILE, "\n\tCreateObjectGraphics(myObj,\"Assets/Sprites/objects_%03d.tga\");", objList[nextObj].item_id);
							}
						objList[nextObj].AlreadyRendered = 1;//Prevent possible duplication of0 objects due to system shock supporting objects that take occupy multiple tiles
						}
					fprintf(UNITY_FILE, "\n");
					nextObj = objList[nextObj].next;//In linked list.
					}
				}
			}
		}
	if (game!=SHOCK)
		{//Render my uw triggers and traps after the main object lists
		for (int i = 0; i < 1024; i++)
			{
			if (objList[i].AlreadyRendered!=1)
					{
					if (isTrigger(objList[i]))
						{
						offX = 0.0; offY = 0.0; offZ = 0.0;
						CalcObjectXYZ(game, &offX, &offY, &offZ, LevelInfo, objList, i, objList[i].tileX, objList[i].tileY);//Figures out where the object should be.
						offX = offX / 100.0; offY = offY / 100.0; offZ = (offZ / 100.0);
						switch (objectMasters[objList[i].item_id].type)
							{
							case A_MOVE_TRIGGER:
								RenderUnityEntityA_MOVE_TRIGGER(game, offX, offY, offZ, objList[i], objList, LevelInfo);
								break;
							default:
								RenderUnityTrigger(game, offX, offY, offZ, objList[i], objList, LevelInfo);
								break;
							}
						fprintf(UNITY_FILE, "\n");
						}

					if (isTrap(objList[i]))
						{
						CalcObjectXYZ(game, &offX, &offY, &offZ, LevelInfo, objList, i, objList[i].tileX, objList[i].tileY);//Figures out where the object should be.
						offX = offX / 100.0; offY = offY / 100.0; offZ = (offZ / 100.0);
						RenderUnityTrap(game, offX, offY, offZ, objList[i], objList, LevelInfo);
						fprintf(UNITY_FILE, "\n");
						}
					}
				}
			}
		
	fclose(UNITY_FILE);
	}

void UnityRotation(int game, int angle1, int angle2, int angle3)
	{
	float ang1 = angle1;
	float ang2 = angle2;
	float ang3 = angle3;
	switch (game)
		{
		case SHOCK:
			fprintf(UNITY_FILE, "\n\tSetRotation(myObj,(float)%f,(float)%f,(float)%f);", -((float)ang1 / 256.0)*360.0, ((float)ang2 / 256.0)*360.0, ((float)ang3 / 256.0)*360.0);
			break;
		default:
			fprintf(UNITY_FILE, "\n\tSetRotation(myObj,%d,%d,%d);",angle1,angle2,angle3);//-180
			break;
		}

	}

void setLink(ObjectItem currobj)
	{
	fprintf(UNITY_FILE, "\n\tSetLink(myObj,%d);", currobj.link);
	}

void setSprite(unsigned char *SpriteName)
	{
	fprintf(UNITY_FILE, "\n\tSetSprite(myObj,%s);", SpriteName);
	}

void SetScale(float x, float y, float z)
	{
	fprintf(UNITY_FILE, "\n\tSetScale(myObj,(float)%f,(float)%f,(float)%f);", x, y, z);
	}

void setReadable()
	{
	fprintf(UNITY_FILE, "\n\tSetReadable(myObj);");
	}


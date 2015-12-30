#include <stdio.h>
#include <stdlib.h>
#include <fstream>
#include "gameobjectsrender.h"
#include "math.h"


#include "D3DarkMod.h"
#include "textures.h"
#define utils_h
#include "utils.h"
#include "main.h"
#include "gameobjects.h"

extern FILE *MAPFILE;

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

void CalcObjectXYZ(int game, float *offX, float *offY, float *offZ, tile LevelInfo[64][64], ObjectItem objList[1600], long nextObj, int x, int y)
	{
	int ResolutionXY = 7;	// A tile has a 7x7 grid for object positioning.
	int ResolutionZ = 128;	//UW has 127 posible z positions for an object in tile.
	if (game == SHOCK){ ResolutionXY = 256; ResolutionZ = 256; }	//Shock has more "z" in it.


	*offX = 0;  *offY = 0; *offZ = 0;

	float BrushX = BrushSizeX;
	float BrushY = BrushSizeY;
	float BrushZ = BrushSizeZ;

	*offX = (x*BrushX) + ((objList[nextObj].x) * (BrushX / ResolutionXY));
	*offY = (y*BrushY) + ((objList[nextObj].y) * (BrushY / ResolutionXY));
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

void CalcObjectXYZ(int game, float *offX, float *offY, float *offZ, tile LevelInfo[64][64], ObjectItem objList[1600], long nextObj, int x, int y, short WallAdjust)
	{
	float ResolutionXY = 7.0;	// A tile has a 7x7 grid for object positioning.
	float ResolutionZ = 128.0;	//UW has 127 posible z positions for an object in tile.
	if (game == SHOCK){ ResolutionXY = 256.0; ResolutionZ = 256.0; }	//Shock has more "z" in it.

	*offX = 0;  *offY = 0; *offZ = 0;
	float BrushX = BrushSizeX;
	float BrushY = BrushSizeY;
	float BrushZ = BrushSizeZ;
	float objX = (float)objList[nextObj].x;
	float objY = (float)objList[nextObj].y;
	*offX = (x*BrushX) + ((objList[nextObj].x) * (BrushX / ResolutionXY));
	*offY = (y*BrushY) + ((objList[nextObj].y) * (BrushY / ResolutionXY));

	float zpos = objList[nextObj].zpos;
	float ceil = CEILING_HEIGHT;
	*offZ = ((zpos / ResolutionZ) * (ceil)) * BrushZ;
	if (game !=SHOCK)
		{//Adjust zpos by a fraction for objects on sloped tiles.
		switch (LevelInfo[x][y].tileType)
			{
				case TILE_SLOPE_N:
					*offZ += objY * (48.0 / BrushZ);
					break;
				case TILE_SLOPE_E:
					*offX += objX * (48.0 / BrushZ);
					break;
				case TILE_SLOPE_S:
					*offZ += (8.0f-objY) * (48.0 / BrushZ);
					break;
				case TILE_SLOPE_W:
					*offZ += (8.0f - objX) * (48.0 / BrushZ);
					break;
			}
		}

	if (WallAdjust == 1)
		{//Adjust the object x,y to avoid clipping into walls.
		switch (game)
			{
				case SHOCK:
					if (objList[nextObj].x == 0)
						{
						*offX = *offX + 2.0f;
						}
					if (objList[nextObj].x == 128)
						{
						*offX = *offX - 2.0f;
						}
					if (objList[nextObj].y == 0)
						{
						*offY = *offY + 2.0f;
						}
					if (objList[nextObj].y == 128)
						{
						*offY = *offY - 2.0f;
						}
					break;
				default:
					if (objList[nextObj].x == 0)
						{
						*offX = *offX + 2.0f;
						}
					if (objList[nextObj].x == 7)
						{
						*offX = *offX - 2.0f;
						}
					if (objList[nextObj].y == 0)
						{
						*offY = *offY + 2.0f;
						}
					if (objList[nextObj].y == 7)
						{
						*offY = *offY - 2.0f;
						}
					break;
			}
		}
	}

void createScriptCall(ObjectItem &currobj, float x, float y, float z)
	{//Entity for running a script when triggered.
	fprintf(MAPFILE, "\n// entity %d\n{\n", EntityCount);
	fprintf(MAPFILE, "\"classname\" \"atdm:target_callscriptfunction\"\n");
	fprintf(MAPFILE, "\"name\" \"runscript_%s\"\n", UniqueObjectName(currobj));
	fprintf(MAPFILE, "\"origin\" \"%f %f %f\"\n", x, y, z);
	fprintf(MAPFILE, "\"call\" \"start_%s\"\n", UniqueObjectName(currobj));
	fprintf(MAPFILE, "}\n");
	EntityCount++;
	}

void createScriptCall(ObjectItem &currobj, float x, float y, float z, char *callname)
	{//Entity for running a script when triggered.
	fprintf(MAPFILE, "\n// entity %d\n{\n", EntityCount);
	fprintf(MAPFILE, "\"classname\" \"atdm:target_callscriptfunction\"\n");
	fprintf(MAPFILE, "\"name\" \"runscript_%s_%s\"\n", UniqueObjectName(currobj), callname);
	fprintf(MAPFILE, "\"origin\" \"%f %f %f\"\n", x, y, z);
	fprintf(MAPFILE, "\"call\" \"start_%s_%s\"\n", UniqueObjectName(currobj), callname);
	fprintf(MAPFILE, "}\n");
	EntityCount++;
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
				{fprintf(MAPFILE, "\n\"rotation\" \"1 0 0 0 1 0 0 0 1\"\n"); break; }
			case 45:
				{fprintf(MAPFILE, "\n\"rotation\" \"0.707107 0.707107 0 -0.707107 0.707107 0 0 0 1\"\n"); break; }
			case 90:
				{fprintf(MAPFILE, "\n\"rotation\" \"0 -1 0 1 0 0 0 0 1\"\n"); break; }
			case 135:
				{fprintf(MAPFILE, "\n\"rotation\" \"-0.707107 0.707107 0 -0.707107 -0.707107 0 0 0 1\"\n"); break; }
			case 180:
				{fprintf(MAPFILE, "\n\"rotation\" \"-1 0 0 0 -1 0 0 0 1\"\n"); break; }
			case 225:
				{fprintf(MAPFILE, "\n\"rotation\" \"-0.707107 -0.707107 0 0.707107 -0.707107 0 0 0 1\"\n"); break; }
			case 270:
				{fprintf(MAPFILE, "\n\"rotation\" \"0 1 0 -1 0 0 0 0 1\"\n"); break; }
			case 315:
				{fprintf(MAPFILE, "\n\"rotation\" \"0.707107 -0.707107 0 0.707107 0.707107 0 0 0 1\"\n"); break; }
			default:
				{fprintf(MAPFILE, "\n\"rotation\" \"1 0 0 0 1 0 0 0 1\"\n"); break; }
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

void RenderEntity(int game, float x, float y, float z, ObjectItem &currobj, ObjectItem objList[1600], tile LevelInfo[64][64])
	{
	//Picks what type of object to generate.
	//long patchX;long patchY;long patchZ;
	//int patchOffsetX;int patchOffsetY;

	printf("Rendering:%s\n", UniqueObjectName(currobj));
	switch (objectMasters[currobj.item_id].isEntity)
		{
			case -1:	//ignore
				{return; break; }
			case 0:	//Model
				{
				RenderEntityModel(game, x, y, z, currobj, objList, LevelInfo);
				break;
				}
			case 1:	//entity
				{
				switch (objectMasters[currobj.item_id].type)
					{
						case NPC:
							RenderEntityNPC(game, x, y, z, currobj, objList, LevelInfo);
							break;
						case HIDDENDOOR:
						case DOOR:
						case PORTCULLIS:
							RenderEntityDoor(game, x, y, z, currobj, objList, LevelInfo);
							break;
						case KEY:
							RenderEntityKey(game, x, y, z, currobj, objList, LevelInfo);
							break;
						case CONTAINER:
							RenderEntityContainer(game, x, y, z, currobj, objList, LevelInfo);
							break;
						case ACTIVATOR:
							RenderEntityActivator(game, x, y, z, currobj, objList, LevelInfo);
							break;
						case BUTTON:
							RenderEntityButton(game, x, y, z, currobj, objList, LevelInfo);
							break;
						case LOCK:
						case A_DOOR_TRAP:
							RenderEntityA_DOOR_TRAP(game, x, y, z, currobj, objList, LevelInfo);
							break;
						case A_DO_TRAP:
							RenderEntityA_DO_TRAP(game, x, y, z, currobj, objList, LevelInfo);
							break;
						case A_CHANGE_TERRAIN_TRAP:
							RenderEntityA_CHANGE_TERRAIN_TRAP(game, x, y, z, currobj, objList, LevelInfo);
							break;
						case TMAP_SOLID:
						case TMAP_CLIP:
							RenderEntityTMAP(game, x, y, z, currobj, objList, LevelInfo);
							break;
						case BOOK:
						case SCROLL:
							RenderEntityBOOK(game, x, y, z, 0, currobj, objList, LevelInfo);
							break;
						case SIGN:
							RenderEntitySIGN(game, x, y, z, currobj, objList, LevelInfo);
							break;
						case A_MOVE_TRIGGER:
							RenderEntityA_MOVE_TRIGGER(game, x, y, z, currobj, objList, LevelInfo);
							break;
						case A_TELEPORT_TRAP:	//a destination for a teleport.
							RenderEntityA_TELEPORT_TRAP(game, x, y, z, currobj, objList, LevelInfo);
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
							RenderEntityNULL_TRIGGER(game, x, y, z, currobj, objList, LevelInfo);
							break;
						case SHOCK_TRIGGER_REPULSOR:
							RenderEntityREPULSOR(game, x, y, z, currobj, objList, LevelInfo);
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
						case UW_PAINTING:
							RenderEntityPaintingUW(game, x, y, z, currobj, objList, LevelInfo);
							break;
						case BRIDGE:
							RenderEntityBridgeUW(game, x, y, z, currobj, objList, LevelInfo);
							break;
						case PARTICLE:
							RenderEntityParticle(game, x, y, z, currobj, objList, LevelInfo, 0);
							break;
						default:
							//just the basic name. with no properties.
							fprintf(MAPFILE, "\n// entity %d\n{\n", EntityCount);

							//fprintf(MAPFILE, "\"name\" \"%s_%04d\"\n", objectMasters[currobj.item_id].desc, EntityCount);
							fprintf(MAPFILE, "\"name\" \"%s\"\n", UniqueObjectName(currobj));
							//position

							EntityRotation(currobj.heading);
							AttachToJoint(currobj);		//for models/darkmod/containers/bag1_small.lwonpc items

							if (objectMasters[currobj.item_id].isMoveable == 1)
								{
								if (objectMasters[currobj.item_id].isInventory == 1)
									{
									fprintf(MAPFILE, "\"classname\" \"%s\"\n", "atdm:moveable_custom_item");
									}
								else
									{
									fprintf(MAPFILE, "\"classname\" \"%s\"\n", "atdm:grabable_custom_item");
									}
								fprintf(MAPFILE, "\"origin\" \"%f %f %f\"\n", x, y, z + 12);
								fprintf(MAPFILE, "\"bouncyness\" \"0.1\"\n");
								fprintf(MAPFILE, "\"friction\" \"0.1\"\n");
								fprintf(MAPFILE, "\"frobable\" \"1\"\n");
								fprintf(MAPFILE, "\"mass\" \"0.6\"\n");
								fprintf(MAPFILE, "\"model\" \"%s\"\n", objectMasters[currobj.item_id].base);
								fprintf(MAPFILE, "\"notpushable\" \"0\"\n");
								fprintf(MAPFILE, "\"snd_bounce\" \"tdm_impact_small_hard_object\"\n");
								fprintf(MAPFILE, "\"spr_object_hardness\" \"hard\"\n");
								fprintf(MAPFILE, "\"spr_object_size\" \"medium\"\n");

								//fprintf(MAPFILE, "\"frob_action_script\" \"testfrob\"\n");
								}
							else
								{
								fprintf(MAPFILE, "\"classname\" \"%s\"\n", objectMasters[currobj.item_id].path);
								fprintf(MAPFILE, "\"origin\" \"%f %f %f\"\n", x, y, z);
								}

							if (objectMasters[currobj.item_id].isInventory == 1)
								{
								fprintf(MAPFILE, "\"inv_icon\" \"%s\"\n", objectMasters[currobj.item_id].InvIcon);
								fprintf(MAPFILE, "\"inv_name\" \"%s\"\n", objectMasters[currobj.item_id].desc);
								fprintf(MAPFILE, "\"inv_map_start\" \"0\"\n");
								fprintf(MAPFILE, "\"inv_droppable\" \"0\"\n");
								fprintf(MAPFILE, "\"frob_action_script\" \"%s_frob\"\n", UniqueObjectName(currobj));
								}

							fprintf(MAPFILE, "}");
							EntityCount++;
							break;
					}
				}
		}
	if (objectMasters[currobj.item_id].hasParticle == 1)
		{
		RenderEntityParticle(game, x, y, z, currobj, objList, LevelInfo, 1);
		}
	if (objectMasters[currobj.item_id].hasSound == 1)
		{
		RenderEntitySound(game, x, y, z, currobj, objList, LevelInfo, 1);
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

void RenderEntityA_DO_TRAP(int game, float x, float y, float z, ObjectItem &currobj, ObjectItem objList[1600], tile LevelInfo[64][64])
	{
	//This is a trigger in UW that can do a bunch of different things. Eg cameras/rising platforms.
	switch (currobj.quality)
		{
			case 2: //A camera	
				fprintf(MAPFILE, "\n// entity %d\n{\n", EntityCount);
				fprintf(MAPFILE, "\"classname\" \"func_cameraview\"\n");
				fprintf(MAPFILE, "\"name\" \"%s_%03d_%03d\"\n", objectMasters[currobj.item_id].desc, currobj.tileX, currobj.tileY);
				fprintf(MAPFILE, "\"origin\" \"%f %f %f\"\n", x, y, z);
				fprintf(MAPFILE, "\"trigger\" \"1\"\n");
				//Aim the camera.
				EntityRotation(currobj.heading);//TODO:Points in wrong direction
				fprintf(MAPFILE, "\n}");
				EntityCount++;
				break;
			case 3:	//rising platform
				RenderEntityElevator(game, LevelInfo, currobj);
				//RenderEntityBullfrog(game, LevelInfo, currobj);
				break;
				//case 24://Bullfrog
				//	
			default:
				RenderEntityParticle(game, x, y, z, currobj, objList, LevelInfo, 0);
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

void RenderEntityA_DOOR_TRAP(int game, float x, float y, float z, ObjectItem &currobj, ObjectItem objList[1600], tile LevelInfo[64][64])
	{//Is this in use?
	//A door trap object for opening doors.
	//Params
	//objectOwnerName (passed down from a parent object)
	//objectOwner
	//tileX
	//tileY
	//Need to add path for generic usage.

	fprintf(MAPFILE, "\n// entity %d\n{\n", EntityCount);
	fprintf(MAPFILE, "\"classname\" \"%s\"\n", objectMasters[currobj.item_id].path);
	fprintf(MAPFILE, "\"name\" \"door_%03d_%03d\"\n", currobj.objectOwner, currobj.objectOwnerName);
	fprintf(MAPFILE, "\"target\" \"door_%03d_%03d\"\n", currobj.tileX, currobj.tileY);	//Doors are refered to by their tile location.
	fprintf(MAPFILE, "\"toggle\" \"1\"\n");	//todo: other types of behaviour.
	fprintf(MAPFILE, "\"origin\" \"%f %f %f\"\n", x, y, z);
	fprintf(MAPFILE, "}");
	EntityCount++;
	return;
	}

void RenderEntityA_CHANGE_TERRAIN_TRAP(int game, float x, float y, float z, ObjectItem &currobj, ObjectItem objList[1600], tile LevelInfo[64][64])
	{
	//
	//A trigger that converts one type of terrain into another.
	//We generate both types of terrain at the start but hide the second type until the trigger is activated.
	//render func static for the initial tiles.
	PrimitiveCount = 0;
	int tileCount = 0;
	//for (int i = 0; i <= currobj.x; i++)
	//{
	//	for (int j = 0; j <= currobj.y; j++)
	//	{

	//		fprintf(MAPFILE, "\n// entity %d\n{\n", EntityCount++);
	//		fprintf(MAPFILE, "\"classname\" \"%s\"\n", objectMasters[currobj.item_id].path);
	//		//TODO:There is some weirdness when I try and hide water. For now I'll just ignore it.
	//		//if (LevelInfo[currobj.tileX+i][currobj.tileY+j].isWater == 0)
	//		//	{
	//		//fprintf (MAPFILE, "\"name\" \"%s_initial_%03d_%03d_%03d_%03d\"\n",objectMasters[currobj.item_id].desc,currobj.tileX,currobj.tileY,currobj.index,tileCount);
	//		fprintf(MAPFILE, "\"name\" \"initial_%s_%03d\"\n", UniqueObjectName(currobj), tileCount);
	//		//	}
	//		//else
	//		//	{//water
	//		//	fprintf (MAPFILE, "\"name\" \"%s_initial_%03d_%03d_%03d_%03d\"\n",objectMasters[currobj.item_id].desc,currobj.tileX,currobj.tileY,currobj.index,tileCount);
	//		//		fprintf (MAPFILE, "\n\"underwater_gui\" \"guis\underwater\underwater_green_thinmurk.gui\"\n");
	//		//			}
	//		fprintf(MAPFILE, "\"model\" \"initial_%s_%03d\"\n", UniqueObjectName(currobj), tileCount);
	//		fprintf(MAPFILE, "\"origin\" \"%d %d %d\"\n", (currobj.tileX + i)*BrushSizeX, (currobj.tileY + j)*BrushSizeY, 0);
	//		RenderDarkModTile(game, 0, 0, LevelInfo[currobj.tileX + i][currobj.tileY + j], LevelInfo[currobj.tileX + i][currobj.tileY + j].isWater, 0, 0, 1);
	//		fprintf(MAPFILE, "\n}\n");
	//		tileCount++;
	//	}
	//}

	for (int i = 0; i <= currobj.x; i++)
		{
		for (int j = 0; j <= currobj.y; j++)
			{
			//Then render a func static for how it ends up.
			PrimitiveCount = 0;
			fprintf(MAPFILE, "\n// entity %d\n{\n", EntityCount++);
			fprintf(MAPFILE, "\"classname\" \"%s\"\n", objectMasters[currobj.item_id].path);
			fprintf(MAPFILE, "\"name\" \"%s_%02d_%02d\"\n", UniqueObjectName(currobj), currobj.tileX + i, currobj.tileY + j);
			fprintf(MAPFILE, "\"model\" \"%s_%02d_%02d\"\n", UniqueObjectName(currobj), currobj.tileX + i, currobj.tileY + j);
			fprintf(MAPFILE, "\"origin\" \"%d %d %d\"\n", currobj.tileX*BrushSizeX + (i*BrushSizeX), currobj.tileY*BrushSizeY + (j*BrushSizeY), 0);

			tile t;	//temporary tile for rendering.
			t.tileType = currobj.quality & 0x01;
			t.Render = 1;
			t.floorHeight = ((currobj.zpos >> 3) >> 2) * 8;	//heights in uw are shifted
			t.floorHeight = (currobj.zpos >> 2);	//heights in uw are shifted
			t.ceilingHeight = 0;
			if (game != UW2)
				{
				t.floorTexture = (currobj.quality >> 1) + 210;
				}
			else
				{
				t.floorTexture = LevelInfo[currobj.tileX][currobj.tileY].floorTexture;//?
				}
			t.shockCeilingTexture = LevelInfo[currobj.tileX + i][currobj.tileY + j].shockCeilingTexture;
			t.wallTexture = LevelInfo[currobj.tileX + i][currobj.tileY + j].wallTexture;
			t.West = LevelInfo[currobj.tileX + i][currobj.tileY + j].West;
			t.East = LevelInfo[currobj.tileX + i][currobj.tileY + j].East;
			t.North = LevelInfo[currobj.tileX + i][currobj.tileY + j].North;
			t.South = LevelInfo[currobj.tileX + i][currobj.tileY + j].South;
			t.isWater = 0;
			t.DimY = 1;
			t.DimX = 1;
			t.hasElevator = 0;
			t.BullFrog = 0;
			RenderDarkModTile(game, 0, 0, t, 0, 0, 0, 1);
			fprintf(MAPFILE, "\n}\n");

			}
		}

	}

void RenderEntityA_MOVE_TRIGGER(int game, float x, float y, float z, ObjectItem &currobj, ObjectItem objList[1600], tile LevelInfo[64][64])
	{
	//A trigger that fires when you step in it.
	//Params
	//item_id
	//index
	//tileX
	//tileY
	//need to add objectmaster path for generic usage
	//need to add objectmaster desc for generic usage

	fprintf(MAPFILE, "\n// entity %d\n{\n", EntityCount++);
	fprintf(MAPFILE, "\"classname\" \"%s\"\n", objectMasters[currobj.item_id].path);
	fprintf(MAPFILE, "\"name\" \"%s\"\n", UniqueObjectName(currobj));
	fprintf(MAPFILE, "\"model\" \"%s\"\n", UniqueObjectName(currobj));
	fprintf(MAPFILE, "\"target\" \"runscript_%s\"\n", UniqueObjectName(currobj));
	fprintf(MAPFILE, "\"wait\" \"5\"\n");
	switch (game)
		{
			case UWDEMO:
			case UW1:	//At the corner of the tile
				fprintf(MAPFILE, "\"origin\" \"%d %d %d\"\n", currobj.tileX*BrushSizeX, currobj.tileY*BrushSizeY, LevelInfo[currobj.tileX][currobj.tileY].floorHeight*BrushSizeZ);
				break;
			case UW2:	//Positioned around the triggers origin.
				fprintf(MAPFILE, "\"origin\" \"%f %f %f\"\n", x, y, z);
				break;
			case SHOCK:	//At the corner of the tile.
				fprintf(MAPFILE, "\"origin\" \"%d %d %d\"\n", currobj.tileX*BrushSizeX, currobj.tileY*BrushSizeY, 0);
				break;
		}

	tile t;	//temp tile for rendering trigger
	t.floorTexture = TRIGGER_MULTI;
	t.wallTexture = TRIGGER_MULTI;
	t.East = TRIGGER_MULTI;
	t.West = TRIGGER_MULTI;
	t.North = TRIGGER_MULTI;
	t.South = TRIGGER_MULTI;
	t.DimX = 1; t.DimY = 1;
	t.tileType = 1;
	t.Render = 1;
	t.floorHeight = 0;
	t.ceilingHeight = CEILING_HEIGHT;
	t.isWater = 0;
	t.hasElevator = 0;
	t.BullFrog = 0;
	switch (game)
		{
			case UWDEMO:
			case UW1:
				RenderGenericTile(0, 0, t, 1, 0);
				break;
			case UW2:
				RenderGenericTileAroundOrigin(currobj.tileX, currobj.tileY, t, LevelInfo[currobj.tileX][currobj.tileY].floorHeight + 1, LevelInfo[currobj.tileX][currobj.tileY].floorHeight, BrushSizeZ);
				break;
			case SHOCK:
				//enter any part of tile
				RenderGenericTile(0, 0, t, CEILING_HEIGHT, 0);
				break;
		}

	fprintf(MAPFILE, "\n}");
	createScriptCall(currobj, x, y, z);
	}

void RenderEntityA_TELEPORT_TRAP(int game, float x, float y, float z, ObjectItem &currobj, ObjectItem objList[1600], tile LevelInfo[64][64])
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
		fprintf(MAPFILE, "\n// entity %d\n{\n", EntityCount);
		fprintf(MAPFILE, "\"classname\" \"%s\"\n", objectMasters[currobj.item_id].path);
		fprintf(MAPFILE, "\"name\" \"%s\"\n", UniqueObjectName(currobj));
		fprintf(MAPFILE, "\"origin\" \"%d %d %d\"\n", currobj.quality * BrushSizeX + (BrushSizeX / 2), currobj.owner * BrushSizeY + (BrushSizeY / 2), LevelInfo[currobj.quality][currobj.owner].floorHeight * BrushSizeZ);
		fprintf(MAPFILE, "\n}");
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
				ReadableIndex = currobj.shockProperties[SOFT_PROPERTY_LOG];	//currobj.Property1;	//The chunk that the text comes from.
				break;
			default:
				ReadableIndex = currobj.link - 0x200;
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
	fprintf(MAPFILE, "\"inv_icon\" \"%s\"\n", objectMasters[currobj.item_id].InvIcon);
	switch (game)
		{
			case UWDEMO:
			case UW1:
				{fprintf(MAPFILE, "\"xdata_contents\" \"readables/uw1/scroll_%03d\"\n", ReadableIndex); break; }
			case UW2:
				{fprintf(MAPFILE, "\"xdata_contents\" \"readables/uw2/scroll_%03d\"\n", ReadableIndex); break; }
			case SHOCK:
				{
				fprintf(MAPFILE, "\"xdata_contents\" \"readables/shock/log_%03d\"\n", ReadableIndex);
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
	fprintf(MAPFILE, "\"origin\" \"%f %f %f\"\n", x, y, z);
	EntityRotation(currobj.heading);
	AttachToJoint(currobj);		//for npc items
	fprintf(MAPFILE, "}");
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
			createScriptCall(currobj, x, y, z, "email");
			}
		}
	return;
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
	fprintf(MAPFILE, "\"model\" \"%s\"\n", objectMasters[currobj.item_id].path);
	//position
	fprintf(MAPFILE, "\"origin\" \"%f %f %f\"\n", x, y, z);
	fprintf(MAPFILE, "\"rotate\" \"0 0 1\"\n");
	fprintf(MAPFILE, "\"interruptable\" \"0\"\n");

	fprintf(MAPFILE, "\"hide\" \"%d\"\n", currobj.invis);

	fprintf(MAPFILE, "\"target\" \"runscript_%s\"\n", UniqueObjectName(currobj));
	if (game == SHOCK)
		{//gui related settings. Sets the gui that controls the 2d animation of this switch.
		fprintf(MAPFILE, "\"gui\" \"guis/shock/switch_%d_%d_%d.gui\"\n", currobj.ObjectClass, currobj.ObjectSubClass, currobj.ObjectSubClassIndex);
		fprintf(MAPFILE, "\"gui_parm1\" \"0\"\n", currobj.ObjectClass, currobj.ObjectSubClass, currobj.ObjectSubClassIndex);
		EntityRotationSHOCK(currobj.Angle2);
		}
	else
		{
		EntityRotation(currobj.heading);
		}
	fprintf(MAPFILE, "}\n"); EntityCount++;
	createScriptCall(currobj, x, y, z);	//To run whatever actions this switch performs.
	return;
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

void RenderEntityContainer(int game, float x, float y, float z, ObjectItem &currobj, ObjectItem objList[1600], tile LevelInfo[64][64])
	{
	//Creates something that holds objects. Current behaviour is to spawn objects at various spawn points surrounding the object.
	//Params.
	//Item_id
	//link	//To check for a lock and it's list of contents.

	if (game != SHOCK)
		{
		fprintf(MAPFILE, "\n// entity %d\n{\n", EntityCount++);
		fprintf(MAPFILE, "\"classname\" \"%s\"\n", "func_static");
		fprintf(MAPFILE, "\"model\" \"%s\"\n", objectMasters[currobj.item_id].path);
		//I need to spawn it's contents at the same location (recursively)
		//render it first.
		//TODO: I also need to fix containers which are not really entities
		fprintf(MAPFILE, "\"name\" \"%s\"\n", UniqueObjectName(currobj));
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
		fprintf(MAPFILE, "\"origin\" \"%f %f %f\"\n", x, y, z);
		fprintf(MAPFILE, "\"hide\" \"%d\"\n", currobj.invis);
		AttachToJoint(currobj);
		fprintf(MAPFILE, "}");
		EntityCount++;

		//now recursively get it's contents.
		if (currobj.link != 0)	//Container has objects
			{
			ObjectItem tmpobj = objList[currobj.link];
			while (tmpobj.next != 0)
				{
				if (objectMasters[objList[currobj.link].item_id].type != LOCK)
					{
					RenderEntity(game, x, y, z, tmpobj, objList, LevelInfo);
					}
				tmpobj = objList[tmpobj.next];
				}
			RenderEntity(game, x, y, z, tmpobj, objList, LevelInfo);
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

void RenderEntityDecal(int game, float x, float y, float z, ObjectItem &currobj, ObjectItem objList[1600], tile LevelInfo[64][64])
	{//decals like wall icons etc.
	fprintf(MAPFILE, "\n// entity %d\n{\n", EntityCount++);
	fprintf(MAPFILE, "\"classname\" \"%s\"\n", "func_static");
	fprintf(MAPFILE, "\"name\" \"%s\"\n", UniqueObjectName(currobj));

	switch (currobj.ObjectSubClassIndex)
		{
			case 0:	//sign
				fprintf(MAPFILE, "\"model\" \"%s\"\n", objectMasters[currobj.item_id].path);
				fprintf(MAPFILE, "\"skin\" \"shock_sign_%04d\"\n", 390 + currobj.unk1);
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
				fprintf(MAPFILE, "\"skin\" \"shock_painting_%04d\"\n", 403 + currobj.unk1);

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


void RenderEntityPaintingUW(int game, float x, float y, float z, ObjectItem &currobj, ObjectItem objList[1600], tile LevelInfo[64][64])
	{//UW2 wall paintings.
	fprintf(MAPFILE, "\n// entity %d\n{\n", EntityCount++);
	fprintf(MAPFILE, "\"classname\" \"%s\"\n", "func_static");
	fprintf(MAPFILE, "\"name\" \"%s\"\n", UniqueObjectName(currobj));
	fprintf(MAPFILE, "\"origin\" \"%f %f %f\"\n", x, y, z);
	fprintf(MAPFILE, "\"hide\" \"%d\"\n", currobj.invis);
	fprintf(MAPFILE, "\"model\" \"%s\"\n", objectMasters[currobj.item_id].path);
	fprintf(MAPFILE, "\"skin\" \"uw2_painting_%02d\"\n", currobj.flags & 0x7);
	EntityRotation(currobj.heading);
	fprintf(MAPFILE, "\n}");
	}

void RenderEntityBridgeUW(int game, float x, float y, float z, ObjectItem &currobj, ObjectItem objList[1600], tile LevelInfo[64][64])
	{//UW2 bridges
	fprintf(MAPFILE, "\n// entity %d\n{\n", EntityCount++);
	fprintf(MAPFILE, "\"classname\" \"%s\"\n", "func_static");
	fprintf(MAPFILE, "\"name\" \"%s\"\n", UniqueObjectName(currobj));
	fprintf(MAPFILE, "\"origin\" \"%f %f %f\"\n", x, y, z);
	fprintf(MAPFILE, "\"hide\" \"%d\"\n", currobj.invis);
	fprintf(MAPFILE, "\"model\" \"%s\"\n", objectMasters[currobj.item_id].path);
	if (currobj.flags < 2)
		{
		fprintf(MAPFILE, "\"skin\" \"uw%d_bridge_%02d\"\n", game, currobj.flags & 0x7);
		}
	else
		{
		printf("\nMake sure this skin exists!"); //uw2_bridge_texture_189
		fprintf(MAPFILE, "\"skin\" \"uw%d_bridge_texture_%03d\"\n", game, currobj.texture);
		}

	EntityRotation(currobj.heading);
	fprintf(MAPFILE, "\n}");
	}

void RenderEntityDoor(int game, float x, float y, float z, ObjectItem &currobj, ObjectItem objList[1600], tile LevelInfo[64][64])
	{
	//Params
	//item_id
	//tileX
	//tileY
	//Link for a lock
	float doorWidth = 48;
	float doorHeight = 96;
	int doorThickness = 2;
	float doorOffset = 0;
	float tileX = currobj.tileX;
	float tileY = currobj.tileY;
	float BrushX = BrushSizeX;
	float BrushY = BrushSizeY;
	float zpos = z;

	zpos = LevelInfo[currobj.tileX][currobj.tileY].floorHeight*BrushSizeZ;//Force the door to stay on the ground.
	z = zpos;
	if (game == SHOCK)
		{
		zpos = LevelInfo[currobj.tileX][currobj.tileY].floorHeight * BrushSizeZ;
		if (currobj.Angle1 > 0)
			{
			return;
			}
		}
	//for a door I need to point it's used_by property at the key object's name. This is accessed through a lock object
	fprintf(MAPFILE, "\n// entity %d\n{\n", EntityCount);
	fprintf(MAPFILE, "\"classname\" \"%s\"\n", objectMasters[currobj.item_id].path);

	fprintf(MAPFILE, "\"name\" \"%s_%03d_%03d\"\n", objectMasters[currobj.item_id].desc, currobj.tileX, currobj.tileY);
	fprintf(MAPFILE, "\"hide\" \"%d\"\n", currobj.invis);
	if ((game != SHOCK) && (objectMasters[currobj.item_id].type == DOOR))
		{
		fprintf(MAPFILE, "\"model\" \"%s\"\n", "models/darkmod/uw1/uw_door.ase");
		fprintf(MAPFILE, "\"skin\" \"uw%d_doors_%02d\"\n", game, objectMasters[currobj.item_id].extraInfo);
		}
	fprintf(MAPFILE, "\"auto_close_time\" \"30\"\n");
	if ((currobj.link != 0) || (currobj.SHOCKLocked >0))	//door has a lock. bit 0-6 of the lock objects link is the keyid for opening it in uw
		{
		//up to 6 keys can be used for a door to allow duplicate keys.
		if (game != SHOCK)
			{
			fprintf(MAPFILE, "\"locked\" \"%d\"\n", (objList[currobj.link].flags & 0x01));
			fprintf(MAPFILE, "\"used_by\" \"a_key_%03d_0\"\n", objList[currobj.link].link & 0x3F);
			fprintf(MAPFILE, "\"used_by1\" \"a_key_%03d_1\"\n", objList[currobj.link].link & 0x3F);
			fprintf(MAPFILE, "\"used_by2\" \"a_key_%03d_2\"\n", objList[currobj.link].link & 0x3F);
			fprintf(MAPFILE, "\"used_by3\" \"a_key_%03d_3\"\n", objList[currobj.link].link & 0x3F);
			fprintf(MAPFILE, "\"used_by4\" \"a_key_%03d_4\"\n", objList[currobj.link].link & 0x3F);
			fprintf(MAPFILE, "\"used_by5\" \"a_key_%03d_5\"\n", objList[currobj.link].link & 0x3F);
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
	if (objectMasters[currobj.item_id].type == PORTCULLIS)
		{
		fprintf(MAPFILE, "\"rotate\" \"0 0 0\"\n");
		fprintf(MAPFILE, "\"translate\" \"0 0 80\"\n");
		}
	//fprintf(MAPFILE, "\"rotate\" \"0 90 0\"\n");
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
		{
			case EAST:
			case SHOCK_EAST:
			case WEST:
			case SHOCK_WEST:
				if (game != SHOCK)
					{
					if (currobj.x == 0)
						doorOffset = +2;
					if (currobj.x == 7)
						doorOffset = -2;
					}
				break;
			case NORTH:
			case SHOCK_NORTH:
			case SOUTH:
				if (game != SHOCK)
					{
					if (currobj.y == 0)
						doorOffset = +2;
					if (currobj.y == 7)
						doorOffset = -2;
					}
		}


	switch (heading)
		{//TODO: replace with proper model offset
			case SHOCK_EAST:
			case EAST:
				{fprintf(MAPFILE, "\"origin\" \"%f %f %f\"\n", x + doorOffset, (tileY)*BrushY + ((0 + (BrushY - doorWidth) / 2)), zpos);	break; }
			case SHOCK_WEST:
			case WEST:
				{fprintf(MAPFILE, "\"origin\" \"%f %f %f\"\n", x + doorOffset, (tileY)*BrushY + ((doorWidth + (BrushY - doorWidth) / 2)), zpos);	break; }
			case SHOCK_NORTH:
			case NORTH:
				{fprintf(MAPFILE, "\"origin\" \"%f %f %f\"\n", (tileX)*BrushX + ((doorWidth + (BrushX - doorWidth) / 2)), y + doorOffset, zpos);	break; }
			case SOUTH:
				{fprintf(MAPFILE, "\"origin\" \"%f %f %f\"\n", (tileX)*BrushX + ((0 + (BrushX - doorWidth) / 2)), y + doorOffset, zpos);	break; }
		}



	tile t = LevelInfo[currobj.tileX][currobj.tileY];
	//if (game != SHOCK)
	//{
	//	EntityRotation(currobj.heading);
	//}
	//else
	//{
	if ((objectMasters[currobj.item_id].type != HIDDENDOOR) && (game != SHOCK))
		{
		EntityRotation(currobj.heading);
		//EntityRotationSHOCK(currobj.Angle2);
		}
	//}

	if (objectMasters[currobj.item_id].type == HIDDENDOOR)
		{//For a secret door I need to render a brush to match the wall
		fprintf(MAPFILE, "\"model\" \"%s_%03d_%03d\"\n", objectMasters[currobj.item_id].desc, currobj.tileX, currobj.tileY);
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
					fprintf(MAPFILE, "// primitive %f\n", 0);
					fprintf(MAPFILE, "{\nbrushDef3\n{\n");
					//east face 
					fprintf(MAPFILE, "( 1 0 0 %d )", -(doorThickness));
					getWallTextureName(t, fSELF, 0);
					//north face 
					fprintf(MAPFILE, "( 0 1 0 %f )", -(doorWidth));
					getWallTextureName(t, fSELF, 0);
					//top face
					fprintf(MAPFILE, "( 0 0 1 %f )", -doorHeight);
					getFloorTextureName(t, fTOP);
					//west face
					fprintf(MAPFILE, "( -1 0 0 %d )", -(doorThickness));
					getWallTextureName(t, fSELF, 0);
					//south face
					fprintf(MAPFILE, "( 0 -1 0 %d )", -(0));
					getWallTextureName(t, fSELF, 0);
					//bottom face
					fprintf(MAPFILE, "( 0 0 -1 %d )", 0);
					getFloorTextureName(t, fBOTTOM);
					break;
				case WEST:
				case SHOCK_WEST:
					fprintf(MAPFILE, "// primitive %d\n", 0);
					fprintf(MAPFILE, "{\nbrushDef3\n{\n");
					//east face 
					fprintf(MAPFILE, "( 1 0 0 %d )", -(doorThickness));
					getWallTextureName(t, fSELF, 0);
					//north face 
					fprintf(MAPFILE, "( 0 1 0 %d )", -(0));
					getWallTextureName(t, fSELF, 0);
					//top face
					fprintf(MAPFILE, "( 0 0 1 %f )", -doorHeight);
					getFloorTextureName(t, fTOP);
					//west face
					fprintf(MAPFILE, "( -1 0 0 %d )", -(doorThickness));
					getWallTextureName(t, fSELF, 0);
					//south face
					fprintf(MAPFILE, "( 0 -1 0 %f )", -(doorWidth));
					getWallTextureName(t, fSELF, 0);
					//bottom face
					fprintf(MAPFILE, "( 0 0 -1 %d )", 0);
					getFloorTextureName(t, fBOTTOM);
					break;
				case NORTH:
				case SHOCK_NORTH:
					fprintf(MAPFILE, "// primitive %f\n", 0);
					fprintf(MAPFILE, "{\nbrushDef3\n{\n");
					//east face 
					fprintf(MAPFILE, "( 1 0 0 %d )", -(0));
					getWallTextureName(t, fSELF, 0);
					//north face 
					fprintf(MAPFILE, "( 0 1 0 %d )", -(doorThickness));
					getWallTextureName(t, fSELF, 0);
					//top face
					fprintf(MAPFILE, "( 0 0 1 %f )", -doorHeight);
					getFloorTextureName(t, fTOP);
					//west face
					fprintf(MAPFILE, "( -1 0 0 %f )", -(doorWidth));
					getWallTextureName(t, fSELF, 0);
					//south face
					fprintf(MAPFILE, "( 0 -1 0 %d )", -(doorThickness));
					getWallTextureName(t, fSELF, 0);
					//bottom face
					fprintf(MAPFILE, "( 0 0 -1 %d )", 0);
					getFloorTextureName(t, fBOTTOM);
					break;
				case SOUTH:
					//case SHOCK_SOUTH:
					{
					fprintf(MAPFILE, "// primitive %f\n", 0);
					fprintf(MAPFILE, "{\nbrushDef3\n{\n");
					//east face 
					fprintf(MAPFILE, "( 1 0 0 %f )", -(doorWidth));
					getWallTextureName(t, fSELF, 0);
					//north face 
					fprintf(MAPFILE, "( 0 1 0 %d )", -(doorThickness));
					getWallTextureName(t, fSELF, 0);
					//top face
					fprintf(MAPFILE, "( 0 0 1 %f )", -doorHeight);
					getFloorTextureName(t, fTOP);
					//west face
					fprintf(MAPFILE, "( -1 0 0 %d )", +(0));
					getWallTextureName(t, fSELF, 0);
					//south face
					fprintf(MAPFILE, "( 0 -1 0 %d )", -(doorThickness));
					getWallTextureName(t, fSELF, 0);
					//bottom face
					fprintf(MAPFILE, "( 0 0 -1 %d )", 0);
					getFloorTextureName(t, fBOTTOM);
					break;
					}

			}
		fprintf(MAPFILE, "}\n}\n");
		}
	fprintf(MAPFILE, "}");
	EntityCount++;
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
	return;
	}

void RenderEntitySHOCKDoor(int game, float x, float y, float z, ObjectItem &currobj, ObjectItem objList[1600], tile LevelInfo[64][64])
	{
	//The animated door graphics.
	fprintf(MAPFILE, "\n// entity %d\n{\n", EntityCount++);
	fprintf(MAPFILE, "\"classname\" \"%s\"\n", "func_static");
	fprintf(MAPFILE, "\"name\" \"%s_way\"\n", UniqueObjectName(currobj));
	fprintf(MAPFILE, "\"gui\" \"guis/shock/door_%d_%d_%d.gui\"\n", currobj.ObjectClass, currobj.ObjectSubClass, currobj.ObjectSubClassIndex);
	fprintf(MAPFILE, "\"gui_parm1\" \"0\"\n");
	fprintf(MAPFILE, "\"gui2\" \"guis/shock/door_%d_%d_%d_reverse.gui\"\n", currobj.ObjectClass, currobj.ObjectSubClass, currobj.ObjectSubClassIndex);
	fprintf(MAPFILE, "\"gui2_parm1\" \"0\"\n");
	fprintf(MAPFILE, "\"origin\" \"%f %f %f\"\n", x, y, z);
	fprintf(MAPFILE, "\"model\" \"%s\"\n", objectMasters[currobj.item_id].path);
	fprintf(MAPFILE, "\"hide\" \"%d\"\n", currobj.invis);
	fprintf(MAPFILE, "\"solid\" \"%d\"\n", 0);
	fprintf(MAPFILE, "\"skin\" \"shock_anim_door_%03d\"\n", currobj.item_id);
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
	fprintf(MAPFILE, "\"rotate\" \"%d %d %d\"\n", 0, 0, 0);
	fprintf(MAPFILE, "\"translate_speed\" \"%d\"\n", 500);
	fprintf(MAPFILE, "\"translate\" \"%d %d %d\"\n", 0, 0, -120);
	fprintf(MAPFILE, "\"frobable\" \"%d\"\n", 1);
	fprintf(MAPFILE, "\"frob_action_script\" \"start_%s\"\n", UniqueObjectName(currobj));
	//fprintf(MAPFILE, "\"state_change_callback\" \"start_%s_callback\"\n", UniqueObjectName(currobj));

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
			//fprintf(MAPFILE, "\"used_action_script\" \"start_%s\"\n", UniqueObjectName(currobj));
			fprintf(MAPFILE, "\"open_on_unlock\" \"0\"\n");//For animation compatability
			}
		}
	fprintf(MAPFILE, "\n}");


	if ((currobj.link != 0) || (currobj.SHOCKLocked >0) && (game != SHOCK))
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

void RenderEntityGrating(int game, float x, float y, float z, ObjectItem &currobj, ObjectItem objList[1600], tile LevelInfo[64][64])
	{//Transparent Gratings.
	fprintf(MAPFILE, "\n// entity %d\n{\n", EntityCount++);
	fprintf(MAPFILE, "\"classname\" \"%s\"\n", "func_static");
	fprintf(MAPFILE, "\"name\" \"%s\"\n", UniqueObjectName(currobj));
	fprintf(MAPFILE, "\"model\" \"%s\"\n", objectMasters[currobj.item_id].path);
	fprintf(MAPFILE, "\"skin\" \"shock_grating_%03d\"\n", currobj.ObjectSubClassIndex - 4);
	fprintf(MAPFILE, "\"origin\" \"%f %f %f\"\n", x, y, z);
	fprintf(MAPFILE, "\"hide\" \"%d\"\n", currobj.invis);
	EntityRotationSHOCK(currobj.Angle2);
	fprintf(MAPFILE, "\n}");
	}

void RenderEntityKey(int game, float x, float y, float z, ObjectItem &currobj, ObjectItem objList[1600], tile LevelInfo[64][64])
	{
	//Creates a key. Each key is uniquely named based on a counter. Doors will have a list of potential matching key names to work with keys.
	//Params
	//Item_id
	//Owner

	//A key's owner id matches it's lock link id.
	fprintf(MAPFILE, "\n// entity %d\n{\n", EntityCount);
	fprintf(MAPFILE, "\"classname\" \"%s\"\n", objectMasters[currobj.item_id].path);
	if (game != SHOCK)
		{
		//fprintf(MAPFILE, "\"name\" \"%s_%03d_%d\"\n", objectMasters[currobj.item_id].desc, currobj.owner, keycount[currobj.owner]++);
		fprintf(MAPFILE, "\"name\" \"%s_%03d_%d\"\n", objectMasters[currobj.item_id].desc, currobj.owner, currobj.keyCount);
		fprintf(MAPFILE, "\"inv_name\" \"%s_%03d\"\n", objectMasters[currobj.item_id].desc, currobj.owner);
		fprintf(MAPFILE, "\"inv_icon\" \"%s\"\n", objectMasters[currobj.item_id].InvIcon);
		}
	else
		{
		//fprintf(MAPFILE, "\"name\" \"%s_%d\"\n", objectMasters[currobj.item_id].desc, keycount[currobj.ObjectSubClassIndex]++);
		fprintf(MAPFILE, "\"name\" \"%s_%d\"\n", objectMasters[currobj.item_id].desc, currobj.keyCount);
		fprintf(MAPFILE, "\"inv_name\" \"%s\"\n", objectMasters[currobj.item_id].desc);
		fprintf(MAPFILE, "\"inv_icon\" \"%s\"\n", objectMasters[currobj.item_id].InvIcon);
		}

	//they also need the following properties
	fprintf(MAPFILE, "\"usable\" \"1\"\n\"frobable\" \"1\"\n\n\"inv_target\" \"player1\"\n\"inv_stackable\" \"1\"\n\"inv_category\" \"Keys\"\n");
	//position
	fprintf(MAPFILE, "\"origin\" \"%f %f %f\"\n", x, y, z);
	fprintf(MAPFILE, "\"hide\" \"%d\"\n", currobj.invis);
	EntityRotation(currobj.heading);
	AttachToJoint(currobj);
	fprintf(MAPFILE, "}");
	EntityCount++;
	return;
	}

void RenderEntityModel(int game, float x, float y, float z, ObjectItem &currobj, ObjectItem objList[1600], tile LevelInfo[64][64])
	{//A model with no properties.

	//Params 
	//item_id
	//tileX
	//tileY
	//Index

	fprintf(MAPFILE, "\n// entity %d\n{\n", EntityCount);
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
	fprintf(MAPFILE, "\"name\" \"%s\"\n", UniqueObjectName(currobj));
	fprintf(MAPFILE, "\"origin\" \"%f %f %f\"\n", x, y, z);
	if (objectMasters[currobj.item_id].type == HIDDENPLACEHOLDER)
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
	if (currobj.link != 0)
		{
		fprintf(MAPFILE, "\"frobable\" \"%d\"\n", 1);
		fprintf(MAPFILE, "\"frob_action_script\" \"start_%s\"\n", UniqueObjectName(currobj));
		}
	fprintf(MAPFILE, "\n\"model\" \"%s\"\n}\n", objectMasters[currobj.item_id].path);
	EntityCount++;
	if ((currobj.DeathWatched >= 1) && (game == SHOCK))
		{
		createScriptCall(currobj, x, y, z);
		}
	return;
	}

void RenderEntityNPC(int game, float x, float y, float z, ObjectItem &currobj, ObjectItem objList[1600], tile LevelInfo[64][64])
	{
	//Params
	//item_id
	//npc_whoami
	//npc_attitude
	//link for npc inventory in UW
	//objectOwnerEntity.

	fprintf(MAPFILE, "\n// entity %d\n{\n", EntityCount);
	fprintf(MAPFILE, "\"classname\" \"%s\"\n", objectMasters[currobj.item_id].path);
	fprintf(MAPFILE, "\"name\" \"%s\"\n", UniqueObjectName(currobj));
	switch (currobj.npc_attitude)
		{
			case 0:	//hostile
				{
				fprintf(MAPFILE, "\"team\" \"5\"\n");	//Criminals team
				break;
				}
			default:
				{
				fprintf(MAPFILE, "\"team\" \"5\"\n");	//Beggars team
				break;
				}
		}

	//position
	fprintf(MAPFILE, "\"origin\" \"%f %f %f\"\n", x, y, z);
	//fprintf (MAPFILE, "\"animal_patrol\" \"1\"\n");	
	EntityRotation(currobj.heading);
	fprintf(MAPFILE, "}");
	EntityCount++;
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
			RenderEntity(game, x, y, z, tmpobj, objList, LevelInfo);	//Need to fix up the x y z to a better spot.
			tmpobj = objList[tmpobj.next];
			//I pass the owner info down the line
			tmpobj.objectOwner = currobj.objectOwner;
			tmpobj.objectOwnerName = currobj.objectOwnerName;
			tmpobj.objectOwnerEntity = currobj.objectOwnerEntity;
			tmpobj.joint = JointCount++;
			}
		RenderEntity(game, x, y, z, tmpobj, objList, LevelInfo); //NPC's inventory.

		}

	return;
	}

void RenderEntityNULL_TRIGGER(int game, float x, float y, float z, ObjectItem &currobj, ObjectItem objList[1600], tile LevelInfo[64][64])
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

	createScriptCall(currobj, x, y, z);
	}

void RenderEntityREPULSOR(int game, float x, float y, float z, ObjectItem &currobj, ObjectItem objList[1600], tile LevelInfo[64][64])
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
	fprintf(MAPFILE, "\n// entity %d\n{\n", EntityCount++);
	fprintf(MAPFILE, "\"classname\" \"%s\"\n", objectMasters[currobj.item_id].path);
	fprintf(MAPFILE, "\"name\" \"repulsor_%s\"\n", UniqueObjectName(currobj));
	fprintf(MAPFILE, "\"model\" \"repulsor_%s\"\n", UniqueObjectName(currobj));
	fprintf(MAPFILE, "\"target0\" \"repulsor_%s_target\"\n", UniqueObjectName(currobj));
	//int originZ = (CEILING_HEIGHT - LevelInfo[currobj.tileX][currobj.tileY].ceilingHeight) - LevelInfo[currobj.tileX][currobj.tileY].floorHeight- 8;
	int originZ = (currobj.State >> 3) * BrushSizeZ - LevelInfo[currobj.tileX][currobj.tileY].floorHeight;
	fprintf(MAPFILE, "\"origin\" \"%f %f %d\"\n", x, y, (originZ / 2));
	fprintf(MAPFILE, "\"applyVelocity\" \"1\"\n");
	fprintf(MAPFILE, "\"start_on\" \"1\"\n");
	tile t;	//temp tile for rendering trigger
	t.floorTexture = CAULK;
	t.wallTexture = CAULK;
	t.East = CAULK;
	t.West = CAULK;
	t.North = CAULK;
	t.South = CAULK;
	t.DimX = 1; t.DimY = 1;
	t.tileType = 1;
	t.Render = 1;
	t.floorHeight = LevelInfo[currobj.tileX][currobj.tileY].floorHeight;
	t.ceilingHeight = CEILING_HEIGHT - LevelInfo[currobj.tileX][currobj.tileY].ceilingHeight - 4;
	t.isWater = 0;
	t.hasElevator = 0;
	t.BullFrog = 0;
	RenderGenericTileAroundOrigin(0, 0, t, t.ceilingHeight, t.floorHeight, originZ);
	//RenderGenericTile(0,0,t,t.ceilingHeight,t.floorHeight );

	fprintf(MAPFILE, "\n}");
	//Now create a target for it.
	fprintf(MAPFILE, "\n// entity %d\n{\n", EntityCount++);
	fprintf(MAPFILE, "\"classname\" \"target_null\"\n", objectMasters[currobj.item_id].path);
	fprintf(MAPFILE, "\"name\" \"repulsor_%s_target\"\n", UniqueObjectName(currobj));
	//fprintf (MAPFILE, "\"origin\" \"%f %f %d\"\n",x,y,(CEILING_HEIGHT - LevelInfo[currobj.tileX][currobj.tileY].ceilingHeight - 1) * BrushSizeZ);
	fprintf(MAPFILE, "\"origin\" \"%f %f %d\"\n", x, y, (1 + (currobj.State >> 3))*BrushSizeZ);
	fprintf(MAPFILE, "\n}");

	//and a script object for controlling it.
	createScriptCall(currobj, x, y, z);
	}

void RenderEntitySIGN(int game, float x, float y, float z, ObjectItem &currobj, ObjectItem objList[1600], tile LevelInfo[64][64])
	{
	//A flat object with a gui that is a readable.
	//Params
	//tileX
	//tileY
	//Index
	//currobj.link -200 = pointer to the readable string block in UW
	//heading

	fprintf(MAPFILE, "\n// entity %d\n{\n", EntityCount);
	fprintf(MAPFILE, "\"classname\" \"%s\"\n", objectMasters[currobj.item_id].path);
	fprintf(MAPFILE, "\"name\" \"%s\"\n", UniqueObjectName(currobj));
	fprintf(MAPFILE, "\"hide\" \"%d\"\n", currobj.invis);
	//fprintf (MAPFILE, "\"xdata_contents\" \"readables/uw1/sign_%03d\"\n", currobj.link - 0x200);
	switch (game)
		{
			case UWDEMO:
			case UW1:
				fprintf(MAPFILE, "\"xdata_contents\" \"readables/uw1/sign_%03d\"\n", currobj.link - 0x200);
				fprintf(MAPFILE, "\"skin\" \"uw1_sign_%02d\"\n", currobj.flags & 0x7);
				break;
			case UW2:
				fprintf(MAPFILE, "\"xdata_contents\" \"readables/uw2/sign_%03d\"\n", currobj.link - 0x200);
				fprintf(MAPFILE, "\"skin\" \"uw2_sign_%02d\"\n", currobj.flags & 0x7);
				break;
			case SHOCK:
				{//TODO:Whatever needs to go here.
				//fprintf (MAPFILE, "\"xdata_contents\" \"readables/shock/sign_%03d\"\n", currobj.link - 0x200);
				break; }
		}
	fprintf(MAPFILE, "\"origin\" \"%f %f %f\"\n", x, y, z);
	fprintf(MAPFILE, "\"model\" \"models/darkmod/uw1/uw1_sign.ase\"\n");	//TODO:pass model path in.
	//switch (currobj.heading)	//TODO: need to fix this mess with headings.
	//{
	//case 0:
	//{EntityRotation(270); break; }
	//case 270:
	//{EntityRotation(0); break; }
	//default:
	//{EntityRotation(currobj.heading + 90); break; }
	//}
	EntityRotation(currobj.heading);
	AttachToJoint(currobj);		//for npc items
	fprintf(MAPFILE, "\n}");
	EntityCount++;
	return;
	}

void RenderEntityTMAP(int game, float x, float y, float z, ObjectItem &currobj, ObjectItem objList[1600], tile LevelInfo[64][64])
	{//Flat patch objects used as decals. This should be changed into something like a SHOCK screen model?
	//params
	//link	to see if it can be activated
	//tileX
	//tileY
	//index
	fprintf(MAPFILE, "\n// entity %d\n{\n", EntityCount);
	if (isTrigger(objList[currobj.link]) == 0)
		{
		fprintf(MAPFILE, "\"classname\" \"%s\"\n", objectMasters[currobj.item_id].path);
		}
	else
		{
		//object is a trigger
		fprintf(MAPFILE, "\"classname\" \"%s\"\n", "atdm:mover_button");	//TODO:Is there something better I can use than this.
		fprintf(MAPFILE, "\"target\" \"runscript_%s\"\n", UniqueObjectName(currobj));
		}
	fprintf(MAPFILE, "\"name\" \"%s\"\n", UniqueObjectName(currobj));
	fprintf(MAPFILE, "\"model\" \"%s\"\n", UniqueObjectName(currobj));
	//	fprintf(MAPFILE, "\"origin\" \"%f %f %f\"\n", x, y, z);
	fprintf(MAPFILE, "\"origin\" \"%d %d %f\"\n", currobj.tileX*BrushSizeX, currobj.tileY*BrushSizeY, z);
	fprintf(MAPFILE, "\"hide\" \"%d\"\n", currobj.invis);
	//Renders a patch to display the object
	RenderPatch(game, 0, 0, currobj.zpos, currobj.index, objList);
	fprintf(MAPFILE, "\n}\n");
	EntityCount++;
	if (isTrigger(objList[currobj.link]) == 1)
		{
		createScriptCall(currobj, x, y, z);
		}
	return;
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


void RenderEntityParticle(int game, float x, float y, float z, ObjectItem &currobj, ObjectItem objList[1600], tile LevelInfo[64][64], int bind)
	{
	fprintf(MAPFILE, "\n// entity %d\n{\n", EntityCount++);
	fprintf(MAPFILE, "\"classname\" \"%s\"\n", "func_emitter");
	if (bind == 1)
		{
		fprintf(MAPFILE, "\"name\" \"%s_particle\"\n", UniqueObjectName(currobj));
		fprintf(MAPFILE, "\"bind\" \"%s\"\n", UniqueObjectName(currobj));
		}
	else
		{
		fprintf(MAPFILE, "\"name\" \"%s\"\n", UniqueObjectName(currobj));
		}
	fprintf(MAPFILE, "\"model\" \"%s\"\n", objectMasters[currobj.item_id].particle);
	fprintf(MAPFILE, "\"origin\" \"%f %f %f\"\n", x, y, z + 12);
	fprintf(MAPFILE, "\"hide\" \"%d\"\n", currobj.invis);
	fprintf(MAPFILE, "\n}");
	}


void RenderEntityActivator(int game, float x, float y, float z, ObjectItem &currobj, ObjectItem objList[1600], tile LevelInfo[64][64])
	{//Something in the game world that can fire off events

	fprintf(MAPFILE, "\n// entity %d\n{\n", EntityCount);
	fprintf(MAPFILE, "\"classname\" \"%s\"\n", "atdm:mover_button");
	fprintf(MAPFILE, "\"name\" \"%s\"\n", UniqueObjectName(currobj));
	fprintf(MAPFILE, "\"model\" \"%s\"\n", objectMasters[currobj.item_id].base);

	//position
	fprintf(MAPFILE, "\"origin\" \"%f %f %f\"\n", x, y, z);
	fprintf(MAPFILE, "\"rotate\" \"0 0 1\"\n");
	fprintf(MAPFILE, "\"interruptable\" \"0\"\n");
	fprintf(MAPFILE, "\"hide\" \"%d\"\n", currobj.invis);

	fprintf(MAPFILE, "\"target\" \"runscript_%s\"\n", UniqueObjectName(currobj));
	EntityRotation(currobj.heading);

	fprintf(MAPFILE, "}\n"); EntityCount++;
	createScriptCall(currobj, x, y, z);	//To run whatever actions this switch performs.
	return;
	}


void RenderEntitySound(int game, float x, float y, float z, ObjectItem &currobj, ObjectItem objList[1600], tile LevelInfo[64][64], int bind)
	{
	fprintf(MAPFILE, "\n// entity %d\n{\n", EntityCount++);
	fprintf(MAPFILE, "\"classname\" \"%s\"\n", "speaker");
	if (bind == 1)
		{
		fprintf(MAPFILE, "\"name\" \"%s_sound\"\n", UniqueObjectName(currobj));
		fprintf(MAPFILE, "\"bind\" \"%s\"\n", UniqueObjectName(currobj));
		}
	else
		{
		fprintf(MAPFILE, "\"name\" \"%s_sound\"\n", UniqueObjectName(currobj));
		}
	fprintf(MAPFILE, "\"origin\" \"%f %f %f\"\n", x, y, z + 12);
	fprintf(MAPFILE, "\"s_shader\" \"%s\"\n", objectMasters[currobj.item_id].sound);
	fprintf(MAPFILE, "\"s_mindistance\" \"0\"\n");
	fprintf(MAPFILE, "\"s_maxdistance\" \"10\"\n");
	fprintf(MAPFILE, "\"s_looping\" \"1\"\n");

	fprintf(MAPFILE, "\n}");
	}

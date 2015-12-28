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
	//#include "gameobjectsrender.h"

void getWallTextureName(tile t, int face, short waterWall);
void getFloorTextureName(tile t, int face);
//void RenderPatch(int game, float x, float y, float z,long PatchIndex, ObjectItem objList[1600] );

 
//void CalcObjectXYZ(int game, float *offX,  float *offY, float *offZ, tile LevelInfo[64][64], ObjectItem objList[1600], long nextObj,int x,int y);

//void AddEmails(int game, tile LevelInfo[64][64], ObjectItem objList[1600]);

extern long SHOCK_CEILING_HEIGHT;
extern FILE *MAPFILE;

unsigned char *graves;

int GAME;

int keycount[256];	//For tracking key usage
//int levelNo;

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
			case ACTIVATOR:
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

void setKeyCount(int game, tile LevelInfo[64][64], ObjectItem objList[1600])
{
	//Each keey needs a unique name in game. Here we set the key index number on the key so that will work properly for scripting and map generation
	//int currobj;
	for (int i = 0; i < 1600; i++)
	{
		if ((objList[i].item_id >= 1) && (objList[i].item_id <= 1000))
		{
		
			if (objectMasters[objList[i].item_id].type == KEY)
			{
				if (game == SHOCK)
				{
					keycount[objList[i].ObjectSubClassIndex]++;
					objList[i].keyCount = keycount[objList[i].ObjectSubClassIndex];
					//fprintf(LOGFILE,"%s", UniqueObjectName(objList[i]));
				}
				else
				{
					keycount[objList[i].owner]++;
					objList[i].keyCount = keycount[objList[i].owner];
				}
			}
		}
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
		fprintf(LOGFILE,"\nBuildObjectListShock - Archive not found!\n");
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

	//fprintf(LOGFILE,"\nxref\tTileX\tTileY\tMst\tNext\tNextTile\n");
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
		//fprintf(LOGFILE,"%d\t%d\t%d\t%d\t%d\t%d\n",
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
			objList[MasterIndex].x = 0;
			objList[MasterIndex].y = 0;
			objList[MasterIndex].zpos =0;
			objList[MasterIndex].address=mstaddress_pointer;
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
					//	fprintf(LOGFILE,"\tIt is a %s", objectMasters[objList[MasterIndex].item_id].desc );

					objList[MasterIndex].sprite = getValAtAddress(mst_ark, mstaddress_pointer + 23, 8);
					objList[MasterIndex].State = getValAtAddress(mst_ark, mstaddress_pointer + 23, 8);
					objList[MasterIndex].unk1 = getValAtAddress(mst_ark, mstaddress_pointer + 24, 8);
					fprintf(LOGFILE,"\n++++++++Next object++++++++++++\n");
					fprintf(LOGFILE,"\nMaster Record at %d", blockAddress + mstaddress_pointer);
					fprintf(LOGFILE,"\nIndex = %d \n", objList[MasterIndex].index);
					fprintf(LOGFILE,"Desc %s\t", objectMasters[objList[MasterIndex].item_id].desc);
					fprintf(LOGFILE,"(%s)\n", UniqueObjectName(objList[MasterIndex]));
					fprintf(LOGFILE,"Class: %d,%d,%d\n", objList[MasterIndex].ObjectClass, objList[MasterIndex].ObjectSubClass, objList[MasterIndex].ObjectSubClassIndex);
					fprintf(LOGFILE,"Location = (%d", objList[MasterIndex].tileX);
					fprintf(LOGFILE,",%d", objList[MasterIndex].tileY);
					if (objList[MasterIndex].InUseFlag != 0)
					{
						fprintf(LOGFILE,", %d)\n	", LevelInfo[objList[MasterIndex].tileX][objList[MasterIndex].tileY].floorHeight);
					}
					else
					{
						fprintf(LOGFILE,")\n");
					}
					fprintf(LOGFILE,"InUse = %d\n", objList[MasterIndex].InUseFlag);
					fprintf(LOGFILE,"\tAIIndex = %d\n", getValAtAddress(mst_ark, mstaddress_pointer + 19, 8));
					fprintf(LOGFILE,"\tHitPoints = %d\n", getValAtAddress(mst_ark, mstaddress_pointer + 21, 16));

					//fprintf(LOGFILE,"\tunk1 = %d\n",getValAtAddress(mst_ark,mstaddress_pointer+24,8));
					//fprintf(LOGFILE,"\tunk2 = %d\n",getValAtAddress(mst_ark,mstaddress_pointer+25,8));
					//fprintf(LOGFILE,"\tunk3 = %d\n",getValAtAddress(mst_ark,mstaddress_pointer+26,8));				
					fprintf(LOGFILE,"\tXCoord= %d", getValAtAddress(mst_ark, mstaddress_pointer + 11, 8));
					//fprintf(LOGFILE,"\tXCoord high= %d\n",getValAtAddress(mst_ark,mstaddress_pointer+12,8)); same as tileX
					fprintf(LOGFILE,"\tYCoord= %d", getValAtAddress(mst_ark, mstaddress_pointer + 13, 8));
					//fprintf(LOGFILE,"\tYCoord high= %d\n",getValAtAddress(mst_ark,mstaddress_pointer+14,8)); same as tileY
					fprintf(LOGFILE,"\t(%d) ZCoord = %d\n", blockAddress + mstaddress_pointer + 15, getValAtAddress(mst_ark, mstaddress_pointer + 15, 8));
					fprintf(LOGFILE,"\tAngles = (%d", getValAtAddress(mst_ark, mstaddress_pointer + 16, 8));
					fprintf(LOGFILE,",%d", getValAtAddress(mst_ark, mstaddress_pointer + 17, 8));
					fprintf(LOGFILE,"\,%d)\n", getValAtAddress(mst_ark, mstaddress_pointer + 18, 8));
					fprintf(LOGFILE,"\tObjectType = %d\n", getValAtAddress(mst_ark, mstaddress_pointer + 20, 8));
					fprintf(LOGFILE,"\tHitPoints = %d\n", getValAtAddress(mst_ark, mstaddress_pointer + 21, 16));
					fprintf(LOGFILE,"\t(%d) State = %d", blockAddress + mstaddress_pointer+23, objList[MasterIndex].State);
					fprintf(LOGFILE,"\t(%d,%d)\n", (objList[MasterIndex].State >> 4) & 0xF, objList[MasterIndex].State & 0xF);
					fprintf(LOGFILE,"\tunk1 = %d", getValAtAddress(mst_ark, mstaddress_pointer + 24, 8));
					fprintf(LOGFILE,"\tunk2 = %d", getValAtAddress(mst_ark, mstaddress_pointer + 25, 8));
					fprintf(LOGFILE,"\tunk3 = %d\n", getValAtAddress(mst_ark, mstaddress_pointer + 26, 8));
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
					if (lookUpSubClass(archive_ark, LevelNo * 100 + SOFTWARE_LOGS_OFFSET, SOFTWARE_LOGS, SubClassLink, 9, xref, objList,texture_map, MasterIndex,LevelNo) == -1) { fprintf(LOGFILE,"\nNo properties found!\n"); }
					break;
					}
					case FIXTURES:
					{
					if (lookUpSubClass(archive_ark, LevelNo * 100 + FIXTURES_OFFSET, FIXTURES, SubClassLink, 16, xref, objList, texture_map, MasterIndex, LevelNo) == -1) { fprintf(LOGFILE, "\nNo properties found!\n"); }
					break;
					}
					case GETTABLES_OTHER:
						if (lookUpSubClass(archive_ark, LevelNo * 100 + GETTABLES_OTHER_OFFSET, GETTABLES_OTHER, SubClassLink, 16, xref, objList, texture_map, MasterIndex, LevelNo) == -1) { fprintf(LOGFILE, "\nNo properties found!\n"); }
					break;
					case SWITCHES_PANELS:
					{
					if (lookUpSubClass(archive_ark, LevelNo * 100 + SWITCHES_PANELS_OFFSET, SWITCHES_PANELS, SubClassLink, 30, xref, objList, texture_map, MasterIndex, LevelNo) == -1) { fprintf(LOGFILE, "\nNo properties found!\n"); }
					break;
					}
					case DOORS_GRATINGS:
					{
					if (lookUpSubClass(archive_ark, LevelNo * 100 + DOORS_GRATINGS_OFFSET, DOORS_GRATINGS, SubClassLink, 14, xref, objList, texture_map, MasterIndex, LevelNo) == -1) { fprintf(LOGFILE, "\nNo properties found!\n"); }
					break;
					}
					case ANIMATED:break;
					case TRAPS_MARKERS:
					{
					if (lookUpSubClass(archive_ark, LevelNo * 100 + TRAPS_MARKERS_OFFSET, TRAPS_MARKERS, SubClassLink, 28, xref, objList, texture_map, MasterIndex, LevelNo) == -1)  { fprintf(LOGFILE, "no properties found!"); }
					break;
					}
					case CONTAINERS_CORPSES:
						if (lookUpSubClass(archive_ark, LevelNo * 100 + CONTAINERS_CORPSES_OFFSET, CONTAINERS_CORPSES, SubClassLink, 21, xref, objList, texture_map, MasterIndex, LevelNo) == -1)  { fprintf(LOGFILE, "no properties found!"); }
					break;
					case CRITTERS:
						if (lookUpSubClass(archive_ark, LevelNo * 100 + CRITTERS_OFFSET, CRITTERS, SubClassLink, 46, xref, objList, texture_map, MasterIndex, LevelNo) == -1)  { fprintf(LOGFILE, "no properties found!"); }
						break;
					}
					UniqueObjectName(objList[MasterIndex]);
				}
				else
				{
					objList[MasterIndex].InUseFlag=0;
					fprintf(LOGFILE,"\n\nInvalid item id!!\n");
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

switch (game)
	{
	case UWDEMO:	//Underworld Demo
		{
		char UWdemoFileToOpen[255];
		sprintf_s(UWdemoFileToOpen, 255, "%s\\data\\level13.st", filePath);
		if ((file = fopen(UWdemoFileToOpen, "rb")) == NULL)
			{
			fprintf(LOGFILE, "Could not open specified file\n");
			return;
			}

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
			{
			fprintf(LOGFILE, "Could not open specified file\n");
			}
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
			{
			fprintf(LOGFILE, "Could not open specified file\n");
			return;
			}
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
			fprintf(LOGFILE,"\nInvalid block address!\n");
			return;
			}
		if (isCompressed == 1)
			{
			int datalen;
			lev_ark = unpackUW2(tmp_ark,getValAtAddress(tmp_ark,address_pointer,32),&datalen);
			}
		else
			{//
			int BlockStart = getValAtAddress(tmp_ark, address_pointer, 32);
			int j = 0;
			AddressOfBlockStart = 0;
			lev_ark = new unsigned char[0x7c08];
			for (int i = BlockStart; i < BlockStart + 0x7c08; i++)
			{
				lev_ark[j] = tmp_ark[i];
				j++;
			}
			}
		address_pointer=address_pointer+4;
		AddressOfBlockStart=0;	//since this array only contains that particular block
		objectsAddress=(64*64*4);
		address_pointer=0;

		
		break;
		}
		}
	}
	for (int x=0; x<1025;x++)
		{	//read in master object list
			objList[x].index = x; 
			objList[x].InUseFlag = 0;//Force off until I set tile x and tile y.
			objList[x].tileX=99;	//since we won't know what tile an object is in tile we have them all loaded and we can process the linked lists
			objList[x].tileY=99;
			objList[x].levelno = LevelNo ;	
			objList[x].next=0;
			objList[x].address = objectsAddress+address_pointer;
			//These three will get set when I am rendering the object entity and if the item is an npc's inventory.
			objList[x].objectOwner =0;
			objList[x].objectOwnerEntity =0;
			objList[x].joint =0 ;
			objList[x].objectConversion = 0;
			objList[x].invis = 0;
			objList[x].AlreadyRendered=0;
			//Object header.
			//if (x == 1015)
			//	{
			//	int val = getValAtAddress(lev_ark, objectsAddress + address_pointer + 0, 16);
				//printf("%d",val);
			//	}
			
			objList[x].item_id = (getValAtAddress(lev_ark,objectsAddress+address_pointer+0,16)) & 0x1FF;
			if ((objList[x].item_id >= 464) && ((game == UW1) || (game== UWDEMO)))//Fixed for bugged out of range items
				{
				objList[x].item_id=464;
				}
			//printf("Item ID %d %d\n",x, objList[x].item_id);
			objList[x].flags  = ((getValAtAddress(lev_ark,objectsAddress+address_pointer+0,16))>> 9) & 0x0F;
			objList[x].enchantment = ((getValAtAddress(lev_ark,objectsAddress+address_pointer+0,16)) >> 12) & 0x01;
			objList[x].doordir  = ((getValAtAddress(lev_ark,objectsAddress+address_pointer+0,16)) >> 13) & 0x01;
			objList[x].invis  = ((getValAtAddress(lev_ark,objectsAddress+address_pointer+0,16)) >> 14 )& 0x01;
			objList[x].is_quant = ((getValAtAddress(lev_ark,objectsAddress+address_pointer+0,16)) >> 15) & 0x01;

			//position at +2
			objList[x].zpos = (getValAtAddress(lev_ark,objectsAddress+address_pointer+2,16)) & 0x7F;	//bits 0-6 
			objList[x].heading =  45 * (((getValAtAddress(lev_ark,objectsAddress+address_pointer+2,16)) >> 7) & 0x07); //bits 7-9
			objList[x].y = ((getValAtAddress(lev_ark,objectsAddress+address_pointer+2,16)) >> 10) & 0x07;	//bits 10-12
			objList[x].x =((getValAtAddress(lev_ark,objectsAddress+address_pointer+2,16)) >> 13) & 0x07;	//bits 13-15
			
			//+4
			objList[x].quality =(getValAtAddress(lev_ark,objectsAddress+address_pointer+4,16)) & 0x3F;
			objList[x].next = (getValAtAddress(lev_ark,objectsAddress+address_pointer+4,16)>>6) & 0x3FF;
			
			//+6

			objList[x].owner = (getValAtAddress(lev_ark,objectsAddress+address_pointer+6,16) & 0x3F) ;//bits 0-5

			objList[x].link = (getValAtAddress(lev_ark, objectsAddress + address_pointer + 6, 16) >> 6 & 0x3FF); //bits 6-15

				if ((objectMasters[objList[x].item_id].type == TMAP_SOLID) || (objectMasters[objList[x].item_id].type == TMAP_CLIP))
					{
					objList[x].texture = texture_map[objList[x].owner];	//Sets the texture for tmap objects. I won't have access to the texture map later on.
					}
				if (objectMasters[objList[x].item_id].type == DOOR)
					{
					switch (game)
						{
							case UW1:
								if ((objList[x].item_id >= 328) && (objList[x].item_id <= 333))
									{//Open doors need to be adjusted down?
									objList[x].zpos-=24;
									}
								break;
						}
					}

				if (objectMasters[objList[x].item_id].type == BRIDGE)
					{
					
					if (objList[x].flags >= 2)
						{//267 + textureIndex;
						if (game == UW2)
							{
							objList[x].texture = texture_map[objList[x].flags - 2];	//Sets the texture for bridge
							}
						else
							{
							objList[x].texture =texture_map[objList[x].flags - 2 + 48];	//Sets the texture for bridge
							}
						}
					else
						{
						objList[x].texture = 267 + (objList[x].flags & 0x3F);//267 is an offset into my own textures config file.
						}
					}

				if (objectMasters[objList[x].item_id].type == BUTTON)
					{
					objList[x].texture = objList[x].flags;
					}

				if (objectMasters[objList[x].item_id].type == GRAVE)
					{
					objList[x].texture = objList[x].flags+28;
					if (objList[x].link >= 512)
						{
						objList[x].DeathWatched = getValAtAddress(graves, objList[x].link - 512, 8);
						}
					}
				if (objectMasters[objList[x].item_id].type == A_CREATE_OBJECT_TRAP)//Position the trap in the centre of the tile
					{
					objList[x].x = 4;
					objList[x].y = 4;
					}
				if (objectMasters[objList[x].item_id].type == A_CHANGE_TERRAIN_TRAP)
					{
					//bits 1-5 of the quality field is the floor texture.
					if (game == UW1)
						{
//TODO:Test this further
						/*int textureIndex;
						if (objList[x].quality > 15)
							{
							textureIndex= 48 + (objList[x].quality >> 2);
							}
						else
							{
							textureIndex = 48 + (objList[x].quality >> 1);
							
							}
		
						objList[x].texture = textureIndex;// texture_map[textureIndex];
*/

						int textureQuality = (objList[x].quality >> 1) & 0xf;
						if (textureQuality == 10)
							{
							//Weird glitch texture
							//textureQuality=-1;
							//textureQuality = textureQuality - 10;
							objList[x].texture = -1;
							}
						else if (textureQuality > 10)
							{
							//textureQuality=8;//Always seems to be this texture.
							//textureQuality = -1;//use the texture already there?
							objList[x].texture = -1;//texture_map[(textureQuality)+48];//-1 to reuse the existing texture
							}
						else
							{
							objList[x].texture = texture_map[(textureQuality)+48];
							}
						
						

						}					
					}

			//objList[x].special = objList[x].owner;
			//objList[x].link = objList[x].quantity;
			////fprintf(LOGFILE,"\n\tNext Object ID to this object is  %d", objList[x].next  );
			////fprintf(LOGFILE,"\n%d free object. Value 4=%d",x,getValAtAddress(lev_ark,AddressOfBlockStart+address_pointer+6,16));
			

			//cleanup of shock related stuff
			objList[x].SHOCKLocked = 0;
			////
			

		if (x<256)	
			{
			//mobile objects		
			objList[x].npc_hp = getValAtAddress(lev_ark, objectsAddress + address_pointer + 0x8, 8);
			
			objList[x].npc_goal = getValAtAddress(lev_ark, objectsAddress + address_pointer + 0xb, 16) & 0xF;
			objList[x].npc_gtarg = (getValAtAddress(lev_ark, objectsAddress + address_pointer + 11, 16)>>4 & 0xFF);

			objList[x].npc_level = getValAtAddress(lev_ark, objectsAddress + address_pointer + 0xd, 16) & 0xF;

			objList[x].npc_talkedto = (getValAtAddress(lev_ark, objectsAddress + address_pointer + 0xd, 16) >> 13 & 0x1);
			objList[x].npc_attitude = (getValAtAddress(lev_ark, objectsAddress + address_pointer + 0xd, 16) >> 14 & 0x3);
			
			//objList[x].npc_deathVariable=getValAtAddress(lev_ark, objectsAddress + address_pointer + 0x14,16) & 0xF;

			objList[x].npc_yhome = (getValAtAddress(lev_ark, objectsAddress + address_pointer + 0x16, 16) >> 4 & 0x3F);
			objList[x].npc_xhome = (getValAtAddress(lev_ark, objectsAddress + address_pointer + 0x16, 16) >> 10 & 0x3F);

			objList[x].npc_heading = (getValAtAddress(lev_ark, objectsAddress + address_pointer + 0x18, 16) >> 4 & 0xF);
			objList[x].npc_hunger = (getValAtAddress(lev_ark, objectsAddress + address_pointer + 0x19, 16) & 0x3F);

			objList[x].npc_whoami = getValAtAddress(lev_ark, objectsAddress + address_pointer + 0x1a, 8);
			//objList[x].npc_attitude = (getValAtAddress(lev_ark,objectsAddress+address_pointer+13,16) >> 14);

			////extra info //19 bytes
			//fprintf(LOGFILE,"\n\tFree extra inf. Value 5=%d",getValAtAddress(lev_ark,AddressOfBlockStart+address_pointer+8,8));
			//fprintf(LOGFILE,"\n\t\t free extra inf. Value 6=%d",getValAtAddress(lev_ark,AddressOfBlockStart+address_pointer+9,8));
			//fprintf(LOGFILE,"\n\t\t free extra inf. Value 7=%d",getValAtAddress(lev_ark,AddressOfBlockStart+address_pointer+10,8));
			//fprintf(LOGFILE,"\n\t\t free extra inf. Value 8=%d",getValAtAddress(lev_ark,AddressOfBlockStart+address_pointer+11,8));
			//fprintf(LOGFILE,"\n\t\t free extra inf. Value 9=%d",getValAtAddress(lev_ark,AddressOfBlockStart+address_pointer+12,8));
			//fprintf(LOGFILE,"\n\t\t free extra inf. Value 10=%d",getValAtAddress(lev_ark,AddressOfBlockStart+address_pointer+13,8));
			//fprintf(LOGFILE,"\n\t\t free extra inf. Value 11=%d",getValAtAddress(lev_ark,AddressOfBlockStart+address_pointer+14,8));
			//fprintf(LOGFILE,"\n\t\t free extra inf. Value 12=%d",getValAtAddress(lev_ark,AddressOfBlockStart+address_pointer+15,8));
			//fprintf(LOGFILE,"\n\t\t free extra inf. Value 13=%d",getValAtAddress(lev_ark,AddressOfBlockStart+address_pointer+16,8));
			//fprintf(LOGFILE,"\n\t\t free extra inf. Value 14=%d",getValAtAddress(lev_ark,AddressOfBlockStart+address_pointer+17,8));
			//fprintf(LOGFILE,"\n\t\t free extra inf. Value 15=%d",getValAtAddress(lev_ark,AddressOfBlockStart+address_pointer+18,8));
			//fprintf(LOGFILE,"\n\t\t free extra inf. Value 16=%d",getValAtAddress(lev_ark,AddressOfBlockStart+address_pointer+19,8));
			//fprintf(LOGFILE,"\n\t\t free extra inf. Value 17=%d",getValAtAddress(lev_ark,AddressOfBlockStart+address_pointer+20,8));
			//fprintf(LOGFILE,"\n\t\t free extra inf. Value 18=%d",getValAtAddress(lev_ark,AddressOfBlockStart+address_pointer+21,8));
			//fprintf(LOGFILE,"\n\t\t free extra inf. Value 19=%d",getValAtAddress(lev_ark,AddressOfBlockStart+address_pointer+22,8));
			//fprintf(LOGFILE,"\n\t\t free extra inf. Value 20=%d",getValAtAddress(lev_ark,AddressOfBlockStart+address_pointer+23,8));
			//fprintf(LOGFILE,"\n\t\t free extra inf. Value 21=%d",getValAtAddress(lev_ark,AddressOfBlockStart+address_pointer+24,8));
			//fprintf(LOGFILE,"\n\t\t free extra inf. Value 22=%d",getValAtAddress(lev_ark,AddressOfBlockStart+address_pointer+25,8));
			//fprintf(LOGFILE,"\n\t\t free extra inf. Value 23=%d",getValAtAddress(lev_ark,AddressOfBlockStart+address_pointer+26,8));

			address_pointer=address_pointer+8+19;
			}
		else
			{
			//Static Objects
			address_pointer=address_pointer+8;
			}
		}
}

int lookUpSubClass(unsigned char *archive_ark, int BlockNo, int ClassType, int index, int RecordSize, xrefTable *xRef, ObjectItem objList[1600], long texture_map[256], int objIndex, int levelNo)
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
	fprintf(LOGFILE,"\nLoading Chunk at %d\n",blockAddress);
	LoadShockChunk(blockAddress,chunkType,archive_ark,sub_ark,chunkPackedLength,chunkUnpackedLength);
	
	int k= 0;
int add_ptr=0;
//if (ClassType == CRITTERS)
//{
//for (int z = 0; z < chunkUnpackedLength; z = z + 2)
//{
//	fprintf(LOGFILE,"z=%d, %d\n",z, getValAtAddress(sub_ark, add_ptr + z, 8));
//}
//}
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
				fprintf(LOGFILE,"\tSoftware Properties\n");
				fprintf(LOGFILE,"\t\tVersion %d",objList[objIndex].shockProperties[SOFT_PROPERTY_VERSION]);
				fprintf(LOGFILE,"\tLog Chunk %d",objList[objIndex].shockProperties[SOFT_PROPERTY_LOG]);
				fprintf(LOGFILE,"\tLevel %d",objList[objIndex].shockProperties[SOFT_PROPERTY_LEVEL]);
				return 1;
				break;
				}
			case FIXTURES:
			{
				fprintf(LOGFILE,"\tFixture Properties\n");
				switch (objList[objIndex].ObjectSubClass)
				{
					case 0://regular fixtures
					case 1:
					case 3:
					case 4:
					case 5:
					case 6:
						fprintf(LOGFILE,"\n\tVal 0x6: %d", getValAtAddress(sub_ark, add_ptr + 6, 16));
						fprintf(LOGFILE,"\n\tVal 0x8: %d", getValAtAddress(sub_ark, add_ptr + 8, 16));
						fprintf(LOGFILE,"\n\tVal 0xA: %d", getValAtAddress(sub_ark, add_ptr + 0xA, 16));
						fprintf(LOGFILE,"\n\tVal 0xC: %d", getValAtAddress(sub_ark, add_ptr + 0xC, 16));
						fprintf(LOGFILE,"\n\tVal 0xE: %d", getValAtAddress(sub_ark, add_ptr + 0xE, 16));
						break;
					case 2:
						  switch (objList[objIndex].ObjectSubClassIndex)
						  {
						  case 0://SIGN
						  case 1://ICON
						  case 2://GRAFFITI
						  case 4://painting
						  case 5://poster
							  fprintf(LOGFILE,"\n\tImage to use is value in unk1. Offset from image 1350_0390.bmp or 1350_0403.bmp in objart.res or 0078_0000.bmp or 0079_0000 in objart3.res");
							  break;
						  case 3:
							  {
								  //based on SSHP interpretation
								  int fontID[4] = { 4, 7, 0, 10 };
								  float scale[4] = { 1.0, 0.75, 0.5, 0.25 };
								  fprintf(LOGFILE,"Words:");
								  objList[objIndex].shockProperties[WORDS_STRING_NO] = getValAtAddress(sub_ark, add_ptr + 6, 16);
								  fprintf(LOGFILE,"\nSub chunk %d (from chunk 2152)", getValAtAddress(sub_ark, add_ptr + 6, 16));
								  int FontNSize = getValAtAddress(sub_ark, add_ptr + 8, 16);
								  fprintf(LOGFILE,"\nFont %d (+chunk 602)", fontID[FontNSize & 0x03]);
								  objList[objIndex].shockProperties[WORDS_FONT] = fontID[FontNSize & 0x03] + 602;
								  fprintf(LOGFILE,"\nSize %d ", fontID[FontNSize>>4 & 0x03]);
								  objList[objIndex].shockProperties[WORDS_SIZE] = fontID[FontNSize >> 4 & 0x03];
								  fprintf(LOGFILE,"\nColour %d ", getValAtAddress(sub_ark, add_ptr + 0xA, 16));
								  objList[objIndex].shockProperties[WORDS_COLOUR] = getValAtAddress(sub_ark, add_ptr + 0xA, 16);
								  fprintf(LOGFILE,"\n\tVal 0x6: %d", getValAtAddress(sub_ark, add_ptr + 6, 16));
								  fprintf(LOGFILE,"\n\tVal 0x8: %d", getValAtAddress(sub_ark, add_ptr + 8, 16));
								  fprintf(LOGFILE,"\n\tVal 0xA: %d", getValAtAddress(sub_ark, add_ptr + 0xA, 16));
								  fprintf(LOGFILE,"\n\tVal 0xC: %d", getValAtAddress(sub_ark, add_ptr + 0xC, 16));
								  fprintf(LOGFILE,"\n\tVal 0xE: %d", getValAtAddress(sub_ark, add_ptr + 0xE, 16));
								  break;
							  }
						  case 6:
						  case 8:
						  case 9:
							  fprintf(LOGFILE,"Screens:");
							  objList[objIndex].shockProperties[SCREEN_NO_OF_FRAMES] = getValAtAddress(sub_ark, add_ptr + 6, 16);
							  objList[objIndex].shockProperties[SCREEN_LOOP_FLAG] = getValAtAddress(sub_ark, add_ptr + 8, 16);
							  objList[objIndex].shockProperties[SCREEN_START] = getValAtAddress(sub_ark, add_ptr + 0xC, 16);
							  fprintf(LOGFILE,"\nNo of Frames: %d", objList[objIndex].shockProperties[SCREEN_NO_OF_FRAMES]);
							  fprintf(LOGFILE,"\nLoop repeats: %d ", objList[objIndex].shockProperties[SCREEN_LOOP_FLAG]);
							  fprintf(LOGFILE,"\nStart Frame: %d (from chunk 321) = %d", objList[objIndex].shockProperties[SCREEN_START], 321 + objList[objIndex].shockProperties[SCREEN_START]);
							  if ((objList[objIndex].shockProperties[SCREEN_START] >= 248) && (objList[objIndex].shockProperties[SCREEN_START] <= 255))
								  {//Survellance
								  unsigned char *sur_ark;
								  blockAddress = getShockBlockAddress(levelNo * 100 + SURVELLANCE_OFFSET, archive_ark, &chunkPackedLength, &chunkUnpackedLength, &chunkType);
								  if (blockAddress != -1) 
									  {
									  sur_ark = new unsigned char[chunkUnpackedLength];
									  fprintf(LOGFILE, "\n\tSurvellance Chunk at %d\n", blockAddress);
									  LoadShockChunk(blockAddress, chunkType, archive_ark, sur_ark, chunkPackedLength, chunkUnpackedLength);
									  objList[objIndex].shockProperties[SCREEN_SURVEILLANCE_TARGET] = getValAtAddress(sur_ark, (objList[objIndex].shockProperties[SCREEN_START]-248)*2, 16);
									  fprintf(LOGFILE, "\tSurveillance item id: %d", objList[objIndex].shockProperties[SCREEN_SURVEILLANCE_TARGET]);
									  }
								  }
							  break;
						  default:
							  fprintf(LOGFILE,"\n\tVal 0x6: %d", getValAtAddress(sub_ark, add_ptr + 6, 16));
							  fprintf(LOGFILE,"\n\tVal 0x8: %d", getValAtAddress(sub_ark, add_ptr + 8, 16));
							  fprintf(LOGFILE,"\n\tVal 0xA: %d", getValAtAddress(sub_ark, add_ptr + 0xA, 16));
							  fprintf(LOGFILE,"\n\tVal 0xC: %d", getValAtAddress(sub_ark, add_ptr + 0xC, 16));
							  fprintf(LOGFILE,"\n\tVal 0xE: %d", getValAtAddress(sub_ark, add_ptr + 0xE, 16));
							  break;
						  }
						break;
					case 7:	//bridges etc
						int val = getValAtAddress(sub_ark, add_ptr + 0x8, 8);
						objList[objIndex].shockProperties[BRIDGE_X_SIZE] = val & 0xF;
						objList[objIndex].shockProperties[BRIDGE_Y_SIZE] = (val >>4) & 0xF;
						objList[objIndex].shockProperties[BRIDGE_HEIGHT] = getValAtAddress(sub_ark, add_ptr + 0x9, 8);
						val = getValAtAddress(sub_ark, add_ptr + 0xA, 8);
						objList[objIndex].shockProperties[BRIDGE_TOP_BOTTOM_TEXTURE_SOURCE] = (val >> 7) & 0x1;
						if (objList[objIndex].shockProperties[BRIDGE_TOP_BOTTOM_TEXTURE_SOURCE]==1)//Retrieve from texture map
							{
							objList[objIndex].shockProperties[BRIDGE_TOP_BOTTOM_TEXTURE] = texture_map[val & 0x7F];
							}
						else
							{
							objList[objIndex].shockProperties[BRIDGE_TOP_BOTTOM_TEXTURE] = val & 0x7F;
							}
						
						val = getValAtAddress(sub_ark, add_ptr + 0xB, 8);
						objList[objIndex].shockProperties[BRIDGE_SIDE_TEXTURE_SOURCE] = (val >> 7) & 0x1;
						if (objList[objIndex].shockProperties[BRIDGE_SIDE_TEXTURE_SOURCE] == 1)//Retrieve from texture map
							{
							objList[objIndex].shockProperties[BRIDGE_SIDE_TEXTURE] = texture_map[val & 0x7F];
							}
						else
							{
							objList[objIndex].shockProperties[BRIDGE_SIDE_TEXTURE] = val & 0x7F;
							}
						fprintf(LOGFILE, "\n\tBridge X Size : %d", objList[objIndex].shockProperties[BRIDGE_X_SIZE]);
						fprintf(LOGFILE, "\n\tBridge Y Size : %d", objList[objIndex].shockProperties[BRIDGE_Y_SIZE]);
						fprintf(LOGFILE, "\n\tBridge Height : %d", objList[objIndex].shockProperties[BRIDGE_HEIGHT]);
						fprintf(LOGFILE, "\n\tBridge Top Texture : %d", objList[objIndex].shockProperties[BRIDGE_TOP_BOTTOM_TEXTURE]);
						fprintf(LOGFILE, "\n\tBridge Top Texture Source : %d", objList[objIndex].shockProperties[BRIDGE_TOP_BOTTOM_TEXTURE_SOURCE]);
						fprintf(LOGFILE, "\n\tBridge Side Texture : %d", objList[objIndex].shockProperties[BRIDGE_SIDE_TEXTURE]);
						fprintf(LOGFILE, "\n\tBridge Side Texture Source : %d", objList[objIndex].shockProperties[BRIDGE_SIDE_TEXTURE_SOURCE]);

						/*fprintf(LOGFILE,"\n\tVal 0x6: %d", getValAtAddress(sub_ark, add_ptr + 6, 16));
						fprintf(LOGFILE,"\n\tVal 0x8: %d", getValAtAddress(sub_ark, add_ptr + 8, 16));
						fprintf(LOGFILE,"\n\tVal 0xA: %d", getValAtAddress(sub_ark, add_ptr + 0xA, 16));
						fprintf(LOGFILE,"(%d", getValAtAddress(sub_ark, add_ptr + 0xA, 8));
						fprintf(LOGFILE,",%d)", getValAtAddress(sub_ark, add_ptr + 0xB, 8));
						fprintf(LOGFILE,"\n\tVal 0xC: %d", getValAtAddress(sub_ark, add_ptr + 0xC, 16));
						fprintf(LOGFILE,"\n\tVal 0xE: %d", getValAtAddress(sub_ark, add_ptr + 0xE, 16));*/
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
					fprintf(LOGFILE,"\tContents 1 : %d\n", objList[objIndex].shockProperties[CONTAINER_CONTENTS_1]);
					fprintf(LOGFILE,"\tContents 2 : %d\n", objList[objIndex].shockProperties[CONTAINER_CONTENTS_2]);
					fprintf(LOGFILE,"\tContents 3 : %d\n", objList[objIndex].shockProperties[CONTAINER_CONTENTS_3]);
					fprintf(LOGFILE,"\tContents 4 : %d\n", objList[objIndex].shockProperties[CONTAINER_CONTENTS_4]);
					}
			
				for (int j = 0; j < RecordSize; j = j + 2)
					{
						fprintf(LOGFILE,"j=%d val(16) = %d\n", j, getValAtAddress(sub_ark, add_ptr+ j, 16));
					}

				return 1;
				break;
				}
			case SWITCHES_PANELS:
				{
				fprintf(LOGFILE,"\n\tSwitch Properties\n");
				fprintf(LOGFILE,"\t\tSwitch Action?:%d",getValAtAddress(sub_ark,add_ptr+6,16));
				fprintf(LOGFILE,"\tVariable:%d",getValAtAddress(sub_ark,add_ptr+8,16));
				fprintf(LOGFILE,"\tFail Message:%d",getValAtAddress(sub_ark,add_ptr+10,16));
				objList[objIndex].TriggerAction = getValAtAddress(sub_ark,add_ptr+6,16);
				getShockButtons(LevelInfo,sub_ark,add_ptr,objList,objIndex);
				return 1;
				break;
				}
			case DOORS_GRATINGS:
				{
				fprintf(LOGFILE,"\n\tDoor Properties\n");
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

				fprintf(LOGFILE,"\t\tTrigger xref?:%d (%d)", xRef[crossref].MstIndex, crossref);
				fprintf(LOGFILE,"\tMessage:%d", getValAtAddress(sub_ark, add_ptr + 8, 16));
				fprintf(LOGFILE,"\tAccess Required:%d", getValAtAddress(sub_ark, add_ptr + 0xA, 8));
				fprintf(LOGFILE, "\tOther val:%d\n", getValAtAddress(sub_ark, add_ptr + 0xB, 16));
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
					fprintf(LOGFILE,"\tConditions: %d",objList[objIndex].conditions[0]);
					fprintf(LOGFILE,",%d",objList[objIndex].conditions[1]);
					fprintf(LOGFILE,",%d",objList[objIndex].conditions[2]);
					fprintf(LOGFILE,",%d\n",objList[objIndex].conditions[3]);
					fprintf(LOGFILE,"\tTrigger once: %d\n",objList[objIndex].TriggerOnce);
					objList[objIndex].address = blockAddress+add_ptr;
					fprintf(LOGFILE,"\tObject is at address %d\n", objList[objIndex].address);
					if (objectMasters[objList[objIndex].item_id].type == SHOCK_TRIGGER_REPULSOR)
						{
						objList[objIndex].shockProperties[TRIG_PROPERTY_VALUE] = getValAtAddress(sub_ark, add_ptr + 21, 8);
						objList[objIndex].shockProperties[TRIG_PROPERTY_FLAG] = getValAtAddress(sub_ark, add_ptr + 24, 8);
						fprintf(LOGFILE,"\tRepulsor Upwards Displacement is %d\n", objList[objIndex].shockProperties[TRIG_PROPERTY_VALUE]);
						if (objList[objIndex].shockProperties[TRIG_PROPERTY_FLAG] == 1)
							{
							fprintf(LOGFILE,"\tRepulsor is off (%d)\n", objList[objIndex].shockProperties[TRIG_PROPERTY_FLAG]);
							}
						else
							{
							fprintf(LOGFILE,"\tRepulsor is on (%d)\n", objList[objIndex].shockProperties[TRIG_PROPERTY_FLAG]);
							}
						}
					else
						{
						getShockTriggerAction(LevelInfo, sub_ark, add_ptr, xRef, objList, objIndex);
						}
				

				return 1;
				break;
			case CONTAINERS_CORPSES:
				fprintf(LOGFILE,"\n\tContainer Properties\n");
				objList[objIndex].shockProperties[CONTAINER_CONTENTS_1] = getValAtAddress(sub_ark, add_ptr + 0x6, 16);
				objList[objIndex].shockProperties[CONTAINER_CONTENTS_2] = getValAtAddress(sub_ark, add_ptr + 0x8, 16);
				objList[objIndex].shockProperties[CONTAINER_CONTENTS_3] = getValAtAddress(sub_ark, add_ptr + 0xA, 16);
				objList[objIndex].shockProperties[CONTAINER_CONTENTS_4] = getValAtAddress(sub_ark, add_ptr + 0xC, 16);
				objList[objIndex].shockProperties[CONTAINER_WIDTH] = getValAtAddress(sub_ark, add_ptr + 0xE, 8);
				objList[objIndex].shockProperties[CONTAINER_HEIGHT] = getValAtAddress(sub_ark, add_ptr + 0xF, 8);
				objList[objIndex].shockProperties[CONTAINER_DEPTH] = getValAtAddress(sub_ark, add_ptr + 0x10, 8);
				objList[objIndex].shockProperties[CONTAINER_TOP] = getValAtAddress(sub_ark, add_ptr + 0x11, 8);
				objList[objIndex].shockProperties[CONTAINER_SIDE] = getValAtAddress(sub_ark, add_ptr + 0x12, 8);
				fprintf(LOGFILE,"\tContents 1 : %d\n", objList[objIndex].shockProperties[CONTAINER_CONTENTS_1]);
				fprintf(LOGFILE,"\tContents 2 : %d\n", objList[objIndex].shockProperties[CONTAINER_CONTENTS_2]);
				fprintf(LOGFILE,"\tContents 3 : %d\n", objList[objIndex].shockProperties[CONTAINER_CONTENTS_3]);
				fprintf(LOGFILE,"\tContents 4 : %d\n", objList[objIndex].shockProperties[CONTAINER_CONTENTS_4]);
				fprintf(LOGFILE,"\tWidth : %d", objList[objIndex].shockProperties[CONTAINER_WIDTH]);
				fprintf(LOGFILE,"\tHeight : %d", objList[objIndex].shockProperties[CONTAINER_HEIGHT]);
				fprintf(LOGFILE,"\tDepth : %d\n", objList[objIndex].shockProperties[CONTAINER_DEPTH]);
				fprintf(LOGFILE,"\tTop : %d", objList[objIndex].shockProperties[CONTAINER_TOP]);
				fprintf(LOGFILE,"\tSide : %d", objList[objIndex].shockProperties[CONTAINER_SIDE]);
				return 1;
				break;
				}
			case CRITTERS:
				fprintf(LOGFILE,"\Critter Properties\n");
				for (int j = 0; j < RecordSize; j = j + 2)
				{
					fprintf(LOGFILE,"\tj=%d val(16) = %d\n", j, getValAtAddress(sub_ark, add_ptr + j, 16));
				}
				return 1;
				break;
			}
		}
	add_ptr+=RecordSize;
	k++;
	}
return -1;
}

void getShockTriggerAction(tile LevelInfo[64][64],unsigned char *sub_ark,int add_ptr, xrefTable *xRef, ObjectItem objList[1600], int objIndex)
{
//Look up what a trigger does in system shock. Different trigger types activate other triggers/ do things in different ways.
short PrintDebug = 1;// (objList[objIndex].item_id == 384);
fprintf(LOGFILE,"",UniqueObjectName(objList[objIndex]));	//Weirdness with garbage info getting printed out?
int TriggerType =getValAtAddress(sub_ark,add_ptr+6,8);
objList[objIndex].TriggerAction = TriggerType;
switch (TriggerType)
	{ 
	case ACTION_DO_NOTHING :
		{//Default action.
		if (PrintDebug==1)
			{
			fprintf(LOGFILE,"\tACTION_DO_NOTHING or default for %s\n",UniqueObjectName(objList[objIndex]));
			DebugPrintTriggerVals(sub_ark, add_ptr,28);
			//fprintf(LOGFILE,"\t\tOther values 1:%d\n",getValAtAddress(sub_ark,add_ptr+12,16));
			//fprintf(LOGFILE,"\t\tOther values 2:%d\n",getValAtAddress(sub_ark,add_ptr+14,16));
			//fprintf(LOGFILE,"\t\tOther values 3:%d\n",getValAtAddress(sub_ark,add_ptr+16,16));
			//fprintf(LOGFILE,"\t\tOther values 4:%d\n",getValAtAddress(sub_ark,add_ptr+18,16));
			//fprintf(LOGFILE,"\t\tOther values 5:%d\n",getValAtAddress(sub_ark,add_ptr+20,16));
			//fprintf(LOGFILE,"\t\tOther values 6:%d\n",getValAtAddress(sub_ark,add_ptr+22,16));		
			//fprintf(LOGFILE,"\t\tOther values 7:%d\n",getValAtAddress(sub_ark,add_ptr+24,16));		
			//fprintf(LOGFILE,"\t\tOther values 8:%d\n",getValAtAddress(sub_ark,add_ptr+26,16));	
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
			fprintf(LOGFILE,"\tACTION_TRANSPORT_LEVEL for %s\n",UniqueObjectName(objList[objIndex]));
			fprintf(LOGFILE,"\t\tDestination (%d,%d,%d)\n",objList[objIndex].shockProperties[TRIG_PROPERTY_TARGET_X], objList[objIndex].shockProperties[TRIG_PROPERTY_TARGET_Y],objList[objIndex].shockProperties[TRIG_PROPERTY_TARGET_Z] );
			DebugPrintTriggerVals(sub_ark, add_ptr, 28);
			//fprintf(LOGFILE,"\t\tOther values 1:%d\n",getValAtAddress(sub_ark,add_ptr+12,16));
			//fprintf(LOGFILE,"\t\tOther values 2:%d\n",getValAtAddress(sub_ark,add_ptr+14,16));
			//fprintf(LOGFILE,"\t\tOther values 3:%d\n",getValAtAddress(sub_ark,add_ptr+16,16));
			//fprintf(LOGFILE,"\t\tOther values 4:%d\n",getValAtAddress(sub_ark,add_ptr+18,16));
			//fprintf(LOGFILE,"\t\tOther values 5:%d\n",getValAtAddress(sub_ark,add_ptr+20,16));
			//fprintf(LOGFILE,"\t\tOther values 6:%d\n",getValAtAddress(sub_ark,add_ptr+22,16));		
			//fprintf(LOGFILE,"\t\tOther values 7:%d\n",getValAtAddress(sub_ark,add_ptr+24,16));		
			//fprintf(LOGFILE,"\t\tOther values 8:%d\n",getValAtAddress(sub_ark,add_ptr+26,16));	
			}		
		break;
		}
	case ACTION_RESURRECTION:
		{//Brings the player back to life?
		if (PrintDebug==1)
			{
			fprintf(LOGFILE,"\tACTION_RESURRECTION for %s\n",UniqueObjectName(objList[objIndex]));
			DebugPrintTriggerVals(sub_ark, add_ptr,30);
			//fprintf(LOGFILE,"\t\tOther values 1:%d\n",getValAtAddress(sub_ark,add_ptr+12,16));
			//fprintf(LOGFILE,"\t\tOther values 2:%d\n",getValAtAddress(sub_ark,add_ptr+14,16));
			//fprintf(LOGFILE,"\t\tOther values 3:%d\n",getValAtAddress(sub_ark,add_ptr+16,16));
			//fprintf(LOGFILE,"\t\tOther values 4:%d\n",getValAtAddress(sub_ark,add_ptr+18,16));
			//fprintf(LOGFILE,"\t\tOther values 5:%d\n",getValAtAddress(sub_ark,add_ptr+20,16));
			//fprintf(LOGFILE,"\t\tOther values 6:%d\n",getValAtAddress(sub_ark,add_ptr+22,16));		
			//fprintf(LOGFILE,"\t\tOther values 7:%d\n",getValAtAddress(sub_ark,add_ptr+24,16));		
			//fprintf(LOGFILE,"\t\tOther values 8:%d\n",getValAtAddress(sub_ark,add_ptr+26,16));	
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
			fprintf(LOGFILE,"\tACTION_CLONE for %s\n",UniqueObjectName(objList[objIndex]));
			fprintf(LOGFILE,"\t\tObject to transport:%d\n",getValAtAddress(sub_ark,add_ptr+0xC,16));
			fprintf(LOGFILE,"\t\tDeleteFlag?:%d\n",getValAtAddress(sub_ark,add_ptr+0xE,16));
			fprintf(LOGFILE,"\t\tDestination tileX:%d\n",getValAtAddress(sub_ark,add_ptr+0x10,16));
			fprintf(LOGFILE,"\t\tDestination tileY:%d\n",getValAtAddress(sub_ark,add_ptr+0x14,16));
			fprintf(LOGFILE,"\t\tDestination height:%d\n",getValAtAddress(sub_ark,add_ptr+0x18,16));
			DebugPrintTriggerVals(sub_ark, add_ptr, 28);
			//fprintf(LOGFILE,"\t\tOther values 1:%d\n",getValAtAddress(sub_ark,add_ptr+12,16));
			//fprintf(LOGFILE,"\t\tOther values 2:%d\n",getValAtAddress(sub_ark,add_ptr+14,16));
			//fprintf(LOGFILE,"\t\tOther values 3:%d\n",getValAtAddress(sub_ark,add_ptr+16,16));
			//fprintf(LOGFILE,"\t\tOther values 4:%d\n",getValAtAddress(sub_ark,add_ptr+18,16));
			//fprintf(LOGFILE,"\t\tOther values 5:%d\n",getValAtAddress(sub_ark,add_ptr+20,16));
			//fprintf(LOGFILE,"\t\tOther values 6:%d\n",getValAtAddress(sub_ark,add_ptr+22,16));		
			//fprintf(LOGFILE,"\t\tOther values 7:%d\n",getValAtAddress(sub_ark,add_ptr+24,16));		
			//fprintf(LOGFILE,"\t\tOther values 8:%d\n",getValAtAddress(sub_ark,add_ptr+26,16));	

			
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
					fprintf(LOGFILE,"\tACTION_SET_VARIABLE for %s\n",UniqueObjectName(objList[objIndex]));
					fprintf(LOGFILE,"\t\tVariable to Set:%d\n",getValAtAddress(sub_ark,add_ptr+0xC,16));
					fprintf(LOGFILE,"\t\tValue:%d",getValAtAddress(sub_ark,add_ptr+0x10,16));
					fprintf(LOGFILE,"\t\taction?:%d (00 set 01 add)\n",getValAtAddress(sub_ark,add_ptr+0x12,16));
					fprintf(LOGFILE,"\t\tOptional Message:%d\n",getValAtAddress(sub_ark,add_ptr+0x14,16));
					DebugPrintTriggerVals(sub_ark, add_ptr, 28);
/*					fprintf(LOGFILE,"\t\tOther values 1:%d\n",getValAtAddress(sub_ark,add_ptr+12,16));
					fprintf(LOGFILE,"\t\tOther values 2:%d\n",getValAtAddress(sub_ark,add_ptr+14,16));
					fprintf(LOGFILE,"\t\tOther values 3:%d\n",getValAtAddress(sub_ark,add_ptr+16,16));
					fprintf(LOGFILE,"\t\tOther values 4:%d\n",getValAtAddress(sub_ark,add_ptr+18,16));
					fprintf(LOGFILE,"\t\tOther values 5:%d\n",getValAtAddress(sub_ark,add_ptr+20,16));
					fprintf(LOGFILE,"\t\tOther values 6:%d\n",getValAtAddress(sub_ark,add_ptr+22,16));		
					fprintf(LOGFILE,"\t\tOther values 7:%d\n",getValAtAddress(sub_ark,add_ptr+24,16));		
					fprintf(LOGFILE,"\t\tOther values 8:%d\n",getValAtAddress(sub_ark,add_ptr+26,16));	*/					
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
			fprintf(LOGFILE,"\tACTION_ACTIVATE for %s\n",UniqueObjectName(objList[objIndex]));

			fprintf(LOGFILE,"\t\t1st Object to activate raw :%d\t",objList[objIndex].shockProperties[0]);
			fprintf(LOGFILE,"1st Object Delay:%d\n",objList[objIndex].shockProperties[1]);

			fprintf(LOGFILE,"\t\t2nd Object to activate raw :%d\t",objList[objIndex].shockProperties[2]);		
			fprintf(LOGFILE,"2nd Object Delay:%d\n",objList[objIndex].shockProperties[3]);
			
			fprintf(LOGFILE,"\t\t3rd Object to activate raw :%d\t",objList[objIndex].shockProperties[4]);
			fprintf(LOGFILE,"3rd Object Delay:%d\n",objList[objIndex].shockProperties[5]);
			
			fprintf(LOGFILE,"\t\t4th Object to activate raw :%d\t",objList[objIndex].shockProperties[6]);		
			fprintf(LOGFILE,"4th Object Delay:%d\n",objList[objIndex].shockProperties[7]);	
			DebugPrintTriggerVals(sub_ark, add_ptr, 28);
/*			fprintf(LOGFILE,"\t\tOther values 1:%d\n",getValAtAddress(sub_ark,add_ptr+12,16));
			fprintf(LOGFILE,"\t\tOther values 2:%d\n",getValAtAddress(sub_ark,add_ptr+14,16));
			fprintf(LOGFILE,"\t\tOther values 3:%d\n",getValAtAddress(sub_ark,add_ptr+16,16));
			fprintf(LOGFILE,"\t\tOther values 4:%d\n",getValAtAddress(sub_ark,add_ptr+18,16));
			fprintf(LOGFILE,"\t\tOther values 5:%d\n",getValAtAddress(sub_ark,add_ptr+20,16));
			fprintf(LOGFILE,"\t\tOther values 6:%d\n",getValAtAddress(sub_ark,add_ptr+22,16));		
			fprintf(LOGFILE,"\t\tOther values 7:%d\n",getValAtAddress(sub_ark,add_ptr+24,16));		
			fprintf(LOGFILE,"\t\tOther values 8:%d\n",getValAtAddress(sub_ark,add_ptr+26,16));	*/						
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
		objList[objIndex].shockProperties[TRIG_PROPERTY_LIGHT_OP] = getValAtAddress(sub_ark, add_ptr + 16, 16);
		objList[objIndex].shockProperties[TRIG_PROPERTY_UPPERSHADE_1] = getValAtAddress(sub_ark, add_ptr + 22, 8);//22,24,23,25
		objList[objIndex].shockProperties[TRIG_PROPERTY_LOWERSHADE_1] = getValAtAddress(sub_ark, add_ptr + 23, 8);
		objList[objIndex].shockProperties[TRIG_PROPERTY_UPPERSHADE_2] = getValAtAddress(sub_ark, add_ptr + 24, 8);
		objList[objIndex].shockProperties[TRIG_PROPERTY_LOWERSHADE_2] = getValAtAddress(sub_ark, add_ptr + 25, 8);
		if (PrintDebug==1)
			{
			fprintf(LOGFILE,"\tACTION_LIGHTING for %s\n",UniqueObjectName(objList[objIndex]));
			fprintf(LOGFILE,"\t\t(%d)Lighting Operation: %d\n", objList[objIndex].address+16, objList[objIndex].shockProperties[TRIG_PROPERTY_LIGHT_OP]);
			fprintf(LOGFILE,"\t\tControl point 1:%d\n",objList[objIndex].shockProperties[TRIG_PROPERTY_CONTROL_1]);
			fprintf(LOGFILE,"\t\tControl point 2:%d\n", objList[objIndex].shockProperties[TRIG_PROPERTY_CONTROL_2]);
			fprintf(LOGFILE,"\t\t(%d)Not used? Upper Shade adjustment = %d\n", objList[objIndex].address +22, objList[objIndex].shockProperties[TRIG_PROPERTY_UPPERSHADE_1]);
			fprintf(LOGFILE,"\t\t(%d)Not used? Lower Shade adjustment = %d\n", objList[objIndex].address +23 ,objList[objIndex].shockProperties[TRIG_PROPERTY_LOWERSHADE_1]);
			fprintf(LOGFILE,"\t\t(%d)Upper Shade adjustment = %d\n", objList[objIndex].address +24 ,objList[objIndex].shockProperties[TRIG_PROPERTY_UPPERSHADE_2]);
			fprintf(LOGFILE,"\t\t(%d)Lower Shade adjustment = %d\n", objList[objIndex].address +25 ,objList[objIndex].shockProperties[TRIG_PROPERTY_LOWERSHADE_2]);
			DebugPrintTriggerVals(sub_ark, add_ptr, 28);
			//fprintf(LOGFILE,"\t\tOther values 1:%d\n",getValAtAddress(sub_ark,add_ptr+12,16));
			//fprintf(LOGFILE,"\t\tOther values 2:%d\n",getValAtAddress(sub_ark,add_ptr+14,16));
			//fprintf(LOGFILE,"\t\tOther values 3:%d\n",getValAtAddress(sub_ark,add_ptr+16,16));
			//fprintf(LOGFILE,"\t\tOther values 4:%d\n",getValAtAddress(sub_ark,add_ptr+18,16));
			//fprintf(LOGFILE,"\t\tOther values 5:%d\n",getValAtAddress(sub_ark,add_ptr+20,16));
			//fprintf(LOGFILE,"\t\tOther values 6:%d\n",getValAtAddress(sub_ark,add_ptr+22,16));		
			//fprintf(LOGFILE,"\t\tOther values 7:%d\n",getValAtAddress(sub_ark,add_ptr+24,16));		
			//fprintf(LOGFILE,"\t\tOther values 8:%d\n",getValAtAddress(sub_ark,add_ptr+26,16));	
		}			
		break;
		}
	case ACTION_EFFECT:
		{//Preforms a special effect. One example is the power breaker sparking on research level.
		if (PrintDebug==1)
			{
			fprintf(LOGFILE,"\tACTION_EFFECT for %s\n",UniqueObjectName(objList[objIndex]));
			DebugPrintTriggerVals(sub_ark, add_ptr, 28);
			//fprintf(LOGFILE,"\t\tOther values 1:%d\n",getValAtAddress(sub_ark,add_ptr+12,16));
			//fprintf(LOGFILE,"\t\tOther values 2:%d\n",getValAtAddress(sub_ark,add_ptr+14,16));
			//fprintf(LOGFILE,"\t\tOther values 3:%d\n",getValAtAddress(sub_ark,add_ptr+16,16));
			//fprintf(LOGFILE,"\t\tOther values 4:%d\n",getValAtAddress(sub_ark,add_ptr+18,16));
			//fprintf(LOGFILE,"\t\tOther values 5:%d\n",getValAtAddress(sub_ark,add_ptr+20,16));
			//fprintf(LOGFILE,"\t\tOther values 6:%d\n",getValAtAddress(sub_ark,add_ptr+22,16));		
			//fprintf(LOGFILE,"\t\tOther values 7:%d\n",getValAtAddress(sub_ark,add_ptr+24,16));		
			//fprintf(LOGFILE,"\t\tOther values 8:%d\n",getValAtAddress(sub_ark,add_ptr+26,16));	
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
				fprintf(LOGFILE,"\tACTION_TIMER (i think) for %s\n", UniqueObjectName(objList[objIndex]));

				fprintf(LOGFILE,"\t\t1st Object to activate raw :%d\t", objList[objIndex].shockProperties[0]);
				fprintf(LOGFILE,"1st Object Delay:%d\n", objList[objIndex].shockProperties[1]);

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
			fprintf(LOGFILE,"\tACTION_CHOICE for %s\n",UniqueObjectName(objList[objIndex]));
			fprintf(LOGFILE,"\t\tTrigger1:%d\n",objList[objIndex].shockProperties[TRIG_PROPERTY_TRIG_1]);
			fprintf(LOGFILE,"\t\tTrigger2:%d\n",objList[objIndex].shockProperties[TRIG_PROPERTY_TRIG_2]);
			DebugPrintTriggerVals(sub_ark, add_ptr, 28);
			//fprintf(LOGFILE,"\t\tOther values 1:%d\n",getValAtAddress(sub_ark,add_ptr+12,16));
			//fprintf(LOGFILE,"\t\tOther values 2:%d\n",getValAtAddress(sub_ark,add_ptr+14,16));
			//fprintf(LOGFILE,"\t\tOther values 3:%d\n",getValAtAddress(sub_ark,add_ptr+16,16));
			//fprintf(LOGFILE,"\t\tOther values 4:%d\n",getValAtAddress(sub_ark,add_ptr+18,16));
			//fprintf(LOGFILE,"\t\tOther values 5:%d\n",getValAtAddress(sub_ark,add_ptr+20,16));
			//fprintf(LOGFILE,"\t\tOther values 6:%d\n",getValAtAddress(sub_ark,add_ptr+22,16));		
			//fprintf(LOGFILE,"\t\tOther values 7:%d\n",getValAtAddress(sub_ark,add_ptr+24,16));		
			//fprintf(LOGFILE,"\t\tOther values 8:%d\n",getValAtAddress(sub_ark,add_ptr+26,16));	
			}
		break;
		}
	case ACTION_EMAIL:
		{//Sends the player an email. (Differs from a message in that a message just plays once and does not hit the data reader)
		if (PrintDebug==1)
			{
		fprintf(LOGFILE,"\tACTION_EMAIL for %s\n",UniqueObjectName(objList[objIndex]));
		//	0F Player receives email
		//000C	int16	Chunk no. of email (offset from 2441 0x0989)
		//Note the subject line of an email may be used to chain a sequence of emails together (see sspecs)
		fprintf(LOGFILE,"\t\tEmail chunk:", getValAtAddress(sub_ark,add_ptr+0x0C,16)+2441);
		DebugPrintTriggerVals(sub_ark, add_ptr, 28);
/*			fprintf(LOGFILE,"\t\tOther values 1:%d\n",getValAtAddress(sub_ark,add_ptr+12,16));
			fprintf(LOGFILE,"\t\tOther values 2:%d\n",getValAtAddress(sub_ark,add_ptr+14,16));
			fprintf(LOGFILE,"\t\tOther values 3:%d\n",getValAtAddress(sub_ark,add_ptr+16,16));
			fprintf(LOGFILE,"\t\tOther values 4:%d\n",getValAtAddress(sub_ark,add_ptr+18,16));
			fprintf(LOGFILE,"\t\tOther values 5:%d\n",getValAtAddress(sub_ark,add_ptr+20,16));
			fprintf(LOGFILE,"\t\tOther values 6:%d\n",getValAtAddress(sub_ark,add_ptr+22,16));		
			fprintf(LOGFILE,"\t\tOther values 7:%d\n",getValAtAddress(sub_ark,add_ptr+24,16));		
			fprintf(LOGFILE,"\t\tOther values 8:%d\n",getValAtAddress(sub_ark,add_ptr+26,16));*/	
		}			
		objList[objIndex].shockProperties[TRIG_PROPERTY_EMAIL] =getValAtAddress(sub_ark,add_ptr+0x0C,16)+2441;
		
		break;
		
		}
	case ACTION_RADAWAY:
		{//Radiation healing on the reactor?
			if (PrintDebug==1)
				{
				fprintf(LOGFILE,"\tACTION_RADAWAY for %s\n",UniqueObjectName(objList[objIndex]));
				DebugPrintTriggerVals(sub_ark, add_ptr, 28);
/*				fprintf(LOGFILE,"\t\tOther values 1:%d\n",getValAtAddress(sub_ark,add_ptr+12,16));
				fprintf(LOGFILE,"\t\tOther values 2:%d\n",getValAtAddress(sub_ark,add_ptr+14,16));
				fprintf(LOGFILE,"\t\tOther values 3:%d\n",getValAtAddress(sub_ark,add_ptr+16,16));
				fprintf(LOGFILE,"\t\tOther values 4:%d\n",getValAtAddress(sub_ark,add_ptr+18,16));
				fprintf(LOGFILE,"\t\tOther values 5:%d\n",getValAtAddress(sub_ark,add_ptr+20,16));
				fprintf(LOGFILE,"\t\tOther values 6:%d\n",getValAtAddress(sub_ark,add_ptr+22,16));		
				fprintf(LOGFILE,"\t\tOther values 7:%d\n",getValAtAddress(sub_ark,add_ptr+24,16));		
				fprintf(LOGFILE,"\t\tOther values 8:%d\n",getValAtAddress(sub_ark,add_ptr+26,16));*/	
				}
		break;
		}
	case ACTION_CHANGE_STATE:
		{//Used a lot in switches. Needs more research. (changes the image?)
		if (PrintDebug==1)
			{
			fprintf(LOGFILE,"\tACTION_CHANGE_STATE for %s\n",UniqueObjectName(objList[objIndex]));
			objList[objIndex].shockProperties[TRIG_PROPERTY_TYPE] = getValAtAddress(sub_ark, add_ptr + 12, 16);
			objList[objIndex].shockProperties[TRIG_PROPERTY_OBJECT] = getValAtAddress(sub_ark, add_ptr + 16, 16);
			fprintf(LOGFILE, "\t\tObject to activate:%d\n", objList[objIndex].shockProperties[TRIG_PROPERTY_OBJECT]);
			fprintf(LOGFILE, "\t\tNew type:%d\n", objList[objIndex].shockProperties[TRIG_PROPERTY_TYPE]);
			DebugPrintTriggerVals(sub_ark, add_ptr, 28);
			//fprintf(LOGFILE,"\t\tOther values 1:%d\n",getValAtAddress(sub_ark,add_ptr+12,16));
			//fprintf(LOGFILE,"\t\tOther values 2:%d\n",getValAtAddress(sub_ark,add_ptr+14,16));
			//fprintf(LOGFILE,"\t\tOther values 3:%d\n",getValAtAddress(sub_ark,add_ptr+16,16));
			//fprintf(LOGFILE,"\t\tOther values 4:%d\n",getValAtAddress(sub_ark,add_ptr+18,16));
			//fprintf(LOGFILE,"\t\tOther values 5:%d\n",getValAtAddress(sub_ark,add_ptr+20,16));
			//fprintf(LOGFILE,"\t\tOther values 6:%d\n",getValAtAddress(sub_ark,add_ptr+22,16));		
			//fprintf(LOGFILE,"\t\tOther values 7:%d\n",getValAtAddress(sub_ark,add_ptr+24,16));		
			//fprintf(LOGFILE,"\t\tOther values 8:%d\n",getValAtAddress(sub_ark,add_ptr+26,16));	
			}
		break;
		}
	case ACTION_AWAKEN:
		{//Wakes up sleeping drones in between the two control points and sends them after you. (maybe)
		objList[objIndex].shockProperties[TRIG_PROPERTY_CONTROL_1] = getValAtAddress(sub_ark, add_ptr + 0x10, 16);
		objList[objIndex].shockProperties[TRIG_PROPERTY_CONTROL_2] = getValAtAddress(sub_ark, add_ptr + 0x12, 16);
		if (PrintDebug == 1)
			{
			fprintf(LOGFILE,"\tACTION_AWAKEN for %s\n", UniqueObjectName(objList[objIndex]));
			fprintf(LOGFILE,"\t\tControl point object1:%d\n", objList[objIndex].shockProperties[TRIG_PROPERTY_CONTROL_1]);
			fprintf(LOGFILE,"\t\tControl point object2:%d\n", objList[objIndex].shockProperties[TRIG_PROPERTY_CONTROL_2]);
			DebugPrintTriggerVals(sub_ark, add_ptr, 28);
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
			fprintf(LOGFILE,"\tACTION_MESSAGE for %s\n",UniqueObjectName(objList[objIndex]));
			fprintf(LOGFILE,"\t\tSuccess Message%d\n",objList[objIndex].shockProperties[TRIG_PROPERTY_MESSAGE1]);
			fprintf(LOGFILE,"\t\tFail Message:%d\n",objList[objIndex].shockProperties[TRIG_PROPERTY_MESSAGE2]);
			DebugPrintTriggerVals(sub_ark, add_ptr, 28);
/*			fprintf(LOGFILE,"\t\tOther values 1:%d\n",getValAtAddress(sub_ark,add_ptr+12,16));
			fprintf(LOGFILE,"\t\tOther values 2:%d\n",getValAtAddress(sub_ark,add_ptr+14,16));
			fprintf(LOGFILE,"\t\tOther values 3:%d\n",getValAtAddress(sub_ark,add_ptr+16,16));
			fprintf(LOGFILE,"\t\tOther values 4:%d\n",getValAtAddress(sub_ark,add_ptr+18,16));
			fprintf(LOGFILE,"\t\tOther values 5:%d\n",getValAtAddress(sub_ark,add_ptr+20,16));
			fprintf(LOGFILE,"\t\tOther values 6:%d\n",getValAtAddress(sub_ark,add_ptr+22,16));		
			fprintf(LOGFILE,"\t\tOther values 7:%d\n",getValAtAddress(sub_ark,add_ptr+24,16));		
			fprintf(LOGFILE,"\t\tOther values 8:%d\n",getValAtAddress(sub_ark,add_ptr+26,16));	*/	
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
			fprintf(LOGFILE,"\tACTION_SPAWN for %s\n",UniqueObjectName(objList[objIndex]));
			fprintf(LOGFILE,"\t\Class-sub-type to spawn:%d\n",objList[objIndex].shockProperties[TRIG_PROPERTY_TYPE]);
			fprintf(LOGFILE,"\t\tControl point object1:%d\n",objList[objIndex].shockProperties[TRIG_PROPERTY_CONTROL_1]);
			fprintf(LOGFILE,"\t\tControl point object2:%d\n",objList[objIndex].shockProperties[TRIG_PROPERTY_CONTROL_2]);
			fprintf(LOGFILE,"\t\t??:%d\n",getValAtAddress(sub_ark,add_ptr+0x14,16));		
			fprintf(LOGFILE,"\t\t??:%d\n",getValAtAddress(sub_ark,add_ptr+0x18,16));	
			DebugPrintTriggerVals(sub_ark, add_ptr, 28);
/*			fprintf(LOGFILE,"\t\tOther values 1:%d\n",getValAtAddress(sub_ark,add_ptr+12,16));
			fprintf(LOGFILE,"\t\tOther values 2:%d\n",getValAtAddress(sub_ark,add_ptr+14,16));
			fprintf(LOGFILE,"\t\tOther values 3:%d\n",getValAtAddress(sub_ark,add_ptr+16,16));
			fprintf(LOGFILE,"\t\tOther values 4:%d\n",getValAtAddress(sub_ark,add_ptr+18,16));
			fprintf(LOGFILE,"\t\tOther values 5:%d\n",getValAtAddress(sub_ark,add_ptr+20,16));
			fprintf(LOGFILE,"\t\tOther values 6:%d\n",getValAtAddress(sub_ark,add_ptr+22,16));		
			fprintf(LOGFILE,"\t\tOther values 7:%d\n",getValAtAddress(sub_ark,add_ptr+24,16));		
			fprintf(LOGFILE,"\t\tOther values 8:%d\n",getValAtAddress(sub_ark,add_ptr+26,16));		*/	
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
			fprintf(LOGFILE,"\tACTION_CHANGE_TYPE for %s\n",UniqueObjectName(objList[objIndex]));
			fprintf(LOGFILE,"\t\Object to Change:%d\n",objList[objIndex].shockProperties[TRIG_PROPERTY_OBJECT]);
			fprintf(LOGFILE,"\t\tNew Type (within subclass):%d\n",objList[objIndex].shockProperties[TRIG_PROPERTY_TYPE]);
			//fprintf(LOGFILE,"\t\tChanges to %s\n", getObjectNameByClass(objList[objIndex].ObjectClass, objList[objIndex].ObjectSubClass, objList[objIndex].ObjectSubClassIndex);
			fprintf(LOGFILE,"\t\t??:%d\n",getValAtAddress(sub_ark,add_ptr+0x12,16));	
			DebugPrintTriggerVals(sub_ark, add_ptr, 28);
/*			fprintf(LOGFILE,"\t\tOther values 1:%d\n",getValAtAddress(sub_ark,add_ptr+12,16));
			fprintf(LOGFILE,"\t\tOther values 2:%d\n",getValAtAddress(sub_ark,add_ptr+14,16));
			fprintf(LOGFILE,"\t\tOther values 3:%d\n",getValAtAddress(sub_ark,add_ptr+16,16));
			fprintf(LOGFILE,"\t\tOther values 4:%d\n",getValAtAddress(sub_ark,add_ptr+18,16));
			fprintf(LOGFILE,"\t\tOther values 5:%d\n",getValAtAddress(sub_ark,add_ptr+20,16));
			fprintf(LOGFILE,"\t\tOther values 6:%d\n",getValAtAddress(sub_ark,add_ptr+22,16));		
			fprintf(LOGFILE,"\t\tOther values 7:%d\n",getValAtAddress(sub_ark,add_ptr+24,16));		
			fprintf(LOGFILE,"\t\tOther values 8:%d\n",getValAtAddress(sub_ark,add_ptr+26,16));	*/		
			}			
		break;
		}
	default:
		{
		if (PrintDebug==1)
			{
				fprintf(LOGFILE,"\tUnknown triggeraction:%d for %s\n",TriggerType, UniqueObjectName(objList[objIndex]));
				DebugPrintTriggerVals(sub_ark, add_ptr, 28);
/*				fprintf(LOGFILE,"\t\tOther values 1:%d\n",getValAtAddress(sub_ark,add_ptr+12,16));
				fprintf(LOGFILE,"\t\tOther values 2:%d\n",getValAtAddress(sub_ark,add_ptr+14,16));
				fprintf(LOGFILE,"\t\tOther values 3:%d\n",getValAtAddress(sub_ark,add_ptr+16,16));
				fprintf(LOGFILE,"\t\tOther values 4:%d\n",getValAtAddress(sub_ark,add_ptr+18,16));
				fprintf(LOGFILE,"\t\tOther values 5:%d\n",getValAtAddress(sub_ark,add_ptr+20,16));
				fprintf(LOGFILE,"\t\tOther values 6:%d\n",getValAtAddress(sub_ark,add_ptr+22,16));		
				fprintf(LOGFILE,"\t\tOther values 7:%d\n",getValAtAddress(sub_ark,add_ptr+24,16));		
				fprintf(LOGFILE,"\t\tOther values 8:%d\n",getValAtAddress(sub_ark,add_ptr+26,16));	*/		
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
	{//Replaces a link in the Sytem Shock linked list when removing duplicate items that are in two tiles per the xref/master table reconciliaton.
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
{//Replaces the specified object index (into tile) if it is a duplicate per the xref/master table reconciliaton.
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
//I'm keeping this seperate from trigger action retrieval for the moment.

	//fprintf(LOGFILE,"\n\tVal_oc: %d\n" ,getValAtAddress(sub_ark,add_ptr+0x0c,16));
	//fprintf(LOGFILE,"\tVal_oe: %d\n" ,getValAtAddress(sub_ark,add_ptr+0x0E,16));
	//fprintf(LOGFILE,"\tVal_10: %d\n" ,getValAtAddress(sub_ark,add_ptr+0x10,16));
	//fprintf(LOGFILE,"\tVal_12: %d\n" ,getValAtAddress(sub_ark,add_ptr+0x12,16));
	//fprintf(LOGFILE,"\tVal_14: %d\n" ,getValAtAddress(sub_ark,add_ptr+0x14,16));
	//fprintf(LOGFILE,"\tVal_16: %d\n" ,getValAtAddress(sub_ark,add_ptr+0x16,16));
	//fprintf(LOGFILE,"\tVal_18: %d\n" ,getValAtAddress(sub_ark,add_ptr+0x18,16));
	//fprintf(LOGFILE,"\tVal_1a: %d\n" ,getValAtAddress(sub_ark,add_ptr+0x1A,16));	
	//
	fprintf(LOGFILE,"\tSwitch Properties\n");
if (objList[objIndex].ObjectSubClass ==0)
	{//regular buttons and switches
	switch (objList[objIndex].TriggerAction)	//Switches have action types as well.
		{	
			case ACTION_SET_VARIABLE:
			{//Sets a game variable. I don't yet know what the various variables are. I suspect they may be in the exe so I'll have to just observe them in the wild?
				//000C	int16	variable to set
				//0010	int16	value
				//0012	int16	?? action 00 set 01 add
				//0014	int16	Optional message to receive
				fprintf(LOGFILE,"\tACTION_SET_VARIABLE for %s\n", UniqueObjectName(objList[objIndex]));
				fprintf(LOGFILE,"\t\tVariable to Set:%d\n", getValAtAddress(sub_ark, add_ptr + 0xC, 16));
				fprintf(LOGFILE,"\t\tValue:%d", getValAtAddress(sub_ark, add_ptr + 0x10, 16));
				fprintf(LOGFILE,"\t\taction?:%d (00 set 01 add)\n", getValAtAddress(sub_ark, add_ptr + 0x12, 16));
				fprintf(LOGFILE,"\t\tOptional Message:%d\n", getValAtAddress(sub_ark, add_ptr + 0x14, 16));
				DebugPrintTriggerVals(sub_ark, add_ptr, 28);
				objList[objIndex].shockProperties[TRIG_PROPERTY_VARIABLE] = getValAtAddress(sub_ark, add_ptr + 0xC, 16);
				objList[objIndex].shockProperties[TRIG_PROPERTY_VALUE] = getValAtAddress(sub_ark, add_ptr + 0x10, 16);
				objList[objIndex].shockProperties[TRIG_PROPERTY_OPERATION] = getValAtAddress(sub_ark, add_ptr + 0x12, 16);
				objList[objIndex].shockProperties[TRIG_PROPERTY_MESSAGE1] = getValAtAddress(sub_ark, add_ptr + 0x14, 16);
			break;
			}
		case ACTION_ACTIVATE:
				{	//Assume same behaviour as a trigger?
				fprintf(LOGFILE,"Switch:Action_Activate\n");
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
				fprintf(LOGFILE,"Switch:Action_Moving_Platform\n");
				setElevatorProperties(LevelInfo,sub_ark,add_ptr,objList,objIndex,1);
				}
		case ACTION_CHOICE:
				{
				fprintf(LOGFILE,"Switch:Action_Choice\n");
				objList[objIndex].shockProperties[TRIG_PROPERTY_TRIG_1] = getValAtAddress(sub_ark, add_ptr + 0x0C, 16);
				objList[objIndex].shockProperties[TRIG_PROPERTY_TRIG_2] = getValAtAddress(sub_ark, add_ptr + 0x10, 16);
				break;
				}
		case ACTION_LIGHTING:
				{	
				fprintf(LOGFILE,"Switch:Action_Lighting\n");
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
				fprintf(LOGFILE,"\t\tControl point 1:%d\n", objList[objIndex].shockProperties[TRIG_PROPERTY_CONTROL_1]);
				fprintf(LOGFILE,"\t\tControl point 2:%d\n", objList[objIndex].shockProperties[TRIG_PROPERTY_CONTROL_2]);
				fprintf(LOGFILE,"\t\t1st Time Upper Shade adjustment = %d\n", objList[objIndex].shockProperties[TRIG_PROPERTY_UPPERSHADE_1]);
				fprintf(LOGFILE,"\t\t1st Time Lower Shade adjustment = %d\n", objList[objIndex].shockProperties[TRIG_PROPERTY_LOWERSHADE_1]);
				fprintf(LOGFILE,"\t\t2nd Time Upper Shade adjustment = %d\n", objList[objIndex].shockProperties[TRIG_PROPERTY_UPPERSHADE_2]);
				fprintf(LOGFILE,"\t\t2nd Time Lower Shade adjustment = %d\n", objList[objIndex].shockProperties[TRIG_PROPERTY_LOWERSHADE_2]);
				break;
				}
		case ACTION_CHANGE_TYPE:
				{
				fprintf(LOGFILE,"Switch:Action_Change_Type\n");
				objList[objIndex].shockProperties[TRIG_PROPERTY_OBJECT] = getValAtAddress(sub_ark, add_ptr + 0x0C, 16);
				objList[objIndex].shockProperties[TRIG_PROPERTY_TYPE] = getValAtAddress(sub_ark, add_ptr + 0x10, 8);
				fprintf(LOGFILE, "\t\tObject to change:%d\n", objList[objIndex].shockProperties[TRIG_PROPERTY_OBJECT]);
				fprintf(LOGFILE, "\t\tNew type:%d\n", objList[objIndex].shockProperties[TRIG_PROPERTY_TYPE]);
				break;
			    }
		case ACTION_CHANGE_STATE:
			{
			fprintf(LOGFILE, "Switch:Action_Change_State\n");
			objList[objIndex].shockProperties[TRIG_PROPERTY_TYPE] = getValAtAddress(sub_ark, add_ptr + 12, 16);
			objList[objIndex].shockProperties[TRIG_PROPERTY_OBJECT] = getValAtAddress(sub_ark, add_ptr + 16, 16);
			fprintf(LOGFILE, "\t\tObject to activate:%d\n", objList[objIndex].shockProperties[TRIG_PROPERTY_OBJECT]);
			fprintf(LOGFILE, "\t\tNew type:%d\n", objList[objIndex].shockProperties[TRIG_PROPERTY_TYPE]);
			DebugPrintTriggerVals(sub_ark, add_ptr, 30);
			break;
			}
		default:	
				{
				fprintf(LOGFILE,"Switch:Default\n");
				objList[objIndex].shockProperties[BUTTON_PROPERTY_TRIGGER] = getValAtAddress(sub_ark,add_ptr+12,16);
				objList[objIndex].shockProperties[BUTTON_PROPERTY_TRIGGER_2] = getValAtAddress(sub_ark,add_ptr+16,16);
				}
		}
		
		fprintf(LOGFILE,"\tDefault trigger target %d",objList[objIndex].shockProperties[BUTTON_PROPERTY_TRIGGER]);
		//fprintf(LOGFILE,"\n\tVal_oc: %d\n" ,getValAtAddress(sub_ark,add_ptr+0x0c,16));
		//fprintf(LOGFILE,"\tVal_oe: %d\n" ,getValAtAddress(sub_ark,add_ptr+0x0E,16));
		//fprintf(LOGFILE,"\tVal_10: %d\n" ,getValAtAddress(sub_ark,add_ptr+0x10,16));
		//fprintf(LOGFILE,"\tVal_12: %d\n" ,getValAtAddress(sub_ark,add_ptr+0x12,16));
		//fprintf(LOGFILE,"\tVal_14: %d\n" ,getValAtAddress(sub_ark,add_ptr+0x14,16));
		//fprintf(LOGFILE,"\tVal_16: %d\n" ,getValAtAddress(sub_ark,add_ptr+0x16,16));
		//fprintf(LOGFILE,"\tVal_18: %d\n" ,getValAtAddress(sub_ark,add_ptr+0x18,16));
		//fprintf(LOGFILE,"\tVal_1a: %d\n" ,getValAtAddress(sub_ark,add_ptr+0x1A,16));	
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
	fprintf(LOGFILE,"\tCyberspace (%d,%d,%d @ %d)\n",objList[objIndex].shockProperties[0],objList[objIndex].shockProperties[1],objList[objIndex].shockProperties[2],objList[objIndex].shockProperties[3]);
	return;
	}

if((objList[objIndex].ObjectSubClass==2) && (objList[objIndex].ObjectSubClassIndex>=1))
	{//Fixup station/energy station
	objList[objIndex].shockProperties[0]  = getValAtAddress(sub_ark,add_ptr+0x0c,16);   //Amount of charge?/? always 255
	objList[objIndex].shockProperties[1]  = getValAtAddress(sub_ark,add_ptr+0x10,16);	//Security level?? //reuse timer??
	fprintf(LOGFILE,"\tEnergy Charge: %d %d\n",objList[objIndex].shockProperties[0] ,objList[objIndex].shockProperties[1] );
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
		fprintf(LOGFILE,"\tPuzzle panel: Type is block\n");
		}
	else
		{
		fprintf(LOGFILE,"\tPuzzle panel: Type is wire\n");
		}
	fprintf(LOGFILE,"\tTrigger is %d",objList[objIndex].shockProperties[BUTTON_PROPERTY_TRIGGER]);
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
	fprintf(LOGFILE,"\tElevator to one of %d, %d or %d panels on other levels\n",objList[objIndex].shockProperties[0],objList[objIndex].shockProperties[2],objList[objIndex].shockProperties[2]);
	fprintf(LOGFILE,"\tAccesable levels actual:%d shaft:%d\n",objList[objIndex].shockProperties[3],objList[objIndex].shockProperties[4]);
	
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
	fprintf(LOGFILE,"\tNumber pad. Combo is %d, Triggers %d",objList[objIndex].shockProperties[BUTTON_PROPERTY_COMBO],objList[objIndex].shockProperties[BUTTON_PROPERTY_TRIGGER] );
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
	fprintf(LOGFILE,"\tOther button type!");
	DebugPrintTriggerVals(sub_ark, add_ptr, 30);

}

char *UniqueObjectName(ObjectItem currObj)
{//returns a unique name for the object
	char str[80] = "";
	switch (objectMasters[currObj.item_id].type)
	{
		case DOOR:
		case SHOCK_DOOR:
		case SHOCK_DOOR_TRANSPARENT:
			{// a_door_%03d_%03d\");", doorX, doorY);
			sprintf_s(str, 80, "%s_%03d_%03d\0", objectMasters[currObj.item_id].desc, currObj.tileX, currObj.tileY);
			return str;
			break;
			}
		/*case KEY:
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
				}*/
		default:
			{
			if (objectMasters[currObj.item_id].isSet == 1)
				{
					sprintf_s(str, 80, "%s_%02d_%02d_%02d_%04d\0", objectMasters[currObj.item_id].desc, currObj.tileX, currObj.tileY, currObj.levelno, currObj.index);
				}
			else
				{
					sprintf_s(str, 80, "BUGGEDOBJECT_%02d_%04d\0", currObj.levelno, currObj.index);
				}
				//_snprintf(str,80,"%s_%02d_%02d_%02d_%04d", objectMasters[currObj.item_id].desc, currObj.tileX, currObj.tileY, currObj.levelno ,currObj.index);
				
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
//Read in some common object properties file to find some useful info.
char *filePathCO = SHOCK_COMMONOBJ_FILE;
FILE *f;
int RunningTotalExtraFrames=0;
unsigned char *obj_ark; 
if ((fopen_s(&f,filePathCO, "rb") == 0))
	{
	long add_ptr;
		long fileSize = getFileSize(f);
		obj_ark = new unsigned char[fileSize];
		fread(obj_ark, fileSize, 1,f);
		fclose(f);  
		//int frameCount=2;	
		add_ptr = 5099;
		//long ObjOffset = 5099;	//hope this is right
		int prevClass = objectMasters[0].objClass;
		fprintf(LOGFILE, "\nSystem Shock Common object Properties");
		fprintf(LOGFILE, "\nIndex\t");
		fprintf(LOGFILE, "Desc\t");
		fprintf(LOGFILE, "Address\t");
		
		fprintf(LOGFILE, "Mass\t");
		fprintf(LOGFILE, "hp\t");
		fprintf(LOGFILE, "armour\t");
		fprintf(LOGFILE, "Render\t");
		fprintf(LOGFILE, "Vulner\t");
		fprintf(LOGFILE, "spevul\t");
		fprintf(LOGFILE, "defence\t");
		fprintf(LOGFILE, "flags\t");
		fprintf(LOGFILE, "3d mod\t");
		fprintf(LOGFILE, "frames\t");
		fprintf(LOGFILE, "framesbits 4-7\t");
		fprintf(LOGFILE, "framesbits 0-3\t");
		fprintf(LOGFILE, "Running total Extra\t");
		for (long i = 0; i<475;i++)
			{
			//if (prevClass != objectMasters[i].objClass)
				//{
				//frameCount=0;	//Start a new cycle for each class
				//fprintf(LOGFILE,"\n----next class------");
				//}
			prevClass = objectMasters[i].objClass;
			fprintf(LOGFILE, "\n%d\t", i);
			fprintf(LOGFILE,"%s\t" ,objectMasters[i].desc);
			//fprintf(LOGFILE,"\tRender:%d", getValAtAddress(obj_ark,ObjOffset+i*27+0x7,8));
			
			//fprintf(LOGFILE,"\tmodel:%d", getValAtAddress(obj_ark,ObjOffset+i*27+0x16,16));
			
			//objectMasters[i].frame1 = frameCount;	
			//frameCount+=(3+((getValAtAddress(obj_ark,ObjOffset+i*27+0x19,8) >>4) & 0x0F));
			//fprintf(LOGFILE,"\tframe:1350_%04d.bmp" ,objectMasters[i].frame1);
			fprintf(LOGFILE, "%d\t", add_ptr);
			fprintf(LOGFILE, "%d\t", getValAtAddress(obj_ark, add_ptr + 0x0, 32));//Mass 
			fprintf(LOGFILE, "%d\t", getValAtAddress(obj_ark, add_ptr + 0x04, 16));//hp  
			fprintf(LOGFILE, "%d\t", getValAtAddress(obj_ark, add_ptr + 0x06, 8));//armour  
			fprintf(LOGFILE, "%d\t", getValAtAddress(obj_ark, add_ptr + 0x07, 8));//Render  
			fprintf(LOGFILE, "%d\t", getValAtAddress(obj_ark, add_ptr + 0x0e, 8));//Vulner  
			fprintf(LOGFILE, "%d\t", getValAtAddress(obj_ark, add_ptr + 0x0f, 8));//spevul  
			fprintf(LOGFILE, "%d\t", getValAtAddress(obj_ark, add_ptr + 0x12, 8));//defence  
			fprintf(LOGFILE, "%d\t", getValAtAddress(obj_ark, add_ptr + 0x14, 16));//flags  
			fprintf(LOGFILE, "%d\t", getValAtAddress(obj_ark, add_ptr + 0x16, 16));//3d mod  
			fprintf(LOGFILE, "%d\t", getValAtAddress(obj_ark, add_ptr + 0x19, 8));//frames  
			fprintf(LOGFILE, "%d\t", (getValAtAddress(obj_ark, add_ptr + 0x19, 8) >> 4) & 0x7);//framesbits 4-7
			fprintf(LOGFILE, "%d\t", getValAtAddress(obj_ark, add_ptr  + 0x19, 8) & 0x7);//framesbits 0-3 
			fprintf(LOGFILE, "%d", RunningTotalExtraFrames);
			RunningTotalExtraFrames = RunningTotalExtraFrames + ((getValAtAddress(obj_ark, add_ptr + 0x19, 8) >> 4) & 0x7);
			add_ptr=add_ptr+27;

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
			fprintf(LOGFILE,"\tACTION_MOVING_PLATFORM action for %s\n", UniqueObjectName(objList[objIndex]));
			fprintf(LOGFILE,"\t\tTileX of Platform:%d\n",objList[objIndex].shockProperties[TRIG_PROPERTY_TARGET_X]);
			fprintf(LOGFILE,"\t\tTileY of Platform:%d\n",objList[objIndex].shockProperties[TRIG_PROPERTY_TARGET_Y]);
			fprintf(LOGFILE,"\t\tTarget floor height:%d\n",objList[objIndex].shockProperties[TRIG_PROPERTY_FLOOR]);
			fprintf(LOGFILE,"\t\tTarget ceiling height:%d\n",objList[objIndex].shockProperties[TRIG_PROPERTY_CEILING]);
			fprintf(LOGFILE,"\t\tSpeed:%d\n",objList[objIndex].shockProperties[TRIG_PROPERTY_SPEED]);
			fprintf(LOGFILE,"\t\tMy elevator flag=%d\n",elevatorFlag);
			DebugPrintTriggerVals(sub_ark, add_ptr, 28);
/*			fprintf(LOGFILE,"\t\tOther values 1:%d\n",getValAtAddress(sub_ark,add_ptr+12,16));
			fprintf(LOGFILE,"\t\tOther values 2:%d\n",getValAtAddress(sub_ark,add_ptr+14,16));
			fprintf(LOGFILE,"\t\tOther values 3:%d\n",getValAtAddress(sub_ark,add_ptr+16,16));
			fprintf(LOGFILE,"\t\tOther values 4:%d\n",getValAtAddress(sub_ark,add_ptr+18,16));
			fprintf(LOGFILE,"\t\tOther values 5:%d\n",getValAtAddress(sub_ark,add_ptr+20,16));
			fprintf(LOGFILE,"\t\tOther values 6:%d\n",getValAtAddress(sub_ark,add_ptr+22,16));		
			fprintf(LOGFILE,"\t\tOther values 7:%d\n",getValAtAddress(sub_ark,add_ptr+24,16));		
			fprintf(LOGFILE,"\t\tOther values 8:%d\n",getValAtAddress(sub_ark,add_ptr+26,16));	*/		
		}	

}

void DebugPrintTriggerVals(unsigned char *sub_ark, int add_ptr,int length)
{
	for (int i = 12; i <= length-2; i = i + 2)
	{
		fprintf(LOGFILE,"\n\t\tOther values %i:%d (%d,%d)",i, 
			getValAtAddress(sub_ark, add_ptr + i, 16),
			getValAtAddress(sub_ark, add_ptr + i, 8),
			getValAtAddress(sub_ark, add_ptr + i+1, 8)
			);
	}
	//fprintf(LOGFILE,"\t\tOther values 1:%d\n", getValAtAddress(sub_ark, add_ptr + 12, 16));
	//fprintf(LOGFILE,"\t\tOther values 2:%d\n", getValAtAddress(sub_ark, add_ptr + 14, 16));
	//fprintf(LOGFILE,"\t\tOther values 3:%d\n", getValAtAddress(sub_ark, add_ptr + 16, 16));
	//fprintf(LOGFILE,"\t\tOther values 4:%d\n", getValAtAddress(sub_ark, add_ptr + 18, 16));
	//fprintf(LOGFILE,"\t\tOther values 5:%d\n", getValAtAddress(sub_ark, add_ptr + 20, 16));
	//fprintf(LOGFILE,"\t\tOther values 6:%d\n", getValAtAddress(sub_ark, add_ptr + 22, 16));
	//fprintf(LOGFILE,"\t\tOther values 7:%d\n", getValAtAddress(sub_ark, add_ptr + 24, 16));
	//fprintf(LOGFILE,"\t\tOther values 8:%d\n", getValAtAddress(sub_ark, add_ptr + 26, 16));
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

void SetBullFrog(tile LevelInfo[64][64], ObjectItem objList[1600],int LevelNo)
{
//Special UW1 case
	if (LevelNo==3)
		{
		for (int x= 48; x< 56;x++)
			{
			for (int y = 48; y< 56; y++)
				{
				LevelInfo[x][y].BullFrog=1;
				}
			}	
		}
//for (int i = 0; i < 1600; i++)
//	{
//	if (objList[i].item_id >= 0)
//		{
//		if ((objectMasters[objList[i].item_id].type == A_USE_TRIGGER))
//			{
//			int Special = objList[i].link;
//			int triggerXOffset = objList[i].x; 
//			int triggerYOffset = objList[i].y;
//			if (objectMasters[objList[Special].item_id].type == A_DO_TRAP)
//				{
//				if (objList[Special].quality==24)
//					{//A bullfrog trap at tile 
//					fprintf(LOGFILE,"Bullfrog offsets %d %d\n", triggerXOffset, triggerYOffset);
//					for (int x = objList[Special].tileX + triggerXOffset; x<objList[Special].tileX + triggerXOffset+8; x++)
//						{
//						for (int y = objList[Special].tileY + triggerYOffset; y<objList[Special].tileY + triggerYOffset + 8; y++)
//							{
//							fprintf(LOGFILE,"Bullfrog %d %d\n",x,y);
//							LevelInfo[x][y].BullFrog = 0;
//							}
//						}
//					}
//				}
//			}
//		}
//	}
}

void DumpObjectCombinations(char *filePath, int game)
	{
	FILE *file = NULL;      // File pointer
	unsigned char *cmb_dat;
	long fileSize;

	if ((file = fopen(filePath, "rb")) == NULL)
		{
		fprintf(LOGFILE, "Could not open specified file\n");
		return;
		}
	fileSize = getFileSize(file);
	cmb_dat = new unsigned char[fileSize];
	fread(cmb_dat, fileSize, 1, file);
	fclose(file);
	int addressPtr = 0;
	for (int i = 0; i < fileSize / 6; i++)
		{
		int Object1 = getValAtAddress(cmb_dat, addressPtr, 16) & 0x1FF;
		int Object1Destroyed = (getValAtAddress(cmb_dat, addressPtr, 16) & 0x8000) >> 15;
		int Object2 = getValAtAddress(cmb_dat, addressPtr + 2, 16) & 0x1FF;
		int Object2Destroyed = (getValAtAddress(cmb_dat, addressPtr + 2, 16) & 0x8000) >> 15;
		int ObjectOut = getValAtAddress(cmb_dat, addressPtr + 4, 16) & 0x1FF;
		if (Object1 < 511)
			{
			printf("%d. %s(%d)(d:%d) + %s(%d)(d:%d) = %s(%d)\n",
				i,
				objectMasters[Object1].desc, Object1, Object1Destroyed,
				objectMasters[Object2].desc, Object2, Object2Destroyed,
				objectMasters[ObjectOut].desc, ObjectOut);

			}

		addressPtr = addressPtr + 6;
		}
	}

void UWCommonObj(int game)
	{

	char filePathCommon[255];
	char filePathObjects[255];

	const char *uw_comp_file;
	const char *uw_obj_prop_file;
	uw_comp_file = "DATA\\comobj.dat";
	uw_obj_prop_file = "DATA\\Objects.dat";

	sprintf_s(filePathCommon, 255, "%s\\%s", path_uw1, uw_comp_file);
	sprintf_s(filePathObjects, 255, "%s\\%s", path_uw1, uw_obj_prop_file);


//Read in the common object and object properties files 
	FILE *file = NULL;      // File pointer
	unsigned char *comobj_dat;
	unsigned char *obj_dat;
	long fileSize;

	if ((file = fopen(filePathCommon, "rb")) == NULL)
		{
		fprintf(LOGFILE, "Could not open specified file\n");
		return;
		}
	fileSize = getFileSize(file);
	comobj_dat = new unsigned char[fileSize];
	fread(comobj_dat, fileSize, 1, file);
	fclose(file);
	int addressPtr = 2;//First 2 bytes are unknown
	int j = 0;
	for (int i = 0; i < fileSize-2 / 11; i++)
		{
		if (j <= 463)
			{
			fprintf(LOGFILE, "%s\n", objectMasters[j].desc);
			fprintf(LOGFILE, "\tHeight = %d\n", getValAtAddress(comobj_dat, addressPtr, 8));
			objectMasters[j].uwProperties[UW_PROP_HEIGHT] = getValAtAddress(comobj_dat, addressPtr, 8);
			fprintf(LOGFILE, "\tRadius = %d\n", getValAtAddress(comobj_dat, addressPtr + 1, 16) & 0x7);
			objectMasters[j].uwProperties[UW_PROP_RADIUS] = getValAtAddress(comobj_dat, addressPtr + 1, 16) & 0x7;
			fprintf(LOGFILE, "\tAnimatedflag? = %d\n", (getValAtAddress(comobj_dat, addressPtr + 1, 16) >> 3) & 0x1);
			fprintf(LOGFILE, "\tMass = %d * 0.1st\n", (getValAtAddress(comobj_dat, addressPtr + 1, 16) >> 4));
			objectMasters[j].uwProperties[UW_PROP_MASS] = (getValAtAddress(comobj_dat, addressPtr + 1, 16) >> 4);
			fprintf(LOGFILE, "\tFlags (bit 0) = %d\n", (getValAtAddress(comobj_dat, addressPtr + 3, 8)) & 0x01);
			fprintf(LOGFILE, "\tFlags (bit 1) = %d\n", (getValAtAddress(comobj_dat, addressPtr + 3, 8) >> 1) & 0x01);
			fprintf(LOGFILE, "\tFlags (bit 2) = %d\n", (getValAtAddress(comobj_dat, addressPtr + 3, 8) >> 2) & 0x01);
			fprintf(LOGFILE, "\tFlags (Magic?) = %d\n", (getValAtAddress(comobj_dat, addressPtr + 3, 8) >> 3) & 0x01);
			fprintf(LOGFILE, "\tFlags (Decal) = %d\n", (getValAtAddress(comobj_dat, addressPtr + 3, 8) >> 4) & 0x01);
			fprintf(LOGFILE, "\tFlags (Pickable) = %d\n", (getValAtAddress(comobj_dat, addressPtr + 3, 8) >> 5) & 0x01);
			fprintf(LOGFILE, "\tFlags (bit 6) = %d\n", (getValAtAddress(comobj_dat, addressPtr + 3, 8) >> 6) & 0x01);
			fprintf(LOGFILE, "\tFlags (Container) = %d\n", (getValAtAddress(comobj_dat, addressPtr + 3, 8) >> 7) & 0x01);
			
			fprintf(LOGFILE, "\tValue = %d\n", getValAtAddress(comobj_dat, addressPtr + 4, 16));
			objectMasters[j].uwProperties[UW_PROP_VALUE] = getValAtAddress(comobj_dat, addressPtr + 4, 16);
			fprintf(LOGFILE, "\tQualityClass = %d * 6\n", (getValAtAddress(comobj_dat, addressPtr + 6, 8) >> 2) & 0x3);
			objectMasters[j].uwProperties[UW_PROP_QUALITY] = (getValAtAddress(comobj_dat, addressPtr + 6, 8) >> 2) & 0x3;
			fprintf(LOGFILE, "\tCan be owned = %d\n", (getValAtAddress(comobj_dat, addressPtr + 7, 8) >> 6) & 0x1);
			objectMasters[j].uwProperties[UW_PROP_OWNER] = (getValAtAddress(comobj_dat, addressPtr + 6, 8) >> 2) & 0x3;
			fprintf(LOGFILE, "\tQuality Type = %d\n", getValAtAddress(comobj_dat, addressPtr + 10, 8) & 0xF);
			objectMasters[j].uwProperties[UW_PROP_QUALITY] = getValAtAddress(comobj_dat, addressPtr + 10, 8) & 0xF;
			fprintf(LOGFILE, "\tLook at flag = %d\n", (getValAtAddress(comobj_dat, addressPtr + 10, 8) >> 3) & 0x1);

			}

	/*	0000  Int8    height
		0001  Int16   mass / stuff:
     		bits 0 - 2 : radius
			bit 3 : 1 for npc's, 3d objects and misc. items (animated flg?)
			bits 4 - 15 : mass in 0.1 stones
		0003  Int8    flags
			0 / 2 : object in range[336, 368[seem to be 3d objects
			3:magic object(? )
			4 : decal object(always 0 in uw1)
			5 : is set when object can be picked up
			7 : is set when object is a container
		0004  Int16   monetary value
		0006  Int8    bits 2..3 : quality class (this value * 6 + quality gives index
			into string block 5
		0007  Int8    bit 7: if 1, item can have owner("belongs to ...")
			bits 1..4 : type ? a = talisman, 9 = magic, 3..5 = ammunition
		0008  Int8    scale value(? )
		0009  Int8    unknown2
			bits 0 - 1 : ? ?
		000A  Int8    bits 0 - 3 : quality type 0 - f
			bit 4 : printable "look at" description when 1*/
		addressPtr = addressPtr + 11;
		j++;
		}


	if ((file = fopen(filePathObjects, "rb")) == NULL)
		{
		fprintf(LOGFILE, "Could not open specified file\n");
		return;
		}
	fileSize = getFileSize(file);
	obj_dat = new unsigned char[fileSize];
	fread(obj_dat, fileSize, 1, file);
	fclose(file);
	addressPtr = 2;
	j=0;
	//printf("\nWeapons\n\tSlash\tBash\tStab\tSkill\tDurability");
	for (int i = 0; i < 16; i++)
		{//The weapons table
		
		//printf("\n\t%d", getValAtAddress(obj_dat,addressPtr,8));//slash
		objectMasters[j].uwProperties[UW_PROP_WEAP_SLASH] = getValAtAddress(obj_dat, addressPtr, 8);
		//printf("\t%d", getValAtAddress(obj_dat, addressPtr+1, 8));//bash
		objectMasters[j].uwProperties[UW_PROP_WEAP_BASH] = getValAtAddress(obj_dat, addressPtr+1, 8);
		//printf("\t%d", getValAtAddress(obj_dat, addressPtr + 2, 8));//stab
		objectMasters[j].uwProperties[UW_PROP_WEAP_STAB] = getValAtAddress(obj_dat, addressPtr+2, 8);
		//printf("\t%d", getValAtAddress(obj_dat, addressPtr + 6, 8));//Skill
		objectMasters[j].uwProperties[UW_PROP_WEAP_SKILL] = getValAtAddress(obj_dat, addressPtr+6, 8);
		//printf("\t%d", getValAtAddress(obj_dat, addressPtr + 7, 8));//Durability
		objectMasters[j].uwProperties[UW_PROP_DURABILITY] = getValAtAddress(obj_dat, addressPtr+7, 8);
		//printf("\t%s", objectMasters[j].desc);
		
		//printf("\t(%d", getValAtAddress(obj_dat, addressPtr + 3, 8));//unknown
		//printf(",%d", getValAtAddress(obj_dat, addressPtr + 4, 8));//unknown
		//printf(",%d)", getValAtAddress(obj_dat, addressPtr + 5, 8));//unknown
		addressPtr=addressPtr+8;
		j++;
//		*Melee weapons table(0x0000 - 0x000f)
//			0000   Int8   damage modifier for Slash attack
//			0001   Int8   damage modifier for Bash attack
//			0002   Int8   damage modifier for Stab attack
//			0003   3      unknown
//			0006   Int8   skill type(3: sword, 4 : axe, 5 : mace, 6 : unarmed)
//			0007   Int8   durability
		}
	//printf("\nAddress is %d\nRanged\n",addressPtr);
//	printf("\n\tRaw\tAmmo\tDurability");
	for (int i = 0; i < 16; i++)
		{//Ranged weapons
			//0000   Int16  unknown
			//bits 9 - 15: ammunition needed(+0x10)
			//	0002   Int8   durability
	//	printf("\n\t%d", getValAtAddress(obj_dat, addressPtr, 16));
	//	printf("\t%d", ((getValAtAddress(obj_dat,addressPtr,16)>>9) & 0x7F));//is this right at all????
		//printf("\t%d", getValAtAddress(obj_dat,addressPtr+2,8));
	//	printf("\t%s", objectMasters[j].desc);
		addressPtr = addressPtr + 3;
		j++;
		}

	printf("\nAddress is %d\nArmour & Wearable\n", addressPtr);
	printf("\n\tProt\tDurabil\tUnkn\Category");
	for (int i = 0; i < 32; i++)
		{
/*		0000   Int8   protection
		0001   Int8   durability
		0002   Int8   unknown
		0003   Int8   category :
		    00 : shield
			01 : body armour
			03 : leggings
			04 : gloves
			05 : boots
			08 : hat
			09 : ring
*/
		//printf("\n\t%d",getValAtAddress(obj_dat,addressPtr,8));//Protection
		objectMasters[j].uwProperties[UW_PROP_ARM_PROTECTION] = getValAtAddress(obj_dat, addressPtr, 8);
		//printf("\t%d", getValAtAddress(obj_dat, addressPtr +1 , 8));//durability
		objectMasters[j].uwProperties[UW_PROP_DURABILITY] = getValAtAddress(obj_dat, addressPtr + 1, 8);
		//printf("\t%d", getValAtAddress(obj_dat, addressPtr +2, 8));//Unknown
		//printf("\t%d", getValAtAddress(obj_dat, addressPtr +3, 8));//Category
		//printf("\t%s", objectMasters[j].desc);
		addressPtr = addressPtr + 4;
		j++;
		}

	//printf("\nAddress is %d\nCritters\n", addressPtr);
	for (int i = 0; i < 64; i++)
		{//Critters
		addressPtr = addressPtr + 48;
		j++;
		}

	//printf("\nAddress is %d\nContainers\n", addressPtr);
	//printf("\n\tCap\tTypeofObj\tUnkn\noOfSlots");
	for (int i = 0; i < 16; i++)
		{
/*		*Containers table(0x0080 - 0x008f)
			0000   Int8   capacity in 0.1 stones
			0001   Int8   objects accepted; 0: runes, 1 : arrows, 2 : scrolls, 3 : edibles, 0xFF : any
			0002   Int8   number of slots available ? ; 2:, -1 : any
*/
		//printf("\n\t%d", getValAtAddress(obj_dat, addressPtr, 8));//Capacity
		objectMasters[j].uwProperties[UW_PROP_CONT_CAPACITY] = getValAtAddress(obj_dat, addressPtr, 8);
		//printf("\t%d", getValAtAddress(obj_dat, addressPtr + 1, 8));//Objects
		objectMasters[j].uwProperties[UW_PROP_CONT_OBJECTS] = getValAtAddress(obj_dat, addressPtr+1, 8);
		//printf("\t%d", getValAtAddress(obj_dat, addressPtr + 2, 8));//No of Slots
		objectMasters[j].uwProperties[UW_PROP_CONT_SLOTS] = getValAtAddress(obj_dat, addressPtr+2, 8);
		//printf("\t%s", objectMasters[j].desc);
		addressPtr = addressPtr + 3;
		j++;
		}

	//printf("\nAddress is %d\nLight Sources\n", addressPtr);
	//printf("\n\tBright\tDuration");
	for (int i = 0; i < 16; i++)//should be 8
		{
		/*
		* Light source table (0x0090-0x009f)
		TODO:This is the wrong way around in UWSpecs!
		0000   Int8   light brightness (max. is 4; 0 means unlit)
		0001   Int8   duration (00: doesn't go out, e.g. taper of sacrifice)
		*/
		//printf("\t%d", getValAtAddress(obj_dat, addressPtr + 1, 8));//duration
		objectMasters[j].uwProperties[UW_PROP_LIGHT_DURATION] = getValAtAddress(obj_dat, addressPtr, 8);
		//printf("\n\t%d", getValAtAddress(obj_dat, addressPtr, 8));//Brightness.
		objectMasters[j].uwProperties[UW_PROP_LIGHT_BRIGHTNESS] = getValAtAddress(obj_dat, addressPtr + 1, 8);
		//printf("\t%s", objectMasters[j].desc);
		addressPtr = addressPtr + 2;
		j++;
		}

	//printf("\nAddress is %d\nValuables?\n", addressPtr);
	//printf("\n\t????\t???");
	for (int i = 0; i < 16; i++)
		{
	//	printf("\n\t%d", getValAtAddress(obj_dat, addressPtr, 8));
		//printf("\t%d", getValAtAddress(obj_dat, addressPtr + 1, 8));
		//printf("\t%s", objectMasters[j].desc);
		addressPtr = addressPtr + 2;
		j++;
		}

	j = j + 272;
	//printf("\nAddress is %d\nAnimations\n", addressPtr);
	//printf("\n\tunk\tunk\tStart\tNoOfFrames");
	for (int i = 0; i < 11; i++)
		{
		/*
		0000   Int8   unknown (0x00, 0x21 or 0x84)
		0001   Int8   unknown (always 0x00)
		0002   Int8   start frame (from animo.gr)
		0003   Int8   number of frames
		*/
		//printf("\n\t%d", getValAtAddress(obj_dat, addressPtr, 8));
		objectMasters[j].uwProperties[UW_PROP_ANIM_PAL] = getValAtAddress(obj_dat, addressPtr, 8);
		//printf("\t%d", getValAtAddress(obj_dat, addressPtr + 1, 8));
		//printf("\t%d", getValAtAddress(obj_dat, addressPtr + 2, 8));
		objectMasters[j].uwProperties[UW_PROP_ANIM_START] = getValAtAddress(obj_dat, addressPtr+2, 8);
		//printf("\t%d", getValAtAddress(obj_dat, addressPtr + 3, 8));
		objectMasters[j].uwProperties[UW_PROP_ANIM_FRAMES] = getValAtAddress(obj_dat, addressPtr+3, 8);
		//printf("\t%s", objectMasters[j].desc);
		addressPtr = addressPtr + 4;
		j++;
		}

//	pos   size     desc                        entries   bytes per entry
//0000  Int16    unknown, always 0x010f
//0002  0x80     melee weapons table         16         8 bytes
//0082  0x30     ranged weapons table        16         3 bytes
//00b2  0x80     armour and wearables table  32         4 bytes
//0132  0x0c00   critters table              64        48 bytes
//0d32  0x30     containers table            16         3 bytes
//0d62  0x20     light source table          16         2 bytes
//0d82  0x20     unknown, maybe jewelry info table
//0da2  0x40     animation object table      16         4 bytes
//0de2           end
	//printf("DONE");




	return;
	}

	void UW1_Graves(char *filePath)
		{
		FILE *file = NULL;
		long fileSize;
		if ((file = fopen(filePath, "rb")) == NULL)
			{
			fprintf(LOGFILE, "Could not open specified file\n");
			return;
			}
		// Get the size of the file in bytes
		fileSize = getFileSize(file);
		// Allocate space in the buffer for the whole file
		graves = new unsigned char[fileSize];
		// Read the file in to the buffer
		fread(graves, fileSize, 1, file);
		fclose(file);
		return;
		}
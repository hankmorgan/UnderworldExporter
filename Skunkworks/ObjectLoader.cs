using UnityEngine;
using System.Collections;
using System.IO;
using System.Text;
using UnityEngine.UI;

public class ObjectLoader : MonoBehaviour {

	public const int NPC_TYPE =0;
	public const int WEAPON =1;
	public const int ARMOUR =2 ;
	public const int AMMO =3 ;
	public const int DOOR =4 ;
	public const int KEY =5 ;
	public const int RUNE =6 ;
	public const int BRIDGE =7 ;
	public const int BUTTON =8 ;
	public const int LIGHT =9 ;
	public const int SIGN =10 ;
	public const int BOOK =11 ;
	public const int WAND =12 ;
	public const int SCROLL= 13; //The reading kind
	public const int POTIONS =14;
	public const int INSERTABLE =15; //Shock style put the circuit board in the slot.
	public const int INVENTORY =16; //Quest items and the like with no special properties
	public const int ACTIVATOR =17; //Crystal balls,magic fountains and surgery machines that have special custom effects when you activate them
	public const int TREASURE =18 ;
	public const int CONTAINER =19 ;
	//public const int TRAP =20 ;
	public const int LOCK =21 ;
	public const int TORCH =22 ;
	public const int CLUTTER =23 ;
	public const int FOOD =24 ;
	public const int SCENERY =25 ;
	public const int INSTRUMENT =26 ;
	public const int FIRE =27 ;
	public const int MAP= 28 ;
	public const int HIDDENDOOR =29 ;
	public const int PORTCULLIS =30 ;
	public const int PILLAR =31 ;
	public const int SOUND= 32 ;
	public const int CORPSE =33 ;
	public const int TMAP_SOLID =34 ;
	public const int TMAP_CLIP= 35 ;
	public const int MAGICSCROLL =36 ;
	public const int A_DAMAGE_TRAP =37 ;
	public const int A_TELEPORT_TRAP =38 ;
	public const int A_ARROW_TRAP =39 ;
	public const int A_DO_TRAP= 40 ;
	public const int A_PIT_TRAP= 41 ;
	public const int A_CHANGE_TERRAIN_TRAP= 42 ;
	public const int A_SPELLTRAP =43 ;
	public const int A_CREATE_OBJECT_TRAP =44 ;
	public const int A_DOOR_TRAP= 45 ;
	public const int A_WARD_TRAP =46 ;
	public const int A_TELL_TRAP =47 ;
	public const int A_DELETE_OBJECT_TRAP= 48 ;
	public const int AN_INVENTORY_TRAP =49 ;
	public const int A_SET_VARIABLE_TRAP =50 ;
	public const int A_CHECK_VARIABLE_TRAP= 51 ;
	public const int A_COMBINATION_TRAP= 52 ;
	public const int A_TEXT_STRING_TRAP =53 ;
	public const int A_MOVE_TRIGGER =54 ;
	public const int A_PICK_UP_TRIGGER= 55 ;
	public const int A_USE_TRIGGER =56 ;
	public const int A_LOOK_TRIGGER =57 ;
	public const int A_STEP_ON_TRIGGER =58 ;
	public const int AN_OPEN_TRIGGER =59 ;
	public const int AN_UNLOCK_TRIGGER =60 ;
	public const int A_FOUNTAIN= 61 ;
	public const int SHOCK_DECAL =62 ;
	public const int COMPUTER_SCREEN=63 ;
	public const int SHOCK_WORDS =64 ;
	public const int SHOCK_GRATING= 65 ;
	public const int SHOCK_DOOR= 66 ;
	public const int SHOCK_DOOR_TRANSPARENT= 67 ;
	public const int UW_PAINTING= 68 ;
	public const int PARTICLE =69 ;
	public const int RUNEBAG =70 ;
	public const int SHOCK_BRIDGE =71 ;
	public const int FORCE_DOOR= 72 ;
	public const int HIDDENPLACEHOLDER = 999 ;
	public const int HELM = 73;
	public const int RING = 74;
	public const int BOOT = 75;
	public const int GLOVES = 76;
	public const int LEGGINGS = 77;
	public const int SHIELD = 78;
	public const int LOCKPICK = 79;
	public const int ANIMATION = 80;
	public const int SILVERSEED = 81;
	public const int FOUNTAIN = 82;
	public const int GRAVE = 83;
	public const int SHRINE = 84;
	public const int ANVIL = 85;
	public const int POLE = 86;
	public const int SPIKE = 87;
	public const int REFILLABLE_LANTERN =88;
	public const int OIL =89;
	public const int MOONSTONE =89;
	public const int LEECH= 91;
	public const int FISHING_POLE= 92;
	public const int  ZANIUM= 93;
	public const int  BEDROLL =94;
	public const int  FORCEFIELD= 95;
	public const int  MOONGATE= 96;
	public const int  BOULDER= 97;


	const int UWDEMO =0;
	const int  UW1= 1;
	const int  UW2 =2;
	const int  SHOCK =3;

	public string filePathObjMasters;
	public string filePathGraves;
	char[] lev_ark; 
	char[] graves;//
	public MapLoader ml;

	public GameObject parent;
	ObjectInfo[] objListp;
	public Text listing;
	ObjectMasterInfo[] objectMasters;

	public void Go()
		{
		LoadObjectMasters(filePathObjMasters);
		if (!DataLoader.ReadStreamFile(ml.Path, out lev_ark))
			{
			return ;
			}
		DataLoader.ReadStreamFile(filePathGraves, out graves);
		//Read in data here!
		ml.BuildTileMapUW(ml.Path,1,ml.LevelToRetrieve);

		objListp=new ObjectInfo[1600];
		BuildObjectListUW(ml.LevelInfo,ref objListp,ml.texture_map,lev_ark,1,ml.LevelToRetrieve);

		setObjectTileXY(1,ref ml.LevelInfo,ref objListp);

		setDoorBits(ref ml.LevelInfo,ref objListp);
		setElevatorBits(ref ml.LevelInfo,ref objListp);
		setTerrainChangeBits(ref ml.LevelInfo,ref objListp);
		SetBullFrog(ref ml.LevelInfo,ref objListp,ml.LevelToRetrieve);

		ml.CleanUp(1);
		ml.GenerateLevelFromTileMap(1);

		for (int i=0;i<objListp.GetUpperBound(0);i++)
			{
			if (objListp[i]!=null)
				{
				if (objListp[i].InUseFlag==1)
					{
					GameObject newObj = new GameObject();
					newObj.name= UniqueObjectName(objListp[i]);
					newObj.transform.parent=parent.transform;
					newObj.transform.localPosition=CalcObjectXYZ(1,ml.LevelInfo,objListp,i,objListp[i].tileX,objListp[i].tileY,0);
					}
				}
			}
		}

	public void ObjectEnquiry(int Number)
		{
		listing.text= UniqueObjectName(objListp[Number]);
		}

	////************

	void BuildObjectListUW(TileInfo[,] LevelInfo, ref ObjectInfo[] objList,int[] texture_map, char[] lev_ark, int game, int LevelNo)
		{

		//unsigned char *lev_ark; 
		//unsigned char *tmp_ark;		//for uw2 decompression
		long fileSize;
		int NoOfBlocks;
		long AddressOfBlockStart;
		long objectsAddress;
		long address_pointer;

		switch (game)
		{
		case 1:	//Underworld 1
				{					
				//Get the number of blocks in this file.
				NoOfBlocks =  (int)DataLoader.getValAtAddress(lev_ark,0,32);
				//Get the first map block
				AddressOfBlockStart = DataLoader.getValAtAddress(lev_ark,(LevelNo * 4) + 2,32);
				objectsAddress = AddressOfBlockStart + (64*64*4); //+ 1;
				address_pointer =0;
				break;
				}
		default:
			return;
		}
		for (int x=0; x<1025;x++)
			{	//read in master object list
			objList[x]=new ObjectInfo();
			objList[x].index = x; 
			objList[x].InUseFlag = 0;//Force off until I set tile x and tile y.
			objList[x].tileX=99;	//since we won't know what tile an object is in tile we have them all loaded and we can process the linked lists
			objList[x].tileY=99;
			objList[x].levelno = (short)LevelNo ;	
			objList[x].next=0;
			objList[x].address = objectsAddress+address_pointer;
			//These three will get set when I am rendering the object entity and if the item is an npc's inventory.
			//objList[x].objectOwner =0;
			//objList[x].objectOwnerEntity =0;
			//objList[x].joint =0 ;
			//objList[x].objectConversion = 0;
			objList[x].invis = 0;
			objList[x].AlreadyRendered=0;
			//Object header.

			objList[x].item_id = (int)(DataLoader.getValAtAddress(lev_ark,objectsAddress+address_pointer+0,16)) & 0x1FF;
			if ((objList[x].item_id >= 464) && ((game == UW1) || (game== UWDEMO)))//Fixed for bugged out of range items
				{
				objList[x].item_id=464;
				}
			//printf("Item ID %d %d\n",x, objList[x].item_id);
			objList[x].flags  = (int)((DataLoader.getValAtAddress(lev_ark,objectsAddress+address_pointer+0,16))>> 9) & 0x0F;
			objList[x].enchantment = (short)(((DataLoader.getValAtAddress(lev_ark,objectsAddress+address_pointer+0,16)) >> 12) & 0x01);
			objList[x].doordir  = (short)(((DataLoader.getValAtAddress(lev_ark,objectsAddress+address_pointer+0,16)) >> 13) & 0x01);
			objList[x].invis  = (short)(((DataLoader.getValAtAddress(lev_ark,objectsAddress+address_pointer+0,16)) >> 14 )& 0x01);
			objList[x].is_quant = (short)(((DataLoader.getValAtAddress(lev_ark,objectsAddress+address_pointer+0,16)) >> 15) & 0x01);

			//position at +2
			objList[x].zpos = (int)(DataLoader.getValAtAddress(lev_ark,objectsAddress+address_pointer+2,16)) & 0x7F;	//bits 0-6 
			objList[x].heading =  45 * (int)(((DataLoader.getValAtAddress(lev_ark,objectsAddress+address_pointer+2,16)) >> 7) & 0x07); //bits 7-9
			objList[x].y = (int)((DataLoader.getValAtAddress(lev_ark,objectsAddress+address_pointer+2,16)) >> 10) & 0x07;	//bits 10-12
			objList[x].x = (int)((DataLoader.getValAtAddress(lev_ark,objectsAddress+address_pointer+2,16)) >> 13) & 0x07;	//bits 13-15

			//+4
			objList[x].quality =(int)(DataLoader.getValAtAddress(lev_ark,objectsAddress+address_pointer+4,16)) & 0x3F;
			objList[x].next = (int)(DataLoader.getValAtAddress(lev_ark,objectsAddress+address_pointer+4,16)>>6) & 0x3FF;

			//+6

			objList[x].owner = (int)(DataLoader.getValAtAddress(lev_ark,objectsAddress+address_pointer+6,16) & 0x3F) ;//bits 0-5

			objList[x].link = (int)(DataLoader.getValAtAddress(lev_ark, objectsAddress + address_pointer + 6, 16) >> 6 & 0x3FF); //bits 6-15

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
					objList[x].DeathWatched = (short)DataLoader.getValAtAddress(graves, objList[x].link - 512, 8);
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
					if (objList[x].zpos > 96)
						{
						//cap the zpos height at this
						objList[x].zpos = 96;
						}


					}					
				}

			//objList[x].special = objList[x].owner;
			//objList[x].link = objList[x].quantity;
			////fprintf(LOGFILE,"\n\tNext Object ID to this object is  %d", objList[x].next  );
			////fprintf(LOGFILE,"\n%d free object. Value 4=%d",x,DataLoader.getValAtAddress(lev_ark,AddressOfBlockStart+address_pointer+6,16));


			//cleanup of shock related stuff
			//objList[x].SHOCKLocked = 0;
			////


			if (x<256)	
				{
				//mobile objects		
				objList[x].npc_hp =(int)(DataLoader.getValAtAddress(lev_ark, objectsAddress + address_pointer + 0x8, 8));

				objList[x].npc_goal =(short) (DataLoader.getValAtAddress(lev_ark, objectsAddress + address_pointer + 0xb, 16) & 0xF);
				objList[x].npc_gtarg =(short) (DataLoader.getValAtAddress(lev_ark, objectsAddress + address_pointer + 0xb, 16) >> 4 & 0xFF);

				objList[x].npc_level =(short) (DataLoader.getValAtAddress(lev_ark, objectsAddress + address_pointer + 0xd, 16) & 0xF);

				objList[x].npc_talkedto =(short) (DataLoader.getValAtAddress(lev_ark, objectsAddress + address_pointer + 0xd, 16) >> 13 & 0x1);
				objList[x].npc_attitude = (short)(DataLoader.getValAtAddress(lev_ark, objectsAddress + address_pointer + 0xd, 16) >> 14 & 0x3);

				//objList[x].npc_deathVariable=DataLoader.getValAtAddress(lev_ark, objectsAddress + address_pointer + 0x14,16) & 0xF;

				objList[x].npc_yhome =(short) (DataLoader.getValAtAddress(lev_ark, objectsAddress + address_pointer + 0x16, 16) >> 4 & 0x3F);
				objList[x].npc_xhome =(short) (DataLoader.getValAtAddress(lev_ark, objectsAddress + address_pointer + 0x16, 16) >> 10 & 0x3F);

				objList[x].npc_heading =(short) (DataLoader.getValAtAddress(lev_ark, objectsAddress + address_pointer + 0x18, 16) >> 4 & 0xF);
				objList[x].npc_hunger = (short)(DataLoader.getValAtAddress(lev_ark, objectsAddress + address_pointer + 0x19, 16) & 0x3F);

				objList[x].npc_whoami = (int)DataLoader.getValAtAddress(lev_ark, objectsAddress + address_pointer + 0x1a, 8);
				//objList[x].npc_attitude = (DataLoader.getValAtAddress(lev_ark,objectsAddress+address_pointer+13,16) >> 14);

				////extra info //19 bytes
				//fprintf(LOGFILE,"\n\tFree extra inf. Value 5=%d",DataLoader.getValAtAddress(lev_ark,AddressOfBlockStart+address_pointer+8,8));
				//fprintf(LOGFILE,"\n\t\t free extra inf. Value 6=%d",DataLoader.getValAtAddress(lev_ark,AddressOfBlockStart+address_pointer+9,8));
				//fprintf(LOGFILE,"\n\t\t free extra inf. Value 7=%d",DataLoader.getValAtAddress(lev_ark,AddressOfBlockStart+address_pointer+10,8));
				//fprintf(LOGFILE,"\n\t\t free extra inf. Value 8=%d",DataLoader.getValAtAddress(lev_ark,AddressOfBlockStart+address_pointer+11,8));
				//fprintf(LOGFILE,"\n\t\t free extra inf. Value 9=%d",DataLoader.getValAtAddress(lev_ark,AddressOfBlockStart+address_pointer+12,8));
				//fprintf(LOGFILE,"\n\t\t free extra inf. Value 10=%d",DataLoader.getValAtAddress(lev_ark,AddressOfBlockStart+address_pointer+13,8));
				//fprintf(LOGFILE,"\n\t\t free extra inf. Value 11=%d",DataLoader.getValAtAddress(lev_ark,AddressOfBlockStart+address_pointer+14,8));
				//fprintf(LOGFILE,"\n\t\t free extra inf. Value 12=%d",DataLoader.getValAtAddress(lev_ark,AddressOfBlockStart+address_pointer+15,8));
				//fprintf(LOGFILE,"\n\t\t free extra inf. Value 13=%d",DataLoader.getValAtAddress(lev_ark,AddressOfBlockStart+address_pointer+16,8));
				//fprintf(LOGFILE,"\n\t\t free extra inf. Value 14=%d",DataLoader.getValAtAddress(lev_ark,AddressOfBlockStart+address_pointer+17,8));
				//fprintf(LOGFILE,"\n\t\t free extra inf. Value 15=%d",DataLoader.getValAtAddress(lev_ark,AddressOfBlockStart+address_pointer+18,8));
				//fprintf(LOGFILE,"\n\t\t free extra inf. Value 16=%d",DataLoader.getValAtAddress(lev_ark,AddressOfBlockStart+address_pointer+19,8));
				//fprintf(LOGFILE,"\n\t\t free extra inf. Value 17=%d",DataLoader.getValAtAddress(lev_ark,AddressOfBlockStart+address_pointer+20,8));
				//fprintf(LOGFILE,"\n\t\t free extra inf. Value 18=%d",DataLoader.getValAtAddress(lev_ark,AddressOfBlockStart+address_pointer+21,8));
				//fprintf(LOGFILE,"\n\t\t free extra inf. Value 19=%d",DataLoader.getValAtAddress(lev_ark,AddressOfBlockStart+address_pointer+22,8));
				//fprintf(LOGFILE,"\n\t\t free extra inf. Value 20=%d",DataLoader.getValAtAddress(lev_ark,AddressOfBlockStart+address_pointer+23,8));
				//fprintf(LOGFILE,"\n\t\t free extra inf. Value 21=%d",DataLoader.getValAtAddress(lev_ark,AddressOfBlockStart+address_pointer+24,8));
				//fprintf(LOGFILE,"\n\t\t free extra inf. Value 22=%d",DataLoader.getValAtAddress(lev_ark,AddressOfBlockStart+address_pointer+25,8));
				//fprintf(LOGFILE,"\n\t\t free extra inf. Value 23=%d",DataLoader.getValAtAddress(lev_ark,AddressOfBlockStart+address_pointer+26,8));

				address_pointer=address_pointer+8+19;
				}
			else
				{
				//Static Objects
				address_pointer=address_pointer+8;
				}
			}
		}
	



	///*************


	//Load up object masters
	public bool LoadObjectMasters(string fileName)
		{
		objectMasters=new ObjectMasterInfo[500];
		int i=0;
		string line;
		StreamReader fileReader = new StreamReader(fileName, Encoding.Default);
		//string PreviousKey="";
		//string PreviousValue="";
		using (fileReader)
			{
			// While there's lines left in the text file, do this:
			do
				{
				line = fileReader.ReadLine();
				if (line != null)
					{
					string[] entries = line.Split(' ');
					if (entries.Length > 0)
						{
						//Debug.Log(line);
						objectMasters[i]=new ObjectMasterInfo();
						objectMasters[i].index = int.Parse(entries[0]);
						objectMasters[i].objClass= short.Parse(entries[1]);	//For Shock
						objectMasters[i].objSubClass= short.Parse(entries[2]);
						objectMasters[i].objSubClassIndex= short.Parse(entries[3]);
						objectMasters[i].cat= entries[4];
						objectMasters[i].type =  short.Parse (entries[5]);	
						objectMasters[i].desc= entries[6];
						objectMasters[i].path= entries[7];
						objectMasters[i].hasParticle=short.Parse (entries[8]);
						objectMasters[i].particle= entries[9];
						objectMasters[i].hasSound=(short)int.Parse (entries[10]);
						objectMasters[i].sound= entries[11];
						//isEntity= int.Parse(entries[12]); // 1 for entity. 0 for model. -1 for ignored entries
						//isSet= int.Parse(entries[13]);
						objectMasters[i].baseModel= entries[12];
						objectMasters[i].isSolid= short.Parse(entries[13]);
						objectMasters[i].isMoveable= short.Parse(entries[14]);
						objectMasters[i].isInventory= short.Parse(entries[15]);
						objectMasters[i].InvIcon= entries[16];

						objectMasters[i].EquippedIconFemaleLowestQuality= entries[17];
						objectMasters[i].EquippedIconFemaleLowQuality= entries[18];
						objectMasters[i].EquippedIconFemaleMediumQuality= entries[19];
						objectMasters[i].EquippedIconFemaleBestQuality= entries[20];
						objectMasters[i].EquippedIconMaleLowestQuality= entries[21];
						objectMasters[i].EquippedIconMaleLowQuality= entries[22];
						objectMasters[i].EquippedIconMaleMediumQuality= entries[23];
						objectMasters[i].EquippedIconMaleBestQuality= entries[24];



						/*extraInfo[i]= int.Parse(entries[11]);
						renderType[i]= int.Parse(entries[12]);
						frame1[i]= int.Parse(entries[13]);
						DeathWatch[i]= int.Parse(entries[14]);
						hasParticle[i]= int.Parse(entries[15]);
						hasSound[i]= int.Parse(entries[16]);*/



						i++;
						}
					}
				}
			while (line != null);
			fileReader.Close();
			return true;
			}



		}




	//*************

	string UniqueObjectName(ObjectInfo currObj)
		{//returns a unique name for the object

		 //"%s_%02d_%02d_%02d_%04d\0", objectMasters[currObj.item_id].desc, currObj.tileX, currObj.tileY, currObj.levelno, currObj.index);

		return objectMasters[currObj.item_id].desc+"_"+currObj.tileX+"_"+currObj.tileY+"_"+currObj.levelno+"_"+currObj.index;
		}









	///*********


	void setObjectTileXY(int game,ref TileInfo[,] LevelInfo, ref ObjectInfo[] objList)
		{//Justs some useful info to know.
		//ObjectItem currObj;
		for (short x=0; x<64;x++)
			{
			for (short y=0;y<64;y++)
				{
				if (LevelInfo[x,y].indexObjectList !=0)
					{
					long nextObj=LevelInfo[x,y].indexObjectList;
					while (nextObj!=0)
						{
						objList[nextObj].tileX=x;
						objList[nextObj].tileY=y;
						objList[nextObj].InUseFlag = 1;
						if ((isContainer(objList[nextObj])) || (objectMasters[objList[nextObj].item_id].type == NPC_TYPE))
							{
							SetContainerInUse(game, ref LevelInfo,ref objList, objList[nextObj].index);
							}
						else if (objectMasters[objList[nextObj].item_id].type == A_CREATE_OBJECT_TRAP)
							{
							if (objList[nextObj].InUseFlag == 0)
								{
								objList[nextObj].tileX = x;
								objList[nextObj].tileY = y;
								objList[nextObj].InUseFlag = 1;
								}
							if ( 
								(objectMasters[objList[objList[nextObj].link].item_id].type == NPC_TYPE)
								&& 
								(objList[objList[nextObj].link].InUseFlag==0)
							)
								{
								SetContainerInUse(game, ref LevelInfo, ref objList, objList[objList[nextObj].link].index);
								}
							}

						nextObj=objList[nextObj].next;
						}
					}
				}	

			for (int i = 0; i < 1024;i++)
				{//Make sure triggers and traps are created.
				if (objList[i].InUseFlag == 0)
					{
					if ((isTrigger(objList[i]) )|| (isTrap(objList[i])))
						{
						objList[i].InUseFlag=1;
						}
					}
				}

			}

		}


		bool isContainer(ObjectInfo currobj)
			{
			return  ((objectMasters[currobj.item_id].type == CONTAINER) || (objectMasters[currobj.item_id].type == CORPSE));
			}




	bool isTrigger(ObjectInfo currobj)
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
					return true;
					}	
			default:
					{
					return false;
					}
			}
		}


	bool isTrap(ObjectInfo currobj)
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
					return true;
					}
			default:
					{
					return false;
					}
			}
		}


	void SetContainerInUse(int game, ref TileInfo[,] LevelInfo, ref ObjectInfo[] objList, int index)
		{
		//Take a container/npc and set inuseflag for it contents. 
		ObjectInfo currobj = objList[index];
		//currobj.InUseFlag == 1;
		objList[index].InUseFlag=1;
		if (currobj.link != 0)
			{//Object has contents.
			ObjectInfo tmpObj = objList[currobj.link];//Get the first item in the contents.
			objList[tmpObj.index].InUseFlag=1;
			if ((isContainer(tmpObj)) || (objectMasters[tmpObj.item_id].type == NPC_TYPE))
				{//If the first item is a container recursively set it's flag
				SetContainerInUse(game,ref  LevelInfo,ref  objList, tmpObj.index);
				}
			//Now loop through the linked list.
			if (tmpObj.next > 0)
				{
				while (tmpObj.next > 0)
					{
					tmpObj = objList[tmpObj.next];
					objList[tmpObj.index].InUseFlag = 1;
					//if the next object is a countainer loop through it.
					if ((isContainer(tmpObj)) || (objectMasters[tmpObj.item_id].type == NPC_TYPE))
						{//If the first item is a container recursively set it's flag
						SetContainerInUse(game,ref LevelInfo,ref  objList, tmpObj.index);
						}
					}
				}
			tmpObj.InUseFlag = 1;
			}
		}

	///

	void setElevatorBits(ref TileInfo[,] LevelInfo, ref ObjectInfo[] objList)
		{//So I know the tile contains an elevator.
		//Note for shock this is set when I read in the object. I should probably do the same for UW.
		ObjectInfo currObj;
		for (short x=0; x<64;x++)
			{
			for (short y=0;y<64;y++)
				{
				if (LevelInfo[x,y].indexObjectList !=0)
					{
					currObj = objList[LevelInfo[x,y].indexObjectList];
					do  
						{
						if ((objectMasters[objList[currObj.index].item_id].type == A_DO_TRAP ) && (currObj.quality==3))
							{
							LevelInfo[x,y].hasElevator= 1;
							//LevelInfo[x,y].ElevatorIndex = currObj.index;
							currObj.tileX=x;
							currObj.tileY=y;
							break;
							}
						currObj=objList[currObj.next];
						}while (currObj.index !=0);
					}
				}

			}	

		}

	void setTerrainChangeBits(ref TileInfo[,] LevelInfo, ref ObjectInfo[] objList)
		{//So I know that the tile terrains changes and I can later render both versions of the tile.
		ObjectInfo currObj;
		for (short x=0; x<64;x++)
			{
			for (short y=0;y<64;y++)
				{
				if (LevelInfo[x,y].indexObjectList !=0)
					{
					currObj = objList[LevelInfo[x,y].indexObjectList];
					do  
						{
						if (objectMasters[objList[currObj.index].item_id].type == A_CHANGE_TERRAIN_TRAP )
							{
							LevelInfo[x,y].TerrainChange= 1;
							//LevelInfo[x,y].TerrainChangeIndex = currObj.index;
							//Need to flag the range of tiles affected. X/y of the object gives the dimensions
							for (int j=x; j<= x+currObj.x; j++ )
								{
								for (int k=y; k<= y+currObj.y; k++  )
									{
									LevelInfo[j,k].TerrainChange = 1;
									///LevelInfo[j,k].TerrainChangeIndices[LevelInfo[j,k].TerrainChangeCount]=currObj.index;
									LevelInfo[j,k].TerrainChangeCount++;
									//LevelInfo[j,k].isWater  = 0;// turn off water in terrain change tiles
									if (LevelInfo[j,k].isDoor==1)//The tile contains a door. I need to make sure the door is created at the height of the tile.
										{
										objList[LevelInfo[j,k].DoorIndex].zpos = objList[currObj.index].zpos;
										}
									}						
								}
							currObj.tileX=x;
							currObj.tileY=y;
							//break;
							}
						currObj=objList[currObj.next];
						}while (currObj.index !=0);
					}
				}

			}	

		}



	void setDoorBits(ref TileInfo[,] LevelInfo,ref ObjectInfo[] objList)
		{//So I know if the tile contains a door.
		ObjectInfo currObj;
		for (short x=0; x<64;x++)
			{
			for (int y=0;y<64;y++)
				{
				if (LevelInfo[x,y].indexObjectList !=0)
					{
					currObj = objList[LevelInfo[x,y].indexObjectList];
					do  
						{
						if ((objectMasters[objList[currObj.index].item_id].type == DOOR ) 
							|| (objectMasters[objList[currObj.index].item_id].type == HIDDENDOOR )
							|| (objectMasters[objList[currObj.index].item_id].type == PORTCULLIS))
							{
							//if (currObj.Angle1 >0)
							//	{
							//	//This door is a flat grating. I don't support that yet!
							//	break;
							//	}
							//else
							//	{
								LevelInfo[x,y].isDoor = 1;
								LevelInfo[x,y].DoorIndex = currObj.index;
							//	}
							break;
							}
						else
							{
							if (objectMasters[objList[currObj.index].item_id].type == SHOCK_DOOR)
								{
								LevelInfo[x,y].shockDoor = 1;
								LevelInfo[x,y].DoorIndex = currObj.index;
								}
							}
						currObj=objList[currObj.next];
						}while (currObj.index !=0);
					}
				}

			}
		}

	void SetBullFrog(ref TileInfo[,] LevelInfo, ref ObjectInfo[] objList,int LevelNo)
		{
		//Special UW1 case
		if (LevelNo==3)
			{
			for (int x= 48; x< 56;x++)
				{
				for (int y = 48; y< 56; y++)
					{
					LevelInfo[x,y].BullFrog=1;
					}
				}	
			}
		}




	///calczyz
	///  float *offX, float *offY, float *offZ,
	public Vector3 CalcObjectXYZ(int game, TileInfo[,] LevelInfo, ObjectInfo[] objList, long index, int x, int y, short WallAdjust)
		{
		float offX= 0f; float offY= 0f; float offZ= 0f;
		float ResolutionXY = 7.0f;	// A tile has a 7x7 grid for object positioning.
		float ResolutionZ = 128.0f;	//UW has 127 posible z positions for an object in tile.
			if (game == SHOCK){ ResolutionXY = 256.0f; ResolutionZ = 256.0f; }	//Shock has more "z" in it.

		float BrushX = 1.2f;
		float BrushY = 1.2f;
		float BrushZ = 0.15f;
		float objX = (float)objList[index].x;
		float objY = (float)objList[index].y;
		offX = (x*BrushX) + ((objList[index].x) * (BrushX / ResolutionXY));
		offY = (y*BrushY) + ((objList[index].y) * (BrushY / ResolutionXY));

		float zpos = objList[index].zpos;
		float ceil = ml.CEILING_HEIGHT;
		offZ = ((zpos / ResolutionZ) * (ceil)) * BrushZ;
		if ((game !=SHOCK) && (x<64) && (y<64))
			{//Adjust zpos by a fraction for objects on sloped tiles.
			switch (LevelInfo[x,y].tileType)
			{
			case MapLoader.TILE_SLOPE_N:
				offZ += objY * (48.0f / BrushZ);
				break;
			case MapLoader.TILE_SLOPE_E:
				offX += objX * (48.0f / BrushZ);
				break;
			case MapLoader.TILE_SLOPE_S:
				offZ += (8.0f-objY) * (48.0f / BrushZ);
				break;
			case MapLoader.TILE_SLOPE_W:
				offZ += (8.0f - objX) * (48.0f / BrushZ);
				break;
			}
			}

		if (WallAdjust == 1)
			{//Adjust the object x,y to avoid clipping into walls.
			switch (game)
			{
			case SHOCK:
				if (objList[index].x == 0)
					{
					offX = offX + 2.0f;
					}
				if (objList[index].x == 128)
					{
					offX = offX - 2.0f;
					}
				if (objList[index].y == 0)
					{
					offY = offY + 2.0f;
					}
				if (objList[index].y == 128)
					{
					offY = offY - 2.0f;
					}
				break;
			default:
				if (objList[index].x == 0)
					{
					offX = offX + 2.0f;
					}
				if (objList[index].x == 7)
					{
					offX =offX - 2.0f;
					}
				if (objList[index].y == 0)
					{
					offY = offY + 2.0f;
					}
				if (objList[index].y == 7)
					{
					offY = offY - 2.0f;
					}
				break;
			}
			}

		return new Vector3(offX,offZ,offY);
		}


}

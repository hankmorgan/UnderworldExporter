using UnityEngine;
using System.Collections;

public class ObjectLoader : Loader {
		const int UWDEMO =0;
		const int  UW1= 1;
		const int  UW2 =2;
		const int  SHOCK =3;


		//System Shock object classes
		const int  GUNS_WEAPONS	=	0;
		const int  AMMUNITION	=	1;
		const int  PROJECTILES=	2;
		const int  GRENADE_EXPLOSIONS=	3;
		const int  PATCHES=		4;
		const int  HARDWARE=	5;
		const int  SOFTWARE_LOGS=	6;
		const int  FIXTURES=	7;
		const int  GETTABLES_OTHER=	8;
		const int  SWITCHES_PANELS	=9;
		const int  DOORS_GRATINGS=	10;
		const int  ANIMATED=	11;
		const int  TRAPS_MARKERS=	12;
		const int  CONTAINERS_CORPSES=	13;
		const int  CRITTERS=	14;

		//System Shock object classes offsets. For this I will use their chunk offset value.
		const int  GUNS_WEAPONS_OFFSET=	4010;
		const int  AMMUNITION_OFFSET=4011;
		const int  PROJECTILES_OFFSET=4012;
		const int  GRENADE_EXPLOSIONS_OFFSET=4013;	//a guess
		const int  PATCHES_OFFSET=4014;
		const int  HARDWARE_OFFSET=	4015;
		const int  SOFTWARE_LOGS_OFFSET=4016;
		const int  FIXTURES_OFFSET=	4017;
		const int  GETTABLES_OTHER_OFFSET=4018;		//a guess
		const int  SWITCHES_PANELS_OFFSET=4019;
		const int  DOORS_GRATINGS_OFFSET=4020;
		const int  ANIMATED_OFFSET=	4021;	//a guess?
		const int  TRAPS_MARKERS_OFFSET=4022;
		const int  CONTAINERS_CORPSES_OFFSET=4023;
		const int  CRITTERS_OFFSET=4024;
		const int  SURVELLANCE_OFFSET= 4043;




		/*Some friendly array indices for shock objProperties array*/
		//Software
		const int  SOFT_PROPERTY_VERSION= 0;
		const int  SOFT_PROPERTY_LOG= 9;
		const int  SOFT_PROPERTY_LEVEL =2;
		//Buttons and panels

		const int  BUTTON_PROPERTY_TRIGGER =0;
		const int  BUTTON_PROPERTY_PUZZLE =1;
		const int  BUTTON_PROPERTY_COMBO =2;
		const int  BUTTON_PROPERTY_TRIGGER_2= 3;


		//Trigger props
		const int  TRIG_PROPERTY_OBJECT		=0;
		const int  TRIG_PROPERTY_TARGET_X	=1;
		const int  TRIG_PROPERTY_TARGET_Y	=2;
		const int  TRIG_PROPERTY_TARGET_Z	=3;
		const int  TRIG_PROPERTY_FLAG		=4;
		const int  TRIG_PROPERTY_VARIABLE	=5;
		const int  TRIG_PROPERTY_VALUE		=6;
		const int  TRIG_PROPERTY_OPERATION	=7;
		const int  TRIG_PROPERTY_MESSAGE1	=8;
		const int  TRIG_PROPERTY_MESSAGE2	=9;
		const int  TRIG_PROPERTY_LIGHT_OP	=3;
		const int  TRIG_PROPERTY_CONTROL_1	=4 ;
		const int  TRIG_PROPERTY_CONTROL_2	=5;
		const int  TRIG_PROPERTY_UPPERSHADE_1 =6;
		const int  TRIG_PROPERTY_LOWERSHADE_1 =7;
		const int  TRIG_PROPERTY_UPPERSHADE_2= 8;
		const int  TRIG_PROPERTY_LOWERSHADE_2 =9;

		const int  TRIG_PROPERTY_FLOOR		=5 ;
		const int  TRIG_PROPERTY_CEILING	=6;
		const int  TRIG_PROPERTY_SPEED		=7 ;
		const int  TRIG_PROPERTY_TRIG_1		=5;
		const int  TRIG_PROPERTY_TRIG_2		=6;
		const int  TRIG_PROPERTY_EMAIL		=9;
		const int  TRIG_PROPERTY_TYPE		=8;

		const int  CONTAINER_CONTENTS_1=	0;
		const int  CONTAINER_CONTENTS_2	=1;
		const int  CONTAINER_CONTENTS_3=	2;
		const int  CONTAINER_CONTENTS_4=	3;
		const int  CONTAINER_WIDTH	       = 5;
		const int  CONTAINER_HEIGHT	   = 6;
		const int  CONTAINER_DEPTH	        =7;
		const int  CONTAINER_TOP		=	8;
		const int  CONTAINER_SIDE		=	9;

		const int  SCREEN_NO_OF_FRAMES= 0;
		const int  SCREEN_LOOP_FLAG= 1;
		const int  SCREEN_START= 2;
		const int  SCREEN_SURVEILLANCE_TARGET= 3;

		const int  WORDS_STRING_NO =0;
		const int  WORDS_FONT =1;
		const int  WORDS_SIZE =2;
		const int  WORDS_COLOUR= 3;

		const int  BRIDGE_X_SIZE= 0;
		const int  BRIDGE_Y_SIZE= 1;
		const int  BRIDGE_HEIGHT= 2;
		const int  BRIDGE_TOP_BOTTOM_TEXTURE =3;
		const int  BRIDGE_TOP_BOTTOM_TEXTURE_SOURCE= 4;
		const int  BRIDGE_SIDE_TEXTURE= 5;
		const int  BRIDGE_SIDE_TEXTURE_SOURCE =6;


		/// <summary>
		/// Address in the file where the data is kept.
		/// </summary>
		public long objectsAddress;


		/// <summary>
		/// The game objects currently in use.
		/// </summary>
		//public ObjectInteraction[] ObjectInteractions;
		public ObjectLoaderInfo[] objInfo;


		struct xrefTable
		{
				public short tileX;// position
				public short tileY;// position
				public int next;
				public int	MstIndex;// into master object table
				public int nextTile; //objects in next tile
				public short duplicate;
				public short duplicateAssigned;
				public short duplicateNextAssigned;
		};

		/// <summary>
		/// Readies the object list. Requires the tilemap to be read in first
		/// </summary>
		/// <param name="tileMap">Tile map.</param>
		/// <param name="lev_ark">Lev ark.</param>
		/// <param name="game">Game.</param>
		public void LoadObjectList(TileMap tileMap, char[] lev_ark)
		{

			objInfo=new ObjectLoaderInfo[1024];
			BuildObjectListUW(tileMap.Tiles, objInfo, tileMap.texture_map, lev_ark, tileMap.thisLevelNo);

			setObjectTileXY(1,tileMap.Tiles,objInfo);

			setDoorBits(tileMap.Tiles,objInfo);
			setElevatorBits(tileMap.Tiles,objInfo);
			setTerrainChangeBits(tileMap.Tiles,objInfo);
			SetBullFrog(tileMap.Tiles,objInfo,tileMap.thisLevelNo);

		}

		public void LoadObjectListShock(TileMap tileMap, char[] lev_ark)
		{

				objInfo=new ObjectLoaderInfo[1600];
				BuildObjectListShock(tileMap.Tiles, objInfo, tileMap.texture_map, lev_ark, tileMap.thisLevelNo);

				setObjectTileXY(1,tileMap.Tiles,objInfo);

				//setDoorBits(tileMap.Tiles,objInfo);
				//setElevatorBits(tileMap.Tiles,objInfo);
				//setTerrainChangeBits(tileMap.Tiles,objInfo);
				//SetBullFrog(tileMap.Tiles,objInfo,tileMap.thisLevelNo);

		}


		//void BuildObjectListUW(TileInfo[,] LevelInfo, ObjectLoaderInfo[] objList,int[] texture_map, char[] lev_ark, int LevelNo)
		bool BuildObjectListShock(TileInfo[,] LevelInfo, ObjectLoaderInfo[] objList, int[] texture_map,char[] archive_ark, int LevelNo)
		{

				short InUseFlag;
				int ObjectClass;
				int ObjectSubClass;
				int ObjectSubClassIndex;

				//int[] MasterAddressLookup=new int[1600];
				//long address_pointer=4;	

				//unsigned char *archive_ark;	//the full file.

				DataLoader.Chunk xref_ark;		//The crossref table
				DataLoader.Chunk mst_ark;		//The master table



				if (!DataLoader.LoadChunk(archive_ark,LevelNo*100+4009,out xref_ark ))
				{
					return false;
				}

				xrefTable[] xref;
				xref =new xrefTable[xref_ark.chunkUnpackedLength/10];
				int i=0;
				int xref_ptr=0; 
				//int xRefLength = (xref_ark.chunkUnpackedLength/10);


				//Read in the xref table
				for (i=0;i<xref_ark.chunkUnpackedLength/10;i++)
				{
					xref[i].tileX= (short)DataLoader.getValAtAddress(xref_ark.data,xref_ptr+0,16);
					xref[i].tileY =(short)DataLoader.getValAtAddress(xref_ark.data,xref_ptr+2,16);	
					xref[i].MstIndex =(int)DataLoader.getValAtAddress(xref_ark.data,xref_ptr+4,16);	
					xref[i].next = (int)DataLoader.getValAtAddress(xref_ark.data,xref_ptr+6,16);
					xref[i].nextTile = (int)DataLoader.getValAtAddress(xref_ark.data,xref_ptr+8,16);
					if (xref[i].nextTile!= i)
					{//object extends over many tiles
						xref[i].duplicate =1;
						xref[i].duplicateAssigned=0;	//when this changes to 1 in a later loop it is the particular instance to use.
					}
					xref_ptr+=10;
				}

				if (!DataLoader.LoadChunk(archive_ark,LevelNo*100+4008,out mst_ark ))
				{
						return false;
				}
				long mstaddress_pointer =0;

				//now run through the master table and process the duplicates flag
				for (i=0;i<mst_ark.chunkUnpackedLength/27;i++)
				{
						xref_ptr= (int)DataLoader.getValAtAddress(mst_ark.data,mstaddress_pointer+5,16);
						if (xref[xref_ptr].duplicate == 1)
						{
								//picks the first duplicate found to show any others will be pushed aside.
								xref[xref_ptr].duplicateAssigned =1;	
						}
						mstaddress_pointer+=27;
				}

				for(i=0;i<xref_ark.chunkUnpackedLength/10;i++)				
				{
						if ((xref[i].duplicate==1) && (xref[i].duplicateAssigned !=1))
						{//These are xref entries that are considered extra. I just cut them out of their linked list.
								replaceLink(ref xref,(int)xref_ark.chunkUnpackedLength/10,i,xref[i].next);	//replace the links to the duplicate
								replaceMapLink(ref LevelInfo,i,xref[i].next);
						}
				}


				for (i=0;i<=objList.GetUpperBound(0);i++)
				{
						//To stop later crashes in ascii dumps I set some inital values.
						objList[i]=new ObjectLoaderInfo();
						objList[i].index=i;objList[i].next =0;objList[i].item_id=0;objList[i].link =0;objList[i].owner =0;
				}

				//now i can build based on my master list with no duplicates spoiling things.!	
				mstaddress_pointer=0;
				for (i=0; i < mst_ark.chunkUnpackedLength/27; i++)
				{

						xref_ptr =(int)DataLoader.getValAtAddress(mst_ark.data,mstaddress_pointer+5,16);
						int MasterIndex=xref[xref_ptr].MstIndex ;
						objList[MasterIndex].index=MasterIndex;
						objList[MasterIndex].link =0;
						//objList[MasterIndex].joint=0;
						objList[MasterIndex].heading=0;
						//objList[MasterIndex].objectConversion = 0;
						objList[MasterIndex].invis = 0;
						objList[MasterIndex].x = 0;
						objList[MasterIndex].y = 0;
						objList[MasterIndex].zpos =0;
						objList[MasterIndex].address=mstaddress_pointer;
						InUseFlag=(short)DataLoader.getValAtAddress(mst_ark.data,mstaddress_pointer,8);
						objList[MasterIndex].InUseFlag = InUseFlag;

						objList[MasterIndex].levelno = (short)LevelNo ;
						objList[MasterIndex].tileX = xref[xref_ptr].tileX ;
						objList[MasterIndex].tileY = xref[xref_ptr].tileY ;
						objList[MasterIndex].next =xref[xref[xref_ptr].next].MstIndex  ;
						objList[MasterIndex].parentList=this;

						ObjectClass =(int)DataLoader.getValAtAddress(mst_ark.data,mstaddress_pointer+1,8);
						objList[MasterIndex].ObjectClass = ObjectClass;
						ObjectSubClass=(int)DataLoader.getValAtAddress(mst_ark.data,mstaddress_pointer+2,8);
						objList[MasterIndex].ObjectSubClass = ObjectSubClass;
						int SubClassLink =(int)DataLoader.getValAtAddress(mst_ark.data,mstaddress_pointer+3,16);

						//Subclass per sspecs is  a link to the sub table. not the class it self. For that we need the object type.
						ObjectSubClassIndex =(int)DataLoader.getValAtAddress(mst_ark.data,mstaddress_pointer+20,8);	

						objList[MasterIndex].ObjectSubClassIndex = ObjectSubClassIndex;
						int LookupIndex=getShockObjectIndex(ObjectClass,ObjectSubClass,ObjectSubClassIndex);//Into my object list not the sublist
						if (LookupIndex != -1)
						{

								objList[MasterIndex].item_id = LookupIndex;

								objList[MasterIndex].x = (int)DataLoader.getValAtAddress(mst_ark.data, mstaddress_pointer + 11, 8);
								objList[MasterIndex].y = (int)DataLoader.getValAtAddress(mst_ark.data, mstaddress_pointer + 13, 8);
								objList[MasterIndex].zpos = (int)DataLoader.getValAtAddress(mst_ark.data, mstaddress_pointer + 15, 8);

								objList[MasterIndex].Angle1 = (int)DataLoader.getValAtAddress(mst_ark.data, mstaddress_pointer + 16, 8);
								objList[MasterIndex].Angle2 = (int)DataLoader.getValAtAddress(mst_ark.data, mstaddress_pointer + 17, 8);
								objList[MasterIndex].Angle3 = (int)DataLoader.getValAtAddress(mst_ark.data, mstaddress_pointer + 18, 8);

								objList[MasterIndex].sprite = (int)DataLoader.getValAtAddress(mst_ark.data, mstaddress_pointer + 23, 8);
								objList[MasterIndex].State = (int)DataLoader.getValAtAddress(mst_ark.data, mstaddress_pointer + 23, 8);
								objList[MasterIndex].unk1 = (int)DataLoader.getValAtAddress(mst_ark.data, mstaddress_pointer + 24, 8);

								//fprintf(LOGFILE,"InUse = %d\n", objList[MasterIndex].InUseFlag);
								//fprintf(LOGFILE,"\tAIIndex = %d\n", getValAtAddress(mst_ark, mstaddress_pointer + 19, 8));
								//fprintf(LOGFILE,"\tHitPoints = %d\n", getValAtAddress(mst_ark, mstaddress_pointer + 21, 16));

								//fprintf(LOGFILE,"\tunk1 = %d\n",getValAtAddress(mst_ark,mstaddress_pointer+24,8));
								//fprintf(LOGFILE,"\tunk2 = %d\n",getValAtAddress(mst_ark,mstaddress_pointer+25,8));
								//fprintf(LOGFILE,"\tunk3 = %d\n",getValAtAddress(mst_ark,mstaddress_pointer+26,8));				
								//fprintf(LOGFILE,"\tXCoord= %d", getValAtAddress(mst_ark, mstaddress_pointer + 11, 8));
								//fprintf(LOGFILE,"\tXCoord high= %d\n",getValAtAddress(mst_ark,mstaddress_pointer+12,8)); same as tileX
								//fprintf(LOGFILE,"\tYCoord= %d", getValAtAddress(mst_ark, mstaddress_pointer + 13, 8));
								//fprintf(LOGFILE,"\tYCoord high= %d\n",getValAtAddress(mst_ark,mstaddress_pointer+14,8)); same as tileY
								//fprintf(LOGFILE,"\t(%d) ZCoord = %d\n", blockAddress + mstaddress_pointer + 15, getValAtAddress(mst_ark, mstaddress_pointer + 15, 8));
								//fprintf(LOGFILE,"\tAngles = (%d", getValAtAddress(mst_ark, mstaddress_pointer + 16, 8));
								//fprintf(LOGFILE,",%d", getValAtAddress(mst_ark, mstaddress_pointer + 17, 8));
								//fprintf(LOGFILE,"\,%d)\n", getValAtAddress(mst_ark, mstaddress_pointer + 18, 8));
								//fprintf(LOGFILE,"\tObjectType = %d\n", getValAtAddress(mst_ark, mstaddress_pointer + 20, 8));
								//fprintf(LOGFILE,"\tHitPoints = %d\n", getValAtAddress(mst_ark, mstaddress_pointer + 21, 16));
								//fprintf(LOGFILE,"\t(%d) State = %d", blockAddress + mstaddress_pointer+23, objList[MasterIndex].State);
								//fprintf(LOGFILE,"\t(%d,%d)\n", (objList[MasterIndex].State >> 4) & 0xF, objList[MasterIndex].State & 0xF);
								//fprintf(LOGFILE,"\tunk1 = %d", getValAtAddress(mst_ark, mstaddress_pointer + 24, 8));
								//fprintf(LOGFILE,"\tunk2 = %d", getValAtAddress(mst_ark, mstaddress_pointer + 25, 8));
								//fprintf(LOGFILE,"\tunk3 = %d\n", getValAtAddress(mst_ark, mstaddress_pointer + 26, 8));
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
											lookUpSubClass(archive_ark, LevelInfo, LevelNo * 100 + SOFTWARE_LOGS_OFFSET, SOFTWARE_LOGS, SubClassLink, 9, xref, objList,texture_map, MasterIndex,LevelNo);
										break;
									}
								case FIXTURES:
									{
												lookUpSubClass(archive_ark,LevelInfo, LevelNo * 100 + FIXTURES_OFFSET, FIXTURES, SubClassLink, 16, xref, objList, texture_map, MasterIndex, LevelNo);
									break;
									}
								case GETTABLES_OTHER:
									{
												lookUpSubClass(archive_ark,LevelInfo, LevelNo * 100 + GETTABLES_OTHER_OFFSET, GETTABLES_OTHER, SubClassLink, 16, xref, objList, texture_map, MasterIndex, LevelNo);
										break;	
									}
								case SWITCHES_PANELS:
									{
												lookUpSubClass(archive_ark,LevelInfo, LevelNo * 100 + SWITCHES_PANELS_OFFSET, SWITCHES_PANELS, SubClassLink, 30, xref, objList, texture_map, MasterIndex, LevelNo);
										break;
									}
								case DOORS_GRATINGS:
									{
												lookUpSubClass(archive_ark, LevelInfo,LevelNo * 100 + DOORS_GRATINGS_OFFSET, DOORS_GRATINGS, SubClassLink, 14, xref, objList, texture_map, MasterIndex, LevelNo) ;
										break;
									}
								case ANIMATED:break;
								case TRAPS_MARKERS:
									{
												lookUpSubClass(archive_ark,LevelInfo, LevelNo * 100 + TRAPS_MARKERS_OFFSET, TRAPS_MARKERS, SubClassLink, 28, xref, objList, texture_map, MasterIndex, LevelNo);
										break;
									}
								case CONTAINERS_CORPSES:
									{
												lookUpSubClass(archive_ark,LevelInfo, LevelNo * 100 + CONTAINERS_CORPSES_OFFSET, CONTAINERS_CORPSES, SubClassLink, 21, xref, objList, texture_map, MasterIndex, LevelNo);
										break;	
									}

								case CRITTERS:
									{
												lookUpSubClass(archive_ark,LevelInfo, LevelNo * 100 + CRITTERS_OFFSET, CRITTERS, SubClassLink, 46, xref, objList, texture_map, MasterIndex, LevelNo);
										break;		
									}
								}
								UniqueObjectName(objList[MasterIndex]);
						}
						else
						{
								objList[MasterIndex].InUseFlag=0;
								//fprintf(LOGFILE,"\n\nInvalid item id!!\n");
						}


						mstaddress_pointer +=27;
				}

				//turn obj indices into master indices
				for (int x=0;x<64;x++)
				{
						for(int y=0;y<64;y++)
						{
								if (LevelInfo[x,y].indexObjectList !=0)
								{LevelInfo[x,y].indexObjectList= xref[LevelInfo[x,y].indexObjectList].MstIndex; }
						}
				}
			return true;
		}






















		/// <summary>
		/// Builds the object list for UW games
		/// </summary>
		/// <param name="LevelInfo">Level info.</param>
		/// <param name="objList">Object list.</param>
		/// <param name="texture_map">Texture map.</param>
		/// <param name="lev_ark">Lev ark.</param>
		/// <param name="LevelNo">Level no.</param>
		void BuildObjectListUW(TileInfo[,] LevelInfo, ObjectLoaderInfo[] objList,int[] texture_map, char[] lev_ark, int LevelNo)
		{
			int NoOfBlocks;
			long AddressOfBlockStart;
			
			long address_pointer;
			//char[] graves;

			//Load in the grave information
			//DataLoader.ReadStreamFile(Loader.BasePath + "DATA\\GRAVE.DAT", out graves);
			switch (_RES)
			{
			case GAME_UWDEMO:
				AddressOfBlockStart = 0;
				objectsAddress = AddressOfBlockStart + (64*64*4); //+ 1;
				address_pointer = 0;
				break;

			case GAME_UW1:	//Underworld 1
				{					
				//Get the number of blocks in this file.
				NoOfBlocks =  (int)DataLoader.getValAtAddress(lev_ark,0,32);
				//Get the first map block
				AddressOfBlockStart = DataLoader.getValAtAddress(lev_ark,(LevelNo * 4) + 2,32);
				objectsAddress = AddressOfBlockStart + (64*64*4); //+ 1;
				
				address_pointer =0;
				break;
				}
			
			case GAME_UW2: //underworld 2
				{
					char[] tmp_ark =new char[lev_ark.GetUpperBound(0)+1];
					for (int i =0; i<=lev_ark.GetUpperBound(0);i++)
					{
							tmp_ark[i] = lev_ark[i];
					}				
					address_pointer=6;
					NoOfBlocks=(int)DataLoader.getValAtAddress(tmp_ark,0,32);
					int compressionFlag=(int)DataLoader.getValAtAddress(tmp_ark,address_pointer + (NoOfBlocks*4) ,32);
					int isCompressed =(compressionFlag>>1) & 0x01;

					//long dataSize = address_pointer + (2*NoOfBlocks*4);	//????
					address_pointer=(LevelNo * 4) + 6;
					if (DataLoader.getValAtAddress(tmp_ark,address_pointer,32)==0)
					{
						return;
					}
					if (isCompressed == 1)
					{
						int datalen=0;
						lev_ark = DataLoader.unpackUW2(tmp_ark,DataLoader.getValAtAddress(tmp_ark,address_pointer,32), ref datalen);
					}
					else
					{//
						int BlockStart = (int)DataLoader.getValAtAddress(tmp_ark, address_pointer, 32);
						int j = 0;
						AddressOfBlockStart = 0;
						lev_ark = new char[0x7c08];
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

			default:
					return;
			}
			for (int x=0; x<1024;x++)
			{	//read in master object list
				objList[x]=new ObjectLoaderInfo();
				objList[x].parentList=this;
				objList[x].index = x; 
				objList[x].InUseFlag = 0;//Force off until I set tile x and tile y.
				objList[x].tileX=99;	//since we won't know what tile an object is in tile we have them all loaded and we can process the linked lists
				objList[x].tileY=99;
				objList[x].levelno = (short)LevelNo ;	
				objList[x].next=0;
				objList[x].address = objectsAddress+address_pointer;

				objList[x].invis = 0;
				objList[x].AlreadyRendered=0;

				objList[x].item_id = (int)(DataLoader.getValAtAddress(lev_ark,objectsAddress+address_pointer+0,16)) & 0x1FF;
				if ((objList[x].item_id >= 464) && ((_RES == GAME_UW1) || (_RES== GAME_UWDEMO)))//Fixed for bugged out of range items
				{
						objList[x].item_id=0;
				}
				//printf("Item ID %d %d\n",x, objList[x].item_id);
				objList[x].flags  = (int)((DataLoader.getValAtAddress(lev_ark,objectsAddress+address_pointer+0,16))>> 9) & 0x0F;
				objList[x].enchantment = (short)(((DataLoader.getValAtAddress(lev_ark,objectsAddress+address_pointer+0,16)) >> 12) & 0x01);
				objList[x].doordir  = (short)(((DataLoader.getValAtAddress(lev_ark,objectsAddress+address_pointer+0,16)) >> 13) & 0x01);
				objList[x].invis  = (short)(((DataLoader.getValAtAddress(lev_ark,objectsAddress+address_pointer+0,16)) >> 14 )& 0x01);
				objList[x].is_quant = (short)(((DataLoader.getValAtAddress(lev_ark,objectsAddress+address_pointer+0,16)) >> 15) & 0x01);

				//position at +2
				objList[x].zpos = (int)(DataLoader.getValAtAddress(lev_ark,objectsAddress+address_pointer+2,16)) & 0x7F;	//bits 0-6 
				//objList[x].heading =  45 * (int)(((DataLoader.getValAtAddress(lev_ark,objectsAddress+address_pointer+2,16)) >> 7) & 0x07); //bits 7-9
				objList[x].heading = (int)(((DataLoader.getValAtAddress(lev_ark,objectsAddress+address_pointer+2,16)) >> 7) & 0x07); //bits 7-9

				objList[x].y = (int)((DataLoader.getValAtAddress(lev_ark,objectsAddress+address_pointer+2,16)) >> 10) & 0x07;	//bits 10-12
				objList[x].x = (int)((DataLoader.getValAtAddress(lev_ark,objectsAddress+address_pointer+2,16)) >> 13) & 0x07;	//bits 13-15

				//+4
				objList[x].quality =(int)((DataLoader.getValAtAddress(lev_ark,objectsAddress+address_pointer+4,16)) & 0x3F);
				objList[x].next = ((DataLoader.getValAtAddress(lev_ark,objectsAddress+address_pointer+4,16)>>6) & 0x3FF);

				//+6

				objList[x].owner = (int)(DataLoader.getValAtAddress(lev_ark,objectsAddress+address_pointer+6,16) & 0x3F) ;//bits 0-5

				objList[x].link = (int)(DataLoader.getValAtAddress(lev_ark, objectsAddress + address_pointer + 6, 16) >> 6 & 0x3FF); //bits 6-15

				if ((GameWorldController.instance.objectMaster.type[objList[x].item_id] == ObjectInteraction.TMAP_SOLID) || (GameWorldController.instance.objectMaster.type[objList[x].item_id] == ObjectInteraction.TMAP_CLIP))
				{
						objList[x].texture = texture_map[objList[x].owner];	//Sets the texture for tmap objects. I won't have access to the texture map later on.
				}

				if (GameWorldController.instance.objectMaster.type[objList[x].item_id] == ObjectInteraction.DOOR)
				{
					switch (_RES)
					{
					case GAME_UWDEMO:
					case GAME_UW1:
					case GAME_UW2:
						if ((objList[x].item_id >= 328) && (objList[x].item_id <= 333))
						{//Open doors need to be adjusted down?
								//objList[x].zpos-=24;
						}
						break;
					}
				}

				if (GameWorldController.instance.objectMaster.type[objList[x].item_id] == ObjectInteraction.BRIDGE)
				{
					if (objList[x].flags >= 2)
					{//267 + textureIndex;
						if (_RES == GAME_UW2)
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

				if (GameWorldController.instance.objectMaster.type[objList[x].item_id] == ObjectInteraction.BUTTON)
				{
					objList[x].texture = objList[x].flags;
				}

				if (GameWorldController.instance.objectMaster.type[objList[x].item_id] == ObjectInteraction.GRAVE)
				{
					objList[x].texture = objList[x].flags+28;
					//if (objList[x].link >= 512)
					//{
					//	objList[x].DeathWatched = (short)DataLoader.getValAtAddress(graves, objList[x].link - 512, 8);
					//}
				}
				if (GameWorldController.instance.objectMaster.type[objList[x].item_id] == ObjectInteraction.A_CREATE_OBJECT_TRAP)//Position the trap in the centre of the tile
				{
					objList[x].x = 4;
					objList[x].y = 4;
				}
				if (GameWorldController.instance.objectMaster.type[objList[x].item_id] == ObjectInteraction.A_CHANGE_TERRAIN_TRAP)
				{
					//bits 1-5 of the quality field is the floor texture.
					if (_RES == GAME_UW1)
					{
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
				if (x<256)	
				{
					//mobile objects		
					objList[x].npc_hp =(int)(DataLoader.getValAtAddress(lev_ark, objectsAddress + address_pointer + 0x8, 8));

					objList[x].npc_goal =(short) (DataLoader.getValAtAddress(lev_ark, objectsAddress + address_pointer + 0xb, 16) & 0xF);
					objList[x].npc_gtarg =(short) (DataLoader.getValAtAddress(lev_ark, objectsAddress + address_pointer + 0xb, 16) >> 4 & 0xFF);

					objList[x].npc_level =(short) (DataLoader.getValAtAddress(lev_ark, objectsAddress + address_pointer + 0xd, 16) & 0xF);

					objList[x].npc_talkedto =(short) (DataLoader.getValAtAddress(lev_ark, objectsAddress + address_pointer + 0xd, 16) >> 13 & 0x1);
					objList[x].npc_attitude = (short)(DataLoader.getValAtAddress(lev_ark, objectsAddress + address_pointer + 0xd, 16) >> 14 & 0x3);

					objList[x].npc_yhome =(short) (DataLoader.getValAtAddress(lev_ark, objectsAddress + address_pointer + 0x16, 16) >> 4 & 0x3F);
					objList[x].npc_xhome =(short) (DataLoader.getValAtAddress(lev_ark, objectsAddress + address_pointer + 0x16, 16) >> 10 & 0x3F);

					objList[x].npc_heading =(short) (DataLoader.getValAtAddress(lev_ark, objectsAddress + address_pointer + 0x18, 16) >> 4 & 0xF);
					objList[x].npc_hunger = (short)(DataLoader.getValAtAddress(lev_ark, objectsAddress + address_pointer + 0x19, 16) & 0x3F);

					objList[x].npc_whoami = (int)DataLoader.getValAtAddress(lev_ark, objectsAddress + address_pointer + 0x1a, 8);
					address_pointer=address_pointer+8+19;
				}
				else
				{
					//Static Objects
					address_pointer=address_pointer+8;
				}
			}
	}


	public static string UniqueObjectName(ObjectLoaderInfo currObj)
	{//returns a unique name for the object

			//"%s_%02d_%02d_%02d_%04d\0", GameWorldController.instance.objectMaster[currObj.item_id].desc, currObj.tileX, currObj.tileY, currObj.levelno, currObj.index);
			switch(GameWorldController.instance.objectMaster.type[currObj.item_id])
			{
			case ObjectInteraction.DOOR:
			case ObjectInteraction.HIDDENDOOR:
			case ObjectInteraction.PORTCULLIS:
					return "door_" + currObj.tileX.ToString("d3") + "_" + currObj.tileY.ToString("d3") ;
			default:
					return GameWorldController.instance.objectMaster.desc[currObj.item_id]+"_"+currObj.tileX.ToString("d2")+"_"+currObj.tileY.ToString("d2")+"_"+currObj.levelno.ToString("d2")+"_"+currObj.index.ToString("d4");
			}

	}









	//*********

	
		/// <summary>
		/// Sets the object tile X and Y values. Flags if the object exists in the map
		/// </summary>
		/// <param name="game">Game.</param>
		/// <param name="LevelInfo">Level info.</param>
		/// <param name="objList">Object list.</param>
	void setObjectTileXY(int game,TileInfo[,] LevelInfo, ObjectLoaderInfo[] objList)
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
						if ((isContainer(objList[nextObj])) || (GameWorldController.instance.objectMaster.type[objList[nextObj].item_id] == ObjectInteraction.NPC_TYPE))
						{
								SetContainerInUse(game, LevelInfo,objList, objList[nextObj].index);
						}
						else if (GameWorldController.instance.objectMaster.type[objList[nextObj].item_id] == ObjectInteraction.A_CREATE_OBJECT_TRAP)
						{
								if (objList[nextObj].InUseFlag == 0)
								{
										objList[nextObj].tileX = x;
										objList[nextObj].tileY = y;
										objList[nextObj].InUseFlag = 1;
								}
								if ( 
										(GameWorldController.instance.objectMaster.type[objList[objList[nextObj].link].item_id] == ObjectInteraction.NPC_TYPE)
										&& 
										(objList[objList[nextObj].link].InUseFlag==0)
								)
								{
										SetContainerInUse(game, LevelInfo, objList, objList[objList[nextObj].link].index);
								}
						}

						nextObj=objList[nextObj].next;
					}
				}
			}	

			for (int i = 0; i < 1024;i++)
			{//Make sure triggers, traps and special items are created.
				if (objList[i].InUseFlag == 0)
				{
					if ((isTrigger(objList[i]) )|| (isTrap(objList[i]) || (isAlwaysInUse(objList[i]))))
					{
						objList[i].InUseFlag=1;
					}
				}
			}
		}
	}


	public static bool isContainer(ObjectLoaderInfo currobj)
	{
		return  ((GameWorldController.instance.objectMaster.type[currobj.item_id] == ObjectInteraction.CONTAINER) || (GameWorldController.instance.objectMaster.type[currobj.item_id] == ObjectInteraction.CORPSE));
	}

		/// <summary>
		/// Tells if the objects that will never move
		/// </summary>
		/// <returns><c>true</c>, if static was ised, <c>false</c> otherwise.</returns>
		/// <param name="currobj">Currobj.</param>
	public static  bool isStatic(ObjectLoaderInfo currobj)
	{
		if (isTrap(currobj)||isTrigger(currobj))
		{
				return true;	
		}
		switch(GameWorldController.instance.objectMaster.type[currobj.item_id] )
		{	
		case ObjectInteraction.TMAP_CLIP:
		case ObjectInteraction.TMAP_SOLID:
		case ObjectInteraction.DOOR:
		case ObjectInteraction.HIDDENDOOR:
		case ObjectInteraction.PORTCULLIS:
		case ObjectInteraction.GRAVE:
		case ObjectInteraction.FOUNTAIN:
		case ObjectInteraction.BUTTON:
		case ObjectInteraction.PILLAR:
		case ObjectInteraction.BRIDGE:
				return true;
		default:
				return false;							
		}
	}


		public static  bool isAlwaysInUse(ObjectLoaderInfo currobj)
		{//Objects that will always be generated.
			switch(GameWorldController.instance.objectMaster.type[currobj.item_id] )
			{	
			case ObjectInteraction.SPELL:
					return true;
			default:
					return false;							
			}
		}

		public static  bool isTrigger(ObjectLoaderInfo currobj)
		{//Tells if the object is a trigger that can set of a trap.
				switch(GameWorldController.instance.objectMaster.type[currobj.item_id] )
				{
				case  ObjectInteraction.A_MOVE_TRIGGER :
				case  ObjectInteraction.A_PICK_UP_TRIGGER :
				case  ObjectInteraction.A_USE_TRIGGER :
				case  ObjectInteraction.A_LOOK_TRIGGER :
				case  ObjectInteraction.A_STEP_ON_TRIGGER :
				case  ObjectInteraction.AN_OPEN_TRIGGER :
				case  ObjectInteraction.AN_UNLOCK_TRIGGER :
				case  ObjectInteraction.A_TIMER_TRIGGER:
				case  ObjectInteraction.A_SCHEDULED_TRIGGER:
						{
								return true;
						}	
				default:
						{
								return false;
						}
				}
		}


		public static bool isTrap(ObjectLoaderInfo currobj)
		{
			switch (GameWorldController.instance.objectMaster.type[currobj.item_id] )
			{
			case ObjectInteraction.A_DAMAGE_TRAP :
			case ObjectInteraction.A_TELEPORT_TRAP :
			case  ObjectInteraction.A_ARROW_TRAP :
			case  ObjectInteraction.A_DO_TRAP :
			case  ObjectInteraction.A_PIT_TRAP :
			case  ObjectInteraction.A_CHANGE_TERRAIN_TRAP :
			case  ObjectInteraction.A_SPELLTRAP :
			case  ObjectInteraction.A_CREATE_OBJECT_TRAP :
			case  ObjectInteraction.A_DOOR_TRAP :
			case  ObjectInteraction.A_WARD_TRAP :
			case  ObjectInteraction.A_TELL_TRAP  :
			case  ObjectInteraction.A_DELETE_OBJECT_TRAP :
			case  ObjectInteraction.AN_INVENTORY_TRAP :
			case  ObjectInteraction.A_SET_VARIABLE_TRAP :
			case  ObjectInteraction.A_CHECK_VARIABLE_TRAP :
			case  ObjectInteraction.A_COMBINATION_TRAP :
			case  ObjectInteraction.A_TEXT_STRING_TRAP :
			case  ObjectInteraction.AN_OSCILLATOR:
			case ObjectInteraction.A_CHANGE_TO_TRAP:
			case ObjectInteraction.A_CHANGE_FROM_TRAP:
			case ObjectInteraction.AN_EXPERIENCE_TRAP:
				{
					return true;
				}
			default:
				{
					return false;
				}
			}
		}


		void SetContainerInUse(int game, TileInfo[,] LevelInfo, ObjectLoaderInfo[] objList, int index)
		{
				
				//Take a container/npc and set inuseflag for it contents. 
				ObjectLoaderInfo currobj = objList[index];
				//currobj.InUseFlag == 1;
				objList[index].InUseFlag=1;
				if (currobj.link != 0)
				{//Object has contents.
						ObjectLoaderInfo tmpObj = objList[currobj.link];//Get the first item in the contents.
						objList[tmpObj.index].InUseFlag=1;
						if ((isContainer(tmpObj)) || (GameWorldController.instance.objectMaster.type[tmpObj.item_id] == ObjectInteraction.NPC_TYPE))
						{//If the first item is a container recursively set it's flag
								SetContainerInUse(game, LevelInfo, objList, tmpObj.index);
						}
						//Now loop through the linked list.
						if (tmpObj.next > 0)
						{
								while (tmpObj.next > 0)
								{
										tmpObj = objList[tmpObj.next];
										objList[tmpObj.index].InUseFlag = 1;
										//if the next object is a countainer loop through it.
										if ((isContainer(tmpObj)) || (GameWorldController.instance.objectMaster.type[tmpObj.item_id] == ObjectInteraction.NPC_TYPE))
										{//If the first item is a container recursively set it's flag
												SetContainerInUse(game,LevelInfo, objList, tmpObj.index);
										}
								}
						}
						tmpObj.InUseFlag = 1;
				}
		}

		///

		void setElevatorBits(TileInfo[,] LevelInfo, ObjectLoaderInfo[] objList)
		{//So I know the tile contains an elevator.
			//Note for shock this is set when I read in the object. I should probably do the same for UW.
			ObjectLoaderInfo currObj;
			for (short x=0; x<64;x++)
			{
				for (short y=0;y<64;y++)
				{
					if (LevelInfo[x,y].indexObjectList !=0)
					{
						currObj = objList[LevelInfo[x,y].indexObjectList];
						do  
						{
						if (
							((GameWorldController.instance.objectMaster.type[objList[currObj.index].item_id] == ObjectInteraction.A_DO_TRAP ) && (currObj.quality==3))
							|| 
							((GameWorldController.instance.objectMaster.type[objList[currObj.index].item_id] == ObjectInteraction.AN_OSCILLATOR ))
							|| 
							((GameWorldController.instance.objectMaster.type[objList[currObj.index].item_id] == ObjectInteraction.A_PIT_TRAP ))
							)
							{
								LevelInfo[x,y].hasElevator= 1;
								LevelInfo[x,y].TerrainChange=1;
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

		void setTerrainChangeBits(TileInfo[,] LevelInfo, ObjectLoaderInfo[] objList)
		{//So I know that the tile terrains changes and I can later render both versions of the tile.
				ObjectLoaderInfo currObj;
				for (short x=0; x<64;x++)
				{
						for (short y=0;y<64;y++)
						{
								if (LevelInfo[x,y].indexObjectList !=0)
								{
										currObj = objList[LevelInfo[x,y].indexObjectList];
										do  
										{
												if (GameWorldController.instance.objectMaster.type[objList[currObj.index].item_id] == ObjectInteraction.A_CHANGE_TERRAIN_TRAP )
												{
														LevelInfo[x,y].TerrainChange= 1;
														//LevelInfo[x,y].TerrainChangeIndex = currObj.index;
														//Need to flag the range of tiles affected. X/y of the object gives the dimensions
														for (int j=x; j<= x+currObj.x; j++ )
														{
																for (int k=y; k<= y+currObj.y; k++  )
																{
																		LevelInfo[j,k].TerrainChange = 1;
																		//Flag each of it's neighbours as well. May already be flagged.
																		for (int q=-1; q<=1; q++)
																		{
																				for (int r=-1; r<=1; r++)
																				{
																						if   ( ((j+r>=0) && (j+r<63)) && ((k+q>=0) && (k+q<63)))
																						{
																								LevelInfo[j+r,k+q].TerrainChange=1;	
																						}
																				}	
																		}
																		///LevelInfo[j,k].TerrainChangeIndices[LevelInfo[j,k].TerrainChangeCount]=currObj.index;
																		LevelInfo[j,k].TerrainChangeCount++;
																		//LevelInfo[j,k].isWater  = 0;// turn off water in terrain change tiles
																		if (LevelInfo[j,k].isDoor==true)//The tile contains a door. I need to make sure the door is created at the height of the tile.
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



		void setDoorBits(TileInfo[,] LevelInfo,ObjectLoaderInfo[] objList)
		{//So I know if the tile contains a door.
				ObjectLoaderInfo currObj;
				for (short x=0; x<64;x++)
				{
						for (int y=0;y<64;y++)
						{
								if (LevelInfo[x,y].indexObjectList !=0)
								{
										currObj = objList[LevelInfo[x,y].indexObjectList];
										do  
										{
												if ((GameWorldController.instance.objectMaster.type[objList[currObj.index].item_id] == ObjectInteraction.DOOR ) 
														|| (GameWorldController.instance.objectMaster.type[objList[currObj.index].item_id] == ObjectInteraction.HIDDENDOOR )
														|| (GameWorldController.instance.objectMaster.type[objList[currObj.index].item_id] == ObjectInteraction.PORTCULLIS))
												{
														//if (currObj.Angle1 >0)
														//	{
														//	//This door is a flat grating. I don't support that yet!
														//	break;
														//	}
														//else
														//	{
														LevelInfo[x,y].isDoor = true;
														LevelInfo[x,y].DoorIndex = currObj.index;
														//Put it's lock into use if it exists.
														//I'm ignoring for the moment but it is here for compatability to vanilla.
														if (currObj.link!=0)
														{
																if (objList[currObj.link].InUseFlag==0)
																{
																		objList[currObj.link].InUseFlag=1;	
																		objList[currObj.link].tileX=99;
																		objList[currObj.link].tileY=99;	
																}

														}
														//	}
														break;
												}
												else
												{
														if (GameWorldController.instance.objectMaster.type[objList[currObj.index].item_id] == ObjectInteraction.SHOCK_DOOR)
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

		void SetBullFrog(TileInfo[,] LevelInfo, ObjectLoaderInfo[] objList,int LevelNo)
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
		public Vector3 CalcObjectXYZ(string game, TileMap tileMap, TileInfo[,] LevelInfo, ObjectLoaderInfo[] objList, long index, int x, int y, short WallAdjust)
		{
				float offX= 0f; float offY= 0f; float offZ= 0f;
				float ResolutionXY = 7.0f;	// A tile has a 7x7 grid for object positioning.
				float ResolutionZ = 128.0f;	//UW has 127 posible z positions for an object in tile.
				if (game == Loader.GAME_SHOCK){ ResolutionXY = 256.0f; ResolutionZ = 256.0f; }	//Shock has more "z" in it.

				float BrushX = 120f;
				float BrushY = 120f;
				float BrushZ = 15f;
				float objX = (float)objList[index].x;
				float objY = (float)objList[index].y;
				offX = (x*BrushX) + ((objList[index].x) * (BrushX / ResolutionXY));
				offY = (y*BrushY) + ((objList[index].y) * (BrushY / ResolutionXY));

				float zpos = objList[index].zpos;
				if (_RES!=GAME_SHOCK)
				{
					if ((objList[index].item_id >= 328) && (objList[index].item_id <= 333))
					{//Open doors need to be adjusted down?
						zpos -= 24f;
					}	
				}
				//if (game==Loader.GAME_SHOCK)
				//{
				//	zpos= zpos- GameWorldController.instance.ShockObjProp.properties[objList[index].item_id].Offset;
				//}
				float ceil = tileMap.CEILING_HEIGHT;
				offZ = ((zpos / ResolutionZ) * (ceil)) * BrushZ;
				if ((game !=Loader.GAME_SHOCK) && (x<64) && (y<64))
				{//Adjust zpos by a fraction for objects on sloped tiles.
						switch (LevelInfo[x,y].tileType)
						{
						case TileMap.TILE_SLOPE_N:
								offZ += objY * (48.0f / BrushZ);
								break;
						case TileMap.TILE_SLOPE_E:
								offX += objX * (48.0f / BrushZ);
								break;
						case TileMap.TILE_SLOPE_S:
								offZ += (8.0f-objY) * (48.0f / BrushZ);
								break;
						case TileMap.TILE_SLOPE_W:
								offZ += (8.0f - objX) * (48.0f / BrushZ);
								break;
						}
				}

				switch (GameWorldController.instance.objectMaster.type[objList[index].item_id])
				{
				case ObjectInteraction.TMAP_CLIP:
				case ObjectInteraction.TMAP_SOLID:
						switch (objList[index].heading*45)
						{
						case ObjectInteraction.HEADINGWEST:
						case ObjectInteraction.HEADINGEAST:		
								offY = (y*BrushY) + 60f;//center in tile
								/*offX = (x*BrushX) + 0.6f;*/
								if (objList[index].x == 0)
								{
										offX +=0.15f;
								}
								if (objList[index].x == 7)
								{
										offX -=0.15f;
								}
								break;
						case ObjectInteraction.HEADINGNORTH:
						case ObjectInteraction.HEADINGSOUTH:
								/*	offY = (y*BrushY) + 0.6f;*/
								offX = (x*BrushX) +60f;
								if (objList[index].y == 0)
								{
										offY +=0.15f;
								}
								if (objList[index].y == 7)
								{
										offY -=0.15f;
								}
								break;
						}
						break;

				case ObjectInteraction.DOOR:
				case ObjectInteraction.HIDDENDOOR:
				case ObjectInteraction.PORTCULLIS:
						{
							float DOORWIDTH=80f;

							switch (objList[index].heading*45)
							{//Move the object position so it can located in the right position in the centre of the frame.
							case ObjectInteraction.HEADINGWEST:
									{
									offY = (objList[index].tileY*BrushY + DOORWIDTH + ((BrushY - DOORWIDTH) / 2f));
									//offY = (((float)(objList[index].tileY)*BrushY) + BrushY + ((BrushY - DOORWIDTH) / 2f)); 
									break;
									}
							case ObjectInteraction.HEADINGEAST:
									{
									offY = (objList[index].tileY*BrushY + ((BrushY - DOORWIDTH) / 2f)) ;			
									//offY = ((float)objList[index].tileY*BrushY + ((BrushY - DOORWIDTH) / 2f)) ;
									break;
										}
							case ObjectInteraction.HEADINGNORTH:
									{
									offX = (objList[index].tileX*BrushX + DOORWIDTH + ((BrushX - DOORWIDTH) / 2f));												
									//offX = ((float)objList[index].tileX*BrushX + DOORWIDTH + ((BrushX - DOORWIDTH) / 2f));
									break;
									}
							case ObjectInteraction.HEADINGSOUTH:
									{
									offX = (objList[index].tileX*BrushX + ((BrushX - DOORWIDTH) / 2f)) ;
									//offX = ((float)objList[index].tileX*BrushX + ((BrushX - DOORWIDTH) / 2f)) ;
									break;
									}
							}	
								if (objList[index].x == 0){offX = offX + 2f;}
								if (objList[index].x == 7){offX = offX - 2f;}
								if (objList[index].y == 0){offY = offY + 2f;}
								if (objList[index].y == 7){offY = offY - 2f;}
							break;
						}
				default:
						{
								if (WallAdjust == 1)
								{//Adjust the object x,y to avoid clipping into walls.
										switch (game)
										{
										case Loader.GAME_SHOCK:
												if (objList[index].x == 0){	offX = offX + 0.02f;	}
												if (objList[index].x == 128){offX = offX - 0.02f;}
												if (objList[index].y == 0){offY = offY + 0.02f;}
												if (objList[index].y == 128){offY = offY - 0.02f;}
												break;
										default:
												if (objList[index].x == 0){offX = offX + 0.02f;}
												if (objList[index].x == 7){offX = offX - 0.02f;}
												if (objList[index].y == 0){offY = offY + 0.02f;}
												if (objList[index].y == 7){offY = offY - 0.02f;}
												break;
										}
								}		
								break;		
						}

				}



				return new Vector3(offX/100.0f,offZ/100.0f,offY/100.0f);
		}







		/// <summary>
		/// Renders the object list stored on this class
		/// </summary>
		public static void RenderObjectList(ObjectLoader instance, TileMap tilemap, GameObject parent)
		{
			//Clear out the children in the transform
			foreach (Transform child in parent.transform) {
					GameObject.Destroy(child.gameObject);
			}
			//Init the objects
			//instance.ObjectInteractions=new ObjectInteraction[1600];

			for (int i=0;i<=instance.objInfo.GetUpperBound(0);i++)
			{
			if (instance.objInfo[i]!=null)
				{
					if ((instance.objInfo[i].InUseFlag==1) || (UWEBase.EditorMode))
					{
						Vector3 position;
						if (tilemap==null)
						{
							position = new Vector3(99*1.2f,5f, 99*1.2f);
						}
						else
						{
							position = instance.CalcObjectXYZ(_RES,tilemap,tilemap.Tiles,instance.objInfo,i,instance.objInfo[i].tileX,instance.objInfo[i].tileY,1);
						}
					
					instance.objInfo[i].instance = ObjectInteraction.CreateNewObject(tilemap, instance.objInfo[i],parent,position);
										if(parent==GameWorldController.instance.InventoryMarker)
										{//FOr inventory objects spawned
												instance.objInfo[i].instance.PickedUp=true;	
										}
					}
				}
			}
		}


		/// <summary>
		/// Gets the object at index on the current level
		/// </summary>
		/// <returns>The <see cref="ObjectLoaderInfo"/>.</returns>
		/// <param name="index">Index.</param>
		public static ObjectLoaderInfo getObjectInfoAt (int index)
		{
			return GameWorldController.instance.CurrentObjectList().objInfo[index];
		}


		public static ObjectLoaderInfo getObjectInfoAt (int index, ObjectLoader objList)
		{
			//return GameWorldController.instance.CurrentObjectList().objInfo[index];
				return objList.objInfo[index];
		}


		/// <summary>
		/// Gets the object int at index.
		/// </summary>
		/// <returns>The <see cref="ObjectLoaderInfo"/>.</returns>
		/// <param name="index">Index.</param>
		public static  ObjectInteraction getObjectIntAt (int index)
		{
			return GameWorldController.instance.CurrentObjectList().objInfo[index].instance;
		}

		/// <summary>
		/// Gets the object masters item type for the index.
		/// </summary>
		/// <param name="index">Index.</param>
		public static int GetItemTypeAt(int index)
		{
			return GameWorldController.instance.objectMaster.type[getObjectInfoAt(index).item_id];
		}

		/// <summary>
		/// Gets the item type at index and objList.
		/// </summary>
		/// <returns>The <see cref="System.Int32"/>.</returns>
		/// <param name="index">Index.</param>
		/// <param name="objList">Object list.</param>
		public static int GetItemTypeAt(int index, ObjectLoader objList)
		{
			return GameWorldController.instance.objectMaster.type[getObjectInfoAt(index,objList).item_id];
		}


		/// <summary>
		/// Gets the game object at index.
		/// </summary>
		/// <returns>The <see cref="UnityEngine.GameObject"/>.</returns>
		/// <param name="index">Index.</param>
		public static GameObject getGameObjectAt(int index)
		{
			if (GameWorldController.instance.CurrentObjectList().objInfo[index].instance!=null)
			{
				return GameWorldController.instance.CurrentObjectList().objInfo[index].instance.gameObject;
			}
			else
			{
				return null;
			}
		}

		/// <summary>
		/// Creates the new object list with just the items in the object marker.
		/// </summary>
		public static void UpdateObjectList(TileMap currTileMap, ObjectLoader currObjList)
		{
			if (currObjList==null){return;}
			//TileMap currTileMap= GameWorldController.instance.currentTileMap();
			//ObjectLoader currObjList = GameWorldController.instance.CurrentObjectList();
			int[,] nexts= new int[64,64]; //What was the last object found at this tile for next assignments.
			//Update indices to match the array.

			for (int i =0; i<=	currObjList.objInfo.GetUpperBound(0);i++ )
			{
				currObjList.objInfo[i].index=i;
				currObjList.objInfo[i].next=0;
					if (currObjList.objInfo[i].instance!=null)
					{
						//currObjList.objInfo[i].instance.debugindex=i;
						currObjList.objInfo[i].instance.next=0;				
					}
				
				//GameWorldController.instance.CurrentObjectList().objInfo[i].tileX=99;
				//GameWorldController.instance.CurrentObjectList().objInfo[i].tileY=99;
			}

			if (currTileMap!=null)
			{
					//Clear the tilemaps indexobjectlist
					for (int x=0;x<=TileMap.TileMapSizeX;x++){
						for (int y=0;y<=TileMap.TileMapSizeY;y++){
								currTileMap.Tiles[x,y].indexObjectList=0;
							}
					}		
			}

			foreach (Transform t in GameWorldController.instance.ObjectMarker.transform) 
			{
				if (t.gameObject.GetComponent<ObjectInteraction>()!=null)
				{
					ObjectInteraction objInt = t.gameObject.GetComponent<ObjectInteraction>();
					//Copy back the info stored on the object interaction to the lists.
						if (objInt.objectloaderinfo==null)
							{
							objInt.objectloaderinfo=new ObjectLoaderInfo();
							objInt.objectloaderinfo.InUseFlag=0;
							objInt.objectloaderinfo.tileX=99;
							objInt.objectloaderinfo.tileY=99;
							}
						objInt.UpdatePosition(); //Update the coordinates and tile x and y of the object
						if (objInt.objectloaderinfo.InUseFlag==1)
							{
								currObjList.CopyDataToList(objInt,ref objInt.objectloaderinfo);		
							}	
							if ((t.gameObject.GetComponent<Container>()) || (t.gameObject.GetComponent<NPC>()))
							{//Rebuild container chain
								linkContainerContents(t.gameObject.GetComponent<Container>());
								t.gameObject.GetComponent<ObjectInteraction>().link=0;
								//objInt.objectloaderinfo.link=0;
							}
						}
				}

				//rebuild the linked list
				for (int i =0; i<=	currObjList.objInfo.GetUpperBound(0);i++ )
				{
						int x= currObjList.objInfo[i].tileX;
						int y=currObjList.objInfo[i].tileY;
						if (currObjList.objInfo[i].InUseFlag==1)
						{
								if  ((x !=TileMap.ObjectStorageTile) && (y!=TileMap.ObjectStorageTile))
								{
										if (nexts[x,y] == 0)		
										{//This object is the first in the chain at this tile
												currTileMap.Tiles[x,y].indexObjectList= i;
												nexts[x,y] = i;
										}
										else
										{
												currObjList.objInfo[nexts[x,y]].next = (long)i;
												currObjList.objInfo[nexts[x,y]].instance.next=(long)i;
												nexts[x,y] = i;
										}
								}	
						}
				}
		}


		/// <summary>
		/// Creates the new object list with just the items in the object marker.
		/// </summary>
		/// <returns>The inventory object list.</returns>
		public static string[] UpdateInventoryObjectList()
		{
			PlayerInventory pInv = GameWorldController.instance.playerUW.playerInventory;
			int NoOfInventoryItems=0;
			GameObject Prev=null;
			foreach (Transform child in GameWorldController.instance.InventoryMarker.transform) {
				if (child!=null)
				{
					NoOfInventoryItems++;	
					//Initialise the next value to zero.
					child.gameObject.GetComponent<ObjectInteraction>().next=0;
				}
			}
			//Store the objects in an array to give them indices
			string[] InventoryObjects= new string[NoOfInventoryItems];
			int i=0;
				//First add the objects on the paperdoll to the so that they are first.
				for (int s=0; s<=18;s++)
				{
						string objName="";
					if (s<=10)//Paperdoll objects
						{
						objName = pInv.GetObjectAtSlot(s);
						}
					else
						{
							objName =pInv.playerContainer.GetItemAt(s-11);		
						}
						if (objName!="")
						{
							InventoryObjects[i++]=objName;
						}
				}
			foreach (Transform child in GameWorldController.instance.InventoryMarker.transform) {
				if (child!=null)
				{
					if (System.Array.IndexOf(InventoryObjects,child.name)<0)//No match.
					{
							InventoryObjects[i++]=child.name;	
					}						
				}
			}

			int itemIndex=0;
			//Go through each slot
			
			for (int s=0; s<=18;s++)
			{
				GameObject obj;
				if (s<=10)//Paperdoll objects
				{
					obj=pInv.GetGameObjectAtSlot(s);	
				}
				else
				{
					obj= pInv.playerContainer.GetGameObjectAt(s-11);		
				}
				if(obj!=null)
				{
					if (obj.GetComponent<Container>()!=null)		
					{
						linkInventoryContainers(obj.GetComponent<Container>(), ref InventoryObjects);	
					}	
					if (Prev!=null)
					{
						Prev.GetComponent<ObjectInteraction>().next = System.Array.IndexOf(InventoryObjects,obj.name)+1;
					}
					Prev=obj;
				}
			}
			return InventoryObjects;
		}


		/// <summary>
		/// Links the inventory list containers.
		/// </summary>
		/// <param name="cn">Cn.</param>
		/// <param name="InventoryObjects">Inventory objects.</param>
		static void linkInventoryContainers(Container cn, ref string[] InventoryObjects)
		{
			bool cnLinked=false;
			cn.gameObject.GetComponent<ObjectInteraction>().link=0;//Initially unlinked.
			int index= System.Array.IndexOf(InventoryObjects,cn.name)+1;
			GameObject prev=null;
			//int newindex=index;
			//For each spot in the container
			for (int i=0; i<=cn.MaxCapacity();i++)
			{
				//Get the item name in the container
				string itemname=cn.GetItemAt(i);
				if (itemname!="")
				{
					//Get the object
					GameObject obj = GameObject.Find(itemname);
					if (obj!=null)
					{
						index= System.Array.IndexOf(InventoryObjects,obj.name)+1;
						if (cnLinked==false)	
						{//The container is first linked to this object							
							cn.gameObject.GetComponent<ObjectInteraction>().link = index;
							cnLinked=true;
							prev=obj;
						}
						else
						{//The object needs to be a next of the previous object
							//index= System.Array.IndexOf(InventoryObjects,obj.name);
							prev.GetComponent<ObjectInteraction>().next=index;
							prev=obj;
						}						
						if (obj.GetComponent<Container>()!=null)
						{//if a container then link the items in that container.
							linkInventoryContainers(obj.GetComponent<Container>(), ref InventoryObjects);	
						}
					}
				}
			}
		}

		static void linkContainerContents(Container cn)
		{
			int itemCounter=0;
			ObjectInteraction cnObjInt = cn.gameObject.GetComponent<ObjectInteraction>();
			int PrevIndex=cnObjInt.objectloaderinfo.index;
			for (int i=0; i<cn.GetCapacity();i++)
			{
				GameObject obj= cn.GetGameObjectAt(i);	
				if(obj != null)
				{
					ObjectInteraction itemObjInt= obj.GetComponent<ObjectInteraction>();
					if (itemCounter==0)
					{//First item link to the container
						cnObjInt.link=  itemObjInt.objectloaderinfo.index;		
						cnObjInt.objectloaderinfo.link= itemObjInt.objectloaderinfo.index;	
						PrevIndex=itemObjInt.objectloaderinfo.index;
					}
					else
					{//next item next onto previous item.
						ObjectLoader.getObjectIntAt(PrevIndex).next=itemObjInt.objectloaderinfo.index;
						ObjectLoader.getObjectIntAt(PrevIndex).objectloaderinfo.next= itemObjInt.objectloaderinfo.index;
						itemObjInt.next=0;//end for now.
						itemObjInt.objectloaderinfo.next=0;
						PrevIndex=itemObjInt.objectloaderinfo.index;
					}
					itemCounter++;
					
					//If a container then link its contents as well
					if (obj.GetComponent<Container>())
					{//Rebuild container chain
						linkContainerContents(obj.GetComponent<Container>());
					}
				}

			}
		}

		/// <summary>
		/// Gets the object index currently at the tile.
		/// </summary>
		/// <returns>The tile index next.</returns>
		/// <param name="tileX">Tile x.</param>
		/// <param name="tileY">Tile y.</param>
		public static int GetTileIndexNext(int tileX, int tileY)
		{
				return	GameWorldController.instance.currentTileMap().Tiles[tileX,tileY].indexObjectList;
		}


		/// <summary>
		/// Assigns the object to the object list and returns the index it is at.
		/// </summary>
		/// <returns>The object to list.</returns>
		/// <param name="objInt">Object int.</param>
		public static int AssignObjectToList(ref ObjectInteraction objInt)
		{
				int index;
				int startindex=1;
				//Check if objINt is an npc
				if ((objInt.GetComponent<NPC>()==null))
				{
					startindex= 256;
				}
				//find a free slot in the list.
				if(GameWorldController.instance.CurrentObjectList().getFreeSlot(startindex, out index))
				{		
					//Assign and return the reference
					objInt.objectloaderinfo= GameWorldController.instance.CurrentObjectList().objInfo[index];
					objInt.objectloaderinfo.InUseFlag=1;
					objInt.objectloaderinfo.index=index;
						//Debug.Log("Assigning "+ objInt.name + " to index " + index);
					if ((objInt.GetComponent<Container>()) || (objInt.GetComponent<NPC>()))
						{//Put the container items back into the list as well
								Container cn = objInt.GetComponent<Container>();
								int itemCounter=0;
								int prevLink=index;
								for (int i=0; i<=cn.GetCapacity();i++)
								{
									GameObject obj= cn.GetGameObjectAt(i);
									if(obj != null)
									{
										ObjectInteraction objI=obj.GetComponent<ObjectInteraction>();
										int newlink = AssignObjectToList(ref objI);
										if(itemCounter==0)
										{//First object											
											objInt.link=newlink;
											objInt.objectloaderinfo.link=newlink;
											prevLink= newlink;
										}
										else
										{														
											GameWorldController.instance.CurrentObjectList().objInfo[prevLink].next=newlink;
											GameWorldController.instance.CurrentObjectList().objInfo[prevLink].instance.next=newlink;
											prevLink= newlink;											
											
										}
										objI.objectloaderinfo.next=0;//init
										objI.next=0;
										itemCounter++;
									}
								}
								if(itemCounter==0)
								{
									objInt.link=0;//No contents
								}
						}
					GameWorldController.instance.CurrentObjectList().CopyDataToList(objInt,ref objInt.objectloaderinfo);
				}	
				return index;
		}

		/// <summary>
		/// Gets the free slot available to use starting from the specified index.
		/// </summary>
		/// <returns>The free slot.</returns>
		public bool getFreeSlot(int startIndex, out int index)
		{
			for (int i=startIndex; i<=objInfo.GetUpperBound(0);i++)
			{
				if(objInfo[i].InUseFlag==0)	
				{
					index=i;
					return true;
				}
			}
			index=-1;
			return false;
		}
		

		void CopyDataToList(ObjectInteraction objInt, ref ObjectLoaderInfo info )
		{
			info.item_id= objInt.item_id;
			info.flags= objInt.flags;	//9-12
			info.enchantment= objInt.enchantment;	//12
			info.doordir= objInt.doordir;	//13
			info.invis= objInt.invis;		//14
			//if (objInt.isQuant())
			//{
				info.is_quant= objInt.isquant;	//15						
			//}
			//else
			//{
				//info.is_quant= 0;	//15	
			//}


			//info.texture= objInt.texture;	// Note: some objects don't have flags and use the whole lower byte as a texture number
			//(gravestone, picture, lever, switch, shelf, bridge, ..)

			info.zpos= objInt.zpos;    //  0- 6   7   "zpos"      Object Z position (0-127)
			info.heading= objInt.heading;	//        7- 9   3   "heading"   Heading (*45 deg)
			info.x= objInt.x; //   10-12   3   "ypos"      Object Y position (0-7)
			info.y= objInt.y; //  13-15   3   "xpos"      Object X position (0-7)
			//0004 quality / chain
			info.quality= objInt.quality;	//;     0- 5   6   "quality"   Quality
			info.next= objInt.next; //    6-15   10  "next"      Index of next object in chain

			//0006 link / special
			//     0- 5   6   "owner"     Owner / special

			info.owner= objInt.owner;	//Also special
			//     6-15   10  (*)         Quantity / special link / special property

			info.link= objInt.link	;	//also quantity	
			
			info.tileX=objInt.tileX;
			info.tileY=objInt.tileY;

				//Npcs specific
				if (info.index<256)
				{
						NPC npc = objInt.GetComponent<NPC>();
						if (npc!=null)
						{
								//The values stored in the NPC info area (19 bytes) contain infos for
								//critters unique to each object.
								//0008 
								info.npc_hp=npc.npc_hp;	//0-7
								//0009	
								//blank?
								//000a   
								//blank?
								//000b   Int16      
								info.npc_goal=(short)npc.npc_goal;	//0-3
								info.npc_gtarg=(short)npc.npc_gtarg;    //4-11   
								//000d        
								info.npc_level=(short)npc.npc_level;	//0-3
								info.npc_talkedto=(short)npc.npc_talkedto;   //13     
								info.npc_attitude=(short)npc.npc_attitude;	//14-15
								//000f    
								//info.npc_height=npc.npc_height ;//6- 12 ?
								//0016  
								info.npc_yhome=(short)npc.npc_yhome;	// 4-9    
								info.npc_xhome=(short)npc.npc_xhome; // 10-15  
								//0018   0010   Int8   0-4:   npc_heading?
								//info.npc_heading=npc.npc_heading;
								//   0019      Int8   0-6:   
								info.npc_hunger=(short)npc.npc_hunger; //(?)
								//001a   0012   Int8          
								info.npc_whoami=(short)npc.npc_whoami;

								info.npc_health=(short)npc.npc_health;
								info.npc_arms=(short)npc.npc_arms;
								info.npc_power = (short)npc.npc_power;
								info.npc_name = (short)npc.npc_name;		
						}
				}


			//Match the two instances
			info.instance=objInt;
			objInt.objectloaderinfo=info;
		}


		/// <summary>
		/// Creates a new object in the static object section of the list.
		/// </summary>
		/// <returns>The object.</returns>
		public static ObjectLoaderInfo newObject(int item_id, int quality, int owner, int link)
		{
			int index=0;
			if (GameWorldController.instance.CurrentObjectList().getFreeSlot(256, out index)	)
			{
				GameWorldController.instance.CurrentObjectList().objInfo[index].quality=quality;
				GameWorldController.instance.CurrentObjectList().objInfo[index].flags=0;
				GameWorldController.instance.CurrentObjectList().objInfo[index].owner=owner;
				GameWorldController.instance.CurrentObjectList().objInfo[index].item_id=item_id;
				GameWorldController.instance.CurrentObjectList().objInfo[index].next=0;
				GameWorldController.instance.CurrentObjectList().objInfo[index].link=link;
				GameWorldController.instance.CurrentObjectList().objInfo[index].zpos=0;
				GameWorldController.instance.CurrentObjectList().objInfo[index].x=0;
				GameWorldController.instance.CurrentObjectList().objInfo[index].y=0;
				GameWorldController.instance.CurrentObjectList().objInfo[index].tileX=TileMap.ObjectStorageTile;
				GameWorldController.instance.CurrentObjectList().objInfo[index].tileY=TileMap.ObjectStorageTile;
				GameWorldController.instance.CurrentObjectList().objInfo[index].InUseFlag=1;
				GameWorldController.instance.CurrentObjectList().objInfo[index].index=index;
				return GameWorldController.instance.CurrentObjectList().objInfo[index];
			}
			return null;
		}




	void replaceLink(ref xrefTable[] xref, int tableSize, int indexToFind, int linkToReplace)
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

	void replaceMapLink(ref TileInfo[,]levelInfo, int indexToFind, int linkToReplace)
	{//Replaces the specified object index (into tile) if it is a duplicate per the xref/master table reconciliaton.
		if ((indexToFind==0) && (linkToReplace ==0))
		{return;}

		for (int x=0;x<=TileMap.TileMapSizeX;x++)
		{
			for(int y=0;y<=TileMap.TileMapSizeY;y++)
			{
				{
					if (levelInfo[x,y].indexObjectList == indexToFind)
					{
						levelInfo[x,y].indexObjectList=linkToReplace;
					}
				}
			}
		}
	}




		int getShockObjectIndex(int objClass, int objSubClass, int objSubClassIndex)
		{//Find the specified object in the array of shock objectmasters
			
			for (int i=0;i<=GameWorldController.instance.objectMaster.objClass.GetUpperBound(0);i++)
			{
						
				if (
					(GameWorldController.instance.objectMaster.objClass[i] == objClass)
					&&
					(GameWorldController.instance.objectMaster.objSubClass[i] == objSubClass)
					&&
					(GameWorldController.instance.objectMaster.objSubClassIndex[i] == objSubClassIndex)
				)
				{
					return i;
				}
			}
			return -1;	//not found
		}





		bool lookUpSubClass(char[] archive_ark,TileInfo[,] LevelInfo, int BlockNo, int ClassType, int index, int RecordSize, xrefTable[] xRef,ObjectLoaderInfo[] objList, int[] texture_map, int objIndex, int levelNo)
	{
			//

			//unsigned char *sub_ark ;
			//long chunkUnpackedLength;
			//long chunkType;//compression type
			//long chunkPackedLength;

			//long chunkUnpackedLength =LoadShockChunk(filePath,BlockNo,sub_ark);

			//long blockAddress =getShockBlockAddress(BlockNo,archive_ark,&chunkPackedLength,&chunkUnpackedLength,&chunkType); 
			//if (blockAddress == -1) {return -1;}
			//sub_ark=new unsigned char[chunkUnpackedLength];
			//fprintf(LOGFILE,"\nLoading Chunk at %d\n",blockAddress);
			//LoadShockChunk(blockAddress,chunkType,archive_ark,sub_ark,chunkPackedLength,chunkUnpackedLength);
			DataLoader.Chunk sub_ark;
			if (!DataLoader.LoadChunk(archive_ark, BlockNo, out sub_ark))
			{
				return false;
			}

			int k= 0;
			int add_ptr=0;

			while (k<=sub_ark.chunkUnpackedLength)
			{
					if (k==index)
					{
							switch(ClassType)
							{
							case SOFTWARE_LOGS:
									{
												objList[objIndex].shockProperties[SOFT_PROPERTY_VERSION]=(int)DataLoader.getValAtAddress(sub_ark.data,add_ptr+6,8);	//Software version
												objList[objIndex].shockProperties[SOFT_PROPERTY_LOG]=(int)DataLoader.getValAtAddress(sub_ark.data,add_ptr+7,8) + 2488;	//Chunk containing log
												objList[objIndex].shockProperties[SOFT_PROPERTY_LEVEL]=(int)DataLoader.getValAtAddress(sub_ark.data,add_ptr+8,8);	//Level No of Chunk
										//fprintf(LOGFILE,"\tSoftware Properties\n");
										//fprintf(LOGFILE,"\t\tVersion %d",objList[objIndex].shockProperties[SOFT_PROPERTY_VERSION]);
										//fprintf(LOGFILE,"\tLog Chunk %d",objList[objIndex].shockProperties[SOFT_PROPERTY_LOG]);
										//fprintf(LOGFILE,"\tLevel %d",objList[objIndex].shockProperties[SOFT_PROPERTY_LEVEL]);
										return true;
										//break;
									}
							case FIXTURES:
									{
											//fprintf(LOGFILE,"\tFixture Properties\n");
											switch (objList[objIndex].ObjectSubClass)
											{
											case 0://regular fixtures
											case 1:
											case 3:
											case 4:
											case 5:
											case 6:
														//fprintf(LOGFILE,"\n\tVal 0x6: %d", getValAtAddress(sub_ark.data, add_ptr + 6, 16));
														//fprintf(LOGFILE,"\n\tVal 0x8: %d", getValAtAddress(sub_ark.data, add_ptr + 8, 16));
														//fprintf(LOGFILE,"\n\tVal 0xA: %d", getValAtAddress(sub_ark.data, add_ptr + 0xA, 16));
														//fprintf(LOGFILE,"\n\tVal 0xC: %d", getValAtAddress(sub_ark.data, add_ptr + 0xC, 16));
														//fprintf(LOGFILE,"\n\tVal 0xE: %d", getValAtAddress(sub_ark.data, add_ptr + 0xE, 16));
													break;
											case 2:
													switch (objList[objIndex].ObjectSubClassIndex)
													{
													case 0://SIGN
													case 1://ICON
													case 2://GRAFFITI
													case 4://painting
													case 5://poster
															//fprintf(LOGFILE,"\n\tImage to use is value in unk1. Offset from image 1350_0390.bmp or 1350_0403.bmp in objart.res or 0078_0000.bmp or 0079_0000 in objart3.res");
															break;
													case 3:
															{
																	//based on SSHP interpretation
																	int[] fontID = { 4, 7, 0, 10 };
																	//float[] scale= { 1.0f, 0.75f, 0.5f, 0.25f };
																	//fprintf(LOGFILE,"Words:");
																		objList[objIndex].shockProperties[WORDS_STRING_NO] = (int)DataLoader.getValAtAddress(sub_ark.data, add_ptr + 6, 16);
																		//fprintf(LOGFILE,"\nSub chunk %d (from chunk 2152)", getValAtAddress(sub_ark.data, add_ptr + 6, 16));
																		int FontNSize = (int)DataLoader.getValAtAddress(sub_ark.data, add_ptr + 8, 16);
																	//fprintf(LOGFILE,"\nFont %d (+chunk 602)", fontID[FontNSize & 0x03]);
																	objList[objIndex].shockProperties[WORDS_FONT] = fontID[FontNSize & 0x03] + 602;
																	//fprintf(LOGFILE,"\nSize %d ", fontID[FontNSize>>4 & 0x03]);
																	objList[objIndex].shockProperties[WORDS_SIZE] = fontID[FontNSize >> 4 & 0x03];
																	//fprintf(LOGFILE,"\nColour %d ", getValAtAddress(sub_ark, add_ptr + 0xA, 16));
																		objList[objIndex].shockProperties[WORDS_COLOUR] = (int)DataLoader.getValAtAddress(sub_ark.data, add_ptr + 0xA, 16);
																		//fprintf(LOGFILE,"\n\tVal 0x6: %d", getValAtAddress(sub_ark.data, add_ptr + 6, 16));
																		//fprintf(LOGFILE,"\n\tVal 0x8: %d", getValAtAddress(sub_ark.data, add_ptr + 8, 16));
																		//fprintf(LOGFILE,"\n\tVal 0xA: %d", getValAtAddress(sub_ark.data, add_ptr + 0xA, 16));
																		//fprintf(LOGFILE,"\n\tVal 0xC: %d", getValAtAddress(sub_ark.data, add_ptr + 0xC, 16));
																		//fprintf(LOGFILE,"\n\tVal 0xE: %d", getValAtAddress(sub_ark.data, add_ptr + 0xE, 16));
																	break;
															}
													case 6:
													case 8:
													case 9:
															//fprintf(LOGFILE,"Screens:");
																objList[objIndex].shockProperties[SCREEN_NO_OF_FRAMES] = (int)DataLoader.getValAtAddress(sub_ark.data, add_ptr + 6, 16);
																objList[objIndex].shockProperties[SCREEN_LOOP_FLAG] = (int)DataLoader.getValAtAddress(sub_ark.data, add_ptr + 8, 16);
																objList[objIndex].shockProperties[SCREEN_START] = (int)DataLoader.getValAtAddress(sub_ark.data, add_ptr + 0xC, 16);
															//fprintf(LOGFILE,"\nNo of Frames: %d", objList[objIndex].shockProperties[SCREEN_NO_OF_FRAMES]);
															//fprintf(LOGFILE,"\nLoop repeats: %d ", objList[objIndex].shockProperties[SCREEN_LOOP_FLAG]);
															//fprintf(LOGFILE,"\nStart Frame: %d (from chunk 321) = %d", objList[objIndex].shockProperties[SCREEN_START], 321 + objList[objIndex].shockProperties[SCREEN_START]);
															if ((objList[objIndex].shockProperties[SCREEN_START] >= 248) && (objList[objIndex].shockProperties[SCREEN_START] <= 255))
															{//Survellance
																	//unsigned char *sur_ark;
																		DataLoader.Chunk sur_ark;
																		if (DataLoader.LoadChunk(archive_ark,levelNo * 100 + SURVELLANCE_OFFSET,out sur_ark))
																		{
																				
																				//fprintf(LOGFILE, "\n\tSurvellance Chunk at %d\n", blockAddress);
																				//LoadShockChunk(blockAddress, chunkType, archive_ark, sur_ark, chunkPackedLength, chunkUnpackedLength);
																				objList[objIndex].shockProperties[SCREEN_SURVEILLANCE_TARGET] = (int)DataLoader.getValAtAddress(sur_ark.data, (objList[objIndex].shockProperties[SCREEN_START]-248)*2, 16);
																				//fprintf(LOGFILE, "\tSurveillance item id: %d", objList[objIndex].shockProperties[SCREEN_SURVEILLANCE_TARGET]);
																					
																		}

															}
															break;
													default:
																//fprintf(LOGFILE,"\n\tVal 0x6: %d", getValAtAddress(sub_ark.data, add_ptr + 6, 16));
																//fprintf(LOGFILE,"\n\tVal 0x8: %d", getValAtAddress(sub_ark.data, add_ptr + 8, 16));
																//fprintf(LOGFILE,"\n\tVal 0xA: %d", getValAtAddress(sub_ark.data, add_ptr + 0xA, 16));
																//fprintf(LOGFILE,"\n\tVal 0xC: %d", getValAtAddress(sub_ark.data, add_ptr + 0xC, 16));
																//fprintf(LOGFILE,"\n\tVal 0xE: %d", getValAtAddress(sub_ark.data, add_ptr + 0xE, 16));
															break;
													}
													break;
											case 7:	//bridges etc
														int val =  (int)DataLoader.getValAtAddress(sub_ark.data, add_ptr + 0x8, 8);
													objList[objIndex].shockProperties[BRIDGE_X_SIZE] = val & 0xF;
													objList[objIndex].shockProperties[BRIDGE_Y_SIZE] = (val >>4) & 0xF;
													objList[objIndex].shockProperties[BRIDGE_HEIGHT] =  (int)DataLoader.getValAtAddress(sub_ark.data, add_ptr + 0x9, 8);
													val =  (int)DataLoader.getValAtAddress(sub_ark.data, add_ptr + 0xA, 8);
													objList[objIndex].shockProperties[BRIDGE_TOP_BOTTOM_TEXTURE_SOURCE] = (val >> 7) & 0x1;
													if (objList[objIndex].shockProperties[BRIDGE_TOP_BOTTOM_TEXTURE_SOURCE]==1)//Retrieve from texture map
													{
															objList[objIndex].shockProperties[BRIDGE_TOP_BOTTOM_TEXTURE] = texture_map[val & 0x7F];
													}
													else
													{
															objList[objIndex].shockProperties[BRIDGE_TOP_BOTTOM_TEXTURE] = val & 0x7F;
													}

													val =  (int)DataLoader.getValAtAddress(sub_ark.data, add_ptr + 0xB, 8);
													objList[objIndex].shockProperties[BRIDGE_SIDE_TEXTURE_SOURCE] = (val >> 7) & 0x1;
													if (objList[objIndex].shockProperties[BRIDGE_SIDE_TEXTURE_SOURCE] == 1)//Retrieve from texture map
													{
															objList[objIndex].shockProperties[BRIDGE_SIDE_TEXTURE] = texture_map[val & 0x7F];
													}
													else
													{
															objList[objIndex].shockProperties[BRIDGE_SIDE_TEXTURE] = val & 0x7F;
													}
													//fprintf(LOGFILE, "\n\tBridge X Size : %d", objList[objIndex].shockProperties[BRIDGE_X_SIZE]);
													//fprintf(LOGFILE, "\n\tBridge Y Size : %d", objList[objIndex].shockProperties[BRIDGE_Y_SIZE]);
													//fprintf(LOGFILE, "\n\tBridge Height : %d", objList[objIndex].shockProperties[BRIDGE_HEIGHT]);
													//fprintf(LOGFILE, "\n\tBridge Top Texture : %d", objList[objIndex].shockProperties[BRIDGE_TOP_BOTTOM_TEXTURE]);
													//fprintf(LOGFILE, "\n\tBridge Top Texture Source : %d", objList[objIndex].shockProperties[BRIDGE_TOP_BOTTOM_TEXTURE_SOURCE]);
													//fprintf(LOGFILE, "\n\tBridge Side Texture : %d", objList[objIndex].shockProperties[BRIDGE_SIDE_TEXTURE]);
													//fprintf(LOGFILE, "\n\tBridge Side Texture Source : %d", objList[objIndex].shockProperties[BRIDGE_SIDE_TEXTURE_SOURCE]);

													/*fprintf(LOGFILE,"\n\tVal 0x6: %d", getValAtAddress(sub_ark, add_ptr + 6, 16));
					fprintf(LOGFILE,"\n\tVal 0x8: %d", getValAtAddress(sub_ark, add_ptr + 8, 16));
					fprintf(LOGFILE,"\n\tVal 0xA: %d", getValAtAddress(sub_ark, add_ptr + 0xA, 16));
					fprintf(LOGFILE,"(%d", getValAtAddress(sub_ark, add_ptr + 0xA, 8));
					fprintf(LOGFILE,",%d)", getValAtAddress(sub_ark, add_ptr + 0xB, 8));
					fprintf(LOGFILE,"\n\tVal 0xC: %d", getValAtAddress(sub_ark, add_ptr + 0xC, 16));
					fprintf(LOGFILE,"\n\tVal 0xE: %d", getValAtAddress(sub_ark, add_ptr + 0xE, 16));*/
													break;
											}



											return true;
										//	break;
									}
							case GETTABLES_OTHER:
									{
											if (objList[objIndex].item_id == 191)	//Brief case contents
											{
														objList[objIndex].shockProperties[CONTAINER_CONTENTS_1] = (int)DataLoader.getValAtAddress(sub_ark.data, add_ptr + 0x6, 16);
														objList[objIndex].shockProperties[CONTAINER_CONTENTS_2] = (int)DataLoader.getValAtAddress(sub_ark.data, add_ptr + 0x8, 16);
														objList[objIndex].shockProperties[CONTAINER_CONTENTS_3] = (int)DataLoader.getValAtAddress(sub_ark.data, add_ptr + 0xA, 16);
														objList[objIndex].shockProperties[CONTAINER_CONTENTS_4] = (int)DataLoader.getValAtAddress(sub_ark.data, add_ptr + 0xC, 16);
												//	fprintf(LOGFILE,"\tContents 1 : %d\n", objList[objIndex].shockProperties[CONTAINER_CONTENTS_1]);
													//fprintf(LOGFILE,"\tContents 2 : %d\n", objList[objIndex].shockProperties[CONTAINER_CONTENTS_2]);
													//fprintf(LOGFILE,"\tContents 3 : %d\n", objList[objIndex].shockProperties[CONTAINER_CONTENTS_3]);
													//fprintf(LOGFILE,"\tContents 4 : %d\n", objList[objIndex].shockProperties[CONTAINER_CONTENTS_4]);
											}

											//for (int j = 0; j < RecordSize; j = j + 2)
											//{
													//fprintf(LOGFILE,"j=%d val(16) = %d\n", j, getValAtAddress(sub_ark, add_ptr+ j, 16));
											//}

												return true;
											//break;
									}
							case SWITCHES_PANELS:
									{
											//fprintf(LOGFILE,"\n\tSwitch Properties\n");
												//fprintf(LOGFILE,"\t\tSwitch Action?:%d",getValAtAddress(sub_ark.data,add_ptr+6,16));
												//fprintf(LOGFILE,"\tVariable:%d",getValAtAddress(sub_ark.data,add_ptr+8,16));
												//fprintf(LOGFILE,"\tFail Message:%d",getValAtAddress(sub_ark.data,add_ptr+10,16));

												//TODO:Sort out the trigger action variable into a property
											objList[objIndex].TriggerAction = (int)DataLoader.getValAtAddress(sub_ark.data,add_ptr+6,16);
											getShockButtons(LevelInfo,sub_ark,add_ptr,objList,objIndex);
											return true;
											//break;
									}
							case DOORS_GRATINGS:
									{
												//TODO: Sort out locking state 
											//fprintf(LOGFILE,"\n\tDoor Properties\n");
											//	int crossref = (int)DataLoader.getValAtAddress(sub_ark.data, add_ptr + 6, 16);
										//	if (crossref != 0)
											//{
											//		objList[objIndex].SHOCKLocked  = 1;	// = crossref;	
										//	}
											//else
											//{
										//			objList[objIndex].SHOCKLocked = 0;
										//	}
											//	objList[objIndex].link = getValAtAddress(sub_ark.data, add_ptr + 10, 8);	//Link to it's key. reusage from uw.

											//fprintf(LOGFILE,"\t\tTrigger xref?:%d (%d)", xRef[crossref].MstIndex, crossref);
											//	fprintf(LOGFILE,"\tMessage:%d", getValAtAddress(sub_ark.data, add_ptr + 8, 16));
											//	fprintf(LOGFILE,"\tAccess Required:%d", getValAtAddress(sub_ark.data, add_ptr + 0xA, 8));
											//	fprintf(LOGFILE, "\tOther val:%d\n", getValAtAddress(sub_ark.data, add_ptr + 0xB, 16));
												return true;
											//break;
									}
							case	TRAPS_MARKERS: //and triggers too
									{
												//TODO: Fix conditions and trigger once values
												objList[objIndex].conditions[0] = (int)DataLoader.getValAtAddress(sub_ark.data,add_ptr+8,8);
												objList[objIndex].conditions[1] = (int)DataLoader.getValAtAddress(sub_ark.data,add_ptr+9,8);
												objList[objIndex].conditions[2] =  (int)DataLoader.getValAtAddress(sub_ark.data,add_ptr+10,8);
												objList[objIndex].conditions[3] = (int)DataLoader.getValAtAddress(sub_ark.data,add_ptr+11,8);
												objList[objIndex].TriggerOnce = (int)DataLoader.getValAtAddress(sub_ark.data,add_ptr+7,8);
											//objList[objIndex].TriggerOnceGlobal = 0;
											//fprintf(LOGFILE,"\tConditions: %d",objList[objIndex].conditions[0]);
											//fprintf(LOGFILE,",%d",objList[objIndex].conditions[1]);
											//fprintf(LOGFILE,",%d",objList[objIndex].conditions[2]);
											//fprintf(LOGFILE,",%d\n",objList[objIndex].conditions[3]);
											//fprintf(LOGFILE,"\tTrigger once: %d\n",objList[objIndex].TriggerOnce);
											//objList[objIndex].address = blockAddress+add_ptr;
											//fprintf(LOGFILE,"\tObject is at address %d\n", objList[objIndex].address);
											if (  GameWorldController.instance.objectMaster.type[objList[objIndex].item_id] == ObjectInteraction.SHOCK_TRIGGER_REPULSOR)
											{
														objList[objIndex].shockProperties[TRIG_PROPERTY_VALUE] = (int)DataLoader.getValAtAddress(sub_ark.data, add_ptr + 21, 8);
														objList[objIndex].shockProperties[TRIG_PROPERTY_FLAG] = (int)DataLoader.getValAtAddress(sub_ark.data, add_ptr + 24, 8);
													//fprintf(LOGFILE,"\tRepulsor Upwards Displacement is %d\n", objList[objIndex].shockProperties[TRIG_PROPERTY_VALUE]);
													if (objList[objIndex].shockProperties[TRIG_PROPERTY_FLAG] == 1)
													{
															//fprintf(LOGFILE,"\tRepulsor is off (%d)\n", objList[objIndex].shockProperties[TRIG_PROPERTY_FLAG]);
													}
													else
													{
															//fprintf(LOGFILE,"\tRepulsor is on (%d)\n", objList[objIndex].shockProperties[TRIG_PROPERTY_FLAG]);
													}
											}
											else
											{
													getShockTriggerAction(LevelInfo, sub_ark, add_ptr, xRef, objList, objIndex);
											}


											return true;
											//break;
										}
											case CONTAINERS_CORPSES:
											//fprintf(LOGFILE,"\n\tContainer Properties\n");
										objList[objIndex].shockProperties[CONTAINER_CONTENTS_1] = (int)DataLoader.getValAtAddress(sub_ark.data, add_ptr + 0x6, 16);
										objList[objIndex].shockProperties[CONTAINER_CONTENTS_2] = (int)DataLoader.getValAtAddress(sub_ark.data, add_ptr + 0x8, 16);
										objList[objIndex].shockProperties[CONTAINER_CONTENTS_3] = (int)DataLoader.getValAtAddress(sub_ark.data, add_ptr + 0xA, 16);
										objList[objIndex].shockProperties[CONTAINER_CONTENTS_4] =(int)DataLoader.getValAtAddress(sub_ark.data, add_ptr + 0xC, 16);
										objList[objIndex].shockProperties[CONTAINER_WIDTH] = (int)DataLoader.getValAtAddress(sub_ark.data, add_ptr + 0xE, 8);
										objList[objIndex].shockProperties[CONTAINER_HEIGHT] =(int)DataLoader.getValAtAddress(sub_ark.data, add_ptr + 0xF, 8);
										objList[objIndex].shockProperties[CONTAINER_DEPTH] = (int)DataLoader.getValAtAddress(sub_ark.data, add_ptr + 0x10, 8);
										objList[objIndex].shockProperties[CONTAINER_TOP] = (int)DataLoader.getValAtAddress(sub_ark.data, add_ptr + 0x11, 8);
										objList[objIndex].shockProperties[CONTAINER_SIDE] = (int)DataLoader.getValAtAddress(sub_ark.data, add_ptr + 0x12, 8);
											//fprintf(LOGFILE,"\tContents 1 : %d\n", objList[objIndex].shockProperties[CONTAINER_CONTENTS_1]);
											//fprintf(LOGFILE,"\tContents 2 : %d\n", objList[objIndex].shockProperties[CONTAINER_CONTENTS_2]);
											//fprintf(LOGFILE,"\tContents 3 : %d\n", objList[objIndex].shockProperties[CONTAINER_CONTENTS_3]);
											//fprintf(LOGFILE,"\tContents 4 : %d\n", objList[objIndex].shockProperties[CONTAINER_CONTENTS_4]);
											//fprintf(LOGFILE,"\tWidth : %d", objList[objIndex].shockProperties[CONTAINER_WIDTH]);
											//fprintf(LOGFILE,"\tHeight : %d", objList[objIndex].shockProperties[CONTAINER_HEIGHT]);
											//fprintf(LOGFILE,"\tDepth : %d\n", objList[objIndex].shockProperties[CONTAINER_DEPTH]);
											//fprintf(LOGFILE,"\tTop : %d", objList[objIndex].shockProperties[CONTAINER_TOP]);
											//fprintf(LOGFILE,"\tSide : %d", objList[objIndex].shockProperties[CONTAINER_SIDE]);
											return true;
											//break;
									
							case CRITTERS:
									//fprintf(LOGFILE,"\Critter Properties\n");
									//for (int j = 0; j < RecordSize; j = j + 2)
									//{
										//fprintf(LOGFILE,"\tj=%d val(16) = %d\n", j, getValAtAddress(sub_ark.data, add_ptr + j, 16));
									//}
									return true;
									//break;
							}
					}
					add_ptr+=RecordSize;
					k++;
			}
			return false;
	}







		void getShockTriggerAction(TileInfo[,] LevelInfo,DataLoader.Chunk sub_ark, int add_ptr, xrefTable[] xRef, ObjectLoaderInfo[] objList, int objIndex)
		{
				//Look up what a trigger does in system shock. Different trigger types activate other triggers/ do things in different ways.
				//short PrintDebug = 1;// (objList[objIndex].item_id == 384);
				//fprintf(LOGFILE,"",UniqueObjectName(objList[objIndex]));	//Weirdness with garbage info getting printed out?
				int TriggerType =(int)DataLoader.getValAtAddress(sub_ark.data,add_ptr+6,8);
				objList[objIndex].TriggerAction = TriggerType;
				switch (TriggerType)
				{ 
				case ObjectInteraction.ACTION_DO_NOTHING :
						{//Default action.
								/*if (PrintDebug==1)
								{
										//fprintf(LOGFILE,"\tACTION_DO_NOTHING or default for %s\n",UniqueObjectName(objList[objIndex]));
										//DebugPrintTriggerVals(sub_ark, add_ptr,28);
										//fprintf(LOGFILE,"\t\tOther values 1:%d\n",getValAtAddress(sub_ark,add_ptr+12,16));
										//fprintf(LOGFILE,"\t\tOther values 2:%d\n",getValAtAddress(sub_ark,add_ptr+14,16));
										//fprintf(LOGFILE,"\t\tOther values 3:%d\n",getValAtAddress(sub_ark,add_ptr+16,16));
										//fprintf(LOGFILE,"\t\tOther values 4:%d\n",getValAtAddress(sub_ark,add_ptr+18,16));
										//fprintf(LOGFILE,"\t\tOther values 5:%d\n",getValAtAddress(sub_ark,add_ptr+20,16));
										//fprintf(LOGFILE,"\t\tOther values 6:%d\n",getValAtAddress(sub_ark,add_ptr+22,16));		
										//fprintf(LOGFILE,"\t\tOther values 7:%d\n",getValAtAddress(sub_ark,add_ptr+24,16));		
										//fprintf(LOGFILE,"\t\tOther values 8:%d\n",getValAtAddress(sub_ark,add_ptr+26,16));	
								}	*/	
								break;	
						}
				case ObjectInteraction.ACTION_TRANSPORT_LEVEL:
						{//Sends the player to the specified position in the level.

								objList[objIndex].shockProperties[TRIG_PROPERTY_TARGET_X] = (int)DataLoader.getValAtAddress(sub_ark.data,add_ptr+12,16);	//Target X of teleport
								objList[objIndex].shockProperties[TRIG_PROPERTY_TARGET_Y] =(int)DataLoader.getValAtAddress(sub_ark.data,add_ptr+16,16); //Target Y of teleport
								objList[objIndex].shockProperties[TRIG_PROPERTY_TARGET_Z]= (int)DataLoader.getValAtAddress(sub_ark.data,add_ptr+20,16);	//Target Z of teleport

								/*if (PrintDebug==1)
								{
										//fprintf(LOGFILE,"\tACTION_TRANSPORT_LEVEL for %s\n",UniqueObjectName(objList[objIndex]));
										//fprintf(LOGFILE,"\t\tDestination (%d,%d,%d)\n",objList[objIndex].shockProperties[TRIG_PROPERTY_TARGET_X], objList[objIndex].shockProperties[TRIG_PROPERTY_TARGET_Y],objList[objIndex].shockProperties[TRIG_PROPERTY_TARGET_Z] );
										//DebugPrintTriggerVals(sub_ark, add_ptr, 28);
										//fprintf(LOGFILE,"\t\tOther values 1:%d\n",getValAtAddress(sub_ark,add_ptr+12,16));
										//fprintf(LOGFILE,"\t\tOther values 2:%d\n",getValAtAddress(sub_ark,add_ptr+14,16));
										//fprintf(LOGFILE,"\t\tOther values 3:%d\n",getValAtAddress(sub_ark,add_ptr+16,16));
										//fprintf(LOGFILE,"\t\tOther values 4:%d\n",getValAtAddress(sub_ark,add_ptr+18,16));
										//fprintf(LOGFILE,"\t\tOther values 5:%d\n",getValAtAddress(sub_ark,add_ptr+20,16));
										//fprintf(LOGFILE,"\t\tOther values 6:%d\n",getValAtAddress(sub_ark,add_ptr+22,16));		
										//fprintf(LOGFILE,"\t\tOther values 7:%d\n",getValAtAddress(sub_ark,add_ptr+24,16));		
										//fprintf(LOGFILE,"\t\tOther values 8:%d\n",getValAtAddress(sub_ark,add_ptr+26,16));	
								}	*/	
								break;
						}
				case ObjectInteraction.ACTION_RESURRECTION:
						{//Brings the player back to life?
								/*if (PrintDebug==1)
								{
										//fprintf(LOGFILE,"\tACTION_RESURRECTION for %s\n",UniqueObjectName(objList[objIndex]));
										//DebugPrintTriggerVals(sub_ark, add_ptr,30);
										//fprintf(LOGFILE,"\t\tOther values 1:%d\n",getValAtAddress(sub_ark,add_ptr+12,16));
										//fprintf(LOGFILE,"\t\tOther values 2:%d\n",getValAtAddress(sub_ark,add_ptr+14,16));
										//fprintf(LOGFILE,"\t\tOther values 3:%d\n",getValAtAddress(sub_ark,add_ptr+16,16));
										//fprintf(LOGFILE,"\t\tOther values 4:%d\n",getValAtAddress(sub_ark,add_ptr+18,16));
										//fprintf(LOGFILE,"\t\tOther values 5:%d\n",getValAtAddress(sub_ark,add_ptr+20,16));
										//fprintf(LOGFILE,"\t\tOther values 6:%d\n",getValAtAddress(sub_ark,add_ptr+22,16));		
										//fprintf(LOGFILE,"\t\tOther values 7:%d\n",getValAtAddress(sub_ark,add_ptr+24,16));		
										//fprintf(LOGFILE,"\t\tOther values 8:%d\n",getValAtAddress(sub_ark,add_ptr+26,16));	
								}*/
								objList[objIndex].shockProperties[TRIG_PROPERTY_VALUE] =(int)DataLoader.getValAtAddress(sub_ark.data,add_ptr+16,16);	//Target Health
								break;
						}
				case ObjectInteraction.ACTION_CLONE:
						{//Need to do more research on what this does?
								//	000C	int16	Object to transport.
								//	000E	int16	Delete flag?
								//	0010	int16	Tile destination X
								//	0014	int16	Tile destination Y
								//	0018	int16	Destination height?		
								/*if (PrintDebug==1)
								{
										//fprintf(LOGFILE,"\tACTION_CLONE for %s\n",UniqueObjectName(objList[objIndex]));
										//fprintf(LOGFILE,"\t\tObject to transport:%d\n",getValAtAddress(sub_ark,add_ptr+0xC,16));
										//fprintf(LOGFILE,"\t\tDeleteFlag?:%d\n",getValAtAddress(sub_ark,add_ptr+0xE,16));
										//fprintf(LOGFILE,"\t\tDestination tileX:%d\n",getValAtAddress(sub_ark,add_ptr+0x10,16));
										//fprintf(LOGFILE,"\t\tDestination tileY:%d\n",getValAtAddress(sub_ark,add_ptr+0x14,16));
										//fprintf(LOGFILE,"\t\tDestination height:%d\n",getValAtAddress(sub_ark,add_ptr+0x18,16));
										//DebugPrintTriggerVals(sub_ark, add_ptr, 28);
										//fprintf(LOGFILE,"\t\tOther values 1:%d\n",getValAtAddress(sub_ark,add_ptr+12,16));
										//fprintf(LOGFILE,"\t\tOther values 2:%d\n",getValAtAddress(sub_ark,add_ptr+14,16));
										//fprintf(LOGFILE,"\t\tOther values 3:%d\n",getValAtAddress(sub_ark,add_ptr+16,16));
										//fprintf(LOGFILE,"\t\tOther values 4:%d\n",getValAtAddress(sub_ark,add_ptr+18,16));
										//fprintf(LOGFILE,"\t\tOther values 5:%d\n",getValAtAddress(sub_ark,add_ptr+20,16));
										//fprintf(LOGFILE,"\t\tOther values 6:%d\n",getValAtAddress(sub_ark,add_ptr+22,16));		
										//fprintf(LOGFILE,"\t\tOther values 7:%d\n",getValAtAddress(sub_ark,add_ptr+24,16));		
										//fprintf(LOGFILE,"\t\tOther values 8:%d\n",getValAtAddress(sub_ark,add_ptr+26,16));	


								}*/
								objList[objIndex].shockProperties[TRIG_PROPERTY_OBJECT] =	(int)DataLoader.getValAtAddress(sub_ark.data,add_ptr+0xC,16);	//obj to transport
								objList[objIndex].shockProperties[TRIG_PROPERTY_FLAG] = (int)DataLoader.getValAtAddress(sub_ark.data,add_ptr+0x0E,16);		//Delete flag
								objList[objIndex].shockProperties[TRIG_PROPERTY_TARGET_X] = (int)DataLoader.getValAtAddress(sub_ark.data,add_ptr+0x10,16);	//Target X
								objList[objIndex].shockProperties[TRIG_PROPERTY_TARGET_Y] =(int)DataLoader.getValAtAddress(sub_ark.data,add_ptr+0x14,16);	//Target Y
								objList[objIndex].shockProperties[TRIG_PROPERTY_TARGET_Z] = (int)DataLoader.getValAtAddress(sub_ark.data,add_ptr+0x18,16);	//Target z

								break;
						}
				case ObjectInteraction.ACTION_SET_VARIABLE:
						{//Sets a game variable. I don't yet know what the various variables are. I suspect they may be in the exe so I'll have to just observe them in the wild?
								//000C	int16	variable to set
								//0010	int16	value
								//0012	int16	?? action 00 set 01 add
								//0014	int16	Optional message to receive
								/*if (PrintDebug==1)
								{
										//fprintf(LOGFILE,"\tACTION_SET_VARIABLE for %s\n",UniqueObjectName(objList[objIndex]));
										//fprintf(LOGFILE,"\t\tVariable to Set:%d\n",getValAtAddress(sub_ark,add_ptr+0xC,16));
										//fprintf(LOGFILE,"\t\tValue:%d",getValAtAddress(sub_ark,add_ptr+0x10,16));
										//fprintf(LOGFILE,"\t\taction?:%d (00 set 01 add)\n",getValAtAddress(sub_ark,add_ptr+0x12,16));
										//fprintf(LOGFILE,"\t\tOptional Message:%d\n",getValAtAddress(sub_ark,add_ptr+0x14,16));
										//DebugPrintTriggerVals(sub_ark, add_ptr, 28);
										/*					fprintf(LOGFILE,"\t\tOther values 1:%d\n",getValAtAddress(sub_ark,add_ptr+12,16));
					fprintf(LOGFILE,"\t\tOther values 2:%d\n",getValAtAddress(sub_ark,add_ptr+14,16));
					fprintf(LOGFILE,"\t\tOther values 3:%d\n",getValAtAddress(sub_ark,add_ptr+16,16));
					fprintf(LOGFILE,"\t\tOther values 4:%d\n",getValAtAddress(sub_ark,add_ptr+18,16));
					fprintf(LOGFILE,"\t\tOther values 5:%d\n",getValAtAddress(sub_ark,add_ptr+20,16));
					fprintf(LOGFILE,"\t\tOther values 6:%d\n",getValAtAddress(sub_ark,add_ptr+22,16));		
					fprintf(LOGFILE,"\t\tOther values 7:%d\n",getValAtAddress(sub_ark,add_ptr+24,16));		
					fprintf(LOGFILE,"\t\tOther values 8:%d\n",getValAtAddress(sub_ark,add_ptr+26,16));	*/					
							//	}
								objList[objIndex].shockProperties[TRIG_PROPERTY_VARIABLE] =(int)DataLoader.getValAtAddress(sub_ark.data,add_ptr+0xC,16);
								objList[objIndex].shockProperties[TRIG_PROPERTY_VALUE] = (int)DataLoader.getValAtAddress(sub_ark.data,add_ptr+0x10,16);
								objList[objIndex].shockProperties[TRIG_PROPERTY_OPERATION]=(int)DataLoader.getValAtAddress(sub_ark.data,add_ptr+0x12,16);
								objList[objIndex].shockProperties[TRIG_PROPERTY_MESSAGE1]=(int)DataLoader.getValAtAddress(sub_ark.data,add_ptr+0x14,16);

								break;
						}
				case ObjectInteraction.ACTION_ACTIVATE:
						{//Turns on up to 4 other triggers.
								//000C	int16	1st object to activate.
								//000E	int16	Delay before activating object 1.
								//0010	...	Up to 4 objects and delays stored here.	
								objList[objIndex].shockProperties[0] = (int)DataLoader.getValAtAddress(sub_ark.data,add_ptr+0xC,16)		;					
								objList[objIndex].shockProperties[1] = (int)DataLoader.getValAtAddress(sub_ark.data,add_ptr+0xe,16)		;
								objList[objIndex].shockProperties[2] = (int)DataLoader.getValAtAddress(sub_ark.data,add_ptr+0x10,16)		;
								objList[objIndex].shockProperties[3] = (int)DataLoader.getValAtAddress(sub_ark.data,add_ptr+0x12,16)		;
								objList[objIndex].shockProperties[4] = (int)DataLoader.getValAtAddress(sub_ark.data,add_ptr+0x14,16)		;
								objList[objIndex].shockProperties[5] = (int)DataLoader.getValAtAddress(sub_ark.data,add_ptr+0x16,16)		;
								objList[objIndex].shockProperties[6] = (int)DataLoader.getValAtAddress(sub_ark.data,add_ptr+0x18,16)		;
								objList[objIndex].shockProperties[7] = (int)DataLoader.getValAtAddress(sub_ark.data,add_ptr+0x1A,16)		;
								/*if (PrintDebug==1)
								{	
										//fprintf(LOGFILE,"\tACTION_ACTIVATE for %s\n",UniqueObjectName(objList[objIndex]));

										//fprintf(LOGFILE,"\t\t1st Object to activate raw :%d\t",objList[objIndex].shockProperties[0]);
										//fprintf(LOGFILE,"1st Object Delay:%d\n",objList[objIndex].shockProperties[1]);

										//fprintf(LOGFILE,"\t\t2nd Object to activate raw :%d\t",objList[objIndex].shockProperties[2]);		
										//fprintf(LOGFILE,"2nd Object Delay:%d\n",objList[objIndex].shockProperties[3]);

										//fprintf(LOGFILE,"\t\t3rd Object to activate raw :%d\t",objList[objIndex].shockProperties[4]);
										//fprintf(LOGFILE,"3rd Object Delay:%d\n",objList[objIndex].shockProperties[5]);

										//fprintf(LOGFILE,"\t\t4th Object to activate raw :%d\t",objList[objIndex].shockProperties[6]);		
										//fprintf(LOGFILE,"4th Object Delay:%d\n",objList[objIndex].shockProperties[7]);	
										//DebugPrintTriggerVals(sub_ark, add_ptr, 28);
										/*			fprintf(LOGFILE,"\t\tOther values 1:%d\n",getValAtAddress(sub_ark,add_ptr+12,16));
			fprintf(LOGFILE,"\t\tOther values 2:%d\n",getValAtAddress(sub_ark,add_ptr+14,16));
			fprintf(LOGFILE,"\t\tOther values 3:%d\n",getValAtAddress(sub_ark,add_ptr+16,16));
			fprintf(LOGFILE,"\t\tOther values 4:%d\n",getValAtAddress(sub_ark,add_ptr+18,16));
			fprintf(LOGFILE,"\t\tOther values 5:%d\n",getValAtAddress(sub_ark,add_ptr+20,16));
			fprintf(LOGFILE,"\t\tOther values 6:%d\n",getValAtAddress(sub_ark,add_ptr+22,16));		
			fprintf(LOGFILE,"\t\tOther values 7:%d\n",getValAtAddress(sub_ark,add_ptr+24,16));		
			fprintf(LOGFILE,"\t\tOther values 8:%d\n",getValAtAddress(sub_ark,add_ptr+26,16));	*/						
								//}

								break;
						}
				case ObjectInteraction.ACTION_LIGHTING:
						{//Controls lighting between the specified control points. The control points are usually null triggers but are sometimes regular objects as well.
								//000C	int16	Control point 1
								//000E	int16	Control point 2
								//	...	?

								objList[objIndex].shockProperties[TRIG_PROPERTY_CONTROL_1] 	= (int)DataLoader.getValAtAddress(sub_ark.data,add_ptr+12,16);
								objList[objIndex].shockProperties[TRIG_PROPERTY_CONTROL_2] 	=(int)DataLoader.getValAtAddress(sub_ark.data,add_ptr+14,16);
								objList[objIndex].shockProperties[TRIG_PROPERTY_LIGHT_OP] = (int)DataLoader.getValAtAddress(sub_ark.data, add_ptr + 16, 16);
								objList[objIndex].shockProperties[TRIG_PROPERTY_UPPERSHADE_1] = (int)DataLoader.getValAtAddress(sub_ark.data, add_ptr + 22, 8);//22,24,23,25
								objList[objIndex].shockProperties[TRIG_PROPERTY_LOWERSHADE_1] = (int)DataLoader.getValAtAddress(sub_ark.data, add_ptr + 23, 8);
								objList[objIndex].shockProperties[TRIG_PROPERTY_UPPERSHADE_2] = (int)DataLoader.getValAtAddress(sub_ark.data, add_ptr + 24, 8);
								objList[objIndex].shockProperties[TRIG_PROPERTY_LOWERSHADE_2] = (int)DataLoader.getValAtAddress(sub_ark.data, add_ptr + 25, 8);
								/*if (PrintDebug==1)
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
								}	*/		
								break;
						}
				case ObjectInteraction.ACTION_EFFECT:
						{//Preforms a special effect. One example is the power breaker sparking on research level.
								/*if (PrintDebug==1)
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
								}		*/
								break;
						}
				case ObjectInteraction.ACTION_MOVING_PLATFORM:
						{//Usually a lift or a blast door type setup. Both the floor and ceiling have parameters in this.

								setElevatorProperties(LevelInfo, sub_ark,add_ptr,objList, objIndex);
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
				case ObjectInteraction.ACTION_TIMER:
						{//Delays the trigger getting fired off. A good example is the aftermath of destroying the CPUs on hospital level.
								//000C	int16	1st object to activate.?
								//000E	int16	Delay before activating object 1.?

								objList[objIndex].shockProperties[0] = (int)DataLoader.getValAtAddress(sub_ark.data, add_ptr + 0xC, 16);
								objList[objIndex].shockProperties[1] = (int)DataLoader.getValAtAddress(sub_ark.data, add_ptr + 0xe, 16);
								objList[objIndex].shockProperties[2] = (int)DataLoader.getValAtAddress(sub_ark.data, add_ptr + 0x10, 16);
								objList[objIndex].shockProperties[3] = (int)DataLoader.getValAtAddress(sub_ark.data, add_ptr + 0x12, 16);
								objList[objIndex].shockProperties[4] = (int)DataLoader.getValAtAddress(sub_ark.data, add_ptr + 0x14, 16);
								objList[objIndex].shockProperties[5] = (int)DataLoader.getValAtAddress(sub_ark.data, add_ptr + 0x16, 16);
								objList[objIndex].shockProperties[6] = (int)DataLoader.getValAtAddress(sub_ark.data, add_ptr + 0x18, 16);
								objList[objIndex].shockProperties[7] = (int)DataLoader.getValAtAddress(sub_ark.data, add_ptr + 0x1A, 16);
								/*if (PrintDebug == 1)
								{
										fprintf(LOGFILE,"\tACTION_TIMER (i think) for %s\n", UniqueObjectName(objList[objIndex]));

										fprintf(LOGFILE,"\t\t1st Object to activate raw :%d\t", objList[objIndex].shockProperties[0]);
										fprintf(LOGFILE,"1st Object Delay:%d\n", objList[objIndex].shockProperties[1]);

										DebugPrintTriggerVals(sub_ark, add_ptr, 28);
								}*/
								break;
						}
				case ObjectInteraction.ACTION_CHOICE:
						{//A toggle?
								//000C	int16	Trigger 1
								//0010	int16	Trigger 2

								objList[objIndex].shockProperties[TRIG_PROPERTY_TRIG_1] = (int)DataLoader.getValAtAddress(sub_ark.data,add_ptr+0x0C,16);	
								objList[objIndex].shockProperties[TRIG_PROPERTY_TRIG_2] = (int)DataLoader.getValAtAddress(sub_ark.data,add_ptr+0x10,16);	
								/*if (PrintDebug==1)
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
								}*/
								break;
						}
				case ObjectInteraction.ACTION_EMAIL:
						{//Sends the player an email. (Differs from a message in that a message just plays once and does not hit the data reader)
								/*if (PrintDebug==1)
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
								//}			
						objList[objIndex].shockProperties[TRIG_PROPERTY_EMAIL] =(int)DataLoader.getValAtAddress(sub_ark.data,add_ptr+0x0C,16)+2441;

								break;

						}
				case ObjectInteraction.ACTION_RADAWAY:
						{//Radiation healing on the reactor?
								/*if (PrintDebug==1)
								{
										//fprintf(LOGFILE,"\tACTION_RADAWAY for %s\n",UniqueObjectName(objList[objIndex]));
										//DebugPrintTriggerVals(sub_ark, add_ptr, 28);
										/*				fprintf(LOGFILE,"\t\tOther values 1:%d\n",getValAtAddress(sub_ark,add_ptr+12,16));
				fprintf(LOGFILE,"\t\tOther values 2:%d\n",getValAtAddress(sub_ark,add_ptr+14,16));
				fprintf(LOGFILE,"\t\tOther values 3:%d\n",getValAtAddress(sub_ark,add_ptr+16,16));
				fprintf(LOGFILE,"\t\tOther values 4:%d\n",getValAtAddress(sub_ark,add_ptr+18,16));
				fprintf(LOGFILE,"\t\tOther values 5:%d\n",getValAtAddress(sub_ark,add_ptr+20,16));
				fprintf(LOGFILE,"\t\tOther values 6:%d\n",getValAtAddress(sub_ark,add_ptr+22,16));		
				fprintf(LOGFILE,"\t\tOther values 7:%d\n",getValAtAddress(sub_ark,add_ptr+24,16));		
				fprintf(LOGFILE,"\t\tOther values 8:%d\n",getValAtAddress(sub_ark,add_ptr+26,16));*/	
								//}
								break;
						}
				case ObjectInteraction.ACTION_CHANGE_STATE:
						{//Used a lot in switches. Needs more research. (changes the image?)
								/*if (PrintDebug==1)
								{
										//fprintf(LOGFILE,"\tACTION_CHANGE_STATE for %s\n",UniqueObjectName(objList[objIndex]));
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
								}*/
								break;
						}
				case ObjectInteraction.ACTION_AWAKEN:
						{//Wakes up sleeping drones in between the two control points and sends them after you. (maybe)
								objList[objIndex].shockProperties[TRIG_PROPERTY_CONTROL_1] = (int)DataLoader.getValAtAddress(sub_ark.data, add_ptr + 0x10, 16);
								objList[objIndex].shockProperties[TRIG_PROPERTY_CONTROL_2] = (int)DataLoader.getValAtAddress(sub_ark.data, add_ptr + 0x12, 16);
								/*if (PrintDebug == 1)
								{
										fprintf(LOGFILE,"\tACTION_AWAKEN for %s\n", UniqueObjectName(objList[objIndex]));
										fprintf(LOGFILE,"\t\tControl point object1:%d\n", objList[objIndex].shockProperties[TRIG_PROPERTY_CONTROL_1]);
										fprintf(LOGFILE,"\t\tControl point object2:%d\n", objList[objIndex].shockProperties[TRIG_PROPERTY_CONTROL_2]);
										DebugPrintTriggerVals(sub_ark, add_ptr, 28);
								}*/
								break;
						}
				case ObjectInteraction.ACTION_MESSAGE:
						{//A once off message. For example the computer voice when the cyborg conversion is activated.
								//16 Trap message offset in Chunk 2151 
								//000C	int16	"Success" message
								//0010	int16	"Fail" message
								objList[objIndex].shockProperties[TRIG_PROPERTY_MESSAGE1]=(int)DataLoader.getValAtAddress(sub_ark.data,add_ptr+0x0C,16);
								objList[objIndex].shockProperties[TRIG_PROPERTY_MESSAGE2]=(int)DataLoader.getValAtAddress(sub_ark.data,add_ptr+0x10,16);
								/*if (PrintDebug==1)
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
								//}			
								break;
						}
				case ObjectInteraction.ACTION_SPAWN:	
						{
								//000C	int32	Class/subclass/type of object to spawn
								//0010	int16	Control point 1 (object)
								//0012	int16	Control point 2 (object)
								//0014		??
								//0018		??	

								objList[objIndex].shockProperties[TRIG_PROPERTY_TYPE]=(int)DataLoader.getValAtAddress(sub_ark.data,add_ptr+0x0C,32);
								objList[objIndex].shockProperties[TRIG_PROPERTY_CONTROL_1]=(int)DataLoader.getValAtAddress(sub_ark.data,add_ptr+0x10,16);
								objList[objIndex].shockProperties[TRIG_PROPERTY_CONTROL_2]=(int)DataLoader.getValAtAddress(sub_ark.data,add_ptr+0x12,16);
							/*	if (PrintDebug==1)
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
							//	}
								break;
						}	
				case ObjectInteraction.ACTION_CHANGE_TYPE:
						{
								//000C	int16	Object ID to change.
								//0010	int8	New type.
								//0012		??

								objList[objIndex].shockProperties[TRIG_PROPERTY_OBJECT] =(int)DataLoader.getValAtAddress(sub_ark.data,add_ptr+0x0C,16);
								objList[objIndex].shockProperties[TRIG_PROPERTY_TYPE] =(int)DataLoader.getValAtAddress(sub_ark.data,add_ptr+0x10,8);
								/*if (PrintDebug==1)
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
								//}			
								break;
						}
				default:
						{
								/*if (PrintDebug==1)
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
								//}
								break;
						}	

				}

		}





		/******/




		void getShockButtons(TileInfo[,] LevelInfo,DataLoader.Chunk sub_ark,int add_ptr, ObjectLoaderInfo[] objList, int objIndex)
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
				//fprintf(LOGFILE,"\tSwitch Properties\n");
				if (objList[objIndex].ObjectSubClass ==0)
				{//regular buttons and switches
						switch (objList[objIndex].TriggerAction)	//Switches have action types as well.
						{	
						case ObjectInteraction.ACTION_SET_VARIABLE:
								{//Sets a game variable. I don't yet know what the various variables are. I suspect they may be in the exe so I'll have to just observe them in the wild?
										//000C	int16	variable to set
										//0010	int16	value
										//0012	int16	?? action 00 set 01 add
										//0014	int16	Optional message to receive
										//fprintf(LOGFILE,"\tACTION_SET_VARIABLE for %s\n", UniqueObjectName(objList[objIndex]));
										//fprintf(LOGFILE,"\t\tVariable to Set:%d\n", getValAtAddress(sub_ark, add_ptr + 0xC, 16));
										//fprintf(LOGFILE,"\t\tValue:%d", getValAtAddress(sub_ark, add_ptr + 0x10, 16));
										//fprintf(LOGFILE,"\t\taction?:%d (00 set 01 add)\n", getValAtAddress(sub_ark, add_ptr + 0x12, 16));
										//fprintf(LOGFILE,"\t\tOptional Message:%d\n", getValAtAddress(sub_ark, add_ptr + 0x14, 16));
										//DebugPrintTriggerVals(sub_ark, add_ptr, 28);
										objList[objIndex].shockProperties[TRIG_PROPERTY_VARIABLE] = (int)DataLoader.getValAtAddress(sub_ark.data, add_ptr + 0xC, 16);
										objList[objIndex].shockProperties[TRIG_PROPERTY_VALUE] = (int)DataLoader.getValAtAddress(sub_ark.data, add_ptr + 0x10, 16);
										objList[objIndex].shockProperties[TRIG_PROPERTY_OPERATION] = (int)DataLoader.getValAtAddress(sub_ark.data, add_ptr + 0x12, 16);
										objList[objIndex].shockProperties[TRIG_PROPERTY_MESSAGE1] = (int)DataLoader.getValAtAddress(sub_ark.data, add_ptr + 0x14, 16);
										break;
								}
						case ObjectInteraction.ACTION_ACTIVATE:
								{	//Assume same behaviour as a trigger?
										//fprintf(LOGFILE,"Switch:Action_Activate\n");
										objList[objIndex].shockProperties[0] = (int)DataLoader.getValAtAddress(sub_ark.data,add_ptr+0xC,16)		;					
										objList[objIndex].shockProperties[1] = (int)DataLoader.getValAtAddress(sub_ark.data,add_ptr+0xe,16)		;
										objList[objIndex].shockProperties[2] = (int)DataLoader.getValAtAddress(sub_ark.data,add_ptr+0x10,16)		;
										objList[objIndex].shockProperties[3] = (int)DataLoader.getValAtAddress(sub_ark.data,add_ptr+0x12,16)		;
										objList[objIndex].shockProperties[4] = (int)DataLoader.getValAtAddress(sub_ark.data,add_ptr+0x14,16)		;
										objList[objIndex].shockProperties[5] = (int)DataLoader.getValAtAddress(sub_ark.data,add_ptr+0x16,16)		;
										objList[objIndex].shockProperties[6] = (int)DataLoader.getValAtAddress(sub_ark.data,add_ptr+0x18,16)		;
										objList[objIndex].shockProperties[7] = (int)DataLoader.getValAtAddress(sub_ark.data,add_ptr+0x1A,16)		;				
										break;
								}
						case ObjectInteraction.ACTION_MOVING_PLATFORM:
								{
										//fprintf(LOGFILE,"Switch:Action_Moving_Platform\n");
										setElevatorProperties(LevelInfo,sub_ark,add_ptr,objList,objIndex);
										break;
								}
						case ObjectInteraction.ACTION_CHOICE:
								{
										//fprintf(LOGFILE,"Switch:Action_Choice\n");
										objList[objIndex].shockProperties[TRIG_PROPERTY_TRIG_1] = (int)DataLoader.getValAtAddress(sub_ark.data, add_ptr + 0x0C, 16);
										objList[objIndex].shockProperties[TRIG_PROPERTY_TRIG_2] = (int)DataLoader.getValAtAddress(sub_ark.data, add_ptr + 0x10, 16);
										break;
								}
						case ObjectInteraction.ACTION_LIGHTING:
								{	
										//fprintf(LOGFILE,"Switch:Action_Lighting\n");
										objList[objIndex].shockProperties[TRIG_PROPERTY_CONTROL_1] = (int)DataLoader.getValAtAddress(sub_ark.data, add_ptr + 12, 16);
										if (objList[objIndex].shockProperties[TRIG_PROPERTY_CONTROL_1] <= 3)
										{	//seems to be a special case?
												objList[objIndex].shockProperties[TRIG_PROPERTY_CONTROL_1] = objIndex;
										}
										objList[objIndex].shockProperties[TRIG_PROPERTY_CONTROL_2] = (int)DataLoader.getValAtAddress(sub_ark.data, add_ptr + 14, 16);
										objList[objIndex].shockProperties[TRIG_PROPERTY_UPPERSHADE_1] = (int)DataLoader.getValAtAddress(sub_ark.data, add_ptr + 22, 8);
										objList[objIndex].shockProperties[TRIG_PROPERTY_LOWERSHADE_1] = (int)DataLoader.getValAtAddress(sub_ark.data, add_ptr + 24, 8);
										objList[objIndex].shockProperties[TRIG_PROPERTY_UPPERSHADE_2] = (int)DataLoader.getValAtAddress(sub_ark.data, add_ptr + 23, 8);
										objList[objIndex].shockProperties[TRIG_PROPERTY_LOWERSHADE_2] = (int)DataLoader.getValAtAddress(sub_ark.data, add_ptr + 25, 8);
										//fprintf(LOGFILE,"\t\tControl point 1:%d\n", objList[objIndex].shockProperties[TRIG_PROPERTY_CONTROL_1]);
										//fprintf(LOGFILE,"\t\tControl point 2:%d\n", objList[objIndex].shockProperties[TRIG_PROPERTY_CONTROL_2]);
										//fprintf(LOGFILE,"\t\t1st Time Upper Shade adjustment = %d\n", objList[objIndex].shockProperties[TRIG_PROPERTY_UPPERSHADE_1]);
										//fprintf(LOGFILE,"\t\t1st Time Lower Shade adjustment = %d\n", objList[objIndex].shockProperties[TRIG_PROPERTY_LOWERSHADE_1]);
										//fprintf(LOGFILE,"\t\t2nd Time Upper Shade adjustment = %d\n", objList[objIndex].shockProperties[TRIG_PROPERTY_UPPERSHADE_2]);
										//fprintf(LOGFILE,"\t\t2nd Time Lower Shade adjustment = %d\n", objList[objIndex].shockProperties[TRIG_PROPERTY_LOWERSHADE_2]);
										break;
								}
						case ObjectInteraction.ACTION_CHANGE_TYPE:
								{
										//fprintf(LOGFILE,"Switch:Action_Change_Type\n");
										objList[objIndex].shockProperties[TRIG_PROPERTY_OBJECT] = (int)DataLoader.getValAtAddress(sub_ark.data, add_ptr + 0x0C, 16);
										objList[objIndex].shockProperties[TRIG_PROPERTY_TYPE] = (int)DataLoader.getValAtAddress(sub_ark.data, add_ptr + 0x10, 8);
										//fprintf(LOGFILE, "\t\tObject to change:%d\n", objList[objIndex].shockProperties[TRIG_PROPERTY_OBJECT]);
										//fprintf(LOGFILE, "\t\tNew type:%d\n", objList[objIndex].shockProperties[TRIG_PROPERTY_TYPE]);
										break;
								}
						case ObjectInteraction.ACTION_CHANGE_STATE:
								{
										//fprintf(LOGFILE, "Switch:Action_Change_State\n");
										objList[objIndex].shockProperties[TRIG_PROPERTY_TYPE] = (int)DataLoader.getValAtAddress(sub_ark.data, add_ptr + 12, 16);
										objList[objIndex].shockProperties[TRIG_PROPERTY_OBJECT] = (int)DataLoader.getValAtAddress(sub_ark.data, add_ptr + 16, 16);
										//fprintf(LOGFILE, "\t\tObject to activate:%d\n", objList[objIndex].shockProperties[TRIG_PROPERTY_OBJECT]);
										//fprintf(LOGFILE, "\t\tNew type:%d\n", objList[objIndex].shockProperties[TRIG_PROPERTY_TYPE]);
										//DebugPrintTriggerVals(sub_ark, add_ptr, 30);
										break;
								}
						default:	
								{
										//fprintf(LOGFILE,"Switch:Default\n");
										objList[objIndex].shockProperties[BUTTON_PROPERTY_TRIGGER] = (int)DataLoader.getValAtAddress(sub_ark.data,add_ptr+12,16);
										objList[objIndex].shockProperties[BUTTON_PROPERTY_TRIGGER_2] = (int)DataLoader.getValAtAddress(sub_ark.data,add_ptr+16,16);
										break;
								}
						}

						//fprintf(LOGFILE,"\tDefault trigger target %d",objList[objIndex].shockProperties[BUTTON_PROPERTY_TRIGGER]);
						//fprintf(LOGFILE,"\n\tVal_oc: %d\n" ,getValAtAddress(sub_ark,add_ptr+0x0c,16));
						//fprintf(LOGFILE,"\tVal_oe: %d\n" ,getValAtAddress(sub_ark,add_ptr+0x0E,16));
						//fprintf(LOGFILE,"\tVal_10: %d\n" ,getValAtAddress(sub_ark,add_ptr+0x10,16));
						//fprintf(LOGFILE,"\tVal_12: %d\n" ,getValAtAddress(sub_ark,add_ptr+0x12,16));
						//fprintf(LOGFILE,"\tVal_14: %d\n" ,getValAtAddress(sub_ark,add_ptr+0x14,16));
						//fprintf(LOGFILE,"\tVal_16: %d\n" ,getValAtAddress(sub_ark,add_ptr+0x16,16));
						//fprintf(LOGFILE,"\tVal_18: %d\n" ,getValAtAddress(sub_ark,add_ptr+0x18,16));
						//fprintf(LOGFILE,"\tVal_1a: %d\n" ,getValAtAddress(sub_ark,add_ptr+0x1A,16));	
						//DebugPrintTriggerVals(sub_ark, add_ptr, 30);

						return;
				}
				if((objList[objIndex].ObjectSubClass==2) && (objList[objIndex].ObjectSubClassIndex==0))
				{//cyberspace terminal
						//000C  int16 X of target Cyberspace
						//0010  int16 Y of target Cyberspace
						//0014  int16 Z of target Cyberspace
						//0018  int16 Level (Cyberspace)
						objList[objIndex].shockProperties[0] = (int)DataLoader.getValAtAddress(sub_ark.data,add_ptr+0x0c,16); 
						objList[objIndex].shockProperties[1] = (int)DataLoader.getValAtAddress(sub_ark.data,add_ptr+0x10,16); 
						objList[objIndex].shockProperties[2] = (int)DataLoader.getValAtAddress(sub_ark.data,add_ptr+0x14,16); 
						objList[objIndex].shockProperties[3] = (int)DataLoader.getValAtAddress(sub_ark.data,add_ptr+0x18,16); 
						//fprintf(LOGFILE,"\tCyberspace (%d,%d,%d @ %d)\n",objList[objIndex].shockProperties[0],objList[objIndex].shockProperties[1],objList[objIndex].shockProperties[2],objList[objIndex].shockProperties[3]);
						return;
				}

				if((objList[objIndex].ObjectSubClass==2) && (objList[objIndex].ObjectSubClassIndex>=1))
				{//Fixup station/energy station
						objList[objIndex].shockProperties[0]  = (int)DataLoader.getValAtAddress(sub_ark.data,add_ptr+0x0c,16);   //Amount of charge?/? always 255
						objList[objIndex].shockProperties[1]  = (int)DataLoader.getValAtAddress(sub_ark.data,add_ptr+0x10,16);	//Security level?? //reuse timer??
						//fprintf(LOGFILE,"\tEnergy Charge: %d %d\n",objList[objIndex].shockProperties[0] ,objList[objIndex].shockProperties[1] );
						return;
				}
				if((objList[objIndex].ObjectSubClass==3) && (objList[objIndex].ObjectSubClassIndex<=3))
				{	
						//puzzle panels. need to see them in the wild before I know what other stuff does
						objList[objIndex].shockProperties[BUTTON_PROPERTY_TRIGGER]=(int)DataLoader.getValAtAddress(sub_ark.data,add_ptr+0x0c,16);

						//if bit 28 is set (0x10000000) it is a block puzzle, else it is a wire puzzle.
						objList[objIndex].shockProperties[BUTTON_PROPERTY_PUZZLE]= ((int)DataLoader.getValAtAddress(sub_ark.data,add_ptr+0x10,8)>>28) & 0x01;
						if (objList[objIndex].shockProperties[BUTTON_PROPERTY_PUZZLE] == 1)
						{
							//	fprintf(LOGFILE,"\tPuzzle panel: Type is block\n");
						}
						else
						{
								//fprintf(LOGFILE,"\tPuzzle panel: Type is wire\n");
						}
						//fprintf(LOGFILE,"\tTrigger is %d",objList[objIndex].shockProperties[BUTTON_PROPERTY_TRIGGER]);
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

						objList[objIndex].shockProperties[0]  = (int)DataLoader.getValAtAddress(sub_ark.data,add_ptr+0x0c,16);//elevator panel ids
						objList[objIndex].shockProperties[1]  = (int)DataLoader.getValAtAddress(sub_ark.data,add_ptr+0x0E,16);
						objList[objIndex].shockProperties[2]  = (int)DataLoader.getValAtAddress(sub_ark.data,add_ptr+0x12,16);
						objList[objIndex].shockProperties[3]  = (int)DataLoader.getValAtAddress(sub_ark.data,add_ptr+0x18,16);//bitfields for access
						objList[objIndex].shockProperties[4]  = (int)DataLoader.getValAtAddress(sub_ark.data,add_ptr+0x1A,16);
						//fprintf(LOGFILE,"\tElevator to one of %d, %d or %d panels on other levels\n",objList[objIndex].shockProperties[0],objList[objIndex].shockProperties[2],objList[objIndex].shockProperties[2]);
						//fprintf(LOGFILE,"\tAccesable levels actual:%d shaft:%d\n",objList[objIndex].shockProperties[3],objList[objIndex].shockProperties[4]);

						return;
				}

				if((objList[objIndex].ObjectSubClass==3) && ((objList[objIndex].ObjectSubClassIndex==7) || (objList[objIndex].ObjectSubClassIndex==8) ))
				{
						//Number Pads
						//000C	int16	Combination in BCD
						//000E  int16 Map Object to trigger
						//0018  int16 Map Object to Extra Trigger (?)
						int combo =(int)DataLoader.getValAtAddress(sub_ark.data,add_ptr+0x0c,16);
						int value = 
								(combo & 0x0F) * 1
								+(combo>>4 & 0x0F) * 10
								+(combo>>8 & 0x0F) * 100;
						objList[objIndex].shockProperties[BUTTON_PROPERTY_COMBO]  =value;	// getValAtAddress(sub_ark,add_ptr+0x0c,16);

						objList[objIndex].shockProperties[BUTTON_PROPERTY_TRIGGER]  = (int)DataLoader.getValAtAddress(sub_ark.data,add_ptr+0x0E,16);
						objList[objIndex].shockProperties[3]  = (int)DataLoader.getValAtAddress(sub_ark.data,add_ptr+0x18,16);	//extra trigger?
						//fprintf(LOGFILE,"\tNumber pad. Combo is %d, Triggers %d",objList[objIndex].shockProperties[BUTTON_PROPERTY_COMBO],objList[objIndex].shockProperties[BUTTON_PROPERTY_TRIGGER] );
						return;
				}

				//unknown object if all other tests fail. set the usual trigger value and keep an eye on this statement in debugging.
				objList[objIndex].shockProperties[BUTTON_PROPERTY_TRIGGER]=(int)DataLoader.getValAtAddress(sub_ark.data,add_ptr+0x0c,16);
				/*	shockProperties[0]  = getValAtAddress(sub_ark,add_ptr+0x0c,16);   
	shockProperties[1]  = getValAtAddress(sub_ark,add_ptr+0x10,16);	
	shockProperties[2]  = getValAtAddress(sub_ark,add_ptr+0x12,16);
	shockProperties[3]  = getValAtAddress(sub_ark,add_ptr+0x14,16);
	shockProperties[4]  = getValAtAddress(sub_ark,add_ptr+0x16,16);
	shockProperties[5]  = getValAtAddress(sub_ark,add_ptr+0x18,16);
	shockProperties[6]  = getValAtAddress(sub_ark,add_ptr+0x1A,16);
	shockProperties[7]  = getValAtAddress(sub_ark,add_ptr+0x1B,16);
	shockProperties[8]  = getValAtAddress(sub_ark,add_ptr+0x1C,16);	*/	
				//fprintf(LOGFILE,"\tOther button type!");
				//DebugPrintTriggerVals(sub_ark, add_ptr, 30);

		}







		void setElevatorProperties(TileInfo[,]LevelInfo,DataLoader.Chunk sub_ark,int add_ptr, ObjectLoaderInfo[] objList, int objIndex)
		{

				//000C	int16	Tile x coord of platform
				//0010	int16	Tile y coord of platform
				//0014	int16	Target floor height
				//0016	int16	Target ceiling height
				//0018	int16	Speed

				objList[objIndex].shockProperties[TRIG_PROPERTY_TARGET_X] = (int)DataLoader.getValAtAddress(sub_ark.data,add_ptr+0x0C,16);
				objList[objIndex].shockProperties[TRIG_PROPERTY_TARGET_Y] = (int)DataLoader.getValAtAddress(sub_ark.data,add_ptr+0x10,16);
				objList[objIndex].shockProperties[TRIG_PROPERTY_FLOOR] = (int)DataLoader.getValAtAddress(sub_ark.data,add_ptr+0x14,16);	//5
				objList[objIndex].shockProperties[TRIG_PROPERTY_CEILING] = (int)DataLoader.getValAtAddress(sub_ark.data,add_ptr+0x16,16);	//6
				objList[objIndex].shockProperties[TRIG_PROPERTY_SPEED] = (int)DataLoader.getValAtAddress(sub_ark.data,add_ptr+0x18,16);
				//LevelInfo[objList[objIndex].shockProperties[TRIG_PROPERTY_TARGET_X]][objList[objIndex].shockProperties[TRIG_PROPERTY_TARGET_Y]].hasElevator =1;

				//short ceilingFlag = (objList[objIndex].shockProperties[TRIG_PROPERTY_CEILING]<=SHOCK_CEILING_HEIGHT);
				//short floorFlag = (objList[objIndex].shockProperties[TRIG_PROPERTY_FLOOR] <= SHOCK_CEILING_HEIGHT);
				//short elevatorFlag = (ceilingFlag << 1) | (floorFlag);

				//LevelInfo[objList[objIndex].shockProperties[TRIG_PROPERTY_TARGET_X]][objList[objIndex].shockProperties[TRIG_PROPERTY_TARGET_Y]].hasElevator = elevatorFlag;
				//LevelInfo[objList[objIndex].shockProperties[TRIG_PROPERTY_TARGET_X],objList[objIndex].shockProperties[TRIG_PROPERTY_TARGET_Y]].hasElevator = elevatorFlag;

				/*if (PrintDebug==1)
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
			//	}	

		}








}

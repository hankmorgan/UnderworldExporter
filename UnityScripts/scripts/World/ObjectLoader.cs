using UnityEngine;
using System.Collections;

public class ObjectLoader  {
		const int UWDEMO =0;
		const int  UW1= 1;
		const int  UW2 =2;
		const int  SHOCK =3;

		/// <summary>
		/// The game objects currently in use.
		/// </summary>
		//public ObjectInteraction[] ObjectInteractions;
		public ObjectLoaderInfo[] objInfo;

		/// <summary>
		/// Readies the object list. Requires the tilemap to be read in first
		/// </summary>
		/// <param name="tileMap">Tile map.</param>
		/// <param name="lev_ark">Lev ark.</param>
		/// <param name="game">Game.</param>
		public void LoadObjectList(TileMap tileMap, char[] lev_ark, int game)
		{

			objInfo=new ObjectLoaderInfo[1024];
			BuildObjectListUW(tileMap.Tiles, objInfo, tileMap.texture_map, lev_ark, game, tileMap.thisLevelNo);

			setObjectTileXY(1,tileMap.Tiles,objInfo);

			setDoorBits(tileMap.Tiles,objInfo);
			setElevatorBits(tileMap.Tiles,objInfo);
			setTerrainChangeBits(tileMap.Tiles,objInfo);
			SetBullFrog(tileMap.Tiles,objInfo,tileMap.thisLevelNo);

		}


		void BuildObjectListUW(TileInfo[,] LevelInfo, ObjectLoaderInfo[] objList,int[] texture_map, char[] lev_ark, int game, int LevelNo)
		{
				

				//unsigned char *lev_ark; 
				//unsigned char *tmp_ark;		//for uw2 decompression
				long fileSize;
				int NoOfBlocks;
				long AddressOfBlockStart;
				long objectsAddress;
				long address_pointer;
				char[] graves;

				//Load in the grave information
				DataLoader.ReadStreamFile(GameWorldController.instance.Graves_File, out graves);
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
				for (int x=0; x<1024;x++)
				{	//read in master object list
						objList[x]=new ObjectLoaderInfo();
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

						if (GameWorldController.instance.objectMaster.type[objList[x].item_id] == ObjectInteraction.BRIDGE)
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

						if (GameWorldController.instance.objectMaster.type[objList[x].item_id] == ObjectInteraction.BUTTON)
						{
								objList[x].texture = objList[x].flags;
						}

						if (GameWorldController.instance.objectMaster.type[objList[x].item_id] == ObjectInteraction.GRAVE)
						{
								objList[x].texture = objList[x].flags+28;
								if (objList[x].link >= 512)
								{
										objList[x].DeathWatched = (short)DataLoader.getValAtAddress(graves, objList[x].link - 512, 8);
								}
						}
						if (GameWorldController.instance.objectMaster.type[objList[x].item_id] == ObjectInteraction.A_CREATE_OBJECT_TRAP)//Position the trap in the centre of the tile
						{
								objList[x].x = 4;
								objList[x].y = 4;
						}
						if (GameWorldController.instance.objectMaster.type[objList[x].item_id] == ObjectInteraction.A_CHANGE_TERRAIN_TRAP)
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









		///*********


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


		bool isContainer(ObjectLoaderInfo currobj)
		{
				return  ((GameWorldController.instance.objectMaster.type[currobj.item_id] == ObjectInteraction.CONTAINER) || (GameWorldController.instance.objectMaster.type[currobj.item_id] == ObjectInteraction.CORPSE));
		}


		bool isAlwaysInUse(ObjectLoaderInfo currobj)
		{//Objects that will always be generated.
			switch(GameWorldController.instance.objectMaster.type[currobj.item_id] )
			{	
			case ObjectInteraction.SPELL:
					return true;
			default:
					return false;							
			}
		}

		bool isTrigger(ObjectLoaderInfo currobj)
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
						{
								return true;
						}	
				default:
						{
								return false;
						}
				}
		}


		bool isTrap(ObjectLoaderInfo currobj)
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
												if ((GameWorldController.instance.objectMaster.type[objList[currObj.index].item_id] == ObjectInteraction.A_DO_TRAP ) && (currObj.quality==3))
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
		public Vector3 CalcObjectXYZ(int game, TileMap tileMap, TileInfo[,] LevelInfo, ObjectLoaderInfo[] objList, long index, int x, int y, short WallAdjust)
		{
				float offX= 0f; float offY= 0f; float offZ= 0f;
				float ResolutionXY = 7.0f;	// A tile has a 7x7 grid for object positioning.
				float ResolutionZ = 128.0f;	//UW has 127 posible z positions for an object in tile.
				if (game == SHOCK){ ResolutionXY = 256.0f; ResolutionZ = 256.0f; }	//Shock has more "z" in it.

				float BrushX = 120f;
				float BrushY = 120f;
				float BrushZ = 15f;
				float objX = (float)objList[index].x;
				float objY = (float)objList[index].y;
				offX = (x*BrushX) + ((objList[index].x) * (BrushX / ResolutionXY));
				offY = (y*BrushY) + ((objList[index].y) * (BrushY / ResolutionXY));

				float zpos = objList[index].zpos;
				float ceil = tileMap.CEILING_HEIGHT;
				offZ = ((zpos / ResolutionZ) * (ceil)) * BrushZ;
				if ((game !=SHOCK) && (x<64) && (y<64))
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
							break;
						}
				default:
						{
								if (WallAdjust == 1)
								{//Adjust the object x,y to avoid clipping into walls.
										switch (game)
										{
										case SHOCK:
												if (objList[index].x == 0){	offX = offX + 2.0f;	}
												if (objList[index].x == 128){offX = offX - 2.0f;}
												if (objList[index].y == 0){offY = offY + 2.0f;}
												if (objList[index].y == 128){offY = offY - 2.0f;}
												break;
										default:
												if (objList[index].x == 0){offX = offX + 2.0f;}
												if (objList[index].x == 7){offX = offX - 2.0f;}
												if (objList[index].y == 0){offY = offY + 2.0f;}
												if (objList[index].y == 7){offY = offY - 2.0f;}
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

			for (int i=0;i<instance.objInfo.GetUpperBound(0);i++)
			{
			if (instance.objInfo[i]!=null)
				{
				if (instance.objInfo[i].InUseFlag==1)
					{
					Vector3 position = instance.CalcObjectXYZ(1,tilemap,tilemap.Tiles,instance.objInfo,i,instance.objInfo[i].tileX,instance.objInfo[i].tileY,1);
					instance.objInfo[i].instance = ObjectInteraction.CreateNewObject(tilemap, instance.objInfo[i],parent,position);
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

}

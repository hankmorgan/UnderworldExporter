using UnityEngine;
using System.Collections;
using System.IO;

public class SaveGame : Loader {
		private const int NoOfEncryptedBytes=0xD2;//218;		//219
		/// <summary>
		/// Loads the player dat file into the current character
		/// </summary>
		/// <param name="slotNo">Slot no.</param>
		public static void LoadPlayerDat(int slotNo)
		{
				GameWorldController.instance.playerUW.CharName="";
				char[] buffer;
				int x_position=0;
				int y_position=0;
				int z_position=0;

				int[] gametimevals=new int[3];
				int[] ActiveEffectIds=new int[3];
				int[] ActiveEffectStability=new int[3];
				int effectCounter=0;
				GameWorldController.instance.playerUW.playerInventory.currentContainer="_Gronk";
				if (DataLoader.ReadStreamFile(Loader.BasePath + "save" + slotNo + "\\player.dat", out buffer))
				{

						TileMap.OnWater=false;
						int xOrValue= (int)buffer[0];
						GameWorldController.instance.playerUW.XorKey=xOrValue;
						int incrnum = 3;

						//Write out the XOR values used in this file.
						FileStream file = File.Open(Loader.BasePath + "save" + slotNo + "\\xor.dat",FileMode.Create);
						BinaryWriter writer= new BinaryWriter(file);

						for(int i=1; i<=NoOfEncryptedBytes; i++)
						{
								if ((i==81) | (i==161))
								{
									incrnum = 3;
								}
								buffer[i] ^= (char)((xOrValue+incrnum) & 0xFF);

								DataLoader.WriteInt8(writer,((xOrValue+incrnum) & 0xFF));

								incrnum += 3;
						}
						file.Close();
						//string Result="";
						int runeOffset=0;
						for (int i=1; i<=221;i++)
						{
								if (i<14)
								{
										if (buffer[i].ToString() != "\0")
										{
										GameWorldController.instance.playerUW.CharName +=buffer[i];
										}
								}
								else
								{
										switch(i)//UWformats doesn't take the first byte into account when describing offsets! I have incremented plus one
										{
										case 0x1F ://Strength
												GameWorldController.instance.playerUW.PlayerSkills.STR=(int)buffer[i];break;
										case 0x20 ://Dex
												GameWorldController.instance.playerUW.PlayerSkills.DEX=(int)buffer[i];break;
										case 0x21 : ///    Intelligence
												GameWorldController.instance.playerUW.PlayerSkills.INT=(int)buffer[i];break;
										case 0x22 : ///    Attack
												GameWorldController.instance.playerUW.PlayerSkills.Attack=(int)buffer[i];break;
										case 0x23 : ///    Defense
												GameWorldController.instance.playerUW.PlayerSkills.Defense=(int)buffer[i];break;
										case 0x24 : ///    Unarmed
												GameWorldController.instance.playerUW.PlayerSkills.Unarmed=(int)buffer[i];break;
										case 0x25  : ///    Sword
												GameWorldController.instance.playerUW.PlayerSkills.Sword=(int)buffer[i];break;
										case 0x26  : ///    Axe
												GameWorldController.instance.playerUW.PlayerSkills.Axe=(int)buffer[i];break;
										case 0x27 : ///    Mace
												GameWorldController.instance.playerUW.PlayerSkills.Mace=(int)buffer[i];break;
										case 0x28   : ///    Missile
												GameWorldController.instance.playerUW.PlayerSkills.Missile=(int)buffer[i];break;
										case 0x29  : ///    Mana
												GameWorldController.instance.playerUW.PlayerSkills.ManaSkill=(int)buffer[i];break;
										case 0x2A : ///    Lore
												GameWorldController.instance.playerUW.PlayerSkills.Lore=(int)buffer[i];break;
										case 0x2B  : ///    Casting
												GameWorldController.instance.playerUW.PlayerSkills.Casting=(int)buffer[i];break;
										case 0x2C  : ///    Traps
												GameWorldController.instance.playerUW.PlayerSkills.Traps=(int)buffer[i];break;
										case 0x2D  : ///    Search
												GameWorldController.instance.playerUW.PlayerSkills.Search=(int)buffer[i];break;
										case 0x2E : ///    Track
												GameWorldController.instance.playerUW.PlayerSkills.Track=(int)buffer[i];break;
										case 0x2F  : ///    Sneak
												GameWorldController.instance.playerUW.PlayerSkills.Sneak=(int)buffer[i];break;
										case 0x30  : ///    Repair
												GameWorldController.instance.playerUW.PlayerSkills.Repair=(int)buffer[i];break;
										case 0x31 : ///    Charm
												GameWorldController.instance.playerUW.PlayerSkills.Charm=(int)buffer[i];break;
										case 0x32 : ///    Picklock
												GameWorldController.instance.playerUW.PlayerSkills.PickLock=(int)buffer[i];break;
										case 0x33  : ///    Acrobat
												GameWorldController.instance.playerUW.PlayerSkills.Acrobat=(int)buffer[i];break;
										case 0x34  : ///    Appraise
												GameWorldController.instance.playerUW.PlayerSkills.Appraise=(int)buffer[i];break;
										case 0x35  : ///    Swimming
												GameWorldController.instance.playerUW.PlayerSkills.Swimming=(int)buffer[i];break;
										case 0x36://Curvit
												GameWorldController.instance.playerUW.CurVIT=(int)buffer[i];break;
										case 0x37 : ///    max. vitality
												GameWorldController.instance.playerUW.MaxVIT=(int)buffer[i];break;
										case 0x38 : ///    current mana, (play_mana)
												GameWorldController.instance.playerUW.PlayerMagic.CurMana=(int)buffer[i];break;
										case 0x39  : ///    max. mana
												GameWorldController.instance.playerUW.PlayerMagic.MaxMana=(int)buffer[i];break;
										case 0x3A : ///    hunger, play_hunger
												GameWorldController.instance.playerUW.FoodLevel=(int)buffer[i];break;		
										case 0x3B:
												//Unknown. Observed values 0 and 64?//Fatigue???
												break;
												//case 0x3C:
												//		testvalue=(int)buffer[i];break;	

										case 0x3E : ///    character level (play_level)
												GameWorldController.instance.playerUW.CharLevel=(int)buffer[i];break;
										case 0x3F:
										case 0x41:
										case 0x43://Active spell effect
												{
													ActiveEffectIds[effectCounter]=SaveGame.GetActiveSpellID((int)buffer[i]);break;		
												}
										case 0x3F+1:
										case 0x41+1:
										case 0x43+1://Active spell effect stability
												{
													ActiveEffectStability[effectCounter++]=(int)buffer[i];break;		
												}
										case 0x45://Runebits
										case 0x46://Runebits
										case 0x47://Runebits
												for (int r =7; r>=0; r--)
												{
														if (((buffer[i]>>r) & 0x1 )== 1)
														{
																GameWorldController.instance.playerUW.PlayerMagic.PlayerRunes[7-r+runeOffset]=true;
														}
														else
														{
																GameWorldController.instance.playerUW.PlayerMagic.PlayerRunes[7-r+runeOffset]=false;
														}
												}
												runeOffset+=8;
												break;
										case 0x48:
												SetActiveRuneSlots(0, (int)buffer[i]);
												break;
										case 0x49:
												SetActiveRuneSlots(1, (int)buffer[i]);
												break;
										case 0x4A:
												SetActiveRuneSlots(2, (int)buffer[i]);
												break;

										case 0x4D : ///   weight in 0.1 stones
												//Or STR * 2; safe to ignore?
												//testvalue=(int)DataLoader.getValAtAddress(buffer,i,16);break;
												break;
										case 0x4F  : ///   experience in 0.1 points
												GameWorldController.instance.playerUW.EXP=(int)DataLoader.getValAtAddress(buffer,i,32);break;
										case 0x53: // skillpoints available to spend
												GameWorldController.instance.playerUW.TrainingPoints=(int)buffer[i];break;
										case 0x55 : ///   x-position in level
												x_position= (int)DataLoader.getValAtAddress(buffer,i,16);break;
										case 0x57  : ///   y-position
												y_position=(int)DataLoader.getValAtAddress(buffer,i,16);break;
										case 0x59 : ///   z-position
												z_position=(int)DataLoader.getValAtAddress(buffer,i,16);break;
										case 0x5C : ///   heading
												{
														float heading=(float)DataLoader.getValAtAddress(buffer,i,8);	

														//heading=255f-heading;//reversed
														//playerCam.transform.rotation=Vector3.zero;

														//this.transform.Rotate(0f,heading*(255f/360f),0f,Space.World);
														GameWorldController.instance.playerUW.transform.eulerAngles=new Vector3(0f,heading*(360f/255f),0f);
														//playerCam.transform.localRotation.eulerAngles=Vector3.zero;
														GameWorldController.instance.playerUW.playerCam.transform.localRotation=Quaternion.identity;
														break;
												}


										case 0x5D  : ///   dungeon level
												GameWorldController.instance.startLevel=(int)DataLoader.getValAtAddress(buffer,i,16) - 1;break;
										case 0x5F:///High nibble is dungeon level+1 with the silver tree if planted
												//Low nibble is moongate level + 1
												GameWorldController.instance.playerUW.ResurrectLevel=((int)buffer[i]>>4) & 0xf;
												GameWorldController.instance.playerUW.MoonGateLevel=((int)buffer[i]) & 0xf;
												break;
										case 0x60  : ///    bits 2..5: play_poison and no of active effects
												GameWorldController.instance.playerUW.play_poison=(int)((buffer[i]>>2) & 0x7 );
												effectCounter = ((int)buffer[i]>>6) & 0x3;
												break;


										case 0x65: // hand, Gender & body, and class
												{
														//bit 1 = hand left/right
														//bit 2-5 = gender & body
														//bit 6-8 = class

														GRLoader chrBdy = new GRLoader(GRLoader.BODIES_GR);
														GameWorldController.instance.playerUW.isLefty = (((int)buffer[i] & 0x1) == 0);
														int bodyval= ((int)buffer[i]>>1) & 0xf;
														if (bodyval % 2 == 0)
														{//male 0,2,4,6,8
																GameWorldController.instance.playerUW.isFemale=false;
																//Body
																GameWorldController.instance.playerUW.Body=bodyval/2;
																UWHUD.instance.playerBody.texture=chrBdy.LoadImageAt(0+(bodyval/2));
														}
														else
														{//female=1,3,5,7,9
																GameWorldController.instance.playerUW.isFemale=true;
																GameWorldController.instance.playerUW.Body=(bodyval-1)/2;
																UWHUD.instance.playerBody.texture=chrBdy.LoadImageAt(5+((bodyval-1)/2));
														}
														//class
														GameWorldController.instance.playerUW.CharClass= buffer[i]>>5;

														break;
												}
										case 0x66://Quest flags
												{
														int val = (int)DataLoader.getValAtAddress(buffer,i,32);
														for (int b=31; b>=0;b--)
														{//Check order here
																if (((val<<b) & 0x1) == 1)
																{
																	GameWorldController.instance.playerUW.quest().QuestVariables[32-b]=1;
																}
																else
																{
																	GameWorldController.instance.playerUW.quest().QuestVariables[32-b]=0;	
																}
														}
														break;
												}
										case 0x6A:
												GameWorldController.instance.playerUW.quest().QuestVariables[32]=(int)DataLoader.getValAtAddress(buffer,i,8);break;
										case 0x6B:
												GameWorldController.instance.playerUW.quest().QuestVariables[33]=(int)DataLoader.getValAtAddress(buffer,i,8);break;
										case 0x6C:
												GameWorldController.instance.playerUW.quest().QuestVariables[34]=(int)DataLoader.getValAtAddress(buffer,i,8);break;
										case 0x6D:
												GameWorldController.instance.playerUW.quest().QuestVariables[35]=(int)DataLoader.getValAtAddress(buffer,i,8);break;
										case 0x6F://Garamon dream related?
												GameWorldController.instance.playerUW.quest().GaramonDream=(int)DataLoader.getValAtAddress(buffer,i,8);break;
										case 0x71://Game variables
										case 0x72:
										case 0x73:
										case 0x74:
										case 0x75:
										case 0x76:
										case 0x77:
										case 0x78:
										case 0x79:
										case 0x7A:
										case 0x7B:
										case 0x7C:
										case 0x7D:
										case 0x7E:
										case 0x7F:
										case 0x80:
										case 0x81:
										case 0x82:
										case 0x83:
										case 0x84:
										case 0x85:
										case 0x86:
										case 0x87:
										case 0x88:
										case 0x89:
										case 0x8A:
										case 0x8B:
										case 0x8C:
										case 0x8D:
										case 0x8E:
										case 0x8F:
										case 0x90:
												{
													GameWorldController.instance.variables[i-0x71]=(int)DataLoader.getValAtAddress(buffer,i,8);break;
													break;
												}
										case 0xCF  : ///   game time
												GameWorldController.instance.playerUW.game_time=(int)DataLoader.getValAtAddress(buffer,i,32);break;
										case 0xD0: gametimevals[0]=(int)DataLoader.getValAtAddress(buffer,i,8);break;
										case 0xD1: gametimevals[1]=(int)DataLoader.getValAtAddress(buffer,i,8);break;
										case 0xD2: gametimevals[2]=(int)DataLoader.getValAtAddress(buffer,i,8);break;


										case 0xDD  : ///    current vitality
												GameWorldController.instance.playerUW.CurVIT=(int)buffer[i];break;
										}
								}
						}
						//Reapply spell effects
						for (int a=0; a<=GameWorldController.instance.playerUW.ActiveSpell.GetUpperBound(0);a++)
						{//Clear out the old effects.
							if (GameWorldController.instance.playerUW.ActiveSpell[a]!=null)	
							{
								GameWorldController.instance.playerUW.ActiveSpell[a].CancelEffect();	
								if (GameWorldController.instance.playerUW.ActiveSpell[a]!=null)	
								{//The prevous effect had cancelled into anew effect. Eg fly->slowfall. Cancel again.
									GameWorldController.instance.playerUW.ActiveSpell[a].CancelEffect();	
								}
							}
						}

						//Clearout the passive spell effects
						for (int a=0; a<=GameWorldController.instance.playerUW.PassiveSpell.GetUpperBound(0);a++)
						{//Clear out the old passive effects.
							if (GameWorldController.instance.playerUW.PassiveSpell[a]!=null)	
							{
								GameWorldController.instance.playerUW.PassiveSpell[a].CancelEffect();
								if (GameWorldController.instance.playerUW.PassiveSpell[a]!=null)	
								{//The prevous effect had cancelled into anew effect. Eg fly->slowfall. Cancel again.
									GameWorldController.instance.playerUW.PassiveSpell[a].CancelEffect();	
								}
							}
						}

						for (int a=0; a<effectCounter;a++)
						{//Recast the new ones.
							GameWorldController.instance.playerUW.ActiveSpell[a] = GameWorldController.instance.playerUW.PlayerMagic.CastEnchantment(GameWorldController.instance.playerUW.gameObject,null,ActiveEffectIds[a], Magic.SpellRule_TargetSelf );
							GameWorldController.instance.playerUW.ActiveSpell[a].counter=ActiveEffectStability[a];
						}


						//Reapply poisoning.
						if (GameWorldController.instance.playerUW.play_poison!=0)
						{
							SpellEffectPoison p = (SpellEffectPoison)GameWorldController.instance.playerUW.PlayerMagic.CastEnchantment(GameWorldController.instance.playerUW.gameObject,null,SpellEffect.UW1_Spell_Effect_Poison,Magic.SpellRule_TargetSelf);
							p.counter=GameWorldController.instance.playerUW.play_poison;
							p.DOT=p.Value/p.counter;//Recalculate the poison damage to reapply.									
						}
						else
						{//Make sure any poison is cured.
							GameWorldController.instance.playerUW.PlayerMagic.CastEnchantment(GameWorldController.instance.playerUW.gameObject,null, SpellEffect.UW1_Spell_Effect_CurePoison,Magic.SpellRule_TargetSelf);									
						}

						GameClock.setUWTime( gametimevals[0] + (gametimevals[1] * 255 )  + (gametimevals[2] * 255 * 255 ));

						float Ratio=213f;
						float VertAdjust = 0.3543672f;
						GameWorldController.instance.StartPos=new Vector3((float)x_position/Ratio, (float)z_position/Ratio +VertAdjust ,(float)y_position/Ratio);

						//Read in the inventory
						//Stored in much the same way as an linked object list is.
						//Inventory list
						int NoOfItems = (buffer.GetUpperBound(0)-312)/8;
						ObjectLoader objLoader = new ObjectLoader();
						objLoader.objInfo = new ObjectLoaderInfo[NoOfItems+2];
						//ObjectLoaderInfo[] objList = new ObjectLoaderInfo[NoOfItems+2];
						int x=1;
						//Debug.Log ("remaining space " + ((int)buffer.GetUpperBound(0)-222));
						if (buffer.GetUpperBound(0)>=312)
						{
								int i = 312;
								while (i < buffer.GetUpperBound(0))
								{
										objLoader.objInfo[x] = new ObjectLoaderInfo();
										objLoader.objInfo[x].index=x;
										objLoader.objInfo[x].parentList=objLoader;
										objLoader.objInfo[x].tileX=TileMap.ObjectStorageTile;
										objLoader.objInfo[x].tileY=TileMap.ObjectStorageTile;
										objLoader.objInfo[x].InUseFlag=1;
										objLoader.objInfo[x].item_id = (int)(DataLoader.getValAtAddress(buffer,i+0,16)) & 0x1FF;
										objLoader.objInfo[x].flags  = (int)((DataLoader.getValAtAddress(buffer,i+0,16))>> 9) & 0x0F;
										objLoader.objInfo[x].enchantment = (short)(((DataLoader.getValAtAddress(buffer,i+0,16)) >> 12) & 0x01);
										objLoader.objInfo[x].doordir  = (short)(((DataLoader.getValAtAddress(buffer,i+0,16)) >> 13) & 0x01);
										objLoader.objInfo[x].invis  = (short)(((DataLoader.getValAtAddress(buffer,i+0,16)) >> 14 )& 0x01);
										objLoader.objInfo[x].is_quant = (short)(((DataLoader.getValAtAddress(buffer,i+0,16)) >> 15) & 0x01);
										//position at +2
										objLoader.objInfo[x].zpos = (int)(DataLoader.getValAtAddress(buffer,i+2,16)) & 0x7F;	//bits 0-6 
										//objList[x].heading =  45 * (int)(((DataLoader.getValAtAddress(buffer,i+2,16)) >> 7) & 0x07); //bits 7-9
										objLoader.objInfo[x].heading = (int)(((DataLoader.getValAtAddress(buffer,i+2,16)) >> 7) & 0x07); //bits 7-9

										objLoader.objInfo[x].y = (int)((DataLoader.getValAtAddress(buffer,i+2,16)) >> 10) & 0x07;	//bits 10-12
										objLoader.objInfo[x].x = (int)((DataLoader.getValAtAddress(buffer,i+2,16)) >> 13) & 0x07;	//bits 13-15

										//+4
										objLoader.objInfo[x].quality =(int)((DataLoader.getValAtAddress(buffer,i+4,16)) & 0x3F);
										objLoader.objInfo[x].next = ((DataLoader.getValAtAddress(buffer,i+4,16)>>6) & 0x3FF);

										//+6

										objLoader.objInfo[x].owner = (int)(DataLoader.getValAtAddress(buffer,i+6,16) & 0x3F) ;//bits 0-5

										objLoader.objInfo[x].link = (int)(DataLoader.getValAtAddress(buffer, i + 6, 16) >> 6 & 0x3FF); //bits 6-15
										i=i+8;
										x++;

								}
								//Create the inventory objects
								ObjectLoader.RenderObjectList(objLoader,GameWorldController.instance.currentTileMap(),GameWorldController.instance.InventoryMarker);
								for (int j=248; j<286; j=j+2)
								{//Apply objects to slots
										int index = ((int)DataLoader.getValAtAddress(buffer,j,16) >>6);
										string item_name;
										if (index!=0)
										{
												item_name=ObjectLoader.UniqueObjectName(objLoader.objInfo[index]);
										}
										else
										{
												item_name="";	
										}
										switch(j)
										{//Q? does handeness effect these???
										case 248://Helm
												GameWorldController.instance.playerUW.playerInventory.sHelm=item_name;break;
										case 250://Chest
												GameWorldController.instance.playerUW.playerInventory.sChest=item_name;break;
										case 252: //gloves
												GameWorldController.instance.playerUW.playerInventory.sGloves=item_name;break;
										case 254://Leggings
												GameWorldController.instance.playerUW.playerInventory.sLegs=item_name;break;
										case 256://boots
												GameWorldController.instance.playerUW.playerInventory.sBoots=item_name;break;
										case 258://  is the top right shoulder.
												GameWorldController.instance.playerUW.playerInventory.sRightShoulder=item_name;break;
										case 260:// is the top left shoulder.
												GameWorldController.instance.playerUW.playerInventory.sLeftShoulder=item_name;break;
										case 262://  is the right hand.
												GameWorldController.instance.playerUW.playerInventory.sRightHand=item_name;break;
										case 264://  is the left hand.
												GameWorldController.instance.playerUW.playerInventory.sLeftHand=item_name;break;
										case 266://  is the left ring (assumption.
												GameWorldController.instance.playerUW.playerInventory.sLeftRing=item_name;break;
										case 268://  is the right ring (assumption.
												GameWorldController.instance.playerUW.playerInventory.sRightRing=item_name;break;
										case 270://  is the backpack slots 1.
												GameWorldController.instance.playerUW.playerInventory.playerContainer.items[0]=item_name;break;
										case 272://  is the backpack slots 2.
												GameWorldController.instance.playerUW.playerInventory.playerContainer.items[1]=item_name;break;
										case 274://  is the backpack slots 3.
												GameWorldController.instance.playerUW.playerInventory.playerContainer.items[2]=item_name;break;
										case 276://  is the backpack slots 4.
												GameWorldController.instance.playerUW.playerInventory.playerContainer.items[3]=item_name;break;
										case 278://  is the backpack slots 5.
												GameWorldController.instance.playerUW.playerInventory.playerContainer.items[4]=item_name;break;
										case 280://  is the backpack slots 6.
												GameWorldController.instance.playerUW.playerInventory.playerContainer.items[5]=item_name;break;
										case 282://  is the backpack slots 7.
												GameWorldController.instance.playerUW.playerInventory.playerContainer.items[6]=item_name;break;
										case 284://  is the backpack slots 8.
												GameWorldController.instance.playerUW.playerInventory.playerContainer.items[7]=item_name;break;
										}
								}
								GameWorldController.instance.playerUW.playerInventory.Refresh();

							//Reapply effects from enchanted items by recalling the equip event.
							for (int s=0; s<=10; s++)
							{
								GameObject obj = GameWorldController.instance.playerUW.playerInventory.GetGameObjectAtSlot(s);
								if (obj!=null)
								{
									obj.GetComponent<ObjectInteraction>().Equip(s);
								}
							}

						}

						//Change the XOR Key back to D9
						//XorKey= 0xD9; 

						if (GameWorldController.instance.playerUW.decode)
						{
								//write out decrypted file for analysis
								byte[] dataToWrite = new byte[buffer.GetUpperBound(0)+1];
								for (long i=0; i<=buffer.GetUpperBound(0);i++)
								{
										dataToWrite[i] = (byte)buffer[i];
								}
								File.WriteAllBytes(Loader.BasePath + "save" + slotNo + "\\decoded_" + slotNo + ".dat", dataToWrite);
						}

						/*	if (recode)//Rewrite the file with test value changes.
						{
								xOrValue= (int)buffer[0];
								incrnum = 3;
								if (indextochange!=0)
								{
										buffer[indextochange]=(char)newvalue;										
								}

								for(int i=1; i<220; i++)
								{
										if ((i==81) | (i==161))
										{
												incrnum = 3;
										}
										buffer[i] ^= (char)((xOrValue+incrnum) & 0xFF);
										incrnum += 3;
								}
								//write back reencrypted file to test c
								byte[] dataToWrite = new byte[buffer.GetUpperBound(0)+1];
								for (long i=0; i<=buffer.GetUpperBound(0);i++)
								{
										dataToWrite[i] = (byte)buffer[i];
								}
								File.WriteAllBytes(Loader.BasePath + "save" + slotNo + "\\recoded.dat", dataToWrite);
						}*/


				}


		}

		/// <summary>
		/// Calcs the active spell effect id in a player.dat file and returns the correct value for the spell.
		/// </summary>
		/// <param name="val">Value.</param>
		public static int GetActiveSpellID(int val)
		{
			int effectID= ((val & 0xf)<<4) | ((val & 0xf0) >> 4);
			//Debug.Log (StringController.instance.GetString(6,effectID));

			switch (effectID)
			{
				case 178: 
					return SpellEffect.UW1_Spell_Effect_Speed;
				case 179:
					return SpellEffect.UW1_Spell_Effect_Telekinesis;					
				case 176: 
					return SpellEffect.UW1_Spell_Effect_FreezeTime;					
				case 183:
					return SpellEffect.UW1_Spell_Effect_RoamingSight;//Should not appear in a save game									
				default:
					return effectID;
			}
		}

		/// <summary>
		/// Sets the active rune slots.
		/// </summary>
		/// <param name="slotNo">Slot no.</param>
		/// <param name="rune">Rune.</param>
		static void SetActiveRuneSlots(int slotNo, int rune)
		{
				if (rune<24)
				{
						GameWorldController.instance.playerUW.PlayerMagic.ActiveRunes[slotNo]=rune;		
				}
				else
				{
						GameWorldController.instance.playerUW.PlayerMagic.ActiveRunes[slotNo]=-1;
				}
				ActiveRuneSlot.UpdateRuneSlots();	
		}

		/// <summary>
		/// Writes the player dat file based on the current character
		/// </summary>
		/// <param name="slotNo">Slot no.</param>
		public static void WritePlayerDat(int slotNo)
		{
				float Ratio=213f;
				float VertAdjust = 0.3543672f;

				//****Hardcoded values
			//	int[] hardcoded = {
				//		16,	16,	16,	16,	16,	240,	240,	240,	240,	240,	240,	16,	16,	16,	16,	16,	48,	48,	48,	48,	48,	37,	24,	16,	16,	16,	16,	143,	112,	112,	112,	112,	16,	16,	16,	16,	16,	48,	48,	48,	48,	48,	48,	16,	16,	16,	50,	33,	251,	241,	118,	122,	2,	160,	227,	22,	137,	140,	143,	0,	34,	0,	0,	0,	48,	0,	0,	0,	0,	0,	0,	0,	0,	44,	32,	128,	0,	0,	253,	0,	0,	0,	0,	0,	0,	0,	0
				//};

	
				FileStream file = File.Open(Loader.BasePath + "save" + slotNo + "\\playertmp.dat",FileMode.Create);
				BinaryWriter writer= new BinaryWriter(file);
				int NoOfActiveEffects=0;
				int runeOffset=0;

				//update inventory linking
				string[] inventoryObjects= ObjectLoader.UpdateInventoryObjectList();

				//Write the XOR Key
				DataLoader.WriteInt8(writer,GameWorldController.instance.playerUW.XorKey);
				//I'm lazy. I'm going to write a temp file and then re-encode using the key.
				for (int i=1; i<312;i++)
				{//non inventory data 

						if (i<14)
						{
								if (i-1 < GameWorldController.instance.playerUW.CharName.Length)	
								{
										char alpha = GameWorldController.instance.playerUW.CharName.ToCharArray()[i-1];
										DataLoader.WriteInt8(writer,(int)alpha);
								}
								else
								{
										DataLoader.WriteInt8(writer,0);
								}
						}
						else
						{
								switch(i)
								{
								case 0x1F ://Strength
										DataLoader.WriteInt8(writer,GameWorldController.instance.playerUW.PlayerSkills.STR);break;
								case 0x20 ://Dex
										DataLoader.WriteInt8(writer,GameWorldController.instance.playerUW.PlayerSkills.DEX);break;
								case 0x21 : ///    Intelligence
										DataLoader.WriteInt8(writer,GameWorldController.instance.playerUW.PlayerSkills.INT);break;
								case 0x22 : ///    Attack
										DataLoader.WriteInt8(writer,GameWorldController.instance.playerUW.PlayerSkills.Attack);break;
								case 0x23 : ///    Defense
										DataLoader.WriteInt8(writer,GameWorldController.instance.playerUW.PlayerSkills.Defense);break;
								case 0x24 : ///    Unarmed
										DataLoader.WriteInt8(writer,GameWorldController.instance.playerUW.PlayerSkills.Unarmed);break;
								case 0x25  : ///    Sword
										DataLoader.WriteInt8(writer,GameWorldController.instance.playerUW.PlayerSkills.Sword);break;
								case 0x26  : ///    Axe
										DataLoader.WriteInt8(writer,GameWorldController.instance.playerUW.PlayerSkills.Axe);break;
								case 0x27 : ///    Mace
										DataLoader.WriteInt8(writer,GameWorldController.instance.playerUW.PlayerSkills.Mace);break;
								case 0x28   : ///    Missile
										DataLoader.WriteInt8(writer,GameWorldController.instance.playerUW.PlayerSkills.Missile);break;
								case 0x29  : ///    Mana
										DataLoader.WriteInt8(writer,GameWorldController.instance.playerUW.PlayerSkills.ManaSkill);break;
								case 0x2A : ///    Lore
										DataLoader.WriteInt8(writer,GameWorldController.instance.playerUW.PlayerSkills.Lore);break;
								case 0x2B  : ///    Casting
										DataLoader.WriteInt8(writer,GameWorldController.instance.playerUW.PlayerSkills.Casting);break;
								case 0x2C  : ///    Traps
										DataLoader.WriteInt8(writer,GameWorldController.instance.playerUW.PlayerSkills.Traps);break;
								case 0x2D  : ///    Search
										DataLoader.WriteInt8(writer,GameWorldController.instance.playerUW.PlayerSkills.Search);break;
								case 0x2E : ///    Track
										DataLoader.WriteInt8(writer,GameWorldController.instance.playerUW.PlayerSkills.Track);break;
								case 0x2F  : ///    Sneak
										DataLoader.WriteInt8(writer,GameWorldController.instance.playerUW.PlayerSkills.Sneak);break;
								case 0x30  : ///    Repair
										DataLoader.WriteInt8(writer,GameWorldController.instance.playerUW.PlayerSkills.Repair);break;
								case 0x31 : ///    Charm
										DataLoader.WriteInt8(writer,GameWorldController.instance.playerUW.PlayerSkills.Charm);break;
								case 0x32 : ///    Picklock
										DataLoader.WriteInt8(writer,GameWorldController.instance.playerUW.PlayerSkills.PickLock);break;
								case 0x33  : ///    Acrobat
										DataLoader.WriteInt8(writer,GameWorldController.instance.playerUW.PlayerSkills.Acrobat);break;
								case 0x34  : ///    Appraise
										DataLoader.WriteInt8(writer,GameWorldController.instance.playerUW.PlayerSkills.Appraise);break;
								case 0x35  : ///    Swimming
										DataLoader.WriteInt8(writer,GameWorldController.instance.playerUW.PlayerSkills.Swimming);break;
								case 0x36://Curvit
										DataLoader.WriteInt8(writer,GameWorldController.instance.playerUW.CurVIT);break;
								case 0x37 : ///    max. vitality
										DataLoader.WriteInt8(writer,GameWorldController.instance.playerUW.MaxVIT);break;
								case 0x38 : ///    current mana, (play_mana)
										DataLoader.WriteInt8(writer,GameWorldController.instance.playerUW.PlayerMagic.CurMana);break;
								case 0x39  : ///    max. mana
										DataLoader.WriteInt8(writer,GameWorldController.instance.playerUW.PlayerMagic.MaxMana);break;
								case 0x3A : ///    hunger, play_hunger
										DataLoader.WriteInt8(writer,GameWorldController.instance.playerUW.FoodLevel);break;

								case 0x3B://Unknown s
								case 0x3C:		
										DataLoader.WriteInt8(writer,64);break;
								case 0x3E : ///    character level (play_level)
										DataLoader.WriteInt8(writer,GameWorldController.instance.playerUW.CharLevel);break;
								case 0x3F:
								//Active spell effect
									{
										for (int e = 0; e<3;e++)
										{
											if (GameWorldController.instance.playerUW.ActiveSpell[e]!=null)
											{
												int effectId= 0;
												int byteToWrite=0;

												switch (GameWorldController.instance.playerUW.ActiveSpell[e].EffectID)
												{//Fix spell effects that do not work with the nibble swap 
													case SpellEffect.UW1_Spell_Effect_Speed:
														effectId=178;break;
													case SpellEffect.UW1_Spell_Effect_Telekinesis:
														effectId=179;break;	
													case SpellEffect.UW1_Spell_Effect_FreezeTime:
														effectId=176;break;	
													case SpellEffect.UW1_Spell_Effect_RoamingSight://Should not appear in a save game
														effectId=183;break;			
													default:
														effectId=GameWorldController.instance.playerUW.ActiveSpell[e].EffectID;
														break;	
												}
												int stability =  GameWorldController.instance.playerUW.ActiveSpell[e].counter;
												byteToWrite =(stability <<8) | ((effectId & 0xf0)>> 4) | ((effectId & 0xf) <<4);
												
												//int effectID= ((val & 0xf)<<4) | ((val & 0xf0) >> 4*/
												
												DataLoader.WriteInt16(writer,byteToWrite);
												NoOfActiveEffects++;
											}
											else
											{//No effect leave empty
													DataLoader.WriteInt16(writer,0);		
											}						
												
										}
										break;
									}

								case 0x41:
								case 0x43:
								case 0x3F+1:
								case 0x41+1:
								case 0x43+1://Active spell effect. Addl. byte do nothing here.
										break;
								case 0x45://Runebits
								case 0x46://Runebits
								case 0x47://Runebits
										{
												int RuneByte=0;
												for (int r =7; r>=0; r--)
												{
														if (GameWorldController.instance.playerUW.PlayerMagic.PlayerRunes[7-r+runeOffset]==true)
														{
																RuneByte |= (1<<r); 
														}
												}
												DataLoader.WriteInt8(writer, RuneByte);
												runeOffset+=8;
												break;
										}
								case 0x48:
										if (GameWorldController.instance.playerUW.PlayerMagic.ActiveRunes[0]==-1)
										{
												DataLoader.WriteInt8(writer,24);	
										}
										else
										{
												DataLoader.WriteInt8(writer,GameWorldController.instance.playerUW.PlayerMagic.ActiveRunes[0]);	
										}
										break;
								case 0x49:
										if (GameWorldController.instance.playerUW.PlayerMagic.ActiveRunes[1]==-1)
										{
												DataLoader.WriteInt8(writer,24);	
										}
										else
										{
												DataLoader.WriteInt8(writer,GameWorldController.instance.playerUW.PlayerMagic.ActiveRunes[1]);	
										}
										break;
								case 0x4A:
										if (GameWorldController.instance.playerUW.PlayerMagic.ActiveRunes[2]==-1)
										{
												DataLoader.WriteInt8(writer,24);	
										}
										else
										{
												DataLoader.WriteInt8(writer,GameWorldController.instance.playerUW.PlayerMagic.ActiveRunes[2]);	
										}
										break;
								case 0x4B:
										{//No of inventory items?
												DataLoader.WriteInt8(writer,(inventoryObjects.GetUpperBound(0)+1)<<2);
												break;
										}

								case 0x4D : ///   weight in 0.1 stones
										//Or STR * 2; 
										DataLoader.WriteInt16(writer,GameWorldController.instance.playerUW.PlayerSkills.STR*2*10);
										break;
								case 0x4D+1://2nd Byte of weight. Ignore
										break;
								case 0x4F  : ///   experience in 0.1 points
										DataLoader.WriteInt32(writer,GameWorldController.instance.playerUW.EXP);break;
								case 0x4F+1:
								case 0x4F+2:
								case 0x4F+3:
										break;
								case 0x53: // skillpoints available to spend
										DataLoader.WriteInt8(writer,GameWorldController.instance.playerUW.TrainingPoints);break;
								case 0x55 : ///   x-position in level
										int x_position=(int)(GameWorldController.instance.playerUW.transform.position.x*Ratio);
										DataLoader.WriteInt16(writer,x_position);
										break;
								case 0x57  : ///   y-position
										int y_position=(int)(GameWorldController.instance.playerUW.transform.position.z*Ratio);
										DataLoader.WriteInt16(writer,y_position);
										break;
								case 0x59 : ///   z-position
										int z_position=(int)((GameWorldController.instance.playerUW.transform.position.y - VertAdjust)  * (Ratio));
										DataLoader.WriteInt16(writer,z_position);
										break;
								case 0x55+1 : ///   x-position in level
								case 0x57+1  : ///   y-position
								case 0x59+1 : ///   z-position
										//Skip over int 16
										break;
								case 0x5C : ///   heading
										{
												float heading=GameWorldController.instance.playerUW.transform.eulerAngles.y * (255f/360f);
												DataLoader.WriteInt8(writer,(int)heading);break;
												break;
										}
								case 0x5D  : ///   dungeon level										
										DataLoader.WriteInt8(writer,GameWorldController.instance.LevelNo+1);break;
								case 0x5F:///High nibble is dungeon level+1 with the silver tree if planted
										{
												int val = (GameWorldController.instance.playerUW.ResurrectLevel & 0xf)<<4 | (GameWorldController.instance.playerUW.MoonGateLevel & 0xf)	;
												DataLoader.WriteInt8(writer,val);
												break;
										}
								case 0x60  : ///    bits 2..5: play_poison
										DataLoader.WriteInt8(writer, (((NoOfActiveEffects & 0x3) <<6)) | GameWorldController.instance.playerUW.play_poison<<2);
										break;
								case 0x65: // hand, Gender & body, and class
										{
												//bit 1 = hand left/right
												//bit 2-5 = gender & body
												//bit 6-8 = class
												int val=0;
												if (!GameWorldController.instance.playerUW.isLefty)
												{
														val |=1;
												}
												if (GameWorldController.instance.playerUW.isFemale)
												{
														val |= ((GameWorldController.instance.playerUW.Body*2) + 1) <<1;
												}
												else
												{
														val |= ((GameWorldController.instance.playerUW.Body*2) ) <<1;	
												}
												val |=GameWorldController.instance.playerUW.CharClass<<5;
												DataLoader.WriteInt8(writer,val);break;
												break;
										}
								case 0x66://Quest flags
										{
												int val = 0;
												for (int b=0;b<32;b++)
												{
														val |= (GameWorldController.instance.playerUW.quest().QuestVariables[b] & 0x1) << b;
												}
												DataLoader.WriteInt32(writer,val);
												break;
										}

								case 0x66+1://Quest flags ignore
								case 0x66+2://Quest flags ignore
								case 0x66+3://Quest flags ignore
										break;

								case 0x6A:
										DataLoader.WriteInt8(writer,GameWorldController.instance.playerUW.quest().QuestVariables[32]);break;
								case 0x6B:
										DataLoader.WriteInt8(writer,GameWorldController.instance.playerUW.quest().QuestVariables[33]);break;
								case 0x6C:
										DataLoader.WriteInt8(writer,GameWorldController.instance.playerUW.quest().QuestVariables[34]);break;
								case 0x6D:
										DataLoader.WriteInt8(writer,GameWorldController.instance.playerUW.quest().QuestVariables[35]);break;
								case 0x6E://Is always 8???
										DataLoader.WriteInt8(writer,8);break;
								case 0x6F://Garamon dream related?
										DataLoader.WriteInt8(writer,GameWorldController.instance.playerUW.quest().GaramonDream);break;

								case 0x71://Game variables
								case 0x72:
								case 0x73:
								case 0x74:
								case 0x75:
								case 0x76:
								case 0x77:
								case 0x78:
								case 0x79:
								case 0x7A:
								case 0x7B:
								case 0x7C:
								case 0x7D:
								case 0x7E:
								case 0x7F:
								case 0x80:
								case 0x81:
								case 0x82:
								case 0x83:
								case 0x84:
								case 0x85:
								case 0x86:
								case 0x87:
								case 0x88:
								case 0x89:
								case 0x8A:
								case 0x8B:
								case 0x8C:
								case 0x8D:
								case 0x8E:
								case 0x8F:
								case 0x90:
										{
												DataLoader.WriteInt8(writer,GameWorldController.instance.variables[i-0x71]);
												break;
										}
								case 0xBC:
										//Unknown
										DataLoader.WriteInt8(writer,0xFF);
										break;

								case 0xB6: //UW Game options
										//high nibble is detail level.
										//bit 0 of low nibble is sound
										//bit 3 of low nibble is music
										DataLoader.WriteInt8(writer,0x35);
										break;
								case 0xB7://Unknown
										DataLoader.WriteInt8(writer,0x8);
										break;										
								case 0xCF  : ///   game time
										DataLoader.WriteInt32(writer,GameWorldController.instance.playerUW.game_time);break;
										break;
								case 0xD0://gametime ignore
								case 0xD1:
								case 0xD2:
										break;
								case 0xD3://No of inventory items + 1.
										DataLoader.WriteInt16(writer,inventoryObjects.GetUpperBound(0)+1+1);
										//Debug.Log("No of inventory " + inventoryObjects.GetUpperBound(0));
										break;
								case 0xD4://Skip prev
										break;
								case 0xD5:
										{//7F 20
												DataLoader.WriteInt8(writer,0x7F);break;
												break;	
										}
								case 0xD6:
										{//The mysterious clip through bridges on a second jump byte.
												DataLoader.WriteInt8(writer,0x20);break;
												break;
										}
								case 0xDB:
										if (GameWorldController.instance.InventoryMarker.transform.childCount>0)
										{//player has inventory. Not sure where these values come from
												DataLoader.WriteInt8(writer,0x40);break;	
										}
										else
										{
												DataLoader.WriteInt8(writer,0x0);break;	
										}
										break;
								case 0xDD://Duplicate curvit
										DataLoader.WriteInt8(writer,GameWorldController.instance.playerUW.CurVIT);break;
										break;

								case 0xF8: // Helm (all of these subsequent values are indices into the object list at offset 312
										WriteInventoryIndex(writer, inventoryObjects,0);break;
								case 0xF9: // Helm ignore
										break;
								case 0xFA: // Chest
										WriteInventoryIndex(writer, inventoryObjects,1);break;
								case 0xFB: // Chest ignore
										break;
								case 0xFC: // Gloves
										WriteInventoryIndex(writer, inventoryObjects,4);break;
								case 0xFD: // Gloves ignore
										break;
								case 0xFE: // Leggings
										WriteInventoryIndex(writer, inventoryObjects,2);break;
								case 0xFF: // Leggings ignore
										break;
								case 0x100: // Boots
										WriteInventoryIndex(writer, inventoryObjects,3);break;
								case 0x101: // Boots ignore
										break;
								case 0x102: // TopRightShoulder
										WriteInventoryIndex(writer, inventoryObjects,5);break;
								case 0x103: // TopRightShoulder ignore
										break;
								case 0x104: // TopLeftShoulder
										WriteInventoryIndex(writer, inventoryObjects,6);break;
								case 0x105: // TopLeftShoulder ignore
										break;
								case 0x106: // Righthand
										WriteInventoryIndex(writer, inventoryObjects,7);break;
								case 0x107: // Righthand ignore
										break;
								case 0x108: // LeftHand
										WriteInventoryIndex(writer, inventoryObjects,8);break;
								case 0x109: // LeftHand ignore
										break;
								case 0x10A: // RightRing
										WriteInventoryIndex(writer, inventoryObjects,9);break;
								case 0x10B: // RightRing ignore
										break;
								case 0x10C: // LeftRing
										WriteInventoryIndex(writer, inventoryObjects,10);break;
								case 0x10D: // LeftRing ignore
										break;
								case 0x10E: // Backpack0
										WriteInventoryIndex(writer, inventoryObjects,11);break;
								case 0x10F: // Backpack0 ignore
										break;
								case 0x110: // Backpack1
										WriteInventoryIndex(writer, inventoryObjects,12);break;
								case 0x111: // Backpack1 ignore
										break;
								case 0x112: // Backpack2
										WriteInventoryIndex(writer, inventoryObjects,13);break;
								case 0x113: // Backpack2 ignore
										break;
								case 0x114: // Backpack3
										WriteInventoryIndex(writer, inventoryObjects,14);break;
								case 0x115: // Backpack3 ignore
										break;
								case 0x116: // Backpack4
										WriteInventoryIndex(writer, inventoryObjects,15);break;
								case 0x117: // Backpack4 ignore
										break;
								case 0x118: // Backpack5
										WriteInventoryIndex(writer, inventoryObjects,16);break;
								case 0x119: // Backpack5 ignore
										break;
								case 0x11A: // Backpack6
										WriteInventoryIndex(writer, inventoryObjects,17);break;
								case 0x11B: // Backpack6 ignore
										break;
								case 0x11C: // Backpack7
										WriteInventoryIndex(writer, inventoryObjects,18);break;
								case 0x11D: // Backpack7 ignore
										break;	

								default://No value. Write 0	or hardcoded values
										//if ((i>=0xA1) || (i<=0xF7))
										//{//Unknown Hardcoded values
										//		DataLoader.WriteInt8(writer,hardcoded[i-161])	;
										//}
										//else
										//{
												DataLoader.WriteInt8(writer,0);break;	
										//}


										break;

								}	//endswitch


						}

				}

				//ALl things going well I should be at byte no 312 where I can write the inventory info.


				for (int o =0; o<=inventoryObjects.GetUpperBound(0); o++)
				{
						GameObject obj = GameObject.Find(inventoryObjects[o]);
						if (obj!=null)
						{
								ObjectInteraction currobj = obj.GetComponent<ObjectInteraction>();
								int ByteToWrite= (currobj.isquant << 15) |
										(currobj.invis << 14) |
										(currobj.doordir << 13) |
										(currobj.enchantment << 12) |
										((currobj.flags & 0x0F) << 9) |
										(currobj.item_id & 0x1FF) ;

								DataLoader.WriteInt8(writer,(ByteToWrite & 0xFF));
								DataLoader.WriteInt8(writer,((ByteToWrite>>8) & 0xFF));

								ByteToWrite = ((currobj.x & 0x7) << 13) |
										((currobj.y & 0x7) << 10) |
										((currobj.heading & 0x7) << 7) |
										((currobj.zpos & 0x7F));
								DataLoader.WriteInt8(writer,(ByteToWrite & 0xFF));
								DataLoader.WriteInt8(writer,((ByteToWrite>>8) & 0xFF));

								ByteToWrite = (((int)currobj.next & 0x3FF)<<6) |
										(currobj.quality & 0x3F); 
								DataLoader.WriteInt8(writer,(ByteToWrite & 0xFF));
								DataLoader.WriteInt8(writer,((ByteToWrite>>8) & 0xFF));	

								ByteToWrite = ((currobj.link & 0x3FF)<<6) |
										(currobj.owner & 0x3F); 
								DataLoader.WriteInt8(writer,(ByteToWrite & 0xFF));
								DataLoader.WriteInt8(writer,((ByteToWrite>>8) & 0xFF));	
						}
				}


				writer.Close();

				char[] buffer;
				//Reopen and encrypt the file
				if (DataLoader.ReadStreamFile(Loader.BasePath + "save" + slotNo + "\\playertmp.dat", out buffer))
				{
						int xOrValue= (int)buffer[0];
						int incrnum = 3;
						for(int i=1; i<=NoOfEncryptedBytes; i++)
						{
								if ((i==81) | (i==161))
								{
										incrnum = 3;
								}
								buffer[i] ^= (char)((xOrValue+incrnum) & 0xFF);
								incrnum += 3;
						}

						byte[] dataToWrite = new byte[buffer.GetUpperBound(0)+1];
						for (long i=0; i<=buffer.GetUpperBound(0);i++)
						{
								dataToWrite[i] = (byte)buffer[i];
						}
						File.WriteAllBytes(Loader.BasePath + "save" + slotNo + "\\player.dat", dataToWrite);

				}				

		}

		static void WriteInventoryIndex(BinaryWriter writer, string[] InventoryObjects, int slotIndex)
		{
				string itemAtSlot="";
				if (slotIndex<=10)
				{
						itemAtSlot = GameWorldController.instance.playerUW.playerInventory.GetObjectAtSlot(slotIndex);	
				}
				else
				{
						itemAtSlot = GameWorldController.instance.playerUW.playerInventory.playerContainer.GetItemAt(slotIndex-11);
				}
				if (itemAtSlot!="")
				{
						int index =((System.Array.IndexOf(InventoryObjects,itemAtSlot)+1)<<6);//64
						DataLoader.WriteInt16(writer, index);
				}
				else
				{
						DataLoader.WriteInt16(writer, 0);
				}
		}




		public static void LoadPlayerDatUW2(int slotNo)
		{
				GameWorldController.instance.playerUW.CharName="";
				char[] pDat;
				int x_position=0;
				int y_position=0;
				int z_position=0;

				int[] gametimevals=new int[3];
				int[] ActiveEffectIds=new int[3];
				int[] ActiveEffectStability=new int[3];
				int effectCounter=0;
				GameWorldController.instance.playerUW.playerInventory.currentContainer="_Gronk";
				if (DataLoader.ReadStreamFile(Loader.BasePath + "save" + slotNo + "\\player.dat", out pDat))
				{
					TileMap.OnWater=false;

						byte MS = (byte)DataLoader.getValAtAddress(pDat,0,8);
						//char [] c = new char[pDat.GetUpperBound(0)];
						///for (int i=1; i<=pDat.GetUpperBound(0); i++)
						//{
						//	c[i-1] = pDat[i];
						//}
						//MS=0x98;
						int[] MA = new int[80];
						MS += 7;
						for (int i = 0; i<80; ++i)
						{
								MS += 6;
								MA[i] = MS;
						}
						for (int i = 0; i<16; ++i)
						{
								MS += 7;
								MA[i*5] = MS;
						}
						for (int i = 0; i<4; ++i)
						{
								MS += 0x29;
								MA[i*12] = MS;
						}
						for (int i = 0; i<11; ++i)
						{
								MS += 0x49;
								MA[i*7] = MS;
						}

						char[] buffer = new char[pDat.GetUpperBound(0)+1];
						int offset=1;
						int byteCounter=0;
						for (int l=0; l<=11; l++)
						{
							buffer[0+offset] = (char)(pDat[0+offset] ^ MA[0]);
							byteCounter++;
							for (int i=1; i<0x50;++i)
							{
								if (byteCounter<0x37D)
								{
											buffer[i+offset] =(char)((
												(pDat[i+offset] & 0xff) ^
													( ( buffer[i-1+offset]  & 0xff)
														+ ( pDat[i-1+offset] & 0xff)
														+ ( MA[i] & 0xff)
												)
										) & 0xff);		
									byteCounter++;
								}
								
							}	
							offset+=80;
							
						}

						//Copy the remainder of the plaintext data
						while (byteCounter <=pDat.GetUpperBound(0))
						{
							buffer[byteCounter]= pDat[byteCounter];
							byteCounter++;
						}
				
						if (GameWorldController.instance.playerUW.decode)
						{
								//write out decrypted file for analysis
								byte[] dataToWrite = new byte[buffer.GetUpperBound(0)+1];
								for (long i=0; i<=buffer.GetUpperBound(0);i++)
								{
										dataToWrite[i] = (byte)buffer[i];
								}
								File.WriteAllBytes(Loader.BasePath + "save" + slotNo + "\\decoded_" + slotNo + ".dat", dataToWrite);
						}

						int runeOffset=0;

						for (int i=1; i<=300;i++)
						{
								if (i<14)
								{
										if (buffer[i].ToString() != "\0")
										{
												GameWorldController.instance.playerUW.CharName +=buffer[i];
										}
								}
								else
								{

										switch(i)//UWformats doesn't take the first byte into account when describing offsets! I have incremented plus one
										{
										case 0x1F ://Strength
												GameWorldController.instance.playerUW.PlayerSkills.STR=(int)buffer[i];break;
										case 0x20 ://Dex
												GameWorldController.instance.playerUW.PlayerSkills.DEX=(int)buffer[i];break;
										case 0x21 : ///    Intelligence
												GameWorldController.instance.playerUW.PlayerSkills.INT=(int)buffer[i];break;
										case 0x22 : ///    Attack
												GameWorldController.instance.playerUW.PlayerSkills.Attack=(int)buffer[i];break;
										case 0x23 : ///    Defense
												GameWorldController.instance.playerUW.PlayerSkills.Defense=(int)buffer[i];break;
										case 0x24 : ///    Unarmed
												GameWorldController.instance.playerUW.PlayerSkills.Unarmed=(int)buffer[i];break;
										case 0x25  : ///    Sword
												GameWorldController.instance.playerUW.PlayerSkills.Sword=(int)buffer[i];break;
										case 0x26  : ///    Axe
												GameWorldController.instance.playerUW.PlayerSkills.Axe=(int)buffer[i];break;
										case 0x27 : ///    Mace
												GameWorldController.instance.playerUW.PlayerSkills.Mace=(int)buffer[i];break;
										case 0x28   : ///    Missile
												GameWorldController.instance.playerUW.PlayerSkills.Missile=(int)buffer[i];break;
										case 0x29  : ///    Mana
												GameWorldController.instance.playerUW.PlayerSkills.ManaSkill=(int)buffer[i];break;
										case 0x2A : ///    Lore
												GameWorldController.instance.playerUW.PlayerSkills.Lore=(int)buffer[i];break;
										case 0x2B  : ///    Casting
												GameWorldController.instance.playerUW.PlayerSkills.Casting=(int)buffer[i];break;
										case 0x2C  : ///    Traps
												GameWorldController.instance.playerUW.PlayerSkills.Traps=(int)buffer[i];break;
										case 0x2D  : ///    Search
												GameWorldController.instance.playerUW.PlayerSkills.Search=(int)buffer[i];break;
										case 0x2E : ///    Track
												GameWorldController.instance.playerUW.PlayerSkills.Track=(int)buffer[i];break;
										case 0x2F  : ///    Sneak
												GameWorldController.instance.playerUW.PlayerSkills.Sneak=(int)buffer[i];break;
										case 0x30  : ///    Repair
												GameWorldController.instance.playerUW.PlayerSkills.Repair=(int)buffer[i];break;
										case 0x31 : ///    Charm
												GameWorldController.instance.playerUW.PlayerSkills.Charm=(int)buffer[i];break;
										case 0x32 : ///    Picklock
												GameWorldController.instance.playerUW.PlayerSkills.PickLock=(int)buffer[i];break;
										case 0x33  : ///    Acrobat
												GameWorldController.instance.playerUW.PlayerSkills.Acrobat=(int)buffer[i];break;
										case 0x34  : ///    Appraise
												GameWorldController.instance.playerUW.PlayerSkills.Appraise=(int)buffer[i];break;
										case 0x35  : ///    Swimming
												GameWorldController.instance.playerUW.PlayerSkills.Swimming=(int)buffer[i];break;
										case 0x36://Curvit
												GameWorldController.instance.playerUW.CurVIT=(int)buffer[i];break;
										case 0x37 : ///    max. vitality
												GameWorldController.instance.playerUW.MaxVIT=(int)buffer[i];break;
										case 0x38 : ///    current mana, (play_mana)
												GameWorldController.instance.playerUW.PlayerMagic.CurMana=(int)buffer[i];break;
										case 0x39  : ///    max. mana
												GameWorldController.instance.playerUW.PlayerMagic.MaxMana=(int)buffer[i];break;
										case 0x3A : ///    hunger, play_hunger
												GameWorldController.instance.playerUW.FoodLevel=(int)buffer[i];break;		
										case 0x3B:
												//Unknown. Observed values 0 and 64?//Fatigue???
												break;
												//case 0x3C:
												//		testvalue=(int)buffer[i];break;	

										case 0x3E : ///    character level (play_level)
												GameWorldController.instance.playerUW.CharLevel=(int)buffer[i];break;
										case 0x3F:
										case 0x41:
										case 0x43://Active spell effect
												{
														ActiveEffectIds[effectCounter]=SaveGame.GetActiveSpellID((int)buffer[i]);break;		
												}
										case 0x3F+1:
										case 0x41+1:
										case 0x43+1://Active spell effect stability
												{
														ActiveEffectStability[effectCounter++]=(int)buffer[i];break;		
												}
										case 0x45://Runebits
										case 0x46://Runebits
										case 0x47://Runebits
												for (int r =7; r>=0; r--)
												{
														if (((buffer[i]>>r) & 0x1 )== 1)
														{
																GameWorldController.instance.playerUW.PlayerMagic.PlayerRunes[7-r+runeOffset]=true;
														}
														else
														{
																GameWorldController.instance.playerUW.PlayerMagic.PlayerRunes[7-r+runeOffset]=false;
														}
												}
												runeOffset+=8;
												break;
										case 0x48:
												SetActiveRuneSlots(0, (int)buffer[i]);
												break;
										case 0x49:
												SetActiveRuneSlots(1, (int)buffer[i]);
												break;
										case 0x4A:
												SetActiveRuneSlots(2, (int)buffer[i]);
												break;

										case 0x4D : ///   weight in 0.1 stones
												//Or STR * 2; safe to ignore?
												//testvalue=(int)DataLoader.getValAtAddress(buffer,i,16);break;
												break;
										case 0x4F  : ///   experience in 0.1 points
												GameWorldController.instance.playerUW.EXP=(int)DataLoader.getValAtAddress(buffer,i,32);break;
										case 0x53: // skillpoints available to spend
												GameWorldController.instance.playerUW.TrainingPoints=(int)buffer[i];break;
										case 0x55 : ///   x-position in level
												x_position= (int)DataLoader.getValAtAddress(buffer,i,16);break;
										case 0x57  : ///   y-position
												y_position=(int)DataLoader.getValAtAddress(buffer,i,16);break;
										case 0x59 : ///   z-position
												z_position=(int)DataLoader.getValAtAddress(buffer,i,16);break;
										case 0x5C : ///   heading
												{
														float heading=(float)DataLoader.getValAtAddress(buffer,i,8);	

														//heading=255f-heading;//reversed
														//playerCam.transform.rotation=Vector3.zero;

														//this.transform.Rotate(0f,heading*(255f/360f),0f,Space.World);
														GameWorldController.instance.playerUW.transform.eulerAngles=new Vector3(0f,heading*(360f/255f),0f);
														//playerCam.transform.localRotation.eulerAngles=Vector3.zero;
														GameWorldController.instance.playerUW.playerCam.transform.localRotation=Quaternion.identity;
														break;
												}


										case 0x5D  : ///   dungeon level									
												GameWorldController.instance.startLevel=(int)DataLoader.getValAtAddress(buffer,i,16) - 1;break;
										case 0x5F:///High nibble is dungeon level+1 with the silver tree if planted
												//Low nibble is moongate level + 1
												GameWorldController.instance.playerUW.ResurrectLevel=((int)buffer[i]>>4) & 0xf;
												GameWorldController.instance.playerUW.MoonGateLevel=((int)buffer[i]) & 0xf;
												break;
										case 0x60  : ///    bits 2..5: play_poison and no of active effects
												GameWorldController.instance.playerUW.play_poison=(int)((buffer[i]>>2) & 0x7 );
												effectCounter = ((int)buffer[i]>>6) & 0x3;
												break;
										case 0x65+1: // hand, Gender & body, and class
												{
														//bit 1 = hand left/right
														//bit 2-5 = gender & body
														//bit 6-8 = class

														GRLoader chrBdy = new GRLoader(GRLoader.BODIES_GR);
														GameWorldController.instance.playerUW.isLefty = (((int)buffer[i] & 0x1) == 0);
														int bodyval= ((int)buffer[i]>>1) & 0xf;
														if (bodyval % 2 == 0)
														{//male 0,2,4,6,8
																GameWorldController.instance.playerUW.isFemale=false;
																//Body
																GameWorldController.instance.playerUW.Body=bodyval/2;
																UWHUD.instance.playerBody.texture=chrBdy.LoadImageAt(0+(bodyval/2));
														}
														else
														{//female=1,3,5,7,9
																GameWorldController.instance.playerUW.isFemale=true;
																GameWorldController.instance.playerUW.Body=(bodyval-1)/2;
																UWHUD.instance.playerBody.texture=chrBdy.LoadImageAt(5+((bodyval-1)/2));
														}
														//class
														GameWorldController.instance.playerUW.CharClass= buffer[i]>>5;

														break;
												}


										}
								}

						}
						//Reapply spell effects
						for (int a=0; a<=GameWorldController.instance.playerUW.ActiveSpell.GetUpperBound(0);a++)
						{//Clear out the old effects.
								if (GameWorldController.instance.playerUW.ActiveSpell[a]!=null)	
								{
										GameWorldController.instance.playerUW.ActiveSpell[a].CancelEffect();	
										if (GameWorldController.instance.playerUW.ActiveSpell[a]!=null)	
										{//The prevous effect had cancelled into anew effect. Eg fly->slowfall. Cancel again.
												GameWorldController.instance.playerUW.ActiveSpell[a].CancelEffect();	
										}
								}
						}

						//Clearout the passive spell effects
						for (int a=0; a<=GameWorldController.instance.playerUW.PassiveSpell.GetUpperBound(0);a++)
						{//Clear out the old passive effects.
								if (GameWorldController.instance.playerUW.PassiveSpell[a]!=null)	
								{
										GameWorldController.instance.playerUW.PassiveSpell[a].CancelEffect();
										if (GameWorldController.instance.playerUW.PassiveSpell[a]!=null)	
										{//The prevous effect had cancelled into anew effect. Eg fly->slowfall. Cancel again.
												GameWorldController.instance.playerUW.PassiveSpell[a].CancelEffect();	
										}
								}
						}

						for (int a=0; a<effectCounter;a++)
						{//Recast the new ones.
								GameWorldController.instance.playerUW.ActiveSpell[a] = GameWorldController.instance.playerUW.PlayerMagic.CastEnchantment(GameWorldController.instance.playerUW.gameObject,null,ActiveEffectIds[a], Magic.SpellRule_TargetSelf );
								GameWorldController.instance.playerUW.ActiveSpell[a].counter=ActiveEffectStability[a];
						}


						//Reapply poisoning.
						if (GameWorldController.instance.playerUW.play_poison!=0)
						{
								SpellEffectPoison p = (SpellEffectPoison)GameWorldController.instance.playerUW.PlayerMagic.CastEnchantment(GameWorldController.instance.playerUW.gameObject,null,SpellEffect.UW1_Spell_Effect_Poison,Magic.SpellRule_TargetSelf);
								p.counter=GameWorldController.instance.playerUW.play_poison;
								p.DOT=p.Value/p.counter;//Recalculate the poison damage to reapply.									
						}
						else
						{//Make sure any poison is cured.
								GameWorldController.instance.playerUW.PlayerMagic.CastEnchantment(GameWorldController.instance.playerUW.gameObject,null, SpellEffect.UW1_Spell_Effect_CurePoison,Magic.SpellRule_TargetSelf);									
						}

						GameClock.setUWTime( gametimevals[0] + (gametimevals[1] * 255 )  + (gametimevals[2] * 255 * 255 ));

						float Ratio=213f;
						float VertAdjust = 0.3543672f;
						GameWorldController.instance.StartPos=new Vector3((float)x_position/Ratio, (float)z_position/Ratio +VertAdjust ,(float)y_position/Ratio);


						return;
				}




		}


}

using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.UI;

public class SaveGame : Loader {
		private const int NoOfEncryptedBytes=0xD2;//218;		//219
		/// <summary>
		/// Loads the player dat file into the current character
		/// </summary>
		/// <param name="slotNo">Slot no.</param>
		public static void LoadPlayerDat(int slotNo)
		{
				UWCharacter.Instance.CharName="";
				char[] buffer;
				int x_position=0;
				int y_position=0;
				int z_position=0;

				//int[] gametimevals=new int[3];
				int[] ActiveEffectIds=new int[3];
				short[] ActiveEffectStability=new short[3];
				int effectCounter=0;
				UWCharacter.Instance.playerInventory.currentContainer="_Gronk";
				UWHUD.instance.ContainerOpened.GetComponent<RawImage>().texture=UWCharacter.Instance.playerInventory.Blank;
				UWHUD.instance.ContainerOpened.GetComponent<ContainerOpened>().BackpackBg.SetActive(false);
				UWHUD.instance.ContainerOpened.GetComponent<ContainerOpened>().InvUp.SetActive(false);
				UWHUD.instance.ContainerOpened.GetComponent<ContainerOpened>().InvDown.SetActive(false);
				if (DataLoader.ReadStreamFile(Loader.BasePath + "save" + slotNo + "\\player.dat", out buffer))
				{

						TileMap.OnWater=false;
						int xOrValue= (int)buffer[0];
						UWCharacter.Instance.XorKey=xOrValue;
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
										UWCharacter.Instance.CharName +=buffer[i];
										}
								}
								else
								{
										switch(i)//UWformats doesn't take the first byte into account when describing offsets! I have incremented plus one
										{
										case 0x1F ://Strength
												UWCharacter.Instance.PlayerSkills.STR=(int)buffer[i];break;
										case 0x20 ://Dex
												UWCharacter.Instance.PlayerSkills.DEX=(int)buffer[i];break;
										case 0x21 : ///    Intelligence
												UWCharacter.Instance.PlayerSkills.INT=(int)buffer[i];break;
										case 0x22 : ///    Attack
												UWCharacter.Instance.PlayerSkills.Attack=(int)buffer[i];break;
										case 0x23 : ///    Defense
												UWCharacter.Instance.PlayerSkills.Defense=(int)buffer[i];break;
										case 0x24 : ///    Unarmed
												UWCharacter.Instance.PlayerSkills.Unarmed=(int)buffer[i];break;
										case 0x25  : ///    Sword
												UWCharacter.Instance.PlayerSkills.Sword=(int)buffer[i];break;
										case 0x26  : ///    Axe
												UWCharacter.Instance.PlayerSkills.Axe=(int)buffer[i];break;
										case 0x27 : ///    Mace
												UWCharacter.Instance.PlayerSkills.Mace=(int)buffer[i];break;
										case 0x28   : ///    Missile
												UWCharacter.Instance.PlayerSkills.Missile=(int)buffer[i];break;
										case 0x29  : ///    Mana
												UWCharacter.Instance.PlayerSkills.ManaSkill=(int)buffer[i];break;
										case 0x2A : ///    Lore
												UWCharacter.Instance.PlayerSkills.Lore=(int)buffer[i];break;
										case 0x2B  : ///    Casting
												UWCharacter.Instance.PlayerSkills.Casting=(int)buffer[i];break;
										case 0x2C  : ///    Traps
												UWCharacter.Instance.PlayerSkills.Traps=(int)buffer[i];break;
										case 0x2D  : ///    Search
												UWCharacter.Instance.PlayerSkills.Search=(int)buffer[i];break;
										case 0x2E : ///    Track
												UWCharacter.Instance.PlayerSkills.Track=(int)buffer[i];break;
										case 0x2F  : ///    Sneak
												UWCharacter.Instance.PlayerSkills.Sneak=(int)buffer[i];break;
										case 0x30  : ///    Repair
												UWCharacter.Instance.PlayerSkills.Repair=(int)buffer[i];break;
										case 0x31 : ///    Charm
												UWCharacter.Instance.PlayerSkills.Charm=(int)buffer[i];break;
										case 0x32 : ///    Picklock
												UWCharacter.Instance.PlayerSkills.PickLock=(int)buffer[i];break;
										case 0x33  : ///    Acrobat
												UWCharacter.Instance.PlayerSkills.Acrobat=(int)buffer[i];break;
										case 0x34  : ///    Appraise
												UWCharacter.Instance.PlayerSkills.Appraise=(int)buffer[i];break;
										case 0x35  : ///    Swimming
												UWCharacter.Instance.PlayerSkills.Swimming=(int)buffer[i];break;
										case 0x36://Curvit
												UWCharacter.Instance.CurVIT=(int)buffer[i];break;
										case 0x37 : ///    max. vitality
												UWCharacter.Instance.MaxVIT=(int)buffer[i];break;
										case 0x38 : ///    current mana, (play_mana)
												UWCharacter.Instance.PlayerMagic.CurMana=(int)buffer[i];break;
										case 0x39  : ///    max. mana  (see also true max mana)
												UWCharacter.Instance.PlayerMagic.MaxMana=(int)buffer[i];break;
										case 0x3A : ///    hunger, play_hunger
												UWCharacter.Instance.FoodLevel=(int)buffer[i];break;		
										case 0x3B:
												//Unknown. Observed values 0 and 64?//Fatigue???
												break;
												//case 0x3C:
												//		testvalue=(int)buffer[i];break;	

										case 0x3E : ///    character level (play_level)
												UWCharacter.Instance.CharLevel=(int)buffer[i];break;
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
												ActiveEffectStability[effectCounter++]=(short)buffer[i];break;		
												}
										case 0x45://Runebits
										case 0x46://Runebits
										case 0x47://Runebits
												for (int r =7; r>=0; r--)
												{
														if (((buffer[i]>>r) & 0x1 )== 1)
														{
																UWCharacter.Instance.PlayerMagic.PlayerRunes[7-r+runeOffset]=true;
														}
														else
														{
																UWCharacter.Instance.PlayerMagic.PlayerRunes[7-r+runeOffset]=false;
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
										case 0x4B://No of items. used here just to initialise a value.
												//UWCharacter.Instance.playerInventory.ItemCounter= (int)buffer[i]>>2;
												break;
										case 0x4D : ///   weight in 0.1 stones
												//Or STR * 2; safe to ignore?
												//testvalue=(int)DataLoader.getValAtAddress(buffer,i,16);break;
												break;
										case 0x4F  : ///   experience in 0.1 points
												UWCharacter.Instance.EXP=(int)DataLoader.getValAtAddress(buffer,i,32);break;
										case 0x53: // skillpoints available to spend
												UWCharacter.Instance.TrainingPoints=(int)buffer[i];break;
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
														UWCharacter.Instance.transform.eulerAngles=new Vector3(0f,heading*(360f/255f),0f);
														//playerCam.transform.localRotation.eulerAngles=Vector3.zero;
														UWCharacter.Instance.playerCam.transform.localRotation=Quaternion.identity;
														break;
												}


										case 0x5D  : ///   dungeon level
												GameWorldController.instance.startLevel=(short)(DataLoader.getValAtAddress(buffer,i,16) - 1);break;
										case 0x5F:///High nibble is dungeon level+1 with the silver tree if planted
												//Low nibble is moongate level + 1
												UWCharacter.Instance.ResurrectLevel=(short)((buffer[i]>>4) & 0xf);
												UWCharacter.Instance.MoonGateLevel=(short)((buffer[i]) & 0xf);
												break;
										case 0x60  : ///    bits 2..5: play_poison and no of active effects
												Quest.instance.IncenseDream=(int)(buffer[i] & 0x3);
												UWCharacter.Instance.play_poison=(short)((buffer[i]>>2) & 0xf );
												effectCounter = ((int)buffer[i]>>6) & 0x3;
												break;
										case 0x61:
												{
													Quest.instance.isOrbDestroyed= ((((int)DataLoader.getValAtAddress(buffer,i,8) >> 5) & 0x1) == 1);
													Quest.instance.isCupFound= ((((int)DataLoader.getValAtAddress(buffer,i,8) >> 6) & 0x1) == 1);
														break;
												}	
										case 0x63:
												{
													Quest.instance.isGaramonBuried= ((int)buffer[i]==28);break;
												}
										
										case 0x65: // hand, Gender & body, and class
												{
														//bit 1 = hand left/right
														//bit 2-5 = gender & body
														//bit 6-8 = class

														GRLoader chrBdy = new GRLoader(GRLoader.BODIES_GR);
														UWCharacter.Instance.isLefty = (((int)buffer[i] & 0x1) == 0);
														int bodyval= ((int)buffer[i]>>1) & 0xf;
														if (bodyval % 2 == 0)
														{//male 0,2,4,6,8
																UWCharacter.Instance.isFemale=false;
																//Body
																UWCharacter.Instance.Body=bodyval/2;
																UWHUD.instance.playerBody.texture=chrBdy.LoadImageAt(0+(bodyval/2));
														}
														else
														{//female=1,3,5,7,9
																UWCharacter.Instance.isFemale=true;
																UWCharacter.Instance.Body=(bodyval-1)/2;
																UWHUD.instance.playerBody.texture=chrBdy.LoadImageAt(5+((bodyval-1)/2));
														}
														//class
														UWCharacter.Instance.CharClass= buffer[i]>>5;

														break;
												}
										case 0x66://Quest flags
												{
														int val = (int)DataLoader.getValAtAddress(buffer,i,32);
														for (int b=31; b>=0;b--)
														{//Check order here
																if (((val<<b) & 0x1) == 1)
																{
																	Quest.instance.QuestVariables[32-b]=1;
																}
																else
																{
																	Quest.instance.QuestVariables[32-b]=0;	
																}
														}
														break;
												}
										case 0x6A:
												Quest.instance.QuestVariables[32]=(int)DataLoader.getValAtAddress(buffer,i,8);break;
										case 0x6B:
												Quest.instance.QuestVariables[33]=(int)DataLoader.getValAtAddress(buffer,i,8);break;
										case 0x6C:
												Quest.instance.QuestVariables[34]=(int)DataLoader.getValAtAddress(buffer,i,8);break;
										case 0x6D:
												Quest.instance.QuestVariables[35]=(int)DataLoader.getValAtAddress(buffer,i,8);break;
										
										case 0x6E://No of talismans still to destory
												Quest.instance.TalismansRemaining=(int)DataLoader.getValAtAddress(buffer,i,8);break;
										
										case 0x6F://Garamon dream related?
												Quest.instance.GaramonDream=(int)DataLoader.getValAtAddress(buffer,i,8);break;
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
													Quest.instance.variables[i-0x71]=(int)DataLoader.getValAtAddress(buffer,i,8);break;
													//break;
												}
										case 0xB1:  //The true max mana of the character. Used with the orb on level 7
												UWCharacter.Instance.PlayerMagic.TrueMaxMana=(int)DataLoader.getValAtAddress(buffer,i,8);
												break;
										case 0xB6: //Game options. High nibble is detail which is ignored Bit 0 is sound. Bit 3 is music
												{
													int val =	(int)DataLoader.getValAtAddress(buffer,i,8);
													ObjectInteraction.PlaySoundEffects= ((val & 0x1) == 1);
													MusicController.PlayMusic=( ( ( val>>2 ) & 0x1 ) == 1 );
													break;
												}
										case 0xCF  : ///   game time
												UWCharacter.Instance.game_time=(int)DataLoader.getValAtAddress(buffer,i,32);break;
										case 0xD0: 
												GameClock.instance.gametimevals[0]=(int)DataLoader.getValAtAddress(buffer,i,8);break;
										case 0xD1: 
												GameClock.instance.gametimevals[1]=(int)DataLoader.getValAtAddress(buffer,i,8);break;
										case 0xD2: 
												GameClock.instance.gametimevals[2]=(int)DataLoader.getValAtAddress(buffer,i,8);break;

										case 0xDD  : ///    current vitality
												UWCharacter.Instance.CurVIT=(int)buffer[i];break;
										}
								}
						}
						//Reapply spell effects
						for (int a=0; a<=UWCharacter.Instance.ActiveSpell.GetUpperBound(0);a++)
						{//Clear out the old effects.
							if (UWCharacter.Instance.ActiveSpell[a]!=null)	
							{
								UWCharacter.Instance.ActiveSpell[a].CancelEffect();	
								if (UWCharacter.Instance.ActiveSpell[a]!=null)	
								{//The prevous effect had cancelled into anew effect. Eg fly->slowfall. Cancel again.
									UWCharacter.Instance.ActiveSpell[a].CancelEffect();	
								}
							}
						}

						//Clearout the passive spell effects
						for (int a=0; a<=UWCharacter.Instance.PassiveSpell.GetUpperBound(0);a++)
						{//Clear out the old passive effects.
							if (UWCharacter.Instance.PassiveSpell[a]!=null)	
							{
								UWCharacter.Instance.PassiveSpell[a].CancelEffect();
								if (UWCharacter.Instance.PassiveSpell[a]!=null)	
								{//The prevous effect had cancelled into anew effect. Eg fly->slowfall. Cancel again.
									UWCharacter.Instance.PassiveSpell[a].CancelEffect();	
								}
							}
						}

						for (int a=0; a<effectCounter;a++)
						{//Recast the new ones.
							UWCharacter.Instance.ActiveSpell[a] = UWCharacter.Instance.PlayerMagic.CastEnchantment(UWCharacter.Instance.gameObject,null,ActiveEffectIds[a], Magic.SpellRule_TargetSelf );
							UWCharacter.Instance.ActiveSpell[a].counter=ActiveEffectStability[a];
						}


						//Reapply poisoning.
						if (UWCharacter.Instance.play_poison!=0)
						{
							SpellEffectPoison p = (SpellEffectPoison)UWCharacter.Instance.PlayerMagic.CastEnchantment(UWCharacter.Instance.gameObject,null,SpellEffect.UW1_Spell_Effect_Poison,Magic.SpellRule_TargetSelf);
							p.counter=UWCharacter.Instance.play_poison;
							p.DOT=(short)(p.Value/p.counter);//Recalculate the poison damage to reapply.									
						}
						else
						{//Make sure any poison is cured.
							UWCharacter.Instance.PlayerMagic.CastEnchantment(UWCharacter.Instance.gameObject,null, SpellEffect.UW1_Spell_Effect_CurePoison,Magic.SpellRule_TargetSelf);									
						}

						GameClock.setUWTime( GameClock.instance.gametimevals[0] + (GameClock.instance.gametimevals[1] * 255 )  + (GameClock.instance.gametimevals[2] * 255 * 255 ));

						float Ratio=213f;
						float VertAdjust = 0.3543672f;
						GameWorldController.instance.StartPos=new Vector3((float)x_position/Ratio, (float)z_position/Ratio +VertAdjust ,(float)y_position/Ratio);

						//CLear out the original inventory
						UWCharacter.Instance.playerInventory.sHelm="";
						UWCharacter.Instance.playerInventory.sChest="";
						UWCharacter.Instance.playerInventory.sGloves="";
						UWCharacter.Instance.playerInventory.sLegs="";
						UWCharacter.Instance.playerInventory.sBoots="";
						UWCharacter.Instance.playerInventory.sRightShoulder="";
						UWCharacter.Instance.playerInventory.sLeftShoulder="";
						UWCharacter.Instance.playerInventory.sRightHand="";
						UWCharacter.Instance.playerInventory.sLeftHand="";
						UWCharacter.Instance.playerInventory.sRightRing="";
						UWCharacter.Instance.playerInventory.sLeftRing="";
						for (int c=0; c<=UWCharacter.Instance.playerInventory.playerContainer.items.GetUpperBound(0);c++)
						{
							UWCharacter.Instance.playerInventory.playerContainer.items[c]="";
						}
						foreach (Transform child in GameWorldController.instance.InventoryMarker.transform) {
							GameObject.Destroy(child.gameObject);
						}

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
										objLoader.objInfo[x].guid=System.Guid.NewGuid();
										objLoader.objInfo[x].parentList=objLoader;
										objLoader.objInfo[x].tileX=TileMap.ObjectStorageTile;
										objLoader.objInfo[x].tileY=TileMap.ObjectStorageTile;
										objLoader.objInfo[x].InUseFlag=1;
										objLoader.objInfo[x].item_id = (int)(DataLoader.getValAtAddress(buffer,i+0,16)) & 0x1FF;
										objLoader.objInfo[x].flags  = (short)(((DataLoader.getValAtAddress(buffer,i+0,16))>> 9) & 0x07);
										objLoader.objInfo[x].enchantment = (short)(((DataLoader.getValAtAddress(buffer,i+0,16)) >> 12) & 0x01);
										objLoader.objInfo[x].doordir  = (short)(((DataLoader.getValAtAddress(buffer,i+0,16)) >> 13) & 0x01);
										objLoader.objInfo[x].invis  = (short)(((DataLoader.getValAtAddress(buffer,i+0,16)) >> 14 )& 0x01);
										objLoader.objInfo[x].is_quant = (short)(((DataLoader.getValAtAddress(buffer,i+0,16)) >> 15) & 0x01);
										//position at +2
										objLoader.objInfo[x].zpos = (short)((DataLoader.getValAtAddress(buffer,i+2,16)) & 0x7F);	//bits 0-6 
										//objList[x].heading =  45 * (int)(((DataLoader.getValAtAddress(buffer,i+2,16)) >> 7) & 0x07); //bits 7-9
										objLoader.objInfo[x].heading = (short)(((DataLoader.getValAtAddress(buffer,i+2,16)) >> 7) & 0x07); //bits 7-9

										objLoader.objInfo[x].y = (short)(((DataLoader.getValAtAddress(buffer,i+2,16)) >> 10) & 0x07);	//bits 10-12
										objLoader.objInfo[x].x = (short)(((DataLoader.getValAtAddress(buffer,i+2,16)) >> 13) & 0x07);	//bits 13-15

										//+4
										objLoader.objInfo[x].quality =(short)((DataLoader.getValAtAddress(buffer,i+4,16)) & 0x3F);
										objLoader.objInfo[x].next = (int)((DataLoader.getValAtAddress(buffer,i+4,16)>>6) & 0x3FF);

										//+6

										objLoader.objInfo[x].owner = (short)(DataLoader.getValAtAddress(buffer,i+6,16) & 0x3F) ;//bits 0-5

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
												UWCharacter.Instance.playerInventory.sHelm=item_name;break;
										case 250://Chest
												UWCharacter.Instance.playerInventory.sChest=item_name;break;
										case 252: //gloves
												UWCharacter.Instance.playerInventory.sGloves=item_name;break;
										case 254://Leggings
												UWCharacter.Instance.playerInventory.sLegs=item_name;break;
										case 256://boots
												UWCharacter.Instance.playerInventory.sBoots=item_name;break;
										case 258://  is the top right shoulder.
												UWCharacter.Instance.playerInventory.sRightShoulder=item_name;break;
										case 260:// is the top left shoulder.
												UWCharacter.Instance.playerInventory.sLeftShoulder=item_name;break;
										case 262://  is the right hand.
												UWCharacter.Instance.playerInventory.sRightHand=item_name;break;
										case 264://  is the left hand.
												UWCharacter.Instance.playerInventory.sLeftHand=item_name;break;
										case 266://  is the right ring.
												UWCharacter.Instance.playerInventory.sRightRing=item_name;break;
										case 268://  is the left ring .
												UWCharacter.Instance.playerInventory.sLeftRing=item_name;break;
										case 270://  is the backpack slots 1.
												UWCharacter.Instance.playerInventory.playerContainer.items[0]=item_name;break;
										case 272://  is the backpack slots 2.
												UWCharacter.Instance.playerInventory.playerContainer.items[1]=item_name;break;
										case 274://  is the backpack slots 3.
												UWCharacter.Instance.playerInventory.playerContainer.items[2]=item_name;break;
										case 276://  is the backpack slots 4.
												UWCharacter.Instance.playerInventory.playerContainer.items[3]=item_name;break;
										case 278://  is the backpack slots 5.
												UWCharacter.Instance.playerInventory.playerContainer.items[4]=item_name;break;
										case 280://  is the backpack slots 6.
												UWCharacter.Instance.playerInventory.playerContainer.items[5]=item_name;break;
										case 282://  is the backpack slots 7.
												UWCharacter.Instance.playerInventory.playerContainer.items[6]=item_name;break;
										case 284://  is the backpack slots 8.
												UWCharacter.Instance.playerInventory.playerContainer.items[7]=item_name;break;
										}
								}
								UWCharacter.Instance.playerInventory.Refresh();

							//Reapply effects from enchanted items by recalling the equip event.
							for (short s=0; s<=10; s++)
							{
								GameObject obj = UWCharacter.Instance.playerInventory.GetGameObjectAtSlot(s);
								if (obj!=null)
								{
									obj.GetComponent<ObjectInteraction>().Equip(s);
								}
							}

						}

						//Change the XOR Key back to D9
						//XorKey= 0xD9; 

						if (UWCharacter.Instance.decode)
						{
								//write out decrypted file for analysis
								byte[] dataToWrite = new byte[buffer.GetUpperBound(0)+1];
								for (long i=0; i<=buffer.GetUpperBound(0);i++)
								{
										dataToWrite[i] = (byte)buffer[i];
								}
								File.WriteAllBytes(Loader.BasePath + "save" + slotNo + "\\decod_" + slotNo + ".dat", dataToWrite);
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
						UWCharacter.Instance.PlayerMagic.ActiveRunes[slotNo]=rune;		
				}
				else
				{
						UWCharacter.Instance.PlayerMagic.ActiveRunes[slotNo]=-1;
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
				DataLoader.WriteInt8(writer,UWCharacter.Instance.XorKey);
				//I'm lazy. I'm going to write a temp file and then re-encode using the key.
				for (int i=1; i<312;i++)
				{//non inventory data 

						if (i<14)
						{
								if (i-1 < UWCharacter.Instance.CharName.Length)	
								{
										char alpha = UWCharacter.Instance.CharName.ToCharArray()[i-1];
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
										DataLoader.WriteInt8(writer,UWCharacter.Instance.PlayerSkills.STR);break;
								case 0x20 ://Dex
										DataLoader.WriteInt8(writer,UWCharacter.Instance.PlayerSkills.DEX);break;
								case 0x21 : ///    Intelligence
										DataLoader.WriteInt8(writer,UWCharacter.Instance.PlayerSkills.INT);break;
								case 0x22 : ///    Attack
										DataLoader.WriteInt8(writer,UWCharacter.Instance.PlayerSkills.Attack);break;
								case 0x23 : ///    Defense
										DataLoader.WriteInt8(writer,UWCharacter.Instance.PlayerSkills.Defense);break;
								case 0x24 : ///    Unarmed
										DataLoader.WriteInt8(writer,UWCharacter.Instance.PlayerSkills.Unarmed);break;
								case 0x25  : ///    Sword
										DataLoader.WriteInt8(writer,UWCharacter.Instance.PlayerSkills.Sword);break;
								case 0x26  : ///    Axe
										DataLoader.WriteInt8(writer,UWCharacter.Instance.PlayerSkills.Axe);break;
								case 0x27 : ///    Mace
										DataLoader.WriteInt8(writer,UWCharacter.Instance.PlayerSkills.Mace);break;
								case 0x28   : ///    Missile
										DataLoader.WriteInt8(writer,UWCharacter.Instance.PlayerSkills.Missile);break;
								case 0x29  : ///    Mana
										DataLoader.WriteInt8(writer,UWCharacter.Instance.PlayerSkills.ManaSkill);break;
								case 0x2A : ///    Lore
										DataLoader.WriteInt8(writer,UWCharacter.Instance.PlayerSkills.Lore);break;
								case 0x2B  : ///    Casting
										DataLoader.WriteInt8(writer,UWCharacter.Instance.PlayerSkills.Casting);break;
								case 0x2C  : ///    Traps
										DataLoader.WriteInt8(writer,UWCharacter.Instance.PlayerSkills.Traps);break;
								case 0x2D  : ///    Search
										DataLoader.WriteInt8(writer,UWCharacter.Instance.PlayerSkills.Search);break;
								case 0x2E : ///    Track
										DataLoader.WriteInt8(writer,UWCharacter.Instance.PlayerSkills.Track);break;
								case 0x2F  : ///    Sneak
										DataLoader.WriteInt8(writer,UWCharacter.Instance.PlayerSkills.Sneak);break;
								case 0x30  : ///    Repair
										DataLoader.WriteInt8(writer,UWCharacter.Instance.PlayerSkills.Repair);break;
								case 0x31 : ///    Charm
										DataLoader.WriteInt8(writer,UWCharacter.Instance.PlayerSkills.Charm);break;
								case 0x32 : ///    Picklock
										DataLoader.WriteInt8(writer,UWCharacter.Instance.PlayerSkills.PickLock);break;
								case 0x33  : ///    Acrobat
										DataLoader.WriteInt8(writer,UWCharacter.Instance.PlayerSkills.Acrobat);break;
								case 0x34  : ///    Appraise
										DataLoader.WriteInt8(writer,UWCharacter.Instance.PlayerSkills.Appraise);break;
								case 0x35  : ///    Swimming
										DataLoader.WriteInt8(writer,UWCharacter.Instance.PlayerSkills.Swimming);break;
								case 0x36://Curvit
										DataLoader.WriteInt8(writer,UWCharacter.Instance.CurVIT);break;
								case 0x37 : ///    max. vitality
										DataLoader.WriteInt8(writer,UWCharacter.Instance.MaxVIT);break;
								case 0x38 : ///    current mana, (play_mana)
										DataLoader.WriteInt8(writer,UWCharacter.Instance.PlayerMagic.CurMana);break;
								case 0x39  : ///    max. mana
										DataLoader.WriteInt8(writer,UWCharacter.Instance.PlayerMagic.MaxMana);break;
								case 0x3A : ///    hunger, play_hunger
										DataLoader.WriteInt8(writer,UWCharacter.Instance.FoodLevel);break;

								case 0x3B://Unknown s
								case 0x3C:		
										DataLoader.WriteInt8(writer,64);break;
								case 0x3E : ///    character level (play_level)
										DataLoader.WriteInt8(writer,UWCharacter.Instance.CharLevel);break;
								case 0x3F:
								//Active spell effect
									{
										for (int e = 0; e<3;e++)
										{
											if (UWCharacter.Instance.ActiveSpell[e]!=null)
											{
												int effectId= 0;
												int byteToWrite=0;

												switch (UWCharacter.Instance.ActiveSpell[e].EffectID)
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
														effectId=UWCharacter.Instance.ActiveSpell[e].EffectID;
														break;	
												}
												int stability =  UWCharacter.Instance.ActiveSpell[e].counter;
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
														if (UWCharacter.Instance.PlayerMagic.PlayerRunes[7-r+runeOffset]==true)
														{
																RuneByte |= (1<<r); 
														}
												}
												DataLoader.WriteInt8(writer, RuneByte);
												runeOffset+=8;
												break;
										}
								case 0x48:
										if (UWCharacter.Instance.PlayerMagic.ActiveRunes[0]==-1)
										{
												DataLoader.WriteInt8(writer,24);	
										}
										else
										{
												DataLoader.WriteInt8(writer,UWCharacter.Instance.PlayerMagic.ActiveRunes[0]);	
										}
										break;
								case 0x49:
										if (UWCharacter.Instance.PlayerMagic.ActiveRunes[1]==-1)
										{
												DataLoader.WriteInt8(writer,24);	
										}
										else
										{
												DataLoader.WriteInt8(writer,UWCharacter.Instance.PlayerMagic.ActiveRunes[1]);	
										}
										break;
								case 0x4A:
										if (UWCharacter.Instance.PlayerMagic.ActiveRunes[2]==-1)
										{
												DataLoader.WriteInt8(writer,24);	
										}
										else
										{
												DataLoader.WriteInt8(writer,UWCharacter.Instance.PlayerMagic.ActiveRunes[2]);	
										}
										break;
								case 0x4B:
										{//No of inventory items?
												DataLoader.WriteInt8(writer,(inventoryObjects.GetUpperBound(0)+1)<<2);
												break;
										}

								case 0x4D : ///   weight in 0.1 stones
										//Or STR * 2; 
										DataLoader.WriteInt16(writer,UWCharacter.Instance.PlayerSkills.STR*2*10);
										break;
								case 0x4D+1://2nd Byte of weight. Ignore
										break;
								case 0x4F  : ///   experience in 0.1 points
										DataLoader.WriteInt32(writer,UWCharacter.Instance.EXP);break;
								case 0x4F+1:
								case 0x4F+2:
								case 0x4F+3:
										break;
								case 0x53: // skillpoints available to spend
										DataLoader.WriteInt8(writer,UWCharacter.Instance.TrainingPoints);break;
								case 0x55 : ///   x-position in level
										int x_position=(int)(UWCharacter.Instance.transform.position.x*Ratio);
										DataLoader.WriteInt16(writer,x_position);
										break;
								case 0x57  : ///   y-position
										int y_position=(int)(UWCharacter.Instance.transform.position.z*Ratio);
										DataLoader.WriteInt16(writer,y_position);
										break;
								case 0x59 : ///   z-position
										int z_position=(int)((UWCharacter.Instance.transform.position.y - VertAdjust)  * (Ratio));
										DataLoader.WriteInt16(writer,z_position);
										break;
								case 0x55+1 : ///   x-position in level
								case 0x57+1  : ///   y-position
								case 0x59+1 : ///   z-position
										//Skip over int 16
										break;
								case 0x5C : ///   heading
										{
												float heading=UWCharacter.Instance.transform.eulerAngles.y * (255f/360f);
												DataLoader.WriteInt8(writer,(int)heading);break;
												//break;
										}
								case 0x5D  : ///   dungeon level										
										DataLoader.WriteInt8(writer,GameWorldController.instance.LevelNo+1);break;
								case 0x5F:///High nibble is dungeon level+1 with the silver tree if planted
										{
											int val = (UWCharacter.Instance.ResurrectLevel & 0xf)<<4 | (UWCharacter.Instance.MoonGateLevel & 0xf)	;
											DataLoader.WriteInt8(writer,val);
											break;
										}
								case 0x60  : ///    bits 2..5: play_poison.  no of active spell effects
										DataLoader.WriteInt8(writer, ( ((NoOfActiveEffects & 0x3) <<6)) | (UWCharacter.Instance.play_poison<<2) | (Quest.instance.IncenseDream & 0x3)   );

										break;
								case 0x61:
										{
											int val =0;
											if (Quest.instance.isOrbDestroyed)
											{
												val=32;//bit 5
											}
											if (Quest.instance.isCupFound)
											{
												val = val | 64;		// bit 6 is the cup found.
											}

											DataLoader.WriteInt8(writer,val);	
											break;
										}
								case 0x63: //Is garamon buried
										{
											if (Quest.instance.isGaramonBuried)
											{
												DataLoader.WriteInt8(writer, 28);	
											}
											else
											{//Default value Unknown meaning.
												DataLoader.WriteInt8(writer, 16);	
											}
											break;
										}
								case 0x65: // hand, Gender & body, and class
										{
												//bit 1 = hand left/right
												//bit 2-5 = gender & body
												//bit 6-8 = class
												int val=0;
												if (!UWCharacter.Instance.isLefty)
												{
														val |=1;
												}
												if (UWCharacter.Instance.isFemale)
												{
														val |= ((UWCharacter.Instance.Body*2) + 1) <<1;
												}
												else
												{
														val |= ((UWCharacter.Instance.Body*2) ) <<1;	
												}
												val |=UWCharacter.Instance.CharClass<<5;
												DataLoader.WriteInt8(writer,val);break;
												//break;
										}
								case 0x66://Quest flags
										{
												int val = 0;
												for (int b=0;b<32;b++)
												{
														val |= (Quest.instance.QuestVariables[b] & 0x1) << b;
												}
												DataLoader.WriteInt32(writer,val);
												break;
										}

								case 0x66+1://Quest flags ignore
								case 0x66+2://Quest flags ignore
								case 0x66+3://Quest flags ignore
										break;

								case 0x6A:
										DataLoader.WriteInt8(writer,Quest.instance.QuestVariables[32]);break;
								case 0x6B:
										DataLoader.WriteInt8(writer,Quest.instance.QuestVariables[33]);break;
								case 0x6C:
										DataLoader.WriteInt8(writer,Quest.instance.QuestVariables[34]);break;
								case 0x6D:
										DataLoader.WriteInt8(writer,Quest.instance.QuestVariables[35]);break;
								case 0x6E://No of talismans still to destory
										DataLoader.WriteInt8(writer,Quest.instance.TalismansRemaining);break;
								case 0x6F://Garamon dream related?
										DataLoader.WriteInt8(writer,Quest.instance.GaramonDream);break;
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
											DataLoader.WriteInt8(writer,Quest.instance.variables[i-0x71]);
											break;
										}
								case 0xB1://The max mana the player has when their mana is drained by the magic orb.
										{
											DataLoader.WriteInt8(writer,UWCharacter.Instance.PlayerMagic.TrueMaxMana);
											break;
										}
								case 0xBC:
										//Unknown
										DataLoader.WriteInt8(writer,0xFF);
										break;
								case 0xb5://difficulty
										DataLoader.WriteInt8(writer,GameWorldController.instance.difficulty);break;

								case 0xB6: //UW Game options TODO: Implement these
										//high nibble is detail level.
										//bit 0 of low nibble is sound
										//bit 3 of low nibble is music
										{
											int valToWrite = 0x30;//High detail	
											if (ObjectInteraction.PlaySoundEffects)
											{
												valToWrite = valToWrite | 0x1;
											}
											if (MusicController.PlayMusic)
											{
												valToWrite = valToWrite | 0x4;
											}
											DataLoader.WriteInt8(writer,valToWrite);
										}
										break;
								case 0xB7://Unknown. Always 8
										DataLoader.WriteInt8(writer,0x8);
										break;										
								case 0xCF  : ///   game time
										//DataLoader.WriteInt32(writer,UWCharacter.Instance.game_time);break;
										DataLoader.WriteInt8(writer,0);break;//Write zero since I don't track milliseconds
										//break;
								case 0xD0:
										DataLoader.WriteInt8(writer,GameClock.instance.gametimevals[0]);break;
								case 0xD1:
										DataLoader.WriteInt8(writer,GameClock.instance.gametimevals[1]);break;
								case 0xD2:
										DataLoader.WriteInt8(writer,GameClock.instance.gametimevals[2]);break;
								case 0xD3://No of inventory items + 1.
										DataLoader.WriteInt16(writer,inventoryObjects.GetUpperBound(0)+1+1);
										//Debug.Log("No of inventory " + inventoryObjects.GetUpperBound(0));
										break;
								case 0xD4://Skip prev
										break;
								case 0xD5:
										{//7F 20
												DataLoader.WriteInt8(writer,0x7F);break;
												//break;	
										}
								case 0xD6:
										{//The mysterious clip through bridges on a second jump byte.
												DataLoader.WriteInt8(writer,0x20);break;
												//break;
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
										//break;
								case 0xDD://Duplicate curvit
										DataLoader.WriteInt8(writer,UWCharacter.Instance.CurVIT);break;
										//break;

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
								case 0x10A: // leftRing
										WriteInventoryIndex(writer, inventoryObjects,10);break;
								case 0x10B: // leftRing ignore
										break;
								case 0x10C: // rightRing
										WriteInventoryIndex(writer, inventoryObjects,9);break;
								case 0x10D: // rightRing ignore
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


										//break;

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
										((currobj.flags & 0x07) << 9) |
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


				writer.Close();//The file now saved is un-encrypted

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

	static char[] DecodeEncodeUW2PlayerDat (char[] pDat, byte MS)
	{
		int[] MA = new int[80];
		MS += 7;
		for (int i = 0; i < 80; ++i) {
			MS += 6;
			MA [i] = MS;
		}
		for (int i = 0; i < 16; ++i) {
			MS += 7;
			MA [i * 5] = MS;
		}
		for (int i = 0; i < 4; ++i) {
			MS += 0x29;
			MA [i * 12] = MS;
		}
		for (int i = 0; i < 11; ++i) {
			MS += 0x49;
			MA [i * 7] = MS;
		}
		char[] buffer = new char[pDat.GetUpperBound (0) + 1];
		int offset = 1;
		int byteCounter = 0;
		for (int l = 0; l <= 11; l++) {
			buffer [0 + offset] = (char)(pDat [0 + offset] ^ MA [0]);
			byteCounter++;
			for (int i = 1; i < 0x50; ++i) {
				if (byteCounter < 0x37D) {
					buffer [i + offset] = (char)(((pDat [i + offset] & 0xff) ^ ((buffer [i - 1 + offset] & 0xff) + (pDat [i - 1 + offset] & 0xff) + (MA [i] & 0xff))) & 0xff);
					byteCounter++;
				}
			}
			offset += 80;
		}
		//Copy the remainder of the plaintext data
		while (byteCounter <= pDat.GetUpperBound (0)) {
			buffer [byteCounter] = pDat [byteCounter];
			byteCounter++;
		}
		buffer[0]=pDat[0];
		return buffer;
	}

		static void WriteInventoryIndex(BinaryWriter writer, string[] InventoryObjects, short slotIndex)
		{
				string itemAtSlot="";
				if (slotIndex<=10)
				{
						itemAtSlot = UWCharacter.Instance.playerInventory.GetObjectAtSlot(slotIndex);	
				}
				else
				{
						itemAtSlot = UWCharacter.Instance.playerInventory.playerContainer.GetItemAt((short)(slotIndex-11));
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
				UWCharacter.Instance.CharName="";
				char[] pDat;
				int x_position=0;
				int y_position=0;
				int z_position=0;
				int x_clock=1;



				int[] gametimevals=new int[3];
				int[] ActiveEffectIds=new int[3];
				short[] ActiveEffectStability=new short[3];
				int effectCounter=0;
				int QuestCounter=0;
				int VariableCounter=0;
				int arena=0;
				UWCharacter.Instance.playerInventory.currentContainer="_Gronk";
				UWHUD.instance.ContainerOpened.GetComponent<RawImage>().texture=UWCharacter.Instance.playerInventory.Blank;
				UWHUD.instance.ContainerOpened.GetComponent<ContainerOpened>().BackpackBg.SetActive(false);
				UWHUD.instance.ContainerOpened.GetComponent<ContainerOpened>().InvUp.SetActive(false);
				UWHUD.instance.ContainerOpened.GetComponent<ContainerOpened>().InvDown.SetActive(false);


				UWCharacter.Instance.JustTeleported=true;
				UWCharacter.Instance.teleportedTimer=0f;
				if (DataLoader.ReadStreamFile(Loader.BasePath + "save" + slotNo + "\\player.dat", out pDat))
				{
					TileMap.OnWater=false;

						byte MS = (byte)DataLoader.getValAtAddress(pDat,0,8);

						char[] buffer = DecodeEncodeUW2PlayerDat (pDat, MS);
						if (UWCharacter.Instance.decode)
						{
								//write out decrypted file for analysis
								byte[] dataToWrite = new byte[buffer.GetUpperBound(0)+1];
								for (long i=0; i<=buffer.GetUpperBound(0);i++)
								{
										dataToWrite[i] = (byte)buffer[i];
								}
								File.WriteAllBytes(Loader.BasePath + "save" + slotNo + "\\decode_" + slotNo + ".dat", dataToWrite);
						}






						/*for (int c=0; c<=pDat.GetUpperBound(0);c++)
						{
								if (recodetest[c]!=pDat[c])
								{
										Debug.Log("File difference at " + c);
										break;
								}
						}*/

						//File.WriteAllBytes(Loader.BasePath + "save4\\player.dat", (byte)recodetest);
						if (UWCharacter.Instance.recode)
						{
								if (UWCharacter.Instance.recode_cheat)
								{
										for (int r=31; r<=53;r++)
										{
												buffer[r]=(char)30;
										}
								}
								else
								{
										buffer[UWCharacter.Instance.IndexToRecode]=(char)UWCharacter.Instance.ValueToRecode;		
								}

								char[] recodetest = DecodeEncodeUW2PlayerDat(buffer,MS);

								byte[] dataToWrite = new byte[recodetest.GetUpperBound(0)+1];
								for (long i=0; i<=recodetest.GetUpperBound(0);i++)
								{
										dataToWrite[i] = (byte)recodetest[i];
								}
								File.WriteAllBytes(Loader.BasePath + "save" + slotNo +"\\playerrecoded.dat", dataToWrite);
						}



						int runeOffset=0;

						for (int i=1; i<=930;i++)
						{
								if (i<14)
								{
										if (buffer[i].ToString() != "\0")
										{
												UWCharacter.Instance.CharName +=buffer[i];
										}
								}
								else
								{

										switch(i)//UWformats doesn't take the first byte into account when describing offsets! I have incremented plus one
										{
										case 0x1F ://Strength
												UWCharacter.Instance.PlayerSkills.STR=(int)buffer[i];break;
										case 0x20 ://Dex
												UWCharacter.Instance.PlayerSkills.DEX=(int)buffer[i];break;
										case 0x21 : ///    Intelligence
												UWCharacter.Instance.PlayerSkills.INT=(int)buffer[i];break;
										case 0x22 : ///    Attack
												UWCharacter.Instance.PlayerSkills.Attack=(int)buffer[i];break;
										case 0x23 : ///    Defense
												UWCharacter.Instance.PlayerSkills.Defense=(int)buffer[i];break;
										case 0x24 : ///    Unarmed
												UWCharacter.Instance.PlayerSkills.Unarmed=(int)buffer[i];break;
										case 0x25  : ///    Sword
												UWCharacter.Instance.PlayerSkills.Sword=(int)buffer[i];break;
										case 0x26  : ///    Axe
												UWCharacter.Instance.PlayerSkills.Axe=(int)buffer[i];break;
										case 0x27 : ///    Mace
												UWCharacter.Instance.PlayerSkills.Mace=(int)buffer[i];break;
										case 0x28   : ///    Missile
												UWCharacter.Instance.PlayerSkills.Missile=(int)buffer[i];break;
										case 0x29  : ///    Mana
												UWCharacter.Instance.PlayerSkills.ManaSkill=(int)buffer[i];break;
										case 0x2A : ///    Lore
												UWCharacter.Instance.PlayerSkills.Lore=(int)buffer[i];break;
										case 0x2B  : ///    Casting
												UWCharacter.Instance.PlayerSkills.Casting=(int)buffer[i];break;
										case 0x2C  : ///    Traps
												UWCharacter.Instance.PlayerSkills.Traps=(int)buffer[i];break;
										case 0x2D  : ///    Search
												UWCharacter.Instance.PlayerSkills.Search=(int)buffer[i];break;
										case 0x2E : ///    Track
												UWCharacter.Instance.PlayerSkills.Track=(int)buffer[i];break;
										case 0x2F  : ///    Sneak
												UWCharacter.Instance.PlayerSkills.Sneak=(int)buffer[i];break;
										case 0x30  : ///    Repair
												UWCharacter.Instance.PlayerSkills.Repair=(int)buffer[i];break;
										case 0x31 : ///    Charm
												UWCharacter.Instance.PlayerSkills.Charm=(int)buffer[i];break;
										case 0x32 : ///    Picklock
												UWCharacter.Instance.PlayerSkills.PickLock=(int)buffer[i];break;
										case 0x33  : ///    Acrobat
												UWCharacter.Instance.PlayerSkills.Acrobat=(int)buffer[i];break;
										case 0x34  : ///    Appraise
												UWCharacter.Instance.PlayerSkills.Appraise=(int)buffer[i];break;
										case 0x35  : ///    Swimming
												UWCharacter.Instance.PlayerSkills.Swimming=(int)buffer[i];break;
										case 0x36://Curvit
												UWCharacter.Instance.CurVIT=(int)buffer[i];break;
										case 0x37 : ///    max. vitality
												UWCharacter.Instance.MaxVIT=(int)buffer[i];break;
										case 0x38 : ///    current mana, (play_mana)
												UWCharacter.Instance.PlayerMagic.CurMana=(int)buffer[i];break;
										case 0x39  : ///    max. mana
												UWCharacter.Instance.PlayerMagic.MaxMana=(int)buffer[i];break;
										case 0x3A : ///    hunger, play_hunger
												UWCharacter.Instance.FoodLevel=(int)buffer[i];break;		
										case 0x3B:
												//Unknown. Observed values 0 and 64?//Fatigue???
												break;
												//case 0x3C:
												//		testvalue=(int)buffer[i];break;	

										case 0x3E : ///    character level (play_level)
												UWCharacter.Instance.CharLevel=(int)buffer[i];break;
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
														ActiveEffectStability[effectCounter++]=(short)buffer[i];break;		
												}
										case 0x45://Runebits
										case 0x46://Runebits
										case 0x47://Runebits
												for (int r =7; r>=0; r--)
												{
														if (((buffer[i]>>r) & 0x1 )== 1)
														{
																UWCharacter.Instance.PlayerMagic.PlayerRunes[7-r+runeOffset]=true;
														}
														else
														{
																UWCharacter.Instance.PlayerMagic.PlayerRunes[7-r+runeOffset]=false;
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
												UWCharacter.Instance.EXP=(int)DataLoader.getValAtAddress(buffer,i,32);break;
										case 0x53: // skillpoints available to spend
												UWCharacter.Instance.TrainingPoints=(int)buffer[i];break;
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
														UWCharacter.Instance.transform.eulerAngles=new Vector3(0f,heading*(360f/255f),0f);
														//playerCam.transform.localRotation.eulerAngles=Vector3.zero;
														UWCharacter.Instance.playerCam.transform.localRotation=Quaternion.identity;
														break;
												}


										case 0x5D  : ///   dungeon level									
												GameWorldController.instance.startLevel=(short)(DataLoader.getValAtAddress(buffer,i,16) - 1);break;
										case 0x5F:///High nibble is dungeon level+1 with the silver tree if planted
												//Low nibble is moongate level + 1
												UWCharacter.Instance.ResurrectLevel=(short)((buffer[i]>>4) & 0xf);
												UWCharacter.Instance.MoonGateLevel=(short)(buffer[i] & 0xf);
												break;
										case 0x61  : ///    bits 1..4 play_poison and no of active effects (unchecked)
												UWCharacter.Instance.play_poison=(short)((buffer[i]>>1) & 0xF );
												effectCounter = ((int)buffer[i]>>6) & 0x3;
												break;
										case 0x64:
												Quest.instance.FightingInArena=  (((int)buffer[i]>>2) & 0x1) ;
												break;
										case 0x66: // hand, Gender & body, and class
												{
														//bit 0 = hand left/right
														//bit 1-4 = gender & body
														//bit 5-7 = class

														GRLoader chrBdy = new GRLoader(GRLoader.BODIES_GR);
														UWCharacter.Instance.isLefty = (((int)buffer[i] & 0x1) == 0);
														int bodyval= ((int)buffer[i]>>1) & 0xf;
														if (bodyval % 2 == 0)
														{//male 0,2,4,6,8
																UWCharacter.Instance.isFemale=false;
																//Body
																UWCharacter.Instance.Body=bodyval/2;
																UWHUD.instance.playerBody.texture=chrBdy.LoadImageAt(0+(bodyval/2));
														}
														else
														{//female=1,3,5,7,9
																UWCharacter.Instance.isFemale=true;
																UWCharacter.Instance.Body=(bodyval-1)/2;
																UWHUD.instance.playerBody.texture=chrBdy.LoadImageAt(5+((bodyval-1)/2));
														}
														//class
														UWCharacter.Instance.CharClass= buffer[i]>>5;

														break;
												}

										case 0x67:  //Quests 0 to 3
										case 0x6B:  //Quests 4 to 7
										case 0x6F:  //Quests 8 to 11
										case 0x73:  //Quests 12 to 15
										case 0x77:  //Quests 16 to 19
										case 0x7B:  //Quests 20 to 23
										case 0x7F:  //Quests 24 to 27
										case 0x83:  //Quests 28 to 31
										case 0x87:  //Quests 32 to 35
										case 0x8B:  //Quests 36 to 39
										case 0x8F:  //Quests 40 to 43
										case 0x93:  //Quests 44 to 47
										case 0x97:  //Quests 48 to 51
										case 0x9B:  //Quests 52 to 55
										case 0x9F:  //Quests 56 to 59
										case 0xA3:  //Quests 60 to 63
										case 0xA7:  //Quests 64 to 67
										case 0xAB:  //Quests 68 to 71
										case 0xAF:  //Quests 72 to 75
										case 0xB3:  //Quests 76 to 79
										case 0xB7:  //Quests 80 to 83
										case 0xBB:  //Quests 84 to 87
										case 0xBF:  //Quests 88 to 91
										case 0xC3:  //Quests 92 to 95
										case 0xC7:  //Quests 96 to 99
										case 0xCB:  //Quests 100 to 103
										case 0xCF:  //Quests 104 to 107
										case 0xD3:  //Quests 108 to 111
										case 0xD7:  //Quests 112 to 115
										case 0xDB:  //Quests 116 to 119
										case 0xDF:  //Quests 120 to 123
										case 0xE3:  //Quests 124 to 127
												{//The first 4 bits of each of these is the quest flags.
													int val = (int)DataLoader.getValAtAddress(buffer,i,8);
													for (int q=0; q<4;q++)
													{
														Quest.instance.QuestVariables[QuestCounter++] = (val >> q) & 0x1;
													}
													break;
												}
										case 0xE7:  //Quest 128 - Where the lines of power have been cut
										case 0xE8:  //Quest 129
										case 0xE9:  //Quest 130
										case 0xEA:  //Quest 131
										case 0xEB:  //Quest 132
										case 0xEC:  //Quest 133
										case 0xED:  //Quest 134
										case 0xEE:  //Quest 135
										case 0xEF:  //Quest 136
										case 0xF0:  //Quest 137
										case 0xF1:  //Quest 138
												{//TODO:These quests are not tested.
													Quest.instance.QuestVariables[i-103]=(int)DataLoader.getValAtAddress(buffer,i,8);
													break;
												}


										case 0xFA:  //Variable0
										case 0xFC:  //Variable1
										case 0xFE:  //Variable2
										case 0x100:  //Variable3
										case 0x102:  //Variable4
										case 0x104:  //Variable5
										case 0x106:  //Treated gems used/ Variable6
										case 0x108:  //Variable7
										case 0x10A:  //Variable8
										case 0x10C:  //Variable9
										case 0x10E:  //Variable10
										case 0x110:  //Variable11
										case 0x112:  //Variable12
										case 0x114:  //Variable13
										case 0x116:  //Variable14
										case 0x118:  //Variable15
										case 0x11A:  //Variable16
										case 0x11C:  //Variable17
										case 0x11E:  //Variable18
										case 0x120:  //Variable19
										case 0x122:  //Variable20
										case 0x124:  //Variable21
										case 0x126:  //Variable22
										case 0x128:  //Variable23
										case 0x12A:  //Variable24
										case 0x12C:  //Variable25
										case 0x12E:  //Variable26
										case 0x130:  //Variable27
										case 0x132:  //Variable28
										case 0x134:  //Variable29
										case 0x136:  //Variable30
										case 0x138:  //Variable31
										case 0x13A:  //Variable32
										case 0x13C:  //Variable33
										case 0x13E:  //Variable34
										case 0x140:  //Variable35
										case 0x142:  //Variable36
										case 0x144:  //Variable37
										case 0x146:  //Variable38
										case 0x148:  //Variable39
										case 0x14A:  //Variable40
										case 0x14C:  //Variable41
										case 0x14E:  //Variable42
										case 0x150:  //Variable43
										case 0x152:  //Variable44
										case 0x154:  //Variable45
										case 0x156:  //Variable46
										case 0x158:  //Variable47
										case 0x15A:  //Variable48
										case 0x15C:  //Variable49
										case 0x15E:  //Variable50
										case 0x160:  //Variable 51
										case 0x162:  //Variable 52
										case 0x164:  //Variable 53 
										case 0x166:  //54
										case 0x168:  //55
										case 0x16A:  //56
										case 0x16C:  //57
										case 0x16E:  //58
										case 0x170:  //59
										case 0x172:  //60
										case 0x174:  //61
										case 0x176:  //62
										case 0x178:  //63
										case 0x17A:  //64
										case 0x17C:  //65
										case 0x17E:  //66
										case 0x180:  //67
										case 0x182:  //68
										case 0x184:  //69
										case 0x186:  //70
										case 0x188:  //71
										case 0x18A:  //72
										case 0x18C:  //73
										case 0x18E:  //74
										case 0x190:  //75
										case 0x192:  //76
										case 0x194:  //77
										case 0x196:  //78
										case 0x198:  //79
										case 0x19A:  //80
										case 0x19C:  //81
										case 0x19E:  //82
										case 0x1A0:  //83
										case 0x1A2:  //84
										case 0x1A4:  //85
										case 0x1A6:  //86
										case 0x1A8:  //87
										case 0x1AA:  //88
										case 0x1AC:  //89
										case 0x1AE:  //90
										case 0x1B0:  //91
										case 0x1B2:  //92
										case 0x1B4:  //93
										case 0x1B6:  //94
										case 0x1B8:  //95
										case 0x1BA:  //96
										case 0x1BC:  //97
										case 0x1BE:  //98
										case 0x1C0:  //99
										case 0x1C2:  //100
										case 0x1C4:  //Variable 101
										case 0x1C6:  //102
										case 0x1C8:  //103
										case 0x1CA:  //104
										case 0x1CC:  //105
										case 0x1CE:  //106
										case 0x1D0:  //107

										case 0x1D4:  //109
										case 0x1D6:  //110
										case 0x1D8:  //111
										case 0x1DA:  //112
										case 0x1DC:  //Variable 113
										case 0x1DE:  //Variable 114 (duplicate with below!!!)
										case 0x1E0:  //Variable 115
										case 0x1E2:  //116
										case 0x1E4:  //117
										case 0x1E6:  //118
										case 0x1E8:  //119
										case 0x1EA:  //120
										case 0x1EC:  //121
										case 0x1EE:  //122
										case 0x1F0:  //123
										case 0x1F2:  //124
										case 0x1F4:  //125
										case 0x1F6:  //126
										case 0x1F8:  //Variable 127
												{
													Quest.instance.variables[VariableCounter++]= (int)DataLoader.getValAtAddress(buffer,i,8);
													break;
												}
										case 0x1D2:  //Variable 108 //Int 16 used in qbert
												{
													Quest.instance.variables[VariableCounter++]= (int)DataLoader.getValAtAddress(buffer,i,16);
													break;
												}
										case 0x303:
												{//Game objections high nibble is graphic detail
												int val =	(int)DataLoader.getValAtAddress(buffer,i,8);
												ObjectInteraction.PlaySoundEffects= ((val & 0x1) == 1);
												MusicController.PlayMusic=( ( ( val>>2 ) & 0x1 ) == 1 );
												break;
												}

										case 0x361://Item Ids of arena warriors.
										case 0x362:
										case 0x363:
										case 0x364:
										case 0x365:
												{
													Quest.instance.ArenaOpponents[arena++]=(int)DataLoader.getValAtAddress(buffer,i,8);
													break;
												}
										//x_clocks
										case 0x36f://1 Castle events
										case 0x370://2
										case 0x371://3 DjinnCapture
										case 0x372://4
										case 0x373://5
										case 0x374://6
										case 0x375://7
										case 0x376://8
										case 0x377://9
										case 0x378://10
										case 0x379://11
										case 0x37a://12
										case 0x37b://13
										case 0x37c://14
										//case 0x37d://15 -- This could be wrong.
												{//The mysterious x_clocks
													Quest.instance.x_clocks[x_clock++]=(int)DataLoader.getValAtAddress(buffer,i,8);
													break;
												}

									//	case 0x371://DjinnCapture
											//	{
												//	Quest.instance.DjinnCapture=(short)DataLoader.getValAtAddress(buffer,i,8);
												//	break;
												//}
										}
								}

						}


						/*Load inventory*/

						//Read in the inventory
						//Stored in much the same way as an linked object list is.
						//Inventory list
						int NoOfItems = (buffer.GetUpperBound(0)-994)/8;
						ObjectLoader objLoader = new ObjectLoader();
						objLoader.objInfo = new ObjectLoaderInfo[NoOfItems+2];

						int x=1;

						if (buffer.GetUpperBound(0)>=995)
						{
								int i = 995;
								while (i < buffer.GetUpperBound(0))
								{
										objLoader.objInfo[x] = new ObjectLoaderInfo();
										objLoader.objInfo[x].index=x;
										objLoader.objInfo[x].guid=System.Guid.NewGuid();
										objLoader.objInfo[x].parentList=objLoader;
										objLoader.objInfo[x].tileX=TileMap.ObjectStorageTile;
										objLoader.objInfo[x].tileY=TileMap.ObjectStorageTile;
										objLoader.objInfo[x].InUseFlag=1;
										objLoader.objInfo[x].item_id = (int)(DataLoader.getValAtAddress(buffer,i+0,16)) & 0x1FF;
										objLoader.objInfo[x].flags  = (short)(((DataLoader.getValAtAddress(buffer,i+0,16))>> 9) & 0x07);
										objLoader.objInfo[x].enchantment = (short)(((DataLoader.getValAtAddress(buffer,i+0,16)) >> 12) & 0x01);
										objLoader.objInfo[x].doordir  = (short)(((DataLoader.getValAtAddress(buffer,i+0,16)) >> 13) & 0x01);
										objLoader.objInfo[x].invis  = (short)(((DataLoader.getValAtAddress(buffer,i+0,16)) >> 14 )& 0x01);
										objLoader.objInfo[x].is_quant = (short)(((DataLoader.getValAtAddress(buffer,i+0,16)) >> 15) & 0x01);
										//position at +2
										objLoader.objInfo[x].zpos = (short)((DataLoader.getValAtAddress(buffer,i+2,16)) & 0x7F);	//bits 0-6 
										//objList[x].heading =  45 * (int)(((DataLoader.getValAtAddress(buffer,i+2,16)) >> 7) & 0x07); //bits 7-9
										objLoader.objInfo[x].heading = (short)(((DataLoader.getValAtAddress(buffer,i+2,16)) >> 7) & 0x07); //bits 7-9

										objLoader.objInfo[x].y = (short)(((DataLoader.getValAtAddress(buffer,i+2,16)) >> 10) & 0x07);	//bits 10-12
										objLoader.objInfo[x].x = (short)(((DataLoader.getValAtAddress(buffer,i+2,16)) >> 13) & 0x07);	//bits 13-15

										//+4
										objLoader.objInfo[x].quality =(short)((DataLoader.getValAtAddress(buffer,i+4,16)) & 0x3F);
										objLoader.objInfo[x].next = (int)((DataLoader.getValAtAddress(buffer,i+4,16)>>6) & 0x3FF);

										//+6

										objLoader.objInfo[x].owner = (short)(DataLoader.getValAtAddress(buffer,i+6,16) & 0x3F) ;//bits 0-5

										objLoader.objInfo[x].link = (int)(DataLoader.getValAtAddress(buffer, i + 6, 16) >> 6 & 0x3FF); //bits 6-15
										i=i+8;
										x++;

								}
								//Create the inventory objects
								ObjectLoader.RenderObjectList(objLoader,GameWorldController.instance.currentTileMap(),GameWorldController.instance.InventoryMarker);
								//Find any wands and move their spell objects to the gameworld to behave like UW1
								for (int o=0; o<=objLoader.objInfo.GetUpperBound(0);o++)
								{
										if (objLoader.objInfo[o]!=null)
										{
												if ( 
														( GameWorldController.instance.objectMaster.type[ objLoader.objInfo[o].item_id ] == ObjectInteraction.WAND )
														||
														(
																( GameWorldController.instance.objectMaster.type[ objLoader.objInfo[o].item_id ] == ObjectInteraction.CLUTTER)
																&&
																(objLoader.objInfo[o].link!=0)
														)
												)
												{
														if ( objLoader.objInfo[o].enchantment == 0)
														{//Enchantment is in a spell object link
																ObjectLoaderInfo spellObj = objLoader.objInfo[ objLoader.objInfo[o].link ];
																if (spellObj!=null)
																{
																		//Move it's spell object to the game world and destroy the instance of that object that is on the inventory marker
																		//ObjectLoaderInfo newobjt= ObjectLoader.newObject(288, spellObj.quality,spellObj.owner,spellObj.link,256);
																		//ObjectInteraction spell = ObjectInteraction.CreateNewObject(GameWorldController.instance.currentTileMap(),newobjt,  GameWorldController.instance.LevelMarker().gameObject, GameWorldController.instance.LevelMarker().position );
																		Wand wandInfo = objLoader.objInfo[o].instance.GetComponent<Wand>();
																		wandInfo.SpellObjectOwnerToCreate= spellObj.owner;
																		wandInfo.SpellObjectLink= spellObj.link;
																		wandInfo.SpellObjectQualityToCreate= spellObj.quality;
																		GameObject.Destroy(spellObj.instance.gameObject);
																}	
														}
														else
														{//enchantment is on the wand itself.
															//Debug.Log("wand link is out of range")	;
															Wand wandInfo = objLoader.objInfo[o].instance.GetComponent<Wand>();
															wandInfo.SpellObjectOwnerToCreate= -1;
														}
												}		
										}
								}


								for (int j=931; j<969; j=j+2)
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
										case 931://Helm
												UWCharacter.Instance.playerInventory.sHelm=item_name;break;
										case 933://Chest
												UWCharacter.Instance.playerInventory.sChest=item_name;break;
										case 935: //gloves
												UWCharacter.Instance.playerInventory.sGloves=item_name;break;
										case 937://Leggings
												UWCharacter.Instance.playerInventory.sLegs=item_name;break;
										case 939://boots
												UWCharacter.Instance.playerInventory.sBoots=item_name;break;
										case 941://  is the top right shoulder.
												UWCharacter.Instance.playerInventory.sRightShoulder=item_name;break;
										case 943:// is the top left shoulder.
												UWCharacter.Instance.playerInventory.sLeftShoulder=item_name;break;
										case 945://  is the right hand.
												UWCharacter.Instance.playerInventory.sRightHand=item_name;break;
										case 947://  is the left hand.
												UWCharacter.Instance.playerInventory.sLeftHand=item_name;break;
										case 949://  is the right ring.
												UWCharacter.Instance.playerInventory.sRightRing=item_name;break;
										case 951://  is the left ring .
												UWCharacter.Instance.playerInventory.sLeftRing=item_name;break;
										case 953://  is the backpack slots 1.
												UWCharacter.Instance.playerInventory.playerContainer.items[0]=item_name;break;
										case 955://  is the backpack slots 2.
												UWCharacter.Instance.playerInventory.playerContainer.items[1]=item_name;break;
										case 957://  is the backpack slots 3.
												UWCharacter.Instance.playerInventory.playerContainer.items[2]=item_name;break;
										case 959://  is the backpack slots 4.
												UWCharacter.Instance.playerInventory.playerContainer.items[3]=item_name;break;
										case 961://  is the backpack slots 5.
												UWCharacter.Instance.playerInventory.playerContainer.items[4]=item_name;break;
										case 963://  is the backpack slots 6.
												UWCharacter.Instance.playerInventory.playerContainer.items[5]=item_name;break;
										case 965://  is the backpack slots 7.
												UWCharacter.Instance.playerInventory.playerContainer.items[6]=item_name;break;
										case 967://  is the backpack slots 8.
												UWCharacter.Instance.playerInventory.playerContainer.items[7]=item_name;break;
										}
								}
								UWCharacter.Instance.playerInventory.Refresh();

								//Reapply spell effects
								for (int a=0; a<=UWCharacter.Instance.ActiveSpell.GetUpperBound(0);a++)
								{//Clear out the old effects.
										if (UWCharacter.Instance.ActiveSpell[a]!=null)	
										{
												UWCharacter.Instance.ActiveSpell[a].CancelEffect();	
												if (UWCharacter.Instance.ActiveSpell[a]!=null)	
												{//The prevous effect had cancelled into anew effect. Eg fly->slowfall. Cancel again.
														UWCharacter.Instance.ActiveSpell[a].CancelEffect();	
												}
										}
								}

							//Reapply effects from enchanted items by recalling the equip event.
							for (short s=0; s<=10; s++)
							{
								GameObject obj = UWCharacter.Instance.playerInventory.GetGameObjectAtSlot(s);
								if (obj!=null)
								{
									obj.GetComponent<ObjectInteraction>().Equip(s);
								}
							}

						}


						/* end load inventory  */





						for (int a=0; a<effectCounter;a++)
						{//Recast the new ones.
								UWCharacter.Instance.ActiveSpell[a] = UWCharacter.Instance.PlayerMagic.CastEnchantment(UWCharacter.Instance.gameObject,null,ActiveEffectIds[a], Magic.SpellRule_TargetSelf );
								UWCharacter.Instance.ActiveSpell[a].counter=ActiveEffectStability[a];
						}


						//Reapply poisoning.
						if (UWCharacter.Instance.play_poison!=0)
						{
								SpellEffectPoison p = (SpellEffectPoison)UWCharacter.Instance.PlayerMagic.CastEnchantment(UWCharacter.Instance.gameObject,null,SpellEffect.UW1_Spell_Effect_Poison,Magic.SpellRule_TargetSelf);
								p.counter=UWCharacter.Instance.play_poison;
								p.DOT=(short)(p.Value/p.counter);//Recalculate the poison damage to reapply.									
						}
						else
						{//Make sure any poison is cured.
								UWCharacter.Instance.PlayerMagic.CastEnchantment(UWCharacter.Instance.gameObject,null, SpellEffect.UW1_Spell_Effect_CurePoison,Magic.SpellRule_TargetSelf);									
						}

						GameClock.setUWTime( gametimevals[0] + (gametimevals[1] * 255 )  + (gametimevals[2] * 255 * 255 ));

						float Ratio=213f;
						float VertAdjust = 0.3543672f;
						GameWorldController.instance.StartPos=new Vector3((float)x_position/Ratio, (float)z_position/Ratio +VertAdjust ,(float)y_position/Ratio);
						UWCharacter.Instance.TeleportPosition=GameWorldController.instance.StartPos;

						return;
				}
		}



		/// <summary>
		/// Returns a save game name to use when saving.
		/// </summary>
		/// <returns>The game name.</returns>
		public static string SaveGameName(int slotNo)
		{
				return "Level " + GameWorldController.instance.LevelNo + " " + System.DateTime.Now;
		}


}


using UnityEngine;
using System.Collections;
using System.Text;
using System.IO;


//SCD.ark in uw2 does things. I don't know what they are yet. 

public class WhatTheHellIsSCD_ARK : UWEBase {
		public bool TableView=true;
		public int InfoSize=16;
		public bool DoTheThingThisCodeDoes=false;

		public void DumpScdArkInfo(string SCD_Ark_File_Path)
		{
				if (!DoTheThingThisCodeDoes)
				{
						return;
				}

				int LevelNo=0;
				string output="";
				StreamWriter writer;// = new StreamWriter( Application.dataPath + "//..//_scd_ark.txt", false);
				if (TableView)
				{
						writer = new StreamWriter( Application.dataPath + "//..//_scd_ark.csv", false);	
						output=output + "Address,Block,Level,1,Type,TypeDesc,Variable/TileX,IsQuest/TileY,5,6,7,8,9,10,11,12,13,14,15\n";
				}
				else
				{
						writer = new StreamWriter( Application.dataPath + "//..//_scd_ark.txt", false);			
				}



				char[] scd_ark;	
				char[] scd_ark_file_data;
				if (!DataLoader.ReadStreamFile(Loader.BasePath +  SCD_Ark_File_Path, out scd_ark_file_data))
				{
						Debug.Log(Loader.BasePath + SCD_Ark_File_Path + " File not loaded");
						return;
				}	

				int NoOfBlocks=(int)DataLoader.getValAtAddress(scd_ark_file_data,0,32);
				for (LevelNo=0; LevelNo<NoOfBlocks; LevelNo++)
				{

						long address_pointer=6;
						int compressionFlag=(int)DataLoader.getValAtAddress(scd_ark_file_data,address_pointer + (NoOfBlocks*4) + (LevelNo*4) ,32);
						long datalen =DataLoader.getValAtAddress(scd_ark_file_data,address_pointer + (NoOfBlocks*4*2) + (LevelNo*4) ,32);
						int isCompressed =(compressionFlag>>1) & 0x01;
						long AddressOfBlockStart;
						address_pointer=(LevelNo * 4) + 6;
						//Debug.Log("Block " + LevelNo + " Datalen is " + datalen + " at address " + ( (int)DataLoader.getValAtAddress(scd_ark_file_data,address_pointer,32) ));
						if ((int)DataLoader.getValAtAddress(scd_ark_file_data,address_pointer,32)==0)
						{
								Debug.Log("No Scd.ark data for this level");
						}

						if (isCompressed == 1)
						{//should not happen in scd.ark
								datalen=0;
								scd_ark = DataLoader.unpackUW2(scd_ark_file_data,DataLoader.getValAtAddress(scd_ark_file_data,address_pointer,32), ref datalen);
								address_pointer=address_pointer+4;
								AddressOfBlockStart=0;
								address_pointer=0;
						}
						else
						{
								long BlockStart = DataLoader.getValAtAddress(scd_ark_file_data, address_pointer, 32);
								int j=0;
								AddressOfBlockStart=BlockStart;
								address_pointer=0;//Since I am at the start of a fresh array.
								scd_ark = new char[datalen];
								for (long i = BlockStart; i < BlockStart + datalen; i++)
								{
										scd_ark[j] = scd_ark_file_data[i];
										j++;
								}
						}
						int add_ptr=0;

						if (TableView)
						{

								int noOfRows = (int)DataLoader.getValAtAddress(scd_ark,0,8);	
								if (noOfRows!=0)
								{
										//skip header
										//for (int i=1;i<324;i++)
										//{
										//		add_ptr++;	
										//}
										add_ptr=326;
										int r=0;

										for (int i=326; i<datalen; i++)
										{			
												if (r==0)
												{
														output = output + AddressOfBlockStart+add_ptr + "," + LevelNo +",";	
												}
												switch(r)
												{													
												case 2://type
														{
																output = output + (int)DataLoader.getValAtAddress(scd_ark,add_ptr,8) +"," ;
																switch ((int)DataLoader.getValAtAddress(scd_ark,add_ptr,8))
																{//TODO:Add all the identified types in event_action.cs
																case event_base.RowTypeSetNPCGoal:
																		output = output + "SetGoal";
																		break;
																case event_base.RowTypeCondition:
																		output = output + "Condition";
																		break;
																case event_base.RowTypeKillNPC:
																		output =output+"KillNPC";
																		break;
																case event_base.RowTypeFireTriggers:
																		output = output + "FireTrigger";
																		break;
																case event_base.RowTypeScheduled:
																		output = output + "ScheduledEvent";
																		break;
																case event_base.RowTypeRaceAttidude:
																		output = output + "RaceAttitude";
																		break;
																case event_base.RowTypeSetProps:
																		output = output + "SetProps";
																		break;
																case event_base.RowTypeRemoveNPC:
																		output = output + "RemoveNPC";
																		break;
																case event_base.RowTypeKillNPCorRace:
																		output=output + "KillNPCorRace";
																		break;
																case event_base.RowTypePlaceNPC:
																		output = output + "PlaceNPC";
																		break;
																case event_base.RowTypeSetNPCGOAL_Alt:
																		output = output + "SetGoal Alt";
																		break;
																default:
																		output = output + "UNK";
																		break;
																}

																add_ptr++;
																break;
														}

												default:
														output = output + (int)DataLoader.getValAtAddress(scd_ark,add_ptr++,8);// + ",";
														break;
												}


												r++;
												if (r==16)
												{
														r=0;
														output = output +"\n"; 		
												}
												else
												{
														output=output + ",";	
												}

										}
										output = output +"\n";
								}

						}
						else
						{
								output = output + "Block no " + LevelNo + " at address " + AddressOfBlockStart + "\n";
								output = output+ "No of rows " + (int)DataLoader.getValAtAddress(scd_ark,add_ptr++,8) + "\n";
								int noOfRows = (int)DataLoader.getValAtAddress(scd_ark,0,8);
								if (noOfRows!=0)
								{
										output = output + "Unknown info 1-325\n";
										for (int i=1;i<324;i++)
										{
												output = output + (int)DataLoader.getValAtAddress(scd_ark,add_ptr++,8) + "\n";		
										}


										output = output +"Row Data\nr\n";
										add_ptr=326;
										int r=0;

										for (int i=326; i<datalen; i++)
										{				

												output = output + (int)DataLoader.getValAtAddress(scd_ark,add_ptr++,8) + "\n";
												r++;
												if (r==16)
												{
														r=0;
														output = output +"r\n"; 		
												}

										}
								}		
						}


				}
				writer.WriteLine(output);
				writer.Close();

		}
}

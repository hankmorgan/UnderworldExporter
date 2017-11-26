using UnityEngine;
using System.Collections;

/// <summary>
/// Event base.
/// </summary>
/// Based Class for loading the SCD ark events
public class event_base : UWClass {

		public const int RowTypeSetNPCGoal= 1;
		public const int RowTypeMoveNPC= 2;
		public const int RowTypeKillNPC= 3;//Only used to kill tory.
		public const int RowTypeFireTriggers= 5;//Fires triggers in specified tiles. Similar to scheduled trigger but ignores type (untested)?
		public const int RowTypeCondition= 10;	
		public const int RowTypeRemoveNPC=245; //Remove an NPC from the game world
		public const int RowTypeRaceAttidude=248;//Change the races attitude/other properties towards you.
		public const int RowTypeSetProps=249;//Change the various properties of an NPC based on the WHOAMI in offset 6
		public const int RowTypeScheduled=251;
		public const int RowTypeKillNPCorRace=253;//Kill an npc or race with the specified race???
		public const int RowTypePlaceNPC=254;//??
		public const int RowTypeSetNPCGOAL_Alt=255;
		/// <summary>
		/// The raw data from scd.ark
		/// </summary>
		public char[] RawData= new char[16];

		/// <summary>
		/// The block within which this event is contained.
		/// </summary>
		public int BlockNo;

		/// <summary>
		/// The type of event row this is.
		/// </summary>
		public int type;

		/// <summary>
		/// The levelNo of the event to be triggered
		/// </summary>
		public int LevelNo=0;  //the level no can also refer to a world eg 247 means any part of the prison tower.

		/// <summary>
		/// The x clock that is required for this event to occur (can happen in conditions or events)
		/// </summary>
		/// 0=not required
		/// Uses block no to refer to clock index.
		public int x_clock=0;


		public bool clear=false;

		/// <summary>
		/// Controls if we are executing a block of commands following a conditional.
		/// </summary>
		public static bool Executing=false;

		public virtual void Process()
		{
				if (Executing)
				{
						if (CheckCondition())
						{
								ExecuteEvent();
								PostEvent();
						}						
				}
		}

		/// <summary>
		/// Handling of the event post activation.
		/// </summary>
		/// Usually this is destroying the row
		public virtual void PostEvent()
		{
				if (LevelNo<=80)
				{
						clear=true;				
				}			
		}

		/// <summary>
		/// Inits the raw data from the scd.ark file
		/// </summary>
		/// <param name="add_ptr">Add ptr.</param>
		/// <param name="fileData">File data.</param>
		public void InitRawData(int blockNo, int add_ptr, char[]fileData)
		{
				BlockNo=blockNo;
				for (int i=0; i<=RawData.GetUpperBound(0);i++)
				{
						RawData[i]=fileData[add_ptr+i];
				}
				LevelNo= RawData[0]-1;//Adjust to match UWE level nos
				type=RawData[2];
				x_clock=RawData[14];
		}


		/// <summary>
		/// Checks the conditions necessary to fire this event or check this conditional.
		/// </summary>
		/// <returns><c>true</c>, if condition was checked, <c>false</c> otherwise.</returns>
		public virtual bool CheckCondition()
		{
			return LevelTest() && xclocktest();
		}

		/// <summary>
		/// Executes the events defined by this row.
		/// </summary>
		public virtual void ExecuteEvent()
		{
				Debug.Log("Event type :" + type );
		}

		/// <summary>
		/// Determines whether the current level is the level number specified by the condition
		/// </summary>
		/// <returns><c>true</c> if this instance is level the specified levelNoToTest; otherwise, <c>false</c>.</returns>
		/// <param name="levelNoToTest">Level no to test.</param>
		public bool IsLevel(int levelNoToTest)
		{
				if (levelNoToTest==LevelNo)
				{
						return true;
				}
				else
				{
					switch (LevelNo)
					{
					case 246://Prison tower area code -1
							return ((levelNoToTest>=(int)GameWorldController.UW2_LevelNames.Prison0) 
									&&
									(levelNoToTest<=(int)GameWorldController.UW2_LevelNames.Prison7));
					
					case 240://Talorus area code -1
							return ((levelNoToTest>=(int)GameWorldController.UW2_LevelNames.Talorus0) 
									&&
									(levelNoToTest<=(int)GameWorldController.UW2_LevelNames.Talorus1));
							
					case 254://Pits area code -1
							return ((levelNoToTest>=(int)GameWorldController.UW2_LevelNames.Pits0) 
									&&
									(levelNoToTest<=(int)GameWorldController.UW2_LevelNames.Pits2));

					default:
							return false;
					}

				}
		}

		/// <summary>
		/// Tests if the xclock is correct to fire this event.
		/// </summary>
		public bool xclocktest()
		{
			if (x_clock==0)
			{
				return true;
			}
			else
			{
				return (Quest.instance.x_clocks[BlockNo]==x_clock);		
			}
		}


		public bool LevelTest()
		{
				return IsLevel(GameWorldController.instance.LevelNo);
		}

		/// <summary>
		/// Finds every NPC with the specified whoami.
		/// </summary>
		/// <returns>The NP.</returns>
		/// <param name="WhoAmI">Who am i.</param>
		public NPC[] findNPC(int WhoAmI)
		{
				int NoOfNpcs=0;
				ObjectLoaderInfo[] objList=GameWorldController.instance.CurrentObjectList().objInfo;
				for (int o=0; o<=256;o++)
				{
						if (objList[o].instance!=null)
						{
								if (objList[o].instance.GetComponent<NPC>())
								{
										if (objList[o].instance.GetComponent<NPC>().npc_whoami == WhoAmI)
										{
												objList[o].instance.GetComponent<NPC>().objInt().UpdatePosition();//Only bring back on-map npcs
												if (objList[o].instance.tileX!=TileMap.ObjectStorageTile)
												{
														NoOfNpcs++;		
												}
										}		
								}
						}
				}
				if (NoOfNpcs!=0)
				{
						NPC[] result = new NPC[NoOfNpcs];
						int i=0;
						for (int o=0; o<=256;o++)
						{
								if (objList[o].instance!=null)
								{
										if (objList[o].instance.GetComponent<NPC>())
										{
												if (objList[o].instance.GetComponent<NPC>().npc_whoami == WhoAmI)
												{
														if (objList[o].instance.tileX!=TileMap.ObjectStorageTile)
														{
														result[i++] = objList[o].instance.GetComponent<NPC>();
														}
												}		
										}
								}
						}
						return result;
				}
				else
				{
					return null;
				}

		}


		/// <summary>
		/// Gets all the npcs of the specified race.
		/// </summary>
		/// <returns>The race.</returns>
		/// <param name="race">Race.</param>
		public NPC[] findRace(int Race)
		{
				int NoOfNpcs=0;
				ObjectLoaderInfo[] objList=GameWorldController.instance.CurrentObjectList().objInfo;
				for (int o=0; o<=256;o++)
				{
						if (objList[o].instance!=null)
						{
								if (objList[o].instance.GetComponent<NPC>())
								{
										if (objList[o].instance.GetComponent<NPC>().GetRace() == Race)
										{
												objList[o].instance.GetComponent<NPC>().objInt().UpdatePosition();//Only bring back on-map npcs
												if (objList[o].instance.tileX!=TileMap.ObjectStorageTile)
												{
														NoOfNpcs++;		
												}		
										}		
								}
						}
				}
				if (NoOfNpcs!=0)
				{
					NPC[] result = new NPC[NoOfNpcs];
					int i=0;
					for (int o=0; o<=256;o++)
					{
							if (objList[o].instance!=null)
							{
									if (objList[o].instance.GetComponent<NPC>())
									{
											if (objList[o].instance.GetComponent<NPC>().GetRace() == Race)
											{
													//objList[o].instance.GetComponent<NPC>().objInt().UpdatePosition();//Only bring back on-map npcs
													if (objList[o].instance.tileX!=TileMap.ObjectStorageTile)
													{
																result[i++]	= objList[o].instance.GetComponent<NPC>();
													}		
											}		
									}
							}
					}
					return result;
				}
				return null;
		}
}
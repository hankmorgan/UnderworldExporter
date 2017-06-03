using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;

/// <summary>
/// Implementation of the conversation virtual machine
/// based on UWAdventures hacking tools.
/// </summary>
public class ConversationVM : UWEBase {


		///The NPC is talking
		public const int NPC_SAY=0;
		///The PC is talking
		public const int PC_SAY=1;
		///Printed text is displayed
		public const int PRINT_SAY=2;

		//The op codes for the vm.
		const int cnv_NOP=0;
		const int cnv_OPADD=1;
		const int cnv_OPMUL=2;
		const int cnv_OPSUB=3;
		const int cnv_OPDIV=4;
		const int cnv_OPMOD=5;
		const int cnv_OPOR=6;
		const int cnv_OPAND=7;
		const int cnv_OPNOT=8;
		const int cnv_TSTGT=9;
		const int cnv_TSTGE=10;
		const int cnv_TSTLT=11;
		const int cnv_TSTLE=12;
		const int cnv_TSTEQ=13;
		const int cnv_TSTNE=14;
		const int cnv_JMP=15;
		const int cnv_BEQ=16;
		const int cnv_BNE=17;
		const int cnv_BRA=18;
		const int cnv_CALL=19;
		const int cnv_CALLI=20;
		const int cnv_RET=21;
		const int cnv_PUSHI=22;
		const int cnv_PUSHI_EFF=23;
		const int cnv_POP=24;
		const int cnv_SWAP=25;
		const int cnv_PUSHBP=26;
		const int cnv_POPBP=27;
		const int cnv_SPTOBP=28;
		const int cnv_BPTOSP=29;
		const int cnv_ADDSP=30;
		const int cnv_FETCHM=31;
		const int cnv_STO=32;
		const int cnv_OFFSET=33;
		const int cnv_START=34;
		const int cnv_SAVE_REG=35;
		const int cnv_PUSH_REG=36;
		const int cnv_STRCMP=37;
		const int cnv_EXIT_OP=38;
		const int cnv_SAY_OP=39;
		const int cnv_RESPOND_OP=40;
		const int cnv_OPNEG=41;


		const int import_function =0x111;
		const int import_variable =0x10f;

		const int return_void = 0;
		const int return_int = 0x129;
		const int return_string = 0x12b;

		//The input and output controls
		//private static Text Output;
		private static Text PlayerInput;

		private int currConv=0;//The conversation that is being ran.

		public int MaxAnswer;


		/// <summary>
		/// Imported function and memory data from the conv.ark file
		/// </summary>
		struct ImportedFunctions{
				//0000   Int16   length of function name
				//0002   n*char  name of function
				public string functionName;
				//n+02   Int16   ID (imported func.) / memory address (variable)
				public int ID_or_Address;
				//	n+04   Int16   unknown, always seems to be 1
				public int import_type;//n+06   Int16   import type (0x010F=variable, 0x0111=imported func.)
				public int return_type; //n+08   Int16   return type (0x0000=void, 0x0129=int, 0x012B=string)
		};

		/// <summary>
		/// Conversation header defines the size and layout of the converstation.
		/// </summary>
		struct cnvHeader{
				//0000   Int16   unknown, always seems to be 0x0828, or 28 08
				//0002   Int16   unknown, always 0x0000
				public int CodeSize;  //0004   Int16   code size in number of instructions (16-bit words)
				////0006   Int16   unknown, always 0x0000
				//0008   Int16   unknown, always 0x0000
				public int StringBlock;//		000A   Int16   game strings block to use for conversation strings
				public int NoOfMemorySlots;//	000C   Int16   number of memory slots reserved for variables (*)
				public int NoOfImportedGlobals;//000E   Int16   number of imported globals (functions + variables)
				//0010           start of imported functions list	
				public ImportedFunctions[] functions;
				public int[] instuctions;
		};


		cnvHeader[] conv;
		//char[] cnv_ark;

		//public string Path; //to cnv.ark
		//public string StringsPath; //to strings.pak

		//public StringController stringcontrol;

		CnvStack stack;
		public int call_level=1;
		public int instrp=0;
		//public int basep = 0;
		public int result_register;


		public static int PlayerAnswer;
		///Conversation waiting mode. Player has to enter a menu option
		public static bool WaitingForInput;
		///Conversation waiting mode. Player has to press any key to continue
		public static bool WaitingForMore;
		///Conversation waiting mode. Player has to type an answer.
		public static bool WaitingForTyping;
		///The array that maps menu options in a bablf_menu to their answer numbers
		public static int[] bablf_array = new int[10];
		///Tells if we are using a bablf_menu
		public static bool usingBablF;
		/// The answer from the bablf_menu
		public static int bablf_ans=0;


		/// <summary>
		/// Loads the cnv ark file and parses it to initialise the conversation headers and imported functions
		/// </summary>
		/// <param name="cnv_ark_path">Cnv ark path.</param>
	public void LoadCnvArk(string cnv_ark_path)
	{
		char[] cnv_ark;
		if (DataLoader.ReadStreamFile(cnv_ark_path, out cnv_ark))
		{
			int NoOfConversations = (int)DataLoader.getValAtAddress(cnv_ark,0,16);
			conv=new cnvHeader[NoOfConversations];
			for (int i=0; i<NoOfConversations;i++)
			{
				int add_ptr = (int)DataLoader.getValAtAddress(cnv_ark,2+ i*4,32);
				if (add_ptr!=0)
				{
					/*
				   0000   Int16   unknown, always seems to be 0x0828, or 28 08
				   0002   Int16   unknown, always 0x0000
				   0004   Int16   code size in number of instructions (16-bit words)
				   0006   Int16   unknown, always 0x0000
				   0008   Int16   unknown, always 0x0000
				   000A   Int16   game strings block to use for conversation strings
				   000C   Int16   number of memory slots reserved for variables (*)
				   000E   Int16   number of imported globals (functions + variables)
				   0010           start of imported functions list
					*/
					conv[i].CodeSize=(int)DataLoader.getValAtAddress(cnv_ark,add_ptr+0x4,16);
					conv[i].StringBlock=(int)DataLoader.getValAtAddress(cnv_ark,add_ptr+0xA,16);
					conv[i].NoOfMemorySlots=(int)DataLoader.getValAtAddress(cnv_ark,add_ptr+0xC,16);
					conv[i].NoOfImportedGlobals=(int)DataLoader.getValAtAddress(cnv_ark,add_ptr+0xE,16);
					conv[i].functions= new ImportedFunctions[conv[i].NoOfImportedGlobals];
					int funcptr= add_ptr+0x10;
					for (int f=0; f<conv[i].NoOfImportedGlobals; f++)
					{

						/*0000   Int16   length of function name
						0002   n*char  name of function
						n+02   Int16   ID (imported func.) / memory address (variable)
						n+04   Int16   unknown, always seems to be 1
						n+06   Int16   import type (0x010F=variable, 0x0111=imported func.)
						n+08   Int16   return type (0x0000=void, 0x0129=int, 0x012B=string)*/
						int len = (int)DataLoader.getValAtAddress (cnv_ark,funcptr,16);
						for (int j=0 ; j<len;j++ )
						{
								conv[i].functions[f].functionName += (char)DataLoader.getValAtAddress(cnv_ark,funcptr+2+j,8);
						}
						conv[i].functions[f].ID_or_Address= (int)DataLoader.getValAtAddress(cnv_ark,funcptr+len+2,16);
						conv[i].functions[f].import_type= (int)DataLoader.getValAtAddress(cnv_ark,funcptr+len+6,16);
						conv[i].functions[f].return_type= (int)DataLoader.getValAtAddress(cnv_ark,funcptr+len+8,16);
						funcptr+= len+10;
					}
					conv[i].instuctions = new int[conv[i].CodeSize];
					int counter=0;
					for (int c=0; c<conv[i].CodeSize*2; c=c+2)
					{
						conv[i].instuctions[counter++] = (int)DataLoader.getValAtAddress(cnv_ark, funcptr + c, 16);
					}

				}
			}

		}
	}


		/// <summary>
		/// Runs the conversation.
		/// </summary>
		public void RunConversation(NPC npc)
		{
				currConv=npc.npc_whoami;
				UWHUD.instance.RefreshPanels(UWHUD.HUD_MODE_CONV);
				UWHUD.instance.Conversation_tl.Clear();
				UWHUD.instance.MessageScroll.Clear();


				UWHUD.instance.RefreshPanels(UWHUD.HUD_MODE_CONV);

				///Clear the trade slots for the npcs
				for (int i=0; i<4;i++)
				{
						UWHUD.instance.npcTrade[i++].clear ();
				}

				///Identifies the NPC for future looking at
				npc.objInt().isIdentified=true;//TODO:Replace this with vanilla behaviour

				///Sets up the portraits for the player and the NPC
				RawImage portrait = UWHUD.instance.ConversationPortraits[0];
				RawImage npcPortrait = UWHUD.instance.ConversationPortraits[1];
				GRLoader grPCHead = new GRLoader(GRLoader.HEADS_GR);
				if (GameWorldController.instance.playerUW.isFemale)
				{
						//portrait.texture=Resources.Load <Texture2D> (_RES +"/HUD/PlayerHeads/heads_"+ (GameWorldController.instance.playerUW.Body+5).ToString("0000"));//TODO:playerbody
						portrait.texture= grPCHead.LoadImageAt(GameWorldController.instance.playerUW.Body+5);
				}
				else
				{
						//portrait.texture=Resources.Load <Texture2D> (_RES +"/HUD/PlayerHeads/heads_"+ (GameWorldController.instance.playerUW.Body).ToString("0000"));//TODO:playerbody		
						portrait.texture= grPCHead.LoadImageAt(GameWorldController.instance.playerUW.Body);
				}


				if ((npc.npc_whoami!=0) && (npc.npc_whoami<=28))
				{
						GRLoader grCharHead = new GRLoader(GRLoader.CHARHEAD_GR);
						//npcPortrait.texture=Resources.Load <Texture2D> (_RES +"/HUD/Charhead/charhead_"+ (npc.npc_whoami-1).ToString("0000"));			
						npcPortrait.texture= grCharHead.LoadImageAt((npc.npc_whoami-1));
				}	
				else
				{
						//head in charhead.gr
						int HeadToUse = npc.objInt().item_id-64;
						if (HeadToUse >59)
						{
								HeadToUse=0;
						}			
						GRLoader grGenHead =new GRLoader(GRLoader.GENHEAD_GR);
						//npcPortrait.texture=Resources.Load <Texture2D> (_RES +"/HUD/genhead/genhead_"+ (HeadToUse).ToString("0000"));
						npcPortrait.texture = grGenHead.LoadImageAt(HeadToUse);
				}
				UWHUD.instance.MessageScroll.Clear ();
				/*End UI Setup*/

				///Cancels player movement
				GameWorldController.instance.playerUW.playerMotor.enabled=false;

				///Sets the music to the conversation theme
				if  (GameWorldController.instance.getMus()!=null)
				{
						GameWorldController.instance.getMus().GetComponent<MusicController>().InMap=true;
				}

				///Slows the world down so no other npc will attack or interupt the conversation
				Time.timeScale=0.00f;

				StartCoroutine(RunConversationVM(npc));
		}


		/// <summary>
		/// Main looping function for a conversation
		/// </summary>
		/// <returns>The conversation V.</returns>
		private IEnumerator RunConversationVM(NPC npc)
		{
				call_level=1;
				instrp=0;
				//basep = 0;
				result_register = 1;//Set a default value
				bool finished = false;
				stack=new CnvStack(4096);
				stack.set_stackp(100);//Skip over imported memory for the moment
				stack.basep=0;

				//Import the variables
				ImportVariableMemory(npc);


				// execute one instruction
				//switch(code[instrp])
				while ( (finished==false))
				{
						switch(conv[currConv].instuctions[instrp])
						{
						case cnv_NOP:
								break;

						case cnv_OPADD:
								{
										int arg1 = stack.Pop();
										int arg2 = stack.Pop();
										stack.Push(arg1 + arg2);
								}
								break;

						case cnv_OPMUL:
								{

										int arg1 = stack.Pop();
										int arg2 = stack.Pop();
										stack.Push(arg1 * arg2);
								}
								break;

						case cnv_OPSUB:
								{
										int arg1 = stack.Pop();
										int arg2 = stack.Pop();
										stack.Push(arg2 - arg1);
								}
								break;

						case cnv_OPDIV:
								{
										int arg1 = stack.Pop();
										int arg2 = stack.Pop();
										//if (arg1==0)
										//	throw ua_ex_div_by_zero;
										stack.Push(arg2 / arg1);
								}
								break;

						case cnv_OPMOD:
								{
										int arg1 = stack.Pop();
										int arg2 = stack.Pop();
										//if (arg1==0)
										//	throw ua_ex_div_by_zero;
										stack.Push(arg2 % arg1);
								}
								break;

						case cnv_OPOR:
								{
										int arg1 = stack.Pop();
										int arg2 = stack.Pop();
										stack.Push(arg2 | arg1);
								}
								break;

						case cnv_OPAND:
								{
										int arg1 = stack.Pop();
										int arg2 = stack.Pop();
										stack.Push(arg2 & arg1);
								}
								break;

						case cnv_OPNOT:
								{
										int arg1 = stack.Pop();
										if (arg1==0)
										{
												stack.Push(1);
										}
										else
										{
												stack.Push(0);
										}
										//stack.Push(!stack.Pop());
										break;
								}


						case cnv_TSTGT:
								{
										int arg1 = stack.Pop();
										int arg2 = stack.Pop();
										if (arg2>arg1)
										{
												stack.Push(1);
										}
										else
										{
												stack.Push(0);
										}
										//stack.Push(arg2 > arg1);
								}
								break;

						case cnv_TSTGE:
								{
										int arg1 = stack.Pop();
										int arg2 = stack.Pop();
										if (arg2>=arg1)
										{
												stack.Push(1);
										}
										else
										{
												stack.Push(0);
										}

										//stack.Push(arg2 >= arg1);
								}
								break;

						case cnv_TSTLT:
								{
										int arg1 = stack.Pop();
										int arg2 = stack.Pop();
										if (arg2<arg1)
										{
												stack.Push(1);
										}
										else
										{
												stack.Push(0);
										}
										//stack.Push(arg2 < arg1);
								}
								break;

						case cnv_TSTLE:
								{
										int arg1 = stack.Pop();
										int arg2 = stack.Pop();
										if (arg2<=arg1)
										{
												stack.Push(1);
										}
										else
										{
												stack.Push(0);
										}
										//stack.Push(arg2 <= arg1);
								}
								break;

						case cnv_TSTEQ:
								{
										int arg1 = stack.Pop();
										int arg2 = stack.Pop();
										if (arg2==arg1)
										{
												stack.Push(1);
										}
										else
										{
												stack.Push(0);
										}
										//stack.Push(arg2 == arg1);
								}
								break;

						case cnv_TSTNE:
								{
										int arg1 = stack.Pop();
										int arg2 = stack.Pop();
										if (arg2!=arg1)
										{
												stack.Push(1);
										}
										else
										{
												stack.Push(0);
										}
										//stack.Push(arg2 != arg1);
								}
								break;

						case cnv_JMP:
								//Debug.Log("instr = " +instrp + " JMP to " +  conv[currConv].instuctions[instrp+1]);
								instrp = conv[currConv].instuctions[instrp+1]-1;
								//if (conv[currConv].instuctions[instrp+1] == cnv_BRA)
								//{//Skip over a branch when jumping
								//		instrp+=2;
								//}
								break;

						case cnv_BEQ:
								{
										int arg1 = stack.Pop();
										if (arg1 == 0)
												instrp += conv[currConv].instuctions[instrp+1];
										else
												instrp++;
								}
								break;

						case cnv_BNE:
								{
										int arg1 = stack.Pop();
										if (arg1 != 0)
												instrp += conv[currConv].instuctions[instrp+1];
										else
												instrp++;
								}
								break;

						case cnv_BRA:
								{
									if (conv[currConv].instuctions[instrp+1]<=conv[currConv].instuctions.GetUpperBound(0))
									{
										instrp += conv[currConv].instuctions[instrp+1];		
									}
									else
									{//Skip over an invalid instruction address
										//instrp++;

												//Go backwards
										int offset =  conv[currConv].instuctions[instrp+1] ^ 0xffff	;
												offset++;
										instrp -=offset;
									}
									break;		
								}

						case cnv_CALL: // local function
								// stack value points to next instruction after call
								//Debug.Log("inst=" + instrp + "stack ptr" + stack.stackptr + " new inst=" + (conv[currConv].instuctions[instrp+1]-1));
								stack.Push(instrp+1);
								instrp = conv[currConv].instuctions[instrp+1]-1;
								call_level++;
								break;

						case cnv_CALLI: // imported function
								{
									int arg1 = conv[currConv].instuctions[++instrp];
									for (int i=0; i<=conv[currConv].functions.GetUpperBound(0);i++)
									{
										if ((conv[currConv].functions[i].ID_or_Address==arg1) && (conv[currConv].functions[i].import_type==0x0111))
										{
											//Debug.Log("Calling function  " + arg1 + " which is currently : " + conv[currConv].functions[i].functionName );
											yield return StartCoroutine( run_imported_function(conv[currConv].functions[i] , npc));
											break;
										}
									}


										/*	std::string funcname;
				if (imported_funcs.find(arg1) == imported_funcs.end())
					throw ua_ex_imported_na;

				imported_func(imported_funcs[arg1].name);*/
								}
								break;

						case cnv_RET:
								{

										if (--call_level<0)
										{
												// conversation ended
												finished = true;
										}
										else
										{
												int arg1 = stack.Pop();
												//Debug.Log("instr = " +instrp + " returning to " + arg1);
												instrp = arg1;
										}
								}
								break;

						case cnv_PUSHI:
								stack.Push(conv[currConv].instuctions[++instrp]);
								break;

						case cnv_PUSHI_EFF:
								stack.Push(stack.basep + conv[currConv].instuctions[++instrp]);
								break;

						case cnv_POP:
								stack.Pop();
								break;

						case cnv_SWAP:
								{
										int arg1 = stack.Pop();
										int arg2 = stack.Pop();
										stack.Push(arg1);
										stack.Push(arg2);
								}
								break;

						case cnv_PUSHBP:
								stack.Push(stack.basep);
								break;

						case cnv_POPBP:
								{
										int arg1 = stack.Pop();
										stack.basep = arg1;
								}
								break;

						case cnv_SPTOBP:
								stack.basep = stack.get_stackp();
								break;

						case cnv_BPTOSP:
								stack.set_stackp(stack.basep);
								break;

						case cnv_ADDSP:
								{
										int arg1 = stack.Pop();

										// fill reserved stack space with dummy values
										for(int i=0; i<arg1; i++)
												stack.Push(0);
								}
								break;

						case cnv_FETCHM:
								{
										int arg1 = stack.Pop();
										//Debug.Log("instr = " +instrp + " fetching address " + arg1 + " from stack at " +(stack.stackptr+1) + " Pushing value " + stack.at(arg1));
										//fetch_value(arg1);
										stack.Push(stack.at(arg1));
								}
								break;

						case cnv_STO:
								{
										//int arg1 = stack.Pop();
										int arg1 = stack.at(stack.stackptr-1);
										//int arg2 = stack.Pop();
										int arg2 = stack.at(stack.stackptr-2);

										//store_value(arg2,arg1);

										stack.Set(arg2,arg1);
								}
								break;

						case cnv_OFFSET:
								{
										int arg1 = stack.Pop();
										int arg2 = stack.Pop();
										arg1 += arg2 - 1 ;
										stack.Push(arg1);
								}
								break;

						case cnv_START:
								// do nothing
								break;

						case cnv_SAVE_REG:
								{
										int arg1 = stack.Pop();
										result_register = arg1;
								}
								break;

						case cnv_PUSH_REG:
								//Debug.Log("instr = " +instrp + " saving result " + result_register + " to " + stack.stackptr );
								stack.Push(result_register);
								break;

						case cnv_EXIT_OP:
								// finish processing (we still might be in some sub function)
								finished = true;
								break;

						case cnv_SAY_OP:
								{
										int arg1 = stack.Pop();
										yield return StartCoroutine(say_op(arg1));
								}
								break;

						case cnv_RESPOND_OP:
								// do nothing
								break;

						case cnv_OPNEG:
								{
										int arg1 = stack.Pop();
										stack.Push(-arg1);
								}
								break;

						default: // unknown opcode
								//throw ua_ex_unk_opcode;
								break;
						}

						// process next instruction
						++instrp;
						if (instrp>conv[currConv].instuctions.GetUpperBound(0))
						{
								finished=true;
						}
				}
			yield return StartCoroutine(EndConversation(npc));
		}

		/// <summary>
		/// Ends the conversation.
		/// </summary>
		public IEnumerator EndConversation(NPC npc)
		{
				Conversation.InConversation=false;
				//Copy back private variables to the globals file.

				for (int c = 0; c<=GameWorldController.instance.bGlobals.GetUpperBound(0);c++)
				{
					if (Conversation.CurrentConversation== GameWorldController.instance.bGlobals[c].ConversationNo)
					{
						for (int x=0; x<= GameWorldController.instance.bGlobals[c].Globals.GetUpperBound(0);x++)
						{
								//Copy Private variables
								GameWorldController.instance.bGlobals[c].Globals[x]=fetch_value(x);
						}
						break;
					}
				}

				//Copy back npc related variables that need to update. Eg attitude. Talked to etc.
				for (int i=0; i<= conv[currConv].functions.GetUpperBound(0);i++)
				{
						if (conv[currConv].functions[i].import_type== import_variable)
						{
								int address=conv[currConv].functions[i].ID_or_Address;
								switch (conv[currConv].functions[i].functionName.ToLower())
								{
								case "npc_talkedto":
										npc.npc_talkedto = fetch_value(address);break;
								case "npc_gtarg":
										npc.npc_gtarg = fetch_value(address);break;
								case "npc_attitude":
										npc.npc_attitude= fetch_value(address);break;
								case "npc_goal":
										npc.npc_goal= fetch_value(address);break;
								case "npc_power":
										npc.npc_power= fetch_value(address);break;
								case "npc_arms":
										npc.npc_arms= fetch_value(address);break;
								case "npc_hp":
										npc.npc_hp= fetch_value(address);break;
								case "npc_health":										
										npc.npc_health= fetch_value(address);break;
								case "npc_hunger":
										npc.npc_hunger= fetch_value(address);break;
								case "npc_whoami":
										npc.npc_whoami= fetch_value(address);break;
								case "npc_yhome":
										npc.npc_yhome= fetch_value(address);break;
								case "npc_xhome":
										npc.npc_xhome= fetch_value(address);break;
								}

						}
				}


				///Give movement back to the player			
				GameWorldController.instance.playerUW.playerMotor.enabled=true;
				Container cn = GameObject.Find (GameWorldController.instance.playerUW.GetComponent<PlayerInventory>().currentContainer).GetComponent<Container>();
				///Return any items in the trade area to their owner
				for (int i =0; i <=3; i++)
				{
						TradeSlot npcSlot = UWHUD.instance.playerTrade[i];//GameObject.Find ("Trade_Player_Slot_" + i).GetComponent<TradeSlot>();
						if (npcSlot.objectInSlot!="")
						{///Moves the object to the players container or to the ground
								if (Container.GetFreeSlot(cn)!=-1)//Is there space in the container.
								{
										npc.GetComponent<Container>().RemoveItemFromContainer(npcSlot.objectInSlot);
										cn.AddItemToContainer(npcSlot.objectInSlot);
										npcSlot.clear ();
										GameWorldController.instance.playerUW.GetComponent<PlayerInventory>().Refresh ();
								}
								else
								{
										GameObject demanded = GameObject.Find (npcSlot.objectInSlot);
										demanded.transform.parent=GameWorldController.instance.LevelMarker();
										GameWorldController.MoveToWorld(demanded);
										demanded.transform.position=npc.transform.position;
										npc.GetComponent<Container>().RemoveItemFromContainer(npcSlot.objectInSlot);
										npcSlot.clear();
								}
						}

				}

				///Puts the time scales back to normal
				Time.timeScale=1.0f;
				yield return new WaitForSeconds(4f);
				//npc.npc_talkedto=1;
				UWHUD.instance.Conversation_tl.Clear();
				UWHUD.instance.MessageScroll.Clear();

				UWCharacter.InteractionMode=UWCharacter.InteractionModeTalk;
				if  (GameWorldController.instance.getMus()!=null)
				{
						GameWorldController.instance.getMus().InMap=false;
				}
				if (GameWorldController.instance.playerUW.playerInventory.ObjectInHand!="")
				{
						UWCharacter.InteractionMode=UWCharacter.InteractionModePickup;
				}
				StopAllCoroutines();

				///Resets the UI
				UWHUD.instance.RefreshPanels(UWHUD.HUD_MODE_INVENTORY);
		}


		void ImportVariableMemory(NPC npc)
		{
				//Copy the stored values from glob first
				for (int c = 0; c<=GameWorldController.instance.bGlobals.GetUpperBound(0);c++)
				{
					if (npc.npc_whoami== GameWorldController.instance.bGlobals[c].ConversationNo)
					{
						//cnv.privateVariables = new int[GameWorldController.instance.bGlobals[c].Globals.GetUpperBound(0)+1];
						for (int x=0; x<= GameWorldController.instance.bGlobals[c].Globals.GetUpperBound(0);x++)
						{
							//Copy Private variables
							//cnv.privateVariables[x]	= GameWorldController.instance.bGlobals[c].Globals[x];	
							store_value(x,GameWorldController.instance.bGlobals[c].Globals[x] );
						}
						break;
					}
				}


				//Add in the imported variables.
				for (int i=0; i<= conv[currConv].functions.GetUpperBound(0);i++)
				{
						if (conv[currConv].functions[i].import_type== import_variable)
						{
							int address=conv[currConv].functions[i].ID_or_Address;
							switch (conv[currConv].functions[i].functionName.ToLower())
							{
							case "game_mins":
									store_value(address,GameClock.minute);break;
								case "game_days":
									store_value(address,GameClock.day);break;
								//case "game_time"://What shou
										//store_value(address,GameClock.);
										//break;
								case "riddlecounter":
										store_value(address,0);break;
								case "dungeon_level":
										store_value(address,GameWorldController.instance.LevelNo+1);break;
								//case "npc_name":
								case "npc_level":
										store_value(address,npc.npc_level);break;
								case "npc_talkedto":
										store_value(address,npc.npc_talkedto);break;
								case "npc_gtarg":
										store_value(address,npc.npc_gtarg);break;
								case "npc_attitude":
										store_value(address,npc.npc_attitude);break;
								case "npc_goal":
										store_value(address,npc.npc_goal);break;
								case "npc_power":
										store_value(address,npc.npc_power);break;
								case "npc_arms":
										store_value(address,npc.npc_arms);break;
								case "npc_hp":
										store_value(address,npc.npc_hp);break;
								case "npc_health":
										store_value(address,npc.npc_health);break;
								case "npc_hunger":
										store_value(address,npc.npc_hunger);break;
								case "npc_whoami":
										store_value(address,npc.npc_whoami);break;
								case "npc_yhome":
										store_value(address,npc.npc_yhome);break;
								case "npc_xhome":
										store_value(address,npc.npc_xhome);break;
								case "play_sex":
										{
											if (GameWorldController.instance.playerUW.isFemale)
											{
												store_value(address, 1);
											}
											else
											{
												store_value(address,0);
											}
										break;
										}

								//case "play_drawn":
								case "play_poison":
										store_value(address,GameWorldController.instance.playerUW.play_poison);break;
								//case "play_name":
								//case "new_player_exp":
								case "play_level":
										store_value(address,GameWorldController.instance.playerUW.CharLevel);break;
								case "play_mana":
										store_value(address,GameWorldController.instance.playerUW.PlayerMagic.CurMana);break;
								case "play_hp":
										store_value(address,GameWorldController.instance.playerUW.CurVIT);break;
								//case "play_power":
										
								//case "play_arms":
							//	case "play_health":
								case "play_hunger":
										store_value(address,GameWorldController.instance.playerUW.FoodLevel);break;
										break;
							default:
								Debug.Log("unimplemented memory import " + conv[currConv].functions[i].functionName);
								break;

							}
						}
				}
		}


		void store_value(int at, int val)
		{
			stack.Set(at,val);
		}

		int fetch_value(int at)
		{
			return stack.at(at);
		}

		IEnumerator say_op(int arg1)
		{
			//Debug.Log( stringcontrol.GetString(conv[currConv].StringBlock,arg1));
			//Output.text += StringController.instance.GetString(conv[currConv].StringBlock,arg1) + "\n";
			//UWHUD.instance.Conversation_tl.Add ( StringController.instance.GetString(conv[currConv].StringBlock,arg1) + "\n", NPC_SAY);
			yield return StartCoroutine(say_op(arg1,NPC_SAY));
			yield return 0;
		}


		IEnumerator say_op(int arg1, int PrintType)
		{
				//Debug.Log( stringcontrol.GetString(conv[currConv].StringBlock,arg1));
				//Output.text += StringController.instance.GetString(conv[currConv].StringBlock,arg1) + "\n";

				///Sets the markup to colour the text based on print type.

				//UWHUD.instance.Conversation_tl.Add ( Markup + StringController.instance.GetString(conv[currConv].StringBlock,arg1) + "\n" + "</color>");
			yield return StartCoroutine(say_op(StringController.instance.GetString(conv[currConv].StringBlock,arg1),PrintType));
			yield return 0;

		}


		IEnumerator say_op(string text, int PrintType)
		{				
			string Markup="";
			switch (PrintType)
			{
			case PC_SAY:
					Markup="<color=red>";break;//[FF0000]
			case PRINT_SAY:
					Markup="<color=black>";break;//[000000]
			default:
					Markup="<color=green>";break;//[00FF00]
			}	
			UWHUD.instance.Conversation_tl.Add ( Markup + text + "" + "</color>"); //\n
			yield return 0;
		}


		IEnumerator run_imported_function(ImportedFunctions func, NPC npc)
		{
				//Debug.Log("Calling " + func.functionName);
				switch (func.functionName.ToLower())
				{
				case "babl_menu":
						{
								stack.Pop();
								int start =stack.Pop(); //stack.at(stack.stackptr-2);//Not sure if this is correct for all conversations but lets try it anyway!
								yield return StartCoroutine(babl_menu(start));
								break;
						}

				case "babl_fmenu":
						{
								stack.Pop();
								int start =stack.Pop(); // stack.at(stack.stackptr-2);//Not sure if this is correct for all conversations but lets try it anyway!
								int flagstart =stack.Pop(); //  stack.at(stack.stackptr-3);
								yield return StartCoroutine(babl_fmenu(start,flagstart));
								break;
						}

				case "get_quest":
						{
								stack.Pop();
								int index= stack.at(stack.Pop());
								//int index= stack.at( stack.at( stack.stackptr-2 ) );
								result_register = get_quest(0,index);
								break;
						}

				case "set_quest":
						{
								int val = stack.Pop();
								int index= stack.at(stack.Pop()); //stack.at( stack.at( stack.stackptr-5 ) );
								//stack.at( stack.at( stack.stackptr-4 ) ) ;
								set_quest(0,val,index );//Or the other way around.
								break;
						}

				case "print":
						{
								say_op(stack.Pop(),PRINT_SAY);
								break;
						}

				case "x_skills":
						{
								int val1 = stack.Pop();
								int val2 = stack.Pop();
								int val3 = stack.Pop();
								int val4 = stack.Pop();
								result_register = x_skills(val1,val2,val3,val4);//Or the other way around.
								break;
						}

				case "set_likes_dislikes":
						{
								stack.Pop();
								int index1= stack.Pop();
								int index2= stack.Pop();
								set_likes_dislikes(index1,index2);
								break;
						}

				case "sex":
						{
							stack.Pop();
							stack.Pop();
							stack.Pop();
							int arg2=stack.Pop();
							int arg1=stack.Pop();
							if (GameWorldController.instance.playerUW.isFemale)
							{
								result_register=stack.at(arg2);		
							}
							else
							{
								result_register=stack.at(arg1);
							}
							break;
						}

				case "random":
						{
							stack.Pop();
							//stack.Pop();
							int arg1=stack.Pop();
							result_register=Random.Range(1,stack.at(arg1)+1);
							break;
						}

				case "show_inv":
						{
							//stack.Pop();
							int arg1 = stack.at(stack.stackptr-2);
							int arg2 = stack.at(stack.stackptr-3);
							result_register= show_inv(arg1,arg2);
							break;
						}

				case "give_to_npc":
						{
							stack.Pop();
							int arg1= stack.Pop();	
							int arg2= stack.Pop();
							give_to_npc(npc, stack.at(arg1), stack.at(arg2));
							break;
						}

				case "take_from_npc":
						{
							stack.Pop();
							int arg1 = stack.Pop();
							take_from_npc(npc, stack.at(arg1));
							break;
						}

				case "setup_to_barter":
						{
							//stack.Pop();
							setup_to_barter(npc);
							break;
						}

				case "do_offer":
						{
							int noOfArgs=stack.Pop();
							switch (noOfArgs)
							{
							case 7:
								{
									int []args =new int[noOfArgs];
									int start= stack.Pop();
									for (int i=0; i<noOfArgs; i++)
									{
										args[i]	= stack.at(start-i);
									}


									yield return StartCoroutine(do_offer(npc, noOfArgs,args[0],args[1],args[2],args[3],args[4],args[5],args[6]));
									break;		
								}

							default:
								{
									Debug.Log("unimplemented version of do_offer " + noOfArgs);
									break;		
								}
							}
						break;
						}

				case "do_demand":
						{
							int noOfArgs=stack.Pop();
							int []args =new int[noOfArgs];
							int start= stack.Pop();
							for (int i=0; i<noOfArgs; i++)
							{
									args[i]	= stack.at(start-i);
							}	
							yield return StartCoroutine(do_demand(npc,args[0],args[1]));
							break;
						}

				case "do_judgement":
						{
							//stack.Pop();
							yield return StartCoroutine(do_judgement(npc));
							break;
						}


				default: 

						Debug.Log("unimplemented function " + func.functionName);
						break;
				}
				yield return 0;
		}

		public IEnumerator babl_menu(int Start)
		{
				UWHUD.instance.MessageScroll.Clear();
				//PlayerInput.text="";
				usingBablF=false;
				string tmp="";
				MaxAnswer=0;
				int j=1;
				for (int i = Start; i <=stack.Upperbound() ; i++)
				{
						if ( stack.at(i) >0)
						{
								//tl_input.Add(j++ + "." + StringController.instance.GetString(StringBlock,localsArray[i]).Replace("@GS8",GameWorldController.instance.playerUW.CharName));
								//tl_input.Add(j++ + "." + StringController.instance.GetString(StringBlock,localsArray[i]));
								//PlayerInput.text += (j++ + "." + StringController.instance.GetString(conv[currConv].StringBlock,stack.at(i))) + "\n";
								UWHUD.instance.MessageScroll.Add(j++ + "." + StringController.instance.GetString(conv[currConv].StringBlock,stack.at(i)) + "");//  \n

								MaxAnswer++;
						}
						else
						{
								break;
						}
				}
				yield return StartCoroutine(WaitForInput());
				int AnswerIndex=stack.at(Start+PlayerAnswer-1);
				yield return StartCoroutine(say_op(AnswerIndex, PC_SAY));
				result_register = PlayerAnswer;
				yield return 0;
		}


		/// <summary>
		/// Dialog menu with choices that may or may not show based on the flags
		/// </summary>
		/// <param name="unknown">Unknown.</param>
		/// <param name="localsArray">Array of local variables from the conversation</param>
		/// <param name="Start">Index to start taking values from the array</param>
		/// <param name="flagIndex">Index to start flagging if a value is allowed from the array</param>
		public IEnumerator babl_fmenu(int Start, int flagIndex)
		{
				UWHUD.instance.MessageScroll.Clear();
				//Debug.Log("babl_fmenu - " + Start + " " + flagIndex);
				//tl_input.Clear();
				//PlayerInput.text="";
				usingBablF=true;
				for (int i =0; i<=bablf_array.GetUpperBound (0);i++)
				{//Reset the answers array
						bablf_array[i]=0;
				}
				string tmp="";
				int j=1;
				MaxAnswer=0;
				for (int i = Start; i <=stack.Upperbound() ; i++)
				{
						if (stack.at(i)!=0)
						{
								if (stack.at(flagIndex++) !=0)
								{
										bablf_array[j-1] = stack.at(i);
										//tmp = tmp + j++ + "." + StringController.instance.GetString(StringBlock,localsArray[i]) + "\n";
										UWHUD.instance.MessageScroll.Add (j++ + "." + StringController.instance.GetString(conv[currConv].StringBlock,stack.at(i)) + "\n");
										MaxAnswer++;
								}
						}
						else
						{
								break;
						}
				}
				yield return StartCoroutine(WaitForInput());
				//tmp= StringController.instance.GetString (stringcontrol.GetString(conv[currConv].StringBlock,bablf_array[bablf_ans-1]);
				//yield return StartCoroutine(say (tmp,PC_SAY));
				yield return StartCoroutine(say_op(bablf_array[bablf_ans-1]));
				result_register=bablf_array[bablf_ans-1];
				yield return 0;
		}




		/// <summary>
		/// Waits for input in babl_menu and bablf_menu
		/// </summary>
		IEnumerator WaitForInput()
		{
				WaitingForInput=true;
				while (WaitingForInput)
				{yield return null;}
		}




		/// <summary>
		/// Processes key presses from the player when waiting for input.
		/// </summary>
		void OnGUI()
		{
			if (WaitingForInput)
			{
				if (Input.GetKeyDown (KeyCode.Alpha1))
				{
						CheckAnswer(1);
				}
				else if (Input.GetKeyDown (KeyCode.Alpha2))
				{
						CheckAnswer(2);
				}
				else if (Input.GetKeyDown (KeyCode.Alpha3))
				{
						CheckAnswer(3);
				}
				else if (Input.GetKeyDown (KeyCode.Alpha4))
				{
						CheckAnswer(4);
				}
				else if (Input.GetKeyDown (KeyCode.Alpha5))
				{
						CheckAnswer(5);
				}
				else if (Input.GetKeyDown (KeyCode.Alpha6))
				{
						CheckAnswer(6);
				}
			}
			else if (WaitingForMore)
			{
				if (Input.GetKeyDown (KeyCode.Space))
				{
						WaitingForMore=false;
				}
			}
		}




		/// <summary>
		/// Checks the answer the player has entered to see if it in within the bounds of the valid options.
		/// Sets the PlayerAnswer variable for checking within the conversations
		/// </summary>
		/// <param name="AnswerNo">The answer number from the menu entered by the player</param>
		private void CheckAnswer(int AnswerNo)
		{
				if (usingBablF ==false)
				{		
						if ((AnswerNo>0) && (AnswerNo<=MaxAnswer))
						{
								PlayerAnswer=AnswerNo;
								WaitingForInput=false;
						}
				}
				else
				{
						if ((AnswerNo>0) && (AnswerNo<=MaxAnswer))
						{
								///For babl_fmenus convert the answer using the bablf_array
								bablf_ans=AnswerNo;
								PlayerAnswer=bablf_array[AnswerNo-1];
								WaitingForInput=false;
								usingBablF=false;
						}
				}
		}


		/// <summary>
		/// Gets the quest variable.
		/// </summary>
		/// <returns>The quest.</returns>
		/// <param name="unk">Unk.</param>
		/// <param name="QuestNo">Quest no to lookup</param>
		public int get_quest(int unk, int QuestNo)
		{
				return GameWorldController.instance.playerUW.quest().QuestVariables[QuestNo];
		}

		/// <summary>
		/// Sets the quest variable
		/// </summary>
		/// <param name="unk">Unk.</param>
		/// <param name="value">Value to change to</param>
		/// <param name="QuestNo">Quest no to change</param>
		public void set_quest(int unk,int value, int QuestNo)
		{
			GameWorldController.instance.playerUW.quest().QuestVariables[QuestNo]=value;
		}

		/// <summary>
		/// Probably returns the skill value at the index.
		/// </summary>
		/// <returns>The skills.</returns>
		/// <param name="index">Index.</param>
		public int x_skills(int val1, int val2, int val3, int val4)
		{
				Debug.Log("X_skills(" + val1 + "," + val2 + "," + val3 + "," + val4 +")");
				return 0;
		}

		/// <summary>
		/// Sets the likes dislikes.
		/// </summary>
		/// <param name="index1">Index1.</param>
		/// <param name="index2">Index2.</param>
		public void set_likes_dislikes(int index1, int index2)
		{
				Debug.Log("set_likes_dislikes(" +index1 + "," + index2 +")");
		}



		/// <summary>
		/// Copies inventory item ids and slot positions into the array indices specified.
		/// </summary>
		/// <returns>The number of items found</returns>
		/// <param name="startObjectPos">Start index of object position.</param>
		/// <param name="startObjectIDs">Start index of object Ids.</param>
		public int show_inv(int startObjectPos, int startObjectIDs)
		{
			int j=0;
			for (int i=0; i<4;i++)
			{
					TradeSlot pcSlot = UWHUD.instance.playerTrade[i]; 
					if (pcSlot.isSelected())
					{
							//locals[startObjectPos+j]= i;
							stack.Set(startObjectPos+j,i+1);
							//locals[startObjectIDs+j]= pcSlot.GetObjectID();
							stack.Set(startObjectIDs+j,pcSlot.GetObjectID());
							j++;
					}
			}
				//Debug.Log(j + " items saved to " + startObjectPos + startObjectIDs);
			return j;
		}



		/// <summary>
		/// Gives the items at the specified positions in the array to the NPC
		/// </summary>
		/// <returns>1 if something given</returns>
		/// <param name="start">Start index of slots to transfer from</param>
		/// <param name="NoOfItems">No of items to transfer</param>
		public int give_to_npc(NPC npc, int start, int NoOfItems)
		{
				Container cn =npc.gameObject.GetComponent<Container>();
				bool SomethingGiven=false;
				for (int i=0; i<NoOfItems; i++)
				{
						int slotNo = start-1+i; //locals[start+i] ;
						if (slotNo<=3)
						{
								TradeSlot pcSlot = UWHUD.instance.playerTrade[slotNo];
								//Give the item to the npc
								if (Container.GetFreeSlot(cn)!=-1)
								{
										cn.AddItemToContainer(pcSlot.objectInSlot);
										pcSlot.clear ();
										SomethingGiven=true;
								}
								else
								{
										GameObject demanded = GameObject.Find (pcSlot.objectInSlot);
										if (demanded!=null)
										{
												demanded.transform.parent=GameWorldController.instance.LevelMarker();
												GameWorldController.MoveToWorld(demanded);
												demanded.transform.position=npc.transform.position;
												SomethingGiven=true;
										}
										pcSlot.clear();
								}
						}
				}
				if (SomethingGiven==true)
				{
						return 1;
				}
				else
				{
						return 0;
				}
		}




	/// <summary>
	/// transfers an item from npc inventory to player inventory,based on an item id. 
	/// </summary>
	/// when the value is > 1000, all items of		
	/// a category are copied. category item start = (arg1-1000)*16
	/// My currenty example is lanugo (10) who is passing a value greater than 1000*/
	/// Until It get more examples I'm doing the following*/
	/// Get the items in the npcs container. If their ITEM id is between the calculated category value and +16 of that I take that item*/
	/// Another example goldthirst who specifically has an item id to pass.
	/// 
	/// <returns>1: ok, 2: player has no space left</returns>
	/// <param name="unk">Unk.</param>
	/// <param name="arg1">Arg1.</param>
	public int take_from_npc(NPC npc, int arg1)
	{
		/*
		   id=0015 name="take_from_npc" ret_type=int
		   parameters:   arg1: item id (can also be an item category value, > 1000)
		   description:  transfers an item from npc inventory to player inventory,
		                 based on an item id. when the value is > 1000, all items of
		                 a category are copied. category item start = (arg1-1000)*16
		   return value: 1: ok, 2: player has no space left
			*/
		/*My currenty example is lanugo (10) who is passing a value greater than 1000*/
		/*Until It get more examples I'm doing the following*/
		/*Get the items in the npcs container. If their ITEM id is between the calculated category value and +16 of that I take that item*/
		//Debug.Log ("Item Category is " + (arg1-1000)*16);
		//Another example goldthirst who specifically has an item id to pass.
		int playerHasSpace=1;
		Container cn = npc.gameObject.GetComponent<Container>();
		Container cnpc = GameWorldController.instance.playerUW.gameObject.GetComponent<Container>();

		int rangeS = (arg1-1000)*16;
		int rangeE = rangeS+16;

		for (int i = 0; i<= cn.MaxCapacity ();i++)
		{
			//string itemName=cn.GetItemAt (i);				
			if (cn.GetItemAt (i)!="")
			{
				ObjectInteraction objInt =cn.GetGameObjectAt(i).GetComponent<ObjectInteraction>(); //GameObject.Find (itemName).GetComponent<ObjectInteraction>();
				if (
						((arg1>=1000) && (objInt.item_id >= rangeS ) && (objInt.item_id<=rangeE))
						||
						((arg1<1000) && (objInt.item_id == arg1 ))
				)
				{
					//Give to PC
					GameObject demanded =cn.GetGameObjectAt(i);
					string itemName=cn.GetItemAt (i);
					if (Container.GetFreeSlot(cnpc)!=-1)//Is there space in the container.
					{
						demanded.transform.parent= GameWorldController.instance.playerUW.playerInventory.InventoryMarker.transform;
						npc.GetComponent<Container>().RemoveItemFromContainer(itemName);
						cnpc.AddItemToContainer(itemName);
						demanded.GetComponent<ObjectInteraction>().PickedUp=true;
						GameWorldController.instance.playerUW.GetComponent<PlayerInventory>().Refresh ();
					}
					else
					{
						playerHasSpace=0;
						demanded.transform.parent=GameWorldController.instance.LevelMarker();
						GameWorldController.MoveToWorld(demanded);
						demanded.transform.position=npc.transform.position;
						npc.GetComponent<Container>().RemoveItemFromContainer(itemName);
					}
				}
			}
		}
		return playerHasSpace;
	}


	/// <summary>
	/// Waits for the player to press any key when printing text
	/// </summary>
	IEnumerator WaitForMore()
	{
			WaitingForMore=true;
			while (WaitingForMore)
			{yield return null;}
	}





		/// <summary>
		/// Setups the barter windows
		/// </summary>
		/// TODO: Figure out where generic NPCs get their inventory for trading from???? Is there a loot list somewhere?
		public void setup_to_barter(NPC npc)
		{
				/*
		   id=001f name="setup_to_barter" ret_type=void
		   parameters:   none
		   description:  starts bartering; shows npc items in npc bartering area
		 */

				Container cn = npc.gameObject.GetComponent<Container>();
				int itemCount=0;

				Debug.Log ("Setup to barter. Based on characters inventory at the moment.");
				for (int i =0 ; i<= cn.MaxCapacity(); i++)
				{
						if (cn.GetItemAt(i)!="")
						{
								if (itemCount <=3)
								{//Just take the first four items
										ObjectInteraction itemToTrade = cn.GetGameObjectAt(i).GetComponent<ObjectInteraction>(); //GameObject.Find (cn.GetItemAt(i)).GetComponent<ObjectInteraction>();
										TradeSlot ts = UWHUD.instance.npcTrade[itemCount++];//GameObject.Find ("Trade_NPC_Slot_" + itemCount++).GetComponent<TradeSlot>();
										ts.objectInSlot=itemToTrade.gameObject.name;
										ts.SlotImage.texture=itemToTrade.GetInventoryDisplay().texture;
										int qty= itemToTrade.GetQty();
										if (qty<=1)
										{
												ts.Quantity.text="";
										}
										else
										{
												ts.Quantity.text=qty.ToString();
										}
								}
						}
				}

				return;
		}


		/// <summary>
		/// Does the appraisal of the worth of the items in the trade area
		/// TODO: figure out how this works. for the moment just base it out quantity of objects selected
		/// Current implemenation is based on qty of objects in the trade area.
		/// </summary>
		/// <returns>The judgement.</returns>
		/// <param name="unk">Unk.</param>

		public IEnumerator do_judgement(NPC npc)
		{
				/*
	id=0021 name="do_judgement" ret_type=void
   parameters:   none
   description:  judges current trade (using the "appraise" skill) and prints result
		 */
				//Debug.Log ("Do Judgment");

				int playerObjectCount=0; int npcObjectCount=0;
				for (int i = 0; i<4; i++)
				{
						TradeSlot npcSlot = UWHUD.instance.npcTrade[i];//GameObject.Find ("Trade_NPC_Slot_" + i).GetComponent<TradeSlot>();
						TradeSlot pcSlot =  UWHUD.instance.playerTrade[i];// GameObject.Find ("Trade_Player_Slot_" + i).GetComponent<TradeSlot>();
						if (npcSlot.isSelected()){npcObjectCount++;}
						if (pcSlot.isSelected()){playerObjectCount++;}
				}
				if (playerObjectCount<npcObjectCount)
				{
						yield return  StartCoroutine ( say_op("Player has the better deal",PRINT_SAY));
				}
				else if (playerObjectCount==npcObjectCount)
				{
						yield return  StartCoroutine (say_op("It is an even deal",PRINT_SAY));
				}
				else
				{
						yield return  StartCoroutine (say_op ("NPC has the better deal",PRINT_SAY));
				}
				//return;
		}

		/// <summary>
		/// Declines the trade offer
		/// Moves items back into respective inventories
		/// </summary>
		/// <param name="unk">Unk.</param>
		public void do_decline(NPC npc)
		{
				/*
   id=0022 name="do_decline" ret_type=void
   parameters:   none
   description:  declines trade offer (?)
		*/

				Container cn = GameObject.Find (GameWorldController.instance.playerUW.GetComponent<PlayerInventory>().currentContainer).GetComponent<Container>();
				for (int i =0; i <=3; i++)
				{
						TradeSlot pcSlot =  UWHUD.instance.playerTrade[i] ;//GameObject.Find ("Trade_Player_Slot_" + i).GetComponent<TradeSlot>();
						if (pcSlot.objectInSlot!="")
						{//Move the object to the players container or to the ground
								if (Container.GetFreeSlot(cn)!=-1)//Is there space in the container.
								{
										//GameWorldController.instance.playerUW.GetComponent<Container>().RemoveItemFromContainer(pcSlot.objectInSlot);
										cn.AddItemToContainer(pcSlot.objectInSlot);
										pcSlot.clear ();
										GameWorldController.instance.playerUW.GetComponent<PlayerInventory>().Refresh ();
								}
								else
								{
										GameObject demanded = GameObject.Find (pcSlot.objectInSlot);
										demanded.transform.parent=GameWorldController.instance.LevelMarker();
										GameWorldController.MoveToWorld(demanded);
										demanded.transform.position=npc.transform.position;
										pcSlot.clear();
								}
						}
				}

				for (int i=0; i<=3; i++)
				{//Clear out the trade slots.
						UWHUD.instance.npcTrade[i].clear();
				}
				return;
		}



		/// <summary>
		/// Checks the offer.
		/// checks if the deal is acceptable for the npc, based on the
		/// selected items in both bartering areas. the values in arg1
		/// to arg5 are probably values of the items that are
		/// acceptable for the npc.
		/// the function is sometimes called with 7 args, but arg6 and
		/// arg7 are always set to -1.
		/// </summary>
		/// <returns>1 if the deal is acceptable, 0 if not</returns>
		/// <param name="unk">Unk.</param>
		/// <param name="arg1">Arg1.</param>
		/// <param name="arg2">Arg2.</param>
		/// <param name="arg3">Arg3.</param>
		/// <param name="arg4">Arg4.</param>
		/// <param name="arg5">Arg5.</param>
		/// <param name="arg6">Arg6.</param>
		/// <param name="arg7">Arg7.</param>
		/// I think the values passed are actually the strings for how the npc reacts to the offer. The value judgment is done elsewhere
		/// In the prototype I randomise the decision. And then randomise a response based on that decision.
		/// Arg5 is the yes answer
		public IEnumerator  do_offer(NPC npc, int unk, int arg1, int arg2, int arg3, int arg4, int arg5, int arg6, int arg7)
		{
				/*
   id=0018 name="do_offer" ret_type=int
   parameters:   arg1 ... arg5: unknown
                 [arg6, arg7]: unknown
   description:  checks if the deal is acceptable for the npc, based on the
                 selected items in both bartering areas. the values in arg1
                 to arg5 are probably values of the items that are
                 acceptable for the npc.
                 the function is sometimes called with 7 args, but arg6 and
                 arg7 are always set to -1.
   return value: 1 if the deal is acceptable, 0 if not*/


				PlayerAnswer = Random.Range (0,2);

				if (PlayerAnswer==1)
				{
						yield return StartCoroutine (say_op (arg5));
						//for the moment move to the player's backpack or if no room there drop them on the ground
						//Container cn = GameObject.Find (GameWorldController.instance.playerUW.GetComponent<PlayerInventory>().currentContainer).GetComponent<Container>();
						for (int i =0; i <=3; i++)
						{
								TakeFromNPC (npc,i);//Takes from the NPC slot if selected
						}


						//Now give the item to the NPC.
						//cn =npc.gameObject.GetComponent<Container>();
						for (int i =0; i <=3; i++)
						{
								TakeFromPC (npc, i);
						}
				}
				else
				{
						//Debug.Log ("offer declined");
						switch ( Random.Range(1,5))
						{
						case 1:
								yield return StartCoroutine (say_op (arg1));break;
						case 2:
								yield return StartCoroutine (say_op (arg2));break;
						case 3:
								yield return StartCoroutine (say_op (arg3));break;
						case 4:
								yield return StartCoroutine (say_op (arg4));break;
						}
				}
		}

		/// <summary>
		/// Does the offer.
		/// </summary>
		public IEnumerator do_offer(NPC npc, int unk, int arg1, int arg2, int arg3, int arg4, int arg5, int arg6)
		{
			yield return StartCoroutine( do_offer (npc, unk,arg1,arg2,arg3,arg4,arg5,arg6,-1) );
		}

		/// <summary>
		/// Player demands the items from the npc
		/// </summary>
		/// <returns>returns 1 when player persuaded the NPC, 0 else</returns>
		/// <param name="unk">Unk.</param>
		/// <param name="arg1">string id with text to print if NPC is not willing to give the item</param>
		/// <param name="arg2">string id with text if NPC gives the player the item</param>
		public IEnumerator do_demand(NPC npc, int arg1, int arg2)
		{
				/*
   id=0019 name="do_demand" ret_type=int
   parameters:   arg1: string id with text to print if NPC is not willing
                       to give the item
                 arg2: string id with text if NPC gives the player the item
   description:  decides if the player can "persuade" the NPC to give away
                 the items in barter area, e.g. using karma.
   return value: returns 1 when player persuaded the NPC, 0 else
		 */
				int DemandResult = Random.Range (0,2);
				if (DemandResult==1)
				{		
						//Demand sucessfull
						for (int i =0; i <=3; i++)
						{
								TakeFromNPC (npc, i);//Takes from the NPC slot if selected
						}
						yield return StartCoroutine ( say_op (arg2) );
				}
				else
				{
						//Unsucessful
						yield return StartCoroutine ( say_op (arg1) );
				}

				//Move the players items back to his inventory;
				RestorePCsInventory (npc);
				PlayerAnswer=DemandResult;
		}








		/// <summary>
		/// Gives the selected items to the NPC
		/// </summary>
		/// <param name="SlotNo">Slot no.</param>
		private void TakeFromNPC (NPC npc, int SlotNo)
		{
				Container cn = GameObject.Find (GameWorldController.instance.playerUW.GetComponent<PlayerInventory>().currentContainer).GetComponent<Container>();
				TradeSlot npcSlot = UWHUD.instance.npcTrade [SlotNo];
				//GameObject.Find ("Trade_NPC_Slot_" + i).GetComponent<TradeSlot>();
				if (npcSlot.isSelected ()) {
						//Move the object to the container or to the ground
						if (Container.GetFreeSlot (cn) != -1)//Is there space in the container.
						{
								npc.GetComponent<Container> ().RemoveItemFromContainer (npcSlot.objectInSlot);
								cn.AddItemToContainer (npcSlot.objectInSlot);
								GameObject demanded = GameObject.Find (npcSlot.objectInSlot);
								demanded.transform.parent = GameWorldController.instance.InventoryMarker.transform;
								GameWorldController.MoveToInventory(demanded);
								demanded.transform.position = Vector3.zero;
								npcSlot.clear ();
								GameWorldController.instance.playerUW.GetComponent<PlayerInventory> ().Refresh ();
								demanded.GetComponent<ObjectInteraction>().PickedUp=true;
						}
						else {
								GameObject demanded = GameObject.Find (npcSlot.objectInSlot);
								demanded.transform.parent = GameWorldController.instance.LevelMarker ();
								demanded.transform.position = npc.transform.position;
								GameWorldController.MoveToWorld(demanded);
								npc.GetComponent<Container> ().RemoveItemFromContainer (npcSlot.objectInSlot);
								npcSlot.clear ();
						}
				}
				return;
		}
		/// <summary>
		/// Takes from PCs selected items  ang gives them to the NPC.
		/// </summary>
		/// <param name="slotNo">Slot no.</param>
		void TakeFromPC (NPC npc, int slotNo)
		{
				Container cn = npc.GetComponent<Container> ();//GameObject.Find (GameWorldController.instance.playerUW.GetComponent<PlayerInventory>().currentContainer).GetComponent<Container>();
				TradeSlot pcSlot = UWHUD.instance.playerTrade [slotNo];
				if (pcSlot.isSelected ()) {
						//Move the object to the container or to the ground
						if (Container.GetFreeSlot (cn) != -1)//Is there space in the container.
						{
								cn.AddItemToContainer (pcSlot.objectInSlot);
								//Move to the inventory room
								GameObject demanded = GameObject.Find (pcSlot.objectInSlot);
								demanded.transform.parent = GameWorldController.instance.LevelMarker ();
								GameWorldController.MoveToWorld(demanded);
								demanded.transform.position = new Vector3 (119f, 2.1f, 119f);
								pcSlot.clear ();
						}
						else {
								GameObject demanded = GameObject.Find (pcSlot.objectInSlot);
								demanded.transform.parent = GameWorldController.instance.LevelMarker ();
								demanded.transform.position = npc.transform.position;
								pcSlot.clear ();
						}
				}
		}
		/// <summary>
		/// Restores the Pcs inventory out of the trade area and back into the current container.
		/// </summary>

		void RestorePCsInventory (NPC npc)
		{
				Container cn = GameObject.Find (GameWorldController.instance.playerUW.GetComponent<PlayerInventory>().currentContainer).GetComponent<Container>();
				for (int i = 0; i <= 3; i++) {
						TradeSlot npcSlot = UWHUD.instance.playerTrade [i];
						if (npcSlot.objectInSlot != "") {
								//Move the object to the players container or to the ground
								if (Container.GetFreeSlot (cn) != -1)//Is there space in the container.
								{
										npc.GetComponent<Container> ().RemoveItemFromContainer (npcSlot.objectInSlot);
										cn.AddItemToContainer (npcSlot.objectInSlot);
										npcSlot.clear ();
										GameWorldController.instance.playerUW.GetComponent<PlayerInventory> ().Refresh ();
								}
								else {
										GameObject demanded = GameObject.Find (npcSlot.objectInSlot);
										demanded.transform.parent = GameWorldController.instance.LevelMarker ();
										demanded.transform.position = npc.transform.position;
										GameWorldController.MoveToWorld(demanded);
										npc.GetComponent<Container> ().RemoveItemFromContainer (npcSlot.objectInSlot);
										npcSlot.clear ();
								}
						}
				}
		}

}

using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;
using System.Text.RegularExpressions;

/// <summary>
/// Implementation of the conversation virtual machine
/// based on UWAdventures hacking tools.
/// </summary>
public class ConversationVM : UWEBase {
		//TODO:Make sure pickups support containers
		//TODO:Make inventory related code operate on the master object list rather than trade slots.->Trade slots should just give indices into that list in show_inv, 
		/// Is the user entering a quantity
		public static bool EnteringQty;

		///The NPC is talking
		public const int NPC_SAY=0;
		///The PC is talking
		public const int PC_SAY=1;
		///Printed text is displayed
		public const int PRINT_SAY=2;

		//The op codes for the vm.
		const short cnv_NOP=0;
		const short cnv_OPADD=1;
		const short cnv_OPMUL=2;
		const short cnv_OPSUB=3;
		const short cnv_OPDIV=4;
		const short cnv_OPMOD=5;
		const short cnv_OPOR=6;
		const short cnv_OPAND=7;
		const short cnv_OPNOT=8;
		const short cnv_TSTGT=9;
		const short cnv_TSTGE=10;
		const short cnv_TSTLT=11;
		const short cnv_TSTLE=12;
		const short cnv_TSTEQ=13;
		const short cnv_TSTNE=14;
		const short cnv_JMP=15;
		const short cnv_BEQ=16;
		const short cnv_BNE=17;
		const short cnv_BRA=18;
		const short cnv_CALL=19;
		const short cnv_CALLI=20;
		const short cnv_RET=21;
		const short cnv_PUSHI=22;
		const short cnv_PUSHI_EFF=23;
		const short cnv_POP=24;
		const short cnv_SWAP=25;
		const short cnv_PUSHBP=26;
		const short cnv_POPBP=27;
		const short cnv_SPTOBP=28;
		const short cnv_BPTOSP=29;
		const short cnv_ADDSP=30;
		const short cnv_FETCHM=31;
		const short cnv_STO=32;
		const short cnv_OFFSET=33;
		const short cnv_START=34;
		const short cnv_SAVE_REG=35;
		const short cnv_PUSH_REG=36;
		const short cnv_STRCMP=37;
		const short cnv_EXIT_OP=38;
		const short cnv_SAY_OP=39;
		const short cnv_RESPOND_OP=40;
		const short cnv_OPNEG=41;


		const int import_function =0x111;
		const int import_variable =0x10f;

		const int return_void = 0;
		const int return_int = 0x129;
		const int return_string = 0x12b;


		const int TradeAreaOffset=10000;

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
				public short[] instuctions;
		};


		cnvHeader[] conv;

		/// <summary>
		/// The memory stack for the VM.
		/// </summary>
		CnvStack stack;

		/// The player answer.
		public static int PlayerAnswer;
		///The text the player has typed in response to a question
		public static string PlayerTypedAnswer;
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



		void Update()
		{
			if (WaitingForTyping)
			{
				UWHUD.instance.InputControl.Select();//Keep focus on input control	
			}
		}

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
					conv[i].instuctions = new short[conv[i].CodeSize];
					int counter=0;
					for (int c=0; c<conv[i].CodeSize*2; c=c+2)
					{
						conv[i].instuctions[counter++] = (short)DataLoader.getValAtAddress(cnv_ark, funcptr + c, 16);
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
				if (npc.npc_whoami==0)
				{
					currConv = 256+(npc.objInt().item_id -64);
				}
				else
				{
					currConv=npc.npc_whoami;	
				}

				UWHUD.instance.RefreshPanels(UWHUD.HUD_MODE_CONV);
				UWHUD.instance.Conversation_tl.Clear();
				UWHUD.instance.MessageScroll.Clear();
				PlayerInput=UWHUD.instance.MessageScroll.NewUIOUt;

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
			
			
			//basep = 0;
			//stack.result_register = 1;//Set a default value
			bool finished = false;
			stack=new CnvStack(4096);
			stack.set_stackp(100);//Skip over imported memory for the moment
			stack.basep=0;

			//Import the variables
			ImportVariableMemory(npc);


			// execute one instruction
			//switch(code[stack.instrp])
			while ( (finished==false))
			{
				switch(conv[currConv].instuctions[stack.instrp])
				{
				case cnv_NOP:
					{
						break;				
					}
						

				case cnv_OPADD:
					{
						stack.Push(stack.Pop() + stack.Pop());
						break;
					}
					

				case cnv_OPMUL:
					{
						stack.Push(stack.Pop() * stack.Pop());
						break;
					}
						

				case cnv_OPSUB:
					{
						int arg1 = stack.Pop();
						int arg2 = stack.Pop();
						stack.Push(arg2 - arg1);
						break;
					}
						

				case cnv_OPDIV:
					{
						int arg1 = stack.Pop();
						int arg2 = stack.Pop();
						//if (arg1==0)
						//	throw ua_ex_div_by_zero;
						stack.Push(arg2 / arg1);
						break;
					}
						

				case cnv_OPMOD:
					{
						int arg1 = stack.Pop();
						int arg2 = stack.Pop();
						//if (arg1==0)
						//	throw ua_ex_div_by_zero;
						stack.Push(arg2 % arg1);
						break;
					}
						

				case cnv_OPOR:
					{
						stack.Push(stack.Pop() | stack.Pop());
					}
					break;

				case cnv_OPAND:
					{
						stack.Push(stack.Pop() & stack.Pop());
					}
					break;

				case cnv_OPNOT:
					{
						if (stack.Pop()==0)
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
						break;
					}
					

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
						break;
					}
						

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
						break;
					}
						

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
						break;
					}
					

				case cnv_TSTEQ:
					{
						if (stack.Pop()==stack.Pop())
						{
							stack.Push(1);
						}
						else
						{
							stack.Push(0);
						}
						break;
					}
						

				case cnv_TSTNE:
					{
						if (stack.Pop()!=stack.Pop())
						{
							stack.Push(1);
						}
						else
						{
							stack.Push(0);
						}
							//stack.Push(arg2 != arg1);
						break;
					}						

				case cnv_JMP:
					{//Debug.Log("instr = " +stack.instrp + " JMP to " +  conv[currConv].instuctions[stack.instrp+1]);
						stack.instrp = conv[currConv].instuctions[stack.instrp+1]-1;
						break;	
					}

				case cnv_BEQ:
					{
					if (stack.Pop() == 0)
						{
							stack.instrp += conv[currConv].instuctions[stack.instrp+1];	
						}

						else
						{
							stack.instrp++;	
						}
					break;
					}						

				case cnv_BNE:
					{
					if (stack.Pop() != 0)
						{
							stack.instrp += conv[currConv].instuctions[stack.instrp+1];	
						}							
					else
						{
							stack.instrp++;	
						}
						break;
					}						

				case cnv_BRA:
					{
						stack.instrp += conv[currConv].instuctions[stack.instrp+1];	
						/*int offset = conv[currConv].instuctions[stack.instrp+1];
						if (offset >0)
						{							
							stack.instrp += offset;	
						}
						else
						{		
							stack.instrp += offset;
						}*/
						break;		
					}

				case cnv_CALL: // local function
					{
						// stack value points to next instruction after call
						//Debug.Log("inst=" + stack.instrp + "stack ptr" + stack.stackptr + " new inst=" + (conv[currConv].instuctions[stack.instrp+1]-1));
						stack.Push(stack.instrp+1);
						stack.instrp = conv[currConv].instuctions[stack.instrp+1]-1;
						stack.call_level++;
						break;	
					}

				case cnv_CALLI: // imported function
					{
						int arg1 = conv[currConv].instuctions[++stack.instrp];
						for (int i=0; i<=conv[currConv].functions.GetUpperBound(0);i++)
						{
							if ((conv[currConv].functions[i].ID_or_Address==arg1) && (conv[currConv].functions[i].import_type==0x0111))
							{
								//Debug.Log("Calling function  " + arg1 + " which is currently : " + conv[currConv].functions[i].functionName );
								yield return StartCoroutine( run_imported_function(conv[currConv].functions[i] , npc));
								break;
							}
						}
						break;
					}
						

				case cnv_RET:
					{
						if (--stack.call_level<0)
						{
							// conversation ended
							finished = true;
						}
						else
						{
							//Debug.Log("instr = " +stack.instrp + " returning to " + arg1);
							stack.instrp = stack.Pop();
						}
						break;
					}
						

				case cnv_PUSHI:
					{
						//Debug.Log("Instruction:" + stack.instrp +" Pushing Immediate value :" +conv[currConv].instuctions[stack.instrp+1] + " => " + stack.stackptr);
										if  (conv[currConv].instuctions[stack.instrp+1] == 1440)
										{
												int a=0;
												a++;

										}
						stack.Push(conv[currConv].instuctions[++stack.instrp]);
						break;		
					}


				case cnv_PUSHI_EFF:
					{
						int offset =  conv[currConv].instuctions[stack.instrp+1];
						if (offset>=0)
						{
							stack.Push(stack.basep + offset);	
							
						}
						else
						{
							offset--; //to skip over base ptr;
							stack.Push(stack.basep + offset);	
						}	
						stack.instrp++;
						break;
					}


				case cnv_POP:
					{
						stack.Pop();
						break;	
					}


				case cnv_SWAP:
					{
						int arg1 = stack.Pop();
						int arg2 = stack.Pop();
						stack.Push(arg1);
						stack.Push(arg2);
						break;
					}					

				case cnv_PUSHBP:
					{
						//Debug.Log("Instruction:" + stack.instrp +" Pushing Base Ptr :" + stack.basep + " => " + stack.stackptr);							
						stack.Push(stack.basep);
						break;	
					}


				case cnv_POPBP:
					{
						int arg1 = stack.Pop();
						stack.basep = arg1;
						break;
					}						

				case cnv_SPTOBP:
					{
						stack.basep = stack.stackptr;
						break;	
					}


				case cnv_BPTOSP:
					{
						stack.set_stackp(stack.basep);
						break;	
					}


				case cnv_ADDSP:
					{
						int arg1 = stack.Pop();
						/// fill reserved stack space with dummy values
						for(int i=0; i<=arg1; i++)
							stack.Push(0);
					
					//stack.set_stackp(stack.stackptr+arg1);//This will probably cause problems down the line....
					//stack.set_stackp(stack.stackptr+arg1);
					break;
					}
						

				case cnv_FETCHM:
					{
						//Debug.Log("Instruction:" + stack.instrp +" Fetching address :" + stack.TopValue + " => " + stack.at(stack.TopValue));
						//fetch_value(arg1);
						stack.Push(stack.at(stack.Pop()));
						break;
					}
						

				case cnv_STO:
					{
						int value = stack.Pop();
						//int value = stack.at(stack.stackptr-1);
						int index = stack.Pop();
						//int index = stack.at(stack.stackptr-2);
						stack.Set(index,value);
						break;
					}
						

				case cnv_OFFSET:
					{
						int arg1 = stack.Pop();
						int arg2 = stack.Pop();
						//Debug.Log("Offset " +arg1 + " & " + arg2  + "= " + (arg1+arg2-1));
						arg1 += arg2 - 1 ;
						//Debug.Log("Instruction:" + stack.instrp +" Offset pushed : " + arg1 + " => " + stack.stackptr);

						stack.Push(arg1);
						break;
					}
						

				case cnv_START:
					{
					// do nothing
					break;		
					}

				case cnv_SAVE_REG:
					{
					stack.result_register = stack.Pop();
					break;
					}
						

				case cnv_PUSH_REG:
					{
						stack.Push(stack.result_register);
						break;
					}


				case cnv_EXIT_OP:
					{
						// finish processing (we still might be in some sub function)
						finished = true;
						break;										
					}


				case cnv_SAY_OP:
					{
						int arg1 = stack.Pop();
						yield return StartCoroutine(say_op(arg1));
						break;
					}						

				case cnv_RESPOND_OP:
					{// do nothing
						break;
					}

				case cnv_OPNEG:
					{
						stack.Push(-stack.Pop());
						break;
					}
					

				default: // unknown opcode
					//throw ua_ex_unk_opcode;
					break;
				}

				// process next instruction
				++stack.instrp;
				if (stack.instrp>conv[currConv].instuctions.GetUpperBound(0))
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
					if (Conversation.CurrentConversation == GameWorldController.instance.bGlobals[c].ConversationNo)
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

				///Return any items in the trade area to their owner
				for (int i =0; i <=3; i++)
				{
					UWHUD.instance.npcTrade[i].clear();
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
					if (npc.npc_whoami == GameWorldController.instance.bGlobals[c].ConversationNo)
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
								case "play_name":
										store_value(address,StringController.instance.AddString(conv[currConv].StringBlock,GameWorldController.instance.playerUW.CharName));break;

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
								//Debug.Log("uniplemented memory import " + conv[currConv].functions[i].functionName);
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
			if (text.Contains("@"))
			{
				text = TextSubstitute(text);
			}
				string [] Lines  = text.Split(new string [] {"\n"}, System.StringSplitOptions.None);

				for (int s=0; s<= Lines.GetUpperBound(0);s++)
				{//Lines
					string [] Paragraphs = Lines[s].Split(new string [] {"\\m"}, System.StringSplitOptions.None);

					for (int i=0; i<=Paragraphs.GetUpperBound(0);i++)
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
							UWHUD.instance.Conversation_tl.Add ( Markup + Paragraphs[i] + "</color>" ); //\n	
							if (i<Paragraphs.GetUpperBound(0))
							{
								UWHUD.instance.Conversation_tl.Add ("<color=white>MORE</color>");
								yield return StartCoroutine(WaitForMore());	
							}

					}
				}




			yield return 0;
		}


	string TextSubstitute(string input)
	{
		//X: source of variable to substitute, one of these: GSP
		//G: game global variable
		//S: stack variable
		//P: pointer variable
		//Y: type of variable, one of these: SI
		//S: value is a string number into current string block
		//I: value is an integer value
		//<num>: decimal value
		//<extension>: format: C<number>: use array index <number>
		string regexForStringReplacement="@[GSP][SI]([-+]?[0-9]*\\.?[0-9]+)";
		string regexForStringReplacementType="@[GSP][SI]";
		string regexForStringReplacementValue="([-+]?[0-9]*\\.?[0-9]+)";
		MatchCollection matches=Regex.Matches(input, regexForStringReplacement);
		for (int s = 0; s<matches.Count; s++)
		{
			if (matches[s].Success)
			{
				string ReplacementString=matches[s].Groups[0].Value;
				Match ReplacementValue =  Regex.Match(ReplacementString, regexForStringReplacementValue);
				if (ReplacementValue.Success)
				{
					int value = int.Parse(ReplacementValue.Groups[0].Value);
					//Try and find what type of replacement this is
					Match ReplacementType = Regex.Match(ReplacementString, regexForStringReplacementType);
					string FoundString="";
					if (ReplacementType.Success)
					{
						switch (ReplacementType.Groups[0].Value)
						{
						case "@GS": //Global string.
							{
								FoundString= StringController.instance.GetString(conv[currConv].StringBlock,stack.at(value));
								break;
							}
						case "@GI": //Global integer
							{
								FoundString= stack.at(value).ToString();
								break;	
							}
						case "@SS": //Stack string
							{
								FoundString= StringController.instance.GetString(conv[currConv].StringBlock,stack.at(stack.basep+value));
								break;	
							}
						case "@SI": //Stack integer
							{
								FoundString= stack.at(stack.basep+value+1).ToString();//Skip over 1 for basepointer
								break;	
							}

						case "@PS": //Pointer string
							{
								FoundString= StringController.instance.GetString(conv[currConv].StringBlock,stack.at(stack.at(stack.basep+value)));
								break;	
							}
						case "@PI": //Pointer integer
							{
								FoundString= stack.at(stack.at(stack.basep+value)).ToString();
								break;	
							}
						}
						if (FoundString!="")
						{
							Debug.Log("To Replace "+ ReplacementString + " Type=" + ReplacementType.Groups[0].Value + " value=" + value + " replacing with " + FoundString);
							input=input.Replace(ReplacementString,FoundString);
						}	
					}	
				}
			}		
		}
		return input;
	}


		IEnumerator run_imported_function(ImportedFunctions func, NPC npc)
		{
				//Debug.Log("Calling " + func.functionName);
				switch (func.functionName.ToLower())
				{
				case "babl_menu":
						{
							int[] args=new int[1];
							args[0]= stack.at(stack.stackptr-2);//ptr to value

							yield return StartCoroutine(babl_menu(args[0]));
							break;
						}

				case "babl_fmenu":
						{///FMENU appears bugged. Causes stackptr issues further down the line (see conversation 88  and door opening)
							//stack.Pop();
							int start =stack.at(stack.stackptr-2);//Not sure if this is correct for all conversations but lets try it anyway!
							int flagstart = stack.at(stack.stackptr-3);
							yield return StartCoroutine(babl_fmenu(start,flagstart));
							break;
						}

				case "babl_ask":
						{
							yield return StartCoroutine(babl_ask());
							break;
						}

				case "get_quest":
						{
								int[] args=new int[1];
								args[0]= stack.at(stack.stackptr-2);//ptr to value


							//int[] args = argsArray();
							//stack.Pop();
							//int index= stack.at(stack.Pop());
							//int index= stack.at( stack.at( stack.stackptr-2 ) );
							stack.result_register = get_quest(stack.at(args[0]));
							break;
						}

				case "set_quest":
						{
							//int[] args = argsArray();
							int[] args=new int[2];
							args[0]= stack.at(stack.stackptr-2);//ptr to value
							args[1]= stack.at(stack.stackptr-3);//ptr to value

							//int val = stack.Pop();
							//int index= stack.at(stack.Pop()); //stack.at( stack.at( stack.stackptr-5 ) );
							//stack.at( stack.at( stack.stackptr-4 ) ) ;
							set_quest(stack.at(args[0]),stack.at(args[1]));//Or the other way around.
							break;
						}

				case "print":
						{//TODO:review use of argsarray
						//int[] args = argsArray();								
						int[] args=new int[2];
						args[0]= stack.at(stack.stackptr-2);//ptr to value
						yield return StartCoroutine(say_op(stack.at(args[0]),PRINT_SAY));
						break;
						}

				case "x_skills":
						{
							int val1 = stack.Pop();
							int val2 = stack.Pop();
							int val3 = stack.Pop();
							int val4 = stack.Pop();
							stack.result_register = x_skills(val1,val2,val3,val4);//Or the other way around.
							break;
						}

				case "set_likes_dislikes":
						{
							//stack.Pop();
							//int index1= stack.Pop();
							//int index2= stack.Pop();
								int[] args=new int[2];
								args[0]= stack.at(stack.stackptr-2);//ptr to value
								args[1]= stack.at(stack.stackptr-3);//ptr to value

								set_likes_dislikes(stack.at(args[0]),stack.at(args[1]));
							break;
						}

				case "sex":
						{
							int[] args=new int[2];
							args[0]= stack.at(stack.stackptr-2);//ptr to value
							args[1]= stack.at(stack.stackptr-3);//ptr to value
							stack.result_register= sex(stack.at(args[0]),stack.at(args[1]));
							break;
						}

				case "random":
						{
						//	int[] args = argsArray();
							//stack.Pop();
							//stack.Pop();
							//int arg1=stack.Pop();
							//stack.result_register=Random.Range(1,stack.at(arg1)+1);
							int[] args=new int[1];
							args[0]= stack.at(stack.stackptr-2);//ptr to value
							stack.result_register=Random.Range(1,stack.at(args[0])+1);
							break;
						}

				case "show_inv":
						{
							//stack.Pop();
							int arg1 = stack.at(stack.stackptr-2);
							int arg2 = stack.at(stack.stackptr-3);
							stack.result_register= show_inv(arg1,arg2);

							break;
						}

				case "give_to_npc":
						{
							//stack.Pop();
							//int arg1= stack.Pop();	
							//int arg2= stack.Pop();
							int[] args=new int[2];
							args[0]= stack.at(stack.stackptr-2);//ptr to value
							args[1]= stack.at(stack.stackptr-3);//ptr to value
							stack.result_register = give_to_npc(npc, stack.at(args[0]), stack.at(args[1]));
							break;
						}

				case "take_from_npc":
						{
							//stack.Pop();
							//int arg1 = stack.Pop();
							
							int arg = stack.at(stack.stackptr-2);//ptr to value

							stack.result_register = take_from_npc(npc, stack.at(arg));
							break;
						}

				case "setup_to_barter":
						{
							//stack.Pop();
							setup_to_barter(npc);
							break;
						}

				case "do_offer":
						{//TODO:review use of argsarray
							//int noOfArgs=stack.Pop();
							//int[] args = argsArray();

							switch (stack.TopValue)//(args.GetUpperBound(0))
							{
							case 7:
								{
									int[] args=new int[7];
									args[0]= stack.at(stack.stackptr-2);//ptr to value
									args[1]= stack.at(stack.stackptr-3);//ptr to value
									args[2]= stack.at(stack.stackptr-4);//ptr to value
									args[3]= stack.at(stack.stackptr-5);//ptr to value
									args[4]= stack.at(stack.stackptr-6);//ptr to value
									args[5]= stack.at(stack.stackptr-7);//ptr to value
									args[6]= stack.at(stack.stackptr-8);//ptr to value

									yield return StartCoroutine(do_offer(npc, stack.at(args[0]), stack.at(args[1]), stack.at(args[2]), stack.at(args[3]), stack.at(args[4]), stack.at(args[5]), stack.at(args[6])));
									break;		
								}
								case 5:
								{
									int[] args=new int[5];
									args[0]= stack.at(stack.stackptr-2);//ptr to value
									args[1]= stack.at(stack.stackptr-3);//ptr to value
									args[2]= stack.at(stack.stackptr-4);//ptr to value
									args[3]= stack.at(stack.stackptr-5);//ptr to value
									args[4]= stack.at(stack.stackptr-5);//ptr to value
									yield return StartCoroutine(do_offer(npc, stack.at(args[0]), stack.at(args[1]), stack.at(args[2]), stack.at(args[3]), stack.at(args[4]),-1,-1));	
									break;
								}


							default:
								{
									Debug.Log("uniplemented version of do_offer " + stack.TopValue);
									break;		
								}
							}
						break;
						}

				case "do_demand":
						{//TODO:review use of argsarray
							//int[] args = argsArray();
							int[] args=new int[2];
							args[0]= stack.at(stack.stackptr-2);//ptr to value
							args[1]= stack.at(stack.stackptr-3);//ptr to value
							yield return StartCoroutine(do_demand(npc,stack.at(args[0]),stack.at(args[1])));
							break;
						}

				case "do_judgement":
						{
							//stack.Pop();
							yield return StartCoroutine(do_judgement(npc));
							break;
						}

				case "do_decline":
						{
							do_decline(npc);
							break;
						}

				case "gronk_door":
						{//TODO:review use of argsarray
							//int[] args = argsArray();
								//stack.Pop();//no of args
							int[] args=new int[3];
							args[0]= stack.at(stack.stackptr-2);//ptr to value
							args[1]= stack.at(stack.stackptr-3);//ptr to value
							args[2]= stack.at(stack.stackptr-4);//ptr to value
							stack.result_register=gronk_door(stack.at(args[0]),stack.at(args[1]),stack.at(args[2]));
							break;
						}


				case "x_obj_stuff":
						{//This is totally wrong!
							//x_obj_stuff( 9,locals[9], locals[8], locals[7], locals[2], locals[6], locals[5], locals[4], locals[3], param2 );

							//int[] args = argsArrayPtr();
							//	int[] args=new int[4];
								//stack.Pop();//no of args

						
								int[] args=new int[9];
								//stack.Pop();//no of args
								args[0]= stack.at(stack.stackptr-2);//ptr to value
								args[1]= stack.at(stack.stackptr-3);//ptr to value
								args[2]= stack.at(stack.stackptr-4);//ptr to value
								args[3]= stack.at(stack.stackptr-5);//ptr to value
								args[4]= stack.at(stack.stackptr-6);//ptr to value
								args[5]= stack.at(stack.stackptr-7);//ptr to value
								args[6]= stack.at(stack.stackptr-8);//ptr to value
								args[7]= stack.at(stack.stackptr-9);//ptr to value
								args[8]= stack.at(stack.stackptr-10);//ptr to value
								x_obj_stuff(args[0],args[1],args[2],args[3],args[4],args[5],args[6],args[7],args[8]);

							break;
						}

				case "find_inv":
						{//TODO:review use of argsarray
							//int[] args=argsArray();
								int[] args=new int[2];
								//stack.Pop();//no of args
							args[0]= stack.at(stack.stackptr-2);//ptr to value
							args[1]= stack.at(stack.stackptr-3);//ptr to value
							stack.result_register = find_inv(npc, stack.at(args[0]), stack.at(args[1]));
							break;
						}

				case "identify_inv":
						{

								//Pop No of args.
								//stack.Pop();
								//pop that array ptr
								// identify_inv( 4,locals,  17, 15, 16, locals[6+i] );
								int[] args=new int[4];
								//stack.Pop();//no of args
								args[0]= stack.at(stack.stackptr-2);//ptr to value
								args[1]= stack.at(stack.stackptr-3);//ptr to value
								args[2]= stack.at(stack.stackptr-4);//ptr to value
								args[3]= stack.at(stack.stackptr-5);//ptr to value
							//int[] args=argsArray();
								stack.result_register = identify_inv(args[0],args[1],args[2],args[3]) ;	
							break;
						}

				case "contains":
						{
							int[] args=new int[2];
							args[0]= stack.at(stack.stackptr-2);//ptr to value
							args[1]= stack.at(stack.stackptr-3);//ptr to value
							stack.result_register=contains(args[0],args[1]);
							break;
						}

				case "set_race_attitude":
						{
								//TODO:review use of argsarray
							//int[] args=argsArray();
							int[] args=new int[3];
							args[0]= stack.at(stack.stackptr-2);//ptr to value
							args[1]= stack.at(stack.stackptr-3);//ptr to value
							args[2]= stack.at(stack.stackptr-3);//ptr to value
							set_race_attitude(npc,stack.at(args[0]),stack.at(args[1]),stack.at(args[2]));
							break;
						}

				case "set_attitude":
						{//TODO:review use of argsarray
							//int[] args=argsArray();
							int[] args=new int[2];
							args[0]= stack.at(stack.stackptr-2);//ptr to value
							args[1]= stack.at(stack.stackptr-3);//ptr to value
							set_attitude(stack.at(args[0]),stack.at(args[1]));
							break;
						}

				case "compare":
						{//TODO:review use of argsarray
							int[] args=new int[2];
							args[0]= stack.at(stack.stackptr-2);//ptr to value
							args[1]= stack.at(stack.stackptr-3);//ptr to value
							stack.result_register= compare(stack.at(args[0]),stack.at(args[1]));
							break;
						}

				case "count_inv":
						{
							int[] args=new int[1];
							args[0]= stack.at(stack.stackptr-2);//ptr to value
							stack.result_register=count_inv(stack.at(args[0]));
							break;
						}

				case "remove_talker":
						{
							remove_talker(npc);
							break;
						}
				case "give_ptr_npc":
						{
							int[] args=new int[2];
							args[0]= stack.at(stack.stackptr-2);//ptr to value
							args[1]= stack.at(stack.stackptr-3);//ptr to value
							give_ptr_npc(npc, stack.at(args[0]),stack.at(args[1]));
							break;
						}
				case "take_from_npc_inv":
						{
							int[] args=new int[1];
							args[0]= stack.at(stack.stackptr-2);//ptr to value
							stack.result_register= take_from_npc_inv(npc, stack.at(args[0]));
							break;
						}

				case "take_id_from_npc":
						{
							int[] args=new int[1];
							args[0]= stack.at(stack.stackptr-2);//ptr to value
							stack.result_register=  take_id_from_npc(npc, stack.at(args[0]));
							break;
						}

				case "find_barter":
						{
							int[] args=new int[1];
							args[0]= stack.at(stack.stackptr-2);//ptr to value
							stack.result_register=  find_barter(stack.at(args[0]));
							break;
						}

				case "length":
						{
							int[] args=new int[1];
							args[0]= stack.at(stack.stackptr-2);//ptr to value	
							stack.result_register= length(stack.at(args[0]));
							break;
						}


				case "find_barter_total":
						{
							int[] args=new int[4];
							args[0]= stack.at(stack.stackptr-2);//ptr to value
							args[1]= stack.at(stack.stackptr-3);//ptr to value
							args[2]= stack.at(stack.stackptr-4);//ptr to value
							args[3]= stack.at(stack.stackptr-5);//ptr to value
							stack.result_register=find_barter_total(args[0],args[1],args[2],stack.at(args[3]));
							break;
						}

				case "do_inv_create":
						{
							int[] args=new int[1];
							args[0]= stack.at(stack.stackptr-2);//ptr to value
							stack.result_register= do_inv_create(stack.at(args[0]));
							break;
						}

				case "place_object":
						{
							int[] args=new int[3];
							args[0]= stack.at(stack.stackptr-2);//ptr to value
							args[1]= stack.at(stack.stackptr-3);//ptr to value
							args[2]= stack.at(stack.stackptr-4);//ptr to value	
							place_object(stack.at(args[0]),stack.at(args[1]),stack.at(args[2]));
							break;
						}

				default: 
						
						Debug.Log("Conversation : " + npc.npc_whoami + "unimplemented function " + func.functionName + " stack at " + stack.stackptr);
						break;
				}
				yield return 0;
		}

		/// <summary>
		/// Creates an array of argumenst based on the number of args in the stack and that many values..
		/// </summary>
		/// <returns>The array.</returns>
		//int [] argsArray()
		//{
		//	int noOfArgs=stack.Pop();
		//	int []args =new int[noOfArgs];
		//	int start= stack.Pop();
		//	for (int i=0; i<noOfArgs; i++)
		//	{
		//			args[i]	= stack.at(start-i);
		//	}	
		//	return args;
		//}

		/// <summary>
		/// Creates an array of argumenst based on the number of args in the stack and that many values..
		/// </summary>
		/// <returns>The array.</returns>
		int [] argsArrayPtr()
		{
			int noOfArgs=stack.Pop();
			int []args =new int[noOfArgs];
			int start= stack.Pop();
			for (int i=0; i<noOfArgs; i++)
			{
					args[i]	=start-i;
			}	
			return args;
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
								string TextLine = StringController.instance.GetString(conv[currConv].StringBlock,stack.at(i));
								if (TextLine.Contains("@"))
								{
									TextLine=TextSubstitute(TextLine);
								}
								//tl_input.Add(j++ + "." + StringController.instance.GetString(StringBlock,localsArray[i]).Replace("@GS8",GameWorldController.instance.playerUW.CharName));
								//tl_input.Add(j++ + "." + StringController.instance.GetString(StringBlock,localsArray[i]));
								//PlayerInput.text += (j++ + "." + StringController.instance.GetString(conv[currConv].StringBlock,stack.at(i))) + "\n";
								UWHUD.instance.MessageScroll.Add(j++ + "." +  TextLine + "");//  \n

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
				stack.result_register = PlayerAnswer;
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
						string TextLine = StringController.instance.GetString(conv[currConv].StringBlock,stack.at(i));
						if (TextLine.Contains("@"))
						{
								TextLine=TextSubstitute(TextLine);
						}


						bablf_array[j-1] = stack.at(i);
						//tmp = tmp + j++ + "." + StringController.instance.GetString(StringBlock,localsArray[i]) + "\n";
						UWHUD.instance.MessageScroll.Add (j++ + "." + TextLine + "");
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
			yield return StartCoroutine(say_op(bablf_array[bablf_ans-1],PC_SAY));
			//stack.result_register=bablf_array[bablf_ans-1];
			stack.result_register=PlayerAnswer;
			yield return 0;
		}


		/// <summary>
		/// Sets up for typed input
		/// </summary>
		public IEnumerator babl_ask()
		{
			PlayerTypedAnswer="";
			//tl_input.Set(">");
			PlayerInput.text=">";
			InputField inputctrl=UWHUD.instance.InputControl;
			inputctrl.gameObject.SetActive(true);
			//inputctrl.GetComponent<GuiBase>().SetAnchorX(0.08f);
			inputctrl.gameObject.GetComponent<InputHandler>().target=this.gameObject;
			inputctrl.gameObject.GetComponent<InputHandler>().currentInputMode=InputHandler.InputConversationWords;
			inputctrl.contentType= InputField.ContentType.Standard;
			inputctrl.text="";
			inputctrl.Select();
			yield return StartCoroutine(WaitForTypedInput());
			yield return StartCoroutine(say_op (PlayerTypedAnswer,PC_SAY));
			inputctrl.text="";
			UWHUD.instance.MessageScroll.Clear ();
			//stack.StringMemory=PlayerTypedAnswer;
			stack.result_register= StringController.instance.AddString(conv[currConv].StringBlock,PlayerTypedAnswer);
		}

		/// <summary>
		/// Responds to player typed input submission.
		/// </summary>
		/// <param name="PlayerTypedAnswerIN">The string the player has typed</param>
		public static void OnSubmitPickup(string PlayerTypedAnswerIN)
		{
				InputField inputctrl=UWHUD.instance.InputControl;
				WaitingForTyping=false;
				inputctrl.gameObject.SetActive(false);
				PlayerTypedAnswer= PlayerTypedAnswerIN; 
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
		/// Waits for typed input from the player when in babl_ask
		/// </summary>
		IEnumerator WaitForTypedInput()
		{
			WaitingForTyping=true;
			while (WaitingForTyping)
			{yield return null;}
		}

		/// <summary>
		/// Processes key presses from the player when waiting for input.
		/// </summary>
		void OnGUI()
		{
				if (EnteringQty==true)
				{
						return;
				}

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
		public int get_quest(int QuestNo)
		{
			return GameWorldController.instance.playerUW.quest().QuestVariables[QuestNo];
		}

		/// <summary>
		/// Sets the quest variable
		/// </summary>
		/// <param name="value">Value to change to</param>
		/// <param name="QuestNo">Quest no to change</param>
		public void set_quest(int value, int QuestNo)
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
					stack.Set(startObjectPos+j, TradeAreaOffset +  i + 1);		//Make them stand out.
					//locals[startObjectIDs+j]= pcSlot.GetObjectID();
					stack.Set(startObjectIDs+j,pcSlot.GetObjectID());
					j++;
				}
			}
			Debug.Log(j + " items saved to pos:" + startObjectPos + " w/id:" + startObjectIDs);
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
						
						int slotNo = start-1+i  - TradeAreaOffset ;//locals[start+i] ;
						if (slotNo<=3)
						{
								TradeSlot pcSlot = UWHUD.instance.playerTrade[slotNo];
								GameObject demanded = GameObject.Find (pcSlot.objectInSlot);
								//Give the item to the npc
								if (Container.GetFreeSlot(cn)!=-1)
								{
									cn.AddItemToContainer(pcSlot.objectInSlot);
									pcSlot.clear ();
									if (demanded!=null)
									{
										demanded.transform.parent=GameWorldController.instance.LevelMarker();
										GameWorldController.MoveToWorld(demanded);
										demanded.transform.position=GameWorldController.instance.InventoryMarker.transform.position;
										SomethingGiven=true;
									}
									SomethingGiven=true;
								}
								else
								{									
									if (demanded!=null)
									{
										demanded.transform.parent=GameWorldController.instance.LevelMarker();
										GameWorldController.MoveToWorld(demanded);
										demanded.transform.position=npc.transform.position;
										SomethingGiven=false;
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
				{//TODO:replace with standard transfer item functions										
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
						playerHasSpace=2;
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
		public IEnumerator  do_offer(NPC npc, int arg1, int arg2, int arg3, int arg4, int arg5, int arg6, int arg7)
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


				//PlayerAnswer = 
				int NpcAnswer=Random.Range (0,2);
				stack.result_register= NpcAnswer;
				if (NpcAnswer==1)
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
		public IEnumerator do_offer(NPC npc, int arg1, int arg2, int arg3, int arg4, int arg5, int arg6)
		{
			yield return StartCoroutine( do_offer (npc, arg1,arg2,arg3,arg4,arg5,arg6,-1) );
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
				stack.result_register=DemandResult;
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


		/// <summary>
		/// Gronks the door open
		/// </summary>
		/// <returns> appears to have something to do with if the door is broken or not.</returns>
		/// <param name="Action">close/open flag (0 means open)</param>
		/// <param name="tileY">y tile coordinate with door to open</param>
		/// <param name="tileX">x tile coordinate</param>
		public int gronk_door(int Action, int tileY, int tileX)
		{
				/*
		id=0025 name="gronk_door" ret_type=int
		parameters:   arg1: x tile coordinate with door to open
		arg2: y tile coordinate
		arg3: close/open flag (0 means open)
		description:  opens/closes door or portcullis
		return value: unknown
		return value appears to have something to do with if the door is broken or not.
		*/

				///Finds the door than needs to be opened
				///Based on the action used the door control functions as appropiate.
				GameObject dr = GameObject.Find ("door_" +tileX .ToString ("D3") + "_" + tileY.ToString ("D3"));
				if (dr!=null)
				{
						DoorControl DC = dr.GetComponent<DoorControl>();
						if (DC!=null)
						{
								if (Action==0)
								{
										DC.UnlockDoor();
										DC.OpenDoor();
								}
								else
								{
										DC.CloseDoor();
										DC.LockDoor ();
								}
								if (DC.objInt ().quality == 0)
								{
										return 0;
								}
								else
								{
										return 1;
								}
						}
						else
						{
								Debug.Log (stack.instrp+ " Unable to find doorcontrol to gronk " + " at " + tileX + " " + tileY);
								return 0;
						}

				}
				else
				{
						Debug.Log ("Unable to find door to gronk " + " at " + tileX + " " + tileY);
						return 0;
				}

				//GameObject door = Var.findDoor(Var.triggerX,Var.triggerY);
		}



		public void x_obj_stuff(int arg1, int arg2, int arg3, int link, int arg5, int owner, int quality, int item_id, int pos)
		{
				//Debug.Log("x_obj_stuff");		
				//id=002f name="x_obj_stuff" ret_type=void
				//	parameters:   arg1: not used in uw1
				//		arg2: not used in uw1
				//		arg3: 0, (upper bit of quality field?)
				//		arg4: quantity/special field, 115
				//		arg5: not used in uw1
				//		arg6: not used in uw1
				//		arg7: quality?
				//		arg8: identified flag? or is it owner or item_id
				//		arg9: position in inventory object list
				//		description:  sets object properties for object in inventory object list.
				//			if a property shouldn't be set, -1 is passed for the
				//         property value.
				//If -1 then it returns the value in the array?
				/*This may be implemented wrongly*/

			ObjectInteraction obj=null;

			
			pos = stack.at(pos);

			if (pos>=TradeAreaOffset)//Item is in a trade slot
			{
				pos -=TradeAreaOffset;//Take the offset off to get back to a trade slot.
				pos--;
				if (pos<0)
				{
					return;
				}
				if (pos<=3)
				{//Item is in players trade area.
					obj= UWHUD.instance.playerTrade[pos].GetGameObjectInteraction();

				}
				else if (pos <=7)
				{//item in npc trade area
					obj= UWHUD.instance.npcTrade[pos-4].GetGameObjectInteraction();					
				}	
			}
			else
			{//Item is in the object masterlist
				obj = GameWorldController.instance.CurrentObjectList().objInfo[pos].instance;
			}		



			if (obj==null)
			{
				return;
			}

			if (stack.at(link)<=0)
			{
					//locals[link]=obj.link-512; 
				stack.Set(link, obj.link-512);
			}
			else
			{
					//obj.link=locals[link]+512;
				obj.link = stack.at(link)+512; 
			}

			if (stack.at(owner)<=0)	
			{
				stack.Set(owner, obj.owner);
			}
			else
			{
				obj.owner=stack.at(owner);
			}


			if (stack.at(quality)<=0)	
			{
				//locals[quality]=obj.quality; 
				stack.Set(quality, obj.quality);
			}
			else
			{
				obj.quality=stack.at(quality);
			}
			if (stack.at(item_id)<=0)
			{
					//locals[id]=obj.item_id; 
				stack.Set(item_id, obj.item_id);
			}
			//else
			//{
			//	obj.item_id=stack.at(item_id);
			//}

		}





	/// <summary>
	/// Finds item in PC or NPC inventory
	/// </summary>
	/// <returns>position in master object list, or 0 if not found</returns>
	/// <param name="unk1">Unk1.</param>
	/// <param name="arg1">0: npc inventory; 1: player inventory</param>
	/// <param name="item_id">Item type ID of the object to find.</param>
	public int find_inv(NPC npc, int targetInventory, int item_id )
	{
		//id=0030 name="find_inv" ret_type=int
		//	parameters:   arg1: 0: npc inventory; 1: player inventory
		//	arg2: item id
		//		description:  searches item in npc or player inventory
		//		return value: position in master object list, or 0 if not found
		switch (targetInventory)
		{
		case 0://NPC inventory
			{
				Container npcCont = npc.gameObject.GetComponent<Container>();

				for ( int i=0; i<npcCont.Capacity; i++)
				{
					GameObject obj = npcCont.GetGameObjectAt(i);
					if (obj!=null)
					{
						if (obj.GetComponent<ObjectInteraction>().item_id==item_id)
						{
								//return 1;//Found object
							return obj.GetComponent<ObjectInteraction>().objectloaderinfo.index;
						}
					}
				}	
				break;
			}
			
		case 1://PC Search
				{
				Debug.Log("PC version of find_inv."); //will happen in judy's conversation
				string itemname =	GameWorldController.instance.playerUW.GetComponent<Container>().findItemOfType(item_id);
				GameObject obj= GameObject.Find(itemname);

				if (obj!=null)
				{
						//return 1;
						return obj.GetComponent<ObjectInteraction>().objectloaderinfo.index;
				}
				else
				{
						return 0;
				}	
			}

		}
		return 0;
	}


	/// <summary>
	/// Identifies the item at the specified trade slot
	/// </summary>
	/// <param name="unk1">Unk1.</param>
	/// <param name="unk2">Unk2.</param>
	/// <param name="unk3">ItemId Sets the item id of the item into the locals array</param>
	/// <param name="unk4">Unk4.</param>
	/// <param name="inventorySlotIndex">Trade slot index.</param>
	public int identify_inv(int pUNK1, int pUNK2, int pUNK3, int pTradeSlot)
	{
			//id=0017 name="identify_inv" ret_type=int
			//	parameters:   arg1:
			//arg2:
			//arg3:
			//arg4: inventory item position
			//description:  unknown TODO
			//return value: unknown
			int tradeSlotIndex = stack.at(pTradeSlot);
			if (tradeSlotIndex<=0)
			{
				return 0;
			}
			tradeSlotIndex--;//adjust to match my 0-based indices
			if (UWHUD.instance.playerTrade[tradeSlotIndex].GetGameObjectInteraction() != null)
			{
					//UWHUD.instance.playerTrade[tradeSlotIndex].GetGameObjectInteraction().isIdentified=true;	
					//locals[ItemId]=-UWHUD.instance.playerTrade[tradeSlotIndex].GetGameObjectInteraction().item_id;//Set as minus to flag this a an item id for string replacement
					//return GameWorldController.instance.commobj.Value[UWHUD.instance.playerTrade[tradeSlotIndex].GetGameObjectInteraction().item_id];//Should this be the value of the item.
				int unitValue = GameWorldController.instance.commonObject.properties[UWHUD.instance.playerTrade[tradeSlotIndex].GetGameObjectInteraction().item_id].Value;
				int qty =UWHUD.instance.playerTrade[tradeSlotIndex].GetGameObjectInteraction().GetQty(); 

				return unitValue*qty;
			}
			else
			{
					return 0;
			}
	}


	/// <summary>
	/// checks if the first string contains the second string,
	/// </summary>
	/// <returns>returns 1 when the string was found, 0 when not</returns>
	public int contains(int pString1, int pString2)
	{//pString2 is the string memory.
		//id=0007 name="contains" ret_type=int
		//parameters:   arg1: pointer to first string id
		//arg2: pointer to second string id
		//description:  checks if the first string contains the second string,
		//case-independent.
		//return value: returns 1 when the string was found, 0 when not
		string String2 = StringController.instance.GetString(conv[currConv].StringBlock, stack.at(pString2));
		string String1 = StringController.instance.GetString(conv[currConv].StringBlock, stack.at(pString1));
		if (String1=="")
		{
			return 0;//no cheating...
		}
		if (String2.ToUpper().Contains(String1.ToUpper()))
		{
			return 1;
		}
		else
		{
			return 0;
		}
	}


		/// <summary>
		/// Sets the race attitude.
		/// </summary>
		/// <param name="unk1">Unk1.</param>
		/// <param name="gtarg">Gtarg.</param>
		/// <param name="attitude">Attitude.</param>
		/// <param name="unk2">Unk2.</param>
		/// Seems to set attitude for all npcs with the whoami of the same value.
		public void set_race_attitude(NPC npc, int unk1, int attitude, int unk2)
		{
			//Used in Bandit chief conversation Level3
			//id=0026 name="set_race_attitude" ret_type=void
			//parameters:   unknown
			//description:  sets attitude for a whole race (?)
			//Seems to set attitude for all npcs with the whoami of the same value.
			//Debug.Log ("set_race_attitude " + attitude);
		/*	NPC[] foundNPCs=GameWorldController.instance.LevelMarker().GetComponentsInChildren<NPC>();
			for (int i=0; i<foundNPCs.GetUpperBound(0);i++)
			{
				if (foundNPCs[i].npc_whoami== npc.npc_whoami)
				{
					Debug.Log("Setting attitude= " + attitude + " for " + foundNPCs[i].name);
					foundNPCs[i].npc_attitude=attitude;
					foundNPCs[i].npc_gtarg=gtarg;
				}
			}*/

			Debug.Log(npc.name + " Set Race attitude " + unk1 + " " + attitude + " " + unk2);
		}


	/// <summary>
	/// Sets the attitude of a target NPC
	/// </summary>
	/// <param name="Attitude">Attitude.</param>
	/// <param name="target_whoami">The NPC whoami to find</param>
	public void set_attitude(int attitude, int target_whoami)
	{

		NPC[] foundNPCs=GameWorldController.instance.LevelMarker().GetComponentsInChildren<NPC>();
		for (int i=0; i<foundNPCs.GetUpperBound(0);i++)
		{
			if (foundNPCs[i].npc_whoami == target_whoami)
			{
				foundNPCs[i].npc_attitude=attitude;
			}
		}
	}


	/// <summary>
	/// compares strings for equality, case independent
	/// </summary>
	/// <returns>returns 1 when strings are equal, 0 when not</returns>
	/// <param name="unk1">Unk1.</param>
	/// <param name="StringIndex">String index.</param>
	/// <param name="StringIn">String in.</param>
	public int compare(int StringIndex1,  int StringIndex2)
	{
		//id=0004 name="compare" ret_type=int
		//	parameters:   arg1: string id
		//	arg2: string id
		//	description:  compares strings for equality, case independent
		//	return value: returns 1 when strings are equal, 0 when not
		//Debug.Log("Comparing :" + StringController.instance.GetString(conv[currConv].StringBlock,StringIndex1).ToUpper() + " to " + StringController.instance.GetString(conv[currConv].StringBlock,StringIndex2).ToUpper() );
		//In this implemention I get the string at stringindex compare with string memory (i'm assuming I'm only comparing with babl_ask)
		if (StringController.instance.GetString(conv[currConv].StringBlock,StringIndex1).ToUpper() == StringController.instance.GetString(conv[currConv].StringBlock,StringIndex2).ToUpper())
		{
			return 1;
		}
		else
		{
			return 0;
		}
	}


	/// <summary>
	/// counts number of items in inventory position.
	/// </summary>
	/// <returns>item number</returns>
	/// <param name="ItemPos">Item position.</param>
	public int count_inv(int ItemPos)
	{
		//id=001e name="count_inv" ret_type=int
		//parameters:   unknown
		//description:  counts number of items in inventory
		//return value: item number
		int total =0;
				if (ItemPos>=TradeAreaOffset)
				{
					ItemPos = ItemPos - TradeAreaOffset;	
				}

				if (ItemPos<0){return 0;}
		GameObject objInslot = GameObject.Find(UWHUD.instance.playerTrade[ItemPos].objectInSlot);
		if (objInslot!=null)
		{
			ObjectInteraction objInt = objInslot.GetComponent<ObjectInteraction>();
			if (objInt!=null)
			{
				return objInt.GetQty();
			}
		}
		return total;
	}



	/// <summary>
	///  removes npc the player is talking to (?)
	/// </summary>
	public void remove_talker(NPC npc)
	{
			//   id=002a name="remove_talker" ret_type=void
			//parameters:   none
			//		description:  removes npc the player is talking to (?)
		npc.gameObject.transform.position = GameWorldController.instance.playerUW.playerInventory.InventoryMarker.transform.position;//new Vector3(99f*1.2f, 3.0f, 99*1.2f);//Move them to the inventory box
	}


	/// <summary>
	/// Copies item from player inventory to npc inventory
	/// </summary>
	/// <param name="unk1">Unk1.</param>
	/// <param name="Quantity">Quantity.</param>
	/// <param name="slotNo">Slot no.</param>
	public void give_ptr_npc(NPC npc, int Quantity, int slotNo)
	{
		/*
id=0014 name="give_ptr_npc" ret_type=int
parameters:   arg1: quantity (?), or -1 for ignore
arg2: inventory object list pos
description:  copies item from player inventory to npc inventory
return value: none
*/
		slotNo--;
		//Debug.Log ("give_ptr_npc");
		if  ( (slotNo<0) || (slotNo >3))
		{
			return;
		}
		Container cn =npc.gameObject.GetComponent<Container>();

			
		if (UWHUD.instance.playerTrade[slotNo].objectInSlot !="")
		{
			GameObject objGiven = GameObject.Find (UWHUD.instance.playerTrade[slotNo].objectInSlot);
			if ((Quantity==-1))
			{
				objGiven.transform.parent=GameWorldController.instance.LevelMarker().transform;
				cn.AddItemToContainer(UWHUD.instance.playerTrade[slotNo].objectInSlot);
				GameWorldController.MoveToWorld(objGiven.GetComponent<ObjectInteraction>());
				UWHUD.instance.playerTrade[slotNo].clear ();
				GameWorldController.instance.playerUW.playerInventory.Refresh();
			}
			else
			{//Clone the object and give the clone to the npc
				//
				if (objGiven!=null)
				{
					if  ((objGiven.GetComponent<ObjectInteraction>().isQuant()==true)
							&& 
							(objGiven.GetComponent<ObjectInteraction>().link>1)
							&&
							(objGiven.GetComponent<ObjectInteraction>().isEnchanted()==false)
							&&
							(objGiven.GetComponent<ObjectInteraction>().link!=Quantity)
					)
					{//Object is a quantity or is a quantity less than the number already there.
						GameObject Split = Instantiate(objGiven.gameObject);//What we are picking up.
						Split.GetComponent<ObjectInteraction>().link =Quantity;
						
						objGiven.GetComponent<ObjectInteraction>().link=objGiven.GetComponent<ObjectInteraction>().link-Quantity;
						
						GameWorldController.MoveToWorld(objGiven.GetComponent<ObjectInteraction>());
												//Split.name = Split.name+"_"+GameWorldController.instance.playerUW.summonCount++;
						Split.name = ObjectLoader.UniqueObjectName(Split.GetComponent<ObjectInteraction>().objectloaderinfo);//(objGiven.GetComponent<ObjectInteraction>()
						cn.AddItemToContainer(objGiven.name);
					}
					else
					{//Object is not a quantity or is the full amount.
						cn.AddItemToContainer(UWHUD.instance.playerTrade[slotNo].objectInSlot);
						objGiven.transform.parent=GameWorldController.instance.LevelMarker().transform;						
						GameWorldController.MoveToWorld(objGiven.GetComponent<ObjectInteraction>());
						GameWorldController.instance.playerUW.playerInventory.Refresh();
						UWHUD.instance.playerTrade[slotNo].clear ();
					}
				}
			}
		}
	}


	/// <summary>
	/// transfers item to player, per id (?)
	/// </summary>
	/// <returns>1: ok, 2: player has no space left</returns>
	/// <param name="unk1">Unk1.</param>
	/// <param name="ItemPos">Item position.</param>
	public int take_id_from_npc(NPC npc, int index)
	{
		//id=0016 name="take_id_from_npc" ret_type=int
		//parameters:   arg1: inventory object list pos (from take_from_npc_inv)
		//description:  transfers item to player, per id (?)
		//return value: 1: ok, 2: player has no space left
		string ItemName = GameWorldController.instance.CurrentObjectList().objInfo[index].instance.name;
		int playerHasSpace=1;
		Container playerContainer = GameWorldController.instance.playerUW.gameObject.GetComponent<Container>();
		Container npcContainer = npc.GetComponent<Container>();

		GameObject obj = GameObject.Find(ItemName);
		if (obj==null){return 1;}

				//Give to PC
		if (Container.GetFreeSlot(playerContainer)!=-1)//Is there space in the container.
		{						
			npc.GetComponent<Container>().RemoveItemFromContainer(obj.name);
			playerContainer.AddItemToContainer(obj.name);
			obj.transform.parent=GameWorldController.instance.InventoryMarker.transform;
			obj.GetComponent<ObjectInteraction>().PickedUp=true;
			GameWorldController.instance.playerUW.GetComponent<PlayerInventory>().Refresh ();
			playerHasSpace=1;
		}
		else
		{
			playerHasSpace=2;
			obj.transform.parent=GameWorldController.instance.LevelMarker();
			GameWorldController.MoveToWorld(obj);
			obj.transform.position=npc.transform.position;
			npc.GetComponent<Container>().RemoveItemFromContainer(obj.name);
		}
		return playerHasSpace;
	}


	/// <summary>
	/// Gets the index of the item in the specified slot of the NPC inventory (I think)
	/// </summary>
	/// <returns>The object list index of the item</returns>
	/// <param name="arg1">Arg1.</param>
	public int take_from_npc_inv(NPC npc, int pos)
	{
		pos--;
		GameObject obj=npc.GetComponent<Container>().GetGameObjectAt(pos);
		if (pos!=null)
		{
			return obj.GetComponent<ObjectInteraction>().objectloaderinfo.index;
		}
		return 0;
	}


	/// <summary>
	/// searches for item in barter area
	/// </summary>
	/// <returns>This returns slot number + 1. Take this into account when retrieving the items in later functions</returns>
	/// <param name="unk1">Unk1.</param>
	/// <param name="itemID">item id to find</param>
	public int find_barter(int itemID)
	{//This returns slot number + 1. Take this into account when retrieving the items in later functions
		//id=0031 name="find_barter" ret_type=int
		//	parameters:   arg1: item id to find
		//	description:  searches for item in barter area
		//	return value: returns pos in inventory object list, or 0 if not found
		// if arg1 > 1000 return Item Category is = + (arg1-1000)*16);
		for (int i = 0; i<4; i++)
		{
			if (UWHUD.instance.playerTrade[i].isSelected())
			{
				ObjectInteraction objInt = UWHUD.instance.playerTrade[i].GetGameObjectInteraction();
				if (objInt!=null)
				{					
					if (itemID<1000)
					{
						if (objInt.item_id== itemID)
						{
							return i+1;
														//return 1;
						}
					}
					else
					{
						if ((objInt.item_id>= (itemID-1000)*16) && (objInt.item_id< ((itemID+1)-1000)*16))
						{
							return i+1;
														//return 1;
						}
					}
				}
			}

		}

		return 0;
	}


		/// <summary>
		/// Length of the specified string.
		/// </summary>
		/// <param name="str">String.</param>
		public int length(int str)
		{
			//id=000b name="length" ret_type=int
			//	parameters:   arg1: string id
			//	description:  calculates length of string
			//	return value: length of string
			return StringController.instance.GetString(conv[currConv].StringBlock, str).Length;
		}


		/// <summary>
		/// Gets the string no that identifies this players gender.
		/// </summary>
		/// <param name="unknown">Unknown.</param>
		/// <param name="ParamFemale">female string</param>
		/// <param name="ParamMale">male string</param>
		public int sex(int ParamFemale, int ParamMale)
		{
			if (GameWorldController.instance.playerUW.isFemale==true)
			{
				return ParamFemale;
			}
			else
			{
				return ParamMale;
			}
		}



		/// <summary>
		/// Finds the barter total.
		/// </summary>
		/// <returns>The barter total.</returns>
		/// <param name="unk1">Unk1.</param>
		/// <param name="ptrCount">Ptr count.</param>
		/// <param name="ptrSlot">Ptr slot.</param>
		/// <param name="ptrNoOfSlots">Ptr no of slots.</param>
		/// <param name="item_id">Item identifier.</param>
		/// <param name="variables">Variables.</param>
		/// My implementation 
		/// find the total number of matching items
		/// keep a list of slots where they are found
		/// keep a number of found slots.
		public int find_barter_total( int ptrCount, int ptrSlot, int ptrNoOfSlots, int item_id )
		{
				/*
   id=0032 name="find_barter_total" ret_type=int
   parameters:   s[0]: ???
                 s[1]: pointer to number of found items
                 s[2]: pointer to
                 s[3]: pointer to
                 s[4]: pointer to item ID to find
   description:  searches for item in barter area
   return value: 1 when found (?)
	*/
			ObjectInteraction objInt=null;
			int slotFoundCounter=0;
			stack.Set(ptrNoOfSlots,0);
			for (int i = 0; i<4; i++)
			{
				if (UWHUD.instance.playerTrade[i].isSelected())
				{
					objInt = UWHUD.instance.playerTrade[i].GetGameObjectInteraction();

					if (objInt!=null)
					{
						Debug.Log(objInt.item_id);
						int founditem_id=objInt.item_id;
						int itemqt = objInt.GetQty();
						Debug.Log(itemqt);

						if (item_id==founditem_id)
						{
						stack.Set(ptrCount, stack.at(ptrCount) + itemqt);
						stack.Set(ptrSlot+slotFoundCounter++,(TradeAreaOffset+i+1));
						stack.Set(ptrNoOfSlots, stack.at(ptrNoOfSlots) + 1);

						}
					}
					//	if (item_id<1000)
					//	{
							//if (objInt.item_id== item_id)
							//{
													//	Debug.Log("fuck1")						;
								//Debug.Log(objInt.GetQty());
													//	Debug.Log("fuck2")						;

								//stack.Set(ptrCount, stack.at(ptrCount) + objInt.GetQty());
								//stack.StackValues[ptrCount]+= objInt.GetQty();
								//stack.Set(ptrSlot+slotFoundCounter++,(TradeAreaOffset+i));
								//stack.StackValues[ptrSlot+slotFoundCounter++] = (TradeAreaOffset+i);
								//stack.Set(ptrNoOfSlots, stack.at(ptrNoOfSlots) + 1);
								//stack.StackValues[ptrNoOfSlots]++;

							//}
						//}
				//		else
				//		{
				//			if ((objInt.item_id>= (item_id-1000)*16) && (objInt.item_id< ((item_id+1)-1000)*16))
				//			{
				//				stack.Set(ptrCount, stack.at(ptrCount) + objInt.GetQty());
				//				stack.Set(ptrSlot+slotFoundCounter++,(TradeAreaOffset+i));
				//				stack.Set(ptrNoOfSlots, stack.at(ptrNoOfSlots) + 1);
				//			}
				//		}
				//	}		
				}
			}
			return stack.StackValues[ptrCount];
		}



	/// <summary>
	/// creates item in npc inventory
	/// </summary>
	/// <returns>inventory object list position</returns>
	/// <param name="unk1">Unk1.</param>
	/// <param name="item_id">Item identifier.</param>
	public int do_inv_create(int item_id)
	{
		//id=001a name="do_inv_create" ret_type=int
		//parameters:   arg1: item id
		//description:  creates item in npc inventory
		//return value: inventory object list position

		ObjectLoaderInfo newobjt= ObjectLoader.newObject(item_id,0,0,0);
		GameObject myObj= ObjectInteraction.CreateNewObject(GameWorldController.instance.currentTileMap(),newobjt, GameWorldController.instance.LevelMarker().gameObject,GameWorldController.instance.InventoryMarker.transform.position).gameObject;
		GameWorldController.MoveToWorld(myObj.GetComponent<ObjectInteraction>());
		//Container npccont = npc.GetComponent<Container>();
		//if(npccont!=null)
		//{
			//npccont.AddItemToContainer (myObj.name);
			/*for (int i =0; i<4;i++)
			{
				if (UWHUD.instance.npcTrade[i].objectInSlot=="")
				{
					//NPCTradeItems[i]=myObj.name;
					TradeSlot ts = UWHUD.instance.npcTrade[i];
					ts.objectInSlot=myObj.name;
					ts.SlotImage.texture=myObj.GetComponent<ObjectInteraction>().GetInventoryDisplay().texture;
					return i;
				}
			}*/
		//}
		return myObj.GetComponent<ObjectInteraction>().objectloaderinfo.index;
	}



		/// <summary>
		///  places a generated object in underworld
		/// </summary>
		/// <param name="unk1">Unk1.</param>
		/// <param name="tileY">Tile y.</param>
		/// <param name="tileX">Tile x.</param>
		/// <param name="invSlot">inventory item slot number (from do_inv_create)</param>
		public void place_object(int tileY, int tileX, int index )
		{
			/*
id=0027 name="place_object" ret_type=void
parameters:   arg1: x tile pos
         arg2: y tile pos
         arg3: inventory item slot number (from do_inv_create)
description:  places a generated object in underworld
         used in Judy's conversation, #23

			*/
			ObjectInteraction objInt=GameWorldController.instance.CurrentObjectList().objInfo[index].instance;
			if (objInt!=null)
			{
				//string objName = UWHUD.instance.npcTrade[invSlot].objectInSlot;
				GameObject obj = objInt.gameObject;

				obj.transform.position=GameWorldController.instance.currentTileMap().getTileVector(tileX,tileY);
				//obj.transform.parent=GameWorldController.instance.LevelMarker();
				//GameWorldController.MoveToWorld(obj);
				//npc.GetComponent<Container>().RemoveItemFromContainer(objInt.name);
				//UWHUD.instance.npcTrade[invSlot].clear();
			}
			return;
		}
}
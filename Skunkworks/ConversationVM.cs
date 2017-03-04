using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ConversationVM : MonoBehaviour {
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

	public Text Output;
	public Text PlayerInput;
	public int convtodisplay=0;
	public int defaultResult;

	public int MaxAnswer;


	public int[] QuestVariables= new int[32];//placeholder

	struct ImportedFunctions{
		//0000   Int16   length of function name
		//0002   n*char  name of function
		public string functionName;
		//n+02   Int16   ID (imported func.) / memory address (variable)
		public int ID_or_Address;
	//	n+04   Int16   unknown, always seems to be 1
		public int import_type;//n+06   Int16   import type (0x010F=variable, 0x0111=imported func.)
		public int return_type; //n+08   Int16   return type (0x0000=void, 0x0129=int, 0x012B=string)


	}

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
	char[] cnv_ark;

	public string Path; //to cnv.ark
	public string StringsPath; //to strings.pak

	public StringController stringcontrol;



	CnvStack stack;
	public int call_level=1;
	public int instrp=0;
	public int basep = 0;
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



	// Use this for initialization
	void Start () {
		stringcontrol=new StringController();
		stringcontrol.LoadStringsPak(StringsPath);
		LoadCnvArk(Path);
	}
	


	void LoadCnvArk(string cnv_ark_path)
		{
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


	public void DisplayInstructionSet()
		{
		string result="";
		//if (conv[convtodisplay]!=null)
		//	{
			for (int z=0; z <conv[convtodisplay].CodeSize;z++)
				{
				switch(conv[convtodisplay].instuctions[z])
					{
					case cnv_NOP: result += z + ":" +"NOP\n";break;
					case cnv_OPADD: result += z + ":" +"OPADD\n";break;
					case cnv_OPMUL: result += z + ":" +"OPMUL\n";break;
					case cnv_OPSUB: result += z + ":" +"OPSUB\n";break;
					case cnv_OPDIV: result += z + ":" +"OPDIV\n";break;
					case cnv_OPMOD: result += z + ":" +"OPMOD\n";break;
					case cnv_OPOR: result += z + ":" +"OPOR\n";break;
					case cnv_OPAND: result += z + ":" +"OPAND\n";break;
					case cnv_OPNOT: result += z + ":" +"OPNOT\n";break;
					case cnv_TSTGT: result += z + ":" +"TSTGT\n";break;
					case cnv_TSTGE: result += z + ":" +"TSTGE\n";break;
					case cnv_TSTLT: result += z + ":" +"TSTLT\n";break;
					case cnv_TSTLE: result += z + ":" +"TSTLE\n";break;
					case cnv_TSTEQ: result += z + ":" +"TSTEQ\n";break;
					case cnv_TSTNE: result += z + ":" +"TSTNE\n";break;
					case cnv_JMP: result += z + ":" +"JMP "; z++; result += z + ":" + " "+ conv[convtodisplay].instuctions[z] + "\n";break;
			case cnv_BEQ: result += z + ":" +"BEQ "; z++; result += z + ":" + " "+ conv[convtodisplay].instuctions[z] + "\n";break;
			case cnv_BNE: result += z + ":" +"BNE "; z++; result += z + ":" + " "+ conv[convtodisplay].instuctions[z] + "\n";break;
			case cnv_BRA: result += z + ":" +"BRA "; z++; result += z + ":" + " "+ conv[convtodisplay].instuctions[z] + "\n";break;
			case cnv_CALL: result += z + ":" +"CALL "; z++; result += z + ":" + " "+conv[convtodisplay].instuctions[z] + "\n";break;
			case cnv_CALLI: result += z + ":" +"CALLI "; z++; result += z + ":" + " "+ conv[convtodisplay].instuctions[z] + "\n";break;
					case cnv_RET: result += z + ":" +"RET\n";break;
			case cnv_PUSHI: result += z + ":" +"PUSHI "; z++; result += z + ":" +" "+ conv[convtodisplay].instuctions[z] + "\n";break;
			case cnv_PUSHI_EFF: result += z + ":" +"PUSHI_EFF "; z++; result += z + ":" + " "+ conv[convtodisplay].instuctions[z] + "\n";break;
					case cnv_POP: result += z + ":" +"POP\n";break;
					case cnv_SWAP: result += z + ":" +"SWAP\n";break;
					case cnv_PUSHBP: result += z + ":" +"PUSHBP\n";break;
					case cnv_POPBP: result += z + ":" +"POPBP\n";break;
					case cnv_SPTOBP: result += z + ":" +"SPTOBP\n";break;
					case cnv_BPTOSP: result += z + ":" +"BPTOSP\n";break;
					case cnv_ADDSP: result += z + ":" +"ADDSP\n";break;
					case cnv_FETCHM: result += z + ":" +"FETCHM\n";break;
					case cnv_STO: result += z + ":" +"STO\n";break;
					case cnv_OFFSET: result += z + ":" +"OFFSET\n";break;
					case cnv_START: result += z + ":" +"START\n";break;
					case cnv_SAVE_REG: result += z + ":" +"SAVE_REG\n";break;
					case cnv_PUSH_REG: result += z + ":" +"PUSH_REG\n";break;
					case cnv_STRCMP: result += z + ":" +"STRCMP\n";break;
					case cnv_EXIT_OP: result += z + ":" +"EXIT_OP\n";break;
					case cnv_SAY_OP: result += z + ":" +"SAY_OP\n";break;
					case cnv_RESPOND_OP: result += z + ":" +"RESPOND_OP\n";break;
					case cnv_OPNEG: result += z + ":" +"OPNEG\n";break;
					}
				}
			//}
		Output.text=result;
		}


	public void RunConversation()
		{
		StartCoroutine(RunConversationVM());
		}

	public IEnumerator RunConversationVM() 
		{
		call_level=1;
		instrp=0;
		basep = 0;
		result_register = defaultResult;
		bool finished = false;
		stack=new CnvStack(4096);
		stack.set_stackp(100);//Skip over imported memory for the moment
		// execute one instruction
		//switch(code[instrp])
		while ( (finished==false))
			{
			switch(conv[convtodisplay].instuctions[instrp])
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
				instrp = conv[convtodisplay].instuctions[instrp+1]-1;
				break;

			case cnv_BEQ:
					{
					int arg1 = stack.Pop();
					if (arg1 == 0)
						instrp += conv[convtodisplay].instuctions[instrp+1];
					else
						instrp++;
					}
				break;

			case cnv_BNE:
					{
					int arg1 = stack.Pop();
					if (arg1 != 0)
						instrp += conv[convtodisplay].instuctions[instrp+1];
					else
						instrp++;
					}
				break;

			case cnv_BRA:
				instrp += conv[convtodisplay].instuctions[instrp+1];
				break;

			case cnv_CALL: // local function
				// stack value points to next instruction after call
				//Debug.Log("inst=" + instrp + "stack ptr" + stack.stackptr + " new inst=" + (conv[convtodisplay].instuctions[instrp+1]-1));
				stack.Push(instrp+1);
				instrp = conv[convtodisplay].instuctions[instrp+1]-1;
				call_level++;
				break;

			case cnv_CALLI: // imported function
					{
					int arg1 = conv[convtodisplay].instuctions[++instrp];
					for (int i=0; i<=conv[convtodisplay].functions.GetUpperBound(0);i++)
						{
						if ((conv[convtodisplay].functions[i].ID_or_Address==arg1) && (conv[convtodisplay].functions[i].import_type==0x0111))
							{
							//Debug.Log("Calling function  " + arg1 + " which is currently : " + conv[convtodisplay].functions[i].functionName );
							yield return StartCoroutine( run_imported_function(conv[convtodisplay].functions[i]));
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
						//Debug.Log("instr = " +instrp + " retuning to " + arg1);
						instrp = arg1;
						}
					}
				break;

			case cnv_PUSHI:
				stack.Push(conv[convtodisplay].instuctions[++instrp]);
				break;

			case cnv_PUSHI_EFF:
				stack.Push(basep + conv[convtodisplay].instuctions[++instrp]);
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
				stack.Push(basep);
				break;

			case cnv_POPBP:
					{
					int arg1 = stack.Pop();
					basep = arg1;
					}
				break;

			case cnv_SPTOBP:
				basep = stack.get_stackp();
				break;

			case cnv_BPTOSP:
				stack.set_stackp(basep);
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
			if (instrp>conv[convtodisplay].instuctions.GetUpperBound(0))
				{
				finished=true;
				}
			}
		
		}


	void store_value(int at, int val)
		{

		}

	void fetch_value(int at)
		{

		}

	IEnumerator say_op(int arg1)
		{
		//Debug.Log( stringcontrol.GetString(conv[convtodisplay].StringBlock,arg1));
		Output.text += stringcontrol.GetString(conv[convtodisplay].StringBlock,arg1) + "\n";
		yield return 0;
		}



	IEnumerator run_imported_function(ImportedFunctions func)
		{
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
				say_op(stack.Pop());
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
		PlayerInput.text="";
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
				PlayerInput.text += (j++ + "." + stringcontrol.GetString(conv[convtodisplay].StringBlock,stack.at(i))) + "\n";
				MaxAnswer++;
				}
			else
				{
				break;
				}
			}
		yield return StartCoroutine(WaitForInput());
		int AnswerIndex=stack.at(Start+PlayerAnswer-1);
		yield return StartCoroutine(say_op(AnswerIndex));
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
		Debug.Log("babl_fmenu - " + Start + " " + flagIndex);
		//tl_input.Clear();
		PlayerInput.text="";
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
					PlayerInput.text += (j++ + "." + stringcontrol.GetString(conv[convtodisplay].StringBlock,stack.at(i))) + "\n";
					MaxAnswer++;
					}
				}
			else
				{
				break;
				}
			}
		yield return StartCoroutine(WaitForInput());
		//tmp= StringController.instance.GetString (stringcontrol.GetString(conv[convtodisplay].StringBlock,bablf_array[bablf_ans-1]);
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
		return QuestVariables[QuestNo];
		}

	/// <summary>
	/// Sets the quest variable
	/// </summary>
	/// <param name="unk">Unk.</param>
	/// <param name="value">Value to change to</param>
	/// <param name="QuestNo">Quest no to change</param>
	public void set_quest(int unk,int value, int QuestNo)
		{
		QuestVariables[QuestNo]=value;
		}
	



}

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
	public int convtodisplay=0;

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


	cnvHeader[] headers;
	char[] cnv_ark;

	public string Path; //to cnv.ark
	public string StringsPath; //to strings.pak

	public StringController stringcontrol;

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
				headers=new cnvHeader[NoOfConversations];
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
						headers[i].CodeSize=(int)DataLoader.getValAtAddress(cnv_ark,add_ptr+0x4,16);
						headers[i].StringBlock=(int)DataLoader.getValAtAddress(cnv_ark,add_ptr+0xA,16);
						headers[i].NoOfMemorySlots=(int)DataLoader.getValAtAddress(cnv_ark,add_ptr+0xC,16);
						headers[i].NoOfImportedGlobals=(int)DataLoader.getValAtAddress(cnv_ark,add_ptr+0xE,16);
						headers[i].functions= new ImportedFunctions[headers[i].NoOfImportedGlobals];
						int funcptr= add_ptr+0x10;
						for (int f=0; f<headers[i].NoOfImportedGlobals; f++)
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
								headers[i].functions[f].functionName += (char)DataLoader.getValAtAddress(cnv_ark,funcptr+2+j,8);
								}
							headers[i].functions[f].ID_or_Address= (int)DataLoader.getValAtAddress(cnv_ark,funcptr+len+2,16);
							headers[i].functions[f].import_type= (int)DataLoader.getValAtAddress(cnv_ark,funcptr+len+6,16);
							headers[i].functions[f].return_type= (int)DataLoader.getValAtAddress(cnv_ark,funcptr+len+8,16);
							funcptr+= len+10;
							}
						headers[i].instuctions = new int[headers[i].CodeSize];
						int counter=0;
						for (int c=0; c<headers[i].CodeSize*2; c=c+2)
							{
							headers[i].instuctions[counter++] = (int)DataLoader.getValAtAddress(cnv_ark, funcptr + c, 16);
							}
							
						}
					}

			}
		}


	public void DisplayInstructionSet()
		{
		string result="";
		//if (headers[convtodisplay]!=null)
		//	{
			for (int z=0; z <headers[convtodisplay].CodeSize;z++)
				{
				switch(headers[convtodisplay].instuctions[z])
					{
					case cnv_NOP: result += "NOP\n";break;
					case cnv_OPADD: result += "OPADD\n";break;
					case cnv_OPMUL: result += "OPMUL\n";break;
					case cnv_OPSUB: result += "OPSUB\n";break;
					case cnv_OPDIV: result += "OPDIV\n";break;
					case cnv_OPMOD: result += "OPMOD\n";break;
					case cnv_OPOR: result += "OPOR\n";break;
					case cnv_OPAND: result += "OPAND\n";break;
					case cnv_OPNOT: result += "OPNOT\n";break;
					case cnv_TSTGT: result += "TSTGT\n";break;
					case cnv_TSTGE: result += "TSTGE\n";break;
					case cnv_TSTLT: result += "TSTLT\n";break;
					case cnv_TSTLE: result += "TSTLE\n";break;
					case cnv_TSTEQ: result += "TSTEQ\n";break;
					case cnv_TSTNE: result += "TSTNE\n";break;
					case cnv_JMP: result += "JMP "; z++; result +=  " "+ headers[convtodisplay].instuctions[z] + "\n";break;
			case cnv_BEQ: result += "BEQ "; z++; result +=  " "+ headers[convtodisplay].instuctions[z] + "\n";break;
			case cnv_BNE: result += "BNE "; z++; result +=  " "+ headers[convtodisplay].instuctions[z] + "\n";break;
			case cnv_BRA: result += "BRA "; z++; result +=  " "+ headers[convtodisplay].instuctions[z] + "\n";break;
			case cnv_CALL: result += "CALL "; z++; result +=  " "+headers[convtodisplay].instuctions[z] + "\n";break;
			case cnv_CALLI: result += "CALLI "; z++; result +=  " "+ headers[convtodisplay].instuctions[z] + "\n";break;
					case cnv_RET: result += "RET\n";break;
			case cnv_PUSHI: result += "PUSHI "; z++; result += " "+ headers[convtodisplay].instuctions[z] + "\n";break;
			case cnv_PUSHI_EFF: result += "PUSHI_EFF "; z++; result +=  " "+ headers[convtodisplay].instuctions[z] + "\n";break;
					case cnv_POP: result += "POP\n";break;
					case cnv_SWAP: result += "SWAP\n";break;
					case cnv_PUSHBP: result += "PUSHBP\n";break;
					case cnv_POPBP: result += "POPBP\n";break;
					case cnv_SPTOBP: result += "SPTOBP\n";break;
					case cnv_BPTOSP: result += "BPTOSP\n";break;
					case cnv_ADDSP: result += "ADDSP\n";break;
					case cnv_FETCHM: result += "FETCHM\n";break;
					case cnv_STO: result += "STO\n";break;
					case cnv_OFFSET: result += "OFFSET\n";break;
					case cnv_START: result += "START\n";break;
					case cnv_SAVE_REG: result += "SAVE_REG\n";break;
					case cnv_PUSH_REG: result += "PUSH_REG\n";break;
					case cnv_STRCMP: result += "STRCMP\n";break;
					case cnv_EXIT_OP: result += "EXIT_OP\n";break;
					case cnv_SAY_OP: result += "SAY_OP\n";break;
					case cnv_RESPOND_OP: result += "RESPOND_OP\n";break;
					case cnv_OPNEG: result += "OPNEG\n";break;
					}
				}
			//}
		Output.text=result;
		}

}

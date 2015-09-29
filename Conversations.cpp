/*
UNDERWORLD EXPORTER
conversations.cpp

Functions for implementing conversations in UW1&2

*/
#include "utils.h"
#include "main.h"
#include "Conversations.h"

void ExtractConversations(int game)
	{
	//UW1&2
	//Pulls info outo cnv.ark 
	//At the moment just trying to understand the problems of implementing conversations.
	FILE *file = NULL;

	unsigned char *cnv_ark;
	unsigned char *bab;
	long fileSize;
	int add_ptr;
	int cnv_ptr;
	if (game != UW1)
		{
		return;
		}

	if ((file = fopen("c:\\games\\uw1\\save2\\bglobals.dat", "rb")) == NULL)
		fprintf(LOGFILE, "Could not open specified file\n");
	else
		{//Read in the game globals in the specified save file.
		fileSize = getFileSize(file);
		bab = new unsigned char[fileSize];
		fread(bab,fileSize,1,file);
		fclose(file);
		add_ptr = 0;
		while (add_ptr < fileSize)
			{
			int convSlot = getValAtAddress(bab,add_ptr,16);
			add_ptr = add_ptr + 2;
			int convSlotSize = getValAtAddress(bab, add_ptr, 16);
			fprintf(LOGFILE,"Slot %d - Size %d\n", convSlot,convSlotSize);
			for (int k = 0; k < convSlotSize; k++)
				{
				add_ptr = add_ptr + 2;
				fprintf(LOGFILE, "\tGlobal (%d) %d\n",k, getValAtAddress(bab,add_ptr,16));	
				}
			add_ptr = add_ptr + 2;
			}
		}
		


	if ((file = fopen(UW1_CONVERSATION, "rb")) == NULL)
		fprintf(LOGFILE,"Could not open specified file\n");
	else
		fprintf(LOGFILE,"");
	fileSize = getFileSize(file);
	cnv_ark = new unsigned char[fileSize];
	fread(cnv_ark, fileSize, 1, file);
	fclose(file);

	fprintf(LOGFILE,"Conversation Header\nNo of Conversations %d", getValAtAddress(cnv_ark, 0, 16));
	int noOfConversations = getValAtAddress(cnv_ark, 0, 16);
	add_ptr = 2;
	for (int i = 0; i < noOfConversations; i++)
		{
		cnv_ptr = getValAtAddress(cnv_ark, add_ptr, 32);
		if (cnv_ptr != 0)
			{
			fprintf(LOGFILE,"\n\t Offset to conversation %d: %d", i, getValAtAddress(cnv_ark, add_ptr, 32));
			fprintf(LOGFILE,"\n\t\tConversation Header:");
			fprintf(LOGFILE,"\n\t\tUnknown: %d", getValAtAddress(cnv_ark, cnv_ptr + 0, 16));
			fprintf(LOGFILE,"\n\t\tUnknown: %d", getValAtAddress(cnv_ark, cnv_ptr + 2, 16));
			fprintf(LOGFILE,"\n\t\tCode Size: %d", getValAtAddress(cnv_ark, cnv_ptr + 4, 16));
			int codeSize = getValAtAddress(cnv_ark, cnv_ptr + 4, 16);
			fprintf(LOGFILE,"\n\t\tUnknown: %d", getValAtAddress(cnv_ark, cnv_ptr + 6, 16));
			fprintf(LOGFILE,"\n\t\tUnknown: %d", getValAtAddress(cnv_ark, cnv_ptr + 8, 16));
			fprintf(LOGFILE,"\n\t\tStrings Block: %d", getValAtAddress(cnv_ark, cnv_ptr + 0xA, 16));
			fprintf(LOGFILE,"\n\t\tTalking to: %d", getValAtAddress(cnv_ark, cnv_ptr + 0xA, 16) - 0x0e00 + 16);
			fprintf(LOGFILE,"\n\t\tNo of Memory slots: %d", getValAtAddress(cnv_ark, cnv_ptr + 0xC, 16));
			int NoOfImports = getValAtAddress(cnv_ark, cnv_ptr + 0xE, 16);
			fprintf(LOGFILE,"\n\t\tNo of imported globals: %d", getValAtAddress(cnv_ark, cnv_ptr + 0xE, 16));
			fprintf(LOGFILE,"\n\t\t\tImported Functions List");
			int func_ptr = cnv_ptr + 0x10;
			for (int k = 0; k < NoOfImports; k++)
				{
				fprintf(LOGFILE,"\n\n\t\t\tLength of Function Name: %d", getValAtAddress(cnv_ark, func_ptr, 16));
				int functionLength = getValAtAddress(cnv_ark, func_ptr, 16);
				fprintf(LOGFILE,"\n\t\t\tFunction Name:");
				for (int j = 0; j < functionLength; j++)
					{
					fprintf(LOGFILE,"%c", cnv_ark[func_ptr + 2 + j]);
					}

				fprintf(LOGFILE,"\n\t\t\t\tID (imported func) or Memory address (variable): %d", getValAtAddress(cnv_ark, func_ptr + functionLength + 2, 16));
				fprintf(LOGFILE,"\n\t\t\t\tUnknown: %d", getValAtAddress(cnv_ark, func_ptr + functionLength + 4, 16));
				switch (getValAtAddress(cnv_ark, func_ptr + functionLength + 6, 16))//Import Type
					{
						case 0x010F:
							fprintf(LOGFILE,"\n\t\t\t\tImport Type: Variable"); break;
						case 0x0111:
							fprintf(LOGFILE,"\n\t\t\t\tImport Type: Imported Func"); break;
						default:
							fprintf(LOGFILE,"\n\t\t\t\tImport Type: Unknown %d", getValAtAddress(cnv_ark, func_ptr + functionLength + 6, 16)); break;
					}
				switch (getValAtAddress(cnv_ark, func_ptr + functionLength + 8, 16))
					{
						case 0x000:
							fprintf(LOGFILE,"\n\t\t\t\tReturn Type: void", getValAtAddress(cnv_ark, func_ptr + functionLength + 8, 16)); break;
						case 0x129:
							fprintf(LOGFILE,"\n\t\t\t\tReturn Type: Int", getValAtAddress(cnv_ark, func_ptr + functionLength + 8, 16)); break;
						case 0x12B:
							fprintf(LOGFILE,"\n\t\t\t\tReturn Type: String"); break;
						default:
							fprintf(LOGFILE,"\n\t\t\t\tReturn Type: Unknown %d", getValAtAddress(cnv_ark, func_ptr + functionLength + 8, 16)); break;
					}

				func_ptr = func_ptr + functionLength + 10;
				}
			fprintf(LOGFILE,"\n\t\t\t\t\tCode:\n");
			for (int z = 0; z<codeSize * 2; z = z + 2)
				{
				fprintf(LOGFILE,"\t\t\t\t\t");
				int OPCode = getValAtAddress(cnv_ark, func_ptr + z, 16);
				//fprintf(LOGFILE,"%d,", getValAtAddress(cnv_ark, func_ptr + z, 16));
				fprintf(LOGFILE,"%d:",z);
				switch (OPCode)
					{
						case cnv_NOP: fprintf(LOGFILE,"NOP\n"); break;
						case cnv_OPADD: fprintf(LOGFILE,"OPADD\n"); break;
						case cnv_OPMUL: fprintf(LOGFILE,"OPMUL\n"); break;
						case cnv_OPSUB: fprintf(LOGFILE,"OPSUB\n"); break;
						case cnv_OPDIV: fprintf(LOGFILE,"OPDIV\n"); break;
						case cnv_OPMOD: fprintf(LOGFILE,"OPMOD\n"); break;
						case cnv_OPOR: fprintf(LOGFILE,"OPOR\n"); break;
						case cnv_OPAND: fprintf(LOGFILE,"OPAND\n"); break;
						case cnv_OPNOT: fprintf(LOGFILE,"OPNOT\n"); break;
						case cnv_TSTGT: fprintf(LOGFILE,"TSTGT\n"); break;
						case cnv_TSTGE: fprintf(LOGFILE,"TSTGE\n"); break;
						case cnv_TSTLT: fprintf(LOGFILE,"TSTLT\n"); break;
						case cnv_TSTLE: fprintf(LOGFILE,"TSTLE\n"); break;
						case cnv_TSTEQ: fprintf(LOGFILE,"TSTEQ\n"); break;
						case cnv_TSTNE: fprintf(LOGFILE,"TSTNE\n"); break;
						case cnv_JMP: fprintf(LOGFILE,"JMP "); z = z + 2; fprintf(LOGFILE," %d\n", getValAtAddress(cnv_ark, func_ptr + z, 16)); break;
						case cnv_BEQ: fprintf(LOGFILE,"BEQ "); z = z + 2; fprintf(LOGFILE," %d\n,", getValAtAddress(cnv_ark, func_ptr + z, 16)); break;
						case cnv_BNE: fprintf(LOGFILE,"BNE "); z = z + 2; fprintf(LOGFILE," %d\n", getValAtAddress(cnv_ark, func_ptr + z, 16)); break;
						case cnv_BRA: fprintf(LOGFILE,"BRA "); z = z + 2; fprintf(LOGFILE," %d\n", getValAtAddress(cnv_ark, func_ptr + z, 16)); break;
						case cnv_CALL: fprintf(LOGFILE,"CALL "); z = z + 2; fprintf(LOGFILE," %d\n", getValAtAddress(cnv_ark, func_ptr + z, 16)); break;
						case cnv_CALLI: fprintf(LOGFILE,"CALLI "); z = z + 2; fprintf(LOGFILE," %d\n", getValAtAddress(cnv_ark, func_ptr + z, 16)); break;
						case cnv_RET: fprintf(LOGFILE,"RET\n"); break;
						case cnv_PUSHI: fprintf(LOGFILE,"PUSHI "); z = z + 2; fprintf(LOGFILE," %d\n", getValAtAddress(cnv_ark, func_ptr + z, 16)); break;
						case cnv_PUSHI_EFF: fprintf(LOGFILE,"PUSHI_EFF "); z = z + 2; fprintf(LOGFILE," %d\n", getValAtAddress(cnv_ark, func_ptr + z, 16)); break;
						case cnv_POP: fprintf(LOGFILE,"POP\n"); break;
						case cnv_SWAP: fprintf(LOGFILE,"SWAP\n"); break;
						case cnv_PUSHBP: fprintf(LOGFILE,"PUSHBP\n"); break;
						case cnv_POPBP: fprintf(LOGFILE,"POPBP\n"); break;
						case cnv_SPTOBP: fprintf(LOGFILE,"SPTOBP\n"); break;
						case cnv_BPTOSP: fprintf(LOGFILE,"BPTOSP\n"); break;
						case cnv_ADDSP: fprintf(LOGFILE,"ADDSP\n"); break;
						case cnv_FETCHM: fprintf(LOGFILE,"FETCHM\n"); break;
						case cnv_STO: fprintf(LOGFILE,"STO\n"); break;
						case cnv_OFFSET: fprintf(LOGFILE,"OFFSET\n"); break;
						case cnv_START: fprintf(LOGFILE,"START\n"); break;
						case cnv_SAVE_REG: fprintf(LOGFILE,"SAVE_REG\n"); break;
						case cnv_PUSH_REG: fprintf(LOGFILE,"PUSH_REG\n"); break;
						case cnv_STRCMP: fprintf(LOGFILE,"STRCMP\n"); break;
						case cnv_EXIT_OP: fprintf(LOGFILE,"EXIT_OP\n"); break;
						case cnv_SAY_OP: fprintf(LOGFILE,"SAY_OP\n"); break;
						case cnv_RESPOND_OP: fprintf(LOGFILE,"RESPOND_OP\n"); break;
						case cnv_OPNEG: fprintf(LOGFILE,"OPNEG\n"); break;

					}
				}

			}
		else
			{
			//fprintf(LOGFILE,"\t (Empty Slot)");
			}
		add_ptr = add_ptr + 4;
		}


	}
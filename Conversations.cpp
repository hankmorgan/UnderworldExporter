#include "utils.h"
#include "main.h"


void ExtractConversations(int game)
{
	FILE *file = NULL;

	unsigned char *cnv_ark;
	unsigned char *bab;

	int add_ptr;
	int cnv_ptr;
	if (game != UW1)
	{
	return;
	}

	if ((file = fopen(UW1_CONVERSATION, "rb")) == NULL)
		printf("Could not open specified file\n");
	else
		printf("");
	long fileSize = getFileSize(file);
	cnv_ark = new unsigned char[fileSize];
	fread(cnv_ark, fileSize, 1, file);
	fclose(file);

	printf("Conversation Header\nNo of Conversations %d", getValAtAddress(cnv_ark,0,16));
	int noOfConversations = getValAtAddress(cnv_ark, 0, 16);
	add_ptr=2;
	for (int i = 0; i < noOfConversations; i++)
		{
		cnv_ptr = getValAtAddress(cnv_ark, add_ptr, 32);
		if (cnv_ptr != 0)
			{
			printf("\n\t Offset to conversation %d: %d", i, getValAtAddress(cnv_ark, add_ptr, 32));
			printf("\n\t\tConversation Header:");
			printf("\n\t\tUnknown: %d",getValAtAddress(cnv_ark,cnv_ptr+0,16));
			printf("\n\t\tUnknown: %d", getValAtAddress(cnv_ark, cnv_ptr + 2, 16));
			printf("\n\t\tCode Size: %d", getValAtAddress(cnv_ark, cnv_ptr + 4, 16));
			int codeSize = getValAtAddress(cnv_ark, cnv_ptr + 4, 16);
			printf("\n\t\tUnknown: %d", getValAtAddress(cnv_ark, cnv_ptr + 6, 16));
			printf("\n\t\tUnknown: %d", getValAtAddress(cnv_ark, cnv_ptr + 8, 16));
			printf("\n\t\tStrings Block: %d", getValAtAddress(cnv_ark, cnv_ptr + 0xA, 16));
			printf("\n\t\tTalking to: %d", getValAtAddress(cnv_ark, cnv_ptr + 0xA, 16)- 0x0e00 + 16);
			printf("\n\t\tNo of Memory slots: %d", getValAtAddress(cnv_ark, cnv_ptr + 0xC, 16));
			int NoOfImports = getValAtAddress(cnv_ark, cnv_ptr + 0xE, 16);
			printf("\n\t\tNo of imported globals: %d", getValAtAddress(cnv_ark, cnv_ptr + 0xE, 16));
			printf("\n\t\t\tImported Functions List");
			int func_ptr=cnv_ptr+0x10;
			for (int k = 0; k < NoOfImports; k++)
				{
				printf("\n\n\t\t\tLength of Function Name: %d", getValAtAddress(cnv_ark, func_ptr, 16));
				int functionLength = getValAtAddress(cnv_ark, func_ptr, 16);
					printf("\n\t\t\tFunction Name:");
					for (int j = 0; j < functionLength; j++)
					{
						printf("%c", cnv_ark[func_ptr + 2 + j]);
					}
					
					printf("\n\t\t\t\tID (imported func) or Memory address (variable): %d", getValAtAddress(cnv_ark, func_ptr + functionLength + 2, 16));
					printf("\n\t\t\t\tUnknown: %d", getValAtAddress(cnv_ark, func_ptr + functionLength + 4, 16));
					switch (getValAtAddress(cnv_ark, func_ptr + functionLength + 6, 16))//Import Type
						{
						case 0x010F:
							printf("\n\t\t\t\tImport Type: Variable");break;
						case 0x0111:
							printf("\n\t\t\t\tImport Type: Imported Func"); break;
						default:
							printf("\n\t\t\t\tImport Type: Unknown %d", getValAtAddress(cnv_ark, func_ptr + functionLength + 6, 16)); break;
						}
					switch (getValAtAddress(cnv_ark, func_ptr + functionLength + 8, 16))
					{
						case 0x000:
							printf("\n\t\t\t\tReturn Type: void", getValAtAddress(cnv_ark, func_ptr + functionLength + 8, 16));break;
						case 0x129:
							printf("\n\t\t\t\tReturn Type: Int", getValAtAddress(cnv_ark, func_ptr + functionLength + 8, 16)); break;
						case 0x12B:
							printf("\n\t\t\t\tReturn Type: String"); break;
						default:
							printf("\n\t\t\t\tReturn Type: Unknown %d", getValAtAddress(cnv_ark, func_ptr + functionLength + 8, 16)); break;
					}

					
					
					func_ptr = func_ptr+functionLength+10;
				}
			printf("\n\t\t\t\t\tCode:\n\t\t\t\t\t");
			for (int z=0;z<codeSize*2;z=z+2)
				{
				printf("%d,", getValAtAddress(cnv_ark,func_ptr+z,16));
				}

			}
		else
			{
			//printf("\t (Empty Slot)");
			}
		add_ptr=add_ptr+4;
		}
	

}
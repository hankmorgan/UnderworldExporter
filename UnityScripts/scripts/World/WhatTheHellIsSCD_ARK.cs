using UnityEngine;
using System.Collections;
using System.Text;
using System.IO;

//SCD.ark in uw2 does things. I don't know what they are yet. 

public class WhatTheHellIsSCD_ARK : UWEBase {

	public int InfoSize=16;

	public void DumpScdArkInfo(string SCD_Ark_File_Path, int LevelNo)
	{
		string output="";
		StreamWriter writer = new StreamWriter( Application.dataPath + "//..//_scd_ark.txt", true);

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
			int datalen =(int)DataLoader.getValAtAddress(scd_ark_file_data,address_pointer + (NoOfBlocks*4*2) + (LevelNo*4) ,32);
			int isCompressed =(compressionFlag>>1) & 0x01;
			long AddressOfBlockStart;
			address_pointer=(LevelNo * 4) + 6;
			//Debug.Log("Block " + LevelNo + " Datalen is " + datalen + " at address " + ( (int)DataLoader.getValAtAddress(scd_ark_file_data,address_pointer,32) ));
			if ((int)DataLoader.getValAtAddress(scd_ark_file_data,address_pointer,32)==0)
			{
				Debug.Log("No Scd.ark data for this level");
			}

			if (isCompressed == 1)
			{
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
				AddressOfBlockStart=0;
				address_pointer=0;//Since I am at the start of a fresh array.
				scd_ark = new char[datalen];
				for (long i = BlockStart; i < BlockStart + datalen; i++)
				{
					scd_ark[j] = scd_ark_file_data[i];
					j++;
				}
			}
			int add_ptr=0;
				//Output data
						//Debug.Log("block no " + LevelNo);
			output = output + "\nBlock no " + LevelNo + " at address " + AddressOfBlockStart + "\n";
			output = output+ "No of rows " + (int)DataLoader.getValAtAddress(scd_ark,add_ptr++,8) + "\n";
			int noOfRows = (int)DataLoader.getValAtAddress(scd_ark,0,8);
			if (noOfRows!=0)
			{
				output = output + "Unknown info 1-325\n";
				for (int i=1;i<324;i++)
				{
					output = output + (int)DataLoader.getValAtAddress(scd_ark,add_ptr++,8) + ",";		
				}
			

				output = output +"\nRow Data\n";
				add_ptr=326;
								int r=0;
				//for (int i=0; i<noOfRows; i++)
				for (int i=326; i<datalen; i++)
				{				

					output = output + (int)DataLoader.getValAtAddress(scd_ark,add_ptr++,8) + ",";
					r++;
					if (r==16)
					{
							r=0;
							output = output +"\n"; 		
					}

													 
				}
			}
		}
		writer.WriteLine(output);
		writer.Close();

	}

		/*
observed factors based on datalen of various scd.ark files
1, 2, 3, 4,    6,        12,         131, 262, 393, 524, 786, 1572
1, 2, 3, 4,    6, 9,     12,         18, 27, 36, 54, 81, 108, 162, 324
1, 2, 3, 4, 5, 6,    10, 12,     15, 19, 20, 30, 38, 57, 60, 76, 95, 114, 190, 228, 285, 380, 570, 1140
1, 2, 3, 4, 5, 6, 7, 10, 12, 14, 15, 20, 21, 28, 30, 35, 42, 60, 70, 84, 105, 140, 210, 420
1, 2, 3, 4,    6,        12, 139, 278, 417, 556, 834, 1668
1, 2,    4,                     281, 562, 1124
1, 2, 3, 4,    6, 12, 107, 214, 321, 428, 642, 1284
1, 2, 3, 4,    6, 9, 12, 18, 36, 41, 82, 123, 164, 246, 369, 492, 738, 1476

*/
}

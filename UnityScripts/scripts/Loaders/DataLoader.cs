using UnityEngine;
using System.Collections;
using System;
using System.IO;
using System.Collections.Generic;

/// <summary>
/// Data loader for loading binary files.
/// </summary>
public class DataLoader :Loader {

		/// <summary>
		/// System shock ark files.
		/// </summary>
		public struct Chunk{
				public long chunkUnpackedLength;
				public int chunkCompressionType;//compression type
				public long chunkPackedLength;
				public int chunkContentType;
				public char[] data;
		};

		/// <summary>
		/// UW block structure for .ark files.
		/// </summary>
		public struct UWBlock
		{
				public char[] Data;
				public long Address;
				public long DataLen;
				//UW2 specific
				public int CompressionFlag;
				public long ReservedSpace;
		};

		//Compression flags for UW2
		public const int UW2_NOCOMPRESSION=0;
		public const int UW2_SHOULDCOMPRESS=1;
		public const int UW2_ISCOMPRESS=2;
		public const int UW2_HASEXTRASPACE=4;


		/// <summary>
		/// Reads the file into the file buffer
		/// </summary>
		/// <returns><c>true</c>, if stream file was  read, <c>false</c> otherwise.</returns>
		/// <param name="Path">Path.</param>
		/// <param name="buffer">Buffer.</param>
		public static bool ReadStreamFile(String Path, out char[] buffer)
		{			
			Path = Path.Replace("--",sep.ToString());
			if (!File.Exists(Path))
			{						
				UWHUD.instance.ErrorText.text = "File not found " + Path + "\nCheck your paths in config.ini and ensure game files have been extracted. See readme.txt";
				Debug.Log("DataLoader.ReadStreamFile : File not found : " + Path);
				buffer=null;
				return false;
			}
			FileStream fs= File.OpenRead(Path);
			if (fs.CanRead)
			{
					buffer= new char[fs.Length];
					for (int i =0; i<fs.Length;i++)
					{
							buffer[i]=(char)fs.ReadByte();
					}
					fs.Close();
					return true;
			}
			else
			{
					fs.Close();
					buffer= new char[0];
					return false;
			}
		}


		public static long ConvertInt16( char Byte1,  char Byte2)
		{
				//return Byte1 << 8 | Byte2 ;
				return Byte2 << 8 | Byte1 ;
		}

		public static long ConvertInt24( char Byte1,  char Byte2,  char Byte3)
		{
				return Byte3 << 16 | Byte2 << 8 | Byte1 ;
		}

		public static long ConvertInt32(char Byte1,  char Byte2,   char Byte3,  char Byte4)
		{
				return Byte4 << 24 | Byte3 << 16 | Byte2 << 8 | Byte1 ;		//24 was 32
		}


		/// <summary>
		/// Gets the value at the specified address in the file buffer and performs any necessary -endian conversions
		/// </summary>
		/// <returns>The value at address.</returns>
		/// <param name="buffer">Buffer.</param>
		/// <param name="Address">Address.</param>
		/// <param name="size">Size of the data in bits</param>
		public static long getValAtAddress(UWBlock buffer, long Address, int size)
			{//Gets contents of bytes the the specific integer address. int(8), int(16), int(32) per uw-formats.txt
				return getValAtAddress(buffer.Data,Address,size);
			}



		/// <summary>
		/// Gets the value at the specified address in the file buffer and performs any necessary -endian conversions
		/// </summary>
		/// <returns>The value at address.</returns>
		/// <param name="buffer">Buffer.</param>
		/// <param name="Address">Address.</param>
		/// <param name="size">Size of the data in bits</param>
		public static long getValAtAddress(char[] buffer, long Address, int size)
		{//Gets contents of bytes the the specific integer address. int(8), int(16), int(32) per uw-formats.txt
				switch (size)
				{
				case 8:
						{return buffer[Address];}
				case 16:
						{return ConvertInt16(buffer[Address],buffer[Address+1]);}
				case 24:
						{return ConvertInt24(buffer[Address],buffer[Address+1],buffer[Address+2]);}
				case 32:	//may be buggy!
						{return ConvertInt32(buffer[Address], buffer[Address + 1], buffer[Address + 2], buffer[Address + 3]); }
				default:
						{
							Debug.Log("Invalid data size in getValAtAddress");
							return -1;
						}
				}
		}


		/// <summary>
		/// Unpacks the Uw2 compressed blocks
		/// </summary>
		/// <returns>The Uw2 uncompressed block.</returns>
		/// <param name="tmp">Tmp.</param>
		/// <param name="address_pointer">Address pointer.</param>
		/// <param name="datalen">Datalen.</param>
		/// Robbed and changed slightly from the Labyrinth of Worlds implementation project.
		///This decompresses UW2 blocks.
	public static char[] unpackUW2(char[] tmp, long address_pointer, ref long datalen)
	{
		long BlockLen = (int)DataLoader.getValAtAddress(tmp,address_pointer,32);	//lword(base);
		long NoOfSegs = ((BlockLen / 0x1000) + 1) * 0x1000;
		//char[] buf = new char[BlockLen+100];
		char[] buf = new char[ Math.Max(NoOfSegs, BlockLen+100)];
			
		long upPtr=0;
		datalen = 0;
		address_pointer += 4;
		
		while(upPtr < BlockLen)
		{
			byte bits = (byte)tmp[address_pointer++];
			for(int r=0; r<8; r++)
			{
				if (address_pointer>tmp.GetUpperBound(0))
				{//No more data!
					return buf;
				}
				if((bits & 1)==1)
				{//Transfer
					buf[upPtr++] = tmp[address_pointer++];
					datalen = datalen+1;
				}
				else
				{//copy
					int o = tmp[address_pointer++];
					int c = tmp[address_pointer++];

					o |= ((c&0xF0)<<4);
					//if((o&0x800) == 0x800)
					//	{//Apparently I need to turn this to twos complement when the sign bit is set. 
					///Possibly the code below is what achieves this?
					//	o = (o | 0xFFFFF000);
					//	//o = 0 & 0x7ff;
					//	}
							

					c = ((c&15) + 3);						
					o = (o+18);								

					if (o>upPtr)
						{
							o -= 0x1000;					
						}

					while(o < (upPtr-0x1000))
						{
							o += 0x1000;					
						}

					while(c-- >0)
					{					
						if (o<0)
						{
							//int currentsegment = ((datalen/0x1000) + 1) * 0x1000;
							//buf[upPtr++]= buf[buf.GetUpperBound(0) + o++];//This is probably very very wrong.
							//buf[upPtr++]= buf[currentsegment + o++];//This is probably very very wrong.
							buf[upPtr++] = (char)0;
							o++;
						}
						else
						{
							buf[upPtr++]= buf[o++];								
						}
						
						datalen++;    // = datalen+1;
					}
				}
				bits >>= 1;
			}
		}
		return buf;
	}


		/// <summary>
		/// Repacks a byte array into a UW2 compressed block
		/// </summary>
		/// <param name="srcData">Source data.</param>
		/// 
		///for each byte in src data
		///read in byte.
		///if byte count >3
		///  if find byte in previous data
		///if previous data header is a copy record then increment its size (up to max of 18)
		///else create a new copy record.
		/// this is a transfer record
		///else
		///this is a transfer record
		public static char[] RepackUW2(char[] srcData)
		{
			List<char> Input = new List<char>();
			List<char> Output = new List<char>();
			int addptr=0;
			int bit=0;
				int MatchingOffset; 
				//int PrevMatchingOffset=-1; 
				//int CopyRecordOffset=0;
				int copycount=0; int HeaderIndex=0;
			while (addptr<=srcData.GetUpperBound(0))
			{
				//Read in the data to the input list
				Input.Add(srcData[addptr++]);
				if (Input.Count>3)//One I have at least 3 bytes I can test its contents
				{//THIS IS WRONG> Code will only match up to size 3.
					//At this point I need to start testing increasing sizes of data up to 18 bytes until I find the max copy record to create;
					if(FindMatchingSequence(ref Output, ref Input, out MatchingOffset))	
						{//the data is part of a copy sequence. Try and find the biggest block and make a copy record out of that.
									//TODO
									//
						/*	if (MatchingOffset == PrevMatchingOffset )	
							{//Increment copy count
								copycount++;
								IncrementCopyRecord(ref Output, CopyRecordOffset);
								if (copycount>=18)
								{
									PrevMatchingOffset=-1; //force a new copy record on next loop	
									Input.Clear();
								}								
							}
							else
							{//Create copy record
								copycount=0;
								if (bit==0)
								{
										HeaderIndex=CreateHeader(ref Output);	
								}
								CopyRecordOffset = CreateCopyRecord(ref Output, MatchingOffset, copycount, HeaderIndex, bit++ );
							}*/
						}
						else
						{//There is no copy for the specified data. Transfer data that is not copied and clear out the input buffer
							for (int i=copycount; i<Input.Count; i++)
							{
								if (bit==0)
								{
									HeaderIndex=CreateHeader(ref Output);	
								}
								CreateTransferRecord(ref Output, Input[i], HeaderIndex,bit++);								
							}
							Input.Clear();
						}
				}
				if (bit==8)
				{
					bit=0;
				}
			}

			//Write the data to a file.
			WriteListToBytes(Output,Loader.BasePath + "DATA" + sep + "recodetest.dat" );
			char[] outchar = new char[Output.Count];
			for (int i=0; i<Output.Count;i++)
			{
					outchar[i] = Output[i];
			}
			return outchar;			
		}

		static int CreateHeader(ref List<char> Output)
		{
			Output.Add((char)0);
			return Output.Count-1;
		}

		static void WriteListToBytes(List<char> Output, string path)
		{
			FileStream file = File.Open(path,FileMode.Create);
			BinaryWriter writer= new BinaryWriter(file);
			DataLoader.WriteInt32(writer, Output.Count);
			for (int i=0; i<Output.Count;i++)
			{
				DataLoader.WriteInt8(writer, (long)Output[i]);
			}
			writer.Close();
		}

		static void CreateTransferRecord(ref List<char> Output, char TransferData, int headerIndex, int bit)
		{				
				Output[headerIndex] = (char)(Output[headerIndex] | (1<<bit));
				Output.Add(TransferData);
		}

		static int CreateCopyRecord(ref List<char> Output, int Offset, int CopyCount, int headerIndex, int bit)
		{
			//The copy record starts with two Int8's:
			//0000   Int8   0..7: position
			//0001   Int8   0..3: copy count
			//				4..7: position
			//int val = Offset
			Output[headerIndex] = (char)(Output[headerIndex] | (0<<bit));

			//Offset= getTrueOffset(Offset);
			//CopyCount-=3;
			int val1 = Offset & 0xF;
			int val2 = (CopyCount & 0xf)  | (( Offset >> 7) << 4);

			Output.Add((char)val1);
			Output.Add((char)val2);
			return Output.Count-1;
		}

		static void IncrementCopyRecord(ref List<char> Output, int CopyRecordOffset)
		{
			int val = getCopyCountAtOffset(ref Output, CopyRecordOffset);
			val++;
			val = val & 0xF;
			char chardata = (char)(Output[CopyRecordOffset] & 0xf8);//Clear the bits for the count.
			chardata = (char)(chardata | val);
			Output[CopyRecordOffset]=chardata;
		}

		static int getCopyCountAtOffset(ref List<char> Output, int CopyRecordOffset)
		{
			if (CopyRecordOffset<0)
			{
				return 0;
			}
			else
			{
				int val = Output[CopyRecordOffset];
				val = val & 0xF;//Extract copy count
				return val;	
			}
		}

		static bool FindMatchingSequence(ref List<char>records, ref List<char>searchfor, out int MatchingOffset)
		{			
			int lowerbound= (records.Count / 4096) * 4096;
			string searchval = charListToVal(searchfor,0,searchfor.Count);
			MatchingOffset=-1;
			for (int i = records.Count - searchfor.Count; i>=lowerbound; i--)
			{
				string recordval = charListToVal(records, i, searchfor.Count-1)	;
				if (recordval==searchval)
				{
					MatchingOffset=i;
					return true;
				}
			}
			return false;
		}

		static string charListToVal(List<char> input, int start, int len)
		{
			string output="";
			for (int i = start; i<=start+len; i++)
			{
				if (i<input.Count)
				{
					output = output + input[i].ToString();		
				}
			}
			return output;
		}


		/// <summary>
		/// Gets the true offset of the copy record.
		/// </summary>
		/// <returns>The true offset.</returns>
		/// <param name="offset">Offset.</param>
		static int getTrueOffset(int offset)
		{
			while (offset>4096)
			{
				offset -=4096;
			}
			offset -=18;

			return offset;
		}

		//****************************************************************************

		/* The following procedure comes straight from Jim Cameron
   http://madeira.physiol.ucl.ac.uk/people/jim
   Specifically, this procedure can be found on his "Unofficial System Shock
   Specifications" page at
   http://madeira.physiol.ucl.ac.uk/people/jim/games/ss-res.txt
*/
		public static void unpack_data (char[] pack,    ref char[] unpack, long unpacksize)
		{

				//unsigned char *byteptr;
				long byteptr=0;
				//unsigned char *exptr;
				long exptr=0;
				int word = 0;  /* initialise to stop "might be used before set" */
				int nbits;
				/*    int type; */
				int val;

				int ntokens = 0;
				long[] offs_token = new long [16384];
				int[] len_token = new int [16384];
				int[] org_token = new int [16384];

				int i;

				for (i = 0; i < 16384; ++i)
				{
						len_token [i] = 1;
						org_token [i] = -1;
				}
				//memset (unpack, 0, unpacksize); Probably not needed here. Initialises the unpacked array with zeros.


				byteptr =0; //pack;
				exptr   = 0;//unpack;
				nbits = 0;

				// while (exptr - unpack < unpacksize)
				while (exptr<unpacksize)
				{

						while (nbits < 14)
						{
								word = (word << 8) + pack[byteptr++]; //   *byteptr++;
								nbits += 8;
						}

						nbits -= 14;
						val = (word >> nbits) & 0x3FFF;
						if (val == 0x3FFF)
						{
								break;
						}

						if (val == 0x3FFE)
						{
								for (i = 0; i < 16384; ++i)
								{
										len_token [i] = 1;
										org_token [i] = -1;
								}
								ntokens = 0;
								continue;
						}

						if (ntokens < 16384)
						{
								//offs_token [ntokens] = exptr - unpack;
								offs_token [ntokens] = exptr;// - unpack;
								if (val >= 0x100)
								{
										org_token [ntokens] = val - 0x100;
								}
						}
						++ntokens;

						if (val < 0x100)
						{
								// *exptr++ = val;
								unpack[exptr++]= (char)val;
						}
						else
						{
								val -= 0x100;

								if (len_token [val] == 1)
								{   
										if (org_token [val] != -1)
										{
												len_token [val] += len_token [org_token [val]];
										}
										else
										{
												len_token [val] += 1;
										}
								}
								for (i = 0; i < len_token [val]; ++i)
								{
										if (i + offs_token[val]<unpacksize)
										{
												// *exptr++ = unpack[i + offs_token[val]];
												unpack[exptr++] = unpack[i + offs_token[val]];
										}
										else
										{
												Debug.Log("Oh shit");
										}

								}

						}

				}

		}

		// End of Jim Cameron's procedure



		//****************************************************************************


		//*********************


		public static bool LoadChunk(char[] archive_ark, int chunkNo, out Chunk data_ark )
		{
				long blockAddress =0;    //  int chunkId;
				//long chunkUnpackedLength=0;
				//int chunkType=0;//compression type
				// long chunkPackedLength=0;
				//  long chunkContentType;
				data_ark.chunkPackedLength=0;
				data_ark.chunkUnpackedLength=0;
				data_ark.chunkContentType=0;
				data_ark.chunkCompressionType=0;
				//get the level info data from the archive
				blockAddress =getShockBlockAddress(chunkNo,archive_ark, ref data_ark.chunkPackedLength, ref data_ark.chunkUnpackedLength, ref data_ark.chunkCompressionType , ref data_ark.chunkContentType); 
				if (blockAddress == -1) {
						data_ark.data=new char[1];
						return false;
				}
				data_ark.data=new char[data_ark.chunkUnpackedLength];
				LoadShockChunk(blockAddress, data_ark.chunkCompressionType, archive_ark, ref data_ark.data, data_ark.chunkPackedLength,data_ark.chunkUnpackedLength);  
				return true;
		}




		static long getShockBlockAddress(long BlockNo, char[] tmp_ark , ref long chunkPackedLength, ref long chunkUnpackedLength, ref int chunkCompressionType, ref int chunkContentType)
		{
				//Finds the address of the block based on the directory block no.
				//Justs loops through until it finds a match.
				int blnLevelFound =0;
				long DirectoryAddress=DataLoader.getValAtAddress(tmp_ark,124,32);
				//printf("\nThe directory is at %d\n", DirectoryAddress);

				int NoOfChunks = (int)DataLoader.getValAtAddress(tmp_ark,DirectoryAddress,16);
				//printf("there are %d chunks\n",NoOfChunks);
				long firstChunkAddress = DataLoader.getValAtAddress(tmp_ark,DirectoryAddress+2,32);
				//printf("The first chunk is at %d\n", firstChunkAddress);
				long address_pointer=DirectoryAddress+6;
				long AddressOfBlockStart= firstChunkAddress;
				for (int k=0; k< NoOfChunks; k++)
				{
						int chunkId = (int)DataLoader.getValAtAddress(tmp_ark,address_pointer,16);
						chunkUnpackedLength =DataLoader.getValAtAddress(tmp_ark,address_pointer+2,24);
						chunkCompressionType = (int)DataLoader.getValAtAddress(tmp_ark,address_pointer+5,8);  //Compression.
						chunkPackedLength = DataLoader.getValAtAddress(tmp_ark,address_pointer+6,24);
						chunkContentType =(short)DataLoader.getValAtAddress(tmp_ark,address_pointer+9,8);

						//Debug.Log(chunkId + " of type " + chunkContentType + " compress=" + chunkCompressionType + " packed= " + chunkPackedLength + " unpacked=" + chunkUnpackedLength + " at file address " + AddressOfBlockStart );

						//target chunk id is 4005 + level no * 100 for levels
						if (chunkId== BlockNo)    //4005+ LevelNo*100
						{
								blnLevelFound=1;
								address_pointer=0;
								break;
						}


						AddressOfBlockStart=AddressOfBlockStart+ chunkPackedLength;
						if ((AddressOfBlockStart % 4) != 0)
								AddressOfBlockStart = AddressOfBlockStart + 4 - (AddressOfBlockStart % 4); // chunk offsets always fall on 4-byte boundaries


						address_pointer=address_pointer+10;     
				}

				if (blnLevelFound == 0)
				{
						//printf("Level not found"); 
						return -1;
				}
				else
				{
						return AddressOfBlockStart;
				}
		}






		static long LoadShockChunk(long AddressOfBlockStart, int chunkType, char[] archive_ark, ref char[] OutputChunk,long chunkPackedLength,long chunkUnpackedLength)
		{
				//Util to return an uncompressed shock block. Will use this for all future lookups and replace old ones


				//int chunkId;
				//  long chunkUnpackedLength;
				//int chunkType=Compressed;//compression type
				//long chunkPackedLength;
				//long chunkContentType;
				//long filepos;
				//  long AddressOfBlockStart=0;
				//long address_pointer=4;
				//int blnLevelFound=0;    



				//Find the address of the block. This will also return the file size.
				//AddressOfBlockStart = getShockBlockAddress(ChunkNo,archive_ark,&chunkPackedLength,&chunkUnpackedLength,&chunkType);   
				if (AddressOfBlockStart == -1)  {return -1;}

				//if (chunkType ==1)
				switch (chunkType)
				{
				case 0:
						{//Flat uncompressed
								for (long k=0; k< chunkUnpackedLength; k++)
								{
										OutputChunk[k] = archive_ark[AddressOfBlockStart+k];
								}   
								return chunkUnpackedLength;

						}
				case 1: 
						{//flat Compressed
								//printf("\nCompressed chunk");
								char[] temp_ark = new char[chunkPackedLength]; 
								for (long k=0; k< chunkPackedLength; k++)
								{
										temp_ark[k] = archive_ark[AddressOfBlockStart+k];
								}

								unpack_data(temp_ark,ref OutputChunk,chunkUnpackedLength);
								return chunkUnpackedLength;

						}

				case 3://Subdir compressed  //Just return the compressed data and unpack the sub chunks individually?
						{
								//uncompressed the sub chunks
								int NoOfEntries=(int)DataLoader.getValAtAddress(archive_ark,AddressOfBlockStart,16);
								int SubDirLength=(NoOfEntries+1) * 4 + 2;
								char[] temp_ark = new char[chunkPackedLength]; 
								char[] tmpchunk = new char[chunkUnpackedLength]; 
								for (long k=0; k< chunkPackedLength; k++)
								{
										temp_ark[k] = archive_ark[AddressOfBlockStart+k+SubDirLength];
								}
								unpack_data(temp_ark, ref tmpchunk,chunkUnpackedLength);
								//Merge my subdir and uncompressed subdir data back together.
								for (long k=0;k<SubDirLength;k++)
								{//Subdir
										OutputChunk[k]=archive_ark[AddressOfBlockStart+k];
								}
								for (long k=SubDirLength;k<chunkUnpackedLength;k++)
								{//Subdir
										OutputChunk[k]=tmpchunk[k-SubDirLength];
								}
								return chunkUnpackedLength;         

						}
				case 2://Subdir uncompressed
						//{
						//printf("Uncompressed subdir!");
						//}
				default:
						{//Uncompressed. 
								//printf("\nUncompressed chunk");
								//OutputChunk =  new unsigned char[chunkUnpackedLength];
								for (long k=0; k< chunkUnpackedLength; k++)
								{
										OutputChunk[k] = archive_ark[AddressOfBlockStart+k];
								}   
								return chunkUnpackedLength;

						}
				}
		}


		/// <summary>
		/// Writes an int8 to a file
		/// </summary>
		/// <param name="writer">Writer.</param>
		/// <param name="val">Value.</param>
		public static long WriteInt8(BinaryWriter writer, long val)
		{
				byte valOut= (byte)(val & 0xff);
				writer.Write(valOut);

				return 1;
		}


		/// <summary>
		/// Writes an int16 to a file
		/// </summary>
		/// <param name="writer">Writer.</param>
		/// <param name="val">Value.</param>
		public static long WriteInt16(BinaryWriter writer, long val)
		{
				byte valOut= (byte)(val & 0xff);
				writer.Write(valOut);

				valOut= (byte)(val >>8 & 0xff);
				writer.Write(valOut);

				return 2;
		}

		/// <summary>
		/// Writes an int32 to file
		/// </summary>
		/// <param name="writer">Writer.</param>
		/// <param name="val">Value.</param>
		public static long WriteInt32(BinaryWriter writer, long val)
		{
				byte valOut= (byte)(val & 0xff);
				writer.Write(valOut);

				valOut= (byte)(val >>8 & 0xff);
				writer.Write(valOut);

				valOut= (byte)(val >> 16 & 0xff);
				writer.Write(valOut);

				valOut= (byte)(val >>24 & 0xff);
				writer.Write(valOut);

				return 4;
		}



		/// <summary>
		/// Loads the UW block.
		/// </summary>
		/// <returns><c>true</c>, if UW block was loaded, <c>false</c> otherwise.</returns>
		/// <param name="arkData">Ark data.</param>
		/// <param name="blockNo">Block no.</param>
		/// <param name="targetDataLen">Target data length.</param>
		/// <param name="uwb">Uwb.</param>
		public static bool LoadUWBlock(char[] arkData, int blockNo, long targetDataLen, out UWBlock uwb)
		{		
			uwb = new UWBlock();		
			int NoOfBlocks =  (int)DataLoader.getValAtAddress(arkData,0,32);
			switch (_RES)
			{
			case GAME_UW2:
				{//6 + block *4 + (noOfBlocks*type)
					uwb.Address=(int)DataLoader.getValAtAddress(arkData, 6 + (blockNo*4) ,32)  ;
					uwb.CompressionFlag =(int)DataLoader.getValAtAddress(arkData, 6 +  (blockNo*4)  + (NoOfBlocks*4) ,32)  ;
					uwb.DataLen =DataLoader.getValAtAddress(arkData, 6 +  (blockNo*4)  + (NoOfBlocks*8)  ,32)  ;
					uwb.ReservedSpace =DataLoader.getValAtAddress(arkData, 6 +  (blockNo*4)  + (NoOfBlocks*12)  ,32)  ;	
					if (uwb.Address!=0)
					{
						if (((uwb.CompressionFlag >>1) & 0x01) == 1)
						{//data is compressed;
							uwb.Data = unpackUW2(arkData,uwb.Address,ref uwb.DataLen);	
							return true;
						}
						else
						{
							uwb.Data = new char[uwb.DataLen];
							int b=0;
							for (long i=uwb.Address; i<uwb.Address+uwb.DataLen;i++)	
							{//Copy the data to the block.
								uwb.Data[b++]= arkData[i];														
							}
							return true;
						}
					}
					else
					{
						uwb.DataLen = 0;
						return false;
					}
				}
			default:
				{
					uwb.Address =  DataLoader.getValAtAddress(arkData,(blockNo * 4) + 2,32);	
					if (uwb.Address!=0)
					{
						uwb.Data = new char[targetDataLen];
						uwb.DataLen = targetDataLen;
						int b=0;
						for (long i=uwb.Address; i<uwb.Address+uwb.DataLen;i++)	
						{//Copy the data to the block.
								uwb.Data[b++]= arkData[i];														
						}
						return true;
					}
					else
					{
						uwb.DataLen = 0;
						return false;
					}
				}
			}
		}
}

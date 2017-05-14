using UnityEngine;
using System.Collections;
using System;
using System.IO;

/// <summary>
/// Data loader for loading binary files.
/// </summary>
public class DataLoader :Loader {

		public struct Chunk{
				public long chunkUnpackedLength;
				public int chunkCompressionType;//compression type
				public long chunkPackedLength;
				public int chunkContentType;
				public char[] data;
		};


		public static bool ReadStreamFile(String Path, out char[] buffer)
		{
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
	public static char[] unpackUW2(char[] tmp, long address_pointer, ref int datalen)
	{

		//Robbed and changed slightly from the Labyrinth of Worlds implementation project.
		//This decompresses UW2 blocks.
		long	len = (int)DataLoader.getValAtAddress(tmp,address_pointer,32);	//lword(base);
		//long block_address=address_pointer;
		char[] buf = new char[len+100];
		char[] up = buf;
		long upPtr=0;
		long bufPtr=0;
		datalen = 0;
		address_pointer += 4;

		while(upPtr < len)
		{
			int		bits = tmp[address_pointer++];
			for(int r=0; r<8; r++)
			{
				if((bits & 1)==1)
				{
					//printf("transfer %d\ at %d\n", byte(base),base);
					up[upPtr++] = tmp[address_pointer++];
					datalen = datalen+1;
				}
				else
				{
					int	o = tmp[address_pointer++];
					int	c = tmp[address_pointer++];

					o |= (c&0xF0)<<4;
					c = (c&15) + 3;
					o = o+18;
					if(o > (upPtr-bufPtr))
							o -= 0x1000;
					while(o < (upPtr-bufPtr-0x1000))
							o += 0x1000;

					while(c-- >0)
					{
						if (o<0)
						{
							up[upPtr++]= tmp[tmp.GetUpperBound(0)+ o++];
						}
						else
						{
							up[upPtr++]= buf[o++];
						}

						datalen = datalen+1;
					}
				}
				bits >>= 1;
			}
		}

		return buf;
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
		public static void WriteInt8(BinaryWriter writer, long val)
		{
				byte valOut= (byte)(val & 0xff);
				writer.Write(valOut);
		}


		/// <summary>
		/// Writes an int16 to a file
		/// </summary>
		/// <param name="writer">Writer.</param>
		/// <param name="val">Value.</param>
		public static void WriteInt16(BinaryWriter writer, long val)
		{
				byte valOut= (byte)(val & 0xff);
				writer.Write(valOut);

				valOut= (byte)(val >>8 & 0xff);
				writer.Write(valOut);
		}

		/// <summary>
		/// Writes an int32 to file
		/// </summary>
		/// <param name="writer">Writer.</param>
		/// <param name="val">Value.</param>
		public static void WriteInt32(BinaryWriter writer, long val)
		{
				byte valOut= (byte)(val & 0xff);
				writer.Write(valOut);

				valOut= (byte)(val >>8 & 0xff);
				writer.Write(valOut);

				valOut= (byte)(val >> 16 & 0xff);
				writer.Write(valOut);

				valOut= (byte)(val >>24 & 0xff);
				writer.Write(valOut);
		}


}

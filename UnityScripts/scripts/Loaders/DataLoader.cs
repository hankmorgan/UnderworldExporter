using UnityEngine;
using System.Collections;
using System;
using System.IO;

/// <summary>
/// Data loader for loading binary files.
/// </summary>
public class DataLoader :Loader {
		
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
		long block_address=address_pointer;
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


}

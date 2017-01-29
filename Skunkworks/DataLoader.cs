using UnityEngine;
using System.Collections;
using System;
using System.IO;

/// <summary>
/// Data loader for loading binary files.
/// </summary>
public static class DataLoader  {
		
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
}

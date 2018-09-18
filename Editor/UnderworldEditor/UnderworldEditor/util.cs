﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace UnderworldEditor
{
    class Util
    {
        /// <summary>
        /// UW block structure for .ark files.
        /// </summary>
        public struct UWBlock
        {
            public char[] Data;
            public long Address; //The file address of the block

            public long DataLen;
            //UW2 specific
            public int CompressionFlag;
            public long ReservedSpace;
        };


        /// <summary>
        /// Reads the file into the file buffer
        /// </summary>
        /// <returns><c>true</c>, if stream file was  read, <c>false</c> otherwise.</returns>
        /// <param name="Path">Path.</param>
        /// <param name="buffer">Buffer.</param>
        public static bool ReadStreamFile(String Path, out char[] buffer)
        {
            //Path = Path.Replace("--", sep.ToString());
            if (!File.Exists(Path))
            {            
                
                Debug.WriteLine("Util.ReadStreamFile : File not found : " + Path);
                buffer = null;
                return false;
            }
            FileStream fs = File.OpenRead(Path);
            if (fs.CanRead)
            {
                buffer = new char[fs.Length];
                for (int i = 0; i < fs.Length; i++)
                {
                    buffer[i] = (char)fs.ReadByte();
                }
                fs.Close();
                return true;
            }
            else
            {
                fs.Close();
                buffer = new char[0];
                return false;
            }
        }



        public static void WriteStreamFile(String Path, char[] buffer)
        {
            byte[] bytes = new byte[buffer.GetUpperBound(0)+1];
            for (int i=0; i<=buffer.GetUpperBound(0);i++)
            {
                bytes[i] = (byte)buffer[i];
            }
            File.WriteAllBytes(Path, bytes);
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
                    { return buffer[Address]; }
                case 16:
                    { return ConvertInt16(buffer[Address], buffer[Address + 1]); }
                case 24:
                    { return ConvertInt24(buffer[Address], buffer[Address + 1], buffer[Address + 2]); }
                case 32:    //may be buggy!
                    { return ConvertInt32(buffer[Address], buffer[Address + 1], buffer[Address + 2], buffer[Address + 3]); }
                default:
                    {
                        return 0;
                    }
            }
        }


        public static long ConvertInt16(char Byte1, char Byte2)
        {
            int b1 = (int)Byte1;
            int b2 = (int)Byte2;
            return Byte2 << 8 | Byte1;
        }

        public static long ConvertInt24(char Byte1, char Byte2, char Byte3)
        {
            return Byte3 << 16 | Byte2 << 8 | Byte1;
        }

        public static long ConvertInt32(char Byte1, char Byte2, char Byte3, char Byte4)
        {
            return Byte4 << 24 | Byte3 << 16 | Byte2 << 8 | Byte1;      //24 was 32
        }


        /// <summary>
        /// Extracts the specified number of bits from the position in the value.
        /// </summary>
        /// <returns>The bits.</returns>
        /// <param name="value">Value.</param>
        /// <param name="From">From.</param>
        /// <param name="Length">Length.</param>
        public static int ExtractBits(int value, int From, int Length)
        {
            int mask = getMask(Length);
            return (value >> From) & (mask);
        }


        /// <summary>
        /// Gets a bit mask of the specified length.
        /// </summary>
        /// <returns>The mask.</returns>
        /// <param name="Length">Length.</param>
        static int getMask(int Length)
        {
            int mask = 0;
            for (int i = 0; i < Length; i++)
            {
                mask = (mask << 1) | 1;
            }
            return mask;
        }


        /// <summary>
        /// Loads the UW block.
        /// </summary>
        /// <returns><c>true</c>, if UW block was loaded, <c>false</c> otherwise.</returns>
        /// <param name="arkData">Ark data.</param>
        /// <param name="blockNo">Block no.</param>
        /// <param name="targetDataLen">Target data length.</param>
        /// <param name="uwb">Uwb.</param>
        public static bool LoadUWBlock(char[] arkData, int blockNo, long targetDataLen, out UWBlock uwb, int game)
        {
            uwb = new UWBlock();
            int NoOfBlocks = (int)getValAtAddress(arkData, 0, 32);
            switch (game)
            {
                case 2:
                    {//6 + block *4 + (noOfBlocks*type)
                        uwb.Address = (int)getValAtAddress(arkData, 6 + (blockNo * 4), 32);
                        uwb.CompressionFlag = (int)getValAtAddress(arkData, 6 + (blockNo * 4) + (NoOfBlocks * 4), 32);
                        uwb.DataLen = getValAtAddress(arkData, 6 + (blockNo * 4) + (NoOfBlocks * 8), 32);
                        uwb.ReservedSpace = getValAtAddress(arkData, 6 + (blockNo * 4) + (NoOfBlocks * 12), 32);
                        if (uwb.Address != 0)
                        {
                            if (((uwb.CompressionFlag >> 1) & 0x01) == 1)
                            {//data is compressed;
                                uwb.Data = unpackUW2(arkData, uwb.Address, ref uwb.DataLen);
                                return true;
                            }
                            else
                            {
                                uwb.Data = new char[uwb.DataLen];
                                int b = 0;
                                for (long i = uwb.Address; i < uwb.Address + uwb.DataLen; i++)
                                {//Copy the data to the block.
                                    uwb.Data[b++] = arkData[i];
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
                        uwb.Address = getValAtAddress(arkData, (blockNo * 4) + 2, 32);
                        if (uwb.Address != 0)
                        {
                            uwb.Data = new char[targetDataLen];
                            uwb.DataLen = targetDataLen;
                            uwb.CompressionFlag = 0;
                            int b = 0;
                            for (long i = uwb.Address; i < uwb.Address + uwb.DataLen; i++)
                            {//Copy the data to the block.
                                uwb.Data[b++] = arkData[i];
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
            long BlockLen = (int)getValAtAddress(tmp, address_pointer, 32);  //lword(base);
            long NoOfSegs = ((BlockLen / 0x1000) + 1) * 0x1000;
            //char[] buf = new char[BlockLen+100];
            char[] buf = new char[Math.Max(NoOfSegs, BlockLen + 100)];

            long upPtr = 0;
            datalen = 0;
            address_pointer += 4;

            while (upPtr < BlockLen)
            {
                byte bits = (byte)tmp[address_pointer++];
                for (int r = 0; r < 8; r++)
                {
                    if (address_pointer > tmp.GetUpperBound(0))
                    {//No more data!
                        return buf;
                    }
                    if ((bits & 1) == 1)
                    {//Transfer
                        buf[upPtr++] = tmp[address_pointer++];
                        datalen = datalen + 1;
                    }
                    else
                    {//copy
                        int o = tmp[address_pointer++];
                        int c = tmp[address_pointer++];

                        o |= ((c & 0xF0) << 4);
                        //if((o&0x800) == 0x800)
                        //	{//Apparently I need to turn this to twos complement when the sign bit is set. 
                        ///Possibly the code below is what achieves this?
                        //	o = (o | 0xFFFFF000);
                        //	//o = 0 & 0x7ff;
                        //	}


                        c = ((c & 15) + 3);
                        o = (o + 18);

                        if (o > upPtr)
                        {
                            o -= 0x1000;
                        }

                        while (o < (upPtr - 0x1000))
                        {
                            o += 0x1000;
                        }

                        while (c-- > 0)
                        {
                            if (o < 0)
                            {
                                //int currentsegment = ((datalen/0x1000) + 1) * 0x1000;
                                //buf[upPtr++]= buf[buf.GetUpperBound(0) + o++];//This is probably very very wrong.
                                //buf[upPtr++]= buf[currentsegment + o++];//This is probably very very wrong.
                                buf[upPtr++] = (char)0;
                                o++;
                            }
                            else
                            {
                                buf[upPtr++] = buf[o++];
                            }

                            datalen++;    // = datalen+1;
                        }
                    }
                    bits >>= 1;
                }
            }
            return buf;
        }


    }//end class
}
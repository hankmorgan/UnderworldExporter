using System;
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


    }//end class
}

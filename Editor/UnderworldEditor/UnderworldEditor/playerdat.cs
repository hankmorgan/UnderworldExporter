using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderworldEditor
{
    class playerdat
    {
        /// <summary>
        /// Size of encrypted area in UW1 player.dat
        /// </summary>
        private const int NoOfEncryptedBytes = 0xD2;

        public static char[] LoadPlayerDatUW1(string FilePath)
        {
            char[] buffer;
            if (Util.ReadStreamFile(FilePath, out buffer))
            {
                int xOrValue = (int)buffer[0];
                EncryptDecryptUW1(buffer, xOrValue);
            }//end readstreamfile
            return buffer;

        }//end loadplayerdatuw1


        public static char[] LoadPlayerDatUW2(string FilePath)
        {
            char[] buffer;
            if (Util.ReadStreamFile(FilePath, out buffer))
            {
                int xOrValue = (int)buffer[0];
                buffer = EncryptDecryptUW2(buffer, (byte)xOrValue);
            }//end readstreamfile
            return buffer;
        }

        /// <summary>
        /// Encrypts or decrypts a UW1 player dat file.
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="xOrValue"></param>
        public static void EncryptDecryptUW1(char[] buffer, int xOrValue)
        {
            int incrnum = 3;
            for (int i = 1; i <= NoOfEncryptedBytes; i++)
            {
                if ((i == 81) | (i == 161))
                {
                    incrnum = 3;
                }
                buffer[i] ^= (char)((xOrValue + incrnum) & 0xFF);
                incrnum += 3;
            }
        }


        /// <summary>
        /// Encrypts or decrypts a UW2 player dat file.
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="xOrValue"></param>
        public static char[] EncryptDecryptUW2(char[] pDat, byte MS)
        {
            int[] MA = new int[80];
            MS += 7;
            for (int i = 0; i < 80; ++i)
            {
                MS += 6;
                MA[i] = MS;
            }
            for (int i = 0; i < 16; ++i)
            {
                MS += 7;
                MA[i * 5] = MS;
            }
            for (int i = 0; i < 4; ++i)
            {
                MS += 0x29;
                MA[i * 12] = MS;
            }
            for (int i = 0; i < 11; ++i)
            {
                MS += 0x49;
                MA[i * 7] = MS;
            }
            char[] buffer = new char[pDat.GetUpperBound(0) + 1];
            int offset = 1;
            int byteCounter = 0;
            for (int l = 0; l <= 11; l++)
            {
                buffer[0 + offset] = (char)(pDat[0 + offset] ^ MA[0]);
                byteCounter++;
                for (int i = 1; i < 0x50; ++i)
                {
                    if (byteCounter < 0x37D)
                    {
                        buffer[i + offset] = (char)(((pDat[i + offset] & 0xff) ^ ((buffer[i - 1 + offset] & 0xff) + (pDat[i - 1 + offset] & 0xff) + (MA[i] & 0xff))) & 0xff);
                        byteCounter++;
                    }
                }
                offset += 80;
            }
            //Copy the remainder of the plaintext data
            while (byteCounter <= pDat.GetUpperBound(0))
            {
                buffer[byteCounter] = pDat[byteCounter];
                byteCounter++;
            }
            buffer[0] = pDat[0];
            return buffer;
        }


        /// <summary>
        /// Returns the player.dat field name for UW1
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public static string FieldName(int index, int game)
        {
            if (game == 2)
            {
                return PlayerDatNames.UW2FieldName(index);
            }
            else
            {
                return PlayerDatNames.UW1FieldName(index);
            }
            
            
        }



    }//End class
}

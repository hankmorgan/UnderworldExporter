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

        }//end class
}

using UnityEngine;
using System.Collections;
using System;
using System.IO;
using System.Collections.Generic;

public class Loader: UWClass  {

	public static string BasePath = "C:\\GAMES\\UW1\\";
	public string Path;//To the file relative to the root of the game folder
	public bool DataLoaded;



    /// <summary>
    /// Reads the file into the file buffer
    /// </summary>
    /// <returns><c>true</c>, if stream file was  read, <c>false</c> otherwise.</returns>
    /// <param name="Path">Path.</param>
    /// <param name="buffer">Buffer.</param>
    public static bool ReadStreamFile(String Path, out char[] buffer)
    {
        Path = Path.Replace("--", sep.ToString());
        if (!File.Exists(Path))
        {
           // UWHUD.instance.ErrorText.text = "File not found " + Path + "\nCheck your paths in config.ini and ensure game files have been extracted. See readme.txt";
            Debug.Log("DataLoader.ReadStreamFile : File not found : " + Path);
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


    public static long ConvertInt16(char Byte1, char Byte2)
    {
        // int b1 = (int)Byte1;
        //int b2 = (int)Byte2;
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
            case 32:   
                { return ConvertInt32(buffer[Address], buffer[Address + 1], buffer[Address + 2], buffer[Address + 3]); }
            default:
                {
                    Debug.Log("Invalid data size in getValAtAddress");
                    return -1;
                }
        }
    }



}

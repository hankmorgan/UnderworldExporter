//Original code from 
//http://forum.unity3d.com/threads/tga-loader-for-unity3d.172291/

// This was made by aaro4130 on the Unity forums.  Thanks boss!
// It's been optimized and slimmed down for the purpose of loading Quake 3 TGA textures from memory streams.

using System;
using System.IO;
using UnityEngine;

public static class TGALoader
{
	
	public static Texture2D LoadTGA(string fileName)
	{
		using (var imageFile = File.OpenRead(fileName))
		{
			return LoadTGA(imageFile);
		}
	}

	public static Texture2D LoadTGA(Stream TGAStream)
	{
		
		using (BinaryReader r = new BinaryReader(TGAStream))
		{
			// Skip some header info we don't care about.
			// Even if we did care, we have to move the stream seek point to the beginning,
			// as the previous method in the workflow left it at the end.
			r.BaseStream.Seek(12, SeekOrigin.Begin);
			
			short width = r.ReadInt16();
			short height = r.ReadInt16();
			int bitDepth = r.ReadByte();
			
			// Skip a byte of header information we don't care about.
			r.BaseStream.Seek(1, SeekOrigin.Current);
			
			Texture2D tex = new Texture2D(width, height);
			Color32[] pulledColors = new Color32[width * height];
			
			if (bitDepth == 32)
			{
				for (int i = 0; i < width * height; i++)
				{
					byte red = r.ReadByte();
					byte green = r.ReadByte();
					byte blue = r.ReadByte();
					byte alpha = r.ReadByte();
					
					pulledColors [i] = new Color32(blue, green, red, alpha);
				}
			} else if (bitDepth == 24)
			{
				for (int i = 0; i < width * height; i++)
				{
					byte red = r.ReadByte();
					byte green = r.ReadByte();
					byte blue = r.ReadByte();
					
					pulledColors [i] = new Color32(blue, green, red, 1);
				}
			} else
			{
				throw new Exception("TGA texture had non 32/24 bit depth.");
			}
			
			tex.SetPixels32(pulledColors);
			tex.Apply();
			return tex;
		}
	}


}
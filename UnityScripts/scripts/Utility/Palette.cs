using UnityEngine;
using System.Collections;

/// <summary>
/// RGB palettes for graphics
/// </summary>
public class Palette : UWClass {

	public byte[] red= new byte[256];
	public byte[] blue= new byte[256];
	public byte[] green= new byte[256];


	/// <summary>
	/// Returns the color for the specified palette index. 
	/// </summary>
	/// <returns>The at pixel.</returns>
	/// <param name="pixel">Pixel.</param>
	/// <param name="Alpha">If set to <c>true</c> alpha.</param>
	public Color32 ColorAtPixel(byte pixel, bool Alpha)
	{
		byte alpha;
		if (Alpha == true)
		{
			if (pixel != 0)	//Alpha
			{
				alpha = 255;
			}
			else
			{
				alpha = 0;
			}
		}
		else
		{
			alpha = 0;
		}
		return new Color32(red[pixel], green[pixel],blue[pixel], alpha);
	}

	/// <summary>
	/// Converts the palette to an image.
	/// </summary>
	/// <returns>The image.</returns>
	static public Texture2D toImage(Palette pal)
	{
				if (pal==null)
				{
						Debug.Log("Null Palette in cyclePalette");
						return null;
				}
		//int pixelcount=0;
		int height = 1; int width = 256;
		Texture2D image = new Texture2D(width, height,TextureFormat.ARGB32,false);
		Color32[] imageColors = new Color32[256 * 1];
		long counter=0;
		byte alpha=0;
		for (int iRow = height - 1; iRow >= 0; iRow--)
		{
			for (int j = (iRow *width); j <(iRow*width) + width; j++)
			{
				if (counter != 0)	//Alpha
				{
						alpha = 255;
				}
				imageColors [counter] = new Color32(pal.red[counter], pal.green[counter], pal.blue[counter], alpha);
				counter++;
			}
		}
		image.filterMode=FilterMode.Point;
		//image.alphaIsTransparency=Alpha;
		image.SetPixels32(imageColors);
		image.Apply();
		return image;	
	}

	/// <summary>
	/// Cycles the palette.
	/// </summary>
	/// <param name="pal">Pal.</param>
	/// <param name="Start">Start.</param>
	/// <param name="length">Length.</param>
	public static void cyclePalette(Palette pal, int Start, int length )
	{
		/*Shifts the palette values around between the start and start+length. Used for texture animations and special effects*/
				if (pal==null)
				{
						Debug.Log("Null Palette in cyclePalette");
						return;
				}
		byte firstRed = pal.red[Start];
		byte firstGreen = pal.green[Start];
		byte firstBlue = pal.blue[Start];
		for (int i = Start; i < Start + length - 1; i++)
		{
			pal.red[i] = pal.red[i + 1];
			pal.green[i] = pal.green[i + 1];
			pal.blue[i] = pal.blue[i + 1];
		}
		pal.red[Start + length - 1] = firstRed;
		pal.green[Start + length - 1] = firstGreen;
		pal.blue[Start + length - 1] = firstBlue;
	}

}

using UnityEngine;
using System.Collections;

/// <summary>
/// Game Palettes.
/// </summary>
public class Palette  {
	
	public byte[] red= new byte[256];
	public byte[] blue= new byte[256];
	public byte[] green= new byte[256];


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
}

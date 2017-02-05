using UnityEngine;
using System.Collections;

/// <summary>
/// RGB palettes for graphics
/// </summary>
public class Palette {

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
}

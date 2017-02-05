using UnityEngine;
using System.Collections;


/// <summary>
/// Base class for loading artwork
/// </summary>
public class ArtLoader : Loader {

	/// <summary>
	/// The complete image file 
	/// </summary>
	protected char[] ImageFileData;

	/// <summary>
	/// Loads the image file into the buffer
	/// </summary>
	/// <returns><c>true</c>, if image file was loaded, <c>false</c> otherwise.</returns>
	public virtual bool LoadImageFile()
	{
		if (DataLoader.ReadStreamFile(BasePath + Path, out ImageFileData))
		{//data read
			DataLoaded=true;
		}
		else
		{
			DataLoaded=false;
		}
		return DataLoaded;
	}
				
	/// <summary>
	/// Loads the image at index.
	/// </summary>
	/// <returns>The <see cref="UnityEngine.Texture2D"/>.</returns>
	/// <param name="index">Index.</param>
	public virtual Texture2D LoadImageAt(int index)
	{
		return new Texture2D(1,1);
	}


	/// <summary>
	/// Generates the image from the specified data buffer position
	/// </summary>
	/// <param name="databuffer">Databuffer.</param>
	/// <param name="dataOffSet">Data off set.</param>
	/// <param name="width">Width.</param>
	/// <param name="height">Height.</param>
	/// <param name="imageName">Image name.</param>
	/// <param name="pal">Pal.</param>
	/// <param name="Alpha">If set to <c>true</c> alpha.</param>
	protected Texture2D Image(char[] databuffer,long dataOffSet, int width, int height, string imageName, Palette pal , bool Alpha )
	{
		int pixelcount=0;
		Texture2D image = new Texture2D(width, height);
		Color32[] imageColors = new Color32[width * height];
		long counter=0;
		for (int iRow = height - 1; iRow >= 0; iRow--)
		{
			for (int j = (iRow *width); j <(iRow*width) + width; j++)
			{
				byte pixel = (byte)DataLoader.getValAtAddress(databuffer, dataOffSet + (long)j, 8);
				imageColors [counter++] = pal.ColorAtPixel(pixel,Alpha); //new Color32(blue, green, red, alpha);
			}
		}
		image.filterMode=FilterMode.Point;
		image.alphaIsTransparency=Alpha;
		image.SetPixels32(imageColors);
		image.Apply();
		return image;
	}

}

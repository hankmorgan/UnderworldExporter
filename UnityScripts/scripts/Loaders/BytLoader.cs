using UnityEngine;
using System.Collections;

/// <summary>
/// Byt loader. Loads from UW1 byt files in the data folder
/// </summary>
public class BytLoader : ArtLoader {
		public const int BLNKMAP_BYT =0;
		public const int CHARGEN_BYT =1;
		public const int CONV_BYT =2;
		public const int MAIN_BYT =3;
		public const int OPSCR_BYT =4;
		public const int PRES1_BYT =5;
		public const int PRES2_BYT =6;
		public const int WIN1_BYT =7;
		public const int WIN2_BYT =8;

		private int currentIndex=-1;

		private string[] FilePaths={
			"Data\\BLNKMAP.BYT",
			"Data\\CHARGEN.BYT",
			"Data\\CONV.BYT",
			"Data\\MAIN.BYT",
			"Data\\OPSCR.BYT",
		 	"Data\\PRES1.BYT",
			"Data\\PRES2.BYT",
			"Data\\WIN1.BYT",
			"Data\\WIN2.BYT"
		};

		private int[] PaletteIndices=
		{
			3,
			9,
			0,
			0,
			6,
			15,
			15,
			0,
			22	
		};


	/// <summary>
	/// Loads the texture form a byt file
	/// </summary>
	/// <returns>The <see cref="UnityEngine.Texture2D"/>.</returns>
	/// <param name="index">Index.</param>
	/// In this case the index is a loading of the seperate file. 
	public override Texture2D LoadImageAt (int index)
	{
		return LoadImageAt(index,false);
	}



	public override Texture2D LoadImageAt (int index, bool Alpha)
	{
		if (currentIndex!=index)
		{//Only load from disk if the image to bring back has changed.
			DataLoaded=false;
			Path=FilePaths[index];
			LoadImageFile();		
		}

		return Image(ImageFileData,0,320,200,"name_goes_here",GameWorldController.instance.palLoader.Palettes[PaletteIndices[index]],Alpha);
	}
}

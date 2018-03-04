using UnityEngine;
using System.Collections;
using System.IO;

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
		public const int PRESD_BYT =9;

		//UW2 bitmap indices
		public const int UW2MAIN_BYT=5;


		private int currentIndex=-1;


		private string[] FilePaths={
			"DATA--BLNKMAP.BYT",
			"DATA--CHARGEN.BYT",
			"DATA--CONV.BYT",
			"DATA--MAIN.BYT",
			"DATA--OPSCR.BYT",
		 	"DATA--PRES1.BYT",
			"DATA--PRES2.BYT",
			"DATA--WIN1.BYT",
			"DATA--WIN2.BYT",
			"DATA--PRESD.BYT"
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
			22,
			0
		};


		private int[] PaletteIndicesUW2=
		{
			3,
			0,
			0,
			0,
			0,
			0,
			15,
			15,
			0,
			0,
			0
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
		switch (_RES)
		{
		case GAME_UW2:
			{
								
				return  extractUW2Bitmap("DATA" + sep + "BYT.ARK", index, Alpha);
			}
		default:
			{
				if (File.Exists(BasePath +FilePaths[index].Replace("--", sep.ToString()).Replace(".","_") + sep + "001.tga"))
				{
					return TGALoader.LoadTGA(BasePath + FilePaths[index].Replace("--", sep.ToString()).Replace(".","_") + sep + "001.tga")	;
				}
			if (currentIndex!=index)
				{//Only load from disk if the image to bring back has changed.
					DataLoaded=false;
					Path=FilePaths[index];
					LoadImageFile();		
				}
				return Image(ImageFileData,0,320,200,"name_goes_here",GameWorldController.instance.palLoader.Palettes[PaletteIndices[index]],Alpha);
			}
		}
	}

		public Texture2D extractUW2Bitmap(string path, int index, bool Alpha)
		{
			char[] textureFile;          // Pointer to our buffered data (little endian format)
			//int i;
			long NoOfTextures;

				if (File.Exists(BasePath +path.Replace(".","_") + sep + index.ToString("d3") + ".tga"))
				{
					return TGALoader.LoadTGA(BasePath +path.Replace(".","_") + sep + index.ToString("d3") + ".tga")	;
				}

			if (!DataLoader.ReadStreamFile(BasePath + path, out textureFile))
			{return null;}
			// Get the size of the file in bytes

			NoOfTextures = DataLoader.getValAtAddress(textureFile,0,8);
			long textureOffset = (int)DataLoader.getValAtAddress(textureFile, (index * 4) + 6, 32);
			if (textureOffset !=0)
			{
					int compressionFlag=(int)DataLoader.getValAtAddress(textureFile,((index * 4) + 6)+(NoOfTextures*4),32);
					int isCompressed =(compressionFlag>>1) & 0x01;
					if (isCompressed==1)	
					{
						long datalen=0;
						return Image(DataLoader.unpackUW2(textureFile,textureOffset,ref datalen),0,320,200,"namehere",GameWorldController.instance.palLoader.Palettes[PaletteIndicesUW2[index]],Alpha);
					}
					else
					{
						return Image(textureFile,textureOffset,320,200,"name_goes_here",GameWorldController.instance.palLoader.Palettes[PaletteIndicesUW2[index]],Alpha);	
					}
			}
				return null;
		}



}

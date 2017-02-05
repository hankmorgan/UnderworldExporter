using UnityEngine;
using System.Collections;

/// <summary>
/// Palette loader.
/// </summary>
public class PaletteLoader : ArtLoader {

	public Palette[] Palettes = new Palette[22];
	public int NoOfPals=22;

	public void LoadPalettes()
	{
		char[] pals_dat;
		Palettes=new Palette[NoOfPals];
		if(DataLoader.ReadStreamFile(Path,out pals_dat))
		{
			for (int palNo =0; palNo<=Palettes.GetUpperBound(0); palNo++ )
			{
				Palettes[palNo]=new Palette();
				for (int pixel=0; pixel<256; pixel++)
				{
					Palettes[palNo].red[pixel]= (byte)(DataLoader.getValAtAddress(pals_dat, palNo*256 + (pixel*3) + 0 ,8) <<2);
					Palettes[palNo].green[pixel]= (byte)(DataLoader.getValAtAddress(pals_dat, palNo*256 + (pixel*3) + 1 ,8) <<2);
					Palettes[palNo].blue[pixel]= (byte)(DataLoader.getValAtAddress(pals_dat, palNo*256 + (pixel*3) + 2 ,8) <<2);
				}
			}

		}
	}



	public static Palette LoadAuxilaryPal(string auxPalPath, Palette gamepal, int auxPalIndex)
	{
		char[] palf;
		Palette auxpal = new Palette();
		auxpal.red = new byte[16];
		auxpal.green = new byte[16];
		auxpal.blue = new byte[16];
		if (DataLoader.ReadStreamFile(auxPalPath, out palf))
		{
			for (int j = 0; j <16; j++)
			{
				int value = (int)DataLoader.getValAtAddress(palf, auxPalIndex * 16 + j, 8);
				auxpal.green[j] = gamepal.green[value];
				auxpal.blue[j] = gamepal.blue[value];
				auxpal.red[j] = gamepal.red[value];
			}
		}
		return auxpal;
	}
}

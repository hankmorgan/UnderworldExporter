using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace UnderworldEditor
{

    /// <summary>
    /// Palette loader.
    /// </summary>
    public class PaletteLoader : ArtLoader
    {

        public static Palette[] Palettes = new Palette[22];
        public static int NoOfPals = 22;
        public static Palette GreyScale = null;

        public PaletteLoader(string PathToResource, short chunkID)
        {
            //Path = Loader.BasePath + PathToResource;
            if (main.curgame == main.GAME_UW2)
            {
                PaletteNo = chunkID;
            }
            LoadPalettes("c:\\games\\uw1\\data\\pals.dat");
        }

        public static int GetNearestColour(Color ColourToMatch, Palette pal)
        {
            int nearest =0;
            int nearestindex = 0;
            int newred = ColourToMatch.R;
            int newgreen = ColourToMatch.G;
            int newblue = ColourToMatch.B;

            for (int i=0; i<=pal.red.GetUpperBound(0);i++)
            {
                int diff = Math.Abs((int)pal.red[i] - newred) 
                    + Math.Abs((int)pal.green[i] - newgreen) 
                    + Math.Abs((int)pal.blue[i] - newblue);
                if (i==0)
                {
                    nearest = diff;
                    nearestindex = 0;
                }
                else
                {
                    if (diff<nearest)
                    {
                        nearest = diff;
                        nearestindex = i;
                    }
                }  
            }
            return nearestindex;
        }



        public static void LoadPalettes(string Path)
        {
            GreyScale = new Palette();
            for (int i = 0; i <= GreyScale.blue.GetUpperBound(0); i++)
            {
                GreyScale.red[i] = (byte)i;
                GreyScale.blue[i] = (byte)i;
                GreyScale.green[i] = (byte)i;
            }
            switch (main.curgame)
            {
                default:
                    {
                        char[] pals_dat;
                        Palettes = new Palette[NoOfPals];
                        if (Util.ReadStreamFile(Path, out pals_dat))
                        {
                            for (int palNo = 0; palNo <= Palettes.GetUpperBound(0); palNo++)
                            {
                                Palettes[palNo] = new Palette();
                                for (int pixel = 0; pixel < 256; pixel++)
                                {
                                    Palettes[palNo].red[pixel] = (byte)(Util.getValAtAddress(pals_dat, palNo * 256 + (pixel * 3) + 0, 8) << 2);
                                    Palettes[palNo].green[pixel] = (byte)(Util.getValAtAddress(pals_dat, palNo * 256 + (pixel * 3) + 1, 8) << 2);
                                    Palettes[palNo].blue[pixel] = (byte)(Util.getValAtAddress(pals_dat, palNo * 256 + (pixel * 3) + 2, 8) << 2);
                                }
                            }

                        }
                    }
                    break;
            }
        }

        public static int[] LoadAuxilaryPalIndices(string auxPalPath, int auxPalIndex)
        {
            char[] palf;
            int[] auxpal = new int[16];

            if (Util.ReadStreamFile(auxPalPath, out palf))
            {
                for (int j = 0; j < 16; j++)
                {
                    auxpal[j] = (int)Util.getValAtAddress(palf, auxPalIndex * 16 + j, 8);
                }
            }
            return auxpal;
        }

        public static Palette LoadAuxilaryPal(string auxPalPath, Palette gamepal, int auxPalIndex)
        {
            char[] palf;
            Palette auxpal = new Palette();
            auxpal.red = new byte[16];
            auxpal.green = new byte[16];
            auxpal.blue = new byte[16];
            if (Util.ReadStreamFile(auxPalPath, out palf))
            {
                for (int j = 0; j < 16; j++)
                {
                    int value = (int)Util.getValAtAddress(palf, auxPalIndex * 16 + j, 8);
                    auxpal.green[j] = gamepal.green[value];
                    auxpal.blue[j] = gamepal.blue[value];
                    auxpal.red[j] = gamepal.red[value];
                }
            }
            return auxpal;
        }


        /// <summary>
        /// Returns a palette as an image.
        /// </summary>
        /// <returns>The to image.</returns>
        /// <param name="PalIndex">Pal index.</param>
        public static Bitmap PaletteToImage(int PalIndex)
        {
            int height = 1;
            int width = 256;
            char[] imgData = new char[height * width];
            for (int i = 0; i < imgData.GetUpperBound(0); i++)
            {
                imgData[i] = (char)i;
            }
            BitmapUW output= ArtLoader.Image(null, imgData, 0,0, width, height, "name here", Palettes[PalIndex], true, BitmapUW.ImageTypes.Palette);
            return output.image;

        }
    }

}

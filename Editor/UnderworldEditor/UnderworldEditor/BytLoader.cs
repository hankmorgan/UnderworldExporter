using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;

namespace UnderworldEditor
{
    public class BytLoader : ArtLoader
    {
        public const int BLNKMAP_BYT = 0;
        public const int CHARGEN_BYT = 1;
        public const int CONV_BYT = 2;
        public const int MAIN_BYT = 3;
        public const int OPSCR_BYT = 4;
        public const int PRES1_BYT = 5;
        public const int PRES2_BYT = 6;
        public const int WIN1_BYT = 7;
        public const int WIN2_BYT = 8;
        public const int PRESD_BYT = 9;

        //UW2 bitmap indices
        public const int UW2MAIN_BYT = 5;

        string FileName;

        private int currentIndex = -1;

        public static string[] FilePaths ={
            "BLNKMAP.BYT",
            "CHARGEN.BYT",
            "CONV.BYT",
            "MAIN.BYT",
            "OPSCR.BYT",
            "PRES1.BYT",
            "PRES2.BYT",
            "WIN1.BYT",
            "WIN2.BYT" //,
           // "PRESD.BYT"
        };

        private int[] PaletteIndices =
        {
            3,
            9,
            0,
            0,
            6,
            15,
            15,
            0,
            0,//this is probably wrong
            0
        };


        private int[] PaletteIndicesUW2 =
        {
            3,
            0,
            0,
            0,
            0,
            0,
            0,//15,
            0,//15,
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
        public override BitmapUW LoadImageAt(int index)
        {
            return LoadImageAt(index, false);
        }



        public override BitmapUW LoadImageAt(int index, bool Alpha)
        {
            switch (main.curgame)
            {
                case main.GAME_UW2:
                    {
                        return extractUW2Bitmap(main.basepath + "\\DATA\\BYT.ARK", index, Alpha);
                    }
                default:
                    {
                        if (currentIndex != index)
                        {//Only load from disk if the image to bring back has changed.
                            DataLoaded = false;
                            FileName = main.basepath + "\\data\\" + FilePaths[index];
                            LoadImageFile();
                        }
                        return Image(ImageFileData, 0, 0, 320, 200, "name_goes_here", PaletteLoader.Palettes[PaletteIndices[index]], Alpha, BitmapUW.ImageTypes.Byt);
                    }
            }
        }

        public BitmapUW extractUW2Bitmap(string path, int index, bool Alpha)
        {
            char[] textureFile;          // Pointer to our buffered data (little endian format)
                                         //int i;
            long NoOfTextures;


            if (!Util.ReadStreamFile(path, out textureFile))
            { return null; }
            // Get the size of the file in bytes

            NoOfTextures = Util.getValAtAddress(textureFile, 0, 8);
            long textureOffset = (int)Util.getValAtAddress(textureFile, (index * 4) + 6, 32);
            if (textureOffset != 0)
            {
                int compressionFlag = (int)Util.getValAtAddress(textureFile, ((index * 4) + 6) + (NoOfTextures * 4), 32);
                int isCompressed = (compressionFlag >> 1) & 0x01;
                if (isCompressed == 1)
                {
                    long datalen = 0;
                    return Image(Util.unpackUW2(textureFile, textureOffset, ref datalen), 0, index, 320, 200, "namehere", PaletteLoader.Palettes[PaletteIndicesUW2[index]], Alpha, BitmapUW.ImageTypes.Byt);
                }
                else
                {
                    return Image(textureFile, textureOffset, index, 320, 200, "name_goes_here", PaletteLoader.Palettes[PaletteIndicesUW2[index]], Alpha, BitmapUW.ImageTypes.Byt);
                }
            }
            return null;
        }


        /// <summary>
        /// Loads the image file into the buffer
        /// </summary>
        /// <returns><c>true</c>, if image file was loaded, <c>false</c> otherwise.</returns>
        public bool LoadImageFile()
        {
            if (Util.ReadStreamFile(FileName, out ImageFileData))
            {//data read
                DataLoaded = true;
            }
            else
            {
                DataLoaded = false;
            }
            return DataLoaded;
        }

    }
}

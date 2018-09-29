using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace UnderworldEditor
{
    /// <summary>
    /// Class for manipulating images and storing properties.
    /// </summary>
    public class BitmapUW 
    {
        public Bitmap image;
        public Palette ImagePalette;
        public long FileOffset;
        public int ImageNo;
        public ArtLoader artdata;
        public enum ImageTypes
        {
            Texture,
            EightBitUncompressed,
            Byt,
            FourBitRunLength,
            FourBitUncompress,
            Palette,
            Unknown
                //And the rest.
        }

        public ImageTypes ImageType;
        public char[] UncompressedData;
        public int[] PaletteRef; //Either the auxpal used or the greyscale palette.
        public bool Modified = false;
        
        public BitmapUW()
        {
            PaletteRef = new int[256];
            for (int i=0;i<256;i++)
            {
                PaletteRef[i] = i;
            }
        }

        public void SetAuxPalRef(int[] aux)
        {
            PaletteRef = aux;
        }

    }
}

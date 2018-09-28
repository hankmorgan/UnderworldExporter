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

    }
}

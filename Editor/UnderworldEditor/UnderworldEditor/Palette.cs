using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace UnderworldEditor
{
    public class Palette
    {
        public byte[] red = new byte[256];
        public byte[] blue = new byte[256];
        public byte[] green = new byte[256];

        public Palette()
        {
            
        }

        public Palette(int size)
        {
         red = new byte[size];
         blue = new byte[size];
         green = new byte[size];
        }


        /// <summary>
        /// Returns the color for the specified palette index. 
        /// </summary>
        /// <returns>The at pixel.</returns>
        /// <param name="pixel">Pixel.</param>
        /// <param name="Alpha">If set to <c>true</c> alpha.</param>
        public Color ColorAtPixel(byte pixel, bool Alpha)
        {
            byte alpha;
            if (Alpha == true)
            {
                if (pixel != 0) //Alpha
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
            return Color.FromArgb((int)alpha, (int)red[pixel], (int)green[pixel], (int)blue[pixel]);
        }          


    }//end class
}

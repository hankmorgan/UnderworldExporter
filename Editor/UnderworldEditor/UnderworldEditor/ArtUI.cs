using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace UnderworldEditor
{
    class ArtUI
    {

        public static void setPixelAtLocation(TextureLoader artfile, int imageNo, PictureBox img, int x, int y, int newpixel)
        {
            if (artfile == null) { return; }
            if (img.Image == null) { return; }
            //(Bitmap)(img.Image).SetPixel(x, y, PaletteLoader.Palettes[0].ColorAtPixel(50, false));
            artfile.ImageCache[imageNo].SetPixel(x, y, PaletteLoader.Palettes[0].ColorAtPixel((byte)newpixel, false));
            switch (main.curgame)
            {
                case main.GAME_UW1:
                    if (imageNo<210)
                    {
                        artfile.texturebufferW[artfile.OffsetT[imageNo] + y * 64 + x] = (char)newpixel;
                    }
                    break;
            }            
            img.Image = artfile.ImageCache[imageNo];
        }

        public static void SaveTextureData(char[] artfile, bool IsUW1Wall)
        {
            switch (main.curgame)
            {
                case main.GAME_UW1:
                    if (IsUW1Wall)
                    {
                        Util.WriteStreamFile(main.basepath + "\\data\\W64_test.TR", artfile);
                    }
                    else
                    {
                        Util.WriteStreamFile(main.basepath + "\\data\\F64_test.TR", artfile);
                    }                    
                    break;
                case main.GAME_UW2:
                    Util.WriteStreamFile(main.basepath + "\\data\\T64_test.TR", artfile);
                    break;
            }           
        }

    }//endclass
}

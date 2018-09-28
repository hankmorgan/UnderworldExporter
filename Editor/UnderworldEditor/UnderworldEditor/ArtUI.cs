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

        public static void setPixelAtLocation(TextureLoader artfile, BitmapUW currentimg, PictureBox img, int x, int y, int newpixel)
        {
            if (artfile == null) { return; }
            if (img.Image == null) { return; }
            artfile.ImageCache[currentimg.ImageNo].image.SetPixel(x, y, PaletteLoader.Palettes[0].ColorAtPixel((byte)newpixel, false));
            switch (main.CurrentImage.ImageType)
            {
                case BitmapUW.ImageTypes.Texture:
                    {
                        switch (main.curgame)
                        {
                            case main.GAME_UW1:
                                if (currentimg.ImageNo < 210)
                                {
                                    artfile.texturebufferW[artfile.OffsetT[currentimg.ImageNo] + y * 64 + x] = (char)newpixel;
                                }
                                break;
                        }
                        main.CurrentImage = artfile.ImageCache[currentimg.ImageNo];
                        img.Image = main.CurrentImage.image;
                        break;
                    }
            }
        }

        public static void SaveTextureData(char[] artfile, bool IsUW1Wall)
        {
            switch (main.curgame)
            {
                case main.GAME_UW1:
                    if (IsUW1Wall)
                    {
                        Util.WriteStreamFile(main.basepath + "\\data\\W64.TR", artfile);
                    }
                    else
                    {
                        Util.WriteStreamFile(main.basepath + "\\data\\F64.TR", artfile);
                    }                    
                    break;
                case main.GAME_UW2:
                    Util.WriteStreamFile(main.basepath + "\\data\\T64.TR", artfile);
                    break;
            }           
        }

    }//endclass
}

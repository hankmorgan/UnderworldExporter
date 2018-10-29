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

        public static void setPixelAtLocation(BitmapUW currentimg, PictureBox img, int x, int y, int newpixel, int auxpixel)
        {
            if (currentimg.artdata == null) { return; }
            if (img.Image == null) { return; }
            currentimg.artdata.ImageCache[currentimg.ImageNo].image.SetPixel(x, y, currentimg.ImagePalette.ColorAtPixel((byte)newpixel, false));
            
            switch (main.CurrentImage.ImageType)
            {
                case BitmapUW.ImageTypes.Texture:
                    {
                        TextureLoader texdata = (TextureLoader)currentimg.artdata;
                        switch (main.curgame)
                        {
                            case main.GAME_UW1:
                                {
                                    if (currentimg.ImageNo < 210)
                                    {
                                        texdata.texturebufferW[currentimg.FileOffset + y * 64 + x] = (char)newpixel;
                                    }
                                    else
                                    {
                                        texdata.texturebufferF[currentimg.FileOffset + y * 32 + x] = (char)newpixel;
                                    }
                                    currentimg.artdata.Modified = true;
                                    break;
                                }
                            case main.GAME_UW2:
                                {
                                    texdata.texturebufferT[currentimg.FileOffset + y * 64 + x] = (char)newpixel;
                                    currentimg.artdata.Modified = true;
                                    break;
                                }
                        }
                        break;
                    }
                case BitmapUW.ImageTypes.Byt:               
                    {
                        switch (main.curgame)
                        {
                            case main.GAME_UW1:
                                {
                                    BytLoader byt = (BytLoader)currentimg.artdata;
                                    byt.ImageFileData[currentimg.FileOffset + y * (currentimg.image.Width) + x] = (char)newpixel;
                                    currentimg.artdata.Modified = true;
                                    break;
                                }
                        }
                        break;
                    }
                case BitmapUW.ImageTypes.EightBitUncompressed:
                    {
                        GRLoader gr = (GRLoader)currentimg.artdata;
                        gr.ImageFileData[currentimg.FileOffset + y * (currentimg.image.Width) + x] = (char)newpixel;
                        currentimg.artdata.Modified = true;
                        break;
                    }
                case BitmapUW.ImageTypes.FourBitUncompress:
                    {
                        GRLoader gr = (GRLoader)currentimg.artdata;
                        int Offset =  y * (currentimg.image.Width) + x;
                        long NibbleAddress = currentimg.FileOffset + (Offset / 2);
                        int HiOrLow = Offset % 2;
                        if (HiOrLow==1)
                        {//low nibble
                            gr.ImageFileData[NibbleAddress] = (char)(gr.ImageFileData[NibbleAddress] & 0xF0);
                            gr.ImageFileData[NibbleAddress] =(char)( gr.ImageFileData[NibbleAddress] | ((char)auxpixel & 0xf));
                        }
                        else
                        {
                            gr.ImageFileData[NibbleAddress] = (char)(gr.ImageFileData[NibbleAddress] & 0x0F);
                            gr.ImageFileData[NibbleAddress] = (char)(gr.ImageFileData[NibbleAddress] | ((char)(auxpixel<<4) & 0xf0));
                        }
                       
                        currentimg.artdata.Modified = true;
                        break;
                    }
                //case BitmapUW.ImageTypes.FourBitRunLength:
                //    {
                        //GRLoader gr = (GRLoader)currentimg.artdata;
                        //currentimg.UncompressedData[y * (currentimg.image.Width) + x] = (char)auxpixel;
                        //currentimg.artdata.Modified = true;                        
                //        break;
                //    }
                default:
                    {
                        return;
                    // img.Image = main.CurrentImage.image;
                        //break;
                    }
            }
            currentimg.Modified = true;
            main.CurrentImage = currentimg.artdata.ImageCache[currentimg.ImageNo];
            img.Image = main.CurrentImage.image;

        }

        public static void SaveBytDataUW1(char[] artfile, string filename)
        {
            Util.WriteStreamFile(main.basepath + filename, artfile);
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
                        Util.WriteStreamFile(main.basepath + "\\data\\F32.TR", artfile);
                    }                    
                    break;
                case main.GAME_UW2:
                    Util.WriteStreamFile(main.basepath + "\\data\\T64.TR", artfile);
                    break;
            }           
        }


        public static Bitmap UWMap(TileMap tm, TextureLoader tex)
        {           

            Bitmap output = new Bitmap(64* TextureLoader.LOWRESSIZE, 64* TextureLoader.LOWRESSIZE);
            System.Drawing.Graphics display = Graphics.FromImage(output);
            display.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            for (int x = 0; x <= 63 ; x++)
            {
                for (int y = 0; y <=63; y++)
                {
                    if ((tm.Tiles[x, y].Render) && (tm.Tiles[x, y].tileType !=0))
                    {
                        int floortex = TileMap.FloorTextureMapped(tm, TileMap.fTOP, tm.Tiles[x, y], main.curgame);
                        switch (tm.Tiles[x, y].tileType)
                        {
                            case TileMap.TILE_SOLID:
                                break;
                            case TileMap.TILE_DIAG_NE:
                                display.DrawImage(tex.LowResAt(floortex), x * TextureLoader.LOWRESSIZE, (63 - y) * TextureLoader.LOWRESSIZE);
                                display.DrawImage(tex.MaskNE, x * TextureLoader.LOWRESSIZE, (63 - y) * TextureLoader.LOWRESSIZE);
                                break;
                            case TileMap.TILE_DIAG_NW:
                                display.DrawImage(tex.LowResAt(floortex), x * TextureLoader.LOWRESSIZE, (63 - y) * TextureLoader.LOWRESSIZE);
                                display.DrawImage(tex.MaskNW, x * TextureLoader.LOWRESSIZE, (63 - y) * TextureLoader.LOWRESSIZE);
                                break;
                            case TileMap.TILE_DIAG_SW:
                                display.DrawImage(tex.LowResAt(floortex), x * TextureLoader.LOWRESSIZE, (63 - y) * TextureLoader.LOWRESSIZE);
                                display.DrawImage(tex.MaskSW, x * TextureLoader.LOWRESSIZE, (63 - y) * TextureLoader.LOWRESSIZE);
                                break;
                            case TileMap.TILE_DIAG_SE:
                                display.DrawImage(tex.LowResAt(floortex), x * TextureLoader.LOWRESSIZE, (63 - y) * TextureLoader.LOWRESSIZE);
                                display.DrawImage(tex.MaskSE, x * TextureLoader.LOWRESSIZE, (63 - y) * TextureLoader.LOWRESSIZE);
                                break;

                            default:
                                display.DrawImage(tex.LowResAt(floortex), x * TextureLoader.LOWRESSIZE, (63 - y) * TextureLoader.LOWRESSIZE);
                                break;
                        }
                        
                       
                    }
                }
            }
            return output;
        }

    }//endclass
}

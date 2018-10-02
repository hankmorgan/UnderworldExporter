using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace UnderworldEditor
{
    public class TextureLoader: ArtLoader
    {
        public const int LOWRESSIZE = 16;
        private string pathTexW_UW0 = "DATA\\DW64.TR";
        private string pathTexF_UW0 = "DATA\\DF32.TR";
        private string pathTexW_UW1 = "DATA\\W64.TR";
        private string pathTexF_UW1 = "DATA\\F32.TR";
        private string pathTex_UW2 = "DATA\\T64.TR";
        private string pathTex_SS1 = "RES\\DATA\\Texture.res";

        public char[] texturebufferW;//uw1 wall file data
        public char[] texturebufferF;//uw1 floor file data
        public char[] texturebufferT;//uw2 file data

        public long[] OffsetT = new long[261]; //file address offsets for texutres

        public bool texturesWLoaded;
        public bool texturesFLoaded;
        private int TextureSplit = 210;//at what point does a texture index refer to the floor instead of a wall in uw1/demo
        private int FloorDim = 32;

        public const float BumpMapStrength = 1f;

        private Bitmap[] imageCacheLowRes;

        public TextureLoader()
        {
            ImageCache = new BitmapUW[261];
            imageCacheLowRes = new Bitmap[261];
        }

        public override BitmapUW LoadImageAt(int index)
        {
            return LoadImageAt(index, PaletteLoader.Palettes[0]);
        }

        /// <summary>
        /// Loads the image at index.
        /// </summary>
        /// <returns>The <see cref="UnityEngine.Texture2D"/>.</returns>
        /// <param name="index">Index.</param>
        /// <param name="palToUse">Pal to use.</param>
        /// If the index is greater than 209 I return a floor texture.
        public BitmapUW LoadImageAt(int index, Palette palToUse)
        {
            if (main.curgame == main.GAME_UW2)
            {
                FloorDim = 64;
            }

            switch (main.curgame)
            {
                case main.GAME_UW2:
                    {
                        if (ImageCache[index] != null)
                        {
                            return ImageCache[index];
                        }
                        if (texturesFLoaded == false)
                        {
                            if (!Util.ReadStreamFile(main.basepath + "\\" + pathTex_UW2, out texturebufferT))
                            {
                                return base.LoadImageAt(index);
                            }
                            else
                            {
                                texturesFLoaded = true;
                            }
                        }
                        long textureOffset = Util.getValAtAddress(texturebufferT, ((index) * 4) + 4, 32);
                        OffsetT[index] = textureOffset;
                        ImageCache[index] = Image(this, texturebufferT, textureOffset, index, FloorDim, FloorDim, "name_goes_here", palToUse, false, BitmapUW.ImageTypes.Texture);
                        return ImageCache[index];
                    }

                case main.GAME_UW1:
                default:
                    {
                        //if (ImageCache[index]!=null)
                        //{
                        //    return ImageCache[index];
                        //}
                        if (index < TextureSplit)
                        {//Wall textures
                            if (texturesWLoaded == false)
                            {
                                if (!Util.ReadStreamFile(main.basepath + "\\" + pathTexW_UW1, out texturebufferW))
                                {
                                    return base.LoadImageAt(index);
                                }
                                else
                                {
                                    texturesWLoaded = true;
                                }
                            }
                            long textureOffset = Util.getValAtAddress(texturebufferW, (index * 4) + 4, 32);
                            OffsetT[index] = textureOffset;
                            ImageCache[index] = Image(this, texturebufferW, textureOffset, index, 64, 64, "name_goes_here", palToUse, false, BitmapUW.ImageTypes.Texture);
                            return ImageCache[index];
                        }
                        else
                        {//Floor textures (to match my list of textures)
                            if (texturesFLoaded == false)
                            {
                                if (!Util.ReadStreamFile(main.basepath + "\\" + pathTexF_UW1, out texturebufferF))
                                {
                                    return base.LoadImageAt(index);
                                }
                                else
                                {
                                    texturesFLoaded = true;
                                }
                            }
                            long textureOffset = Util.getValAtAddress(texturebufferF, ((index - TextureSplit) * 4) + 4, 32);
                            OffsetT[index] = textureOffset;
                            ImageCache[index] = Image(this, texturebufferF, textureOffset, index, FloorDim, FloorDim, "name_goes_here", palToUse, false, BitmapUW.ImageTypes.Texture);                            
                            return ImageCache[index];
                        }
                    }//end switch	
            }
        }
         
         public Bitmap LowResAt(int index)
        {
            if (imageCacheLowRes[index] == null)
            {
                BitmapUW tmp = LoadImageAt(index);
                imageCacheLowRes[index]= ArtLoader.Resize(tmp.image, LOWRESSIZE, LOWRESSIZE);
            }
            return imageCacheLowRes[index];
        }

    }//end class
}

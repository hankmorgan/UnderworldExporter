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
        
        private string pathTexW_UW0 = "DATA\\DW64.TR";
        private string pathTexF_UW0 = "DATA\\DF32.TR";
        private string pathTexW_UW1 = "DATA\\W64.TR";
        private string pathTexF_UW1 = "DATA\\F32.TR";
        private string pathTex_UW2 = "DATA\\T64.TR";
        private string pathTex_SS1 = "RES\\DATA\\Texture.res";

        char[] texturebufferW;
        char[] texturebufferF;
        char[] texturebufferT;

        public bool texturesWLoaded;
        public bool texturesFLoaded;
        private int TextureSplit = 210;//at what point does a texture index refer to the floor instead of a wall in uw1/demo
        private int FloorDim = 32;

        public const float BumpMapStrength = 1f;

        public override Bitmap LoadImageAt(int index)
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
        public Bitmap LoadImageAt(int index, Palette palToUse)
        {
            if (main.curgame == main.GAME_UW2)
            {
                FloorDim = 64;
            }

            switch (main.curgame)
            {
                case main.GAME_UW2:
                    {
                        if (texturesFLoaded == false)
                        {
                            if (!Util.ReadStreamFile("c:\\games\\uw2\\" + pathTex_UW2, out texturebufferT))
                            {
                                return base.LoadImageAt(index);
                            }
                            else
                            {
                                texturesFLoaded = true;
                            }
                        }
                        long textureOffset = Util.getValAtAddress(texturebufferT, ((index) * 4) + 4, 32);
                        return Image(texturebufferT, textureOffset, FloorDim, FloorDim, "name_goes_here", palToUse, false);
                    }

                case main.GAME_UW1:
                default:
                    {
                        if (index < TextureSplit)
                        {//Wall textures
                            if (texturesWLoaded == false)
                            {
                                if (!Util.ReadStreamFile("c:\\games\\uw1\\" + pathTexW_UW1, out texturebufferW))
                                {
                                    return base.LoadImageAt(index);
                                }
                                else
                                {
                                    texturesWLoaded = true;
                                }
                            }
                            long textureOffset = Util.getValAtAddress(texturebufferW, (index * 4) + 4, 32);
                            return Image(texturebufferW, textureOffset, 64, 64, "name_goes_here", palToUse, false);
                        }
                        else
                        {//Floor textures (to match my list of textures)
                            if (texturesFLoaded == false)
                            {
                                if (!Util.ReadStreamFile("c:\\games\\uw1\\" + pathTexF_UW1, out texturebufferF))
                                {
                                    return base.LoadImageAt(index);
                                }
                                else
                                {
                                    texturesFLoaded = true;
                                }
                            }
                            long textureOffset = Util.getValAtAddress(texturebufferF, ((index - TextureSplit) * 4) + 4, 32);
                            return Image(texturebufferF, textureOffset, FloorDim, FloorDim, "name_goes_here", palToUse, false);
                        }
                    }//end switch	
            }
        }
    }//end class
}

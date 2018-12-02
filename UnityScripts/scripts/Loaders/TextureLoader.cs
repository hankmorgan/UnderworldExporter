using UnityEngine;
using System.Collections;
using System.IO;

/// <summary>
/// Loads textures.
/// </summary>
public class TextureLoader : ArtLoader {

    private string pathTexW_UW0 = "DATA--DW64.TR";
    private string pathTexF_UW0 = "DATA--DF32.TR";
    private string pathTexW_UW1 = "DATA--W64.TR";
    private string pathTexF_UW1 = "DATA--F32.TR";
    private string pathTex_UW2 = "DATA--T64.TR";
    private string pathTex_SS1 = "RES--DATA--Texture.res";

    char[] texturebufferW;
    char[] texturebufferF;
    char[] texturebufferT;

    public bool texturesWLoaded;
    public bool texturesFLoaded;
    private int TextureSplit = 210;//at what point does a texture index refer to the floor instead of a wall in uw1/demo
    private int FloorDim = 32;
    private string ModPathW;
    private string ModPathF;

    public const float BumpMapStrength = 1f;

    public TextureLoader()
    {
        switch (_RES)
        {
            case GAME_SHOCK:
                break;
            case GAME_UW2:
                ModPathW = BasePath + pathTex_UW2.Replace(".", "_").Replace("--", sep.ToString());
                if (Directory.Exists(ModPathW))
                {
                    LoadMod = true;
                }
                break;
            case GAME_UWDEMO:
                ModPathW = BasePath + pathTexW_UW0.Replace(".", "_").Replace("--", sep.ToString());
                if (Directory.Exists(ModPathW))
                {
                    LoadMod = true;
                }
                ModPathF = BasePath + pathTexF_UW0.Replace(".", "_").Replace("--", sep.ToString());
                if (Directory.Exists(ModPathF))
                {
                    LoadMod = true;
                }
                break;
            case GAME_UW1:
                ModPathW = BasePath + pathTexW_UW1.Replace(".", "_").Replace("--", sep.ToString());
                if (Directory.Exists(ModPathW))
                {
                    LoadMod = true;
                }
                ModPathF = BasePath + pathTexF_UW1.Replace(".", "_").Replace("--", sep.ToString());
                if (Directory.Exists(ModPathF))
                {
                    LoadMod = true;
                }
                break;
        }
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="TextureLoader"/> class.
    /// </summary>
    /// <param name="index">Index.</param>
    /// <param name="TextureType">Texture type. 0 = normal, 1 = palette cycled</param>
    public Texture2D LoadImageAt(int index, short TextureType)
    {
        switch (TextureType)
        {
            case 1: // Palette cycled
                return LoadImageAt(index, GameWorldController.instance.palLoader.GreyScale);
            case 2://normal map
                return TGALoader.LoadTGA(ModPathW + sep + index.ToString("d3") + "_normal.tga");
            default:
                return LoadImageAt(index, GameWorldController.instance.palLoader.Palettes[0]);
        }
    }


    public override Texture2D LoadImageAt(int index)
    {
        return LoadImageAt(index, GameWorldController.instance.palLoader.Palettes[0]);
    }

    /// <summary>
    /// Loads the image at index.
    /// </summary>
    /// <returns>The <see cref="UnityEngine.Texture2D"/>.</returns>
    /// <param name="index">Index.</param>
    /// <param name="palToUse">Pal to use.</param>
    /// If the index is greater than 209 I return a floor texture.
    public Texture2D LoadImageAt(int index, Palette palToUse)
    {
        if (_RES == GAME_UWDEMO)
        {//Point the UW1 texture files to the demo files
            TextureSplit = 48;
            pathTexW_UW1 = pathTexW_UW0;
            pathTexF_UW1 = pathTexF_UW0;
        }
        if (_RES == GAME_UW2)
        {
            FloorDim = 64;
        }

        switch (_RES)
        {
            case GAME_SHOCK:
                {
                    if (texturesFLoaded == false)
                    {
                        if (!DataLoader.ReadStreamFile(BasePath + pathTex_SS1, out texturebufferT))
                        {
                            return base.LoadImageAt(index);
                        }
                        else
                        {
                            texturesFLoaded = true;
                        }
                    }
                    //Load the chunk requested
                    //For textures this is index + 1000
                    DataLoader.Chunk art_ark;
                    if (DataLoader.LoadChunk(texturebufferT, index + 1000, out art_ark))
                    {
                        switch (art_ark.chunkContentType)
                        {
                            case 2:
                            case 17:
                                {
                                    long textureOffset = (int)DataLoader.getValAtAddress(art_ark.data, 2 + (0 * 4), 32);
                                    int CompressionType = (int)DataLoader.getValAtAddress(art_ark.data, textureOffset + 4, 16);
                                    int Width = (int)DataLoader.getValAtAddress(art_ark.data, textureOffset + 8, 16);
                                    int Height = (int)DataLoader.getValAtAddress(art_ark.data, textureOffset + 10, 16);
                                    if ((Width > 0) && (Height > 0))
                                    {

                                        if (CompressionType == 4)
                                        {//compressed
                                            char[] outputImg;
                                            //  UncompressBitmap(art_ark+textureOffset+BitMapHeaderSize, outputImg,Height*Width);
                                            UncompressBitmap(art_ark.data, textureOffset + BitMapHeaderSize, out outputImg, Height * Width);
                                            return Image(outputImg, 0, Width, Height, "namehere", palToUse, true);
                                        }
                                        else
                                        {//Uncompressed
                                            return Image(art_ark.data, textureOffset + BitMapHeaderSize, Width, Height, "namehere", palToUse, true);
                                        }
                                    }
                                    else
                                    {
                                        return base.LoadImageAt(index);
                                    }
                                }
                                //break;
                        }
                    }

                    return base.LoadImageAt(index);
                }

            case GAME_UW2:
                {
                    if (LoadMod)
                    {
                        if (File.Exists(ModPathW + sep + index.ToString("d3") + ".tga"))
                        {
                            return TGALoader.LoadTGA(ModPathW + sep + index.ToString("d3") + ".tga");
                        }
                    }
                    if (texturesFLoaded == false)
                    {
                        if (!DataLoader.ReadStreamFile(BasePath + pathTex_UW2, out texturebufferT))
                        {
                            return base.LoadImageAt(index);
                        }
                        else
                        {
                            texturesFLoaded = true;
                        }
                    }
                    long textureOffset = DataLoader.getValAtAddress(texturebufferT, ((index) * 4) + 4, 32);
                    return Image(texturebufferT, textureOffset, FloorDim, FloorDim, "name_goes_here", palToUse, false);
                }


            case GAME_UWDEMO:
            case GAME_UW1:
            default:
                {
                    if (index < TextureSplit)
                    {//Wall textures
                        if (texturesWLoaded == false)
                        {
                            if (!DataLoader.ReadStreamFile(BasePath + pathTexW_UW1, out texturebufferW))
                            {
                                return base.LoadImageAt(index);
                            }
                            else
                            {
                                texturesWLoaded = true;
                            }
                        }
                        if (LoadMod)
                        {
                            if (File.Exists(ModPathW + sep + index.ToString("d3") + ".tga"))
                            {
                                return TGALoader.LoadTGA(ModPathW + sep + index.ToString("d3") + ".tga");
                            }
                        }
                        long textureOffset = DataLoader.getValAtAddress(texturebufferW, (index * 4) + 4, 32);
                        return Image(texturebufferW, textureOffset, 64, 64, "name_goes_here", palToUse, false);
                    }
                    else
                    {//Floor textures (to match my list of textures)
                        if (texturesFLoaded == false)
                        {
                            if (!DataLoader.ReadStreamFile(BasePath + pathTexF_UW1, out texturebufferF))
                            {
                                return base.LoadImageAt(index);
                            }
                            else
                            {
                                texturesFLoaded = true;
                            }
                        }
                        if (LoadMod)
                        {
                            if (File.Exists(ModPathF + sep + index.ToString("d3") + ".tga"))
                            {
                                return TGALoader.LoadTGA(ModPathF + sep + index.ToString("d3") + ".tga");
                            }
                        }
                        long textureOffset = DataLoader.getValAtAddress(texturebufferF, ((index - TextureSplit) * 4) + 4, 32);
                        return Image(texturebufferF, textureOffset, FloorDim, FloorDim, "name_goes_here", palToUse, false);
                    }
                }//end switch	
        }
    }



    /// <summary>
    /// Converts a texture2d into a normal map
    /// </summary>
    /// <returns>The map.</returns>
    /// <param name="source">Source.</param>
    /// <param name="strength">Strength.</param>
    /// Sourced from http://jon-martin.com/?p=123
    public static Texture2D NormalMap(Texture2D source, float strength) {
        strength = Mathf.Clamp(strength, 0.0F, 10.0F);
        Texture2D result;
        float xLeft;
        float xRight;
        float yUp;
        float yDown;
        float yDelta;
        float xDelta;
        result = new Texture2D(source.width, source.height, TextureFormat.ARGB32, true);
        for (int by = 0; by < result.height; by++) {
            for (int bx = 0; bx < result.width; bx++) {
                xLeft = source.GetPixel(bx - 1, by).grayscale * strength;
                xRight = source.GetPixel(bx + 1, by).grayscale * strength;
                yUp = source.GetPixel(bx, by - 1).grayscale * strength;
                yDown = source.GetPixel(bx, by + 1).grayscale * strength;
                xDelta = ((xLeft - xRight) + 1) * 0.5f;
                yDelta = ((yUp - yDown) + 1) * 0.5f;
                result.SetPixel(bx, by, new Color(xDelta, yDelta, 1.0f, yDelta));
            }
        }
        result.Apply();
        return result;
    }

    /// <summary>
    /// Returns the Mod path at the specified index.
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    public string ModPath(int index)
    {
        switch (_RES)
        {
            case GAME_SHOCK:
                {
                    return "";
                }
            case GAME_UW2:
                {
                    return ModPathW + sep + index.ToString("d3") + ".tga";
                }
            case GAME_UWDEMO:
            case GAME_UW1:
            default:
                {
                    if (index < TextureSplit)
                    {//Wall textures
                        return ModPathW + sep + index.ToString("d3") + ".tga";
                    }
                    else
                    {//Floor textures (to match my list of textures)
                        return ModPathF + sep + index.ToString("d3") + ".tga";
                    }
                }
        }//end switch	
    }
}
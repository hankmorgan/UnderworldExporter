using UnityEngine;
using System.Collections;


/// <summary>
/// Loads textures.
/// </summary>
public class TextureLoader : ArtLoader {

	private string pathTexW_UW0="DATA\\DW64.TR";
	private string pathTexF_UW0="DATA\\DF32.TR";
	private string pathTexW_UW1="DATA\\W64.TR";
	private string pathTexF_UW1="DATA\\F32.TR";
	private string pathTex_UW2 = "DATA\\T64.TR";
	private string pathTex_SS1 = "RES\\DATA\\Texture.res";

	char[] texturebufferW;
	char[] texturebufferF;
	char[] texturebufferT;
	
	public bool texturesWLoaded;
	public bool texturesFLoaded;
	private int TextureSplit=210;//at what point does a texture index refer to the floor instead of a wall in uw1/demo
	private int FloorDim=32;

	
		/// <summary>
		/// Initializes a new instance of the <see cref="TextureLoader"/> class.
		/// </summary>
		/// <param name="index">Index.</param>
		/// <param name="TextureType">Texture type. 0 = normal, 1 = palette cycled</param>
	public Texture2D LoadImageAt (int index, short TextureType)
	{
		switch(TextureType)
		{
		case 1: // Palette cycled
			return LoadImageAt (index,GameWorldController.instance.palLoader.GreyScale);
		default:
			return LoadImageAt (index,GameWorldController.instance.palLoader.Palettes[0]);
		}
	}


	public override Texture2D LoadImageAt (int index)
	{
		return LoadImageAt (index,GameWorldController.instance.palLoader.Palettes[0]);
	}

		/// <summary>
		/// Loads the image at index.
		/// </summary>
		/// <returns>The <see cref="UnityEngine.Texture2D"/>.</returns>
		/// <param name="index">Index.</param>
		/// <param name="palToUse">Pal to use.</param>
		/// If the index is greater than 209 I return a floor texture.
	public Texture2D LoadImageAt (int index, Palette palToUse)
	{
		if (_RES==GAME_UWDEMO)
		{//Point the UW1 texture files to the demo files
			TextureSplit=48;
			pathTexW_UW1=pathTexW_UW0;
			pathTexF_UW1=pathTexF_UW0;			
		}
		if (_RES==GAME_UW2)
		{
			FloorDim=64;	
		}

		switch (_RES)
		{
		case GAME_SHOCK:
				{
					if (texturesFLoaded==false)
					{
						if (!DataLoader.ReadStreamFile(BasePath+ pathTex_SS1, out texturebufferT))
						{
							return base.LoadImageAt(index);
						}
						else
						{
							texturesFLoaded=true;
						}
					}
					//Load the chunk requested
					//For textures this is index + 1000
					DataLoader.Chunk art_ark;
					if (DataLoader.LoadChunk(texturebufferT, index+1000, out art_ark ))
					{
						switch(art_ark.chunkContentType)
						{
						case 2:
						case 17:
								{
									long textureOffset = (int)DataLoader.getValAtAddress(art_ark.data, 2 + (0 * 4), 32);
									int CompressionType=(int)DataLoader.getValAtAddress(art_ark.data,textureOffset+4,16);
									int Width=(int)DataLoader.getValAtAddress(art_ark.data,textureOffset+8,16);
									int Height=(int)DataLoader.getValAtAddress(art_ark.data,textureOffset+10,16);
									if ((Width>0) && (Height >0))
									{

									if(CompressionType==4)
										{//compressed
										char[] outputImg;
										//  UncompressBitmap(art_ark+textureOffset+BitMapHeaderSize, outputImg,Height*Width);
										UncompressBitmap(art_ark.data,textureOffset+BitMapHeaderSize, out outputImg,Height*Width);
										return Image(outputImg,0,Width,Height,"namehere",palToUse,true);
										}
									else
										{//Uncompressed
										return Image(art_ark.data,textureOffset+BitMapHeaderSize,Width,Height,"namehere",palToUse,true);
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
				if (texturesFLoaded==false)
				{
						if (!DataLoader.ReadStreamFile(BasePath+ pathTex_UW2, out texturebufferT))
						{
								return base.LoadImageAt(index);
						}
						else
						{
								texturesFLoaded=true;
						}
				}
				long textureOffset = DataLoader.getValAtAddress(texturebufferT, ((index) * 4) + 4, 32);
				return Image(texturebufferT,textureOffset, FloorDim, FloorDim,"name_goes_here",palToUse,false);
			}


		case GAME_UWDEMO:				
		case GAME_UW1:
		default:
			if (index<TextureSplit)
			{//Wall textures
				if (texturesWLoaded==false)
				{
					if (!DataLoader.ReadStreamFile(BasePath+ pathTexW_UW1, out texturebufferW))
					{
							return base.LoadImageAt(index);
					}
					else
					{
							texturesWLoaded=true;
					}
				}	
				long textureOffset = DataLoader.getValAtAddress(texturebufferW, (index * 4) + 4, 32);
				return Image(texturebufferW,textureOffset, 64, 64,"name_goes_here",palToUse,false);
			}
			else
			{//Floor textures (to match my list of textures)
				if (texturesFLoaded==false)
				{
					if (!DataLoader.ReadStreamFile(BasePath+ pathTexF_UW1, out texturebufferF))
					{
							return base.LoadImageAt(index);
					}
					else
					{
							texturesFLoaded=true;
					}
				}
				long textureOffset = DataLoader.getValAtAddress(texturebufferF, ((index-TextureSplit) * 4) + 4, 32);
				return Image(texturebufferF,textureOffset, FloorDim, FloorDim,"name_goes_here",palToUse,false);
			}
			//break;							
		}	
	}
}

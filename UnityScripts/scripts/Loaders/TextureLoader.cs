using UnityEngine;
using System.Collections;


/// <summary>
/// Loads textures.
/// </summary>
public class TextureLoader : ArtLoader {

	private string pathTexW="DATA\\W64.TR";
	private string pathTexF="DATA\\F32.TR";
	private string pathTexUW2 = "DATA\\T64.TR";

	char[] texturebufferW;
	char[] texturebufferF;
	char[] texturebufferT;
	
	public bool texturesWLoaded;
	public bool texturesFLoaded;


		/// <summary>
		/// Loads the image at index.
		/// </summary>
		/// <returns>The <see cref="UnityEngine.Texture2D"/>.</returns>
		/// <param name="index">Index.</param>
		/// If the index is greater than 209 I return a floor texture.
	public override Texture2D LoadImageAt (int index)
	{
				switch (_RES)
				{
				case "UW2":
					{
						if (texturesFLoaded==false)
						{
								if (!DataLoader.ReadStreamFile(BasePath+ pathTexUW2, out texturebufferT))
								{
										return base.LoadImageAt(index);
								}
								else
								{
										texturesFLoaded=true;
								}
						}
						long textureOffset = DataLoader.getValAtAddress(texturebufferT, ((index) * 4) + 4, 32);
						return Image(texturebufferT,textureOffset, 32, 32,"name_goes_here",GameWorldController.instance.palLoader.Palettes[0],false);
					}


				case "UWDEMO":
				case "UW1":
				default:
						if (index<=209)
						{//Wall textures
								if (texturesWLoaded==false)
								{
										if (!DataLoader.ReadStreamFile(BasePath+ pathTexW, out texturebufferW))
										{
												return base.LoadImageAt(index);
										}
										else
										{
												texturesWLoaded=true;
										}
								}	
								long textureOffset = DataLoader.getValAtAddress(texturebufferW, (index * 4) + 4, 32);
								return Image(texturebufferW,textureOffset, 64, 64,"name_goes_here",GameWorldController.instance.palLoader.Palettes[0],false);
						}
						else
						{//Floor textures (to match my list of textures)
								if (texturesFLoaded==false)
								{
										if (!DataLoader.ReadStreamFile(BasePath+ pathTexF, out texturebufferF))
										{
												return base.LoadImageAt(index);
										}
										else
										{
												texturesFLoaded=true;
										}
								}
								long textureOffset = DataLoader.getValAtAddress(texturebufferF, ((index-210) * 4) + 4, 32);
								return Image(texturebufferF,textureOffset, 32, 32,"name_goes_here",GameWorldController.instance.palLoader.Palettes[0],false);
						}
						//break;							
				}

	
	}
}

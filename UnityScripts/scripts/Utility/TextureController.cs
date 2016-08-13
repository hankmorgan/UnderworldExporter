using UnityEngine;
using System.Collections;

/// <summary>
/// Texture controller for applying palettes (UWPalette) to textures for object sprites.
/// </summary>
public class TextureController : UWEBase {
		private int NoOfObjects=500;
		//private int NoOfTextures=500;
		private bool[] ObjectInUse=new bool[500];
		private Texture2D[]ObjectSrcImage=new Texture2D[500];
		private Texture2D[]ObjectDstImage=new Texture2D[500];

		private bool[] ObjectReady=new bool[500];
		private Sprite[]ObjectDstSprite=new Sprite[500];
		public UWPalette pal;

		// Use this for initialization
		void Start () {		
				ObjectInteraction.tc=this;
				pal = this.GetComponent<UWPalette>();

				ObjectInUse=new bool[NoOfObjects];
				ObjectSrcImage = new Texture2D[NoOfObjects];
				ObjectDstImage = new Texture2D[NoOfObjects];
				ObjectDstSprite = new Sprite[NoOfObjects];
		}

		/// <summary>
		/// Creates a sprite for a item object at the specified object index.
		/// </summary>
		/// <returns>The sprite.</returns>
		/// <param name="index">Index.</param>
		/// <param name="isAnimated">If set to <c>true</c> is animated.</param>
		public Sprite RequestSprite(int index, bool isAnimated)
		{
				if (ObjectReady[index]==false)
				{
						if (ObjectInUse[index]==false)
						{//Sprite not already loaded. Request it.
								ObjectSrcImage[index] = LoadImage (_RES +"/Sprites/Object_Greyscale/OBJECTS_BASE_",index);
								ObjectInUse[index]=true;
						}
						//Apply the current palette to the dst image
						if (isAnimated==true)
						{
								ObjectDstImage[index]=pal.ApplyPalette(ObjectSrcImage[index]);
						}
						else
						{
								//Apply the default palette
								ObjectDstImage[index]=pal.ApplyPaletteDefault(ObjectSrcImage[index]);
						}
						ObjectDstImage[index]=pal.ApplyPalette(ObjectSrcImage[index]);
						ObjectDstImage[index].filterMode=FilterMode.Point;
						ObjectDstSprite[index]= Sprite.Create(ObjectDstImage[index] ,new Rect(0,0,ObjectDstImage[index].width,ObjectDstImage[index].height), new Vector2(0.5f, 0.0f));
						ObjectReady[index]=true;
				}
				return ObjectDstSprite[index];
		}

		/// <summary>
		/// Loads the sprite from the specified asset path.
		/// </summary>
		/// <returns>The sprite.</returns>
		/// <param name="AssetPath">Asset path.</param>
		public Sprite RequestSprite(string AssetPath)
		{
				Texture2D img = LoadImage (AssetPath);
				Sprite spr;
				spr=Sprite.Create(img ,new Rect(0,0,img.width,img.height), new Vector2(0.5f, 0.0f));
				spr.texture.filterMode=FilterMode.Point;
				return spr;
		}

		private Texture2D LoadImage(string BasePath)
		{
				return Resources.Load <Texture2D> (BasePath);
		}

		private Texture2D LoadImage(string BasePath, int index)
		{
				return Resources.Load <Texture2D> (BasePath+ index.ToString("0000"));
		}
}

using UnityEngine;
using System.Collections;

public class TextureController : MonoBehaviour {

	public int NoOfObjects=500;
	public int NoOfTextures=500;
	private bool[] ObjectInUse=new bool[500];
	private bool[] TextureInUse=new bool[500];
	private Texture2D[]ObjectSrcImage=new Texture2D[500];
	private Texture2D[]ObjectDstImage=new Texture2D[500];
	private Texture2D[]TextureSrcImage=new Texture2D[500];
	private Texture2D[]TextureDstImage=new Texture2D[500];

	private bool[] TextureReady=new bool[500];
	private bool[] ObjectReady=new bool[500];
	private Sprite[]ObjectDstSprite=new Sprite[500];
	//private Texture2D preview;
	//public bool[]isAnimated;
	UWPalette pal;

	// Use this for initialization
	void Start () {		
		ObjectInteraction.tc=this;
		GameWorldController.tc=this;
		TMAP.tc=this;
		pal = this.GetComponent<UWPalette>();

		ObjectInUse=new bool[NoOfObjects];
		TextureInUse=new bool[NoOfTextures];
		//isAnimated=new bool[NoOfObjects];

		ObjectSrcImage = new Texture2D[NoOfObjects];
		ObjectDstImage = new Texture2D[NoOfObjects];
		ObjectDstSprite = new Sprite[NoOfObjects];

		TextureSrcImage = new Texture2D[NoOfTextures];
		TextureDstImage = new Texture2D[NoOfTextures];
		TextureReady = new bool[NoOfTextures];



	//	for (int i = 0; i<NoOfObjects;i++)
	//		{
	//		ObjectSrcImage[i] = LoadImage (i);
	//		if (ObjectSrcImage[i]!=null)
	//			{
	//			ObjectDstImage[i]=Sprite.Create( ObjectSrcImage[i],new Rect(0,0,ObjectSrcImage[i].width,ObjectSrcImage[i].height), new Vector2(0.5f, 0.0f));
	//			}
	//		else
	//			{
	//			Debug.Log ("Unable to create sprite :" + i);
	//			}
	//		}

	}

	public Sprite RequestSprite(int index, bool isAnimated)
	{
		if (ObjectReady[index]==false)
		{
			if (pal==null)
			{
				pal=this.gameObject.GetComponent<UWPalette>();
			}
			//Debug.Log(index);
			if (ObjectInUse[index]==false)
			{//Sprite not already loaded. Request it.
				ObjectSrcImage[index] = LoadImage ("Sprites/Palette/OBJECTS_BASE_",index);
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


	public Sprite RequestSprite(string AssetPath)
	{
		Texture2D img = LoadImage (AssetPath);
		Sprite spr;
		spr=Sprite.Create(img ,new Rect(0,0,img.width,img.height), new Vector2(0.5f, 0.0f));
		spr.texture.filterMode=FilterMode.Point;
		return spr;
	}

	public Texture2D RequestTexture(int index, bool isAnimated)
	{
		if(TextureReady[index]==false)
		{
			if (pal==null)
			{
				pal=this.gameObject.GetComponent<UWPalette>();
			}
			if (TextureInUse[index]==false)
			{//Sprite not already loaded. Request it.
				TextureSrcImage[index] = LoadImage ("Textures/Palette/UW1_BASE_",index);
				TextureInUse[index]=true;
			} 
			//Apply the current palette to the dst image
			if (isAnimated==true)
			{
				TextureDstImage[index]=pal.ApplyPalette(TextureSrcImage[index]);
			}
			else
			{
				//Apply the default palette
				TextureDstImage[index]=pal.ApplyPaletteDefault(TextureSrcImage[index]);
			}
			TextureDstImage[index].filterMode=FilterMode.Point;
			TextureReady[index]=true;
		}

	//	else
		//	{
		//	}
		//TextureDstImage[index]=pal.ApplyPalette(TextureSrcImage[index]);
		//TextureDstSprite[index]=Sprite.Create(ObjectDstImage[index] ,new Rect(0,0,ObjectDstImage[index].width,ObjectDstImage[index].height), new Vector2(0.5f, 0.0f));

		return TextureDstImage[index];
	}


	// Update is called once per frame
	void Update () {

	}

	void LateUpdate()
	{
		for (int i=0; i<NoOfTextures;i++)
		{
			TextureReady[i]=false;
		}
		for (int i=0; i <NoOfObjects;i++)
		{
			ObjectReady[i]=false;
		}
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


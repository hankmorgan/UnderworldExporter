using UnityEngine;
using System.Collections;

public class TextureController : MonoBehaviour {

	public int NoOfObjects=463;
	public bool[] ObjectInUse;//=new bool[];
	private Texture2D[]ObjectSrcImage;
	private Texture2D[]ObjectDstImage;// = new Texture2D[];
	public Sprite[]ObjectDstSprite;// = new Texture2D[];
	public Texture2D preview;
	public bool[]isAnimated;
	UWPalette pal;

	// Use this for initialization
	void Start () {		ObjectInteraction.tc=this;
		pal = this.GetComponent<UWPalette>();
		ObjectInUse=new bool[NoOfObjects];
		isAnimated=new bool[NoOfObjects];
		ObjectSrcImage = new Texture2D[NoOfObjects];
		ObjectDstImage = new Texture2D[NoOfObjects];
		ObjectDstSprite = new Sprite[NoOfObjects];

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

	public Sprite RequestSprite(int index)
	{
		//Debug.Log(index);
		if (ObjectInUse[index]==false)
		{//Sprite not already loaded. Request it.
			ObjectSrcImage[index] = LoadImage (index);
			ObjectInUse[index]=true;
		}
		//Apply the current palette to the dst image
		if (isAnimated[index]==true)
			{
			ObjectDstImage[index]=pal.ApplyPalette(ObjectSrcImage[index]);
			}
		else
			{
			//Apply the default palette
			ObjectDstImage[index]=pal.ApplyPaletteDefault(ObjectSrcImage[index]);
			}
		ObjectDstImage[index]=pal.ApplyPalette(ObjectSrcImage[index]);
		ObjectDstSprite[index]=Sprite.Create(ObjectDstImage[index] ,new Rect(0,0,ObjectDstImage[index].width,ObjectDstImage[index].height), new Vector2(0.5f, 0.0f));

		return ObjectDstSprite[index];
	}


	// Update is called once per frame
	void Update () {

	}



	private Texture2D LoadImage(int index)
	{
		//Debug.Log ("Sprites/Palette/OBJECTS_BASE_"+ index.ToString("0000"));
		return Resources.Load <Texture2D> ("Sprites/Palette/OBJECTS_BASE_"+ index.ToString("0000"));
	}
}


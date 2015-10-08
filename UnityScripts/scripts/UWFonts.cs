using UnityEngine;
using System.Collections;

public class UWFonts : MonoBehaviour {

	public Texture2D[] font5x6p= new Texture2D[127];
	public Texture2D result;
	int font5x6pWidth = 5;
	int font5x6pHeight = 5;

	// Use this for initialization
	void Start () {
		for (int i = 0; i<127; i++)
		{
			font5x6p[i]= Resources.Load <Texture2D> ("HUD/Fonts/Font5x6p/Font5x6p_" + i.ToString("0000"));
			//font5x6p[i].alphaIsTransparency=true;
		}

		//Texture2D bgfill = (Texture2D)GameObject.Find ("Conversation_Alpha").GetComponent<UITexture>().mainTexture;

		//GameObject.Find ("Conversation_Alpha").GetComponent<UITexture>().mainTexture=result;
	}

/*
	Texture2D bgfill = (Texture2D)GameObject.Find ("Conversation_BG").GetComponent<UITexture>().mainTexture;
	//Texture2D bg = Resources.Load <Texture2D> ("HUD/textbox_fill");
	Texture2D bg = new Texture2D(164,81);
	Texture2D over = Resources.Load <Texture2D> ("HUD/Charheads/charhead_0001");
	Color[] overColors= over.GetPixels();
	bg.SetPixels(0,0, 164, 81,bgfill.GetPixels());
	bg.SetPixels(50,0,over.width,over.height,overColors);
	bg.filterMode=FilterMode.Point;
	bg.Apply();
	GameObject.Find ("Conversation_BG").GetComponent<UITexture>().mainTexture=bg;
*/



	// Update is called once per frame
	void Update () {
	
	}


	public void ConvertString(int font, string strIn, UITexture TargetControl)
	{
		int BitMapWidth = 328; //strIn.Length*font5x6pWidth;
		int BitMapHeight= 328; // 2*font5x6pHeight;
		//Debug.Log("Converting " + strIn);
		Texture2D bgNew = new Texture2D(BitMapWidth,BitMapHeight,TextureFormat.Alpha8,false);
		Texture2D bg = Resources.Load <Texture2D> ("HUD/Textbox_alpha");
		//bgNew.alphaIsTransparency=true;
		bgNew.SetPixels(0,0, BitMapWidth, BitMapHeight,bg.GetPixels());
		bgNew.filterMode=FilterMode.Point;
		//strIn = strIn.ToUpper();

		//int LineWidth = (165/font5x6pWidth) ;
		//Debug.Log ("LineWidth" + LineWidth);
		int RowCounter=1;
		int colCounter=1;
		int HeightOffset=3;
		strIn=strIn.Replace("\n"," ");
		int LineWidth = 40 ;

			string[] StrWords = strIn.Split(new char [] {' '});
			for (int j = 0; j<=StrWords.GetUpperBound (0);j++)
			{
			//Debug.Log ("Words is " + StrWords[j]);
			//if (string.Compare(StrWords[j],"@@@",true ))
			if (StrWords[j]=="@@@")
				{//Newline
				colCounter=0; 
				RowCounter++;
				}
			else
				{					
					char[] strChars =  StrWords[j].ToCharArray();
					if (StrWords[j].Length+colCounter>=LineWidth)
					{
						//colCounter=1; 
						//RowCounter++;
					}
					for (int i = 0; i<= strChars.GetUpperBound(0);i++)
					{
						if (colCounter >= LineWidth)
						{
						//	colCounter=0; 
						//	RowCounter++;
						}
						int charIndex=System.Convert.ToInt32(strChars[i]);
						Color[] defaultColour= font5x6p[charIndex].GetPixels();
						//font5x6p[i].alphaIsTransparency=true;
						//Debug.Log (i + " "+ colCounter * (font5x6pWidth) + " " +(BitMapHeight-(font5x6pHeight*RowCounter)));
						bgNew.SetPixels(colCounter * (font5x6pWidth), (BitMapHeight - HeightOffset)-((font5x6pHeight+1)*RowCounter),font5x6p[charIndex].width,font5x6p[charIndex].height,defaultColour);
						
						colCounter++;
					}
					colCounter++;
				}
			}
			//RowCounter++;

		//bg.filterMode=FilterMode.Point;
		bgNew.Apply();
		TargetControl.mainTexture=bgNew;
	}
}

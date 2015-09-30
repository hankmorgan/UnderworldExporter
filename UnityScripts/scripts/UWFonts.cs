using UnityEngine;
using System.Collections;

public class UWFonts : MonoBehaviour {

	public Texture2D[] font4x5p= new Texture2D[127];
	public Texture2D result;
	int font4x5pWidth = 4;
	int font4x5pHeight = 5;

	// Use this for initialization
	void Start () {
		for (int i = 0; i<127; i++)
		{
			font4x5p[i]= Resources.Load <Texture2D> ("HUD/Fonts/Font4x5P/Font4x5P_" + i.ToString("0000"));
			//font4x5p[i].alphaIsTransparency=true;
		}

		//Texture2D bgfill = (Texture2D)GameObject.Find ("Conversation_Alpha").GetComponent<UITexture>().mainTexture;

		//result= ConvertString(1,"KARINA BUCKLEY");

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
		int BitMapWidth = 164; //strIn.Length*font4x5pWidth;
		int BitMapHeight= 81; // 2*font4x5pHeight;

		Texture2D bgNew = new Texture2D(164,81,TextureFormat.ARGB32,false);
		Texture2D bg = Resources.Load <Texture2D> ("HUD/Textbox_alpha");
		bgNew.alphaIsTransparency=true;
		bgNew.SetPixels(0,0, 164, 81,bg.GetPixels());
		bgNew.filterMode=FilterMode.Point;
		strIn = strIn.ToUpper();

		int LineWidth = (165/font4x5pWidth) ;
		Debug.Log ("LineWidth" + LineWidth);
		int RowCounter=1;
		int colCounter=1;

		string[] StrWords = strIn.Split(new char [] {' '});
		for (int j = 0; j<=StrWords.GetUpperBound (0);j++)
		{
			char[] strChars =  StrWords[j].ToCharArray();
			if (StrWords[j].Length+colCounter>=LineWidth)
				{
					colCounter=1; 
					RowCounter++;
				}
			for (int i = 0; i<= strChars.GetUpperBound(0);i++)
			{
				if (colCounter >= LineWidth)
				{
					colCounter=1; 
					RowCounter++;
				}
				int charIndex=System.Convert.ToInt32(strChars[i]);
				Color[] defaultColour= font4x5p[charIndex].GetPixels();
				//font4x5p[i].alphaIsTransparency=true;
				//Debug.Log (i + " "+ colCounter * (font4x5pWidth) + " " +(BitMapHeight-(font4x5pHeight*RowCounter)));
				bgNew.SetPixels(colCounter * (font4x5pWidth), BitMapHeight-(font4x5pHeight*RowCounter),font4x5p[charIndex].width,font4x5p[charIndex].height,defaultColour);
				
				colCounter++;
			}
			colCounter++;
		}

		//bg.filterMode=FilterMode.Point;
		bgNew.Apply();
		TargetControl.mainTexture=bgNew;
	}
}

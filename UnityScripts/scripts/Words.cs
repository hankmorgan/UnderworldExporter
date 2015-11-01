using UnityEngine;
using System.Collections;

public class Words : MonoBehaviour {
	public int font;
	public int BlockNo;
	public int colour;
	public int StringNo;
	public int size;
	private float fontSpacing;
	//public static GameObject globals;
	public static StringController sc;
	// Use this for initialization
	void Start () {
		switch (font)
		{
		case 606:
		case 609:
			fontSpacing=0.15f;break;
		default:
			fontSpacing=0.05f;break;
		}
		CreateString ();
	}

	void CreateString()
	{
		char[] WordString = sc.GetString(BlockNo,StringNo).ToCharArray();
		//Debug.Log (WordString);
		for (int i = 0; i <= WordString.GetUpperBound(0); i++)
			{
				//int asciichar = WordString[i];
				//Debug.Log (WordString[i] + " = " + asciichar);
				AddLetter(i,WordString[i]);
			}
	}

	void AddLetter(int index, int Asciichar)
	{
		GameObject newObj = new GameObject();
		newObj.name=this.name + "_letter_" + index;
		newObj.transform.parent=this.transform;
		newObj.transform.position=this.transform.position;
		newObj.transform.localPosition=new Vector3((float)fontSpacing*index,0.0f,0.0f);
		newObj.transform.localRotation=new Quaternion(0,0,0,0);
		//Debug.Log ("Fonts/font_" + font.ToString("0000") + Asciichar.ToString ("0000"));
		SpriteRenderer mysprite = newObj.AddComponent<SpriteRenderer>();//Adds the sprite gameobject
		Sprite image = Resources.Load <Sprite> ("Fonts/font_" + font.ToString("0000") + "_" + Asciichar.ToString ("0000"));//Loads the sprite.
		mysprite.sprite = image;//Assigns the sprite to the object.

	}
}

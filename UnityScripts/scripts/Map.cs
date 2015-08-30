using UnityEngine;
using System.Collections;

public class Map : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public bool OpenMap()
	{
		//Use a map
		GameObject map = GameObject.Find ("Automap");//The UI
		GameObject TileMapInfo = GameObject.Find ("Tilemap");//The stored data.

		//Turn on the camera
		foreach(Transform child in map.transform)
		{
			if (child.name == "MapCamera")
			{
				child.gameObject.SetActive(true);
			}
			//UILabel MapDisplay = GameObject.Find ("MapDisplay").GetComponent<UILabel>();

			//MapDisplay.text= TileMapInfo.GetComponent<TileMap>().TileMapAscii(false);
			UITexture MapDisplay=GameObject.Find ("MapDisplay").GetComponent<UITexture>();
			MapDisplay.mainTexture= TileMapInfo.GetComponent<TileMap>().TileMapImage();
		}
		//Turn off the main hud
		GameObject UWHud =GameObject.Find ("UW_HUD");
		foreach(Transform child in UWHud.transform)
		{
			if ((child.name == "Anchor")||(child.name == "Camera"))
			{
				child.gameObject.SetActive(false);
			}
		}
		return true;
	}

	public bool LookAt()
	{//Generic description of the map
		ObjectInteraction objInt = this.gameObject.GetComponent<ObjectInteraction>();
		UILabel ml =objInt.getMessageLog();
		StringController Sc = objInt.getStringController();
		//TODO:Figure out the source for you see a..
		if (objInt.PickedUp==true)
		{
			ml.text =  Sc.GetString(1,260) + " " + Sc.GetFormattedObjectNameUW(objInt) + "\n" + Sc.GetString(1,151);
		}
		else
		{
			ml.text =  Sc.GetString(1,260) + " " + Sc.GetFormattedObjectNameUW(objInt);
		}

		return true;
	}
}

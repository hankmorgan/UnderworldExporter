using UnityEngine;
using System.Collections;

public class Map : object_base {
	//The inventory item
	// Use this for initialization
	protected override void Start ()
	{
		base.Start();
		objInt.isQuant=false; 
	}

	public override bool use ()
	{
		if (playerUW.playerInventory.ObjectInHand=="")
		{
			return OpenMap();
		}
		else
		{
			return ActivateByObject(playerUW.playerInventory.GetGameObjectInHand());
		}
	}

	public bool OpenMap()
	{
		//Use a map
		GameObject map = GameObject.Find ("MapAnchor");//The UI
		GameObject TileMapInfo = GameObject.Find ("Tilemap");//The stored data.

		//Turn on the camera
		foreach(Transform child in map.transform)
		{
			if (child.name == "MapPanel")
			{
				child.gameObject.SetActive(true);
			}
			//UILabel MapDisplay = GameObject.Find ("MapDisplay").GetComponent<UILabel>();

			//MapDisplay.text= TileMapInfo.GetComponent<TileMap>().TileMapAscii(false);
			UITexture MapDisplay=GameObject.Find ("MapDisplay").GetComponent<UITexture>();
			MapDisplay.mainTexture= TileMapInfo.GetComponent<TileMap>().TileMapImage();
		}
		WindowDetect.InMap=true;//turns on blocking collider.
		//Turn off the main hud
		//GameObject UWHud =GameObject.Find ("UW_HUD");
		//foreach(Transform child in UWHud.transform)
		//{
		//	if ((child.name == "Anchor")||(child.name == "Camera"))
		//	{
		//		child.gameObject.SetActive(false);
		//	}
		//}
		GameObject mus = GameObject.Find ("MusicController");
		if  (mus!=null)
		{
			mus.GetComponent<MusicController>().InMap=true;
		}

		UILabel ml = GameObject.Find ("scroll").GetComponent<UILabel>();
		if (ml!=null)
		{
			ml.text="";
		}

		return true;
	}

	public override bool LookAt()
	{//Generic description of the map
		objInt.isQuant=false; //quick bug fix
			if (objInt.PickedUp==true)
			{
				ml.text =  playerUW.StringControl.GetFormattedObjectNameUW(objInt) + "\n" + playerUW.StringControl.GetString(1,151);
			}
			else
			{
				ml.text =  playerUW.StringControl.GetFormattedObjectNameUW(objInt);
			}
		return true;
	}

		//ObjectInteraction objInt = this.gameObject.GetComponent<ObjectInteraction>();
		//UILabel ml =objInt.getMessageLog();
		//StringController Sc = objInt.getStringController();
	///	//TODO:Figure out the source for you see a..
	//	if (objInt.PickedUp==true)
	//	{
	//		ml.text =  Sc.GetString(1,260) + " " + Sc.GetFormattedObjectNameUW(objInt) + "\n" + Sc.GetString(1,151);
	//	}
	//	else
	//	{
	//		ml.text =  Sc.GetString(1,260) + " " + Sc.GetFormattedObjectNameUW(objInt);
	//	}

	//	return true;
	//}
}

using UnityEngine;
using System.Collections;
using UnityEngine.UI;
/// <summary>
/// Used to open and close the players map view
/// </summary>
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


		/// <summary>
		/// Opens the map UI
		/// </summary>
		/// <returns><c>true</c>, if map was opened, <c>false</c> otherwise.</returns>
	public bool OpenMap()
	{
		WindowDetect.InMap=true;//turns on blocking collider.
		MapInteraction.MapNo=GameWorldController.instance.LevelNo;
		playerUW.playerHud.CursorIcon = playerUW.playerHud.MapQuill;
		playerUW.playerHud.MapDisplay.texture=GameWorldController.instance.Tilemap.TileMapImage();
		if  (GameWorldController.instance.mus!=null)
		{
			GameWorldController.instance.mus.GetComponent<MusicController>().InMap=true;
		}
		playerUW.playerHud.MessageScroll.Clear();

		chains.ActiveControl=4;
		GameWorldController.instance.playerUW.playerHud.ChainsControl.Refresh ();

		return true;
	}

	public override bool LookAt()
	{//Generic description of the map
		objInt.isQuant=false; //quick bug fix
			if (objInt.PickedUp==true)
			{
				ml.Add (playerUW.StringControl.GetFormattedObjectNameUW(objInt) + "\n" + playerUW.StringControl.GetString(1,151));
			}
			else
			{
				ml.Add (playerUW.StringControl.GetFormattedObjectNameUW(objInt));
			}
		return true;
	}
}

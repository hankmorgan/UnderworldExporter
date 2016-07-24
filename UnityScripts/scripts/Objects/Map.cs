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
		objInt().isQuant=false; 
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
		UWHUD.instance.CursorIcon = UWHUD.instance.MapQuill;
		UWHUD.instance.MapDisplay.texture=GameWorldController.instance.Tilemap.TileMapImage();
		if  (GameWorldController.instance.mus!=null)
		{
			GameWorldController.instance.mus.GetComponent<MusicController>().InMap=true;
		}
		UWHUD.instance.MessageScroll.Clear();

		UWHUD.instance.RefreshPanels(UWHUD.HUD_MODE_MAP);

		return true;
	}

	public override bool LookAt()
	{//Generic description of the map
		objInt().isQuant=false; //quick bug fix
			if (objInt().PickedUp==true)
			{
				UWHUD.instance.MessageScroll.Add (StringController.instance.GetFormattedObjectNameUW(objInt()) + "\n" + StringController.instance.GetString(1,151));
			}
			else
			{
				UWHUD.instance.MessageScroll.Add (StringController.instance.GetFormattedObjectNameUW(objInt()));
			}
		return true;
	}
}

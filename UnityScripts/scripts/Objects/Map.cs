using UnityEngine;
using System.Collections;
using UnityEngine.UI;
/// <summary>
/// Used to open and close the players map view
/// </summary>
public class Map : object_base {
	//The inventory item
	// Use this for initialization
	//protected override void Start ()
	//{
	//	base.Start();
	//	objInt().isquant=0; 
	//}

	public override bool use ()
	{
		if (UWCharacter.Instance.playerInventory.ObjectInHand=="")
		{
			return OpenMap();
		}
		else
		{
			return ActivateByObject(UWCharacter.Instance.playerInventory.GetGameObjectInHand());
		}
	}


		/// <summary>
		/// Opens the map UI
		/// </summary>
		/// <returns><c>true</c>, if map was opened, <c>false</c> otherwise.</returns>
	public bool OpenMap()
	{
        WindowDetectUW.InMap = true;
        UWHUD.instance.RefreshPanels(UWHUD.HUD_MODE_MAP);
        UWCharacter.Instance.playerMotor.jumping.enabled=false;
		MapInteraction.UpdateMap(GameWorldController.instance.LevelNo);
		
		if (_RES!=GAME_UW2)
		{
				if  (GameWorldController.instance.getMus()!=null)
				{
						GameWorldController.instance.getMus().InMap=true;
				}            
		}
		UWHUD.instance.MessageScroll.Clear();
		UWHUD.instance.ContextMenu.text="";
		

		return true;
	}

	public override bool LookAt()
	{//Generic description of the map
		objInt().isquant=0; //quick bug fix
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

	/*public override bool PickupEvent ()
	{//If this value is not set then then vanilla underworld will crash when loading a saved game while holding a map.
		objInt().isquant=1;
		return true;
	}

	public override bool DropEvent ()
	{
		objInt().isquant=0;
		return true;
	}*/

	public override float GetWeight ()
	{
		return (float)(GameWorldController.instance.commonObject.properties[objInt().item_id].mass * 0.1f);
	}
}

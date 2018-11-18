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
	//	isquant=0; 
	//}

	public override bool use ()
	{
		if (CurrentObjectInHand==null)
		{
			return OpenMap(GameWorldController.instance.LevelNo);
		}
		else
		{
			return ActivateByObject(CurrentObjectInHand);
		}
	}


	/// <summary>
	/// Opens the map UI
	/// </summary>
	/// <returns><c>true</c>, if map was opened, <c>false</c> otherwise.</returns>
	public bool OpenMap(int levelno)
	{
        Time.timeScale = 0f;
        WindowDetectUW.InMap = true;
        UWHUD.instance.RefreshPanels(UWHUD.HUD_MODE_MAP);
        UWCharacter.Instance.playerMotor.jumping.enabled=false;
		MapInteraction.UpdateMap(levelno);
		
		if (_RES!=GAME_UW2)
		{
				if  (MusicController.instance!=null)
				{
						MusicController.instance.InMap=true;
				}            
		}
		UWHUD.instance.MessageScroll.Clear();
		UWHUD.instance.ContextMenu.text="";
		

		return true;
	}

	public override bool LookAt()
	{//Generic description of the map
		isquant=0; //quick bug fix
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
		isquant=1;
		return true;
	}

	public override bool DropEvent ()
	{
		isquant=0;
		return true;
	}*/

	public override float GetWeight ()
	{
		return (float)(GameWorldController.instance.commonObject.properties[item_id].mass * 0.1f);
	}
}

using UnityEngine;
using System.Collections;
/// <summary>
/// Zanium. The fantabulous material that is self attractive.
/// </summary>
public class Zanium : object_base {

	/// <summary>
	/// Sucks up zanium.
	/// </summary>
	///Find the first instance of zanium in the inventory and increases it's quantity before destroying the zanium in the gameworld
	public void SuckUpZanium()
	{
		//
	 	ObjectInteraction someZanium=GameWorldController.instance.playerUW.playerInventory.findObjInteractionByID(objInt().item_id);
		if (someZanium!=null)
		{//Add the zanium to the pile
			someZanium.Link += objInt().Link;
			someZanium.isQuant=true;
			objInt().consumeObject();
			GameWorldController.instance.playerUW.playerInventory.Refresh();//Update the display
		}
	}



	void OnTriggerEnter(Collider other)
	{		
		if ((other.name==GameWorldController.instance.playerUW.name))
		{
			SuckUpZanium();
		}
	}

}



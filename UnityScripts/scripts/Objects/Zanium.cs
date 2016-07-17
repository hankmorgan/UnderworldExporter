using UnityEngine;
using System.Collections;

public class Zanium : object_base {
	//The fantabulous material that is self attractive.

	public void SuckUpZanium()
	{
		//Find the first instance of zanium in the inventory.
	 	ObjectInteraction someZanium=playerUW.playerInventory.findObjInteractionByID(objInt().item_id);
		if (someZanium!=null)
		{//Add the zanium to the pile
			someZanium.Link += objInt().Link;
			someZanium.isQuant=true;
			objInt().consumeObject();
			playerUW.playerInventory.Refresh();//Update the display
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



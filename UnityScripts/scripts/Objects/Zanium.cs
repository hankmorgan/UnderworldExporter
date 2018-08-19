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
	 	ObjectInteraction someZanium=UWCharacter.Instance.playerInventory.findObjInteractionByID(item_id);
		if (someZanium!=null)
		{//Add the zanium to the pile
			someZanium.link += link;
			someZanium.isquant=1;
			objInt().consumeObject();
			UWCharacter.Instance.playerInventory.Refresh();//Update the display
		}
	}



	void OnTriggerEnter(Collider other)
	{		
		if ((other.name==UWCharacter.Instance.name))
		{
			SuckUpZanium();
		}
	}

}



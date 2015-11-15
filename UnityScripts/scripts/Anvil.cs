using UnityEngine;
using System.Collections;

public class Anvil : object_base {



	public override bool use ()
	{
		if (playerUW.playerInventory.ObjectInHand=="")
		{
			BecomeObjectInHand();
			ml.text = "Use Anvil on what?";
			return true;
		}
		else
		{
			return playerUW.playerInventory.GetGameObjectInHand().GetComponent<ObjectInteraction>().FailMessage();
		}
		
	}
}

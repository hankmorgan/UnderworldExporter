using UnityEngine;
using System.Collections;

public class Anvil : object_base {

	public override bool use ()
	{
		if (playerUW.playerInventory.ObjectInHand=="")
		{
			BecomeObjectInHand();
			ml.Set("Use Anvil on what?");
			return true;
		}
		else
		{
			return ActivateByObject(playerUW.playerInventory.GetGameObjectInHand());
		}		
	}
}

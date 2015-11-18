using UnityEngine;
using System.Collections;

public class Spike : object_base {

public override bool use ()
	{
		if (playerUW.playerInventory.ObjectInHand=="")
		{
			BecomeObjectInHand();
			ml.text=playerUW.StringControl.GetString(1,130);
			return true;
		}
		else
		{
			return ActivateByObject(playerUW.playerInventory.GetGameObjectInHand());
		}
	}
}

using UnityEngine;
using System.Collections;

public class Spike : object_base {

public override bool use ()
	{
		if (objInt().PickedUp==true)
		{
			if (playerUW.playerInventory.ObjectInHand=="")
			{
				BecomeObjectInHand();
				GameWorldController.instance.playerUW.playerHud.MessageScroll.Set (playerUW.StringControl.GetString(1,130));
				return true;
			}
			else
			{
				return ActivateByObject(playerUW.playerInventory.GetGameObjectInHand());
			}
		}
		else
		{
			objInt().FailMessage ();
			return false;
		}
	}
}

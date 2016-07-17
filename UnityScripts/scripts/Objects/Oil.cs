using UnityEngine;
using System.Collections;

public class Oil : object_base {

	public override bool use ()
	{
		if (objInt().PickedUp==true)
		{
			if (playerUW.playerInventory.ObjectInHand=="")
			{
				BecomeObjectInHand();
				GameWorldController.instance.playerUW.playerHud.MessageScroll.Set ("Use oil on?");
				return true;
			}
			else
			{
				return ActivateByObject(playerUW.playerInventory.GetGameObjectInHand());
			}
		}
		else

		{
			objInt().FailMessage();
			return false;
		}
	}


	public override bool FailMessage ()
	{
		GameWorldController.instance.playerUW.playerHud.MessageScroll.Add (playerUW.StringControl.GetString(1,177));
		return false;
	}
}

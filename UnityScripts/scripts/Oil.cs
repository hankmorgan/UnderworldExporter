using UnityEngine;
using System.Collections;

public class Oil : object_base {

	public override bool use ()
	{
		if (playerUW.playerInventory.ObjectInHand=="")
		{
			BecomeObjectInHand();
			ml.text = "Use oil on?";
			return true;
		}
		else
		{
			return ActivateByObject(playerUW.playerInventory.GetGameObjectInHand());
		}
	}


	public override bool FailMessage ()
	{
		ml.text=playerUW.StringControl.GetString(1,177);
		return false;
	}
}

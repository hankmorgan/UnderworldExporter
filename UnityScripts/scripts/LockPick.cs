using UnityEngine;
using System.Collections;

public class LockPick : object_base {
	/*A lock pick is used to pick locks*/
	public override bool use()
	{
		if(playerUW.playerInventory.ObjectInHand=="")
		{
			BecomeObjectInHand();
			ml.text = playerUW.StringControl.GetString(1,8);
			return true;
		}
		else
		{
			return ActivateByObject(playerUW.playerInventory.GetGameObjectInHand());
		}
	}
}

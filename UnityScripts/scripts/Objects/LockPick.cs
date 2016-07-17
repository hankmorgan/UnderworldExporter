using UnityEngine;
using System.Collections;
/// <summary>
/// Lock pick.
/// </summary>
/// Used to pick door locks
public class LockPick : object_base {
	public override bool use()
	{
		if (objInt().PickedUp==true)
		{
			if(playerUW.playerInventory.ObjectInHand=="")
			{
				BecomeObjectInHand();
				GameWorldController.instance.playerUW.playerHud.MessageScroll.Set ( playerUW.StringControl.GetString(1,8));
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

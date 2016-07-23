﻿using UnityEngine;
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
				UWHUD.instance.MessageScroll.Set ( StringController.instance.GetString(1,8));
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

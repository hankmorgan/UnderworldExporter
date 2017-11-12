using UnityEngine;
using System.Collections;

public class Spike : object_base {

public override bool use ()
	{
		if (objInt().PickedUp==true)
		{
			if (UWCharacter.Instance.playerInventory.ObjectInHand=="")
			{
				BecomeObjectInHand();
				UWHUD.instance.MessageScroll.Set (StringController.instance.GetString(1,130));
				return true;
			}
			else
			{
				return ActivateByObject(UWCharacter.Instance.playerInventory.GetGameObjectInHand());
			}
		}
		else
		{
			objInt().FailMessage ();
			return false;
		}
	}
}

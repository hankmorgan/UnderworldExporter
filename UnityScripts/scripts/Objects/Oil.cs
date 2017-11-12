using UnityEngine;
using System.Collections;

public class Oil : object_base {

	public override bool use ()
	{
		if (objInt().PickedUp==true)
		{
			if (UWCharacter.Instance.playerInventory.ObjectInHand=="")
			{
				BecomeObjectInHand();
				UWHUD.instance.MessageScroll.Set ("Use oil on?");
				return true;
			}
			else
			{
				return ActivateByObject(UWCharacter.Instance.playerInventory.GetGameObjectInHand());
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
		UWHUD.instance.MessageScroll.Add (StringController.instance.GetString(1,StringController.str_you_cannot_use_oil_on_that_));
		return false;
	}
}

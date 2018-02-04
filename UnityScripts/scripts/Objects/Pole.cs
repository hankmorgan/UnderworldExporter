using UnityEngine;
using System.Collections;

public class Pole : object_base {
	//000~001~157~Using the pole you trigger the switch.
	//000~001~158~The pole cannot be used on that.

	public override bool use ()
	{
		if (objInt().PickedUp==true)
		{
			if (UWCharacter.Instance.playerInventory.ObjectInHand=="")
			{
				BecomeObjectInHand();
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

	public override bool FailMessage ()
	{
		UWHUD.instance.MessageScroll.Add (StringController.instance.GetString(1,StringController.str_the_pole_cannot_be_used_on_that_));
		return false;
	}

}

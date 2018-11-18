using UnityEngine;
using System.Collections;

public class Spike : object_base {

public override bool use ()
	{
		if (objInt().PickedUp==true)
		{
			if (CurrentObjectInHand==null)
			{
				BecomeObjectInHand();
				UWHUD.instance.MessageScroll.Set (StringController.instance.GetString(1,130));
				return true;
			}
			else
			{
				return ActivateByObject(CurrentObjectInHand);
			}
		}
		else
		{
			objInt().FailMessage ();
			return false;
		}
	}
}

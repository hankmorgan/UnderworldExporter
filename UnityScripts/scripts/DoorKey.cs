using UnityEngine;
using System.Collections;

public class DoorKey : object_base {
	/*Guess*/

	public int KeyId;//This should match the doors it is opening. Also index into look descriptions

	public override bool use ()
	{
		if (playerUW.playerInventory.ObjectInHand=="")
		{
			BecomeObjectInHand();
			ml.text = playerUW.StringControl.GetString(1,7);
			return true;
		}
		else
		{
			return ActivateByObject(playerUW.playerInventory.GetGameObjectInHand());
		}
	}

	public override bool LookAt ()
	{
		if (objInt.PickedUp==true)
		{
			ml.text=playerUW.StringControl.GetString(5,KeyId+100);
		}
		else
		{
			ml.text=playerUW.StringControl.GetFormattedObjectNameUW(objInt);
		}

		return true;
	}

}

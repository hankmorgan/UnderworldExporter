using UnityEngine;
using System.Collections;

public class DoorKey : object_base {

	public int KeyId;
	// Use this for initialization

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
			return playerUW.playerInventory.GetGameObjectInHand().GetComponent<ObjectInteraction>().FailMessage();
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

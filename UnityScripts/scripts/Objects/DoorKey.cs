using UnityEngine;
using System.Collections;
/// <summary>
/// Door key.
/// </summary>
/// Guess
public class DoorKey : object_base {
	///This should match the doors it is opening. Also index into look descriptions
	public int KeyId;

	public override bool use ()
	{
		if (objInt().PickedUp==true)
		{
			if (playerUW.playerInventory.ObjectInHand=="")
			{
				BecomeObjectInHand();
				GameWorldController.instance.playerUW.playerHud.MessageScroll.Set (playerUW.StringControl.GetString(1,7));
				return true;
			}
			else
			{
				return ActivateByObject(playerUW.playerInventory.GetGameObjectInHand());
			}
		}
		else
		{
			objInt().FailMessage();
			return false;
		}
	}

	public override bool LookAt ()
	{
		if (objInt().PickedUp==true)
		{
			GameWorldController.instance.playerUW.playerHud.MessageScroll.Add(playerUW.StringControl.GetString(5,KeyId+100));
		}
		else
		{
			GameWorldController.instance.playerUW.playerHud.MessageScroll.Add(playerUW.StringControl.GetFormattedObjectNameUW(objInt()));
		}

		return true;
	}
}
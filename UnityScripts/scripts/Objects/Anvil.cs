using UnityEngine;
using System.Collections;

public class Anvil : object_base {

	/// <summary>
	/// The anvil becomes a special object in hand
	/// </summary>
	/// Actual anvil repairs handled by Equipment
	public override bool use ()
	{
		if (GameWorldController.instance.playerUW.playerInventory.ObjectInHand=="")
		{
			BecomeObjectInHand();
			UWHUD.instance.MessageScroll.Set("Use Anvil on what?");
			return true;
		}
		else
		{
			return ActivateByObject(GameWorldController.instance.playerUW.playerInventory.GetGameObjectInHand());
		}		
	}


	public override string UseVerb()
	{
		return "repair";
	}
}

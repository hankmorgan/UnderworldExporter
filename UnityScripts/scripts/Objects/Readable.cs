using UnityEngine;
using System.Collections;

public class Readable : object_base {

	public override bool use ()
	{
		if (playerUW.playerInventory.ObjectInHand == "")
		{
			return Read ();
		}
		else
		{
			return ActivateByObject(playerUW.playerInventory.GetGameObjectInHand());
		}
	}

	public override bool LookAt ()
	{
		return Read ();
	}

	public bool Read()
	{//Returns the text of this readable.
		//ObjectInteraction objInt = this.gameObject.GetComponent<ObjectInteraction>();
		//StringController SC = objInt().getStringController();
		//UILabel ml = objInt().getMessageLog();

		switch (objInt().ItemType)
		{
		case ObjectInteraction.SIGN: //Sign
			{
			GameWorldController.instance.playerUW.playerHud.MessageScroll.Add (playerUW.StringControl.GetString (8,objInt().Link - 0x200));
			return true;
			}
		case ObjectInteraction.BOOK://Book
		case ObjectInteraction.SCROLL://Scroll
			{
			if (objInt().PickedUp==true)
			{
				if (objInt().Link==520)
				{//Special case. Chasm of fire map.
					playerUW.playerHud.CutScenesSmall.SetAnimation="ChasmMap";
				}
				else
				{
					GameWorldController.instance.playerUW.playerHud.MessageScroll.Add (playerUW.StringControl.GetString (3,objInt().Link - 0x200));
				}
				return true;
			}
			else
				{
					return base.LookAt();
				}

			}

		default: 
			{
			GameWorldController.instance.playerUW.playerHud.MessageScroll.Add ("READABLE TYPE NOT FOUND! (" + objInt().item_id +")");
			return false;
			}
		}
	}
}

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
			return playerUW.playerInventory.GetGameObjectInHand().GetComponent<ObjectInteraction>().FailMessage();
		}
	}

	public override bool LookAt ()
	{
		return Read ();
	}

	public bool Read()
	{//Returns the text of this readable.
		//ObjectInteraction objInt = this.gameObject.GetComponent<ObjectInteraction>();
		//StringController SC = objInt.getStringController();
		//UILabel ml = objInt.getMessageLog();

		switch (objInt.ItemType)
		{
		case ObjectInteraction.SIGN: //Sign
			{
			ml.text =playerUW.StringControl.GetString (8,objInt.Link - 0x200);
			return true;
			break;
			}
		case ObjectInteraction.BOOK://Book
		case ObjectInteraction.SCROLL://Scroll
			{
			ml.text = playerUW.StringControl.GetString (3,objInt.Link - 0x200);
			return true;
			break;
			}
		default: 
			{
			ml.text = "READABLE TYPE NOT FOUND! (" + objInt.item_id +")";
			return false;
			break;
			}
		}
	}
}

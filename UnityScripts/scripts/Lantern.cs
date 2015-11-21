using UnityEngine;
using System.Collections;

public class Lantern : LightSource {
	//A lantern needs oil to work

	public override bool ActivateByObject (GameObject ObjectUsed)
	{
		ObjectInteraction objIntUsed = ObjectUsed.GetComponent<ObjectInteraction>();
		if (objIntUsed != null) 
		{
			switch (objIntUsed.ItemType)
			{
			case ObjectInteraction.OIL:
				if (IsOn==true)
				{
					ml.text=playerUW.StringControl.GetString(1,178);
				}
				else
				{
					if (objInt.Quality==64)
					{
						ml.text=playerUW.StringControl.GetString(1,180);
					}
					else
					{
						ml.text=playerUW.StringControl.GetString(1,179);
						objInt.Quality = 64;
						objIntUsed.consumeObject();
					}
				}
				playerUW.CursorIcon= playerUW.CursorIconDefault;
				playerUW.playerInventory.ObjectInHand="";
				return true;
				break;
			default:
				return base.ActivateByObject(ObjectUsed);
				break;

			}
		}
		return false;
	}

}

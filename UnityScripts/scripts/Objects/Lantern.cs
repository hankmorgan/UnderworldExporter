using UnityEngine;
using System.Collections;
/// <summary>
/// Lantern.
/// </summary>
/// Special variant of light sources that uses fuel to burn rather
public class Lantern : LightSource {

		/// <summary>
		/// Activation of this object by another. EG key on door
		/// </summary>
		/// <returns>true</returns>
		/// <c>false</c>
		/// <param name="ObjectUsed">Object used.</param>
		/// Using oil on the lantern increases it's quality.
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
					GameWorldController.instance.playerUW.playerHud.MessageScroll.Add(playerUW.StringControl.GetString(1,178));
				}
				else
				{
					if (objInt().Quality==64)
					{
						GameWorldController.instance.playerUW.playerHud.MessageScroll.Add(playerUW.StringControl.GetString(1,180));
					}
					else
					{
						GameWorldController.instance.playerUW.playerHud.MessageScroll.Add(playerUW.StringControl.GetString(1,179));
						objInt().Quality = 64;
						objIntUsed.consumeObject();
					}
				}
				playerUW.playerHud.CursorIcon= playerUW.playerHud.CursorIconDefault;
				playerUW.playerInventory.ObjectInHand="";
				return true;
			default:
				return base.ActivateByObject(ObjectUsed);
			}
		}
		return false;
	}
}
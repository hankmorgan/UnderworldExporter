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
		//000~001~178~You think it is a bad idea to add oil to the lit lantern. \n
		//000~001~179~Adding oil, you refuel the lantern. \n
		//000~001~180~The lantern is already full. \n
		ObjectInteraction objIntUsed = ObjectUsed.GetComponent<ObjectInteraction>();
		if (objIntUsed != null) 
		{
			switch (objIntUsed.GetItemType())
			{
			case ObjectInteraction.OIL:
				if (IsOn()==true)
				{
					UWHUD.instance.MessageScroll.Add(StringController.instance.GetString(1,StringController.str_you_think_it_is_a_bad_idea_to_add_oil_to_the_lit_lantern_));
				}
				else
				{
					if (objInt().quality==64)
					{
						UWHUD.instance.MessageScroll.Add(StringController.instance.GetString(1,StringController.str_the_lantern_is_already_full_));
					}
					else
					{
						UWHUD.instance.MessageScroll.Add(StringController.instance.GetString(1,StringController.str_adding_oil_you_refuel_the_lantern_));
						objInt().quality = 64;
						objIntUsed.consumeObject();
					}
				}
				UWHUD.instance.CursorIcon= UWHUD.instance.CursorIconDefault;
				UWCharacter.Instance.playerInventory.ObjectInHand="";
				return true;
			default:
				return base.ActivateByObject(ObjectUsed);
			}
		}
		return false;
	}


	public override string UseObjectOnVerb_Inv ()
	{
		ObjectInteraction ObjIntInHand=UWCharacter.Instance.playerInventory.GetObjIntInHand();
		if (ObjIntInHand!=null)
		{
			switch (ObjIntInHand.GetItemType())	
			{
			case ObjectInteraction.OIL:
				return "refill lantern";
			}
		}

		return base.UseObjectOnVerb_Inv();
	}
}
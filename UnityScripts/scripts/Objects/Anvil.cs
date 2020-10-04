using UnityEngine;
using System.Collections;

public class Anvil : object_base {

	/// <summary>
	/// The anvil becomes a special object in hand
	/// </summary>
	/// Actual anvil repairs handled by Equipment
	public override bool use ()
	{
		if (CurrentObjectInHand==null)
		{
			BecomeObjectInHand();
            UWCharacter.InteractionMode = UWCharacter.InteractionModeUse;
			UWHUD.instance.MessageScroll.Set("Use Anvil on what?");
			return true;
		}
		else
		{
			return ActivateByObject(CurrentObjectInHand);
		}		
	}


	public override string UseVerb()
	{
		return "repair";
	}

    public override bool FailMessage()
    {
        UWHUD.instance.MessageScroll.Add(StringController.instance.GetString(1, StringController.str_you_cannot_repair_that_));          
        return true;
    }
}

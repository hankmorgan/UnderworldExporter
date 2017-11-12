using UnityEngine;
using System.Collections;

public class RuneBag : object_base {


	public override bool use ()
	{
		if (UWCharacter.Instance.playerInventory.ObjectInHand == "")
		{
			return Activate ();
		}
		else
		{
			return ActivateByObject(UWCharacter.Instance.playerInventory.GetGameObjectInHand());
		}
	}

		/// <summary>
		/// Opens the rune bag display panel
		/// </summary>
	void OpenRuneBag()
	{
		UWHUD.instance.RefreshPanels(UWHUD.HUD_MODE_RUNES);
	}

	public override bool Activate()
	{
		OpenRuneBag();
		return true;
	}


	public override bool ActivateByObject(GameObject ObjectUsed)
	{
		//Test for a valid rune being used on the bag and if so add the rune to the players inventory.
		if(ObjectUsed.GetComponent<RuneStone>() !=null)
		{
			UWCharacter.Instance.PlayerMagic.PlayerRunes[ObjectUsed.GetComponent<ObjectInteraction>().item_id-232]=true;
			//Add rune to rune bag and destroy the original object.
			ObjectUsed.GetComponent<ObjectInteraction>().consumeObject();
			UWCharacter.Instance.playerInventory.ObjectInHand="";
			UWHUD.instance.CursorIcon= UWHUD.instance.CursorIconDefault;
			return true;
		}
		else
		{
			if (UWCharacter.InteractionMode== UWCharacter.InteractionModeUse)
			{
				return ObjectUsed.GetComponent<ObjectInteraction>().FailMessage();
			}
			else
			{
				return false;
			}
		}
	}

	public override string UseVerb ()
	{
		return "open";
	}

	public override string UseObjectOnVerb_Inv ()
	{
		ObjectInteraction ObjIntInHand=UWCharacter.Instance.playerInventory.GetObjIntInHand();
		if (ObjIntInHand!=null)
		{
			switch (ObjIntInHand.GetItemType())	
			{
			case ObjectInteraction.RUNE:
				return "place rune in bag";
			}
		}		
		return base.UseObjectOnVerb_Inv();
	}
}
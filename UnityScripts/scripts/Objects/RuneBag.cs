using UnityEngine;
using System.Collections;

public class RuneBag : object_base {


	public override bool use ()
	{
		if (playerUW.playerInventory.ObjectInHand == "")
		{
			return Activate ();
		}
		else
		{
			return ActivateByObject(playerUW.playerInventory.GetGameObjectInHand());
		}
	}

	void OpenRuneBag()
	{
		chains.ActiveControl=2;
		UWHUD.instance.ChainsControl.Refresh();
	}

	public override bool Activate()
	{
		//Open the rune bag in the UI
		OpenRuneBag();
		return true;
	}


	public override bool ActivateByObject(GameObject ObjectUsed)
	{
		//Test for a valid rune being used on the bag and if so add the rune to the players inventory.
		if(ObjectUsed.GetComponent<RuneStone>() !=null)
		{
			playerUW.PlayerMagic.PlayerRunes[ObjectUsed.GetComponent<ObjectInteraction>().item_id-232]=true;
			//Add rune to rune bag and destroy the original object.
			GameObject.Destroy(ObjectUsed);
			playerUW.playerInventory.ObjectInHand="";
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
}

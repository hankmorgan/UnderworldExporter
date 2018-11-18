using UnityEngine;
using System.Collections;

public class RuneBag : object_base {


	public override bool use ()
	{
		if (CurrentObjectInHand == null)
		{
			return Activate (this.gameObject);
		}
		else
		{
			return ActivateByObject(CurrentObjectInHand);
		}
	}

		/// <summary>
		/// Opens the rune bag display panel
		/// </summary>
	void OpenRuneBag()
	{
		UWHUD.instance.RefreshPanels(UWHUD.HUD_MODE_RUNES);
	}

	public override bool Activate(GameObject src)
	{
		OpenRuneBag();
		return true;
	}


	public override bool ActivateByObject(ObjectInteraction ObjectUsed)
	{
		//Test for a valid rune being used on the bag and if so add the rune to the players inventory.
		if(ObjectUsed.GetComponent<RuneStone>() !=null)
		{
			UWCharacter.Instance.PlayerMagic.PlayerRunes[ObjectUsed.item_id-232]=true;
            //Add rune to rune bag and destroy the original object.
            ObjectUsed.consumeObject();
			CurrentObjectInHand=null;
			//UWHUD.instance.CursorIcon= UWHUD.instance.CursorIconDefault;
			return true;
		}
		else
		{
			if (UWCharacter.InteractionMode== UWCharacter.InteractionModeUse)
			{
				return ObjectUsed.FailMessage();
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
		//ObjectInteraction ObjIntInHand=CurrentObjectInHand;
		if (CurrentObjectInHand != null)
		{
			switch (CurrentObjectInHand.GetItemType())	
			{
			case ObjectInteraction.RUNE:
				return "place rune in bag";
			}
		}		
		return base.UseObjectOnVerb_Inv();
	}
}
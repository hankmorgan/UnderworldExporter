using UnityEngine;
using System.Collections;

public class RuneBag : object_base {


	public override bool use ()
	{
		GameObject ObjectInHand = playerUW.playerInventory.GetGameObjectInHand ();
		if (ObjectInHand  != null)
		{
			//Try and see if I can add the object to the rune bag.
			return ActivateByObject(ObjectInHand);
		}
		else
		{
			//open the rune bag if nothing in hand
			Activate();
			return true;
		}
	}

	void OpenRuneBag()
	{
		//chains chainControl = GameObject.Find ("Chain").GetComponent<chains>();
		//if (chainControl!=null)
		//{
		chains.ActiveControl=2;
		//	chainControl.ActiveControl=2;
			//Time.timeScale=0;//pause the game
		//}
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
			//UWCharacter playerUW = GameObject.Find ("Gronk").GetComponent<UWCharacter>();
			//PlayerInventory pInv =GameObject.Find ("Gronk").GetComponent<PlayerInventory>();
			playerUW.PlayerMagic.PlayerRunes[ObjectUsed.GetComponent<ObjectInteraction>().item_id-232]=true;
			//Add rune to rune bag.
			GameObject.Destroy(ObjectUsed);
			playerUW.playerInventory.ObjectInHand="";
			playerUW.CursorIcon= playerUW.CursorIconDefault;
			return true;
		}
		else
		{
			return ObjectUsed.GetComponent<ObjectInteraction>().FailMessage();
		}
	}
}

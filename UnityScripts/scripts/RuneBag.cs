using UnityEngine;
using System.Collections;

public class RuneBag : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Activate()
	{
		//Open the rune bag in the UI
	}

	public bool ActivateByObject(GameObject ObjectUsed)
	{
		//Test for a valid rune being used on the bag and if so add the rune to the players inventory.

		//TODO:Remove isRuneStone
		if(ObjectUsed.GetComponent<ObjectInteraction>().isRuneStone)
		{
			UWCharacter playerUW = GameObject.Find ("Gronk").GetComponent<UWCharacter>();
			PlayerInventory pInv =GameObject.Find ("Gronk").GetComponent<PlayerInventory>();
			playerUW.Runes[ObjectUsed.GetComponent<ObjectInteraction>().item_id-232]=true;
			//Add rune to rune bag.
			GameObject.Destroy(ObjectUsed);
			pInv.ObjectInHand="";
			playerUW.CursorIcon= playerUW.CursorIconDefault;
			playerUW.CurrObjectSprite = "";
			return true;
		}
		else
		{
			return false;
		}
	}
}

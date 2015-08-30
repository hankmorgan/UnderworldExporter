using UnityEngine;
using System.Collections;

public class RuneBag : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OpenRuneBag()
	{
		chains chainControl = GameObject.Find ("Chain").GetComponent<chains>();
		if (chainControl!=null)
		{
			chainControl.ActiveControl=2;
		}
	}

	public void Activate()
	{
		//Open the rune bag in the UI
		OpenRuneBag();

	}

	public bool LookAt()
	{
		//Code for when looking at food. Should one day return quantity and smell properly
		ObjectInteraction objInt = this.gameObject.GetComponent<ObjectInteraction>();
		UILabel ml =objInt.getMessageLog();
		StringController Sc = objInt.getStringController();
		ml.text = Sc.GetString(1,260) + " " + Sc.GetFormattedObjectNameUW(objInt);
		return true;
	}

	public bool ActivateByObject(GameObject ObjectUsed)
	{
		//Test for a valid rune being used on the bag and if so add the rune to the players inventory.
		if(ObjectUsed.GetComponent<RuneStone>() !=null)
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

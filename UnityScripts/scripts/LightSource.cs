using UnityEngine;
using System.Collections;

public class LightSource : MonoBehaviour {

	public int Brightness;
	public int Duration;

	public int ItemIdOn;
	public int ItemIdOff;

	public bool IsOn;

	public const int BaseBrightness = 5;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void Use()
	{
		ObjectInteraction objInt = this.gameObject.GetComponent<ObjectInteraction>();
		UILabel ml =objInt.getMessageLog();
		if (objInt.PickedUp==false)
		{
			return;
		}
		//Light lt = GameObject.Find ("Gronk").GetComponent<Light>();
		//Activates or deactivates the torch.
		if (IsOn == true)
		{//Turn off the torch
			//lt.range=LightSource.BaseLight;
			IsOn=false;
			objInt.item_id=ItemIdOff;
			objInt.InvDisplayIndex=ItemIdOff;
		}
		else
		{//Turn on the torch
			//Try and put the torch in an shoulder/hand slot if it is not already there.
			PlayerInventory pInv = GameObject.Find ("Gronk").GetComponent<PlayerInventory>();
			InventorySlot invSlot = null;
			if ((pInv.sRightShoulder=="") || (pInv.sRightShoulder==this.name))
				{
				invSlot=GameObject.Find ("RightShoulder_Slot").GetComponent<InventorySlot>();
				}
			else if ((pInv.sLeftShoulder=="") || (pInv.sLeftShoulder==this.name))
				{
				invSlot=GameObject.Find ("LeftShoulder_Slot").GetComponent<InventorySlot>();
				}
			else if ((pInv.sRightHand=="") || (pInv.sRightHand==this.name))
				{
				invSlot=GameObject.Find ("RightHand_Slot").GetComponent<InventorySlot>();
				}
			else if ((pInv.sLeftHand=="") || (pInv.sLeftHand==this.name))
				{
				invSlot=GameObject.Find ("LeftHand_Slot").GetComponent<InventorySlot>();
				}
			if (invSlot != null)
				{
				pInv.RemoveItem(this.name);
				pInv.SetObjectAtSlot(invSlot.slotIndex,this.name);
				//lt.range=LightSource.BaseLight+this.Brightness;
				IsOn=true;
				objInt.item_id=ItemIdOn;
				objInt.InvDisplayIndex=ItemIdOn;
				}
			else
				{
				Debug.Log ("No free hand");
				}
		}
		objInt.RefreshAnim();
	}

	public void LookAt()
	{
		ObjectInteraction objInt = this.gameObject.GetComponent<ObjectInteraction>();
		UILabel ml =objInt.getMessageLog();
		StringController Sc = objInt.getStringController();
		ml.text = Sc.GetString(1,260) + " " + Sc.GetFormattedObjectNameUW(objInt);
	}
}

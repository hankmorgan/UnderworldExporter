using UnityEngine;
using System.Collections;

public class LightSource : MonoBehaviour {

	public int Brightness;
	public int Duration;

	public int ItemIdOn;
	public int ItemIdOff;

	public bool IsOn;

	public const int BaseBrightness = 6;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (IsOn==true)
		{
			ObjectInteraction objInt = this.gameObject.GetComponent<ObjectInteraction>();
			if (objInt.PickedUp==false)
			{
				SetOff ();
			}
		}
	}

	public void Use()
	{
		ObjectInteraction objInt = this.gameObject.GetComponent<ObjectInteraction>();
		if (objInt.PickedUp==false)
		{
			if (IsOn==true)
			{
				SetOff ();
			}
			return;
		}

		if (IsOn == true)
		{
			SetOff ();
		}
		else
		{
			SetOn ();
		}

	}

	public void SetOn()
	{		
		ObjectInteraction objInt = this.gameObject.GetComponent<ObjectInteraction>();
		UILabel ml =objInt.getMessageLog();
		//Turn on the torch
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
		objInt.RefreshAnim();
	}
	
	public void SetOff()
	{
		ObjectInteraction objInt = this.gameObject.GetComponent<ObjectInteraction>();
		UILabel ml =objInt.getMessageLog();
		//Turn off the torch
		//lt.range=LightSource.BaseLight;
		IsOn=false;
		objInt.item_id=ItemIdOff;
		objInt.InvDisplayIndex=ItemIdOff;
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

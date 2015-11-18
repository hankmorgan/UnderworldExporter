using UnityEngine;
using System.Collections;

public class LightSource : object_base {

	public int Brightness;
//	public int Duration;// Use the quality to decide the duration.

	public int ItemIdOn;
	public int ItemIdOff;

	public bool IsOn;

	public const int BaseBrightness = 8;
	public static int MagicBrightness=0;


	
	// Update is called once per frame
	void Update () {
		if (IsOn==true)
		{
			//if (objInt==null)
			//{
			//	objInt = this.gameObject.GetComponent<ObjectInteraction>();
			//}
			if (objInt.PickedUp==false)
			{
				SetOff ();
			}
		}
	}

	public override bool use ()
	{
		//base.use();
		if (playerUW.playerInventory.ObjectInHand == "")
		{
			if (objInt.PickedUp==false)
			{
				if (IsOn==true)
				{
					SetOff ();
				}
				return true;
			}
			
			if (IsOn == true)
			{
				SetOff ();
			}
			else
			{
				SetOn ();
			}
			return true;
		}
		else
		{
			return ActivateByObject(playerUW.playerInventory.GetGameObjectInHand());
		}
	}

	public void SetOn()
	{		
		if (objInt==null)
		{
			objInt = this.gameObject.GetComponent<ObjectInteraction>();
		}
		if(ml==null)
		{
			ml =objInt.getMessageLog();
		}

		//Turn on the torch
		//Try and put the torch in an shoulder/hand slot if it is not already there.
		PlayerInventory pInv = playerUW.playerInventory; //GameObject.Find ("Gronk").GetComponent<PlayerInventory>();
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
			if   ((objInt.isQuant==false) || ((objInt.isQuant) && (objInt.Link==1)) || (objInt.isEnchanted==true))
			{//Is a quantity of one or not a quantity/
				pInv.RemoveItem(this.name);
				pInv.SetObjectAtSlot(invSlot.slotIndex,this.name);
				IsOn=true;
				objInt.item_id=ItemIdOn;
				objInt.InvDisplayIndex=ItemIdOn;
			}
			else
			{//Clone the item and move it's clone to the inventory slot
				GameObject split = Instantiate(this.gameObject);
				split.name= split.name+"_"+ playerUW.summonCount++;
				split.GetComponent<ObjectInteraction>().Link=1;//Increment and decrement the object count as appropiate;
				objInt.Link--;
				split.transform.parent=this.transform.parent;
				//Activate the split instead
				split.GetComponent<ObjectInteraction>().Use();
				split.GetComponent<ObjectInteraction>().isQuant=false;
			}

			//lt.range=LightSource.BaseLight+this.Brightness;
		}
		else
		{
			//Debug.Log ("No free hand");
			ml.text=playerUW.StringControl.GetString(1,258);
		}
		objInt.RefreshAnim();
	}
	
	public void SetOff()
	{
		IsOn=false;
		objInt.item_id=ItemIdOff;
		objInt.InvDisplayIndex=ItemIdOff;
		objInt.isQuant=true;
		objInt.RefreshAnim();
	}



	public override bool LookAt()
	{
		//StringController Sc = objInt.getStringController();
		ml.text =playerUW.StringControl.GetFormattedObjectNameUW(objInt);
		return true;
	}

}

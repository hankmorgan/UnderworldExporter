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
	public float LightTimerMax=30.0f;
	public float LightTimer;

	// Update is called once per frame
	void Update () {
		if (IsOn==true)
		{
			if (objInt.PickedUp==false)
			{
				SetOff ();
			}
			else
			{
				LightTimer-=Time.deltaTime;
				if (LightTimer<=0)
				{
				objInt.Quality--;
				LightTimer=LightTimerMax;
				if (objInt.Quality==0)
					{
					SetOff();
					}
				}
			}
		}
	}

	public override bool use ()
	{
		CheckReferences();
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
		/*if (objInt==null)
		{
			objInt = this.gameObject.GetComponent<ObjectInteraction>();
		}
		if(ml==null)
		{
			ml =objInt.getMessageLog();
		}*/
		if (objInt.Quality<=0)
		{//000~001~124~That light is already used up. \n
			ml.Add(playerUW.StringControl.GetString(1,124));
			return;
		}

		LightTimer=LightTimerMax;		

		CheckReferences();
		//Turn on the torch
		//Try and put the torch in an shoulder/hand slot if it is not already there.
		PlayerInventory pInv = playerUW.playerInventory; //GameObject.Find ("Gronk").GetComponent<PlayerInventory>();
		InventorySlot invSlot = null;
		if ((pInv.sRightShoulder=="") || (pInv.sRightShoulder==this.name))
		{						
			//invSlot=GameObject.Find ("RightShoulder_Slot").GetComponent<InventorySlot>();
			invSlot=playerUW.playerInventory.RightShoulder_Slot.gameObject.GetComponent<InventorySlot>();
		}
		else if ((pInv.sLeftShoulder=="") || (pInv.sLeftShoulder==this.name))
		{
			//invSlot=GameObject.Find ("LeftShoulder_Slot").GetComponent<InventorySlot>();
			invSlot=playerUW.playerInventory.LeftShoulder_Slot.gameObject.GetComponent<InventorySlot>();
		}
		else if ((pInv.sRightHand=="") || (pInv.sRightHand==this.name))
		{
			//invSlot=GameObject.Find ("RightHand_Slot").GetComponent<InventorySlot>();
		invSlot=playerUW.playerInventory.RightHand_Slot.gameObject.GetComponent<InventorySlot>();
		}
		else if ((pInv.sLeftHand=="") || (pInv.sLeftHand==this.name))
		{
			//invSlot=GameObject.Find ("LeftHand_Slot").GetComponent<InventorySlot>();
				invSlot=playerUW.playerInventory.LeftHand_Slot.gameObject.GetComponent<InventorySlot>();
		}
		if (invSlot != null)
			{
			if   ((objInt.isQuant==false) || ((objInt.isQuant) && (objInt.Link==1)) || (objInt.isEnchanted==true))
			{//Is a quantity of one or not a quantity/
				pInv.RemoveItem(this.name);
				pInv.SetObjectAtSlot(invSlot.slotIndex,this.name);
				objInt.inventorySlot=invSlot.slotIndex;
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
		}
		else
		{
			//Debug.Log ("No free hand");
			ml.Add (playerUW.StringControl.GetString(1,258));
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
		ml.Add(playerUW.StringControl.GetFormattedObjectNameUW(objInt,lightStatusText()));
		return true;
	}

	private string lightStatusText()
	{//The quality string of the light Eg is it spent or not.

			if (objInt.Quality == 0)
			{
				return playerUW.StringControl.GetString (5,60);//burned out
			}
			if ((objInt.Quality >=1) && (objInt.Quality <15))
			{
				return playerUW.StringControl.GetString (5,61);//nearly spent
			}
			if ((objInt.Quality >=15) && (objInt.Quality <32))
			{
				return playerUW.StringControl.GetString (5,62);//half burned
			}
			if ((objInt.Quality >=32) && (objInt.Quality <49))
			{
				return playerUW.StringControl.GetString (5,63);//somewhat used
			}

			if ((objInt.Quality >=50) && (objInt.Quality <64))
			{
				return playerUW.StringControl.GetString (5,64);//hardly used
			}
			else
			{
				return playerUW.StringControl.GetString (5,64);//unused
			}
	}

}

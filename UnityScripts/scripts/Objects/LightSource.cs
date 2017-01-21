﻿using UnityEngine;
using System.Collections;
/// <summary>
/// Light sources the player can carry around and use
/// </summary>
public class LightSource : object_base {
	/// How bright the light is. Light radius
	public int Brightness;

	/// Sprite index for the light on image
	public int ItemIdOn;
	/// Sprite index for the light off image
	public int ItemIdOff;
	
	/// Is the light active
	public bool IsOn;

		/// Basic brightness around the player.
	public const int BaseBrightness = 8;

		/// The light level obtained from magic spells
	public static int MagicBrightness=0;
		/// Interval of time between light quality drops
	public float LightTimerMax=30.0f;
		/// Current time remaining on the light quality interval
	public float LightTimer;

	/// <summary>
	/// Ticks down the light source
	/// </summary>
	void Update () {
		if (IsOn==true)
		{
			if (objInt().PickedUp==false)
			{
				SetOff ();
			}
			else
			{
				if (objInt().item_id!=147)
				{//The taper never runs out
					LightTimer-=Time.deltaTime;
					if (LightTimer<=0)
					{
							objInt().Quality--;
							LightTimer=LightTimerMax;
							if (objInt().Quality==0)
							{
									SetOff();
							}
					}	
				}

			}
		}
	}

	public override bool use ()
	{
		//CheckReferences();
		if (GameWorldController.instance.playerUW.playerInventory.ObjectInHand == "")
		{
			if (objInt().PickedUp==false)
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
			return ActivateByObject(GameWorldController.instance.playerUW.playerInventory.GetGameObjectInHand());
		}
	}


	public override bool ActivateByObject (GameObject ObjectUsed)
	{
		//000~001~182~You think it is a bad idea to add oil to the lit torch. \n
		ObjectInteraction objIntUsed = ObjectUsed.GetComponent<ObjectInteraction>();
		if (objIntUsed != null) 
		{
				switch (objIntUsed.GetItemType())
				{
				case ObjectInteraction.OIL:
						if (objInt().item_id==149)//Lit torch
						{
							UWHUD.instance.MessageScroll.Add(StringController.instance.GetString(1,182));	
							return true ;
						}
						break;
				}
		}
		return base.ActivateByObject (ObjectUsed);
	}

		/// <summary>
		/// Turns the light on if there is a free inventory slot to hold it in.
		/// </summary>
	public void SetOn()
	{		
		if (objInt().Quality<=0)
		{//000~001~124~That light is already used up. \n
			UWHUD.instance.MessageScroll.Add(StringController.instance.GetString(1,124));
			return;
		}

		LightTimer=LightTimerMax;		

		//CheckReferences();
		//Turn on the torch
		//Try and put the torch in an shoulder/hand slot if it is not already there.
		PlayerInventory pInv = GameWorldController.instance.playerUW.playerInventory; //GameObject.Find ("Gronk").GetComponent<PlayerInventory>();
		InventorySlot invSlot = null;
		if ((pInv.sRightShoulder=="") || (pInv.sRightShoulder==this.name))
		{						
			//invSlot=GameObject.Find ("RightShoulder_Slot").GetComponent<InventorySlot>();
			invSlot=UWHUD.instance.RightShoulder_Slot.gameObject.GetComponent<InventorySlot>();
		}
		else if ((pInv.sLeftShoulder=="") || (pInv.sLeftShoulder==this.name))
		{
			//invSlot=GameObject.Find ("LeftShoulder_Slot").GetComponent<InventorySlot>();
			invSlot=UWHUD.instance.LeftShoulder_Slot.gameObject.GetComponent<InventorySlot>();
		}
		else if ((pInv.sRightHand=="") || (pInv.sRightHand==this.name))
		{
			//invSlot=GameObject.Find ("RightHand_Slot").GetComponent<InventorySlot>();
			invSlot=UWHUD.instance.RightHand_Slot.gameObject.GetComponent<InventorySlot>();
		}
		else if ((pInv.sLeftHand=="") || (pInv.sLeftHand==this.name))
		{
			//invSlot=GameObject.Find ("LeftHand_Slot").GetComponent<InventorySlot>();
			invSlot=UWHUD.instance.LeftHand_Slot.gameObject.GetComponent<InventorySlot>();
		}
		if (invSlot != null)
			{
			if   ((objInt().isQuant==false) || ((objInt().isQuant) && (objInt().Link==1)) || (objInt().isEnchanted==true))
			{//Is a quantity of one or not a quantity/
				pInv.RemoveItem(this.name);
				pInv.SetObjectAtSlot(invSlot.slotIndex,this.name);
				objInt().inventorySlot=invSlot.slotIndex;
				IsOn=true;
				objInt().item_id=ItemIdOn;
				objInt().InvDisplayIndex=ItemIdOn;
			}
			else
			{//Clone the item and move it's clone to the inventory slot
				GameObject split = Instantiate(this.gameObject);
				split.name= split.name+"_"+ GameWorldController.instance.playerUW.summonCount++;
				split.GetComponent<ObjectInteraction>().Link=1;//Increment and decrement the object count as appropiate;
				objInt().Link--;
				split.transform.parent=this.transform.parent;
				//Activate the split instead
				split.GetComponent<ObjectInteraction>().Use();
				split.GetComponent<ObjectInteraction>().isQuant=false;
			}
		}
		else
		{
			//Debug.Log ("No free hand");
			UWHUD.instance.MessageScroll.Add (StringController.instance.GetString(1,258));
		}
		objInt().RefreshAnim();
		GameWorldController.instance.playerUW.playerInventory.UpdateLightSources();
	}
	
	/// <summary>
	/// Turns the light off
	/// </summary>
	public void SetOff()
	{
		IsOn=false;
		objInt().item_id=ItemIdOff;
		objInt().InvDisplayIndex=ItemIdOff;
		objInt().isQuant=true;
		objInt().RefreshAnim();
		GameWorldController.instance.playerUW.playerInventory.UpdateLightSources();
	}

	public override bool LookAt()
	{
		UWHUD.instance.MessageScroll.Add(StringController.instance.GetFormattedObjectNameUW(objInt(),lightStatusText()));
		return true;
	}

		/// <summary>
		/// Returns a string identifying the state of the light source
		/// </summary>
		/// <returns>The status text.</returns>
	private string lightStatusText()
	{//The quality string of the light Eg is it spent or not.

			if (objInt().Quality == 0)
			{
				return StringController.instance.GetString (5,60);//burned out
			}
			if ((objInt().Quality >=1) && (objInt().Quality <15))
			{
				return StringController.instance.GetString (5,61);//nearly spent
			}
			if ((objInt().Quality >=15) && (objInt().Quality <32))
			{
				return StringController.instance.GetString (5,62);//half burned
			}
			if ((objInt().Quality >=32) && (objInt().Quality <49))
			{
				return StringController.instance.GetString (5,63);//somewhat used
			}

			if ((objInt().Quality >=50) && (objInt().Quality <64))
			{
				return StringController.instance.GetString (5,64);//hardly used
			}
			else
			{
				return StringController.instance.GetString (5,64);//unused
			}
	}

	public override bool PutItemAwayEvent (int slotNo)
	{
			if (IsOn)
			{
				SetOff();		
			}
			return true;
	}

		public override string UseVerb()
		{
			if (IsOn)
			{
				return "douse";
			}
			else
			{
				return "ignite";
			}
		}

}
using UnityEngine;
using System.Collections;
/// <summary>
/// Light sources the player can carry around and use
/// </summary>
public class LightSource : object_base {
	/// How bright the light is. Light radius
	//public int Brightness=4;//Default for the moment until we can get commonobj props imported.
	//public int duration;
	/// Sprite index for the light on image
	//public int ItemIdOn;
	/// Sprite index for the light off image
	//public int ItemIdOff;
	

	/// Is the light active
	public bool IsOn()
		{
			switch (item_id)
			{
				case 144:
				case 145:
				case 146:
				case 147:
						return false;
				case 148:
				case 149:
				case 150:
				case 151:
						return true;
			}
		return false;
		}

		/// Basic brightness around the player.
	public static float BaseBrightness = 16f;

		/// The light level obtained from magic spells
	public static float MagicBrightness=0;
		/// Interval of time between light quality drops
	public float LightTimerMax=30.0f;
		/// Current time remaining on the light quality interval
	public float LightTimer;


	/// <summary>
	/// Ticks down the light source
	/// </summary>
	public override void Update()  {
		base.Update();
		if (IsOn()==true)
		{
			if (objInt().PickedUp==false)
			{
			//		SetOff ();
			}
			else
			{
				if (Duration()!=0)
				//if (item_id!=151)
				{//The taper never runs out
					LightTimer-=Time.deltaTime;
					if (LightTimer<=0)
					{
						quality--;
						LightTimer=LightTimerMax;
						if (quality<=0)
						{
							quality=0;
							SetOff();
						}
					}	
				}
			}
		}
	}

	public override bool use ()
	{
		if (CurrentObjectInHand == null)
		{
			if (objInt().PickedUp==false)
			{
				if (IsOn()==true)
				{
					SetOff ();
				}
				return true;
			}
			
			if (IsOn() == true)
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
			return ActivateByObject(CurrentObjectInHand);
		}
	}


	public override bool ActivateByObject (ObjectInteraction ObjectUsed)
	{
		//000~001~182~You think it is a bad idea to add oil to the lit torch. \n
		//ObjectInteraction objIntUsed = ObjectUsed.GetComponent<ObjectInteraction>();
		if (ObjectUsed != null) 
		{
			switch (ObjectUsed.GetItemType())
			{
			case ObjectInteraction.OIL:
				if (item_id==149)//Lit torch
				{
					UWHUD.instance.MessageScroll.Add(StringController.instance.GetString(1,StringController.str_you_think_it_is_a_bad_idea_to_add_oil_to_the_lit_torch_));	
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
		if (quality<=0)
		{//000~001~124~That light is already used up. \n
			UWHUD.instance.MessageScroll.Add(StringController.instance.GetString(1,StringController.str_that_light_is_already_used_up_));
			return;
		}
		LightTimer=LightTimerMax;		

		//Turn on the torch
		//Try and put the torch in an shoulder/hand slot if it is not already there.
		PlayerInventory pInv = UWCharacter.Instance.playerInventory; //GameObject.Find ("Gronk").GetComponent<PlayerInventory>();
		InventorySlot invSlot = null;
		GetInventorySlotForLightSource (pInv, ref invSlot);
		if (invSlot != null)
			{
			if   ((objInt().isQuant==false) || ((objInt().isQuant) && (link<=1)) || (objInt().isEnchanted))
			{//Is a quantity of one or not a quantity/
					PutLightSourceInSlot (pInv, invSlot);
			}
			else
			{//Clone the item and move it's clone to the inventory slot
				if (objInt().GetItemType() != ObjectInteraction.REFILLABLE_LANTERN)
				{
					SplitLightSourceIntoSlot ();
				}
				else
				{
					PutLightSourceInSlot(pInv, invSlot);
				}
			}
		}
		else
		{
			UWHUD.instance.MessageScroll.Add (StringController.instance.GetString(1,StringController.str_there_is_no_place_to_put_that_));
		}
		objInt().RefreshAnim();
		UWCharacter.Instance.playerInventory.UpdateLightSources();
	}

	void SplitLightSourceIntoSlot ()
	{
		GameObject split = Instantiate (this.gameObject);
		split.name =  ObjectInteraction.UniqueObjectName(split.GetComponent<ObjectInteraction>());  //split.name + "_" + UWCharacter.Instance.summonCount++;
		split.GetComponent<ObjectInteraction> ().link = 1;
		//Increment and decrement the object count as appropiate;
		link--;
		if (link < 0) {
			link = 0;
		}
		split.transform.parent = this.transform.parent;
		//Activate the split instead
		split.GetComponent<ObjectInteraction> ().Use ();
		split.GetComponent<ObjectInteraction> ().isquant = 1;
	}

	void PutLightSourceInSlot (PlayerInventory pInv , InventorySlot invSlot)
	{
		pInv.RemoveItem (this.objInt());
		pInv.SetObjectAtSlot (invSlot.slotIndex, objInt());
		objInt().inventorySlot = invSlot.slotIndex;
		item_id = item_id + 4;
		objInt().InvDisplayIndex = item_id;
	}

		/// <summary>
		/// Gets the inventory slot for light source.
		/// </summary>
		/// <param name="pInv">P inv.</param>
		/// <param name="invSlot">Inv slot.</param>
	void GetInventorySlotForLightSource (PlayerInventory pInv, ref InventorySlot invSlot)
	{
		if ((pInv.sRightShoulder == this.objInt())) {
			invSlot = UWHUD.instance.RightShoulder_Slot.gameObject.GetComponent<InventorySlot> ();
		}
		else
			if ((pInv.sLeftShoulder == this.objInt())) {
				invSlot = UWHUD.instance.LeftShoulder_Slot.gameObject.GetComponent<InventorySlot> ();
			}
			else
				if ((pInv.sRightHand == this.objInt())) {
					invSlot = UWHUD.instance.RightHand_Slot.gameObject.GetComponent<InventorySlot> ();
				}
				else
					if ((pInv.sLeftHand == this.objInt())) {
						invSlot = UWHUD.instance.LeftHand_Slot.gameObject.GetComponent<InventorySlot> ();
					}
	}
	
	/// <summary>
	/// Turns the light off
	/// </summary>
	public void SetOff()
	{
		//IsOn=false;
		//item_id=ItemIdOff;
		//objInt().InvDisplayIndex=ItemIdOff;
		item_id=item_id-4;
		objInt().InvDisplayIndex=item_id;
		objInt().WorldDisplayIndex=item_id;
		isquant=1;
		objInt().RefreshAnim();
		//Brightness=GameWorldController.instance.objDat.lightSourceStats[item_id-144].brightness;
		//duration=GameWorldController.instance.objDat.lightSourceStats[item_id-144].duration;
		UWCharacter.Instance.playerInventory.UpdateLightSources();
	}

	public override bool LookAt()
	{
				if ( (_RES==GAME_UW1) && ((item_id==Quest.TalismanTaper) || (item_id==Quest.TalismanTaperLit) ))
				{
						heading=7;
						switch(objInt().identity())
						{
						case ObjectInteraction.IdentificationFlags.Identified:
						default:
								UWHUD.instance.MessageScroll.Add (StringController.instance.GetString(1,StringController.str_you_see_) +  StringController.instance.GetString(1,262));
								break;
						}
						return true;
				}
				else
				{
					UWHUD.instance.MessageScroll.Add(StringController.instance.GetFormattedObjectNameUW(objInt(),lightStatusText()) + OwnershipString());
					return true;
				}
	}

		/// <summary>
		/// Returns a string identifying the state of the light source
		/// </summary>
		/// <returns>The status text.</returns>
	private string lightStatusText()
	{//The quality string of the light Eg is it spent or not.

			if (quality == 0)
			{
				return StringController.instance.GetString (5,60);//burned out
			}
			if ((quality >=1) && (quality <15))
			{
				return StringController.instance.GetString (5,61);//nearly spent
			}
			if ((quality >=15) && (quality <32))
			{
				return StringController.instance.GetString (5,62);//half burned
			}
			if ((quality >=32) && (quality <49))
			{
				return StringController.instance.GetString (5,63);//somewhat used
			}

			if ((quality >=50) && (quality <64))
			{
				return StringController.instance.GetString (5,64);//hardly used
			}
			else
			{
				return StringController.instance.GetString (5,64);//unused
			}
	}

	public override bool PutItemAwayEvent (short slotNo)
	{
			if (IsOn())
			{
				SetOff();		
			}
			return true;
	}

		public override string UseVerb()
		{
			if (IsOn())
			{
				return "douse";
			}
			else
			{
				return "ignite";
			}
		}


		public float Brightness()
		{
			return (float)GameWorldController.instance.objDat.lightSourceStats[item_id-144].brightness * 1.5f;		
		}

		public int Duration()
		{
			return GameWorldController.instance.objDat.lightSourceStats[item_id-144].duration;	
		}

	public override bool DropEvent ()
	{
		if (IsOn())
		{
				SetOff();
				return true;
		}
		return false;
	}

}
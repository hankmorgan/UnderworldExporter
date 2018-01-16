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
			switch (objInt().item_id)
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

	//protected override void Start ()
	//{
		//base.Start ();
		//Brightness=GameWorldController.instance.objDat.lightSourceStats[objInt().item_id-144].brightness;
		//duration=GameWorldController.instance.objDat.lightSourceStats[objInt().item_id-144].duration;
	//}

	/// <summary>
	/// Ticks down the light source
	/// </summary>
	void Update () {
		if (IsOn()==true)
		{
			if (objInt().PickedUp==false)
			{
				SetOff ();
			}
			else
			{
				if (Duration()!=0)
				//if (objInt().item_id!=151)
				{//The taper never runs out
					LightTimer-=Time.deltaTime;
					if (LightTimer<=0)
					{
						objInt().quality--;
						LightTimer=LightTimerMax;
						if (objInt().quality==0)
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
		if (UWCharacter.Instance.playerInventory.ObjectInHand == "")
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
			return ActivateByObject(UWCharacter.Instance.playerInventory.GetGameObjectInHand());
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
		if (objInt().quality<=0)
		{//000~001~124~That light is already used up. \n
			UWHUD.instance.MessageScroll.Add(StringController.instance.GetString(1,StringController.str_that_light_is_already_used_up_));
			return;
		}
		LightTimer=LightTimerMax;		

		//CheckReferences();
		//Turn on the torch
		//Try and put the torch in an shoulder/hand slot if it is not already there.
		PlayerInventory pInv = UWCharacter.Instance.playerInventory; //GameObject.Find ("Gronk").GetComponent<PlayerInventory>();
		InventorySlot invSlot = null;
		if ((pInv.sRightShoulder=="") || (pInv.sRightShoulder==this.name))
		{						
			invSlot=UWHUD.instance.RightShoulder_Slot.gameObject.GetComponent<InventorySlot>();
		}
		else if ((pInv.sLeftShoulder=="") || (pInv.sLeftShoulder==this.name))
		{
			invSlot=UWHUD.instance.LeftShoulder_Slot.gameObject.GetComponent<InventorySlot>();
		}
		else if ((pInv.sRightHand=="") || (pInv.sRightHand==this.name))
		{
			invSlot=UWHUD.instance.RightHand_Slot.gameObject.GetComponent<InventorySlot>();
		}
		else if ((pInv.sLeftHand=="") || (pInv.sLeftHand==this.name))
		{
			invSlot=UWHUD.instance.LeftHand_Slot.gameObject.GetComponent<InventorySlot>();
		}
		if (invSlot != null)
			{
			if   ((objInt().isQuant()==false) || ((objInt().isQuant()) && (objInt().link==1)) || (objInt().isEnchanted()==true))
			{//Is a quantity of one or not a quantity/
				pInv.RemoveItem(this.name);
				pInv.SetObjectAtSlot(invSlot.slotIndex,this.name);
				objInt().inventorySlot=invSlot.slotIndex;
				//IsOn=true;
				objInt().item_id=objInt().item_id+4;
				//Brightness=GameWorldController.instance.objDat.lightSourceStats[objInt().item_id-144].brightness;
				//Duration=GameWorldController.instance.objDat.lightSourceStats[objInt().item_id-144].duration;
				objInt().InvDisplayIndex=objInt().item_id;
			}
			else
			{//Clone the item and move it's clone to the inventory slot
				GameObject split = Instantiate(this.gameObject);
				split.name= split.name+"_"+ UWCharacter.Instance.summonCount++;
				split.GetComponent<ObjectInteraction>().link=1;//Increment and decrement the object count as appropiate;
				objInt().link--;
				split.transform.parent=this.transform.parent;
				//Activate the split instead
				split.GetComponent<ObjectInteraction>().Use();
				split.GetComponent<ObjectInteraction>().isquant=0;
			}
		}
		else
		{
			UWHUD.instance.MessageScroll.Add (StringController.instance.GetString(1,StringController.str_there_is_no_place_to_put_that_));
		}
		objInt().RefreshAnim();
		UWCharacter.Instance.playerInventory.UpdateLightSources();
	}
	
	/// <summary>
	/// Turns the light off
	/// </summary>
	public void SetOff()
	{
		//IsOn=false;
		//objInt().item_id=ItemIdOff;
		//objInt().InvDisplayIndex=ItemIdOff;
		objInt().item_id=objInt().item_id-4;
		objInt().InvDisplayIndex=objInt().item_id;
		objInt().isquant=1;
		objInt().RefreshAnim();
		//Brightness=GameWorldController.instance.objDat.lightSourceStats[objInt().item_id-144].brightness;
		//duration=GameWorldController.instance.objDat.lightSourceStats[objInt().item_id-144].duration;
		UWCharacter.Instance.playerInventory.UpdateLightSources();
	}

	public override bool LookAt()
	{
		UWHUD.instance.MessageScroll.Add(StringController.instance.GetFormattedObjectNameUW(objInt(),lightStatusText()) + OwnershipString());
		return true;
	}

		/// <summary>
		/// Returns a string identifying the state of the light source
		/// </summary>
		/// <returns>The status text.</returns>
	private string lightStatusText()
	{//The quality string of the light Eg is it spent or not.

			if (objInt().quality == 0)
			{
				return StringController.instance.GetString (5,60);//burned out
			}
			if ((objInt().quality >=1) && (objInt().quality <15))
			{
				return StringController.instance.GetString (5,61);//nearly spent
			}
			if ((objInt().quality >=15) && (objInt().quality <32))
			{
				return StringController.instance.GetString (5,62);//half burned
			}
			if ((objInt().quality >=32) && (objInt().quality <49))
			{
				return StringController.instance.GetString (5,63);//somewhat used
			}

			if ((objInt().quality >=50) && (objInt().quality <64))
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
			return (float)GameWorldController.instance.objDat.lightSourceStats[objInt().item_id-144].brightness * 1.5f;		
		}

		public int Duration()
		{
			return GameWorldController.instance.objDat.lightSourceStats[objInt().item_id-144].duration;	
		}

}
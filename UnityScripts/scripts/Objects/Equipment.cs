using UnityEngine;
using System.Collections;
using UnityEngine.UI;
/// <summary>
/// Base class for weapons and armour
/// </summary>
public class Equipment : object_base {
	///Not sure if this is needed.	
	//public int Durability;	

	public virtual int GetActualSpellIndex()
	{
		return objInt().link-256;
	}


	public override bool use ()
	{
		if (GameWorldController.instance.playerUW.playerInventory.ObjectInHand !="")
		{
			return ActivateByObject(GameWorldController.instance.playerUW.playerInventory.GetGameObjectInHand());
		}
		else
		{
			return false;
		}
	}


		/// <summary>
		/// Activation of this object by another. EG key on door
		/// </summary>
		/// <returns>true</returns>
		/// <c>false</c>
		/// <param name="ObjectUsed">Object used.</param>
		/// Handles anvil usage
	public override bool ActivateByObject (GameObject ObjectUsed)
	{
		ObjectInteraction objIntUsed = ObjectUsed.GetComponent<ObjectInteraction>();
		if (objIntUsed != null) 
		{
			switch (objIntUsed.GetItemType())
			{
			case ObjectInteraction.ANVIL: //ANVIL
				{
				//Do a difficulty check and prompt for approval.
				UWHUD.instance.MessageScroll.Set ("[placeholder]You think it will be hard/easy to repair this item. Press Y or N followed by enter to proceed");
				InputField inputctrl =UWHUD.instance.InputControl;
				inputctrl.gameObject.SetActive(true);
				inputctrl.gameObject.GetComponent<InputHandler>().target=this.gameObject;
				inputctrl.gameObject.GetComponent<InputHandler>().currentInputMode=InputHandler.InputAnvil;
				inputctrl.contentType= InputField.ContentType.Alphanumeric;
				inputctrl.Select();
				WindowDetect.WaitingForInput=true;
				Time.timeScale=0.0f;
				return true;
				}
			}
		}
		return false;
	}

		/// <summary>
		/// Refreshes the quality of armour when damage is taken
		/// </summary>
	public virtual void UpdateQuality()
	{//Template for repairing and updating the graphics on equipment. Used by armour mainly.
		return;
	}

		/// <summary>
		/// Event handler for processing the repair question y/n
		/// </summary>
		/// <param name="ans">Ans.</param>
	public void OnSubmitPickup(string ans)
	{
		Time.timeScale=1.0f;
		UWHUD.instance.InputControl.gameObject.SetActive(false);
		WindowDetectUW.WaitingForInput=false;
		UWHUD.instance.MessageScroll.Clear();//="";
		if (ans.Substring(0,1).ToUpper() == "Y")
		{
			//do the repair 
			//Play the cutscene.
			UWHUD.instance.CutScenesSmall.anim.SetAnimation="cs404.n01";
			//TODO:At the moment it suceeds but in future implement failures and breakages.
			//Find out what the story with the sword of justice is?
			//Do the result at the end of the animation.
			if (GameWorldController.instance.playerUW.PlayerSkills.TrySkill(Skills.SkillRepair,0))
			{
								objInt().quality +=5; //objInt().quality+5;
				if (objInt().quality >63){objInt().quality=63;}
				UWHUD.instance.MessageScroll.Add("You repair the item");
			}		
			else
			{
				UWHUD.instance.MessageScroll.Add ("You fail to repair the item");
			}
			UpdateQuality();
		}
		//cancel the repair 
		GameWorldController.instance.playerUW.playerInventory.ObjectInHand="";
		UWHUD.instance.CursorIcon=UWHUD.instance.CursorIconDefault;
	}

	public override bool LookAt ()
	{
		if (objInt().isEnchanted()==true)
		{
			if (objInt().isIdentified==true)
			{
				UWHUD.instance.MessageScroll.Add (StringController.instance.GetFormattedObjectNameUW(objInt(),GetEquipmentConditionString()) + " of " + StringController.instance.GetString(6,GetActualSpellIndex()));
			}
			else
			{
					if (GameWorldController.instance.playerUW.PlayerSkills.TrySkill(Skills.SkillLore, getIdentificationLevels(GetActualSpellIndex())))
					{
						objInt().isIdentified=true;
						UWHUD.instance.MessageScroll.Add (StringController.instance.GetFormattedObjectNameUW(objInt(),GetEquipmentConditionString()) + " of " + StringController.instance.GetString(6,GetActualSpellIndex()));
					}
					else
					{
						UWHUD.instance.MessageScroll.Add (StringController.instance.GetFormattedObjectNameUW(objInt(),GetEquipmentConditionString()));		
					}					
			}
			return true;
		}
		else
		{
			if (objInt().PickedUp==true)
			{
					UWHUD.instance.MessageScroll.Add (StringController.instance.GetFormattedObjectNameUW(objInt(),GetEquipmentConditionString()));		
			}
			else
			{
					return base.LookAt();					
			}			
		}
	return true;
	}

		/// <summary>
		/// Gets the equipment condition.
		/// </summary>
		/// <returns>The equipment condition string.</returns>
		public virtual string GetEquipmentConditionString()
		{
			if ((objInt().quality>0) && (objInt().quality<=15))
			{//lowest
				return StringController.instance.GetString(5,7);
			}
			else if ((objInt().quality>15) && (objInt().quality<=30))
			{
				//Low quality
				return StringController.instance.GetString(5,8);

			}
			else if ((objInt().quality>30) && (objInt().quality<=45))
			{
					//Medium
				return StringController.instance.GetString(5,9);
			}
			else if ((objInt().quality>45) && (objInt().quality<=63))
			{
					//Best
				return StringController.instance.GetString(5,10);
			}
		return "";
		}


	/// <summary>
	/// Damage caused to the item when it hits or is hit by something with heavy resistance.
	/// </summary>
	public virtual void SelfDamage(short damage)
	{
		objInt().quality-=damage;
		UpdateQuality();
		if (objInt().quality<=0)
		{
			ChangeType(208,23);//Change to debris.
			this.gameObject.AddComponent<object_base>();//Add a generic object base for behaviour
			//Destroy(this);//Kill me now.
		}
	}


}
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
/// <summary>
/// Base class for weapons and armour
/// </summary>
public class Equipment : object_base {
	///Not sure if this is needed.	
	public int Durability;	

	public virtual int GetActualSpellIndex()
	{
		return objInt().Link-256;
	}


	public override bool use ()
	{
		if (playerUW.playerInventory.ObjectInHand !="")
		{
			return ActivateByObject(playerUW.playerInventory.GetGameObjectInHand());
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
			switch (objIntUsed.ItemType)
			{
			case ObjectInteraction.ANVIL: //ANVIL
				{
				//Do a difficulty check and prompt for approval.
				GameWorldController.instance.playerUW.playerHud.MessageScroll.Set ("[placeholder]You think it will be hard/easy to repair this item");
				InputField inputctrl =playerUW.playerHud.InputControl;
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
		WindowDetectUW.WaitingForInput=false;
		GameWorldController.instance.playerUW.playerHud.MessageScroll.Clear();//="";
		if (ans.Substring(0,1).ToUpper() == "Y")
		{
			//do the repair 
			//Play the cutscene.
			playerUW.playerHud.CutScenesSmall.SetAnimation="Anvil";
			//TODO:At the moment it suceeds but in future implement failures and breakages.
			//Find out what the story with the sword of justice is?
			//Do the result at the end of the animation.
			if (playerUW.PlayerSkills.TrySkill(Skills.SkillRepair,0))
			{
				objInt().Quality = objInt().Quality+5;
				if (objInt().Quality >63){objInt().Quality=63;}
				GameWorldController.instance.playerUW.playerHud.MessageScroll.Add("You repair the item");
			}		
			else
			{
				GameWorldController.instance.playerUW.playerHud.MessageScroll.Add ("You fail to repair the item");
			}
			UpdateQuality();
		}
		//cancel the repair 
		playerUW.playerInventory.ObjectInHand="";
		playerUW.playerHud.CursorIcon=playerUW.playerHud.CursorIconDefault;
	}

	public override bool LookAt ()
	{
		if (objInt().isEnchanted==true)
		{
			if (objInt().isIdentified==true)
			{
					GameWorldController.instance.playerUW.playerHud.MessageScroll.Add (playerUW.StringControl.GetFormattedObjectNameUW(objInt()) + " of " + playerUW.StringControl.GetString(6,GetActualSpellIndex()));
			}
			else
			{
					if (playerUW.PlayerSkills.TrySkill(Skills.SkillLore, getIdentificationLevels(GetActualSpellIndex())))
					{
							objInt().isIdentified=true;
							GameWorldController.instance.playerUW.playerHud.MessageScroll.Add (playerUW.StringControl.GetFormattedObjectNameUW(objInt()) + " of " + playerUW.StringControl.GetString(6,GetActualSpellIndex()));
					}
					else
					{
							GameWorldController.instance.playerUW.playerHud.MessageScroll.Add (playerUW.StringControl.GetFormattedObjectNameUW(objInt()));		
					}					
			}
			return true;
		}
		else
		{
			return base.LookAt();
		}
	}
}
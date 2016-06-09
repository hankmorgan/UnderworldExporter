using UnityEngine;
using System.Collections;

public class Equipment : object_base {
//Base class for weapons and armour
	public int Durability;	//Not sure if this is needed.

	public virtual int GetActualSpellIndex()
	{
		return objInt.Link-256;
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
				ml.Set ("[placeholder]You think it will be hard/easy to repair this item");
				UIInput inputctrl =playerUW.playerHud.InputControl;
				inputctrl.eventReceiver=this.gameObject;
				inputctrl.type=UIInput.KeyboardType.Default;
				inputctrl.useLabelTextAtStart=true;
				inputctrl.selected=true;
				WindowDetect.WaitingForInput=true;
				Time.timeScale=0.0f;
				return true;
				break;
				}
			}
		}
		return false;
	}

	public virtual void UpdateQuality()
	{//Template for repairing and updating the graphics on equipment. Used by armour mainly.
		return;
	}


	public void OnSubmitPickup()
	{//Event handler for processing the repair question y/n
		Time.timeScale=1.0f;
		WindowDetectUW.WaitingForInput=false;
		UIInput inputctrl =playerUW.playerHud.InputControl;//playerUW.GetMessageLog().gameObject.GetComponent<UIInput>();

		string ans = inputctrl.text;
		ml.Clear();//="";
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
				objInt.Quality = objInt.Quality+5;
				if (objInt.Quality >63){objInt.Quality=63;}
				ml.Add("You repair the item");
			}		
			else
			{
				ml.Add ("You fail to repair the item");
			}
			UpdateQuality();
		}
		//cancel the repair 
		playerUW.playerInventory.ObjectInHand="";
		playerUW.CursorIcon=playerUW.CursorIconDefault;
	}

	public override bool LookAt ()
	{
		if (objInt.isEnchanted==true)
		{
			ml.Add (playerUW.StringControl.GetFormattedObjectNameUW(objInt) + " of " + playerUW.StringControl.GetString(6,GetActualSpellIndex()));
			return true;
		}
		else
		{
			return base.LookAt();
		}
	}

}

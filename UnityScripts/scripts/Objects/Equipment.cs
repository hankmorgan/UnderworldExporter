using UnityEngine;
using System.Collections;
using UnityEngine.UI;
/// <summary>
/// Base class for weapons and armour
/// </summary>
public class Equipment : object_base {
	///Not sure if this is needed.	
	//public int Durability;

	// ProtectionBonus of magic armour
	//public short ProtectionBonus;
	// Toughness Bonus for magic durability 
	//public short ToughnessBonus;


	public int EquipIconIndex;

	public string DisplayEnchantment;

	protected override void Start ()
	{
		base.Start ();
		UpdateQuality();
		SetDisplayEnchantment ();
	}

	/// <summary>
	/// Pulls in the enchantment name on this object for use in the context menu
	/// </summary>
	public void SetDisplayEnchantment ()
	{
		DisplayEnchantment = StringController.instance.GetString (6, GetActualSpellIndex ());
		if (DisplayEnchantment == "") 
		{
				DisplayEnchantment = "NONE";
		}
	}

	public virtual int GetActualSpellIndex()
	{
		return objInt().link-256;
	}

	public override bool use ()
	{
		if (UWCharacter.Instance.playerInventory.ObjectInHand !="")
		{
			return ActivateByObject(UWCharacter.Instance.playerInventory.GetGameObjectInHand());
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
			if (UWCharacter.Instance.PlayerSkills.TrySkill(Skills.SkillRepair,0))
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
		UWCharacter.Instance.playerInventory.ObjectInHand="";
		UWHUD.instance.CursorIcon=UWHUD.instance.CursorIconDefault;
	}

	public override bool LookAt ()
	{
		if (objInt().isEnchanted()==true)
		{
			switch(objInt().identity())
				{
				case ObjectInteraction.IdentificationFlags.Identified:
						UWHUD.instance.MessageScroll.Add (StringController.instance.GetFormattedObjectNameUW(objInt(),GetEquipmentConditionString()) + " of " + StringController.instance.GetString(6,GetActualSpellIndex()) + OwnershipString());
						SetDisplayEnchantment();
						break;				
				case ObjectInteraction.IdentificationFlags.Unidentified:
				case ObjectInteraction.IdentificationFlags.PartiallyIdentified:
						//Try and re-id using lore skill
						if (UWCharacter.Instance.PlayerSkills.TrySkill(Skills.SkillLore, getIdentificationLevels(GetActualSpellIndex())))
						{
							objInt().heading=7;
							UWHUD.instance.MessageScroll.Add (StringController.instance.GetFormattedObjectNameUW(objInt(),GetEquipmentConditionString()) + " of " + StringController.instance.GetString(6,GetActualSpellIndex()) + OwnershipString());
						}
						else
						{
							UWHUD.instance.MessageScroll.Add (StringController.instance.GetFormattedObjectNameUW(objInt(),GetEquipmentConditionString()) + OwnershipString());		
						}
						break;
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
				if (_RES==GAME_UW1)
				{
						if ((objInt().item_id==10) ||(objInt().item_id==55) || (objInt().item_id==47)|| (objInt().item_id==48)|| (objInt().item_id==49)|| (objInt().item_id==50))
						{
								return StringController.instance.GetString(5,10);	
						}
				}
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
			else //if ((objInt().quality>45))// && (objInt().quality<=63))
			{
					//Best
				return StringController.instance.GetString(5,10);
			}
		//return " ";
		}


	/// <summary>
	/// Damage caused to the item when it hits or is hit by something with heavy resistance.
	/// </summary>
	public virtual void SelfDamage(short damage)
	{
		if (_RES==GAME_UW1)
		{
			if ((objInt().item_id==10) ||(objInt().item_id==55) || (objInt().item_id==47)|| (objInt().item_id==48)|| (objInt().item_id==49)|| (objInt().item_id==50))
			{//No damage to sword of justice shield of valor, dragonskin boots or crowns.
				return;
			}
		}
		short equipBefore=(short)EquipIconIndex;
		objInt().quality-=damage;
		UpdateQuality();	
		if (objInt().quality<=0)
		{
			UWHUD.instance.MessageScroll.Add("Your " + StringController.instance.GetSimpleObjectNameUW(objInt().item_id) + " was destroyed");
			ChangeType(208,23);//Change to debris.
			this.gameObject.AddComponent<object_base>();//Add a generic object base for behaviour
			if (this.GetComponent<Weapon>())
			{
				UWCharacter.Instance.PlayerCombat.currWeapon=null;
			}
		}
		else
		{
			if (equipBefore!=EquipIconIndex)
			{
				UWHUD.instance.MessageScroll.Add("Your " + StringController.instance.GetSimpleObjectNameUW(objInt().item_id) + " was damaged");						
			}
		}

	}


		/// <summary>
		/// Gets the defence score of this armour.
		/// </summary>
		/// <returns>The defence.</returns>
		public virtual short getDefence()
		{
				return GameWorldController.instance.objDat.armourStats[objInt().item_id-32].protection;	
		}

		public virtual short getDurability()
		{
			return (short)(0+DurabilityBonus());
			//return GameWorldController.instance.objDat.armourStats[objInt().item_id-32].durability;	
		}


		/// <summary>
		/// Returns the durability bonus applied to the weapon from it's enchantment.
		/// </summary>
		/// <returns>The bonus.</returns>
		public short DurabilityBonus()
		{
				switch(objInt().link)
				{
				case SpellEffect.UW1_Spell_Effect_MinorToughness:
				case SpellEffect.UW1_Spell_Effect_Toughness:
				case SpellEffect.UW1_Spell_Effect_AdditionalToughness:
				case SpellEffect.UW1_Spell_Effect_MajorToughness:
				case SpellEffect.UW1_Spell_Effect_GreatToughness:
				case SpellEffect.UW1_Spell_Effect_VeryGreatToughness:
				case SpellEffect.UW1_Spell_Effect_TremendousToughness:
				case SpellEffect.UW1_Spell_Effect_UnsurpassedToughness:
						return (short)(objInt().link-472);//Toughness bonus starts at +3 why not					
				}
				return 0;	
		}


		public short ProtectionBonus()
		{
				switch(objInt().link)
				{
				case SpellEffect.UW1_Spell_Effect_MinorProtection:
				case SpellEffect.UW1_Spell_Effect_Protection:
				case SpellEffect.UW1_Spell_Effect_AdditionalProtection:
				case SpellEffect.UW1_Spell_Effect_MajorProtection:
				case SpellEffect.UW1_Spell_Effect_GreatProtection:
				case SpellEffect.UW1_Spell_Effect_VeryGreatProtection:
				case SpellEffect.UW1_Spell_Effect_TremendousProtection:
				case SpellEffect.UW1_Spell_Effect_UnsurpassedProtection:
						return (short)(objInt().link-461);//Protection bonus starts at +3 why not					
				}
				return 0;	
		}

		public override string ContextMenuDesc (int item_id)
		{
				if (objInt().isEnchanted())
				{
						switch (objInt().identity())
						{
						case ObjectInteraction.IdentificationFlags.Identified:
								return StringController.instance.GetFormattedObjectNameUW(objInt()) + " of " + DisplayEnchantment;					
						default:
								return base.ContextMenuDesc (item_id);
						}		
				}
				return base.ContextMenuDesc (item_id);	
		}



}
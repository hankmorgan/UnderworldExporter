using UnityEngine;
using System.Collections;
using UnityEngine.UI;
/// <summary>
/// Base class for objects and npcs
/// Works hand in hand with ObjectInteraction
/// </summary>
public class object_base : UWEBase {

	
	
	//The Object interaction that is on this object.
	protected ObjectInteraction _objInt;
	
		//For the context menu
	public static string ItemDesc;
	public static string UseableDesc;
	public static string PickableDesc;
	public static string UseObjectOnDesc;

	public static bool UseAvail;
	public static bool PickAvail;
	public static bool TalkAvail;



	///A trigger to activate when this object is picked up.
	//public string PickupLink;

		/// <summary>
		/// Gets the object interaction that this object base works with
		/// </summary>
		/// <returns>The object interaction.</returns>
	public ObjectInteraction objInt()
	{
		//CheckReferences();
		if (_objInt==null)
		{
			_objInt=this.GetComponent<ObjectInteraction>();
		}
		return _objInt; //this.gameObject.GetComponent<ObjectInteraction>();
	}

	protected virtual void Start()
	{
		//objInt = this.gameObject.GetComponent<ObjectInteraction>();
	/*	if (playerUW==null)
		{
			playerUW=GameWorldController.instance.playerUW;
		}
		if (ml==null)
		{
			ml=UWHUD.instance.MessageScroll;
		}
		CheckReferences();*/
	}

	/// <summary>
	/// For when this object is activated by code. Eg buttons
	/// </summary>
	public virtual bool Activate()
	{//Unimplemented items 
		//CheckReferences();
		return false;
	}

		/// <summary>
		/// Object is attacked or damaged in some way.
		/// </summary>
		/// <returns><c>true</c>, if attack was applyed, <c>false</c> otherwise.</returns>
		/// <param name="damage">Damage.</param>
	public virtual bool ApplyAttack(short damage)
	{
		return false;
	}

		/// <summary>
		/// Applies the attack from a known source
		/// </summary>
		/// <returns><c>true</c>, if attack was applyed, <c>false</c> otherwise.</returns>
		/// <param name="damage">Damage.</param>
		/// <param name="source">Source.</param>
	public virtual bool ApplyAttack(short damage, GameObject source)
	{
		return ApplyAttack(damage);
	}

		/// <summary>
		/// Outputs the look description of the object
		/// </summary>
		/// <returns>The <see cref="System.Boolean"/>.</returns>
	public virtual bool LookAt()
	{
		//CheckReferences();
		UWHUD.instance.MessageScroll.Add(StringController.instance.GetFormattedObjectNameUW(objInt()) + OwnershipString() );
		return true;
	}

		/// <summary>
		/// Activation of this object by another. EG key on door
		/// </summary>
		/// <returns><c>true</c>, if by object was activated, <c>false</c> otherwise.</returns>
		/// <param name="ObjectUsed">Object used.</param>
	public virtual bool ActivateByObject(GameObject ObjectUsed)
	{
		//CheckReferences();
		if (UWCharacter.InteractionMode== UWCharacter.InteractionModeUse)
		{
			FailMessage();
			UWHUD.instance.CursorIcon= UWHUD.instance.CursorIconDefault;
			GameWorldController.instance.playerUW.playerInventory.ObjectInHand="";
			return true;
		}
		else
		{
			return false;
		}
	}

		/// <summary>
		/// The object is used by the player.
		/// </summary>
		/// Checks if the player is already holding something or using something else on this object.
	public virtual bool use()
	{
		//CheckReferences();
		if (GameWorldController.instance.playerUW.playerInventory.ObjectInHand =="")
		{
			if ((objInt().CanBeUsed==true) && (objInt().PickedUp==true))
			{
				BecomeObjectInHand();
				return true;
			}
			else
			{
				if(objInt().CanBeUsed==true)				
				{//Hope this does'nt mess up everything!
					if ((objInt().link != 0) && (objInt().isQuant()==false) && (objInt().enchantment==0))
					{//Not a quantity or an enchanted item.
						if (ObjectLoader.GetItemTypeAt(objInt().link) == ObjectInteraction.A_USE_TRIGGER)
						{
								ObjectLoader.getGameObjectAt(objInt().link).GetComponent<trigger_base>().Activate();	
						}	
					}
				}
				return false;
			}
		}
		else
		{
		return ActivateByObject(GameWorldController.instance.playerUW.playerInventory.GetGameObjectInHand());
		}
	}

	/// <summary>
	/// Checks the external references for this object
	/// </summary>
	/*protected void CheckReferences()
	{
		if (objInt==null)
		{
			objInt = this.gameObject.GetComponent<ObjectInteraction>();
		}
		if ((objInt!=null) && (ml==null))
		{
			ml=UWHUD.instance.MessageScroll;
		}
	}*/

		/// <summary>
		/// This object becomes the object in hand in order to be use
		/// </summary>
	public void BecomeObjectInHand()
	{//In order to use it.
		UWHUD.instance.CursorIcon= objInt().GetInventoryDisplay().texture;
		GameWorldController.instance.playerUW.playerInventory.ObjectInHand=this.name;
		UWCharacter.InteractionMode=UWCharacter.InteractionModeUse;
		InteractionModeControl.UpdateNow=true;
	}

		/// <summary>
		/// Player talks to the object.
		/// </summary>
		/// <returns><c>true</c>, if to was talked, <c>false</c> otherwise.</returns>
	public virtual bool TalkTo()
	{
		//000~001~156~You cannot talk to that.
		UWHUD.instance.MessageScroll.Add(StringController.instance.GetString (1,156));
		return true;
	}

	/// <summary>
	/// Player tries to eat this object.
	/// </summary>
	/// For when the player tries to eat certain objects by dragging them on top of the paper doll face. For future use?
	public virtual bool Eat()
	{
		return false;
	}

		/// <summary>
		/// For special events when an object is picked up. Eg silver seed or pickup traps
		/// </summary>
		/// If object has a pickup link then the object referenced is activated
	public virtual bool PickupEvent()
	{
		if ((objInt().link != 0) && (objInt().isQuant()==false) && (objInt().enchantment==0))
		{
			if (ObjectLoader.GetItemTypeAt(objInt().link) == ObjectInteraction.A_PICK_UP_TRIGGER)
			{
				ObjectLoader.getGameObjectAt(objInt().link).GetComponent<trigger_base>().Activate();	
			}
		}
		if(CanBeOwned())
		{
			if (((objInt().owner & 0x1f))!=0)
			{
				SignalTheft(GameWorldController.instance.playerUW.transform.position, objInt().owner);
				objInt().owner=0;
			}	
		}
	return false;
	}

	/// <summary>
	/// For special events when an object is dropped. Eg setting the map is_quant value back to zero
	/// </summary>
	/// <returns><c>true</c>, if event was droped, <c>false</c> otherwise.</returns>
	public virtual bool DropEvent()
	{
		return false;
	}

						/*
		if (PickupLink!="")
		{
			GameObject obj = GameObject.Find (PickupLink);
			if (obj!=null)
			{
				if (obj.GetComponent<trigger_base>()!=null)
				{
					obj.GetComponent<trigger_base>().Activate();
				}
			}
		}
		return false;*/



		/// <summary>
		/// Event when Item is put into inventory
		/// </summary>
		/// <returns><c>true</c>, if item away was put, <c>false</c> otherwise.</returns>
		/// <param name="slotNo">Slot no.</param>
		public virtual bool PutItemAwayEvent(short slotNo)
		{
				return false;
		}

		/// <summary>
		/// PLayer puts the object on in an inventory slot.
		/// </summary>
		/// <returns><c>true</c>, if event was equiped, <c>false</c> otherwise.</returns>
		/// <param name="slotNo">Slot no.</param>
	public virtual bool EquipEvent(short slotNo)
	{
		return false;
	}

	/// <summary>
	/// Player takes an object out of  an inventory slot.
	/// </summary>
	/// <returns><c>true</c>, if equip event was uned, <c>false</c> otherwise.</returns>
	/// <param name="slotNo">Slot no.</param>
	public virtual bool UnEquipEvent(short slotNo)
	{
		return false;
	}

		/// <summary>
		/// Failure message to display when this object is used on a another object that has no use for it. Eg a key on a sign.
		/// </summary>
		/// <returns><c>true</c>, if message was failed, <c>false</c> otherwise.</returns>
	public virtual bool FailMessage()
	{
		UWHUD.instance.MessageScroll.Add("You cannot use this. (Failmessage default)");
		return false;
	}

	/// <summary>
	/// Return the weight of the object stack
	/// </summary>
	/// <returns>The weight.</returns>
	public virtual float GetWeight()
	{
		if (objInt()==null)
		{
			return 0.0f;
		}
		else
		{

		return (float)(objInt().GetQty())* GameWorldController.instance.commonObject.properties[objInt().item_id].mass * 0.1f;// .Mass[objInt().item_id]*0.1f;
		//return (float)(objInt().GetQty())* GameWorldController.instance.commobj.Mass[objInt().item_id]*0.1f;
		}
	}

	/// <summary>
	/// Code to call when merging two objects. 
	/// To support cases where merging an object means the object becomes something different.
	/// Eg coin into stack of coins
	/// </summary>
	public virtual void MergeEvent()
	{

		return;
	}

	/// <summary>
	/// Another item Id this object could potentially have. Eg coin/gold coin. 
	/// By default it's normal item_id is returned
	/// </summary>
	/// <returns>The item identifier.</returns>
	public virtual int AliasItemId()
	{
		return objInt().item_id;
	}

	/// <summary>
	/// Code to call when spliting an item and the split changes the item fundamentally.
	/// </summary>
	public virtual void Split()
	{
		return;
	}


		/// <summary>
		/// Copies the object base.
		/// </summary>
		/// <param name="target">Target.</param>
		/// Possible use in room management when an object is stuck with DontDestroyOnLoan()
 // public virtual void CopyObject_base(GameObject target)
//	{
	//	object_base objBase=target.AddComponent<object_base>();
	//	objBase.PickupLink=PickupLink;
	//}

		/// <summary>
		/// Changes the type of the object. Eg when destroyed and it needs to become debris.
		/// </summary>
		/// <returns><c>true</c>, if type was changed, <c>false</c> otherwise.</returns>
		/// <param name="newID">New ID.</param>
		/// <param name="itemType">Item type.</param>
	public virtual bool ChangeType(int newID, int itemType)
	{
		objInt().ChangeType(newID,objInt().GetItemType());
		return true;		
	}


		/// <summary>
		/// Gets the identification Skill levels required for identifying the enchantment..
		/// </summary>
		/// <returns>The identification levels.</returns>
		/// <param name="EffectID">Effect ID to test</param>
	public int getIdentificationLevels(int EffectID)
	{
			//TODO:Decide on what to do about values. More powerful effects are harder to id?
			switch(EffectID)
			{
			case SpellEffect.UW1_Spell_Effect_Darkness:
			case SpellEffect.UW1_Spell_Effect_BurningMatch:
			case SpellEffect.UW1_Spell_Effect_Candlelight:
			case SpellEffect.UW1_Spell_Effect_Light:
			case SpellEffect.UW1_Spell_Effect_MagicLantern:
			case SpellEffect.UW1_Spell_Effect_NightVision:
			case SpellEffect.UW1_Spell_Effect_Daylight:
			case SpellEffect.UW1_Spell_Effect_Sunlight:
			case SpellEffect.UW1_Spell_Effect_Leap:
			case SpellEffect.UW1_Spell_Effect_SlowFall:
			case SpellEffect.UW1_Spell_Effect_Levitate:
			case SpellEffect.UW1_Spell_Effect_WaterWalk:
			case SpellEffect.UW1_Spell_Effect_Fly:
			case SpellEffect.UW1_Spell_Effect_ResistBlows:
			case SpellEffect.UW1_Spell_Effect_ThickSkin:
			case SpellEffect.UW1_Spell_Effect_IronFlesh:
			case SpellEffect.UW1_Spell_Effect_Curse:
			case SpellEffect.UW1_Spell_Effect_Stealth:
			case SpellEffect.UW1_Spell_Effect_Conceal:
			case SpellEffect.UW1_Spell_Effect_Invisibilty:
			case SpellEffect.UW1_Spell_Effect_MissileProtection:
			case SpellEffect.UW1_Spell_Effect_Flameproof:
			case SpellEffect.UW1_Spell_Effect_PoisonResistance:
			case SpellEffect.UW1_Spell_Effect_MagicProtection:
			case SpellEffect.UW1_Spell_Effect_GreaterMagicProtection:
			case SpellEffect.UW1_Spell_Effect_LesserHeal:
			case SpellEffect.UW1_Spell_Effect_LesserHeal_alt01:
			case SpellEffect.UW1_Spell_Effect_LesserHeal_alt02:
			case SpellEffect.UW1_Spell_Effect_LesserHeal_alt03:
			case SpellEffect.UW1_Spell_Effect_Heal:
			case SpellEffect.UW1_Spell_Effect_Heal_alt01:
			case SpellEffect.UW1_Spell_Effect_Heal_alt02:
			case SpellEffect.UW1_Spell_Effect_Heal_alt03:
			case SpellEffect.UW1_Spell_Effect_EnhancedHeal:
			case SpellEffect.UW1_Spell_Effect_EnhancedHeal_alt01:
			case SpellEffect.UW1_Spell_Effect_EnhancedHeal_alt02:
			case SpellEffect.UW1_Spell_Effect_EnhancedHeal_alt03:
			case SpellEffect.UW1_Spell_Effect_GreaterHeal:
			case SpellEffect.UW1_Spell_Effect_GreaterHeal_alt01:
			case SpellEffect.UW1_Spell_Effect_GreaterHeal_alt02:
			case SpellEffect.UW1_Spell_Effect_GreaterHeal_alt03:
			case SpellEffect.UW1_Spell_Effect_MagicArrow:
			case SpellEffect.UW1_Spell_Effect_ElectricalBolt:
			case SpellEffect.UW1_Spell_Effect_Fireball:
			case SpellEffect.UW1_Spell_Effect_Reveal:
			case SpellEffect.UW1_Spell_Effect_SheetLightning:
			case SpellEffect.UW1_Spell_Effect_Confusion:
			case SpellEffect.UW1_Spell_Effect_FlameWind:
			case SpellEffect.UW1_Spell_Effect_CauseFear:
			case SpellEffect.UW1_Spell_Effect_SmiteUndead:
			case SpellEffect.UW1_Spell_Effect_Ally:
			case SpellEffect.UW1_Spell_Effect_Poison:
			case SpellEffect.UW1_Spell_Effect_Paralyze:
			case SpellEffect.UW1_Spell_Effect_CreateFood:
			case SpellEffect.UW1_Spell_Effect_SetGuard:
			case SpellEffect.UW1_Spell_Effect_RuneofWarding:
			case SpellEffect.UW1_Spell_Effect_SummonMonster:
			case SpellEffect.UW1_Spell_Effect_Cursed:
			case SpellEffect.UW1_Spell_Effect_Cursed_alt01:
			case SpellEffect.UW1_Spell_Effect_Cursed_alt02:
			case SpellEffect.UW1_Spell_Effect_Cursed_alt03:
			case SpellEffect.UW1_Spell_Effect_Cursed_alt04:
			case SpellEffect.UW1_Spell_Effect_Cursed_alt05:
			case SpellEffect.UW1_Spell_Effect_Cursed_alt06:
			case SpellEffect.UW1_Spell_Effect_Cursed_alt07:
			case SpellEffect.UW1_Spell_Effect_Cursed_alt09:
			case SpellEffect.UW1_Spell_Effect_Cursed_alt10:
			case SpellEffect.UW1_Spell_Effect_Cursed_alt11:
			case SpellEffect.UW1_Spell_Effect_Cursed_alt12:
			case SpellEffect.UW1_Spell_Effect_Cursed_alt13:
			case SpellEffect.UW1_Spell_Effect_Cursed_alt14:
			case SpellEffect.UW1_Spell_Effect_Cursed_alt15:
			case SpellEffect.UW1_Spell_Effect_Cursed_alt16:
			case SpellEffect.UW1_Spell_Effect_IncreaseMana:
			case SpellEffect.UW1_Spell_Effect_IncreaseMana_alt01:
			case SpellEffect.UW1_Spell_Effect_IncreaseMana_alt02:
			case SpellEffect.UW1_Spell_Effect_IncreaseMana_alt03:
			case SpellEffect.UW1_Spell_Effect_ManaBoost:
			case SpellEffect.UW1_Spell_Effect_ManaBoost_alt01:
			case SpellEffect.UW1_Spell_Effect_ManaBoost_alt02:
			case SpellEffect.UW1_Spell_Effect_ManaBoost_alt03:
			case SpellEffect.UW1_Spell_Effect_RegainMana:
			case SpellEffect.UW1_Spell_Effect_RegainMana_alt01:
			case SpellEffect.UW1_Spell_Effect_RegainMana_alt02:
			case SpellEffect.UW1_Spell_Effect_RegainMana_alt03:
			case SpellEffect.UW1_Spell_Effect_RestoreMana:
			case SpellEffect.UW1_Spell_Effect_RestoreMana_alt01:
			case SpellEffect.UW1_Spell_Effect_RestoreMana_alt02:
			case SpellEffect.UW1_Spell_Effect_RestoreMana_alt03:
			case SpellEffect.UW1_Spell_Effect_Speed:
			case SpellEffect.UW1_Spell_Effect_DetectMonster:
			case SpellEffect.UW1_Spell_Effect_StrengthenDoor:
			case SpellEffect.UW1_Spell_Effect_RemoveTrap:
			case SpellEffect.UW1_Spell_Effect_NameEnchantment:
			case SpellEffect.UW1_Spell_Effect_Open:
			case SpellEffect.UW1_Spell_Effect_CurePoison:
			case SpellEffect.UW1_Spell_Effect_RoamingSight:
			case SpellEffect.UW1_Spell_Effect_Telekinesis:
			case SpellEffect.UW1_Spell_Effect_Tremor:
			case SpellEffect.UW1_Spell_Effect_GateTravel:
			case SpellEffect.UW1_Spell_Effect_FreezeTime:
			case SpellEffect.UW1_Spell_Effect_Armageddon:
			case SpellEffect.UW1_Spell_Effect_Regeneration:
			case SpellEffect.UW1_Spell_Effect_ManaRegeneration:
			case SpellEffect.UW1_Spell_Effect_theFrog:
			case SpellEffect.UW1_Spell_Effect_MazeNavigation:
			case SpellEffect.UW1_Spell_Effect_Hallucination:
			case SpellEffect.UW1_Spell_Effect_Light_alt01:
			case SpellEffect.UW1_Spell_Effect_ResistBlows_alt01:
			case SpellEffect.UW1_Spell_Effect_MagicArrow_alt01:
			case SpellEffect.UW1_Spell_Effect_CreateFood_alt01:
			case SpellEffect.UW1_Spell_Effect_Stealth_alt01:
			case SpellEffect.UW1_Spell_Effect_Leap_alt01:
			case SpellEffect.UW1_Spell_Effect_Curse_alt01:
			case SpellEffect.UW1_Spell_Effect_SlowFall_alt01:
			case SpellEffect.UW1_Spell_Effect_LesserHeal_alt04:
			case SpellEffect.UW1_Spell_Effect_DetectMonster_alt01:
			case SpellEffect.UW1_Spell_Effect_CauseFear_alt01:
			case SpellEffect.UW1_Spell_Effect_RuneofWarding_alt01:
			case SpellEffect.UW1_Spell_Effect_Speed_alt01:
			case SpellEffect.UW1_Spell_Effect_Conceal_alt01:
			case SpellEffect.UW1_Spell_Effect_NightVision_alt01:
			case SpellEffect.UW1_Spell_Effect_ElectricalBolt_alt01:
			case SpellEffect.UW1_Spell_Effect_StrengthenDoor_alt01:
			case SpellEffect.UW1_Spell_Effect_ThickSkin_alt01:
			case SpellEffect.UW1_Spell_Effect_WaterWalk_alt01:
			case SpellEffect.UW1_Spell_Effect_Heal_alt04:
			case SpellEffect.UW1_Spell_Effect_Levitate_alt01:
			case SpellEffect.UW1_Spell_Effect_Poison_alt01:
			case SpellEffect.UW1_Spell_Effect_Flameproof_alt01:
			case SpellEffect.UW1_Spell_Effect_RemoveTrap_alt01:
			case SpellEffect.UW1_Spell_Effect_Fireball_alt01:
			case SpellEffect.UW1_Spell_Effect_SmiteUndead_alt01:
			case SpellEffect.UW1_Spell_Effect_NameEnchantment_alt01:
			case SpellEffect.UW1_Spell_Effect_MissileProtection_alt01:
			case SpellEffect.UW1_Spell_Effect_Open_alt01:
			case SpellEffect.UW1_Spell_Effect_CurePoison_alt01:
			case SpellEffect.UW1_Spell_Effect_GreaterHeal_alt04:
			case SpellEffect.UW1_Spell_Effect_SheetLightning_alt01:
			case SpellEffect.UW1_Spell_Effect_GateTravel_alt01:
			case SpellEffect.UW1_Spell_Effect_Paralyze_alt01:
			case SpellEffect.UW1_Spell_Effect_Daylight_alt01:
			case SpellEffect.UW1_Spell_Effect_Telekinesis_alt01:
			case SpellEffect.UW1_Spell_Effect_Fly_alt01:
			case SpellEffect.UW1_Spell_Effect_Ally_alt01:
			case SpellEffect.UW1_Spell_Effect_SummonMonster_alt01:
			case SpellEffect.UW1_Spell_Effect_Invisibility_alt01:
			case SpellEffect.UW1_Spell_Effect_Confusion_alt01:
			case SpellEffect.UW1_Spell_Effect_Reveal_alt01:
			case SpellEffect.UW1_Spell_Effect_IronFlesh_alt01:
			case SpellEffect.UW1_Spell_Effect_Tremor_alt01:
			case SpellEffect.UW1_Spell_Effect_RoamingSight_alt01:
			case SpellEffect.UW1_Spell_Effect_FlameWind_alt01:
			case SpellEffect.UW1_Spell_Effect_FreezeTime_alt01:
			case SpellEffect.UW1_Spell_Effect_Armageddon_alt01:
			case SpellEffect.UW1_Spell_Effect_MassParalyze:
			case SpellEffect.UW1_Spell_Effect_Acid_alt01:
			case SpellEffect.UW1_Spell_Effect_LocalTeleport_alt01:
			case SpellEffect.UW1_Spell_Effect_ManaBoost_alt04:
			case SpellEffect.UW1_Spell_Effect_RestoreMana_alt04:
			case SpellEffect.UW1_Spell_Effect_Leap_alt02:
			case SpellEffect.UW1_Spell_Effect_SlowFall_alt02:
			case SpellEffect.UW1_Spell_Effect_Levitate_alt02:
			case SpellEffect.UW1_Spell_Effect_WaterWalk_alt02:
			case SpellEffect.UW1_Spell_Effect_Fly_alt02:
			case SpellEffect.UW1_Spell_Effect_Curse_alt02:
			case SpellEffect.UW1_Spell_Effect_Stealth_alt02:
			case SpellEffect.UW1_Spell_Effect_Conceal_alt02:
			case SpellEffect.UW1_Spell_Effect_Invisibility_alt02:
			case SpellEffect.UW1_Spell_Effect_MissileProtection_alt02:
			case SpellEffect.UW1_Spell_Effect_Flameproof_alt02:
			case SpellEffect.UW1_Spell_Effect_FreezeTime_alt02:
			case SpellEffect.UW1_Spell_Effect_RoamingSight_alt02:
			case SpellEffect.UW1_Spell_Effect_Haste:
			case SpellEffect.UW1_Spell_Effect_Telekinesis_alt02:
			case SpellEffect.UW1_Spell_Effect_ResistBlows_alt02:
			case SpellEffect.UW1_Spell_Effect_ThickSkin_alt02:
			case SpellEffect.UW1_Spell_Effect_Light_alt02:
			case SpellEffect.UW1_Spell_Effect_IronFlesh_alt02:
			case SpellEffect.UW1_Spell_Effect_NightVision_alt02:
			case SpellEffect.UW1_Spell_Effect_Daylight_alt02:
			case SpellEffect.UW1_Spell_Effect_MinorAccuracy:
			case SpellEffect.UW1_Spell_Effect_Accuracy:
			case SpellEffect.UW1_Spell_Effect_AdditionalAccuracy:
			case SpellEffect.UW1_Spell_Effect_MajorAccuracy:
			case SpellEffect.UW1_Spell_Effect_GreatAccuracy:
			case SpellEffect.UW1_Spell_Effect_VeryGreatAccuracy:
			case SpellEffect.UW1_Spell_Effect_TremendousAccuracy:
			case SpellEffect.UW1_Spell_Effect_UnsurpassedAccuracy:
			case SpellEffect.UW1_Spell_Effect_MinorDamage:
			case SpellEffect.UW1_Spell_Effect_Damage:
			case SpellEffect.UW1_Spell_Effect_AdditionalDamage:
			case SpellEffect.UW1_Spell_Effect_MajorDamage:
			case SpellEffect.UW1_Spell_Effect_GreatDamage:
			case SpellEffect.UW1_Spell_Effect_VeryGreatDamage:
			case SpellEffect.UW1_Spell_Effect_TremendousDamage:
			case SpellEffect.UW1_Spell_Effect_UnsurpassedDamage:
			case SpellEffect.UW1_Spell_Effect_MinorProtection:
			case SpellEffect.UW1_Spell_Effect_Protection:
			case SpellEffect.UW1_Spell_Effect_AdditionalProtection:
			case SpellEffect.UW1_Spell_Effect_MajorProtection:
			case SpellEffect.UW1_Spell_Effect_GreatProtection:
			case SpellEffect.UW1_Spell_Effect_VeryGreatProtection:
			case SpellEffect.UW1_Spell_Effect_TremendousProtection:
			case SpellEffect.UW1_Spell_Effect_UnsurpassedProtection:
			case SpellEffect.UW1_Spell_Effect_MinorToughness:
			case SpellEffect.UW1_Spell_Effect_Toughness:
			case SpellEffect.UW1_Spell_Effect_AdditionalToughness:
			case SpellEffect.UW1_Spell_Effect_MajorToughness:
			case SpellEffect.UW1_Spell_Effect_GreatToughness:
			case SpellEffect.UW1_Spell_Effect_VeryGreatToughness:
			case SpellEffect.UW1_Spell_Effect_TremendousToughness:
			case SpellEffect.UW1_Spell_Effect_UnsurpassedToughness:
			case SpellEffect.UW1_Spell_Effect_PoisonHidden:
						//return 10;
			default:
					//Debug.Log("EffectID" + EffectID + " unknownn");
				return Random.Range(1,31);//This is totally wrong!
			}			
	}

		/// <summary>
		/// Gets the sprite name that is displayed when the object is equipped in inventory
		/// </summary>
		/// <returns>The equip string.</returns>
	//	public virtual string getEquipString()
		//{
		//	return GameWorldController.instance.objectMaster.particle[objInt().item_id];
		//}

		public virtual Sprite GetEquipDisplay()
		{
			return objInt().GetInventoryDisplay();		
		}


		/// <summary>
		/// Gets the context menu text.
		/// </summary>
		public string GetContextMenuText(int item_id, bool isUseable, bool isPickable , bool ObjectInHand)
		{				
			ItemDesc= ContextMenuDesc(item_id);
			TalkAvail=false;
			if (isUseable)
			{
				UseableDesc = ContextMenuUsedDesc();//TODO:Controls
				UseAvail=true;
			}
			else
			{
				UseableDesc="";
				UseAvail=false;
			}
				if (ObjectInHand)
				{
					UseObjectOnDesc=ContextMenuUseObjectOn_World();
				}
				else
				{
					if (isPickable)
					{
							PickableDesc=ContextMenuUsedPickup();
							PickAvail=true;
					}
					else
					{
							PickableDesc="";
							PickAvail=false;
					}	
				}
				if((UWCharacter.InteractionMode==UWCharacter.InteractionModePickup) && (GameWorldController.instance.playerUW.playerInventory.ObjectInHand!=""))
				{//I'm actually throwing something.
						UseAvail=false;		
						UseableDesc="";
						PickableDesc="";
				}

				if (ObjectInHand)
				{
						if(UseAvail==true)
						{
								return ItemDesc + "\n" + UseObjectOnDesc;// + " " + UseObjectOnDesc;			
						}
						else
						{//I'm throwing an object.
								return ItemDesc;
						}
					
				}
				else
				{
					if ((UseableDesc!="") || (PickableDesc!=""))
					{
						return ItemDesc + "\n" + UseableDesc + " " + PickableDesc;		
					}
					else
					{
						return "";//no object description returned.
					}							
				}			
		}

		/// <summary>
		/// Item description for the context menu
		/// </summary>
		/// <returns>The menu desc.</returns>
		/// <param name="item_id">Item identifier.</param>
		public virtual string ContextMenuDesc(int item_id)
		{
			return StringController.instance.GetSimpleObjectNameUW(item_id);	
		}

		public virtual string ContextMenuUsedDesc()
		{
			return "L-Click to " + UseVerb();	
		}

		public virtual string ContextMenuUsedPickup()
		{
			return "R-Click to " + PickupVerb();	
		}

		public virtual string ContextMenuUseObjectOn_World()
		{
			return "L-Click to " + UseObjectOnVerb_World();
		}

		public virtual string ContextMenuUseObjectOn_Inv()
		{
			return "R-Click to " + UseObjectOnVerb_Inv();
		}

		public virtual string UseVerb()
		{
				return "use";
		}

		public virtual string PickupVerb()
		{
				return "pickup";
		}

		public virtual string ExamineVerb()
		{
				return "examine";
		}

		public virtual string UseObjectOnVerb_World()
		{
				return "use object on";
		}

		public virtual string UseObjectOnVerb_Inv()
		{
				return "swap/combine";	
		}


		public virtual Vector3 GetImpactPoint()
		{
			return this.gameObject.transform.position;
		}

		public virtual GameObject GetImpactGameObject()
		{
			return this.gameObject;
		}


		/// <summary>
		/// Requests a sprite from tmOBJ
		/// </summary>
		/// <returns><c>true</c>, if sprite was set, <c>false</c> otherwise.</returns>
		/// <param name="sprt">Sprt.</param>
		/// <param name="SpriteIndex">Sprite index.</param>
		public bool setSpriteTMOBJ(SpriteRenderer sprt, int SpriteIndex)
		{
				if (sprt==null)
				{
						return false;
				}
				if (SpriteIndex!=-1)
				{
					//sprt.sprite = Resources.Load <Sprite> (SpriteName);//Loads the sprite.;//Assigns the sprite to the object.
					sprt.sprite = GameWorldController.instance.TmObjArt.RequestSprite(SpriteIndex);
					//currentSpriteName=SpriteName;
					objInt().animationStarted=true;
					return true;
				}
				return false;
		}

		/// <summary>
		/// Sets a sprite from TMFLat
		/// </summary>
		/// <returns><c>true</c>, if sprite TMFLA was set, <c>false</c> otherwise.</returns>
		/// <param name="sprt">Sprt.</param>
		/// <param name="SpriteIndex">Sprite index.</param>
		public bool setSpriteTMFLAT(SpriteRenderer sprt, int SpriteIndex)
		{
			if (sprt==null)
			{
				return false;
			}
			if (SpriteIndex!=-1)
			{
				sprt.sprite = GameWorldController.instance.TmFlatArt.RequestSprite(SpriteIndex);
				objInt().animationStarted=true;
				return true;
			}
			return false;
		}



		/// <summary>
		/// Special event to occur when this item is in the inventory and is moved to another level
		/// </summary>
		public virtual void InventoryEventOnLevelEnter()
		{

		}

		/// <summary>
		/// Special event to occur when this item is in the inventory and is moved to another level
		/// </summary>
		/// Used mainly to update wands and their spell object links
		public virtual void InventoryEventOnLevelExit()
		{
				
		}

		/// <summary>
		/// Determines whether this object type can be picked up regardless of what is set in common object properties.
		/// </summary>
		/// <returns><c>true</c> if this instance can be picked up; otherwise, <c>false</c>.</returns>
		public virtual bool CanBePickedUp()
		{
			return false;
		}

		/// <summary>
		/// Returns if the item in question can be owned by an NPC
		/// </summary>
		/// <returns><c>true</c> if this instance can be owned; otherwise, <c>false</c>.</returns>
		public bool CanBeOwned()
		{
			return (GameWorldController.instance.commonObject.properties[objInt().item_id].CanBelongTo==1);	
		}

		/// <summary>
		/// String for displaying the ownership of the object in question.
		/// </summary>
		/// <returns>The string.</returns>
		public virtual string OwnershipString()
		{
			if (CanBeOwned())
			{
				if (((objInt().owner & 0x1f))!=0)
				{
					return " belonging to"	+ StringController.instance.GetString(1,370+(objInt().owner & 0x1f) );//This is what uw formats says. I think this is wrong...
				}
			}
				return "";
		}


		/// <summary>
		/// Signals the theft of this object to a specific race
		/// </summary>
		public static void SignalTheft(Vector3 position, int Owner)
		{
			foreach (Collider Col in Physics.OverlapSphere(position,4.0f))
			{
				if (Col.gameObject.GetComponent<NPC>() != null)
				{
					if ((Col.gameObject.GetComponent<NPC>().GetRace()==(Owner & 0x1f)))
					{										
						string OwnerName = StringController.instance.GetString(1,370+(Owner & 0x1f) );
										string reaction="";
						Col.gameObject.GetComponent<NPC>().npc_attitude--;//Make the npc angry with the player.
						if(Col.gameObject.GetComponent<NPC>().npc_attitude<=0)
						{
							Col.gameObject.GetComponent<NPC>().npc_attitude=0;
							Col.gameObject.GetComponent<NPC>().npc_gtarg=1;
							Col.gameObject.GetComponent<NPC>().gtarg=GameWorldController.instance.playerUW.gameObject;
							Col.gameObject.GetComponent<NPC>().gtargName=GameWorldController.instance.playerUW.gameObject.name;
							Col.gameObject.GetComponent<NPC>().npc_goal=5;	
							reaction = StringController.instance.GetString(1,225);
						}
						else
						{
							reaction = StringController.instance.GetString(1,226);
								//StringController.instance.GetString(1,370+(objInt().owner & 0x1f) )
						}
						UWHUD.instance.MessageScroll.Add(OwnerName.Trim() + reaction);
					}
				}
			}	
		}

}
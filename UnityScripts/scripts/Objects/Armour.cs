using UnityEngine;
using System.Collections;
/// <summary>
/// Armour.
/// </summary>
/// Wearable armour
/// Contains the string paths for the paperdoll graphics
public class Armour : Equipment {
	public int Protection;
	//public string ArmourEquipString;
		public int EquipIconIndex;
	/// ProtectionBonus of magic armour
	public int ProtectionBonus;
	/// Toughness Bonus for magic durability 
	public int ToughnessBonus;
	
	/// The image to display when worn.
	/// Takes the image from the Equip[Gender][Quality] strings
	//public Texture2D EquipDisplay;

	/// Permanent spell effect applied by the spell
	public SpellEffect SpellEffectApplied;

	/// <summary>
	/// Gets the effectID index of the spell that this item is enchanted with
	/// </summary>
	/// <returns>The actual spell index.</returns>
	public override int GetActualSpellIndex ()
	{
		return objInt().link-256+16;
	}

	protected override void Start () {
		base.Start ();
		UpdateQuality();
	}

	/// <summary>
	/// Damage caused to the weapon when it hits something with heavy resistance.
	/// </summary>
	public virtual void ArmourSelfDamage()
	{
		objInt().quality-=1;
		UpdateQuality();
		if (objInt().quality<=0)
		{
			ChangeType(208,23);//Change to debris.
			this.gameObject.AddComponent<object_base>();//Add a generic object base for behaviour
			Destroy(this);//Kill me now.
		}
	}
	
	public override void UpdateQuality ()
	{
				int itemIndex= objInt().item_id-32;
						
				if ((itemIndex<15))
				{//Armor pieces
						if ((objInt().quality>0) && (objInt().quality<=15))
						{
								//Shit quality
								EquipIconIndex=  itemIndex;
						}
						else if ((objInt().quality>15) && (objInt().quality<=30))
						{//bashed about
								EquipIconIndex=  itemIndex + (1*15);
						}
						else if ((objInt().quality>30) && (objInt().quality<=45))
						{//medium
								EquipIconIndex=  itemIndex + (2*15);
						}
						else
						{//best
								EquipIconIndex=  itemIndex + (3*15);
						}

				}
				else
				{//Crowns and dragonskin boots
						EquipIconIndex= 60+ (objInt().item_id-47);
				}
	}
		/*

	public override void UpdateQuality1()
	{	//Needs to be called when damaged.
		if ((objInt().quality>0) && (objInt().quality<=15))
		{
			if (GameWorldController.instance.playerUW.isFemale)
			{
				SetEquipTexture(GameWorldController.instance.objectMaster.EquippedIconFemaleLowestQuality[objInt().item_id]);
			}
			else
			{
				SetEquipTexture(GameWorldController.instance.objectMaster.EquippedIconMaleLowestQuality[objInt().item_id]);
			}
		}
		else if ((objInt().quality>15) && (objInt().quality<=30))
		{
			//Low quality
			if (GameWorldController.instance.playerUW.isFemale)
			{
						SetEquipTexture(GameWorldController.instance.objectMaster.EquippedIconFemaleLowQuality[objInt()	.item_id]);
			}
			else
			{
				SetEquipTexture(GameWorldController.instance.objectMaster.EquippedIconMaleLowQuality[objInt().item_id]);
			}
		}
		else if ((objInt().quality>30) && (objInt().quality<=45))
		{
			//Medium
			if (GameWorldController.instance.playerUW.isFemale)
			{
					SetEquipTexture(GameWorldController.instance.objectMaster.EquippedIconFemaleMediumQuality[objInt().item_id]);
			}
			else
			{
					SetEquipTexture(GameWorldController.instance.objectMaster.EquippedIconMaleMediumQuality[objInt().item_id]);
			}
		}
		else if ((objInt().quality>45) && (objInt().quality<=63))
		{
			//Best
			if (GameWorldController.instance.playerUW.isFemale)
			{
				SetEquipTexture(GameWorldController.instance.objectMaster.EquippedIconFemaleBestQuality[objInt().item_id]);
			}
			else
			{
				SetEquipTexture(GameWorldController.instance.objectMaster.EquippedIconMaleBestQuality[objInt().item_id]);
			}
		}
	//objInt().SetEquipDisplay(Sprite.Create(EquipDisplay,new Rect(0,0,EquipDisplay.width,EquipDisplay.height), new Vector2(0.5f, 0.5f)));
	}
	*/
		/*
	/// <summary>
	/// Sets the equip texture.
	/// </summary>
	/// <param name="EquipTexture">Equip texture.</param>
	void SetEquipTexture(string EquipTexture)
	{//Change the paperdoll image
		//EquipDisplay = Resources.Load <Texture2D> (EquipTexture);
		//objInt().EquipString=EquipTexture;
		ArmourEquipString=EquipTexture;
		GameWorldController.instance.playerUW.playerInventory.Refresh(objInt().inventorySlot);
	}
		*/

	//public override string getEquipString ()
	//{
	//	return ArmourEquipString;
	//}

	public override Sprite GetEquipDisplay ()
	{
		//return ObjectInteraction.tc.RequestSprite(ArmourEquipString);
		if(GameWorldController.instance.playerUW.isFemale)
		{
			return GameWorldController.instance.armor_f.RequestSprite(EquipIconIndex);				
		}
		else
		{
			return GameWorldController.instance.armor_m.RequestSprite(EquipIconIndex);
		}
		
	}

	public override bool EquipEvent (int slotNo)
	{
		if ((slotNo >=0) && (slotNo <=4))//Gloves, chest,legging,boots and helm
		{
			UpdateQuality();
			if (objInt().isEnchanted()==true)
			{
				int EffectId=GetActualSpellIndex ();
				switch (EffectId)
				{
				case SpellEffect.UW1_Spell_Effect_MinorProtection:
				case SpellEffect.UW1_Spell_Effect_Protection:
				case SpellEffect.UW1_Spell_Effect_AdditionalProtection:
				case SpellEffect.UW1_Spell_Effect_MajorProtection:
				case SpellEffect.UW1_Spell_Effect_GreatProtection:
				case SpellEffect.UW1_Spell_Effect_VeryGreatProtection:
				case SpellEffect.UW1_Spell_Effect_TremendousProtection:
				case SpellEffect.UW1_Spell_Effect_UnsurpassedProtection:
					ProtectionBonus=EffectId-463;
					break;
				case SpellEffect.UW1_Spell_Effect_MinorToughness:
				case SpellEffect.UW1_Spell_Effect_Toughness:
				case SpellEffect.UW1_Spell_Effect_AdditionalToughness:
				case SpellEffect.UW1_Spell_Effect_MajorToughness:
				case SpellEffect.UW1_Spell_Effect_GreatToughness:
				case SpellEffect.UW1_Spell_Effect_VeryGreatToughness:
				case SpellEffect.UW1_Spell_Effect_TremendousToughness:
				case SpellEffect.UW1_Spell_Effect_UnsurpassedToughness:
					ToughnessBonus=EffectId-471;
					break;

				default:
					//cast enchantment.
					SpellEffectApplied = GameWorldController.instance.playerUW.PlayerMagic.CastEnchantment(GameWorldController.instance.playerUW.gameObject,null,GetActualSpellIndex(),Magic.SpellRule_TargetSelf);
					if (SpellEffectApplied!=null)
					{
						SpellEffectApplied.SetPermanent(true);
					}
					break;
				}
			}
		}
		return true;
	}
	
	public override bool UnEquipEvent (int slotNo)
	{
		if ((slotNo >=0) && (slotNo <=4))
		{
			if (SpellEffectApplied!=null)
			{
				SpellEffectApplied.CancelEffect();
				return true;
			}
		}
		return false;
	}

		/// <summary>
		/// Gets the defence score of this armour.
		/// </summary>
		/// <returns>The defence.</returns>
		public int getDefence()
		{
			return GameWorldController.instance.objDat.armourStats[objInt().item_id-32].protection;
		}
}
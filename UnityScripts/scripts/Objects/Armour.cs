using UnityEngine;
using System.Collections;
/// <summary>
/// Armour.
/// </summary>
/// Wearable armour
/// Contains the string paths for the paperdoll graphics
public class Armour : Equipment {
	//public int Protection;
	//public string ArmourEquipString;
	
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
		int index =objInt().link-256+16;
		if (_RES==GAME_UW2)
		{
			if ((index >=325) && (index<=326))
			{
				return index+69;				
			}					
		}		
		return index;
	}

	//protected override void Start () {
	//	base.Start ();
	//	UpdateQuality();
	//}
	
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

	public override Sprite GetEquipDisplay ()
	{
		//return ObjectInteraction.tc.RequestSprite(ArmourEquipString);
		if(UWCharacter.Instance.isFemale)
		{
			return GameWorldController.instance.armor_f.RequestSprite(EquipIconIndex);				
		}
		else
		{
			return GameWorldController.instance.armor_m.RequestSprite(EquipIconIndex);
		}
		
	}

	public override bool EquipEvent (short slotNo)
	{
		if ((slotNo >=0) && (slotNo <=4))//Gloves, chest,legging,boots and helm
		{
			UpdateQuality();
			if ((objInt().isEnchanted()==true) || ((_RES==GAME_UW1) && (objInt().item_id==47)))
			{//Is magic or the dragonskin boots
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
					//ProtectionBonus=(short)(EffectId-463);
					break;
				case SpellEffect.UW1_Spell_Effect_MinorToughness:
				case SpellEffect.UW1_Spell_Effect_Toughness:
				case SpellEffect.UW1_Spell_Effect_AdditionalToughness:
				case SpellEffect.UW1_Spell_Effect_MajorToughness:
				case SpellEffect.UW1_Spell_Effect_GreatToughness:
				case SpellEffect.UW1_Spell_Effect_VeryGreatToughness:
				case SpellEffect.UW1_Spell_Effect_TremendousToughness:
				case SpellEffect.UW1_Spell_Effect_UnsurpassedToughness:
					//ToughnessBonus=(short)(EffectId-471);
					break;

				default:
					//cast enchantment.
					SpellEffectApplied = UWCharacter.Instance.PlayerMagic.CastEnchantment(UWCharacter.Instance.gameObject,null,GetActualSpellIndex(),Magic.SpellRule_TargetSelf,Magic.SpellRule_Equipable);
					if (SpellEffectApplied!=null)
					{
						SpellEffectApplied.SetPermanent(true);
					}
					else
					{
						Debug.Log(this.name +  " was unable to apply effect. " + GetActualSpellIndex());
					}
					break;
				}
			}
		}
		return true;
	}
	
	public override bool UnEquipEvent (short slotNo)
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

	public override short getDurability ()
	{
		return (short)(GameWorldController.instance.objDat.armourStats[objInt().item_id-32].durability+ DurabilityBonus());	
	}


	public override short getDefence()
	{
		return (short)(GameWorldController.instance.objDat.armourStats[objInt().item_id-32].protection+ProtectionBonus());
	}

}
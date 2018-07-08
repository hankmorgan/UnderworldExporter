using UnityEngine;
using System.Collections;
/// <summary>
/// Base class for enchantments.
/// </summary>
///  If the enchantment flag is set and the object is enchantable, then the
///  link field (less 512) determines the enchantment. Enchantment names are
///  stored in strings chunk 5. The way in which the link value maps onto
///  spells in this chunk depends on the object type.
///  
///  Most objects seem to use spells 256-320 (add 256) if the enchantment
///  number is in the range 0-63, otherwise they add 144 to use spells 208 and
///  up. Healing fountains, however, don't use a correction at all.
///  
///  Weapons and armour have a more complex mapping. Most enchanted weapons and
///  pieces of armour have an enhancement for Accuracy, Damage, Protection or
///  			Toughness, which are spells 448-479 in the main spell list. These map to
///  			special property values 192-207. Yes, there are only 16 values for 32
///  					spells; enchanted armour adds another 16 to the spell index to bring it
///  into the armour enchantment range. However, these items may also carry
///  generic enchantments, in which case the special properties map to spells
///  0-255 (and armour doesn't apply a special correction).
///  
///  Wands don't hold their enchantments directly in the quantity field, since
///  they also need to store the number of charges remaining. Instead, they
///  link to a spell object which holds the enchantment; it seems here that
///  		the "quality" field of the spell object determines the number of charges.
///  Other objects may also carry spells in this way.
/// 
public class enchantment_base : object_base {
	[Header("Enchantment Properties")]
	public string DisplayEnchantment;
	public int SpellIndex;

	protected override void Start ()
	{
		base.Start();
		SetDisplayEnchantment ();
		SpellIndex = GetActualSpellIndex();
	}

	public void SetDisplayEnchantment ()
	{
		DisplayEnchantment = StringController.instance.GetString (6, GetActualSpellIndex ());
		if (DisplayEnchantment == "") 
		{
			DisplayEnchantment = "NONE";
		}
	}

	public override bool use ()
	{
		if (UWCharacter.Instance.playerInventory.ObjectInHand=="")
		{
			UWCharacter.Instance.PlayerMagic.CastEnchantment(UWCharacter.Instance.gameObject,null,GetActualSpellIndex(),Magic.SpellRule_TargetSelf,Magic.SpellRule_Equipable);
			return true;
		}
		else
		{
			return ActivateByObject(UWCharacter.Instance.playerInventory.GetGameObjectInHand());
		}	
	}


	/// <summary>
	/// Gets the actual spell index of the spell.
	/// </summary>
	/// <returns>The actual spell index.</returns>
	protected virtual int GetActualSpellIndex()
	{
		//Calculated the effect id of the enchantment. As in the above notes from UWformats.txt
		int index=objInt().link-512;
		if ( objInt().GetItemType() != ObjectInteraction.RING)
		{
			if (index<63)
			{
				return index+256;
			}
			else
			{
				return index+144;
			}		
		}
		else 
		{
			return index;
		}
	}


	public override bool LookAt ()
	{//Look descriptions for different enchantable objects.
		//string desc;
		if (objInt().PickedUp==false)
		{
			return base.LookAt();
		}
		switch (objInt().item_id)
		{	
		case 54: //Ring of humility
						UWHUD.instance.MessageScroll.Add (StringController.instance.GetFormattedObjectNameUW(objInt()));
			break;
		case 184 :// a_mushroom
		case 185 :// a_toadstool
		case 186 :// a_bottle_of_ale_bottles_of_ale
			//No enchantment revealed
						UWHUD.instance.MessageScroll.Add (StringController.instance.GetFormattedObjectNameUW(objInt()));
			break;
		case 316 :// a_scroll
		case 317 :
		case 318 :
		case 319 :
		case 187 :// a_red_potion
		case 188 :// a_green_potion
		default:
			string enchantmentname=StringController.instance.GetString(6,GetActualSpellIndex());
			switch(objInt().identity())
			{
			case ObjectInteraction.IdentificationFlags.Identified:
					if (enchantmentname=="")
					{
						enchantmentname = "UNNAMED";
					}
					DisplayEnchantment = enchantmentname;
					UWHUD.instance.MessageScroll.Add (StringController.instance.GetFormattedObjectNameUW(objInt()) + " of " + enchantmentname);					
				
					break;
			case ObjectInteraction.IdentificationFlags.Unidentified:
			case ObjectInteraction.IdentificationFlags.PartiallyIdentified:
					if (UWCharacter.Instance.PlayerSkills.TrySkill(Skills.SkillLore, getIdentificationLevels(GetActualSpellIndex())))
					{
						objInt().heading=7;
						if (enchantmentname!="")
						{
							UWHUD.instance.MessageScroll.Add (StringController.instance.GetFormattedObjectNameUW(objInt()) + " of " + enchantmentname);										
						}
						else
						{
							UWHUD.instance.MessageScroll.Add (StringController.instance.GetFormattedObjectNameUW(objInt()))	;								
						}
						
					}
					else
					{
						UWHUD.instance.MessageScroll.Add (StringController.instance.GetFormattedObjectNameUW(objInt()));		
					}					
					break;
			}				
			break;			
		}
		return true;
	}


	public override string ContextMenuDesc (int item_id)
	{
		switch (objInt().identity())
		{
		case ObjectInteraction.IdentificationFlags.Identified:
			return StringController.instance.GetFormattedObjectNameUW(objInt()) + " of " + DisplayEnchantment;					
		default:
			return base.ContextMenuDesc (item_id);
		}		
	}

	public override float GetWeight ()
	{
		return (float)(GameWorldController.instance.commonObject.properties[objInt().item_id].mass * 0.1f);
	}

}
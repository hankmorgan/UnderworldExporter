using UnityEngine;
using System.Collections;

public class enchantment_base : object_base {
		/*
		 * 
		 * enchantments.cs Base class for enchantments.
		 * 
		 * /
	
	/*
 4.2.1  Enchantments

   If the enchantment flag is set and the object is enchantable, then the
   link field (less 512) determines the enchantment. Enchantment names are
   stored in strings chunk 5. The way in which the link value maps onto
   spells in this chunk depends on the object type.

   Most objects seem to use spells 256-320 (add 256) if the enchantment
   number is in the range 0-63, otherwise they add 144 to use spells 208 and
   up. Healing fountains, however, don't use a correction at all.

   Weapons and armour have a more complex mapping. Most enchanted weapons and
   pieces of armour have an enhancement for Accuracy, Damage, Protection or
   Toughness, which are spells 448-479 in the main spell list. These map to
   special property values 192-207. Yes, there are only 16 values for 32
   spells; enchanted armour adds another 16 to the spell index to bring it
   into the armour enchantment range. However, these items may also carry
   generic enchantments, in which case the special properties map to spells
   0-255 (and armour doesn't apply a special correction).

   Wands don't hold their enchantments directly in the quantity field, since
   they also need to store the number of charges remaining. Instead, they
   link to a spell object which holds the enchantment; it seems here that
   the "quality" field of the spell object determines the number of charges.
   Other objects may also carry spells in this way.
*/

	protected virtual int GetActualSpellIndex()
	{
		//Calculated the effect id of the enchantment. As in the above notes from UWformats.txt
		
		int index=objInt.Link-512;
		if ( objInt.ItemType != ObjectInteraction.RING)
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
		string desc;
		
		switch (objInt.item_id)
		{	
		case 54: //Ring of humility
			ml.Add (playerUW.StringControl.GetFormattedObjectNameUW(objInt));
			break;
		case 184 :// a_mushroom
		case 185 :// a_toadstool
		case 186 :// a_bottle_of_ale_bottles_of_ale
			//No enchantment revealed
			ml.Add (playerUW.StringControl.GetFormattedObjectNameUW(objInt));
			break;
		case 316 :// a_scroll
		case 317 :
		case 318 :
		case 319 :
		case 187 :// a_red_potion
		case 188 :// a_green_potion
		default:
			ml.Add (playerUW.StringControl.GetFormattedObjectNameUW(objInt) + " of " + playerUW.StringControl.GetString(6,GetActualSpellIndex()));
			break;			
		}
		return true;
	}
}

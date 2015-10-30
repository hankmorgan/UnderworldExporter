using UnityEngine;
using System.Collections;

public class Potion : object_base {
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

	private int GetActualSpellIndex()
	{
		int index=objInt.Link-512;
		if (index<63)
		{
			return index+256;
		}
		else
		{
			return index+144;
		}

	}

	public override bool use ()
	{
		int index = GetActualSpellIndex();
		playerUW.PlayerMagic.CastEnchantment(playerUW.gameObject,index );
		ml.text=playerUW.StringControl.GetString (1,240);
		objInt.consumeObject();
		return true;
	}

	public override bool LookAt ()
	{
		/*return base.LookAt ();*/
		ml.text=playerUW.StringControl.GetFormattedObjectNameUW(objInt) + " of " + playerUW.StringControl.GetString(6,GetActualSpellIndex());
		return true;
	}


}

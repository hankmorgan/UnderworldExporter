using UnityEngine;
using System.Collections;

public class Wand : enchantment_base {
	public int SpellObjectLink;
	public int SpellObjectQuantity;

	protected override int GetActualSpellIndex ()
	{
		return SpellObjectLink-256;
	}


	public override bool use ()
	{
		if (playerUW.playerInventory.ObjectInHand=="")
		{
			if (SpellObjectQuantity >0)
			{
				playerUW.PlayerMagic.CastEnchantment(playerUW.gameObject,GetActualSpellIndex() );
				SpellObjectQuantity--;
				if (SpellObjectQuantity ==0)
				{
					objInt.item_id = objInt.item_id+4;//Become a broken wand.
					objInt.InvDisplayIndex=objInt.InvDisplayIndex+4;
					objInt.WorldDisplayIndex=objInt.WorldDisplayIndex+4;
					objInt.RefreshAnim();
				}
			}
			return true;
		}
		else
		{
			return ActivateByObject(playerUW.playerInventory.GetGameObjectInHand());
		}		
	}


	public override bool LookAt ()
	{
		if (SpellObjectQuantity>0)
		{
			ml.Add (playerUW.StringControl.GetFormattedObjectNameUW(objInt) 
				+ " of " 
				+ playerUW.StringControl.GetString(6,GetActualSpellIndex())
				+ " with "
				+ SpellObjectQuantity 
				+ " charges remaining.");
		}
		else
		{
			ml.Add (playerUW.StringControl.GetFormattedObjectNameUW(objInt));
		}
		return true;
	}


}

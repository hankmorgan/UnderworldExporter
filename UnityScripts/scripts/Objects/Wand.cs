using UnityEngine;
using System.Collections;

public class Wand : enchantment_base {
	public int SpellObjectLink;
	public int SpellObjectQuantity;

	protected override int GetActualSpellIndex ()
	{
		if (objInt.isEnchanted==true)
		{
			/* Per uwspecs
				 * Most objects seem to use spells 256-320 (add 256) if the enchantment
   				 * number is in the range 0-63, otherwise they add 144 to use spells 208 and
   				 * up. Healing fountains, however, don't use a correction at all.
				 */
			if (objInt.Link-512<63)
			{
				return objInt.Link-512+256;
			}
			else
			{
				return objInt.Link-512+144;
			}

		}
		else
		{
			return SpellObjectLink-256;
		}
	}


	public override bool use ()
	{
		if (playerUW.playerInventory.ObjectInHand=="")
		{
			if (SpellObjectQuantity >0)
				{
					playerUW.PlayerMagic.CastEnchantment(playerUW.gameObject,null,GetActualSpellIndex(),Magic.SpellRule_TargetSelf );
					if (objInt.isEnchanted==false)
						{
						SpellObjectQuantity--;
						if (SpellObjectQuantity ==0)
						{
							objInt.item_id = objInt.item_id+4;//Become a broken wand.
							objInt.InvDisplayIndex=objInt.InvDisplayIndex+4;
							objInt.WorldDisplayIndex=objInt.WorldDisplayIndex+4;
							objInt.RefreshAnim();
						}
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
	string FormattedName="";
	
		if (objInt.isIdentified==true)
			{
				FormattedName=playerUW.StringControl.GetFormattedObjectNameUW(objInt) + " of " + playerUW.StringControl.GetString(6,GetActualSpellIndex());
			}
		else
			{
				if (playerUW.PlayerSkills.TrySkill(Skills.SkillLore, getIdentificationLevels(GetActualSpellIndex())))
				{
					objInt.isIdentified=true;
					FormattedName=playerUW.StringControl.GetFormattedObjectNameUW(objInt) + " of " + playerUW.StringControl.GetString(6,GetActualSpellIndex());
				}
				else
				{
					FormattedName=playerUW.StringControl.GetFormattedObjectNameUW(objInt);		
				}					
			}
	
		if ((SpellObjectQuantity>0) && (objInt.isEnchanted==false) && (objInt.isIdentified))
		{
			ml.Add (FormattedName
				+ " with "
				+ SpellObjectQuantity 
				+ " charges remaining.");
		}
		else
		{
			//ml.Add (playerUW.StringControl.GetFormattedObjectNameUW(objInt));
			ml.Add(FormattedName);
		}
		return true;
	}


}

using UnityEngine;
using System.Collections;

public class Wand : enchantment_base {
	private int SpellObjectLink;
	private int SpellObjectQuantity;

	protected override void Start ()
	{
		base.Start ();
		if (ObjectLoader.getObjectIntAt(objInt().link)!=null)
		{
			SpellObjectLink=ObjectLoader.getObjectIntAt(objInt().link).link;
			SpellObjectQuantity=ObjectLoader.getObjectIntAt(objInt().link).quality;
		}				 
	}

	protected override int GetActualSpellIndex ()
	{
		if (objInt().isEnchanted==true)
		{
			/* Per uwspecs
				 * Most objects seem to use spells 256-320 (add 256) if the enchantment
   				 * number is in the range 0-63, otherwise they add 144 to use spells 208 and
   				 * up. Healing fountains, however, don't use a correction at all.
				 */
			if (objInt().Link-512<63)
			{
				return objInt().Link-512+256;
			}
			else
			{
				return objInt().Link-512+144;
			}

		}
		else
		{
			return SpellObjectLink-256;
		}
	}


	public override bool use ()
	{
		if (GameWorldController.instance.playerUW.playerInventory.ObjectInHand=="")
		{
			if (SpellObjectQuantity >0)
				{
					GameWorldController.instance.playerUW.PlayerMagic.CastEnchantment(GameWorldController.instance.playerUW.gameObject,null,GetActualSpellIndex(),Magic.SpellRule_TargetSelf );
					if (objInt().isEnchanted==false)
						{
						SpellObjectQuantity--;
						if (SpellObjectQuantity ==0)
						{
							objInt().item_id = objInt().item_id+4;//Become a broken wand.
							objInt().InvDisplayIndex=objInt().InvDisplayIndex+4;
							objInt().WorldDisplayIndex=objInt().WorldDisplayIndex+4;
							objInt().RefreshAnim();
						}
					}
				}
			return true;
		}
		else
		{
			return ActivateByObject(GameWorldController.instance.playerUW.playerInventory.GetGameObjectInHand());
		}		
	}


	public override bool LookAt ()
	{
	string FormattedName="";
	
		if (objInt().isIdentified==true)
			{
				FormattedName=StringController.instance.GetFormattedObjectNameUW(objInt()) + " of " + StringController.instance.GetString(6,GetActualSpellIndex());
			}
		else
			{
				if (GameWorldController.instance.playerUW.PlayerSkills.TrySkill(Skills.SkillLore, getIdentificationLevels(GetActualSpellIndex())))
				{
					objInt().isIdentified=true;
					FormattedName=StringController.instance.GetFormattedObjectNameUW(objInt()) + " of " + StringController.instance.GetString(6,GetActualSpellIndex());
				}
				else
				{
					FormattedName=StringController.instance.GetFormattedObjectNameUW(objInt());		
				}					
			}
	
		if ((SpellObjectQuantity>0) && (objInt().isEnchanted==false) && (objInt().isIdentified))
		{
			UWHUD.instance.MessageScroll.Add (FormattedName
				+ " with "
				+ SpellObjectQuantity 
				+ " charges remaining.");
		}
		else
		{
			//UWHUD.instance.MessageScroll.Add (StringController.instance.GetFormattedObjectNameUW(objInt()));
			UWHUD.instance.MessageScroll.Add(FormattedName);
		}
		return true;
	}


}

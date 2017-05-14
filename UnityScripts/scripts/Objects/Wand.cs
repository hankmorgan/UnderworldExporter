using UnityEngine;
using System.Collections;

public class Wand : enchantment_base {
	private int SpellObjectLink;
	//private int SpellObjectQuantity;
	private int SpellObjectQualityToCreate=0;//To persist the spell trap between levels.
	private int SpellObjectOwnerToCreate=0;
	//private int SpellObjectLinkToCreate=0;

	protected override void Start ()
	{
		base.Start ();
		if (ObjectLoader.getObjectIntAt(objInt().link)!=null)
		{
			SpellObjectLink=ObjectLoader.getObjectIntAt(objInt().link).link;
			//SpellObjectQuantity=ObjectLoader.getObjectIntAt(objInt().link).quality;
		}				 
	}
	
	/// <summary>
	/// Gets the actual spell index of the spell.
	/// </summary>
	/// <returns>The actual spell index.</returns>
	/// Wands use link to a spell object to get their spell
		/// 
		/// 						
		/* Per uwspecs
		* Most objects seem to use spells 256-320 (add 256) if the enchantment
		* number is in the range 0-63, otherwise they add 144 to use spells 208 and
		* up. Healing fountains, however, don't use a correction at all.
		*/
	protected override int GetActualSpellIndex ()
	{
		if (objInt().isEnchanted()==true)
		{
			if (objInt().link-512<63)
			{
					return objInt().link-512+256;
			}
			else
			{
					return objInt().link-512+144;
			}
		}
		else
		{
			return SpellObjectLink-256;
		}
	}
				

//}


	public override bool use ()
	{
		if (GameWorldController.instance.playerUW.playerInventory.ObjectInHand=="")
		{
			if (objInt().quality >0)
				{
					GameWorldController.instance.playerUW.PlayerMagic.CastEnchantment(GameWorldController.instance.playerUW.gameObject,null,GetActualSpellIndex(),Magic.SpellRule_TargetSelf );
					if (objInt().isEnchanted()==false)
						{
						objInt().quality--;
						if ((objInt().quality ==0) && ((objInt().item_id>=152) || (objInt().item_id<=155)))
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
	
		if ((objInt().quality>0) && (objInt().isEnchanted()==false) && (objInt().isIdentified))
		{
			UWHUD.instance.MessageScroll.Add (FormattedName
				+ " with "
				+ objInt().quality 
				+ " charges remaining.");
		}
		else
		{
			//UWHUD.instance.MessageScroll.Add (StringController.instance.GetFormattedObjectNameUW(objInt()));
			UWHUD.instance.MessageScroll.Add(FormattedName);
		}
		return true;
	}


	/// <summary>
	/// Creates a new spell trap in the object list
	/// </summary>
	public override void InventoryEventOnLevelEnter ()
		{
		base.InventoryEventOnLevelEnter ();
			//Create a spell trap and store it on the map. This occurs before the list is rendered.
		ObjectLoaderInfo newobj= ObjectLoader.newObject(390,SpellObjectQualityToCreate,SpellObjectOwnerToCreate, SpellObjectLink );
		//ObjectInteraction.CreateNewObject(GameWorldController.instance.currentTileMap(), newobj,GameWorldController.instance.LevelMarker().gameObject,new Vector3(99f*1.2f,0,99f*1.2f));
		objInt().link = newobj.index;
		}


	public override void InventoryEventOnLevelExit ()
		{
		//Store the spell properties so I can create it in the next level. 
		base.InventoryEventOnLevelExit ();
		GameObject linked = ObjectLoader.getGameObjectAt(objInt().link);
			if (linked!=null)
			{
				a_spell spell = linked.GetComponent<a_spell>();
						if (spell!=null)
				{		
					SpellObjectOwnerToCreate = spell.objInt().owner;	
					SpellObjectQualityToCreate = spell.objInt().quality;
					//SpellObjectLinkToCreate=spell.objInt().link;
					//Flag the spell trap as not being in use and change it's type to a fist so it will not persist.
					//Assumes spell traps are all stored off map
					spell.objInt().objectloaderinfo.InUseFlag=0;
					spell.objInt().objectloaderinfo.item_id=0;
				}
			}
			//SpellObjectOwnerToCreate 
		}

}

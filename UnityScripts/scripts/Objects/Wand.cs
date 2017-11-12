using UnityEngine;
using System.Collections;

public class Wand : enchantment_base {
	public int SpellObjectLink;
	public int SpellObjectQualityToCreate=0;//To persist the spell trap between levels.
	public int SpellObjectOwnerToCreate=0;

	protected override void Start ()
	{
		base.Start ();
		if (_RES==GAME_UW2)				
		{
			if (SpellObjectOwnerToCreate==-1)
			{//This is  wand with infinite charges. Does not use a spell object for it's enchantment.
				//Debug.Log("linking wand " + this.name + " to an existing spell");
				//SpellObjectLink = ObjectLoader.getObjectIntAt(objInt().link).link;
			}
			else
			{
				if(objInt().PickedUp)		
				{//A wand and spell in the inventory loaded from a playerdat file. Need to create it's spell object now
					ObjectLoaderInfo newobjt= ObjectLoader.newObject(288, SpellObjectQualityToCreate,SpellObjectOwnerToCreate, SpellObjectLink,256);
					ObjectInteraction spell = ObjectInteraction.CreateNewObject(GameWorldController.instance.currentTileMap(),newobjt,  GameWorldController.instance.LevelMarker().gameObject, GameWorldController.instance.LevelMarker().position );
					objInt().link = newobjt.index;
				}	
			}
		}//UW2 stores enchantments on the player.dat. This is not properly implemented yet


		if (ObjectLoader.getObjectIntAt(objInt().link)!=null)
		{
			SpellObjectLink=ObjectLoader.getObjectIntAt(objInt().link).link;
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
			if (_RES==GAME_UW2)
			{
				if (SpellObjectLink-256>=320)	
				{
					return SpellObjectLink-368;
				}
			}

			return SpellObjectLink-256;	//default
			
		}
	}
				

//}


	public override bool use ()
	{
		if (UWCharacter.Instance.playerInventory.ObjectInHand=="")
		{
			if (objInt().quality >0)
				{
					UWCharacter.Instance.PlayerMagic.CastEnchantment(UWCharacter.Instance.gameObject,null,GetActualSpellIndex(),Magic.SpellRule_TargetSelf );
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
			return ActivateByObject(UWCharacter.Instance.playerInventory.GetGameObjectInHand());
		}		
	}


	public override bool LookAt ()
	{
	string FormattedName="";
				bool isIdentified=true;
				switch(objInt().identity())
				{
				case ObjectInteraction.IdentificationFlags.Identified:
						FormattedName=StringController.instance.GetFormattedObjectNameUW(objInt()) + " of " + StringController.instance.GetString(6,GetActualSpellIndex());
						break;
				case ObjectInteraction.IdentificationFlags.Unidentified:
				case ObjectInteraction.IdentificationFlags.PartiallyIdentified:
						if (UWCharacter.Instance.PlayerSkills.TrySkill(Skills.SkillLore, getIdentificationLevels(GetActualSpellIndex())))
						{
								objInt().heading=7;
								FormattedName=StringController.instance.GetFormattedObjectNameUW(objInt()) + " of " + StringController.instance.GetString(6,GetActualSpellIndex());
						}
						else
						{
								isIdentified=false;
								FormattedName=StringController.instance.GetFormattedObjectNameUW(objInt());		
						}	
						break;
				}	
	
		if ((objInt().quality>0) && (objInt().isEnchanted()==false) && (isIdentified))
		{//TODO: is the quality here the quality on the wand or the quality on the spell object? Is this behaviour different in uw1 vs uw2
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
				if (_RES==GAME_UW2){return;}//UW2 stores enchantments on the player.dat. This is not implemented yet
		base.InventoryEventOnLevelEnter ();
			//Create a spell trap and store it on the map. This occurs before the list is rendered.
		ObjectLoaderInfo newobj= ObjectLoader.newObject(390,SpellObjectQualityToCreate,SpellObjectOwnerToCreate, SpellObjectLink,256 );
		//ObjectInteraction.CreateNewObject(GameWorldController.instance.currentTileMap(), newobj,GameWorldController.instance.LevelMarker().gameObject,new Vector3(99f*1.2f,0,99f*1.2f));
		objInt().link = newobj.index;
		}


	public override void InventoryEventOnLevelExit ()
		{
		if (_RES==GAME_UW2){return;}//UW2 stores enchantments on the player.dat. This is not implemented yet
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

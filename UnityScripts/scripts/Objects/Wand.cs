using UnityEngine;
using System.Collections;

public class Wand : enchantment_base {
	//public int SpellObjectLink;
	//public int SpellObjectQualityToCreate=0;//To persist the spell trap between levels.
	//public int SpellObjectOwnerToCreate=0;
		//public int ActualSpell;

	public a_spell linkedspell;

	//protected override void Start ()
	//{
	//	base.Start ();
		
				/*
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
					ObjectLoaderInfo newobjt= ObjectLoader.newObject(288, SpellObjectQualityToCreate,SpellObjectOwnerToCreate, SpellObjectLink, 256);
					ObjectInteraction spell = ObjectInteraction.CreateNewObject(GameWorldController.instance.currentTileMap(),newobjt,  GameWorldController.instance.DynamicObjectMarker().gameObject, GameWorldController.instance.DynamicObjectMarker().position );
					objInt().link = newobjt.index;
				}	
			}
		}//UW2 stores enchantments on the player.dat. This is not properly implemented yet

		if (! objInt().isEnchanted())
		{
				if (ObjectLoader.getObjectIntAt(objInt().link)!=null)
				{
						SpellObjectLink=ObjectLoader.getObjectIntAt(objInt().link).link;
				}		
		}
		else
		{
			SpellObjectLink=0;
		}

		SetDisplayEnchantment();
		ActualSpell=GetActualSpellIndex();
		*/
//	}
	
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
		if (linkedspell!=null)
		{
			return linkedspell.objInt().link-256;
		}
		else
		{
						if (_RES!=GAME_UW2)
						{
								switch (objInt().link)		
								{
								//TODO:Figure out the range here!

								case 579://frog
								case 580://maze
								case 581://hallucination
										return objInt().link-368;	
								default:
										return objInt().link-256;	
								}
						}
						else
						{//TODO:Figure out the range here!
								switch (objInt().link)		
								{
								case 576://altara
										return objInt().link-368;	
								default:
										return objInt().link-256;	
								}
						}
					//	return objInt().link-256;//Confirm mappings for UW2
		}

				/*
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
			
		}*/
	}
				

//}


	public override bool use ()
	{

		if (UWCharacter.Instance.playerInventory.ObjectInHand=="")
		{
			if ((!objInt().PickedUp))
				{
					return true;
				}
						if (((objInt().item_id>=156) && (objInt().item_id<=159)))
						{	
								return true;//Don't use broken wands
						}

				if (GetActualSpellIndex()<0)
				{//Break invalid wands
						if (((objInt().item_id>=152) && (objInt().item_id<=155)))
						{										
							BreakWand ();
						}
						return true;
				}
			if (objInt().quality >0)
				{
					UWCharacter.Instance.PlayerMagic.CastEnchantment(UWCharacter.Instance.gameObject,null,GetActualSpellIndex(),Magic.SpellRule_TargetSelf, Magic.SpellRule_Immediate);
					if (objInt().isEnchanted()==false)
						{
						objInt().quality--;
						if ( (objInt().quality ==0) && (  (objInt().item_id>=152) && (objInt().item_id<=155) ) )
						{										
							BreakWand ();
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

	void BreakWand ()
	{
		UWHUD.instance.MessageScroll.Add(StringController.instance.GetString(1,StringController.str_with_a_loud_snap_the_wand_cracks_));
		objInt ().item_id = objInt ().item_id + 4;
		//Become a broken wand.
		objInt ().InvDisplayIndex = objInt ().InvDisplayIndex + 4;
		objInt ().WorldDisplayIndex = objInt ().WorldDisplayIndex + 4;
		objInt ().RefreshAnim ();
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

		/*
	/// <summary>
	/// Creates a new spell trap in the object list
	/// </summary>
	public override void InventoryEventOnLevelEnter ()
		{
			
		//objInt().isquant=0;
		if (_RES==GAME_UW2){return;}//UW2 stores enchantments on the player.dat. This is not implemented yet
		base.InventoryEventOnLevelEnter ();
			//Create a spell trap and store it on the map. This occurs before the list is rendered.
				//Try and find an existing spell trap with the necessary qualities. If not found then create a new one
				ObjectLoaderInfo[] objList = GameWorldController.instance.CurrentObjectList().objInfo;
				for (int i = 256; i<=objList.GetUpperBound(0);i++)
				{
						if (objList[i].item_id ==288 )//A spell
						{
								if (objList[i].link == SpellObjectLink)
								{
										objInt().link=i;
										return;
								}
						}
				}

		ObjectLoaderInfo newobj= ObjectLoader.newObject(288,SpellObjectQualityToCreate,SpellObjectOwnerToCreate, SpellObjectLink,256 );
		objInt().link = newobj.index;
		}
		*/

		/*
	public override void InventoryEventOnLevelExit ()
		{
		if (_RES==GAME_UW2){return;}//UW2 stores enchantments on the player.dat. This is not implemented yet
		//Store the spell properties so I can create it in the next level. 
		base.InventoryEventOnLevelExit ();
		//objInt().isquant=0;
		GameObject linked = ObjectLoader.getGameObjectAt(objInt().link);
			if (linked!=null)
			{
				a_spell spell = linked.GetComponent<a_spell>();
				if (spell!=null)
				{		
					SpellObjectOwnerToCreate = spell.objInt().owner;	
					SpellObjectQualityToCreate = spell.objInt().quality;
					//SpellObjectLink = spell.objInt().link;
					//SpellObjectLinkToCreate=spell.objInt().link;
					//Flag the spell trap as not being in use and change it's type to a fist so it will not persist.
					//Assumes spell traps are all stored off map
					//spell.objInt().objectloaderinfo.InUseFlag=0;
					//spell.objInt().objectloaderinfo.item_id=0;
				}
			}
			//SpellObjectOwnerToCreate 
		}
		*/


	public override void MoveToWorldEvent ()
	{
		if (objInt().enchantment==0)
		{//Object links to a spell.
			if (linkedspell !=null)
			{
				bool match =false;
				//Try and find a spell already in the level that matches the characteristics of this spell
				ObjectLoaderInfo[] objList = GameWorldController.instance.CurrentObjectList().objInfo;
				for (int i =0; i<=objList.GetUpperBound(0);i++)
				{
					if (objList[i].GetItemType()==ObjectInteraction.SPELL)
					{												
						if (objList[i].instance!=null)
						{
							if (objList[i].link == linkedspell.objInt().link)
							{
								Destroy(linkedspell.gameObject);
								linkedspell = objList[i].instance.GetComponent<a_spell>();
								objInt().link = i;
								match=true;
								break;	
							}
						}
					}
				}

				if (!match)
				{
					//linkedspell.gameObject.transform.parent=GameWorldController.instance.DynamicObjectMarker();
					GameWorldController.MoveToWorld(linkedspell.gameObject);	
				}
			}				
		}
	}

	public override void MoveToInventoryEvent ()
	{
		if (objInt().enchantment==0)
		{//Object links to a spell.
			if (linkedspell !=null)
			{
				GameObject clonelinkedspell = Object.Instantiate(linkedspell.gameObject);
				clonelinkedspell.name = ObjectInteraction.UniqueObjectName(clonelinkedspell.GetComponent<ObjectInteraction>());
				clonelinkedspell.gameObject.transform.parent=GameWorldController.instance.InventoryMarker.transform;
				linkedspell = clonelinkedspell.GetComponent<a_spell>();
				//GameWorldController.MoveToInventory(clonelinkedspell.gameObject);
			}
		}
	}

	public override string UseVerb ()
	{
		return "cast";
	}

}

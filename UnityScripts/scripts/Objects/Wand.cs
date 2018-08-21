using UnityEngine;
using System.Collections;

public class Wand : enchantment_base {

	public a_spell linkedspell;

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
			return linkedspell.link-256;
		}
		else
		{
			if (_RES!=GAME_UW2)
			{
				switch (link)		
				{
				//TODO:Figure out the range here!

				case 579://frog
				case 580://maze
				case 581://hallucination
						return link-368;	
				default:
						return link-256;	
				}
			}
			else
			{//TODO:Figure out the range here!
				switch (link)		
				{
				case 576://altara
					return link-368;	
				default:
					return link-256;	
				}
			}
		}
	}

	public override bool use ()
	{
		if (UWCharacter.Instance.playerInventory.ObjectInHand=="")
		{
			if ((!objInt().PickedUp))
				{
					return true;
				}
						if (((item_id>=156) && (item_id<=159)))
						{	
								return true;//Don't use broken wands
						}

				if (GetActualSpellIndex()<0)
				{//Break invalid wands
						if (((item_id>=152) && (item_id<=155)))
						{										
							BreakWand ();
						}
						return true;
				}
			if (quality >0)
				{
					UWCharacter.Instance.PlayerMagic.CastEnchantment(UWCharacter.Instance.gameObject,null,GetActualSpellIndex(),Magic.SpellRule_TargetSelf, Magic.SpellRule_Immediate);
					if (objInt().isEnchanted()==false)
						{
						quality--;
						if ( (quality ==0) && (  (item_id>=152) && (item_id<=155) ) )
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
		item_id = item_id + 4;
		//Become a broken wand.
		objInt().InvDisplayIndex = objInt().InvDisplayIndex + 4;
		objInt().WorldDisplayIndex = objInt().WorldDisplayIndex + 4;
		objInt().RefreshAnim ();
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
						heading=7;
						FormattedName=StringController.instance.GetFormattedObjectNameUW(objInt()) + " of " + StringController.instance.GetString(6,GetActualSpellIndex());
				}
				else
				{
						isIdentified=false;
						FormattedName=StringController.instance.GetFormattedObjectNameUW(objInt());		
				}	
				break;
		}	

		if ((quality>0) && (objInt().isEnchanted()==false) && (isIdentified))
		{//TODO: is the quality here the quality on the wand or the quality on the spell object? Is this behaviour different in uw1 vs uw2
			UWHUD.instance.MessageScroll.Add (FormattedName
				+ " with "
				+ quality 
				+ " charges remaining.");
		}
		else
		{
			//UWHUD.instance.MessageScroll.Add (StringController.instance.GetFormattedObjectNameUW(objInt()));
			UWHUD.instance.MessageScroll.Add(FormattedName);
		}
		return true;
	}

    public override void InventoryEventOnLevelExit()
    {
        base.InventoryEventOnLevelExit();
        if (_RES == GAME_UW2)
        {
            if (GameWorldController.instance.LevelNo == 42)
            {
                //make sure the wand of telekinesis is removed from the player as long as the player is not holding it in there hand
                if((SpellIndex == 295) && (linkedspell == null))
                {
                    if (this.name !=UWCharacter.Instance.playerInventory.ObjectInHand)
                    {
                        UWCharacter.Instance.playerInventory.RemoveItem(this.name);
                        //Remove object and place at 29,29
                        GameWorldController.MoveToWorld(objInt());
                        this.transform.position = CurrentTileMap().getTileVector(29, 29);
                    }   
                }
            }
        }
    }

    public override void MoveToWorldEvent ()
	{
		if (enchantment==0)
		{//Object links to a spell.
			if (linkedspell !=null)
			{
				bool match =false;
				//Try and find a spell already in the level that matches the characteristics of this spell
				ObjectLoaderInfo[] objList = CurrentObjectList().objInfo;
				for (int i =0; i<=objList.GetUpperBound(0);i++)
				{
					if (objList[i].GetItemType()==ObjectInteraction.SPELL)
					{												
						if (objList[i].instance!=null)
						{
							if (objList[i].link == linkedspell.link)
							{
								Destroy(linkedspell.gameObject);
								linkedspell = objList[i].instance.GetComponent<a_spell>();
								link = i;
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
		if (enchantment==0)
		{//Object links to a spell.
			if (linkedspell !=null)
			{
				GameObject clonelinkedspell = Object.Instantiate(linkedspell.gameObject);
				clonelinkedspell.name = ObjectInteraction.UniqueObjectName(clonelinkedspell.GetComponent<ObjectInteraction>());
				clonelinkedspell.gameObject.transform.parent=GameWorldController.instance.InventoryMarker.transform;
				linkedspell = clonelinkedspell.GetComponent<a_spell>();
			}
		}
	}

	public override string UseVerb ()
	{
		return "cast";
	}

}

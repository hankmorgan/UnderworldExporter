using UnityEngine;
using System.Collections;

public class Food : object_base {
    /*Food items*/
    public int DebugNutrition;


	protected override void Start ()
	{
		base.Start();

        //Fix to repair invalid food properties.
        if  ((isquant==0) && (link<=1))
		{
			if ((item_id>=176) && (item_id<=192))
			{
					//Debug.Log("Fixing food item " + this.name);
					isquant=1;
					link=1;	
			}
		}
	}

		/// <summary>
		/// Nutrition provided by this item of food
		/// </summary>
		public int Nutrition()
		{
        if ((item_id >=176) && ((item_id <=192)))
        {
            Debug.Log(this.name + " provides nutrition of " + GameWorldController.instance.objDat.nutritionStats[item_id - 176].FoodValue);
            return GameWorldController.instance.objDat.nutritionStats[item_id - 176].FoodValue;
        }
        else
        {
            Debug.Log("unimplemented food nutrition value");
            return 16;
        }
    }

	public override bool use ()
	{
		if ((CurrentObjectInHand==null) || (CurrentObjectInHand==this.objInt()))
		{//Eat if no object in hand or if the object in hand is this item.			
								
			switch(item_id)
			{
			case 191://Wine of compassion.
				if (_RES==GAME_UW1)
				{
					//000~001~127~You are unable to open the wine bottle.
					UWHUD.instance.MessageScroll.Add(StringController.instance.GetString(1,127));
					return true;
				}
				else
				{
					return Eat();
				}
				
			default:
				return Eat();
			}
		}
		else
		{
			return ActivateByObject(CurrentObjectInHand);
		}
	}

    public override bool Eat()
	{
		if (Nutrition()+UWCharacter.Instance.FoodLevel>=255)
		{
			UWHUD.instance.MessageScroll.Add (StringController.instance.GetString(1,StringController.str_you_are_too_full_to_eat_that_now_));
			return false;
		}
		else
        {
            UWCharacter.Instance.FoodLevel = Nutrition() + UWCharacter.Instance.FoodLevel;
            switch (_RES)
            {
                case GAME_UW2:
                    TasteUW2();break;
                default:
                    TasteUW1();break;
            }
            
            if (ObjectInteraction.PlaySoundEffects)
            {
                switch(objInt().GetItemType())
                {
                    case ObjectInteraction.DRINK:
                        DrinkSoundEffects(); break;
                    default:
                        EatSoundEffects();break;
                }                
            }

            if (_RES == GAME_UW2)
            {//Some food items leave left overs
                LeftOvers();
            }
            objInt().consumeObject();//destroy and remove from inventory/world.

            return true; //Food was eaten.
        }
    }

    private static void EatSoundEffects()
    {
        switch (Random.Range(1, 3))
        {
            case 1:
                UWCharacter.Instance.aud.clip = MusicController.instance.SoundEffects[MusicController.SOUND_EFFECT_EAT_1]; break;
            case 2:
                UWCharacter.Instance.aud.clip = MusicController.instance.SoundEffects[MusicController.SOUND_EFFECT_EAT_2]; break;
            default:
                UWCharacter.Instance.aud.clip = MusicController.instance.SoundEffects[MusicController.SOUND_EFFECT_EAT_3]; break;
        }
        UWCharacter.Instance.aud.Play();
    }

    private static void DrinkSoundEffects()
    {//Play Sound effects for drinkg
        Debug.Log("Glug glug");
    }

    /// <summary>
    /// Prints the taste message for UW1 and processes additional food effects
    /// </summary>
    private void TasteUW1()
    {
        switch (item_id)
        {
            case 184:// a_mushroom
                UWHUD.instance.MessageScroll.Add(StringController.instance.GetString(1, StringController.str_the_mushroom_causes_your_head_to_spin_and_your_vision_to_blur_));
                UWCharacter.Instance.PlayerMagic.CastEnchantment(UWCharacter.Instance.gameObject, null, SpellEffect.UW1_Spell_Effect_Hallucination, Magic.SpellRule_TargetSelf, Magic.SpellRule_Consumable);
                break;
            case 185:// a_toadstool
                UWHUD.instance.MessageScroll.Add(StringController.instance.GetString(1, StringController.str_the_toadstool_tastes_odd_and_you_begin_to_feel_ill_));
                //UWCharacter.Instance.PlayerMagic.CastEnchantment(UWCharacter.Instance.gameObject, null, SpellEffect.UW1_Spell_Effect_Poison, Magic.SpellRule_TargetSelf, Magic.SpellRule_Consumable);
                UWCharacter.Instance.play_poison += 2;
                break;
            case 186:// a_bottle_of_ale_bottles_of_ale
                UWHUD.instance.MessageScroll.Add(StringController.instance.GetString(1, StringController.str_you_drink_the_dark_ale_));
                break;
            case 192://plants
            case 207:
            case 212:
                UWHUD.instance.MessageScroll.Add(StringController.instance.GetString(1, StringController.str_the_plant_is_plain_tasting_but_nourishing_));
                break;
            case 217://Dead rotworm
                UWHUD.instance.MessageScroll.Add(StringController.instance.GetString(1, 234));
                break;
            case 283://Rotworm stew
                UWHUD.instance.MessageScroll.Add(StringController.instance.GetString(1, 235));
                break;
            default:
                UWHUD.instance.MessageScroll.Add("That " + StringController.instance.GetObjectNounUW(objInt()) + foodFlavourText());
                break;
        }
    }


    private void TasteUW2()
    {
        switch (item_id)
        {
            case 185:// a_mushroom
                UWHUD.instance.MessageScroll.Add(StringController.instance.GetString(1, StringController.str_the_mushroom_causes_your_head_to_spin_and_your_vision_to_blur_));
                UWCharacter.Instance.PlayerMagic.CastEnchantment(UWCharacter.Instance.gameObject, null, SpellEffect.UW2_Spell_Effect_Hallucination, Magic.SpellRule_TargetSelf, Magic.SpellRule_Consumable);
                break;
            case 206://a_plant
                //000~001~251~Although you have to eat around the thorny flowers, the plant is quite good. \n
                UWHUD.instance.MessageScroll.Add(StringController.instance.GetString(1, StringController.str_although_you_have_to_eat_around_the_thorny_flowers_the_plant_is_quite_good_));
                break;
            case 207://a_plant
                UWHUD.instance.MessageScroll.Add(StringController.instance.GetString(1, StringController.str_the_plant_is_plain_tasting_but_nourishing_));
                break;
            default:
                UWHUD.instance.MessageScroll.Add("That " + StringController.instance.GetObjectNounUW(objInt()) + foodFlavourText());
                break;
        }
    }

    /// <summary>
    /// Spawn leftovers after eating in UW2
    /// </summary>
    protected void LeftOvers()
    {
        int LeftOverToCreate = -1;
        switch (item_id)
        {

            case 176:
            case 177://meat
                LeftOverToCreate = 197; break;
            case 186://honeycomb
                LeftOverToCreate = 210; break;
            case 187:
            case 188:
            case 189://bottles.
                LeftOverToCreate = 317; break;
        }

        if (LeftOverToCreate != -1)
        {
            ObjectLoaderInfo newobjt = ObjectLoader.newObject(LeftOverToCreate, 40, 0, 0, 256);
            newobjt.InUseFlag = 1;
            ObjectInteraction created = ObjectInteraction.CreateNewObject(CurrentTileMap(), newobjt, CurrentObjectList().objInfo, GameWorldController.instance.DynamicObjectMarker().gameObject, GameWorldController.instance.InventoryMarker.transform.position);
            GameWorldController.MoveToInventory(created.gameObject);
            CurrentObjectInHand = created;
            UWCharacter.InteractionMode = UWCharacter.InteractionModePickup;
        }
    }

    public override bool LookAt()
    {
        if (objInt().GetItemType() == ObjectInteraction.DRINK)
        {
            return base.LookAt();
        }
        //Code for when looking at food. Should one day return quantity and smell properly
        switch (_RES)
        {
            case GAME_UW2:
                switch (item_id)
                {
                    case 192://plants
                        return base.LookAt();
                    default:
                        UWHUD.instance.MessageScroll.Add(StringController.instance.GetFormattedObjectNameUW(objInt(), foodSmellText()) + OwnershipString());
                        break;
                }
                break;   

            case GAME_UW1:
            default:
                {
                    switch (item_id)
                    {
                        case 191://Wine of compassion
                            UWHUD.instance.MessageScroll.Add(StringController.instance.GetString(1, StringController.str_you_see_) + " " + StringController.instance.GetString(1, 264));
                            break;
                        case 192://plants
                        case 207:
                        case 212:
                        case 217://Dead Rotworm
                            return base.LookAt();
                        default:
                            UWHUD.instance.MessageScroll.Add(StringController.instance.GetFormattedObjectNameUW(objInt(), foodSmellText()) + OwnershipString());
                            break;
                    }
                    break;
                }            
        }
        return true;
    }

		/// <summary>
		/// The quality string of the food. Eg is it disgusting or not etc.
		/// </summary>
		/// <returns>The flavour text.</returns>
		/// TODO:These are the strings for fish. This needs to reflect other food types!
	private string foodFlavourText()//Literally!
	{
		int QualityClass= GameWorldController.instance.commonObject.properties[item_id].QualityClass;
		int QualityType= GameWorldController.instance.commonObject.properties[item_id].QualityType;
	    Debug.Log ("Food : quality class=" + QualityClass + " quality type=" + QualityType);
		int BaseStringNo=StringController.str__tasted_putrid_;
		if (quality == 0)
			{
				return StringController.instance.GetString (1,BaseStringNo);//worm
			}
		if ((quality >=1) && (quality <15))
			{
				return StringController.instance.GetString (1,BaseStringNo+1);//rotten
			}
		if ((quality >=15) && (quality <32))
			{
				return StringController.instance.GetString (1,BaseStringNo+2);//smelly
			}
		if ((quality >=32) && (quality <40))
			{
				return StringController.instance.GetString (1,BaseStringNo+3);//day old
			}
		if ((quality >=40) && (quality <48))
			{
				return StringController.instance.GetString (1,BaseStringNo+4);//fresh
			}
		else
			{
				return StringController.instance.GetString (1,BaseStringNo+5);//fresh
			}
	}

		/// <summary>
		/// How appetising the food looks and smells
		/// </summary>
		/// <returns>The smell text.</returns>
		/// TODO:Integrate common object settings as appropiate. Currently everything is fish!
	private string foodSmellText()//
	{
		int QualityClass= GameWorldController.instance.commonObject.properties[item_id].QualityClass;
		int QualityType= GameWorldController.instance.commonObject.properties[item_id].QualityType;
		Debug.Log ("Food : quality class=" + QualityClass + " quality type=" + QualityType);				
		if (quality == 0)
		{
				return StringController.instance.GetString (5,18);//worm
		}
		if ((quality >=1) && (quality <15))
		{
				return StringController.instance.GetString (5,19);//rotten
		}
		if ((quality >=15) && (quality <32))
		{
				return StringController.instance.GetString (5,20);//smelly
		}
		if ((quality >=32) && (quality <40))
		{
				return StringController.instance.GetString (5,21);//day old
		}

		if ((quality >=40) && (quality <48))
		{
				return StringController.instance.GetString (5,22);//fresh
		}
		else
		{
				return StringController.instance.GetString (5,23);//fresh
		}	
	}

	public override bool ApplyAttack (short damage)
	{
		quality-=damage;
		if (quality<=0)
		{
			ChangeType(213);//Change to debris.
			this.gameObject.AddComponent<object_base>();//Add a generic object base for behaviour
			objInt().objectloaderinfo.InUseFlag=0;
			Destroy(this);//Kill me now.
		}
		return true;
	}

	public override string UseVerb ()
	{
        switch (objInt().GetItemType())
        {
        case ObjectInteraction.DRINK:
            return "drink";
        default:
            return "eat";
        }			
	}
}

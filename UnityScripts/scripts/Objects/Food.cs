using UnityEngine;
using System.Collections;

public class Food : object_base {
	/*Food items*/

	protected override void Start ()
	{
		base.Start();
		//Fix to repair invalid food properties.
		if  ((objInt().isquant==0) && (objInt().link<=1))
		{
			if ((objInt().item_id>=176) && (objInt().item_id<=192))
			{
					//Debug.Log("Fixing food item " + this.name);
					objInt().isquant=1;
					objInt().link=1;	
			}
		}
	}

		/// <summary>
		/// Nutrition provided by this item of food
		/// </summary>
		public int Nutrition()
		{
				switch (_RES)	
				{
				case GAME_UW2:
						{
							return 16;
						}
				default:
						{//TODO:Identify the proper values to use here (5 is still to be figured out)
								switch (objInt().item_id)	
								{
								case 176://a_piece_of_meat_pieces_of_meat
										return 16;
								case 177://a_loaf_of_bread_loaves_of_bread	
										return 16;
								case 178://a_piece_of_cheese_pieces_of_cheese	
										return 5;
								case 179://an_apple	
										return 6;
								case 180://an_ear_of_corn_ears_of_corn	
										return 5;
								case 181://a_loaf_of_bread_loaves_of_bread	
										return 16;
								case 182://a_fish_fish	
										return 16;
								case 183://some_popcorn_bunches_of_popcorn
										return 5;
								case 184://a_mushroom	
										return 5;
								case 185://a_toadstool	
										return 5;
								}
								break;
						}
				}
			return 16;
		}

	public override bool use ()
	{
		if ((UWCharacter.Instance.playerInventory.ObjectInHand=="") || (UWCharacter.Instance.playerInventory.ObjectInHand==this.name))
		{//Eat if no object in hand or if the object in hand is this item.
						
								
			switch(objInt().item_id)
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
			return ActivateByObject(UWCharacter.Instance.playerInventory.GetGameObjectInHand());
		}
	}


	public override bool Eat()
	{//TODO:Implement drag and drop feeding.

		if (Nutrition()+UWCharacter.Instance.FoodLevel>=255)
		{
			UWHUD.instance.MessageScroll.Add (StringController.instance.GetString(1,StringController.str_you_are_too_full_to_eat_that_now_));
			return false;
		}
		else
		{
			UWCharacter.Instance.FoodLevel = Nutrition()+UWCharacter.Instance.FoodLevel;
			switch (objInt().item_id)//TODO:update for UW2
				{
				case 192://plants
				case 207:	
				case 212:
						UWHUD.instance.MessageScroll.Add (StringController.instance.GetString(1,StringController.str_the_plant_is_plain_tasting_but_nourishing_));
						break;	
				case 217://Dead rotworm
					UWHUD.instance.MessageScroll.Add (StringController.instance.GetString(1,234));
					break;
				case 283://Rotworm stew
					UWHUD.instance.MessageScroll.Add (StringController.instance.GetString(1,235));
					break;
				default:
					UWHUD.instance.MessageScroll.Add ("That " + StringController.instance.GetObjectNounUW(objInt()) + foodFlavourText());
					break;
				}
			if (ObjectInteraction.PlaySoundEffects)
			{
				switch (Random.Range(1,3))
				{
				case 1:
					UWCharacter.Instance.aud.clip=GameWorldController.instance.getMus().SoundEffects[MusicController.SOUND_EFFECT_EAT_1];break;
				case 2:
					UWCharacter.Instance.aud.clip=GameWorldController.instance.getMus().SoundEffects[MusicController.SOUND_EFFECT_EAT_2];break;
				default:
					UWCharacter.Instance.aud.clip=GameWorldController.instance.getMus().SoundEffects[MusicController.SOUND_EFFECT_EAT_3];break;
				}				
				UWCharacter.Instance.aud.Play();		
			}

			if (_RES==GAME_UW2)
			{//Some food items leave left overs
					int LeftOverToCreate=-1;
					switch (objInt().item_id)
					{

					case 176:
					case 177://meat
						LeftOverToCreate=197;break;
					case 186://honeycomb
						LeftOverToCreate=210;break;
					case 187:								
					case 188:
					case 189://bottles.
							LeftOverToCreate=317;break;
					}

					if (LeftOverToCreate!=-1)
					{
						ObjectLoaderInfo newobjt= ObjectLoader.newObject( LeftOverToCreate,40,0,0,256);
						newobjt.InUseFlag=1;
						ObjectInteraction created=ObjectInteraction.CreateNewObject(GameWorldController.instance.currentTileMap(),newobjt, GameWorldController.instance.LevelMarker().gameObject, GameWorldController.instance.InventoryMarker.transform.position);
						GameWorldController.MoveToWorld(created.gameObject);
						UWCharacter.Instance.playerInventory.ObjectInHand=created.name;
						UWHUD.instance.CursorIcon= created.GetInventoryDisplay().texture;
						UWCharacter.InteractionMode=UWCharacter.InteractionModePickup;
					}
			}
			objInt().consumeObject();//destroy and remove from inventory/world.

			return true; //Food was eaten.
		}
	}

	public override bool LookAt()
	{
		//Code for when looking at food. Should one day return quantity and smell properly

		switch(objInt().item_id)
		{
			case 191://Wine of compassion
				UWHUD.instance.MessageScroll.Add (StringController.instance.GetString(1,StringController.str_you_see_) + " " + StringController.instance.GetString(1,264));
				break;
			case 192://plants
			case 207:	
			case 212:
			case 217://Dead Rotworm
				return base.LookAt();
			default:		
				UWHUD.instance.MessageScroll.Add (StringController.instance.GetFormattedObjectNameUW(objInt(),foodSmellText()) + OwnershipString());		
				break;
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
			int QualityClass= GameWorldController.instance.commonObject.properties[objInt().item_id].QualityClass;
			int QualityType= GameWorldController.instance.commonObject.properties[objInt().item_id].QualityType;
			//Debug.Log ("Food : quality class=" + QualityClass + " quality type=" + QualityType);
				int BaseStringNo=StringController.str__tasted_putrid_;
				//if (_RES==GAME_UW2)
				//{
				//		BaseStringNo=187;
				//}
		if (objInt().quality == 0)
			{
				return StringController.instance.GetString (1,BaseStringNo);//worm
			}
		if ((objInt().quality >=1) && (objInt().quality <15))
			{
				return StringController.instance.GetString (1,BaseStringNo+1);//rotten
			}
		if ((objInt().quality >=15) && (objInt().quality <32))
			{
				return StringController.instance.GetString (1,BaseStringNo+2);//smelly
			}
		if ((objInt().quality >=32) && (objInt().quality <40))
			{
				return StringController.instance.GetString (1,BaseStringNo+3);//day old
			}
		if ((objInt().quality >=40) && (objInt().quality <48))
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
		int QualityClass= GameWorldController.instance.commonObject.properties[objInt().item_id].QualityClass;
		int QualityType= GameWorldController.instance.commonObject.properties[objInt().item_id].QualityType;
		//Debug.Log ("Food : quality class=" + QualityClass + " quality type=" + QualityType);				
		if (objInt().quality == 0)
		{
				return StringController.instance.GetString (5,18);//worm
		}
		if ((objInt().quality >=1) && (objInt().quality <15))
		{
				return StringController.instance.GetString (5,19);//rotten
		}
		if ((objInt().quality >=15) && (objInt().quality <32))
		{
				return StringController.instance.GetString (5,20);//smelly
		}
		if ((objInt().quality >=32) && (objInt().quality <40))
		{
				return StringController.instance.GetString (5,21);//day old
		}

		if ((objInt().quality >=40) && (objInt().quality <48))
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
		objInt().quality-=damage;
		if (objInt().quality<=0)
		{
			ChangeType(213,23);//Change to debris.
			this.gameObject.AddComponent<object_base>();//Add a generic object base for behaviour
			objInt().objectloaderinfo.InUseFlag=0;
			Destroy(this);//Kill me now.
		}
		return true;
	}


		public override string UseVerb ()
		{
			return "eat";
		}
}

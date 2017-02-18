using UnityEngine;
using System.Collections;

public class Food : object_base {
	/*Food items*/

	public int Nutrition; //The nutritional value of this food.

	public override bool use ()
	{
		if ((GameWorldController.instance.playerUW.playerInventory.ObjectInHand=="") || (GameWorldController.instance.playerUW.playerInventory.ObjectInHand==this.name))
		{//Eat if no object in hand or if the object in hand is this item.
			switch(objInt().item_id)
			{
			case 191://Wine of compassion.
				//000~001~127~You are unable to open the wine bottle.
				UWHUD.instance.MessageScroll.Add(StringController.instance.GetString(1,127));
				return true;
			default:
				return Eat();
			}
		}
		else
		{
			return ActivateByObject(GameWorldController.instance.playerUW.playerInventory.GetGameObjectInHand());
		}
	}


	public override bool Eat()
	{//TODO:Implement drag and drop feeding.

		if (Nutrition+GameWorldController.instance.playerUW.FoodLevel>=255)
		{
			GameWorldController.instance.playerUW.FoodLevel=255;
			UWHUD.instance.MessageScroll.Add (StringController.instance.GetString(1,126));
			return false;
		}
		else
		{
			GameWorldController.instance.playerUW.FoodLevel = Nutrition+GameWorldController.instance.playerUW.FoodLevel;
			switch (objInt().item_id)
				{
				case 192://plants
				case 207:	
				case 212:
						UWHUD.instance.MessageScroll.Add (StringController.instance.GetString(1,233));
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
				UWHUD.instance.MessageScroll.Add ("You see " + StringController.instance.GetString(1,264));
				break;
			case 192://plants
			case 207:	
			case 212:
			case 217://Dead Rotworm
				return base.LookAt();
			default:		
				UWHUD.instance.MessageScroll.Add (StringController.instance.GetFormattedObjectNameUW(objInt(),foodSmellText()));		
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
		if (objInt().quality == 0)
			{
			return StringController.instance.GetString (1,172);//worm
			}
		if ((objInt().quality >=1) && (objInt().quality <15))
			{
			return StringController.instance.GetString (1,173);//rotten
			}
		if ((objInt().quality >=15) && (objInt().quality <32))
			{
			return StringController.instance.GetString (1,174);//smelly
			}
		if ((objInt().quality >=32) && (objInt().quality <40))
			{
			return StringController.instance.GetString (1,175);//day old
			}
		if ((objInt().quality >=40) && (objInt().quality <48))
			{
			return StringController.instance.GetString (1,176);//fresh
			}
		else
			{
			return StringController.instance.GetString (1,176);//fresh
			}
	}

		/// <summary>
		/// How appetising the food looks and smells
		/// </summary>
		/// <returns>The smell text.</returns>
		/// TODO:Integrate common object settings as appropiate. Currently everything is fish!
	private string foodSmellText()//
	{
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

	public override bool ApplyAttack (int damage)
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

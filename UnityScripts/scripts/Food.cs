using UnityEngine;
using System.Collections;

public class Food : object_base {
	/*Food items*/

	public int Nutrition; //The nutritional value of this food.

	public override bool use ()
	{
		if (playerUW.playerInventory.ObjectInHand=="")
		{
			return Eat();
		}
		else
		{
			return ActivateByObject(playerUW.playerInventory.GetGameObjectInHand());
		}
	}


	public bool Eat()
	{//TODO:Implement drag and drop feeding.

		if (Nutrition+playerUW.FoodLevel>=255)
		{
			playerUW.FoodLevel=255;
			ml.text= ObjectInteraction.playerUW.StringControl.GetString(1,126);
			return false;
		}
		else
		{
			playerUW.FoodLevel = Nutrition+playerUW.FoodLevel;
			ml.text= "That " + playerUW.StringControl.GetObjectNounUW(objInt) + foodFlavourText();
			objInt.consumeObject();//destroy and remove from inventory/world.
			return true; //Food was eaten.
		}
	}

	public override bool LookAt()
	{
		//Code for when looking at food. Should one day return quantity and smell properly
		ml.text = playerUW.StringControl.GetFormattedObjectNameUW(objInt,foodSmellText());
		return true;
	}

	private string foodFlavourText()//Literally!
	{//The quality string of the food. Eg is it disgusting or not etc.
		//How it tasted?
		//TODO:These are the strings for fish. This needs to reflect other food types!
		if (objInt.Quality == 0)
			{
			return playerUW.StringControl.GetString (1,172);//worm
			}
		if ((objInt.Quality >=1) && (objInt.Quality <15))
			{
			return playerUW.StringControl.GetString (1,173);//rotten
			}
		if ((objInt.Quality >=15) && (objInt.Quality <32))
			{
			return playerUW.StringControl.GetString (1,174);//smelly
			}
		if ((objInt.Quality >=32) && (objInt.Quality <40))
			{
			return playerUW.StringControl.GetString (1,175);//day old
			}

		if ((objInt.Quality >=40) && (objInt.Quality <48))
			{
			return playerUW.StringControl.GetString (1,176);//fresh
			}
		else
			{
			return playerUW.StringControl.GetString (1,176);//fresh
			}
	}

	private string foodSmellText()//How appetising the food looks and smells
	{//TODO:Integrate common object settings as appropiate. Currently everything is fish!
		//int FoodQuality = objInt.Quality;
		
		if (objInt.Quality == 0)
		{
			return playerUW.StringControl.GetString (5,18);//worm
		}
		if ((objInt.Quality >=1) && (objInt.Quality <15))
		{
			return playerUW.StringControl.GetString (5,19);//rotten
		}
		if ((objInt.Quality >=15) && (objInt.Quality <32))
		{
			return playerUW.StringControl.GetString (5,20);//smelly
		}
		if ((objInt.Quality >=32) && (objInt.Quality <40))
		{
			return playerUW.StringControl.GetString (5,21);//day old
		}
		
		if ((objInt.Quality >=40) && (objInt.Quality <48))
		{
			return playerUW.StringControl.GetString (5,22);//fresh
		}
		else
		{
			return playerUW.StringControl.GetString (5,23);//fresh
		}
	}

}

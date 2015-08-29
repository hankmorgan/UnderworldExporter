using UnityEngine;
using System.Collections;

public class Food : MonoBehaviour {
	public int Nutrition; //The nutritional value of this food.
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public bool Activate()
	{//TODO:Implement drag and drop feeding.
		//Food gets eaten
		ObjectInteraction objInt = this.gameObject.GetComponent<ObjectInteraction>();
		UWCharacter playerUW = objInt.getPlayerUW();
		StringController Sc = objInt.getStringController();
		UILabel ml =objInt.getMessageLog();
		PlayerInventory pInv = objInt.getPlayerInventory();

		if (Nutrition+playerUW.FoodLevel>=255)
		{
			playerUW.FoodLevel=255;
			ml.text= Sc.GetString(1,126);
			return false;
		}
		else
		{
			playerUW.FoodLevel = Nutrition+playerUW.FoodLevel;
			ml.text= "That " + Sc.GetFormattedObjectNameUW(objInt,1) + " " + foodFlavourText(objInt,Sc);
			objInt.consumeObject();//destroy and remove from inventory/world.
			return true; //Food was eaten.
		}
	}

	public bool LookAt()
	{
		//Code for when looking at food. Should one day return quantity and smell properly
		ObjectInteraction objInt = this.gameObject.GetComponent<ObjectInteraction>();
		UILabel ml =objInt.getMessageLog();
		StringController Sc = objInt.getStringController();
		ml.text = Sc.GetString(1,260) + " " + Sc.GetFormattedObjectNameUW(objInt);
		return true;
	}

	private string foodFlavourText(ObjectInteraction objInt, StringController sc)//Literally!
	{//The quality string of the food. Eg is it disgusting or not etc.
		int FoodQuality = this.GetComponent<ObjectInteraction>().Quality;

		if (FoodQuality == 0)
			{
			return sc.GetString (1,172);//worm
			}
		if ((FoodQuality >=1) && (FoodQuality <15))
			{
			return sc.GetString (1,173);//rotten
			}
		if ((FoodQuality >=15) && (FoodQuality <32))
			{
			return sc.GetString (1,174);//smelly
			}
		if ((FoodQuality >=32) && (FoodQuality <40))
			{
			return sc.GetString (1,175);//day old
			}

		if ((FoodQuality >=40) && (FoodQuality <48))
			{
			return sc.GetString (1,176);//fresh
			}
		else
			{
			return sc.GetString (1,176);//fresh
			}

		return "NO FOOD QUALITY MATCHED";
	}

	private string foodSmellText(ObjectInteraction objInt, StringController sc)//How appetising the food looks and smells
	{//TODO:Integrate common object settings as appropiate. Currently everything is fish!
		int FoodQuality = this.GetComponent<ObjectInteraction>().Quality;
		
		if (FoodQuality == 0)
		{
			return sc.GetString (5,18);//worm
		}
		if ((FoodQuality >=1) && (FoodQuality <15))
		{
			return sc.GetString (5,19);//rotten
		}
		if ((FoodQuality >=15) && (FoodQuality <32))
		{
			return sc.GetString (5,20);//smelly
		}
		if ((FoodQuality >=32) && (FoodQuality <40))
		{
			return sc.GetString (5,21);//day old
		}
		
		if ((FoodQuality >=40) && (FoodQuality <48))
		{
			return sc.GetString (5,22);//fresh
		}
		else
		{
			return sc.GetString (5,23);//fresh
		}
		
		return "NO FOOD QUALITY MATCHED";
	}

}

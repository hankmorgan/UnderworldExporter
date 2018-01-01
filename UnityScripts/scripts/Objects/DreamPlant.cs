using UnityEngine;
using System.Collections;

public class DreamPlant : object_base {


	public override bool use ()
	{	
		if ((UWCharacter.Instance.playerInventory.ObjectInHand=="") || (UWCharacter.Instance.playerInventory.ObjectInHand==this.name))
		{
			return Eat();
		}
		else
		{
			return ActivateByObject(UWCharacter.Instance.playerInventory.GetGameObjectInHand());
		}
	}


	public override bool Eat ()
	{
		if (23+UWCharacter.Instance.FoodLevel>=255)
		{
			UWHUD.instance.MessageScroll.Add (StringController.instance.GetString(1,StringController.str_you_are_too_full_to_eat_that_now_));
			return false;
		}
		else
		{
			UWCharacter.Instance.FoodLevel = 23+UWCharacter.Instance.FoodLevel;
			Quest.instance.DreamPlantEaten=true;
			//000~001~248~The plant is plain tasting but nourishing. \n
			UWHUD.instance.MessageScroll.Add(StringController.instance.GetString(1,248));
			objInt().consumeObject();
			return true;
		}

	}
}

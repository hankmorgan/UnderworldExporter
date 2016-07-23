using UnityEngine;
using System.Collections;

public class ReadableTrap : object_base {

	//Explodes in your face book.	public override bool use ()
	public override bool use ()
	{
		if (playerUW.playerInventory.ObjectInHand == "")
		{
			UWHUD.instance.MessageScroll.Add ("The book explodes in your face");
			playerUW.ApplyDamage(Random.Range (1,20));
			playerUW.quest().QuestVariables[8]=1;//For Bronus/Morlock quest.
			objInt().consumeObject ();
			return true;
		}
		else
		{
			return ActivateByObject(playerUW.playerInventory.GetGameObjectInHand());
		}
	}
}

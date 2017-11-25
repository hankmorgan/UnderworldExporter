using UnityEngine;
using System.Collections;

public class Bedroll : object_base {

	public override bool use ()
	{
	if (UWCharacter.Instance.playerInventory.ObjectInHand=="")
		{
			UWCharacter.Instance.Sleep();
			return true;
		}
		else
		{
		return ActivateByObject(UWCharacter.Instance.playerInventory.GetGameObjectInHand());
		}
	}



	public override string UseVerb ()
	{
		return "sleep";
	}




}

using UnityEngine;
using System.Collections;

public class Pole : object_base {
	//000~001~157~Using the pole you trigger the switch.
	//000~001~158~The pole cannot be used on that.

	public override bool use ()
	{
		BecomeObjectInHand();
		return true;
	}

	public override bool FailMessage ()
	{
		playerUW.GetMessageLog().text=playerUW.StringControl.GetString(1,158);
		return false;
	}

}

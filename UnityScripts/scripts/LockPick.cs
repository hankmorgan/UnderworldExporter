using UnityEngine;
using System.Collections;

public class LockPick : object_base {

	public override bool use()
	{
		BecomeObjectInHand();
		ml.text = playerUW.StringControl.GetString(1,8);
		return true;
	}
}

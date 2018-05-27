using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellProp_Tym : SpellProp {

	public override void onHitPlayer ()
		{
				//Freeze player for 15 seconds.
			UWCharacter.Instance.ParalyzeTimer = 15;
		}
}

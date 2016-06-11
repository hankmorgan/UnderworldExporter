using UnityEngine;
using System.Collections;

public class SpellEffectFly : SpellEffectLevitate {
//SHould this be a subclass of Levitate? Only diff is speed???

	public override void Update ()
	{
		if (Active)
		{
			if (playerUW.flySpeed <= 2)
			{
				playerUW.flySpeed=2;
			}
			playerUW.isFlying=true;
		}
	}
}

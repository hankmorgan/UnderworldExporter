using UnityEngine;
using System.Collections;

public class SpellProp_InJux : SpellProp {
	//Rune of Warding
	public override void init ()
	{
		base.init ();
		//ProjectileSprite = "Sprites/objects_020";
		//Force=200.0f;
		BaseDamage=20;
		//impactFrameStart=21;
		//impactFrameEnd=25;
	}

	public override void onImpact (Transform tf)
	{
		base.onImpact (tf);

		//Announce to the player the ward has gone off.
		//000~001~245~Your Rune of Warding has been set off 
		playerUW.playerHud.MessageScroll.Add(playerUW.StringControl.GetString(1,245) + " at a direction I need to implement");
	}
}

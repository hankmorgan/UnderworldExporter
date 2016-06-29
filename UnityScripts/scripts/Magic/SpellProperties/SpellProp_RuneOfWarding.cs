using UnityEngine;
using System.Collections;

public class SpellProp_RuneOfWarding : SpellProp {
	//Rune of Warding
		public override void init(int effectId)
	{
		base.init (effectId);
		//ProjectileSprite = "Sprites/objects_020";
		//Force=200.0f;
		BaseDamage=0;
		//impactFrameStart=21;
		//impactFrameEnd=25;
	}

	public override void onImpact (Transform tf)
	{
		base.onImpact (tf);
		//Vector3 TrapPosition = new Vector3(tf.position.x,0,tf.position.z);
		//Vector3 PlayerPosition = new Vector3(playerUW.transform.position.x,0,playerUW.transform.position.z);
		//Vector3 relativeAngle = TrapPosition-PlayerPosition;
		//Debug.Log(Vector3.Angle (TrapPosition, PlayerPosition));
		//Announce to the player the ward has gone off.
		//000~001~245~Your Rune of Warding has been set off 
		playerUW.playerHud.MessageScroll.Add(playerUW.StringControl.GetString(1,245) + Compass.getCompassHeading(playerUW.gameObject,tf.gameObject));
	}
	/*
	public override void onImpactPlayer ()
	{
		base.onImpactPlayer ();
		playerUW.playerHud.MessageScroll.Add("TEST");
	}
	*/

}

using UnityEngine;
using System.Collections;

public class SpellProp_RuneOfWarding : SpellProp {
	//Rune of Warding
	public override void init(int effectId, GameObject SpellCaster)
	{
		base.init (effectId,SpellCaster);
		//ProjectileSprite = _RES +"/Sprites/Objects/Objects_020";
		//Force=200.0f;
		BaseDamage=15;
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
		UWHUD.instance.MessageScroll.Add(StringController.instance.GetString(1,StringController.str_your_rune_of_warding_has_been_set_off_) + Compass.getCompassHeading(playerUW.gameObject,tf.gameObject));
	}
	/*
	public override void onImpactPlayer ()
	{
		base.onImpactPlayer ();
		UWHUD.instance.MessageScroll.Add("TEST");
	}
	*/

}

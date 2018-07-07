using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellProp_Homing : SpellProp {
		//Homing missile used in deadly seeker spell
		public MagicProjectile projectileToTrack;

		public override void init(int effectId, GameObject SpellCaster)
		{
				base.init (effectId,SpellCaster);
				ProjectileItemId=27;
				Force=200.0f;
				BaseDamage=12;
				impactFrameStart=43;
				impactFrameEnd=47;
				spread=0;
				noOfCasts=1;
				homing=true;
				hasTrail=true;
		}




}

using UnityEngine;
using System.Collections;

public class SpellProp_FlamHur : SpellProp_PorFlam {
		//Flame wind. Aka DOOM.
		//protected int splashDamage;//Damage applied to the explosion.
		//protected float splashDistance;

		public override void init ()
		{
				base.init ();
				ProjectileSprite = "Sprites/object_blank";
				Force=500.0f;
				BaseDamage=16;
				splashDamage=8;
				splashDistance=1.0f;
				impactFrameStart=21;
				impactFrameEnd=25;
				spread=5;
				noOfCasts=Random.Range(2,5);
		}

}

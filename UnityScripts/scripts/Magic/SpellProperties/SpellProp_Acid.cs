using UnityEngine;
using System.Collections;

public class SpellProp_Acid : SpellProp {



		public override void init(int effectId, GameObject SpellCaster)
		{
				base.init (effectId,SpellCaster);
				ProjectileItemId=22;
				Force=200.0f;
				BaseDamage=3;
				impactFrameStart=46;
				impactFrameEnd=50;
				spread=0;
				noOfCasts=1;
				silent=true;//no sound
				damagetype = DamageTypes.acid;
		}

}

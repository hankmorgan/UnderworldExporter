using UnityEngine;
using System.Collections;

public class SpellProp_Curse : SpellProp {
		
		//What does this spell do?


	public override void init (int effectId, GameObject SpellCaster)
	{
		base.init (effectId,SpellCaster);
		counter=10;
		impactFrameStart=40;
		impactFrameEnd=44;
		damagetype = DamageTypes.psychic;
	}
}

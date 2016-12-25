using UnityEngine;
using System.Collections;

public class SpellProp_SummonMonster : SpellProp {
		/*
		 * NPC properties for SummonMonster.
		 * TODO: Include more advanced monster properties.
		 */
	int[] NPCs={
			64,
			65,
			66,
			67,
			68,
			69,
			70,
			71,
			72,
			73,
			74,
			75,
			76,
			77,
			78,
			79,
			80,
			81,
			82,
			83,
			84,
			85,
			86,
			87,
			88,
			89,
			90,
			91,
			92,
			93,
			94,
			95,
			96,
			97,
			98,
			99,
			100,
			101,
			102,
			103,
			104,
			105,
			106,
			107,
			108,
			109,
			110,
			111,
			112,
			113,
			114,
			115,
			116,
			117,
			118,
			119,
			120,
			121
		};

	public int RndNPC;

		public override void init(int effectId, GameObject SpellCaster)
	{
		base.init (effectId,SpellCaster);
		
		//Pick a random npc from the list of npcs
		RndNPC=NPCs[Random.Range(0,NPCs.GetUpperBound(0))];
	}
}

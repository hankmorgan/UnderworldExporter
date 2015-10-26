﻿using UnityEngine;
using System.Collections;

public class SpellEffectPoison : SpellEffect {

	private int DOT; //The amount of damage per counter tick.

	public override void ApplyEffect ()
	{
		if (isNPC==false)
		{//Apply to player
			if (playerUW==null)
			{
				playerUW= this.GetComponent<UWCharacter>();
			}
			playerUW.Poisoned=true;
		}
		else
		{
			if (npc==null)
			{
				npc=this.GetComponent<NPC>();
			}
			npc.Poisoned=true;
		}

		DOT=Value/counter;//How many hp per tick gets knocked off the players/npcs health.

		base.ApplyEffect();
	}

	public override void CancelEffect ()
	{
		if (isNPC==false)
		{
			playerUW.Poisoned=false;
		}
		else
		{
			npc.Poisoned=false;
		}
		base.CancelEffect();
	}

	public override void EffectOverTime ()
	{
		if (isNPC==false)
		{
			if (playerUW.Poisoned==true)
			{
				playerUW.CurVIT=playerUW.CurVIT-DOT;
			}
		}
		else
		{
			if (npc.Poisoned==true)
			{
				npc.npc_health=npc.npc_health-DOT;
				//playerUW.CurVIT=playerUW.CurVIT-10;
			}
		}

		base.EffectOverTime ();
	}

	void Update()
	{
		if ((playerUW.Poisoned==false) && (Active==true))
		{
			CancelEffect();
		}
	}
}
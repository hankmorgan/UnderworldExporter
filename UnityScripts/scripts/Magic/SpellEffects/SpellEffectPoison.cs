using UnityEngine;
using System.Collections;
/// <summary>
/// Poison effect
/// </summary>
public class SpellEffectPoison : SpellEffect {

	///The amount of damage per counter tick.
	private int DOT; 

	///The effect is applied to an npc
	public bool isNPC;
	
	///The NPC the spell is applied to.
	private NPC npc;


	public override void ApplyEffect ()
	{
		if (isNPC==false)
		{//Apply to player
			if (GameWorldController.instance.playerUW==null)
			{
				GameWorldController.instance.playerUW= this.GetComponent<UWCharacter>();
			}
			GameWorldController.instance.playerUW.Poisoned=true;
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
			GameWorldController.instance.playerUW.Poisoned=false;
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
			if (GameWorldController.instance.playerUW.Poisoned==true)
			{
				GameWorldController.instance.playerUW.CurVIT=GameWorldController.instance.playerUW.CurVIT-DOT;
			}
		}
		else
		{
			if (npc.Poisoned==true)
			{
				npc.npc_hp=npc.npc_hp-DOT;
				//GameWorldController.instance.playerUW.CurVIT=GameWorldController.instance.playerUW.CurVIT-10;
			}
		}

		base.EffectOverTime ();
	}

	void Update()
	{
		if (isNPC==true)
		{
			if ((npc.Poisoned==false) && (Active==true))
			{
				CancelEffect();
			}
		}
		else
		{
			if ((GameWorldController.instance.playerUW.Poisoned==false) && (Active==true))
			{
				CancelEffect();
			}
		}
	}
}

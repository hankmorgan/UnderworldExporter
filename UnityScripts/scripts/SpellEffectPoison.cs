using UnityEngine;
using System.Collections;

public class SpellEffectPoison : SpellEffect {

	private int DOT; //The amount of damage per counter tick.

	public override void ApplyEffect ()
	{
		playerUW= this.GetComponent<UWCharacter>();
		///TODO: Assign a poison effect to an npc?
		/// 
		if (playerUW!=null)
			{
			playerUW.Poisoned=true;
			}
		DOT=Value/counter;//How many hp per tick gets knocked off the players health.
		base.ApplyEffect();
	}

	public override void CancelEffect ()
	{
		playerUW.Poisoned=false;
		base.CancelEffect();
	}

	public override void EffectOverTime ()
	{
		Debug.Log ("DOT on poison");
		playerUW.CurVIT=playerUW.CurVIT-10;
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

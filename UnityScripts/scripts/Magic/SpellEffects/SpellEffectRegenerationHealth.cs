using UnityEngine;
using System.Collections;
/// <summary>
/// Regenerates Health
/// </summary>
public class SpellEffectRegenerationHealth : SpellEffect {
	///The amount of health per counter tick.
	private int DOT; 

	public override void ApplyEffect ()
	{
		DOT=Value/counter;
		base.ApplyEffect ();
	}

	public override void EffectOverTime ()
	{
		base.EffectOverTime ();
		playerUW.CurVIT=playerUW.CurVIT+DOT;
		if (playerUW.CurVIT>=playerUW.MaxVIT)
		{
			playerUW.CurVIT=playerUW.MaxVIT;
		}
	}
}

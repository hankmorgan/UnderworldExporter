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
		GameWorldController.instance.playerUW.CurVIT=GameWorldController.instance.playerUW.CurVIT+DOT;
		if (GameWorldController.instance.playerUW.CurVIT>=GameWorldController.instance.playerUW.MaxVIT)
		{
			GameWorldController.instance.playerUW.CurVIT=GameWorldController.instance.playerUW.MaxVIT;
		}
	}
}

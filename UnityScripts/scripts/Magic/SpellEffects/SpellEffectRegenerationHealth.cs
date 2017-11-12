using UnityEngine;
using System.Collections;
/// <summary>
/// Regenerates Health
/// </summary>
public class SpellEffectRegenerationHealth : SpellEffect {
	///The amount of health per counter tick.
	public int DOT; 

	public override void ApplyEffect ()
	{
		DOT=Value/counter;
		base.ApplyEffect ();
	}

	public override void EffectOverTime ()
	{
		base.EffectOverTime ();
		UWCharacter.Instance.CurVIT=UWCharacter.Instance.CurVIT+DOT;
		if (UWCharacter.Instance.CurVIT>=UWCharacter.Instance.MaxVIT)
		{
			UWCharacter.Instance.CurVIT=UWCharacter.Instance.MaxVIT;
		}
	}
}

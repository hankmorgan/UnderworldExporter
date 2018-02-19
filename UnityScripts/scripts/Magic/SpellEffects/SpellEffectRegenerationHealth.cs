using UnityEngine;
using System.Collections;
/// <summary>
/// Regenerates Health
/// </summary>
public class SpellEffectRegenerationHealth : SpellEffectRegeneration {

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

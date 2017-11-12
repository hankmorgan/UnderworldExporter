using UnityEngine;
using System.Collections;

/// <summary>
/// Slow fall.
/// </summary>
public class SpellEffectSlowFall : SpellEffect {

	public override void ApplyEffect ()
	{
		base.ApplyEffect ();
		UWCharacter.Instance.isFloating=true;
	}

	void Update()
	{
		if (Active==true)
		{//Make sure the effect is continually applied.
			UWCharacter.Instance.isFloating=true;
		}
	}

	public override void CancelEffect ()
	{
		UWCharacter.Instance.isFloating=false;
		base.CancelEffect ();
	}
}

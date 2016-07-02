using UnityEngine;
using System.Collections;

/// <summary>
/// Slow fall.
/// </summary>
public class SpellEffectSlowFall : SpellEffect {

	public override void ApplyEffect ()
	{
		base.ApplyEffect ();
		playerUW.isFloating=true;
	}

	void Update()
	{
		if (Active==true)
		{//Make sure the effect is continually applied.
			playerUW.isFloating=true;
		}
	}

	public override void CancelEffect ()
	{
		playerUW.isFloating=false;
		base.CancelEffect ();
	}
}

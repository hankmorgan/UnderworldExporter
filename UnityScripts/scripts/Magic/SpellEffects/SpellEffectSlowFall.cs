using UnityEngine;
using System.Collections;

/// <summary>
/// Slow fall.
/// </summary>
public class SpellEffectSlowFall : SpellEffect {

	public override void ApplyEffect ()
	{
		base.ApplyEffect ();
		GameWorldController.instance.playerUW.isFloating=true;
	}

	void Update()
	{
		if (Active==true)
		{//Make sure the effect is continually applied.
			GameWorldController.instance.playerUW.isFloating=true;
		}
	}

	public override void CancelEffect ()
	{
		GameWorldController.instance.playerUW.isFloating=false;
		base.CancelEffect ();
	}
}

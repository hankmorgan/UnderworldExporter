using UnityEngine;
using System.Collections;
/// <summary>
/// Interact objects at a distance
/// </summary>
public class SpellEffectTelekinesis : SpellEffect {
		
	public override void ApplyEffect ()
	{
		base.ApplyEffect();
		GameWorldController.instance.playerUW.isTelekinetic=true;
	}

	public override void CancelEffect ()
	{
		base.CancelEffect ();
		GameWorldController.instance.playerUW.isTelekinetic=false;
	}

	void Update()
	{//Keep the effect applied.
		if (Active)
		{
			GameWorldController.instance.playerUW.isTelekinetic=true;
		}
	}

}

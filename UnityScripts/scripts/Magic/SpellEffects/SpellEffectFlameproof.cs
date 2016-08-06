using UnityEngine;
using System.Collections;
/// <summary>
/// Player becomes fireproof.
/// </summary>
public class SpellEffectFlameproof : SpellEffect {

	public override void ApplyEffect ()
	{
		GameWorldController.instance.playerUW.FireProof=true;
		base.ApplyEffect ();
	}

	void Update()
	{
		GameWorldController.instance.playerUW.FireProof=true;
	}

	public override void CancelEffect ()
	{
		GameWorldController.instance.playerUW.FireProof=false;
		base.CancelEffect ();
	}

}

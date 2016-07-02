using UnityEngine;
using System.Collections;
/// <summary>
/// Player becomes fireproof.
/// </summary>
public class SpellEffectFlameproof : SpellEffect {

	public override void ApplyEffect ()
	{
		playerUW.FireProof=true;
		base.ApplyEffect ();
	}

	void Update()
	{
		playerUW.FireProof=true;
	}

	public override void CancelEffect ()
	{
		playerUW.FireProof=false;
		base.CancelEffect ();
	}

}

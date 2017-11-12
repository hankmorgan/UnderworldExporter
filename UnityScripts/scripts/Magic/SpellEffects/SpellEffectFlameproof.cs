using UnityEngine;
using System.Collections;
/// <summary>
/// Player becomes fireproof.
/// </summary>
public class SpellEffectFlameproof : SpellEffect {

	public override void ApplyEffect ()
	{
		UWCharacter.Instance.FireProof=true;
		base.ApplyEffect ();
	}

	void Update()
	{
		UWCharacter.Instance.FireProof=true;
	}

	public override void CancelEffect ()
	{
		UWCharacter.Instance.FireProof=false;
		base.CancelEffect ();
	}

}

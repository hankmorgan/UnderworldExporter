using UnityEngine;
using System.Collections;
/// <summary>
/// Interact objects at a distance
/// </summary>
public class SpellEffectTelekinesis : SpellEffect {
		
	public override void ApplyEffect ()
	{
		base.ApplyEffect();
		UWCharacter.Instance.isTelekinetic=true;
	}

	public override void CancelEffect ()
	{
		base.CancelEffect ();
		UWCharacter.Instance.isTelekinetic=false;
	}

	void Update()
	{//Keep the effect applied.
		if (Active)
		{
			UWCharacter.Instance.isTelekinetic=true;
		}
	}

}

using UnityEngine;
using System.Collections;
/// <summary>
/// Makes the player move fast.
/// </summary>
public class SpellEffectSpeed : SpellEffect {

	///How much the players motion is increased by
	public float speedMultiplier;

	public override void ApplyEffect ()
		{
			UWCharacter.Instance.speedMultiplier=speedMultiplier;
			base.ApplyEffect ();
		}

	void Update()
	{
		if(Active)
		{
		UWCharacter.Instance.speedMultiplier=speedMultiplier;			
		}			
	}

	public override void CancelEffect ()
	{
		UWCharacter.Instance.speedMultiplier=1.0f;
		base.CancelEffect ();		
	}
}

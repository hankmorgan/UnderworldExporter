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
			UWCharacter.Instance.isSpeeding=true;
			base.ApplyEffect ();
		}

	void Update()
	{
		if(Active)
		{
		UWCharacter.Instance.speedMultiplier=speedMultiplier;
		UWCharacter.Instance.isSpeeding=true;
		}			
	}

	public override void CancelEffect ()
	{
		UWCharacter.Instance.speedMultiplier=1.0f;
		UWCharacter.Instance.isSpeeding=false;
		base.CancelEffect ();		
	}
}

using UnityEngine;
using System.Collections;
/// <summary>
/// Allows the player to walk on water
/// </summary>
public class SpellEffectWaterWalk : SpellEffect {


	void Update()
	{
		if (Active)
		{
			UWCharacter.Instance.isWaterWalking=true;
		}
	}

	public override void ApplyEffect ()
	{
		
		if (UWCharacter.Instance==null)
		{
			UWCharacter.Instance= this.GetComponent<UWCharacter>();
		}
		UWCharacter.Instance.isWaterWalking=true;
		
		base.ApplyEffect();
	}

	public override void CancelEffect ()
	{
		UWCharacter.Instance.isWaterWalking=false;
		base.CancelEffect();
	}
}

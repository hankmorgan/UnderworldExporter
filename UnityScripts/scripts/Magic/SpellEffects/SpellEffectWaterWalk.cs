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
			playerUW.isWaterWalking=true;
		}
	}

	public override void ApplyEffect ()
	{
		
		if (playerUW==null)
		{
			playerUW= this.GetComponent<UWCharacter>();
		}
		playerUW.isWaterWalking=true;
		
		base.ApplyEffect();
	}

	public override void CancelEffect ()
	{
		playerUW.isWaterWalking=false;
		base.CancelEffect();
	}
}

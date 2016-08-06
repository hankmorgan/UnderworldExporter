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
			GameWorldController.instance.playerUW.isWaterWalking=true;
		}
	}

	public override void ApplyEffect ()
	{
		
		if (GameWorldController.instance.playerUW==null)
		{
			GameWorldController.instance.playerUW= this.GetComponent<UWCharacter>();
		}
		GameWorldController.instance.playerUW.isWaterWalking=true;
		
		base.ApplyEffect();
	}

	public override void CancelEffect ()
	{
		GameWorldController.instance.playerUW.isWaterWalking=false;
		base.CancelEffect();
	}
}

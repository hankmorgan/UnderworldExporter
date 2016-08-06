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
			GameWorldController.instance.playerUW.speedMultiplier=speedMultiplier;
			base.ApplyEffect ();
		}

	void Update()
	{
		if(Active)
		{
		GameWorldController.instance.playerUW.speedMultiplier=speedMultiplier;			
		}			
	}

	public override void CancelEffect ()
	{
		GameWorldController.instance.playerUW.speedMultiplier=1.0f;
		base.CancelEffect ();		
	}
}

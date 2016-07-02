using UnityEngine;
using System.Collections;
/// <summary>
/// Makes you jump higher.
/// </summary>
public class SpellEffectLeap : SpellEffect {

	public override void ApplyEffect ()
	{
		if (playerUW==null)
		{
			playerUW= this.GetComponent<UWCharacter>();
		}
		playerUW.isLeaping=true;
		base.ApplyEffect ();
	}


	void Update()
	{
		if (Active)
		{//Maintain the effect
			playerUW.isLeaping=true;
		}
	}

	public override void CancelEffect ()
	{
		playerUW.isLeaping=false;
		base.CancelEffect ();
	}
}

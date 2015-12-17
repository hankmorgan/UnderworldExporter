using UnityEngine;
using System.Collections;

public class SpellEffectLeap : SpellEffect {
	//Makes you jump higher.

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

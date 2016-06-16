using UnityEngine;
using System.Collections;

public class SpellEffectSpeed : SpellEffect {

//Either slows down enemies or makes the player faster?
	public float speedMultiplier;

	public override void ApplyEffect ()
		{
			playerUW.speedMultiplier=speedMultiplier;
			base.ApplyEffect ();
		}


	void Update()
	{
		if(Active)
		{
		playerUW.speedMultiplier=speedMultiplier;			
		}			
	}

	public override void CancelEffect ()
	{
		playerUW.speedMultiplier=1.0f;
		base.CancelEffect ();		
	}

}

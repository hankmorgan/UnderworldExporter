using UnityEngine;
using System.Collections;
/// <summary>
/// Makes you jump higher.
/// </summary>
public class SpellEffectLeap : SpellEffect {

	public override void ApplyEffect ()
	{
		if (GameWorldController.instance.playerUW==null)
		{
			GameWorldController.instance.playerUW= this.GetComponent<UWCharacter>();
		}
		GameWorldController.instance.playerUW.isLeaping=true;
		base.ApplyEffect ();
	}


	void Update()
	{
		if (Active)
		{//Maintain the effect
			GameWorldController.instance.playerUW.isLeaping=true;
		}
	}

	public override void CancelEffect ()
	{
		GameWorldController.instance.playerUW.isLeaping=false;
		base.CancelEffect ();
	}
}

using UnityEngine;
using System.Collections;
/// <summary>
/// Makes you jump higher.
/// </summary>
public class SpellEffectLeap : SpellEffect {

	public override void ApplyEffect ()
	{
		if (UWCharacter.Instance==null)
		{
			UWCharacter.Instance= this.GetComponent<UWCharacter>();
		}
		UWCharacter.Instance.isLeaping=true;
		base.ApplyEffect ();
	}


	void Update()
	{
		if (Active)
		{//Maintain the effect
			UWCharacter.Instance.isLeaping=true;
		}
	}

	public override void CancelEffect ()
	{
		UWCharacter.Instance.isLeaping=false;
		base.CancelEffect ();
	}
}

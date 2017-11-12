using UnityEngine;
using System.Collections;
/// <summary>
/// For iron skin, thick skin and resist blows etc that modify damage resistance. (only the strongest applies)
/// </summary>
public class SpellEffectResistance : SpellEffect {

	public override void ApplyEffect ()
	{
		UWCharacter.Instance.Resistance=Value;
		base.ApplyEffect ();
	}

	public override void CancelEffect ()
	{
		UWCharacter.Instance.Resistance=0;
		base.CancelEffect ();
	}

	void Update()
	{//Keeps the value at it's highest possible
		if (Active)
		{
			if (UWCharacter.Instance.Resistance<Value)
			{
				UWCharacter.Instance.Resistance=Value;
			}
		}
	}

}

using UnityEngine;
using System.Collections;
/// <summary>
/// For iron skin, thick skin and resist blows etc that modify damage resistance. (only the strongest applies)
/// </summary>
public class SpellEffectResistance : SpellEffect {

	public override void ApplyEffect ()
	{
		GameWorldController.instance.playerUW.Resistance=Value;
		base.ApplyEffect ();
	}

	public override void CancelEffect ()
	{
		GameWorldController.instance.playerUW.Resistance=0;
		base.CancelEffect ();
	}

	void Update()
	{//Keeps the value at it's highest possible
		if (Active)
		{
			if (GameWorldController.instance.playerUW.Resistance<Value)
			{
				GameWorldController.instance.playerUW.Resistance=Value;
			}
		}
	}

}

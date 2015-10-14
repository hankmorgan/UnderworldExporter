using UnityEngine;
using System.Collections;

public class SpellEffectLight : SpellEffect {

	public override void ApplyEffect ()
	{
		if (LightSource.MagicBrightness<Value)
		{
			LightSource.MagicBrightness=Value;
		}
		base.ApplyEffect();
	}

	public override void CancelEffect ()
	{
		LightSource.MagicBrightness=0;//The next frame of other magic lights will set the nex max magic brightness.
		base.CancelEffect();
	}

	void Update()
	{
		//To make sure the brightness is always correct.
		if (Active==true)
		{
			if (LightSource.MagicBrightness<Value)
			{
				LightSource.MagicBrightness=Value;
			}
		}
	}
}

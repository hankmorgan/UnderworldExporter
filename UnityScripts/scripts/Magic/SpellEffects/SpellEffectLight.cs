using UnityEngine;
using System.Collections;
/// <summary>
/// Creates a light source around the player
/// </summary>
public class SpellEffectLight : SpellEffect {

	public override void ApplyEffect ()
	{
		if (LightSource.MagicBrightness<Value)
		{
			LightSource.MagicBrightness=Value;			
		}
		UWCharacter.Instance.playerInventory.UpdateLightSources();
		base.ApplyEffect();
	}

	public override void CancelEffect ()
	{
		LightSource.MagicBrightness=0;//The next frame of other magic lights will set the next max magic brightness.
		UWCharacter.Instance.playerInventory.UpdateLightSources();
		base.CancelEffect();
	}


	public virtual void Update()
	{
		//To make sure the brightness is always correct.
		if (Active==true)
		{
			if (LightSource.MagicBrightness<Value)
			{
				LightSource.MagicBrightness=Value;
				UWCharacter.Instance.playerInventory.UpdateLightSources();
			}
		}
	}
}

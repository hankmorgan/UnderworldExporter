using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;
/// <summary>
/// Add a Greyscale effect to the player vision.
/// Increases the light range
/// </summary>
public class SpellEffectNightVision : SpellEffectLight {
	public static bool inUse;
	public Grayscale gs;

	public override void ApplyEffect ()
	{
		if (inUse==false)
		{
			gs = Camera.main.gameObject.AddComponent<Grayscale>();	
			gs.shader=Shader.Find ("Hidden/Grayscale Effect");
		}
		
		base.ApplyEffect ();
	}

	public override void Update ()
	{
		if (Active)
		{
			inUse=true;
		}
		base.Update ();
	}

	public override void CancelEffect ()
	{
		if (gs!=null)
		{
				Destroy (gs);		
		}
		inUse=false;
		base.CancelEffect ();
	}
}

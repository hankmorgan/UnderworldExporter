using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;

public class SpellEffectHallucination : SpellEffect {
	private Grayscale gs; 
	public override void ApplyEffect ()
	{
		
		gs = Camera.main.gameObject.AddComponent<Grayscale>();	
		gs.shader=Shader.Find ("Hidden/Grayscale Effect");
		//Pick a random palette to use
			gs.textureRamp = (Texture)Resources.Load("Palettes/palette_000" + Random.Range(0,7));
			base.ApplyEffect ();
	}

	public override void EffectOverTime ()
	{
		gs.textureRamp = (Texture)Resources.Load("Palettes/palette_000" + Random.Range(0,7));				
		base.EffectOverTime ();
	}

	public override void CancelEffect ()
	{
		if (gs!=null)
		{
				Destroy (gs);		
		}
		base.CancelEffect ();
	}
}

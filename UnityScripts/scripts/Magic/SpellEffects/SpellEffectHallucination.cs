using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;

/// <summary>
/// Winners don't take drugs.
/// </summary>
public class SpellEffectHallucination : SpellEffect {
	///Greyscale filter used to apply colour palette on	
	private Grayscale gs; 
	public override void ApplyEffect ()
	{		
		gs = Camera.main.gameObject.AddComponent<Grayscale>();	
			gs.shader=GameWorldController.instance.greyScale;//Shader.Find ("Hidden/Grayscale Effect");
		//Pick a random palette to use
			//	gs.textureRamp =  (Texture)Resources.Load(_RES +"/Palettes/palette_000" + Random.Range(0,7));
			gs.textureRamp = GameWorldController.instance.palLoader.PaletteToImage(Random.Range(0,7));
			base.ApplyEffect ();
	}

		/// <summary>
		/// Randomly changes the palette use on each tick
		/// </summary>
	public override void EffectOverTime ()
	{
		//gs.textureRamp = (Texture)Resources.Load(_RES +"/Palettes/palette_000" + Random.Range(0,7));				
		gs.textureRamp = GameWorldController.instance.palLoader.PaletteToImage(Random.Range(0,7));
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

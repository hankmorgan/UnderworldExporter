using UnityEngine;
using System.Collections;

public class TileContactWater : TileContact {

	protected override void TileContactEvent (ObjectInteraction obj, Vector3 position)
	{
		if (obj.item_id!=453)
		{
			GameObject splash = Impact.SpawnHitImpact(453, position, 36, 40);

			if (IsObjectDestroyable(obj))
			{	
				if (ObjectInteraction.PlaySoundEffects)
				{
					splash.GetComponent<ObjectInteraction>().aud.clip=GameWorldController.instance.getMus().SoundEffects[MusicController.SOUND_EFFECT_SPLASH_1];
					splash.GetComponent<ObjectInteraction>().aud.Play();
				}	
				DestroyObject(obj);
			}	
		}
	}
}
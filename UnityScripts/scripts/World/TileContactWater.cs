using UnityEngine;
using System.Collections;

/// <summary>
/// Controls throwing objects into water
/// </summary>
public class TileContactWater : TileContact {

    protected override void TileContactEvent (ObjectInteraction obj, Vector3 position)
	{
        switch (obj.item_id)
        {
            case 453://A water splash
                return;              
        }
        ObjectHitsWater(obj, position);
    }

    private void ObjectHitsWater(ObjectInteraction obj, Vector3 position)
    {
        if (IsObjectDestroyable(obj))
        {
            GameObject splash = Impact.SpawnHitImpact(453,position, splashanimstart(), splashanimstart()+4);
            if (splash!=null)
            {
                if (ObjectInteraction.PlaySoundEffects)
                {
                    splash.GetComponent<ObjectInteraction>().aud.clip = MusicController.instance.SoundEffects[MusicController.SOUND_EFFECT_SPLASH_1];
                    splash.GetComponent<ObjectInteraction>().aud.Play();
                }
            }
            ObjectInteraction.DestroyObjectFromUW(obj);
        }
    }

    /// <summary>
    /// Gets the appropiate water splash
    /// </summary>
    /// <returns></returns>
    int splashanimstart()
    {
        switch(_RES)
        {
            case GAME_UW2:
                return 34;
            default:
                return 36;
        }
    }

}
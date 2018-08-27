using UnityEngine;
using System.Collections;

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
            if (ObjectInteraction.PlaySoundEffects)
            {
                splash.GetComponent<ObjectInteraction>().aud.clip = MusicController.instance.SoundEffects[MusicController.SOUND_EFFECT_SPLASH_1];
                splash.GetComponent<ObjectInteraction>().aud.Play();
            }
            DestroyObject(obj);
        }
    }

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
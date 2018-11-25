using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Special game effects
/// </summary>
/// Quality appears to control what happens
///     q=1 to 3, 9 appear to do nothing (at least when trap is off map)
///     q=2 plays the guardian laughing sound effect.
///     q=4 is an earthquake
///     q=5 is a red flash 
///     q=6 is a black flash
///     q=7 is an orange flash
///     q=8 is another black flash
/// Owner controls how long the earthquake effect lasts for.
/// 
public class a_special_effect_trap : trap_base {

    public override void ExecuteTrap(object_base src, int triggerX, int triggerY, int State)
    {
        switch (quality)
        {
            case 2://guardian laugh
                {
                    UWCharacter.Instance.aud.clip = MusicController.instance.SoundEffects[MusicController.SOUND_EFFECT_GUARDIAN_LAUGH_1];
                    UWCharacter.Instance.aud.Play();
                    break;
                }
            case 4:
                //Call a camera shake effect
                //CameraShake.instance.shakeDuration = owner * 0.2f;
                CameraShake.instance.ShakeEarthQuake(owner * 0.05f);
                break;
            case 5:
                StartCoroutine(Flash("FadeToRed"));
                break;
            default:
                Debug.Log("unimplemented special effect " + this.name + " q=" +  quality);
                break;
        }        
    }

    /// <summary>
    /// Flashes the screen.
    /// </summary>
    /// <param name="anim"></param>
    /// <returns></returns>
    IEnumerator Flash(string anim)
    {
        UWHUD.instance.EnableDisableControl(UWHUD.instance.CutsceneFullPanel.gameObject, true);
        UWHUD.instance.CutScenesSmall.anim.SetAnimation = anim;
        yield return new WaitForSeconds(0.2f);
        UWHUD.instance.CutScenesSmall.anim.SetAnimation = "Anim_Base";
        UWHUD.instance.EnableDisableControl(UWHUD.instance.CutsceneFullPanel.gameObject, false);        
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class a_splash : object_base {

    //public AudioSource aud;
	// Use this for initialization

    public override void InitSound()
    {
        base.InitSound();

        //aud = this.GetComponent<AudioSource>();
        objInt().aud.clip = MusicController.instance.SoundEffects[MusicController.SOUND_EFFECT_SPLASH_1];
        objInt().aud.playOnAwake = false;
        objInt().aud.loop = true;
        objInt().aud.volume = 0.1f;
        objInt().aud.maxDistance = 10f;
        objInt().aud.rolloffMode = AudioRolloffMode.Linear;
        objInt().aud.Play();
    }

}

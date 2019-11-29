using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class a_splash : object_base {

    public AudioSource aud;
	// Use this for initialization

    protected override void Start()
    {
        base.Start();
        aud = this.GetComponent<AudioSource>();
        aud.clip = MusicController.instance.SoundEffects[MusicController.SOUND_EFFECT_SPLASH_1];
        aud.playOnAwake = false;
        aud.loop = true;        
        aud.volume = 0.1f;
        aud.maxDistance = 10f;
        aud.rolloffMode = AudioRolloffMode.Linear;
        aud.Play();
    }


}

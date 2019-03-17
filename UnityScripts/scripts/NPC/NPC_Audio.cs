using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controller for playing npc audio effects.
/// </summary>
public class NPC_Audio : UWClass {

    public static void playSound(NPC npc, int clip)
    {
        npc.gameObject.GetComponent<AudioSource>().PlayOneShot(MusicController.instance.SoundEffects[clip]);
    }

    /// <summary>
    /// Sound to play when moving.
    /// </summary>
    public static void WalkingSound(NPC npc)
    {
        playSound(npc, MusicController.SOUND_EFFECT_FOOT_1);
    }

    public static void IdleSound(NPC npc)
    {
        playSound(npc, MusicController.SOUND_EFFECT_GUARDIAN_LAUGH_1);
    }

    public static void AngeredSound(NPC npc)
    {
        playSound(npc, MusicController.SOUND_EFFECT_GUARDIAN_LAUGH_2);
    }

    public static void DeathSound(NPC npc)
    {
        playSound(npc, MusicController.SOUND_EFFECT_NPC_DEATH_1);
    }

    public static void SpellCastSound(NPC npc)
    {
        playSound(npc, MusicController.SOUND_EFFECT_ZAP);
    }


}

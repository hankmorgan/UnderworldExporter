using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controller for playing npc audio effects.
/// </summary>
public class NPC_Audio : UWClass {

    public AudioSource audMovement; //AudioSource for walking & running based actions.
    public AudioSource audCombat; //Audiosource for combat actions performed by the npc
    public AudioSource audVoice; //Audiosource for spoken actions. Eg alerts and barks. Idle noises.
    public AudioSource audPhysical; //AudioSource for impacts on the NPC. Eg if the player hits the npc the impact sound will come from here.


    public NPC npc;
    public short SoundWalk = -1;
    public short SoundIdle = -1;
    public short SoundAngered = -1;
    public short SoundDeath 
        {
            get
            {
                switch ((NPC.NPCCategory)GameWorldController.instance.objDat.critterStats[npc.item_id - 64].Category)
                {

                //Set the death sound effect to use
                //Category 	Ethereal = 0x00 (Ethereal critters like ghosts, wisps, and shadow beasts), 
                //Humanoid = 0x01 (Humanlike non-thinking forms like lizardmen, trolls, ghouls, and mages),
                //Flying = 0x02 (Flying critters like bats and imps), 
                //Swimming = 0x03 (Swimming critters like lurkers), 
                //Creeping = 0x04 (Creeping critters like rats and spiders), 
                //Crawling = 0x05 (Crawling critters like slugs, worms, reapers (!), and fire elementals (!!)),
                //EarthGolem = 0x11 (Only used for the earth golem),
                //Human = 0x51 (Humanlike thinking forms like goblins, skeletons, mountainmen, fighters, outcasts, and stone and metal golems).

                //case 0x0:
                //case 0x02:
                case NPC.NPCCategory.ethereal:
                    case NPC.NPCCategory.flying:
                       return MusicController.SOUND_EFFECT_NPC_DEATH_3; 
                    //case 0x03:
                    case NPC.NPCCategory.swimming:
                        return MusicController.SOUND_EFFECT_SPLASH_1; 
                    //case 0x04:
                    //case 0x05:
                    case NPC.NPCCategory.crawling:
                    case NPC.NPCCategory.creeping:
                        return  MusicController.SOUND_EFFECT_NPC_DEATH_2; 
                    //case 0x11:
                    case NPC.NPCCategory.golem:
                        return  MusicController.SOUND_EFFECT_RUMBLE; 
                    //case 0x01:
                    case NPC.NPCCategory.human:
                    case NPC.NPCCategory.humanoid:
                    default:
                        return MusicController.SOUND_EFFECT_NPC_DEATH_1; 
                }
            }
        }
    public short SoundSpellCast = -1;
    public short SoundNPCMissed //= -1; //Sound when NPC is swung at by the play and the hit does not land
        {
            get
            {
                switch (Random.Range(0,2))
                {
                    case 0:
                        return MusicController.SOUND_EFFECT_MELEE_MISS_1;
                    case 1:
                    default:
                        return MusicController.SOUND_EFFECT_MELEE_MISS_2;
                }            
            }
        }

    //public AudioSource aud;


    public NPC_Audio(NPC npcInstance, AudioSource audMovementInstance, AudioSource audCombatInstance, AudioSource audVoiceInstance, AudioSource audPhysicalInstance)
    {
        npc = npcInstance;
        audPhysical = audPhysicalInstance;
        audMovement = audMovementInstance;
        audCombat = audCombatInstance;
        audVoice = audVoiceInstance;
        //SoundWalk = MusicController.SOUND_EFFECT_FOOT_1;
    }


    /// <summary>
    /// PLay the sound clip on the npc
    /// </summary>
    /// <param name="npc"></param>
    /// <param name="clip"></param>
    public static void playSound(AudioSource source, int clip)
    {
        if (ObjectInteraction.PlaySoundEffects)
        {
            if (clip >= 0)
            {
                source.PlayOneShot(MusicController.instance.SoundEffects[clip]);
            }
        }      
    }

    /// <summary>
    /// PLay the sound clip on the npc
    /// </summary>
    /// <param name="npc"></param>
    /// <param name="clip"></param>
    public static void playTestSound(AudioSource source, int clip)
    {
        if (ObjectInteraction.PlaySoundEffects)
        {
            if (clip >= 0)
            {
                source.PlayOneShot(MusicController.instance.TestAudioClips[clip]);
            }
        }
    }



    /// <summary>
    /// Sound to play when moving.
    /// </summary>
    public virtual void PlayWalkingSound_1()
    {
        playSound(this.npc.audMovement, SoundWalk);// MusicController.SOUND_EFFECT_FOOT_1);
    }

    /// <summary>
    /// Sound to play when moving.
    /// </summary>
    public virtual void PlayWalkingSound_2()
    {
        playSound(this.npc.audMovement, SoundWalk);// MusicController.SOUND_EFFECT_FOOT_2);
    }


    public virtual void PlayIdleSound()
    {
        playTestSound(this.npc.audVoice, Random.Range(0,6));// MusicController.SOUND_EFFECT_GUARDIAN_LAUGH_1);
    }

    public virtual void PlayAngeredSound()
    {
        playSound(this.npc.audVoice, SoundAngered);// MusicController.SOUND_EFFECT_GUARDIAN_LAUGH_2);
    }

    public virtual void PlayDeathSound()
    {
        playSound(this.npc.audVoice, SoundDeath);//  MusicController.SOUND_EFFECT_NPC_DEATH_1);
    }

    public virtual void PlaySpellCastSound()
    {
        playSound(this.npc.audCombat, SoundSpellCast); //MusicController.SOUND_EFFECT_ZAP);
    }

    public virtual void PlayCombatMissed()
    {
        playSound(this.npc.audPhysical, SoundNPCMissed);
    }

    public virtual void PlayCombatHit(int sound)
    {
        playSound(this.npc.audPhysical, sound);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


/// <summary>
/// Class for storing audio data for NPCs
/// </summary>
public class NPC_Audio_Data : Loader {

    //For each of the 64 npc classes. 
    //Store a default sound set. (Npc whoami = 0)
    //store a set for up to 256 npc whoami (barks only) //Future proof in case I ever have unique voices for different NPCs of the same class.

    AudioClip WalkSoundLeft; //A class can have only set of walk sounds.
    AudioClip WalkSoundRight; //A class can have only set of walk sounds.
    AudioClip DeathSound; //A class can have only one death sound.
    AudioClip[,] IdleSounds= new AudioClip[256,4]; //A class could have 4 idle sounds per whoami. [NPC_WHO_AM_I, BARK No]
    bool[] loaded = new bool[256]; //Flag to show that specific whoami has been loaded into this dataset
    int ThisItemId;

    /// <summary>
    /// Initialise the NPC audio data for the specified item Id
    /// </summary>
    /// <param name="item_id"></param>
    public NPC_Audio_Data(int item_id)
    {
        ThisItemId = item_id;
        //Load the default class data
        LoadDefaultData();
        AddWhoAmI(0); //Add the voice set for npc whoami =0
        loaded[0] = true;
    }

    /// <summary>
    /// When a npc of a whoami not equal to zero is loaded checked to see if there is a sound bank for them.
    /// </summary>
    /// <param name="who_ami"></param>
    public void AddWhoAmI(int who_ami)
    {
        if (loaded[who_ami] != true)
        {//Load data into my sound bank if not already loaded
            //If exists [uw path]\sound\npc\[item_id]\[who_ami] 
            string dir = BasePath + "sound\\npc\\" + ThisItemId + "\\" + who_ami + "\\";
            if (Directory.Exists(dir))
            {
                string[] files = Directory.GetFiles(dir, "*.ogg"); //ogg files only at the moment.
                for (int i=0; i<=files.GetUpperBound(0);i++)
                {
                    switch(files[i].ToUpper())
                    {
                        case "IDLE0.OGG"://idle track 0
                            LoadIdleClip(files[i], who_ami, 0);break;
                        case "IDLE1.OGG"://idle track 1
                            LoadIdleClip(files[i], who_ami, 1); break;
                        case "IDLE2.OGG"://idle track 2
                            LoadIdleClip(files[i], who_ami, 2); break;
                        case "IDLE3.OGG"://idle track 3
                            LoadIdleClip(files[i], who_ami, 3); break;
                    }
                }
            }
            loaded[who_ami] = true;//Flag true so as to not retry loading again.
        }  
    }

    /// <summary>
    /// Loads the idle sound into the voice bank.
    /// </summary>
    /// <param name="file"></param>
    /// <param name="whoami"></param>
    /// <param name="index"></param>
    /// <returns></returns>
    IEnumerator LoadIdleClip(string file, int whoami, int index)
    {
        if (File.Exists(Path))
        {
            using (WWW download = new WWW("file://" + Path))
            {
                yield return download;                
                IdleSounds[whoami,index] = download.GetAudioClip(false);
            }
        }
    }


    /// <summary>
    /// Load default sounds into whoami=0
    /// </summary>
    public void LoadDefaultData()
    {
        //default Files are. 
        //Walk 1 & 2.
        //Death
        //These are not overriden as they are class specific

    }

    /// <summary>
    /// Return the default walk sound for this npc class.
    /// </summary>
    /// <returns></returns>
    public AudioClip GetWalk(bool step)
    {
        if (step)
        {
            return WalkSoundLeft;
        }
        else
        {
            return WalkSoundRight;
        }
        
    }

    /// <summary>
    /// Set the walk sound for this class.
    /// </summary>
    /// <param name="value"></param>
    public void SetWalk(AudioClip clip, bool step)
    {
        if (step)
        {
            WalkSoundLeft = clip;
        }
        else
        {
            WalkSoundRight = clip;
        }        
    }

    /// <summary>
    /// Set the death sound for this class
    /// </summary>
    /// <param name="clip"></param>
    public void SetDeath(AudioClip clip)
    {
        DeathSound = clip;
    }

    /// <summary>
    /// Get the death sound for this class.
    /// </summary>
    /// <returns></returns>
    public AudioClip GetDeath()
    {
        return DeathSound;
    }

    /// <summary>
    /// Returns a random idle sound to play.
    /// </summary>
    /// <param name="whoami"></param>
    /// <returns></returns>
    public AudioClip GetIdle(int whoami)
    {
        int rndclip = Random.Range(0, 4);
        if (IdleSounds[whoami, rndclip] != null)
        {
            return IdleSounds[whoami, rndclip];
        }
        else
        {
            return IdleSounds[0, rndclip];
        }
    }

    public void SetIdle(int whoami, int clipno, AudioClip clip)
    {
        IdleSounds[whoami, clipno] = clip;
    }

}

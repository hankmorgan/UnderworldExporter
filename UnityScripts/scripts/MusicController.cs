using UnityEngine;
using System.Collections;

public class MusicController : MonoBehaviour {

	//In order of priority
	private const int MUS_DEATH=10;
	private const int MUS_MAP=9;
	private const int MUS_INJURED=8;
	private const int MUS_FLEEING=7;
	private const int MUS_COMBAT=6;
	private const int MUS_WEAPON=4;
	private const int MUS_IDLE=1;

	//One offs? Stop update while playing these?
	private const int MUS_INTRO=0;
	private const int MUS_VICTORY=5;

	public static float LastAttackCounter=0.0f;//To track the end of combat.

	//What I am currently playing.
	public bool Combat;
	public bool InMap;
	public bool WeaponDrawn;
	public bool Injured;
	public bool Death;
	public bool Fleeing;

	public int playing;

	public bool SpecialClip;//One offs
	// Use this for initialization
	public AudioClip[] MainTrackList=new AudioClip[12];
	//public string[] MainTrackList
	//= {"UW01","UW02","UW03","UW04","UW05","UW06","UW07","UW10","UW11","UW12","UW13","UW15"};

	public int[] IntroTracks={0};
	public int[] IdleTracks={1,2,3};
	public int[] CombatTracks={4,5};
	public int[] InjuredTracks={6};
	public int[] WeaponTracks={7};
	public int[] VictoryTracks={8};
	public int[] DeathTracks = {9};
	public int[] FleeingTracks={10};
	public int[] MapTracks={11};
	private bool StopProcessing;
	private AudioSource Aud;

	public UWCharacter playerUW;

	void Start () {
		Aud= this.GetComponent<AudioSource>();
		//Aud.Play();
	}
	
	// Update is called once per frame
	void Update () {
		if (LastAttackCounter <=0)
		{
			Combat=false;
			//Fleeing=false;
		}
		else
		{
			LastAttackCounter -=Time.deltaTime;
			Combat=true;
		}
		if ((playerUW.CurVIT<=10) && (Combat==true))
		{
			Injured=true;
		}
		else
		{
			Injured=false;
		}
		if ((Combat==true) && (WeaponDrawn==false))
		{
			Fleeing=true;
		}
		else
		{
			Fleeing=false;
		}
		if (SpecialClip==true)
		{
			if (Aud.isPlaying==false)
			{
				SpecialClip=false;
			}
			return; //don#t interupt a special clip. Eg fanfare in combate
		}
		if (Aud.isPlaying==false)
		{
			playing=-1; //Force next track;
		}


		//Get the highest priorty tracklist to play.
		switch (GetMaxPriority())
		{
			case MUS_DEATH:
				ChangeTracklist(DeathTracks,MUS_DEATH);break;
			case MUS_MAP:
				ChangeTracklist(MapTracks,MUS_MAP);break;
			case MUS_COMBAT:
				ChangeTracklist(CombatTracks,MUS_COMBAT);break;
			case MUS_INJURED:
				ChangeTracklist(InjuredTracks,MUS_INJURED);break;
			case MUS_FLEEING:
				ChangeTracklist(FleeingTracks,MUS_FLEEING);break;
			case MUS_WEAPON:
				ChangeTracklist(WeaponTracks,MUS_WEAPON);break;
			case MUS_IDLE:
				ChangeTracklist(IdleTracks,MUS_IDLE);break;

		}
	}


	void PlayRandom(int[] tracklist)
	{//Pick a random track to play from the selecte list.

		int rnd = Random.Range (0,tracklist.GetUpperBound(0)+1);
		//Debug.Log (rnd);
	//	Debug.Log ("Picking + " + "Music//" + MainTrackList[rnd]);
		//Debug.Log ("playing " + MainTrackList[tracklist[rnd]].name);
		Aud.clip=MainTrackList[tracklist[rnd]];
		Aud.Play();

	}

	public void Stop()
	{
		Aud.Stop ();
	}

	private int GetMaxPriority()
	{//Get the current state that is active and has the highest priority.
		if (Death)
		{
			return MUS_DEATH;
		}
		else if (InMap)
		{
			return MUS_MAP;
		}
		else if (Injured)
		{
			return MUS_INJURED;
		}
		else if (Fleeing)
		{
			return MUS_FLEEING;
		}
		else if (Combat)
		{
			return MUS_COMBAT;
		}
		else if (WeaponDrawn)
		{
			return MUS_WEAPON;
		}
		else
		{
			return MUS_IDLE;
		}
	}

	void ChangeTracklist(int[] newTrackList, int playingMode)
	{
		if (playing!=playingMode)
		{
			PlayRandom(newTrackList);
			playing=playingMode;
		}
	}

	public void PlaySpecialClip(int[] newTrackList)
	{
		PlayRandom (newTrackList);
		SpecialClip=true;
		playing=-1;
	}

}



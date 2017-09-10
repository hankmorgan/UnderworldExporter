using UnityEngine;
using System.Collections;

/// <summary>
/// The music controller. Updates music tracks to play based on the state of the game world and player.
/// </summary>
public class MusicController : UWEBase {


		public const int SOUND_EFFECT_FOOT_1=1;
		public const int SOUND_EFFECT_FOOT_2=2;
		public const int SOUND_EFFECT_PUNCH_1=3;
		public const int SOUND_EFFECT_PUNCH_2=4;
		public const int SOUND_EFFECT_WATER_LAND_1=5;
		public const int SOUND_EFFECT_NPC_DEATH_1=6;
		public const int SOUND_EFFECT_MELEE_HIT_1=7;
		public const int SOUND_EFFECT_MELEE_HIT_2=8;
		public const int SOUND_EFFECT_RANGED_STRIKE=9;
		public const int SOUND_EFFECT_MELEE_MISS_1=10;
		public const int SOUND_EFFECT_DOOR_MOVE=11;
		public const int SOUND_EFFECT_DOOR_FINISH=12;
		public const int SOUND_EFFECT_RUMBLE=18;
		public const int SOUND_EFFECT_PORTCULLIS=20;
		public const int SOUND_EFFECT_SPLASH_1=24;
		public const int SOUND_EFFECT_SPLASH_2=25;
		public const int SOUND_EFFECT_MELEE_MISS_2=28;
		public const int SOUND_EFFECT_ICE_SLIDE=29;
		public const int SOUND_EFFECT_DRINK=30;
		public const int SOUND_EFFECT_EAT_1=31;
		public const int SOUND_EFFECT_EAT_2=33;
		public const int SOUND_EFFECT_NPC_DEATH_2=34;//Squishy npc death 1.
		public const int SOUND_EFFECT_NPC_DEATH_3=35;//Squishy npc death 2.
		public const int SOUND_EFFECT_ZAP=36;//Squishy npc death.
		public const int SOUND_EFFECT_EAT_3=37;
		public const int SOUND_EFFECT_BANG=40;
		public const int SOUND_EFFECT_FOOT_GRAVELLY=47;
		public const int SOUND_EFFECT_FOOT_ICE=48;

	public static bool PlayMusic=true;

	//Music modes
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
	private const int MUS_ENDGAME=11;

	/// <summary>
	/// Tracks how long ago the last attack took place at.
	/// </summary>
	public static float LastAttackCounter=0.0f;//To track the end of combat.

	/// <summary>
	/// Is music processing stopped
	/// </summary>
	public bool Stopped;

	/// <summary>
	/// Playing intro music
	/// </summary>
	public bool InIntro;
	/// <summary>
	/// Playing combat music
	/// </summary>
	public bool Combat;
	/// <summary>
	/// In the automap
	/// </summary>
	public bool InMap;
	/// <summary>
	/// Weapon drawn music
	/// </summary>
	public bool WeaponDrawn;
	/// <summary>
	/// Player character near death.
	/// </summary>
	public bool Injured;
	/// <summary>
	/// PLayer character is death
	/// </summary>
	public bool Death;
	/// <summary>
	/// Is the player fleeing from combat (recently attacked and no weapon drawn)
	/// </summary>
	public bool Fleeing;

	/// <summary>
	/// is the end game track playing
	/// </summary>
	public bool EndGame;
	
	/// <summary>
	/// What track is playing
	/// </summary>
	private int playing;
	

		/// <summary>
		/// Is a special clip such as a fan fare being played.
		/// </summary>
	public bool SpecialClip;//One offs

		/// <summary>
		/// The main track list. Contains all the tracks that can be played.
		/// </summary>
	public AudioClip[] MainTrackList=new AudioClip[12];

		/// <summary>
		/// Array of the possible intro tracks
		/// </summary>
	public int[] IntroTracks={0};
		/// <summary>
		/// Array of the possible idle tracks
		/// </summary>
	public int[] IdleTracks={1,2,3};
		/// <summary>
		/// Array of the possible combat tracks
		/// </summary>
	public int[] CombatTracks={4,5};
		/// <summary>
		/// Array of the possible injured tracks
		/// </summary>
	public int[] InjuredTracks={6};
		/// <summary>
		/// Array of the possible weapon tracks
		/// </summary>
	public int[] WeaponTracks={7};
		/// <summary>
		/// Array of the possible victory tracks
		/// </summary>
	public int[] VictoryTracks={8};
		/// <summary>
		/// Array of the possible death tracks.
		/// </summary>
	public int[] DeathTracks = {9};
		/// <summary>
		/// Array of the possible  fleeing tracks.
		/// </summary>
	public int[] FleeingTracks={10};
		/// <summary>
		/// Array of the possible automap tracks
		/// </summary>
	public int[] MapTracks={11};

	/// <summary>
	/// Array of possible end game tracks.
	/// </summary>
	public int[] EndGameTracks={1};

	private bool StopProcessing;
	private AudioSource Aud;

	public AudioSource MusicalInstruments;

	public AudioClip[] SoundEffects=new AudioClip[1];

		private static bool ready;

	void Start () {
		Aud= this.GetComponent<AudioSource>();
	}

	public static void Begin()
	{
		ready=true;	
	}


	/// <summary>
	/// Updates the state of the music based on the current world and player state.
	/// </summary>
	public void UpdateMusicState ()
	{
		if (LastAttackCounter <= 0) {
			Combat = false;
		}
		else {
			LastAttackCounter -= Time.deltaTime;
			InIntro = false;
			Combat = true;
		}
		if ((GameWorldController.instance.playerUW.CurVIT <= 10) && (Combat == true)) {
			Injured = true;
		}
		else {
			Injured = false;
		}
		if ((Combat == true) && (WeaponDrawn == false)) {
			Fleeing = true;
		}
		else {
			Fleeing = false;
		}
		if (SpecialClip == true) {
			if (Aud.isPlaying == false) {
				SpecialClip = false;
			}
			return;
			//don#t interupt a special clip. Eg fanfare in combat
		}
		if ((Aud.isPlaying == false) && (StopProcessing == false)) {
			playing = -1;
			//Force next track;
		}
		//Get the highest priorty tracklist to play.
		switch (GetMaxPriority ()) {
		case MUS_ENDGAME:
				ChangeTracklist (EndGameTracks, MUS_DEATH);
				break;	
		case MUS_INTRO:
			ChangeTracklist (IntroTracks, MUS_DEATH);
			break;
		case MUS_DEATH:
			ChangeTracklist (DeathTracks, MUS_DEATH);
			break;
		case MUS_MAP:
			ChangeTracklist (MapTracks, MUS_MAP);
			break;
		case MUS_COMBAT:
			ChangeTracklist (CombatTracks, MUS_COMBAT);
			break;
		case MUS_INJURED:
			ChangeTracklist (InjuredTracks, MUS_INJURED);
			break;
		case MUS_FLEEING:
			ChangeTracklist (FleeingTracks, MUS_FLEEING);
			break;
		case MUS_WEAPON:
			ChangeTracklist (WeaponTracks, MUS_WEAPON);
			break;
		case MUS_IDLE:
			ChangeTracklist (IdleTracks, MUS_IDLE);
			break;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (ready)
		{
			UpdateMusicState ();	
		}		
	}

	/// <summary>
	/// Picks a random track to play from the selected playlist.
	/// </summary>
	/// <param name="tracklist">Tracklist array</param>
	void PlayRandom(int[] tracklist)
	{
		if (PlayMusic)
		{
				int rnd = Random.Range (0,tracklist.GetUpperBound(0)+1);
				Aud.clip=MainTrackList[tracklist[rnd]];
				if (Stopped==false)
				{
						Aud.Play();				
				}
		}
		else
		{
			Aud.Stop();
		}
	}
	/// <summary>
	/// Stops music
	/// </summary>
	public void Stop()
	{
		StopProcessing=true;
		Aud.Stop ();
	}

		/// <summary>
		/// Stops all music processing
		/// </summary>
	public void StopAll()
	{
		Stop();
		Stopped=true;
	}

	public void ResumeAll()
	{
		Stopped=false;
		Resume();	
	}

		/// <summary>
		/// Resumes playing music
		/// </summary>
	public void Resume()
	{
		StopProcessing=false;
		PlayRandom (IdleTracks);
	}

		/// <summary>
		/// Gets  the current music state that is active and has the highest priority.
		/// </summary>
		/// <returns>The max priority music state</returns>
	private int GetMaxPriority()
	{
		if (Death)
		{
			return MUS_DEATH;
		}
		else if (EndGame)
		{
			return MUS_ENDGAME;	
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
		else if (InIntro)
		{
			return MUS_INTRO;
		}
		else
		{
			return MUS_IDLE;
		}
	}

		/// <summary>
		/// Changes the track playing if we go to to a new list
		/// </summary>
		/// <param name="newTrackList">New track list.</param>
		/// <param name="playingMode">Playing mode.</param>
	void ChangeTracklist(int[] newTrackList, int playingMode)
	{
		if (playing!=playingMode)
		{
			if (GameWorldController.instance.AtMainMenu==false)
			{InIntro=false;}
			PlayRandom(newTrackList);
			playing=playingMode;
		}
	}

		/// <summary>
		/// PLays a special music clip. (eg fanfare)
		/// </summary>
		/// <param name="newTrackList">New track list.</param>
	public void PlaySpecialClip(int[] newTrackList)
	{
		PlayRandom (newTrackList);
		SpecialClip=true;
		playing=-1;
	}
}
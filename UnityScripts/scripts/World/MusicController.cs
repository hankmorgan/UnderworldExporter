using UnityEngine;
using System.Collections;
using System.IO;

/// <summary>
/// The music controller. Updates music tracks to play based on the state of the game world and player.
/// </summary>
[RequireComponent(typeof(AudioSource))]
public class MusicController : UWEBase {

		public static string UW1Path;
		public static string UW2Path;

		public enum UWMusicTracks
		{
				UW1introduction = 1,	
				UW1darkabyss = 2,
				UW1descent = 3,
				UW1wanderer = 4,
				UW1battlefield = 5,
				UW1combat = 6,
				UW1injured = 7,
				UW1armed = 10,
				UW1victory = 11,
				UW1death = 12,
				UW1fleeing = 13,
				UW1mapslegends  = 15,

				UW2theme =1,
				UW2enemywounded =2,
				UW2combat=3,
				UW2dangeroussituation = 4,
				UW2armed =5,
				UW2victory = 6,
				UW2sewers = 7,
				UW2talorus =10,
				UW2prisontower = 11,
				UW2death = 12,
				UW2killorn = 13,
				UW2icecaverns = 14,
				UW2scintillus = 15,
				UW2castle = 16,
				UW2themeagain = 17,
				UW2introduction = 30,
				UW2trap = 31
		};

		/*	public enum UW2MusicTracks
		{
				theme =1,
				enemywounded =2,
				combat=3,
				dangeroussituation = 4,
				armed =5,
				victory = 6,
				sewers = 7,
				talorus =10,
				prisontower = 11,
				death = 12,
				killorn = 13,
				icecaverns = 14,
				scintillus = 15,
				castle = 16,
				themeagain = 17,
				introduction = 30,
				trap = 31
		};*/


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
		public AudioClip[] MainTrackList=new AudioClip[32];

		/// <summary>
		/// Array of the possible intro tracks (uw1)
		/// </summary>
		public UWMusicTracks[] IntroTracks={UWMusicTracks.UW1introduction};
		/// <summary>
		/// Array of the possible idle tracks
		/// </summary>
		public UWMusicTracks[] IdleTracks={UWMusicTracks.UW1darkabyss,UWMusicTracks.UW1descent, UWMusicTracks.UW1wanderer};
		/// <summary>
		/// Array of the possible combat tracks
		/// </summary>
		public UWMusicTracks[] CombatTracks={UWMusicTracks.UW1battlefield, UWMusicTracks.UW1combat};
		/// <summary>
		/// Array of the possible injured tracks
		/// </summary>
		public UWMusicTracks[] InjuredTracks={UWMusicTracks.UW1injured};
		/// <summary>
		/// Array of the possible weapon tracks
		/// </summary>
		public UWMusicTracks[] WeaponTracks={UWMusicTracks.UW1armed};
		/// <summary>
		/// Array of the possible victory tracks
		/// </summary>
		public UWMusicTracks[] VictoryTracks={UWMusicTracks.UW1victory};
		/// <summary>
		/// Array of the possible death tracks.
		/// </summary>
		public UWMusicTracks[] DeathTracks = {UWMusicTracks.UW1death};
		/// <summary>
		/// Array of the possible  fleeing tracks.
		/// </summary>
		public UWMusicTracks[] FleeingTracks={UWMusicTracks.UW1fleeing};
		/// <summary>
		/// Array of the possible automap tracks
		/// </summary>
		public UWMusicTracks[] MapTracks={UWMusicTracks.UW1mapslegends};

		/// <summary>
		/// Array of possible end game tracks.
		/// </summary>
		public UWMusicTracks[] EndGameTracks={UWMusicTracks.UW1wanderer};

		private bool StopProcessing;
		private AudioSource Aud;

		public AudioSource MusicalInstruments;

		public AudioClip[] SoundEffects=new AudioClip[1];

		private static bool ready;

		public static MusicController instance;

		void Awake()
		{
				instance=this;
		}


		void Start () {
				Aud= this.GetComponent<AudioSource>();
				//LoadAudioFileFromWWW();
				//StartCoroutine(LoadAudioFileFromWWW("PSXUW1", 1));
		}

		public IEnumerator Begin()
		{
				yield return  LoadGameSoundTracks(_RES);			
				ready=true;	
				yield return 0;
		}

		public IEnumerator LoadGameSoundTracks(string GAME)
		{				
				switch (GAME)
				{
				case GAME_UW2:
						SetTrackListsUW2();
						for (int i = 1; i<=32;i++)
						{
								yield return (LoadAudioFileFromWWW(UW2Path, i));	
						}
						break;
				default:	//UW1 Soundtracks
						SetTrackListsUW1();
						for (int i = 1; i<=15;i++)
						{
								yield return (LoadAudioFileFromWWW(UW1Path, i));	
						}
						break;
				}
				yield return 0;
		}


		IEnumerator LoadAudioFileFromWWW(string AudioBank, int FileTrackNumber)
		{								
				//string Path = Application.dataPath + "//..//..//UWSoundPack//" + AudioBank + "//" + FileTrackNumber.ToString("d2") + ".ogg";
				string Path = AudioBank + FileTrackNumber.ToString("d2") + ".ogg";


				if (File.Exists(Path))
						//{
						//Debug.Log("LoadAudioFileFromWWW : File not found : " + Path);
						//}
						//else
				{
						using (WWW download = new WWW("file://" + Path))
						{
								yield return download;

								AudioClip clip = download.GetAudioClip(false);

								if (clip!=null)
								{
										MainTrackList[FileTrackNumber] = clip;
								}	
						}	
				}
		}

		/// <summary>
		/// Sets the track lists for UW1
		/// </summary>
		void SetTrackListsUW1()
		{
				IntroTracks= new UWMusicTracks[]{UWMusicTracks.UW1introduction};
				IdleTracks =new UWMusicTracks[]{UWMusicTracks.UW1darkabyss,UWMusicTracks.UW1descent, UWMusicTracks.UW1wanderer};
				CombatTracks=new UWMusicTracks[]{UWMusicTracks.UW1battlefield,UWMusicTracks.UW1combat};
				InjuredTracks=new UWMusicTracks[]{UWMusicTracks.UW1injured};
				WeaponTracks=new UWMusicTracks[]{UWMusicTracks.UW1armed};
				VictoryTracks=new UWMusicTracks[]{UWMusicTracks.UW1victory};
				DeathTracks = new UWMusicTracks[]{UWMusicTracks.UW1death};
				FleeingTracks=new UWMusicTracks[]{UWMusicTracks.UW1fleeing};
				MapTracks=new UWMusicTracks[]{UWMusicTracks.UW1mapslegends};	
		}

		void SetTrackListsUW2()
		{
				//IntroTracks=new int[]{UW2MusicTracks.introduction};
				IdleTracks =new UWMusicTracks[]{UWMusicTracks.UW2castle//,
						//UWMusicTracks.UW2icecaverns, 
						//UWMusicTracks.UW2sewers, 
						//UWMusicTracks.UW2killorn, 
						//UWMusicTracks.UW2prisontower,
						//UWMusicTracks.UW2scintillus,
						//UWMusicTracks.UW2talorus,
						//UWMusicTracks.UW2theme				
				};
				CombatTracks=new UWMusicTracks[]{UWMusicTracks.UW2combat};
				InjuredTracks=new UWMusicTracks[]{UWMusicTracks.UW2dangeroussituation};
				WeaponTracks=new UWMusicTracks[]{UWMusicTracks.UW2armed};
				VictoryTracks=new UWMusicTracks[]{UWMusicTracks.UW2victory};
				DeathTracks = new UWMusicTracks[]{UWMusicTracks.UW2death};
				FleeingTracks=new UWMusicTracks[]{UWMusicTracks.UW2trap};//?
				MapTracks=new UWMusicTracks[]{UWMusicTracks.UW2castle};	
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
				if ((UWCharacter.Instance.CurVIT <= 10) && (Combat == true)) {
						UWCharacter.Instance.Injured = true;
				}
				else {
						UWCharacter.Instance.Injured = false;
				}
				if ((Combat == true) && (UWCharacter.Instance.WeaponDrawn == false)) {
						UWCharacter.Instance.Fleeing = true;
				}
				else {
						UWCharacter.Instance.Fleeing = false;
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
		void PlayRandom(UWMusicTracks[] tracklist)
		{
				if (PlayMusic)
				{
						int rnd = Random.Range (0,tracklist.GetUpperBound(0)+1);
						Aud.clip=MainTrackList[(int)tracklist[rnd]];
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
				if (UWCharacter.Instance.Death)
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
				else if (UWCharacter.Instance.Injured)
				{
						return MUS_INJURED;
				}
				else if (UWCharacter.Instance.Fleeing)
				{
						return MUS_FLEEING;
				}
				else if (Combat)
				{
						return MUS_COMBAT;
				}
				else if (UWCharacter.Instance.WeaponDrawn)
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
		void ChangeTracklist(UWMusicTracks[] newTrackList, int playingMode)
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
		public void PlaySpecialClip(UWMusicTracks[] newTrackList)
		{
				PlayRandom (newTrackList);
				SpecialClip=true;
				playing=-1;
		}


		public void ChangeTrackListForUW2(int levelNo)
		{
				switch((GameWorldController.UW2_LevelNos)(levelNo))	
				{
				case GameWorldController.UW2_LevelNos.Academy0:
				case GameWorldController.UW2_LevelNos.Academy1:
				case GameWorldController.UW2_LevelNos.Academy2:
				case GameWorldController.UW2_LevelNos.Academy3:
				case GameWorldController.UW2_LevelNos.Academy4:
				case GameWorldController.UW2_LevelNos.Academy5:
				case GameWorldController.UW2_LevelNos.Academy6:
				case GameWorldController.UW2_LevelNos.Academy7:
						IdleTracks =new UWMusicTracks[]{UWMusicTracks.UW2scintillus, UWMusicTracks.UW2theme	}; 
						break;
				case GameWorldController.UW2_LevelNos.Prison0:
				case GameWorldController.UW2_LevelNos.Prison1:
				case GameWorldController.UW2_LevelNos.Prison2:
				case GameWorldController.UW2_LevelNos.Prison3:
				case GameWorldController.UW2_LevelNos.Prison4:
				case GameWorldController.UW2_LevelNos.Prison5:
				case GameWorldController.UW2_LevelNos.Prison6:
				case GameWorldController.UW2_LevelNos.Prison7:
						IdleTracks =new UWMusicTracks[]{UWMusicTracks.UW2prisontower, UWMusicTracks.UW2theme}; 
						break;
				case GameWorldController.UW2_LevelNos.Ice0:
				case GameWorldController.UW2_LevelNos.Ice1:
						IdleTracks =new UWMusicTracks[]{UWMusicTracks.UW2icecaverns, UWMusicTracks.UW2theme}; 
						break;
				case GameWorldController.UW2_LevelNos.Killorn0:
				case GameWorldController.UW2_LevelNos.Killorn1:
				case GameWorldController.UW2_LevelNos.Pits0:
				case GameWorldController.UW2_LevelNos.Pits1:						
						IdleTracks =new UWMusicTracks[]{UWMusicTracks.UW2killorn, UWMusicTracks.UW2theme}; 
						break;
				case GameWorldController.UW2_LevelNos.Talorus0:
				case GameWorldController.UW2_LevelNos.Talorus1:
				case GameWorldController.UW2_LevelNos.Ethereal0:
				case GameWorldController.UW2_LevelNos.Ethereal1:
				case GameWorldController.UW2_LevelNos.Ethereal2:
				case GameWorldController.UW2_LevelNos.Ethereal3:
				case GameWorldController.UW2_LevelNos.Ethereal4:
				case GameWorldController.UW2_LevelNos.Ethereal5:
				case GameWorldController.UW2_LevelNos.Ethereal6:
				case GameWorldController.UW2_LevelNos.Ethereal7:
				case GameWorldController.UW2_LevelNos.Ethereal8:						
						IdleTracks =new UWMusicTracks[]{UWMusicTracks.UW2talorus}; 
						break;

				case GameWorldController.UW2_LevelNos.Tomb0:
				case GameWorldController.UW2_LevelNos.Tomb1:
				case GameWorldController.UW2_LevelNos.Tomb2:
				case GameWorldController.UW2_LevelNos.Tomb3:
						IdleTracks =new UWMusicTracks[]{UWMusicTracks.UW2castle, UWMusicTracks.UW2icecaverns}; 
						break;
				case GameWorldController.UW2_LevelNos.Britannia2:
				case GameWorldController.UW2_LevelNos.Britannia3:
						IdleTracks =new UWMusicTracks[]{UWMusicTracks.UW2sewers, UWMusicTracks.UW2theme}; 
						break;
				default:
						IdleTracks =new UWMusicTracks[]{UWMusicTracks.UW2castle, UWMusicTracks.UW2theme	}; 
						break;								
				}
		}
}
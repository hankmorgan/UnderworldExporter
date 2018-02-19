using UnityEngine;
using System.Collections;
using System.Collections.Generic;
//using RAIN.BehaviorTrees;
//using RAIN.Core;
//using RAIN.Minds;
using UnityEngine.AI;



/// <summary>
/// NPC Properties and AI
/// </summary>
/// Controls AI status, animation, conversations and general properties.
public class NPC : MobileObject {

		//TODO: these need to match the UW npc_goals
		//The behaviour trees need to be updated too.
		public const int AI_STATE_IDLERANDOM = 0;
		public const int AI_STATE_COMBAT = 1;
		public const int AI_STATE_DYING = 2;
		public const int AI_STATE_STANDING = 3;
		public const int AI_STATE_WALKING = 4 ;
		public const int AI_STATE_FLEE = 5 ;
		public const int AI_STATE_FOLLOW = 6 ;

		//attitude; 0:hostile, 1:upset, 2:mellow, 3:friendly
		public const int AI_ATTITUDE_HOSTILE = 0 ;
		public const int AI_ATTITUDE_UPSET = 1 ;
		public const int AI_ATTITUDE_MELLOW = 2 ;
		public const int AI_ATTITUDE_FRIENDLY = 3 ;

		//Animations are clasified by number
		public const int AI_RANGE_IDLE = 1 ;
		public const int AI_RANGE_MOVE = 10 ;

		public const int AI_ANIM_IDLE_FRONT = 1;
		public const int AI_ANIM_IDLE_FRONT_RIGHT = 2;
		public const int AI_ANIM_IDLE_RIGHT = 3;
		public const int AI_ANIM_IDLE_REAR_RIGHT = 4;
		public const int AI_ANIM_IDLE_REAR = 5;
		public const int AI_ANIM_IDLE_REAR_LEFT = 6;
		public const int AI_ANIM_IDLE_LEFT = 7;
		public const int AI_ANIM_IDLE_FRONT_LEFT = 8;

		public const int AI_ANIM_WALKING_FRONT = 10;
		public const int AI_ANIM_WALKING_FRONT_RIGHT = 20;
		public const int AI_ANIM_WALKING_RIGHT = 30;
		public const int AI_ANIM_WALKING_REAR_RIGHT = 40;
		public const int AI_ANIM_WALKING_REAR = 50;
		public const int AI_ANIM_WALKING_REAR_LEFT = 60;
		public const int AI_ANIM_WALKING_LEFT = 70;
		public const int AI_ANIM_WALKING_FRONT_LEFT = 80;

		public const int AI_ANIM_DEATH =100;
		public const int AI_ANIM_ATTACK_BASH =1000;
		public const int AI_ANIM_ATTACK_SLASH =2000;
		public const int AI_ANIM_ATTACK_THRUST =3000;
		public const int AI_ANIM_COMBAT_IDLE =4000;
		public const int AI_ANIM_ATTACK_SECONDARY =5000;

		private static short[] CompassHeadings={0,-1,-2,-3,4,3,2,1,0};//What direction the npc is facing. To adjust it's animation

		public enum NPCCategory
		{			
			ethereal = 0,
			humanoid = 0x1,
			flying = 0x2,
			swimming = 0x03,
			creeping = 0x4,
			crawling = 0x5,
			golem = 0x6,
			human = 0x51
		};

		public enum npc_goals
		{
				npc_goal_stand_still_0= 0,
				npc_goal_stand_still_7= 7,
				npc_goal_stand_still_11= 11,
				npc_goal_stand_still_12= 12,
				npc_goal_want_to_talk =10,
				npc_goal_goto_1=1,
				npc_goal_wander_2=2,
				npc_goal_wander_4=4,
				npc_goal_wander_8=8,
				npc_goal_attack_5=5,
				npc_goal_attack_9=9,
				npc_goal_flee=6,
				npc_goal_follow=3	
		};

		public enum AttackStages
		{
				AttackPosition = 0,
				AttackAnimateMagic=1,
				AttackAnimateMelee=2,
				AttackExecute=3,
				AttackWaitCycle = 4
		};

		enum AgentMasks
		{
				LAND = 3,
				WATER = 4,
				LAVA = 5,
				AIR = 6
		};

		[Header("Combat")]
		public AttackStages AttackState;
		public int CurrentAttack;//What attack the NPC is currently executing.


		///Anim range defines which animation set to play.
		///Multiple of 10 for dividing animations
		///Angle index * Anim Range give AI_ANIM_X value to pick animation
		/// 
		[Header("Animation")]
		public int AnimRange=1;
		public int NPC_IDi;
		public NPC_Animation newAnim;
		/// The animation index the NPC is facing
		private short facingIndex;
		/// Previous value for tracking changes
		private short PreviousFacing=-1;
		/// Previous value for tracking changes
		private int PreviousAnimRange=-1;
		/// The compass point (see heading array) the NPC is facing relative to the player
		private short CalcedFacing;
		///Integer representation of the current facing of the character. To match with animation angles
		private short currentHeading;
		//Direction between the player and the NPC for calculating relative angle
		private Vector3 direction;	//vector between the player and the ai.
		/// The angle to the character from the player.
		private float angle;

		private SpriteRenderer sprt;
		//public string CurrentSpriteName="";
		//public Sprite currentSpriteLoaded;

		[Header("Status")]
		///flags the NPC as dead so we can kill them off in the next frame
		public bool NPC_DEAD;
		//Added by myself. This are set by spelleffects
		///The NPC is poisoned
		public bool Poisoned;
		///The NPC is parlyzed or timestopped
		public bool Frozen;
		///Allows periodic updating of the NPC animation when frozen to support moving around them
		public short FrozenUpdate=0;
		//Enemy types.
		///Undead Enemy flag
		public bool isUndead=false; 
		public bool isHumanoid=false;
		///For storing spell effects applied to NPCs
		public SpellEffect[] NPCStatusEffects=new SpellEffect[3];
		///Can the NPC fire off magic attacks.
		public bool MagicAttack;	
		///Transform position to launch projectiles from
		public GameObject NPC_Launcher; 
		public int Ammo=0;//How many ranged attacks can this NPC execute. (ie how much ammo can it spawn)
		public float WaitTimer=0f;

		[Header("NavMesh")]
		public NavMeshAgent Agent;
		float targetBaseOffset=0f;
		float startBaseOffset=0f;
		float floatTime =0f;




		private short StartingHP;

		[Header("Positioning")]
		public int CurTileX=0;
		public int CurTileY=0;
		public int prevTileX=-1;
		public int prevTileY=-1;
		public int DestTileX;
		public int DestTileY;
		public Vector3 destinationVector;



		/// <summary>
		/// Initialise some basic info for the NPC ai.
		/// </summary>
		protected override void Start () {
				base.Start();
				//debugCategory=GameWorldController.instance.objDat.critterStats[objInt().item_id-64].Category;
				//debugPoison = GameWorldController.instance.objDat.critterStats[objInt().item_id-64].Poison;
				NPC_IDi=objInt().item_id;
				StartingHP=npc_hp;
				newAnim=this.gameObject.AddComponent<NPC_Animation>();
				if (GameWorldController.instance.critsLoader[NPC_IDi-64]==null)
				{
						GameWorldController.instance.critsLoader[NPC_IDi-64]= new CritLoader(NPC_IDi-64);				
				}
				newAnim.critAnim= GameWorldController.instance.critsLoader[NPC_IDi-64].critter.AnimInfo;
				newAnim.output=this.GetComponentInChildren<SpriteRenderer>();
		}

		void AI_INIT ()
		{				
				//if (ai == null) {
				if (!GameWorldController.NavMeshReady){return;}
				if (Agent == null)
				{
						Vector3 pos = GameWorldController.instance.currentTileMap().getTileVector(CurTileX, CurTileY);
						//this.transform.position=pos;
						NavMeshHit hit;
						int mask = (int)AgentMask();
						mask = 1 << mask;
						NavMesh.SamplePosition(pos, out hit, 0.2f, mask);// NavMesh.AllAreas
						if (hit.hit)
						{//Tests if the npc in question is on the nav mesh
							AddAgent (mask);	
							Agent.Warp(pos);
						}
				}

				/*	GameObject myInstance = Resources.Load ("AI_PREFABS/AI_LAND") as GameObject;
						GameObject newObj = (GameObject)GameObject.Instantiate (myInstance);

						newObj.name = this.gameObject.name + "_AI";
						newObj.transform.position = Vector3.zero;
						newObj.transform.parent = this.gameObject.transform;
						newObj.transform.localPosition = Vector3.zero;
						AIRig aiR = newObj.GetComponent<AIRig> ();
						aiR.AI.Body = this.gameObject;
						ai = aiR;
						ai.AI.WorkingMemory.SetItem<GameObject> ("playerUW", UWCharacter.Instance.gameObject);
						ai.AI.WorkingMemory.SetItem<int> ("attackMode", 0);//Default to melee combat
						ai.AI.Body = this.gameObject;
						ai.AI.Motor.DefaultSpeed = 2.0f * (((float)GameWorldController.instance.objDat.critterStats[objInt().item_id-64].Speed / 12.0f));
						ai.AI.WorkingMemory.SetItem<float> ("Speed", ai.AI.Motor.DefaultSpeed);
						if (this.GetComponent<Animation>()!=null)
						{
								Destroy(this.GetComponent<Animation>()) ;
						}
				}*/
		}

	void AddAgent (int mask)
	{
				int agentId	=GameWorldController.instance.NavMeshLand.agentTypeID;
				Agent = this.gameObject.AddComponent<NavMeshAgent> ();
				Agent.autoTraverseOffMeshLink = false;
				Agent.speed = 2f * (((float)GameWorldController.instance.objDat.critterStats [objInt ().item_id - 64].Speed / 12.0f));

				switch (_RES) {
				case GAME_UW2: {
								switch (objInt ().item_id) {
								case 65://cave bat
								case 66://vampire bat
								case 71://mongbat
								case 75://imp
								case 93://spectre
								case 98://dire ghost
								case 102://haunt
								case 105://lich
								case 106://lich
								case 107://lich
								case 111://gazer	
										agentId = GameWorldController.instance.NavMeshAir.agentTypeID;
										//agentId = GameWorldController.instance.NavMeshLand.agentTypeID;
										break;
								case 77://lurker
								case 89://lurker
										agentId = GameWorldController.instance.NavMeshWater.agentTypeID;
										//agentId = GameWorldController.instance.currentTileMap().getTileAgentID(CurTileX,CurTileY);
										//water
										break;
								case 96://Fire elemental				
										agentId = GameWorldController.instance.NavMeshLava.agentTypeID;
										//agentId = GameWorldController.instance.currentTileMap().getTileAgentID(CurTileX,CurTileY);
										break;
								//default:
										//agentId = GameWorldController.instance.currentTileMap().getTileAgentID(CurTileX,CurTileY);
										break;
								}
								break;
						}
				default: {
								switch (objInt ().item_id) {
								case 66://bat
								case 73://vampire bat
								case 75://imp
								case 81://mongbat
								case 100://ghost
								case 101://ghost
								case 102://gazer
								case 122://wisp
								case 123://tybal
										agentId = GameWorldController.instance.NavMeshAir.agentTypeID;
										//agentId = GameWorldController.instance.NavMeshLand.agentTypeID;
										//flyer
										break;
								case 87://lurker
								case 116://deep lurker
										agentId = GameWorldController.instance.NavMeshWater.agentTypeID;
										//agentId = GameWorldController.instance.currentTileMap().getTileAgentID(CurTileX,CurTileY);
										//water
										break;
								case 120:
								//case 124://slasher
										//fire elemental
										agentId = GameWorldController.instance.NavMeshLava.agentTypeID;
										//agentId = GameWorldController.instance.currentTileMap().getTileAgentID(CurTileX,CurTileY);
										break;
								//default:
										//agentId = GameWorldController.instance.currentTileMap().getTileAgentID(CurTileX,CurTileY);
										//break;
								}
								break;
						}
				}
				Agent.agentTypeID = agentId;
				Agent.areaMask = mask;
	}


		AgentMasks AgentMask ()
		{
				AgentMasks agentMask= AgentMasks.LAND;//land
				switch (_RES) {
				case GAME_UW2: {
								switch (objInt ().item_id) {
								case 65://cave bat
								case 66://vampire bat
								case 71://mongbat
								case 75://imp
								case 93://spectre
								case 98://dire ghost
								case 102://haunt
								case 105://lich
								case 106://lich
								case 107://lich
								case 111://gazer	
										return AgentMasks.AIR;
								case 77://lurker
								case 89://lurker//water
										return AgentMasks.WATER;
								case 96://Fire elemental				
										return AgentMasks.LAVA;
								}
								break;
						}
				default: {
								switch (objInt ().item_id) {
								case 66://bat
								case 73://vampire bat
								case 75://imp
								case 81://mongbat
								case 100://ghost
								case 101://ghost
								case 102://gazer
								case 122://wisp
								case 123://tybal
										return AgentMasks.AIR;
								case 87://lurker
								case 116://deep lurker
										return AgentMasks.WATER;
								case 120:
								//case 124://slasher
										//fire elemental
									return AgentMasks.LAVA;
								}
								break;
						}
				}
				return agentMask;
		}



		/// <summary>
		/// Raises the death events for the player.
		/// </summary>
		/// Uses the conversation for special npcs like Tybal, the Golem and the Beholder.
		/// Dumps out their inventory.
		void OnDeath()
		{
				if (SpecialDeathCases())
				{
						return;
				}
				if (_RES==GAME_UW2)
				{//Improve players Win loss record in the arena
						if (Quest.instance.FightingInArena)
						{
								for (int i=0; i<=Quest.instance.ArenaOpponents.GetUpperBound(0);i++)
								{
										if (Quest.instance.ArenaOpponents[i]==objInt().objectloaderinfo.index)
										{//Update the players win-loss records.
												Quest.instance.ArenaOpponents[i]=0;
												Quest.instance.QuestVariables[129]=Mathf.Min(255, Quest.instance.QuestVariables[129]+1);
												Quest.instance.x_clocks[14]=Mathf.Min(255, Quest.instance.x_clocks[14]+1);	
												Quest.instance.QuestVariables[24]=1;//You have won a fight.
										}
								}	
						}
				}
				objInt().objectloaderinfo.InUseFlag=0;
				objInt().objectloaderinfo.npc_hp=0;
				NPC_DEAD=true;//Tells the update to execute the NPC death animation
				PerformDeathAnim();
				//Dump npc inventory on the floor.
				Container cnt = this.GetComponent<Container>();
				if (cnt!=null)
				{
						SetupNPCInventory();

						cnt.SpillContents();//Spill contents is still not 100% reliable so don't expect to get all the items you want.
				}
				UWCharacter.Instance.AddXP(GameWorldController.instance.objDat.critterStats[objInt().item_id-64].Exp);

				//Category 	Ethereal = 0x00 (Ethereal critters like ghosts, wisps, and shadow beasts), 
				//Humanoid = 0x01 (Humanlike non-thinking forms like lizardmen, trolls, ghouls, and mages),
				//Flying = 0x02 (Flying critters like bats and imps), 
				//Swimming = 0x03 (Swimming critters like lurkers), 
				//Creeping = 0x04 (Creeping critters like rats and spiders), 
				//Crawling = 0x05 (Crawling critters like slugs, worms, reapers (!), and fire elementals (!!)),
				//EarthGolem = 0x11 (Only used for the earth golem),
				//Human = 0x51 (Humanlike thinking forms like goblins, skeletons, mountainmen, fighters, outcasts, and stone and metal golems).
				switch((NPCCategory)GameWorldController.instance.objDat.critterStats[objInt().item_id-64].Category)
				{
				//case 0x0:
				//case 0x02:
				case NPCCategory.ethereal:
				case NPCCategory.flying:
						objInt().aud.clip=GameWorldController.instance.getMus().SoundEffects[MusicController.SOUND_EFFECT_NPC_DEATH_3];break;
				//case 0x03:
				case NPCCategory.swimming:
						objInt().aud.clip=GameWorldController.instance.getMus().SoundEffects[MusicController.SOUND_EFFECT_SPLASH_1];break;
				//case 0x04:
				//case 0x05:
				case NPCCategory.crawling:
				case NPCCategory.creeping:
						objInt().aud.clip=GameWorldController.instance.getMus().SoundEffects[MusicController.SOUND_EFFECT_NPC_DEATH_2];break;
				//case 0x11:
				case NPCCategory.golem:
						objInt().aud.clip=GameWorldController.instance.getMus().SoundEffects[MusicController.SOUND_EFFECT_RUMBLE];break;
				//case 0x01:
				case NPCCategory.human:
				case NPCCategory.humanoid:
				default:
						objInt().aud.clip=GameWorldController.instance.getMus().SoundEffects[MusicController.SOUND_EFFECT_NPC_DEATH_1];break;								
				}
				if (ObjectInteraction.PlaySoundEffects)
				{
						objInt().aud.Play();		
				}
		}

		/// <summary>
		/// Setups the NPC inventory if they use a loot list.
		/// </summary>
		public void SetupNPCInventory ()
		{
				if (_RES!=GAME_UW2)
				{
						if (objInt().item_id==64)
						{//Special case for rotworms.
								return;
						}
				}
				Container cnt = this.GetComponent<Container>();
				if (cnt.CountItems () == 0) {
						//Populate the container with a loot list
						for (int i = 0; i <= GameWorldController.instance.objDat.critterStats [objInt ().item_id - 64].Loot.GetUpperBound (0); i++) {
								if (GameWorldController.instance.objDat.critterStats [objInt ().item_id - 64].Loot [i] != -1) {
										int itemid = GameWorldController.instance.objDat.critterStats [objInt ().item_id - 64].Loot [i];
										ObjectLoaderInfo newobjt = ObjectLoader.newObject (itemid, Random.Range (1, 41), 0, 0, 256);
										if (itemid==16)//Sling stone.
										{
												newobjt.is_quant=1;
												newobjt.link= Random.Range(1,10);
												newobjt.quality=40;
										}
										else
										{
												newobjt.is_quant=0;
										}
										newobjt.instance = ObjectInteraction.CreateNewObject (GameWorldController.instance.currentTileMap (), newobjt, GameWorldController.instance._ObjectMarker, GameWorldController.instance.InventoryMarker.transform.position);
										cnt.AddItemToContainer (newobjt.instance.name);
								}
						}
				}
		}

		/// <summary>
		/// Some NPCs has special events when they die.
		/// </summary>
		/// <returns><c>true</c>, if no more processing is to be done., <c>false</c> otherwise.</returns>
		bool SpecialDeathCases()
		{
				switch(_RES)	
				{
				case GAME_UW1:
						{
								/*if (objInt().item_id==64)
								{//Drop a rotworm corpse
										ObjectLoaderInfo newobjt= ObjectLoader.newObject(217,0,0,0,256);
										ObjectInteraction.CreateNewObject(GameWorldController.instance.currentTileMap(),newobjt, GameWorldController.instance.LevelMarker().gameObject,this.transform.position);
										return false;	
								}*/
								switch (npc_whoami)
								{
								case 22: //The golem on level 6
										{
												if (ConversationVM.InConversation==false)		
												{
														NPC_DEAD=false;
														TalkTo ();
												}
												return true;	
										}
								case 110://The Gazer on level 2
										{
												Quest.instance.QuestVariables[4]=1;
												return false;
										}
								case 142://Rodrick
										{
												Quest.instance.QuestVariables[11]=1;	
												return false;
										}
								case 231:	//Tybal
										{
												//Play the tybal death cutscene.
												//Quest.instance.isTybalDead=true;
												Quest.instance.GaramonDream=7;//Advance to Tybal is dead range of dreams
												Quest.instance.DayGaramonDream=GameClock.day();//Ensure dream triggers on next sleep
												UWCharacter.Instance.PlayerMagic.CastEnchantment(this.gameObject,null,226,Magic.SpellRule_TargetSelf,-1);
												return false;														
										}
								}


								break;
						}

				case GAME_UW2:
						{
								if (GameWorldController.instance.LevelNo==3)
								{
										if (objInt().item_id==78)//Blood worms on level 3 of britannia. This is a quest for the friendly goblins
										{
												Quest.instance.QuestVariables[135]++;
										}
								}
								switch(npc_whoami)
								{
								case 58://Brain creatures in Kilhorn
										Quest.instance.QuestVariables[50]=1;
										return false;
								case 75: //Demon guard in Kilhorn.
										if(NPC_IDi==108)
										{//Convert into a hordling
												NPC_IDi=94;
												objInt().item_id=94;
												npc_hp=	92;	
												NPC_DEAD=false;
												if (GameWorldController.instance.critsLoader[NPC_IDi-64]==null)
												{
														GameWorldController.instance.critsLoader[NPC_IDi-64]= new CritLoader(NPC_IDi-64);				
												}
												newAnim.critAnim= GameWorldController.instance.critsLoader[NPC_IDi-64].critter.AnimInfo;
												return true;
										}
										else
										{
												return false;
										}
								case 98://Zaria
										Quest.instance.QuestVariables[25]=1;
										return false;
								case 99://Dorstag
										Quest.instance.QuestVariables[121]=1;
										return false;
								case 145://The listener under the castle
										Quest.instance.QuestVariables[11]=1;
										Quest.instance.x_clocks[1]++;//Confirm this behaviour!
										return false;
								case 152://Bliy Scup Ductosnore
										{
												Quest.instance.QuestVariables[122]=1;
												//Fires off move trigger at 638 to delete the walls
												ObjectInteraction obj = ObjectLoader.getObjectIntAt(638);
												if (obj!=null)
												{
														if (obj.GetComponent<trigger_base>()!=null)
														{
																obj.GetComponent<trigger_base>().Activate(UWCharacter.Instance.gameObject);
														}
												}
												obj = ObjectLoader.getObjectIntAt(649);
												if (obj!=null)
												{
														if (obj.GetComponent<trigger_base>()!=null)
														{
																obj.GetComponent<trigger_base>().Activate(UWCharacter.Instance.gameObject);
														}
												}
												return false;												
										}
								}
								break;
						}
				}
				return false;
		}


		/// <summary>
		/// Update the NPC state, AI and animations
		/// </summary>
		/// AI is only active when the player is close.
		protected virtual void  Update () {
				if (EditorMode==true){return;}
				if (WaitTimer>0)
				{
						WaitTimer = WaitTimer -Time.deltaTime;
						if (WaitTimer<0)
						{
								WaitTimer=0;
						}		
				}

				if (Frozen)
				{//NPC will not move until timer is complete.
						if (FrozenUpdate==0)
						{
								newAnim.enabled=false;
						}
						else
						{
								FrozenUpdate--;
						}
				}

				if (NPC_DEAD==true)
				{//Set the AI death state
						//Update the appearance of the NPC
						UpdateSprite();
						if (WaitTimer<=0)
						{
								DumpRemains();
						}
						return;
				}

				CurTileX = (int)(transform.position.x/1.2f);
				CurTileY = (int)(transform.position.z/1.2f);

				UpdateNPCAWake ();


				//Update the appearance of the NPC
				UpdateSprite();

				//Update the Goal Target of the NPC
				UpdateGTarg ();

				if ((npc_hp<=0))
				{//Begin death handling.
						OnDeath();
				}
				else
				{
						UpdateGoals ();
				}	

		}

		void UpdateNPCAWake ()
		{
				//The AI is only active when the player is within a certain distance to the player camera.
				if (Vector3.Distance (this.transform.position, UWCharacter.Instance.CameraPos) <= 10) {
						if (objInt () != null) {
								if (TileMap.ValidTile(CurTileX,CurTileY))
								{
										AI_INIT ();
								}
								newAnim.enabled = true;
						}
				}
				else {
						newAnim.enabled = false;
						return;
				}
		}

		void NPCFollow ()
		{//NPC is following the player or an object
				if (gtarg != null) {
						Vector3 ABf = this.transform.position - gtarg.transform.position;
						Vector3 Movepos = gtarg.transform.position + (0.9f * ABf.normalized);
						Agent.destination = Movepos;
						Agent.isStopped = false;
						//Set to idle										
						if (gtarg.name == "_Gronk") {
								//Help out the player dynamically
								if (UWCharacter.Instance.HelpMeMyFriends == true) {
										UWCharacter.Instance.HelpMeMyFriends = false;
										//If I'm not already busy with another NPC
										if (UWCharacter.Instance.LastEnemyToHitMe != null) {
												gtarg = UWCharacter.Instance.LastEnemyToHitMe;
												npc_goal = (short)npc_goals.npc_goal_attack_5;
												npc_gtarg = (short)UWCharacter.Instance.LastEnemyToHitMe.GetComponent<ObjectInteraction> ().objectloaderinfo.index;
												gtargName = UWCharacter.Instance.LastEnemyToHitMe.name;
										}
								}
								if ((_RES == GAME_UW1) && (GameWorldController.instance.LevelNo == 8)) {
										//slasher of veils in the void needs to get rowdy.
										if (objInt ().item_id == 124) {
												npc_goal = (short)npc_goals.npc_goal_attack_5;
												gtarg = UWCharacter.Instance.gameObject;
										}
								}
						}
				}
		}

		/// <summary>
		/// Updates the goals for NPCs that have no navmesh agent on them yet even though navmeshes are ready
		/// </summary>
		void UpdateGoalsForNonAgents()
		{
				switch ((npc_goals)npc_goal) 
				{
				case npc_goals.npc_goal_want_to_talk:
						{
								//I just want to talk to you
								//ai.AI.WorkingMemory.SetItem<int> ("state", AI_STATE_STANDING);
								AnimRange= NPC.AI_RANGE_IDLE;
								if ((UWCharacter.Instance.isRoaming == false) && (ConversationVM.InConversation == false)) 
								{
										if (Vector3.Distance (this.transform.position, UWCharacter.Instance.CameraPos) <= 1.5) 
										{
												TalkTo ();
										}
								}	
								break;
						}
				default:
						return;
				}
		}

		void UpdateGoals ()
		{				
				if (Agent==null){
						if (GameWorldController.NavMeshReady)
						{
								UpdateGoalsForNonAgents();
						}
						return;
				}
				if (!Agent.isOnNavMesh){return;}
				//if (GameWorldController.instance.GenNavMeshNextFrame >0) {return;}//nav mesh update pending
				if (!GameWorldController.NavMeshReady){return;}
				//If the player comes close and I'm hostile. Make sure I go to combat mode.
				if ((npc_attitude == 0) && (Vector3.Distance (this.transform.position, UWCharacter.Instance.transform.position) <= UWCharacter.Instance.DetectionRange)) {
						npc_goal = (short)npc_goals.npc_goal_attack_5;
						//Attack player
						npc_gtarg = 1;
				}
				if (targetBaseOffset!= Agent.baseOffset)
				{
						floatTime +=Time.deltaTime;
						Agent.baseOffset = Mathf.Lerp(startBaseOffset, targetBaseOffset, floatTime );
				}

				switch ((npc_goals)npc_goal) 
				{
				case npc_goals.npc_goal_want_to_talk:
						{
								//I just want to talk to you
								//ai.AI.WorkingMemory.SetItem<int> ("state", AI_STATE_STANDING);
								AnimRange= NPC.AI_RANGE_IDLE;
								if ((UWCharacter.Instance.isRoaming == false) && (ConversationVM.InConversation == false)) 
								{
										if (Vector3.Distance (this.transform.position, UWCharacter.Instance.CameraPos) <= 1.5) 
										{
												TalkTo ();
										}
								}	
								break;
						}

				case npc_goals.npc_goal_stand_still_0:
						//Standing still
				case npc_goals.npc_goal_stand_still_7:
				case npc_goals.npc_goal_stand_still_11:
				case npc_goals.npc_goal_stand_still_12:
						{
								AnimRange= NPC.AI_RANGE_IDLE;
								DestTileX = npc_xhome; DestTileY = npc_yhome;
								if ((CurTileX!=npc_xhome) && (CurTileY!=npc_yhome))								
								{										
										AgentGotoDestTileXY (ref DestTileX, ref DestTileY, ref CurTileX, ref CurTileY);
								}
								break;
						}
						//ai.AI.WorkingMemory.SetItem<int> ("state", AI_STATE_STANDING);
						//break;
				case npc_goals.npc_goal_goto_1:	//Go to gtarg
				case npc_goals.npc_goal_wander_2://Wander randomly	
				case npc_goals.npc_goal_wander_4:
				case npc_goals.npc_goal_wander_8:
				case npc_goals.npc_goal_flee://Morale failure. NPC flees in a random direction
						{
								NPCWanderUpdate ();
								break;
						}			
				case npc_goals.npc_goal_attack_5://Attack target		
				case npc_goals.npc_goal_attack_9:
						{
								NPCCombatUpdate ();
								break;
						}
				case npc_goals.npc_goal_follow:
						{
								//Follow target
								NPCFollow ();
								break;
						}

				}

				if (
						(CurTileX!=prevTileX)
						||
						(CurTileY!=prevTileY)
				)
				{
						switch ((npc_goals)npc_goal) 
						{
							case npc_goals.npc_goal_want_to_talk:
							case npc_goals.npc_goal_stand_still_0:
							case npc_goals.npc_goal_stand_still_7:
							case npc_goals.npc_goal_stand_still_11:
							case npc_goals.npc_goal_stand_still_12:
								if ((CurTileX!=npc_xhome) && (CurTileY!=npc_yhome))								
								{	
										NPCDoorUse ();
								}
								break;
							default:
								NPCDoorUse ();
								break;
						}	
				}

				prevTileX=CurTileX;
				prevTileY=CurTileY;
		}

		/// <summary>
		/// NPC will attempt to open a door in their tile
		/// </summary>
	void NPCDoorUse ()
	{
		//TODO:Make monster Types try and bash doors
				//bool Action=false; //true for open, false to bash.
		//Category 	Ethereal = 0x00 (Ethereal critters like ghosts, wisps, and shadow beasts), 
		//Humanoid = 0x01 (Humanlike non-thinking forms like lizardmen, trolls, ghouls, and mages),
		//Flying = 0x02 (Flying critters like bats and imps), 
		//Swimming = 0x03 (Swimming critters like lurkers), 
		//Creeping = 0x04 (Creeping critters like rats and spiders), 
		//Crawling = 0x05 (Crawling critters like slugs, worms, reapers (!), and fire elementals (!!)),
		//EarthGolem = 0x11 (Only used for the earth golem),
		//Human = 0x51 (Humanlike thinking forms like goblins, skeletons, mountainmen, fighters, outcasts, and stone and metal golems).
		switch((NPCCategory)GameWorldController.instance.objDat.critterStats[objInt().item_id-64].Category)
			{
			 	//case 0x01:
				//case 0x51:
				case NPCCategory.human:
				case NPCCategory.humanoid:
					break;//can open door
				default:
				return;//cannot open door (in the future will attempt to bash if hostile)
			}

		for (int x=-1; x<=1;x++)
		{
				for (int y=-1; y<=1;y++)
				{
						if (
								((x == 0) && ((y==-1) || (y==1)))
								||
								((y == 0) && ((x==-1) || (x==1)))
								||
								((x==0) && (y==0))
						)
						{
								if (TileMap.ValidTile (CurTileX+x, CurTileY+y)) {
										if (GameWorldController.instance.currentTileMap ().Tiles [CurTileX+x, CurTileY+y].isDoor) {
												GameObject door= GameWorldController.findDoor (CurTileX+x, CurTileY+y);
												if (door!=null)
												{
														DoorControl dc = door.GetComponent<DoorControl>();
														if (dc != null) {
																if (dc.state () == false) {
																		//door is closed
																		if ((!dc.locked ()) && (!dc.Spiked)) {
																				//and can be opened.
																				if (dc.DoorBusy == false) {
																						dc.PlayerUse = false;
																						dc.Activate (this.gameObject);
																				}
																		}
																}
														}
												}
										}
								}	
						}
				}		
		}

	}

		void NPCWanderUpdate ()
		{
				CurTileX = (int)(transform.position.x / 1.2f);
				CurTileY = (int)(transform.position.z / 1.2f);
				if ((WaitTimer <= 0) && ((npc_goal != (short)npc_goals.npc_goal_goto_1))) {
						SetRandomDestination ();
				}
				else {
						if ((DestTileX == CurTileX) && (DestTileY == CurTileY)  && ((npc_goal == (short)npc_goals.npc_goal_goto_1))) {
								DestTileX = npc_xhome;
								DestTileY = npc_yhome;
								npc_goal = (short)npc_goals.npc_goal_stand_still_0;
						}
				}
				if ((DestTileX != CurTileX) && (DestTileY != CurTileY)) {
						//I need to move to this tile.
						AnimRange = NPC.AI_RANGE_MOVE;
						AgentGotoDestTileXY (ref DestTileX, ref DestTileY, ref CurTileX, ref CurTileY);
				}
				else {
						//I am at this tile. Stand idle for a random period of time
						AnimRange = NPC.AI_RANGE_IDLE;
						if (WaitTimer == 0) {
								WaitTimer = Random.Range (1f, 10f);
						}
				}
		}

		void NPCCombatUpdate ()
		{
				switch (AttackState) {
				case AttackStages.AttackPosition:
						//if (Room () == UWCharacter.Instance.room) {
						if (true){
								Vector3 AB = this.transform.position - gtarg.transform.position;
								if (AB.magnitude > 1f) {
										if (AB.magnitude < 6f) {
												if (MagicAttack) {
														AgentStand ();
														transform.LookAt (gtarg.transform.position);
														if(AgentCanAttack(NPC_Launcher.transform.position, gtarg.GetComponent<UWEBase>().GetImpactPoint(), gtarg,AB.magnitude))
														{
															AnimRange = NPC.AI_ANIM_ATTACK_SECONDARY;
															AttackState = AttackStages.AttackAnimateMagic;
															WaitTimer = 0.8f;
														}
														else
														{
															//Move to position
															AgentMoveToGtarg ();
														}
												}
												else {
														//Move to position
														AgentMoveToGtarg ();
												}
										}
										else {//Player is not close enough for an attach.
												if (AB.magnitude < 14f + (UWCharacter.Instance.DetectionRange)) 
													{//I'm close enough to still want to hunt you down.
														AgentMoveToGtarg ();
													}
												else
													{
														AgentStand();
													}
										}
								}
								else {
										AgentStand ();
										transform.LookAt (gtarg.transform.position);
										if(AgentCanAttack(NPC_Launcher.transform.position, gtarg.GetComponent<UWEBase>().GetImpactPoint(), gtarg,AB.magnitude))
										{
												SetRandomAttack ();
												AttackState = AttackStages.AttackAnimateMelee;
												WaitTimer = 0.8f;	
										}
										else
										{
												AgentMoveToGtarg ();
										}
	
								}
						}
						else {
								AgentStand ();
								AttackState = AttackStages.AttackWaitCycle;
								WaitTimer = 0.8f;
						}
						break;
				case AttackStages.AttackAnimateMelee:
						if (WaitTimer <= 0.2f) {
								ExecuteAttack ();
								AttackState = AttackStages.AttackExecute;
								WaitTimer = 0.8f;
						}
						break;
				case AttackStages.AttackAnimateMagic:
						if (WaitTimer <= 0.2f) {
								ExecuteMagicAttack ();
								AttackState = AttackStages.AttackExecute;
								WaitTimer = 0.8f;
						}
						break;
				case AttackStages.AttackExecute:
						if (WaitTimer <= 0.2f) {
								AttackState = AttackStages.AttackWaitCycle;
								WaitTimer = 0.8f;
						}
						break;
				case AttackStages.AttackWaitCycle:
						AnimRange = NPC.AI_ANIM_COMBAT_IDLE;
						if (WaitTimer <= 0.2f) {
								AttackState = AttackStages.AttackPosition;
						}
						break;
				}
		}

	void AgentMoveToGtarg ()
	{
		//Move to position
		AgentMoveToPosition (gtarg.transform.position);
		AnimRange = NPC.AI_RANGE_MOVE;
	}

		void AgentGotoDestTileXY (ref int DestinationX, ref int DestinationY, ref int tileX, ref int tileY )
		{
				if (Agent.agentTypeID == GameWorldController.instance.NavMeshAir.agentTypeID) {
						float tileHeight = (float)GameWorldController.instance.currentTileMap ().GetFloorHeight (tileX, tileY) * 0.15f;//Of current tile
						float zpos = Random.Range (tileHeight, 4f);
						//AgentMoveToPosition( GameWorldController.instance.currentTileMap().getTileVector(DestTileX, DestTileY,zpos));	
						targetBaseOffset = 0.5f;//tileHeight + 0.2f ;//zpos - tileHeight;
						startBaseOffset = Agent.baseOffset;
						floatTime = 1f;
						AgentMoveToPosition (GameWorldController.instance.currentTileMap ().getTileVector (DestTileX, DestTileY));
				}
				AgentMoveToPosition (GameWorldController.instance.currentTileMap ().getTileVector (DestTileX, DestTileY));
		}

		void AgentStand ()
		{
				if (Agent.isOnNavMesh)
				{
						destinationVector = this.transform.position;
						Agent.destination = this.transform.position;
						Agent.isStopped = true;
				}
		}

		void AgentMoveToPosition(Vector3 dest)
		{
				if (Agent.isOnNavMesh)
				{
						destinationVector = dest;
						Agent.destination=dest;
						Agent.isStopped=false;	
				}
		}

		void UpdateGTarg ()
		{
				//Update GTarg
				if (npc_gtarg <= 1)//PC
				{
						gtargName = "_Gronk";
						if (gtarg == null) {
								gtarg = UWCharacter.Instance.transform.gameObject;
						}
						else {
								if (gtarg.name != "_Gronk") {
										gtarg = UWCharacter.Instance.transform.gameObject;
								}
						}
				}
				else {
						//Inbuilt NPC Gtargs not supported.
						if (gtarg == null) {
								if (gtargName != "") {
										gtarg = GameObject.Find (gtargName);
								}
						}
						else {
								if (gtarg.name != gtargName) {
										gtarg = GameObject.Find (gtargName);
								}
						}
						if (gtarg == null) {
								//I no longer have a goal. Check what I was doing and revert to a different state.
								//Cases
								if ((npc_attitude > 0) && (gtargName != "") && ((npc_goal == (short)npc_goals.npc_goal_attack_5) || (npc_goal == (short)npc_goals.npc_goal_attack_9))) {
										//NPC Follower who has killed their target->Follow player.
										npc_goal = (short)npc_goals.npc_goal_follow;
										npc_gtarg = 1;
										gtarg = UWCharacter.Instance.transform.gameObject;
								}
								if ((npc_attitude == 0) && (gtargName != "") && ((npc_goal == (short)npc_goals.npc_goal_attack_5) || (npc_goal == (short)npc_goals.npc_goal_attack_9))) {
										//NPC Enemy who has defeated their attacker->Focus on player.
										npc_goal = (short)npc_goals.npc_goal_attack_5;
										npc_gtarg = 1;
										gtarg = UWCharacter.Instance.transform.gameObject;
								}
						}
				}
		}

		/// <summary>
		/// Tests if the NPCs line of sight to the target is not interupted by a door or a wall
		/// </summary>
		/// <returns><c>true</c>, if can attack was agented, <c>false</c> otherwise.</returns>
		/// <param name="src">Source.</param>
		/// <param name="target">Target.</param>
		/// <param name="targetGtarg">Target gtarg.</param>
		/// <param name="range">Range.</param>
		bool AgentCanAttack(Vector3 src, Vector3 target, GameObject targetGtarg, float range)
		{				
			return ! Physics.Linecast(src,target, GameWorldController.instance.MapMeshLayerMask |  GameWorldController.instance.DoorLayerMask);
		}

		/// <summary>
		/// Applies the attack to the NPC
		/// </summary>
		/// <returns><c>true</c>, if attack was applyed, <c>false</c> otherwise.</returns>
		/// <param name="damage">Damage.</param>
		/// NPC becomes hostile on attack. 
		public override bool ApplyAttack(short damage)
		{
				if (! ( (_RES==GAME_UW1) && (objInt().item_id==124) ) )
				{//Do not apply damage if attaching the slasher of veils.
						npc_hp=(short)(npc_hp-damage);
						UWHUD.instance.MonsterEyes.SetTargetFrame(npc_hp, StartingHP );	
				}
				return true;
		}

		/// <summary>
		/// Applies the attack from a known source
		/// </summary>
		/// <returns>true</returns>
		/// <c>false</c>
		/// <param name="damage">Damage.</param>
		/// <param name="source">Source.</param>
		public override bool ApplyAttack (short damage, GameObject source)
		{
				if (source!=null)
				{
						if (source.name=="_Gronk")
						{//PLayer attacked the npc
								npc_attitude=0;//Make the npc angry with the player.
								if(Frozen==false)
								{	
										//Assumes the player has attacked
										npc_gtarg=1;
										gtarg=UWCharacter.Instance.gameObject;
										gtargName=gtarg.name;
										npc_goal=(short)npc_goals.npc_goal_attack_5;
										if (npc_hp<5)//Low health. 20% Chance for morale break
										{
												if (Random.Range(0,5)>=4)
												{
														UWCharacter.Instance.PlayerMagic.CastEnchantment(source,this.gameObject,SpellEffect.UW1_Spell_Effect_CauseFear,Magic.SpellRule_TargetOther,-1);
												}
										}
								}	

								//Alert nearby npcs that i have been attacked.
								//Will alert npcs of same item id or an allied type. (eg goblins & trolls)
								foreach (Collider Col in Physics.OverlapSphere(this.transform.position,8.0f))
								{
										if (Col.gameObject.GetComponent<NPC>()!=null)
										{
												if (AreNPCSAllied(this,Col.gameObject.GetComponent<NPC>()))
												{
														Col.gameObject.GetComponent<NPC>().npc_attitude=0;//Make the npc angry with the player.
														Col.gameObject.GetComponent<NPC>().npc_gtarg=1;
														Col.gameObject.GetComponent<NPC>().gtarg=UWCharacter.Instance.gameObject;
														Col.gameObject.GetComponent<NPC>().gtargName=gtarg.name;
														Col.gameObject.GetComponent<NPC>().npc_goal=(short)npc_goals.npc_goal_attack_5;
												}
										}
								}
						}
						//else
						//{//NPC attack
						//		gtargName=source.name;
						//		//Makes the targeted entity attack the object that attacked it.
						//		npc_gtarg=999;
						//		gtarg=source;
						//		gtargName=source.name;
						//		npc_goal=(short)npc_goals.npc_goal_attack_5;;				
						//}	
				}

				ApplyAttack(damage);
				return true;
		}

		static bool AreNPCSAllied(NPC srcNPC, NPC dstNPC)
		{
				return (srcNPC.GetRace()==dstNPC.GetRace());
		}

		/// <summary>
		/// Begins a conversation if possible
		/// </summary>
		/// <returns><c>true</c>, if to was talked, <c>false</c> otherwise.</returns>
		public override bool TalkTo()
		{//Begin a conversation.				
				GameWorldController.instance.convVM.RunConversation(this);
				return true;
		}

		/// <summary>
		/// Looks at the NPC
		/// </summary>
		/// <returns>The <see cref="System.Boolean"/>.</returns>
		public override bool LookAt ()
		{//TODO:For specific characters that don't follow the standard naming convention use their conversation for the lookat.
				string output="";
				if (objInt().item_id!=123)//Tybal
				{
						output = StringController.instance.GetFormattedObjectNameUW(objInt(),NPCMoodDesc());
				}
				if ((npc_whoami >=1) && (npc_whoami<255)) 
				{
						if (npc_whoami==231)//Tybal
						{
								output= "You see Tybal";
						}
						else if (npc_whoami==207)
						{//Warren spectre.
								output= "You see an " + NPCMoodDesc() + " " + StringController.instance.GetString (7,npc_whoami+16);
						}
						else
						{
								if(npc_talkedto!=0)
								{
										output=output+" named " + StringController.instance.GetString (7,npc_whoami+16);
								}				
						}

				}
				UWHUD.instance.MessageScroll.Add (output);
				return true;
		}


		/// <summary>
		/// Gives a mood string for NPCs
		/// </summary>
		/// <returns>The mood desc.</returns>
		private string NPCMoodDesc()
		{	//004€005€096€hostile
				//004€005€097€upset
				//004€005€098€mellow
				//004€005€099€friendly
				switch (npc_attitude)
				{
				case 0:
						return StringController.instance.GetString (5,96);
				case 1:
						return StringController.instance.GetString (5,97);
				case 2:
						return StringController.instance.GetString (5,98);
				default:
						return StringController.instance.GetString (5,99);

				}
		}


		/// <summary>
		///Updates the appearance of the NPC
		/// </summary>
		/// Calculates the relative angle to the NPC
		void UpdateSprite () {
				//Get the relative vector between the player and the npc.
				direction = UWCharacter.Instance.gameObject.transform.position - this.gameObject.transform.position;
				//Convert the direction into an angle.
				angle = Mathf.Atan2(direction.x,direction.z) * Mathf.Rad2Deg;

				//Get the relative compass heading of the NPC.
				currentHeading = CompassHeadings[ (int)Mathf.Round((  (this.gameObject.transform.eulerAngles.y % 360) / 45f)) ];

				//Get an animation index number for the angle
				facingIndex = facing(angle);

				//Check the facing index and the animation range to see if they have changed since the last update.
				if ((PreviousFacing!=facingIndex) && (AnimRange!=PreviousAnimRange))
				{
						PreviousFacing=facingIndex;
						PreviousAnimRange=AnimRange;
				}
				//Offset the compass heading by the players relative heading.
				CalcedFacing=(short)(facingIndex + currentHeading);
				if (CalcedFacing>=8)//Make sure it wrapps around correcly between 0 and 7 ->The compass headings.
				{
						CalcedFacing=(short)(CalcedFacing-8);
				}
				if (CalcedFacing<=-8)
				{
						CalcedFacing=(short)(CalcedFacing+8);
				}
				if (CalcedFacing<0)
				{
						CalcedFacing=(short)(8+CalcedFacing);
				}
				else if (CalcedFacing>7)
				{
						CalcedFacing=(short)(8-CalcedFacing);
				}

				//Calculate an animation index from the facing and the animation range.
				//0=front
				//1=frontright
				//7=frontleft

				//CalcFacingForDebug=CalcedFacing;
				if (
						((AnimRange== AI_ANIM_ATTACK_BASH) && (!((CalcedFacing==0)||(CalcedFacing==1)||(CalcedFacing==7)) ))
						||
						((AnimRange== AI_ANIM_ATTACK_SLASH) && (!((CalcedFacing==0)||(CalcedFacing==1)||(CalcedFacing==7)) ))
						||
						((AnimRange== AI_ANIM_ATTACK_THRUST) &&  (!((CalcedFacing==0)||(CalcedFacing==1)||(CalcedFacing==7)) ))
						||
						((AnimRange== AI_ANIM_COMBAT_IDLE) && (!((CalcedFacing==0)||(CalcedFacing==1)||(CalcedFacing==7)) ))
				)
				{
						CalcedFacing=(short)((CalcedFacing+1)*1);//Use an idle animation if we can't see the attack
				}
				else
				{
						CalcedFacing=(short)((CalcedFacing+1)*AnimRange);
				}


				//play the calculated animation.
				switch (CalcedFacing)
				{
				case AI_ANIM_IDLE_FRONT:
						{	
								playAnimation(14,false);
								//playAnimation(NPC_ID +"_idle_front",CalcedFacing);
								break;
						}
				case AI_ANIM_IDLE_FRONT_RIGHT:
						{	
								playAnimation(13,false);
								//playAnimation(NPC_ID +"_idle_front_right",CalcedFacing);
								break;
						}
				case AI_ANIM_IDLE_RIGHT:
						{	
								playAnimation(12,false);
								//playAnimation(NPC_ID +"_idle_right",CalcedFacing);
								break;
						}
				case AI_ANIM_IDLE_REAR_RIGHT:
						{	
								playAnimation(11,false);
								//playAnimation(NPC_ID +"_idle_rear_right",CalcedFacing);
								break;
						}
				case AI_ANIM_IDLE_REAR:
						{	
								playAnimation(10,false);
								//playAnimation(NPC_ID +"_idle_rear",CalcedFacing);
								break;
						}
				case AI_ANIM_IDLE_REAR_LEFT:
						{	
								playAnimation(17,false);
								//playAnimation(NPC_ID + "_idle_rear_left",CalcedFacing);
								break;
						}
				case AI_ANIM_IDLE_LEFT:
						{	
								playAnimation(16,false);
								//	playAnimation(NPC_ID +"_idle_left",CalcedFacing);
								break;
						}
				case AI_ANIM_IDLE_FRONT_LEFT:
						{	
								playAnimation(15,false);								
								//playAnimation(NPC_ID +"_idle_front_left",CalcedFacing);
								break;
						}
				case AI_ANIM_WALKING_FRONT:
						{	
								playAnimation(22,false);								
								//playAnimation(NPC_ID +"_walking_front",CalcedFacing);
								break;
						}
				case AI_ANIM_WALKING_FRONT_RIGHT:
						{	
								playAnimation(21,false);
								//			playAnimation(NPC_ID + "_walking_front_right",CalcedFacing);
								break;
						}
				case AI_ANIM_WALKING_RIGHT:
						{	

								playAnimation(20,false);
								//playAnimation(NPC_ID + "_walking_right",CalcedFacing);
								break;
						}
				case AI_ANIM_WALKING_REAR_RIGHT:
						{	
								playAnimation(19,false);								
								//playAnimation(NPC_ID +"_walking_rear_right",CalcedFacing);
								break;
						}
				case AI_ANIM_WALKING_REAR:
						{	
								playAnimation(18,false);								
								//playAnimation(NPC_ID +"_walking_rear",CalcedFacing);
								break;
						}
				case  AI_ANIM_WALKING_REAR_LEFT:
						{	
								playAnimation(25,false);								
								//playAnimation(NPC_ID +"_walking_rear_left",CalcedFacing);
								break;
						}
				case  AI_ANIM_WALKING_LEFT:
						{	
								playAnimation(24,false);								
								//playAnimation(NPC_ID + "_walking_left",CalcedFacing);
								break;
						}
				case AI_ANIM_WALKING_FRONT_LEFT:
						{	
								playAnimation(23,false);								
								//playAnimation(NPC_ID + "_walking_front_left",CalcedFacing);
								break;
						}
				default://special non angled states
						{
								switch(AnimRange)
								{
								case AI_ANIM_DEATH:
										playAnimation(8,true);		break;								
										//playAnimation (NPC_ID +"_death",AI_ANIM_DEATH);break;
								case AI_ANIM_ATTACK_BASH:
										//playAnimation (NPC_ID +"_attack_bash",AI_ANIM_ATTACK_BASH);break;
										playAnimation(1,true);break;
								case AI_ANIM_ATTACK_SLASH:
										//playAnimation (NPC_ID +"_attack_slash",AI_ANIM_ATTACK_SLASH);break;
										playAnimation(2,true);break;
								case AI_ANIM_ATTACK_THRUST:
										//playAnimation (NPC_ID +"_attack_thrust",AI_ANIM_ATTACK_THRUST);break;
										playAnimation(3,true);break;
								case AI_ANIM_COMBAT_IDLE:
										//playAnimation (NPC_ID +"_combat_idle",AI_ANIM_COMBAT_IDLE);break;
										playAnimation(0,true);break;
								case AI_ANIM_ATTACK_SECONDARY:
										//playAnimation (NPC_ID +"_attack_secondary",AI_ANIM_ATTACK_SECONDARY);break;
										playAnimation(5,true);break;
								}
						}
						break;
				}
		}


		/// <summary>
		/// Breaks down the angle in the the facing sector. Clockwise from 0)
		/// </summary>
		/// <param name="angle">Angle.</param>
		short facing(float angle)
		{
				if ((angle >= -22.5) && (angle <= 22.5)) 
				{
						return 0;//*AnimRange;//Facing forward
				} 
				else 
				{
						if ((angle>22.5)&&(angle<=67.5))
						{//Facing forward left
								return 1;//*AnimRange;
						}
						else
						{
								if ((angle >67.5)&&(angle<=112.5))
								{//facing (right)
										return 2;//*AnimRange;
								}
								else
								{
										if ((angle >112.5)&&(angle<=157.5))
										{//Facing away left
												return 3;//*AnimRange;
										}
										else
										{
												if (((angle >157.5)&&(angle<=180.0)) || ((angle>=-180)&&(angle<=-157.5)))
												{//Facing away
														return 4;//*AnimRange;
												}
												else
												{
														if ((angle >=-157.5)&&(angle<-112.5))
														{//Facing away right
																return 5;//*AnimRange;
														}
														else
														{
																if ((angle >-112.5)&&(angle<-67.5))
																{//Facing (left)
																		return 6;//*AnimRange;
																}
																else
																{
																		if ((angle >-67.5)&&(angle<-22.5))
																		{//Facing forward right
																				return 7;//*AnimRange;
																		}
																		else
																		{
																				return 0;//*AnimRange;//default
																		}
																}
														}
												}
										}
								}
						}
				}
		}

		protected void playAnimation(int index, bool isConstantAnim)
		{
				newAnim.Play(index,isConstantAnim);
		}


		/// <summary>
		/// NPC tries to hit the player.
		/// </summary>
		public void ExecuteAttack()
		{
				if(ConversationVM.InConversation){return;}

				if(gtarg==null)
				{
						return;
				}
				float weaponRange=1.5f;

				//NPC tries to raycast at the player or object
				Vector3 TargetingPoint;
				//if (gtarg.name=="_Gronk")
				//{//Try and hit the player
				//		TargetingPoint=UWCharacter.Instance.TargetPoint.transform.position;
				//}
				//else
				//{//Trying to hit an object						
					TargetingPoint=gtarg.GetComponent<UWEBase>().GetImpactPoint();//Aims for the objects impact point	
				//}

				Ray ray= new Ray(NPC_Launcher.transform.position,TargetingPoint-NPC_Launcher.transform.position);

				RaycastHit hit = new RaycastHit(); 
				if (Physics.Raycast(ray,out hit,weaponRange))
				{	
						if (hit.transform.Equals(this.transform))
						{
								Debug.Log ("you've hit yourself ? " + hit.transform.name);
						}
						else
						{			
								if (hit.transform.name == UWCharacter.Instance.name)
								{	
										UWCombat.NPC_Hits_PC(UWCharacter.Instance,this);
								}
								else
								{						
										//Has it hit another npc or object
										if (hit.transform.GetComponent<NPC>()!=null)
										{
												UWCombat.NPC_Hits_NPC(hit.transform.GetComponent<NPC>(), this);
										}
										else if (hit.transform.GetComponent<ObjectInteraction>()!=null)
										{
												short attackDamage =(short)Random.Range(1, GetDamage()+1);
												hit.transform.GetComponent<ObjectInteraction>().Attack(attackDamage, this.gameObject);	
										}
										else
										{
												Impact.SpawnHitImpact(Impact.ImpactDamage(), GetImpactPoint(),46,50);
										}
								}
						}
				}
		}
		/// <summary>
		/// NPC casts a spell.
		/// </summary>
		public void ExecuteMagicAttack()
		{
				if (Vector3.Distance(this.transform.position, UWCharacter.Instance.CameraPos)>8)
				{
						return;						
				}
				UWCharacter.Instance.PlayerMagic.CastEnchantmentImmediate(NPC_Launcher,gtarg,SpellIndex(),Magic.SpellRule_TargetVector,Magic.SpellRule_Immediate);
		}

		/// <summary>
		/// Executes the ranged attack.
		/// </summary>
		public void ExecuteRangedAttack()
		{
				if (Vector3.Distance(this.transform.position, UWCharacter.Instance.CameraPos)>8)
				{
						return;						
				}
				Vector3 TargetingPoint;
				//if (gtarg.name=="_Gronk")
				//{//Try and hit the player
				//		TargetingPoint=UWCharacter.Instance.TargetPoint.transform.position;
				//}
				//else
				//{//Trying to hit an object						
				TargetingPoint=gtarg.GetComponent<UWEBase>().GetImpactPoint();//Aims for the objects impact point	
				//}
				Vector3 TargetingVector = (TargetingPoint-NPC_Launcher.transform.position).normalized;
				TargetingVector=TargetingVector + new Vector3(0.0f,0.3f,0.0f);//Try and give the vector an arc
				Ray ray= new Ray(NPC_Launcher.transform.position,TargetingVector);
				RaycastHit hit = new RaycastHit(); 
				float dropRange=0.5f;
				if (!Physics.Raycast(ray,out hit,dropRange))
				{///Checks No object interferes with the launch
						float force =100f*Vector3.Distance(TargetingPoint,NPC_Launcher.transform.position);

						ObjectLoaderInfo newobjt = ObjectLoader.newObject(16,0,0,1,256);
						newobjt.is_quant=1;
						GameObject launchedItem = ObjectInteraction.CreateNewObject(GameWorldController.instance.currentTileMap(),newobjt, GameWorldController.instance.LevelMarker().gameObject,ray.GetPoint(dropRange-0.1f)).gameObject;

						GameWorldController.UnFreezeMovement(launchedItem);
						Vector3 ThrowDir = TargetingVector;
						///Apply the force along the direction of the ray that the player has targetted along.
						launchedItem.GetComponent<Rigidbody>().AddForce(ThrowDir*force);
						GameObject myObjChild = new GameObject(launchedItem.name + "_damage");
						myObjChild.transform.position =launchedItem.transform.position;
						myObjChild.transform.parent =launchedItem.transform;
						///Appends ProjectileDamage to the projectile to act as the damage delivery method.
						ProjectileDamage pd= myObjChild.AddComponent<ProjectileDamage>();
						pd.Source=this.gameObject;
						pd.Damage=(short)GameWorldController.instance.objDat.rangedStats[0].damage;//sling damage.
						pd.AttackCharge=100f;
						pd.AttackScore =GetAttack();//Assuming there is no special ranged attack score?
						pd.ArmourDamage=GetArmourDamage();
						Ammo--;
				}
		}

		public override string ContextMenuDesc (int item_id)
		{
				if ((npc_talkedto!=0) && (npc_whoami!=0))
				{
						return StringController.instance.GetString (7,npc_whoami+16);
				}	
				else
				{
						return base.ContextMenuDesc(item_id);
				}
		}

		public override string ContextMenuUsedDesc()
		{
				TalkAvail=true;
				return base.ContextMenuUsedDesc();
		}

		public override string UseVerb ()
		{
				return "talk";
		}

		public override Vector3 GetImpactPoint ()
		{
				return NPC_Launcher.transform.position;
		}

		public override GameObject GetImpactGameObject ()
		{
				return NPC_Launcher;
		}

		/// <summary>
		/// Returns the object that this NPC is targeting
		/// </summary>
		/// <returns>The gtarg.</returns>
		public GameObject getGtarg()
		{
				return gtarg;
		}


		public int GetAttack()
		{
				return GameWorldController.instance.objDat.critterStats[objInt().item_id-64].AttackPower;
		}

		public int GetDamage()
		{
				return GameWorldController.instance.objDat.critterStats[objInt().item_id-64].AttackDamage[CurrentAttack];
		}

		public int GetDefence()
		{
				return GameWorldController.instance.objDat.critterStats[objInt().item_id-64].Defence;	
		}

		public int GetArmourDamage()
		{
				return GameWorldController.instance.objDat.critterStats[objInt().item_id-64].EquipDamage;
		}

		public int GetRace()
		{
				return GameWorldController.instance.objDat.critterStats[objInt().item_id-64].Race;
		}

		public int Room()
		{
				int tileX = (int)(transform.position.x/1.2f);
				int tileY = (int)(transform.position.z/1.2f);
				if (TileMap.ValidTile(tileX, tileY))
				{
						return GameWorldController.instance.currentTileMap().Tiles[tileX,tileY].roomRegion;
				}
				else
				{
						return 0;
				}
		}

		/// <summary>
		/// What spell the NPC should use
		/// </summary>
		/// <returns>The index.</returns>
		public int SpellIndex()
		{
				switch(_RES)
				{
				case GAME_UW2:
						return SpellEffect.UW1_Spell_Effect_MagicArrow_alt01;//Magic arrow 

				default:
						switch(objInt().item_id)
						{
						case 69://Acid slug
								return SpellEffect.UW1_Spell_Effect_Acid_alt01;
						case 120://Fire elemental
								return SpellEffect.UW1_Spell_Effect_Fireball_alt01;
						case 123:
								return SpellEffect.UW1_Spell_Effect_SheetLightning_alt01;
						default:
								return SpellEffect.UW1_Spell_Effect_MagicArrow_alt01;//Magic arrow 
						}
				}

		}

		void SetRandomAttack()
		{
				int AttackProb = Random.Range(1,100);
				//NPC npc = ai.Body.GetComponent<NPC>();
				int AccumulatedProb=0;
				int AnimSelected=0;
				for ( AnimSelected=0;AnimSelected<=GameWorldController.instance.objDat.critterStats[NPC_IDi-64].AttackProbability.GetUpperBound(0);AnimSelected++)
				{		
						AccumulatedProb+=GameWorldController.instance.objDat.critterStats[NPC_IDi-64].AttackProbability[AnimSelected];
						if (AttackProb<=AccumulatedProb)
						{
								CurrentAttack=AnimSelected;
								break;
						}
				}

				switch (AnimSelected)
				{
				case 1:
						AnimRange=NPC.AI_ANIM_ATTACK_SLASH;break;
				case 2:					
						AnimRange=NPC.AI_ANIM_ATTACK_THRUST;break;
				case 0:
				default:
						AnimRange=NPC.AI_ANIM_ATTACK_BASH;break;
				}


		}



		void SetRandomDestination()
		{
				int distanceMultipler=1;//For frightened NPCs

				if (npc_gtarg==6)
				{
						distanceMultipler=3;//Runs further away from it's current location.
				}
				//Get a random spot.
				bool DestFound=false;
				Vector3 curPos = transform.position;
				Vector3 dest =curPos;
				int tileX = (int)(curPos.x/1.2f);
				int tileY = (int)(curPos.z/1.2f);
				DestTileX =tileX;
				DestTileY=tileY;
				//int ValidRoom = npc.Room();
				for (int i=0; i<5;i++)
				{
						DestTileX = tileX + Random.Range(-2*distanceMultipler,3*distanceMultipler);
						DestTileY = tileY + Random.Range(-2*distanceMultipler,3*distanceMultipler);
						//if (GameWorldController.instance.currentTileMap().GetTileType(newTileX,newTileY) != TileMap.TILE_SOLID)
						if (Room()== GameWorldController.instance.currentTileMap().GetRoom(DestTileX,DestTileY))
						{
								DestFound=true;
								break;
						}	
						if (DestFound==false)
						{
								DestTileX=tileX;
								DestTileY=tileY;
						}
				}

				//Move back home if too far away
				float xDist2=Mathf.Pow(DestTileX-npc_xhome,2f);
				float yDist2=Mathf.Pow(DestTileY-npc_yhome,2f);
				if (yDist2+xDist2>=10)
				{
						DestTileX=npc_xhome;
						DestTileY=npc_yhome;							
				}

		}


		void PerformDeathAnim()
		{
				AnimRange= NPC.AI_ANIM_DEATH;
				MusicController.LastAttackCounter=0.0f;//Stops combat music unil the next time the player is hit
				GameWorldController.instance.getMus().PlaySpecialClip(GameWorldController.instance.getMus().VictoryTracks); //plays the fanfare
				WaitTimer =0.8f;
		}


		void DumpRemains()
		{
				//Spawn a bloodstain at this spot.
				int bloodstain=-1;
				//Nothing = 0x00, 
				//RotwormCorpse = 0x20, //A??????
				//Rubble = 0x40, 
				//WoodChips = 0x60, 
				//Bones = 0x80, 
				//GreenBloodPool = 0xA0, 
				//RedBloodPool = 0xC0, 
				//RedBloodPoolGiantSpider = 0xE0. 

				//switch (GameWorldController.instance.critterData.Remains[objInt.item_id-64])
				switch (GameWorldController.instance.objDat.critterStats[objInt().item_id-64].Remains)
				{
				case 0x2://Rotworm corpse
						bloodstain=217;
						break;
				case 0x4://Rubble
						bloodstain=218;
						break;
				case 0x6://Woodchips
						bloodstain=219;
						break;
				case 0x8://Bones
						bloodstain=220;
						break;
				case 0xA://Greenblood
						bloodstain=221;
						break;
				case 0xC://Redblood
						bloodstain=222;
						break;
				case 0xE://RedBloodPoolGiantSpider
						bloodstain=223;
						break;
				case 0://Nothing
						bloodstain=-1;
						break;
				default:
						Debug.Log(this.name + " should drop " + GameWorldController.instance.objDat.critterStats[objInt().item_id-64].Remains);
						bloodstain=-1;
						break;
				}

				if(bloodstain!=-1)
				{
						ObjectLoaderInfo newobjt= ObjectLoader.newObject(bloodstain,0,0,0,256);
						ObjectInteraction.CreateNewObject(GameWorldController.instance.currentTileMap(),newobjt, GameWorldController.instance.LevelMarker().gameObject,this.transform.position);
						//ObjectInteraction remains = ObjectInteraction.CreateNewObject(bloodstain);						
						//remains.gameObject.transform.parent=GameWorldController.instance.LevelMarker();
						//GameWorldController.MoveToWorld(remains.gameObject);
						//remains.transform.position=ai.Body.transform.position;
				}

				Destroy(this.gameObject);

		}

		public static int findNpcByWhoAmI(int whoami)
		{

				ObjectLoaderInfo[] objList = GameWorldController.instance.CurrentObjectList().objInfo;
				for (int i=1; i<256;i++)
				{
						if (objList[i].npc_whoami==whoami)
						{
								return i;
						}
				}
			return -1;
		}


		public static void SetNPCLocation(int index, int xhome, int yhome, NPC.npc_goals NewGoal)
		{
				if (index<0){return;}
				ObjectInteraction obj=ObjectLoader.getObjectIntAt(index);
				if (obj!=null)
				{
						NPC npc = obj.GetComponent<NPC>();
						if (npc!=null)
						{
								npc.npc_xhome=(short)xhome;
								npc.npc_yhome=(short)yhome;
								if ((short)NewGoal>=0)
								{
										npc.npc_goal=(short)NewGoal;
								}
						}
				}
		}


		public short PoisonLevel()
		{
			return (short)GameWorldController.instance.objDat.critterStats[objInt().item_id-64].Poison;
		}
}

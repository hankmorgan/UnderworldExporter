using UnityEngine;
using System.Collections;
using RAIN.BehaviorTrees;
using RAIN.Core;
using RAIN.Minds;
/// <summary>
/// NPC Properties and AI
/// </summary>
/// Controls AI status, animation, conversations and general properties.
public class NPC : object_base {
	private static int[] CompassHeadings={0,-1,-2,-3,4,3,2,1,0};//What direction the npc is facing. To adjust it's animation
		public int poisondamage;
		public int AttackPower;
		public int AvgHit;
		public int height;
		public int radius;

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
	
	///Anim range defines which animation set to play.
	///Multiple of 10 for dividing animations
	///Angle index * Anim Range give AI_ANIM_X value to pick animation
	public int AnimRange=1;
	public int curranim=0;
	
	//public int CalcFacingForDebug;

	/// Object ID for the NPC
	private string NPC_ID;
	public int NPC_IDi;
	
	/// The animation that is currently set
	//private string CurrentAnim="";
	
	/// The animator that the NPC is using for it's animations
	//private Animator anim;

	public NPC_Animation newAnim;
	
	/// For tracking the state of the NPC
//	public int currentState=-1;

	/// Thinks this has to do with changing the NPC on the fly
	//private string oldNPC_ID;
	
	/// The animation index the NPC is facing
	private int facingIndex;
	/// Previous value for tracking changes
	private int PreviousFacing=-1;
	/// Previous value for tracking changes
	private int PreviousAnimRange=-1;
	/// The compass point (see heading array) the NPC is facing relative to the player
	private int CalcedFacing;
	
	///Integer representation of the current facing of the character. To match with animation angles
	private int currentHeading;
	//Direction between the player and the NPC for calculating relative angle
	private Vector3 direction;	//vector between the player and the ai.
	/// The angle to the character from the player.
	private float angle;

	/// The Navmesh region the NPC is in
	public string NavMeshRegion;

	//NPC Properties from Underworld
	public int npc_whoami;
	public int npc_xhome;        //  x coord of home tile
	public int npc_yhome;        //  y coord of home tile
//	public int npc_whoami;       //  npc conversation slot number
	public int npc_hunger;
	public int npc_health;
	public int npc_hp;
	public int npc_arms;          // (not used in uw1)
	public int npc_power;
	public int npc_goal;          // goal that NPC has; 5:kill player 6:? 9:?
	public int npc_attitude;       //attitude; 0:hostile, 1:upset, 2:mellow, 3:friendly
	public int npc_gtarg;         //goal target; 1:player
	
	private GameObject gtarg;
	public string gtargName;

	public int npc_talkedto;      // is 1 when player already talked to npc
	public int npc_level;
	public int npc_name;       //    (not used in uw1)

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
	public bool isUndead; 

	///Set state when not in combat or dying.
	///TODO: The state should be replaced with a combination of the above variables and match what UW does.
	//private int state=0; 

	///For storing spell effects applied to NPCs
	public SpellEffect[] NPCStatusEffects=new SpellEffect[3];

	///To flag initiation of the player into the AI modules
	//private static bool playerUWReady;
	///AI module for the character.
	private AIRig ai;	
	
	///Can the NPC fire off magic attacks.
	//public bool MagicAttack;	
	///Transform position to launch projectiles from
	public GameObject NPC_Launcher; 
	///What spell the NPC should cast if they have magicAttack==true
	private int SpellIndex; 

	private SpriteRenderer sprt;

	public string CurrentSpriteName="";
	public Sprite currentSpriteLoaded;

	private int Ammo=10;//How many ranged attacks can this NPC execute. (ie how much ammo can it spawn)
		/*
	void Awake () {
		anim=GetComponentInChildren<Animator>();
	}*/


	/// <summary>
	/// Initialise some basic info for the NPC ai.
	/// </summary>
	protected override void Start () {
		base.Start();
		NPC_IDi=objInt().item_id;
		poisondamage = GameWorldController.instance.objDat.critterStats[NPC_IDi-64].Poison;
		AttackPower = GameWorldController.instance.objDat.critterStats[NPC_IDi-64].AttackPower;
		AvgHit = GameWorldController.instance.objDat.critterStats[NPC_IDi-64].AvgHit;
		height=GameWorldController.instance.commonObject.properties[NPC_IDi].height;
		radius=GameWorldController.instance.commonObject.properties[NPC_IDi].radius;
		
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
		if (ai == null) {
			GameObject myInstance = Resources.Load ("AI_PREFABS/AI_LAND") as GameObject;
			GameObject newObj = (GameObject)GameObject.Instantiate (myInstance);
			NPC_ID=objInt().item_id.ToString();
			newObj.name = this.gameObject.name + "_AI";
			newObj.transform.position = Vector3.zero;
			newObj.transform.parent = this.gameObject.transform;
			newObj.transform.localPosition = Vector3.zero;
			AIRig aiR = newObj.GetComponent<AIRig> ();
			aiR.AI.Body = this.gameObject;
			ai = aiR;
			ai.AI.WorkingMemory.SetItem<GameObject> ("playerUW", GameWorldController.instance.playerUW.gameObject);
			ai.AI.WorkingMemory.SetItem<int> ("attackMode", 0);//Default to melee combat
			ai.AI.Body = this.gameObject;
			ai.AI.Motor.DefaultSpeed = 2.0f * (((float)GameWorldController.instance.objDat.critterStats[objInt().item_id-64].Speed / 12.0f));
			ai.AI.WorkingMemory.SetItem<float> ("Speed", ai.AI.Motor.DefaultSpeed);
			if (this.GetComponent<Animation>()!=null)
			{
				Destroy(this.GetComponent<Animation>()) ;
			}
		}
	}

	/// <summary>
	/// Raises the death events for the player.
	/// </summary>
	/// Uses the conversation for special npcs like Tybal, the Golem and the Beholder.
	/// Dumps out their inventory.
	void OnDeath()
	{
		//If the NPC has a conversation module check it to see if it has any special onDeath code. Eg Tybal, the Gazer on lvl2 and the Golem on Level 6
		Conversation cnv = this.GetComponent<Conversation>();
		if (cnv!=null)
		{
			if(cnv.OnDeath()==true)
			{
				return;
			}			
		}

		NPC_DEAD=true;//Tells the update to execute the NPC death animation
		//Dump npc inventory on the floor.
		Container cnt = this.GetComponent<Container>();
		if (cnt!=null)
		{
			cnt.SpillContents();//Spill contents is still not 100% reliable so don't expect to get all the items you want.
		}
		GameWorldController.instance.playerUW.AddXP(GameWorldController.instance.objDat.critterStats[objInt().item_id-64].Exp);
	}

	

	/// <summary>
	/// Update the NPC state, AI and animations
	/// </summary>
	/// AI is only active when the player is close.
	protected virtual void  Update () {
		if (EditorMode==true){return;}
		if (Frozen)
		{//NPC will not move until timer is complete.
			if (FrozenUpdate==0)
			{
				//anim.enabled=false;
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
			AI_INIT();
			ai.AI.WorkingMemory.SetItem<int>("state",AI_STATE_DYING);//Set to death state.
			return;
		}
		//if (anim==null)
		//{
		//	anim=GetComponentInChildren<Animator>();
		//}

		//The AI is only active when the player is within a certain distance to the player camera.
		if (Vector3.Distance(this.transform.position, GameWorldController.instance.playerUW.CameraPos)<=8)
			{
				if (objInt()!=null)
				{
					AI_INIT ();
					ai.AI.IsActive= Vector3.Distance(this.transform.position, GameWorldController.instance.playerUW.CameraPos)<=8;
					//anim.enabled=true;		
					//anim.enabled=false;		
					newAnim.enabled=true;
				}							
			}
			else
			{
				if (ai!=null)
				{
					ai.AI.IsActive=false;
				}
				//if (anim!=null)
				//{
				//	anim.enabled=false;		

				//}
				newAnim.enabled=false;
				return;
			}

			//Decide what attack modes to use
			switch (NPC_ID)
			{
			//Uses ranged weapons
			case "70":
			case "76":
			case "77":
			case "78":
				if ((Vector3.Distance(this.transform.position, GameWorldController.instance.playerUW.transform.position)>=2) && (Ammo>0))
				{//Ranged attack if far away
					ai.AI.WorkingMemory.SetItem<int>("attackMode",1);	
				}
				else
				{
					ai.AI.WorkingMemory.SetItem<int>("attackMode",0);		
				}
				break;
			//Uses magic attacks when not very near
			case "75":
			case "81":
			case "106":
			case "107":
			case "108":
			case "109":
			case "115":
			case "120":
			case "122":
			case "123":						
				if (Vector3.Distance(this.transform.position, GameWorldController.instance.playerUW.transform.position)>=2)
				{//Ranged attack if far away
					ai.AI.WorkingMemory.SetItem<int>("attackMode",2);	
					SpellIndex= SpellEffect.UW1_Spell_Effect_MagicArrow_alt01;//Magic arrow for the moment..
				}
				else
				{
					ai.AI.WorkingMemory.SetItem<int>("attackMode",0);		
				}
				break;
			default:
				ai.AI.WorkingMemory.SetItem<int>("attackMode",0);	//Melee attack
				break;
			}

			//Update the appearance of the NPC
			UpdateSprite();
			
				//Update GTarg
				if (npc_gtarg<=1)//PC
				{
					gtargName="_Gronk";
					if (gtarg==null)
					{
						gtarg=GameWorldController.instance.playerUW.transform.gameObject;				
					}
					else
					{
						if (gtarg.name!="_Gronk")
						{
							gtarg=GameWorldController.instance.playerUW.transform.gameObject;	
						}
					}
				}
				else
				{
					//Inbuilt NPC Gtargs not supported.
					
						if (gtarg==null)
						{
								if (gtargName!="")
								{
										gtarg=GameObject.Find(gtargName);
								}								
						}
						else
						{
								if (gtarg.name!=gtargName)
								{
									gtarg=GameObject.Find(gtargName);	
								}
						}
						if(gtarg==null)
						{//I no longer have a goal. Check what I was doing and revert to a different state.
							//Cases
								//NPC Follower who has killed their target->Follow player.
								if ((npc_attitude>0) && (gtargName!="") && ((npc_goal==5) || (npc_goal==9)))
									{
										npc_goal=3;
										npc_gtarg=1;
										gtarg=GameWorldController.instance.playerUW.transform.gameObject;
									}

								//NPC Enemy who has defeated their attacker->Focus on player.
								if ((npc_attitude==0) && (gtargName!="") && ((npc_goal==5) || (npc_goal==9)))
								{
										npc_goal=5;
										npc_gtarg=1;	
										gtarg=GameWorldController.instance.playerUW.transform.gameObject;
								}
						}

				}


			if (ai.AI.Navigator.CurrentPath!=null)
			{//Turns the AI around on their route.
				Vector3 NextPosition = ai.AI.Navigator.CurrentPath.GetWaypointPosition(ai.AI.Navigator.NextWaypoint);
				NextPosition.y= this.transform.position.y;//AI is kept level.
				ai.AI.WorkingMemory.SetItem<Vector3>("RotateTowards",NextPosition);
			}
			if ((npc_hp<=0))
			{//Begin death handling.
				OnDeath();
			}
			else
			{
				//If the player comes close and I'm hostile. Make sure I go to combat mode.
				//Make this variable the detection range when stealth spells are created
				if ((npc_attitude==0) && (Vector3.Distance(this.transform.position, GameWorldController.instance.playerUW.transform.position)<=GameWorldController.instance.playerUW.DetectionRange))		
				{
					npc_goal=5;	//Attack player
					npc_gtarg=1;
				}
				switch (npc_goal)
				{
					case 0://Standing still
					case 7:
					case 10:
					case 11:
						ai.AI.WorkingMemory.SetItem<int>("state",AI_STATE_STANDING);
						break;

					case 1://Wander randomly
					case 2:
					case 4:
					case 8:
						ai.AI.WorkingMemory.SetItem<int>("state",AI_STATE_IDLERANDOM);						
						break;

					case 5://Attack target
					case 9:
						ai.AI.WorkingMemory.SetItem<int>("state",AI_STATE_COMBAT);//Set to combat state.
						Vector3 AB = this.transform.position - gtarg.transform.position;
						Vector3 Movepos = gtarg.transform.position + (0.9f * AB.normalized) ;
						ai.AI.WorkingMemory.SetItem<Vector3>("MoveTarget",Movepos);
						break;

					case 6://Run away (morale failure)
						ai.AI.WorkingMemory.SetItem<int>("state",AI_STATE_FLEE);//Set to idle
						break;

					case 3://Follow target
					
						if (gtarg!=null)
						{
							Vector3 ABf =this.transform.position - gtarg.transform.position;
							Vector3 MoveposF = gtarg.transform.position + (0.9f * ABf.normalized) ;
							ai.AI.WorkingMemory.SetItem<Vector3>("MoveTarget",MoveposF);
							ai.AI.WorkingMemory.SetItem<int>("state",AI_STATE_FOLLOW);//Set to idle										
						
							if (gtarg.name=="_Gronk")
							{//Help out the player dynamically
								if (GameWorldController.instance.playerUW.HelpMeMyFriends==true)
								{
								GameWorldController.instance.playerUW.HelpMeMyFriends=false;
								//If I'm not already busy with another NPC
									if(GameWorldController.instance.playerUW.LastEnemyToHitMe!=null)
									{
										gtarg=GameWorldController.instance.playerUW.LastEnemyToHitMe;
										npc_goal=5;
										npc_gtarg=999;
										gtargName=GameWorldController.instance.playerUW.LastEnemyToHitMe.name;																
									}

								}
							}
						}
					break;
								
				}
			}
		}

		/*
		public void LateUpdate()
		{
				return;
				if (GameWorldController.instance.critsLoader[NPC_IDi-64]==null)
			{
					return;
			}
			if (sprt==null)
			{
				sprt=this.GetComponentInChildren<SpriteRenderer>();	
			}
				if (sprt.sprite==null)
				{
						return;
				}
			if(CurrentSpriteName != sprt.sprite.name)
			{
				CurrentSpriteName= sprt.sprite.name;
				currentSpriteLoaded= GameWorldController.instance.critsLoader[NPC_IDi-64].RetrieveSpriteByName(CurrentSpriteName, CritterInfo.TranslateAnimToIndex(CritterInfo.TranslateAnimRangeToAnim(curranim)));
			}
			sprt.sprite=currentSpriteLoaded;
		}
	*/

	/// <summary>
	/// Applies the attack to the NPC
	/// </summary>
	/// <returns><c>true</c>, if attack was applyed, <c>false</c> otherwise.</returns>
	/// <param name="damage">Damage.</param>
	/// NPC becomes hostile on attack. 
	public override bool ApplyAttack(int damage)
	{
		npc_hp=npc_hp-damage;
		return true;
	}

	/// <summary>
	/// Applies the attack from a known source
	/// </summary>
	/// <returns>true</returns>
	/// <c>false</c>
	/// <param name="damage">Damage.</param>
	/// <param name="source">Source.</param>
	public override bool ApplyAttack (int damage, GameObject source)
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
					gtarg=GameWorldController.instance.playerUW.gameObject;
					gtargName=gtarg.name;
					npc_goal=5;
					if (npc_hp<5)//Low health. 20% Chance for morale break
					{
					if (Random.Range(0,5)>=4)
						{
							GameWorldController.instance.playerUW.PlayerMagic.CastEnchantment(source,this.gameObject,SpellEffect.UW1_Spell_Effect_CauseFear,Magic.SpellRule_TargetOther);
						}
					}
				}	
			}
			else
			{//NPC attack
				gtargName=source.name;
				//Makes the targeted entity attack the object that attacked it.
				npc_gtarg=999;
				gtarg=source;
				gtargName=source.name;
				npc_goal=5;				
			}	
		}

		ApplyAttack(damage);
		return true;
	}

	/// <summary>
	/// Begins a conversation if possible
	/// </summary>
	/// <returns><c>true</c>, if to was talked, <c>false</c> otherwise.</returns>
	public override bool TalkTo()
	{//Begin a conversation.
		string npcname="";
		if ((npc_whoami == 255))
		{
			//006~007~001~You get no response.
			UWHUD.instance.MessageScroll.Add (StringController.instance.GetString (7,1));
		}
		else
		{
			if (npc_whoami==0)
			{//Generic conversation.
				ObjectInteraction objInt=this.GetComponent<ObjectInteraction>();
				npcname= StringController.instance.GetFormattedObjectNameUW(objInt);
				//npc_whoami=256+(objInt.item_id -64);
			}
			if (npc_whoami>255)
			{//Generic conversation.
				ObjectInteraction objInt=this.GetComponent<ObjectInteraction>();
				npcname= StringController.instance.GetSimpleObjectNameUW(objInt);
			}
			switch (npc_whoami)
			{

			default:
				{
						UWCharacter.InteractionMode=UWCharacter.InteractionModeInConversation;//Set converation mode.
						Conversation.CurrentConversation=npc_whoami;//To make obsolete
						Conversation.InConversation=true;
						if (npcname=="")
						{
								UWHUD.instance.NPCName.text= StringController.instance.GetString (7,npc_whoami+16);						
						}
						else
						{
								UWHUD.instance.NPCName.text=npcname;	
						}				
						UWHUD.instance.PCName.text= GameWorldController.instance.playerUW.CharName;
						GameWorldController.instance.convVM.RunConversation(this);
						break;		
				}
								/*
				case -1:
					{
						Conversation cnv =this.GetComponent<Conversation>();
						if (cnv!=null)
						{	
								UWCharacter.InteractionMode=UWCharacter.InteractionModeInConversation;//Set converation mode.
								Conversation.CurrentConversation=npc_whoami;
								Conversation.InConversation=true;
								//cnv.WhoAmI=npc_whoami;
								if (npcname=="")
								{
										UWHUD.instance.NPCName.text= StringController.instance.GetString (7,npc_whoami+16);						
								}
								else
								{
										UWHUD.instance.NPCName.text=npcname;	
								}				
								UWHUD.instance.PCName.text= GameWorldController.instance.playerUW.CharName;
								for (int c = 0; c<=GameWorldController.instance.bGlobals.GetUpperBound(0);c++)
								{
										if (npc_whoami== GameWorldController.instance.bGlobals[c].ConversationNo)
										{
												cnv.privateVariables = new int[GameWorldController.instance.bGlobals[c].Globals.GetUpperBound(0)+1];
												for (int x=0; x<= GameWorldController.instance.bGlobals[c].Globals.GetUpperBound(0);x++)
												{
														//Copy Private variables
														cnv.privateVariables[x]	= GameWorldController.instance.bGlobals[c].Globals[x];								
												}
												break;
										}
								}

								StartCoroutine(cnv.main ());//Conversations operate in coroutines to allow interaction
						}
						else
						{
								//You get no response
								UWHUD.instance.MessageScroll.Add (StringController.instance.GetString (7,1));
						}
						break;		
					}*/

			}


		}
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
				if(objInt().isIdentified==true)
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
		//if (anim == null)
		//{
		//	anim = GetComponentInChildren<Animator>();
		//}
		//Get the relative vector between the player and the npc.
		direction = GameWorldController.instance.playerUW.gameObject.transform.position - this.gameObject.transform.position;
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
		CalcedFacing=facingIndex + currentHeading;
		if (CalcedFacing>=8)//Make sure it wrapps around correcly between 0 and 7 ->The compass headings.
		{
			CalcedFacing=CalcedFacing-8;
		}
		if (CalcedFacing<=-8)
		{
			CalcedFacing=CalcedFacing+8;
		}
		if (CalcedFacing<0)
		{
			CalcedFacing=8+CalcedFacing;
		}
		else if (CalcedFacing>7)
		{
			CalcedFacing=8-CalcedFacing;
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
			CalcedFacing=(CalcedFacing+1)*1;//Use an idle animation if we can't see the attack
		}
		else
		{
			CalcedFacing=(CalcedFacing+1)*AnimRange;				
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
			playAnimation(22,true);								
			//playAnimation(NPC_ID +"_walking_front",CalcedFacing);
			break;
		}
		case AI_ANIM_WALKING_FRONT_RIGHT:
		{	
			playAnimation(21,true);
//			playAnimation(NPC_ID + "_walking_front_right",CalcedFacing);
			break;
		}
		case AI_ANIM_WALKING_RIGHT:
		{	

			playAnimation(20,true);
			//playAnimation(NPC_ID + "_walking_right",CalcedFacing);
			break;
		}
		case AI_ANIM_WALKING_REAR_RIGHT:
		{	
			playAnimation(19,true);								
			//playAnimation(NPC_ID +"_walking_rear_right",CalcedFacing);
			break;
		}
		case AI_ANIM_WALKING_REAR:
		{	
			playAnimation(18,true);								
			//playAnimation(NPC_ID +"_walking_rear",CalcedFacing);
			break;
		}
		case  AI_ANIM_WALKING_REAR_LEFT:
		{	
			playAnimation(25,true);								
			//playAnimation(NPC_ID +"_walking_rear_left",CalcedFacing);
			break;
		}
		case  AI_ANIM_WALKING_LEFT:
		{	
			playAnimation(24,true);								
			//playAnimation(NPC_ID + "_walking_left",CalcedFacing);
			break;
		}
		case AI_ANIM_WALKING_FRONT_LEFT:
		{	
			playAnimation(23,true);								
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
	int facing(float angle)
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

	void playAnimation(int index, bool isConstantAnim)
	{
		//newAnim.AnimationIndex=index
		newAnim.Play(index,isConstantAnim);
	}

	/// <summary>
	/// Checks if a new animation is needed and if so run it.
	/// </summary>
	/// <param name="pAnim">P animation.</param>
	/// <param name="newState">New state.</param>
		/// Obsolete. Used by the legacy animator
/*	void playAnimation(string pAnim, int newState)
	{
				return;
				curranim=newState;
		if (Frozen)
		{
			//anim.enabled=true;
			FrozenUpdate=2;
		}
			if (GameWorldController.instance.critsLoader[NPC_IDi-64]==null)
			{
				GameWorldController.instance.critsLoader[NPC_IDi-64]= new CritLoader(NPC_IDi-64);
			}
		//currentState=newState;
		//CurrentAnim=pAnim;
		//anim.Play(pAnim);
		}*/

	/// <summary>
	/// NPC tries to hit the player.
	/// </summary>
	public void ExecuteAttack()
	{
		if(gtarg==null)
		{
			return;
		}
		float weaponRange=1.5f;

		//NPC tries to raycast at the player or object
		
		Vector3 TargetingPoint;
		if (gtarg.name=="_Gronk")
		{//Try and hit the player
			TargetingPoint=GameWorldController.instance.playerUW.TargetPoint.transform.position;
		}
		else
		{//Trying to hit an object						
			TargetingPoint=gtarg.GetComponent<ObjectInteraction>().GetImpactPoint();//Aims for the objects impact point	
		}
			
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
			if (hit.transform.name == GameWorldController.instance.playerUW.name)
				{
					MusicController.LastAttackCounter=30.0f; //Thirty more seconds of combat music
					GameWorldController.instance.playerUW.ApplyDamage(5,this.gameObject);
				}
			else
				{
					//Has it hit another npc or object
					if (hit.transform.GetComponent<ObjectInteraction>()!=null)
					{
						hit.transform.GetComponent<ObjectInteraction>().Attack(5, this.gameObject);
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
		UWCharacter.Instance.PlayerMagic.CastEnchantmentImmediate(NPC_Launcher,gtarg,SpellIndex,Magic.SpellRule_TargetVector);
	}

	/// <summary>
	/// Executes the ranged attack.
	/// </summary>
	public void ExecuteRangedAttack()
	{
		Vector3 TargetingPoint;
		if (gtarg.name=="_Gronk")
		{//Try and hit the player
			TargetingPoint=GameWorldController.instance.playerUW.TargetPoint.transform.position;
		}
		else
		{//Trying to hit an object						
				TargetingPoint=gtarg.GetComponent<ObjectInteraction>().GetImpactPoint();//Aims for the objects impact point	
		}
		Vector3 TargetingVector = (TargetingPoint-NPC_Launcher.transform.position).normalized;
		TargetingVector=TargetingVector + new Vector3(0.0f,0.3f,0.0f);//Try and give the vector an arc
		Ray ray= new Ray(NPC_Launcher.transform.position,TargetingVector);
		RaycastHit hit = new RaycastHit(); 
		float dropRange=0.5f;
		if (!Physics.Raycast(ray,out hit,dropRange))
		{///Checks No object interferes with the launch
			float force =100f*Vector3.Distance(TargetingPoint,NPC_Launcher.transform.position);
			//launchedItem= ObjectInteraction.CreateNewObject(16).gameObject;

			ObjectLoaderInfo newobjt= ObjectLoader.newObject(16,0,0,1);
			GameObject launchedItem=	ObjectInteraction.CreateNewObject(GameWorldController.instance.currentTileMap(),newobjt, GameWorldController.instance.LevelMarker().gameObject,ray.GetPoint(dropRange-0.1f)).gameObject;


			//launchedItem = Instantiate(currentAmmo.gameObject);
		//	launchedItem.name="launched_missile_" +GameWorldController.instance.playerUW.PlayerMagic.SummonCount++;
		//	launchedItem.GetComponent<ObjectInteraction>().link=1;//Only 1

		//	launchedItem.transform.parent=GameWorldController.instance.LevelMarker();
		//	GameWorldController.MoveToWorld(launchedItem);
		//	launchedItem.GetComponent<ObjectInteraction>().PickedUp=false;	//Back in the real world

		//	launchedItem.transform.position=ray.GetPoint(dropRange-0.1f);//GameWorldController.instance.playerUW.transform.position;
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
			pd.Damage=10;
			Ammo--;
		}
	}

	public override string ContextMenuDesc (int item_id)
	{
		if(objInt().isIdentified==true)
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
}

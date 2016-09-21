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
	//attitude; 0:hostile, 1:upset, 2:mellow, 3:friendly
	public const int AI_ATTITUDE_HOSTILE = 0 ;
	public const int AI_ATTITUDE_UPSET = 1 ;
	public const int AI_ATTITUDE_MELLOW = 2 ;
	public const int AI_ATTITUDE_FRIENDLY = 3 ;

  	 //Animations are clasified by number
	public const int AI_RANGE_IDLE = 1 ;
	public const int AI_RANGE_MOVE = 10 ;
	public const int AI_RANGE_DEATH = 100 ;
	public const int AI_RANGE_ATTACK_BASH = 1000 ;
	public const int AI_RANGE_ATTACK_SLASH = 2000 ;
	public const int AI_RANGE_ATTACK_THRUST = 3000 ;
	public const int AI_RANGE_COMBAT_IDLE = 4000 ;
	
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

	///Anim range defines which animation set to play.
	///Multiple of 10 for dividing animations
	///Angle index * Anim Range give AI_ANIM_X value to pick animation
	public int AnimRange=1;
	
	/// Object ID for the NPC
	public string NPC_ID;
	
	/// The animation that is currently set
	public string CurrentAnim;
	
	/// The animator that the NPC is using for it's animations
	public Animator anim;
	
	/// For tracking the state of the NPC
	public int currentState=-1;

	/// Thinks this has to do with changing the NPC on the fly
	private string oldNPC_ID;
	
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


	//TODO: these need to match the UW npc_goals
	//The behaviour trees need to be updated too.
	public const int AI_STATE_IDLERANDOM = 0;
	public const int AI_STATE_COMBAT = 1;
	public const int AI_STATE_DYING = 2;
	public const int AI_STATE_STANDING = 3;
	public const int AI_STATE_WALKING = 4 ;

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
	public int state=0; 

	///For storing spell effects applied to NPCs
	public SpellEffect[] NPCStatusEffects=new SpellEffect[3];

	///To flag initiation of the player into the AI modules
	private static bool playerUWReady;
	///AI module for the character.
	private AIRig ai;	
	
	///Can the NPC fire off magic attacks.
	public bool MagicAttack;	
	///Transform position to launch projectiles from
	public GameObject NPC_Launcher; 
	///What spell the NPC should cast if they have magicAttack==true
	public int SpellIndex; 	

	void Awake () {
		oldNPC_ID=NPC_ID;
		anim=GetComponentInChildren<Animator>();
	}


		/// <summary>
		/// Initialise some basic info for the NPC ai.
		/// </summary>
	protected override void Start () {
		base.Start();
		//this.gameObject.tag="NPCs";
		//Gob = this.GetComponent<GoblinAI>();
		//ai = this.GetComponentInChildren<AIRig>();
		//AI_INIT ();
	}

	void AI_INIT ()
	{
		if (ai == null) {
			GameObject myInstance = Resources.Load ("AI_PREFABS/AI_LAND") as GameObject;
			GameObject newObj = (GameObject)GameObject.Instantiate (myInstance);
			newObj.name = this.gameObject.name + "_AI";
			newObj.transform.position = Vector3.zero;
			//new Vector3(0,0,0);
			newObj.transform.parent = this.gameObject.transform;
			newObj.transform.localPosition = Vector3.zero;
			//new Vector3(0,0,0);
			AIRig aiR = newObj.GetComponent<AIRig> ();
			aiR.AI.Body = this.gameObject;
			ai = aiR;
			ai.AI.WorkingMemory.SetItem<GameObject> ("playerUW", GameWorldController.instance.playerUW.gameObject);
			ai.AI.WorkingMemory.SetItem<bool> ("magicAttack", MagicAttack);
			ai.AI.Body = this.gameObject;
			ai.AI.Motor.DefaultSpeed = 2.0f * (((float)GameWorldController.instance.critter.Speed [objInt ().item_id - 64] / 12.0f));
			ai.AI.WorkingMemory.SetItem<float> ("Speed", ai.AI.Motor.DefaultSpeed);
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

		//GameWorldController.instance.playerUW.AddXP(npc_power*5);//TODO:Is this set somewhere. Common obj props?
		GameWorldController.instance.playerUW.AddXP(GameWorldController.instance.critter.Exp[objInt().item_id-64]);
	}

		/// <summary>
		/// Update the NPC state, AI and animations
		/// </summary>
		/// AI is only active when the player is close.
	protected virtual void  Update () {
		if (Frozen)
		{//NPC will not move until timer is complete.
			if (FrozenUpdate==0)
			{
				anim.enabled=false;
			}
			else
			{
				FrozenUpdate--;
			}
			state = AI_STATE_STANDING;
		}


		if (NPC_DEAD==true)
		{//Set the AI death state
			//Update the appearance of the NPC
			UpdateSprite();
			AI_INIT();
			ai.AI.WorkingMemory.SetItem<int>("state",AI_STATE_DYING);//Set to death state.
			return;
		}


		//else
		//{//The AI is only active when the player is within a certain distance to the player camera.
		if (Vector3.Distance(this.transform.position, GameWorldController.instance.playerUW.CameraPos)<=8)
			{
				AI_INIT ();
				ai.AI.IsActive= Vector3.Distance(this.transform.position, GameWorldController.instance.playerUW.CameraPos)<=8;
				anim.enabled=true;
			}
			else
			{
				anim.enabled=false;
				return;
			}

			//Update the appearance of the NPC
			UpdateSprite();
			
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
				if (npc_attitude==0)
					{//Combat begin
					ai.AI.WorkingMemory.SetItem<int>("state",AI_STATE_COMBAT);//Set to combat state.
					Vector3 AB = GameWorldController.instance.playerUW.transform.position-this.transform.position;
					Vector3 Movepos = GameWorldController.instance.playerUW.transform.position + (0.31f * AB.normalized) ;
					//ai.AI.WorkingMemory.SetItem<Vector3>("MoveTarget",GameWorldController.instance.playerUW.gameObject.transform.position);
					ai.AI.WorkingMemory.SetItem<Vector3>("MoveTarget",Movepos);
					}
				else
					{//Friendly states
						ai.AI.WorkingMemory.SetItem<int>("state",state);//Set to idle
					}
			}
		}
	//}


		/// <summary>
		/// Applies the attack to the NPC
		/// </summary>
		/// <returns><c>true</c>, if attack was applyed, <c>false</c> otherwise.</returns>
		/// <param name="damage">Damage.</param>
		/// NPC becomes hostile on attack. 
	public override bool ApplyAttack(int damage)
	{
		if(Frozen==false)
		{
			npc_attitude=0;//NPC becomes hostile.
		}	
		npc_hp=npc_hp-damage;
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
				npc_whoami=256+(objInt.item_id -64);
			}
			if (npc_whoami>255)
			{//Generic conversation.
				ObjectInteraction objInt=this.GetComponent<ObjectInteraction>();
				npcname= StringController.instance.GetSimpleObjectNameUW(objInt);
			}
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
				
				StartCoroutine(cnv.main ());//Conversations operate in coroutines to allow interaction
			}
			else
			{
				//You get no response
				UWHUD.instance.MessageScroll.Add (StringController.instance.GetString (7,1));
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
		if (anim == null)
		{
			anim = GetComponentInChildren<Animator>();
		}
		if (NPC_ID!=oldNPC_ID)
		{
			currentState=-1;
			oldNPC_ID=NPC_ID;
		}
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
		CalcedFacing=(CalcedFacing+1)*AnimRange;
		
		//play the calculated animation.
		switch (CalcedFacing)
		{
		case AI_ANIM_IDLE_FRONT:
		{	
			playAnimation(NPC_ID +"_idle_front",CalcedFacing);
			break;
		}
		case AI_ANIM_IDLE_FRONT_RIGHT:
		{	
			playAnimation(NPC_ID +"_idle_front_right",CalcedFacing);
			break;
		}
		case AI_ANIM_IDLE_RIGHT:
		{	
			playAnimation(NPC_ID +"_idle_right",CalcedFacing);
			break;
		}
		case AI_ANIM_IDLE_REAR_RIGHT:
		{	
			playAnimation(NPC_ID +"_idle_rear_right",CalcedFacing);
			break;
		}
		case AI_ANIM_IDLE_REAR:
		{	
			playAnimation(NPC_ID +"_idle_rear",CalcedFacing);
			break;
		}
		case AI_ANIM_IDLE_REAR_LEFT:
		{	
			playAnimation(NPC_ID + "_idle_rear_left",CalcedFacing);
			break;
		}
		case AI_ANIM_IDLE_LEFT:
		{	
			playAnimation(NPC_ID +"_idle_left",CalcedFacing);
			break;
		}
		case AI_ANIM_IDLE_FRONT_LEFT:
		{	
			playAnimation(NPC_ID +"_idle_front_left",CalcedFacing);
			break;
		}
		case AI_ANIM_WALKING_FRONT:
		{	
			playAnimation(NPC_ID +"_walking_front",CalcedFacing);
			break;
		}
		case AI_ANIM_WALKING_FRONT_RIGHT:
		{	
			playAnimation(NPC_ID + "_walking_front_right",CalcedFacing);
			break;
		}
		case AI_ANIM_WALKING_RIGHT:
		{	
			playAnimation(NPC_ID + "_walking_right",CalcedFacing);
			break;
		}
		case AI_ANIM_WALKING_REAR_RIGHT:
		{	
			playAnimation(NPC_ID +"_walking_rear_right",CalcedFacing);
			break;
		}
		case AI_ANIM_WALKING_REAR:
		{	
			playAnimation(NPC_ID +"_walking_rear",CalcedFacing);
			break;
		}
		case  AI_ANIM_WALKING_REAR_LEFT:
		{	
			playAnimation(NPC_ID +"_walking_rear_left",CalcedFacing);
			break;
		}
		case  AI_ANIM_WALKING_LEFT:
		{	
			playAnimation(NPC_ID + "_walking_left",CalcedFacing);
			break;
		}
		case AI_ANIM_WALKING_FRONT_LEFT:
		{	
			playAnimation(NPC_ID + "_walking_front_left",CalcedFacing);
			break;
		}
		default://special non angled states
		{
			switch(AnimRange)
			{
			case AI_ANIM_DEATH:
				playAnimation (NPC_ID +"_death",AI_ANIM_DEATH);break;
			case AI_ANIM_ATTACK_BASH:
				playAnimation (NPC_ID +"_attack_bash",AI_ANIM_ATTACK_BASH);break;
			case AI_ANIM_ATTACK_SLASH:
				playAnimation (NPC_ID +"_attack_slash",AI_ANIM_ATTACK_SLASH);break;
			case AI_ANIM_ATTACK_THRUST:
				playAnimation (NPC_ID +"_attack_thrust",AI_ANIM_ATTACK_THRUST);break;
			case AI_ANIM_COMBAT_IDLE:
				playAnimation (NPC_ID +"_combat_idle",AI_ANIM_COMBAT_IDLE);break;
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

		/// <summary>
		/// Checks if a new animation is needed and if so run it.
		/// </summary>
		/// <param name="pAnim">P animation.</param>
		/// <param name="newState">New state.</param>
	void playAnimation(string pAnim, int newState)
	{
		if (newState!=currentState)
		{
			if (Frozen)
			{
				anim.enabled=true;
				FrozenUpdate=2;
			}
			currentState=newState;
			CurrentAnim=pAnim;
			anim.Play(pAnim);
		}
	}


	/// <summary>
	/// NPC tries to hit the player.
	/// </summary>
	public void ExecuteAttack()
	{
		float weaponRange=1.0f;

		//NPC tries to raycast at the player.
		Ray ray= new Ray(this.transform.position,GameWorldController.instance.playerUW.gameObject.transform.position-this.transform.position);
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
					GameWorldController.instance.playerUW.ApplyDamage(5);
				}
			}
		}
	}
	/// <summary>
		/// NPC casts a spell.
	/// </summary>
	public void ExecuteMagicAttack()
	{
		UWCharacter.Instance.PlayerMagic.CastEnchantmentImmediate(NPC_Launcher,UWCharacter.Instance.gameObject,SpellIndex,Magic.SpellRule_TargetVector);
	}
}

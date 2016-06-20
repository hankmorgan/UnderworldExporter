using UnityEngine;
using System.Collections;
using RAIN.BehaviorTrees;
using RAIN.Core;
using RAIN.Minds;

public class NPC : object_base {
		/*
		 * Npc.cs Code related the NPC.
		 * Controls AI status, animation, conversations and general properties.
		 * 
		 */
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

	public int AnimRange=1;//Multiple of 10 for dividing animations
	public string NPC_ID;
	public string CurrentAnim;

	private NavMeshAgent agent;
	public Animator anim;
	public int currentState=-1;
	private bool followPlayer=false;
	private string oldNPC_ID;
	
	private int facingIndex;
	private int PreviousFacing=-1;
	private int PreviousAnimRange=-1;
	private int CalcedFacing;
	
	private int currentHeading;//Integer representation of the current facing of the character. To match with animation angles
	
	private Vector3 direction;	//vector between the player and the ai.
	float angle;// The angle to the character from the player.



	//End of from goblin AI




	//TODO: these need to match the UW npc_goals
	//The behaviour trees need to be updated too.
	public const int AI_STATE_IDLERANDOM = 0;
	public const int AI_STATE_COMBAT = 1;
	public const int AI_STATE_DYING = 2;
	public const int AI_STATE_STANDING = 3;
	public const int AI_STATE_WALKING = 4 ;

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

	public bool NPC_DEAD;

	//Added by myself. This are set by spelleffects
	public bool Poisoned;
	public bool Frozen;
	public short FrozenUpdate=0;

	//Enemy types.
	public bool isUndead; 

	//TODO: The state should be replaced with a combination of the above variables and match what UW does.
	public int state=0; //Set state when not in combat or dying.

	//For storing spell effects applied to NPCs
	public SpellEffect[] NPCStatusEffects=new SpellEffect[3];

	private static bool playerUWReady;//To flag initiation of the player into the AI modules
	private AIRig ai;	//AI module for the character.

	public bool MagicAttack;	//Can the NPC fire off magic attacks.
	public GameObject NPC_Launcher; //Transform position to launch projectiles from
	public int SpellIndex; 	//What spell the NPC should cast.

	void Awake () {
		oldNPC_ID=NPC_ID;
		agent = GetComponent<NavMeshAgent>();
		anim=GetComponentInChildren<Animator>();
	}


	// Use this for initialization
	void Start () {
		base.Start();
		this.gameObject.tag="NPCs";
		//Gob = this.GetComponent<GoblinAI>();
		ai = this.GetComponentInChildren<AIRig>();

		ai.AI.WorkingMemory.SetItem<GameObject>("playerUW",playerUW.gameObject);
		ai.AI.WorkingMemory.SetItem<bool>("magicAttack",MagicAttack);
		ai.AI.Body=this.gameObject;
	}

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
	}

	void Update () {
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
		//Update the appearance of the NPC
		UpdateSprite();

		if (NPC_DEAD==true)
		{//Set the AI death state
			ai.AI.WorkingMemory.SetItem<int>("state",AI_STATE_DYING);//Set to death state.
			return;
		}

		if ( playerUWReady==false)
		{//Initialise the relationship of the player to the AI module
			if(playerUW!=null)
			{
				ai.AI.WorkingMemory.SetItem<GameObject>("playerUW",playerUW.gameObject);
				playerUWReady=true;
			}
		}
		else
		{//The AI is only active when the player is within a certain distance to the player.
			ai.AI.IsActive= Vector3.Distance(this.transform.position, playerUW.gameObject.transform.position)<=8;
			if (ai.AI.IsActive==false)
			{
				return;
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
				if (npc_attitude==0)
					{//Combat begin
					ai.AI.WorkingMemory.SetItem<int>("state",AI_STATE_COMBAT);//Set to combat state.
					}
				else
					{//Friendly states
						ai.AI.WorkingMemory.SetItem<int>("state",state);//Set to idle
					}
			}
		}
	}



	public override bool ApplyAttack(int damage)
	{
		if(Frozen==false)
		{
			npc_attitude=0;//NPC becomes hostile.
		}	
		npc_hp=npc_hp-damage;
		return true;
	}

	public override bool TalkTo()
	{//Begin a conversation.
		if ((npc_whoami == 255))
		{
			//006~007~001~You get no response.
			ml.Add (playerUW.StringControl.GetString (7,1));
		}
		else
		{
			if (npc_whoami==0)
			{//Generic conversation.
				ObjectInteraction objInt=this.GetComponent<ObjectInteraction>();
				npc_whoami=256+(objInt.item_id -64);
			}
			Conversation cnv = (Conversation)this.GetComponent("Conversation_"+npc_whoami);//Get the conversation object
			if (cnv!=null)
			{	
				UWCharacter.InteractionMode=UWCharacter.InteractionModeInConversation;//Set converation mode.
				Conversation.CurrentConversation=npc_whoami;
				Conversation.InConversation=true;
				cnv.WhoAmI=npc_whoami;
				Conversation.maincam=Camera.main;//To control the camera from conversation scripts
				StartCoroutine(cnv.main ());//Conversations operate in coroutines to allow interaction
			}
			else
			{
				//You get no response
				ml.Add (playerUW.StringControl.GetString (7,1));
			}
		}
		return true;
	}

	public override bool LookAt ()
	{//TODO:For specific characters that don't follow the standard naming convention use their conversation for the lookat.
		string output="";
		if (objInt.item_id!=123)//Tybal
		{
			output = playerUW.StringControl.GetFormattedObjectNameUW(objInt,NPCMoodDesc());
		}
		if ((npc_whoami >=1) && (npc_whoami<255)) 
		{
			if (npc_whoami==231)//Tybal
			{
				output= "You see Tybal";
			}
			else if (npc_whoami==207)
			{//Warren spectre.
				output= "You see an " + NPCMoodDesc() + " " + playerUW.StringControl.GetString (7,npc_whoami+16);
			}
			else
			{
				output=output+" named " + playerUW.StringControl.GetString (7,npc_whoami+16);
			}

		}
		ml.Add (output);
		return true;
	}



	private string NPCMoodDesc()
	{
		//Gives a mood string for NPCs
		//004€005€096€hostile
		//004€005€097€upset
		//004€005€098€mellow
		//004€005€099€friendly
		switch (npc_attitude)
		{
		case 0:
			return playerUW.StringControl.GetString (5,96);break;
		case 1:
			return playerUW.StringControl.GetString (5,97);break;
		case 2:
			return playerUW.StringControl.GetString (5,98);break;
		default:
			return playerUW.StringControl.GetString (5,99);break;

		}
	}


	void UpdateSprite () {
		//Updates the appearance of the NPC
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
		direction = playerUW.gameObject.transform.position - this.gameObject.transform.position;
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



	int facing(float angle)
	{
		//Breaks down the angle in the the facing sector. Clockwise from 0)
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


	void playAnimation(string pAnim, int newState)
	{//Checks if a new animation is needed and if so run it.
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

	public void ExecuteAttack()
	{//NPC tries to hit the player.
		float weaponRange=1.0f;

		//NPC tries to raycast at the player.
		Ray ray= new Ray(this.transform.position,playerUW.gameObject.transform.position-this.transform.position);
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
					playerUW.ApplyDamage(5);
				}
			}
		}
	}
	
	public void ExecuteMagicAttack()
	{//NPC casts a spell.
		UWCharacter.Instance.PlayerMagic.CastEnchantmentImmediate(NPC_Launcher,UWCharacter.Instance.gameObject,SpellIndex,Magic.SpellRule_TargetVector);
	}
}

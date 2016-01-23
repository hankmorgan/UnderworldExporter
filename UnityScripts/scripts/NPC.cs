using UnityEngine;
using System.Collections;
using RAIN.BehaviorTrees;
using RAIN.Core;
using RAIN.Minds;

public class NPC : object_base {
	//From goblinAI
	private static int[] CompassHeadings={0,-1,-2,-3,4,3,2,1,0};

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
	
	//public static TileMap tm;
	
	//private UILabel MessageLog;
	private NavMeshAgent agent;
	public static GameObject player;
	private Animator anim;
	private int currentState=-1;
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

	//public int npc_deathvariable;	//Quest variable to set when the character is killed
	public bool NPC_DEAD;

	//Added by myself
	public bool Poisoned;

	//TODO: The state should be replaces with a combination of the above variables.
	public int state=0; //Set state when not in combat or dying.


	//For applying spell effects to NPCs
	public SpellEffect[] NPCStatusEffects=new SpellEffect[3];

	//public static UWCharacter playerUW;
	private static bool playerUWReady;
	private GoblinAI Gob;
	private AIRig ai;

	public bool MagicAttack;
	public GameObject NPC_Launcher; //Transform position to launch projectiles from
	public int SpellIndex; 	//What spell the NPC should cast.

	void Awake () {
		oldNPC_ID=NPC_ID;
		//MessageLog = (UILabel)GameObject.FindWithTag("MessageLog").GetComponent<UILabel>();
		agent = GetComponent<NavMeshAgent>();
		anim=GetComponentInChildren<Animator>();
	}


	// Use this for initialization
	void Start () {
		base.Start();

		Gob = this.GetComponent<GoblinAI>();
		ai = this.GetComponentInChildren<AIRig>();

		if (playerUW==null)
		{
			playerUW = GameObject.Find ("Gronk").GetComponent<UWCharacter>();
		}
		//playerUW = GameObject.Find ("Gronk").GetComponent<UWCharacter>();
		ai.AI.WorkingMemory.SetItem<GameObject>("playerUW",playerUW.gameObject);
		ai.AI.WorkingMemory.SetItem<bool>("magicAttack",MagicAttack);
		ai.AI.Body=this.gameObject;
	}

	void OnDeath()
	{
		Conversation cnv = this.GetComponent<Conversation>();
		if (cnv!=null)
		{
			if(cnv.OnDeath()==true)
			{
				return;
			}			
		}

		NPC_DEAD=true;
		//Dump items on the floor.
		//
		Container cnt = this.GetComponent<Container>();
		if (cnt!=null)
		{
			Debug.Log ("Spilling " + this.name);
			cnt.SpillContents();//Spill contents is still not 100% reliable so don't expect to get all the items you want.
		}
		else
		{
			Debug.Log ("no container to spill");
		}
	}

	// Update is called once per frame
	void Update () {

		UpdateSprite();

		//Gob.isHostile=((npc_attitude==0) && (npc_hp>0));
		//Gob.HP=npc_hp;
		if (NPC_DEAD==true)
		{
			ai.AI.WorkingMemory.SetItem<int>("state",AI_STATE_DYING);//Set to death state.
			return;
		}

		if ( playerUWReady==false)
		{
			if(playerUW!=null)
			{
				ai.AI.WorkingMemory.SetItem<GameObject>("playerUW",playerUW.gameObject);
				playerUWReady=true;
			}
		}
		else
		{
			ai.AI.IsActive= Vector3.Distance(this.transform.position, playerUW.gameObject.transform.position)<=8;
			if (ai.AI.IsActive==false)
			{
				return;
			}
			//if (state== NPC.AI_STATE_WALKING)
			//{//Sets the AI to always be turned towards their next waypoint
			if (ai.AI.Navigator.CurrentPath!=null)
			{
				Vector3 NextPosition = ai.AI.Navigator.CurrentPath.GetWaypointPosition(ai.AI.Navigator.NextWaypoint);
				NextPosition.y= this.transform.position.y;
				//ai.AI.WorkingMemory.SetItem<Vector3>("RotateTowards",ai.AI.Navigator.CurrentPath.GetWaypointPosition(ai.AI.Navigator.NextWaypoint));
				ai.AI.WorkingMemory.SetItem<Vector3>("RotateTowards",NextPosition);
			}
			//}


			if ((npc_hp<=0))
			{
				//if ((npc_deathvariable>0) && (npc_deathvariable<32))
			//	{
				//	playerUW.quest().QuestVariables[npc_deathvariable]=1;
			//	}

				OnDeath();
			//	Debug.Log("NPC Dead");
			}
			else
			{
				if (npc_attitude==0)
					{
					ai.AI.WorkingMemory.SetItem<int>("state",AI_STATE_COMBAT);//Set to combat state.
					}
				else
				{
					ai.AI.WorkingMemory.SetItem<int>("state",state);//Set to idle
				}
			}
		}
	}



	public override bool ApplyAttack(int damage)
	{
		//npc_attitude=0;
		npc_attitude=0;
		npc_hp=npc_hp-damage;

		return true;
	}

	public override bool TalkTo()
	{
		//if (npc_attitude==0)
		//{//Hostile
		//	ml.Add (playerUW.StringControl.GetString (7,1));
		//	return false;
		//}
		//Debug.Log("Talking to " + WhoAmI) ;


		//TODO:Make sure you add the conversation object to the npc!
		if ((npc_whoami == 255))
		{
			//006~007~001~You get no response.
			ml.Add (playerUW.StringControl.GetString (7,1));
		}
		else
		{
			if (npc_whoami==0)
			{
				ObjectInteraction objInt=this.GetComponent<ObjectInteraction>();
				npc_whoami=256+(objInt.item_id -64);
				//Debug.Log ("npc who am i is now " + npc_whoami);
			}
			Conversation x = (Conversation)this.GetComponent("Conversation_"+npc_whoami);
			if (x!=null)
			{	
				UWCharacter.InteractionMode=UWCharacter.InteractionModeInConversation;
				Conversation.CurrentConversation=npc_whoami;
				Conversation.InConversation=true;
				x.WhoAmI=npc_whoami;

				Conversation.maincam=Camera.main;
			//	UWCharacter.InteractionMode=UWCharacter.InteractionModeTalk;
			//	InteractionModeControl.UpdateNow=true;				
				//Camera.main.enabled = false;
				StartCoroutine(x.main ());

			}
			else
			{
				ml.Add (playerUW.StringControl.GetString (7,1));
				//chains.ActiveControl=0;//Enable UI Elements
				//chains.Refresh();
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
		if (anim == null)
		{
			anim = GetComponentInChildren<Animator>();
		}
		if (NPC_ID!=oldNPC_ID)
		{
			currentState=-1;
			oldNPC_ID=NPC_ID;
		}
		direction = player.transform.position - this.gameObject.transform.position;
		angle = Mathf.Atan2(direction.x,direction.z) * Mathf.Rad2Deg;
		
		currentHeading = CompassHeadings[ (int)Mathf.Round((  (this.gameObject.transform.eulerAngles.y % 360) / 45f)) ];
		
		facingIndex = facing(angle);
		if ((PreviousFacing!=facingIndex) && (AnimRange!=PreviousAnimRange))
		{
			PreviousFacing=facingIndex;
			PreviousAnimRange=AnimRange;
		}
		
		CalcedFacing=facingIndex + currentHeading;
		if (CalcedFacing>=8)
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
		
		
		CalcedFacing=(CalcedFacing+1)*AnimRange;
		
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
			{playAnimation (NPC_ID +"_death",AI_ANIM_DEATH);break;}
			case AI_ANIM_ATTACK_BASH:
			{playAnimation (NPC_ID +"_attack_bash",AI_ANIM_ATTACK_BASH);break;}
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
	{
		if (newState!=currentState)
		{
			currentState=newState;
			CurrentAnim=pAnim;
			anim.Play(pAnim);
		}
	}

	public void ExecuteAttack()
	{
		float weaponRange=1.0f;
		Ray ray= new Ray(this.transform.position,player.transform.position-this.transform.position);
		RaycastHit hit = new RaycastHit(); 
		if (Physics.Raycast(ray,out hit,weaponRange))
		{
			if (hit.transform.Equals(this.transform))
			{
				Debug.Log ("you've hit yourself ? " + hit.transform.name);
			}
			else
			{
				if (hit.transform.name == "Gronk")
				{
					MusicController.LastAttackCounter=30.0f; //Thirty more seconds of combat music
					UWCharacter playerUW =hit.transform.GetComponent<UWCharacter>();
					playerUW.ApplyDamage(5);
				}
			}
		}
	}
	
	public void ExecuteMagicAttack()
	{
		UWCharacter.Instance.PlayerMagic.CastEnchantmentImmediate(NPC_Launcher,UWCharacter.Instance.gameObject,SpellIndex,Magic.SpellRule_TargetVector);
	}


}

using UnityEngine;
using System.Collections;
//using RAIN.BehaviorTrees;
//using RAIN.Core;
//using RAIN.Minds;



public class GoblinAI : MonoBehaviour {
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

	public bool executeAttack=false;
	public int AnimRange=1;//Multiple of 10 for dividing animations
	public string NPC_ID;
	public string CurrentAnim;

	public static TileMap tm;

	private UILabel MessageLog;
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

	private static int[] CompassHeadings={0,-1,-2,-3,4,3,2,1,0};

	// Use this for initialization
	void Awake () {
		oldNPC_ID=NPC_ID;
		MessageLog = (UILabel)GameObject.FindWithTag("MessageLog").GetComponent<UILabel>();
		agent = GetComponent<NavMeshAgent>();
		anim=GetComponentInChildren<Animator>();
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
		//else
		//{
		//	Debug.Log ("MISS");
		//}
	}


	// Update is called once per frame
	void Update () {
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

	void playAnimation(string pAnim, int newState)
	{
		if (newState!=currentState)
		{
			currentState=newState;
			CurrentAnim=pAnim;
			anim.Play(pAnim);
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
}

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
	//public bool isDead=false;
	//public bool isHostile=false;
	//public int HP;

	public static TileMap tm;
//	private AIRig ai;
	//public string Idle_Front;
	//public string Idle_Rear;
	//public string Idle_Right;
	//public string Idle_Left;
	//public string Idle_Front_Right;
	//public string Idle_Front_Left;
	//public string Idle_Rear_Right;
	//public string Idle_Rear_Left;
	//public string Walking_Front;
	//public string Walking_Rear;
	//public string Walking_Right;
	//public string Walking_Left;
	//public string Walking_Front_Right;
	//public string Walking_Front_Left;
	//public string Walking_Rear_Right;
	//public string Walking_Rear_Left;
	//public string idle_combat;
	//public string attack_bash;
	//public string attack_slash;
	//public string attack_thrust;
	//public string attack_secondary;
	//public string death;
	//public string begin_combat;//?

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
	//public int OriginalCalcedFacing;

	private Vector3 direction;	//vector between the player and the ai.
	float angle;// The angle to the character from the player.

	private static int[] CompassHeadings={0,-1,-2,-3,4,3,2,1,0};

	// Use this for initialization
	void Awake () {
		oldNPC_ID=NPC_ID;
		MessageLog = (UILabel)GameObject.FindWithTag("MessageLog").GetComponent<UILabel>();
		//MessageLog.text="StartUp";
		//GameObject targetPoint = GameObject.Find ("a_goblin_52_59_00_0202");
		agent = GetComponent<NavMeshAgent>();
		//player = GameObject.Find ("Gronk");
		//var agent: NavMeshAgent GetComponent.<NavMeshAgent>();
		//anim = GameObject.Find (name + "_Animation").GetComponent<Animator>();
		//anim = (Animator)transform.FindChild (name + "_Sprite").GetComponent<Animator>();
		//anim = GameObject.Find (name + "_sprite").GetComponent<Animator>();
		//anim = GetComponentInChildren<Animator>();
		anim=GetComponentInChildren<Animator>();
	//	ai = GetComponentInChildren<AIRig>();
	//	if (ai != null)
	//	{
			//Debug.Log ("init ai");
	//		ai.AI.Body=this.gameObject;
	//		ai.AI.WorkingMemory.SetItem<GameObject>("playerUW",player);
			//ai.AI.WorkingMemory.SetItem<Vector3>("moveStartPoint",player.transform.position);
	//	}

	}



	//void ApplyDamage()
	//{

	//	playAnimation(NPC_ID+"_death",100);
		//isDead=true;
	//}

	public void ExecuteAttack()
	{
		float weaponRange=1.2f;
		//Ray ray = new Ray(this.transform.position+Vector3.up*1.0f,Vector3.forward); 
		//Ray ray = new Ray(this.transform.position+Vector3.up*0.5f,this.transform.TransformDirection(Vector3.forward)); 
		Ray ray= new Ray(this.transform.position,player.transform.position-this.transform.position);
		RaycastHit hit = new RaycastHit(); 
		if (Physics.Raycast(ray,out hit,weaponRange))
			//if (Physics.Raycast (transform.position,transform.TransformDirection(Vector3.forward),out hit))
		{
			if (hit.transform.Equals(this.transform))
			{
				Debug.Log ("you've hit yourself ? " + hit.transform.name);
			}
			else
			{
				Debug.Log (this.name + "has hit " + hit.transform.name);
				if (hit.transform.name == "Gronk")
				{
					MusicController.LastAttackCounter=30.0f; //Thirty more seconds of combat music
					UWCharacter playerUW =hit.transform.GetComponent<UWCharacter>();
					playerUW.ApplyDamage(5);
				}
				//hit.transform.SendMessage("ApplyDamage");
				//Destroy(hit.collider.gameObject);
			}
			
		}
		else
		{
			Debug.Log ("MISS");
		}

	}


	// Update is called once per frame
	void Update () {
		//if (ai == null)
		//{
		//	ai = GetComponentInChildren<AIRig>();
		//}
		//else
		//{
			//ai.AI.IsActive= Vector3.Distance(this.transform.position, player.transform.position)<10;
			//if (ai.AI.IsActive)
			//{
				//ai.AI.WorkingMemory.SetItem<bool>("isHostile",isHostile);
				//ai.AI.WorkingMemory.SetItem<int>("HP",HP);
			//}
		//}

		if (anim == null)
		{
			anim = GetComponentInChildren<Animator>();
		}

	//if (isDead==true)
	//	{
	//		return;
	//	}
		//float angle = Quaternion.Angle(transform.rotation, player.transform.rotation);
		//if (followPlayer==true)
		//{
		//	//Vector3 target = player.transform.position;
		//	agent.SetDestination(player.transform.position);
		//}
		if (NPC_ID!=oldNPC_ID)
		{
			currentState=-1;
			oldNPC_ID=NPC_ID;
		}
		//if (executeAttack==true)
		//{
		//	AnimRange=1000;
		//	ExecuteAttack();
		//	executeAttack=false;
		//}

		direction = player.transform.position - this.gameObject.transform.position;
		angle = Mathf.Atan2(direction.x,direction.z) * Mathf.Rad2Deg;

		currentHeading = CompassHeadings[ (int)Mathf.Round((  (this.gameObject.transform.eulerAngles.y % 360) / 45f)) ];

		facingIndex = facing(angle);
		if ((PreviousFacing!=facingIndex) && (AnimRange!=PreviousAnimRange))
		{
			//Debug.Log (facingIndex-1);
			PreviousFacing=facingIndex;
			PreviousAnimRange=AnimRange;
		}

		CalcedFacing=facingIndex + currentHeading;
		//OriginalCalcedFacing=CalcedFacing;
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
			//Debug.Log ("less than zero");
			CalcedFacing=8+CalcedFacing;
		}
		else if (CalcedFacing>7)
		{
			//Debug.Log ("more than zero");
			CalcedFacing=8-CalcedFacing;
		}

		//Debug.Log (facingIndex);
		//print (angle);
		CalcedFacing=(CalcedFacing+1)*AnimRange;
		//Debug.Log (CalcedFacing);
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
		/*	if (AnimRange==  AI_ANIM_DEATH)//Dying
				{playAnimation (NPC_ID +"_death",AI_ANIM_DEATH);}
			if (AnimRange==  AI_ANIM_ATTACK_BASH)//combat
				{playAnimation (NPC_ID +"_attack_bash",AI_ANIM_ATTACK_BASH);}
			if (AnimRange==  AI_ANIM_ATTACK_SLASH)//combat
				{playAnimation (NPC_ID +"_attack_slash",AI_ANIM_ATTACK_SLASH);}
			if (AnimRange==  AI_ANIM_ATTACK_THRUST)//combat
				{playAnimation (NPC_ID +"_attack_thrust",AI_ANIM_ATTACK_THRUST);}*/
			}
			break;
		}
	}

	void playAnimation(string pAnim, int newState)
	{
		if (newState!=currentState)
		{
			//MessageLog.text= name + "Playing anim:" + pAnim;
			currentState=newState;
			//MessageLog.text= name + "Playing anim:" + anim.animation.isPlaying;
			//Debug.Log (pAnim);
			CurrentAnim=pAnim;
			anim.Play(pAnim);



			//print(pAnim);
		}
		//currentState=newState;
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

/*	void OnMouseDown()
	{*/
		//return;
/*		switch (UWCharacter.InteractionMode)
		{
		case UWCharacter.InteractionModeOptions://Options
			MessageLog.text = "Nothing will happen in options mode " + name;
			break;
		case UWCharacter.InteractionModeTalk://Talk
			MessageLog.text = "You can't talk to " + name;
			AnimRange=1000;
			break;
		case UWCharacter.InteractionModePickup://Pickup
			MessageLog.text = "You pick up a " + name;
			break;
		case UWCharacter.InteractionModeLook://Look
			MessageLog.text = "You see a " + name;
			AnimRange=1;
			break;
		case UWCharacter.InteractionModeAttack://Attack
			MessageLog.text = "You attack a " + name;
			//followPlayer=true;
			AnimRange=100;
			break;
		case UWCharacter.InteractionModeUse://Use
			MessageLog.text = "You use a " + name;
			AnimRange=10;
			break;
		}*/
/*	}*/
}

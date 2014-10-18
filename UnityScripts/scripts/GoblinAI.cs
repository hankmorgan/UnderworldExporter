using UnityEngine;
using System.Collections;



public class GoblinAI : MonoBehaviour {

	public int AnimRange=1;//Multiple of 10 for dividing animations
	public string NPC_ID;
	public string CurrentAnim;
	public bool isDead=false;
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
	private GameObject player;
	private Animator anim;
	private int currentState=-1;
	private bool followPlayer=false;
	private string oldNPC_ID;
	// Use this for initialization
	void Awake () {
		oldNPC_ID=NPC_ID;
		MessageLog = (UILabel)GameObject.FindWithTag("MessageLog").GetComponent<UILabel>();
		//MessageLog.text="StartUp";
		//GameObject targetPoint = GameObject.Find ("a_goblin_52_59_00_0202");
		agent = GetComponent<NavMeshAgent>();
		player = GameObject.Find ("Gronk");
		//var agent: NavMeshAgent GetComponent.<NavMeshAgent>();
		//anim = GameObject.Find (name + "_Animation").GetComponent<Animator>();
		//anim = (Animator)transform.FindChild (name + "_Sprite").GetComponent<Animator>();
		//anim = GameObject.Find (name + "_sprite").GetComponent<Animator>();
		//anim = GetComponentInChildren<Animator>();
		anim=GetComponentInChildren<Animator>();
	}

	void ApplyDamage()
	{
		playAnimation(NPC_ID+"_death",100);
		isDead=true;
	}




	// Update is called once per frame
	void Update () {
		if (anim == null)
		{
			anim = GetComponentInChildren<Animator>();
		}
	if (isDead==true)
		{
			return;
		}
		//float angle = Quaternion.Angle(transform.rotation, player.transform.rotation);
		if (followPlayer==true)
		{
			//Vector3 target = player.transform.position;
			agent.SetDestination(player.transform.position);
		}
		if (NPC_ID!=oldNPC_ID)
		{
			currentState=-1;
			oldNPC_ID=NPC_ID;
		}


		Vector3 direction = player.transform.position - transform.position;
		float angle = Mathf.Atan2(direction.x,direction.z) * Mathf.Rad2Deg;
		int facingIndex = facing(angle);
	
		//print (angle);
		switch (facingIndex)
		{
		case 1:
			{	
			playAnimation(NPC_ID +"_idle_front",0);
			break;
			}
		case 2:
			{	
			playAnimation(NPC_ID +"_idle_front_left",1);
			break;
			}
		case 3:
			{	
			playAnimation(NPC_ID +"_idle_left",2);
			break;
			}
		case 4:
			{	
			playAnimation(NPC_ID +"_idle_rear_left",3);
			break;
			}
		case 5:
			{	
			playAnimation(NPC_ID +"_idle_rear",4);
			break;
			}
		case 6:
			{	
			playAnimation(NPC_ID + "_idle_rear_right",5);
			break;
			}
		case 7:
			{	
			playAnimation(NPC_ID +"_idle_right",6);
			break;
			}
		case 8:
			{	
			playAnimation(NPC_ID +"_idle_front_right",7);
			break;
			}
		case 10:
		{	
			playAnimation(NPC_ID +"_walking_front",0);
			break;
		}
		case 20:
		{	
			playAnimation(NPC_ID + "_walking_front_left",1);
			break;
		}
		case 30:
		{	
			playAnimation(NPC_ID + "_walking_left",2);
			break;
		}
		case 40:
		{	
			playAnimation(NPC_ID +"_walking_rear_left",3);
			break;
		}
		case 50:
		{	
			playAnimation(NPC_ID +"_walking_rear",4);
			break;
		}
		case 60:
		{	
			playAnimation(NPC_ID +"_walking_Rear_Right",5);
			break;
		}
		case 70:
		{	
			playAnimation(NPC_ID + "_walking_right",6);
			break;
		}
		case 80:
		{	
			playAnimation(NPC_ID + "_walking_front_right",7);
			break;
		}
		default://special non angled states
			{
				if (AnimRange== 100)//Dying
					{playAnimation (NPC_ID +"_death",100);}
				if (AnimRange== 1000)//combat
					{playAnimation (NPC_ID +"_attack_bash",1000);}
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
			//try
			//{
				CurrentAnim=pAnim;
				anim.Play(pAnim);
			//}
			//catch
			//{
			//	Debug.Log ("Failed to play anim" + pAnim);
			//}
			//print(pAnim);
		}
		//currentState=newState;
	}


	int facing(float angle)
	{
		//Breaks down the angle in the the facing sector. Clockwise from 0)
		if ((angle >= -22.5) && (angle <= 22.5)) 
				{
			return 1*AnimRange;//Facing forward
				} 
		else 
			{
			if ((angle>22.5)&&(angle<=67.5))
				{//Facing forward left
				return 2*AnimRange;
				}
			else
			{
				if ((angle >67.5)&&(angle<=112.5))
				{//facing (right)
					return 7*AnimRange;
				}
				else
				{
					if ((angle >112.5)&&(angle<=157.5))
					{//Facing away left
						return 4*AnimRange;
					}
					else
					{
						if (((angle >157.5)&&(angle<=180.0)) || ((angle>=-180)&&(angle<=-157.5)))
						{//Facing away
							return 5*AnimRange;
						}
						else
						{
							if ((angle >=-157.5)&&(angle<-112.5))
							{//Facing away right
								return 6*AnimRange;
							}
							else
							{
								if ((angle >-112.5)&&(angle<-67.5))
								{//Facing (left)
									return 3*AnimRange;
								}
								else
								{
									if ((angle >-67.5)&&(angle<-22.5))
									{//Facing forward right
										return 8*AnimRange;
									}
									else
									{
										return 0*AnimRange;//default
									}
								}
							}
						}
					}
				}
			}
		}
	}

	void OnMouseDown()
	{
		switch (UWCharacter.InteractionMode)
		{
		case 0://Options
			MessageLog.text = "Nothing will happen in options mode " + name;
			break;
		case 1://Talk
			MessageLog.text = "You can't talk to " + name;
			AnimRange=1000;
			break;
		case 2://Pickup
			MessageLog.text = "You pick up a " + name;
			break;
		case 4://Look
			MessageLog.text = "You see a " + name;
			AnimRange=1;
			break;
		case 8://Attack
			MessageLog.text = "You attack a " + name;
			//followPlayer=true;
			AnimRange=100;
			break;
		case 16://Use
			MessageLog.text = "You use a " + name;
			AnimRange=10;
			break;
		}
	}
}

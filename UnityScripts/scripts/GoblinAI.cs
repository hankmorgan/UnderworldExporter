using UnityEngine;
using System.Collections;


public class GoblinAI : MonoBehaviour {

	public int State=1;//Multiple of 10 for
	public string CurrentAnim;
	public string Idle_Front;
	public string Idle_Rear;
	public string Idle_Right;
	public string Idle_Left;
	public string Idle_Front_Right;
	public string Idle_Front_Left;
	public string Idle_Rear_Right;
	public string Idle_Rear_Left;
	public string Walking_Front;
	public string Walking_Rear;
	public string Walking_Right;
	public string Walking_Left;
	public string Walking_Front_Right;
	public string Walking_Front_Left;
	public string Walking_Rear_Right;
	public string Walking_Rear_Left;
	public string idle_combat;
	public string attack_bash;
	public string attack_slash;
	public string attack_thrust;
	public string attack_secondary;
	public string death;
	public string begin_combat;//?

	private UILabel MessageLog;
	private NavMeshAgent agent;
	private GameObject player;
	private Animator anim;
	private int currentState=-1;
	private bool followPlayer=false;
	// Use this for initialization
	void Awake () {
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
	
	// Update is called once per frame
	void Update () {
		if (anim == null)
		{
			anim = GetComponentInChildren<Animator>();
		}
		//float angle = Quaternion.Angle(transform.rotation, player.transform.rotation);
		if (followPlayer==true)
		{
			//Vector3 target = player.transform.position;
			agent.SetDestination(player.transform.position);
		}


		Vector3 direction = player.transform.position - transform.position;
		float angle = Mathf.Atan2(direction.x,direction.z) * Mathf.Rad2Deg;

	
		//print (angle);
		switch (facing(angle))
		{
		case 1:
			{	
			playAnimation(Idle_Front,0);
			break;
			}
		case 2:
			{	
			playAnimation(Idle_Front_Left,1);
			break;
			}
		case 3:
			{	
			playAnimation(Idle_Left,2);
			break;
			}
		case 4:
			{	
			playAnimation(Idle_Rear_Left,3);
			break;
			}
		case 5:
			{	
			playAnimation(Idle_Rear,4);
			break;
			}
		case 6:
			{	
			playAnimation(Idle_Rear_Right,5);
			break;
			}
		case 7:
			{	
			playAnimation(Idle_Right,6);
			break;
			}
		case 8:
			{	
			playAnimation(Idle_Front_Right,7);
			break;
			}
		case 10:
		{	
			playAnimation(Walking_Front,0);
			break;
		}
		case 20:
		{	
			playAnimation(Walking_Front_Left,1);
			break;
		}
		case 30:
		{	
			playAnimation(Walking_Left,2);
			break;
		}
		case 40:
		{	
			playAnimation(Walking_Rear_Left,3);
			break;
		}
		case 50:
		{	
			playAnimation(Walking_Rear,4);
			break;
		}
		case 60:
		{	
			playAnimation(Walking_Rear_Right,5);
			break;
		}
		case 70:
		{	
			playAnimation(Walking_Right,6);
			break;
		}
		case 80:
		{	
			playAnimation(Walking_Front_Right,7);
			break;
		}
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
				return 1*State;//Facing forward
				} 
		else 
			{
			if ((angle>22.5)&&(angle<=67.5))
				{//Facing forward left
				return 2*State;
				}
			else
			{
				if ((angle >67.5)&&(angle<=112.5))
				{//facing left
					return 3*State;
				}
				else
				{
					if ((angle >112.5)&&(angle<=157.5))
					{//Facing away left
						return 4*State;
					}
					else
					{
						if (((angle >157.5)&&(angle<=180.0)) || ((angle>=-180)&&(angle<=-157.5)))
						{//Facing away
							return 5*State;
						}
						else
						{
							if ((angle >=-157.5)&&(angle<-112.5))
							{//Facing away right
								return 6*State;
							}
							else
							{
								if ((angle >-112.5)&&(angle<-67.5))
								{//Facing right
									return 7*State;
								}
								else
								{
									if ((angle >-67.5)&&(angle<-22.5))
									{//Facing forward right
										return 8*State;
									}
									else
									{
										return 0*State;//default
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
		switch (ObjectVariables.InteractionMode)
		{
		case 0://Options
			MessageLog.text = "Nothing will happen in options mode " + name;
			break;
		case 1://Talk
			MessageLog.text = "You can't talk to " + name;
			State=1;
			break;
		case 2://Pickup
			MessageLog.text = "You pick up a " + name;
			break;
		case 4://Look
			MessageLog.text = "You see a " + name;
			break;
		case 8://Attack
			MessageLog.text = "You attack a " + name;
			followPlayer=true;
			break;
		case 16://Use
			MessageLog.text = "You use a " + name;
			State=10;
			break;
		}
	}
}

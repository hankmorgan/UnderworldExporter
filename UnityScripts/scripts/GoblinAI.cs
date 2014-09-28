using UnityEngine;
using System.Collections;


public class GoblinAI : MonoBehaviour {

	public string IdleForward;
	public string IdleAway;
	public string IdleRight;
	public string IdleLeft;
	public string IdleForwardRight;
	public string IdleForwardLeft;
	public string IdleAwayRight;
	public string IdleAwayLeft;

	private UILabel MessageLog;
	private NavMeshAgent agent;
	private GameObject player;
	private Animator anim;
	private int currentState=-1;
	private bool followPlayer=false;
	// Use this for initialization
	void Start () {
		MessageLog = (UILabel)GameObject.FindWithTag("MessageLog").GetComponent<UILabel>();
		//MessageLog.text="StartUp";
		//GameObject targetPoint = GameObject.Find ("a_goblin_52_59_00_0202");
		agent = GetComponent<NavMeshAgent>();
		player = GameObject.Find ("First Person Controller");
		//var agent: NavMeshAgent GetComponent.<NavMeshAgent>();
		//anim = GameObject.Find (name + "_Animation").GetComponent<Animator>();
		//anim = (Animator)transform.FindChild (name + "_Sprite").GetComponent<Animator>();
		//anim = GameObject.Find (name + "_sprite").GetComponent<Animator>();
		anim = GetComponentInChildren<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

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
		case 0:
			{	
			playAnimation(IdleForward,0);
			break;
			}
		case 1:
			{	
			playAnimation(IdleForwardLeft,1);
			break;
			}
		case 2:
			{	
			playAnimation(IdleLeft,2);
			break;
			}
		case 3:
			{	
			playAnimation(IdleAwayLeft,3);
			break;
			}
		case 4:
			{	
			playAnimation(IdleAway,4);
			break;
			}
		case 5:
			{	
			playAnimation(IdleAwayRight,5);
			break;
			}
		case 6:
			{	
			playAnimation(IdleRight,6);
			break;
			}
		case 7:
			{	
			playAnimation(IdleForwardRight,7);
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
				return 0;//Facing forward
				} 
		else 
			{
			if ((angle>22.5)&&(angle<=67.5))
				{//Facing forward left
				return 1;
				}
			else
			{
				if ((angle >67.5)&&(angle<=112.5))
				{//facing left
					return 2;
				}
				else
				{
					if ((angle >112.5)&&(angle<=157.5))
					{//Facing away left
						return 3;
					}
					else
					{
						if (((angle >157.5)&&(angle<=180.0)) || ((angle>=-180)&&(angle<=-157.5)))
						{//Facing away
							return 4;
						}
						else
						{
							if ((angle >=-157.5)&&(angle<-112.5))
							{//Facing away right
								return 5;
							}
							else
							{
								if ((angle >-112.5)&&(angle<-67.5))
								{//Facing right
									return 6;
								}
								else
								{
									if ((angle >-67.5)&&(angle<-22.5))
									{//Facing forward right
										return 7;
									}
									else
									{
										return 0;//default
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
			break;
		}
	}
}

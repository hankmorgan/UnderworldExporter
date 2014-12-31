using UnityEngine;
using System.Collections;

//OPTIONS_MODE 0
//TALK_MODE 1
//PICKUP_MODE 2
//LOOK_MODE 4
//ATTACK_MODE 8
//USE_MODE 16
/*
Functions for activating the next trigger in the chain.
 */
public class TriggerHandler : MonoBehaviour {
	public int triggerX;
	public int triggerY;
	//public int state;
	public string trigger;//what is set off
	private ObjectVariables Var;
	private GameObject triggerObj;
	private UILabel MessageLog;
	public int InteractionFlag;	//Bit wise interaction 

	// Use this for initialization
	void Start () {
		MessageLog = (UILabel)GameObject.FindWithTag("MessageLog").GetComponent<UILabel>();
		Var=GetComponent<ObjectVariables>();
		triggerObj=GameObject.Find (trigger);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Activate()
	{
		ObjectVariables targetvars = triggerObj.GetComponent<ObjectVariables>();
		targetvars.triggerX=triggerX;
		targetvars.triggerY=triggerY;
		targetvars.state=Var.state;
		MessageLog.text=MessageLog.text + name +"_activated";
		triggerObj.SendMessage ("Activate");
		
		if (Var.state == 8)
		{
			Var.state = 0;
		}
		else
		{
			Var.state++;
		}
	}

	void OnTriggerEnter(Collider other)
		{
		if (other.name=="Gronk")
		//Debug.Log ("TriggerEntered");
			{
			Activate ();
			}
		}
}

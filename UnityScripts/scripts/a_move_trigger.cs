using UnityEngine;
using System.Collections;

public class a_move_trigger : trigger_base {
/*	
	private GameObject triggerObj;
	private ObjectVariables Var;
	private UILabel MessageLog;

	
	// Use this for initialization
	void Start () {
		MessageLog = (UILabel)GameObject.FindWithTag("MessageLog").GetComponent<UILabel>();
		Var=GetComponent<ObjectVariables>();
	}
	
	public void Activate()
	{
		//Do what it needs to do.
		Debug.Log (name + " activated");
		if (Var.trigger !="")
		{//Trigger the next object in it's chain
			triggerObj.SendMessage ("Activate");
		}
	}
	*/

	///void OnCollisionEnter(Collision collision)
	//{
		//if (other.name=="Gronk")
			//Debug.Log ("TriggerEntered");
		//{
		//	Activate ();
		//}
//	}

	void OnTriggerEnter(Collider other)
	{
		if (other.name=="Gronk")
			//Debug.Log ("TriggerEntered");
		{
			Activate ();
		}
	}
}

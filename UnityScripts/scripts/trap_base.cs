using UnityEngine;
using System.Collections;

public class trap_base : MonoBehaviour {

	private GameObject triggerObj;
	private ObjectVariables Var;
	private UILabel MessageLog;
	
	//TODO:Update traps to base themselves off of this..
	//TODO:Add this to obj_base.
	// Use this for initialization
	void Start () {
		MessageLog = (UILabel)GameObject.FindWithTag("MessageLog").GetComponent<UILabel>();
		Var=GetComponent<ObjectVariables>();
		triggerObj=GameObject.Find (Var.trigger);
	}
	

	public void Activate()
	{
		
		//Do what it needs to do.
		MessageLog.text=MessageLog.text + name + " activated";
		if (Var.trigger !="")
		{
			triggerObj.SendMessage ("Activate");
		}
	}
}

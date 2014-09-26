using UnityEngine;
using System.Collections;

public class a_do_trap_camera : MonoBehaviour {
	
	private GameObject triggerObj;
	private ObjectVariables Var;
	private UILabel MessageLog;

	
	// Use this for initialization
	void Start () {
		MessageLog = (UILabel)GameObject.FindWithTag("MessageLog").GetComponent<UILabel>();
		Var=GetComponent<ObjectVariables>();
	}
	
	// Update is called once per frame
	//void Update () {
	
	//}
	
	public void Activate()
	{
		//Do what it needs to do.
		MessageLog.text=MessageLog.text + name + " activated\n";
		if (Var.trigger !="")
		{//Trigger the next object in it's chain
			triggerObj.SendMessage ("Activate");
		}
	}
}

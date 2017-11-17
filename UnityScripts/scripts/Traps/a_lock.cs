using UnityEngine;
using System.Collections;

public class a_lock : trap_base {
	/*
Not really used by uwexporter but does exist in UW. Created here for compatabilty.
	 */
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
		MessageLog.text=MessageLog.text + name + " activated\n";
		if (Var.trigger !="")
		{//Trigger the next object in it's chain
			triggerObj.SendMessage ("Activate");
		}
	}*/

	public override void ExecuteTrap (object_base src, int triggerX, int triggerY, int State)
	{
		//Debug.Log(this.name + " called by " +src.name);
				//LockObject.flags = (short)(LockObject.flags | 0x1);

				if ((objInt().flags & 0x1) == 1)
				{//locked
					objInt().flags = (short)(objInt().flags & 0xE);	
				}
				else
				{
					objInt().flags = (short)(objInt().flags | 0x1);
				}
	}


	public override void TriggerNext (int triggerX, int triggerY, int State)
	{
	
	}

	public override void PostActivate (object_base src)
	{

	}
}

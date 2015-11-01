using UnityEngine;
using System.Collections;

public class a_use_trigger : MonoBehaviour {
	
	private GameObject triggerObj;
	private ObjectVariables Var;
	private UILabel MessageLog;
	
	public int state;
	// Use this for initialization
	void Start () {
		MessageLog = (UILabel)GameObject.FindWithTag("MessageLog").GetComponent<UILabel>();
		Var=GetComponent<ObjectVariables>();
		triggerObj=GameObject.Find (Var.trigger);
		if (triggerObj != null)
			{
			triggerObj.GetComponent<ObjectVariables>().state=state;
			}
	}
	
	public void Activate()
	{
		if (triggerObj == null)
		{
			triggerObj=GameObject.Find (Var.trigger);
			if (triggerObj != null)
			{
				triggerObj.GetComponent<ObjectVariables>().state=state;
			}
		}
		//Do what it needs to do.
		MessageLog.text=MessageLog.text + name + " activated";
		ObjectVariables triggerVars = triggerObj.GetComponent<ObjectVariables>();
		if (triggerVars.state >8)
		{
			triggerVars.state=1;
		}
		else
		{
			triggerVars.state++;
		}
		if (Var.trigger !="")
		{
			triggerObj.SendMessage ("Activate");
		}
	}
}

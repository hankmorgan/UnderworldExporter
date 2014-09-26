using UnityEngine;
using System.Collections;

public class TriggerHandler : MonoBehaviour {
	public int triggerX;
	public int triggerY;
	public string trigger;//what is set off
	private ObjectVariables Var;
	private GameObject triggerObj;
	private UILabel MessageLog;

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
		MessageLog.text=MessageLog.text + name +"_activated";
		triggerObj.SendMessage ("Activate");
	}
}

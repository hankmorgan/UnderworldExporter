using UnityEngine;
using System.Collections;

public class ButtonHandler : MonoBehaviour {
	public string trigger;
	public int triggerX;
	public int triggerY;
	public int state;
	public int maxstate;

	private GameObject triggerObj;
	private UILabel MessageLog;
	// Use this for initialization
	void Start () {
		MessageLog = (UILabel)GameObject.FindWithTag("MessageLog").GetComponent<UILabel>();
		triggerObj=GameObject.Find (trigger);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGui(){
		//MessageLog.text=name;
	}

	void OnTriggerEnter()
	{
		//counter++;
		//MessageLog.text=name +"triggered";// + counter;
	}

	void OnMouseEnter()
	{
		//MessageLog.text=name +"entered";
	}

	void OnMouseExit()
	{
		//MessageLog.text=name +"exited";
	}

	void OnMouseDown()
	{
		ObjectVariables targetvars = triggerObj.GetComponent<ObjectVariables>();
		targetvars.triggerX=triggerX;
		targetvars.triggerY=triggerY;
		MessageLog.text=name +"_clicked";
		triggerObj.SendMessage ("Activate");
	}
}


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
	private ObjectVariables Var;
	// Use this for initialization
	void Start () {
		MessageLog = (UILabel)GameObject.FindWithTag("MessageLog").GetComponent<UILabel>();
		triggerObj=GameObject.Find (trigger);
		Var=GetComponent<ObjectVariables>();
	}
	
	// Update is called once per frame
	void Update () {
	if (triggerObj == null)
		{
			triggerObj=GameObject.Find (trigger);
		}
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
				break;
			case 16://Use
				MessageLog.text = "You use a " + name;
				ObjectVariables targetvars = triggerObj.GetComponent<ObjectVariables>();
				targetvars.triggerX=triggerX;
				targetvars.triggerY=triggerY;
				targetvars.state=Var.state;
				MessageLog.text=name +"_clicked";
				triggerObj.SendMessage ("Activate");
				if (Var.state == 8)
					{
						Var.state=0;
					}
				else
					{
						Var.state++;
					}
				break;
			}

	}	
}


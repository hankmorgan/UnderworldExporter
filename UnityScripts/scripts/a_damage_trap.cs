using UnityEngine;
using System.Collections;

public class a_damage_trap : MonoBehaviour {
	
	private GameObject triggerObj;
	private ObjectVariables Var;
	private UILabel MessageLog;

	
	// Use this for initialization
	void Start () {
		MessageLog = (UILabel)GameObject.FindWithTag("MessageLog").GetComponent<UILabel>();
		Var=GetComponent<ObjectVariables>();
		triggerObj=GameObject.Find (Var.trigger);
	}
	
	// Update is called once per frame
	void Update () {
		if ((triggerObj == null) && (Var.trigger != "") && (Var.trigger != null))
		{//For when objects are added at run time.
			triggerObj=GameObject.Find (Var.trigger);
		}
	}
	
	public void Activate()
	{
		//Do what it needs to do.
		Debug.Log(name + " activated." + Var.trigger) ;
		if (triggerObj !=null )
		{
			triggerObj.SendMessage ("Activate");
		}
	}
}

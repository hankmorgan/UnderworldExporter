using UnityEngine;
using System.Collections;

public class a_teleport_trap : trap_base {

//	private GameObject triggerObj;
	//private ObjectVariables Var;
	//private UILabel MessageLog;
	public int levelNo;
	public float targetX;
	public float targetY;
	public float targetZ;
	//public bool LevelTeleport=false;
	// Use this for initialization
	//void Start () {
	//	MessageLog = (UILabel)GameObject.FindWithTag("MessageLog").GetComponent<UILabel>();
	//	Var=GetComponent<ObjectVariables>();
	//	triggerObj=GameObject.Find (Var.trigger);
	//}

	public override void ExecuteTrap (int triggerX, int triggerY, int State)
	{
		//GameObject player = GameObject.Find ("Gronk");
		CheckReferences();
		if (levelNo==0)//At the moment ignore the level teleport.
		{
			playerUW.gameObject.transform.position = new Vector3(targetX,targetZ+0.3f,targetY);
		}
		else
		{
			Debug.Log ("teleporting to level " + levelNo);
		}
	}

	//public void Activate()
	//{
		
		//Do what it needs to do.
		//Teleport to the location specified by the x,y,z

		//MessageLog.text=MessageLog.text + name + " activated";
	//	if (Var.trigger !="")
	//	{
	//		triggerObj.SendMessage ("Activate");
	//	}
	//}
}

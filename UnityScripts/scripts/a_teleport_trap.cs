using UnityEngine;
using System.Collections;

public class a_teleport_trap : MonoBehaviour {
	
	private GameObject triggerObj;
	private ObjectVariables Var;
	private UILabel MessageLog;
	public float targetX;
	public float targetY;
	public float targetZ;
	public bool LevelTeleport=false;
	// Use this for initialization
	void Start () {
		MessageLog = (UILabel)GameObject.FindWithTag("MessageLog").GetComponent<UILabel>();
		Var=GetComponent<ObjectVariables>();
		triggerObj=GameObject.Find (Var.trigger);
	}

	public void Activate()
	{
		
		//Do what it needs to do.
		//Teleport to the location specified by the x,y,z
		GameObject player = GameObject.Find ("Gronk");
		if ((player!=null) && (LevelTeleport!=true))//At the moment ignore the level teleport.
			{
			player.transform.position = new Vector3(targetX,targetZ+0.3f,targetY);
			}
		MessageLog.text=MessageLog.text + name + " activated";
		if (Var.trigger !="")
		{
			triggerObj.SendMessage ("Activate");
		}
	}
}

using UnityEngine;
using System.Collections;

public class a_door_trap : MonoBehaviour {
	
	private GameObject triggerObj;
	private ObjectVariables Var;
	private UILabel MessageLog;
	public int quality;

	// Use this for initialization
	void Start () {
		MessageLog = (UILabel)GameObject.FindWithTag("MessageLog").GetComponent<UILabel>();
		Var=GetComponent<ObjectVariables>();
	}
	
	// Update is called once per frame
	void Update () {
		if ((triggerObj = null) && (Var.trigger != "") && (Var.trigger != null))
		{//For when objects are added at run time.
			triggerObj=GameObject.Find (Var.trigger);
		}
	}
	
	public void Activate()
	{
		GameObject door = Var.findDoor(Var.triggerX,Var.triggerY);

		if (door!=null)
		{
			DoorControl DC = door.GetComponent<DoorControl>();
			switch (quality)
			{
			case 1://try open
				//MessageLog.text=MessageLog.text + door.name + " opened\n";
				DC.UnlockDoor();
				DC.OpenDoor();
				break;
			case 2://try close
				//MessageLog.text=MessageLog.text + door.name + " closed\n";
				DC.CloseDoor();
				DC.LockDoor ();
				break;
			case 3://try toggle
				//MessageLog.text=MessageLog.text + door.name + " toggled\n";
				DC.ToggleDoor();
				break;
			}

		}
		else
		{
			Debug.Log ("Door not found!");
		}
		//Do what it needs to do.

		//A door trap has no further items in it's chain.
		//if (Var.trigger !="")
		//{//Trigger the next object in it's chain
		//	triggerObj.SendMessage ("Activate");
		//}
	}
}

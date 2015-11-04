using UnityEngine;
using System.Collections;

public class a_door_trap : trap_base {
	
	//private GameObject triggerObj;
	//private ObjectVariables Var;
	//private UILabel MessageLog;
	//public int quality;

	// Use this for initialization
	//void Start () {
	//	MessageLog = (UILabel)GameObject.FindWithTag("MessageLog").GetComponent<UILabel>();
	//	Var=GetComponent<ObjectVariables>();
	//}
	//

	public override void ExecuteTrap (int triggerX, int triggerY, int State)
	{
		GameObject door = GameWorldController.findDoor(triggerX,triggerY);
		if (door!=null)
		{
			DoorControl DC = door.GetComponent<DoorControl>();
			switch (objInt.Quality)
			{
			case 1://try open
				DC.UnlockDoor();
				DC.OpenDoor();
				break;
			case 2://try close
				DC.CloseDoor();
				DC.LockDoor ();
				break;
			case 3://try toggle
				DC.ToggleDoor();
				break;
			}
			
		}
		else
		{
			Debug.Log ("Door not found!");
		}

	}

//	public override bool Activate (int triggerX, int triggerY)
	//{


	//	GameObject triggerObj=GameObject.Find (TriggerObject);


	//}
}

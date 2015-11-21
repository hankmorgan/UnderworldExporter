using UnityEngine;
using System.Collections;

public class a_door_trap : trap_base {
/*
Opens the door that is in the targeted tile.
 */


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
}

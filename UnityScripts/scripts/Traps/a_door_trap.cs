using UnityEngine;
using System.Collections;

public class a_door_trap : trap_base {
/*
Opens the door that is in the targeted tile.
 */

	public override void ExecuteTrap (int triggerX, int triggerY, int State)
	{
		Debug.Log (this.name);
		GameObject door = GameWorldController.findDoor(triggerX,triggerY);

		if (door!=null)
		{

			DoorControl DC = door.GetComponent<DoorControl>();

			switch (objInt().quality)
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
				//TODO:check if toggle respects unlocked status. (door trap 1001 on level 3)
				DC.ToggleDoor();
				break;
			}

		}
		else
		{
			Debug.Log ("Door not found!");
		}
	}

	public override void PostActivate ()
	{//To stop destruction of trap

	}
}

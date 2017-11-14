using UnityEngine;
using System.Collections;

public class a_door_trap : trap_base {
/*
Opens the door that is in the targeted tile.
 */
	public bool TriggerInstantly;

	public override void ExecuteTrap (object_base src, int triggerX, int triggerY, int State)
	{
		//Debug.Log (this.name);
		GameObject door = GameWorldController.findDoor(triggerX,triggerY);

		if (door!=null)
		{
			DoorControl DC = door.GetComponent<DoorControl>();

			switch (objInt().quality)
			{
			case 1://try open
				if (TriggerInstantly)
				{
					DC.UnlockDoor();
					DC.OpenDoor(0f);	
				}
				else
				{
					DC.UnlockDoor();
					DC.OpenDoor(DoorControl.DefaultDoorTravelTime);	
				}

				break;
			case 2://try close
				if (TriggerInstantly)
				{
					DC.CloseDoor(0f);
					DC.LockDoor ();		
				}
				else
				{
					DC.CloseDoor(DoorControl.DefaultDoorTravelTime);
					DC.LockDoor ();			
				}

				break;
			case 3://try toggle
				//TODO:check if toggle respects unlocked status. (door trap 1001 on level 3)
				if (TriggerInstantly)
				{
					DC.ToggleDoor(0);						
				}
				else
				{
					DC.ToggleDoor(DoorControl.DefaultDoorTravelTime);
				}				
				break;
			}

		}
		else
		{
			Debug.Log ("Door not found!");
		}
	}

	public override void PostActivate (object_base src)
	{//To stop destruction of trap

	}
}

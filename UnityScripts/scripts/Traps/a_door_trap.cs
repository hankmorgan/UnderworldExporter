using UnityEngine;
using System.Collections;

public class a_door_trap : trap_base {
/*
Opens the door that is in the targeted tile.
 */
	public bool TriggerInstantly;

	public override void ExecuteTrap (object_base src, int triggerX, int triggerY, int State)
	{
		GameObject door = GameWorldController.findDoor(triggerX,triggerY);

		if (door!=null)
		{
			DoorControl DC = door.GetComponent<DoorControl>();

			switch (quality)
			{
			case 0://Just lock
				//Copy the lock object at the link to use on this door
				if (link!=0)
				{//link to a lock
					if (ObjectLoader.GetItemTypeAt(link)	== ObjectInteraction.LOCK)	
					{
						ObjectInteraction lockToCopy = ObjectLoader.getObjectIntAt(link);
						ObjectLoaderInfo newobjt= ObjectLoader.newObject(lockToCopy.item_id,lockToCopy.quality,lockToCopy.owner,lockToCopy.link,256);
						newobjt.flags=lockToCopy.flags;
						newobjt.doordir=lockToCopy.doordir;
						newobjt.invis=lockToCopy.invis;
						newobjt.enchantment=lockToCopy.enchantment;
						newobjt.zpos=lockToCopy.zpos;
						newobjt.xpos = lockToCopy.xpos;
						newobjt.ypos = lockToCopy.ypos;
						newobjt.next=DC.link;//To allow proper triggering of traps
						newobjt.InUseFlag=1;
												GameObject Created = ObjectInteraction.CreateNewObject(GameWorldController.instance.currentTileMap(),newobjt,GameWorldController.instance.CurrentObjectList().objInfo, GameWorldController.instance.InventoryMarker.gameObject, GameWorldController.instance.InventoryMarker.transform.position).gameObject;
						DC.link=newobjt.index;	//Point the lock at this new lock							
					}	
				}
				else
				{//unlink the lock and tie the locks next back to the door as it's link																					
					ObjectInteraction linkedObj = ObjectLoader.getObjectIntAt(DC.link);
					if (linkedObj!=null)
					{
						DC.link= linkedObj.next;
						linkedObj.objectloaderinfo.InUseFlag=0;
						Destroy(linkedObj);		
					}
				}
				break;

			case 1://try open
				if (TriggerInstantly)
				{
					DC.UnlockDoor(false);
					DC.OpenDoor(0f);	
				}
				else
				{
					DC.UnlockDoor(false);
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
					DC.ToggleDoor(0,false);						
				}
				else
				{
					DC.ToggleDoor(DoorControl.DefaultDoorTravelTime,false);
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
        Debug.Log("Overridden PostActivate to test " + this.name);
        base.PostActivate(src);
    }
}

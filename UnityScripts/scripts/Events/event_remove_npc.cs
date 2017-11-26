using UnityEngine;
using System.Collections;

public class event_remove_npc : event_base {

//Removes an npc from the game world but does not kill them

	public override void ExecuteEvent ()
	{
		base.ExecuteEvent();
		int WhoAmI=RawData[4];
		NPC[] npc = findNPC(WhoAmI);
		if (npc!=null)
		{
			for (int i=0; i<=npc.GetUpperBound(0);i++)
			{
				npc[i].gameObject.transform.position = UWCharacter.Instance.playerInventory.InventoryMarker.transform.position;
			}
		}
	}
}

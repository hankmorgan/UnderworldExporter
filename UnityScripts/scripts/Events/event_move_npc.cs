using UnityEngine;
using System.Collections;

public class event_move_npc : event_base {

//Moves an NPC to a specified tileX & tile Y
		//Not sure how this should differ from placenpc event

	public override void ExecuteEvent ()
	{
		base.ExecuteEvent();
		int tileX=RawData[3];
		int tileY=RawData[4];
		int WhoAmI= RawData[6];
		Vector3 pos = GameWorldController.instance.currentTileMap().getTileVector(tileX,tileY);

		NPC[] npc = findNPC(WhoAmI);
		if (npc!=null)
		{
			for (int i=0; i<=npc.GetUpperBound(0);i++)
			{
				npc[i].transform.position=pos;
				npc[i].npc_xhome=(short)tileX;
				npc[i].npc_yhome=(short)tileY;
			}
		}
	}
}


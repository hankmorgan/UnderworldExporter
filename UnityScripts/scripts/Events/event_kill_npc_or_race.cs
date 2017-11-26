using UnityEngine;
using System.Collections;

public class event_kill_npc_or_race : event_base {


	public override void ExecuteEvent ()
	{
		base.ExecuteEvent();
		NPC[] npcs=null;
		bool isNPC = (RawData[5]==1);
		if (isNPC)
		{
			int WhoAmI = RawData[4];
			npcs = findNPC(WhoAmI);
		}
		else
		{	
			int race=RawData[4];
			npcs=findRace(race);
		}
		if (npcs!=null)
		{
			for (int i=0; i<=npcs.GetUpperBound(0);i++)
			{
				npcs[i].npc_hp=-1;	
			}
		}
	}
}

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

    public override string EventName()
    {
        return "Kill_NPC_Or_Race";
    }

    public override string summary()
    {
        bool isNPC = (RawData[5] == 1);
        if (isNPC)
        {
            return base.summary() + "\n\t\tIsNPC=" + (int)RawData[5] + ",WhoAmI=" + (int)RawData[4];
        }
        else
        {
            return base.summary() + "\n\t\tIsNPC=" + (int)RawData[5] + ",Race=" + (int)RawData[4];
        }
    }
}

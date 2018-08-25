using UnityEngine;
using System.Collections;

public class event_kill_npc : event_base {
//Take a guess.


	public override void ExecuteEvent ()
	{
		base.ExecuteEvent();
		int WhoAmI = RawData[4];
		NPC[] npc = findNPC(WhoAmI);
		if (npc!=null)
		{
			for (int i=0; i<=npc.GetUpperBound(0);i++)
			{
					npc[i].npc_hp=-1;//Force death in next frame					
			}			
		}
	}

    public override string EventName()
    {
        return "Kill_NPC";
    }

    public override string summary()
    {
        return base.summary() + "\n\t\tWhoAmI=" + (int)RawData[4];
    }
}

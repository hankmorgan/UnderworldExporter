using UnityEngine;
using System.Collections;

public class event_set_race_attitude : event_base {
		//Set the attitude of a race towards you.

	public override void ExecuteEvent ()
	{
		base.ExecuteEvent();
		int Race=RawData[4];
		int newAttitude = RawData[5];

		NPC[] npcs =findRace(Race);
		if (npcs!=null)
		{
			for (int i=0; i<=npcs.GetUpperBound(0);i++)
			{
				npcs[i].npc_attitude=(short)newAttitude;		
			}	
		}
	}

    public override string EventName()
    {
        return "set_race_attitude";
    }

    public override string summary()
    {
        return base.summary() + "\n\t\tRace=" + (int)RawData[4] + ",Attitude=" + (int)RawData[5];
    }
}

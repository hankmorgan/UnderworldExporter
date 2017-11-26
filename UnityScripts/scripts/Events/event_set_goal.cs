using UnityEngine;
using System.Collections;

public class event_set_goal : event_always {

//Event that sets the goal for an NPC or a race

	public override void ExecuteEvent ()
	{
		base.ExecuteEvent();
		bool isNPC = RawData[3]==0;
		int WhoAmIorRace=RawData[4];
		int newGoal = RawData[5];
		int gtarg=RawData[6];
		NPC[] npcs=null;
		if (isNPC)
		{
			npcs=findNPC(WhoAmIorRace);
		}
		else
		{
			//set for each npc of this race.
			//I think this is based on an area of effect but for now implement to all npcs
			//Only usage is in the pits.
			npcs= findRace(WhoAmIorRace);
		}

		if (npcs!=null)
		{
				for (int i=0; i<=npcs.GetUpperBound(0);i++)
				{
						npcs[i].npc_goal=(short)newGoal;	
						npcs[i].npc_gtarg=(short)gtarg;
				}
		}
	}
}

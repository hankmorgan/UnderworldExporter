using UnityEngine;
using System.Collections;

public class a_hack_trap_coward : a_hack_trap {

	//Used when the avatar flees the arena 

	public override void ExecuteTrap (object_base src, int triggerX, int triggerY, int State)
	{
		int OpponentsFound=0;
		int OpponentIndex=0;		
		for (int i=0;i<=Quest.instance.ArenaOpponents.GetUpperBound(0);i++)
		{
			if (Quest.instance.ArenaOpponents[i]!=0)
			{
				OpponentsFound++;
				OpponentIndex=Quest.instance.ArenaOpponents[i];
				ObjectInteraction objI = ObjectLoader.getObjectIntAt(OpponentIndex);
				if (objI!=null)
				{
					if (objI.GetComponent<NPC>()!=null)
					{//Make NPC calmer.
						objI.GetComponent<NPC>().npc_attitude=1;
						objI.GetComponent<NPC>().npc_goal=(short)NPC.npc_goals.npc_goal_wander_8;
					}
				}
			}
			Quest.instance.ArenaOpponents[i]=0;
		}
		//Reduce player reputation.
		if (OpponentsFound>0)
		{
			//Update win loss record to record a loss
			Quest.instance.QuestVariables[129] = Mathf.Max(Quest.instance.QuestVariables[129]-OpponentsFound, 0);
			Quest.instance.QuestVariables[133]=0;
			if (OpponentIndex>0)
			{//Begin taunting conversation.
				ObjectInteraction objI = ObjectLoader.getObjectIntAt(OpponentIndex);
				if (objI!=null)
				{
					objI.TalkTo();		
				}
			}
			else
			{
				Quest.instance.FightingInArena=false;
			}
		}
		
	}


	public override void PostActivate (object_base src)
	{

	}
}
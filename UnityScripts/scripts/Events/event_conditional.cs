using UnityEngine;
using System.Collections;

public class event_conditional : event_base {
		//Checks the conditions based on quest flag and variables and begins a sequence of events until the next conditional is found.


		public override bool CheckCondition ()
		{
				bool isQuest = (RawData[4]==1);
				bool variableTest=false;
				int variable = RawData[3];			
				if (isQuest)
				{
						variableTest= (Quest.instance.QuestVariables[variable]==1);
				}
				else
				{
						variableTest= (Quest.instance.variables[variable]==1)	;
				}
				return ((variableTest) && (xclocktest()) && (LevelTest()));
		}

}

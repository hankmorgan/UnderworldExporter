using UnityEngine;
using System.Collections;

public class event_conditional : event_base {
		//Checks the conditions based on quest flag and variables and begins a sequence of events until the next conditional is found.


	public override void Process ()
	{
		Executing=CheckCondition();
	}


	public override bool CheckCondition ()
	{
		bool isQuest = (RawData[4]==1);
		bool variableTest=false;
		int variable = RawData[3];	
		int targetValue= RawData[8];
		if (isQuest)
		{
			variableTest= (Quest.instance.QuestVariables[variable]==targetValue);
		}
		else
		{//TODO:verify if variable tests require at least zero and up to target value or just an exact target value match
			variableTest= (Quest.instance.variables[variable]==targetValue);
		}
		return ((variableTest) && (xclocktest()) && (LevelTest()));
	}

	public override void PostEvent ()
	{
		//preent destruction of the event.
	}

    public override string EventName()
    {
        return "Conditional";
    }


    public override string summary()
    {
        int isQuest = RawData[4] ;
        int variable = RawData[3];
        int targetValue = RawData[8];
        return base.summary() + "\n\t\tIsQuest=" + isQuest + ",Variable=" + variable + ",TargetValue=" + targetValue;
    }
}

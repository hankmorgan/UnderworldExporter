using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Action;
using RAIN.Core;

[RAINAction]
public class AI_COMBAT_END : RAINAction
{
    public override void Start(RAIN.Core.AI ai)
    {
        base.Start(ai);
    }

    public override ActionResult Execute(RAIN.Core.AI ai)
    {
//		NPC npc=  ai.Body.GetComponent<NPC>();
//		npc.npc_attitude=1;
		//GoblinAI gob=  ai.Body.GetComponent<GoblinAI>();
		//gob.isHostile=false;
		//ai.WorkingMemory.SetItem<bool>("isHostile",false);
		ai.WorkingMemory.SetItem<int>("state",0); //goto idle states
        return ActionResult.SUCCESS;
    }

    public override void Stop(RAIN.Core.AI ai)
    {
        base.Stop(ai);
    }
}
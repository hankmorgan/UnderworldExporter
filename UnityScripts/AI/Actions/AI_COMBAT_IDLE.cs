using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Action;
using RAIN.Core;

[RAINAction]
public class AI_COMBAT_IDLE : RAINAction
{
    public override void Start(RAIN.Core.AI ai)
    {
        base.Start(ai);
    }

    public override ActionResult Execute(RAIN.Core.AI ai)
    {
		ai.WorkingMemory.SetItem<bool>("isMovingRandom",false);
		NPC npc=  ai.Body.GetComponent<NPC>();
		npc.AnimRange=NPC.AI_ANIM_COMBAT_IDLE;

        return ActionResult.SUCCESS;
    }

    public override void Stop(RAIN.Core.AI ai)
    {
        base.Stop(ai);
    }
}
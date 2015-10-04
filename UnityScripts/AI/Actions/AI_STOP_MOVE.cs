using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Action;
using RAIN.Core;

[RAINAction]
public class AI_STOP_MOVE : RAINAction
{
    public override void Start(RAIN.Core.AI ai)
    {
        base.Start(ai);
    }

    public override ActionResult Execute(RAIN.Core.AI ai)
    {
		//ai.WorkingMemory.GetItem<Vector3>("moveStartPoint");
		ai.WorkingMemory.SetItem<Vector3>("MoveTarget",ai.WorkingMemory.GetItem<Vector3>("moveStartPoint"));
		//ai.WorkingMemory.SetItem<bool>("isMovingRandom",false);
        return ActionResult.SUCCESS;
    }

    public override void Stop(RAIN.Core.AI ai)
    {
        base.Stop(ai);
    }
}
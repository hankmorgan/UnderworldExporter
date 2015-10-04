using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Action;
using RAIN.Core;

[RAINAction]
public class AI_ATTACK_RANDOM : RAINAction
{
    public override void Start(RAIN.Core.AI ai)
    {
        base.Start(ai);
    }

    public override ActionResult Execute(RAIN.Core.AI ai)
    {
		GoblinAI gob=  ai.Body.GetComponent<GoblinAI>();
		switch (Random.Range(0,3))
		{
		case 0:
			gob.AnimRange=GoblinAI.AI_RANGE_ATTACK_BASH;break;
		case 1:
			gob.AnimRange=GoblinAI.AI_ANIM_ATTACK_SLASH;break;
		case 2:
			gob.AnimRange=GoblinAI.AI_ANIM_ATTACK_THRUST;break;
		}

        return ActionResult.SUCCESS;
    }

    public override void Stop(RAIN.Core.AI ai)
    {
        base.Stop(ai);
    }
}
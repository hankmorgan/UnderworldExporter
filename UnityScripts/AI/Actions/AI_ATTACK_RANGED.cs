using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Action;
using RAIN.Core;

[RAINAction]
public class AI_ATTACK_RANGED : RAINAction
{
    public override void Start(RAIN.Core.AI ai)
    {
        base.Start(ai);
    }

	public override ActionResult Execute(RAIN.Core.AI ai)
	{
			NPC npc=  ai.Body.GetComponent<NPC>();
			npc.ExecuteRangedAttack();

			return ActionResult.SUCCESS;
	}

    public override void Stop(RAIN.Core.AI ai)
    {
        base.Stop(ai);
    }
}
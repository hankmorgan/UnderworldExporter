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
		NPC npc=  ai.Body.GetComponent<NPC>();
		switch (Random.Range(0,3))
		{
		case 0:
			npc.AnimRange=NPC.AI_ANIM_ATTACK_BASH;break;
		case 1:
			npc.AnimRange=NPC.AI_ANIM_ATTACK_SLASH;break;
		case 2:
			npc.AnimRange=NPC.AI_ANIM_ATTACK_THRUST;break;
		}

        return ActionResult.SUCCESS;
    }

    public override void Stop(RAIN.Core.AI ai)
    {
        base.Stop(ai);
    }
}
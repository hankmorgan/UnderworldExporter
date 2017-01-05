using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Action;
using RAIN.Core;

[RAINAction]
public class AI_ATTACK_SECONDARY : RAINAction
{
    public override void Start(RAIN.Core.AI ai)
    {
        base.Start(ai);
    }

    public override ActionResult Execute(RAIN.Core.AI ai)
    {
				
		NPC npc=  ai.Body.GetComponent<NPC>();

				if (
						(npc.NPC_ID=="70")
						||
						(npc.NPC_ID=="76")
						||
						(npc.NPC_ID=="77")
						||
						(npc.NPC_ID=="78")
				)//Only some NPCs have a secondary animation
				{
						npc.AnimRange=NPC.AI_ANIM_ATTACK_SECONDARY;				
				}
				else
				{//Default if not an npc with a secondary
					npc.AnimRange=NPC.AI_ANIM_ATTACK_BASH;
				}
		
        return ActionResult.SUCCESS;
    }

    public override void Stop(RAIN.Core.AI ai)
    {
        base.Stop(ai);
    }
}
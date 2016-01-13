using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Action;
using RAIN.Core;

[RAINAction]
public class AI_DEATH : RAINAction
{
    public override void Start(RAIN.Core.AI ai)
    {
        base.Start(ai);
    }

    public override ActionResult Execute(RAIN.Core.AI ai)
    {
		NPC npc =  ai.Body.GetComponent<NPC>();
		npc.AnimRange=NPC.AI_RANGE_DEATH;
		GameObject mus = GameObject.Find ("MusicController");
		if (mus!=null)
		{
			MusicController.LastAttackCounter=0.0f;
			mus.GetComponent<MusicController>().PlaySpecialClip(mus.GetComponent<MusicController>().VictoryTracks);

		}
        return ActionResult.SUCCESS;
    }

    public override void Stop(RAIN.Core.AI ai)
    {
        base.Stop(ai);
    }
}
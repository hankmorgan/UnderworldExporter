using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellEffectPetrified : SpellEffect {

    private NPC npc;


    public override void ApplyEffect()
    {
        base.ApplyEffect();
        npc = this.GetComponent<NPC>();
        TickTime = 1;//Realtime counter
        npc.npc_goal = (short)NPC.npc_goals.npc_goal_petrified;
        npc.npc_gtarg = counter;
        npc.newAnim.FreezeAnimFrame = true;
        npc.newAnim.output.color = Color.gray;
    }

    public override void EffectOverTime()
    {
        base.EffectOverTime();
        npc.npc_gtarg = counter;
    }

    public override void CancelEffect()
    {
        npc.npc_goal = (short)NPC.npc_goals.npc_goal_attack_5;
        npc.npc_gtarg = 0;
        npc.newAnim.FreezeAnimFrame = false;
        npc.newAnim.output.color = Color.white;
        base.CancelEffect();
    }

}

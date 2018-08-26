using UnityEngine;
using System.Collections;

/// <summary>
/// A hack trap castle npcs.
/// </summary>
/// Teleports npcs to their home positions after talking to british at the start of the game.
public class a_hack_trap_castle_npcs : a_hack_trap
{
    /// <summary>
    /// Britannia NPC who am i values
    /// </summary>
    public enum BritanniaNPCS
    {
        MaleGuard = 129,
        Nystrul = 130,
        Charles = 131,
        Dupre = 132,
        Geoffrey = 133,
        Iolo = 134,
        Julia = 135,
        Miranda = 136,
        Nanna = 137,
        Nell = 138,
        Nelson = 139,
        Patterson = 140,
        Tory = 141,
        LordBritish = 142,
        Feridwyn = 143,
        FemaleGuard = 149,        
        Syria = 168
    };
    //Seems to move npcs to different locations.
    //Possibly used to implement npc schedules?
    //Nystrul 130@254
    //Geoffrey 133@250
    //miranda 136@249
    //Nelson 139 @236
    //Tory 141 @244
    //LB 142@235
    //Dupre 132@252
    //iolo 134@253
    //syria 168@255
    //nell 138@216
    //charles 131@228
    //patterson 140@232
    //nanna 137@245
    //Julia 135@251
    //feridwyn 143@246

    public override void ExecuteTrap(object_base src, int triggerX, int triggerY, int State)
    {
        switch(Quest.instance.x_clocks[0])
        {
            case 0:
                EventsAtXClock0();
                break;
            default:
                Debug.Log("what happens now???");
                break;
        }
    }
    
    void EventsAtXClock0()
    {
        //Play Cutscene for Guardian taunt.
        //This is probably called by some other means in vanilla but it is convenient to do so here.
        Cutscene_TauntBritish cs = UWHUD.instance.gameObject.AddComponent<Cutscene_TauntBritish>();
        UWHUD.instance.CutScenesFull.cs = cs;
        UWHUD.instance.CutScenesFull.Begin();

        //Move NPCS at Xclock 0
        //Debug.Log("Moving everyone Xclock is " + Quest.instance.x_clocks[1]);
        NPC.SetNPCLocation(getNPC(BritanniaNPCS.Nell), 43, 49, NPC.npc_goals.npc_goal_wander_2);
        NPC.SetNPCLocation(227, 42, 35, NPC.npc_goals.npc_goal_wander_2);//a guard
        NPC.SetNPCLocation(getNPC(BritanniaNPCS.Charles), 36, 51, NPC.npc_goals.npc_goal_wander_2);
        NPC.SetNPCLocation(230, 29, 36, NPC.npc_goals.npc_goal_wander_2);//another guard
        NPC.SetNPCLocation(231, 30, 52, NPC.npc_goals.npc_goal_goto_1);//another guard next to lb
        NPC.SetNPCLocation(getNPC(BritanniaNPCS.Patterson), 21, 34, NPC.npc_goals.npc_goal_goto_1);
        NPC.SetNPCLocation(233, 34, 35, NPC.npc_goals.npc_goal_wander_2);//another guard
        NPC.SetNPCLocation(getNPC(BritanniaNPCS.LordBritish), 31, 52, NPC.npc_goals.npc_goal_goto_1);
        NPC.SetNPCLocation(getNPC(BritanniaNPCS.Nelson), 22, 37, NPC.npc_goals.npc_goal_wander_2);
        NPC.SetNPCLocation(getNPC(BritanniaNPCS.Tory), 24, 39, NPC.npc_goals.npc_goal_wander_2);
        NPC.SetNPCLocation(getNPC(BritanniaNPCS.Nanna), 44, 48, NPC.npc_goals.npc_goal_wander_2);
        NPC.SetNPCLocation(getNPC(BritanniaNPCS.Feridwyn), 25, 34, NPC.npc_goals.npc_goal_wander_2);
        NPC.SetNPCLocation(248, 33, 52, NPC.npc_goals.npc_goal_goto_1);//another guard next to lb
        NPC.SetNPCLocation(getNPC(BritanniaNPCS.Miranda), 27, 36, NPC.npc_goals.npc_goal_goto_1);
        NPC.SetNPCLocation(getNPC(BritanniaNPCS.Geoffrey), 37, 35, NPC.npc_goals.npc_goal_wander_2);
        NPC.SetNPCLocation(getNPC(BritanniaNPCS.Julia), 25, 43, NPC.npc_goals.npc_goal_wander_2);
        NPC.SetNPCLocation(getNPC(BritanniaNPCS.Dupre), 21, 42, NPC.npc_goals.npc_goal_wander_2);
        NPC.SetNPCLocation(getNPC(BritanniaNPCS.Iolo), 22, 51, NPC.npc_goals.npc_goal_wander_2);
        NPC.SetNPCLocation(getNPC(BritanniaNPCS.Nystrul), 42, 43, NPC.npc_goals.npc_goal_goto_1);//nyst
        NPC.SetNPCLocation(getNPC(BritanniaNPCS.Syria), 42, 36, NPC.npc_goals.npc_goal_wander_2);
    }

    /// <summary>
    /// Finds the first instance of the specified NPC by whoami
    /// </summary>
    /// <param name="who"></param>
    /// <returns></returns>
    static int getNPC(BritanniaNPCS who)
    {
        return NPC.findNpcByWhoAmI((int)who);
    }

    public static void MakeEveryoneFriendly()
    {
        NPC.SetNPCAttitudeGoal(getNPC(BritanniaNPCS.Nell), NPC.npc_goals.npc_goal_wander_2,NPC.AI_ATTITUDE_FRIENDLY);
       // NPC.SetNPCLocation(227, 42, 35, NPC.npc_goals.npc_goal_wander_2);//a guard
        NPC.SetNPCAttitudeGoal(getNPC(BritanniaNPCS.Charles),  NPC.npc_goals.npc_goal_wander_2, NPC.AI_ATTITUDE_FRIENDLY);
        //NPC.SetNPCLocation(230, 29, 36, NPC.npc_goals.npc_goal_wander_2);//another guard
        // NPC.SetNPCLocation(231, 30, 52, NPC.npc_goals.npc_goal_goto_1);//another guard next to lb
        NPC.SetNPCAttitudeGoal(getNPC(BritanniaNPCS.Patterson),  NPC.npc_goals.npc_goal_goto_1, NPC.AI_ATTITUDE_FRIENDLY);
        // NPC.SetNPCLocation(233, 34, 35, NPC.npc_goals.npc_goal_wander_2);//another guard
        NPC.SetNPCAttitudeGoal(getNPC(BritanniaNPCS.LordBritish),  NPC.npc_goals.npc_goal_goto_1, NPC.AI_ATTITUDE_FRIENDLY);
        NPC.SetNPCAttitudeGoal(getNPC(BritanniaNPCS.Nelson), NPC.npc_goals.npc_goal_wander_2, NPC.AI_ATTITUDE_FRIENDLY);
        NPC.SetNPCAttitudeGoal(getNPC(BritanniaNPCS.Tory),  NPC.npc_goals.npc_goal_wander_2, NPC.AI_ATTITUDE_FRIENDLY);
        NPC.SetNPCAttitudeGoal(getNPC(BritanniaNPCS.Nanna), NPC.npc_goals.npc_goal_wander_2, NPC.AI_ATTITUDE_FRIENDLY);
        NPC.SetNPCAttitudeGoal(getNPC(BritanniaNPCS.Feridwyn), NPC.npc_goals.npc_goal_wander_2, NPC.AI_ATTITUDE_FRIENDLY);
        //NPC.SetNPCLocation(248, 33, 52, NPC.npc_goals.npc_goal_goto_1);//another guard next to lb
        NPC.SetNPCAttitudeGoal(getNPC(BritanniaNPCS.Miranda), NPC.npc_goals.npc_goal_goto_1, NPC.AI_ATTITUDE_FRIENDLY);
        NPC.SetNPCAttitudeGoal(getNPC(BritanniaNPCS.Geoffrey),  NPC.npc_goals.npc_goal_wander_2, NPC.AI_ATTITUDE_FRIENDLY);
        NPC.SetNPCAttitudeGoal(getNPC(BritanniaNPCS.Julia),  NPC.npc_goals.npc_goal_wander_2, NPC.AI_ATTITUDE_FRIENDLY);
        NPC.SetNPCAttitudeGoal(getNPC(BritanniaNPCS.Dupre),  NPC.npc_goals.npc_goal_wander_2, NPC.AI_ATTITUDE_FRIENDLY);
        NPC.SetNPCAttitudeGoal(getNPC(BritanniaNPCS.Iolo),  NPC.npc_goals.npc_goal_wander_2, NPC.AI_ATTITUDE_FRIENDLY);
        NPC.SetNPCAttitudeGoal(getNPC(BritanniaNPCS.Nystrul),  NPC.npc_goals.npc_goal_goto_1, NPC.AI_ATTITUDE_FRIENDLY);
        NPC.SetNPCAttitudeGoal(getNPC(BritanniaNPCS.Syria), NPC.npc_goals.npc_goal_wander_2, NPC.AI_ATTITUDE_FRIENDLY);

        NPC.SetNPCAttitudeGoal(getNPC(BritanniaNPCS.FemaleGuard), NPC.npc_goals.npc_goal_wander_2, NPC.AI_ATTITUDE_FRIENDLY);
        NPC.SetNPCAttitudeGoal(getNPC(BritanniaNPCS.MaleGuard),  NPC.npc_goals.npc_goal_wander_2, NPC.AI_ATTITUDE_FRIENDLY);

    }

}

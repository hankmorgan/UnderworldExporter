using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Changes the goal of a type of npc
/// </summary>
/// zpos seems to be the controlling param here for what npcs are affected. Matches against WhoAmI
/// Owner is the attitude to change to
public class a_hack_trap_change_goal : a_hack_trap {

    public override void ExecuteTrap(object_base src, int triggerX, int triggerY, int State)
    {
        NPC[] foundNPCs = GameWorldController.instance.DynamicObjectMarker().GetComponentsInChildren<NPC>();
        for (int i = 0; i < foundNPCs.GetUpperBound(0); i++)
        {            
            if (foundNPCs[i].npc_whoami == objInt().zpos)
            {
                foundNPCs[i].npc_goal= (short)objInt().owner;
            }
        }
    }

}

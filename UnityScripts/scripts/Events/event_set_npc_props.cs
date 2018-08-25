using UnityEngine;
using System.Collections;

public class event_set_npc_props : event_base
{

    //Set some various properties for Npcs around their position and goal


    public override void ExecuteEvent()
    {
        base.ExecuteEvent();
        int whoAmI = RawData[5];
        int newGoal = RawData[3];
        int homeX = 0; int homeY = 0;
        NPC[] npc;
        if (whoAmI == 0)
        {
            //WhoAmI is in a different offset and this needs to process differently
            whoAmI = RawData[7];
            npc = findNPC(whoAmI);
            homeX = RawData[8];
            homeY = RawData[9];
        }
        else
        {
            npc = findNPC(whoAmI);
            homeX = RawData[6];
            homeY = RawData[7];
        }
        if (npc != null)
        {

            Vector3 pos = CurrentTileMap().getTileVector(homeX, homeY);
            for (int i = 0; i <= npc.GetUpperBound(0); i++)
            {
                npc[i].transform.position = pos;
                npc[i].npc_xhome = (short)homeX;
                npc[i].npc_yhome = (short)homeY;
                npc[i].npc_goal = (short)newGoal;
            }
        }
    }

    public override string EventName()
    {
        return "set_npc_props";
    }

    public override string summary()
    {
        if (RawData[5] == 0)
        {
            return base.summary() + "\n\t\tWhoAmI=" + (int)RawData[7] + ",Goal=" + (int)RawData[3] + ",HomeX=" + (int)RawData[8] + ",HomeY=" + (int)RawData[9];
        }
        else
        {
            return base.summary() + "\n\t\tWhoAmI=" + (int)RawData[5] + ",Goal=" + (int)RawData[3] + ",HomeX=" + (int)RawData[6] + ",HomeY=" + (int)RawData[7];
        }
    }
}

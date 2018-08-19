using UnityEngine;
using System.Collections;

/// <summary>
/// Trigger that fires when a door is open
/// </summary>
public class an_open_trigger : trigger_base
{
    public override bool Activate(GameObject src)
    {
        //int thisType=objInt().GetItemType();
        GameObject triggerObj = ObjectLoader.getGameObjectAt(link);
        if (triggerObj != null)
        {
            if (triggerObj.GetComponent<trap_base>() != null)
            {
                triggerObj.GetComponent<trap_base>().Activate(this, quality, owner, flags);
            }
        }

        //Open/Close trigers may have additional triggers that fire off as well
        if (ObjectLoader.GetItemTypeAt(next) != ObjectInteraction.A_CLOSE_TRIGGER)
        {
            triggerObj = ObjectLoader.getGameObjectAt(next);
            if (triggerObj != null)
            {
                if (triggerObj.GetComponent<trigger_base>() != null)
                {
                    triggerObj.GetComponent<trigger_base>().Activate(this.gameObject);
                }
            }
        }

        PostActivate(src);
        return true;
    }

    public override void PostActivate(GameObject src)
    {
        Debug.Log("Overridden PostActivate to test " + this.name);
        base.PostActivate(src);
    }
}
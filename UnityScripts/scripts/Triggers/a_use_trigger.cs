using UnityEngine;
using System.Collections;

public class a_use_trigger : trigger_base
{

    /*
     A trigger that is fired when the player uses something eg switches
     */

    public bool Activate(GameObject src, bool mode)
    {
        //Debug.Log (this.name);
        GameObject triggerObj = null;
        if (mode)
        {
            triggerObj = ObjectLoader.getGameObjectAt(link);
        }
        else
        {
            if (next != 0)
            {
                triggerObj = ObjectLoader.getGameObjectAt((int)next);
            }
            else
            {
                triggerObj = ObjectLoader.getGameObjectAt(link);
            }
        }

        if (triggerObj != null)
        {
            if (triggerObj.GetComponent<trap_base>() != null)
            {
                triggerObj.GetComponent<trap_base>().Activate(this, quality, owner, flags);
            }
            if (triggerObj.GetComponent<trigger_base>() != null)
            {
                triggerObj.GetComponent<trigger_base>().Activate(this.gameObject);
            }
        }

        PostActivate(src);
        return true;
    }
}

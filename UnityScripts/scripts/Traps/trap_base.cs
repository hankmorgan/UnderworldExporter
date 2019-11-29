using UnityEngine;
using System.Collections;

public class trap_base : traptrigger_base
{

    public bool ExecuteNow;
    //public string TriggerObject;//Next in the chain

    public virtual void ExecuteTrap(object_base src, int triggerX, int triggerY, int State)
    {
        //Do whatever
        Debug.Log("Base Execute Trap " + this.name);
    }

    /// <summary>
    /// Executes the trap chain
    /// </summary>
    /// <param name="src"></param>
    /// <param name="triggerX"></param>
    /// <param name="triggerY"></param>
    /// <param name="State"></param>
    /// <returns></returns>
	public virtual bool Activate(object_base src, int triggerX, int triggerY, int State)
    {
        //Do what it needs to do.
        ExecuteTrap(src, triggerX, triggerY, State);

        //Trigger the next in the chain
        TriggerNext(triggerX, triggerY, State);

        //Stuff to happen after the trap has fired.
        PostActivate(src);
        return true;
    }

    /// <summary>
    /// Find the next trigger to execute and fire it.
    /// </summary>
    /// <param name="triggerX"></param>
    /// <param name="triggerY"></param>
    /// <param name="State"></param>
	public virtual void TriggerNext(int triggerX, int triggerY, int State)
    {
        if (link == 0) { return; }
        GameObject triggerObj = ObjectLoader.getGameObjectAt(link); // GameObject.Find (TriggerObject);
        if (triggerObj != null)
        {
            trigger_base trig = triggerObj.GetComponent<trigger_base>();
            if (trig != null)
            {
                trig.Activate(this.gameObject);
            }
            else
            {
                //try and find a trap instead
                trap_base trap = triggerObj.GetComponent<trap_base>();
                if (trap != null)
                {
                    trap.Activate(this, triggerX, triggerY, State);
                }
                else
                {
                    //Debug.Log ("no trigger or trap found on this object " + triggerObj);					
                    //return false;
                }
            }
        }
    }

    /// <summary>
    /// The first bit of the trap flags seems to control if it repeats
    /// </summary>
    /// <returns></returns>
    public override bool WillFireRepeatedly()
    {
        return (flags & 0x1) == 1;
    }

    /// <summary>
    /// Traps will always fire
    /// </summary>
    /// <returns></returns>
    public override bool WillFire()
    {
        return true;
    }

    public virtual void PostActivate(object_base src)
    {
        //Destruction of traps is probably controlled by the trigger.
        //int TriggerRepeat = (flags>>1) & 0x1;
        //int TriggerRepeat = (flags) & 0x1;
        if (!WillFireRepeatedly())
        {
            DestroyTrap(src);
        }
    }

    protected void DestroyTrap(object_base src)
    {
        if (src != null)
        {
            if (src.GetComponent<ObjectInteraction>() != null)
            {
                //Clear the link to the trigger/trap from the source if it is destroyed.
                if (src.GetComponent<ObjectInteraction>().link == this.gameObject.GetComponent<ObjectInteraction>().objectloaderinfo.index)
                {
                    src.GetComponent<ObjectInteraction>().link = 0;
                }
            }
        }
        objInt().objectloaderinfo.InUseFlag = 0;
        Debug.Log("Destroying Trap: " + this.name);
        Destroy(this.gameObject);
    }

    /// <summary>
    /// Finds the trap of the specified type in chain of execution
    /// </summary>
    /// <returns><c>true</c>, if trap in chain was found, <c>false</c> otherwise.</returns>
    /// <param name="link">Link.</param>
    /// <param name="TrapType">Trap type.</param>
    public virtual bool FindTrapInChain(int link, int TrapType)
    {
        if (link != 0)
        {
            ObjectInteraction objLink = CurrentObjectList().objInfo[link].instance;
            if (objLink != null)
            {
                if (objLink.GetItemType() == ObjectInteraction.A_DELETE_OBJECT_TRAP)
                {
                    return (TrapType == ObjectInteraction.A_DELETE_OBJECT_TRAP);
                }
                if (objLink.GetItemType() == TrapType)
                {
                    return true;
                }
                else
                {
                    return FindTrapInChain(objLink.link, TrapType);
                }
            }
        }
        return false;
    }


    public override void Update()
    {
        if (ExecuteNow)
        {
            ExecuteNow = false;
            ExecuteTrap(this, 0, 0, 0);
        }
    }

    protected virtual void OnDrawGizmos()
    {
        Gizmos.color = Color.green;

        if (link != 0)
        {
            GameObject target = ObjectLoader.getGameObjectAt(link);
            if (target != null)
            {
                Gizmos.DrawLine(transform.position, target.transform.position);
            }
        }
    }


}
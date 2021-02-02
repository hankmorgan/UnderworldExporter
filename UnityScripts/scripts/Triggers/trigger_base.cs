using UnityEngine;
using System.Collections;

public class trigger_base : traptrigger_base {

	/// <summary>
	/// The trigger me now. Fire off the trigger to test it's operation.
	/// </summary>
	public bool TriggerMeNow=false;

	protected override void Start ()
	{
		base.Start ();
		this.gameObject.layer=LayerMask.NameToLayer("Ignore Raycast");
	}

	public override bool Activate (GameObject src)
	{
		GameObject triggerObj = ObjectLoader.getGameObjectAt(link);
		if (triggerObj!=null)
		{
            if (WillFire())
            {
                if (triggerObj.GetComponent<trap_base>() != null)
                {
                    triggerObj.GetComponent<trap_base>().Activate(this, quality, owner, flags);
                }
            }
            else
            {
                Debug.Log(this.name + " will not trigger due to flag.");
            }
		}
		PostActivate(src);
		return true;
	}

	public virtual void PostActivate(GameObject src)
	{
		//int TriggerRepeat = (flags>>1) & 0x1;

        if ( !WillFireRepeatedly() )
		{
			if (src!=null)
			{
				if (src.GetComponent<ObjectInteraction>()!=null)
				{//Clear the link to the trigger/trap from the source if it is destroyed.
					if (src.GetComponent<ObjectInteraction>().link == this.gameObject.GetComponent<ObjectInteraction>().BaseObjectData.index)
					{
						src.GetComponent<ObjectInteraction>().link=0;
					}
				}	
			}
			objInt().BaseObjectData.InUseFlag=0;
			Destroy (this.gameObject);
		}
	}

	public override void Update() 
	{
		if(TriggerMeNow)
		{
			TriggerMeNow=false;
			Activate(this.gameObject);
		}
	}

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

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


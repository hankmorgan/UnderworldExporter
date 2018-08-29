using UnityEngine;
using System.Collections;

public class a_timer_trigger : trigger_base {
		//The zpos value appears to control it's rate of triggering.
		float traptime=0f;
		float interval=1f;

	protected override void Start ()
	{
		base.Start();
		if (zpos!=0)
		{
			interval=(float)zpos;
		}
		else
		{
			interval=1;
		}
	}

	public override void Update ()
	{
		if (GameWorldController.instance.EnableTimerTriggers)
		{
			base.Update ();
			traptime+=Time.deltaTime;
			if(traptime> interval * GameWorldController.instance.TimerRate)
			{
				Activate(this.gameObject);
				traptime=0f;
			}			
		}	
		else
		{
			if (TriggerMeNow)
			{
					base.Update();
			}
		}
	}



		//Override to supress debug messages.
	public override bool Activate (GameObject src)
	{
		if (EditorMode)
		{
			return true;
		}
		GameObject triggerObj = ObjectLoader.getGameObjectAt(link);
		if (triggerObj!=null)
		{
            if (triggerObj.GetComponent<trap_base>()!=null)
            {
                triggerObj.GetComponent<trap_base>().Activate(this, quality, owner, flags);
            }
            else
            {
                Debug.Log("null trap on " + this.name);
            }
			
		}

		PostActivate(src);
		return true;
	}

		//DO not destroy
		//public virtual void PostActivate()
		//{
		//}
}

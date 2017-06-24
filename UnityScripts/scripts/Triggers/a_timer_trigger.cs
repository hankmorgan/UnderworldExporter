using UnityEngine;
using System.Collections;

public class a_timer_trigger : trigger_base {
		//The zpos value appears to control it's rate of triggering.
		float traptime=0f;


	public override void Update ()
	{
		base.Update ();
		traptime+=Time.deltaTime;
		if(traptime> (float)objInt().zpos * 0.3f)
		{
				Activate();
				traptime=0f;
		}		
	}



		//Override to supress debug messages.
	public override bool Activate ()
	{
				if (EditorMode)
				{
					return true;
				}
		GameObject triggerObj = ObjectLoader.getGameObjectAt(objInt().link);
		if (triggerObj!=null)
		{
			triggerObj.GetComponent<trap_base>().Activate (this, objInt().quality,objInt().owner,objInt().flags);
		}

		PostActivate();
		return true;
	}

		//DO not destroy
		//public virtual void PostActivate()
		//{
		//}
}

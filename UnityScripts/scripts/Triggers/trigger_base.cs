using UnityEngine;
using System.Collections;

public class trigger_base : object_base {

	public string TrapObject;//The next trap to activte
	public int state;


	public override bool Activate ()
	{
		Debug.Log (this.name);
	//public overrideal bool Activate()
		//Do what it needs to do.
		//state=state;
		//Trigger the next in the chain
		GameObject triggerObj= GameObject.Find (TrapObject);
		if (triggerObj!=null)
		{
			triggerObj.GetComponent<trap_base>().Activate (objInt().Quality,objInt().Owner,state);
			if (state == 8)
			{
				state = 0;
			}
			else
			{
				state++;
			}
		}

		PostActivate();
		return true;
	}

	public virtual void PostActivate()
	{
		int TriggerRepeat = (objInt().flags>>1) & 0x1;
		//Debug.Log(TriggerRepeat);
		if (TriggerRepeat==0)
		{
			Destroy (this.gameObject);
		}

	}

}


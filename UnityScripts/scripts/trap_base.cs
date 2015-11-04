using UnityEngine;
using System.Collections;

public class trap_base : object_base {


	public string TriggerObject;//Next in the chain

	public virtual void ExecuteTrap(int triggerX, int triggerY, int State)
	{
		//Do whatever
		Debug.Log ("ExecuteTrap " + this.name);
	}



	public virtual bool Activate(int triggerX, int triggerY, int State)
	{
		
		//Do what it needs to do.
		ExecuteTrap(triggerX,triggerY, State);

		//Trigger the next in the chain
		GameObject triggerObj= GameObject.Find (TriggerObject);
		if (triggerObj!=null)
		{
			triggerObj.GetComponent<trigger_base>().Activate ();
		}

		return true;
	}
}

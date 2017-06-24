using UnityEngine;
using System.Collections;

public class trap_base : object_base {


	//public string TriggerObject;//Next in the chain

	public virtual void ExecuteTrap(object_base src, int triggerX, int triggerY, int State)
	{
		//Do whatever
		//Debug.Log ("Base Execute Trap " + this.name);
	}



	public virtual bool Activate(object_base src, int triggerX, int triggerY, int State)
	{	//triggerX aka quality, triggerY aka owner
		//CheckReferences();
		//Debug.Log (this.name);
		//Do what it needs to do.
		ExecuteTrap(src, triggerX,triggerY, State);

		//Trigger the next in the chain
		TriggerNext (triggerX, triggerY, State);

		//Stuff to happen after the trap has fired.
		PostActivate();
		return true;
	}

	public virtual void TriggerNext(int triggerX, int triggerY, int State)
	{
		if(objInt().link==0){return;}
		GameObject triggerObj= ObjectLoader.getGameObjectAt(objInt().link); // GameObject.Find (TriggerObject);
		if (triggerObj!=null)
		{
			trigger_base trig= triggerObj.GetComponent<trigger_base>();
			if (trig!=null)
			{
				trig.Activate();
			}
			else
			{
				//try and find a trap instead
				trap_base trap = triggerObj.GetComponent<trap_base>();
				if (trap!=null)
				{
					trap.Activate(this, triggerX,triggerY,State);
					//return true;
				}
				else
				{
					Debug.Log ("no trigger or trap found on this object");
					//return false;
				}
			}
		}
	}

	public virtual void PostActivate()
	{
		//Destruction of traps is probably controlled by the trigger.
		int TriggerRepeat = (objInt().flags>>1) & 0x1;
		if (TriggerRepeat==0)
		{
			this.GetComponent<ObjectInteraction>().objectloaderinfo.InUseFlag=0;
			Destroy (this.gameObject);
		}
	}
}

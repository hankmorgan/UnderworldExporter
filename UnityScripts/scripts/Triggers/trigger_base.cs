using UnityEngine;
using System.Collections;

public class trigger_base : object_base {

	//public string TrapObject;//The next trap to activte
	//public int state;

	protected override void Start ()
	{
		base.Start ();
		this.gameObject.layer=LayerMask.NameToLayer("Ignore Raycast");
	}

	public override bool Activate ()
	{
		Debug.Log (this.name);
	//public overrideal bool Activate()
		//Do what it needs to do.
		//state=state;
		//Trigger the next in the chain
		//GameObject triggerObj= GameObject.Find (TrapObject);
		GameObject triggerObj = ObjectLoader.getGameObjectAt(objInt().link);
		if (triggerObj!=null)
		{
			triggerObj.GetComponent<trap_base>().Activate (objInt().Quality,objInt().Owner,objInt().flags);
			/*if (objInt().flags == 8)
			{
				objInt().flags = 0;
			}
			else
			{
				objInt().flags++;
			}*/
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


using UnityEngine;
using System.Collections;

public class a_create_object_trap : trap_base {
	//0187  a_create object trap
	//	creates a new object using the object referenced by the "quantity"
	//		field as a template. the object is created only when a random number
	//		between 0 and 3f is greater than the "quality" field value.

	private bool TrapFired=false;

	public override void ExecuteTrap (int triggerX, int triggerY, int State)
	{
		if (objInt.Quality <= Random.Range(0,41)) //100% chance when quality is zero.
		{
			GameObject objToClone = GameObject.Find (TriggerObject);
			if (objToClone !=null)
			{
				GameObject cloneObj = Instantiate(objToClone);
				cloneObj.transform.position = this.gameObject.transform.position;
				TrapFired=true;
			}
		}
	}

	public override bool Activate (int triggerX, int triggerY, int State)
	{
		//Do what it needs to do.
		ExecuteTrap(triggerX,triggerY, State);

		//It's link is the object it is creating so no activation.
		PostActivate();
		return true;

	}

}

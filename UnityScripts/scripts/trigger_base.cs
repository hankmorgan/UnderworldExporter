using UnityEngine;
using System.Collections;

public class trigger_base : object_base {

	public string TrapObject;//The next trap to activte
	public int state;


	public override bool Activate ()
	{
	//public overrideal bool Activate()
		//Do what it needs to do.
		//state=state;
		//Trigger the next in the chain
		GameObject triggerObj= GameObject.Find (TrapObject);
		if (triggerObj!=null)
		{
			triggerObj.GetComponent<trap_base>().Activate (objInt.Quality,objInt.Owner,state);
			if (state == 8)
			{
				state = 0;
			}
			else
			{
				state++;
			}
		}
		
		return true;
	}

}


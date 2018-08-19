using UnityEngine;
using System.Collections;

public class a_hack_trap_visibility : a_hack_trap {

	//Makes the linked object to this visible.
	public override void ExecuteTrap (object_base src, int triggerX, int triggerY, int State)
	{
		ObjectInteraction obj = ObjectLoader.getObjectIntAt(link);
		if (obj!=null)
		{
			obj.setInvis(0);//make visible.
		}
	}

}

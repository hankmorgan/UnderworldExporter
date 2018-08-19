using UnityEngine;
using System.Collections;

public class a_hack_trap_unlink : a_hack_trap {
	//Removes the link on the target object.
	public override void ExecuteTrap (object_base src, int triggerX, int triggerY, int State)
	{
		ObjectInteraction objToUnlink = ObjectLoader.getObjectIntAt(link);
		if (objToUnlink!=null)
		{
			objToUnlink.link=0;
		}
	}

	public override bool Activate (object_base src,int triggerX, int triggerY, int State)
	{
		//Do what it needs to do.
		ExecuteTrap(this, triggerX,triggerY, State);

		//Unlink traps are always the end of the line so no more activations.

		PostActivate(src);
		return true;
	}

}

using UnityEngine;
using System.Collections;

public class a_delete_object_trap : trap_base {
	
	public override bool Activate (int triggerX, int triggerY, int State)
	{
		//Do what it needs to do.
		ExecuteTrap(triggerX,triggerY, State);

		//Delete object traps are always the end of the line

		PostActivate();
		return true;
	}
}

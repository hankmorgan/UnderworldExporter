using UnityEngine;
using System.Collections;

/// <summary>
/// Makes the linked object to this visible.
/// </summary>
public class a_hack_trap_visibility : a_hack_trap
{    	
	public override void ExecuteTrap (object_base src, int triggerX, int triggerY, int State)
	{
		ObjectInteraction obj = ObjectLoader.getObjectIntAt(link);
		if (obj!=null)
		{
			obj.setInvis(0);//make visible.
		}
	}
}

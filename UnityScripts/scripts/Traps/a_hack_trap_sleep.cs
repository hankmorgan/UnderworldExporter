using UnityEngine;
using System.Collections;

public class a_hack_trap_sleep : a_hack_trap{
    
	public override void ExecuteTrap (object_base src, int triggerX, int triggerY, int State)
	{
		UWCharacter.Instance.Sleep();
	}
}

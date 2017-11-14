using UnityEngine;
using System.Collections;

public class a_skill_trap : trap_base {


	public override void ExecuteTrap (object_base src, int triggerX, int triggerY, int State)
	{
		Debug.Log(this.name + " called with params q=" + objInt().quality + " o=" + objInt().owner);
		base.ExecuteTrap (src, triggerX, triggerY, State);
	}

}

using UnityEngine;
using System.Collections;

public class a_hack_trap_trespass : a_hack_trap {
		//A trap that angers nearby npcs if you enter it.


	public override void ExecuteTrap (object_base src, int triggerX, int triggerY, int State)
	{
		Debug.Log("A trespass trap " + objInt().owner + " "  + this.name );
		if (((objInt().owner & 0x1f))!=0)
		{
			SignalTheft(UWCharacter.Instance.transform.position, objInt().owner,7f);
		}	
	}

}

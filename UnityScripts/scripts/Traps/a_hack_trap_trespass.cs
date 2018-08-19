using UnityEngine;
using System.Collections;

public class a_hack_trap_trespass : a_hack_trap {
	//A trap that angers nearby npcs if you enter it.
	//TODO:The stealth skill should effect this (see skill trap on lvl2 of prison tower)

	public override void ExecuteTrap (object_base src, int triggerX, int triggerY, int State)
	{
		if (((owner & 0x1f))!=0)
		{
			SignalTheft(UWCharacter.Instance.transform.position, owner,7f);
		}	
	}
}

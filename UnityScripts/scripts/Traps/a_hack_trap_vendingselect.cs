using UnityEngine;
using System.Collections;

public class a_hack_trap_vendingselect : a_hack_trap {
	//Changes the variable controlling the vending machine selection

	public override void ExecuteTrap (object_base src, int triggerX, int triggerY, int State)
	{
		Quest.instance.variables[owner]++;
		if (Quest.instance.variables[owner]>=8)
		{
			Quest.instance.variables[owner]=0;
		}
	}

	public override void PostActivate (object_base src)
	{

	}
}

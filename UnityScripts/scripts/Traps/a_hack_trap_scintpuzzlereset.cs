using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Resets the variable for the switches on scintillus level 5.
/// </summary>
public class a_hack_trap_scintpuzzlereset : a_hack_trap {

	public override void ExecuteTrap (object_base src, int triggerX, int triggerY, int State)
	{
		Quest.instance.ScintLvl5Switches=0;
	}

	public override void PostActivate (object_base src)
	{
        //do not destroy
        Debug.Log("Overridden PostActivate to test " + this.name);
        base.PostActivate(src);
    }
}

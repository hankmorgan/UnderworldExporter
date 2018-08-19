using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Toggles a row of bridges of size quality x ?
/// Starts at trigger x and y
///  
/// Owner appears to be used (possibly to control direction? and other dimension?)
/// </summary>
public class a_bridge_trap : trap_base {

    public override void ExecuteTrap(object_base src, int triggerX, int triggerY, int State)
    {
        Debug.Log(this.name + " at " + triggerX + "," + triggerY);
    }

}

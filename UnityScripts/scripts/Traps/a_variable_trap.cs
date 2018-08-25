using UnityEngine;
using System.Collections;

public class a_variable_trap : trap_base
{
    public int value;
    //   field   bits in value
    //  ypos    0..2
    //   owner   3..7     (bit 5 of "owner" seems not to be used)
    //    quality 8..13

    //public int VariableIndex;
    //public int VariableIndex;	//currObj.zpos
    //public int VariableValue;	//((currObj.owner & 0x7) <<3) | (currObj.y )) or maybe 
    //public int heading;

    protected override void Start()
    {
        base.Start();
        value = VariableValue();
    }


    /*public override void PostActivate (object_base src)
	{
		int TriggerRepeat = (flags>>1) & 0x1;
		if (TriggerRepeat==1)
		{
				DestroyTrap (src);
		}
	}*/

    /// <summary>
    /// Works out the variable the trap uses to set or check against.
    /// </summary>
    /// <returns>The value.</returns>
    public virtual int VariableValue()
    {
        return ((quality & 0x3f) << 8) | (((owner & 0x1f) << 3) | (ypos & 0x7));
    }
}
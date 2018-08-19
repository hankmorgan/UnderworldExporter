using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class traptrigger_base : object_base {

    /// <summary>
    /// Will the trigger fire. Usually the third bit of the flags (zero based)
    /// </summary>
    /// <returns></returns>
    public virtual bool WillFire()
    {
        return (((flags >> 2) & 0x1) == 1);
        //return true;
    }

    /// <summary>
    /// The trigger will not delete itself after firing. Usually the  second bit of the flags.
    /// </summary>
    public virtual bool WillFireRepeatedly()
    {
        return ((flags >> 1) & 0x1) == 1;
    }
}

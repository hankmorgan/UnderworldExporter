using UnityEngine;
using System.Collections;

public class a_lock : object_base {
    /*
Not really used by uwexporter but does exist in UW. Created here for compatabilty.
The lock acts as a flag to show that a door is locked
	 */
    public int KeyIndex;//The index of the key that will open this lock.

    protected override void Start()
    {
        base.Start();
        KeyIndex = link & 0x3F;
    }

    //public override void ExecuteTrap (object_base src, int triggerX, int triggerY, int State)
    //{
    //	if ((flags & 0x1) == 1)
    //	{//locked
    //		flags = (short)(flags & 0xE);	
    //	}
    //	else
    //	{
    //		flags = (short)(flags | 0x1);
    //	}
    //}


    //public override void TriggerNext (int triggerX, int triggerY, int State)
    //{

    //}

    //public override void PostActivate (object_base src)
    //{
    //       Debug.Log("Overridden PostActivate to test " + this.name);
    //       base.PostActivate(src);
    //   }


}

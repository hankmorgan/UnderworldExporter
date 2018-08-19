using UnityEngine;
using System.Collections;

public class a_lock : trap_base {
	/*
Not really used by uwexporter but does exist in UW. Created here for compatabilty.
	 */

	public override void ExecuteTrap (object_base src, int triggerX, int triggerY, int State)
	{
		if ((flags & 0x1) == 1)
		{//locked
			flags = (short)(flags & 0xE);	
		}
		else
		{
			flags = (short)(flags | 0x1);
		}
	}


	public override void TriggerNext (int triggerX, int triggerY, int State)
	{
	
	}

	public override void PostActivate (object_base src)
	{
        Debug.Log("Overridden PostActivate to test " + this.name);
        base.PostActivate(src);
    }
}

using UnityEngine;
using System.Collections;

public class an_enter_trigger : a_move_trigger {

	protected override void Start ()
	{
		boxDimensions= new Vector3(1.2f,16f,1.2f);
		base.Start ();
        playerStartedInTrigger = false;//Enter triggers will ignore that the player started within them. See prison lvl 6 
    }
}

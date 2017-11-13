using UnityEngine;
using System.Collections;

public class an_enter_trigger : a_move_trigger {

	protected override void Start ()
	{
		boxDimensions= new Vector3(1.2f,16f,1.2f);
		base.Start ();
	}
}

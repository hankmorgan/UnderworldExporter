using UnityEngine;
using System.Collections;

public class an_exit_trigger : a_move_trigger {

	protected override void Start ()
	{
		boxDimensions= new Vector3(1.2f,16f,1.2f);
		base.Start ();
	}

	protected override void OnTriggerEnter (Collider other)
	{

	}

	void OnTriggerExit(Collider other)
	{
		base.OnTriggerEnter(other);
	}
}

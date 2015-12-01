using UnityEngine;
using System.Collections;

public class a_move_trigger : trigger_base {
/*
A trigger that fires when the player character enters it
*/

	void OnTriggerEnter(Collider other)
	{

		if ((other.name=="Gronk") || (other.name=="Feet"))
		{
			Activate ();
		}
	}
}

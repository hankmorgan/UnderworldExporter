using UnityEngine;
using System.Collections;

public class a_move_trigger : trigger_base {
/*
A trigger that fires when the player character enters it
*/

	protected override void Start ()
	{
		base.Start ();
		BoxCollider box=this.gameObject.AddComponent<BoxCollider>();
		box.transform.position = this.gameObject.transform.position;
		box.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
		box.isTrigger=true;
	}

	void OnTriggerEnter(Collider other)
	{

	if ((other.name==GameWorldController.instance.playerUW.name) || (other.name=="Feet"))
		{
			Activate ();
		}
	}
}

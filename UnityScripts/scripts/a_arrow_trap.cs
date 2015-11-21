using UnityEngine;
using System.Collections;

public class a_arrow_trap : trap_base {
	/*
	An arrow trap is used to fire projectiles (usually at the player).
	The item type created is controlled by the object quality and owner
	target = (currobj.quality << 5) | currobj.owner; //This is set in UWexporter

	The vector is simply the heading of the trap.

	Examples of usage
	The mine collapse on level2
	The skulls launched at the player on level3 -Troll area.
	*/


	public int item_index;//The object id created.
	public int item_type;//The type of the object created

	public override void ExecuteTrap (int triggerX, int triggerY, int State)
	{
		Debug.Log ("an arrow trap has gone off. It will spawn a " + item_index + " of type " + item_type + " along vector " + this.gameObject.transform.rotation);
	}

}

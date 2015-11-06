using UnityEngine;
using System.Collections;

public class a_arrow_trap : trap_base {


	//Quality and owner appears to control what appears.

	public int item_index;
	public int item_type;

	public override void ExecuteTrap (int triggerX, int triggerY, int State)
	{
		Debug.Log ("an arrow trap has gone off. It will spawn a " + item_index + " of type " + item_type + " along vector " + this.gameObject.transform.rotation);
	}

}

using UnityEngine;
using System.Collections;

public class a_delete_object_trap : trap_base {

	/*
Per Uw-formats.txt
   018b  a_delete object trap
         deletes an object when set off. "owner" and "quality" of the trap
         determines tile the object is to be found, "sp_link" points to the
         object.

Examples of usage
Level 3 removal of TMAP object when searching for the switch leading to the sword hilt.

	 */

	public override bool Activate (object_base src,int triggerX, int triggerY, int State)
	{
		//Do what it needs to do.
		ExecuteTrap(this, triggerX,triggerY, State);

		//Delete object traps are always the end of the line so no more activations.

		PostActivate(src);
		return true;
	}


	public override void ExecuteTrap (object_base src, int triggerX, int triggerY, int State)
	{

		GameObject triggerObj = ObjectLoader.getGameObjectAt(objInt().link); //GameObject.Find (TriggerObject);
		if (triggerObj!=null)
		{
			triggerObj.GetComponent<ObjectInteraction>().objectloaderinfo.InUseFlag=0;
			if (triggerObj.GetComponent<map_object>()!=null)
			{
				Destroy(triggerObj.GetComponent<map_object>().ModelInstance);	
			}
			Debug.Log (this.name + " deleting " + triggerObj.name);
			Destroy(triggerObj);
		}
	}
}

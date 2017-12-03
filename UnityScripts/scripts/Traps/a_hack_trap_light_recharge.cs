using UnityEngine;
using System.Collections;

public class a_hack_trap_light_recharge : a_hack_trap {
	//Recharges light spheres

	public override void ExecuteTrap (object_base src, int triggerX, int triggerY, int State)
	{
		Vector3 ContactArea= new Vector3(0.59f,0.15f,0.59f);
		Collider[] colliders = Physics.OverlapBox(GameWorldController.instance.currentTileMap().getTileVector(triggerX,triggerY), ContactArea);
		for (int i=0; i<=colliders.GetUpperBound(0);i++)
		{
			if (colliders[i].gameObject.GetComponent<ObjectInteraction>()!=null)
			{
				if (
					(colliders[i].gameObject.GetComponent<ObjectInteraction>().item_id==147) ||
					(colliders[i].gameObject.GetComponent<ObjectInteraction>().item_id==151)
					)
				{
					colliders[i].gameObject.GetComponent<ObjectInteraction>().quality=63;	
					Debug.Log("sparkle sparkle");
				}
			}
		}
	}



	public override void PostActivate (object_base src)
	{

	}
}

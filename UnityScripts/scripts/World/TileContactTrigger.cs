using UnityEngine;
using System.Collections;

public class TileContactTrigger : TileContact {

	//public a_pressure_trigger triggerToUse;

				//public int TileXToWatch;
		//public int TileYToWatch;
	//public bool Triggered;
		/*
	protected override void TileContactEvent (ObjectInteraction obj, Vector3 position)
	{
		if (triggerToUse!=null)
		{
			if (obj.GetComponent<Rigidbody>().useGravity)
			{
				if (position==Vector3.zero)
				{
					triggerToUse.ReleaseWeightFrom();
				}
				else
				{
					triggerToUse.PutWeightOn();
					GameWorldController.FreezeMovement(obj.gameObject);
				}	
												
			}
		}		
	}*/

	/*protected virtual void OnCollisionExit(Collision collision)
	{
		if (collision.gameObject.GetComponent<ObjectInteraction>()!=null)
		{
			TileContactEvent(collision.gameObject.GetComponent<ObjectInteraction>(), Vector3.zero);
		}
	}*/

	/*void Update()
	{				
		if ((TileXToWatch==TileMap.visitTileX) && (TileXToWatch==TileMap.visitTileX))
		{
			if (Triggered==false)
			{
				if (triggerToUse!=null)
				{
					//triggerToUse.Activate();				
					Triggered=triggerToUse.PutWeightOn();
				}	
			}
			//Triggered=true;	
		}
		else
		{
			if (Triggered==true)
			{
				//Leaving this tile.	
				triggerToUse.ReleaseWeightFrom();
			}
			Triggered=false;
		}
	}*/

}

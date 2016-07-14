using UnityEngine;
using System.Collections;

public class a_create_object_trap : trap_base {
/*
Per uw-formats.txt
	0187  a_create object trap
	creates a new object using the object referenced by the "quantity"
	field as a template. the object is created only when a random number
	between 0 and 3f is greater than the "quality" field value.
	
Typically the object is stored off map in the room at 99,99 and cloned from there
Examples of usage
Level 1 at the north end of the level near the staircase. Two goblins will spawn when the player steps on the move triggers in that area
*/

	//private bool TrapFired=false;
	public string NavMeshRegion;//Which nav mesh should apply to cloned objects if they are npcs.

	public override void ExecuteTrap (int triggerX, int triggerY, int State)
	{
		if (objInt.Quality <= Random.Range(0,41)) //100% chance when quality is zero.
		{
			GameObject objToClone = GameObject.Find (TriggerObject);
			if (objToClone !=null)
			{
				GameObject cloneObj = Instantiate(objToClone);
				
				if (this.gameObject.transform.position.x>=100.0f)
				{//If the object is off map use the triggerX and Y to calculate a suitable spawning point.
					cloneObj.transform.position = new Vector3( 
					                                          (((float)triggerX) *1.2f + 0.6f), 
																(float)GameWorldController.instance.Tilemap.GetFloorHeight(GameWorldController.instance.LevelNo,triggerX,triggerY)/6.666f,
					                                          (((float)triggerY) *1.2f  + 0.6f) 
					                                          );
				}
				else
				{
					cloneObj.transform.position = this.gameObject.transform.position;
				}

				cloneObj.transform.parent=objToClone.transform.parent;
				if (cloneObj.GetComponent<NPC>()!=null)
				{
					cloneObj.GetComponent<NPC>().NavMeshRegion=NavMeshRegion;
				}
				//TrapFired=true;
			}
		}
	}

	public override bool Activate (int triggerX, int triggerY, int State)
	{
		//Do what it needs to do.
		ExecuteTrap(triggerX,triggerY, State);

		//It's link is the object it is creating so no activation of more traps/triggers
		PostActivate();
		return true;
	}
}

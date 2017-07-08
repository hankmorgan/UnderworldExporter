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
	public string NavMeshRegion;//Which nav mesh should apply to cloned objects if they are npcs. No longer needed here!

	public override void ExecuteTrap (object_base src, int triggerX, int triggerY, int State)
	{
		Debug.Log (this.name);
		if (objInt().quality <= Random.Range(1,41)) //100% chance when quality is zero.
		{
			//GameObject objToClone = GameObject.Find (TriggerObject);
			ObjectInteraction objToClone = ObjectLoader.getObjectIntAt(objInt().link);
			if (objToClone !=null)
			{
			  	GameObject NewObject = CloneObject (objToClone,triggerX,triggerY,true);
				
				if (objToClone.GetComponent<Container>()!=null)
				{//Clone the items on this object
					for (int i=0; i<= objToClone.GetComponent<Container>().MaxCapacity();i++)		
					{
					if (objToClone.GetComponent<Container>().GetItemAt(i)!="")
						{
							GameObject obj = objToClone.GetComponent<Container>().GetGameObjectAt(i);	
							GameObject CloneContainerItem = CloneObject(obj.GetComponent<ObjectInteraction>(),triggerX,triggerY,false);
							NewObject.GetComponent<Container>().items[i] = CloneContainerItem.name;
						}						
					}
				}
			}
		}
	}

	public GameObject CloneObject(ObjectInteraction objToClone, int triggerX, int triggerY, bool MoveItem)
	{
		GameObject cloneObj = Instantiate(objToClone.gameObject);

		ObjectLoaderInfo objI =  ObjectLoader.newObject(objToClone.item_id,objToClone.quality,objToClone.quality, objToClone.link);
		objI.instance= cloneObj.GetComponent<ObjectInteraction>();
		cloneObj.GetComponent<ObjectInteraction>().objectloaderinfo= objI;
		cloneObj.name= ObjectLoader.UniqueObjectName(objI);
		if (MoveItem)
		{
			if (this.gameObject.transform.position.x>=100.0f)
			{//If the object is off map use the triggerX and Y to calculate a suitable spawning point.
				cloneObj.transform.position = new Vector3( 
						(((float)triggerX) *1.2f + 0.6f), 
						(float)GameWorldController.instance.currentTileMap().GetFloorHeight(triggerX,triggerY)/6.666f,
						(((float)triggerY) *1.2f  + 0.6f) 
				);
			}
			else
			{
				cloneObj.transform.position = this.gameObject.transform.position;
			}	
		}

		cloneObj.transform.parent=objToClone.transform.parent;
		if (cloneObj.GetComponent<NPC>()!=null)
		{
			cloneObj.GetComponent<NPC>().NavMeshRegion=NavMeshRegion;
		}	
		return cloneObj;
	}


	public override bool Activate (object_base src,int triggerX, int triggerY, int State)
	{
		//Do what it needs to do.
		ExecuteTrap(this, triggerX,triggerY, State);

		//It's link is the object it is creating so no activation of more traps/triggers
		PostActivate();
		return true;
	}
}

using UnityEngine;
using System.Collections;

public class a_do_trap_emeraldpuzzle : a_hack_trap {

	public bool hasExecuted;

	public override void ExecuteTrap (object_base src, int triggerX, int triggerY, int State)
	{
		Debug.Log (this.name);
		if (hasExecuted==false)
		{
			//Check if 4 emeralds on on top of the plinths.
			if (CheckPlinths())
			{
				CreateRuneStone(253);				
				hasExecuted=true;
			}
		}
	}


	private void CreateRuneStone(int ItemID)
	{
		ObjectLoaderInfo newobjt= ObjectLoader.newWorldObject(ItemID,0,0,1,256);
		GameObject myObj = ObjectInteraction.CreateNewObject(CurrentTileMap(),newobjt,CurrentObjectList().objInfo, GameWorldController.instance.DynamicObjectMarker().gameObject,new Vector3(64.5f,4.0f,24.5f)).gameObject;
		UnFreezeMovement(myObj);
	}


	private bool CheckPlinths()
	{
		if (CheckArea(new Vector3(59.4f,3.9f,27.0f),1.2f,167) ==true)
		{
			if (CheckArea(new Vector3(59.4f,3.9f,17.5f),1.2f,167) ==true)
			{
				if (CheckArea(new Vector3(69.0f,3.9f,17.5f),1.2f,167) ==true)
				{
					if (CheckArea(new Vector3(69.0f,3.9f,27.0f),1.2f,167) ==true)
					{
						return true;	
					}	
				}	
			}
		}
		return false;
	}


	private bool CheckArea(Vector3 centre, float radius, int item_id) 
	{
		Collider[] hitColliders = Physics.OverlapSphere(centre, radius);
		int i = 0;
		while (i < hitColliders.Length) {
			if (hitColliders[i].gameObject.GetComponent<ObjectInteraction>()!=null)
			{
			if (hitColliders[i].gameObject.GetComponent<ObjectInteraction>().item_id==item_id)
			    {
					Debug.Log("found " + hitColliders[i].gameObject.name);
				return true;
				}
			}
			i++;
		}
	return false;
	}

	public override void PostActivate (object_base src)
	{
        //Stop trap from destroying itself.
        Debug.Log("Overridden PostActivate to test " + this.name);
        base.PostActivate(src);
    }
}
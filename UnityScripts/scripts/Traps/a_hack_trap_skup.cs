using UnityEngine;
using System.Collections;

public class a_hack_trap_skup : a_hack_trap {

//Used to spawn the new bliy scup ductosnore

	bool skupSpawned=false;

	public override void ExecuteTrap (object_base src, int triggerX, int triggerY, int State)
	{		
		
				//Test the crystals and delganiser
		if (
				(TestObjectAtTile(59,4,161,2)!=-1)
				&&
				(TestObjectAtTile(57,4,161,6)!=-1)
				&&
				(TestObjectAtTile(58,4,174,-1)!=-1)
		)
		{
			//Once all conditions are met execute the following trap to spawn the  bliy
			ObjectInteraction obj =ObjectLoader.getObjectIntAt(642);
			if (obj!=null)
			{
				if (obj.GetComponent<trigger_base>()!=null)
				{
					skupSpawned=true;
					Quest.instance.QuestVariables[38]=1;
					Quest.instance.QuestVariables[122]=0;
					obj.GetComponent<trigger_base>().Activate(this.gameObject);
					int ObjToDestroy = TestObjectAtTile(59,4,161,2);
					if(ObjToDestroy!=-1)
					{
						ObjectInteraction objToDestroy= ObjectLoader.getObjectIntAt(ObjToDestroy);
						if (objToDestroy!=null)
						{
							objToDestroy.consumeObject();
						}
					}
					ObjToDestroy = TestObjectAtTile(57,4,161,6);
					if(ObjToDestroy!=-1)
					{
						ObjectInteraction objToDestroy= ObjectLoader.getObjectIntAt(ObjToDestroy);
						if (objToDestroy!=null)
						{
							objToDestroy.consumeObject();
						}
					}
				}
			}	
		}
	}


	int TestObjectAtTile(int tileX, int tileY, int ObjectToFind, int QualityToFind)
	{
		Vector3 ContactArea= new Vector3(0.59f,0.15f,0.59f);
		Collider[] colliders = Physics.OverlapBox(CurrentTileMap().getTileVector(tileX,tileY), ContactArea);
		for (int i=0; i<=colliders.GetUpperBound(0);i++)
		{
			if (colliders[i].gameObject.GetComponent<ObjectInteraction>()!=null)
			{
				if (
					(colliders[i].gameObject.GetComponent<ObjectInteraction>().item_id==ObjectToFind) 		
				)
				{
					if (QualityToFind!=-1)
					{
						if (colliders[i].gameObject.GetComponent<ObjectInteraction>().quality==QualityToFind)
						{
								return colliders[i].gameObject.GetComponent<ObjectInteraction>().objectloaderinfo.index;
						}
						else												
						{
								return -1;
						}

					}
					else
					{
						return colliders[i].gameObject.GetComponent<ObjectInteraction>().objectloaderinfo.index;
					}
				}
			}
		}

		return -1;
	}



	public override void PostActivate (object_base src)
	{
		if (skupSpawned)
		{
            Debug.Log("Overridden PostActivate to test " + this.name);
            base.PostActivate(src);
        }
	}
}

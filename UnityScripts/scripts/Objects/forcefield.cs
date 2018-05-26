using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class forcefield : object_base {
	BoxCollider bx;
	
	protected override void Start ()
	{
		base.Start ();
	
		bx = this.gameObject.AddComponent<BoxCollider>();
		bx.size=new Vector3(1.2f,5f,1.2f);
		bx.center= new Vector3(0f,2.5f,0f);
		this.gameObject.layer= LayerMask.NameToLayer("MapMesh");
		//this.gameObject.AddComponent<NavMeshObstacle>();
		

	}


	void Update()
	{
		bx.enabled=true;
		if (_RES==GAME_UW2)
		{
			GameObject objInHands;
			objInHands=UWCharacter.Instance.playerInventory.GetGameObjectAtSlot(4);
			if (objInHands !=null)
			{
				if (objInHands.GetComponent<ObjectInteraction>().item_id == 51)
				{//Fraznium gloves
						bx.enabled = false;	
				}
			}
		}
	}
}

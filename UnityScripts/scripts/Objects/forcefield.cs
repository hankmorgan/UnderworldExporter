using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class forcefield : object_base {
	BoxCollider bx;
	
	protected override void Start ()
	{
		base.Start ();	
		bx = this.gameObject.GetComponent<BoxCollider>();
        if (bx==null)
        {
            bx = this.gameObject.AddComponent<BoxCollider>();
        }
		bx.size=new Vector3(1.2f,5f,1.2f);
        //TODO: Make this fit the level properly
        bx.center= new Vector3(0f,2.5f,0f);
		this.gameObject.layer= LayerMask.NameToLayer("MapMesh");
	}


	public override void Update() 
	{
		bx.enabled=true;
		if (_RES==GAME_UW2)
		{
            ObjectInteraction objInGloveSlot = UWCharacter.Instance.playerInventory.GetObjectIntAtSlot(4);
			if (objInGloveSlot != null)
			{
				if (objInGloveSlot.item_id == 51)
				{//Fraznium gloves
					bx.enabled = false;	
				}
			}
		}
	}
}

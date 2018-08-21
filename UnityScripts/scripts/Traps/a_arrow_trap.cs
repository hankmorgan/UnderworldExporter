using UnityEngine;
using System.Collections;

public class a_arrow_trap : trap_base {
	/*
	An arrow trap is used to fire projectiles (usually at the player).
	The item type created is controlled by the object quality and owner
	target = (currobj.quality << 5) | currobj.owner; //This is set in UWexporter

	The vector is simply the heading of the trap.

	Examples of usage
	The mine collapse on level2
	The skulls launched at the player on level3 -Troll area.
	*/

	public override void ExecuteTrap (object_base src, int triggerX, int triggerY, int State)
	{
		int item_index=  (quality << 5) | owner;

		ObjectLoaderInfo newobjt= ObjectLoader.newObject(item_index,0,0,0,256);
		GameObject myObj = ObjectInteraction.CreateNewObject(CurrentTileMap(),newobjt,CurrentObjectList().objInfo, GameWorldController.instance.DynamicObjectMarker().gameObject, this.transform.position).gameObject;
		if (ObjectTileX == TileMap.ObjectStorageTile)
		{
			Vector3 pos = CurrentTileMap().getTileVector(triggerX,triggerY);
			pos = new Vector3(pos.x,this.transform.position.y,pos.z);
			myObj.transform.position=pos;
		}
		else
		{
			myObj.transform.position = this.transform.position;			
		}
		myObj.transform.rotation = this.transform.rotation;	
		if (myObj.GetComponent<Rigidbody>()==null)
		{
			myObj.AddComponent<Rigidbody>();
		}

		UnFreezeMovement(myObj);
		myObj.GetComponent<Rigidbody>().collisionDetectionMode=CollisionDetectionMode.Continuous;
		myObj.GetComponent<Rigidbody>().AddForce(myObj.transform.forward* 20.0f *((float)(owner)));
		
		GameObject myObjChild = new GameObject(myObj.name + "_damage");
		myObjChild.transform.position =myObj.transform.position;
		myObjChild.transform.parent =myObj.transform;
		ProjectileDamage pd= myObjChild.AddComponent<ProjectileDamage>();
		pd.Source=this.gameObject;//Traps don't need to be identified.
		pd.Damage=10;//Dunno what drives damage here?
		pd.AttackCharge=100f;
		pd.AttackScore=15;//down the middle.
	}

    //public override void PostActivate (object_base src)
    //{
    //Debug.Log("Overridden PostActivate to test " + this.name);
    //base.PostActivate(src);
    //      if ((int)(src.flags & 0x1) ==1)
    //{
    //		//Do not delete as src trap/trigger is set to repeat
    //}
    //else
    //{
    //		base.PostActivate (src);				
    //}		
    //}

    public override bool WillFireRepeatedly()
    {//Looks like arrow traps will always repeat. Behaviour is controlled by trigger?
        return true;
    }
}

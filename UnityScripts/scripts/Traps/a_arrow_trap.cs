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


	//public int item_index;//The object id created.
	//public int item_type;//The type of the object created

	public override void ExecuteTrap (int triggerX, int triggerY, int State)
	{//TODO: update this for the new object system.
		int item_index=  (objInt().quality << 5) | objInt().owner;
		int item_type = GameWorldController.instance.objectMaster.type[item_index];
		//Debug.Log ("an arrow trap has gone off. It will spawn a " + item_index + " of type " + item_type + " along vector " + this.gameObject.transform.rotation);
		GameObject myObj=  new GameObject("SummonedObject_" + GameWorldController.instance.playerUW.PlayerMagic.SummonCount++);
		myObj.layer=LayerMask.NameToLayer("UWObjects");
		myObj.transform.position = this.transform.position;
		myObj.transform.rotation = this.transform.rotation;
		myObj.transform.parent=GameWorldController.instance.LevelMarker();
		GameWorldController.MoveToWorld(myObj);
		ObjectInteraction.CreateObjectGraphics(myObj,_RES +"/Sprites/Objects/Objects_" + item_index,true);
		ObjectInteraction.CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, _RES +"/Sprites/Objects/Objects_" + item_index.ToString ("000"), _RES +"/Sprites/Objects/Objects_" + item_index.ToString ("000"), _RES +"/Sprites/Objects/Objects_" + item_index, item_type, item_index, 0, objInt().quality, objInt().owner, 1, 1, 0, 1, 0, 0, 0, 1);
		myObj.AddComponent<object_base>();
		GameWorldController.UnFreezeMovement(myObj);
		myObj.GetComponent<Rigidbody>().collisionDetectionMode=CollisionDetectionMode.Continuous;
		myObj.GetComponent<Rigidbody>().AddForce(myObj.transform.forward* 50.0f *((float)(objInt().owner)));
		GameObject myObjChild = new GameObject(myObj.name + "_damage");
		myObjChild.transform.position =myObj.transform.position;
		myObjChild.transform.parent =myObj.transform;
		ProjectileDamage pd= myObjChild.AddComponent<ProjectileDamage>();
		pd.Source=null;//Traps don't need to be identified.
		pd.Damage=10;
	}


}

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


	public int item_index;//The object id created.
	public int item_type;//The type of the object created

	public override void ExecuteTrap (int triggerX, int triggerY, int State)
	{
		//Debug.Log ("an arrow trap has gone off. It will spawn a " + item_index + " of type " + item_type + " along vector " + this.gameObject.transform.rotation);
		GameObject myObj=  new GameObject("SummonedObject_" + playerUW.PlayerMagic.SummonCount++);
		myObj.layer=LayerMask.NameToLayer("UWObjects");
		myObj.transform.position = this.transform.position;
		myObj.transform.rotation=this.transform.rotation;
		//myObj.transform.parent=playerUW.playerInventory.InventoryMarker.transform;
		ObjectInteraction.CreateObjectGraphics(myObj,"Sprites/OBJECTS_" + item_index,true);
		ObjectInteraction.CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_" + item_index, "Sprites/OBJECTS_" + item_index, "Sprites/OBJECTS_" + item_index, item_type, item_index, 0, objInt.Quality, objInt.Owner, 1, 1, 0, 1, 0, 0, 0, 1);
		myObj.AddComponent<object_base>();

		Vector3 ThrowDir;// =myObj.transform.position + (myObj.transform.rotation.eulerAngles.normalized);
		WindowDetectUW.UnFreezeMovement(myObj);
		ThrowDir = myObj.transform.position + (myObj.transform.forward);
		//Debug.Log (objInt.transform.name + " " + myObj.transform.position  + " to " + ThrowDir + " via " + myObj.transform.rotation.eulerAngles.normalized);
		//myObj.GetComponent<Rigidbody>().AddForce(ThrowDir* 10.0f);
		myObj.GetComponent<Rigidbody>().AddForce(myObj.transform.forward* 50.0f *((float)objInt.Owner));

		//myObj.transform.position=ThrowDir;

	}


}

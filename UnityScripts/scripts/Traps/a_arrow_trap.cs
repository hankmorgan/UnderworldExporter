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
		int item_index=  (objInt().quality << 5) | objInt().owner;

		ObjectLoaderInfo newobjt= ObjectLoader.newObject(item_index,0,0,0,256);
		GameObject myObj = ObjectInteraction.CreateNewObject(GameWorldController.instance.currentTileMap(),newobjt, GameWorldController.instance.LevelMarker().gameObject, this.transform.position).gameObject;

		myObj.transform.position = this.transform.position;
		myObj.transform.rotation = this.transform.rotation;

		GameWorldController.UnFreezeMovement(myObj);
		myObj.GetComponent<Rigidbody>().collisionDetectionMode=CollisionDetectionMode.Continuous;
		myObj.GetComponent<Rigidbody>().AddForce(myObj.transform.forward* 50.0f *((float)(objInt().owner)));
		GameObject myObjChild = new GameObject(myObj.name + "_damage");
		myObjChild.transform.position =myObj.transform.position;
		myObjChild.transform.parent =myObj.transform;
		ProjectileDamage pd= myObjChild.AddComponent<ProjectileDamage>();
		pd.Source=this.gameObject;//Traps don't need to be identified.
		pd.Damage=10;//Dunno what drives damage here?
		pd.AttackCharge=100f;
		pd.AttackScore=15;//down the middle.
	}


}

using UnityEngine;
using System.Collections;

public class a_do_trap_emeraldpuzzle : trap_base {

	public bool hasExecuted;

	public override void ExecuteTrap (int triggerX, int triggerY, int State)
	{
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
		string Item= ItemID.ToString("000");
		GameObject myObj=  new GameObject("SummonedObject_" + playerUW.PlayerMagic.SummonCount++);
		myObj.layer=LayerMask.NameToLayer("UWObjects");
		//myObj.transform.position = playerUW.playerInventory.InventoryMarker.transform.position;
		//myObj.transform.parent=playerUW.playerInventory.InventoryMarker.transform;
		ObjectInteraction.CreateObjectGraphics(myObj,"Sprites/OBJECTS_224",true);
		ObjectInteraction.CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, "Sprites/OBJECTS_224", "Sprites/OBJECTS_"+Item, "Sprites/OBJECTS_" +Item, ObjectInteraction.RUNE, 224, 1, 40, 0, 1, 1, 0, 1, 1, 0, 0, 1);
		
		myObj.AddComponent<RuneStone>();

		myObj.transform.position = new Vector3(64.5f,4.0f,24.5f);
		WindowDetect.UnFreezeMovement(myObj);
	}


	private bool CheckPlinths()
	{

		return true;
	}
}

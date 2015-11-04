using UnityEngine;
using System.Collections;

public class SilverSeed : object_base {


	public override bool PickupEvent ()
	{
		base.PickupEvent ();
		if (objInt.item_id==458)
		{//The seed is a sapling
			//Turn it into a seed.
			objInt.item_id=290;
			objInt.WorldDisplayIndex=290;
			objInt.InvDisplayIndex=290;
			AnimationOverlay animo =this.GetComponent<AnimationOverlay>();
			if (animo!=null)
			{
				animo.Stop ();
			}
			objInt.UpdateAnimation();//Update the inventory display
			playerUW.CursorIcon = objInt.GetInventoryDisplay().texture;
			playerUW.ResurrectPosition=Vector3.zero;
			objInt.SetWorldDisplay(objInt.GetInventoryDisplay());
			objInt.getMessageLog ().text= playerUW.StringControl.GetString (1,9);
			return true;
		}
		else
		{
			return false;
		}
	}

	public override bool use ()
	{
		if (playerUW.playerInventory.ObjectInHand=="")
		{
		if ((objInt.item_id==290) && (objInt.PickedUp==true))
			{
				//I'll test positioning later. For now just place it at the players position
				//Turn it into a sapling.
				objInt.item_id=458;
				objInt.WorldDisplayIndex=458;
				objInt.InvDisplayIndex=458;
				AnimationOverlay animo =this.GetComponent<AnimationOverlay>();
				if (animo!=null)
				{
					animo.Stop ();
				}
				objInt.UpdateAnimation();//Update the inventory display
				objInt.SetWorldDisplay(objInt.GetInventoryDisplay());
				objInt.getMessageLog ().text=  playerUW.StringControl.GetString (1,12);


				playerUW.CursorIcon = playerUW.CursorIconDefault;
				playerUW.ResurrectPosition=playerUW.transform.position;
				objInt.gameObject.transform.parent=null;
				objInt.transform.position=playerUW.transform.position;//TODO:Position the tree properly

				playerUW.playerInventory.RemoveItemFromEquipment(objInt.gameObject.name);
				playerUW.playerInventory.GetCurrentContainer().RemoveItemFromContainer(objInt.gameObject.name);
				playerUW.playerInventory.Refresh ();

				objInt.PickedUp=false;
				return true;
			}
			else
			{
				return false;
			}
		}
		else
		{
			return playerUW.playerInventory.GetGameObjectInHand().GetComponent<ObjectInteraction>().FailMessage();
		}
	}
}

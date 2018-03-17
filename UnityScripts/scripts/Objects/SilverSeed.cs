using UnityEngine;
using System.Collections;

public class SilverSeed : object_base {


	public override bool PickupEvent ()
	{
		base.PickupEvent ();
		if (objInt().item_id==458)
		{//The seed is a sapling
			//Turn it into a seed.
			//objInt().ChangeType(290,objInt().GetItemType());
			objInt().item_id=290;
			objInt().WorldDisplayIndex=290;
			objInt().InvDisplayIndex=290;
			AnimationOverlay animo =this.GetComponent<AnimationOverlay>();
			if (animo!=null)
			{
				animo.Stop ();
			}
			objInt().UpdateAnimation();//Update the inventory display
			UWHUD.instance.CursorIcon = objInt().GetInventoryDisplay().texture;
			UWCharacter.Instance.ResurrectPosition=Vector3.zero;
			UWCharacter.Instance.ResurrectLevel=0;
			objInt().SetWorldDisplay(objInt().GetInventoryDisplay());
			UWHUD.instance.MessageScroll.Add (StringController.instance.GetString (1,9));

			return true;
		}
		else
		{
			return false;
		}
	}

	public override bool use ()
	{
		if (UWCharacter.Instance.playerInventory.ObjectInHand=="")
		{
		if ((objInt().item_id==290) && (objInt().PickedUp==true))
			{
				//I'll test positioning later. For now just place it at the players position
				//Turn it into a sapling.
				objInt().item_id=458;
				objInt().WorldDisplayIndex=458;
				objInt().InvDisplayIndex=458;
				AnimationOverlay animo =this.GetComponent<AnimationOverlay>();
				if (animo!=null)
				{
					animo.Stop ();
				}
				objInt().UpdateAnimation();//Update the inventory display
				objInt().SetWorldDisplay(objInt().GetInventoryDisplay());
				UWHUD.instance.MessageScroll.Add(StringController.instance.GetString (1,12));


				UWHUD.instance.CursorIcon = UWHUD.instance.CursorIconDefault;
				UWCharacter.Instance.ResurrectPosition=UWCharacter.Instance.transform.position;
				UWCharacter.Instance.ResurrectLevel=(short)(GameWorldController.instance.LevelNo+1);
				//int tileX= GameWorldController.instance.Tilemap.visitTileX;
				//int tileY= GameWorldController.instance.Tilemap.visitTileY;
				objInt().gameObject.transform.parent=GameWorldController.instance.DynamicObjectMarker();

				objInt().gameObject.transform.position=GameWorldController.instance.currentTileMap().getTileVector(TileMap.visitTileX,TileMap.visitTileY);
				UWCharacter.Instance.playerInventory.RemoveItemFromEquipment(objInt().gameObject.name);
				UWCharacter.Instance.playerInventory.GetCurrentContainer().RemoveItemFromContainer(objInt().gameObject.name);
				UWCharacter.Instance.playerInventory.Refresh ();
				objInt().PickedUp=false;
				GameWorldController.MoveToWorld(objInt());
				return true;
			}
			else
			{
				return false;
			}
		}
		else
		{
			return ActivateByObject(UWCharacter.Instance.playerInventory.GetGameObjectInHand());
		}
	}

	public override string UseVerb()
	{
		return "plant";
	}

	public override bool CanBePickedUp ()
	{
		return true;
	}
}

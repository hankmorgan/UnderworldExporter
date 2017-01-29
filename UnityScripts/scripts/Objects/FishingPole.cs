using UnityEngine;
using System.Collections;

public class FishingPole : object_base {

public override bool use ()
	{
		if (objInt().PickedUp==true)
		{
			if (GameWorldController.instance.playerUW.playerInventory.ObjectInHand=="")
			{
				GoFish();
				return true;
			}
			else
			{
				return FailMessage();//No use on behaviour for this object.
			}
		}
		else
		{
			return false;
		}

	}

	/// <summary>
	/// Fishing Code.
	/// </summary>
	private void GoFish()
	{
		int tileX=(int)(GameWorldController.instance.playerUW.transform.position.x/1.2f);
		int tileY=(int)(GameWorldController.instance.playerUW.transform.position.z/1.2f);
	

		for (int x=-1; x<=1;x++)
		{//test the tile and it's neighbours for water.
			for (int y=-1; y<=1;y++)
			{
				if (GameWorldController.instance.currentTileMap().Tiles[tileX+x,tileY+y].isWater)
				{
					if (Random.Range (0,10)>=7)
					{//catch something or test for encumerance
						//000~001~099~You catch a lovely fish.
						if ((GameWorldController.instance.commobj.Mass[182]*0.1f) <= GameWorldController.instance.playerUW.playerInventory.getEncumberance())
						{
							UWHUD.instance.MessageScroll.Add (StringController.instance.GetString (1,99));
							GameObject fishy = CreateFish();
							GameWorldController.instance.playerUW.playerInventory.ObjectInHand=fishy.name;
							ObjectInteraction FishobjInt = fishy.GetComponent<ObjectInteraction>();
							if (FishobjInt!=null)
							{
								FishobjInt.UpdateAnimation();
								//UWHUD.instance.CursorIcon= //FishobjInt.InventoryDisplay.texture;
								UWHUD.instance.CursorIcon= FishobjInt.GetInventoryDisplay().texture ;//FishobjInt.InventoryDisplay.texture;
							}

							UWCharacter.InteractionMode=UWCharacter.InteractionModePickup;
							InteractionModeControl.UpdateNow=true;
						}
						else
						{//000~001~102~You feel a nibble, but the fish gets away.
							UWHUD.instance.MessageScroll.Add (StringController.instance.GetString (1,102));
						}
					}
					else
					{//000~001~100~No luck this time.
						UWHUD.instance.MessageScroll.Add (StringController.instance.GetString (1,100));
					}
					return;
				}
			}
		}
		//000~001~101~You cannot fish there.  Perhaps somewhere else.
		UWHUD.instance.MessageScroll.Add (StringController.instance.GetString (1,101));
	}

	/// <summary>
	/// Creates the fish that the player has caught.
	/// </summary>
	/// <returns>The fish.</returns>
	GameObject CreateFish()
	{
		return ObjectInteraction.CreateNewObject(182).gameObject;
	}

}

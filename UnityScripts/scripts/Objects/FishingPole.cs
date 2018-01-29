using UnityEngine;
using System.Collections;

public class FishingPole : object_base {

public override bool use ()
	{
		if (objInt().PickedUp==true)
		{
			if (UWCharacter.Instance.playerInventory.ObjectInHand=="")
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
		int tileX=(int)(UWCharacter.Instance.transform.position.x/1.2f);
		int tileY=(int)(UWCharacter.Instance.transform.position.z/1.2f);
	

		for (int x=-1; x<=1;x++)
		{//test the tile and it's neighbours for water.
			for (int y=-1; y<=1;y++)
			{
				if (GameWorldController.instance.currentTileMap().Tiles[tileX+x,tileY+y].isWater)
				{
					if (Random.Range (0,10)>=7)
					{//catch something or test for encumerance
						//000~001~099~You catch a lovely fish.
						if ((GameWorldController.instance.commonObject.properties[182].mass*0.1f) <= UWCharacter.Instance.playerInventory.getEncumberance())
						{
							UWHUD.instance.MessageScroll.Add (StringController.instance.GetString (1,StringController.str_you_catch_a_lovely_fish_));
							GameObject fishy = CreateFish();
							UWCharacter.Instance.playerInventory.ObjectInHand=fishy.name;
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
							UWHUD.instance.MessageScroll.Add (StringController.instance.GetString (1,StringController.str_you_feel_a_nibble_but_the_fish_gets_away_));
						}
					}
					else
					{//000~001~100~No luck this time.
						UWHUD.instance.MessageScroll.Add (StringController.instance.GetString (1,StringController.str_no_luck_this_time_));
					}
					return;
				}
			}
		}
		//000~001~101~You cannot fish there.  Perhaps somewhere else.
		UWHUD.instance.MessageScroll.Add (StringController.instance.GetString (1,StringController.str_you_cannot_fish_there__perhaps_somewhere_else_));
	}

	/// <summary>
	/// Creates the fish that the player has caught.
	/// </summary>
	/// <returns>The fish.</returns>
	GameObject CreateFish()
	{
		ObjectLoaderInfo newobjt= ObjectLoader.newObject(182,40,0,1,256);
		ObjectInteraction fishy = ObjectInteraction.CreateNewObject(GameWorldController.instance.currentTileMap(),newobjt, GameWorldController.instance.InventoryMarker.gameObject, GameWorldController.instance.InventoryMarker.transform.position);
		fishy.gameObject.name= ObjectLoader.UniqueObjectName(newobjt);
		fishy.isquant=1;
		GameWorldController.MoveToInventory(fishy.gameObject);
		return fishy.gameObject;
	}

}

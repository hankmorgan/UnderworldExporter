using UnityEngine;
using System.Collections;

public class FishingPole : object_base {

public override bool use ()
	{
		if (objInt.PickedUp==true)
		{
			if (playerUW.playerInventory.ObjectInHand=="")
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
		int tileX=(int)(playerUW.transform.position.x/1.2f);
		int tileY=(int)(playerUW.transform.position.z/1.2f);
	

		for (int x=-1; x<=1;x++)
		{//test the tile and it's neighbours for water.
			for (int y=-1; y<=1;y++)
			{
				if (GameWorldController.instance.Tilemap.isWater[tileX+x,tileY+y])
				{
					if (Random.Range (0,10)>=7)
					{//catch something or test for encumerance
						//000~001~099~You catch a lovely fish.
						if ((ObjectInteraction.Weight[182]*0.1f) <= playerUW.playerInventory.getEncumberance())
						{
							ml.Add (playerUW.StringControl.GetString (1,99));
							GameObject fishy = CreateFish();
							playerUW.playerInventory.ObjectInHand=fishy.name;
							ObjectInteraction FishobjInt = fishy.GetComponent<ObjectInteraction>();
							if (FishobjInt!=null)
							{
								FishobjInt.UpdateAnimation();
								playerUW.CursorIcon= FishobjInt.InventoryDisplay.texture;
							}

							UWCharacter.InteractionMode=UWCharacter.InteractionModePickup;
							InteractionModeControl.UpdateNow=true;
						}
						else
						{//000~001~102~You feel a nibble, but the fish gets away.
							ml.Add (playerUW.StringControl.GetString (1,102));
						}
					}
					else
					{//000~001~100~No luck this time.
						ml.Add (playerUW.StringControl.GetString (1,100));
					}
					return;
				}
			}
		}
		//000~001~101~You cannot fish there.  Perhaps somewhere else.
		ml.Add (playerUW.StringControl.GetString (1,101));
	}


	GameObject CreateFish()
	{//Create food

		//int ObjectNo = 182;
		GameObject myObj=  new GameObject("SummonedObject_" + playerUW.PlayerMagic.SummonCount++);
		myObj.layer=LayerMask.NameToLayer("UWObjects");
		myObj.transform.position = playerUW.playerInventory.InventoryMarker.transform.position;
		myObj.transform.parent=playerUW.playerInventory.InventoryMarker.transform;
		ObjectInteraction.CreateObjectGraphics(myObj,_RES +"/Sprites/OBJECTS_182",true);
		//CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, _RES +"/Sprites/OBJECTS_" +ObjectNo, _RES +"/Sprites/OBJECTS_"+ObjectNo, _RES +"/Sprites/OBJECTS_"+ObjectNo, ObjectInteraction.FOOD, ObjectNo, 1, 40, 0, 1, 0, 1);
		ObjectInteraction.CreateObjectInteraction(myObj,0.5f,0.5f,0.5f,0.5f, _RES +"/Sprites/OBJECTS_182", _RES +"/Sprites/OBJECTS_182", _RES +"/Sprites/OBJECTS_182", ObjectInteraction.FOOD, 182, 1, 40, 0, 1, 1, 0, 1, 1, 0, 0, 1);

		Food fd = myObj.AddComponent<Food>();
		fd.Nutrition=5;//TODO:determine values to use here.
		return myObj;
	}

}

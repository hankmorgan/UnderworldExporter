using UnityEngine;
using System.Collections;

public class a_hack_trap_vending : a_hack_trap {

		//spawns vending selection
	public override void ExecuteTrap (object_base src, int triggerX, int triggerY, int State)
	{//4.4
		Vector3 spawn = GameWorldController.instance.currentTileMap().getTileVector(objInt().tileX, objInt().tileY);
		spawn = new Vector3(spawn.x,4.4f,spawn.z);
		int ItemStringIndex=0;
		int Price=0;

		switch (Quest.instance.variables[objInt().owner])
		{
		case 0://fish
				ItemStringIndex=182;
				Price=3;
				break;
		case 1://meat
				ItemStringIndex=176;
				Price=3;
				break;
		case 2://ale
				ItemStringIndex=187;
				Price=4;
				break;
		case 3://leeches
				ItemStringIndex=293;
				Price=4;
				break;
		case 4://water
				ItemStringIndex=188;
				Price=3;
				break;
		case 5://dagger
				ItemStringIndex=3;
				Price=11;
				break;
		case 6://lockpick
				ItemStringIndex=257;
				Price=6;
				break;
		case 7://torch
				ItemStringIndex=145;
				Price=4;
				break;
		default:
				return;
		}

		if(CheckPrice(Price, objInt().tileX, objInt().tileY))
		{//price check
			ObjectLoaderInfo newobjt= ObjectLoader.newObject( ItemStringIndex,40,0,0,256);
			newobjt.InUseFlag=1;
			GameWorldController.UnFreezeMovement(GameWorldController.MoveToWorld(ObjectInteraction.CreateNewObject(GameWorldController.instance.currentTileMap(),newobjt, GameWorldController.instance.LevelMarker().gameObject, spawn)).gameObject);
		}		
	}


		bool CheckPrice(int TargetPrice, int triggerX, int triggerY)
		{//Checks if enough gold is on the pad
				Vector3 ContactArea= new Vector3(0.59f,0.15f,0.59f);
				Collider[] colliders = Physics.OverlapBox(GameWorldController.instance.currentTileMap().getTileVector(triggerX,triggerY), ContactArea);
				for (int i=0; i<=colliders.GetUpperBound(0);i++)
				{
						if (colliders[i].gameObject.GetComponent<ObjectInteraction>()!=null)
						{
								if (
										(colliders[i].gameObject.GetComponent<ObjectInteraction>().item_id==160) 
								)
								{
										if (colliders[i].gameObject.GetComponent<ObjectInteraction>().GetQty()>=TargetPrice)
										{
												for (int p=0; p<TargetPrice;p++)
												{//Only take what is needed 
														colliders[i].gameObject.GetComponent<ObjectInteraction>().consumeObject();		
												}
												return true;
										}
								}
						}
				}
				return false;
		}




	public override void PostActivate (object_base src)
	{

	}
}

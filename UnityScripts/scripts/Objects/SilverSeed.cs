using UnityEngine;
using System.Collections;

public class SilverSeed : object_base {
    
	public override bool use ()
	{
		if (CurrentObjectInHand==null)
		{
		if ((objInt().PickedUp==true))
			{
                ObjectLoaderInfo newtree = ObjectLoader.newObject(458, 40, 16, 1, 256);
                newtree.is_quant = 1;
                ObjectInteraction.CreateNewObject
                    (
                    CurrentTileMap(),
                    newtree,
                    CurrentObjectList().objInfo,
                    GameWorldController.instance.DynamicObjectMarker().gameObject,
                    CurrentTileMap().getTileVector(TileMap.visitTileX, TileMap.visitTileY)
                    );

			    UWHUD.instance.MessageScroll.Add(StringController.instance.GetString (1,12));

                //UWHUD.instance.CursorIcon = UWHUD.instance.CursorIconDefault;
				UWCharacter.Instance.ResurrectPosition=UWCharacter.Instance.transform.position;
				UWCharacter.Instance.ResurrectLevel=(short)(GameWorldController.instance.LevelNo+1);
                objInt().consumeObject();
				return true;
			}
			else
			{
				return false;
			}
		}
		else
		{
			return ActivateByObject(CurrentObjectInHand);
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

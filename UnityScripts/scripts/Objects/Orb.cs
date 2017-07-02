using UnityEngine;
using System.Collections;

public class Orb : object_base {


	protected override void Start ()
	{
		base.Start ();
		if ((_RES==GAME_UW1) && (GameWorldController.instance.LevelNo==6))
			{
			if (GameWorldController.instance.playerUW.quest().isOrbDestroyed==false)	
				{
					GameWorldController.instance.playerUW.PlayerMagic.CurMana=0;
					GameWorldController.instance.playerUW.PlayerMagic.MaxMana=0;
				}
			}
	}


	public override bool LookAt ()
	{
		if (objInt().link!=0)
		{
			ObjectInteraction objIntLink = ObjectLoader.getObjectIntAt(objInt().link);
			if (objIntLink!=null)
			{
				switch (GameWorldController.instance.objectMaster.type[objIntLink.item_id])
				{
				case ObjectInteraction.A_LOOK_TRIGGER:
					return objIntLink.GetComponent<trigger_base>().Activate();					
				}
			}
		}
		return base.LookAt();
	}

	public override bool use ()
	{
		if (GameWorldController.instance.playerUW.playerInventory.ObjectInHand=="")
		{
			if (objInt().link!=0)
			{
				ObjectInteraction objIntLink = ObjectLoader.getObjectIntAt(objInt().link);
				if (objIntLink!=null)
				{
					switch (GameWorldController.instance.objectMaster.type[objIntLink.item_id])
					{
					case ObjectInteraction.A_USE_TRIGGER:
						return objIntLink.GetComponent<trigger_base>().Activate();																										
					}
				}
			}
		}
		else
		{
			return ActivateByObject(GameWorldController.instance.playerUW.playerInventory.GetGameObjectInHand());
		}

		return LookAt();
	}


	public override bool ActivateByObject (GameObject ObjectUsed)
	{
		ObjectInteraction objIntUsed = ObjectUsed.GetComponent<ObjectInteraction>();
		if (objIntUsed != null) 
		{
			switch (objIntUsed.GetItemType())
			{
				case ObjectInteraction.AN_ORB_ROCK:
				{
					if ((_RES==GAME_UW1) && (GameWorldController.instance.LevelNo==6))
					{
						UWHUD.instance.CursorIcon= UWHUD.instance.CursorIconDefault;
						GameWorldController.instance.playerUW.playerInventory.ObjectInHand="";
						OrbRock.DestroyOrb(objInt());
						return true;
					}
					else
					{
						return base.ActivateByObject (ObjectUsed);	
					}
				}				
			}
		}
		return base.ActivateByObject (ObjectUsed);
	}


}

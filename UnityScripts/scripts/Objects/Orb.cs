using UnityEngine;
using System.Collections;

public class Orb : object_base {


	protected override void Start ()
	{
		base.Start ();
		if ((_RES==GAME_UW1) && (GameWorldController.instance.LevelNo==6))
			{
			if (Quest.instance.isOrbDestroyed==false)	
				{
					UWCharacter.Instance.PlayerMagic.CurMana=0;
					UWCharacter.Instance.PlayerMagic.MaxMana=0;
				}
			}
	}


	public override bool LookAt ()
	{
		if (link!=0)
		{
			ObjectInteraction objIntLink = ObjectLoader.getObjectIntAt(link);
			if (objIntLink!=null)
			{
				switch (objIntLink.GetItemType())
				{
				case ObjectInteraction.A_LOOK_TRIGGER:
					return objIntLink.GetComponent<trigger_base>().Activate(this.gameObject);					
				}
			}
		}
		return base.LookAt();
	}

	public override bool use ()
	{
		if (UWCharacter.Instance.playerInventory.ObjectInHand=="")
		{
			if (link!=0)
			{
				ObjectInteraction objIntLink = ObjectLoader.getObjectIntAt(link);
				if (objIntLink!=null)
				{
					switch (objIntLink.GetItemType())
					{
					case ObjectInteraction.A_USE_TRIGGER:
						return objIntLink.GetComponent<trigger_base>().Activate(this.gameObject);																										
					}
				}
			}
		}
		else
		{
			return ActivateByObject(UWCharacter.Instance.playerInventory.GetGameObjectInHand());
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
						UWCharacter.Instance.playerInventory.ObjectInHand="";
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

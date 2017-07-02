using UnityEngine;
using System.Collections;

public class OrbRock : object_base {

	public static void DestroyOrb(ObjectInteraction orbToDestroy)
	{
		//Spawn an impact
		Impact.SpawnHitImpact(orbToDestroy.transform.name + "_impact", orbToDestroy.GetImpactPoint(),46,50);
		GameWorldController.instance.playerUW.quest().isOrbDestroyed=true;
		GameWorldController.instance.playerUW.PlayerMagic.MaxMana=GameWorldController.instance.playerUW.PlayerMagic.TrueMaxMana;
		GameWorldController.instance.playerUW.PlayerMagic.CurMana=GameWorldController.instance.playerUW.PlayerMagic.MaxMana;
		//000-001-133 The orb is destroyed
		UWHUD.instance.MessageScroll.Add(StringController.instance.GetString (1,133));

		orbToDestroy.consumeObject();						
	}

	void OnCollisionEnter(Collision collision)
	{//	
		if (objInt().PickedUp==false)
		{
			if ((GameWorldController.instance.LevelNo==6) && (_RES==GAME_UW1))
			{
				if(collision.gameObject.name.Contains("orb"))
				{
					ObjectInteraction HitobjInt = collision.gameObject.GetComponent<ObjectInteraction>();
					if (HitobjInt.GetItemType()==ObjectInteraction.ORB)
					{
						DestroyOrb(HitobjInt);
					}
				}
			}	
		}

	}


}

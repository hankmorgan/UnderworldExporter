using UnityEngine;
using System.Collections;

public class WeaponRanged : Weapon {

	//public int AmmoType;//Item_id of the ammo to be used. (Why not make it anything I want it to be!
	//public int durabil;


		public int AmmoType()
		{
			return GameWorldController.instance.objDat.rangedStats[objInt().item_id-24].ammo;	
		}


		public int Damage()
		{
			return GameWorldController.instance.objDat.rangedStats[objInt().item_id-24].damage;	
		}
}


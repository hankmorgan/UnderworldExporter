using UnityEngine;
using System.Collections;

public class a_damage_trap : trap_base {
	//0180  a_damage trap
	//	player vitality is decreased; number of hit points are in "quality"
	//	field; if the "owner" field is != 0, the hit points are added
	//	instead. the trap is only set of when a random value [0..10] is >= 7.


	public override void ExecuteTrap (int triggerX, int triggerY, int State)
	{
		if (Random.Range(0,11) >= 7)
		{
			if (objInt.Owner ==0)
			{
				playerUW.CurVIT= playerUW.CurVIT- objInt.Quality;
			}
			else
			{
				playerUW.CurVIT= playerUW.CurVIT+objInt.Quality;
			}
		}
	}
}

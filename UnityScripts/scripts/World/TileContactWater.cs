using UnityEngine;
using System.Collections;

public class TileContactWater : TileContact {

	protected override void TileContactEvent (ObjectInteraction obj, Vector3 position)
	{
		if (obj.item_id!=453)
		{
			Impact.SpawnHitImpact(453, position, 36, 40);
			if (IsObjectDestroyable(obj))
			{			
				DestroyObject(obj);
			}	
		}
	}
}
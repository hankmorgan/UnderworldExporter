using UnityEngine;
using System.Collections;

public class TileContactLava : TileContact {

	protected override void TileContactEvent (ObjectInteraction obj, Vector3 position)
	{
		if (obj.item_id!=456)
		{
			Impact.SpawnHitImpact(456, position, 9, 12);
			if (IsObjectDestroyable(obj))
			{			
				DestroyObject(obj);
			}	
		}
	}
}
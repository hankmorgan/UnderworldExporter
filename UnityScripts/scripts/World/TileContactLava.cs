using UnityEngine;
using System.Collections;

public class TileContactLava : TileContact {

    /// <summary>
    /// Handles throwing objects into lava.
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="position"></param>
    /// Does not include handling of the talismans which use the larger shrine lava trigger.
	protected override void TileContactEvent (ObjectInteraction obj, Vector3 position)
	{
		if (obj.item_id!=456)
		{
			Impact.SpawnHitImpact(456, position, 9, 12);
			if (IsObjectDestroyable(obj))
			{
                ObjectInteraction.DestroyObjectFromUW(obj);
            }	
		}
	}
}
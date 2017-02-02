using UnityEngine;
using System.Collections;

public class Orb : object_base {


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
		return LookAt();
	}



}

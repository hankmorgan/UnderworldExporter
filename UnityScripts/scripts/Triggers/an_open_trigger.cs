using UnityEngine;
using System.Collections;

public class an_open_trigger : trigger_base {
		
	public override bool Activate (GameObject src)
	{
		int thisType=objInt().GetItemType();
		GameObject triggerObj = ObjectLoader.getGameObjectAt(objInt().link);
		if (triggerObj!=null)
		{
			if (triggerObj.GetComponent<trap_base>() !=null)
			{
				triggerObj.GetComponent<trap_base>().Activate (this, objInt().quality,objInt().owner,objInt().flags);	
			}
		}

		//Open/Close trigers may have additional triggers that fire off as well
				if (ObjectLoader.GetItemTypeAt(objInt().next) != ObjectInteraction.A_CLOSE_TRIGGER)
				{
						triggerObj = ObjectLoader.getGameObjectAt(objInt().next);
						if (triggerObj!=null)
						{
								if (triggerObj.GetComponent<trigger_base>() !=null)
								{
										triggerObj.GetComponent<trigger_base>().Activate (this.gameObject);	
								}
						}	
				}


		PostActivate(src);
		return true;
	}


	public override void PostActivate (GameObject src)
	{

	}

}

using UnityEngine;
using System.Collections;

public class a_close_trigger :trigger_base {
		
		public override bool Activate (GameObject src)
		{
				//int thisType=objInt().GetItemType();
				GameObject triggerObj = ObjectLoader.getGameObjectAt(link);
				if (triggerObj!=null)
				{
						if (triggerObj.GetComponent<trap_base>() !=null)
						{
								triggerObj.GetComponent<trap_base>().Activate (this, quality,owner,flags);	
						}
				}

				//Open/Close trigers may have additional triggers that fire off as well
				if (ObjectLoader.GetItemTypeAt(next) != ObjectInteraction.AN_OPEN_TRIGGER)
				{
						triggerObj = ObjectLoader.getGameObjectAt(next);
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

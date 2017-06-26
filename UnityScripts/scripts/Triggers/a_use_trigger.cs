using UnityEngine;
using System.Collections;

public class a_use_trigger : trigger_base {
	
/*
 A trigger that is fired when the player uses something eg switches
 */

		public bool Activate (bool mode)
		{
				Debug.Log (this.name);
				GameObject triggerObj=null;
				if (mode)
				{
						triggerObj= ObjectLoader.getGameObjectAt(objInt().link);	
				}
				else
				{
					if (objInt().next!=0)		
					{
						triggerObj= ObjectLoader.getGameObjectAt((int)objInt().next);	
					}
					else
					{
						triggerObj= ObjectLoader.getGameObjectAt(objInt().link);	
					}
				}

				if (triggerObj!=null)
				{
						if (triggerObj.GetComponent<trap_base>() !=null)
						{
								triggerObj.GetComponent<trap_base>().Activate (this, objInt().quality,objInt().owner,objInt().flags);	
						}
						if (triggerObj.GetComponent<trigger_base>() !=null)
						{
							triggerObj.GetComponent<trigger_base>().Activate ();	
						}
				}

				PostActivate();
				return true;
		}



}

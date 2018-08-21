using UnityEngine;
using System.Collections;

public class event_fire_triggers : event_base {

		//Fires any type of trigger at the specified tiles

		public override void ExecuteEvent ()
		{
				base.ExecuteEvent();
				int eventTileX = RawData[3];
				int eventTileY = RawData[4];

				ObjectLoaderInfo[] objList=CurrentObjectList().objInfo;
				for (int o=256; o<=objList.GetUpperBound(0);o++)
				{
						if ( (objList[o].ObjectTileX == eventTileX) && (objList[o].ObjectTileY == eventTileY) && (objList[o].instance!=null))
						{
								if (ObjectLoader.isTrigger(objList[o]))
								{
										objList[o].instance.GetComponent<trigger_base>().Activate(UWCharacter.Instance.gameObject);
								}
						}
				}
		}
}

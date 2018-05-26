using UnityEngine;
using System.Collections;

public class a_text_string_trap : trap_base {
/*
 0190  a_text string trap
 causes the player to get a text message when it is set off. The
 "owner" field specifies string number per level, in game strings
 block 0009. The actual string number printed is (64*level + "owner")

*/
	//public int StringNo;	//What string we are spitting out. (num is based on level no)
	//public int StringBlock; //From what block the string is from.

	public override void ExecuteTrap (object_base src, int triggerX, int triggerY, int State)
	{
		//Debug.Log (this.name);
		//CheckReferences();
				int StringNo=0;

				switch (_RES)
				{
				case GAME_UW2:
					StringNo=(32*objInt().quality + objInt().owner);//I hope.
					break;
				default:
					StringNo=(64*GameWorldController.instance.LevelNo)+objInt().owner;	
					break;
				}

		UWHUD.instance.MessageScroll.Add(StringController.instance.GetString(9,StringNo));
	}

	public override void PostActivate (object_base src)
	{//Do not destroy.
		if (((objInt().flags >> 2) & 0x1) ==1)
		{
			//This string will trigger only once and will destroy all triggers linked to it as well as itself
			ObjectLoaderInfo[] objList = GameWorldController.instance.CurrentObjectList().objInfo;
			for (int i =256; i<=objList.GetUpperBound(0);i++ )
			{
				if (objList[i].instance!=null)
				{
					if (ObjectLoader.isTrigger(objList[i]))
					{
						if (objList[i].link == objInt().objectloaderinfo.index)
						{
							objList[i].instance.consumeObject();
						}
					}		
				}
			}
			base.PostActivate(src);
		}
	}

}

using UnityEngine;
using System.Collections;

public class a_text_string_trap : trap_base {
/*
 0190  a_text string trap
 causes the player to get a text message when it is set off. The
 "owner" field specifies string number per level, in game strings
 block 0009. The actual string number printed is (64*level + "owner")

*/

	public override void ExecuteTrap (object_base src, int triggerX, int triggerY, int State)
	{
		int StringNo=0;

		switch (_RES)
		{
		case GAME_UW2:
			StringNo=(32*quality + owner);//I hope.
			break;
		default:
			StringNo=(64*GameWorldController.instance.LevelNo)+owner;	
			break;
		}

		UWHUD.instance.MessageScroll.Add(StringController.instance.GetString(9,StringNo));
	}


    public override void PostActivate(object_base src)
    {//Prevent deletion of the trap
        Debug.Log("Overridden PostActivate to test " + this.name);
        base.PostActivate(src);
    }

    //public override void PostActivate (object_base src)
    //{//Do not destroy.
    //       Debug.Log("Overridden PostActivate to test " + this.name);
    //       if (((flags >> 2) & 0x1) ==1)
    //	{
    //		//This string will trigger only once and will destroy all triggers linked to it as well as itself
    //		ObjectLoaderInfo[] objList = CurrentObjectList().objInfo;
    //		for (int i =256; i<=objList.GetUpperBound(0);i++ )
    //		{
    //			if (objList[i].instance!=null)
    //			{
    //				if (ObjectLoader.isTrigger(objList[i]))
    //				{
    //					if (objList[i].link == objInt().objectloaderinfo.index)
    //					{
    //						objList[i].instance.consumeObject();
    //					}
    //				}		
    //			}
    //		}
    //		base.PostActivate(src);
    //	}
    //}

}

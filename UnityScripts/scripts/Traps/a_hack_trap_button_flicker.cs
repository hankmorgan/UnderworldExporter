using UnityEngine;
using System.Collections;

public class a_hack_trap_button_flicker : a_hack_trap {

	ObjectLoaderInfo[] objList;

	protected override void Start ()
	{
		base.Start ();
		objList =GameWorldController.instance.CurrentObjectList().objInfo;
	}

	public override void ExecuteTrap (object_base src, int triggerX, int triggerY, int State)
	{
		if(objList==null){return;}
		for (int i=256; i<=objList.GetUpperBound(0);i++)
		{
			if ((objList[i].InUseFlag !=0) )
			{
			if (
					(
					(objList[i].item_id==376)
					||
					(objList[i].item_id==368)
					||
					(objList[i].item_id==380)
					||
					(objList[i].item_id==372)
					)
					&&
					(objList[i].link==0	)
				)
				{
					if (objList[i].instance!=null)
					{
						if (Random.Range(0,2)  == 1)
						{
							if (objList[i].instance.GetComponent<ButtonHandler>()!=null)	
							{
								objList[i].instance.GetComponent<ButtonHandler>().Activate(this.gameObject);
							}
						}
					}
				}
			}
		}
	}


	public override void PostActivate (object_base src)
	{
        Debug.Log("Overridden PostActivate to test " + this.name);
        base.PostActivate(src);
    }
}

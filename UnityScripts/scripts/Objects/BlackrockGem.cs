using UnityEngine;
using System.Collections;

public class BlackrockGem : object_base {
//One of the small blackrock gemstones
		//
	public override bool LookAt ()
	{
		string lookdesc;
		if (owner==1)
		{
			lookdesc=StringController.instance.GetString(1,StringController.str_you_see_) 
				+ " a " 
				+ StringController.instance.GetString(1,357) 
				+ StringController.instance.GetSimpleObjectNameUW(objInt())	;
		}
		else
		{
			lookdesc=StringController.instance.GetString(1,StringController.str_you_see_) 
					+ " a " 
					+ StringController.instance.GetString(1,356) 
					+ StringController.instance.GetSimpleObjectNameUW(objInt())	;
		}
		UWHUD.instance.MessageScroll.Add(lookdesc);
		return true;
	}

}

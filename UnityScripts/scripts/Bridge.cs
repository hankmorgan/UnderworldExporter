using UnityEngine;
using System.Collections;

public class Bridge : object_base {
	public int TextureIndex;//For description
	public string UseLink;//A trigger to fire when used.

	public override bool LookAt ()
	{
		if (objInt.flags<2)
		{
			return base.LookAt ();
		}
		else
		{
			//Return material description
			ml.Add (playerUW.StringControl.TextureDescription(( 510- (TextureIndex-210)  )));
			return true;
		}
	}

	public override bool use ()
	{
		if (UseLink!="")
		{
			GameObject obj = GameObject.Find (UseLink);
			if (obj!=null)
			{
				if (obj.GetComponent<trigger_base>()!=null)
				{
					return obj.GetComponent<trigger_base>().Activate();
				}
			}
		}
		return false;
	}
}

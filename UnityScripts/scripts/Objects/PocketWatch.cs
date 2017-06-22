using UnityEngine;
using System.Collections;

public class PocketWatch : object_base {



	public override bool use ()
	{//000~001~039~The watch reads
		UWHUD.instance.MessageScroll.Add(StringController.instance.GetString(1,39) + GameClock.hour() + ":" + GameClock.minute().ToString("d2"));
		return true;
	}

}

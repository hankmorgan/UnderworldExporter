using UnityEngine;
using System.Collections;

public class Bedroll : object_base {

	public override bool use ()
	{
	    if (CurrentObjectInHand==null)
		    {
			    UWCharacter.Instance.Sleep();
			    return true;
		    }
		    else
		    {
		    return ActivateByObject(CurrentObjectInHand);
		    }
	}

	public override string UseVerb ()
	{
		return "sleep";
	}

}

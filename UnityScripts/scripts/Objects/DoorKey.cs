using UnityEngine;
using System.Collections;
/// <summary>
/// Door key.
/// </summary>
/// Guess
public class DoorKey : object_base {
	///This should match the doors it is opening. Also index into look descriptions
	public int KeyId;

    protected override void Start()
    {
        KeyId = owner;
    }

    public override bool use ()
	{
		if (objInt().PickedUp==true)
		{
			if (CurrentObjectInHand==null)
			{
				BecomeObjectInHand();
				UWHUD.instance.MessageScroll.Set (StringController.instance.GetString(1,7));
				return true;
			}
			else
			{
				return ActivateByObject(CurrentObjectInHand);
			}
		}
		else
		{
			objInt().FailMessage();
			return false;
		}
	}

	public override bool LookAt ()
	{
		if (objInt().PickedUp==true)
		{
			UWHUD.instance.MessageScroll.Add(StringController.instance.GetString(5,owner+100));
		}
		else
		{
			UWHUD.instance.MessageScroll.Add(StringController.instance.GetFormattedObjectNameUW(objInt()));
		}

		return true;
	}
}
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
        KeyId = objInt().owner;
    }

    public override bool use ()
	{
		if (objInt().PickedUp==true)
		{
			if (UWCharacter.Instance.playerInventory.ObjectInHand=="")
			{
				BecomeObjectInHand();
				UWHUD.instance.MessageScroll.Set (StringController.instance.GetString(1,7));
				return true;
			}
			else
			{
				return ActivateByObject(UWCharacter.Instance.playerInventory.GetGameObjectInHand());
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
			UWHUD.instance.MessageScroll.Add(StringController.instance.GetString(5,objInt().owner+100));
		}
		else
		{
			UWHUD.instance.MessageScroll.Add(StringController.instance.GetFormattedObjectNameUW(objInt()));
		}

		return true;
	}
}
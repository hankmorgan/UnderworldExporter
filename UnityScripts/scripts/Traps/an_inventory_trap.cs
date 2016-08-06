using UnityEngine;
using System.Collections;

public class an_inventory_trap : trap_base {
	/*
   018c  an_inventory trap
         the trap searches for an item in the inventory; when it is found, the
         sp_link'ed trigger is set off. the item_id is given by
         ("quality" << 5) | "owner". additionally, the zpos value must be != 0
         to enable the trap.
	*/

	private bool ObjectFound;

	public override void ExecuteTrap (int triggerX, int triggerY, int State)
	{
		int itemToFind = objInt().Quality <<5 | objInt().Owner;
		ObjectFound=false;
		ObjectInteraction foundObjInt = GameWorldController.instance.playerUW.playerInventory.findObjInteractionByID(itemToFind);
		if (foundObjInt!=null)
		{
			ObjectFound=true;
		}
	}

	public override void TriggerNext (int triggerX, int triggerY, int State)
	{
		if (ObjectFound==true)
		{
			base.TriggerNext (triggerX, triggerY, State);
		}
	}

	public override void PostActivate ()
	{//Do not destroy.

	}

}

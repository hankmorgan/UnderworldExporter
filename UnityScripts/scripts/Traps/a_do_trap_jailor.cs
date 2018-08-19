using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class a_do_trap_jailor : a_hack_trap {

		//Triggers conversation with feral troll jail in tybals lair (if they are alive)

    //TODO:Check if this should match to a npc_whoami instead of a specific object Id
	public override void ExecuteTrap (object_base src, int triggerX, int triggerY, int State)
	{
		ObjectInteraction npc = ObjectLoader.getObjectIntAt(251);
		if (npc!=null)
		{
			if (npc.GetComponent<NPC>()!=null)
			{
				if (npc.GetComponent<NPC>().npc_whoami == 216)
				{
					npc.TalkTo();
				}
			}
		}
	}
}

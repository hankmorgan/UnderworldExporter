using UnityEngine;
using System.Collections;

public class a_hack_trap_castle_npcs : a_hack_trap {

//Seems to move npcs to different locations.
		//Possibly used to implement npc schedules?

	public override void ExecuteTrap (object_base src, int triggerX, int triggerY, int State)
	{
		SetNPCLocation(216,43,49);
		SetNPCLocation(227,42,35);
		SetNPCLocation(228,36,51);
		SetNPCLocation(230,29,36);
		SetNPCLocation(231,30,52);
		SetNPCLocation(232,21,34);
		SetNPCLocation(233,34,35);
		SetNPCLocation(235,31,52);
		SetNPCLocation(236,22,37);
		SetNPCLocation(244,24,39);
		SetNPCLocation(245,44,48);
		SetNPCLocation(246,25,34);
		SetNPCLocation(248,33,52);
		SetNPCLocation(249,29,47);
		SetNPCLocation(250,37,35);
		SetNPCLocation(251,25,43);
		SetNPCLocation(252,21,42);
		SetNPCLocation(253,22,51);
		SetNPCLocation(254,30,50);
		SetNPCLocation(255,42,36);
	}


	void SetNPCLocation(int index, int xhome, int yhome)
	{
		ObjectInteraction obj=ObjectLoader.getObjectIntAt(index);
		if (obj!=null)
		{
			NPC npc = obj.GetComponent<NPC>();
			if (npc!=null)
			{
					npc.npc_xhome=(short)xhome;
					npc.npc_yhome=(short)yhome;
			}
		}
	}
}

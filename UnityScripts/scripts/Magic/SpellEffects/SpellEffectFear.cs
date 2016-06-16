using UnityEngine;
using System.Collections;

public class SpellEffectFear : SpellEffect {

	public int OriginalState;
	public int OriginalAttitude;
	public NPC npc;
	public bool WasActive;
	public override void ApplyEffect ()
	{
		if ((this.GetComponent<SpellEffectAlly>()==null) && (this.GetComponent<SpellEffectConfusion>()==null))
		{//Only one or the other.
			npc=this.GetComponent<NPC>();
			if (npc!=null)
			{
				OriginalState= npc.state;
				OriginalAttitude=npc.npc_attitude;
				npc.state=NPC.AI_STATE_IDLERANDOM;	//Temporarily just wander around
				npc.npc_attitude=NPC.AI_ATTITUDE_UPSET;
				WasActive=true;
			}	
		}
		base.ApplyEffect();
	}

	public override void CancelEffect ()
	{
		if(WasActive==true)
		{
			npc.state=OriginalState;
			npc.npc_attitude=OriginalAttitude;		
		}
		base.CancelEffect ();
	}
}

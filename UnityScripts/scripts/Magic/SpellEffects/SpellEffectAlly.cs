using UnityEngine;
using System.Collections;

public class SpellEffectAlly : SpellEffect {
	//Makes the npc an ally of the player.
		public int OriginalState;
		public int OriginalAttitude;
		public NPC npc;
		public bool WasActive;
		public override void ApplyEffect ()
		{
			if ((this.GetComponent<SpellEffectConfusion>()==null) && (this.GetComponent<SpellEffectFear>()==null))
			{//Only one or the other.
				npc=this.GetComponent<NPC>();
				if (npc!=null)
				{
					OriginalState= npc.state;
					OriginalAttitude=npc.npc_attitude;
					npc.state=NPC.AI_STATE_STANDING;	//Temporarily just wander around
					npc.npc_attitude=NPC.AI_ATTITUDE_MELLOW;
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


using UnityEngine;
using System.Collections;
/// <summary>
/// Makes the npc an ally of the player.
/// </summary>
public class SpellEffectAlly : SpellEffect {
		/// Backup the original state of the Npc
		//public int OriginalState;
		/// Backup the original attitude and goals of the npc
		public short OriginalAttitude;
		public short OriginalGtarg;
		public short OriginalGoal;

		private NPC npc;
		public bool WasActive;

		/// <summary>
		/// Applies the effect.
		/// </summary>
		/// Sets the NPC attitude and states
		/// Does not apply if confused or afraid
		public override void ApplyEffect ()
		{
			if ((this.GetComponent<SpellEffectConfusion>()==null) && (this.GetComponent<SpellEffectFear>()==null))
			{//Only one or the other.
				npc=this.GetComponent<NPC>();
				if (npc!=null)
				{
					//OriginalState= npc.state;
					OriginalAttitude=npc.npc_attitude;
								OriginalGoal=npc.npc_goal;
								OriginalGtarg=npc.npc_gtarg;

					//npc.state=NPC.AI_STATE_STANDING;	//Temporarily just wander around
					npc.npc_attitude=NPC.AI_ATTITUDE_MELLOW;
								//Makes the NPC follow the player
								npc.npc_goal=3;
								npc.npc_gtarg=1;

					WasActive=true;
				}	
			}
			base.ApplyEffect();
		}

		public override void CancelEffect ()
		{
			if(WasActive==true)
			{
				//npc.state=OriginalState;
				npc.npc_attitude=OriginalAttitude;	
						npc.npc_goal=OriginalGoal;
						npc.npc_gtarg=OriginalGtarg;
			}
			base.CancelEffect ();
		}
}


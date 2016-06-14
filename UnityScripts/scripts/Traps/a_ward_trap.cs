using UnityEngine;
using System.Collections;

public class a_ward_trap : trap_base {
	//?
	/*
	 * Magic ward traps.
	 * NPC collides with one it will set off a spell property object.
	 */

	public SpellProp spellprop;//The spell properties of the ward.

	protected override void Start ()
		{
			base.Start ();
			this.gameObject.layer = LayerMask.NameToLayer("Ward");
		}

	void OnTriggerEnter(Collider other)
		{
			//Get the NPC that hit the ward
			NPC npc =other.gameObject.GetComponent<NPC>();

			if (npc!=null)//Has the collision hit an npc
			{
					spellprop.init();
					if(spellprop.BaseDamage!=0)
					{
							npc.ApplyAttack(spellprop.BaseDamage);
					}
					spellprop.onImpact(npc.transform);
					spellprop.onHit(npc.gameObject.GetComponent<ObjectInteraction>());
					Destroy (this.gameObject);
			}
		}
}

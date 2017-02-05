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
				spellprop.init(SpellEffect.UW1_Spell_Effect_RuneofWarding,GameWorldController.instance.playerUW.gameObject);
				if(spellprop.BaseDamage!=0)
				{
						npc.ApplyAttack(spellprop.BaseDamage);
				}
				spellprop.onImpact(npc.transform);
				spellprop.onHit(npc.gameObject.GetComponent<ObjectInteraction>());
				this.GetComponent<ObjectInteraction>().objectloaderinfo.InUseFlag=0;
				Destroy (this.gameObject);
			}
			else
			{
			if (other.gameObject.GetComponent<UWCharacter>())
				{
					spellprop.onImpactPlayer();
				}					
			}
		}
}

using UnityEngine;
using System.Collections;

public class SpellEffectFreezeTime : SpellEffect {
	//Pauses animations and movement for the npc
	public Animator anim;
	public int state;//THe state the npc was in before the spell was cast at them
	public override void ApplyEffect ()
	{
		this.GetComponent<NPC>().Frozen=true;
		state = this.GetComponent<NPC>().state;
		anim = this.GetComponent<NPC>().anim;
		if (anim!=null)
		{
			anim.enabled=false;
		}
		base.ApplyEffect ();
	}

	void Update()
	{
		this.GetComponent<NPC>().Frozen=true;
	}


	public override void CancelEffect ()
	{
		this.GetComponent<NPC>().Frozen=false;
		this.GetComponent<NPC>().CurrentAnim="";
		this.GetComponent<NPC>().currentState=-1;
		this.GetComponent<NPC>().state=state;
		if (anim!=null)
		{
				anim.enabled=true;
		}
		base.CancelEffect ();
	}
}

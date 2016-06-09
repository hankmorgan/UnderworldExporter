using UnityEngine;
using System.Collections;

public class SpellEffectFreezeTime : SpellEffect {
	//Pauses animations and movement for the npc
	public Animator anim;
	public override void ApplyEffect ()
	{
		this.GetComponent<NPC>().Frozen=true;
		anim = this.GetComponentInChildren<NPC>().anim;
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
		if (anim!=null)
		{
			anim.enabled=true;
			this.GetComponentInChildren<NPC>().CurrentAnim="";
			this.GetComponentInChildren<NPC>().currentState=-1;
		}
		base.CancelEffect ();
	}
}

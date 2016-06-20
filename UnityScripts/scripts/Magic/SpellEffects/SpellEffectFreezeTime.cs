using UnityEngine;
using System.Collections;

public class SpellEffectFreezeTime : SpellEffect {
	//Pauses animations and movement for the npc
	public Animator anim;
	public int state;//THe state the npc was in before the spell was cast at them
	public long Key;
	public bool isNPC;
	public override void ApplyEffect ()
	{
			if (isNPC)
			{
					this.GetComponent<NPC>().Frozen=true;
					state = this.GetComponent<NPC>().state;
					anim = this.GetComponent<NPC>().anim;
					if (anim!=null)
					{
							anim.enabled=false;
					}	
			}
				else
				{//Player applies the effect to other npcs?
						
				}

		base.ApplyEffect ();
	}

	void Update()
	{
				if (isNPC==true)
				{
						this.GetComponent<NPC>().Frozen=true;				
				}
		
	}


	public override void CancelEffect ()
	{
				if (isNPC==true)
				{
						this.GetComponent<NPC>().Frozen=false;
						this.GetComponent<NPC>().CurrentAnim="";
						this.GetComponent<NPC>().currentState=-1;
						this.GetComponent<NPC>().state=state;
						if (anim!=null)
						{
								anim.enabled=true;
						}
				}
				else
				{
						//Find npcs with this effect and key and cancel them.
						GameObject[] npcs= GameObject.FindGameObjectsWithTag("NPCs");
						for (int i = 0; i<=npcs.GetUpperBound(0); i++)
						{
								if( npcs[i].gameObject.GetComponent<SpellEffectFreezeTime>()!=null)
								{
										if  (npcs[i].gameObject.GetComponent<SpellEffectFreezeTime>().Key==Key)
										{
												npcs[i].gameObject.GetComponent<SpellEffectFreezeTime>().CancelEffect();	
										}
								}
						}
				}


		base.CancelEffect ();
	}
}

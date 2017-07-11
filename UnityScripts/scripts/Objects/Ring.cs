using UnityEngine;
using System.Collections;

public class Ring : enchantment_base {

	public SpellEffect SpellEffectApplied;
	
	public override bool EquipEvent (short slotNo)
	{
		if ((slotNo ==9) || (slotNo ==10))
		{
			if (objInt().isEnchanted()==true)
			{
				//cast enchantment.
				SpellEffectApplied = GameWorldController.instance.playerUW.PlayerMagic.CastEnchantment(GameWorldController.instance.playerUW.gameObject,null,GetActualSpellIndex(),Magic.SpellRule_TargetSelf);
				if (SpellEffectApplied!=null)
				{
					SpellEffectApplied.SetPermanent(true);
				}
			}
		}
		return true;
	}

	public override bool UnEquipEvent (short slotNo)
	{
		if (((slotNo ==9) || (slotNo ==10)) && (objInt().item_id!=54))//Not the ring of humility
		{
		if (SpellEffectApplied!=null)
			{
				SpellEffectApplied.CancelEffect();
				return true;
			}
		}
		return false;
	}

	public override bool use ()
	{//Has no use event
		return false;
	}
}

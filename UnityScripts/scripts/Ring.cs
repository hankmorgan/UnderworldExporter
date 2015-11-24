using UnityEngine;
using System.Collections;

public class Ring : enchantment_base {

	public SpellEffect SpellEffectApplied;
	public override bool EquipEvent (int slotNo)
	{
		if ((slotNo ==9) || (slotNo ==10))
		{
			if (objInt.isEnchanted==true)
			{
				//cast enchantment.
				SpellEffectApplied = playerUW.PlayerMagic.CastEnchantment(playerUW.gameObject,GetActualSpellIndex());
				if (SpellEffectApplied!=null)
				{
					SpellEffectApplied.SetPermanent(true);
				}
			}
		}
		return true;
	}

	public override bool UnEquipEvent (int slotNo)
	{
		if ((slotNo ==9) || (slotNo ==10))
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

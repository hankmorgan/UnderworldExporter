using UnityEngine;
using System.Collections;

public class Weapon : Equipment {

	public SpellEffect SpellEffectApplied;

	public int Skill;
	//public int Durability;
	public int Slash;
	public int Bash;
	public int Stab;

	public override bool EquipEvent (int slotNo)
	{
		if (((slotNo ==7) && (playerUW.isLefty==false)) || ((slotNo ==8) && (playerUW.isLefty==true)))
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
		if ((slotNo ==7) || (slotNo ==8))
		{
			if (SpellEffectApplied!=null)
			{
				SpellEffectApplied.CancelEffect();
				return true;
			}
		}
		return false;
	}



}

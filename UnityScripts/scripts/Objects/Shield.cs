using UnityEngine;
using System.Collections;

public class Shield : Equipment {
	public SpellEffect SpellEffectApplied;
	public int ProtectionBonus;
	public int ToughnessBonus;

	public override int GetActualSpellIndex ()
	{
		return objInt().link-512;
	}


	public override bool EquipEvent (int slotNo)
	{		
		if (((slotNo ==7) && (GameWorldController.instance.playerUW.isLefty==true)) || ((slotNo ==8) && (GameWorldController.instance.playerUW.isLefty==false)))//Only on off hand
		{
			UpdateQuality();
			if (objInt().isEnchanted()==true)
			{
				int EffectId=GetActualSpellIndex ();
				switch (EffectId)
				{
				case SpellEffect.UW1_Spell_Effect_MinorProtection:
				case SpellEffect.UW1_Spell_Effect_Protection:
				case SpellEffect.UW1_Spell_Effect_AdditionalProtection:
				case SpellEffect.UW1_Spell_Effect_MajorProtection:
				case SpellEffect.UW1_Spell_Effect_GreatProtection:
				case SpellEffect.UW1_Spell_Effect_VeryGreatProtection:
				case SpellEffect.UW1_Spell_Effect_TremendousProtection:
				case SpellEffect.UW1_Spell_Effect_UnsurpassedProtection:
					ProtectionBonus=EffectId-463;
					break;
				case SpellEffect.UW1_Spell_Effect_MinorToughness:
				case SpellEffect.UW1_Spell_Effect_Toughness:
				case SpellEffect.UW1_Spell_Effect_AdditionalToughness:
				case SpellEffect.UW1_Spell_Effect_MajorToughness:
				case SpellEffect.UW1_Spell_Effect_GreatToughness:
				case SpellEffect.UW1_Spell_Effect_VeryGreatToughness:
				case SpellEffect.UW1_Spell_Effect_TremendousToughness:
				case SpellEffect.UW1_Spell_Effect_UnsurpassedToughness:
					ToughnessBonus=EffectId-471;
					break;
					
				default:
					//cast enchantment.
					SpellEffectApplied = GameWorldController.instance.playerUW.PlayerMagic.CastEnchantment(GameWorldController.instance.playerUW.gameObject,null,GetActualSpellIndex(),Magic.SpellRule_TargetSelf);
					if (SpellEffectApplied!=null)
					{
						SpellEffectApplied.SetPermanent(true);
					}
					break;
				}
			}
		}
		return true;
	}
}

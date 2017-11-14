using UnityEngine;
using System.Collections;

public class Shield : Equipment {
	public SpellEffect SpellEffectApplied;
	//public int ProtectionBonus;
	//public int ToughnessBonus;

	public override int GetActualSpellIndex ()
	{
		if (_RES==GAME_UW2)
		{
			return objInt().link-240;
		}
		else
		{
			return objInt().link-512;				
		}		
	}


	public override bool EquipEvent (short slotNo)
	{		
		if (((slotNo ==7) && (UWCharacter.Instance.isLefty==true)) || ((slotNo ==8) && (UWCharacter.Instance.isLefty==false)))//Only on off hand
		{
			UpdateQuality();
			if (objInt().isEnchanted()==true)
			{
				switch(_RES)
				{
				case GAME_UW2:
					{
						int EffectId=GetActualSpellIndex ();
						switch(EffectId)
						{
						case SpellEffect.UW2_Spell_Effect_MinorProtection:
						case SpellEffect.UW2_Spell_Effect_Protection:
						case SpellEffect.UW2_Spell_Effect_AdditionalProtection:
						case SpellEffect.UW2_Spell_Effect_MajorProtection:
						case SpellEffect.UW2_Spell_Effect_GreatProtection:
						case SpellEffect.UW2_Spell_Effect_VeryGreatProtection:
						case SpellEffect.UW2_Spell_Effect_TremendousProtection:
						case SpellEffect.UW2_Spell_Effect_UnsurpassedProtection:
								break;
						case SpellEffect.UW2_Spell_Effect_MinorToughness:
						case SpellEffect.UW2_Spell_Effect_Toughness:
						case SpellEffect.UW2_Spell_Effect_AdditionalToughness:
						case SpellEffect.UW2_Spell_Effect_MajorToughness:
						case SpellEffect.UW2_Spell_Effect_GreatToughness:
						case SpellEffect.UW2_Spell_Effect_VeryGreatToughness:
						case SpellEffect.UW2_Spell_Effect_TremendousToughness:
						case SpellEffect.UW2_Spell_Effect_UnsurpassedToughness:
								break;
						default:
							//cast enchantment.
							SpellEffectApplied = UWCharacter.Instance.PlayerMagic.CastEnchantment(UWCharacter.Instance.gameObject,null,GetActualSpellIndex(),Magic.SpellRule_TargetSelf);
							if (SpellEffectApplied!=null)
							{
								SpellEffectApplied.SetPermanent(true);
							}
							break;
						}
						break;
					}
				

				default:
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
									//ProtectionBonus=(short)(EffectId-463);
									break;
							case SpellEffect.UW1_Spell_Effect_MinorToughness:
							case SpellEffect.UW1_Spell_Effect_Toughness:
							case SpellEffect.UW1_Spell_Effect_AdditionalToughness:
							case SpellEffect.UW1_Spell_Effect_MajorToughness:
							case SpellEffect.UW1_Spell_Effect_GreatToughness:
							case SpellEffect.UW1_Spell_Effect_VeryGreatToughness:
							case SpellEffect.UW1_Spell_Effect_TremendousToughness:
							case SpellEffect.UW1_Spell_Effect_UnsurpassedToughness:
									//ToughnessBonus=(short)(EffectId-471);
									break;
							default:
									//cast enchantment.
									SpellEffectApplied = UWCharacter.Instance.PlayerMagic.CastEnchantment(UWCharacter.Instance.gameObject,null,GetActualSpellIndex(),Magic.SpellRule_TargetSelf);
									if (SpellEffectApplied!=null)
									{
											SpellEffectApplied.SetPermanent(true);
									}
									break;
							}
						break;
					}
				}
			}
		}
		return true;
	}
}



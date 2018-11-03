using UnityEngine;
using System.Collections;

public class a_spelltrap : trap_base {
    //0186  a_spelltrap
    //	fields "quality" and "owner" determine spell type.

    public override void ExecuteTrap (object_base src, int triggerX, int triggerY, int State)
	{
        switch (_RES)
        {
            case GAME_UW2:
                {
                    switch (GetSpellIndex())
                    {
                        case SpellEffect.UW2_Spell_Effect_Hallucination:
                        case SpellEffect.UW2_Spell_Effect_Hallucination_alt01:
                            UWCharacter.Instance.PlayerMagic.CastEnchantment(this.gameObject, null, GetSpellIndex(), Magic.SpellRule_TargetSelf, Magic.SpellRule_Immediate);
                            return;
                    }                    
                    break;
                }
        }
        UWCharacter.Instance.PlayerMagic.CastEnchantment(this.gameObject, null, GetSpellIndex(), Magic.SpellRule_TargetVector, Magic.SpellRule_Immediate);

    }

	/// <summary>
	/// Gets the index of the spell. This is used for wands as well
	/// </summary>
	/// <returns>The spell index.</returns>
	public int GetSpellIndex()
	{
		return ((quality & 0xf)<<4) | (owner & 0xf);//<-Sometimes if the owner if 5 bits then that extra bit is respected. Eg uw2 dreams cast by spell trap. (effect id 232 for example!!)
	}

}

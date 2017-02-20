using UnityEngine;
using System.Collections;

public class a_spelltrap : trap_base {
	//0186  a_spelltrap
	//	fields "quality" and "owner" determine spell type.
	public override void ExecuteTrap (int triggerX, int triggerY, int State)
	{
		//int spellindex = ((objInt().quality & 0xf)<<4) | (objInt().owner & 0xf) ;
		//	Debug.Log ("casting spelleffect " + spellindex);
		GameWorldController.instance.playerUW.PlayerMagic.CastEnchantment(this.gameObject,null,GetSpellIndex(),Magic.SpellRule_TargetVector);
	}

	/// <summary>
	/// Gets the index of the spell. This is used for wands as well
	/// </summary>
	/// <returns>The spell index.</returns>
	public int GetSpellIndex()
	{
		return ((objInt().quality & 0xf)<<4) | (objInt().owner & 0xf);
	}

}

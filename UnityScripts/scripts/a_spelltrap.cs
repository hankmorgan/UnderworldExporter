using UnityEngine;
using System.Collections;

public class a_spelltrap : trap_base {
	//0186  a_spelltrap
	//	fields "quality" and "quantity" determine spell type.
	public override void ExecuteTrap (int triggerX, int triggerY, int State)
	{
		int spellindex = ((objInt.Quality & 0xf)<<4) | (objInt.Owner & 0xf) ;
		//	Debug.Log ("casting spelleffect " + spellindex);
		playerUW.PlayerMagic.CastEnchantment(this.gameObject,null,spellindex,Magic.SpellRule_TargetVector);
	}
}

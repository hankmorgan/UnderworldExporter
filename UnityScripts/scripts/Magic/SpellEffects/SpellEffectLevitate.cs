using UnityEngine;
using System.Collections;

public class SpellEffectLevitate : SpellEffect {
	

	
	public override void ApplyEffect ()
	{

		if (playerUW==null)
		{
			playerUW= this.GetComponent<UWCharacter>();
		}
		playerUW.isFlying=true;

		base.ApplyEffect();
	}
	
	public override void CancelEffect ()
	{
		playerUW.isFlying=false;
		//TODO:The effect changes to a slow fall
		base.CancelEffect();
		playerUW.isFloating=true;
		playerUW.PlayerMagic.CastEnchantment(playerUW.gameObject,null,SpellEffect.UW1_Spell_Effect_SlowFall,Magic.SpellRule_TargetSelf);
	}
	
	void Update()
	{
		if (Active)
		{
			playerUW.isFlying=true;
		}
	}
}

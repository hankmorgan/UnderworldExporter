using UnityEngine;
using System.Collections;
/// <summary>
/// Makes the player fly
/// </summary>
public class SpellEffectLevitate : SpellEffect {
	public float flySpeed=1.0f;
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
		//The effect changes to a slow fall
		base.CancelEffect();
		playerUW.isFloating=true;
		playerUW.flySpeed=0;
		playerUW.PlayerMagic.CastEnchantment(playerUW.gameObject,null,SpellEffect.UW1_Spell_Effect_SlowFall,Magic.SpellRule_TargetSelf);
	}
	
	public virtual void Update()
	{
		if (Active)
		{
			if (playerUW.flySpeed <= flySpeed)
			{
				playerUW.flySpeed=flySpeed;
			}
			playerUW.isFlying=true;
		}
	}
}

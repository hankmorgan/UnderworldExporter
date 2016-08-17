using UnityEngine;
using System.Collections;
/// <summary>
/// Makes the player fly
/// </summary>
public class SpellEffectLevitate : SpellEffect {
	public float flySpeed=1.0f;
	public override void ApplyEffect ()
	{
		if (GameWorldController.instance.playerUW==null)
		{
			GameWorldController.instance.playerUW= this.GetComponent<UWCharacter>();
		}
		GameWorldController.instance.playerUW.isFlying=true;

		base.ApplyEffect();
	}
	
	public override void CancelEffect ()
	{
		GameWorldController.instance.playerUW.isFlying=false;
		//The effect changes to a slow fall
		base.CancelEffect();
		if (!Permanent)
		{//Only allow floating when not an equipment effect.
				GameWorldController.instance.playerUW.isFloating=true;				
				GameWorldController.instance.playerUW.PlayerMagic.CastEnchantment(GameWorldController.instance.playerUW.gameObject,null,SpellEffect.UW1_Spell_Effect_SlowFall,Magic.SpellRule_TargetSelf);
		}		
		GameWorldController.instance.playerUW.flySpeed=0;		
	}
	
	public virtual void Update()
	{
		if (Active)
		{
			if (GameWorldController.instance.playerUW.flySpeed <= flySpeed)
			{
				GameWorldController.instance.playerUW.flySpeed=flySpeed;
			}
			GameWorldController.instance.playerUW.isFlying=true;
		}
	}
}

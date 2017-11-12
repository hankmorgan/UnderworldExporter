using UnityEngine;
using System.Collections;
/// <summary>
/// Makes the player fly
/// </summary>
public class SpellEffectLevitate : SpellEffect {
	public float flySpeed=1.0f;
	public override void ApplyEffect ()
	{
		if (UWCharacter.Instance==null)
		{
			UWCharacter.Instance= this.GetComponent<UWCharacter>();
		}
		UWCharacter.Instance.isFlying=true;

		base.ApplyEffect();
	}
	
	public override void CancelEffect ()
	{
		UWCharacter.Instance.isFlying=false;
		//The effect changes to a slow fall
		base.CancelEffect();
		if (!Permanent)
		{//Only allow floating when not an equipment effect.
				UWCharacter.Instance.isFloating=true;	
				if (_RES==GAME_UW2)
				{
					UWCharacter.Instance.PlayerMagic.CastEnchantment(UWCharacter.Instance.gameObject,null,SpellEffect.UW2_Spell_Effect_SlowFall,Magic.SpellRule_TargetSelf);
				}
				else
				{
					UWCharacter.Instance.PlayerMagic.CastEnchantment(UWCharacter.Instance.gameObject,null,SpellEffect.UW1_Spell_Effect_SlowFall,Magic.SpellRule_TargetSelf);				
				}
				
		}		
		UWCharacter.Instance.flySpeed=0;		
	}
	
	public virtual void Update()
	{
		if (Active)
		{
			if (UWCharacter.Instance.flySpeed <= flySpeed)
			{
				UWCharacter.Instance.flySpeed=flySpeed;
			}
			UWCharacter.Instance.isFlying=true;
		}
	}
}

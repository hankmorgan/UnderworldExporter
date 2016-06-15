using UnityEngine;
using System.Collections;

public class SpellProp : MonoBehaviour {
	/*
	 * SpellProp.cs 
	 * 
	 * Properties for spells. Mainly used for projectile spells.
	 * 
	 */


	public int BaseDamage;//How much damage the spell applies.
	public int counter; //How long the spell effect lasts
	public int DOT;//What damage over time the spell effect has.
	public int noOfCasts=1; //How many interations 
	public float spread; //How the spell projectile is spread in a cone.
	public float Force; //What force is applied to the projectile.

	public string ProjectileSprite;
	public int impactFrameStart;//What impact image is played on a miss.
	public int impactFrameEnd;//What impact image is played on a miss.
	public static UWCharacter playerUW;

	void Start()
	{
		init();
	}

	public virtual void init()
	{
		//Set spell variables

		//Init the spelleffect applied by the spell.
	}

	public virtual void onImpact(Transform tf)
	{
	//Code to run when it hits anything. eg for explosions	
	}

	public virtual void onHit(ObjectInteraction objInt)
	{//Actions to take when the projectile hits a specific object.

	}

	public virtual void onHitPlayer()
	{//Special code to fire when the projectile hits the player.
			
	}

	public virtual void onImpactPlayer()
	{//Special code for when the player trips this spell. Used in rune traps (UW2)
			
	}


	/* ************Sample enchantment Code *********************
	public override void onHit (ObjectInteraction objInt)
	{//Sample enchantment poisons the target.
	if (objInt.ItemType==ObjectInteraction.NPC_TYPE)
		{
			playerUW.PlayerMagic.CastEnchantment(playerUW.gameObject,objInt.gameObject,SpellEffect.UW1_Spell_Effect_Poison,Magic.SpellRule_TargetOther);				
		}		
	}
	*/
}

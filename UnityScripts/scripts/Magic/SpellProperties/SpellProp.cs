using UnityEngine;
using System.Collections;

public class SpellProp : MonoBehaviour {
//Properties for spells. Mainly used for projectile spells that have no unique code.

	public int BaseDamage;//How much damage the spell applies.
	//private SpellEffect spelleffect;//What spell effect the spell has.
	public int counter; //How long the spell effect lasts
	public int DOT;//What damage over time the spell effect has.
	public int noOfCasts=1; //How many interations 
	public float spread; //How the spell projectile is spread in a cone.
	public float Force; //What force is applied to the projectile.

	public string ProjectileSprite;
	public int impactFrameStart;//What impact image is played on a miss.
	public int impactFrameEnd;//What impact image is played on a miss.
	public static UWCharacter playerUW;

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
}

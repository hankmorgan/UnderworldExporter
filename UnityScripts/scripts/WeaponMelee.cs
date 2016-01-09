using UnityEngine;
using System.Collections;

public class WeaponMelee : Weapon {

	public int Skill;
	//public int Durability;
	public int Slash;
	public int Bash;
	public int Stab;



	public virtual void onHit(GameObject target)
	{//Apply any posible magic effects when the weapon strikes.
		if (objInt.isEnchanted==true)
		{
			int EffectId = GetActualSpellIndex ();
			if (EffectId<=447)
			{//Not a standard effect
				//Debug.Log ("Casting + "+EffectId + " on " + target.name);
				playerUW.PlayerMagic.CastEnchantmentImmediate(playerUW.gameObject,target,EffectId,Magic.SpellRule_TargetOther);
			}
		}
	}


}

using UnityEngine;
using System.Collections;

/// <summary>
/// Melee Weapons.
/// </summary>
public class WeaponMelee : Weapon {

	/// <summary>
	/// Apply any possible magic effects when the weapon strikes.
	/// </summary>
	/// <param name="target">The entity that is hit by the weapon</param>
	public virtual void onHit(GameObject target)
	{
		if (objInt().isEnchanted()==true)
		{
			int EffectId = GetActualSpellIndex ();
			if (EffectId<=447)
			{//Not a standard effect
				GameWorldController.instance.playerUW.PlayerMagic.CastEnchantmentImmediate(GameWorldController.instance.playerUW.gameObject,target,EffectId,Magic.SpellRule_TargetOther);
			}
		}
	}

		/// <summary>
		/// Gets the slash base damage
		/// </summary>
		/// <returns>The slash damage</returns>
		public int GetSlash()
		{
			return GameWorldController.instance.weaponprops.getPropSlash(objInt().item_id);
		}

		/// <summary>
		/// Gets the bash base damage
		/// </summary>
		/// <returns>The bash damage</returns>
		public int GetBash()
		{
			return GameWorldController.instance.weaponprops.getPropBash(objInt().item_id);
		}

		/// <summary>
		/// Gets the stab damage
		/// </summary>
		/// <returns>The stab damage</returns>
		public int GetStab()
		{
			return GameWorldController.instance.weaponprops.getPropStab(objInt().item_id);
		}

		/// <summary>
		/// Gets the durability of the weapon.
		/// </summary>
		/// <returns>The durability.</returns>
		public int GetDurability()
		{
			return GameWorldController.instance.weaponprops.getPropDurability(objInt().item_id);	
		}


		/// <summary>
		/// Gets the melee slash value
		/// </summary>
		/// <returns>The melee slash.</returns>
		public static int getMeleeSlash()
		{
			return GameWorldController.instance.weaponprops.getPropSlash(15);	
		}

		/// <summary>
		/// Gets the melee bash value
		/// </summary>
		/// <returns>The melee bash.</returns>
		public static int getMeleeBash()
		{
			return GameWorldController.instance.weaponprops.getPropBash(15);		
		}

		/// <summary>
		/// Gets the melee stab value.
		/// </summary>
		/// <returns>The melee stab.</returns>
		public static int getMeleeStab()
		{
			return GameWorldController.instance.weaponprops.getPropStab(15);	
		}

		/// <summary>
		/// Gets the skill that this weapon uses
		/// </summary>
		/// <returns>The skill.</returns>
		public int GetSkill()
		{
			return GameWorldController.instance.weaponprops.getPropSkill(objInt().item_id);
		}

}

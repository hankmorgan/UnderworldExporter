using UnityEngine;
using System.Collections;

/// <summary>
/// Base Class for combat related logic (player side)
/// Combat is the animation of weapon swings, attack charging and attack execution.
/// </summary>
public class Combat : MonoBehaviour {

	/// How far a melee attack is raycast from the player.
	protected float weaponRange=1.0f;
	/// Is the player charging an attack.
	public bool AttackCharging; 
	/// Is the player currently releasing an attack. IE playing their animation.
	public bool AttackExecuting; 
	/// The current charge of the attack.
	public float Charge;  
	/// The rate per second that the attack charge increases by. 
	public float chargeRate=33.0f;



	/// <summary>
	/// Processing of the player combat idle state.
	/// Sets the weapon animation in use when idle.
	/// </summary>
	public virtual void PlayerCombatIdle()
	{
		return;
	}

	/// <summary>
	/// Begins combat for the player
	/// </summary>
	public virtual void CombatBegin()
	{
		return;
	}

	/// <summary>
	/// Charging of melee weapon attacks.
	/// </summary>
	public virtual void CombatCharging()
	{
		return;
	}


	/// <summary>
	/// Execution of ranged attacks
	/// </summary>
	public virtual void ExecuteRanged(float charge)
	{
		return;
	}

	/// <summary>
	/// Releases the attack.
	/// </summary>
	public virtual void ReleaseAttack()
	{
		return;
	}

	/// <summary>
	/// Executes the melee attack after the attack has been released.
	/// </summary>
	public virtual IEnumerator ExecuteMelee(string StrikeType, float StrikeCharge)
	{
		yield break;
	}
}
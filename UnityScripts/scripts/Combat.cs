using UnityEngine;
using System.Collections;

public class Combat : MonoBehaviour {
	//Base Class for combat related logic (player side)
	//Combat variables
	public float weaponRange=1.0f;
	public bool AttackCharging;
	public bool AttackExecuting;
	public float Charge;
	public float chargeRate=33.0f;

	public WeaponAnimation wpa;

	void Start()
	{
		wpa = GameObject.Find ("HudAnimations").GetComponentInChildren<WeaponAnimation>();
	}

	public virtual void PlayerCombatUpdate()
	{//The processing of combat activity
		return;
	}


	public virtual void MeleeBegin()
	{
		return;
	}


	public virtual void MeleeCharging()
	{
		return;
	}

	public virtual IEnumerator ExecuteMelee()
	{
		yield break;
	}


	public virtual void MeleeExecute()
	{
		return;
	}

	public virtual  void AttackModeMelee()
	{
		return;
	}
}




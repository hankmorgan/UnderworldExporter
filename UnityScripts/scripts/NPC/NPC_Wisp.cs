using UnityEngine;
using System.Collections;

/// <summary>
/// NPC wisp in the ethereal void. Is not really an NPC but an animated decoration
/// </summary>
public class NPC_Wisp : NPC {

	/// <summary>
	/// NPC Does not need a start like NPcs
	/// </summary>
	protected override void Start ()
	{
		npc_whoami=48;//Wisp conversation.
	}

	/// <summary>
	/// NPC Door update is not required.
	/// </summary>
	public override void Update() 
	{
		//base.Update ();
	}

	public override bool ApplyAttack (short damage, GameObject source)
	{
		return true;
	}

	public override bool ApplyAttack (short damage)
	{
		return true;
	}
}

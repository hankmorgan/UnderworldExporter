using UnityEngine;
using System.Collections;
/// <summary>
/// Special case to support conversation with the talking door
/// </summary>
public class NPC_Door : NPC {

	/// <summary>
	/// NPC Does not need a start like NPcs
	/// </summary>
	protected override void Start ()
	{
		//this.gameObject.tag="NPCs";
	}

	/// <summary>
	/// NPC Door update is not required.
	/// </summary>
	public override void Update() 
	{
		//base.Update ();
	}
}

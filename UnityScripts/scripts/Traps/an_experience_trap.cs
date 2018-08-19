using UnityEngine;
using System.Collections;
/// <summary>
/// An experience trap.
/// </summary>
///Adds experience points to the character. 
/// I'm guessing the value in owner.
public class an_experience_trap : trap_base {
	
	public override void ExecuteTrap (object_base src, int triggerX, int triggerY, int State)
	{
		UWCharacter.Instance.AddXP(owner);
	}
}

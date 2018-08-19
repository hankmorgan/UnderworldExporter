using UnityEngine;
using System.Collections;

public class a_skill_trap : trap_base {

		//Does a skill check?
		//Quality is the skill to check

		//It is used in level 2 of the prison tower when the guards are annoyed 
			//It's params are quality =17 (suggests picklock)
			//Owner = 7 (min score?)
			//Called by an unlock trigger

		//Does this mean the lock requires a skill of at least 7 in pick lock to open???
		//The subsequent trap (a trespass trap) had no effect when player stealth was 30


	public override void ExecuteTrap (object_base src, int triggerX, int triggerY, int State)
	{
		Debug.Log(this.name + " called with params q=" + quality + " o=" + owner);
		base.ExecuteTrap (src, triggerX, triggerY, State);
	}
}

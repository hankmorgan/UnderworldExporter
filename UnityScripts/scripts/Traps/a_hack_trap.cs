using UnityEngine;
using System.Collections;

public class a_hack_trap : trap_base {		
	//qual=5 is a trespass trap.
		//qual=10  is probably the awarding of class specific items at the start fof the game
		//qual = 12 is an oscillator row of tiles (i think)
		//qual=20 used for rising platforms on level 42 (scintilus)
	//qual=21 is the moving switches in loths tomb.
		//qual=24 is the same id as the bullfrog trap. Used in lvl 42 scint.

	//qual=25 is the bly scup chamber puzzle
		//qual=27 Removes the link from the target object
		//qual=28 is change tmap objects to use a different texture
		//qual =32 is the qbert puzzle in the void. - Used on both the pyramid and the teleports that take you to it (from red hell at least)
	//qual=35 is recharge light crystals	
		//qual =36. Called after first LB conversation. Moves all NPCs to their proper locations.
		//qual=39 is change object visability

	public override void ExecuteTrap (object_base src, int triggerX, int triggerY, int State)
	{
		Debug.Log ("Hack Trap " + this.name);
	}



}

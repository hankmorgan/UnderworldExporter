using UnityEngine;
using System.Collections;

public class a_hack_trap : trap_base {		
	//qual=5 is a trespass trap.
		//qual=10  is probably the awarding of class specific items at the start fof the game
		//qual = 12 is an oscillator row of tiles (i think)
		//qual = 14 cycles wall/floro colours in a room in talours
		//qual=20 used for rising platforms on level 42 (scintilus)
	//qual=21 is the moving switches in loths tomb.
		//qual=23 is a variant of the tmpa change
		//qual=24 is the same id as the bullfrog trap. Used in lvl 42 scint and the pits to change graffiti?
			
	//qual=25 is the bly scup chamber puzzle
		//qual=27 Removes the link from the target object
		//qual=28 is change tmap objects to use a different texture
		//Qual=29 is randomly flick buttons. (talorus 1)
		//qual=30 is the avatar is a coward trap in the pits
		//qual=31 something in the arena of fire?
		//qual =32 is the qbert puzzle in the void. - Used on both the pyramid and the teleports that take you to it (from red hell at least)
	//qual=35 is recharge light crystals	
		//qual =36. Called after first LB conversation. Moves all NPCs to their proper locations.
		//qual=39 is change object visability
		//qual=40 is the vending machine selection
		//qual=41 is the vending machine spawning
		//qual=42 is the vending machine sign (in uw1 is is the talking door!)
		//qual=44 is a go to sleep trap used by "bridge based" beds. (eg prison tower straw beds)

	public override void ExecuteTrap (object_base src, int triggerX, int triggerY, int State)
	{
		Debug.Log ("Hack Trap " + this.name);
	}



}

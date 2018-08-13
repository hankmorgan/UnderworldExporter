using UnityEngine;
using System.Collections;

public class a_hack_trap : trap_base {		
		//Hack trap is the term for a do_trap in UW2
		//qual=5 is a trespass trap.
		//qual=10  is probably the awarding of class specific items at the start fof the game
		//qual = 12 is an oscillator row of tiles (i think)  -unimplemented
		//qual = 14 cycles wall/floro colours in a room in talours
		//qual = 18 Scintillus 5 switch puzzle reset
		//qual = 19 scintullus 7 platform puzzle reset
		//qual=20 used for rising platforms on level 42 (scintilus)
		//qual=21 is the moving switches in loths tomb.  -unimplemented
		//qual=23 is a variant of the tmap change
		//qual=24 is the same id as the bullfrog trap. Used in lvl 42 scint and the pits to change graffiti.			
		//qual=25 is the bly scup chamber puzzle
		//qual=26 is the force field on scint level 5
		//qual=27 Removes the link from the target object   
		//qual=28 is change tmap objects to use a different texture
		//Qual=29 is randomly flick buttons. (talorus 1)
		//qual=30 if the avatar is a coward trap in the pits
		//qual=31 something in the arena of fire? unimplemented
		//qual=32 is the qbert puzzle in the void. - Used on both the pyramid and the teleports that take you to it (from red hell at least)
		//qual=33 is used to recycle empty bottles! 
		//qual=35 is recharge light crystals	
		//qual=36. Called after first LB conversation. Moves all NPCs to their proper locations. Possibly used to manage schedules. Only implemented for the first xclock 
        //qual=38 Used in the tombs to swap your potion of cure poison with a potion of poison (via a linked damage trap)
		//qual=39 is change object visability
		//qual=40 is the vending machine selection
		//qual=41 is the vending machine spawning
		//qual=42 is the vending machine sign (in uw1 is is the talking door!)
        //qual=43 is to change the goal of a (type) of Npc. Used in Tombs level 1 by the skeletons who attack when you pick up the map piece 
		//qual=44 is a go to sleep trap used by "bridge based" beds. (eg prison tower straw beds)
		//qual=50 is to trigger the conversation with the troll #251 in tybals lair after you are imprisoned.

	public override void ExecuteTrap (object_base src, int triggerX, int triggerY, int State)
	{
		Debug.Log ("Hack Trap " + this.name);
	}



}

using UnityEngine;
using System.Collections;

public class a_hack_trap : trap_base {		
	//qual=5 is a trespass trap.
		//qual=20 used for rising platforms on level 42 (scintilus)
	//qual=21 is the moving switches in loths tomb.
		//qual=24 is the same id as the bullfrog trap. Used in lvl 42 scint.

	//qual=25 is the bly scup chamber puzzle
		//qual=28 is change tmap objects to use a different texture
		//qual =32 is the qbert puzzle in the void. - Used on both the pyramid and the teleports that take you to it (from red hell at least)
	//qual=35 is recharge light crystals	

	public override void PostActivate ()
	{
		//no trap deletion
	}
}

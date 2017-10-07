using UnityEngine;
using System.Collections;

public class a_hack_trap : trap_base {		
	//qual=5 is a trespass trap.
	//qual=21 is the moving switches in loths tomb.
	//qual=25 is the bly scup chamber puzzle
		//qual=28 is change tmap objects to use a different texture
	//qual=35 is recharge light crystals	

	public override void PostActivate ()
	{
		//no trap deletion
	}
}

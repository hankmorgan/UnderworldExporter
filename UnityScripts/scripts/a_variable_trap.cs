using UnityEngine;
using System.Collections;

public class a_variable_trap : trap_base {


	//public int VariableIndex;
	public int VariableIndex;	//currObj.zpos
	public int VariableValue;	//((currObj.owner & 0x7) <<3) | (currObj.y ))
	public int heading;

	public override void PostActivate ()
	{
		//Do nothing. Stop trap from destroying itself.
	}

}

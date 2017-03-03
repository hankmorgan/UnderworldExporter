using UnityEngine;
using System.Collections;

public class a_variable_trap : trap_base {


	//public int VariableIndex;
	public int VariableIndex;	//currObj.zpos
	public int VariableValue;	//((currObj.owner & 0x7) <<3) | (currObj.y )) or maybe 
	public int heading;

		public void Start()
		{//INit the variables

				VariableIndex=objInt().zpos;
				VariableValue= ((objInt().quality & 0x3f)<<8) | (((objInt().owner & 0x1f) << 3) | (objInt().y));
				heading = objInt().heading/45;
		}


	public override void PostActivate ()
	{
		//Do nothing. Stop trap from destroying itself.
	}

}

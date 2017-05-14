using UnityEngine;
using System.Collections;

public class a_variable_trap : trap_base {
      //   field   bits in value
        //  ypos    0..2
       //   owner   3..7     (bit 5 of "owner" seems not to be used)
      //    quality 8..13

	//public int VariableIndex;
	public int VariableIndex;	//currObj.zpos
	public int VariableValue;	//((currObj.owner & 0x7) <<3) | (currObj.y )) or maybe 
	public int heading;


	protected override void Start ()
	{
			base.Start();
		//Init the variables

			VariableIndex=objInt().zpos;
			VariableValue= ((objInt().quality & 0x3f)<<8) | (((objInt().owner & 0x1f) << 3) | (objInt().y & 0x7));

			heading = objInt().heading/45;
	}


	public override void PostActivate ()
	{
		//Do nothing. Stop trap from destroying itself.
	}

}
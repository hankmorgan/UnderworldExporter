using UnityEngine;
using System.Collections;

public class a_change_from_trap : trap_base {
		//Theory. Untested 
		//This is used to change the tile type &  wall/floor texture on all tiles in a level.
		//The From trap defines the criteria
		//and the to trap defines the changes to make.


		//Heading seems to define a  floor texture to match for changing.
		//Nothing seems to define the range of tiles to change so it may be a global change
		//Therefore
		 	//Use the change_From trap to execute the changes using the values in the to trap.
			//Use the to trap as a placeholder to pass execution along in the link chain.
	


	public override void ExecuteTrap (object_base src, int triggerX, int triggerY, int State)
	{
				Debug.Log(this.name + "triggerX = " + triggerX + " triggerY = " + triggerY);
	}

}

using UnityEngine;
using System.Collections;

public class a_change_to_trap : trap_base {

		//Theory. Untested 
		//This is used to change the texture on a range of tiles. 
		//The From trap defines the start
		//and the to trap defines the end of the block.

		//Changing the owner changes the tile type (10 is open)
		//changing the zpos (bits 0-3) changes the tile heights
			//val=31 seems to leave tile the same as it was
		//heading and bit 4 of the zpos changes the texture of the floor	
		//quality changes the wall textures (63 is no change made)

		//See the from trap for implemenation of this trap pair.


		public override void ExecuteTrap (object_base src, int triggerX, int triggerY, int State)
		{
			Debug.Log(this.name + "triggerX = " + triggerX + " triggerY = " + triggerY);
		}

}

using UnityEngine;
using System.Collections;

public class a_hack_trap_qbert : a_hack_trap {

		//Trap used to control the qbert puzzle in the ethereal void.
		//qual=32

		//Takes a couple of parameters.
		//Owner = 0 //entrance teleport to pyramid from red hell. tells game you need to set a red pyramid.
		//owner = 2 //entrance from the blue zone
		//owner = 3 //entrance from the purple zone (stickman)
		//Owner = 4 //entrance from the green zone (maze)
		//Owner = 11 to 15 //Unknown usage possibly used for  other moongate destinations such as the sigil of binding or the shrine
		//owner = 16 //used in leaving the pyramid area and the sigil

		//Owner = 63 //Used in stepping on the pyramid, Most steps point to one of two traps with this owner value.


		//game variables 101 to 108 are used for this trap
}

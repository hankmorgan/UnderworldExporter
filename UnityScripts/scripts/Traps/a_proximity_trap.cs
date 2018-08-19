using System.Collections;
using UnityEngine;


/// <summary>
/// A proximity trap.
/// </summary>
/// This appears to behave as a move trigger rather than a trap.
/// Appears to fires when the player passes through the trigger plane along a range of owner by quality tiles.
public class a_proximity_trap : a_move_trigger {


	protected override void Start ()
	{
	boxDimensions= new Vector3(quality * 1.2f,0.2f,owner*1.2f);
	boxCenter = new Vector3(quality * 0.6f,0f,owner*0.6f);
	base.Start ();
	}

}

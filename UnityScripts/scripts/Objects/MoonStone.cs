using UnityEngine;
using System.Collections;
/// <summary>
/// Used by the Gate Travel spell as a teleport target
/// </summary>
public class MoonStone : object_base {

	protected override void Start ()
	{
		base.Start ();
		playerUW.MoonGateLevel = GameWorldController.instance.LevelNo;
	}

		/// <summary>
		/// Updates the location of the moonstone
		/// </summary>
		/// TODO: only update when position changes?
	void Update()
	{
		if (objInt().PickedUp==false)
		{
			playerUW.MoonGatePosition=this.transform.position;
		}
		else
		{
			playerUW.MoonGatePosition=Vector3.zero;
		}
	}
}

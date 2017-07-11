using UnityEngine;
using System.Collections;
/// <summary>
/// Used by the Gate Travel spell as a teleport target
/// </summary>
public class MoonStone : object_base {

	protected override void Start ()
	{
		base.Start ();
		GameWorldController.instance.playerUW.MoonGateLevel = (short)(GameWorldController.instance.LevelNo+1);
		GameWorldController.instance.playerUW.MoonGatePosition=this.transform.position;
	}

		/// <summary>
		/// Updates the location of the moonstone
		/// </summary>
		/// TODO: only update when position changes?
		/// Or find when on spell cast or Update when leaving level.
	void Update()
	{
		if (objInt().PickedUp==false)
		{
			GameWorldController.instance.playerUW.MoonGateLevel = (short)(GameWorldController.instance.LevelNo+1);
			GameWorldController.instance.playerUW.MoonGatePosition=this.transform.position;
		}
		else
		{
			GameWorldController.instance.playerUW.MoonGatePosition=Vector3.zero;
		}
	}


}

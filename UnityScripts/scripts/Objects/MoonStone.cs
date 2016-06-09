using UnityEngine;
using System.Collections;

public class MoonStone : object_base {


	protected override void Start ()
	{
		base.Start ();
		playerUW.MoonGateLevel = GameWorldController.instance.LevelNo;
	}

	void Update()
	{
		if (objInt.PickedUp==false)
		{
			playerUW.MoonGatePosition=this.transform.position;
		}
		else
		{
			playerUW.MoonGatePosition=Vector3.zero;
		}
	}
}

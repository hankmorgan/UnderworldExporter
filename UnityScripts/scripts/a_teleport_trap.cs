using UnityEngine;
using System.Collections;

public class a_teleport_trap : trap_base {
/*
0181  a_teleport trap
	teleports the player to another level and tile; destination level is
	given by "zpos" (0 means current level), tile x/y coordinates
	are given in "quality" and "owner" fields.
*/
	public int levelNo;
	public float targetX;
	public float targetY;
	public float targetZ;

	public override void ExecuteTrap (int triggerX, int triggerY, int State)
	{
		CheckReferences();
		if (levelNo==0)//At the moment ignore the level teleport.
		{
			playerUW.gameObject.transform.position = new Vector3(targetX,targetZ+0.3f,targetY);
		}
		else
		{
			Debug.Log ("teleporting to level " + levelNo);
		}
	}

	public override void PostActivate ()
	{//Prevent deletion of the trap

	}
}

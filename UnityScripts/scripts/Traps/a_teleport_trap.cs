using UnityEngine;
using System.Collections;

public class a_teleport_trap : trap_base {
/*
0181  a_teleport trap
	teleports the player to another level and tile; destination level is
	given by "zpos" (0 means current level), tile x/y coordinates
	are given in "quality" and "owner" fields.
*/
	//public int levelNo;
	//public float targetX;
	//public float targetY;
	//public float targetZ;

	public override void ExecuteTrap (int triggerX, int triggerY, int State)
	{
		float targetX=(float)objInt().quality*1.2f + 0.6f;
		float targetY= (float)objInt().owner*1.2f + 0.6f;
		if (objInt().zpos==0)
		{//Stay on this level.
			float Height = ((float)(GameWorldController.instance.currentTileMap().GetFloorHeight(objInt().quality,objInt().owner)))*0.15f;
			GameWorldController.instance.playerUW.gameObject.transform.position = new Vector3(targetX,Height+0.3f,targetY);
		}
		else
		{
			//Goto to another level
			GameWorldController.instance.SwitchLevel(objInt().zpos-1,objInt().quality,objInt().owner);
		}
	}

	public override void PostActivate ()
	{//Prevent deletion of the trap

	}
}

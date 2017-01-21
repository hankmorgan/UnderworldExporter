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
		//CheckReferences();
		if (levelNo==0)
		{
			GameWorldController.instance.playerUW.gameObject.transform.position = new Vector3(targetX,targetZ+0.3f,targetY);
								}
		else
		{
			float TileHeight = (float)GameWorldController.instance.Tilemap.GetFloorHeight(levelNo-1,objInt().Quality,objInt().Owner);
			float posNewTile =(TileHeight+1) * 0.15f ;

			//GameWorldController.instance.playerUW.gameObject.transform.position = new Vector3(targetX,targetZ+0.3f,targetY);
			GameWorldController.instance.playerUW.gameObject.transform.position = new Vector3(targetX,posNewTile,targetY);
			GameWorldController.instance.SwitchLevel(levelNo-1);
						//Move to the level height

			//Debug.Log ("teleporting to level " + (levelNo-1));
			//RoomManager.LoadRoom(levelNo.ToString());
		}
	}

	public override void PostActivate ()
	{//Prevent deletion of the trap

	}
}

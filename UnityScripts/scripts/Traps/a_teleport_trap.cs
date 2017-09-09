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

	public override void ExecuteTrap (object_base src, int triggerX, int triggerY, int State)
	{
		if (_RES==GAME_UWDEMO)
		{
			if (objInt().zpos!=0)
			{
				ExecuteForUWDemo();
				return;
			}
				//Special case for the UW Demo.
		}
		//Debug.Log (this.name);
		if (EditorMode)
		{
			return;
		}
		if ((_RES==GAME_UW2) && (GameWorldController.instance.playerUW.JustTeleported))
		{//To stop infinite level transitions in UW2
			GameWorldController.instance.playerUW.JustTeleported=false;
			return;
		}

		float targetX=(float)objInt().quality*1.2f + 0.6f;
		float targetY= (float)objInt().owner*1.2f + 0.6f;


		GameWorldController.instance.playerUW.JustTeleported=true;	
		GameWorldController.instance.playerUW.teleportedTimer=0f;
		if (objInt().zpos==0)
		{//Stay on this level.
			float Height = ((float)(GameWorldController.instance.currentTileMap().GetFloorHeight(objInt().quality,objInt().owner)))*0.15f;
			GameWorldController.instance.playerUW.transform.position = new Vector3(targetX,Height+0.3f,targetY);
			GameWorldController.instance.playerUW.TeleportPosition=GameWorldController.instance.playerUW.transform.position;
		}
		else
		{
			GameWorldController.instance.playerUW.teleportedTimer=-1f;//Longer wait period when travelling between levels.
			//Goto to another level
			if (_RES==GAME_UW1)
			{//Special case for the magic drain effect in UW1
				if (GameWorldController.instance.playerUW.PlayerMagic.MaxMana<GameWorldController.instance.playerUW.PlayerMagic.TrueMaxMana)
				{
					GameWorldController.instance.playerUW.PlayerMagic.MaxMana=GameWorldController.instance.playerUW.PlayerMagic.TrueMaxMana;
					if (GameWorldController.instance.playerUW.PlayerMagic.CurMana==0)
					{
						GameWorldController.instance.playerUW.PlayerMagic.CurMana = GameWorldController.instance.playerUW.PlayerMagic.MaxMana/4;
					}
				}
			}
			GameWorldController.instance.playerUW.playerMotor.movement.velocity=Vector3.zero;
			GameWorldController.instance.SwitchLevel((short)(objInt().zpos-1),objInt().quality,objInt().owner);
		}
	}

		public void ExecuteForUWDemo()
		{//IN the UW demo the level transition 
				UWHUD.instance.MessageScroll.Add("You have reached level 2 of the Underworld. This level is not in the demo.");
		}

	public override void PostActivate ()
	{//Prevent deletion of the trap

	}
}

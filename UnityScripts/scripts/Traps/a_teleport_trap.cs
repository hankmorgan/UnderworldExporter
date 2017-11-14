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
		if ((_RES==GAME_UW2) && (UWCharacter.Instance.JustTeleported))
		{//To stop infinite level transitions in UW2
			//UWCharacter.Instance.JustTeleported=false;
			return;
		}

		float targetX=(float)objInt().quality*1.2f + 0.6f;
		float targetY= (float)objInt().owner*1.2f + 0.6f;


		UWCharacter.Instance.JustTeleported=true;	
		UWCharacter.Instance.teleportedTimer=0f;
		if (objInt().zpos==0)
		{//Stay on this level.
			float Height = ((float)(GameWorldController.instance.currentTileMap().GetFloorHeight(objInt().quality,objInt().owner)))*0.15f;
			UWCharacter.Instance.transform.position = new Vector3(targetX,Height+0.3f,targetY);
			UWCharacter.Instance.TeleportPosition=UWCharacter.Instance.transform.position;
		}
		else
		{
			UWCharacter.Instance.teleportedTimer=-1f;//Longer wait period when travelling between levels.
			//Goto to another level
			if (_RES==GAME_UW1)
			{//Special case for the magic drain effect in UW1
				if (UWCharacter.Instance.PlayerMagic.MaxMana<UWCharacter.Instance.PlayerMagic.TrueMaxMana)
				{
					UWCharacter.Instance.PlayerMagic.MaxMana=UWCharacter.Instance.PlayerMagic.TrueMaxMana;
					if (UWCharacter.Instance.PlayerMagic.CurMana==0)
					{
						UWCharacter.Instance.PlayerMagic.CurMana = UWCharacter.Instance.PlayerMagic.MaxMana/4;
					}
				}
			}
			UWCharacter.Instance.playerMotor.movement.velocity=Vector3.zero;
			GameWorldController.instance.SwitchLevel((short)(objInt().zpos-1),objInt().quality,objInt().owner);
		}
	}

		public void ExecuteForUWDemo()
		{//IN the UW demo the level transition 
				UWHUD.instance.MessageScroll.Add("You have reached level 2 of the Underworld. This level is not in the demo.");
		}

	public override void PostActivate (object_base src)
	{//Prevent deletion of the trap

	}
}

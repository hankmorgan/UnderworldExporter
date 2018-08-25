using UnityEngine;
using System.Collections;

public class a_teleport_trap : trap_base {
    
/*
0181  a_teleport trap
	teleports the player to another level and tile; destination level is
	given by "zpos" (0 means current level), tile x/y coordinates
	are given in "quality" and "owner" fields.
*/

	public override void ExecuteTrap (object_base src, int triggerX, int triggerY, int State)
	{
		if (_RES==GAME_UWDEMO)
		{
			if (zpos!=0)
			{
				ExecuteForUWDemo();
				return;
			}
				//Special case for the UW Demo.
		}
		if (EditorMode)
		{
			return;
		}
		if ((_RES==GAME_UW2) && (UWCharacter.Instance.JustTeleported))
		{//To stop infinite level transitions in UW2
			//UWCharacter.Instance.JustTeleported=false;
			return;
		}

		float targetX=(float)quality*1.2f + 0.6f;
		float targetY= (float)owner*1.2f + 0.6f;
        //Heading
        //0=north
        //1=northeast 
        //2=east and so on
        UWCharacter.Instance.transform.eulerAngles = new Vector3(0f, ((float)heading*45f), 0f);
        UWCharacter.Instance.playerCam.transform.localRotation = Quaternion.identity;

        UWCharacter.Instance.JustTeleported=true;	
		UWCharacter.Instance.teleportedTimer=0f;

        if (zpos==0)
		{//Stay on this level.
			float Height = ((float)(CurrentTileMap().GetFloorHeight(quality,owner)))*0.15f;
			UWCharacter.Instance.transform.position = new Vector3(targetX,Height+0.5f,targetY);
			UWCharacter.Instance.TeleportPosition=UWCharacter.Instance.transform.position;
		}
		else
		{
			UWCharacter.Instance.teleportedTimer=-1f;//Longer wait period when travelling between levels.
			//Goto to another level
			if (_RES==GAME_UW1)
			{//Special case for the magic drain effect in UW1
				UWCharacter.ResetTrueMana ();
			}
			UWCharacter.Instance.playerMotor.movement.velocity=Vector3.zero;
            if ((xpos & 0x1)==1)
            {//Teleport above ground and drop down into level
                GameWorldController.instance.SwitchLevel((short)(zpos - 1), quality, owner, 24);
            }
            else
            {
                GameWorldController.instance.SwitchLevel((short)(zpos - 1), quality, owner);
            }            
        }
	}

	public void ExecuteForUWDemo()
	{//IN the UW demo the level transition 
			UWHUD.instance.MessageScroll.Add("You have reached level 2 of the Underworld. This level is not in the demo.");
	}

    public override bool WillFireRepeatedly()
    {
        return true;
    }
}

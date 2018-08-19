using UnityEngine;
using System.Collections;

public class a_hack_trap_teleport : a_hack_trap {

	public bool[] availableWorlds = new bool[8];
	public static int NoOfWorlds=0;
	const int PrisonTower=0;
	const int Killorn=1;
	const int IceCaverns =2;
	const int Talorus =3;
	const int Scintillus =4;
	const int Pits = 5;
	const int Tomb =6;
	const int EtherealVoid=7;

	short[] DestinationLevels = {8,16,24,32,40,56,48,68};
	short[] DestinationTileX = {33,27,18,32,4,59,32,33};
	short[] DestinationTileY = {32,34,39,31,38,20,32,4};
    short[] DestinationFloorHeight = { -1, -1, -1, 24, -1, -1, -1, -1 };
    //TODO: destination heights.

    public static a_hack_trap_teleport instance;

//Probably used to teleport to an other world possible based on the state of the other gem hack trap and probably based on the players position.

		//One thing to note: there is an invisible rotary switch near this trap. Making this visible and using changes the available face
		//on the gem and what level you can go to.
		//It's linked to the variable no 6 via a set_variable_trap. Seems like that variable controls what level the teleport goes to. 


		// this has a quality of 55d

	protected override void Start ()
	{
		base.Start ();
        instance = this;
		if (Quest.instance.x_clocks[1]<4)
		{
			availableWorlds[PrisonTower]=true;
			NoOfWorlds=0;
		}
		else if (Quest.instance.x_clocks[1]<8)
		{
			availableWorlds[PrisonTower]=true;
			availableWorlds[Killorn]=true;
			availableWorlds[IceCaverns]=true;
			NoOfWorlds=2;
		}
		else if (Quest.instance.x_clocks[1]<13)
		{
			availableWorlds[PrisonTower]=true;
			availableWorlds[Killorn]=true;
			availableWorlds[IceCaverns]=true;
			availableWorlds[Talorus]=true;
			availableWorlds[Scintillus]=true;
			availableWorlds[Pits]=true;
			NoOfWorlds=5;
		}
		else
		{
			availableWorlds[PrisonTower]=true;
			availableWorlds[Killorn]=true;
			availableWorlds[IceCaverns]=true;
			availableWorlds[Talorus]=true;
			availableWorlds[Scintillus]=true;
			availableWorlds[Pits]=true;
			availableWorlds[Tomb]=true;
			availableWorlds[EtherealVoid]=true;
			NoOfWorlds=7;
		}
		availableWorlds[0]=true;
	}

	public override void ExecuteTrap (object_base src, int triggerX, int triggerY, int State)
	{

        return;//This trap is just a placeholder as teleportation is now handled by a UI button that calls the TravelDirect function below
        
		int OxPos = src.xpos;
		int OyPos = src.ypos;
		int variable = Quest.instance.variables[6];

				//x and y positions are as follows.
				//2,7
				//7,3
				//5,6
				//7,4
				//6,0
				//1,6
				if (TestPosXY(OxPos, OyPos, 2,7))
				{
					//Debug.Log("Found 2,7");
					TravelToWorlds(variable, Tomb, Pits);
				}
				else if (TestPosXY(OxPos, OyPos, 7,3))
				{
					//	Debug.Log("Found 7,3");
					TravelToWorlds(variable,Scintillus, Pits);
				}
				else if (TestPosXY(OxPos, OyPos, 5,6))
				{//Always prison tower
						//Debug.Log("Found 5,6");
					//Debug.Log("Travel to world " + PrisonTower);
					TravelToWorlds(variable, PrisonTower , PrisonTower);
				}
				else if (TestPosXY(OxPos, OyPos, 7,4))
				{//Kilhorn and Ice caverns
					TravelToWorlds(variable,Killorn,IceCaverns);
				}
				else if (TestPosXY(OxPos, OyPos, 6,0))
				{
						//Debug.Log("Found 6,0");
					TravelToWorlds(variable,Talorus,Scintillus);
				}
				else if (TestPosXY(OxPos, OyPos, 1,6))
				{
						//Debug.Log("Found 4,6");
					TravelToWorlds(variable, Tomb,EtherealVoid);
				}
				else
				{
					Debug.Log("Unable to match a move trigger");
				}

	}



		/// <summary>
		/// Travels to worlds.
		/// </summary>
		/// <param name="variable">Variable.</param>
		/// <param name="world1">World1.</param>
		/// <param name="world2">World2.</param>
		/// Based on the variable value the player will travel to either world 1 or 2. 
		/// If world is unavailable it will attempt the other world.
		/// If both are unavailable no world is travelled to and the standard pushed back message is recieved.
	public void TravelToWorlds(int variable, int world1, int world2)
	{
		int WorldToGoto=-1;
		if (variable==0)
		{
			if (CheckWorldAvailabilty(world1))	
			{
				//Debug.Log("Travel to world " + world1);
				WorldToGoto=world1;				
			}
			else if (CheckWorldAvailabilty(world2))	
			{
				//Debug.Log("Travel to world " + world2);
				WorldToGoto=world2;			
			}	
		}
		else
		{
			if (CheckWorldAvailabilty(world2))	
			{
				//Debug.Log("Travel to world " + world2);
				WorldToGoto=world2;
			}	
			else if (CheckWorldAvailabilty(world1))	
			{
					//Debug.Log("Travel to world " + world1);
				WorldToGoto=world1;
			}	
		}
		if (WorldToGoto==-1)
		{
			//000~001~348~That face of the gem remains opaque, and you are bounced back. \n
			UWHUD.instance.MessageScroll.Add(StringController.instance.GetString(1,348));	
		}
		else
		{
			UWCharacter.Instance.JustTeleported=true;
			UWCharacter.Instance.teleportedTimer=0f;
			GameWorldController.instance.SwitchLevel(DestinationLevels[WorldToGoto],DestinationTileX[WorldToGoto],DestinationTileY[WorldToGoto]);	
		}
	}

	public bool CheckWorldAvailabilty(int world)
	{
		return (availableWorlds[world]);
	}


	public bool TestPosXY(int xToTest, int yToTest, int TargetX, int TargetY)
	{
		if ((xToTest==TargetX) && (yToTest==TargetY))
		{
			return true;
		}
		else
		{
			return false;
		}
	}

	public override void PostActivate (object_base src)
	{
	//no deletion
	}


    /// <summary>
    /// Shows or hides the world select UI element
    /// </summary>
    public override void Update()
    {
        base.Update();
        if (
            (TileMap.visitTileX>=27)
            &&
            (TileMap.visitTileX <= 29)
            &&
           (TileMap.visitTileY >= 39)
            &&
            (TileMap.visitTileY <= 41)
            )
        {            
            UWHUD.instance.EnableDisableControl(UWHUD.instance.WorldSelect.gameObject,
                UWHUD.instance.CURRENT_HUD_MODE != UWHUD.HUD_MODE_CONV
                && UWHUD.instance.CURRENT_HUD_MODE != UWHUD.HUD_MODE_CUTS_FULL
                && UWCharacter.InteractionMode != UWCharacter.InteractionModeOptions
                );
        }
        else
        {
            UWHUD.instance.EnableDisableControl(UWHUD.instance.WorldSelect.gameObject, false);
        }
    }

    /// <summary>
    /// Sends the player to the specified world if the game allows it based on the stored game variables
    /// </summary>
    /// <param name="World"></param>
    public void TravelDirect(int World)
    {
        if (CheckWorldAvailabilty(World))
        {
            UWHUD.instance.EnableDisableControl(UWHUD.instance.WorldSelect.gameObject, false);
            UWCharacter.Instance.JustTeleported = true;
            UWCharacter.Instance.teleportedTimer = 0f;
            GameWorldController.instance.SwitchLevel(DestinationLevels[World], DestinationTileX[World], DestinationTileY[World], DestinationFloorHeight[World]);
        }
        else
        {
            UWHUD.instance.MessageScroll.Add(StringController.instance.GetString(1, 348));
        }
    }


}

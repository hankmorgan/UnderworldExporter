using UnityEngine;
using System.Collections;

public class a_hack_trap_teleport : a_hack_trap {

	public bool[] availableWorlds = new bool[8];

	const int PrisonTower=0;
	const int Killorn=1;
	const int IceCaverns =2;
	const int Talorus =3;
	const int Scintillus =4;
	const int Pits = 5;
	const int Tomb =6;
	const int EtherealVoid=7;

	int[] DestinationLevels = {8,16,24,32,40,56,48,68};
	int[] DestinationTileX = {33,27,18,31,4,59,32,33};
	int[] DestinationTileY = {32,34,40,31,38,20,32,4};

//Probably used to teleport to an other world possible based on the state of the other gem hack trap and probably based on the players position.

		//One thing to note: there is an invisible rotary switch near this trap. Making this visible and using changes the available face
		//on the gem and what level you can go to.
		//It's linked to the variable no 6 via a set_variable_trap. Seems like that variable controls what level the teleport goes to. (untested)


		// this has a quality of 55d

	protected override void Start ()
	{
		base.Start ();
		availableWorlds[0]=true;
	}

	public override void ExecuteTrap (object_base src, int triggerX, int triggerY, int State)
	{
		int xPos = src.objInt().x;
		int yPos = src.objInt().y;
		int variable = GameWorldController.instance.variables[6];

				//x and y positions are as follows.
				//2,7
				//7,3
				//5,6
				//7,4
				//6,0
				//1,6
				if (TestPosXY(xPos,yPos, 2,7))
				{
					//Debug.Log("Found 2,7");
					TravelToWorlds(variable, Tomb, Pits);
				}
				else if (TestPosXY(xPos,yPos, 7,3))
				{
					//	Debug.Log("Found 7,3");
					TravelToWorlds(variable,Scintillus, Pits);
				}
				else if (TestPosXY(xPos,yPos, 5,6))
				{//Always prison tower
						//Debug.Log("Found 5,6");
					//Debug.Log("Travel to world " + PrisonTower);
					TravelToWorlds(variable, PrisonTower , PrisonTower);
				}
				else if (TestPosXY(xPos,yPos, 7,4))
				{//Kilhorn and Ice caverns
					TravelToWorlds(variable,Killorn,IceCaverns);
				}
				else if (TestPosXY(xPos,yPos, 6,0))
				{
						//Debug.Log("Found 6,0");
					TravelToWorlds(variable,Talorus,Scintillus);
				}
				else if (TestPosXY(xPos,yPos, 1,6))
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
			GameWorldController.instance.playerUW.JustTeleported=true;
			GameWorldController.instance.playerUW.teleportedTimer=0f;
			GameWorldController.instance.SwitchLevel(DestinationLevels[WorldToGoto],DestinationTileX[WorldToGoto],DestinationTileY[WorldToGoto]);	
		}
	}

	public bool CheckWorldAvailabilty( int world)
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

	public override void PostActivate ()
	{
	//no deletion
	}
}

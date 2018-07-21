using UnityEngine;
using System.Collections;

public class a_hack_trap_qbert : a_hack_trap {
		const int QbertColourRed=0;
		const int QbertColourGreen=1; //unused?
		const int QbertColourBlue=2;
		const int QbertColourPurple=3;
		const int QbertColourYellow=4;
		const int QbertColourOrange=5;
		const int QbertColourWhite=6;

		//const int CompletedPyramid=3569;
		//Trap used to control the qbert puzzle in the ethereal void.
		//qual=32

		//Takes a couple of parameters.
		//Owner = 0 //entrance teleport to pyramid from red hell. tells game you need to set a red pyramid.
		//owner = 2 //entrance from the blue zone
		//owner = 3 //entrance from the purple zone (stickman)
		//Owner = 4 //entrance from the green zone (maze)
		//Owner = 11 to 15 //Unknown usage possibly used for  other moongate destinations such as the sigil of binding or the shrine
		//owner = 16 //used in leaving the pyramid area and the sigil
		//Onwer = 32 //randomly takes you to a moongate of the same colour or to the matching zone for this moongate.
		//Owner = 63 //Used in stepping on the pyramid, Most steps point to one of two traps with this owner value.


		//game variables 101 to 108 are used for this trap
		//These variables track the state of the puzzle
		//101 to 105 are the colours. The colour is the texture map index
		//These values start at 0xFF and need to be set accordingly in a new game.
			//0=red
			//1=white (default)?
			//2=blue
			//3=purple
			//4=gold
			//5=orange (final)
		//106 seems to be unused.
		//107 is set to one when you are in the pyramid room.

		//On completion of the pyramid a moongate is spawned at the top of the pyramid and you can teleport to hidden rooms (for each colour)
		//or to the shrine room.
		//After the first 4 pyramids a new final moongate is spawned at the entrance to the void to take you to the 
		//final pyramid(orange)

		//when the top pyramid spawns the owner and quality target changes on the teleport trap.
		//The moongate becomes invisible.

	public override void ExecuteTrap (object_base src, int triggerX, int triggerY, int State)
	{
		switch (objInt().owner)
		{
			case 0://Exit from zones to pyramid
			case 1:
			case 2:
			case 3:
			case 4:
			case 5:
				ExitToPyramid(objInt().owner);
				break;
			case 16:
				LeaveArea();
				break;
			case 32:
			case 12:
				//GameWorldController.instance.PositionDetect();
				RandomTeleport(src);
				break;
			case 62:
				BeginQbertPyramid();
				break;
			case 63:
				//GameWorldController.instance.PositionDetect();
				StepOnPyramid(TileMap.visitTileX, TileMap.visitTileY);
				break;
			default:
				UWHUD.instance.MessageScroll.Add("Unimplemented qbert destination " + objInt().owner);
				break;
		}
	}

		/// <summary>
		/// Leave a zone and enter the pyramid
		/// </summary>
		/// <param name="colourToSet">Colour to set.</param>
	void ExitToPyramid(int colourToSet)
	{
		AddColourToQbert(colourToSet);
		//goto the pyramid from red hell.
		TeleportToLocation(68,49,51);
		UWCharacter.Instance.transform.position=new Vector3(UWCharacter.Instance.transform.position.x,4.2f,UWCharacter.Instance.transform.position.z);
		return;
	}

		/// <summary>
		/// Adds the colour to qbert sequnce of colours if not already there
		/// </summary>
		/// <param name="colourToAdd">Colour to add.</param>
	void AddColourToQbert(int colourToAdd)
	{
		int[] colourSequence=getColourSequence();
		bool ColourFound=false;
		//find red in the sequence
		for (int i =0; i<colourSequence.GetUpperBound(0);i++)
		{
			if (colourSequence[i]==colourToAdd)
			{
				ColourFound=true;
			}
		}
		if (!ColourFound)
		{
			Quest.instance.variables[101+ colourSequence.GetUpperBound(0)] = colourToAdd;
		}
	}

		/// <summary>
		/// Randomly teleports based on the moongate in the same tile
		/// </summary>
		/// <param name="src">Source.</param>
	void RandomTeleport(object_base src)
	{
		ObjectInteraction obj=null;
		if (FindMoongateInTile((int)src.objInt().tileX,(int)src.objInt().tileY,out obj))
		{//not all teleport locations are confirmed!
		switch (obj.link)
			{
			case 545://Red 
			case 557://Red on red hell
				TeleportRed(); break;
			case 591 ://blue
				TeleportBlue();break;			
			case 603: //purple
				TeleportPurple();break;
			case 528: //Yellow
				TeleportYellow();break;						
			}
		}
	}

	void TeleportRed()
	{
		switch (Random.Range(0,7))
		{//red zones.
		case 0:TeleportToLocation(68,19,3);break;
		case 1:TeleportToLocation(68,17,31);break;
		case 2:TeleportToLocation(68,22,50);break; //Sigil of binding.
		case 3:TeleportToLocation(68,46,23);break;
		case 4:
		default:
			if (GameWorldController.instance.LevelNo!=64)
			{
				TeleportToLocation(64,44,56);//To Red hell
			}
			else
			{
				TeleportToLocation(68,19,3);	
			}
			break;
						
		}		
	}

	void TeleportBlue()
	{
		switch (Random.Range(0,7))
		{//blue zones.
		case 0:TeleportToLocation(68,33,38);break;
		case 1:TeleportToLocation(68,47,14);break;
		case 2:TeleportToLocation(68,22,50);break; //Sigil of binding.
		case 3:TeleportToLocation(68,12,6);break;
		case 4:
		default:
			if (GameWorldController.instance.LevelNo!=64)
			{
				TeleportToLocation(64,10,60);//To jumpland
			}
			else
			{
				TeleportToLocation(68,33,38);	
			}
			break;
		}	
	}

	void TeleportYellow()
	{
		switch (Random.Range(0,7))
		{//yellow zones.
		case 0:TeleportToLocation(68,44,19);break;
		case 1:TeleportToLocation(68,21,17);break;
		case 2:TeleportToLocation(68,22,50);break; //Sigil of binding.
		case 3:TeleportToLocation(68,24,38);break;
		case 4:
		default:
			if (GameWorldController.instance.LevelNo!=67)
			{
				TeleportToLocation(67,2,20);//To annoying maze
			}
			else
			{
				TeleportToLocation(68,44,19);	
			}
			break;

		}	
	}

	void TeleportPurple()
	{
		switch (Random.Range(0,7))
		{//purple zones.
		case 0:TeleportToLocation(68,49,19);break;
		case 1:TeleportToLocation(68,45,38);break;
		case 2:TeleportToLocation(68,22,50);break; //Sigil of binding.
		case 3:TeleportToLocation(68,21,34);break;
		case 4:
		default:
			if (GameWorldController.instance.LevelNo!=64)
			{
				TeleportToLocation(64,26,13);//To sliding land					
			}
			else
			{
				TeleportToLocation(68,49,19);//Go back to main world
			}
			break;			
		}
	}

	void TeleportWhite()
	{
		switch (Random.Range(0,4))
		{//White zones.
		case 0:TeleportToLocation(68,13,34);break;
		case 1:TeleportToLocation(68,20,28);break;
		case 2:TeleportToLocation(68,22,50);break; //Sigil of binding.
		case 3:TeleportToLocation(68,41,4);break;						
		}	
	}

		/// <summary>
		/// Leaves the pyramid area (and others) and takes player back to the a random part of the level including the
		/// </summary>
		void LeaveArea()
		{
			TeleportWhite();			
			Quest.instance.variables[107]=0;//Flags that you have left the pyramid area
		}

		/// <summary>
		/// Begins the qbert pyramid.
		/// </summary>
		/// When you land on top of the pyramid the game needs to know you have begun stepping.
		/// If the current colour sequence is is not solved then the pyramdid can be updated.
		void BeginQbertPyramid()
		{
			//Initalises the pyramid. 
			Quest.instance.variables[107]=1;
		}

		/// <summary>
		/// Code for handling steping on the pyramid
		/// </summary>
		/// <param name="tileX">Tile x.</param>
		/// <param name="tileY">Tile y.</param>
		void StepOnPyramid(int tileX, int tileY)
		{
			int previousTileX=0;
			int previousTileY=0;
			getPreviousTileXY(out previousTileX, out previousTileY);
			if ((tileX==previousTileX) && (tileY==previousTileY))
			{
				return;
			}
			setPreviousTileXY(tileX,tileY);
			int nextColour = getNextColour(tileX,tileY);

			GameWorldController.instance.currentTileMap().Tiles[tileX,tileY].floorTexture=(short)nextColour;
			GameWorldController.instance.currentTileMap().Tiles[tileX,tileY].TileNeedsUpdate();
			GameObject tile = GameWorldController.FindTile(tileX,tileY,TileMap.SURFACE_FLOOR);
			Destroy(tile);
			
			int []ColourSequence = getColourSequence();
			int ColourTestPassed=-1;

			for (int i=0; i<=ColourSequence.GetUpperBound(0);i++)
			{
				if (CheckTileColours(ColourSequence[i]))
				{
					ColourTestPassed=ColourSequence[i];
					
					break;
				}										
			}
			if(ColourTestPassed !=-1)
			{//Set the pyramid to the colour and spawn the moongate
				//TODO:Update the walls of the pyramid here!
				SetPyramidWallColour(ColourTestPassed);
				Debug.Log("Moongate spawned");
				GameWorldController.instance.CurrentObjectList().objInfo[974].instance.setInvis(0);
				//Change the owner and quality of the telport trap at 973 based on the colour
				switch(ColourTestPassed)
				{
				case QbertColourBlue:
						GameWorldController.instance.CurrentObjectList().objInfo[973].instance.quality=4;
						GameWorldController.instance.CurrentObjectList().objInfo[973].instance.owner=16;
						break;
				case QbertColourYellow:
						GameWorldController.instance.CurrentObjectList().objInfo[973].instance.quality=4;
						GameWorldController.instance.CurrentObjectList().objInfo[973].instance.owner=28;
						break;
				case QbertColourPurple:
						GameWorldController.instance.CurrentObjectList().objInfo[973].instance.quality=4;
						GameWorldController.instance.CurrentObjectList().objInfo[973].instance.owner=22;
						break;
				case QbertColourRed:
						GameWorldController.instance.CurrentObjectList().objInfo[973].instance.quality=4;
						GameWorldController.instance.CurrentObjectList().objInfo[973].instance.owner=4;
						break;
				case QbertColourWhite:
						GameWorldController.instance.CurrentObjectList().objInfo[973].instance.quality=4;
						GameWorldController.instance.CurrentObjectList().objInfo[973].instance.owner=40;
						break;
				case QbertColourOrange://Takes you to shrine.
						GameWorldController.instance.CurrentObjectList().objInfo[973].instance.quality=32;
						GameWorldController.instance.CurrentObjectList().objInfo[973].instance.owner=25;
						break;						
				}
				if (ColourSequence.GetUpperBound(0)>=4)
				{//All normal sequences found and the pyramid has been solved at least once. Allow access to the orange pyramid
					Quest.instance.variables[105]=5;
					GameWorldController.instance.CurrentObjectList().objInfo[666].instance.setInvis(0); //my code is evil...
				}	
			}
			else
			{
				GameWorldController.instance.CurrentObjectList().objInfo[974].instance.setInvis(1);
				Debug.Log("Moongate despawned");
			}
			//}
		}

		void SetPyramidWallColour(int colourToSet)
		{
			//Outer border
			SetWallColour(44,51,colourToSet);
			SetWallColour(45,52,colourToSet);
			SetWallColour(46,53,colourToSet);
			SetWallColour(47,54,colourToSet);
			SetWallColour(48,55,colourToSet);
			SetWallColour(49,56,colourToSet);

			SetWallColour(45,51,colourToSet);
			SetWallColour(46,51,colourToSet);
			SetWallColour(47,51,colourToSet);
			SetWallColour(48,51,colourToSet);
			SetWallColour(49,51,colourToSet);

			SetWallColour(46,52,colourToSet);
			SetWallColour(47,52,colourToSet);
			SetWallColour(48,52,colourToSet);
			SetWallColour(49,52,colourToSet);

			SetWallColour(47,53,colourToSet);
			SetWallColour(48,53,colourToSet);
			SetWallColour(49,53,colourToSet);

			SetWallColour(48,54,colourToSet);
			SetWallColour(49,54,colourToSet);

			SetWallColour(49,55,colourToSet);


			/*SetWallColour(46,51,colourToSet);
			SetWallColour(46,52,colourToSet);

			SetWallColour(47,51,colourToSet);
			SetWallColour(47,52,colourToSet);
			SetWallColour(47,53,colourToSet);

			SetWallColour(48,51,colourToSet);
			SetWallColour(48,52,colourToSet);
			SetWallColour(48,53,colourToSet);
			SetWallColour(49,53,colourToSet);

			SetWallColour(50,51,colourToSet);
			SetWallColour(50,52,colourToSet);
			SetWallColour(50,53,colourToSet);
			SetWallColour(50,53,colourToSet);
			SetWallColour(50,53,colourToSet);*/

			GameWorldController.instance.currentTileMap().SetTileMapWallFacesUW();
	
				 
			DestroyTile(45,51);

			DestroyTile(46,51);
			DestroyTile(46,52);

			DestroyTile(47,51);
			DestroyTile(47,52);
			DestroyTile(47,53);

			DestroyTile(48,51);
			DestroyTile(48,52);
			DestroyTile(48,53);
			DestroyTile(48,54);

			DestroyTile(49,51);
			DestroyTile(49,52);
			DestroyTile(49,53);
			DestroyTile(49,54);
			DestroyTile(49,55);

		}

		void SetWallColour(int tileX, int tileY,int colourToSet)
		{
			GameWorldController.instance.currentTileMap().Tiles[tileX,tileY].wallTexture=(short)colourToSet;
				//Assumes tile is destroyed in destroytile below to trigger re-render
		}

		void DestroyTile(int tileX, int tileY)
		{
			GameWorldController.instance.currentTileMap().Tiles[tileX,tileY].TileNeedsUpdate();
			GameObject tile = GameWorldController.FindTile(tileX,tileY,TileMap.SURFACE_FLOOR);
			if (tile!=null)
			{
				Destroy (tile);
			}
		}

		/// <summary>
		/// Checks the tile colours versus the colour to test.
		/// </summary>
		/// <returns><c>true</c>, if tile colours was checked, <c>false</c> otherwise.</returns>
		/// <param name="ColourToTest">Colour to test.</param>
		bool CheckTileColours(int ColourToTest)
		{
			int[]TileColours=getPyramidTileColours();	
			for (int i=0; i<=TileColours.GetUpperBound(0);i++)
			{
				if (TileColours[i]!=ColourToTest)
				{
					return false;
				}
			}
			return true;
		}


		/// <summary>
		/// Gets the pyramid tile colours.
		/// </summary>
		/// <returns>The pyramid tile colours.</returns>
		int[] getPyramidTileColours()
		{
			int[]TileColours = new int[15];
			TileColours[0]=getFloorTexture(45,51);
			TileColours[1]=getFloorTexture(46,51);
			TileColours[2]=getFloorTexture(46,52);
			TileColours[3]=getFloorTexture(47,51);
			TileColours[4]=getFloorTexture(47,52);
			TileColours[5]=getFloorTexture(47,53);
			TileColours[6]=getFloorTexture(48,51);
			TileColours[7]=getFloorTexture(48,52);
			TileColours[8]=getFloorTexture(48,53);
			TileColours[9]=getFloorTexture(48,54);
			TileColours[10]=getFloorTexture(49,51);
			TileColours[11]=getFloorTexture(49,52);
			TileColours[12]=getFloorTexture(49,53);
			TileColours[13]=getFloorTexture(49,54);
			TileColours[14]=getFloorTexture(49,55);
			return TileColours;
		}


		/// <summary>
		/// Gets the previous tile X and Y that has been changed.
		/// </summary>
		/// <param name="tileX">Tile x.</param>
		/// <param name="tileY">Tile y.</param>
		void getPreviousTileXY(out int tileX, out int tileY)
		{
			int gamevar=Quest.instance.variables[108];
			tileX = gamevar  & 0x3f;
			tileY = (gamevar >> 6) & 0x3f;
		}

		void setPreviousTileXY(int tileX, int tileY)
		{
			Quest.instance.variables[108] = (tileY <<6 ) | (tileX);
		}


		/// <summary>
		/// Gets the last colour in the seqeunes that needs to be set on this pyramid.
		/// </summary>
		/// <returns>The active colour.</returns>
		/// If no colour is available use white. (should not happen)
		int getTargetColour()
		{
			int target=1;
			for (int i=101; i<=105; i++)
			{
				if (Quest.instance.variables[i]!=0xFF)
				{
					target=	Quest.instance.variables[i];
				}
				else
				{
					break;
				}
			}
			return target;
		}

		/// <summary>
		/// Gets the next colour that in the sequence af after the current tile.
		/// </summary>
		/// <returns>The next colour.</returns>
		/// <param name="tileX">Tile x.</param>
		/// <param name="tileY">Tile y.</param>
		int getNextColour(int tileX, int tileY)
		{
			int CurrentColour = getFloorTexture(tileX,tileY);
			int[] sequence = getColourSequence();
			for (int i=0; i<=sequence.GetUpperBound(0);i++)
			{
				if (sequence[i]==CurrentColour)
				{//Found colour.
					if (i<sequence.GetUpperBound(0))
					{
						return sequence[i+1];
					}
					else
					{
						return sequence[0];
					}
				}
			}
			return QbertColourWhite;
		}

		/// <summary>
		/// Gets the floor texture at the specified tile.
		/// </summary>
		/// <returns>The floor texture.</returns>
		/// <param name="tileX">Tile x.</param>
		/// <param name="tileY">Tile y.</param>
		int getFloorTexture(int tileX, int tileY)
		{
			return GameWorldController.instance.currentTileMap().Tiles[tileX,tileY].floorTexture;
		}


		/// <summary>
		/// Gets the colour sequence that the pyramid is set to cycle through.
		/// </summary>
		/// <returns>The colour sequence.</returns>
		int[] getColourSequence()
		{
			int noOfColours=0;
			for (int i=101; i<=105; i++)
			{
				if  (Quest.instance.variables[i]!=0xFF)
				{
					noOfColours++;
				}
			}
			int[] Sequence = new int[noOfColours+1];//No of unlocked colours plus the default which come last.
			Sequence[noOfColours]=QbertColourWhite;
			for (int i=101; i<=105; i++)
			{
				if  (Quest.instance.variables[i]!=0xFF)
				{
					Sequence[i-101]=Quest.instance.variables[i];
				}
				else
				{
					break;
				}
			}
			return Sequence;
		}

		/*bool isQbertSolved(int colourToTest)
		{
				int[] sequence = getColourSequence();
				for (int i=0; i<sequence.GetUpperBound(0);i++)//No need to test last colour
				{
					if (sequence[i]==colourToTest)
					{
						if (i<sequence.GetUpperBound(0)-1)
						{//Colour is not the last one in the sequence. Assume solved
								return true;
						}
						else
						{//Colour is last in sequence. Check flag value
							if (Quest.instance.variables[108]== CompletedPyramid)
							{
								return true;
							}
							else
							{
								return false;
							}
						}
					}
				}
				//the colour was not found. Assume unsolved.
				return false;
		}*/




	void TeleportToLocation(int levelNo, int tileX, int tileY)
	{
		if (GameWorldController.instance.LevelNo!=levelNo)
		{
			UWCharacter.Instance.playerMotor.movement.velocity=Vector3.zero;
			GameWorldController.instance.SwitchLevel((short)levelNo,(short)tileX,(short)tileY);
		}
		else
		{
			float targetX=(float)tileX*1.2f + 0.6f;
			float targetY= (float)tileY*1.2f + 0.6f;

			float Height = ((float)(GameWorldController.instance.currentTileMap().GetFloorHeight(tileX,tileY)))*0.15f;
			UWCharacter.Instance.transform.position = new Vector3(targetX,Height+0.3f,targetY);
			UWCharacter.Instance.TeleportPosition=UWCharacter.Instance.transform.position;	
		}
	}


	bool FindMoongateInTile(int tileX, int tileY, out ObjectInteraction obj)
	{
		ObjectLoaderInfo[] objList=GameWorldController.instance.CurrentObjectList().objInfo;
		for (int i = 0; i < 1024;i++)
		{//Make sure triggers, traps and special items are created.
			if (objList[i]!=null)
			{
				if (objList[i].GetItemType() == ObjectInteraction.MOONGATE)
				{
					if ((objList[i].tileX == tileX) && (objList[i].tileY == tileY))
					{
						obj= objList[i].instance;
						return true;
					}
				}
			}
		}
		obj=null;
		return false;
	}


	public override void PostActivate (object_base src)
	{

	}
}

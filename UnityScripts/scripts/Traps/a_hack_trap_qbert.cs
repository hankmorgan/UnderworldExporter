using UnityEngine;
using System.Collections;

public class a_hack_trap_qbert : a_hack_trap {
		const int QbertColourRed=0;
		const int QbertColourGreen=1; //unused?
		const int QbertColourBlue=2;
		const int QbertColourPurple=3;
		const int QbertColourGold=4;
		const int QbertColourOrange=5;
		const int QbertColourWhite=6;

		const int CompletedPyramid=3569;
		//Trap used to control the qbert puzzle in the ethereal void.
		//qual=32

		//Takes a couple of parameters.
		//Owner = 0 //entrance teleport to pyramid from red hell. tells game you need to set a red pyramid.
		//owner = 2 //entrance from the blue zone
		//owner = 3 //entrance from the purple zone (stickman)
		//Owner = 4 //entrance from the green zone (maze)
		//Owner = 11 to 15 //Unknown usage possibly used for  other moongate destinations such as the sigil of binding or the shrine
		//owner = 16 //used in leaving the pyramid area and the sigil

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

	public override void ExecuteTrap (object_base src, int triggerX, int triggerY, int State)
	{

				switch (objInt().owner)
				{
				case 62:
					BeginQbertPyramid();
					break;
				case 63:
					GameWorldController.instance.PositionDetect();
					StepOnPyramid(TileMap.visitTileX, TileMap.visitTileY);
					break;
				}
	}



		/// <summary>
		/// Begins the qbert pyramid.
		/// </summary>
		/// When you land on top of the pyramid the game needs to know you have begun stepping.
		/// If the current colour sequence is is not solved then the pyramdi can be updated.
		void BeginQbertPyramid()
		{
				//Initalises the pyramid. 

				if (! isQbertSolved(getTargetColour()))
				{
					GameWorldController.instance.playerUW.quest().variables[107]=1;
				}
				else
				{
					GameWorldController.instance.playerUW.quest().variables[107]=0;
				}
		}

		/// <summary>
		/// Code for handling steping on the pyramid
		/// </summary>
		/// <param name="tileX">Tile x.</param>
		/// <param name="tileY">Tile y.</param>
		void StepOnPyramid(int tileX, int tileY)
		{
			if (GameWorldController.instance.playerUW.quest().variables[107]==1)
			{
				int targetColour = getTargetColour();
				int nextColour = getNextColour(tileX,tileY);
				if (targetColour==nextColour)
				{
						//set the variable for this step
				}
				else
				{
						//clear the variable for this step
				}

				GameWorldController.instance.currentTileMap().Tiles[tileX,tileY].floorTexture=(short)nextColour;
				GameWorldController.instance.currentTileMap().Tiles[tileX,tileY].TileNeedsUpdate();
						GameObject tile = GameWorldController.FindTile(tileX,tileY,TileMap.SURFACE_FLOOR);
						Destroy(tile);
						if (GameWorldController.instance.playerUW.quest().variables[108] == CompletedPyramid)
				{
				//Turn the whole pyramid in to the target colour		
				//Spawn moongates 
				}

			}

		}



		/// <summary>
		/// Gets the target colour that needs to be set on this pyramid.
		/// </summary>
		/// <returns>The active colour.</returns>
		/// If no colour is available use white. (should not happen)
		int getTargetColour()
		{
			int target=1;
			for (int i=101; i<=105; i++)
			{
				if (GameWorldController.instance.playerUW.quest().variables[i]!=0xFF)
				{
					target=	GameWorldController.instance.playerUW.quest().variables[i];
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
					if  (GameWorldController.instance.playerUW.quest().variables[i]!=0xFF)
					{
							noOfColours++;
					}
			}
			int[] Sequence = new int[noOfColours+1];//No of unlocked colours plus the default which come last.
			Sequence[noOfColours]=QbertColourWhite;
			for (int i=101; i<=105; i++)
			{
				if  (GameWorldController.instance.playerUW.quest().variables[i]!=0xFF)
				{
					Sequence[i-101]=GameWorldController.instance.playerUW.quest().variables[i];
				}
				else
				{
					break;
				}
			}
			return Sequence;
		}

		bool isQbertSolved(int colourToTest)
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
							if (GameWorldController.instance.playerUW.quest().variables[108]== CompletedPyramid)
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
		}

}

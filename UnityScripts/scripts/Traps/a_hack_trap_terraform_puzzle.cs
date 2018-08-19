using UnityEngine;
using System.Collections;

public class a_hack_trap_terraform_puzzle : a_hack_trap {
		//Used on level 42 - scintilus academy terraforming test

		/* MAP OF ROOM
		 * 			 EXIT
				X  X  X  X  X
				
				X  X  X  X  X
				
				X  X  X  X  X
		            ENTRANCE
		 */

		//Quality is the height of the tile when set "on"
		//Bit field of the following parameters toggles the tiles as follows (bits go from exit to entrance)
		//eg x=1 will change the bottom left tile on the above map
		//x = controls the first column (left to right)
		//y = controls the second
		//heading = the third column
		//bits 0-2 of zpos = the fourth column
		//bits 3-6 of zpos = the fifth column




	public override void ExecuteTrap (object_base src, int triggerX, int triggerY, int State)
	{
		//change the x columns first
		if (xpos != 0)
		{
			ChangeColumn(triggerX,triggerY,0,xpos);
		}

		if (ypos != 0)
		{
			ChangeColumn(triggerX,triggerY,1,ypos);
		}

		if (heading!=0)
		{
			ChangeColumn(triggerX,triggerY,2,heading);
		}

		if ((zpos & 0x7)!=0)
		{
			ChangeColumn(triggerX,triggerY,3,(zpos & 0x7));
		}

		if (((zpos>>3) & 0x7)!=0)
		{
			ChangeColumn(triggerX,triggerY,4,((zpos>>3) & 0x7));
		}

	}


	public void ChangeColumn(int baseX, int baseY, int column, int bitfield)
	{
		int tileX = baseX+ (column*3);//every column of tiles

		for (int i=0; i<3;i++)	
		{
			int tileFlag=(bitfield>>i) & 0x1;
			if(tileFlag ==1)//This tile will change
			{
			int tileY = baseY+ (i*3);					
				if (GameWorldController.instance.currentTileMap().Tiles[tileX,tileY].floorHeight/2==owner-2)
				{
					GameWorldController.instance.currentTileMap().Tiles[tileX,tileY].floorHeight=4;	
				}
				else
				{
					GameWorldController.instance.currentTileMap().Tiles[tileX,tileY].floorHeight=(short)((owner-2)*2);
					if ((TileMap.visitTileX == tileX) && (TileMap.visitTileY==tileY))
					{
						UWCharacter.Instance.transform.position = GameWorldController.instance.currentTileMap().getTileVector(tileX,tileY);
					}
				}
				GameWorldController.instance.currentTileMap().Tiles[tileX,tileY].TileNeedsUpdate();
				GameObject tileToDestroy= GameWorldController.FindTile(tileX,tileY,TileMap.SURFACE_FLOOR);
				if (tileToDestroy!=null)
				{
					Destroy(tileToDestroy);
				}
			}
		}
	}
}

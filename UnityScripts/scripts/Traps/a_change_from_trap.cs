using UnityEngine;
using System.Collections;

public class a_change_from_trap : trap_base {
		//Theory. Untested 
		//This is used to change the tile type &  wall/floor texture on all tiles in a level.
		//The From trap defines the criteria
		//and the to trap defines the changes to make.
		//Heading seems to define a  floor texture to match for changing.
		//Nothing seems to define the range of tiles to change so it may be a global change
		//Therefore
		 	//Use the change_From trap to execute the changes using the values in the to trap.
			//Use the to trap as a placeholder to pass execution along in the link chain.
	


	public override void ExecuteTrap (object_base src, int triggerX, int triggerY, int State)
	{
				//return;
		//TileMap curr = GameWorldController.instance.currentTileMap();
		ObjectInteraction ChangeTo=null;
		if (objInt().link!=0)
		{
			ChangeTo = GameWorldController.instance.CurrentObjectList().objInfo[objInt().link].instance;								
		}
		if (ChangeTo==null)
		{
			return;
		}

		short NewTileFloorTexture =(short)( ChangeTo.heading |  (((ChangeTo.zpos >> 4) & 0x1 ) << 3));
		//int NewFloorHeight = ChangeTo.zpos & 0xf;
		//Debug.Log(this.name + "triggerX = " + triggerX + " triggerY = " + triggerY);
		for (int x=0; x<=63; x++)
		{
			for (int y=0; y<=63; y++)
			{
				//Every tile needs to be reset and tested again.
				 GameWorldController.instance.currentTileMap().Tiles[x,y].Render=1;		
				 GameWorldController.instance.currentTileMap().Tiles[x,y].DimX=1;			
				 GameWorldController.instance.currentTileMap().Tiles[x,y].DimY=1;			
				GameWorldController.instance.currentTileMap().Tiles[x,y].Grouped=0;	
				if ( GameWorldController.instance.currentTileMap().Tiles[x,y].floorTexture==objInt().heading)
				{	

					//Tiles[x,y].VisibleFaces = 63;
					for (int v = 0; v < 6; v++)
					{
						 GameWorldController.instance.currentTileMap().Tiles[x,y].VisibleFaces[v]=1;
						 GameWorldController.instance.currentTileMap().Tiles[x,y].VisibleFaces[v]=1;
					}


					 GameWorldController.instance.currentTileMap().Tiles[x,y].floorTexture = NewTileFloorTexture;//ChangeTo.heading;
					if (ChangeTo.owner<10)	
					{
						GameWorldController.instance.currentTileMap().Tiles[x,y].tileType=(short)ChangeTo.owner;
					}
					if (ChangeTo.zpos<15)
					{
						 GameWorldController.instance.currentTileMap().Tiles[x,y].floorHeight= ChangeTo.zpos;
					}
					if (ChangeTo.quality<63)
					{
						// GameWorldController.instance.currentTileMap().Tiles[x,y].wallTexture= ChangeTo.quality;

							//Now change neighbours
						if ( GameWorldController.instance.currentTileMap().Tiles[x,y].tileType==TileMap.TILE_SOLID)
						{
							 GameWorldController.instance.currentTileMap().Tiles[x,y].North=ChangeTo.quality;
							 GameWorldController.instance.currentTileMap().Tiles[x,y].South=ChangeTo.quality;
							 GameWorldController.instance.currentTileMap().Tiles[x,y].East=ChangeTo.quality;
							 GameWorldController.instance.currentTileMap().Tiles[x,y].West=ChangeTo.quality;
						}
						 GameWorldController.instance.currentTileMap().Tiles[x,y].wallTexture=ChangeTo.quality;

						if (y>0)
						{//Change its neighbour, only if the neighbour is not a solid
							if ( GameWorldController.instance.currentTileMap().Tiles[x,y-1].tileType>TileMap.TILE_SOLID)
							{
									 GameWorldController.instance.currentTileMap().Tiles[x,y-1].North=ChangeTo.quality;	
							}
						}

						if (y<TileMap.TileMapSizeY)
						{//Change its neighbour, only if the neighbour is not a solid
							if ( GameWorldController.instance.currentTileMap().Tiles[x,y+1].tileType>TileMap.TILE_SOLID)
							{
									 GameWorldController.instance.currentTileMap().Tiles[x,y+1].South=ChangeTo.quality;	
							}
						}

						if (x>0)
						{//Change its neighbour, only if the neighbour is not a solid
							if ( GameWorldController.instance.currentTileMap().Tiles[x-1,y].tileType>TileMap.TILE_SOLID)
							{
									 GameWorldController.instance.currentTileMap().Tiles[x-1,y].East=ChangeTo.quality;	
							}
						}

						if ( x<TileMap.TileMapSizeX)
						{//Change its neighbour, only if the neighbour is not a solid
							if ( GameWorldController.instance.currentTileMap().Tiles[x+1,y].tileType>TileMap.TILE_SOLID)
							{
									 GameWorldController.instance.currentTileMap().Tiles[x+1,y].West=ChangeTo.quality;
							}
						}
					}
				}
			}	
		}

		//Re-render the level to see the changes
		// GameWorldController.instance.currentTileMap().CleanUp(_RES);
		//TileMapRenderer.GenerateLevelFromTileMap(GameWorldController.instance.LevelModel,_RES,curr,GameWorldController.instance.CurrentObjectList());
		GameWorldController.WorldReRenderPending=true;//Request a world redraw at the next lateupdate.
		GameWorldController.FullReRender=true;

	}

}

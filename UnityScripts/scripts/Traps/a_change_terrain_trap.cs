using UnityEngine;
using System.Collections;

public class a_change_terrain_trap : trap_base {
/*
A change terrain trap changes a tile from one type to another. It works over a range of tiles that are set by the traps
x,y values. In Underworld these are set by the the relative position of the trap within the tile.
The tile it acts on is controlled by the trigger.

Examples of it's usage
The Moonstone room on Level2
The path to the sword hilt on Level3

*/

	public override void ExecuteTrap (object_base src, int triggerX, int triggerY, int State)
	{
		Debug.Log (this.name);
		int textureQuality = (objInt().quality >> 1) & 0xf;
		for (int x=0; x<=objInt().x;x++)
		{
			for (int y=0; y<=objInt().y;y++)
			{
					int tileXToChange=x+triggerX; 
					int tileYToChange=y +triggerY;
					GameObject tile = GameWorldController.FindTile(tileXToChange,tileYToChange,TileMap.SURFACE_FLOOR);
					if (tile!=null)
					{
						TileInfo tileToChange = GameWorldController.instance.currentTileMap().Tiles[tileXToChange,tileYToChange];
						//Destroy (tile);
						
						switch (_RES)
						{//I will probably have to change this again!
						//case GAME_UW2:
						//	tileToChange.floorTexture=textureQuality;
						//	break;
						default:
							if (textureQuality<10)
							{
								tileToChange.floorTexture=textureQuality;//+48;
									//tileToChange.floorTexture=GameWorldController.instance.currentTileMap().texture_map[textureQuality+48];
							}
							break;
						}

										//currobj.zpos >> 2
										//(objList[k].zpos >> 2);
						tileToChange.Render=1;
						for (int v=0;v<6;v++)
						{
							tileToChange.VisibleFaces[v]=1;		
						}
						int tileTypeToChangeTo = objInt().quality & 0x01;
						int newTileHeight = objInt().zpos>>2;
						int newWallTexture = tileToChange.wallTexture;
						if (_RES==GAME_UW2)
						{//UW2 has some slightly different behaviour to support toggling of traps
						/*if ((tileToChange.tileType==TileMap.TILE_SOLID) && (tileTypeToChangeTo== TileMap.TILE_SOLID))
							{//If the tile is already a solid then change it to an open tile at that height.
								//Debug.Log(this.name + " Terrain change height to be checked " + objInt().zpos);
								//if ((objInt().flags & 0x1) == 1)//???
								//{
								tileTypeToChangeTo=TileMap.TILE_OPEN;	
								//}								
							}
						else if ((tileToChange.tileType==TileMap.TILE_OPEN) && (tileTypeToChangeTo== TileMap.TILE_OPEN))
							{
								tileTypeToChangeTo=TileMap.TILE_SOLID;	
							}
							*/
							//Also the owner can be used to change wall texture. This means changing it's neighours.

							if (objInt().owner<63)
							{
								newWallTexture=objInt().owner;
							}


						}												

						//tileToChange.tileType=tileTypeToChangeTo;
						tileToChange.DimX=1;
						tileToChange.DimY=1;

						////tileToChange.floorHeight=newTileHeight;	
						//tileToChange.floorHeight=tileToChange.floorHeight;//DOUBLE CHECK THIS
						//tileToChange.isWater=TileMap.isTextureWater(GameWorldController.instance.currentTileMap().texture_map[ tileToChange.floorTexture]);
						//TileMapRenderer.RenderTile(GameWorldController.instance.LevelModel,tileXToChange,tileYToChange,tileToChange,tileToChange.isWater,false,false,true);
						tileToChange.TileNeedsUpdate();
						TileMapRenderer.UpdateTile(tileXToChange,tileYToChange, tileTypeToChangeTo, newTileHeight,tileToChange.floorTexture, newWallTexture ,false );
						Destroy (tile);
					}
				else
				{
					Debug.Log(this.name + " Unable to find tile for change terrain trap " + tileXToChange + " " + tileYToChange );
				}
			}	
		}
	
		GameWorldController.WorldReRenderPending=true;
			
				if ((objInt().owner<63) && (_RES==GAME_UW2))
				{
						//Now re-render the tiles and their neighbours since the wall texture has changed.
						for (int x=-1; x<=objInt().x+1;x++)
						{
								for (int y=-1; y<=objInt().y+1;y++)
								{

										int tileXToChange=x+triggerX; 
										int tileYToChange=y +triggerY;

										GameObject tile = GameWorldController.FindTile(tileXToChange,tileYToChange,TileMap.SURFACE_FLOOR);
										if (tile!=null)
										{
												Destroy (tile);
												if ( (tileXToChange >=0) && (tileXToChange <=63) &&  (tileYToChange >=0) && (tileYToChange <=63))
												{
														TileInfo tileToChange = GameWorldController.instance.currentTileMap().Tiles[tileXToChange,tileYToChange];	
														tileToChange.Render=1;
														for (int v=0;v<6;v++)
														{
																tileToChange.VisibleFaces[v]=1;		
														}
														tileToChange.isWater=TileMap.isTextureWater(GameWorldController.instance.currentTileMap().texture_map[ tileToChange.floorTexture]);
														//TileMapRenderer.RenderTile(GameWorldController.instance.LevelModel,tileXToChange,tileYToChange,tileToChange,tileToChange.isWater,false,false,true);											
														tileToChange.TileNeedsUpdate();
												}
										}
								}

						}

				}


	}

	public override void PostActivate ()
	{
	//	base.PostActivate ();
	}
}

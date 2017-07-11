using UnityEngine;
using System.Collections;

public class a_pit_trap : trap_base {


		//Quality or some portion of it appears (first 4 bits?) to define the texture of the tile to create at the base.
		//Owner does the same for the top??
		//ZPos is likely the height of the floor.


	public override void ExecuteTrap (object_base src, int triggerX, int triggerY, int State)
	{
		Debug.Log (this.name);
		int tileXToChange=triggerX; 
		int tileYToChange=triggerY;
		GameObject tile = GameWorldController.FindTile(tileXToChange,tileYToChange,TileMap.SURFACE_FLOOR);
		if (tile!=null)
		{
			TileInfo tileToChange = GameWorldController.instance.currentTileMap().Tiles[tileXToChange,tileYToChange];
			Destroy (tile);

			if (tileToChange.floorHeight==0)
			{//create a tile at the floor height
				tileToChange.floorHeight=(short)(objInt().zpos>>2);
				tileToChange.floorTexture =(short)(objInt().owner & 0xf);
			}
			else
			{
				tileToChange.floorHeight=0;	
				tileToChange.floorTexture =(short)(objInt().quality & 0xf);
			}
		TileMapRenderer.RenderTile(GameWorldController.instance.LevelModel,tileXToChange,tileYToChange,tileToChange,tileToChange.isWater,false,false,true);

		}

	}

		//Do not destroy
	public override void PostActivate ()
	{

	}
}

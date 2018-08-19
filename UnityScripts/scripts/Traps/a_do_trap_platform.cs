using UnityEngine;
using System.Collections;

public class a_do_trap_platform : a_hack_trap {

/*
Moves a tile up and down.

State is controlled by the triggering objects (eg switches)

Usage example
The platform puzzle on Level 1 leading to the grave of Korianus.
*/

	public override void ExecuteTrap (object_base src, int triggerX, int triggerY, int State)
	{
	Debug.Log (this.name);
	GameObject platformTile= GameWorldController.FindTile (triggerX,triggerY,TileMap.SURFACE_FLOOR);//Var.FindTile (Var.triggerX,Var.triggerY,1);
	//Get the height of the tile
	
	
	//if (flags==7)
	if (GameWorldController.instance.currentTileMap().Tiles[triggerX,triggerY].floorHeight>=18)	
		{
			//Move the tile to the bottom
			StartCoroutine(MoveTile (platformTile.transform, new Vector3(0f,-0.3f*7f,0f) ,0.7f));
			flags=(short)State;
			//state = 1;
			GameWorldController.instance.currentTileMap().Tiles[triggerX,triggerY].floorHeight=2;
		}
		else
		{
			//Go up a step.
			StartCoroutine(MoveTile (platformTile.transform, new Vector3(0f,0.3f,0f) ,0.1f));
			//flags=State;
			GameWorldController.instance.currentTileMap().Tiles[triggerX,triggerY].floorHeight += 2;
		}
		flags=(short)State;
	}


	protected IEnumerator MoveTile(Transform platform, Vector3 dist, float traveltime)
		{
		//Co-routine to move the tile to it's target position.
		float rate = 1.0f/traveltime;
		float index = 0.0f;
		Vector3 StartPos = platform.position;
		Vector3 EndPos = StartPos + dist;
		while (index <1.0f)
			{
			platform.position = Vector3.Lerp (StartPos,EndPos,index);
			index += rate * Time.deltaTime;
			yield return new WaitForSeconds(0.01f);
			}
		platform.position = EndPos;
		}

		public override void PostActivate (object_base src)
		{//Do not destroy.

		}
}

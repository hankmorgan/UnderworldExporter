using UnityEngine;
using System.Collections;

public class an_oscillator_trap : trap_base {

		//Theory on this. Need to prove with some hex editing.

		//X is the current direction.
		//owner is the max floor height to reach.
		//Y or zpos(likely) is possibly the min height. 
		GameObject platformTile;

	public override void ExecuteTrap (object_base src, int triggerX, int triggerY, int State)
	{
		Debug.Log (this.name);
		if  (platformTile ==  null)
		{
			platformTile =	GameWorldController.FindTile (triggerX,triggerY,TileMap.SURFACE_FLOOR);		
		}
				if  (platformTile ==  null)
				{
						return;
				}
		if (GameWorldController.instance.currentTileMap().Tiles[triggerX,triggerY].floorHeight/2>=objInt().owner)
		{
			objInt().x=0;	
		}
			else if (GameWorldController.instance.currentTileMap().Tiles[triggerX,triggerY].floorHeight/2<= objInt().quality )
		{
			objInt().x=1;	
		}

		if (objInt().x==1)
		{//moving up
			GameWorldController.instance.currentTileMap().Tiles[triggerX,triggerY].floorHeight+=2;
			StartCoroutine(MoveTile (platformTile.transform, new Vector3(0f,0.3f,0f) ,0.1f));
		}
		else
		{//moving down
			GameWorldController.instance.currentTileMap().Tiles[triggerX,triggerY].floorHeight-=2;	
			StartCoroutine(MoveTile (platformTile.transform, new Vector3(0f,-0.3f,0f) ,0.1f));
		}
	}



		protected IEnumerator MoveTile(Transform platform, Vector3 dist, float traveltime)
		{
			//Co-routine to move the tile to it's target position.
			float rate = 1.0f/traveltime;
			float index = 0.0f;
			Vector3 StartPos = platform.position;
			Vector3 EndPos = StartPos + dist;
			this.transform.position=StartPos;
			while (index <1.0f)
			{
					
					platform.position = Vector3.Lerp (StartPos,EndPos,index);
					this.transform.position=platform.position;
					index += rate * Time.deltaTime;
					yield return new WaitForSeconds(0.01f);
			}
			platform.position = EndPos;
			this.transform.position=EndPos;
		}


		public override void PostActivate ()
		{//Do not destroy.

		}
}

using UnityEngine;
using System.Collections;

public class an_oscillator_trap : trap_base {

		//Theory on this. Need to prove with some hex editing.

		//X is the current direction.
		//owner is the max floor height to reach.
		//Y or zpos(likely) is possibly the min height. 
	GameObject platformTile;



	/// <summary>
	/// The position of the center of the tile.
	/// </summary>
	public Vector3 TileVector;

	/// <summary>
	/// The tile X that contains this trigger.
	/// </summary>	
	public int TileXToWatch;

	/// <summary>
	/// The tile Y that contains this trigger.
	/// </summary>
	public int TileYToWatch;

	/// <summary>
	/// The contact area that detects the presence of objects.
	/// </summary>
	public Vector3 ContactArea= new Vector3(0.59f,0.15f,0.59f);

	/// <summary>
	/// The colliders that are in contact with the trigger.
	/// </summary>
	public Collider[] colliders;

	protected override void Start ()
	{
		base.Start ();
		TileXToWatch=objInt().tileX;
		TileYToWatch=objInt().tileY;
		TileVector=GameWorldController.instance.currentTileMap().getTileVector(TileXToWatch,TileYToWatch);
	}

	public override void ExecuteTrap (object_base src, int triggerX, int triggerY, int State)
	{
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
			TileVector=GameWorldController.instance.currentTileMap().getTileVector(TileXToWatch,TileYToWatch);
			colliders= Physics.OverlapBox(TileVector, ContactArea);
			while (index <1.0f)
			{			
				Vector3 OldPosition = platform.position;
				platform.position = Vector3.Lerp (StartPos,EndPos,index);
				//Vector3 Displacement = platform.position-OldPosition;
				float height = TileVector.y;
				MoveObjectsInContact(height);
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


		/// <summary>
		/// Moves the objects in contact.
		/// </summary>
		/// <param name="Height">Height.</param>
		/// Could be better.
		public void MoveObjectsInContact(float Height)
		{
			for (int i=0; i<=colliders.GetUpperBound(0);i++)
			{
				if (colliders[i].gameObject.GetComponent<ObjectInteraction>()!=null)
				{
					Vector3 objPosition =colliders[i].gameObject.transform.position;
					GameWorldController.UnFreezeMovement(colliders[i].gameObject);
					colliders[i].gameObject.transform.position=new Vector3(objPosition.x,Height,objPosition.z);
				}
			}
		}

}

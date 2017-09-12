using UnityEngine;
using System.Collections;


/// <summary>
/// A pressure trigger that is activated when a weight is placed or removed from a tile.
/// </summary>
/// There are multiple Item ids that have this trigger type.
/// A pressure trigger only triggers on weights put on.
/// A release trigger only triggers on weights removed. Both triggers track if the weight is on them.
/// Currently this implementation is tested for IDs 436 & 437 which change the texture of the tile.
public class a_pressure_trigger : trigger_base {

		/// <summary>
		/// The tile that triggers this transition.
		/// </summary>	
	public int TileXToWatch;
	public int TileYToWatch;

	public int TextureOn;
	public int TextureOff;

	public Collider[] colliders;

	public bool IsReleaseTrigger;

	//Any door that uses this trigger

	//public static a_pressure_trigger instance;
		//public long frameNo=0;
	public a_door_trap door; //Any door that this trigger might use

	//bool WaitingForStateChange;
	//int eventNo=0;
	//bool trigger_busy=false;
	public float WeightOnTrigger;
	public float PreviousWeightOnTrigger;
	public Vector3 TileVector;

	/*public enum PlayerContactStates{
			playerInContact,
			playerLeavesContact,
			playerNotInContact,
			playerEntersContact
	};*/

	//public PlayerContactStates playerContactState;

	protected override void Start ()
	{
		base.Start ();
		IsReleaseTrigger = ((objInt().item_id==437) || (objInt().item_id==421));
						
		TileXToWatch=objInt().tileX;
		TileYToWatch=objInt().tileY;
		TileVector=GameWorldController.instance.currentTileMap().getTileVector(TileXToWatch,TileYToWatch);

		int currentFloorTexture=GameWorldController.instance.currentTileMap().Tiles[TileXToWatch,TileYToWatch].floorTexture;
		GameWorldController.instance.currentTileMap().Tiles[TileXToWatch,TileYToWatch].PressureTriggerIndex=objInt().objectloaderinfo.index;
		/*if (objInt().y==2)
		{//Is released
				TextureOn=currentFloorTexture+1;
				TextureOff=currentFloorTexture;
		}
		else if (objInt().y==3)
		{//Is weighed down.
				TextureOn=currentFloorTexture;
				TextureOff=currentFloorTexture-1;
		}*/

		colliders= Physics.OverlapBox(TileVector, new Vector3(0.4f,0.1f,0.4f));
		WeightOnTrigger=0f;		
		for (int i=0; i<=colliders.GetUpperBound(0);i++)
		{
			if (colliders[i].gameObject.GetComponent<ObjectInteraction>()!=null)
			{
				WeightOnTrigger+= colliders[i].gameObject.GetComponent<ObjectInteraction>().GetWeight();
			}
			else if( (colliders[i].gameObject.GetComponent<UWCharacter>()!=null) ||  (colliders[i].gameObject.GetComponent<Feet>()!=null) )
			{
				WeightOnTrigger+=5000;
			}
		}
		PreviousWeightOnTrigger=WeightOnTrigger;
		Debug.Log("starting weight is " + PreviousWeightOnTrigger);

		if ( GameWorldController.instance.objectMaster.type[GameWorldController.instance.CurrentObjectList().objInfo[objInt().link].item_id]== ObjectInteraction.A_DOOR_TRAP)
		{					
			ObjectInteraction objDoorTrap=	ObjectLoader.getObjectIntAt(objInt().link);

			if (objDoorTrap!=null)
			{
				door = objDoorTrap.GetComponent<a_door_trap>();
			}
		}
	}


	public override void Update ()
	{
		base.Update();
		
		colliders= Physics.OverlapBox(TileVector, new Vector3(0.4f,0.1f,0.4f));
		WeightOnTrigger=0f;
		for (int i=0; i<=colliders.GetUpperBound(0);i++)
		{
			if (colliders[i].gameObject.GetComponent<ObjectInteraction>()!=null)
			{
				WeightOnTrigger+= colliders[i].gameObject.GetComponent<ObjectInteraction>().GetWeight();
			}
			else if( (colliders[i].gameObject.GetComponent<UWCharacter>()!=null) ||  (colliders[i].gameObject.GetComponent<Feet>()!=null) )
			{
				WeightOnTrigger+=5000;
			}
		}

		if (IsReleaseTrigger)
		{
			if ((WeightOnTrigger<1.0f) && (PreviousWeightOnTrigger>=1.0f))								
			{
				ReleaseWeightFrom();	
			}
		}
		else
		{
			if ((WeightOnTrigger>=1.0f) && (PreviousWeightOnTrigger<1.0f))								
			{
				PutWeightOn();
			}	
		}

		PreviousWeightOnTrigger=WeightOnTrigger;
				/*
		if (objInt().y==2)
		{//Needs weight
			if (WeightOnTrigger>=1.0f)
			{
				objInt().y=3;
				if (!IsReleaseTrigger)
				{
						//Debug.Log("Weighing on frame no " + frameNo+ " " + this.name);
						PutWeightOn();	
				}
				return;
			}
		}
		else if (objInt().y==3)
		{//Needs lightening.
			if (WeightOnTrigger<1.0f)
			{
				objInt().y=2;
				if (IsReleaseTrigger)
				{
					//Debug.Log("Releasing on frame no " + frameNo+ " " + this.name);
					ReleaseWeightFrom();
				}
				return;
			}	
		}*/

	
	}
	
	public void PutWeightOn()
	{
		//Debug.Log(eventNo++ + " weighing down");				
		UpdateTileTexture(GameWorldController.instance.currentTileMap().Tiles[TileXToWatch,TileYToWatch].floorTexture+1);
		if (door!=null)
		{
			door.TriggerInstantly=true;
		}
		Activate ();	
		if (door!=null)
		{
			door.TriggerInstantly=false;
		}
	}

	public void ReleaseWeightFrom()
	{
		//Debug.Log(eventNo++ + " releasing weight");		
		UpdateTileTexture(GameWorldController.instance.currentTileMap().Tiles[TileXToWatch,TileYToWatch].floorTexture-1);
		if (door!=null)
		{
			door.TriggerInstantly=true;
		}
		Activate ();	
		if (door!=null)
		{
			door.TriggerInstantly=false;
		}	
	}


	public void UpdateTileTexture(int newTexture)
	{
		//switch(objInt().item_id)
		//{
		//case 436://A pressure trigger
		//case 437://A pressure release trigger.
			GameWorldController.instance.currentTileMap().Tiles[TileXToWatch,TileYToWatch].floorTexture = (short)newTexture;
			//Tile.gameObject.GetComponent<MeshRenderer>().materials[0] =	GameWorldController.instance.MaterialMasterList[newTexture];
			GameWorldController.instance.currentTileMap().Tiles[TileXToWatch,TileYToWatch].TileNeedsUpdate();
			Destroy(GameWorldController.FindTile(TileXToWatch,TileYToWatch,TileMap.SURFACE_FLOOR));
			//Debug.Log("setting texture " + TileMapRenderer.FloorTexture(TileMap.SURFACE_FLOOR, GameWorldController.instance.currentTileMap().Tiles[objInt().tileX, objInt().tileY])) ;
			//Tile.gameObject.GetComponent<MeshRenderer>().materials[0] =	GameWorldController.instance.MaterialMasterList[TileMapRenderer.FloorTexture(TileMap.SURFACE_FLOOR, GameWorldController.instance.currentTileMap().Tiles[objInt().tileX, objInt().tileY])];
			//break;
		//default:
			//return;
		//}
	}
		/*
	bool IsTriggerWeighedDown()
	{
		return (getWeightOnTrigger() >= 10f);
	}

	bool IsTriggerLightened()
	{
		return (!IsTriggerWeighedDown());
	}*/
		/*
	public float getWeightOnTrigger()
	{
		float totalWeight=0;
		GameWorldController.instance.PositionDetect();
		if ((TileMap.visitTileX==TileXToWatch) && (TileMap.visitTileY==TileYToWatch))
		{
			totalWeight=255f;//The player is always heavy enough
		}
		else
		{
						//int ybefore=0;
						//ybefore=objInt().y;
			//	ObjectLoader.UpdateObjectList(GameWorldController.instance.currentTileMap(), GameWorldController.instance.CurrentObjectList());
						//Debug.Log("Y was " + ybefore + " is now " + objInt().y);
				int index= GameWorldController.instance.currentTileMap().Tiles[this.objInt().tileX,this.objInt().tileY].indexObjectList;
				int tileHeight = GameWorldController.instance.currentTileMap().Tiles[this.objInt().tileX,this.objInt().tileY].floorHeight;
				if (index!=0)
				{
					while (index!=0)		
					{
						if ( 
							(GameWorldController.instance.CurrentObjectList().objInfo[index].instance.zpos >=tileHeight*4)
							&&
							(GameWorldController.instance.CurrentObjectList().objInfo[index].instance.zpos <=(tileHeight*4)+2)
								)
								{
									totalWeight += GameWorldController.instance.CurrentObjectList().objInfo[index].instance.GetWeight();	
								}	
						index = GameWorldController.instance.CurrentObjectList().objInfo[index].next;
					}
				}	
		}
		//Debug.Log("total weight=" + totalWeight);
		return totalWeight;
	}
	*/


//	bool findDoorNotBusy()
	//{
	//	if (door!=null)
		//{
		//	return ! door.DoorBusy;
	//	}
	//	return true;
	//}
}

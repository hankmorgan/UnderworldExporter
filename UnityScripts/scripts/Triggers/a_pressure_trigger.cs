using UnityEngine;
using System.Collections;


/// <summary>
/// A pressure trigger that is activated when a weight is placed or removed from a tile.
/// </summary>
/// There are multiple Item ids that have this trigger type.
/// Currently this implementation is tested for IDs 436 & 437 which change the texture of the tile.
public class a_pressure_trigger : trigger_base {

		/// <summary>
		/// The tile that triggers this transition.
		/// </summary>
	public TileContactTrigger Tile;
	public int TileXToWatch;
	public int TileYToWatch;

		//Any door that uses this trigger

	public DoorControl door; //Any door that this trigger might use

	bool WaitingForStateChange;
	int eventNo=0;
		bool trigger_busy=false;

	public enum PlayerContactStates{
			playerInContact,
			playerLeavesContact,
			playerNotInContact,
			playerEntersContact
	};

	public PlayerContactStates playerContactState;

	protected override void Start ()
	{
		base.Start ();
		TileXToWatch=objInt().tileX;
		TileYToWatch=objInt().tileY;
		if ((TileXToWatch==TileMap.visitTileX) && (TileXToWatch==TileMap.visitTileX))
		{
			playerContactState=PlayerContactStates.playerInContact;
		}
		else
		{
			playerContactState=PlayerContactStates.playerNotInContact;
		}
		LinkContact();
	}

	void LinkContact()
	{
		GameObject TileGameObject = GameWorldController.FindTile(objInt().tileX,objInt().tileY,TileMap.SURFACE_FLOOR);
		if (TileGameObject!=null)
		{
			Tile = TileGameObject.AddComponent<TileContactTrigger>();	
			Tile.triggerToUse=this;
			TileXToWatch=objInt().tileX;
			TileYToWatch=objInt().tileY;
		}	

		if ( GameWorldController.instance.objectMaster.type[GameWorldController.instance.CurrentObjectList().objInfo[objInt().link].item_id]== ObjectInteraction.A_DOOR_TRAP)
		{
			ObjectInteraction objDoorTrap=	ObjectLoader.getObjectIntAt(objInt().link);
			if (objDoorTrap!=null)
			{
				GameObject doorObj = GameWorldController.findDoor(objDoorTrap.quality,objDoorTrap.owner);
				if(doorObj!=null)
				{
					door=doorObj.GetComponent<DoorControl>();
				}
			}
		}
	}

	public override void Update ()
	{
		base.Update();
		if (Tile==null)
		{
			LinkContact();	
		}
		else
		{
			UpdatePlayerContactState ();
		}
	}

	bool UpdatePlayerContactState ()
	{
		switch (playerContactState) {
		case PlayerContactStates.playerInContact:
			//Player is in this tile. Check if player leaves.
			trigger_busy=false;
			if (! isPlayerGroundedInTile() ) 
			{
				playerContactState = PlayerContactStates.playerLeavesContact;
				return true;
			}
			break;
		case PlayerContactStates.playerLeavesContact:
			if ((findDoorNotBusy ()) && (!trigger_busy)) 
				{
				Debug.Log (eventNo++ + " player leaves contact due to free door");
				playerContactState = PlayerContactStates.playerNotInContact;
				ReleaseWeightFrom ();
				trigger_busy=true;
				return true;
			}
			else 
			{
				Debug.Log (eventNo++ + " player waiting on door to become free. will leave contact when this happens");
			}
			break;
		case PlayerContactStates.playerNotInContact:
			//Check if player enters contact
			trigger_busy=false;
			if (isPlayerGroundedInTile()) 
			{
				playerContactState = PlayerContactStates.playerEntersContact;
				return true;
			}
			break;
		case PlayerContactStates.playerEntersContact:
			if ((findDoorNotBusy ()) && (!trigger_busy)) 
			{
				Debug.Log (eventNo++ + " player in contact and door is free");
				playerContactState = PlayerContactStates.playerInContact;
				PutWeightOn ();
				trigger_busy=true;
				return true;
			}				
			else 
			{
				Debug.Log (eventNo++ + " player enters contact and is waiting on door");
			}
			break;
		}
		return false;
	}


		public bool isPlayerGroundedInTile()
		{
			GameWorldController.instance.PositionDetect();
			return 
					(
							(
								(TileXToWatch == TileMap.visitTileX)
								&&
								(TileXToWatch == TileMap.visitTileX) 
							)
							&& 
								(TileMap.OnGround)
					)	;
		}

	public bool PutWeightOn()
	{
		if(door!=null)
		{
			if (door.DoorBusy)
			{
				return false;
			}
		}

		if (IsTriggerWeighedDown())
		{
			if(objInt().y==2)//This is the behaviour in scintillus academy. Untested on other locations
			{
				Debug.Log(eventNo++ + " weighing down");
				objInt().y=3;
				UpdateTileTexture(1);
				Activate ();			
			}				
			return true;
		}
		else
		{
			return false;//ReleaseWeightFrom();
		}
	}

	public bool ReleaseWeightFrom()
	{
		if(door!=null)
		{
			if (door.DoorBusy)
			{
				return false;
			}
		}

		if (IsTriggerLightened())
		{
			if (objInt().y==3)//This is the behaviour in scintillus academy. Untested on other locations
			{
				Debug.Log(eventNo++ + " releasing weight");
				objInt().y=2;
				UpdateTileTexture(-1);
				Activate ();		
				return true;	
			}
			else
			{
				return false;
			}
		}
		else
		{
			return false;//PutWeightOn();
		}	
	}


	public void UpdateTileTexture(int dir)
	{
		switch(objInt().item_id)
		{
		case 436://A pressure trigger
		case 437://A pressure release trigger.
			GameWorldController.instance.currentTileMap().Tiles[objInt().tileX, objInt().tileY].floorTexture += (short)dir;
			GameWorldController.instance.currentTileMap().Tiles[objInt().tileX, objInt().tileY].TileNeedsUpdate();
			Destroy(Tile.gameObject);
			//Debug.Log("setting texture " + TileMapRenderer.FloorTexture(TileMap.SURFACE_FLOOR, GameWorldController.instance.currentTileMap().Tiles[objInt().tileX, objInt().tileY])) ;
			//Tile.gameObject.GetComponent<MeshRenderer>().materials[0] =	GameWorldController.instance.MaterialMasterList[TileMapRenderer.FloorTexture(TileMap.SURFACE_FLOOR, GameWorldController.instance.currentTileMap().Tiles[objInt().tileX, objInt().tileY])];
			break;
		default:
			return;
		}
	}

	bool IsTriggerWeighedDown()
	{
		return (getWeightOnTrigger() >= 10f);
	}

	bool IsTriggerLightened()
	{
		return (!IsTriggerWeighedDown());
	}

	public float getWeightOnTrigger()
	{
		float totalWeight=0;
		GameWorldController.instance.PositionDetect();
		if ((TileMap.visitTileX==objInt().tileX) && (TileMap.visitTileY==objInt().tileY))
		{
				totalWeight=255f;//The player is always heavy enough
		}
		else
		{
				ObjectLoader.UpdateObjectList(GameWorldController.instance.currentTileMap(), GameWorldController.instance.CurrentObjectList());
				int index= GameWorldController.instance.currentTileMap().Tiles[this.objInt().tileX,this.objInt().tileY].indexObjectList;

				if (index!=0)
				{
						while (index!=0)		
						{
								totalWeight += GameWorldController.instance.CurrentObjectList().objInfo[index].instance.GetWeight();
								index = GameWorldController.instance.CurrentObjectList().objInfo[index].next;
						}
				}	
		}
		return totalWeight;
	}


	bool findDoorNotBusy()
	{
		if (door!=null)
		{
			return ! door.DoorBusy;
		}
		return true;
	}
}

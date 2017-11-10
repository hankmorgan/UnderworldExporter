using UnityEngine;
using System.Collections;

public class a_move_trigger : trigger_base {
/*
A trigger that fires when the player character enters it
*/
	bool playerStartedInTrigger=false;
	
	protected override void Start ()
	{
				
		base.Start ();
		if ( (TileMap.visitTileX==objInt().tileX) && (TileMap.visitTileY==objInt().tileY))
		{//TODO:do this based on trigger box
			playerStartedInTrigger=true;
		}
		BoxCollider box=this.gameObject.AddComponent<BoxCollider>();
		//box.transform.position = this.gameObject.transform.position;
		//box.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
		box.size = new Vector3(1.2f, 1.2f, 1.2f);

		box.isTrigger=true;
		Collider[] colliders=Physics.OverlapBox(this.transform.position, box.size);
		for (int i=0; i<=colliders.GetUpperBound(0);i++)
		{
			if( (colliders[i].gameObject.GetComponent<UWCharacter>()!=null) ||  (colliders[i].gameObject.GetComponent<Feet>()!=null) )
			{
				playerStartedInTrigger=true;
				break;
			}
		}

		//Check if this trap points to a teleport trap that goes to another level
		if ( (objInt().tileX<TileMap.TileMapSizeX) && (objInt().tileY<TileMap.TileMapSizeY))
		{
			if (objInt().link!=0)
			{
				GameObject triggerObj = ObjectLoader.getGameObjectAt(objInt().link);
				if (triggerObj!=null)
				{
					if (triggerObj.GetComponent<a_teleport_trap>() !=null)
					{
						if (triggerObj.GetComponent<a_teleport_trap>().objInt().zpos!=0)
						{
							//if (_RES==GAME_UW1)
							//{
							GameWorldController.instance.currentAutoMap().MarkTileDisplayType(objInt().tileX, objInt().tileY, AutoMap.DisplayTypeStair);
							//}						
						}
					}
				}	
			}	
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (playerStartedInTrigger!=true)
		{
			if (((other.name==GameWorldController.instance.playerUW.name) || (other.name=="Feet")) && (!GameWorldController.EditorMode))
			{
				Debug.Log(this.name);
				Activate ();
			}	
		}
		else
		{
			playerStartedInTrigger=false;
		}
	}
}

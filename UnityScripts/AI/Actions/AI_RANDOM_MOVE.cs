using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Action;
using RAIN.Core;

[RAINAction]
public class AI_RANDOM_MOVE : RAINAction
{
    public override void Start(RAIN.Core.AI ai)
    {
        base.Start(ai);
    }

    public override ActionResult Execute(RAIN.Core.AI ai)
    {
		//TODO:replace target selection with something based off of the tilemap.
		//if (ai.Navigator.CurrentGraph==null)
		//{
		NPC npc=ai.Body.gameObject.GetComponent<NPC>();
		string navmesh= npc.NavMeshRegion;//ai.Body.gameObject.GetComponent<NPC>().NavMeshRegion;
		ai.Navigator.CurrentGraph = RAIN.Navigation.NavigationManager.Instance.GetNavigationGraph (navmesh);
		int distanceMultipler=1;//For frightened NPCs
		if (npc.state==6)
		{
			distanceMultipler=3;//Runs far away.
		}

		if (ai.Navigator.CurrentGraph==null)
		{
			return ActionResult.FAILURE;
		}
		//Get a random spot.
		bool DestFound=false;
		Vector3 curPos = ai.Body.transform.position;
		Vector3 dest =curPos;//= new Vector3(curPos.x+RndSphere.x, curPos.y, curPos.z+RndSphere.z);
		int tileX = (int)(curPos.x/1.2f);
		int tileY = (int)(curPos.z/1.2f);
		int newTileX=tileX;
		int newTileY=tileY;
		for (int i=0; i<5;i++)
		{
			newTileX = tileX + Random.Range(-2*distanceMultipler,3*distanceMultipler);
			newTileY = tileY + Random.Range(-2*distanceMultipler,3*distanceMultipler);
			if (GameWorldController.instance.Tilemap.GetTileType(newTileX,newTileY) != TileMap.TILE_SOLID)
			{
				DestFound=true;
				break;
			}	
			if (DestFound==false)
			{
				newTileX=tileX;
				newTileY=tileY;
			}
		}

		//Move back home if too far away
		float yDist2=Mathf.Pow(newTileY-npc.npc_yhome,2f);
		float xDist2=Mathf.Pow(newTileX-npc.npc_xhome,2f);
		if (yDist2+xDist2>=10)
		{
				newTileY=npc.npc_yhome;	
				newTileX=npc.npc_xhome;	
		}
			
		//Vector3 RndSphere = Random.insideUnitSphere *((float)Random.Range(0,5));
		//dest = new Vector3(curPos.x+RndSphere.x, curPos.y, curPos.z+RndSphere.z);

		//dest =  ai.Navigator.CurrentGraph.ClosestPointOnGraph(dest,1000f);
		dest= GameWorldController.instance.Tilemap.getTileVector(newTileX,newTileY);


		ai.WorkingMemory.SetItem<bool>("isMovingRandom",true);
		ai.WorkingMemory.SetItem<Vector3>("moveStartPoint", curPos);   //, curPos);
		ai.WorkingMemory.SetItem<Vector3>("MoveTarget",dest);
        return ActionResult.SUCCESS;
    }

    public override void Stop(RAIN.Core.AI ai)
    {
        base.Stop(ai);
    }
}
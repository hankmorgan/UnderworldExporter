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
		//if (ai.Navigator.CurrentGraph==null)
		//{
			string navmesh= ai.Body.gameObject.GetComponent<NPC>().NavMeshRegion;
			ai.Navigator.CurrentGraph = RAIN.Navigation.NavigationManager.Instance.GetNavigationGraph (navmesh);
		if (ai.Navigator.CurrentGraph==null)
		{
			return ActionResult.FAILURE;
		}
		//Get a random spot.
		Vector3 curPos = ai.Body.transform.position;
		Vector3 dest =curPos;//= new Vector3(curPos.x+RndSphere.x, curPos.y, curPos.z+RndSphere.z);
	//	bool flag=false; int counter=0;
		//TODO Make curPos.y the floor of the destination.

		//while ((flag==false) && (counter<1))
		//{
			Vector3 RndSphere = Random.insideUnitSphere *((float)Random.Range(0,5));
			dest = new Vector3(curPos.x+RndSphere.x, curPos.y, curPos.z+RndSphere.z);


		//dest = new Vector3(RndSphere.x, curPos.y, RndSphere.z);


		//ai.WorkingMemory.SetItem<Vector3>("originalDest",ai.Body.transform.position);
			
		dest =  ai.Navigator.CurrentGraph.ClosestPointOnGraph(dest,1000f);

		//flag = (GoblinAI.tm.ValidTile(dest));
		//	counter++;
		//}

	//if (flag==false)
	//	{
			//Debug.Log ("unable to get a valid dest");
			//dest=curPos;//Stay where you are.
	//	}


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
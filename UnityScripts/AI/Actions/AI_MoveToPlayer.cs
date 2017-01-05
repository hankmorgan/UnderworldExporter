using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Action;
using RAIN.Core;

[RAINAction]
public class AI_MoveToPlayer : RAINAction
{
    public override void Start(RAIN.Core.AI ai)
    {
        base.Start(ai);
    }

    public override ActionResult Execute(RAIN.Core.AI ai)
    {
		//GoblinAI gob=  ai.Body.GetComponent<GoblinAI>();
		//gob.AnimRange=GoblinAI.AI_RANGE_MOVE;
		//if (ai.Navigator.CurrentGraph==null)
	//	{
			string navmesh= ai.Body.gameObject.GetComponent<NPC>().NavMeshRegion;
			ai.Navigator.CurrentGraph = RAIN.Navigation.NavigationManager.Instance.GetNavigationGraph (navmesh);
		//}

	//	Debug.Log (RAIN.Navigation.NavigationManager.Instance.NavigationGraphs.Count);
	
		RAIN.Navigation.Graph.RAINNavigationGraph graph = ai.Navigator.CurrentGraph;
		if (graph!=null)
		{
			/*Debug.Log (graph.GraphName);*/
			//GameObject player = NPC.playerUW.gameObject;//ai.WorkingMemory.GetItem<GameObject>("playerUW");
			//NPC.playerUW.gameObject
			//Vector3 point = player.transform.position;
			/*Vector3 ClosestPoint;
			ClosestPoint=graph.ClosestPointOnGraph(point,1000f);
			Debug.Log (point + " goes to " + ClosestPoint + " on graph " + graph.GraphName);
			ai.WorkingMemory.SetItem<Vector3>("MoveTarget",ClosestPoint);*/

			NPC npc = ai.Body.GetComponent<NPC>();
			if (npc!=null)
			{
				if (npc.gtarg!=null)
				{
					//AB between player and npc
					Vector3 AB = npc.gtarg.transform.position-ai.Body.gameObject.transform.position;
					Vector3 Movepos = npc.gtarg.transform.position + (0.31f * AB.normalized) ;
					ai.WorkingMemory.SetItem<Vector3>("MoveTarget",Movepos);	
				}	
			}

			return ActionResult.SUCCESS;
		}
		else
		{
			Debug.Log ("Unable to find Graph " + navmesh + " for  " + ai.Body.gameObject.name);
			return ActionResult.FAILURE;
		}

        
    }

    public override void Stop(RAIN.Core.AI ai)
    {
        base.Stop(ai);
    }
}
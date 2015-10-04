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
		if (ai.Navigator.CurrentGraph==null)
		{
			ai.Navigator.CurrentGraph = RAIN.Navigation.NavigationManager.Instance.GetNavigationGraph ("GroundMesh2");
		}

	//	Debug.Log (RAIN.Navigation.NavigationManager.Instance.NavigationGraphs.Count);
	
		RAIN.Navigation.Graph.RAINNavigationGraph graph = ai.Navigator.CurrentGraph;
		if (graph!=null)
		{
			/*Debug.Log (graph.GraphName);*/
			GameObject player = NPC.playerUW.gameObject;//ai.WorkingMemory.GetItem<GameObject>("playerUW");
			//NPC.playerUW.gameObject
			//Vector3 point = player.transform.position;
			/*Vector3 ClosestPoint;
			ClosestPoint=graph.ClosestPointOnGraph(point,1000f);
			Debug.Log (point + " goes to " + ClosestPoint + " on graph " + graph.GraphName);
			ai.WorkingMemory.SetItem<Vector3>("MoveTarget",ClosestPoint);*/
			ai.WorkingMemory.SetItem<Vector3>("MoveTarget",player.transform.position);
			return ActionResult.SUCCESS;
		}
		else
		{
			Debug.Log ("Unable to find Graph");
			return ActionResult.FAILURE;
		}

        
    }

    public override void Stop(RAIN.Core.AI ai)
    {
        base.Stop(ai);
    }
}
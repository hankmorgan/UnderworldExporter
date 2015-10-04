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
		if (ai.Navigator.CurrentGraph==null)
		{
			ai.Navigator.CurrentGraph = RAIN.Navigation.NavigationManager.Instance.GetNavigationGraph ("GroundMesh2");
		}
		//Get a random spot.
		Vector3 curPos = ai.Body.transform.position;
		Vector3 dest =curPos;//= new Vector3(curPos.x+RndSphere.x, curPos.y, curPos.z+RndSphere.z);
		bool flag=false; int counter=0;
		//TODO Make curPos.y the floor of the destination.

		while ((flag==false) && (counter<1))
		{
			Vector3 RndSphere = Random.onUnitSphere*((float)Random.Range(1,4));
			dest = new Vector3(curPos.x+RndSphere.x, curPos.y, curPos.z+RndSphere.z);
			flag = (GoblinAI.tm.ValidTile(dest));
			counter++;
		}

	if (flag==false)
		{
			//Debug.Log ("unable to get a valid dest");
			//dest=curPos;//Stay where you are.
		}


		ai.WorkingMemory.SetItem<bool>("isMovingRandom",true);
		ai.WorkingMemory.SetItem<Vector3>("moveStartPoint",ai.Body.transform.position);
		ai.WorkingMemory.SetItem<Vector3>("MoveTarget",dest);
        return ActionResult.SUCCESS;
    }

    public override void Stop(RAIN.Core.AI ai)
    {
        base.Stop(ai);
    }
}